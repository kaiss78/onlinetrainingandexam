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

public partial class Web_UserTest : System.Web.UI.Page
{
    BLLWS_User userService = new BLLWS_User();
    BLLWS_Exam examService = new BLLWS_Exam();
    DALWS_SingleSelected singleSelectedService2 = new DALWS_SingleSelected();
    BLLWS_SingleSelected singleSelectedService = new BLLWS_SingleSelected();

    protected int singeCount = 1;
    protected void Page_Load(object sender, EventArgs e)
    {
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
                Label i1 = (Label)Page.FindControl("labUser");
                i1.Text = userName;

                lblPaperName.Text = Session["PaperName"].ToString();

                Exam exam = examService.GetExam(Convert.ToInt32(Session["ExamID"]));
                DateTime now = examService.GetServerTime();
                Timer1.Interval = Convert.ToInt32((exam.EndTime - now).TotalMilliseconds);
                lbEndTime.Text = exam.EndTime.ToString();

                GetParperAll();
            }
        }
    }

    private void GetParperAll()
    {
        IEnumerable list = sqlSingleMark.Select(DataSourceSelectArguments.Empty);
        foreach (DataRowView o in list)
        {
            labSingle.Text = o[0].ToString();
            break;
        }
        IEnumerable list1 = SqlMultiMark.Select(DataSourceSelectArguments.Empty);
        foreach (DataRowView o in list1)
        {
            Label3.Text = o[0].ToString();
            break;
        }
        IEnumerable list2 = SqlFillMark.Select(DataSourceSelectArguments.Empty);
        foreach (DataRowView o in list2)
        {
            Label5.Text = o[0].ToString();
            break;
        }

        IEnumerable list3 = SqlJudgeMark.Select(DataSourceSelectArguments.Empty);
        foreach (DataRowView o in list3)
        {
            Label4.Text = o[0].ToString();
            break;
        }
        IEnumerable list4 = SqlQuestionMark.Select(DataSourceSelectArguments.Empty);
        foreach (DataRowView o in list4)
        {
            Label6.Text = o[0].ToString();
            break;
        }
    }
    protected void imgBtnSubmit_Click(object sender, ImageClickEventArgs e)
    {
        NewMethod();
    }

    private void NewMethod()
    {
        if (!(singleSelectedService2.Getitem(Session["userID"].ToString(), Request["PaperID"].ToString())))
        {
            Response.Write("<script language=javascript>alert('您已经考过!');window.close();</script>");
            return;
        }
        string Label = labSingle.Text;//单选分数
        string paperid = Session["PaperID"].ToString();
        string UserId = Session["userID"].ToString();
        DBHelp db = new DBHelp();
        foreach (RepeaterItem item in singleRep.Items)
        {
            HiddenField titleId = item.FindControl("titleId") as HiddenField;
            string id = (string)titleId.Value;
            string str = "";
            if (((RadioButton)item.FindControl("rbA")).Checked)
            {
                str = "A";
            }
            else if (((RadioButton)item.FindControl("rbB")).Checked)
            {
                str = "B";
            }
            else if (((RadioButton)item.FindControl("rbC")).Checked)
            {
                str = "C";
            }
            else if (((RadioButton)item.FindControl("rbD")).Checked)
            {
                str = "D";
            }
            string single = "insert into UserAnswer(UserID,PaperID,Type,TitleID,Mark,UserAnswer,ExamTime) values('" + UserId + "','" + paperid + "','单选题','" + id + "','" + Label + "','" + str + "','" + DateTime.Now.ToString() + "')";
            db.Insert(single);

        }


        string labeM = Label3.Text;//多选分数
        foreach (RepeaterItem item in Repeater2.Items)
        {
            HiddenField titleId = item.FindControl("titleId") as HiddenField;
            string id = (string)titleId.Value;
            string str = "";
            if (((CheckBox)item.FindControl("CheckBox1")).Checked)
            {
                str += "A";
            }
            if (((CheckBox)item.FindControl("CheckBox2")).Checked)
            {
                str += "B";
            }
            if (((CheckBox)item.FindControl("CheckBox3")).Checked)
            {
                str += "C";
            }
            if (((CheckBox)item.FindControl("CheckBox4")).Checked)
            {
                str += "D";
            }
            string Multi = "insert into UserAnswer(UserID,PaperID,Type,TitleID,Mark,UserAnswer,ExamTime) values('" + UserId + "','" + paperid + "','多选题','" + id + "','" + labeM + "','" + str + "','" + DateTime.Now.ToString() + "')";
            db.Insert(Multi);


        }

        string labeJ = Label4.Text;//判断分数
        foreach (RepeaterItem item in Repeater3.Items)
        {
            HiddenField titleId = item.FindControl("titleId") as HiddenField;
            string id = (string)titleId.Value;

            string str = Convert.ToString(false);
            if (((RadioButton)item.FindControl("rbA")).Checked)
            {
                str = Convert.ToString(true);
            }
            else if (((RadioButton)item.FindControl("rbB")).Checked)
            {
                str = Convert.ToString(false);
            }
            string Judge = "insert into UserAnswer(UserID,PaperID,Type,TitleID,Mark,UserAnswer,ExamTime) values('" + UserId + "','" + paperid + "','判断题','" + id + "','" + labeJ + "','" + str + "','" + DateTime.Now.ToString() + "')";
            db.Insert(Judge);
        }

        string labeF = Label5.Text;//填空分数
        foreach (RepeaterItem item in Repeater1.Items)
        {
            HiddenField titleId = item.FindControl("titleId") as HiddenField;
            string id = (string)titleId.Value;
            string str = "";
            str = ((TextBox)item.FindControl("TextBox1")).Text.Trim();
            string Fill = "insert into UserAnswer(UserID,PaperID,Type,TitleID,Mark,UserAnswer,ExamTime) values('" + UserId + "','" + paperid + "','填空题','" + id + "','" + labeF + "','" + str + "','" + DateTime.Now.ToString() + "')";
            db.Insert(Fill);

        }
        string labeQ = Label6.Text;//问答分数
        foreach (RepeaterItem item in Repeater4.Items)
        {
            HiddenField titleId = item.FindControl("titleId") as HiddenField;
            string id = (string)titleId.Value;
            string str = "";
            str = ((TextBox)item.FindControl("TextBox2")).Text.Trim();
            string Que = "insert into UserAnswer(UserID,PaperID,Type,TitleID,Mark,UserAnswer,ExamTime) values('" + UserId + "','" + paperid + "','问答题','" + id + "','" + labeQ + "','" + str + "','" + DateTime.Now.ToString() + "')";
            db.Insert(Que);


        }
        // Session["Test"] = "eeee";

        string del = "delete UserCache where UserID='" + UserId + "' and PaperID=" + paperid;
        db.Insert(del);

        Response.Write("<script language=javascript>alert('试卷提交成功!');window.close();</script>");

    }
    protected void Timer1_Tick(object sender, EventArgs e)
    {
        NewMethod();
    }
    protected void Timer2_Tick(object sender, EventArgs e)
    {
        SetCache();
    }
    protected void Timer3_Tick(object sender, EventArgs e)
    {
        Timer3.Enabled = false;
        GetCache();
    }
    private void SetCache()
    {
        string Label = labSingle.Text;//单选分数
        string paperid = Session["PaperID"].ToString();
        string UserId = Session["userID"].ToString();
        DBHelp db = new DBHelp();

        string sqlStr = "select * from UserCache where UserID='" + UserId + "' and PaperID=" + paperid;
        DataSet ds = db.GetDataSetSql(sqlStr);
        bool insert = false;
        if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
            insert = true;

        foreach (RepeaterItem item in singleRep.Items)
        {
            HiddenField titleId = item.FindControl("titleId") as HiddenField;
            string id = (string)titleId.Value;
            string str = "";
            if (((RadioButton)item.FindControl("rbA")).Checked)
            {
                str = "A";
            }
            else if (((RadioButton)item.FindControl("rbB")).Checked)
            {
                str = "B";
            }
            else if (((RadioButton)item.FindControl("rbC")).Checked)
            {
                str = "C";
            }
            else if (((RadioButton)item.FindControl("rbD")).Checked)
            {
                str = "D";
            }
            if (insert)
            {
                string single = "insert into UserCache(UserID,PaperID,Type,TitleID,Mark,UserAnswer,ExamTime) values('" + UserId + "','" + paperid + "','单选题','" + id + "','" + Label + "','" + str + "','" + DateTime.Now.ToString() + "')";
                db.Insert(single);
            }
            else
            {
                string single = "update UserCache set UserAnswer='" + str + "' where UserID='" + UserId + "' and PaperID=" + paperid + " and Type='单选题' and TitleID=" + id;
                db.Insert(single);
            }
        }


        string labeM = Label3.Text;//多选分数
        foreach (RepeaterItem item in Repeater2.Items)
        {
            HiddenField titleId = item.FindControl("titleId") as HiddenField;
            string id = (string)titleId.Value;
            string str = "";
            if (((CheckBox)item.FindControl("CheckBox1")).Checked)
            {
                str += "A";
            }
            if (((CheckBox)item.FindControl("CheckBox2")).Checked)
            {
                str += "B";
            }
            if (((CheckBox)item.FindControl("CheckBox3")).Checked)
            {
                str += "C";
            }
            if (((CheckBox)item.FindControl("CheckBox4")).Checked)
            {
                str += "D";
            }
            if (insert)
            {
                string Multi = "insert into UserCache(UserID,PaperID,Type,TitleID,Mark,UserAnswer,ExamTime) values('" + UserId + "','" + paperid + "','多选题','" + id + "','" + labeM + "','" + str + "','" + DateTime.Now.ToString() + "')";
                db.Insert(Multi);
            }
            else
            {
                string Multi = "update UserCache set UserAnswer='" + str + "' where UserID='" + UserId + "' and PaperID=" + paperid + " and Type='多选题' and TitleID=" + id;
                db.Insert(Multi);
            }
        }

        string labeJ = Label4.Text;//判断分数
        foreach (RepeaterItem item in Repeater3.Items)
        {
            HiddenField titleId = item.FindControl("titleId") as HiddenField;
            string id = (string)titleId.Value;

            string str = Convert.ToString(false);
            if (((RadioButton)item.FindControl("rbA")).Checked)
            {
                str = Convert.ToString(true);
            }
            else if (((RadioButton)item.FindControl("rbB")).Checked)
            {
                str = Convert.ToString(false);
            }
            if (insert)
            {
                string Judge = "insert into UserCache(UserID,PaperID,Type,TitleID,Mark,UserAnswer,ExamTime) values('" + UserId + "','" + paperid + "','判断题','" + id + "','" + labeJ + "','" + str + "','" + DateTime.Now.ToString() + "')";
                db.Insert(Judge);
            }
            else
            {
                string Judge = "update UserCache set UserAnswer='" + str + "' where UserID='" + UserId + "' and PaperID=" + paperid + " and Type='判断题' and TitleID=" + id;
                db.Insert(Judge);
            }
        }

        string labeF = Label5.Text;//填空分数
        foreach (RepeaterItem item in Repeater1.Items)
        {
            HiddenField titleId = item.FindControl("titleId") as HiddenField;
            string id = (string)titleId.Value;
            string str = "";
            str = ((TextBox)item.FindControl("TextBox1")).Text.Trim();
            if (insert)
            {
                string Fill = "insert into UserCache(UserID,PaperID,Type,TitleID,Mark,UserAnswer,ExamTime) values('" + UserId + "','" + paperid + "','填空题','" + id + "','" + labeF + "','" + str + "','" + DateTime.Now.ToString() + "')";
                db.Insert(Fill);
            }
            else
            {
                string Fill = "update UserCache set UserAnswer='" + str + "' where UserID='" + UserId + "' and PaperID=" + paperid + " and Type='填空题' and TitleID=" + id;
                db.Insert(Fill);
            }
        }

        string labeQ = Label6.Text;//问答分数
        foreach (RepeaterItem item in Repeater4.Items)
        {
            HiddenField titleId = item.FindControl("titleId") as HiddenField;
            string id = (string)titleId.Value;
            string str = "";
            str = ((TextBox)item.FindControl("TextBox2")).Text.Trim();
            if (insert)
            {
                string Que = "insert into UserCache(UserID,PaperID,Type,TitleID,Mark,UserAnswer,ExamTime) values('" + UserId + "','" + paperid + "','问答题','" + id + "','" + labeQ + "','" + str + "','" + DateTime.Now.ToString() + "')";
                db.Insert(Que);
            }
            else
            {
                string Que = "update UserCache set UserAnswer='" + str + "' where UserID='" + UserId + "' and PaperID=" + paperid + " and Type='问答题' and TitleID=" + id;
                db.Insert(Que);
            }
        }
        // Session["Test"] = "eeee";
    }

    protected void GetCache()
    {
        string paperid = Session["PaperID"].ToString();
        string UserId = Session["userID"].ToString();
        DBHelp db = new DBHelp();

        string sqlStr = "select * from UserCache where UserID='" + UserId + "' and PaperID=" + paperid;
        DataSet ds = db.GetDataSetSql(sqlStr);
        if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
            return;
        DataTable dt = ds.Tables[0];
        int i = 0;

        foreach (RepeaterItem item in singleRep.Items)
        {
            switch (dt.Rows[i++]["UserAnswer"].ToString())
            {
                case "A":
                    ((RadioButton)item.FindControl("rbA")).Checked = true;
                    break;
                case "B":
                    ((RadioButton)item.FindControl("rbB")).Checked = true;
                    break;
                case "C":
                    ((RadioButton)item.FindControl("rbC")).Checked = true;
                    break;
                case "D":
                    ((RadioButton)item.FindControl("rbD")).Checked = true;
                    break;
            }
        }

        foreach (RepeaterItem item in Repeater2.Items)
        {
            string str = dt.Rows[i++]["UserAnswer"].ToString();
            if (str.IndexOf("A") >= 0)
            {
                ((CheckBox)item.FindControl("CheckBox1")).Checked = true;
            }
            if (str.IndexOf("B") >= 0)
            {
                ((CheckBox)item.FindControl("CheckBox2")).Checked = true;
            }
            if (str.IndexOf("C") >= 0)
            {
                ((CheckBox)item.FindControl("CheckBox3")).Checked = true;
            }
            if (str.IndexOf("D") >= 0)
            {
                ((CheckBox)item.FindControl("CheckBox4")).Checked = true;
            }
        }

        foreach (RepeaterItem item in Repeater3.Items)
        {
            switch (dt.Rows[i++]["UserAnswer"].ToString())
            {
                case "True":
                    ((RadioButton)item.FindControl("rbA")).Checked = true;
                    break;
                case "False":
                    ((RadioButton)item.FindControl("rbB")).Checked = true;
                    break;
            }
        }

        foreach (RepeaterItem item in Repeater1.Items)
        {
            ((TextBox)item.FindControl("TextBox1")).Text = dt.Rows[i++]["UserAnswer"].ToString();
        }

        foreach (RepeaterItem item in Repeater4.Items)
        {
            ((TextBox)item.FindControl("TextBox2")).Text = dt.Rows[i++]["UserAnswer"].ToString();
        }
    }
}
