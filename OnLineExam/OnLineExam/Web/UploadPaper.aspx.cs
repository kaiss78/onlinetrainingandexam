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

public partial class UploadPaper : System.Web.UI.Page
{

    BLLWS_User userService = new BLLWS_User();
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = "上传试卷";
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
    protected void Upload_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("Upload.aspx");
        }
        catch (Exception ex)
        {
            this.lblMessage.Text += "上传发生错误！原因是：" + ex.ToString();
        }
    }

}
