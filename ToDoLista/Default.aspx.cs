using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
            List<string> lista = new List<string>();
            lista.Add("Adam");
            lista.Add("Edmund");
            lista.Add("Kazi");
            lista.Add("Eryk");
            lista.Add("Brajan");
            lb_selectUser.DataSource = lista;
        }
    }
}