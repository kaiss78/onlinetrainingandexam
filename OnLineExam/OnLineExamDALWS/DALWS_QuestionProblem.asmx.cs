using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using OnLineExamModel;

namespace OnLineExamDALWS
{
    /// <summary>
    /// DALWS_QuestionProblem 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class DALWS_QuestionProblem : System.Web.Services.WebService
    {

        [WebMethod]
        public bool QuestionProblemInsert(QuestionProblem qi)
        {
            string sql = "Insert into QuestionProblem(CourseID,Title,Answer) values(@CourseID,@Title,@Answer)";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@CourseID",qi.CourseID),
                new SqlParameter("@Title",qi.Title),
                new SqlParameter("@Answer",qi.Answer)
            };
            int i = DBHelp.ExecuteCommand(sql, param);
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        [WebMethod]
        public bool QuestionProblemUpdate(QuestionProblem qu)
        {
            string sql = "Update QuestionProblem Set CourseID=@CourseID,Title=@Title,Answer=@Answer where ID=@ID";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@CourseID",qu.CourseID),
                new SqlParameter("@Title",qu.Title),
                new SqlParameter("@Answer",qu.Answer),
                new SqlParameter("@ID",qu.ID)
            };
            int i = DBHelp.ExecuteCommand(sql, param);
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        [WebMethod]
        public List<QuestionProblem> GetQuestionProblemList(string selectvalue)
        {
            using (SqlConnection con = DBHelp.GetConnection())
            {
                string sql = "Select * from QuestionProblem where CourseID=" + selectvalue;
                SqlCommand cmd = new SqlCommand(sql,con);
                con.Open();
                List<QuestionProblem> list = new List<QuestionProblem>();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    QuestionProblem ques = new QuestionProblem();
                    ques.ID = Convert.ToInt32(dr["ID"]);
                    ques.CourseID = Convert.ToInt32(dr["CourseID"]);
                    ques.Title = dr["Title"].ToString();
                    ques.Answer = dr["Answer"].ToString();
                    list.Add(ques);
                }
                return list;
            }
        }

        [WebMethod]
        public List<QuestionProblem> selectQuesQuestion(string UserId, int PaperId)
        {
            using (SqlConnection con = DBHelp.GetConnection())
            {
                string sql = @"SELECT     dbo.UserAnswer.Mark, dbo.UserAnswer.UserAnswer, dbo.UserAnswer.ExamTime, dbo.QuestionProblem.Title, dbo.QuestionProblem.Answer, 
                      dbo.Paper.PaperName
FROM         dbo.UserAnswer INNER JOIN
                      dbo.QuestionProblem ON dbo.UserAnswer.TitleID = dbo.QuestionProblem.ID INNER JOIN
                      dbo.Paper ON dbo.UserAnswer.PaperID = dbo.Paper.PaperID AND dbo.UserAnswer.Type = '问答题'
where 
dbo.UserAnswer.UserID='" + UserId + "' and dbo.UserAnswer.PaperID='" + PaperId + "'";
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                List<QuestionProblem> list = new List<QuestionProblem>();
                while (dr.Read())
                {
                    QuestionProblem Ques = new QuestionProblem();
                    Ques.Mark = Convert.ToInt32(dr["Mark"]);
                    Ques.UserAnswer = dr["UserAnswer"].ToString();
                    Ques.ExamTime = Convert.ToDateTime(dr["ExamTime"]);
                    Ques.Title = dr["Title"].ToString();
                    Ques.Answer = dr["Answer"].ToString();
                    Ques.PaperName = dr["PaperName"].ToString();
                    list.Add(Ques);
                }
                return list;
            }
        }
    }
}
