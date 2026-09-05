<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs"
    Inherits="AcademicCalendarLeaveSystem.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Academic Calendar & Leave Management System</title>
</head>

<body>

<form id="form1" runat="server">

    <!-- ================= LOGIN PAGE ================= -->

    <asp:Panel ID="pnlLogin" runat="server">

        <h1>Student Login</h1>

        <hr />

        <asp:Label ID="lblUsername"
            runat="server"
            Text="Username: ">
        </asp:Label>

        <asp:TextBox ID="txtUsername"
            runat="server">
        </asp:TextBox>

        <br /><br />

        <asp:Label ID="lblPassword"
            runat="server"
            Text="Password: ">
        </asp:Label>

        <asp:TextBox ID="txtPassword"
            runat="server"
            TextMode="Password">
        </asp:TextBox>

        <br /><br />

        <asp:Button ID="btnLogin"
            runat="server"
            Text="Login"
            OnClick="btnLogin_Click">
        </asp:Button>

        <br /><br />

        <asp:Label ID="lblLoginMessage"
            runat="server">
        </asp:Label>

    </asp:Panel>


    <!-- ================= MAIN PAGE ================= -->

    <asp:Panel ID="pnlMain" runat="server" Visible="false">

        <h1>Academic Calendar & Leave Management System</h1>

        <hr />

        <!-- STUDENT DETAILS -->

        <h2>Student Details</h2>

        <asp:Label ID="lblStudentDetails"
            runat="server">
        </asp:Label>

        <br /><br />

        <asp:Button ID="btnLogout"
            runat="server"
            Text="Logout"
            OnClick="btnLogout_Click">
        </asp:Button>

        <hr />


        <!-- ================= ACADEMIC CALENDAR ================= -->

        <h2>Academic Calendar</h2>

        <asp:Calendar ID="AcademicCalendar"
            runat="server"
            OnSelectionChanged="AcademicCalendar_SelectionChanged"
            OnDayRender="AcademicCalendar_DayRender">
        </asp:Calendar>

        <br />

        <asp:Label ID="lblSelectedDate"
            runat="server"
            Text="Select a date from the calendar.">
        </asp:Label>

        <br /><br />

        <asp:Label ID="lblEvent"
            runat="server">
        </asp:Label>

        <hr />


        <!-- ================= LEAVE MANAGEMENT ================= -->

        <h2>Leave Management</h2>

        <asp:Label ID="lblLeaveType"
            runat="server"
            Text="Select Leave Type: ">
        </asp:Label>

        <br />

        <asp:RadioButtonList ID="rblLeaveType"
            runat="server">

            <asp:ListItem Text="Sick Leave"
                Value="Sick Leave">
            </asp:ListItem>

            <asp:ListItem Text="Casual Leave"
                Value="Casual Leave">
            </asp:ListItem>

            <asp:ListItem Text="Personal Leave"
                Value="Personal Leave">
            </asp:ListItem>

            <asp:ListItem Text="Other Leave"
                Value="Other Leave">
            </asp:ListItem>

        </asp:RadioButtonList>

        <br />

        <asp:Label ID="lblLeaveDays"
            runat="server"
            Text="Number of Days: ">
        </asp:Label>

        <asp:DropDownList ID="ddlLeaveDays"
            runat="server">

            <asp:ListItem Text="1 Day"
                Value="1">
            </asp:ListItem>

            <asp:ListItem Text="2 Days"
                Value="2">
            </asp:ListItem>

            <asp:ListItem Text="3 Days"
                Value="3">
            </asp:ListItem>

            <asp:ListItem Text="4 Days"
                Value="4">
            </asp:ListItem>

            <asp:ListItem Text="5 Days"
                Value="5">
            </asp:ListItem>

        </asp:DropDownList>

        <br /><br />

        <asp:Label ID="lblReason"
            runat="server"
            Text="Reason: ">
        </asp:Label>

        <br />

        <asp:TextBox ID="txtReason"
            runat="server"
            TextMode="MultiLine"
            Rows="4"
            Columns="40">
        </asp:TextBox>

        <br /><br />

        <asp:Button ID="btnApplyLeave"
            runat="server"
            Text="Apply Leave"
            OnClick="btnApplyLeave_Click">
        </asp:Button>

        <br /><br />

        <asp:Label ID="lblMessage"
            runat="server">
        </asp:Label>

        <hr />


        <!-- ================= LEAVE SUMMARY ================= -->

        <h2>Leave Summary</h2>

        <asp:Label ID="lblTotalLeave"
            runat="server"
            Text="Total Leave Used: 0">
        </asp:Label>

        <br /><br />

        <asp:GridView ID="gvLeave"
            runat="server"
            AutoGenerateColumns="true">
        </asp:GridView>

        <hr />


        <!-- ================= COOKIE ================= -->

        <h2>Cookie Information</h2>

        <asp:Label ID="lblCookie"
            runat="server">
        </asp:Label>

    </asp:Panel>

</form>

</body>
</html>