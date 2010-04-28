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

public partial class Web_QuestionAnalyse : System.Web.UI.Page
{
    BLLWS_User userService = new BLLWS_User();

    protected void Page_Load(object sender, EventArgs e)
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

            Panel1.Visible = true;
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Panel1.Visible = false;
    }
}
