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
using localhost;

public partial class _Default : System.Web.UI.Page
{
    BLLWS_User userService = new BLLWS_User();
    BLLWS_Exam examService = new BLLWS_Exam();
    BLLWS_Course courseService = new BLLWS_Course();
    BLLWS_Paper paperService = new BLLWS_Paper();

    protected void Page_Load(object sender, EventArgs e)
    {
        this.Page.Title = "添加考试";

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

                Course[] list = courseService.GetSelect();
                for (int j = 0; j < list.Length; j++)
                {
                    ListItem item = new ListItem(list[j].DepartmentName.ToString(), list[j].DepartmentId.ToString());
                    ddlCourse.Items.Add(item);
                }

                Paper[] list2 = paperService.SelectPaper();
                for (int j = 0; j < list2.Length; j++)
                {
                    if (list2[j].CourseID == Convert.ToInt32(ddlCourse.Text))
                    {
                        ListItem item = new ListItem(list2[j].PaperName.ToString(), list2[j].PaperID.ToString());
                        ddlPaper.Items.Add(item);
                    }
                }
            }
        }
    }
    protected void ddlCourse_SelectedIndexChanged(object sender, EventArgs e)
    {
        Paper[] list2 = paperService.SelectPaper();
        ddlPaper.Items.Clear();
        for (int j = 0; j < list2.Length; j++)
        {
            if (list2[j].CourseID == Convert.ToInt32(ddlCourse.Text))
            {
                ListItem item = new ListItem(list2[j].PaperName.ToString(), list2[j].PaperID.ToString());
                ddlPaper.Items.Add(item);
            }
        }
    }
    protected void imgBtnSave_Click(object sender, ImageClickEventArgs e)
    {
        Exam exam = new Exam();
        exam.CourseID = Convert.ToInt32(ddlCourse.Text);
        exam.PaperID = Convert.ToInt32(ddlPaper.Text);
        try
        {
            exam.StartTime = new DateTime(Convert.ToInt32(txtStartYear.Text), Convert.ToInt32(txtStartMonth.Text), Convert.ToInt32(txtStartDay.Text), Convert.ToInt32(txtStartHour.Text), Convert.ToInt32(txtStartMinute.Text), 0);
        }
        catch (ArgumentOutOfRangeException)
        {
            lblMessage.Text = "请输入合法的开始时间！";
            return;
        }
        exam.EndTime = exam.StartTime.AddMinutes(60 * Convert.ToInt32(txtHour.Text) + Convert.ToInt32(txtMinute.Text));
        if (examService.AddExam(exam))
        {
            lblMessage.Text = "添加成功！";
        }
        else
        {
            lblMessage.Text = "添加失败！";
        }
    }
    protected void imgBtnReturn_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("ExamManage.aspx");
    }
}
