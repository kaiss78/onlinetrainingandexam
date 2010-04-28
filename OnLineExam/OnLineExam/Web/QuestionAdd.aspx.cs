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
using System.Collections.Generic;
using localhost;

public partial class Web_QuestionAdd : System.Web.UI.Page
{
    DALWS_SingleSelected singleSelectedService = new DALWS_SingleSelected();
    BLLWS_QuestionProblem questionProblemService = new BLLWS_QuestionProblem();

    protected void Page_Load(object sender, EventArgs e)
    {
        this.Page.Title = "增加试题";
        if (!IsPostBack)
        {
            if (Session["userID"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                ddlCourse.Items.Clear();
                Course course = new Course();
                Course[] list = singleSelectedService.ListCourse();

                for (int i = 0; i < list.Length; i++)
                {
                    ListItem item = new ListItem(list[i].DepartmentName.ToString(), list[i].DepartmentId.ToString());
                    ddlCourse.Items.Add(item);
                }
            }
        }
    }
    protected void imgBtnSave_Click(object sender, ImageClickEventArgs e)
    {
        QuestionProblem pro = new QuestionProblem();
        pro.CourseID = Convert.ToInt32(ddlCourse.SelectedValue);
        pro.Title = txtTitle.Text;
        pro.Answer = txtAnswer.Text;
        if (questionProblemService.QuestionProblemInsert(pro))
        {
            lblMessage.Text = "添加成功！";
            txtTitle.Text = string.Empty;
            txtAnswer.Text = string.Empty;
        }
        else
        {
            lblMessage.Text = "添加失败！";
        }


    }
    protected void imgBtnReturn_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("QuestionManage.aspx");
    }
}
