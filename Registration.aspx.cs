using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hostel_Managment_System.User
{
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Calendar1.Visible = false;

            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            if (Calendar1.Visible)
            {

                Calendar1.Visible = false;
            }
            else
            {
                Calendar1.Visible = true;
            }
        }
        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            TextBox5.Text = Calendar1.SelectedDate.ToString("d");

            Calendar1.Visible = false;
        }
        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {
            DateTime rs = new DateTime(1994,01,01);
            DateTime re = new DateTime(2000, 01, 01);

            if(e.Day.Date < rs || e.Day.Date > re)

            {
                e.Day.IsSelectable = false;
                e.Cell.ForeColor = System.Drawing.Color.Blue;
            }
        }
        

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\02-04-19\\Hostel_Managment_System\\Hostel_Managment_System\\App_Data\\Hostel.mdf;Integrated Security=True");
            
                
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into reg(fname,lname,uname,password,sq,sa,branch,dob,mno,email,fathername,fathermno,mothername,mothermno,city,address)values(@fname,@lname,@uname,@password,@sq,@sa,@branch,@dob,@mno,@email,@fathername,@fathermno,@mothername,@mothermno,@city,@address)",con);
            cmd.Parameters.AddWithValue("@fname",txtfname.Text);
            cmd.Parameters.AddWithValue("@lname", txtlname.Text);
            cmd.Parameters.AddWithValue("@uname", txtuname.Text);
            cmd.Parameters.AddWithValue("@password", txtpass.Text);
            cmd.Parameters.AddWithValue("@sq", DropDownList2.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@sa", txtans.Text);
            
            cmd.Parameters.AddWithValue("@branch", txtbranch.Text);
            cmd.Parameters.AddWithValue("@dob", TextBox5.Text);
            cmd.Parameters.AddWithValue("@mno", txtmno.Text);
            cmd.Parameters.AddWithValue("@email", txtemail.Text);
            cmd.Parameters.AddWithValue("@fathername", txtfathername.Text);
            cmd.Parameters.AddWithValue("@fathermno", txtfmno.Text);
            cmd.Parameters.AddWithValue("@mothername", txtmothername.Text);
            cmd.Parameters.AddWithValue("@mothermno", txtmmno.Text);
            cmd.Parameters.AddWithValue("@city", txtcity.Text);
            cmd.Parameters.AddWithValue("@address", txtadd.Text);
            cmd.ExecuteNonQuery();
            Response.Redirect("Login.aspx");
            con.Close();
        }
    }
}