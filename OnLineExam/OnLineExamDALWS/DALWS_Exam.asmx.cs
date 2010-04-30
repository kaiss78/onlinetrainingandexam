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
    /// DALWS_Exam 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class DALWS_Exam : System.Web.Services.WebService
    {

        [WebMethod]
        public bool AddExam(Exam exam)
        {
            string sql = @"insert into Exam (ExamID, CourseID, PaperID, StartTime, EndTime) 
VALUES (@ExamID, @CourseID, @PaperID, @StartTime, @EndTime)";

            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@ExamID", exam.ExamID),
                new SqlParameter("@CourseID", exam.CourseID),
                new SqlParameter("@PaperID", exam.PaperID),
                new SqlParameter("@StartTime", exam.StartTime),
                new SqlParameter("@EndTime", exam.EndTime)
            };

            int i = DBHelp.ExecuteCommand(sql, para);
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
        public void DelExam(int examID)
        {
            using (SqlConnection conn = DBHelp.GetConnection())
            {
                string sql = @"delete from Exam where ExamID = '" + examID + "'";

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = sql;

                conn.Open();

                cmd.ExecuteNonQuery();

                conn.Close();
            }
        }
    }
}
