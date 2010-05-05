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

public partial class MasterPage : System.Web.UI.MasterPage
{
    BLLWS_Role roleService = new BLLWS_Role();
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("Login.aspx");
    }

    public int RedirectPage()
    {
        if (Session["userID"] == null)
            Response.Redirect("Login.aspx");

        Role user = new Role();
        string userId = Session["userID"].ToString();
        user.RoleName = roleService.GetRoleName(userId);
        switch (user.RoleName)
        {
            case "管理员":
                return 0;
                break;
            case "教师":
                return 1;
                break;
            case "学生":
                return 2;
                break;
            default:
                break;
        }
        return -1;
    }
}
