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
    /// DALWS_Paper 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class DALWS_Paper : System.Web.Services.WebService
    {

        [WebMethod]
        public string GetPaperType(int id)
        {
            using (SqlConnection conn = DBHelp.GetConnection())
            {
                string type = "";
                string sql = "select * from Paper where PaperID=" + id + "";
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    type = dr["PaperName"].ToString();
                }
                dr.Close();
                conn.Close();
                return type;
            }
        }
        
        /// <summary>
        /// </summary>
        /// <param name="PaperID"></param>
        /// <returns></returns>
        [WebMethod]
        public bool UpdatePaperState(int PaperID)
        {
            using (SqlConnection conn = DBHelp.GetConnection())
            {
                string sql = @"Update Paper set PaperState='false' where PaperID='{0}'";
                SqlCommand cmd = conn.CreateCommand();
                sql = string.Format(sql, PaperID);
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
        public bool UpdatePaperState1(int PaperID)
        {
            using (SqlConnection conn = DBHelp.GetConnection())
            {
                string sql = @"Update Paper set PaperState='true' where PaperID='{0}'";
                SqlCommand cmd = conn.CreateCommand();
                sql = string.Format(sql, PaperID);
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
        public bool DeletePaper(int PaperID)
        {
            using (SqlConnection conn = DBHelp.GetConnection())
            {
                string sql = @"Delete from Paper where PaperID='{0}'";
                SqlCommand cmd = conn.CreateCommand();
                sql = string.Format(sql, PaperID);
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
        public bool DeletePaperDetail(int PaperID)
        {
            using (SqlConnection conn = DBHelp.GetConnection())
            {
                string sql = @"Delete from PaperDetail where PaperID='{0}'";
                SqlCommand cmd = conn.CreateCommand();
                sql = string.Format(sql, PaperID);
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
        public DataSet QueryAllPaper()
        {
            DBHelp DB = new DBHelp();
            return DB.GetDataSets("Proc_PaperList");
        }

        [WebMethod]
        public DataSet GetAllPaperSing(int PapperId, string sb)
        {
            using (SqlConnection conn = DBHelp.GetConnection())
            {
                string sql =
                    @"select * from SingleProblem where ID in 
                    (select TitleID from dbo.PaperDetail where PaperID='{0}' and Type='{1}')";
                SqlCommand cmd = conn.CreateCommand();
                sql = string.Format(sql, PapperId, sb);
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
        public DataSet GetAllPaperSingMark(int PapperId, string sb)
        {
            using (SqlConnection conn = DBHelp.GetConnection())
            {
                string sql = @"select * from dbo.PaperDetail where PaperID='{0}' and Type='{1}'";
                SqlCommand cmd = conn.CreateCommand();
                sql = string.Format(sql, PapperId, sb);
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
        public DataSet GetAllPaperMult(int PapperId, string sb)
        {
            using (SqlConnection conn = DBHelp.GetConnection())
            {
                string sql =
                    @"select * from MultiProblem where ID in 
                    (select TitleID from dbo.PaperDetail where PaperID='{0}' and Type='{1}')";
                SqlCommand cmd = conn.CreateCommand();
                sql = string.Format(sql, PapperId, sb);
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
        public DataSet GetAllPaperMultMark(int PapperId, string sb)
        {
            using (SqlConnection conn = DBHelp.GetConnection())
            {
                string sql = @"select * from dbo.PaperDetail where PaperID='{0}' and Type='{1}'";
                SqlCommand cmd = conn.CreateCommand();
                sql = string.Format(sql, PapperId, sb);
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
        public DataSet GetAllPaperJudg(int PapperId, string sb)
        {
            using (SqlConnection conn = DBHelp.GetConnection())
            {
                string sql =
                    @"select * from JudgeProblem where ID in 
                    (select TitleID from dbo.PaperDetail where PaperID='{0}' and Type='{1}')";
                SqlCommand cmd = conn.CreateCommand();
                sql = string.Format(sql, PapperId, sb);
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
        public DataSet GetAllPaperJudgMark(int PapperId, string sb)
        {
            using (SqlConnection conn = DBHelp.GetConnection())
            {
                string sql = @"select * from dbo.PaperDetail where PaperID='{0}' and Type='{1}'";
                SqlCommand cmd = conn.CreateCommand();
                sql = string.Format(sql, PapperId, sb);
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
        public DataSet GetAllPaperFill(int PapperId, string sb)
        {
            using (SqlConnection conn = DBHelp.GetConnection())
            {
                string sql =
                    @"select * from FillBlankProblem where ID in 
                    (select TitleID from dbo.PaperDetail where PaperID='{0}' and Type='{1}')";
                SqlCommand cmd = conn.CreateCommand();
                sql = string.Format(sql, PapperId, sb);
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
        public DataSet GetAllPaperFillMark(int PapperId, string sb)
        {
            using (SqlConnection conn = DBHelp.GetConnection())
            {
                string sql = @"select * from dbo.PaperDetail where PaperID='{0}' and Type='{1}'";
                SqlCommand cmd = conn.CreateCommand();
                sql = string.Format(sql, PapperId, sb);
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
        public DataSet GetAllPaperQues(int PapperId, string sb)
        {
            using (SqlConnection conn = DBHelp.GetConnection())
            {
                string sql =
                    @"select * from QuestionProblem where ID in 
                    (select TitleID from dbo.PaperDetail where PaperID='{0}' and Type='{1}')";
                SqlCommand cmd = conn.CreateCommand();
                sql = string.Format(sql, PapperId, sb);
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
        public DataSet GetAllPaperQuesMark(int PapperId, string sb)
        {
            using (SqlConnection conn = DBHelp.GetConnection())
            {
                string sql = @"select * from dbo.PaperDetail where PaperID='{0}' and Type='{1}'";
                SqlCommand cmd = conn.CreateCommand();
                sql = string.Format(sql, PapperId, sb);
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
        public DataSet QueryPaper()
        {
            using (SqlConnection conn = DBHelp.GetConnection())
            {
                string sql =
                    @"select * from Paper where PaperState='True'";
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
        public List<Paper> SelectPaper()
        {
            using (SqlConnection con = DBHelp.GetConnection())
            {
                string sql = "select * from Paper";
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                List<Paper> list = new List<Paper>();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Paper p = new Paper();
                    p.PaperID = Convert.ToInt32(dr["PaperID"].ToString());
                    p.CourseID = Convert.ToInt32(dr["CourseID"].ToString());
                    p.PaperName = dr["PaperName"].ToString();
                    list.Add(p);
                }
                dr.Close();
                con.Close();
                return list;
            }
        }
    }
}
