
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ClimateRepair
{
    public partial class OperatorRequests : Form
    {
        private int userRole;
        private string userLog;
        private DataGridViewRow selRow;
        private Dictionary<string, int> masterIds = new Dictionary<string, int>();
        private Dictionary<string, int> statusIds = new Dictionary<string, int>();
        private string sortColumn = "StartDate";
        private string sortOrder = "ASC";
        private string connectionString = @"Data Source=ADCLG1;Initial Catalog=OleksenkoPract;Integrated Security=True";
        //@"Data Source=ADCLG1;Initial Catalog=OleksenkoPract;Integrated Security=True";

        public OperatorRequests(int role, string usLog)
        {
            userRole = role;
            userLog = usLog;
            InitializeComponent();
            LoadOperatorDGV();
        }

        private void LoadOperatorDGV()
        {
            string query = $@"
                SELECT 
                    R.RequestID,  
                    R.StartDate,
                    C.FullName AS ClientName,
                    M.FullName AS MasterName,
                    ET.TypeName AS EquipmentType,
                    E.Model AS EquipmentModel,
                    R.ProblemDescription,
                    R.RepairParts,
                    RS.StatusName,
                    R.CompletionDate
                FROM Requests R
                LEFT JOIN Users C ON R.ClientID = C.UserID
                LEFT JOIN Users M ON R.MasterID = M.UserID
                LEFT JOIN Equipment E ON R.EquipmentID = E.EquipmentID
                LEFT JOIN EquipmentTypes ET ON E.TypeID = ET.TypeID
                LEFT JOIN RequestStatuses RS ON R.StatusID = RS.StatusID
                ORDER BY {sortColumn} {sortOrder}";

            LoadData(query);
        }
        private void LoadData(string query)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                operatorDGV.Rows.Clear();

                while (reader.Read())
                {
                    operatorDGV.Rows.Add(
                        reader["RequestID"],
                        reader["StartDate"],
                        reader["ClientName"],
                        reader["MasterName"],
                        reader["EquipmentType"],
                        reader["EquipmentModel"],
                        reader["ProblemDescription"],
                        reader["RepairParts"],
                        reader["StatusName"],
                        reader["CompletionDate"]
                    );
                }
            }
            operatorDGV.Columns["CompletionDate"].SortMode = DataGridViewColumnSortMode.NotSortable;
            operatorDGV.Columns["RepairParts"].SortMode = DataGridViewColumnSortMode.NotSortable;
            UpdateRecordCount();
            LoadAllMasters();
            LoadAllStatuses();
        }

        // Получаем список мастеров
        private void LoadAllMasters()
        {
            string query = @"
    SELECT U.UserID, U.FullName
    FROM Users U
    INNER JOIN UserTypes UT ON U.UserTypeID = UT.UserTypeID
    WHERE UT.TypeName = N'Мастер'";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                DataGridViewComboBoxColumn masterColumn = (DataGridViewComboBoxColumn)operatorDGV.Columns["Master_FullName"];
                masterColumn.Items.Clear();
                masterIds.Clear();

                while (reader.Read())
                {
                    int userId = (int)reader["UserID"];
                    string fullName = reader["FullName"].ToString();
                    masterColumn.Items.Add(fullName);
                    masterIds[fullName] = userId;
                }
            }
        }

        // Получаем список статусов
        private void LoadAllStatuses()
        {
            string query = "SELECT StatusID, StatusName FROM RequestStatuses";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                DataGridViewComboBoxColumn statusColumn = (DataGridViewComboBoxColumn)operatorDGV.Columns["StatusName"];
                statusColumn.Items.Clear();
                statusIds.Clear();

                while (reader.Read())
                {
                    int statusId = (int)reader["StatusID"];
                    string statusName = reader["StatusName"].ToString();
                    statusColumn.Items.Add(statusName);
                    statusIds[statusName] = statusId;
                }
            }
        }

        private void operatorDGV_SelectionChanged(object sender, EventArgs e)
        {
            editTableButton.Enabled = operatorDGV.SelectedRows.Count > 0;
        }

        private void UpdateRecordCount()
        {
            int displayedRows = operatorDGV.Rows.Count;
            int totalRows = GetTotalRecordCount();
            recordCountLabel.Text = $"{displayedRows} из {totalRows}";
        }

        private int GetTotalRecordCount()
        {
            string query = "SELECT COUNT(*) FROM Requests";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                return (int)cmd.ExecuteScalar();
            }
        }

        // Метод для обновления заявки в базе данных
        private void UpdateRequest(int requestId, int masterId, int statusId, DateTime? startDate, DateTime? completionDate)
        {
            string query = @"UPDATE Requests 
                     SET MasterID = @MasterID, StatusID = @StatusID, StartDate = @StartDate, CompletionDate = @CompletionDate
                     WHERE RequestID = @RequestID";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@RequestID", requestId);
                cmd.Parameters.AddWithValue("@MasterID", masterId);
                cmd.Parameters.AddWithValue("@StatusID", statusId);

                // Устанавливаем значения для StartDate и CompletionDate с проверкой на null
                cmd.Parameters.AddWithValue("@StartDate", startDate.HasValue ? (object)startDate.Value : DBNull.Value);
                cmd.Parameters.AddWithValue("@CompletionDate", completionDate.HasValue ? (object)completionDate.Value : DBNull.Value);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        private void editTableButton_Click(object sender, EventArgs e)
        {
            confirmButton.Visible = true;
            DataGridViewRow selectedRow = operatorDGV.SelectedRows[0];
            selRow = selectedRow;

            operatorDGV.ReadOnly = false;

            // Устанавливаем необходимые ячейки как редактируемые
            selectedRow.Cells["RequestID"].ReadOnly = true;
            selectedRow.Cells["Client_FullName"].ReadOnly = true;
            selectedRow.Cells["TypeName"].ReadOnly = true;
            selectedRow.Cells["Model"].ReadOnly = true;
            selectedRow.Cells["ProblemDescription"].ReadOnly = true;
            selectedRow.Cells["RepairParts"].ReadOnly = true;

            // Если роль — менеджер, делаем даты редактируемыми
            selectedRow.Cells["StartDate"].ReadOnly = userRole != 1;
            selectedRow.Cells["CompletionDate"].ReadOnly = userRole != 1;

        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            int requestId = Convert.ToInt32(selRow.Cells["RequestID"].Value);

            // Получение ID мастера и статуса по выбранному значению
            string selectedMasterName = selRow.Cells["Master_FullName"].FormattedValue.ToString();
            int selectedMasterId = masterIds.ContainsKey(selectedMasterName) ? masterIds[selectedMasterName] : 0;

            string selectedStatusName = selRow.Cells["StatusName"].FormattedValue.ToString();
            int selectedStatusId = statusIds.ContainsKey(selectedStatusName) ? statusIds[selectedStatusName] : 0;

            // Получаем даты, проверяем на наличие значения
            DateTime? startDate = DateTime.TryParse(selRow.Cells["StartDate"].Value?.ToString(), out DateTime parsedStartDate) ? parsedStartDate : (DateTime?)null;
            DateTime? completionDate = selectedStatusName == "Завершена" ? DateTime.Now :
            DateTime.TryParse(selRow.Cells["CompletionDate"].Value?.ToString(), out DateTime parsedCompletionDate) ? parsedCompletionDate : (DateTime?)null;

            if (selectedStatusName == "Завершена")
            {
                DialogResult result = MessageBox.Show(
                    "Вы завершаете заявку, убедитесь что все правильно. После нажатия на 'ОК' отчет будет отправлен клиенту.",
                    "Завершение заявки", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                if (result == DialogResult.OK)
                {
                    UpdateRequest(requestId, selectedMasterId, selectedStatusId, startDate, completionDate);
                    MessageBox.Show("Заявка успешно завершена и отчет отправлен клиенту.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                UpdateRequest(requestId, selectedMasterId, selectedStatusId, startDate, completionDate);
                MessageBox.Show("Изменения успешно сохранены.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            operatorDGV.ReadOnly = true;
            confirmButton.Visible = false;
            LoadOperatorDGV(); // Перезагружаем данные
        }

        private void filterField_TextChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }
        private void ApplyFilters()
        {
            // Получаем текст из фильтрующих полей
            string filterValue1 = filterField1.Text.Trim();
            string filterValue2 = filterField2.Text.Trim();

            // Проверяем, пусты ли оба фильтра
            if (string.IsNullOrEmpty(filterValue1) && string.IsNullOrEmpty(filterValue2))
            {
                // Если оба фильтра пусты, загружаем все записи
                LoadOperatorDGV();
                return;
            }

            // Построение фильтрованного запроса
            string filterQuery = @"
        SELECT 
            R.RequestID,  
            R.StartDate,
            C.FullName AS ClientName,
            M.FullName AS MasterName,
            ET.TypeName AS EquipmentType,
            E.Model AS EquipmentModel,
            R.ProblemDescription,
            R.RepairParts,
            RS.StatusName,
            R.CompletionDate
        FROM Requests R
        LEFT JOIN Users C ON R.ClientID = C.UserID
        LEFT JOIN Users M ON R.MasterID = M.UserID
        LEFT JOIN Equipment E ON R.EquipmentID = E.EquipmentID
        LEFT JOIN EquipmentTypes ET ON E.TypeID = ET.TypeID
        LEFT JOIN RequestStatuses RS ON R.StatusID = RS.StatusID
        WHERE (C.FullName LIKE @Filter1 OR @Filter1 = '')
          AND (M.FullName LIKE @Filter2 OR @Filter2 = '')
        ORDER BY " + sortColumn + " " + sortOrder;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(filterQuery, conn);
                cmd.Parameters.AddWithValue("@Filter1", "%" + filterValue1 + "%");
                cmd.Parameters.AddWithValue("@Filter2", "%" + filterValue2 + "%");
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                operatorDGV.Rows.Clear();

                while (reader.Read())
                {
                    operatorDGV.Rows.Add(
                        reader["RequestID"],
                        reader["StartDate"],
                        reader["ClientName"],
                        reader["MasterName"],
                        reader["EquipmentType"],
                        reader["EquipmentModel"],
                        reader["ProblemDescription"],
                        reader["RepairParts"],
                        reader["StatusName"],
                        reader["CompletionDate"]
                    );
                }
            }

            UpdateRecordCount();
        }

        private void operatorDGV_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Проверяем индекс нажатого столбца
            if (e.ColumnIndex == operatorDGV.Columns["Client_FullName"].Index)
            {
                sortColumn = "C.FullName";  // Поле FullName для клиента
            }
            else if (e.ColumnIndex == operatorDGV.Columns["Master_FullName"].Index)
            {
                sortColumn = "M.FullName";  // Поле FullName для мастера
            }
            else
            {
                // Для всех других столбцов берем их имя напрямую
                sortColumn = operatorDGV.Columns[e.ColumnIndex].Name;
            }

            // Переключение порядка сортировки
            sortOrder = sortOrder == "ASC" ? "DESC" : "ASC";

            // Перезагружаем данные с учетом сортировки
            LoadOperatorDGV();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            MainMenu mainMenu = new MainMenu(userRole, userLog);
            mainMenu.Show();
            Hide();
        }
    }
}
