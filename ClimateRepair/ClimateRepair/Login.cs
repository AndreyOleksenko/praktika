using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace ClimateRepair
{
    public partial class Login : Form
    {
        private int userRole;
        private int failedAttempts = 0;
        private DateTime blockEndTime;
        private Random random = new Random();
        private string generatedCaptcha = "";
        private string connectionString = @"Data Source=ADCLG1;Initial Catalog=OleksenkoPract;Integrated Security=True";
        //@"Data Source=ADCLG1;Initial Catalog=OleksenkoPract;Integrated Security=True";

        public Login()
        {
            InitializeComponent();
            captchaPictureBox.Visible = false;
            captchaTextBox.Visible = false;
            regenerateCaptchaButton.Visible = false;
            passTextBox.UseSystemPasswordChar = true;
            showPasswordCheckBox.CheckedChanged += (s, e) =>
            {
                passTextBox.UseSystemPasswordChar = !showPasswordCheckBox.Checked;
            };
        }

        private void LogLoginAttempt(string userLogin, bool isSuccess)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string insertLoginHistoryQuery = "INSERT INTO LoginHistory (UserLogin, IsSuccessful) VALUES (@UserLogin, @IsSuccessful)";
                using (SqlCommand cmd = new SqlCommand(insertLoginHistoryQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@UserLogin", userLogin);
                    cmd.Parameters.AddWithValue("@IsSuccessful", isSuccess);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void enterButton_Click(object sender, EventArgs e)
        {
            string userLogin = loginTextBox.Text;
            bool isSuccess = false;

            if (failedAttempts >= 1 && captchaTextBox.Text != generatedCaptcha)
            {
                captchaTextBox.Clear();
                MessageBox.Show("CAPTCHA введена неправильно.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogLoginAttempt(userLogin, false);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string selectUserQuery = "SELECT UserTypeID, Password FROM Users WHERE Login = @Login";
                    using (SqlCommand cmd = new SqlCommand(selectUserQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@Login", userLogin);
                        var reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            userRole = Convert.ToInt32(reader["UserTypeID"]);
                            string storedPassword = reader["Password"].ToString();

                            if (storedPassword == passTextBox.Text)
                            {
                                isSuccess = true;
                                failedAttempts = 0;
                                MessageBox.Show("Вход выполнен успешно!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                MainMenu mainMenu = new MainMenu(userRole, userLogin);
                                mainMenu.Show();
                                Hide();
                                failedAttempts = 0;
                                ResetCaptcha();
                            }
                            else
                            {
                                HandleFailedAttempt();
                            }
                        }
                        else
                        {
                            HandleFailedAttempt();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при попытке подключения к базе данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            LogLoginAttempt(userLogin, isSuccess);
        }

        private void HandleFailedAttempt()
        {
            ResetCaptcha();
            failedAttempts++;

            if (failedAttempts < 3)
            {
                ShowCaptcha();
                MessageBox.Show("Неверный пароль! Пожалуйста, введите CAPTCHA.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (failedAttempts == 3)
            {
                BlockLogin(0.1);
                MessageBox.Show("Вход заблокирован на 3 минуты.", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                enterButton.Enabled = false;
            }
            else if (failedAttempts >= 4)
            {
                BlockLoginPermanent();
            }
        }

        private void ShowCaptcha()
        {
            generatedCaptcha = GenerateCaptcha();
            captchaPictureBox.Image = CreateCaptchaImage(generatedCaptcha);
            captchaPictureBox.Visible = true;
            captchaTextBox.Visible = true;
            regenerateCaptchaButton.Visible = true;
        }

        private string GenerateCaptcha()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            char[] stringChars = new char[4];

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            return new string(stringChars);
        }

        private Image CreateCaptchaImage(string captcha)
        {
            Bitmap bmp = new Bitmap(150, 60);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.White);
                Random random = new Random();

                using (Font font = new Font("Arial", 22, FontStyle.Bold))
                {
                    // Отображаем каждый символ с небольшим случайным смещением
                    for (int i = 0; i < captcha.Length; i++)
                    {
                        float xOffset = 26 + (i * 22) + random.Next(-5, 5); // Смещение по X
                        float yOffset = 12 + random.Next(-5, 5);            // Смещение по Y
                        g.DrawString(captcha[i].ToString(), font, Brushes.Black, new PointF(xOffset, yOffset));
                    }
                }

                // Добавление шума и перекрытий
                for (int i = 0; i < 22; i++)
                {
                    int x1 = random.Next(0, bmp.Width);
                    int y1 = random.Next(0, bmp.Height);
                    int x2 = random.Next(0, bmp.Width);
                    int y2 = random.Next(0, bmp.Height);
                    g.DrawLine(Pens.Gray, x1, y1, x2, y2);
                }
            }
            return bmp;
        }

        private void regenerateCaptchaButton_Click(object sender, EventArgs e)
        {
            ShowCaptcha();
        }

        private void BlockLogin(double minutes)
        {
            blockTimerLabel.Visible = true;
            blockEndTime = DateTime.Now.AddMinutes(minutes);
            Task.Run(BlockCountdown);
        }

        private async Task BlockCountdown()
        {
            while (DateTime.Now < blockEndTime)
            {
                TimeSpan remaining = blockEndTime - DateTime.Now;
                Invoke((MethodInvoker)(() =>
                {
                    blockTimerLabel.Text = $"Блокировка: {remaining.Minutes:D2}:{remaining.Seconds:D2}";
                }));
                await Task.Delay(1000);
            }

            
            Invoke((MethodInvoker)(() =>
            {
                blockTimerLabel.Text = "";
                enterButton.Enabled = true;
                ShowCaptcha(); // Показ последней CAPTCHA после разблокировки
            }));
        }

        private void BlockLoginPermanent()
        {
            MessageBox.Show("Вход заблокирован. Перезапустите приложение.", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            enterButton.Enabled = false;
            captchaPictureBox.Visible = false;
            captchaTextBox.Visible = false;
            regenerateCaptchaButton.Visible = false;
        }

        private void ResetCaptcha()
        {
            captchaPictureBox.Visible = false;
            captchaTextBox.Visible = false;
            regenerateCaptchaButton.Visible = false;
            captchaTextBox.Clear();
        }
    }
}
