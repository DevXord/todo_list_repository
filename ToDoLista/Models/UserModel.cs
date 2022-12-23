using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Xml.Linq;

namespace ToDoLista.Models
{
    public class UserModel
    {
        public int? ID_User { get; set; }
        public string Name { get; set; }
        public DateTime? JoinDate { get; set; }
        public DateTime? LastLogin { get; set; }


        public static int GetIdUserWithName(string userName)
        {
            int userID = -1;
            string query = @"SELECT 
                                ID_User 
                                FROM users
                                WHERE Name = @userName;";
            using (MySqlConnection connection = new MySqlConnection("Database=todolist;Host=127.0.0.1;Port=3306;User Id=root;"))
            {
                connection.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.Add("@userName", MySqlDbType.String).Value = userName;
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            try
                            {

                                userID = reader.GetInt32(0);
                 

                            }
                            catch (Exception ex)
                            {

                                throw ex;
                            }

                        }

                    }

                }

            }
            return userID;

        }

        public static List<UserModel> ShowAllUser()
        {
            List<UserModel> users = new List<UserModel>();
            
            string query = @"SELECT 
                                ID_User 
                                ,Name  
                                ,JoinDate  
                                ,LastLoginDate 
                                FROM users;";
            using (MySqlConnection connection = new MySqlConnection("Database=todolist;Host=127.0.0.1;Port=3306;User Id=root;"))
            {
                connection.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            try
                            {
                                UserModel x = new UserModel();
                                x.ID_User = reader.GetInt32(0);
                                x.Name = reader.IsDBNull(1) || reader.GetString(1) == "" ? string.Empty : reader.GetString(1);
                                x.JoinDate = reader.IsDBNull(2)  ? (DateTime?)null : reader.GetDateTime(2);
                                x.LastLogin = reader.IsDBNull(3) ? (DateTime?)null : reader.GetDateTime(3);

                                users.Add(x);

                            }
                            catch (Exception ex)
                            {

                                throw ex;
                            }

                        }

                    }

                }

            }
            return users;

        }


        public static void CreateNewUser(string name)
        {
            string query = @"INSERT INTO `todolist`.`users`
                            (
                            `Name`,
                            `JoinDate`,
                            `LastLoginDate`)
                            VALUES(
                            @userName,
                            @JoinDate,
                            @LastLoginDate);";


            using (MySqlConnection connection = new MySqlConnection("Database=todolist;Host=127.0.0.1;Port=3306;User Id=root;"))
            {
                connection.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.Add("@userName", MySqlDbType.String).Value = name;
                    cmd.Parameters.Add("@JoinDate", MySqlDbType.DateTime).Value = DateTime.Now;
                    cmd.Parameters.Add("@LastLoginDate", MySqlDbType.DateTime).Value = DateTime.Now;
                    try
                    {
                         
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception e)
                    {

                        throw e;
                    }
                    
                }

            }

        }

        public static void DeleteUser(int? userID)
        {
            string query = @"DELETE FROM `todolist`.`users`
                             WHERE ID_User = @UserId;";


            using (MySqlConnection connection = new MySqlConnection("Database=todolist;Host=127.0.0.1;Port=3306;User Id=root;"))
            {
                connection.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.Add("@UserId", MySqlDbType.Int32).Value = userID;
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception e)
                    {

                        throw e;
                    }

                }

            }

        }

    }
}