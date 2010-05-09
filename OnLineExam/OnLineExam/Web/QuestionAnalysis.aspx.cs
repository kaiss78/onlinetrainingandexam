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
    BLLWS_User userService = new BLLWS_User();
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Page.Title = "问题统计分析";
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
                Label i1 = (Label)Page.Master.FindControl("labUser");
                i1.Text = userName;
            }
        }
        updatescore();
    }

    public void updatescore()
    {
        string type = DropDownList1.SelectedValue;
        DataSet ds = service.getdetails(type);
         DataTable table = new DataTable();
        table.Columns.Add("题目序号");
        table.Columns.Add("学生");
        table.Columns.Add("试卷");
        table.Columns.Add("类型");
          table.Columns.Add("分值");
          table.Columns.Add("答案");
          table.Columns.Add("考试时间");
          table.Columns.Add("学生得分");
          int score = 0;
        int j = 0;
        while (j<ds.Tables[0].Rows.Count)
        {
            DataRow row = table.NewRow();
            row[0] = ds.Tables[0].Rows[j][0];
            string userid = ds.Tables[0].Rows[j][1].ToString();
            DataSet da1 = service.getusername(userid);
            row[1] = da1.Tables[0].Rows[0][0];
            string paperid = ds.Tables[0].Rows[j][2].ToString();
            DataSet da2 = service.getpapername(paperid);
            row[2] = da2.Tables[0].Rows[0][0];
            row[3] = type ;
            row[4] = ds.Tables[0].Rows[j][3];
            row[5] = ds.Tables[0].Rows[j][4];
            row[6] = ds.Tables[0].Rows[j][5];
            row[7] = ds.Tables[0].Rows[j][6];
            score += Convert.ToInt32(row[7].ToString());
            j++;
            table.Rows.Add(row);
        } 
        GridView1.DataSource = table;
        GridView1.DataBind();
        if (ds.Tables[0].Rows.Count != 0)
        {
            score = score / j;
            Label3.Text = score.ToString();
        }
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
    protected void ddlCourse_SelectedIndexChanged(object sender, EventArgs e)
    {
        updatescore();
    }
}
