using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using ToDoLista.Models;

namespace ToDoLista.Controls
{
    public partial class ListTODOControl : System.Web.UI.UserControl
    {
       

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                gv_toDoList.DataBind();
            }
        }


        protected void gv_toDoList_DataBinding(object sender, EventArgs e)
        {
            List<TaskModel> lista = new List<TaskModel>();
            TaskModel tm1 = new TaskModel();
            tm1.ID_ToDo = 1;
            tm1.Task = "Go to shop";
            tm1.EnteredDate = DateTime.Now;
            tm1.EndDate = DateTime.Now.AddDays(20);
            lista.Add(tm1);
            TaskModel tm2 = new TaskModel();
            tm2.ID_ToDo = 2;
            tm2.Task = "Clear room";
            tm2.EnteredDate = DateTime.Now.AddDays(1);
            tm2.EndDate = tm2.EnteredDate.Value.AddDays(20);
            lista.Add(tm2);
            TaskModel tm3 = new TaskModel();
            tm3.ID_ToDo = 3;
            tm3.Task = "Give eat dog";
            tm3.EnteredDate = DateTime.Now.AddDays(2);
            tm3.EndDate = tm3.EnteredDate.Value.AddDays(20);
            lista.Add(tm3);
            gv_toDoList.DataSource = lista;
        }

        protected void gv_toDoList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "bt_deleteToDo")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                hf_listToDo.Value = gv_toDoList.Rows[index].Cells[0].Text;
                ImageButton btn = (ImageButton)gv_toDoList.Rows[index].Cells[1].Controls[0];
                btn.Attributes.Add("onclick", "showAskToast(); return false;");
            }
            if (e.CommandName == "bt_editToDo")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                hf_listToDo.Value = gv_toDoList.Rows[index].Cells[0].Text;
                ImageButton btn = (ImageButton)gv_toDoList.Rows[index].Cells[2].Controls[0];
                btn.Attributes.Add("onclick", "showAskToast(); return false;");
            }
        }

        protected void DeleteRow_Click(object sender, EventArgs e)
        {
            if (hf_listToDo.Value != string.Empty)
                TaskModel.DeleteTask(Convert.ToInt32(hf_listToDo.Value));

        }

        protected void gv_toDoList_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }

        protected void gv_toDoList_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gv_toDoList.EditIndex = e.NewEditIndex;
            gv_toDoList.DataSource = ViewState["dt"] as DataTable;
            gv_toDoList.DataBind();
        }
    }
}