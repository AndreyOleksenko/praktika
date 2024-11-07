using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ClimateRepair
{
    public partial class Reports : Form
    {
        private string ReqID;
        private string connectionString = @"Data Source=ADCLG1;Initial Catalog=OleksenkoPract;Integrated Security=True";
        ///*@"Data Source=ADCLG1;Initial Catalog=OleksenkoPract;Integrated Security=True";*/
        //@"Data Source=(localdb)\MSSQLLocalDB;Initial catalog=OleksenkoPract;Integrated Security=True";
        public Reports(string clientName, string startDate, string repairParts, string id)
        {
            InitializeComponent();
            ReqID = id;
            clientTextBox.Text = clientName;
            dateTextBox.Text = startDate;
            partsTextBox.Text = repairParts;
        }
        private void CheckFields(object sender, EventArgs e)
        {
            // Проверяем, что все поля заполнены
            confirmButton.Enabled =
                !string.IsNullOrWhiteSpace(detailsTextBox.Text);
        }
        private void confirmButton_Click(object sender, EventArgs e)
        {
            DateTime Date = DateTime.Now;
            string date = Date.ToString("yyyy-MM-dd");
            string insertQuery = $"INSERT INTO Reports VALUES ({ReqID}, '{date}', N'{detailsTextBox.Text}')";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
            MessageBox.Show("Отчет отправлен", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
