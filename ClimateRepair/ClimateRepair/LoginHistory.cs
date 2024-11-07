using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClimateRepair
{
    public partial class LoginHistory : Form
    {
        private int userRole;
        private string userLog;
        private string connectionString = @"Data Source=ADCLG1;Initial Catalog=OleksenkoPract;Integrated Security=True";
        //@"Data Source=ADCLG1;Initial Catalog=OleksenkoPract;Integrated Security=True";
        public LoginHistory(int role, string usLog)
        {
            userRole = role;
            userLog = usLog;
            InitializeComponent();
            LoadLoginHistory();
        }

        private void filterField_TextChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }
        private void ApplyFilters()
        {
            // Получаем текст из фильтрующих полей
            string filterValue1 = filterField1.Text.Trim();

            // Построение фильтрованного запроса
            string filterQuery = @"
                SELECT * FROM LoginHistory
                WHERE (UserLogin LIKE @Filter1 OR @Filter1 = '')";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(filterQuery, conn);
                cmd.Parameters.AddWithValue("@Filter1", "%" + filterValue1 + "%");
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                LogHDGV.Rows.Clear();

                while (reader.Read())
                {
                    LogHDGV.Rows.Add(
                        reader["HistoryID"],
                        reader["LoginTime"],
                        reader["UserLogin"],
                        reader["IsSuccessful"]
                    );
                }
            }

            UpdateRecordCount();
        }
        private void UpdateRecordCount()
        {
            int displayedRows = LogHDGV.Rows.Count;
            int totalRows = GetTotalRecordCount();
            recordLabel.Text = $"{displayedRows} из {totalRows}";
        }

        private int GetTotalRecordCount()
        {
            string query = "SELECT COUNT(*) FROM LoginHistory";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                return (int)cmd.ExecuteScalar();
            }
        }

        private void LoadLoginHistory()
        {
            string query = "SELECT * FROM LoginHistory";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                LogHDGV.Rows.Clear();

                while (reader.Read())
                {
                    LogHDGV.Rows.Add(
                        reader["HistoryID"],
                        reader["LoginTime"],
                        reader["UserLogin"],
                        reader["IsSuccessful"]
                    );
                }
            }
            UpdateRecordCount();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            MainMenu mainMenu = new MainMenu(userRole, userLog);
            mainMenu.Show();
            Hide();
        }
    }
}
