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
    public partial class Main : Form
    {
        string username;
        string date;
        data d = new data();
        bool[] isMeal = new bool[4];
        Label[] textboxes = new Label[4];
        Label[] labels = new Label[4];
        Button[] buttons = new Button[4];
        Button[] delBtn = new Button[20];
        int[] numOfDelBtns = new int[4];
        bool isCalendarOpen = false;

        public Main(string _username)
        {
            InitializeComponent();
            username = _username;
            //this.Dock = DockStyle.Top;
        }

        private void Main_Load(object sender, EventArgs e)
        {
            // gets current date
            button5.Text = "" + DateTime.Now.ToString("yyyyMMdd");
            date = DateTime.Now.ToString("MMddyyyy");

            // initialises textboxes
            initTextbox();

            int posY = 0;
            int delBtnPosY = 0;
            int k = 0;
            int kk = 0;
            int kkk = 0;

            // initialises delete buttons
            initDelBtn();


            for (int meal = 0; meal < 4; meal++)
            {
                d.select(username + "1");
                d.sqlStr += "WHERE day =" + date + " AND meal =" + (meal+1)+";";
                d.work();
                d.con();
                //control_panel.Controls.Add(textboxes[meal]);
                while (d.rd.Read())
                {
                    numOfDelBtns[meal]++;
                    delBtn[kkk].Name = d.rd[1].ToString();
                    textboxes[meal].Text += d.rd[1].ToString() + " x" + d.rd[2].ToString() + "\r\n";
                    isMeal[meal] = true;
                    kkk++;
                }
                d.disconnect();
            }


            for (int i = 0; i < 4; i++)
            {
                labels[i] = new Label();
                labels[i].Location = new Point(0, posY);
                control_panel.Controls.Add(labels[i]);
                posY += 25;

                buttons[i] = new Button();
                buttons[i].Location = new Point(0, posY);
                control_panel.Controls.Add(buttons[i]);
                buttons[i].Name = "button" + i;
                buttons[i].Click += new EventHandler(button_Click);

                control_panel.Controls.Add(textboxes[i]);
                if (isMeal[i])
                {
                    posY += 30;
                    delBtnPosY = posY;
                    textboxes[i].Location = new Point(0, posY);


                    k += numOfDelBtns[i];
                    for (int j = 0 + kk; j < k; j++)
                    {
                        delBtn[j].Location = new Point(0, delBtnPosY);
                        delBtnPosY += 17;
                    }
                    kk += numOfDelBtns[i];

                    posY += textboxes[i].Height + 10;
                }
                else posY += 40;

                if (i == 0) labels[i].Text = "Breakfast";
                if (i == 1) labels[i].Text = "Lunch";
                if (i == 2) labels[i].Text = "Dinner";
                if (i == 3) labels[i].Text = "Snacks";

                buttons[i].Text = "Add Food";
            }

            insertPicture();
            texture();
        }

        private void button_Click(object sender, EventArgs e)
        {
            Search f2;
            if (((Button)(sender)).Name.ToString() == "button0")
            {
                f2 = new Search(1, this, username, date);
                f2.Show();
            }
            if (((Button)(sender)).Name.ToString() == "button1")
            {
                f2 = new Search(2, this, username, date);
                f2.Show();
            }
            if (((Button)(sender)).Name.ToString() == "button2")
            {
                f2 = new Search(3, this, username, date);
                f2.Show();
            }
            if (((Button)(sender)).Name.ToString() == "button3")
            {
                f2 = new Search(4, this, username, date);
                f2.Show();
            }
            this.Hide();
        }

        // Edit button
        private void button8_Click(object sender, EventArgs e)
        {
            // disable all the other buttons
            button5.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;
            button8.Enabled = false;
            button9.Enabled = false;
            for (int i = 0; i < 4; i++) buttons[i].Enabled = false;

            button1.Visible = true;
            int k = numOfDelBtns[0] + numOfDelBtns[1] + numOfDelBtns[2] + numOfDelBtns[3];

            for (int i = 0; i < k; i++)
            {
                delBtn[i].Visible = true;
                delBtn[i].Enabled = true;
            }

            for (int i = 0; i < 4; i++) textboxes[i].Location = new Point(30, textboxes[i].Location.Y);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //button5.Text = "" + monthCalendar1.SelectionRange.Start.AddDays(-1).ToString("yyyyMMdd");
            monthCalendar1.SelectionRange = new SelectionRange(monthCalendar1.SelectionRange.Start.AddDays(-1), monthCalendar1.SelectionRange.Start);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (!isCalendarOpen)
            {
                monthCalendar1.Visible = true;
                isCalendarOpen = true;
            }
            else
            {
                monthCalendar1.Visible = false;
                isCalendarOpen = false;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
           // button5.Text = "" + monthCalendar1.SelectionRange.Start.AddDays(1).ToString("yyyyMMdd");
            monthCalendar1.SelectionRange = new SelectionRange(monthCalendar1.SelectionRange.Start.AddDays(1), monthCalendar1.SelectionRange.Start);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            graph f = new graph(username, this);
            f.Show();
            this.Hide();
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            monthCalendar1.Visible = false;
            button5.Text = "" + monthCalendar1.SelectionRange.Start.ToString("yyyyMMdd");
            date = monthCalendar1.SelectionRange.Start.ToString("MMddyyyy");



            for (int meal = 0; meal < 4; meal++)
            {
                isMeal[meal] = false;
                textboxes[meal].Text = "";

                d.select(username + "1");
                d.sqlStr += "WHERE day =" + Int32.Parse(date) + " AND meal =" + (meal+1)+";";
                d.work();
                d.con();
                while (d.rd.Read())
                {
                    numOfDelBtns[meal]++;
                    textboxes[meal].Text += d.rd[1].ToString() + " x" + d.rd[2].ToString() + "\r\n";
                    isMeal[meal] = true;
                }
                d.disconnect();
            }

            int posY = 0;

            for (int i = 0; i < 4; i++)
            {
                labels[i].Location = new Point(0, posY);
                posY += 25;

                buttons[i].Location = new Point(0, posY);

                if (isMeal[i])
                {
                    posY += 30;
                    textboxes[i].Location = new Point(0, posY);
                    posY += textboxes[i].Height + 10;
                }
                else posY += 40;
            }


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings(this, username);
            settings.Show();
            this.Hide();
        }

        private void delBtn_Clicked(object sender, EventArgs e)
        {
            int intDate = Int32.Parse(date);

            this.control_panel.Controls.Remove((sender as Button));
            float[] delete = new float[5];
            d.delete(username + "1");
            d.where((sender as Button).Name);
            d.work();
            d.select("food");
            d.where((sender as Button).Name);
            d.work();
            d.connect();
            for (int i = 0; i < 5; i++)
                delete[i] = float.Parse(d.rd[i + 1].ToString());

            d.disconnect();
            d.select(username + "2");
            d.where(intDate);
            d.work();
            d.connect();
            for (int i = 0; i < 5; i++)
                delete[i] = float.Parse(d.rd[i + 1].ToString()) - delete[i];
            d.disconnect();
            d.delete(username + "2");
            d.where(intDate);
            d.work();
            d.insert_personal_daily(username, intDate, delete[0], delete[1], delete[2], delete[3], delete[4]);
            d.work();

            // determine which button it is
            // obtain which meal it is and do delBtns[i]--

            for (int i = 0; i < 4; i++) textboxes[i].Text = "";

            numOfDelBtns[0] = 0;
            numOfDelBtns[1] = 0;
            numOfDelBtns[2] = 0;
            numOfDelBtns[3] = 0;


            for (int i = 0; i < 20; i++)
            {
                delBtn[i].Visible = false;
                delBtn[i].Enabled = false;
            }
            int kkk = 0;

            for (int meal = 0; meal < 4; meal++)
            {
                d.select(username + "1");
                d.sqlStr += "WHERE day =" + date + "AND meal =" + (meal + 1);
                d.work();
                d.con();
                while (d.rd.Read())
                {
                    numOfDelBtns[meal]++;
                    delBtn[kkk].Name = d.rd[1].ToString();
                    textboxes[meal].Text += d.rd[1].ToString() + " x" + d.rd[2].ToString() + "\r\n";
                    isMeal[meal] = true;
                    kkk++;
                }
                d.disconnect();
            }

            int posY = 0;
            int delBtnPosY = 0;
            int k = 0;
            int kk = 0;

            for (int i = 0; i < 4; i++)
            {
                labels[i].Location = new Point(0, posY);
                posY += 25;

                if (isMeal[i])
                {
                    posY += 30;
                    delBtnPosY = posY;
                    textboxes[i].Location = new Point(0, posY);

                    k += numOfDelBtns[i];
                    for (int j = 0 + kk; j < k; j++)
                    {
                        delBtn[j].Location = new Point(0, delBtnPosY);
                        delBtnPosY += 17;
                    }
                    kk += numOfDelBtns[i];

                    posY += textboxes[i].Height + 10;
                }
                else posY += 40;
            }
        }

        private void initTextbox()
        {
            for (int i = 0; i < 4; i++)
            {
                textboxes[i] = new Label();
                textboxes[i].Font = new Font("Century Gothic", 11);
                textboxes[i].AllowDrop = true;
                this.textboxes[i].TextChanged += new EventHandler(textboxes_TextChanged);
            }
        }
        private void textboxes_TextChanged(object sender, EventArgs e)
        {
            Size size = TextRenderer.MeasureText((sender as Label).Text, (sender as Label).Font);
            (sender as Label).Width = size.Width + 20;
            (sender as Label).Height = size.Height;
        }

        private void initDelBtn()
        {
            for (int i = 0; i < 20; i++)
            {
                delBtn[i] = new Button();
                delBtn[i].Visible = false;
                delBtn[i].Enabled = false;
                delBtn[i].Size = new Size(15, 15);
                this.control_panel.Controls.Add(delBtn[i]);

                delBtn[i].Click += new EventHandler(delBtn_Clicked);
            }
        }

        private void insertPicture()
        {
            data dd = new data();

            dd.sqlStr += "SELECT * FROM account_data WHERE account = '" + username + "'";
            dd.work();
            dd.con();
            dd.rd.Read();
            string photo = dd.rd[8].ToString();
            dd.disconnect();
            pictureBox1.Image = Image.FromFile(photo);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void texture()
        {
            for(int i = 0; i < 4; i++)
            {
                buttons[i].BackColor = Color.Transparent;
                buttons[i].FlatStyle = FlatStyle.Flat;
                buttons[i].Font = new Font("Century Gothic", 9);
                buttons[i].UseVisualStyleBackColor = true;

                labels[i].BackColor = Color.Transparent;
                labels[i].Font = new Font("Century Gothic", 9);
                
            }
        }

        public void update()
        {
            data dd = new data();

            dd.sqlStr += "SELECT * FROM account_data WHERE account = '" + username + "'";
            dd.work();
            dd.con();
            dd.rd.Read();
            string photo = dd.rd[8].ToString();
            dd.disconnect();

            pictureBox1.Image = Image.FromFile(photo);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            // enable all the other buttons
            button5.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = true;
            button8.Enabled = true;
            button9.Enabled = true;
            for (int i = 0; i < 4; i++) buttons[i].Enabled = true;

            // clear textboxes 
            for (int i = 0; i < 4; i++) textboxes[i].Text = "";

            button1.Visible = false;
            numOfDelBtns[0] = 0;
            numOfDelBtns[1] = 0;
            numOfDelBtns[2] = 0;
            numOfDelBtns[3] = 0;


            for (int i = 0; i < 20; i++)
            {
                delBtn[i].Visible = false;
                delBtn[i].Enabled = false;
            }
            int kkk = 0;

            for (int meal = 0; meal < 4; meal++)
            {
                d.select(username + "1");
                d.sqlStr += "WHERE day =" + date + "AND meal =" + (meal+1);
                d.work();
                d.con();
                while (d.rd.Read())
                {
                    numOfDelBtns[meal]++;
                    delBtn[kkk].Name = d.rd[1].ToString();
                    textboxes[meal].Text += d.rd[1].ToString() + " x" + d.rd[2].ToString() + "\r\n";
                    isMeal[meal] = true;
                    kkk++;
                }
                d.disconnect();
            }

            int posY = 0;
            int delBtnPosY = 0;
            int k = 0;
            int kk = 0;

            for (int i = 0; i < 4; i++)
            {
                labels[i].Location = new Point(0, posY);
                posY += 25;

                if (isMeal[i])
                {
                    posY += 30;
                    delBtnPosY = posY;
                    textboxes[i].Location = new Point(0, posY);

                    k += numOfDelBtns[i];
                    for (int j = 0 + kk; j < k; j++)
                    {
                        delBtn[j].Location = new Point(0, delBtnPosY);
                        delBtnPosY += 17;
                    }
                    kk += numOfDelBtns[i];

                    posY += textboxes[i].Height + 10;
                }
                else posY += 40;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Mine mine = new Mine();
            mine.Show();
            this.Hide();
        }
    }
}
