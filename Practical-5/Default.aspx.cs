using System;
using System.Data;
using System.Web;
using System.Web.UI.WebControls;

namespace AcademicCalendarLeaveSystem
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Check whether user is already logged in
                if (Session["Username"] != null)
                {
                    ShowMainPage();
                }
                else
                {
                    pnlLogin.Visible = true;
                    pnlMain.Visible = false;
                }

                // Create Leave DataTable
                if (Session["LeaveData"] == null)
                {
                    DataTable dt = new DataTable();

                    dt.Columns.Add("Student Name");
                    dt.Columns.Add("Leave Type");
                    dt.Columns.Add("Number of Days");
                    dt.Columns.Add("Reason");
                    dt.Columns.Add("Date");

                    Session["LeaveData"] = dt;
                    Session["TotalLeave"] = 0;
                }

                // Check Cookie
                HttpCookie cookie =
                    Request.Cookies["StudentUsername"];

                if (cookie != null)
                {
                    txtUsername.Text = cookie.Value;
                }
            }
        }


        // =====================================================
        // LOGIN
        // =====================================================

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            // Simple login credentials for practical
            string correctUsername = "student";
            string correctPassword = "1234";

            if (username == correctUsername &&
                password == correctPassword)
            {
                // Store username in Session
                Session["Username"] = username;

                // Store username in Cookie
                HttpCookie cookie =
                    new HttpCookie("StudentUsername");

                cookie.Value = username;
                cookie.Expires =
                    DateTime.Now.AddDays(7);

                Response.Cookies.Add(cookie);

                // Show main page
                ShowMainPage();

                lblLoginMessage.Text = "";
            }
            else
            {
                lblLoginMessage.Text =
                    "Invalid Username or Password.";

                lblLoginMessage.ForeColor =
                    System.Drawing.Color.Red;
            }
        }


        // =====================================================
        // SHOW MAIN PAGE AFTER LOGIN
        // =====================================================

        private void ShowMainPage()
        {
            pnlLogin.Visible = false;
            pnlMain.Visible = true;

            string username =
                Session["Username"].ToString();

            lblStudentDetails.Text =
                "<b>Welcome:</b> " + username +
                "<br/><br/>" +
                "<b>Course:</b> Computer Engineering" +
                "<br/>" +
                "<b>Semester:</b> 5th Semester" +
                "<br/>" +
                "<b>Academic Year:</b> 2026-2027";

            // Show cookie information
            HttpCookie cookie =
                Request.Cookies["StudentUsername"];

            if (cookie != null)
            {
                lblCookie.Text =
                    "Logged in User from Cookie: " +
                    cookie.Value;
            }

            // Display leave information
            if (Session["TotalLeave"] != null)
            {
                lblTotalLeave.Text =
                    "Total Leave Used: " +
                    Session["TotalLeave"].ToString();
            }

            // Display leave records
            if (Session["LeaveData"] != null)
            {
                DataTable dt =
                    (DataTable)Session["LeaveData"];

                gvLeave.DataSource = dt;
                gvLeave.DataBind();
            }
        }


        // =====================================================
        // LOGOUT
        // =====================================================

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            // Remove login session
            Session.Remove("Username");

            // Clear login fields
            txtUsername.Text = "";
            txtPassword.Text = "";

            // Show login page
            pnlLogin.Visible = true;
            pnlMain.Visible = false;

            lblLoginMessage.Text =
                "You have been logged out.";

            lblLoginMessage.ForeColor =
                System.Drawing.Color.Green;
        }


        // =====================================================
        // ACADEMIC CALENDAR
        // =====================================================

        protected void AcademicCalendar_SelectionChanged(
            object sender,
            EventArgs e)
        {
            DateTime selectedDate =
                AcademicCalendar.SelectedDate;

            lblSelectedDate.Text =
                "Selected Date: " +
                selectedDate.ToString("dd-MM-yyyy");

            // Check academic events

            if (selectedDate.Month == 1 &&
                selectedDate.Day == 26)
            {
                lblEvent.Text =
                    "Event: Republic Day";
            }
            else if (selectedDate.Month == 8 &&
                     selectedDate.Day == 15)
            {
                lblEvent.Text =
                    "Event: Independence Day";
            }
            else if (selectedDate.DayOfWeek ==
                     DayOfWeek.Sunday)
            {
                lblEvent.Text =
                    "Event: Sunday / Holiday";
            }
            else if (selectedDate.Month == 5)
            {
                lblEvent.Text =
                    "Event: Summer Vacation";
            }
            else
            {
                lblEvent.Text =
                    "Event: Regular Academic Day";
            }
        }


        // Highlight important dates
        protected void AcademicCalendar_DayRender(
            object sender,
            DayRenderEventArgs e)
        {
            DateTime date = e.Day.Date;

            // Republic Day
            if (date.Month == 1 &&
                date.Day == 26)
            {
                e.Cell.Controls.Add(
                    new System.Web.UI.LiteralControl(
                        "<br/>Republic Day"));
            }

            // Independence Day
            if (date.Month == 8 &&
                date.Day == 15)
            {
                e.Cell.Controls.Add(
                    new System.Web.UI.LiteralControl(
                        "<br/>Independence Day"));
            }

            // Sunday
            if (date.DayOfWeek ==
                DayOfWeek.Sunday)
            {
                e.Cell.Controls.Add(
                    new System.Web.UI.LiteralControl(
                        "<br/>Holiday"));
            }
        }


        // =====================================================
        // APPLY LEAVE
        // =====================================================

        protected void btnApplyLeave_Click(
            object sender,
            EventArgs e)
        {
            // Check login
            if (Session["Username"] == null)
            {
                lblMessage.Text =
                    "Please login first.";

                return;
            }

            // Check leave type
            if (rblLeaveType.SelectedValue == "")
            {
                lblMessage.Text =
                    "Please select a leave type.";

                return;
            }

            // Check reason
            if (txtReason.Text.Trim() == "")
            {
                lblMessage.Text =
                    "Please enter leave reason.";

                return;
            }

            string studentName =
                Session["Username"].ToString();

            string leaveType =
                rblLeaveType.SelectedValue;

            int days =
                Convert.ToInt32(
                    ddlLeaveDays.SelectedValue);

            string reason =
                txtReason.Text.Trim();

            string date =
                DateTime.Now.ToString("dd-MM-yyyy");


            // Get DataTable from Session
            DataTable dt =
                (DataTable)Session["LeaveData"];


            // Create new row
            DataRow row =
                dt.NewRow();

            row["Student Name"] =
                studentName;

            row["Leave Type"] =
                leaveType;

            row["Number of Days"] =
                days;

            row["Reason"] =
                reason;

            row["Date"] =
                date;

            dt.Rows.Add(row);


            // Save DataTable in Session
            Session["LeaveData"] = dt;


            // Calculate total leave
            int totalLeave =
                Convert.ToInt32(
                    Session["TotalLeave"]);

            totalLeave += days;

            Session["TotalLeave"] =
                totalLeave;


            // Display total leave
            lblTotalLeave.Text =
                "Total Leave Used: " +
                totalLeave;


            // Display GridView
            gvLeave.DataSource = dt;
            gvLeave.DataBind();


            // Success message
            lblMessage.Text =
                "Leave applied successfully.";

            lblMessage.ForeColor =
                System.Drawing.Color.Green;


            // Clear input
            rblLeaveType.ClearSelection();

            ddlLeaveDays.SelectedIndex = 0;

            txtReason.Text = "";
        }
    }
}