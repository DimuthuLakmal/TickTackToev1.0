using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TickTackToev1_0
{
    class CDBC
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        void dbConn()
        {
            server = "localhost";
            database = "tictactoe";
            uid = "root";
            password = "123";
            string connectionString = "SERVER=" + server + ";" +
                "DATABASE=" + database + ";" +
                "UID=" + uid + ";" +
                "PASSWORD=" + password + ";" +
                "PORT= 3306";
            connection = new MySqlConnection(connectionString);
        }

        private bool OpenConnection()
        {
            try
            {
                dbConn();
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server. Contact......");
                        break;
                    case 1045:
                        MessageBox.Show("Invalid username/password, please.....");
                        break;
                }
                return false;
            }
        }

        public void Insert(string query)
        {
            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(string query)
        {
            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = query;
                cmd.Connection = connection;
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(string query)
        {
            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
            }
        }

        public void Select(string query)
        {
            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                if (dataReader.Read())
                {
                    MessageBox.Show(dataReader["un"] + "-" + dataReader["pass"]);
                }
                else
                {
                    MessageBox.Show("Sorry.....");
                }
                dataReader.Close();
            }
        }

        public DataSet SelectDataSet(string query)
        {
            DataSet ds = new DataSet();
            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);

                da.Fill(ds);
                return ds;
            }
            else
            {
                return ds;
            }
        }
    }
}
