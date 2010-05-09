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

public partial class Web_PaperAnalysis : System.Web.UI.Page
{
    BLLWS_User userService = new BLLWS_User();
    BLLWS_StudentAnalysis service = new BLLWS_StudentAnalysis();
    BLLWS_PaperAnalysis pa = new BLLWS_PaperAnalysis();

    protected void Page_Load(object sender, EventArgs e)
    {
        this.Page.Title = "试卷统计分析";
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

                initdata();
            }
        }
    }




    public void initdata()
    { 
        DataSet da = pa.GetPaperName();
        string[,] pn = new string[100,2];
        int i = 0;
        while (i < da.Tables[0].Rows.Count)
        {
            pn[i,0] = da.Tables[0].Rows[i][0].ToString();
            pn[i,1] = da.Tables[0].Rows[i][1].ToString();
            i++;
        }
        i=0;
         while (pn[i,0]!=null)
        {
            if (!DropDownList1.Items.Contains(new ListItem(pn[i, 1], pn[i, 0])))
                DropDownList1.Items.Add(new ListItem(pn[i, 1], pn[i, 0]));
            i++;
        }
         updatescore();

    }


    public void updatescore()
    {
        Label1.Text = "0";
        string PaperID = DropDownList1.SelectedValue;
        string[] s = pa.GetPaperDetail(PaperID);
        DataTable table = new DataTable();
        table.Columns.Add("试卷编号");
        table.Columns.Add("课程名称");
        table.Columns.Add("试卷名称");
        table.Columns.Add("学生姓名");
        table.Columns.Add("学生成绩");
        table.Columns.Add("考试时间");
        table.Columns.Add("评卷时间");
        int scores = 0;
        int i = 0;
        int j = 0;
       while(s[i]!=null)
        {
            DataRow row = table.NewRow();
            row[0] = s[i++];
            row[1] = s[i++];
            row[2] = s[i++];
            row[3] = s[i++];
            scores += Convert.ToInt32(s[i]);
            row[4] = s[i++];
            row[5] = s[i++];
            row[6] = s[i++];
            table.Rows.Add(row);
            j++;
        }
       if (j != 0)
       {
           scores = scores / j;
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
            e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#CCFF66'");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#FFFFFF'");
        }
    }

}
