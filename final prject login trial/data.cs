using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace final_prject_login_trial
{
    class data
    {
        public data()
        {
            conn = new SqlConnection();
            conn.ConnectionString = path;
            conn.Open();
            cmd = new SqlCommand(null, conn);
            account[0] = "account"; account[1] = "password"; account[2] = "gender"; account[3] = "height";
            account[4] = "weight"; account[5] = "age"; account[6] = "lifestyle"; account[7] = "daily_calories";
            food[0] = "day"; food[1] = "calories"; food[2] = "carbohydrate"; food[3] = "protein";
            food[4] = "fat"; food[5] = "sugar";
        }
        public void create(string name)
        {
            sqlStr = "CREATE TABLE [dbo].[" + name;
            sqlStr += "1]([day] INT NOT NULL, [name] NVARCHAR(50) NOT NULL, [number] INT NOT NULL, [meal] INT NOT NULL)";
            work();
            sqlStr = "CREATE TABLE[dbo].[" + name;
            sqlStr += "2]([day] INT NOT NULL PRIMARY KEY,[calories] FLOAT NOT NULL,";
            sqlStr += "[carbohydrate] FLOAT NOT NULL, [protein] FLOAT NOT NULL, ";
            sqlStr += "[fat] FLOAT NOT NULL, [sugar] FLOAT NOT NULL)";
            work();
        }
        public void where(int day, string name, int meal)
        {
            sqlStr += "WHERE day = " + day + " AND name = '" + name + "' AND meal = " + meal + ";";
        }
        public void where(int day)
        {
            sqlStr += "WHERE day = " + day + ";";
        }
        public void where(string name)
        {
            sqlStr += "WHERE name = '" + name + "';";
        }
        public void where_account(string name)
        {
            sqlStr += "WHERE account = '" + name + "';";
        }
        public void delete(string name)
        {
            sqlStr += "DELETE FROM " + name + " ";
        }
        public void select(string name)
        {
            sqlStr += "SELECT * FROM " + name + " ";
        }
        public void between(int a, int b)
        {
            sqlStr += "WHERE day BETWEEN " + a + " AND " + b;
        }
        public void insert_account(string accoun, string password, int gender, float height, float weight, float age, int lifestyle, float daily_calories, string pic)
        {
            sqlStr = "INSERT INTO account_data (";
            sqlStr += account[0];
            for (int i = 1; i < 8; i++)
                sqlStr += "," + account[i];
            sqlStr += ",picture) VALUES (";
            sqlStr += "'" + accoun + "',";
            sqlStr += "'" + password + "',";
            sqlStr += gender + ",";
            sqlStr += height + ",";
            sqlStr += weight + ",";
            sqlStr += age + ",";
            sqlStr += lifestyle + ",";
            sqlStr += daily_calories + ",";
            sqlStr +=  "'" + pic + "')";
        }
        public void insert_personal_food(string account, int day, string name, int number, int meal)
        {
            sqlStr = "INSERT INTO " + account + "1 (";
            sqlStr += "day,name,number,meal)";
            sqlStr += " VALUES (";
            sqlStr += day + ",";
            sqlStr += "'" + name + "',";
            sqlStr += number + ",";
            sqlStr += meal + ")";
        }
        public void insert_personal_daily(string account, int day, float calories, float carbohydrate, float protein, float fat, float sugar)
        {
            sqlStr = "INSERT INTO " + account + "2 (";
            sqlStr += food[0];
            for (int i = 1; i < 6; i++)
                sqlStr += "," + food[i];
            sqlStr += ") VALUES (";
            sqlStr += day + ",";
            sqlStr += "'" + calories + "',";
            sqlStr += "'" + carbohydrate + "',";
            sqlStr += "'" + protein + "',";
            sqlStr += "'" + fat + "',";
            sqlStr += sugar + ")";
        }
        public void work()
        {
            cmd.CommandText = sqlStr;
            cmd.ExecuteNonQuery();
            sqlStr = "";
        }
        public void connect()
        {
            rd = cmd.ExecuteReader();
            rd.Read();
        }

        public void con()
        {
            rd = cmd.ExecuteReader();
        }
        public bool next()
        {
            return rd.NextResult();
        }
        public void disconnect()
        {
            rd.Close();
        }
        ~data()
        {
            //conn.Close();

        }
        private string[] food = new string[6];
        private string[] account = new string[8];
        public string sqlStr = "";
        private string path = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename="+System.Environment.CurrentDirectory+@"\dataserver.mdf;Integrated Security=True";

       // private string path = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\IIMBA\OneDrive\Desktop\final prject login trial\final prject login trial\dataserver.mdf;Integrated Security=True";
        private SqlConnection conn;
        private SqlCommand cmd;
        public SqlDataReader rd;
    }
}
