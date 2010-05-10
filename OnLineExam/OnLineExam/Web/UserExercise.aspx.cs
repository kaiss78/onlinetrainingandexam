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

public partial class Web_UserExercise : System.Web.UI.Page
{
    BLLWS_User userService = new BLLWS_User();
    BLLWS_Exercise exerciseService = new BLLWS_Exercise();
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

                lblExerciseName.Text = Session["ExerciseName"].ToString();

                Exercise exercise = exerciseService.GetExercise(Convert.ToInt32(Session["ExerciseID"]));
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
        TextBox text = new TextBox();
        int grade = 0;
        for (int k = 0; k < GridView1.Rows.Count; k++)
        {
            text = GridView1.Rows[k].FindControl("tbxqueScore1") as TextBox;
            grade += Convert.ToInt32(text.Text);
        }
        for (int k = 0; k < GridView2.Rows.Count; k++)
        {
            text = GridView2.Rows[k].FindControl("tbxqueScore2") as TextBox;
            grade += Convert.ToInt32(text.Text);
        } 
        for (int k = 0; k < GridView3.Rows.Count; k++)
        {
            text = GridView5.Rows[k].FindControl("tbxqueScore3") as TextBox;
            grade += Convert.ToInt32(text.Text);
        } 
        for (int k = 0; k < GridView4.Rows.Count; k++)
        {
            text = GridView4.Rows[k].FindControl("tbxqueScore") as TextBox;
            grade += Convert.ToInt32(text.Text);
        } 
        for (int k = 0; k < GridView5.Rows.Count; k++)
        {
            text = GridView5.Rows[k].FindControl("tbxqueScore") as TextBox;
            grade += Convert.ToInt32(text.Text);
        }

        string userID = Session["userID"].ToString();
        int exerciseID = Convert.ToInt32(Session["ExerciseID"]);
        DBHelp db = new DBHelp();
        string sql = "insert into ExerciseScore(UserID,ExerciseID,Score) values('" + userID + "'," + exerciseID + "," + grade + ")";
        db.Insert(sql);
        
    }

    protected void imgBtnAnswer_Click(object sender, ImageClickEventArgs e)
    {
        int exerciseid = Convert.ToInt32(Session["ExerciseID"]);

        GridView1.DataSource = exerciseService.GetSingQuestion(exerciseid);
        GridView1.DataBind();

        GridView2.DataSource = exerciseService.GetMultiQuestion(exerciseid);
        GridView2.DataBind();

        GridView3.DataSource = exerciseService.GetJudgeQuestion (exerciseid);
        GridView3.DataBind();

        GridView4.DataSource = exerciseService.GetFillBlankQuestion(exerciseid);
        GridView4.DataBind();

        GridView5.DataSource = exerciseService.GetQuestionQuestion(exerciseid);
        GridView5.DataBind();
        
       
    }
}
