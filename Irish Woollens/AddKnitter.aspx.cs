﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Irish_Woollens
{
    public partial class AddKnitter : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["Key"]);

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //function for adding new knitters
        void Add()
        {
            clsStaffCollection StaffList = new clsStaffCollection();
            String Error = StaffList.ThisStaff.Valid(txtAddress.Text,
                                                           txtEmailAddress.Text,
                                                           txtFirstname.Text,
                                                           txtSurname.Text,
                                                           txtPassword.Text,
                                                           txtTelephoneNumber.Text,
                                                           txtRole.Text);


            string enterPassword;
            enterPassword = txtPassword.Text + txtEmailAddress.Text;


            // Create a new instance of the hash crypto service provider.
            HashAlgorithm hashAlg = new SHA256CryptoServiceProvider();
            // Convert the data (entered password) to hash to an array of Bytes.
            byte[] bytValue = System.Text.Encoding.UTF8.GetBytes(enterPassword);
            // Compute the Hash. This returns an array of Bytes.
            byte[] bytHash = hashAlg.ComputeHash(bytValue);
            // represent the hash value as a base64-encoded string, for security --> 
            // -->if you need to display the value or transmit it over a network.
            string hashedPassword = Convert.ToBase64String(bytHash);

            if (Error == "")
            {
                StaffList.ThisStaff.Firstname = txtFirstname.Text;
                StaffList.ThisStaff.Surname = txtSurname.Text;
                StaffList.ThisStaff.Address = txtAddress.Text;
                StaffList.ThisStaff.EmailAddress = txtEmailAddress.Text;
                StaffList.ThisStaff.Password = hashedPassword;
                StaffList.ThisStaff.TelephoneNumber = txtTelephoneNumber.Text;
                StaffList.ThisStaff.RoleId = 2;

                //Add the record
                StaffList.Add();
                lblError.Text = "Knitter added successfully";
            }
            else
            {
                //report
                lblError.Text = "There were problem(s) with the data you entered: " + Error;
            }
        }

            protected void btnAddKnitter_Click(object sender, EventArgs e)
        {
            //add the new record
            Add();
            //javascript message to show to the manager when they have added a new knitter successfully 
            //Response.Write("<script type='text/javascript'>alert('You have successfully added a new knitter to the system');</script>");
            //ClearTextBoxes(Page);
        }

        //protected void ClearTextBoxes(Control p1)
        //{
        //    foreach (Control ctrl in p1.Controls)
        //    {
        //        if (ctrl is TextBox)
        //        {
        //            TextBox t = ctrl as TextBox;

        //            if (t != null)
        //            {
        //                t.Text = String.Empty;
        //            }
        //        }
        //        else
        //        {
        //            if (ctrl.Controls.Count > 0)
        //            {
        //                ClearTextBoxes(ctrl);
        //            }
        //        }
        //    }
        //}

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("homepage.aspx");
        }
    }
}