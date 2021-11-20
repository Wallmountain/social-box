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
    public partial class Mine : Form
    {
        Button[,] btn = new Button[101, 101];
        int[,] btn_prop = new int[101, 101];
        int[,] saved_btn_prop = new int[101, 101];
        Point coordinate;
        bool firstPlay = true;
        bool failed = false;

        int second = 0;
        int minute = 0;

        int[] dx8 = { 1, 0, -1, 0, 1, -1, -1, 1 };
        int[] dy8 = { 0, 1, 0, -1, 1, -1, 1, -1 };

        int start_x, start_y;
        int width, height;

        int mines;
        int cabbage_num_value = 10;
        int cabbage_num;

        int buttonSize = 20;
        int distance = 20;

        double easy = 0.1f;
        double medium = 0.2f;
        double hard = 0.3f;

        public Mine()
        {
            InitializeComponent();
        }

        private void Mine_Load(object sender, EventArgs e)
        {
            losed_weight.Visible = false;
            remainingFlags.Visible = false;
            label4.Visible = false;
            minute_label.Text = "";
            second_label.Text = "";
            loss_number.Text = "";
            gameProgress.Visible = false;
        }
        private int check_point_map(int x, int y)
        {
            if (x < 1 || x > width || y < 1 || y > height)
                return 0;
            return 1;
        }

        private void EmptySpace(int x, int y)
        {
            if (btn_prop[x, y] == 0)
            {
                for (int i = 0; i < 8; i++)
                {
                    int cx = x + dx8[i];
                    int cy = y + dy8[i];

                    if (check_point_map(cx, cy) == 1)
                        if (btn[cx, cy].Enabled == true && btn_prop[cx, cy] != -1 && !failed)
                        {
                            gameProgress.Value++;
                            loss_number.Text = gameProgress.Value.ToString();
                            set_ButtonImage(cx, cy);
                        }
                }
            }
        }

        private int Mine_Around(int x, int y)
        {
            int losed_weight = 0;
            for (int i = 0; i < 8; i++)
            {
                int cx = x + dx8[i];
                int cy = y + dy8[i];

                if (check_point_map(cx, cy) == 1 && btn_prop[cx, cy] == -1)
                    losed_weight++;
            }
            return losed_weight;
        }

        private void SetMapNumbers(int x, int y)
        {
            for (int i = 1; i <= x; i++)
                for (int j = 1; j <= y; j++)
                    if (btn_prop[i, j] != -1)
                    {
                        btn_prop[i, j] = Mine_Around(i, j);
                        saved_btn_prop[i, j] = Mine_Around(i, j);
                    }
        }
        private void Check_FlagWin()
        {
            bool win = true;

            for (int i = 1; i <= width; i++)
                for (int j = 1; j <= height; j++)
                    if (btn_prop[i, j] == -1)
                        win = false;

            if (win)
            {
                WinGame();
            }
        }

        private void Discover_Map()
        {
            for (int i = 1; i <= width; i++)
                for (int j = 1; j <= height; j++)
                    if (btn[i, j].Enabled == true)
                    {
                        set_ButtonImage(i, j);
                    }
        }

        private void Fail_game()
        {
            failed = true;
            Discover_Map();
            MessageBox.Show("You Failed!");
        }

        private void WinGame()
        {
            failed = true;
            Discover_Map();
            gameProgress.Value = 0;
            MessageBox.Show("Win !");
        }
        private void Check_ClickWin()
        {
            bool win = true;
            for (int i = 1; i <= width; i++)
                for (int j = 1; j <= height; j++)
                    if (btn[i, j].Enabled == true && saved_btn_prop[i, j] != -1)
                        win = false;

            if (win)
            {
                WinGame();
            }
        }

        void GenerateMap(int x, int y, int mines)
        {
            Random rand = new Random();
            List<int> coordinate_x = new List<int>();
            List<int> coordinate_y = new List<int>();

            while (mines > 0)
            {
                coordinate_x.Clear();
                coordinate_y.Clear();

                for (int i = 1; i <= x; i++)
                    for (int j = 1; j <= y; j++)
                        if (btn_prop[i, j] != -1)
                        {
                            coordinate_x.Add(i);
                            coordinate_y.Add(j);
                        }

                int randNum = rand.Next(0, coordinate_x.Count);
                btn_prop[coordinate_x[randNum], coordinate_y[randNum]] = -1;
                saved_btn_prop[coordinate_x[randNum], coordinate_y[randNum]] = -1;
                mines--;
            }
        }

        private void StartGame()
        {
            switch (difficulty.Text)
            {
                case "Easy":
                    mines = (int)(height * width * easy);
                    break;

                case "Medium":
                    mines = (int)(height * width * medium);
                    break;

                case "Hard":
                    mines = (int)(height * width * hard);
                    break;
            }

            cabbage_num = mines;
            failed = false;

            gameProgress.Value = 0;
            gameProgress.Maximum = height * width - mines;

            timer.Start();
            second = 0;
            minute = 0;

            remainingFlags.Text = "Cabbages: " + cabbage_num;
            losed_weight.Text = "Weight Loss ";
            // loss_number.Text += 0;
                CreateButtons(width, height);

            GenerateMap(width, height, mines);
            SetMapNumbers(width, height);

        }


        private void set_ButtonImage(int x, int y)
        {
            btn[x, y].Enabled = false;
            btn[x, y].BackgroundImageLayout = ImageLayout.Stretch;

            if (failed && btn_prop[x, y] == cabbage_num_value)
                btn_prop[x, y] = saved_btn_prop[x, y];

            if (failed)
                timer.Stop();

            switch (btn_prop[x, y])
            {
                case 0:
                    btn[x, y].Text = "";
                    EmptySpace(x, y);
                    break;

                case 1:
                    btn[x, y].Text = "1";
                    break;

                case 2:
                    btn[x, y].Text = "2";
                    break;

                case 3:
                    btn[x, y].Text = "3";
                    break;

                case 4:
                    btn[x, y].Text = "4";
                    break;

                case 5:
                    btn[x, y].Text = "5";
                    break;

                case 6:
                    btn[x, y].Text = "6";
                    break;

                case 7:
                    btn[x, y].Text = "7";
                    break;

                case 8:
                    btn[x, y].Text = "8";
                    break;

                case -1:
                    //btn[x, y].Text = "bomb";
                    btn[x, y].BackgroundImage = final_prject_login_trial.Properties.Resources.png_clipart_fried_chicken_leg;
                    // btn[x, y].BackColor = Color.LightGray;
                    if (!failed)
                        Fail_game();
                    break;
            }

        }

        private void OneClick(object sender, EventArgs e)
        {
            coordinate = ((Button)sender).Location;
            int x = (coordinate.X - start_x) / buttonSize;
            int y = (coordinate.Y - start_y) / buttonSize;

            if (btn_prop[x, y] != cabbage_num_value)
            {
                ((Button)sender).Enabled = false;
                ((Button)sender).Text = "";

                ((Button)sender).BackgroundImageLayout = ImageLayout.Stretch;

                if (btn_prop[x, y] != -1 && !failed)
                {
                    Check_ClickWin();
                }

                set_ButtonImage(x, y);
            }
        }
        private void RightClick(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Right)
            {

                coordinate = ((Button)sender).Location;
                int x = (coordinate.X - start_x) / buttonSize;
                int y = (coordinate.Y - start_y) / buttonSize;

                if (btn_prop[x, y] != cabbage_num_value && cabbage_num > 0)
                {
                    btn[x, y].BackgroundImageLayout = ImageLayout.Stretch;
                    //btn[x, y].Text = "flag";
                    btn[x, y].BackgroundImage = final_prject_login_trial.Properties.Resources.veg;
                    btn_prop[x, y] = cabbage_num_value;
                    cabbage_num--;
                    Check_FlagWin();
                }
                else
                    if (btn_prop[x, y] == cabbage_num_value)
                {
                    btn_prop[x, y] = saved_btn_prop[x, y];
                    btn[x, y].BackgroundImageLayout = ImageLayout.Stretch;
                    btn[x, y].BackgroundImage = null;
                    cabbage_num++;
                }

                remainingFlags.Text = "Cabbages: " + cabbage_num;
            }
        }
        private void CreateButtons(int x, int y)
        {
            for (int i = 1; i <= x; ++i)
                for (int j = 1; j <= y; ++j)
                {
                    btn[i, j] = new Button();
                    btn[i, j].SetBounds(i * buttonSize + start_x, j * buttonSize + start_y, distance, distance);
                    btn[i, j].Click += new EventHandler(OneClick);
                    btn[i, j].MouseUp += new MouseEventHandler(RightClick);
                    btn_prop[i, j] = 0;
                    saved_btn_prop[i, j] = 0;
                    btn[i, j].TabStop = false;
                    //Controls.Add(btn[i, j]);
                    panel1.Controls.Add(btn[i, j]);
                    btn[i, j].FlatStyle = FlatStyle.Flat;
                    btn[i, j].FlatAppearance.BorderSize = 1;
                    btn[i, j].FlatAppearance.BorderColor = System.Drawing.Color.SeaGreen;
                    btn[i, j].BackColor = System.Drawing.Color.FloralWhite;
                }
        }

        private void Warnings(int id)
        {
            switch (id)
            {
                case 1:
                    MessageBox.Show("Empty Fields !");
                    break;
                case 2:
                    MessageBox.Show("Wrong Input !");
                    break;

            }
        }

        private bool hasLetters(string s)
        {
            for (int i = 0; i < s.Length; i++)
                if (!Char.IsDigit(s, i))
                    return true;

            return false;
        }

        private bool CorrectFields()
        {
            bool result = true;

            if (heightBox.Text == "" || widthBox.Text == "" || difficulty.Text == "")
            {
                Warnings(1);
                result = false;
            }
            else
            if (heightBox.Text != "" && widthBox.Text != "" && difficulty.Text != "")
            {
                if (hasLetters(heightBox.Text) || hasLetters(widthBox.Text))
                {
                    Warnings(2);
                    result = false;
                }
            }

            return result;
        }

        private void SetDimensions()
        {
            height = int.Parse(heightBox.Text);
            width = int.Parse(widthBox.Text);

            if (height > 100)
                height = 100;
            else
                if (height < 5)
                height = 5;

            if (width > 100)
                width = 100;
            else
                if (width < 5)
                width = 5;

            heightBox.Text = height.ToString();
            widthBox.Text = width.ToString();

        }

        private void ResetGame(int x, int y)
        {
            for (int i = 1; i <= x; i++)
                for (int j = 1; j <= y; j++)
                {
                    btn[i, j].Enabled = true;
                    btn[i, j].Text = "";
                    btn[i, j].BackgroundImage = null;
                    btn_prop[i, j] = 0;
                    saved_btn_prop[i, j] = 0;
                }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            second++;

            if (second == 60)
            {
                minute++;
                second = 0;
            }

            second_label.Text = second.ToString();
            minute_label.Text = minute.ToString();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, panel1.ClientRectangle, Color.DarkGreen, ButtonBorderStyle.Solid);
        }

        private void Play_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, Play.ClientRectangle, Color.Transparent, ButtonBorderStyle.None);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void TableMargins(int x, int y)
        {
            start_x = (panel1.Size.Width - (width + 2) * distance) / 2;
            start_y = (panel1.Size.Height - (height + 2) * distance) / 2;
        }

        private void Play_Click(object sender, EventArgs e)
        {

            if (CorrectFields())
            {
                if (!firstPlay)
                    for (int i = 1; i <=height; i++)
                        for (int j = 1; j <= width; j++)
                            btn[i, j].Dispose();
                losed_weight.Visible = true;
                remainingFlags.Visible = true;
                label4.Visible = true;
                SetDimensions();
                TableMargins(height, width);

                if (firstPlay)
                {
                    StartGame();
                    firstPlay = false;

                    //widthBox.Enabled = false;
                    //heightBox.Enabled = false;
                }
                else
                {
                   //ResetGame(width, height);
                    StartGame();
                }
            }

        }

    }
}

