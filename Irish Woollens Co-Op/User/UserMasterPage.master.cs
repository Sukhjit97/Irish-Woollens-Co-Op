﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        //redirect to the login page
        Response.Redirect("LoginPage.aspx");
       
    }

    protected void btnRegister_Click(object sender, EventArgs e)
    {
        //redirect to the registeration page
        Response.Redirect("RegisterPage.aspx");
    }
}
