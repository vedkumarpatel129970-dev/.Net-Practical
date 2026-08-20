using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace prac_4
{
    public partial class Online_Event_Registeration1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode =
                UnobtrusiveValidationMode.None;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            // Check whether all validations are successful
            Page.Validate();

            if (Page.IsValid)
            {
                // Get values from TextBoxes
                string name = TextBox1.Text;
                string email = TextBox2.Text;
                string mobile = TextBox3.Text;
                string college = TextBox4.Text;

                // Get selected Department
                string department = RadioButtonList1.SelectedValue;

                // Get selected Event
                string eventName = DropDownList1.SelectedValue;

                // Get selected Gender
                string gender = "";

                if (Male.Checked)
                {
                    gender = "Male";
                }
                else if (Female.Checked)
                {
                    gender = "Female";
                }

                // Get selected Skills
                string skills = "";

                foreach (ListItem item in CheckBoxList1.Items)
                {
                    if (item.Selected)
                    {
                        if (skills != "")
                        {
                            skills += ", ";
                        }

                        skills += item.Text;
                    }
                }

                // Get Address
                string address = TextArea1.Text;

                // Get Terms status
                string terms = "";

                if (chkTerms.Checked)
                {
                    terms = "Accepted";
                }
                else
                {
                    terms = "Not Accepted";
                }

                // Display registration details
                lblResult.Text =
                    "<b>Full Name :-</b> " +
                    Server.HtmlEncode(name) + "<br />" +

                    "<b>Email :-</b> " +
                    Server.HtmlEncode(email) + "<br />" +

                    "<b>Mobile :-</b> " +
                    Server.HtmlEncode(mobile) + "<br />" +

                    "<b>College :-</b> " +
                    Server.HtmlEncode(college) + "<br />" +

                    "<b>Department :-</b> " +
                    Server.HtmlEncode(department) + "<br />" +

                    "<b>Event :-</b> " +
                    Server.HtmlEncode(eventName) + "<br />" +

                    "<b>Gender :-</b> " +
                    Server.HtmlEncode(gender) + "<br />" +

                    "<b>Skills :-</b> " +
                    Server.HtmlEncode(skills) + "<br />" +

                    "<b>Address :-</b> " +
                    Server.HtmlEncode(address)
                        .Replace("\r\n", "<br />") + "<br />" +

                    "<b>Terms :-</b> " +
                    Server.HtmlEncode(terms);

                // Make result section visible
                pnlResult.Visible = true;
            }
            else
            {
                // Hide result if validation fails
                pnlResult.Visible = false;
            }
        }

        protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
        }
    }
}