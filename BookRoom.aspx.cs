﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hostel_Managment_System.User
{
    public partial class BookRoom : System.Web.UI.Page
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
            TextBox6.Text = Calendar1.SelectedDate.ToString("d");

            Calendar1.Visible = false;
        }
        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {
            if (e.Day.IsOtherMonth)
            {
                e.Day.IsSelectable = false;

            }

        }

    }
}