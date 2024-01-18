using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Registrationform
{
    public partial class Login : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"server=DESKTOP-3HUC9PM\SQLEXPRESS;database=NovDB;integrated security=true");
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sel="select count(id) from Reg where username='"+TextBox1.Text+"'and password='"+TextBox2.Text+"'";
            SqlCommand cmd = new SqlCommand(sel, con);
            con.Open();
            string count = cmd.ExecuteScalar().ToString();
            con.Close();
            if (count == "1")
            {
                string selid = "select id from Reg where username = '" + TextBox1.Text + "'and password='" + TextBox2.Text + "'";
                SqlCommand cmd1 = new SqlCommand(selid, con);
                con.Open();
                string id = cmd1.ExecuteScalar().ToString();
                con.Close();
                Session["uid"] = id;
                Response.Redirect("UserProfile.aspx");
            }
            else
                Label3.Text = "Invalid username and password";
        }
    }
}