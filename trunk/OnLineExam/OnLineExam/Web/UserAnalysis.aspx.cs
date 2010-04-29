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

public partial class Web_Userscore1 : System.Web.UI.Page
{

    BLLWS_User userService = new BLLWS_User();
    DALWS_User userService2 = new DALWS_User();
    BLLWS_StudentAnalysis service = new BLLWS_StudentAnalysis();

    protected void Page_Load(object sender, EventArgs e)
    {
        this.Page.Title = "学生统计分析";

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
                Label i1 = (Label)Page.Master.FindControl("labUser");
                i1.Text = userName;
                initdata();
            }
        }
    

       
      
    }

    public void initdata()
    {
        Users[] user=service.SelectUserName();
        int i = 0;
        while (i<user.Length)
        {
            if (!DropDownList1.Items.Contains(new ListItem(user[i].UserName, user[i].UserID)))
            DropDownList1.Items.Add(new ListItem(user[i].UserName,user[i].UserID));
            i++;
        }
        updatescore();
    }

   
    public void updatescore()
    {
        Label1.Text = "0"; 
        string StudentID = DropDownList1.SelectedValue;
        Scores[] score = service.SelectUserScores(StudentID.Trim());
        DataTable table = new DataTable();
        table.Columns.Add("用户编号");
        table.Columns.Add("用户姓名");
        table.Columns.Add("试卷");
        table.Columns.Add("成绩");
        table.Columns.Add("考试时间");
        table.Columns.Add("评卷时间");
        int scores = 0;
        for (int i = 0; i < score.Length; i++)
        {
            DataRow row = table.NewRow();
            row[0] = score[i].UserID;
            row[1] = score[i].UserName;
            row[2] = service.GetPaperName(score[i].PaperID);
            row[3] = score[i].Score;
            scores += score[i].Score;
            row[4] = score[i].ExamTime;
            row[5] = score[i].JudgeTime;
            table.Rows.Add(row);
        }
        if (score.Length > 0)
        {
            scores = scores / score.Length;
            Label1.Text = scores.ToString();
        }
        GridView1.DataSource = table;
        GridView1.DataBind(); 
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        updatescore();

    }

  
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#cbe2fa'");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#FFFFFF'");
        }
    }

}
