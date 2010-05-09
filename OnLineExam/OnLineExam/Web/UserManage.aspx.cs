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

public partial class Web_UserManage : System.Web.UI.Page
{
    BLLWS_User userService = new BLLWS_User();

    protected void Page_Load(object sender, EventArgs e)
    {
        this.Page.Title = "用户管理";
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

                GridView1.DataSource = userService.listuser();
                GridView1.DataBind();
            }
        }
    }

    protected void ImageButtonQuery_Click(object sender, ImageClickEventArgs e)
    {
        string userID = tbxUserID.Text;
        string userName = tbxUserName.Text;
        if (userID == "" && userName == "")
        {
            //Response.Write("<script language=javascript>alert('查询条件不能都为空！!')</script>");
        }
        else
        {
            if (userID != "")
            {
                GridView1.DataSource = userService.seluser(userID);
                GridView1.DataBind();
                tbxUserID.Text = "";
                tbxUserName.Text = "";
            }
            else
            {
                GridView1.DataSource = userService.seluserName(userName);
                GridView1.DataBind();
                tbxUserID.Text = "";
                tbxUserName.Text = "";
            }
        }
    }
    protected void ImageButtonBack_Click(object sender, ImageClickEventArgs e)
    {
        GridView1.DataSource = userService.listuser();
        GridView1.DataBind();
    }

    protected void ImageButtonResetPassword_Click(object sender, ImageClickEventArgs e)
    {
        int numOfChecked = 0;
        for (int i = 0; i < this.GridView1.Rows.Count; i++)
        {
            bool isChecked = ((CheckBox)GridView1.Rows[i].FindControl("chkSelected")).Checked;
            if (isChecked)
            {
                numOfChecked++;
            }
        }
        if (numOfChecked == 1)
        {
            for (int i = 0; i < this.GridView1.Rows.Count; i++)
            {
                bool isChecked = ((CheckBox)GridView1.Rows[i].FindControl("chkSelected")).Checked;
                if (isChecked)
                {
                    string UserID = ((Label)GridView1.Rows[i].FindControl("Label1")).Text;

                    Random ran = new Random();
                    string newPassword = (ran.Next(999999).ToString().PadLeft(6, '8'));	//随机生成一个密码

                    Users user = new Users();//创建Users对象user
                    string pwdMd5 = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(newPassword, "MD5").ToString();
                    user.UserPwd = pwdMd5.ToString().Trim();
                    if (userService.Update(pwdMd5, UserID))//更改用户密码
                    {
                        Response.Write("<Script language=JavaScript>alert('" + UserID + "的密码已经重置，新密码为【" + newPassword + "】。');</Script>");
                    }
                    else//修改密码失败
                    {
                        Response.Write("<Script language=JavaScript>alert('" + UserID + "重置密码失败!');</Script>");
                    }
                }
            }

        }
        else
        {
            Response.Write("<Script language=JavaScript>alert('您只能选择一个用户!');</Script>");
            return;
        }
    }
    protected void ImageButtonDelete_Click(object sender, ImageClickEventArgs e)
    {
        for (int i = 0; i < this.GridView1.Rows.Count; i++)
        {
            bool isChecked = ((CheckBox)GridView1.Rows[i].FindControl("chkSelected")).Checked;
            if (isChecked)
            {
                string userID = ((Label)GridView1.Rows[i].FindControl("Label1")).Text;
                Users user = new Users();//创建Users类对象user
                if (userService.delUserId(userID))//根据主键使用DeleteByProc方法删除用户
                {
                    Response.Write("<script language=javascript>alert('删除成功!')</script>");
                }
                else
                {
                    Response.Write("<script language=javascript>alert('" + userID + "删除失败!')</script>");
                }

            }
        }
        GridView1.DataSource = userService.listuser();
        GridView1.DataBind();
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#D9E480'");
            if (e.Row.RowIndex % 2 == 0)
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#F7F7DE'");
            else
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#FFFFFF'");
        }
    }
}
