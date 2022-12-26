using AjaxControlToolkit;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading;
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
        #region Useful methods
        public void showEndTaskControls(bool position)
        {
            lb_showEndTask.Visible = position;
            cb_showEndTask.Visible = position;

        }
        public void ShowClientErrorMessage(string message) {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "ShowErrorMessage('"+ message + "');", true);
            

        }
        protected void CheckRow_Click(object sender, EventArgs e)
        {
            if (hf_listToDo.Value != string.Empty)
                TaskModel.CheckTask(Convert.ToInt32(hf_listToDo.Value));
            gv_toDoList.DataBind();
        }
        protected void DeleteRow_Click(object sender, EventArgs e)
        {
            if (hf_listToDo.Value != string.Empty)
                TaskModel.DeleteTask(Convert.ToInt32(hf_listToDo.Value));
            gv_toDoList.DataBind();
        }

        protected void AddNewTask_Click(object sender, EventArgs e)
        {
            bool isValid = false;
            if (tb_newTask.Text == "")
            {
                ShowClientErrorMessage("The new task field is empty!");
                isValid = true;
            }
            if (!isValid && hf_endDate.Value == "")
            {
                ShowClientErrorMessage("The end task date field is empty!");
                isValid = true;
            }
            if (!isValid && Convert.ToDateTime(hf_endDate.Value) < DateTime.Now  ) { 
                ShowClientErrorMessage("The date must be from the future!");
                isValid = true;
            }
            if (!isValid)
            {
                try
                {
                    Convert.ToDateTime(hf_endDate.Value);
                }
                catch (Exception)
                {
                    ShowClientErrorMessage("Invalid date!");
                    isValid = true;
                }
            }
            if (!isValid)
            {
                TaskModel task = new TaskModel();

                task.Task = tb_newTask.Text;
                task.EnteredDate = DateTime.Now;
                task.EndDate = Convert.ToDateTime(hf_endDate.Value);
                task.User_ID = Convert.ToInt32(Session["userID"]);


                if (!TaskModel.HasUserThisTask(task.User_ID, task))
                {
                    TaskModel.CreateNewTask(task);
                }
                else
                    ShowClientErrorMessage("This task already exists!");



            }
            tb_dateTask.Text = null;
            tb_newTask.Text = null;
            gv_toDoList.DataBind();


        }

        protected void SaveCheck_Click(object sender, EventArgs e)
        {
            bool check = cb_showEndTask.Checked;
            UserModel.SelectEndTaskUser(Convert.ToInt32(Session["userID"]), check);

            gv_toDoList.DataBind();
        }

        public void ClearGridView_Click(object sender, EventArgs e)
        {
            gv_toDoList.DataBind();
        }

        #endregion Useful methods

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                gv_toDoList.DataBind();
        }


        protected void gv_toDoList_DataBinding(object sender, EventArgs e)
        {
            if (TaskModel.HasUserTasks(Convert.ToInt32(Session["userID"])))
                showEndTaskControls(true);
            else
                showEndTaskControls(false);

      
            
            gv_toDoList.DataSource = TaskModel.ShowUserTasks(Convert.ToInt32(Session["userID"]), UserModel.GetSelectedUser(Convert.ToInt32(Session["userID"])));;
            cb_showEndTask.DataBind();
        }

        protected void gv_toDoList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Accept")
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "showCheckAskToast();", true);
            if (e.CommandName == "Delete")
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "showDeleteAskToast();", true);

            hf_listToDo.Value = gv_toDoList.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text;

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
            
 
            DateTime result;
            bool is_valid = false;
            if (DateTime.TryParse(hf_endDate.Value, out result))
            {
                if (result == new DateTime(0001, 1, 1, 12, 0, 0))
                {
                    ShowClientErrorMessage("Invalid date!");
                     
                    is_valid = true;
                }


                if (result < DateTime.Now && task.EndDate != result)
                {
                     ShowClientErrorMessage("The date must be from the futur!");

                    is_valid = true;
                }
                if (!is_valid)
                {
                    task.EndDate = result;
                }

            }



            TaskModel.UpdateTask(task);



            if (is_valid == false)
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
            if (gv_toDoList.EditIndex != -1)
            {
                gv_toDoList.Rows[e.NewEditIndex].CssClass = "gv_toDoList_row_edit";
                var bt_deleteRow = gv_toDoList.Rows[e.NewEditIndex].Cells[1].Controls[0] as ImageButton;
                bt_deleteRow.CssClass = "hiddencol";
            }

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
                    int? firstCompleteTaskID = TaskModel.GetFirstIdCompleteTask(task.User_ID);
                    int? lastCompleteTaskID = TaskModel.GetLastIdCompleteTask(task.User_ID);
                    Label l_endDate = e.Row.FindControl("l_endDate") as Label;
                    if (task.IsToDo == 1)
                    {
                      
                        if (l_endDate != null)
                        {
                            var bt_deleteRow = e.Row.Cells[1].Controls[0] as ImageButton;
                            var bt_editRow = e.Row.Cells[2].Controls[0] as ImageButton;

                            bt_editRow.CssClass = "hiddencol";

                            bt_deleteRow.CssClass = "hiddencol";

                           
                            l_endDate.ForeColor = Color.White;
                            if(firstCompleteTaskID != null && task.ID_ToDo == firstCompleteTaskID)
                                e.Row.CssClass = "gv_toDoList_row_isDoFirst";
                            else if (lastCompleteTaskID != null && task.ID_ToDo == lastCompleteTaskID)
                                e.Row.CssClass = "gv_toDoList_row_isDoLast";
                            else e.Row.CssClass = "gv_toDoList_row_isDo";
                        }
                        
                    }
                    if (task.EndDate < DateTime.Now && task.IsToDo == 0)
                    {
                        e.Row.CssClass = "";
                        if (l_endDate != null)
                        {

                            var bt_deleteRow = e.Row.Cells[1].Controls[0] as ImageButton;
                           

                          

                            bt_deleteRow.CssClass = "hiddencol";


                            l_endDate.ForeColor = Color.White;
                            e.Row.CssClass = "gv_toDoList_row_After";
                        }

                    }
                    if (l_endDate != null)
                        l_endDate.Text = task.EndDate.Value.ToString("dd/MM/yyyy") + " at " + task.EndDate.Value.ToString("HH:mm");
                }

            }
        }

        protected void gv_toDoList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            gv_toDoList.DataBind();
        }



        protected void gv_toDoList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            gv_toDoList.PageIndex = e.NewPageIndex;
            gv_toDoList.DataBind();

        }



        protected void cb_showEndTask_DataBinding(object sender, EventArgs e)
        {
            cb_showEndTask.Checked = UserModel.GetSelectedUser(Convert.ToInt32(Session["userID"]));
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "changeTextLabel();", true);
        }

        protected void gv_toDoList_DataBound(object sender, EventArgs e)
        {
            cb_showEndTask.DataBind();
        }
 

        protected void tb_endDate_TextChanged(object sender, EventArgs e)
        {
            TextBox date = sender as TextBox;
            date.Text = date.Text.Replace('T', ' ');
            hf_endDate.Value = date.Text;
        }

      
    }
}
