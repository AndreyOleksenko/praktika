using System;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;


namespace ClimateRepair
{
    public partial class MainMenu : Form
    {
        private int userRole;
        private string userLog;
        private string connectionString = @"Data Source=ADCLG1;Initial Catalog=OleksenkoPract;Integrated Security=True";
        //@"Data Source=ADCLG1;Initial Catalog=OleksenkoPract;Integrated Security=True";

        public MainMenu(int role, string usLog)
        {
            userRole = role;
            userLog = usLog;
            InitializeComponent();
            LoadProfilePicture();
            usLogLabel.Text = userLog;
            switch (userRole)
            {
                case 1:
                    addRequestButton.Visible = false;
                    operatorReqButton.Location = new Point(222, 296);
                    historyButton.Location = new Point(222, 366);
                    aboutButton.Location = new Point(222, 438);
                    break;
                case 2:
                    addRequestButton.Visible = false;
                    operatorReqButton.Location = new Point(222, 296);
                    historyButton.Visible = false;
                    break;
                case 3:
                    addRequestButton.Visible = false;
                    historyButton.Visible = false;
                    operatorReqButton.Visible = false;
                    aboutButton.Location = new Point(222, 296);
                    break;
                case 4:
                    addRequestButton.Visible = false;
                    historyButton.Visible = false;
                    operatorReqButton.Visible = false;
                    aboutButton.Location = new Point(222, 296);
                    break;

            }
        }
        private void LoadProfilePicture()
        {
            string query = "SELECT ProfilePicture FROM Users WHERE Login = @Login";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Login", userLog);

                conn.Open();
                object result = cmd.ExecuteScalar();

                if (result != null)
                {
                    string picturePath = result.ToString();

                    // Проверяем, существует ли изображение, и загружаем его
                    if (File.Exists(picturePath))
                    {
                        ProfilePictureBox.Image = Image.FromFile(picturePath);
                    }
                }
            }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            Hide();
        }

        private void profileButton_Click(object sender, EventArgs e)
        {
            Profile profile = new Profile(userRole, userLog);
            profile.Show();
            Hide();
        }

        private void addRequestButton_Click(object sender, EventArgs e)
        {
            CreateRequest request = new CreateRequest(userRole, userLog);
            request.Show();
            Hide();
        }

        private void aboutButton_Click(object sender, EventArgs e)
        {
            About about = new About(userRole, userLog);
            about.Show();
            Hide();
        }

        private void operatorReqButton_Click(object sender, EventArgs e)
        {
            OperatorRequests operatorRequests = new OperatorRequests(userRole, userLog);
            operatorRequests.Show();
            Hide();
        }

        private void historyButton_Click(object sender, EventArgs e)
        {
            LoginHistory loginHistory = new LoginHistory(userRole, userLog);
            loginHistory.Show();
            Hide();
        }
    }
}
