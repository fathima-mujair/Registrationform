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
    public partial class Registrationform1 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"server=DESKTOP-3HUC9PM\SQLEXPRESS;database=NovDB;integrated security=true");
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Panel1.Visible = true;
            LabName3.Text = TextBox1.Text;
            Labage3.Text = TextBox2.Text;
            Labadr3.Text = TextBox3.Text;
            Labphn3.Text = TextBox4.Text;
            Labeml3.Text = TextBox5.Text;
            Labstate3.Text = DropDownList1.SelectedItem.Text;
            Labgen3.Text = RadioButtonList1.SelectedItem.Text;
            string items = "";
            for(int i=0;i<CheckBoxList1.Items.Count;i++)
            {
                if(CheckBoxList1.Items[i].Selected)
                {
                    items += CheckBoxList1.Items[i].Text + ",";
                }
            }
            Labqua3.Text = items;
            string s = " ";
            s = "~/images/" + FileUpload1.FileName;
            FileUpload1.SaveAs(MapPath(s));
            Image1.ImageUrl = s;
            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string items = "";
            for (int i = 0; i < CheckBoxList1.Items.Count; i++)
            {
                if (CheckBoxList1.Items[i].Selected)
                {
                    items += CheckBoxList1.Items[i].Text + ",";
                }
            }
            string path = "~/images/" + FileUpload1.FileName;
            FileUpload1.SaveAs(MapPath(path));

            string strinsert = "insert into Reg values('" + TextBox1.Text + "'," + TextBox2.Text + ",'" + TextBox3.Text + "','" + TextBox4.Text + "','" + TextBox5.Text + "','" + RadioButtonList1.SelectedItem.Text + "','" + DropDownList1.SelectedItem.Text + "','"+items+ "','"+path+"','" + TextBox6.Text + "','" + TextBox7.Text + "')";
            SqlCommand cmd = new SqlCommand(strinsert, con);
            con.Open();
            int j = cmd.ExecuteNonQuery();
            con.Close();
            if (j != 0)
                Label11.Text = "inserted";
        }

        protected void TextBox6_TextChanged(object sender, EventArgs e)
        {
            string sel="select count(id) from Reg where username='"+TextBox6.Text+"'";
            SqlCommand cmd = new SqlCommand(sel, con);
            con.Open();
            string count = cmd.ExecuteScalar().ToString();
            if (count == "1")
                Label12.Text = "username exist";
            else
                Label12.Visible = false;
        }
    }
        
}