using IOC;
using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TSS_Management
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            ThietLapKetNoi();
            LoadConfig();
        }

        private void ThietLapKetNoi()
        {
            tbx_server_name.Enabled = chk_thiet_lap.Checked;
            tbx_db_name.Enabled = chk_thiet_lap.Checked;
            tbx_user_sql.Enabled = chk_thiet_lap.Checked;
            tbx_pass_sql.Enabled = chk_thiet_lap.Checked;
        }

        private void chk_thiet_lap_CheckedChanged(object sender, EventArgs e)
        {
            ThietLapKetNoi();
        }

        private void LoadConfig()
        {
            tbx_server_name.Text = Properties.Settings.Default.servername;
            tbx_user_sql.Text = Properties.Settings.Default.usersql;
            tbx_pass_sql.Text = EncryptDecryptServices.DecryptString(Properties.Settings.Default.passsql, "Th41$0nJSC");
            tbx_user_name.Text = Properties.Settings.Default.username;
            tbx_db_name.Text = Properties.Settings.Default.dbname;
        }
        private void SaveConfig()
        {
            Properties.Settings.Default.servername = tbx_server_name.Text;
            Properties.Settings.Default.usersql = tbx_user_sql.Text;
            Properties.Settings.Default.passsql = EncryptDecryptServices.EncryptString(tbx_pass_sql.Text, "Th41$0nJSC");
            Properties.Settings.Default.username = tbx_user_name.Text;
            Properties.Settings.Default.dbname = tbx_db_name.Text;
            Properties.Settings.Default.Save();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            SaveConfig();
            ConfigurationServices.Init(Properties.Settings.Default.servername, Properties.Settings.Default.dbname, Properties.Settings.Default.passsql, Properties.Settings.Default.usersql);
            UserServices userServices = Locator.GetT<UserServices>();
            
            
            if (userServices.checkLogin(tbx_user_name.Text, tbx_password.Text))
            {
                Main main = new Main();
                main.Show();
                this.Hide();
            }
        }
    }
}
