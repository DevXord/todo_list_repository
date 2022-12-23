using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToDoLista.Models
{
    public class UserModel
    {
        public int? ID_User { get; set; }
        public string Name { get; set; }
        public DateTime? JoinDate { get; set; }
        public DateTime? LastLogin { get; set; }



        public static void CreateNewUser(string name)
        {


        }

        public static void DeleteUser(int? userID)
        {


        }

    }
}