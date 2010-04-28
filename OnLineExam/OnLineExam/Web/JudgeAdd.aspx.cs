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

public partial class Web_JudgeAdd : System.Web.UI.Page
{
    BLLWS_User userService = new BLLWS_User();
    DALWS_SingleSelected singleSelectedService = new DALWS_SingleSelected();
    BLLWS_JudgeProblem judgeProblemService = new BLLWS_JudgeProblem();

    protected void Page_Load(object sender, EventArgs e)
    {
        this.Page.Title = "增加试题";
        //展示绑定的数据并将它展示在下拉列表中
        if (!IsPostBack)
        {
            if (Session["userID"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                string userId = Session["userID"].ToString();
                string userName = userService.GetUserName(userId);
                Label i1 = (Label)Page.Master.FindControl("labUser");
                i1.Text = userName;


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
        JudgeProblem pro = new JudgeProblem();
        pro.CourseID = Convert.ToInt32(ddlCourse.SelectedValue);
        pro.Title = txtTitle.Text;
        pro.Answer = Convert.ToBoolean(rblAnswer.SelectedValue);
        if (judgeProblemService.judgeProblemInsert(pro))
        {
            lblMessage.Text = "添加成功！";
            txtTitle.Text = string.Empty;
        }
        else
        {
            lblMessage.Text = "添加失败！";
        }
    }
    protected void imgBtnReturn_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("JudgeManage.aspx");
    }
}
