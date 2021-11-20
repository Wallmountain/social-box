using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace final_prject_login_trial
{
    public partial class graph : Form
    {
        string account = "";
        string BeginDate = "";
        string EndDate = "";
        data d = new data();
        int begin_date = 0;
        int end_date = 0;
        List<string>[] list = new List<string>[6];
        double daily_calories;
        double min_protein;
        double max_protein;
        double min_carbs;
        double max_carbs;
        double min_fat;
        double max_fat;
        List<double> daily_max_list = new List<double>();
        List<double> daily_min_list = new List<double>();
        /* list[0] = date
         * list[1]= calories
         * list[2]=carbonhydrate
         * list[3]=protein
         * list[4]=fat
         * list[5]=sugar
         * protein 12-20%
         * carbs 45-60%
         * fat20-35%
         * sugar no  more than 150 calories
         */
        public graph()
        {
            InitializeComponent();
        }

        Form form;
        public graph(string username, Form f)
        {
            InitializeComponent();
            account = username;
            form = f;

            this.FormClosed += new FormClosedEventHandler(graph_Close);
        }

        private void graph_Close(object sender, EventArgs e)
        {
            form.Show();
        }

        private void graph_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 6; ++i)
            {
                list[i] = new List<string>();
            }
            BegindatePicker.Visible = true;
            EnddatePicker.Visible = true;
            piechart.Visible = false;
            line_Chart.Visible = false;
            datePickbutton.Enabled = false;

            BeginDate = BegindatePicker.Value.Year.ToString() + BegindatePicker.Value.Month.ToString() + BegindatePicker.Value.Day.ToString();
            begin_date = int.Parse(BeginDate);
            EndDate = EnddatePicker.Value.Year.ToString() + EnddatePicker.Value.Month.ToString() + EnddatePicker.Value.Day.ToString();
            end_date = int.Parse(EndDate);

            d.select("account_data");
            d.where_account(account);
            d.work();
            d.connect();
            daily_calories = Convert.ToDouble(d.rd[7]);
            d.disconnect();

            min_protein = daily_calories * 0.12;
            max_protein = daily_calories * 0.20;
            min_carbs = daily_calories * 0.45;
            max_carbs = daily_calories * 0.60;
            min_fat = daily_calories * 0.20;
            max_fat = daily_calories * 0.35;
            line_Chart.Series[1].BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            line_Chart.Series[1].BorderWidth = 3;
            line_Chart.Series[2].BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            line_Chart.Series[2].BorderWidth = 3;
            line_Chart.Series[0].BorderWidth = 3;
        }

        private void BegindatePicker_ValueChanged(object sender, EventArgs e)
        {
            BeginDate = BegindatePicker.Value.Month.ToString() + BegindatePicker.Value.Day.ToString() + BegindatePicker.Value.Year.ToString();
            begin_date = int.Parse(BeginDate);
            // BeginDate += BegindatePicker.Value.Month.ToString();
            //BeginDate += BegindatePicker.Value.Day.ToString();
        }

        private void EnddatePicker_ValueChanged(object sender, EventArgs e)
        {
            EndDate = EnddatePicker.Value.Month.ToString() + EnddatePicker.Value.Day.ToString() + EnddatePicker.Value.Year.ToString();
            end_date = int.Parse(EndDate);
        }

        private void Read(int begin, int end)
        {
            d.select(account + "2");
            d.between(begin, end);
            d.work();
            d.con();
            do
            {
                while (d.rd.Read())
                {
                    for (int i = 0; i < 6; i++)
                    {
                        list[i].Add(d.rd[i].ToString());                
                    }
                }
            } while (d.next());
            d.disconnect();


            for (int i = 0; i < list[0].Count; ++i)
            {
                list[2][i] = (Convert.ToDouble(list[2][i]) * 4).ToString();
                list[3][i] = (Convert.ToDouble(list[2][i]) * 4).ToString();
                list[5][i] = (Convert.ToDouble(list[2][i]) * 4).ToString();
                list[4][i] = (Convert.ToDouble(list[2][i]) * 9).ToString();
            }
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            datePickbutton.Enabled = true;
        }
        private void datePickbutton_Click(object sender, EventArgs e)
        {
            Read(begin_date, end_date);
            //piechart
            if (comboBox1.SelectedIndex == 5)
            {
                piechart.Series[0]["PieLabelStyle"] = "inside";
                piechart.Series[0].IsValueShownAsLabel = true;
                piechart.Visible = true;
                //double calories_avg = 0;
                double carbon_avg = 0;
                double protein_avg = 0;
                double fat_avg = 0;
                double sugar_avg = 0;
                line_Chart.Visible = false;

                for (int i = 0; i < list[0].Count; ++i)
                {
                    //calories_avg += (Convert.ToDouble(list[1][i])) / (double)list[0].Count;
                    carbon_avg += Convert.ToDouble(list[2][i]) / (double)list[0].Count;
                    protein_avg += Convert.ToDouble(list[3][i]) / (double)list[0].Count;
                    fat_avg += Convert.ToDouble(list[4][i]) / (double)list[0].Count;
                    sugar_avg += Convert.ToDouble(list[5][i]) / (double)list[0].Count;
                }

                double[] avg = { carbon_avg, protein_avg, fat_avg, sugar_avg };
                string[] ingredient = {"carbonhydrate", "protein", "fat", "sugar" };
                piechart.Series[0].Points.DataBindXY(ingredient, avg);
            }
            //linechart
            if (comboBox1.SelectedIndex == 0)
            {
                line_Chart.Visible = true;
                line_Chart.Series[0].Points.DataBindXY(list[0], list[1]);
                for (int i = 0; i < list[0].Count; ++i)
                    daily_max_list.Add(daily_calories);
                line_Chart.Series[1].Points.DataBindXY(list[0], daily_max_list);
                line_Chart.Series[2].Enabled = false;
            }
            if (comboBox1.SelectedIndex == 1)
            {
                line_Chart.Visible = true;
                line_Chart.Series[0].Points.DataBindXY(list[0], list[2]);
                line_Chart.Series[2].Enabled = true;
                for (int i = 0; i < list[0].Count; ++i)
                {
                    daily_max_list.Add(max_carbs);
                    daily_min_list.Add(min_carbs);
                }
                line_Chart.Series[1].Points.DataBindXY(list[0], daily_max_list);
                line_Chart.Series[2].Points.DataBindXY(list[0], daily_min_list);

            }
            if (comboBox1.SelectedIndex == 2)
            {
                line_Chart.Visible = true;
                line_Chart.Series[0].Points.DataBindXY(list[0], list[3]);
                line_Chart.Series[2].Enabled = true;
                for (int i = 0; i < list[0].Count; ++i)
                {
                    daily_max_list.Add(max_protein);
                    daily_min_list.Add(min_protein);
                }
                line_Chart.Series[1].Points.DataBindXY(list[0], daily_max_list);
                line_Chart.Series[2].Points.DataBindXY(list[0], daily_min_list);
            }
            if (comboBox1.SelectedIndex == 3)
            {
                line_Chart.Visible = true;
                line_Chart.Series[0].Points.DataBindXY(list[0], list[4]);
                line_Chart.Series[2].Enabled = true;
                for (int i = 0; i < list[0].Count; ++i)
                {
                    daily_max_list.Add(max_fat);
                    daily_min_list.Add(min_fat);
                }
                line_Chart.Series[1].Points.DataBindXY(list[0], daily_max_list);
                line_Chart.Series[2].Points.DataBindXY(list[0], daily_min_list);
            }
            if (comboBox1.SelectedIndex == 4)
            {
                line_Chart.Visible = true;
                line_Chart.Series[2].Enabled = false;
                line_Chart.Series[0].Points.DataBindXY(list[0], list[5]);
                for (int i = 0; i < list[0].Count; ++i)
                {
                    daily_max_list.Add(150);
                }
                line_Chart.Series[1].Points.DataBindXY(list[0], daily_max_list);
            }
            //clear list
            for (int i = 0; i < 6; ++i)
            {
                list[i].Clear();
            }
            daily_max_list.Clear();
            daily_min_list.Clear();
        }

        private void line_Chart_Click(object sender, EventArgs e)
        {

        }
    }
}
