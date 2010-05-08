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

public partial class Web_RoleManage : System.Web.UI.Page
{
    BLLWS_User userService = new BLLWS_User();

    protected void Page_Load(object sender, EventArgs e)
    {
        string userId = Session["userID"].ToString();
        string userName = userService.GetUserName(userId);
        Label i = (Label)Page.Master.FindControl("labUser");
        i.Text = userName;

        this.Page.Title = "权限管理";
    }
    protected void GV_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
    protected void GV_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#CCFF66'");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#FFFFFF'");
        }
    }
    protected void ImageButtonGiant_Click(object sender, ImageClickEventArgs e)
    {

    }
}
