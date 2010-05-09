using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using System.Data;
using OnLineExamModel;

namespace OnLineExamDALWS
{
    /// <summary>
    /// DALWS_Exercise 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class DALWS_Exercise : System.Web.Services.WebService
    {

        [WebMethod]
        public string GetExerciseType(int id)
        {
            using (SqlConnection conn = DBHelp.GetConnection())
            {
                string type = "";
                string sql = "select * from Exercise where ExerciseID=" + id + "";
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    type = dr["ExerciseName"].ToString();
                }
                dr.Close();
                conn.Close();
                return type;
            }
        }

        
        [WebMethod]
        public bool UpdateExerciseState(int ExerciseID)
        {
            using (SqlConnection conn = DBHelp.GetConnection())
            {
                string sql = @"Update Paper set ExerciseState='false' where ExerciseID='{0}'";
                SqlCommand cmd = conn.CreateCommand();
                sql = string.Format(sql, ExerciseID);
                cmd.CommandText = sql;
                conn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
        }

        [WebMethod]
        public bool UpdateExerciseState1(int ExerciseID)
        {
            using (SqlConnection conn = DBHelp.GetConnection())
            {
                string sql = @"Update Paper set ExerciseState='true' where ExerciseID='{0}'";
                SqlCommand cmd = conn.CreateCommand();
                sql = string.Format(sql, ExerciseID);
                cmd.CommandText = sql;
                conn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
        }

        //删除试卷
        [WebMethod]
        public bool DeleteExercise(int ExerciseID)
        {
            using (SqlConnection conn = DBHelp.GetConnection())
            {
                string sql = @"Delete from Exercise where ExerciseID='{0}'";
                SqlCommand cmd = conn.CreateCommand();
                sql = string.Format(sql, ExerciseID);
                cmd.CommandText = sql;
                conn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
        }

        //删除试卷的题
        [WebMethod]
        public bool DeleteExerciseDetail(int ExerciseID)
        {
            using (SqlConnection conn = DBHelp.GetConnection())
            {
                string sql = @"Delete from ExerciseDetail where ExerciseID='{0}'";
                SqlCommand cmd = conn.CreateCommand();
                sql = string.Format(sql, ExerciseID);
                cmd.CommandText = sql;
                conn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
        }

        [WebMethod]
        public DataSet QueryAllExercise()
        {
            DBHelp DB = new DBHelp();
            return DB.GetDataSets("Proc_ExerciseList");
        }

        [WebMethod]
        public DataSet GetAllExerciseSing(int ExerciseId, string sb)
        {
            using (SqlConnection conn = DBHelp.GetConnection())
            {
                string sql =
                    @"select * from SingleProblem where ID in 
                    (select TitleID from dbo.ExerciseDetail where ExerciseID='{0}' and Type='{1}')";
                SqlCommand cmd = conn.CreateCommand();
                sql = string.Format(sql, ExerciseId, sb);
                cmd.CommandText = sql;
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet dataset = new DataSet();
                adapter.Fill(dataset);
                conn.Close();
                return dataset;
            }
        }

        [WebMethod]
        public DataSet GetAllExerciseSingMark(int ExerciseId, string sb)
        {
            using (SqlConnection conn = DBHelp.GetConnection())
            {
                string sql = @"select * from dbo.ExerciseDetail where ExerciseID='{0}' and Type='{1}'";
                SqlCommand cmd = conn.CreateCommand();
                sql = string.Format(sql, ExerciseId, sb);
                cmd.CommandText = sql;
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet dataset = new DataSet();
                adapter.Fill(dataset);
                conn.Close();
                return dataset;
            }
        }

        [WebMethod]
        public DataSet GetAllExerciseMult(int ExerciseId, string sb)
        {
            using (SqlConnection conn = DBHelp.GetConnection())
            {
                string sql =
                    @"select * from MultiProblem where ID in 
                    (select TitleID from dbo.ExerciseDetail where ExerciseID='{0}' and Type='{1}')";
                SqlCommand cmd = conn.CreateCommand();
                sql = string.Format(sql, ExerciseId, sb);
                cmd.CommandText = sql;
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet dataset = new DataSet();
                adapter.Fill(dataset);
                conn.Close();
                return dataset;
            }
        }

        [WebMethod]
        public DataSet GetAllExerciseMultMark(int ExerciseId, string sb)
        {
            using (SqlConnection conn = DBHelp.GetConnection())
            {
                string sql = @"select * from dbo.ExerciseDetail where ExerciseID='{0}' and Type='{1}'";
                SqlCommand cmd = conn.CreateCommand();
                sql = string.Format(sql, ExerciseId, sb);
                cmd.CommandText = sql;
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet dataset = new DataSet();
                adapter.Fill(dataset);
                conn.Close();
                return dataset;
            }
        }

        [WebMethod]
        public DataSet GetAllExerciseJudg(int ExerciseId, string sb)
        {
            using (SqlConnection conn = DBHelp.GetConnection())
            {
                string sql =
                    @"select * from JudgeProblem where ID in 
                    (select TitleID from dbo.ExerciseDetail where ExerciseID='{0}' and Type='{1}')";
                SqlCommand cmd = conn.CreateCommand();
                sql = string.Format(sql, ExerciseId, sb);
                cmd.CommandText = sql;
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet dataset = new DataSet();
                adapter.Fill(dataset);
                conn.Close();
                return dataset;
            }
        }

        [WebMethod]
        public DataSet GetAllExerciseJudgMark(int ExerciseId, string sb)
        {
            using (SqlConnection conn = DBHelp.GetConnection())
            {
                string sql = @"select * from dbo.ExerciseDetail where ExerciseID='{0}' and Type='{1}'";
                SqlCommand cmd = conn.CreateCommand();
                sql = string.Format(sql, ExerciseId, sb);
                cmd.CommandText = sql;
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet dataset = new DataSet();
                adapter.Fill(dataset);
                conn.Close();
                return dataset;
            }
        }

        [WebMethod]
        public DataSet GetAllExerciseFill(int ExerciseId, string sb)
        {
            using (SqlConnection conn = DBHelp.GetConnection())
            {
                string sql =
                    @"select * from FillBlankProblem where ID in 
                    (select TitleID from dbo.ExerciseDetail where ExerciseID='{0}' and Type='{1}')";
                SqlCommand cmd = conn.CreateCommand();
                sql = string.Format(sql, ExerciseId, sb);
                cmd.CommandText = sql;
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet dataset = new DataSet();
                adapter.Fill(dataset);
                conn.Close();
                return dataset;
            }
        }

        [WebMethod]
        public DataSet GetAllExerciseFillMark(int ExerciseId, string sb)
        {
            using (SqlConnection conn = DBHelp.GetConnection())
            {
                string sql = @"select * from dbo.ExerciseDetail where ExerciseID='{0}' and Type='{1}'";
                SqlCommand cmd = conn.CreateCommand();
                sql = string.Format(sql, ExerciseId, sb);
                cmd.CommandText = sql;
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet dataset = new DataSet();
                adapter.Fill(dataset);
                conn.Close();
                return dataset;
            }
        }

        [WebMethod]
        public DataSet GetAllExerciseQues(int ExerciseId, string sb)
        {
            using (SqlConnection conn = DBHelp.GetConnection())
            {
                string sql =
                    @"select * from QuestionProblem where ID in 
                    (select TitleID from dbo.ExerciseDetail where ExerciseID='{0}' and Type='{1}')";
                SqlCommand cmd = conn.CreateCommand();
                sql = string.Format(sql, ExerciseId, sb);
                cmd.CommandText = sql;
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet dataset = new DataSet();
                adapter.Fill(dataset);
                conn.Close();
                return dataset;
            }
        }

        [WebMethod]
        public DataSet GetAllExerciseQuesMark(int ExerciseId, string sb)
        {
            using (SqlConnection conn = DBHelp.GetConnection())
            {
                string sql = @"select * from dbo.ExerciseDetail where ExerciseID='{0}' and Type='{1}'";
                SqlCommand cmd = conn.CreateCommand();
                sql = string.Format(sql, ExerciseId, sb);
                cmd.CommandText = sql;
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet dataset = new DataSet();
                adapter.Fill(dataset);
                conn.Close();
                return dataset;
            }
        }

        [WebMethod]
        public DataSet QueryExercise()
        {
            using (SqlConnection conn = DBHelp.GetConnection())
            {
                string sql =
                    @"select * from Exercise where ExerciseState='True'";
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = sql;
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet dataset = new DataSet();
                adapter.Fill(dataset);
                conn.Close();
                return dataset;
            }
        }

        [WebMethod]
        public List<Exercise> SelectExercise()
        {
            using (SqlConnection con = DBHelp.GetConnection())
            {
                string sql = "select * from Exercise";
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                List<Exercise> list = new List<Exercise>();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Exercise p = new Exercise();
                    p.ExerciseID = Convert.ToInt32(dr["ExerciseID"].ToString());
                    p.CourseID = Convert.ToInt32(dr["CourseID"].ToString());
                    p.ExerciseName = dr["ExerciseName"].ToString();
                    list.Add(p);
                }
                dr.Close();
                con.Close();
                return list;
            }
        }
    }
}
