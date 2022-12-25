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
        public bool Selected { get; set; }

        public static void SelectEndTaskUser(int? userID, bool value = false)
        {
            string query = @"UPDATE `todolist`.`users`
                                SET
                                `Selected` = @value
                                WHERE `ID_User` = @userID;";


            using (MySqlConnection connection = new MySqlConnection("Database=todolist;Host=127.0.0.1;Port=3306;User Id=root;"))
            {
                connection.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.Add("@userID", MySqlDbType.Int32).Value = userID;
                    cmd.Parameters.Add("@value", MySqlDbType.Int32).Value = value == true ? 1 : 0;
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


        public static bool GetSelectedUser(int? UserID)
        {
            bool isSelected = false;
            string query = @"SELECT 
                                Selected 
                                FROM users
                                WHERE ID_User = @UserID;";
            using (MySqlConnection connection = new MySqlConnection("Database=todolist;Host=127.0.0.1;Port=3306;User Id=root;"))
            {
                connection.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.Add("@UserID", MySqlDbType.Int32).Value = UserID;
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            try
                            {
                                isSelected = reader.GetByte(0) == 1 ? true : false; ;


                            }
                            catch (Exception ex)
                            {

                                throw ex;
                            }

                        }

                    }

                }

            }
            return isSelected;

        }



        public static UserModel GetUser(int? UserID)
        {
            UserModel user = new UserModel();
            string query = @"SELECT 
                                ID_User 
                                ,Name  
                                ,JoinDate  
                                ,LastLoginDate 
                                ,Selected 
                                FROM users
                                WHERE ID_User = @UserID;";
            using (MySqlConnection connection = new MySqlConnection("Database=todolist;Host=127.0.0.1;Port=3306;User Id=root;"))
            {
                connection.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.Add("@UserID", MySqlDbType.Int32).Value = UserID;
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            try
                            {
                                user.ID_User = reader.GetInt32(0);
                                user.Name = reader.IsDBNull(1) || reader.GetString(1) == "" ? string.Empty : reader.GetString(1);
                                user.JoinDate = reader.IsDBNull(2) ? (DateTime?)null : reader.GetDateTime(2);
                                user.LastLogin = reader.IsDBNull(3) ? (DateTime?)null : reader.GetDateTime(3);
                                user.Selected = reader.GetByte(4) == 1 ? true : false;

                            }
                            catch (Exception ex)
                            {

                                throw ex;
                            }

                        }

                    }

                }

            }
            return user;

        }

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

            string query = string.Format(@"SELECT 
                                ID_User 
                                ,Name  
                                ,JoinDate
                                ,LastLoginDate
                                ,Selected 
                                FROM users;");
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
                                x.JoinDate = reader.IsDBNull(2) ? (DateTime?)null : Convert.ToDateTime(reader.GetValue(2));
                                x.LastLogin = reader.IsDBNull(3) ? (DateTime?)null : Convert.ToDateTime(reader.GetValue(3));
                                x.Selected = reader.GetByte(4) == 1 ? true : false;
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