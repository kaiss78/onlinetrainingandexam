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

public partial class Web_RoleDel : System.Web.UI.Page
{
    BLLWS_User userService = new BLLWS_User();
    DALWS_Role roleService = new DALWS_Role();

    protected void Page_Load(object sender, EventArgs e)
    {
        this.Title = "删除角色";
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
                Label i = (Label)Page.Master.FindControl("labUser");
                i.Text = userName;
            }
        }
    }
    protected void imgBtnSave_Click(object sender, ImageClickEventArgs e)
    {
        string RoleID = txtRoleID.Text;

        if (roleService.Delect(RoleID))
        {
            lblMessage.Text = "删除成功！";
        }
        else
        {
            lblMessage.Text = "删除失败！";
        }
    }
}
