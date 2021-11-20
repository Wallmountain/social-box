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
    public partial class Form3 : Form
    {
        SearchMenu f;
        data d = new data();
        string food;
        string account;
        int mode;
        string date;
        List<string> list_1 = new List<string>();
        List<string> list_2 = new List<string>();

        public Form3()
        {
            InitializeComponent();
        }
        public Form3(string name, int food_mode, SearchMenu form, string username, string _date)
        {
            InitializeComponent();
            food = name;
            f = form;
            this.FormClosed += new FormClosedEventHandler(Form3_Close);
            account = username;
            mode = food_mode;
            date = _date;
        }


        private void Form3_Load(object sender, EventArgs e)
        {
            d.select("food");
            d.where(food);
            d.work();
            d.connect();
            food_name.Text = d.rd[0].ToString();
            protein_value.Text = d.rd[3].ToString();  calories_value.Text = d.rd[1].ToString(); fat_value.Text = d.rd[4].ToString();
            sugar_value.Text = d.rd[5].ToString(); carbs_value.Text = d.rd[2].ToString(); cholesterol_value.Text = d.rd[10].ToString();
            grams_value.Text = d.rd[6].ToString(); sfat_value.Text = d.rd[9].ToString(); fiber_value.Text = d.rd[8].ToString();
            foodgroup_value.Text = d.rd[7].ToString(); water_value.Text = d.rd[12].ToString(); calcium_value.Text = d.rd[11].ToString();
            d.disconnect();
            list_1.Add("protein");
            list_1.Add("sugar");
            list_1.Add("fat");
            list_1.Add("carbonhydrate");
            list_1.Add("fiber");

            list_2.Add(protein_value.Text);
            list_2.Add(sugar_value.Text);
            list_2.Add(fat_value.Text);
            list_2.Add(carbs_value.Text);
            list_2.Add(fat_value.Text);

            chart.Series[0].Points.DataBindXY(list_1, list_2);
            //chart.Series[0]["PieLabelStyle"] = "outside";
        }

        private void Form3_Close(object sender, EventArgs e)
        {
            f.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int num;
            num = Int32.Parse(date);
     
            int amount = Convert.ToInt16(comboBox1.Text);

            d.insert_personal_food(account,num,food,amount,mode);
            d.work();
            d.select(account+"2");
            d.where(num);
            d.work();
            d.con();
            if (d.rd.Read())
            {
                float[] a=new float[5];
                for (int i = 0; i < 5; i++)
                    a[i] = float.Parse(d.rd[i + 1].ToString());
                d.disconnect();
                d.delete(account + "2");
                d.where(num);
                d.work();
                d.insert_personal_daily(account, num, float.Parse(calories_value.Text) * amount+a[0], float.Parse(carbs_value.Text) * amount+a[1], float.Parse(protein_value.Text) * amount+a[2], float.Parse(fat_value.Text) * amount+a[3], float.Parse(sugar_value.Text) * amount+a[4]);
                d.work();
            }
            else
            {
                d.disconnect();
                d.insert_personal_daily(account, num, float.Parse(calories_value.Text) * amount, float.Parse(carbs_value.Text) * amount, float.Parse(protein_value.Text) * amount, float.Parse(fat_value.Text) * amount, float.Parse(sugar_value.Text) * amount);
                d.work();
            }
            this.Hide();
            Main main = new Main(account);
            main.Show();
        }

        private void chart_Click(object sender, EventArgs e)
        {

        }
    }
}
