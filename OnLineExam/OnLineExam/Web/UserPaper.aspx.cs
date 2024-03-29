﻿using System;
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

public partial class Web_UserPaper : System.Web.UI.Page
{
    BLLWS_User userService = new BLLWS_User();
    BLLWS_Paper paperService = new BLLWS_Paper();
    BLLWS_SingleSelected singleSelectedService = new BLLWS_SingleSelected();
    BLLWS_MultiProblem multiProblemService = new BLLWS_MultiProblem();
    BLLWS_JudgeProblem judgeProblemService = new BLLWS_JudgeProblem();
    BLLWS_FillBlankProblem fillBlankProblemService = new BLLWS_FillBlankProblem();
    BLLWS_QuestionProblem questionProblemService = new BLLWS_QuestionProblem();
    BLWS_QuestionAnalysis qa = new BLWS_QuestionAnalysis();

    protected void Page_Load(object sender, EventArgs e)
    {
        this.Page.Title = "试卷评阅";
        Panel1.Visible = true;
        Panel2.Visible = false;
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


                string userid = Request["UserID"].ToString();
                int paperid = int.Parse(Request["PaperID"]);

                GridView1.DataSource = singleSelectedService.GetSingQuestion(userid, paperid);
                GridView1.DataBind();
                SingleProblem[] list1 = singleSelectedService.GetSingQuestion(userid, paperid);
                if (list1.Length != 0)
                {
                    Label lbl1 = GridView1.HeaderRow.FindControl("Label27") as Label;
                    lbl1.Text = list1[0].Mark.ToString();
                }

                GridView2.DataSource = multiProblemService.GetMutiQuestion(userid, paperid);
                GridView2.DataBind();
                MultiProblem[] list2 = multiProblemService.GetMutiQuestion(userid, paperid);
                if (list2.Length != 0)
                {
                    Label lbl2 = GridView2.HeaderRow.FindControl("Label28") as Label;
                    lbl2.Text = list2[0].Mark.ToString();
                }

                GridView3.DataSource = judgeProblemService.GetJudgeQuestion(userid, paperid);
                GridView3.DataBind();
                JudgeProblem[] list3 = judgeProblemService.GetJudgeQuestion(userid, paperid);
                if (list3.Length != 0)
                {
                    Label lbl3 = GridView3.HeaderRow.FindControl("Label29") as Label;
                    lbl3.Text = list3[0].Mark.ToString();
                }

                GridView4.DataSource = fillBlankProblemService.GetFillQuestion(userid, paperid);
                GridView4.DataBind();
                FillBlankProblem[] list4 = fillBlankProblemService.GetFillQuestion(userid, paperid);
                if (list4.Length != 0)
                {
                    Label lbl4 = GridView4.HeaderRow.FindControl("Label30") as Label;
                    lbl4.Text = list4[0].Mark.ToString();
                }

                GridView5.DataSource = questionProblemService.GetQuesQuestion(userid, paperid);
                GridView5.DataBind();
                QuestionProblem[] list5 = questionProblemService.GetQuesQuestion(userid, paperid);
                if (list5.Length != 0)
                {
                    Label lbl = GridView5.HeaderRow.FindControl("Label31") as Label;
                    lbl.Text = list5[0].Mark.ToString();
                }

                sumScore.Text = (Convert.ToInt32(Session["SingMark"]) + Convert.ToInt32(Session["MulMark"]) + Convert.ToInt32(Session["JudgeMark"]) + Convert.ToInt32(Session["FillMark"])).ToString();
                Xpaperid.Text = paperService.GetPaperType(paperid);
                lblExamtime.Text = userService.GetTime(userid);
                //List<UserAnswer> ans = new List<UserAnswer>();
                //UserService user = new UserService();


                //ans = user.selectUserPaperList();
                //foreach (UserAnswer var in ans)
                //{
                //    Xpaperid.Text = var.PaperName.ToString();
                //    lblExamtime.Text = var.ExamTime.ToString();
                //}
            }
        }

    }

    protected void imgBtnReturn_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("UserPaperList.aspx");

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        TextBox text = new TextBox();
         TextBox text1 = new TextBox();
        int grade = 0;
        for (int k = 0; k < GridView5.Rows.Count; k++)
        {
          
            text = GridView5.Rows[k].FindControl("tbxqueScore") as TextBox;
              text1 = GridView5.Rows[k].FindControl("TextBox3") as TextBox;
            grade += Convert.ToInt32(text.Text);
            DataSet da = qa.select("select id from questionproblem where (answer='"+text1.Text+"')");
            qa.insert("update useranswer set usermark='" + text.Text + "' where (titleid='" + da.Tables[0].Rows[0][0].ToString() + "') and (type='问答题')");
        }
        sumScore.Text = (Convert.ToInt32(Session["SingMark"]) + Convert.ToInt32(Session["MulMark"]) + Convert.ToInt32(Session["JudgeMark"]) + Convert.ToInt32(Session["FillMark"]) + grade).ToString();
    }

    int Mulcount = 0;
    int MulNum = 0;
    int Mulright = 0;
    int Mulerror = 0;
    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            MultiProblem obj = (MultiProblem)e.Row.DataItem;
            CheckBox CheckBoxA = e.Row.FindControl("A") as CheckBox;
            CheckBox CheckBoxB = e.Row.FindControl("B") as CheckBox;
            CheckBox CheckBoxC = e.Row.FindControl("C") as CheckBox;
            CheckBox CheckBoxD = e.Row.FindControl("D") as CheckBox;
            List<Control> list = new List<Control>();
            list.Add(CheckBoxA);
            list.Add(CheckBoxB);
            list.Add(CheckBoxC);
            list.Add(CheckBoxD);

            int Marks = obj.Mark;

            string userAns = obj.UserAnswer;

            foreach (Char var in userAns)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    CheckBox cb = list[i] as CheckBox;
                    if (var.ToString() == cb.ID)
                    {
                        cb.Checked = true;
                    }
                }
            }
            MulNum++;
            if (userAns == obj.Answer)
            {
                qa.insert("update useranswer set usermark='" + obj.Mark + "' where id='" + obj.ID + "'");
                Mulcount = Mulcount + Marks;
                Mulright++;
            }
            else
                qa.insert("update useranswer set usermark='0' where id='" + obj.ID + "'");
            Mulerror = MulNum - Mulright;
            Session["MulMark"] = Mulcount;
            Session["Mulrights"] = Mulright;
            Session["Mulerrors"] = Mulerror;

            float proportion = (float)Mulerror / MulNum;
            Session["proportion1"] = proportion;


            mulScore.Text = Convert.ToString(Session["MulMark"]);


        }
    }
    int Judcount = 0;
    int JudNum = 0;
    int Judright = 0;
    int Juderror = 0;
    protected void GridView3_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            JudgeProblem judge = (JudgeProblem)e.Row.DataItem;
            CheckBox CheckBox1 = e.Row.FindControl("CheckBox5") as CheckBox;
            CheckBox cb = CheckBox1 as CheckBox;
            bool userAns = Convert.ToBoolean(judge.UserAnswer);
            bool Ans = judge.Answer;
            int Marks = judge.Mark;
            if (userAns == true)
            {
                cb.Checked = true;
            }
            if (userAns == Ans)
            {
                qa.insert("update useranswer set usermark='" + judge.Mark + "' where id='" + judge.ID + "'");
                Judcount = Judcount + Marks;
                Judright++;
            }
            else
                qa.insert("update useranswer set usermark='0' where id='" + judge.ID + "'");
            JudNum++;
            Juderror = JudNum - Judright;
            Session["Judrights"] = Judright;
            Session["Juderrors"] = Juderror;
            Session["JudgeMark"] = Judcount;

            float proportion = (float)Juderror / JudNum;
            Session["proportion2"] = proportion;
            judScore.Text = Convert.ToString(Session["JudgeMark"]);
        }
    }
    int Fillcount = 0;
    int FillNum = 0;
    int Fillright = 0;
    int Fillerror = 0;
    protected void GridView4_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            FillBlankProblem Fill = (FillBlankProblem)e.Row.DataItem;
            int Marks = Fill.Mark;
            if (Fill.UserAnswer == Fill.Answer)
            {
                qa.insert("update useranswer set usermark='" + Fill.Mark + "' where id='" + Fill.ID + "'");
                Fillcount = Fillcount + Marks;
                Fillright++;
            }
            else
                qa.insert("update useranswer set usermark='0' where id='" + Fill.ID + "'");
            FillNum++;

            Fillerror = FillNum - Fillright;
            Session["Fillright"] = Fillright;
            Session["Fillerrors"] = Fillerror;
            Session["FillMark"] = Fillcount;

            float proportion = (float)Fillerror / FillNum;
            Session["proportion3"] = proportion;
            filScore.Text = Convert.ToString(Session["FillMark"]);
        }
    }

    protected void imgBtnLook_Click(object sender, ImageClickEventArgs e)
    {
        string userid = Request["UserID"].ToString();
        int paperid = int.Parse(Request["PaperID"]);
        Panel1.Visible = false;
        Panel2.Visible = true;
        //单选题状况
        SingleProblem[] list1 = singleSelectedService.GetSingQuestion(userid, paperid);
        if (list1.Length != 0)
        {


            Label34.Text = Session["Singrights"].ToString();
            Label38.Text = Session["Singerrors"].ToString();
            Label42.Text = string.Format("{0:F2}", Session["proportion"]);
            Label53.Text = Session["SingMark"].ToString();
        }


        //多选题状况
        MultiProblem[] list2 = multiProblemService.GetMutiQuestion(userid, paperid);
        if (list2.Length != 0)
        {
            Label39.Text = Session["Mulrights"].ToString();
            Label40.Text = Session["Mulerrors"].ToString();
            Label43.Text = string.Format("{0:F2}", Session["proportion1"]);
            Label54.Text = Session["MulMark"].ToString();
        }
        //判断题状况
        JudgeProblem[] list3 = judgeProblemService.GetJudgeQuestion(userid, paperid);
        if (list3.Length != 0)
        {
            Label52.Text = Session["Judrights"].ToString();
            Label51.Text = Session["Juderrors"].ToString();
            Label44.Text = string.Format("{0:F2}", Session["proportion2"]);
            Label55.Text = Session["JudgeMark"].ToString();
        }
        //填空题状况
        FillBlankProblem[] list4 = fillBlankProblemService.GetFillQuestion(userid, paperid);
        if (list4.Length != 0)
        {
            Label49.Text = Session["Fillright"].ToString();
            Label50.Text = Session["Fillerrors"].ToString();
            Label45.Text = string.Format("{0:F2}", Session["proportion3"]);
            Label56.Text = Session["FillMark"].ToString();
        }
        Label57.Text = (Convert.ToInt32(Session["SingMark"]) + Convert.ToInt32(Session["MulMark"]) + Convert.ToInt32(Session["JudgeMark"]) + Convert.ToInt32(Session["FillMark"])).ToString();
    }

    int Singcount = 0;
    int SingNum = 0;
    int Singright = 0;
    int Singerror = 0;
    protected void GridView1_RowDataBound1(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            SingleProblem spm = (SingleProblem)e.Row.DataItem;
            RadioButton CheckBoxA = e.Row.FindControl("A") as RadioButton;
            RadioButton CheckBoxB = e.Row.FindControl("B") as RadioButton;
            RadioButton CheckBoxC = e.Row.FindControl("C") as RadioButton;
            RadioButton CheckBoxD = e.Row.FindControl("D") as RadioButton;
            List<Control> list = new List<Control>();
            list.Add(CheckBoxA);
            list.Add(CheckBoxB);
            list.Add(CheckBoxC);
            list.Add(CheckBoxD);

            int Marks = spm.Mark;
            
            string userAns = spm.UserAnswer;

            foreach (Char var in userAns)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    RadioButton cb = list[i] as RadioButton;
                    if (var.ToString() == cb.ID)
                    {
                        cb.Checked = true;
                    }
                }

            }
            SingNum++;
            if (userAns == spm.Answer)
            {
                qa.insert("update useranswer set usermark='"+spm.Mark +"' where id='" + spm.ID + "'");
                Singcount = Singcount + Marks;
                Singright++;
            }
            else
                qa.insert("update useranswer set usermark=0 where id='" + spm.ID + "'");
            Singerror = SingNum - Singright;
            Session["SingMark"] = Singcount;
            Session["Singrights"] = Singright;
            Session["Singerrors"] = Singerror;

            float proportion = (float)Singerror / SingNum;
            Session["proportion"] = proportion;

            sinScore.Text = Convert.ToString(Session["SingMark"]);
        }

    }
    protected void imgBtnSave_Click(object sender, ImageClickEventArgs e)
    {

        Scores scores = new Scores();
        scores.UserID = Request["UserID"].ToString();
        string PaperName = Xpaperid.Text;
        scores.Score = Convert.ToInt32(sumScore.Text);
        scores.ExamTime = Convert.ToDateTime(lblExamtime.Text);
        scores.JudgeTime = DateTime.Now;

        string userId = Request["UserID"].ToString();
        int paperId = int.Parse(Request["PaperID"]);
        if (userService.InsertScores(scores, PaperName, userId, paperId))
        {
            lblMessage.Text = "插入成功！";
        }
        else
        {
            lblMessage.Text = "插入失败！";
        }
    }
}
