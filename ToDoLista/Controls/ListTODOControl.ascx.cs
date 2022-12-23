using AjaxControlToolkit;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Web;
using System.Web.DynamicData;
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
           
            gv_toDoList.DataSource = TaskModel.ShowUserTasks(Convert.ToInt32(Session["userID"]));
        }

        protected void gv_toDoList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            
            if (e.CommandName == "Delete")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                hf_listToDo.Value = gv_toDoList.Rows[index].Cells[0].Text;
                 

            }
            if (e.CommandName == "Edit")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                hf_listToDo.Value = gv_toDoList.Rows[index].Cells[0].Text;
               
            }
        }

        protected void DeleteRow_Click(object sender, EventArgs e)
        {
            if (hf_listToDo.Value != string.Empty)
                TaskModel.DeleteTask(Convert.ToInt32(hf_listToDo.Value));
            gv_toDoList.DataBind();
        }

        protected void gv_toDoList_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
       
            TaskModel task = TaskModel.GetTaskByID(Convert.ToInt32(e.Keys["ID_ToDo"]));

            if (e.NewValues["Task"] == null)
                task.Task = null;
            else
            {
                if (e.NewValues["Task"].ToString() != task.Task)
                    task.Task = e.NewValues["Task"].ToString();
            }
          
            GridViewRow _row = gv_toDoList.Rows[e.RowIndex];
            TextBox ce = _row.FindControl("tb_endDate") as TextBox;
            DateTime result;
            if(DateTime.TryParse(ce.Text, out result)){
                task.EndDate = result;
            }
           





            TaskModel.UpdateTask(task);
            gv_toDoList.EditIndex = -1;
            gv_toDoList.DataBind();
        }

        protected void gv_toDoList_RowEditing(object sender, GridViewEditEventArgs e)
        {
            int Id_Task = Convert.ToInt32(gv_toDoList.Rows[e.NewEditIndex].Cells[0].Text);
            TaskModel task = TaskModel.GetTaskByID(Id_Task);
            if (task.IsToDo == 1)
                gv_toDoList.EditIndex = -1;
            else
            {
                gv_toDoList.EditIndex = e.NewEditIndex;
                gv_toDoList.DataSource = ViewState["dt"] as DataTable;
            }
            gv_toDoList.DataBind();
        }

 
        protected void gv_toDoList_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gv_toDoList.EditIndex = -1;
            gv_toDoList.DataBind();

        }

        protected void gv_toDoList_RowCreated(object sender, GridViewRowEventArgs e)
        { 
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                TaskModel task = e.Row.DataItem as TaskModel;
                if (task != null)
                {
                    if (task.IsToDo == 1)
                    {
                        Label l_endDate = e.Row.FindControl("l_endDate") as Label;
                        if (l_endDate != null)
                        {
                            var bt_editRow = e.Row.Cells[1].Controls[0] as ImageButton;
                            var bt_deleteRow = e.Row.Cells[1].Controls[2] as ImageButton;

                            bt_editRow.CssClass = "hiddencol";

                            bt_deleteRow.CssClass = "hiddencol";


                            l_endDate.ForeColor = Color.White;
                            e.Row.CssClass = "gv_toDoList_row_isDo";
                        }
 
                    }
                }

            }
        }

        protected void gv_toDoList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "showAskToast();", true);
            gv_toDoList.DataBind();
        }

        protected void AddNewTask_Click(object sender, EventArgs e)
        {
 
            TaskModel task = new TaskModel();
            task.Task = tb_newTask.Text;
            task.EnteredDate = DateTime.Now;
            task.EndDate = Convert.ToDateTime( tb_dateTask.Text);
            task.User_ID = Convert.ToInt32(Session["userID"]);
            TaskModel.CreateNewTask(task);
            tb_dateTask.Text = null;
            tb_newTask.Text = null;
            gv_toDoList.DataBind();
        }

     
    }
}