using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace final_prject_login_trial
{
    public partial class Login : Form
    {
        public bool text_input;
        int verification_code;

        public Login()
        {
            InitializeComponent();
        }
      
            
         private void create_account_button_Click(object sender, EventArgs e)
        { 
            {
                Create userinfo = new Create(1, this, "NULL");
                userinfo.Show();
                this.Hide();
            }
        }

        private void login_button_Click(object sender, EventArgs e)
        {
            string user_username = login_username.Text;
            int password_confirm = 0;
            d.sqlStr += "SELECT * FROM account_data  ";
            d.sqlStr += "WHERE account = '" + user_username + "';";
            d.work();
            d.connect();
            string password_data = null;
            try
            {
                password_data = d.rd[1].ToString();
            }
            catch 
            {
                MessageBox.Show("username, password, or verification code is incorrect");
                input_code.Clear();
                Random verification = new Random();
                code_visible.Text = verification.Next(1000, 9999).ToString();
                d.disconnect();
                return;
            }
            password_confirm = string.Compare(password_data, login_password.Text);
            int code_confirm = string.Compare(code_visible.Text, input_code.Text);
            d.disconnect();
            if (password_confirm == 0 && code_confirm == 0)
            {
                Main main = new Main(user_username);
                main.Show();
                this.Hide();
            }
            else 
            {
                MessageBox.Show("username, password, or verification code is incorrect");
                input_code.Clear();
                Random verification = new Random();
                code_visible.Text = verification.Next(1000, 9999).ToString();
            }


        }
        data d = new data();

        private void login_password_TextChanged(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {
            Random verfication = new Random();
            int verification_code = verfication.Next(1000, 9999);
            code_visible.Text = verification_code.ToString();
            login_username.TabIndex = 1;
            login_password.TabIndex = 2;
            input_code.TabIndex = 3;
            login_button.TabIndex = 4;
            create_account_button.TabIndex = 5;
        }

        private void login_button_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                login_button.PerformClick();
            }
        }
    }
    
}
