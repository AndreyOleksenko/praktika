using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;
namespace ClimateRepair
{
    public partial class CreateRequest : Form
    {
        private int userRole;
        private string userLog;
        private int clientId;
        private string clientPhone;
        private string clientFIO;
        public CreateRequest(int role, string usLog)
        {
            userRole = role;
            userLog = usLog;
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            string connectionString = @"Data Source=ADCLG1;Initial Catalog=OleksenkoPract;Integrated Security=True";

            // Получение данных клиента
            string query_ = "SELECT UserID, FullName, Phone FROM Users WHERE @Login = Login";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query_, conn);
                cmd.Parameters.AddWithValue("@Login", userLog);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    clientId = Convert.ToInt32(reader["UserID"]);
                    clientPhone = reader["Phone"].ToString();
                    clientFIO = reader["FullName"].ToString();
                }
            }

            fioTextBox.Text = clientFIO;
            contactTextBox.Text = clientPhone;

            // Загрузка уникальных типов оборудования и их идентификаторов
            string query = @"SELECT DISTINCT TypeID, TypeName FROM EquipmentTypes ORDER BY TypeName";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable equipmentTypesTable = new DataTable();
                adapter.Fill(equipmentTypesTable);

                // Заполнение ComboBox данными из таблицы
                eqTypeComboBox.DataSource = equipmentTypesTable;
                eqTypeComboBox.DisplayMember = "TypeName"; // Отображаем название типа
                eqTypeComboBox.ValueMember = "TypeID";     // ID типа используем как значение
                eqTypeComboBox.SelectedIndex = -1;         // Сбрасываем выбор, чтобы ComboBox был пуст
            }
        }

        private void CheckFields(object sender, EventArgs e)
        {
            // Проверяем, что все поля заполнены
            confirmButton.Enabled =
                !string.IsNullOrWhiteSpace(eqModelTextBox.Text) &&
                !string.IsNullOrWhiteSpace(descriptTextBox.Text) &&
                eqTypeComboBox.SelectedIndex >= 0; // Убедитесь, что выбрано значение в ComboBox
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            
            DateTime Date = DateTime.Now;
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial catalog=OleksenkoPract;Integrated Security=True";
            int equipmentId = 0;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // 1. Вставляем новое оборудование в таблицу Equipment
                string insertEquipmentQuery = @"INSERT INTO Equipment (Model, TypeID) OUTPUT INSERTED.EquipmentID 
                                        VALUES (@Model, @TypeID)";

                using (SqlCommand cmd = new SqlCommand(insertEquipmentQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@Model", eqModelTextBox.Text);
                    cmd.Parameters.AddWithValue("@TypeID", eqTypeComboBox.SelectedValue); // ID выбранного типа оборудования

                    // Получаем ID добавленного оборудования
                    equipmentId = (int)cmd.ExecuteScalar();
                }

                // 2. Вставляем заявку в таблицу Requests, используя полученный EquipmentID
                string insertRequestQuery = @"INSERT INTO Requests (ClientID, StartDate, ProblemDescription, StatusID, CompletionDate, RepairParts, MasterID, EquipmentID) 
                                      VALUES (@ClientID, @StartDate, @ProblemDescription, 1, NULL, NULL, NULL, @EquipmentID)";

                using (SqlCommand cmd = new SqlCommand(insertRequestQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@ClientID", clientId);
                    cmd.Parameters.AddWithValue("@StartDate", Date.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@ProblemDescription", descriptTextBox.Text);
                    cmd.Parameters.AddWithValue("@EquipmentID", equipmentId);

                    cmd.ExecuteNonQuery(); // Выполняем вставку заявки
                    eqModelTextBox.Clear();
                    descriptTextBox.Clear();
                    MessageBox.Show("Заявка успешно создана!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            MainMenu mainMenu = new MainMenu(userRole, userLog);
            mainMenu.Show();
            Hide();
        }
    }
}
