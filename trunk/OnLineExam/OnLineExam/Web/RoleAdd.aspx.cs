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

public partial class Web_RoleAdd : System.Web.UI.Page
{
    BLLWS_User userService = new BLLWS_User();
    BLLWS_Role roleService = new BLLWS_Role();

    protected void Page_Load(object sender, EventArgs e)
    {

        this.Page.Title = "增加角色";
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
        Role role = new Role();

        role.RoleName = txtRoleName.Text;

        if (roleService.InsertRoles(role))
        {
            this.lblMessage.Text = "添加成功！";
        }
        else
        {
            this.lblMessage.Text = "添加失败！";
        }
    }
    protected void imgBtnReturn_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("RoleManage.aspx");
    }
}
