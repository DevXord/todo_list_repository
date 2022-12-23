using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToDoLista.Models
{
    public class TaskModel
    {
        public int? ID_ToDo { get; set; }
        public int? User_ID { get; set; }
        public string Task { get; set; }
        public DateTime? EnteredDate { get; set; }
        public DateTime? EndDate { get; set; }


        public static void DownloadUserTask(int? userID)
        {


        }

        public static void DeleteTask(int? taskID)
        {


        }
        public static void CreateNewTask(int? userID, TaskModel task)
        {


        }
    }
}