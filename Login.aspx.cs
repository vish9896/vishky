using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hostel_Managment_System.User
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\02-04-19\\Hostel_Managment_System\\Hostel_Managment_System\\App_Data\\Hostel.mdf;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Select count(*) from reg where uname=@uname and password=@password",con);
            cmd.Parameters.AddWithValue("@uname",TextBox1.Text);
            cmd.Parameters.AddWithValue("@password",TextBox2.Text);
            
            int i = (int)cmd.ExecuteScalar();
            con.Close();
            if (i > 0)
            {
                Response.Redirect("UHome.aspx");
            }

            else
            {
                Response.Write("<script language='javascript'> alert('Invalid Username Or Password')</script>");
                TextBox1.Text = "";
                TextBox2.Text = "";
            }
            
        }
    }
}