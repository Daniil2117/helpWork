using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp1Rab.CLasses
{
    class Staffs
    {
        public string Name { get; set; }
        public string Birthday { get; set; }
        public string Telephon { get; set; }
        public string Staff { get; set; }


        public Staffs(string name, string birthday, string telephon, string staff)
        {
            Name = name;
            Birthday = birthday;
            Telephon = telephon;
            Staff = staff;
        }

        public static List<Staffs> LoadFromDB()
        {
           // SqlCommand command = new SqlCommand("SELECT * FROM Employee", Connection.Connect);

            List<Staffs> spisok = new List<Staffs>();

            try
            {
                using(SqlConnection connection = new SqlConnection(Connection.Connect))
                {
                    connection.Open();
                    string sqlExp = "SELECT *FROM Employee";
                    SqlCommand cmd = new SqlCommand(sqlExp, connection);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                        spisok.Add(new Staffs(
                            reader.GetString(1),
                            reader.GetString(2),
                            reader.GetString(3),
                            reader.GetString(4)
                            ));

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return spisok;
        }

        internal static string[] GetDataUser(int selectionGridIndex)
        {
            SqlConnection connection = new SqlConnection(Connection.Connect);
            string[] strings = new string[3];
            int p = 0;
            try
            {
                connection.Open();
                string sqlExp = $"SELECT *FROM Employee";
                SqlCommand cmd = new SqlCommand(sqlExp, connection);
                SqlDataReader r = cmd.ExecuteReader();
                if (r.HasRows)
                {
                    while (r.Read())
                    {
                        if (p == selectionGridIndex)
                        {
                            strings[0] = r[1].ToString();
                            strings[1] = r[2].ToString();
                            strings[2] = r[3].ToString();
                            strings[3] = r[4].ToString();
                            break;
                        }
                        else
                        {
                            p++;
                        }
                    }
                    r.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            connection.Close();
            return strings;
        }

        //метод добавляющий новую запись в БД
        public static void AddNewStaff(string name, string birthday, string telephone, string staff)
        {
            SqlConnection connection = new SqlConnection(Connection.Connect);
            try
            {
                connection.Open();
                string sqlExp = $"INSERT INTO Employee Values('{name}','{birthday}','{telephone}','{staff}')";
                SqlCommand cmd = new SqlCommand(sqlExp, connection);
                SqlDataReader r = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            connection.Close();
        }


        
        //метод обновляющий запись
        public static void UpdateStaff(string name, string birthday, string telephone, string staff)
        {
            string[] fields = new string[4];
            fields = Staffs.GetDataUser(Pages.PageMain.selectionGridIndex);

            SqlConnection connection = new SqlConnection(Connection.Connect);
            try
            {
                connection.Open();
                string sqlExp = $"UPDATE Employee SET Name = '{name}',Birthday ='{birthday}',Telephone ='{telephone}',Staff ='{staff}'" +
                    $"WHERE Name = '{fields[0]}' AND Birthday = '{fields[1]}' AND Telephone = '{fields[2]}' AND Staff = '{fields[3]}'";
                SqlCommand cmd = new SqlCommand(sqlExp, connection);
                SqlDataReader r = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            connection.Close();
        }

        //метод удаляющий запись
        public static void DeleteStaff()
        {
            string[] fields = new string[4];
            fields = Staffs.GetDataUser(Pages.PageMain.selectionGridIndex);

            SqlConnection connection = new SqlConnection(Connection.Connect);
            try
            {
                connection.Open();
                string sqlExp = $"DELETE Employee WHERE Name = '{fields[0]}' AND Birthday = '{fields[1]}' " +
                    $"AND Telephone = '{fields[2]}' AND Staff = '{fields[3]}'";
                SqlCommand cmd = new SqlCommand(sqlExp, connection);
                SqlDataReader r = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            connection.Close();
        }
    }
}
