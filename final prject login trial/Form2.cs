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
using System.Data.SqlClient;
using System.Configuration;

namespace final_prject_login_trial
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public string constring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\IIMBA\source\repos\final prject login trial\final prject login trial\Database1.mdf;Integrated Security=True";

        private void create_button_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(constring);
            con.Open();
            float height = float.Parse(input_height.Text);
            float weight = float.Parse(input_weight.Text);
            float age = float.Parse(input_age.Text);
            float daily_calories = 0;
            float x = 0;
            if (sedentary.Checked)
            {
                x = 1.2f;
            }
            if (lightly_active.Checked)
            {
                x = 1.375f;
            }
            if(moderately_active.Checked)
            {
                x = 1.55f;
            }
            if(active.Checked)
            {
                x = 1.725f;
            }
            if(very_active.Checked)
            {
                x = 1.9f;
            }
            if (input_gender.SelectedIndex == 0)
            {
                daily_calories = ((10f * weight) + (6.25f * height) - (5f * age) + 5f)*x;
            }
            if (input_gender.SelectedIndex == 1)
            {
                daily_calories = ((10f * weight) + (6.25f * height) - (5f *age) - 161f)*x;
            }
            string SqlSTR = "CREATE TABLE [dbo].['"+create_username.Text+"'] (username nvarchar(50),password nvarchar(50), height float, weight float, age float, gender int, daily calories float)";
            SqlCommand cmd = new SqlCommand("insert into user_info (username, password, height, weight, age, gender, daily calories) values('" + create_username.Text.ToString() + "', '" + create_password.Text.ToString() +);
            cmd = new SqlCommand(SqlSTR, con);
            cmd.ExecuteNonQuery();
            this.Hide();
            Form1 frm_1 = new Form1();
            frm_1.Show();
        }

    }
  
}
