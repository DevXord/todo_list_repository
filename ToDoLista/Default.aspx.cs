using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
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
                lb_selectUser.DataBind();
              
            }
        }

        protected void lb_selectUser_DataBinding(object sender, EventArgs e)
        {
            lb_selectUser.DataSource = UserModel.ShowAllUser();
        }

        protected void SelectUser_Click(object sender, EventArgs e)
        {
            string userName = lb_selectUser.SelectedIndex != -1 ? lb_selectUser.Text : tb_newUser.Text;
            if (lb_selectUser.SelectedIndex == -1) {
                UserModel.CreateNewUser(userName);
            }

            Session["userName"] = userName;
            Session["userID"] = Convert.ToString(UserModel.GetIdUserWithName(userName));

            Response.Redirect("~/ListToDo.aspx");


        }
    }
}