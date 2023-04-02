using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace olymph8
{
    public class DataBaeController
    {

        string connStr = $"server=127.0.0.1;user=root;database=educational_part;";
        MySqlConnection conn;

        public DataBaeController()
        {
            conn = new MySqlConnection(connStr);
        }
        public bool auth(string username, string password)
        {
            string sql = $"SELECT * FROM users WHERE login = \"{username}\" and  password =\"{password}\"";
            try { conn.Open(); } catch (Exception err) { Console.WriteLine(err); }
            MySqlCommand command = new MySqlCommand(sql, conn);
            try
            {
                MySqlDataReader reader = command.ExecuteReader();

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
            }
            catch { }
            return false;
        }


        public List<string> GetGroup()
        {
            List<string> list = new List<string>();
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                MySqlCommand command = new MySqlCommand("SELECT * FROM `GroupList`", conn);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(reader.GetString(1));
                    }
                }
            }
            return list;
        }
        private bool SeachTabelName(string Name) {
            List<string> list = GetGroup();
            return list.Contains(Name);
        }

        public bool CreateTable(string tableName)
        {

            if (SeachTabelName(tableName))return true;
           
            try { conn.Open(); } catch (Exception err) { Console.WriteLine(err); return false; }
            MySqlCommand Create_table = new MySqlCommand($"INSERT INTO GroupList(name) VALUES (\"{tableName}\")", conn);
            Create_table.ExecuteNonQuery();
             Create_table = new MySqlCommand($"CREATE TABLE `{tableName.ToLower()}`( id int AUTO_INCREMENT PRIMARY KEY, name varchar(30), Term1 varchar(20), FK1 varchar(20) , Sm_Work1 int, Term2 int, FK2 varchar(20), Sm_Work2 int , Teacher varchar(255), Konsult int )", conn);
            Create_table.ExecuteNonQuery();
        

           
            Console.WriteLine(tableName);

            conn.Close();
            return true;
        }


        public void removeData(string tableName)
        {
            try { conn.Open(); } catch (Exception err) { Console.WriteLine(err); return; }
            MySqlCommand Create_table = new MySqlCommand($"DELETE FROM `{tableName}`", conn);
            Create_table.ExecuteNonQuery();  
            Create_table = new MySqlCommand($"ALTER TABLE `{tableName}` AUTO_INCREMENT = 1", conn);
            Create_table.ExecuteNonQuery();
            conn.Clone();
        }

        public bool AddTta( string name, string Term1, string  FK1, string Sm_Work1, 
            string  Term2, string FK2, string Sm_Work2, string Teacher,
            string Konsult, string GroupName)
        {

            try
            {
                conn.Close();
            }
            catch (Exception err) { }
          
            try { conn.Open(); } catch (Exception err) { 
                Console.WriteLine(err);  return false; }

                MySqlCommand Create_table = new MySqlCommand($"INSERT INTO {GroupName}(name, Term1, FK1, Sm_Work1, Term2, FK2, Sm_Work2, Teacher, Konsult) VALUES (\"{name}\",\"{Term1}\",\"{FK1}\",\"{Sm_Work1}\" ,\"{Term2}\",\"{FK2}\" ,\"{Sm_Work2}\",\"{Teacher}\",\"{Konsult}\")", conn);
                Create_table.ExecuteNonQuery();
            

            conn.Close();

            return true;

            
        }

    }


}


