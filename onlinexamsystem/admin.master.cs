using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        HttpCookie admincookie = Request.Cookies["admin_cookies"];
        if(Session["adminemail"] != null || admincookie != null)
        {
            link_loginout.Text = "Log out";
        }
        else
        {
            Response.Redirect("/onlinexamsystem/admin/login.aspx");
        }
    }

    protected void link_loginout_Click(object sender, EventArgs e)
    {
        if (link_loginout.Text == "Log out")
        {
            Response.Cookies["admin_cookies"].Expires = DateTime.Now.AddYears(-1);
            Session.Clear();
            Response.Redirect("/onlinexamsystem/admin/Login.aspx");
        }
        //else 
        //{
        //    link_loginout.Text = "Log in";
        //}
    }
}
