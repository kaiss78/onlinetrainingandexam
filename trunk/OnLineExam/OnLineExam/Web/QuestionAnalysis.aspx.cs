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
using System.IO;
using System.Data.OleDb;
using localhost;

public partial class Web_QuestionAnalysis : System.Web.UI.Page
{
    BLWS_QuestionAnalysis service = new BLWS_QuestionAnalysis();
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Page.Title = "问题统计分析";
      /* if (!IsPostBack)
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
            }
        }*/
        updatescore();
    }

    public void updatescore()
    {
        //GridView1.Columns.
        string StudentID = DropDownList1.SelectedValue;
        string[] s = service.GetList(StudentID);
        DataTable table = new DataTable();
        table.Columns.Add("题目序号");
        table.Columns.Add("课程序号");
        table.Columns.Add("题目");
        int j = 0;
        while (s[j]!=null)
        {
            DataRow row = table.NewRow();
            row[0] = s[j];
            row[1] = s[++j];
            row[2] = s[++j];
            j++;
            table.Rows.Add(row);
        } 
        GridView1.DataSource = table;
        GridView1.DataBind();
    }


    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
      /*  if (e.Row.RowType == DataControlRowType.DataRow || e.Row.RowType == DataControlRowType.Separator)
        {
            Label label1 = e.Row.FindControl("Label1") as Label;
            label1.Text = (e.Row.RowIndex + 1).ToString();
        }*/
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#CCFF66'");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#FFFFFF'");
        }
    }
    protected void ddlCourse_SelectedIndexChanged(object sender, EventArgs e)
    {
        updatescore();
    }
}
