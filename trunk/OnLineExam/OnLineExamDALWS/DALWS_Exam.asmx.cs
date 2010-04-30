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
            string sql = @"insert into Exam (CourseID, PaperID, StartTime, EndTime) 
VALUES (@CourseID, @PaperID, @StartTime, @EndTime)";

            SqlParameter[] para = new SqlParameter[]
            {
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

        [WebMethod]
        public List<Exam> ListExam()
        {
            using (SqlConnection con = DBHelp.GetConnection())
            {
                string sql = "select Exam.ExamID, Exam.CourseID, Exam.PaperID, StartTime, EndTime, Course.Name, PaperName from Exam, Course, Paper where Course.ID = Paper.CourseID and Exam.PaperID = Paper.PaperID";
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                List<Exam> list = new List<Exam>();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Exam e = new Exam();
                    e.ExamID = Convert.ToInt32(dr["ExamID"].ToString());
                    //e.CourseID = Convert.ToInt32(dr["CourseID"].ToString());
                    //e.PaperID = Convert.ToInt32(dr["PaperID"].ToString());
                    e.CourseName = dr["Name"].ToString();
                    e.PaperName = dr["PaperName"].ToString();
                    e.StartTime = Convert.ToDateTime(dr["StartTime"]);
                    e.EndTime = Convert.ToDateTime(dr["EndTime"]);
                    list.Add(e);
                }
                dr.Close();
                con.Close();
                return list;
            }
        }
    }
}
