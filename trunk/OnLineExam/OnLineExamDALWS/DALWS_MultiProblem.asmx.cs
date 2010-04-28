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
    /// DALWS_MultiProblem 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class DALWS_MultiProblem : System.Web.Services.WebService
    {

        [WebMethod]
        public bool MultiProblemInsert(MultiProblem mi)
        {
            string sql = @"Insert into MultiProblem (CourseID,Title,AnswerA,AnswerB,AnswerC,AnswerD,Answer) 
values(@CourseID,@Title,@AnswerA,@AnswerB,@AnswerC,@AnswerD,@Answer)";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@CourseID",mi.CourseID),
                new SqlParameter("@Title",mi.Title),
                new SqlParameter("@AnswerA",mi.AnswerA),
                new SqlParameter("@AnswerB",mi.AnswerB),
                new SqlParameter("@AnswerC",mi.AnswerC),
                new SqlParameter("@AnswerD",mi.AnswerD),
                new SqlParameter("@Answer",mi.Answer)
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
        public bool MultiProblemUpdate(MultiProblem mu)
        {
            string sql = @"Update MultiProblem Set CourseID=@CourseID,Title=@Title,AnswerA=@AnswerA,
AnswerB=@AnswerB,AnswerC=@AnswerC,AnswerD=@AnswerD,Answer=@Answer where ID=@ID";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@CourseID",mu.CourseID),
                new SqlParameter("@Title",mu.Title),
                new SqlParameter("@AnswerA",mu.AnswerA),
                new SqlParameter("@AnswerB",mu.AnswerB),
                new SqlParameter("@AnswerC",mu.AnswerC),
                new SqlParameter("@AnswerD",mu.AnswerD),
                new SqlParameter("@Answer",mu.Answer),
                new SqlParameter("@ID",mu.ID)
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
        public List<MultiProblem> GetMultiProblemList(string selectvalue)
        {
            using (SqlConnection con = DBHelp.GetConnection())
            {
                string sql = "select * from MultiProblem where CourseID='" + selectvalue + "'";
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                List<MultiProblem> list = new List<MultiProblem>();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    MultiProblem mul = new MultiProblem();
                    mul.ID = Convert.ToInt32(dr["ID"]);
                    mul.CourseID = Convert.ToInt32(dr["CourseID"]);
                    mul.Title = dr["Title"].ToString();
                    mul.AnswerA = dr["AnswerA"].ToString();
                    mul.AnswerB = dr["AnswerB"].ToString();
                    mul.AnswerC = dr["AnswerC"].ToString();
                    mul.AnswerD = dr["AnswerD"].ToString();
                    mul.Answer = dr["Answer"].ToString();
                    list.Add(mul);
                }
                return list;
            }
        }

        //根据页面传值展示相应值
        [WebMethod]
        public List<MultiProblem> selectMutiQuestion(string UserId, int PaperId)
        {
            using (SqlConnection con = DBHelp.GetConnection())
            {
                string sql = @"SELECT     dbo.UserAnswer.UserAnswer, dbo.UserAnswer.ExamTime, dbo.MultiProblem.Title, dbo.MultiProblem.AnswerA, dbo.MultiProblem.AnswerB, 
                      dbo.MultiProblem.AnswerC, dbo.MultiProblem.AnswerD, dbo.MultiProblem.Answer, dbo.UserAnswer.Mark, dbo.Paper.PaperName
FROM         dbo.UserAnswer INNER JOIN
                      dbo.MultiProblem ON dbo.UserAnswer.TitleID = dbo.MultiProblem.ID AND dbo.UserAnswer.Type = '多选题' INNER JOIN
                      dbo.Paper ON dbo.UserAnswer.PaperID = dbo.Paper.PaperID AND dbo.UserAnswer.Type = '多选题' 
where 
dbo.UserAnswer.UserID='" + UserId + "' and dbo.UserAnswer.PaperID='" + PaperId + "'";
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                List<MultiProblem> list = new List<MultiProblem>();
                while (dr.Read())
                {
                    MultiProblem mul = new MultiProblem();
                    mul.UserAnswer = dr["UserAnswer"].ToString();
                    mul.Answer = dr["Answer"].ToString();
                    mul.ExamTime = Convert.ToDateTime(dr["ExamTime"]);
                    mul.Title = dr["Title"].ToString();
                    mul.AnswerA = dr["AnswerA"].ToString();
                    mul.AnswerB = dr["AnswerB"].ToString();
                    mul.AnswerC = dr["AnswerC"].ToString();
                    mul.AnswerD = dr["AnswerD"].ToString();
                    mul.Answer = dr["Answer"].ToString();
                    mul.Mark = Convert.ToInt32(dr["Mark"]);
                    mul.PaperName = dr["PaperName"].ToString();
                    list.Add(mul);
                }
                return list;
            }
        }
    }
}
