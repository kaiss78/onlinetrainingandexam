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

public partial class Web_PwdModify1 : System.Web.UI.Page
{
    BLLWS_User userService = new BLLWS_User();
    BLLWS_DbBackup backupService = new BLLWS_DbBackup();

    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = "数据库备份恢复";
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
            }
        }
    }
    protected void btnBackup_Click(object sender, EventArgs e)
    {
        if (backupService.Backup())
            lblMessage.Text = "备份成功！";
        else
            lblMessage.Text = "备份失败！";

    }
    protected void btnRestore_Click(object sender, EventArgs e)
    {
        backupService.Restore();
        if (backupService.Restore())
            lblMessage2.Text = "恢复成功！";
        else
            lblMessage2.Text = "恢复失败！";
    }
}
