using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace final_prject_login_trial
{
    public partial class Pfp : Form
    {
        Settings f;
        string username;

        public Pfp(Settings form, string _username)
        {
            InitializeComponent();
            f = form;
            username = _username;
        }

        private void Pfp_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile("0.png");
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.Image = Image.FromFile("1.png");
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.Image = Image.FromFile("2.png");
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.Image = Image.FromFile("3.png");
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox5.Image = Image.FromFile("4.png");
            pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox6.Image = Image.FromFile("5.png");
            pictureBox6.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox7.Image = Image.FromFile("6.png");
            pictureBox7.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox8.Image = Image.FromFile("7.png");
            pictureBox8.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox9.Image = Image.FromFile("8.png");
            pictureBox9.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox10.Image = Image.FromFile("9.png");
            pictureBox10.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox11.Image = Image.FromFile("10.png");
            pictureBox11.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox12.Image = Image.FromFile("11.png");
            pictureBox12.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox13.Image = Image.FromFile("12.png");
            pictureBox13.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox14.Image = Image.FromFile("13.png");
            pictureBox14.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox15.Image = Image.FromFile("14.png");
            pictureBox15.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            changePicture("0");
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            changePicture("1");
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            changePicture("2");
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            changePicture("3");
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            changePicture("4");
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            changePicture("9");
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            changePicture("8");
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            changePicture("7");
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            changePicture("6");
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            changePicture("5");
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            changePicture("14");
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            changePicture("13");

        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            changePicture("12");
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            changePicture("11");
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            changePicture("10");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            f.Show();
        }

        private void changePicture(string pic)
        {
            data dd = new data();

            dd.sqlStr += "SELECT * FROM account_data WHERE account = '" + username + "'";
            dd.work();
            dd.con();
            dd.rd.Read();
            string password = dd.rd[1].ToString();
            string gender = dd.rd[2].ToString();
            string height = dd.rd[3].ToString();
            string weight = dd.rd[4].ToString();
            string age = dd.rd[5].ToString();
            string life_style = dd.rd[6].ToString();
            string daily_calories = dd.rd[7].ToString();
            string photo = pic + ".png";
            dd.disconnect();
            dd.delete("account_data");
            dd.where_account(username);
            dd.work();
            dd.insert_account(username, password, Int32.Parse(gender), float.Parse(height), float.Parse(weight), float.Parse(age), Int32.Parse(life_style), float.Parse(daily_calories), photo);
            dd.work();

            this.Hide();
            f.updatePfp();
            f.Show();

        }
    }
}
