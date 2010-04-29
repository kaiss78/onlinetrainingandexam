using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using OnLineExamModel;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace OnLineExamDALWS
{
    /// <summary>
    /// WebService1 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {
        [WebMethod]
        public List<Users> SelectUserName()
        {
            using (SqlConnection conn = DBHelp.GetConnection())
            {
                string sql = @"select UserId,UserName from Users where Users.roleId  = 3";
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = sql;
                conn.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                List<Users> list = new List<Users>();

                while (sdr.Read())
                {
                    Users user = new Users();
                    user.UserID = sdr["userID"].ToString();
                    user.UserName = sdr["userName"].ToString();
                    list.Add(user);
                }
                sdr.Close();
                conn.Close();
                return list;
            }
        }

        public string  SelectUserName(string userid)
        {
            using (SqlConnection conn = DBHelp.GetConnection())
            {
                string sql = @"select UserName from Users where Users.UserId  = '" + userid + "'";
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = sql;
                conn.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                string name = "";

                while (sdr.Read())
                {
                    name = sdr["userName"].ToString();
                }
                sdr.Close();
                conn.Close();
                return name;
            }
        }

        [WebMethod]
        public List<Scores> SelectUserScores(string userID)
        {
            using (SqlConnection conn = DBHelp.GetConnection())
            {
                string sql = @"select * from Score where Score.userID  = '" + userID + "'";
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = sql;
                conn.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                List<Scores> list = new List<Scores>();
                while (sdr.Read())
                {
                    Scores score = new Scores();  
                    score.ID=  Convert.ToInt32(sdr["ID"]);
                    score.PaperID = Convert.ToInt32(sdr["PaperID"]);
                    score.Score = Convert.ToInt32(sdr["Score"]);
                    score.ExamTime = Convert.ToDateTime(sdr["ExamTime"]);
                    score.JudgeTime = Convert.ToDateTime(sdr["JudgeTime"]);
                    score.UserID = sdr["UserID"].ToString();
                    score.UserName = SelectUserName(score.UserID); 
                    list.Add(score);
                }
                sdr.Close();
                conn.Close();
                return list;
            }
        }

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

    }
}
