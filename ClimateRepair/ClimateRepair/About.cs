using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClimateRepair
{
    public partial class About : Form
    {
        private int userRole;
        private string userLog;
        public About(int role, string usLog)
        {
            userRole = role;
            userLog = usLog;
            InitializeComponent();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            MainMenu mainMenu = new MainMenu(userRole, userLog);
            mainMenu.Show();
            Hide();
        }
    }
}
