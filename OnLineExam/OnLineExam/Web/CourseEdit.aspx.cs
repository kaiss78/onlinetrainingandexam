using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using localhost;

public partial class Web_CourseManage1 : System.Web.UI.Page
{
    BLLWS_User userService = new BLLWS_User();
    BLLWS_Course courseService = new BLLWS_Course();
    string courseID;
    public string courseName;

    protected void Page_Load(object sender, EventArgs e)
    {
        this.Page.Title = Request["CourseName"].ToString();

        if (!Page.IsPostBack)
        {
            if (Session["userID"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                string userId = Session["userID"].ToString();
                string userName = userService.GetUserName(userId);
                Label i = (Label)Page.Master.FindControl("labUser");
                i.Text = userName;

                courseID = Request["CourseID"].ToString();
                courseName = Request["CourseName"].ToString();
                Users[] list = courseService.SelectUser(Convert.ToInt32(courseID));
                for (int j = 0; j < list.Length; j++)
                {
                    if (list[j].RoleId == 2)
                        lbTeacher.Text = list[j].UserName;
                    else
                    {
                        ListItem item = new ListItem(list[j].UserName, list[j].UserID);
                        lstbStudent.Items.Add(item);
                    }
                }
                Users[] list2 = courseService.SelectOtherUser(Convert.ToInt32(courseID));
                for (int j = 0; j < list2.Length; j++)
                {
                    ListItem item = new ListItem(list2[j].UserName, list2[j].UserID);
                    lstbStudent2.Items.Add(item);
                }
            }
        }
        Page.DataBind();
    }
    protected void BtnDel_Click(object sender, EventArgs e)
    {
        ListItem item = lstbStudent.SelectedItem;
        lstbStudent.Items.Remove(item);
        lstbStudent2.Items.Add(item);
        courseID = Request["CourseID"].ToString();
        courseService.DelUser(courseID, item.Value);
    }
    protected void BtnAdd_Click(object sender, EventArgs e)
    {
        ListItem item = lstbStudent2.SelectedItem;
        lstbStudent2.Items.Remove(item);
        lstbStudent.Items.Add(item);
        courseID = Request["CourseID"].ToString();
        courseService.AddUser(courseID, item.Value);
    }
}
