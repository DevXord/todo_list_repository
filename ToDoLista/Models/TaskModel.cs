using Microsoft.Ajax.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace ToDoLista.Models
{
    public class TaskModel
    {

        public int ID_ToDo { get; set; }
        public int? User_ID { get; set; }
        public string Task { get; set; }
        public DateTime? EnteredDate { get; set; }
        public DateTime? EndDate { get; set; }
        public byte? IsToDo { get; set; }



        public static bool HasUserThisTask(int? userID,TaskModel task)
        {
            bool hasTask = false;
            string query = @"SELECT 
								count(ID_Task)

                                FROM tasks
                                left join users on users.ID_User = User_ID
                                WHERE User_ID = @UserID and Task = @Task and EndDate = @EndDate and users.Selected=0;";
            using (MySqlConnection connection = new MySqlConnection("Database=todolist;Host=127.0.0.1;Port=3306;User Id=root;"))
            {
                connection.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.Add("@UserID", MySqlDbType.Int32).Value = userID;
                    cmd.Parameters.Add("@Task", MySqlDbType.String).Value = task.Task;
                    cmd.Parameters.Add("@EndDate", MySqlDbType.DateTime).Value = task.EndDate;
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            try
                            {
                                hasTask = reader.GetInt32(0) >= 1 ? true : false;

                            }
                            catch (Exception ex)
                            {

                                throw ex;
                            }

                        }

                    }

                }

            }
            return hasTask;

        }

        public static bool HasUserTasks(int? userID)
        {
            bool hasTask = false;
            string query = @"SELECT 
								count(ID_Task)

                                FROM tasks
                                WHERE User_ID = @UserID;";
            using (MySqlConnection connection = new MySqlConnection("Database=todolist;Host=127.0.0.1;Port=3306;User Id=root;"))
            {
                connection.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.Add("@UserID", MySqlDbType.Int32).Value = userID;
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            try
                            {
                                hasTask = reader.GetInt32(0) >= 1 ? true : false;

                            }
                            catch (Exception ex)
                            {

                                throw ex;
                            }

                        }

                    }

                }

            }
            return hasTask;

        }

        public static List<TaskModel> ShowUserTasks(int? userID, bool showEndTasks = false)
        {
            List<TaskModel> tasks = new List<TaskModel>();
            string query = string.Format(@"SELECT 
								ID_Task
                                ,User_ID 
                                ,Task 
                                ,EnteredDate 
                                ,EndDate 
                                ,IsToDo 
                                FROM tasks
                                WHERE User_ID = @UserID {0} order by IsToDo desc ,EndDate asc;", showEndTasks ? "AND IsToDo = 0 " : "");
            using (MySqlConnection connection = new MySqlConnection("Database=todolist;Host=127.0.0.1;Port=3306;User Id=root;"))
            {
                connection.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.Add("@UserID", MySqlDbType.Int32).Value = userID;
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            try
                            {
                                TaskModel x = new TaskModel();
                                x.ID_ToDo = reader.GetInt32(0);
                                x.User_ID = reader.IsDBNull(1) ? null : (int?)reader.GetInt32(1);
                                x.Task = reader.IsDBNull(2) || reader.GetString(2) == "" ? string.Empty : reader.GetString(2);
                                x.EnteredDate = reader.IsDBNull(3) ? (DateTime?)null : (DateTime)reader.GetValue(3);
                                x.EndDate = reader.IsDBNull(4) ? (DateTime?)null : (DateTime)reader.GetValue(4);
                                x.IsToDo = reader.IsDBNull(5) ? (byte?)null : reader.GetByte(5);
                                tasks.Add(x);

                            }
                            catch (Exception ex)
                            {

                                throw ex;
                            }

                        }

                    }

                }

            }
            return tasks;

        }


        public static TaskModel GetTaskByID(int? taskID)
        {

            TaskModel task = new TaskModel();
            string query = @"SELECT 
								ID_Task
                                ,User_ID 
                                ,Task 
                                ,EnteredDate
                                ,EndDate
                                ,IsToDo 
                                FROM tasks
                                WHERE ID_Task = @taskID;";
            using (MySqlConnection connection = new MySqlConnection("Database=todolist;Host=127.0.0.1;Port=3306;User Id=root;"))
            {
                connection.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.Add("@taskID", MySqlDbType.Int32).Value = taskID;
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            try
                            {

                                task.ID_ToDo = reader.GetInt32(0);
                                task.User_ID = reader.IsDBNull(1) ? null : (int?)reader.GetInt32(1);
                                task.Task = reader.IsDBNull(2) || reader.GetString(2) == "" ? string.Empty : reader.GetString(2);
                                task.EnteredDate = reader.IsDBNull(3) ? (DateTime?)null : Convert.ToDateTime(reader.GetValue(3));
                                task.EndDate = reader.IsDBNull(4) ? (DateTime?)null : Convert.ToDateTime(reader.GetValue(4));
                                task.IsToDo = reader.IsDBNull(5) ? (byte?)null : reader.GetByte(5);


                            }
                            catch (Exception ex)
                            {

                                throw ex;
                            }

                        }

                    }

                }

            }
            return task;

        }

         


        public static void CheckTask(int? taskID)
        {
            string query = @"UPDATE `todolist`.`tasks`
                                SET
                                `IsToDo` = 1
                                WHERE `ID_Task` = @ID_Task;";


            using (MySqlConnection connection = new MySqlConnection("Database=todolist;Host=127.0.0.1;Port=3306;User Id=root;"))
            {
                connection.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.Add("@ID_Task", MySqlDbType.Int32).Value = taskID;
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


        public static void DeleteTask(int? taskID)
        {
            string query = @"DELETE FROM `todolist`.`tasks`
                            WHERE ID_Task = @ID_Task;";


            using (MySqlConnection connection = new MySqlConnection("Database=todolist;Host=127.0.0.1;Port=3306;User Id=root;"))
            {
                connection.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.Add("@ID_Task", MySqlDbType.Int32).Value = taskID;
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

        public static void UpdateTask(TaskModel task)
        {
            string query = @"UPDATE `todolist`.`tasks`
                            SET
                            `Task` = @Task,
                            `EndDate` = @EndDate
                            WHERE `ID_Task` = @ID_Task;";


            using (MySqlConnection connection = new MySqlConnection("Database=todolist;Host=127.0.0.1;Port=3306;User Id=root;"))
            {
                connection.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.Add("@ID_Task", MySqlDbType.Int32).Value = task.ID_ToDo;
                    cmd.Parameters.Add("@Task", MySqlDbType.String).Value = task.Task;
                    cmd.Parameters.Add("@EndDate", MySqlDbType.DateTime).Value = task.EndDate;
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

        public static void CreateNewTask(TaskModel task)
        {
            string query = @"INSERT INTO `todolist`.`tasks`
                                    (
                                    `User_ID`,
                                    `Task`,
                                    `EnteredDate`,
                                    `EndDate`,
                                    `IsToDo`)
                                    VALUES
                                    ( @ID_User,
                                    @Task,
                                    @EnteredDate,
                                    @EndDate,
                                    0);";


            using (MySqlConnection connection = new MySqlConnection("Database=todolist;Host=127.0.0.1;Port=3306;User Id=root;"))
            {
                connection.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.Add("@ID_User", MySqlDbType.Int32).Value = task.User_ID;
                    cmd.Parameters.Add("@Task", MySqlDbType.String).Value = task.Task;
                    cmd.Parameters.Add("@EnteredDate", MySqlDbType.DateTime).Value = task.EnteredDate;
                    cmd.Parameters.Add("@EndDate", MySqlDbType.DateTime).Value = task.EndDate;
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