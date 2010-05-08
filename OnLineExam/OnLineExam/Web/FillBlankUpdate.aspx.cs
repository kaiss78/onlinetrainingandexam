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
using System.Data.SqlClient;
using localhost;

public partial class Web_FillBlankUpdate : System.Web.UI.Page
{
    BLLWS_User userService = new BLLWS_User();
    BLLWS_SingleSelected singleSelectedService = new BLLWS_SingleSelected();
    BLLWS_FillBlankProblem fillBlankProblemService = new BLLWS_FillBlankProblem();

    protected void Page_Load(object sender, EventArgs e)
    {
        this.Page.Title = "修改试题";
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

                //根据ID展示相应的值
                int SingleID = int.Parse(Request["ID"].ToString());
                string connStr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "Select * from FillBlankProblem where ID=" + SingleID;
                    conn.Open();
                    SqlDataReader DR = cmd.ExecuteReader();

                    if (DR.Read())
                    {
                        ddlCourse.SelectedValue = DR["CourseID"].ToString();
                        txtFrontTitle.Text = DR["FrontTitle"].ToString();
                        txtBackTitle.Text = DR["BackTitle"].ToString();
                        txtAnswer.Text = DR["Answer"].ToString();
                    }
                    DR.Close();
                    conn.Close();

                }
            }
        }
    }
    protected void imgBtnSave_Click(object sender, ImageClickEventArgs e)
    {

        FillBlankProblem pro = new FillBlankProblem();
        pro.ID = int.Parse(Request["ID"].ToString());
        pro.CourseID = Convert.ToInt32(ddlCourse.SelectedValue);
        pro.FrontTitle = txtFrontTitle.Text;
        pro.BackTitle = txtBackTitle.Text;
        pro.Answer = txtAnswer.Text;
        if (fillBlankProblemService.FillBlankProblemUpdate(pro))
        {
            lblMessage.Text = "修改成功！";
            txtFrontTitle.Text = string.Empty;
            txtBackTitle.Text = string.Empty;
            txtAnswer.Text = string.Empty;
        }
        else
        {
            lblMessage.Text = "修改失败！";
        }

    }
    protected void imgBtnReturn_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("FillBlankManage.aspx");
    }
}
