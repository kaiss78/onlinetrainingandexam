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
using OnLineExamBLL;
using OnLineExamModel;
using System.Collections.Generic;
using localhost;
//using OnLineExamDAL;

public partial class Web_SingleSelectAdd : System.Web.UI.Page
{
    DALWS_SingleSelected DALService = new DALWS_SingleSelected();
    BLLWS_SingleSelected BLLService = new BLLWS_SingleSelected();

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
                string userName = UserManager.GetUserName(userId);
                Label i1 = (Label)Page.Master.FindControl("labUser");
                i1.Text = userName;

                ddlCourse.Items.Clear();
                localhost.Course course = new localhost.Course();
                //List<Course> list = service.ListCourse();
                localhost.Course[] list = DALService.ListCourse();
                
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
        localhost.SingleProblem sp = new localhost.SingleProblem();
        sp.CourseID = Convert.ToInt32(ddlCourse.SelectedValue);
        sp.Title = txtTitle.Text;
        sp.AnswerA = txtAnswerA.Text;
        sp.AnswerB = txtAnswerB.Text;
        sp.AnswerC = txtAnswerC.Text;
        sp.AnswerD = txtAnswerD.Text;
        sp.Answer = ddlAnswer.SelectedValue;
        if (BLLService.AddSingleSelected(sp))
        {
            lblMessage.Text = "添加成功！";
            txtTitle.Text = string.Empty;
            txtAnswerA.Text = string.Empty;
            txtAnswerB.Text = string.Empty;
            txtAnswerC.Text = string.Empty;
            txtAnswerD.Text = string.Empty;
        }
        else
        {
            lblMessage.Text = "添加失败！";
        }

    }
    protected void imgBtnReturn_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("SingleSelectManage.aspx");
    }
}
