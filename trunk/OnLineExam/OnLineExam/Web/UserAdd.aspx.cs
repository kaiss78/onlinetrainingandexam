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
using System.Data.SqlClient;
using System.Collections.Generic;
using localhost;

public partial class Web_UserAdd : System.Web.UI.Page
{
    BLLWS_User userService = new BLLWS_User();

    protected void Page_Load(object sender, EventArgs e)
    {
        this.Page.Title = "增加用户";
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

        txtUserID.Text = getHao();
    }
    protected void imgBtnSave_Click(object sender, ImageClickEventArgs e)
    {
        Users user = new Users();
        user.UserID = txtUserID.Text;
        user.UserName = txtUserName.Text;
        user.UserPwd = txtUserPwd.Text;
        user.RoleId = Convert.ToInt32(ddlRole.SelectedValue);
        if (userService.AddUsers(user))
        {
            lblMessage.Text = "插入成功！";
        }
        else
        {
            lblMessage.Text = "插入失败！";
        }
    }

    public string getHao()
    {
        int i = 0;
        string connStr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        SqlConnection conn = new SqlConnection(connStr);
        SqlCommand cmd = conn.CreateCommand();

        cmd.CommandText = "select UserId from Users";
        conn.Open();

        SqlDataReader dr = cmd.ExecuteReader();
        List<Users> list = new List<Users>();

        while (dr.Read())
        {
            Users user = new Users();
            user.UserID = dr["UserID"].ToString();
            list.Add(user);
            i++;
        }
        string uid = list[i - 2].UserID.ToString();


        string temp = uid.Substring(0, 4);
        string temp1 = uid.Substring(4, uid.Length - 4);
        int num = Convert.ToInt32(temp1) + 101;
        string a = num.ToString();
        temp1 = a.Substring(1, a.Length - 1);
        return temp + temp1;



    }

    protected void imgBtnReturn_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("UserManage.aspx");
    }
}
