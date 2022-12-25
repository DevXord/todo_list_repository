using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToDoLista.Database
{
    public class Datebase
    {
        private static string datebaseAddress = @"Database=todolist;
                                                 Host=127.0.0.1;
                                                 Port=3306;
                                                 User Id=root;";

        public static string GetDateBaseAddress() {
            return datebaseAddress;
        }
    }
}