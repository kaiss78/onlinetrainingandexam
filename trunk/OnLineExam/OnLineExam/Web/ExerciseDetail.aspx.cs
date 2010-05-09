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

public partial class Web_ExerciseDetail : System.Web.UI.Page
{
    BLLWS_User userService = new BLLWS_User();
    BLLWS_Exercise ExerciseService = new BLLWS_Exercise();

    protected void Page_Load(object sender, EventArgs e)
    {
        this.Page.Title = "练习详细信息";
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

                GetExerciseAll();
            }
        }

    }

    public void GetExerciseAll()
    {
        int ExerciseID = Convert.ToInt32(Request.QueryString["ExerciseID"].ToString());

        string type = "单选题";
        DataSet ds1 = ExerciseService.GetAllExerciseSing(ExerciseID, type); //单选题绑定
        GridView1.DataSource = ds1;
        GridView1.DataBind();



        type = "多选题";
        DataSet ds2 = ExerciseService.GetAllExerciseMult(ExerciseID, type);//多选题绑定
        GridView2.DataSource = ds2;
        GridView2.DataBind();



        type = "判断题";
        DataSet ds3 = ExerciseService.GetAllExerciseJudg(ExerciseID, type);//判断题绑定
        GridView3.DataSource = ds3;
        GridView3.DataBind();

        type = "填空题";
        DataSet ds4 = ExerciseService.GetAllExerciseFill(ExerciseID, type);//填空题绑定
        GridView4.DataSource = ds4;
        GridView4.DataBind();


        type = "问答题";
        DataSet ds5 = ExerciseService.GetAllExerciseQues(ExerciseID, type);//问答题绑定
        GridView5.DataSource = ds5;
        GridView5.DataBind();

    }
    protected void imgBtnReturn_Click(object sender, ImageClickEventArgs e)
    {
        Server.Transfer("ExerciseLists.aspx");

    }
}
