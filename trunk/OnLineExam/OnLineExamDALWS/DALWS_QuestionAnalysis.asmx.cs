using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using OnLineExamModel;
using System.ComponentModel;
using System.Collections;
using System.Data;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using System.Data.OleDb;
using System.Data.Sql;

namespace OnLineExamDALWS
{
    /// <summary>
    /// DALWS_QuestionAnalysis 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class DALWS_QuestionAnalysis : System.Web.Services.WebService
    {
        [WebMethod]
        public void insert(string sql)
        {
            try
            {
                string[] str = new string[2];
                string sel = "Data Source=.\\SqlExpress;Initial Catalog=OnLineExam;User ID=sa;Password=";
                SqlConnection conn = new SqlConnection(sel);
                conn.Open();
                SqlCommand sqlc = new SqlCommand(sql, conn);
                sqlc.ExecuteNonQuery();
                sqlc.Dispose();
                conn.Close();
            }
            catch (Exception e)
            {
            }
        }
        [WebMethod]
        public DataSet select(string sql)
        {
            try
            {
                string sel = "Data Source=.\\SqlExpress;Initial Catalog=OnLineExam;User ID=sa;Password=";
                SqlConnection conn = new SqlConnection(sel);
                conn.Open();
                SqlCommand sqlc = new SqlCommand(sql, conn);
                SqlDataAdapter ada = new SqlDataAdapter(sqlc);
                DataSet data1 = new DataSet();
                ada.Fill(data1, "t1");
                conn.Close();
                return data1;
            }
            catch (Exception e)
            {
                return null;
            }
        }


        [WebMethod]
        public List<FillBlankProblem> GeFillBlankProblemList()
        {
            using (SqlConnection con = DBHelp.GetConnection())
            {
                string sql = "select * from FillBlankProblem";
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                List<FillBlankProblem> list = new List<FillBlankProblem>();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    FillBlankProblem fill = new FillBlankProblem();
                    fill.ID = Convert.ToInt32(dr["ID"]);
                    fill.CourseID = Convert.ToInt32(dr["CourseID"]);
                    fill.FrontTitle = dr["FrontTitle"].ToString();
                    list.Add(fill);
                }
                return list;
            }
        }



        [WebMethod]
        public List<SingleProblem> GetSingleProblemList()
        {
            using (SqlConnection con = DBHelp.GetConnection())
            {
                string sql = "select * from SingleProblem";
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                List<SingleProblem> list = new List<SingleProblem>();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    SingleProblem sing = new SingleProblem();
                    sing.ID = Convert.ToInt32(dr["ID"]);
                    sing.CourseID = Convert.ToInt32(dr["CourseID"]);
                    sing.Title = dr["Title"].ToString();
                    list.Add(sing);
                }
                return list;
            }
        }



        [WebMethod]
        public List<QuestionProblem> GetQuestionProblemList()
        {
            using (SqlConnection con = DBHelp.GetConnection())
            {
                string sql = "Select * from QuestionProblem";
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                List<QuestionProblem> list = new List<QuestionProblem>();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    QuestionProblem ques = new QuestionProblem();
                    ques.ID = Convert.ToInt32(dr["ID"]);
                    ques.CourseID = Convert.ToInt32(dr["CourseID"]);
                    ques.Title = dr["Title"].ToString();
                    list.Add(ques);
                }
                return list;
            }
        }

        [WebMethod]
        public List<MultiProblem> GetMultiProblemList()
        {
            using (SqlConnection con = DBHelp.GetConnection())
            {
                string sql = "select * from MultiProblem";
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
                    list.Add(mul);
                }
                return list;
            }
        }


        [WebMethod]
        public List<JudgeProblem> GetJudgeProblemList()
        {
            using (SqlConnection conn = DBHelp.GetConnection())
            {
                string sql = "select * from JudgeProblem";
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                List<JudgeProblem> list = new List<JudgeProblem>();
                SqlDataReader DR = cmd.ExecuteReader();
                if (DR.Read())
                {
                    JudgeProblem judge = new JudgeProblem();
                    judge.ID = Convert.ToInt32(DR["ID"]);
                    judge.CourseID = Convert.ToInt32(DR["CourseID"]);
                    judge.Title = DR["Title"].ToString();
                    list.Add(judge);
                }
                return list;
            }
        }

     


    }
}
