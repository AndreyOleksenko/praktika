using System;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ClimateRepair
{

    public partial class Profile : Form
    {
        private DataGridViewRow selectedMasterRow;
        private string master;
        private bool showingIncompleteOnly = false;
        private int userRole;
        private string userLog;
        private int clientId;
        private string connectionString = @"Data Source=ADCLG1;Initial Catalog=OleksenkoPract;Integrated Security=True";
        //@"Data Source=ADCLG1;Initial Catalog=OleksenkoPract;Integrated Security=True";

        public Profile(int role, string usLog)
        {
            userRole = role;
            userLog = usLog;

            InitializeComponent();
            LoadClientId();
            LoadUserDetails();
            LoadMasterDGV();
            usLogLabel.Text = "Вы вошли как: " + userLog;
            switch(userRole)
            {
                case 3:
                    clientPanel.Visible = false;
                    masterPanel.Location = new Point(5, 181);
                    break;
                case 1:
                    button2.Location = new Point(12, 300); 
                    clientPanel.Visible = false;
                    masterPanel.Visible = false;
                    Size = new Size(924, 403);
                    break;
                case 2:
                    button2.Location = new Point(12, 300);
                    clientPanel.Visible = false;
                    masterPanel.Visible = false;
                    Size = new Size(924, 403);
                    break;
                case 4:
                    break;
            }
        }

        private void filterButton_Click(object sender, EventArgs e)
        {
            // Переключаем флаг
            showingIncompleteOnly = !showingIncompleteOnly;

            // Меняем текст кнопки в зависимости от состояния флага
            filterButton.Text = showingIncompleteOnly ? "Показать все" : "Показать незавершенные";
            LoadMasterDGV();
        }

        private void LoadMasterDGV() 
        {
            string query = @"
    SELECT 
        R.RequestID,
        R.ProblemDescription,
        U.FullName AS ClientName,
        ET.TypeName AS EquipmentType,
        E.Model AS EquipmentModel,
        R.RepairParts,
        R.StartDate,
        R.CompletionDate,
        RS.StatusName,
        C.Message AS CommentMessage
    FROM Requests R
    LEFT JOIN Users U ON R.ClientID = U.UserID
    LEFT JOIN Equipment E ON R.EquipmentID = E.EquipmentID
    LEFT JOIN EquipmentTypes ET ON E.TypeID = ET.TypeID
    LEFT JOIN RequestStatuses RS ON R.StatusID = RS.StatusID
    LEFT JOIN Comments C ON R.RequestID = C.RequestID AND R.MasterID = C.MasterID  -- Связь с таблицей комментариев
    WHERE R.MasterID = @MasterID";

            // Добавляем условие для фильтрации незавершенных заявок, если флаг установлен
            if (showingIncompleteOnly)
            {
                query += " AND RS.StatusName NOT LIKE N'Завершена'";
            }

            query += " ORDER BY R.StartDate";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MasterID", clientId);
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                MasterDGV.Rows.Clear(); 

                while (reader.Read())
                {
                    MasterDGV.Rows.Add(
                        reader["ClientName"].ToString(),
                        reader["EquipmentType"].ToString(),
                        reader["EquipmentModel"].ToString(),
                        reader["ProblemDescription"].ToString(),
                        reader["RepairParts"].ToString(),
                        reader["StartDate"] == DBNull.Value ? "" : Convert.ToDateTime(reader["StartDate"]).ToString("yyyy-MM-dd"),
                        reader["CommentMessage"].ToString(),
                        reader["CompletionDate"] == DBNull.Value ? "" : Convert.ToDateTime(reader["CompletionDate"]).ToString("yyyy-MM-dd"),
                        reader["StatusName"].ToString(),
                        reader["RequestID"]
                    );
                }
            }
        }
        private void reportButton_Click(object sender, EventArgs e)
        {
            if (MasterDGV.SelectedRows.Count > 0)
            {
                // Извлекаем данные из выбранной строки
                DataGridViewRow selectedRow = MasterDGV.SelectedRows[0];

                string clientName = selectedRow.Cells["ClientName"].Value.ToString();
                string startDate = selectedRow.Cells["StartDate"].Value.ToString();
                string repairParts = selectedRow.Cells["RepairParts"].Value.ToString();
                string reqID = selectedRow.Cells["clintreqID"].Value.ToString();


                Reports reports = new Reports(clientName, startDate, repairParts, reqID);
                reports.ShowDialog();
            }
        }

        private void MasterDGV_SelectionChanged(object sender, EventArgs e)
        {
            if (MasterDGV.SelectedRows.Count > 0)
            {
                string status = MasterDGV.SelectedRows[0].Cells["StatusM"].Value.ToString();
                reportButton.Enabled = status != "Завершена";
                editForMasterButton.Enabled = true;
            }
            else
            {
                reportButton.Enabled = false;
                editForMasterButton.Enabled = false;
            }
        }

        private void editForMasterButton_Click(object sender, EventArgs e)
        {
            selectedMasterRow = MasterDGV.SelectedRows[0];

            MasterDGV.ReadOnly = false;
            selectedMasterRow.Cells["ClientName"].ReadOnly = true;
            selectedMasterRow.Cells["EqType"].ReadOnly = true;
            selectedMasterRow.Cells["EqMod"].ReadOnly = true;
            selectedMasterRow.Cells["Descript"].ReadOnly = true;
            selectedMasterRow.Cells["StartDate"].ReadOnly = true;
            selectedMasterRow.Cells["EndDate"].ReadOnly = true;
            selectedMasterRow.Cells["StatusM"].ReadOnly = true;

            confirmButton.Visible = true;
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            int requestId = Convert.ToInt32(selectedMasterRow.Cells["clintreqID"].Value);
            string repParts = selectedMasterRow.Cells["RepairParts"].Value.ToString();
            string comment = selectedMasterRow.Cells["Comment"].Value?.ToString();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Обновление полей RepairParts
                string updateRequestQuery = @"UPDATE Requests 
                                      SET RepairParts = @RepParts
                                      WHERE RequestID = @RequestID";

                using (SqlCommand cmdRequest = new SqlCommand(updateRequestQuery, conn))
                {
                    cmdRequest.Parameters.AddWithValue("@RepParts", repParts);
                    cmdRequest.Parameters.AddWithValue("@RequestID", requestId);
                    cmdRequest.ExecuteNonQuery();
                }

                // Вставка комментария, только если поле не пустое
                if (!string.IsNullOrWhiteSpace(comment))
                {
                    string insertCommentQuery = @"INSERT INTO Comments 
                                          (Message, MasterID, RequestID) 
                                          VALUES(@Comment, @MasterID, @RequestID)";

                    using (SqlCommand cmdComment = new SqlCommand(insertCommentQuery, conn))
                    {
                        cmdComment.Parameters.AddWithValue("@Comment", comment);
                        cmdComment.Parameters.AddWithValue("@MasterID", clientId);
                        cmdComment.Parameters.AddWithValue("@RequestID", requestId);
                        cmdComment.ExecuteNonQuery();
                    }
                }
            }

            confirmButton.Visible = false;
            MessageBox.Show("Изменения успешно сохранены.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

            MasterDGV.ReadOnly = true;
            LoadMasterDGV();
        }



        private void LoadUserDetails()
        {
            string query = @"SELECT UT.TypeName, U.ProfilePicture, U.FullName, U.Phone
             FROM Users U 
             INNER JOIN UserTypes UT ON U.UserTypeID = UT.UserTypeID 
             WHERE U.UserID = @UserID";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserID", clientId);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    phoneTextBox.Text = reader["Phone"].ToString();
                    UsRoleLabel.Text = "Ваша роль: " + reader["TypeName"].ToString();
                    FIOLabel.Text = "ФИО: " + reader["FullName"].ToString();

                    if (reader["ProfilePicture"] != DBNull.Value)
                    {
                        string picturePath = reader["ProfilePicture"].ToString();

                        // Проверка существования изображения и его загрузка
                        if (File.Exists(picturePath))
                        {
                            ProfilePictureBox.Image = Image.FromFile(picturePath);
                        } 
                    }
                }
            }

        }
    
        private void LoadClientId()
        {
           
            string query = "SELECT UserID FROM Users WHERE Login = @Login";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Login", userLog);

                conn.Open();
                object result = cmd.ExecuteScalar();

                if (result != null)
                {
                    clientId = Convert.ToInt32(result);
                    LoadRequestsData(clientId);
                }
                else
                {
                    MessageBox.Show("Не удалось загрузить данные пользователя.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            LoadAllEquipmentTypes();
        }

        private void requestsDGV_SelectionChanged(object sender, EventArgs e)
        {
            if (requestsDGV.SelectedRows.Count > 0)
            {
                master = requestsDGV.SelectedRows[0].Cells["Master0"].Value.ToString();
                string status = requestsDGV.SelectedRows[0].Cells["Status"].Value.ToString();
                changeReqButton.Enabled = status != "Завершена";

                if (status == "Завершена")
                {
                    reportCheckButton.Visible = true;
                }
                else
                {
                    reportCheckButton.Visible = false;
                }
            }
            else
            {
                reportCheckButton.Visible = false;
                changeReqButton.Enabled = false;
            }
        }

        private void reportCheckButton_Click(object sender, EventArgs e)
        {

            if (requestsDGV.SelectedRows.Count == 0) return;

            // Получаем ID заявки
            int requestId = Convert.ToInt32(requestsDGV.SelectedRows[0].Cells["reqID"].Value);

            // Переменные для хранения данных отчета
            string reportDate = string.Empty;
            string reportDetails = string.Empty;

            string query = "SELECT ReportDate, ReportDetails FROM Reports WHERE RequestID = @RequestID";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@RequestID", requestId);
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                // Извлекаем данные из отчета
                if (reader.Read())
                {
                    reportDate = reader["ReportDate"].ToString();
                    reportDetails = reader["ReportDetails"].ToString();
                }
            }

            string fio = FIOLabel.Text.Substring(4);
            // Формируем текст отчета
            string report = $"Клиент: {fio}\nМастер: {master}\nДата отчета: {reportDate}\nДетали: {reportDetails}";

            // Открываем форму отчета с QR-кодом
            using (ReportDialog dialog = new ReportDialog(report))
            {
                dialog.ShowDialog();
            }

            // Скрываем кнопку после просмотра отчета
            reportCheckButton.Visible = false;
        }

        private void leaveButton_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            Hide();
        }

        private void addReqButton_Click(object sender, EventArgs e)
        {
            CreateRequest createRequest = new CreateRequest(userRole, userLog);
            createRequest.Show();
            Hide();

        }

        private void editProfileButton_Click(object sender, EventArgs e)
        {
            FIOTextBox.Visible = true;
            editPicButton.Visible = true;
            yesButton.Visible = true;
            phoneTextBox.Enabled = true;
            string connectionString = @"Data Source=ADCLG1;Initial Catalog=OleksenkoPract;Integrated Security=True";
            string query = "SELECT FullName, ProfilePicture, Phone FROM Users WHERE UserID = @UserID";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserID", clientId);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    FIOTextBox.Text = reader["FullName"].ToString();
                    string profilePicturePath = reader["ProfilePicture"].ToString();
                    if (!string.IsNullOrEmpty(profilePicturePath) && File.Exists(profilePicturePath))
                    {
                        ProfilePictureBox.Image = Image.FromFile(profilePicturePath);
                    }
                }
            }

        }

        private void editPicButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    ProfilePictureBox.Image = Image.FromFile(openFileDialog.FileName);
                }
            }
        }

        private void yesButton_Click(object sender, EventArgs e)
        {
            string updateQuery = @"UPDATE Users SET FullName = @FullName, ProfilePicture = @ProfilePicture, Phone = @Phone WHERE UserID = @UserID";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@Phone", phoneTextBox.Text);
                    cmd.Parameters.AddWithValue("@FullName", FIOTextBox.Text);
                    cmd.Parameters.AddWithValue("@UserID", clientId);

                    if (ProfilePictureBox.Image != null)
                    {
                        try
                        {
                            string projectRootPath = AppDomain.CurrentDomain.BaseDirectory;
                            string profilePictureDirectory = Path.Combine(projectRootPath, "ProfilePictures");

                            if (!Directory.Exists(profilePictureDirectory))
                            {
                                Directory.CreateDirectory(profilePictureDirectory);
                            }

                            // Создание уникального имени файла
                            string uniqueFileName = $"{clientId}_profile_{DateTime.Now.Ticks}.jpg"; // Используем уникальное имя
                            string picturePath = Path.Combine(profilePictureDirectory, uniqueFileName);

                            // Сохранение изображения
                            ProfilePictureBox.Image.Save(picturePath, System.Drawing.Imaging.ImageFormat.Jpeg);
                            cmd.Parameters.AddWithValue("@ProfilePicture", picturePath);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Ошибка при сохранении изображения: {ex.Message}");
                            cmd.Parameters.AddWithValue("@ProfilePicture", DBNull.Value); // Если ошибка, устанавливаем NULL
                        }
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@ProfilePicture", DBNull.Value); // Если изображения нет
                    }

                    try
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Профиль успешно обновлен.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при обновлении профиля: {ex.Message}");
                    }
                }
            }

            FIOTextBox.Visible = false;
            editPicButton.Visible = false;
            yesButton.Visible = false;
            phoneTextBox.Enabled = false;
        }

        private void LoadAllEquipmentTypes()
        {
            string query = "SELECT TypeName FROM EquipmentTypes";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                DataGridViewComboBoxColumn equipTypeColumn = (DataGridViewComboBoxColumn)requestsDGV.Columns["EquipType"];
                equipTypeColumn.Items.Clear();

                while (reader.Read())
                {
                    equipTypeColumn.Items.Add(reader["TypeName"].ToString());
                }
            }
        }


        private void changeReqButton_Click(object sender, EventArgs e)
        {
            saveButton.Visible = true;
            DataGridViewRow selectedRow = requestsDGV.SelectedRows[0];

            requestsDGV.ReadOnly = false;
            selectedRow.Cells["Column4"].ReadOnly = true;
            selectedRow.Cells["Column5"].ReadOnly = true;
            selectedRow.Cells["Master0"].ReadOnly = true;
            selectedRow.Cells["Status"].ReadOnly = true;
            selectedRow.Cells["col"].ReadOnly = true;
            selectedRow.Cells["Column10"].ReadOnly = true;

            saveButton.Click += (s, ev) => SaveRequestChanges(selectedRow);
        }

        private void SaveRequestChanges(DataGridViewRow row)
        {
            int requestId = Convert.ToInt32(row.Cells["reqID"].Value);
            string newProblemDescription = row.Cells["ProblemDescription"].Value.ToString();
            string newEquipType = row.Cells["EquipType"].Value.ToString();
            string newEquipModel = row.Cells["EquipModel"].Value.ToString();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                int typeId = GetEquipmentTypeId(newEquipType, conn);
                int equipmentId = GetOrInsertEquipmentId(typeId, newEquipModel, conn);

                string updateRequestQuery = @"UPDATE Requests 
                                              SET ProblemDescription = @ProblemDescription,
                                                  EquipmentID = @EquipmentID 
                                              WHERE RequestID = @RequestID";

                using (SqlCommand cmdRequest = new SqlCommand(updateRequestQuery, conn))
                {
                    cmdRequest.Parameters.AddWithValue("@ProblemDescription", newProblemDescription);
                    cmdRequest.Parameters.AddWithValue("@EquipmentID", equipmentId);
                    cmdRequest.Parameters.AddWithValue("@RequestID", requestId);
                    cmdRequest.ExecuteNonQuery();
                }
            }
            saveButton.Visible = false;
            MessageBox.Show("Изменения успешно сохранены.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

            requestsDGV.ReadOnly = true;
            LoadRequestsData(clientId);
        }

        private int GetEquipmentTypeId(string typeName, SqlConnection conn)
        {
            string query = "SELECT TypeID FROM EquipmentTypes WHERE TypeName = @TypeName";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@TypeName", typeName);
                object result = cmd.ExecuteScalar();
                return result != null ? Convert.ToInt32(result) : 0;
            }
        }

        private int GetOrInsertEquipmentId(int typeId, string model, SqlConnection conn)
        {
            string selectQuery = "SELECT EquipmentID FROM Equipment WHERE TypeID = @TypeID AND Model = @Model";
            string insertQuery = "INSERT INTO Equipment (TypeID, Model) OUTPUT INSERTED.EquipmentID VALUES (@TypeID, @Model)";

            using (SqlCommand cmd = new SqlCommand(selectQuery, conn))
            {
                cmd.Parameters.AddWithValue("@TypeID", typeId);
                cmd.Parameters.AddWithValue("@Model", model);
                object result = cmd.ExecuteScalar();

                if (result != null)
                {
                    return Convert.ToInt32(result);
                }
            }

            using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
            {
                cmd.Parameters.AddWithValue("@TypeID", typeId);
                cmd.Parameters.AddWithValue("@Model", model);
                return (int)cmd.ExecuteScalar();
            }
        }

        private void LoadRequestsData(int clientId)
        {
            requestsDGV.Rows.Clear();
            string query = @"SELECT R.RequestID, R.StartDate, E.Model AS EquipmentModel, ET.TypeName AS EquipmentType, 
                             R.ProblemDescription, U.FullName AS MasterName, RS.StatusName, 
                             R.RepairParts, R.CompletionDate
                             FROM Requests R
                             LEFT JOIN Equipment E ON R.EquipmentID = E.EquipmentID
                             LEFT JOIN EquipmentTypes ET ON E.TypeID = ET.TypeID
                             LEFT JOIN Users U ON R.MasterID = U.UserID
                             LEFT JOIN RequestStatuses RS ON R.StatusID = RS.StatusID
                             WHERE R.ClientID = @ClientID
                             ORDER BY R.StartDate";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ClientID", clientId);
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                int requestNumber = 1;

                while (reader.Read())
                {
                    requestsDGV.Rows.Add(
                        requestNumber++,
                        reader["StartDate"].ToString(),
                        reader["EquipmentModel"].ToString(),
                        reader["EquipmentType"].ToString(),
                        reader["ProblemDescription"].ToString(),
                        reader["MasterName"].ToString(),
                        reader["StatusName"].ToString(),
                        reader["RepairParts"].ToString(),
                        reader["CompletionDate"] == DBNull.Value ? "" : reader["CompletionDate"].ToString(),
                        reader["RequestID"].ToString()
                    );
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MainMenu mainMenu = new MainMenu(userRole, userLog);
            mainMenu.Show();
            Hide();
        }

        
    }
}
