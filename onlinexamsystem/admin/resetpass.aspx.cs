using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class admin_resetpass : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btn_resetpass_Click(object sender, EventArgs e)
    {
        if (IsValid)
        {
            string cs = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {

                HttpCookie adminCookie = Request.Cookies["admin_cookies"];
                string adminEmail = "";
                if (adminCookie != null)
                {
                    adminEmail = adminCookie["adminemail"];
                    // Now you can use the 'adminEmail' value
                }


                SqlCommand cmd = new SqlCommand("update admin set admin_password= @adminpass where admin_email = @email", con);
                cmd.Parameters.AddWithValue("@adminpass", txt_adminewpass.Text);
                cmd.Parameters.AddWithValue("@email", adminEmail);
                try
                {
                    con.Open();
                    int i = (int)cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        Response.Redirect("/onlinexamsystem/admin/index.aspx");
                    }
                    else
                    {
                        txt_admipresentpass.Focus();
                        panel_resetpass_warning.Visible = true;
                        lbl_resetpasswarning.Text = "Something went wrong. Can't update. Please try after sometime later</br> ";
                    }
                }
                catch (Exception ex)
                {
                    txt_admipresentpass.Focus();
                    panel_resetpass_warning.Visible = true;
                    lbl_resetpasswarning.Text = "Something went wrong. Please try after sometime later</br> Contact you developer for this problem" + ex.Message ;
                }
            } // end of using 
        }
        else
        {
            txt_admipresentpass.Focus();
            panel_resetpass_warning.Visible = true;
            lbl_resetpasswarning.Text = "You must fill all the requirements";
        }
    }
}