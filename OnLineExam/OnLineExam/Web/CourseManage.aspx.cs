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

    protected void Page_Load(object sender, EventArgs e)
    {
        this.Page.Title = "考试科目管理";
       
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
                GridView1.DataSource = courseService.GetSelect();
                GridView1.DataKeyNames = new string[] { "DepartmentId", "DepartmentName" };
                GridView1.DataBind();
            }
        }
    }

    protected void GridView1_RowDataBound1(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow || e.Row.RowType == DataControlRowType.Separator)
        {
            Label label1 = e.Row.FindControl("Label1") as Label;
            label1.Text = (e.Row.RowIndex + 1).ToString();
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#CCFF66'");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#FFFFFF'");
        }
    }
    protected void GridView1_RowDeleting1(object sender, GridViewDeleteEventArgs e)
    {
        Course c = new Course();
        c.DepartmentId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
        try
        {
            courseService.GetDeleteCourse(c);
            lblMessger.Text = "删除成功！";
            Response.Redirect("CourseManage.aspx");
        }
        catch (Exception)
        {
            Response.Redirect("CourseManage.aspx");
        }

    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        Course c = new Course();
        c.DepartmentId = Convert.ToInt32(GridView1.DataKeys[e.NewEditIndex].Values[0]);
        c.DepartmentName = GridView1.DataKeys[e.NewEditIndex].Values[1].ToString();
        Response.Redirect("CourseEdit.aspx?CourseID=" + c.DepartmentId.ToString() + "&CourseName=" + c.DepartmentName);
    }
}
