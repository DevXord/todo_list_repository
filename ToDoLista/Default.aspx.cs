using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.DynamicData;
using System.Web.UI;
using System.Web.UI.WebControls;
using ToDoLista.Models;

namespace ToDoLista
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                cmb_selectUser.DataBind();
              
            }
        }



        protected void SelectUser_Click(object sender, EventArgs e)
        {
            string userName = cmb_selectUser.SelectedValue != null  && cmb_selectUser.SelectedValue != "" ? cmb_selectUser.SelectedItem.Text  : tb_newUser.Text;
            if (cmb_selectUser.SelectedItem == null || cmb_selectUser.SelectedItem.Text == "") 
            {
                UserModel.CreateNewUser(userName);
            }
            Session["userName"] = userName;
            Session["userID"] = Convert.ToString(UserModel.GetIdUserWithName(userName));
            var tasks = TaskModel.ShowUserTasks(Convert.ToInt32(Session["userID"]),true);

            string message = "";

            foreach (var task in tasks)
            {
                if (task.EndDate.Value >= DateTime.Now && task.EndDate.Value < DateTime.Now.AddDays(2)) {
                    message += "Task <b>" + task.Task + "</b><br> End date " + task.EndDate.Value.ToString("dd/MM/yyyy") +" at " + task.EndDate.Value.ToShortTimeString() + "<br>";


                }
            }
            if(message.Length != 0)  
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "ToastInfoButtons('Time to complete the following tasks:<br><br>"+ message +" ', '../ListToDo.aspx');", true);
            else 
                Response.Redirect("~/ListToDo.aspx");


        }



        protected void cmb_selectUser_DataBinding(object sender, EventArgs e)
        {
            cmb_selectUser.DataSource = UserModel.ShowAllUser();
        }
    }
}