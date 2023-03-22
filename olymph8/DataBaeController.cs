using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace olymph8
{
    public class DataBaeController
    {

         string connStr = $"server=127.0.0.1;user=admin;database=olymph8;password=123;";
        MySqlConnection conn;

        public DataBaeController()
        {
            conn = new MySqlConnection(connStr);
        }

        public bool auth(string username, string password)
        {
            

            string sql = $"SELECT * FROM users WHERE login = \"{username}\" and  password =\"{password}\"";
            try { conn.Open(); } catch { }
            MySqlCommand command = new MySqlCommand(sql, conn);
            // объект для чтения ответа сервера
            MySqlDataReader reader = command.ExecuteReader();
            // читаем результат
            while (reader.Read())
            {

                ThisUsers.login = reader[0].ToString();
                ThisUsers.pass = reader[1].ToString();
                ThisUsers.role = reader[2].ToString();

                Console.WriteLine(reader[0].ToString() + " " + reader[1].ToString() + " " + reader[2].ToString());
                reader.Close();
                return true;
            }
            reader.Close(); 
           
            conn.Close();
            return false;
        }
    }
}
