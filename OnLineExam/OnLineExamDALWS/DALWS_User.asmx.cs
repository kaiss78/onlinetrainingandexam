using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using OnLineExamModel;
using System.Data;

namespace OnLineExamDALWS
{
    /// <summary>
    /// Service1 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class DALWS_User : System.Web.Services.WebService
    {

        [WebMethod]
        public List<Scores> SelectAll(string PaperID)
        {
            using (SqlConnection conn = DBHelp.GetConnection())
            {
                string sql;
                if (PaperID == null)
                    sql = @"select ID,Score.UserID,PaperID,Score,ExamTime,JudgeTime,Users.UserName from Score,Users 
where Score.UserID=Users.UserID";
                else
                    sql = @"select ID,Score.UserID,PaperID,Score,ExamTime,JudgeTime,Users.UserName from Score,Users 
where Score.UserID=Users.UserID and PaperID='" + PaperID + "'";
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = sql;

                conn.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                List<Scores> list = new List<Scores>();

                while (dr.Read())
                {
                    Users user = new Users();
                    Scores scores = new Scores();

                    scores.ID = Convert.ToInt32(dr["ID"]);
                    scores.UserID = dr["UserID"].ToString();
                    user.UserName = dr["UserName"].ToString();
                    scores.UserName = user.UserName;
                    scores.PaperID = Convert.ToInt32(dr["PaperID"]);
                    scores.Score = Convert.ToInt32(dr["Score"]);
                    scores.ExamTime = Convert.ToDateTime(dr["ExamTime"]);
                    scores.JudgeTime = Convert.ToDateTime(dr["JudgeTime"]);

                    list.Add(scores);
                }

                dr.Close();

                conn.Close();

                return list;
            }
        }

        //        [WebMethod]
        //        public List<Scores> SelectAll()
        //        {
        //            using (SqlConnection conn = DBHelp.GetConnection())
        //            {
        //                string sql = @"select ID,Score.UserID,PaperID,Score,ExamTime,JudgeTime,Users.UserName from Score,Users 
        //where Score.UserID=Users.UserID";
        //                SqlCommand cmd = conn.CreateCommand();
        //                cmd.CommandText = sql;

        //                conn.Open();

        //                SqlDataReader dr = cmd.ExecuteReader();

        //                List<Scores> list = new List<Scores>();

        //                while (dr.Read())
        //                {
        //                    Users user = new Users();
        //                    Scores scores = new Scores();

        //                    scores.ID = Convert.ToInt32(dr["ID"]);
        //                    scores.UserID = dr["UserID"].ToString();
        //                    user.UserName = dr["UserName"].ToString();
        //                    scores.UserName = user.UserName;
        //                    scores.PaperID = Convert.ToInt32(dr["PaperID"]);
        //                    scores.Score = Convert.ToInt32(dr["Score"]);
        //                    scores.ExamTime = Convert.ToDateTime(dr["ExamTime"]);
        //                    scores.JudgeTime = Convert.ToDateTime(dr["JudgeTime"]);

        //                    list.Add(scores);
        //                }

        //                dr.Close();

        //                conn.Close();

        //                return list;
        //            }
        //        }

        [WebMethod]
        public List<Users> SelectUserID(string userID)
        {
            using (SqlConnection conn = DBHelp.GetConnection())
            {
                string sql = @"select UserId,UserName,RoleName,Phone,Email from Users,[Role]where Users.roleId  = [Role].roleId and UserID='" + userID + "' ";
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

                    Role role = new Role();
                    role.RoleName = sdr["RoleName"].ToString();
                    user.RoleName = role.RoleName;

                    user.Phone = sdr["Phone"].ToString();
                    user.Email = sdr["Email"].ToString();

                    list.Add(user);
                }

                sdr.Close();

                conn.Close();

                return list;
            }
        }

        [WebMethod]
        public List<Users> SelectUserName(string userName)
        {
            using (SqlConnection conn = DBHelp.GetConnection())
            {
                string sql = @"select UserId,UserName,RoleName,Phone,Email from Users,[Role]where Users.roleId  = [Role].roleId and UserName='" + userName + "' ";
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

                    Role role = new Role();
                    role.RoleName = sdr["RoleName"].ToString();
                    user.RoleName = role.RoleName;

                    user.Phone = sdr["Phone"].ToString();
                    user.Email = sdr["Email"].ToString();

                    list.Add(user);
                }

                sdr.Close();

                conn.Close();

                return list;
            }
        }

        [WebMethod]
        public List<Users> SelectUser()
        {
            using (SqlConnection conn = DBHelp.GetConnection())
            {
                string sql = @"select UserId,UserName,RoleName,Phone,Email from Users,[Role]where Users.roleId  = [Role].roleId";

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

                    Role role = new Role();
                    role.RoleName = sdr["RoleName"].ToString();
                    user.RoleName = role.RoleName;

                    user.Phone = sdr["Phone"].ToString();
                    user.Email = sdr["Email"].ToString();

                    list.Add(user);
                }

                sdr.Close();

                conn.Close();

                return list;
            }
        }

        [WebMethod]
        public bool insertUsers(Users user)
        {
            string sql = @"insert into Users (UserId,UserName,UserPwd,RoleId,Phone,Email) 
VALUES (@UserId,@UserName,@UserPwd,@RoleId,@Phone,@Email)";

            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@UserId",user.UserID),
                new SqlParameter("@UserName",user.UserName),
                new SqlParameter("@UserPwd",user.UserPwd),
                new SqlParameter("@RoleId",user.RoleId),
                new SqlParameter("@Phone",user.Phone),
                new SqlParameter("@Email",user.Email)
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
        public Users LoginUser(string UserID, string pwd)
        {
            using (SqlConnection conn = DBHelp.GetConnection())
            {
                string sql = @"SELECT 
UserID, UserName,UserPwd,Users.RoleId,RoleName
FROM Users, Role
WHERE UserID ='{0}' AND UserPwd ='{1}' AND Users.RoleId = Role.RoleId";



                SqlCommand cmd = conn.CreateCommand();
                sql = string.Format(sql, UserID, pwd);
                cmd.CommandText = sql;
                conn.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                if (!dr.Read())
                {
                    return null;
                }

                Users u = PopUserFromDataReader(dr);
                u.RoleId = u.Role.RoleId;

                dr.Close();

                return u;
            }
        }

        [WebMethod]
        private Users PopUserFromDataReader(IDataReader dr)
        {
            Users u = new Users();

            u.UserID = dr["UserID"].ToString();
            u.UserName = dr["UserName"].ToString();
            u.UserPwd = dr["UserPwd"].ToString();


            Role role = new Role();

            role.RoleId = Convert.ToInt32(dr["RoleId"]);
            role.RoleName = dr["RoleName"].ToString();

            u.Role = role;

            return u;
        }

        [WebMethod]
        public bool Update(string UserPwd, string UserId)//根椐用的帐号修改密码;
        {
            using (SqlConnection conn = DBHelp.GetConnection())
            {
                string sql = "update Users set UserPwd='{0}' where UserID='{1}'";

                SqlCommand cmd = conn.CreateCommand();
                sql = string.Format(sql, UserPwd, UserId);
                cmd.CommandText = sql;
                conn.Open();

                cmd.ExecuteNonQuery();

                conn.Close();
            }
            return true;
        }

        //[WebMethod]
        //public bool Update1(string UserId, string UserPwd)
        //{
        //    using (SqlConnection conn = DBHelp.GetConnection())
        //    {
        //        string sql = "update Users set UserPwd='{0}' where UserID='{1}'";

        //        SqlCommand cmd = conn.CreateCommand();
        //        sql = string.Format(sql, UserPwd, UserId);
        //        cmd.CommandText = sql;
        //        conn.Open();

        //        cmd.ExecuteNonQuery();

        //        conn.Close();
        //    }

        //    return true;
        //}

        [WebMethod]
        public bool delUserId(string UserId)
        {
            using (SqlConnection conn = DBHelp.GetConnection())
            {
                string sql = @"delete from Users where UserId = '" + UserId + "'";

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = sql;

                conn.Open();

                cmd.ExecuteNonQuery();

                conn.Close();
            }

            return true;
        }

        [WebMethod]
        public List<UserAnswer> selectUserPaperList()
        {
            using (SqlConnection con = DBHelp.GetConnection())
            {
                string sql = @"select 
u.UserName,p.PaperName,ua.ExamTime,ua.UserID,ua.PaperID
from
Users as u,Paper as p,UserAnswer as ua
where 
ua.UserID = u.UserID and ua.PaperID = p.PaperID and ua.ExamTime = ua.ExamTime and ua.UserID= ua.UserID and ua.PaperID=ua.PaperID
Group by 
u.UserName,p.PaperName,ua.ExamTime,ua.UserID,ua.PaperID";
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                List<UserAnswer> list = new List<UserAnswer>();
                while (dr.Read())
                {
                    UserAnswer user = new UserAnswer();
                    user.UserID = dr["UserID"].ToString();
                    user.PaperID = Convert.ToInt32(dr["PaperID"]);
                    user.ExamTime = Convert.ToDateTime(dr["ExamTime"]);
                    user.UserName = dr["UserName"].ToString();
                    user.PaperName = dr["PaperName"].ToString();
                    list.Add(user);
                }
                return list;
            }
        }

        [WebMethod]
        public bool DeleteUserPaperList(string UsersID, int PapersID)
        {
            using (SqlConnection con = DBHelp.GetConnection())
            {
                string sql = "delete from UserAnswer where UserID='" + UsersID + "' and PaperID='" + PapersID + "'";
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = sql;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            return true;
        }

        [WebMethod]
        public bool delScores(string UserID)//根据Scores表的用户ID列删除对应行记录
        {
            using (SqlConnection conn = DBHelp.GetConnection())
            {
                string sql = @"delete from Score where UserID='" + UserID + "'";

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = sql;

                conn.Open();

                cmd.ExecuteNonQuery();

                conn.Close();
            }

            return true;
        }

        [WebMethod]
        //查询用户考试信息
        public List<UserAnswer> selectExamInfo(string name)
        {
            using (SqlConnection con = DBHelp.GetConnection())
            {


                string sql = @"select 
UserName,PaperName,Score,ExamTime,JudgeTime
from 
Score,Paper,Users
where
paper.PaperID = Score.PaperID and Users.UserID = Score.UserID and Score.UserID='" + name + "'";
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                List<UserAnswer> list = new List<UserAnswer>();
                while (dr.Read())
                {
                    UserAnswer user = new UserAnswer();
                    // user.UserID = dr["UserID"].ToString();
                    user.UserName = dr["UserName"].ToString();
                    user.ExamTime = Convert.ToDateTime(dr["ExamTime"]);
                    // user.UserName = dr["UserName"].ToString();
                    user.PaperName = dr["PaperName"].ToString();
                    user.Score = Convert.ToInt32(dr["Score"]);
                    user.JudgeTime = Convert.ToDateTime(dr["JudgeTime"]);
                    list.Add(user);

                }
                return list;
            }
        }

        [WebMethod]
        public bool SeclctCheck(string userId, int paperId)
        {
            using (SqlConnection con = DBHelp.GetConnection())
            {
                string sql = @"select count (*) from Score where UserID='" + userId + "' and PaperID='" + paperId + "'";
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                if (Convert.ToBoolean(cmd.ExecuteScalar()))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }


        }

        [WebMethod]
        //插入考试成绩
        public bool InsertScore(Scores score, string PaperName, string userId, int paperId)
        {
            if (SeclctCheck(userId, paperId))
            {
                using (SqlConnection con = DBHelp.GetConnection())
                {
                    string sql = @"insert into Score 
    (UserID,PaperID,Score,ExamTime,JudgeTime)
    select 
    @UserID,
    PaperID,
    @Score,
    @ExamTime,
    @JudgeTime
    from 
    Paper
    where 
    PaperName = '" + PaperName + "'";


                    SqlParameter[] para = new SqlParameter[]
                {
                    new SqlParameter("@UserId",score.UserID),
                    new SqlParameter("@PaperID",score.PaperID),
                    new SqlParameter("@Score",score.Score),
                    new SqlParameter("@ExamTime",score.ExamTime),
                    new SqlParameter("@JudgeTime",score.JudgeTime)
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
            }
            else
            {
                using (SqlConnection con = DBHelp.GetConnection())
                {
                    string sql = @"update Score set Score=@Score, JudgeTime=@JudgeTime where UserID=@UserId and PaperID=@PaperID";

                    SqlParameter[] para = new SqlParameter[]
                {
                    new SqlParameter("@Score",score.Score),
                    new SqlParameter("@JudgeTime",score.JudgeTime),
                    new SqlParameter("@UserId",score.UserID),
                    new SqlParameter("@PaperID",paperId)
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
            }
        }

        [WebMethod]
        public string GetTime(int id)
        {
            using (SqlConnection con = DBHelp.GetConnection())
            {
                string time = string.Empty;
                string sql = "select * from UserAnswer where UserID=" + id + "";
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    time = dr["ExamTime"].ToString();
                }
                dr.Close();
                con.Close();
                return time;
            }
        }

        [WebMethod]
        public bool SelectPwd(string Pwd)
        {
            using (SqlConnection conn = DBHelp.GetConnection())
            {
                string sql = "select UserID from Users where UserPwd='" + Pwd + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    dr.Close();
                    conn.Close();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        [WebMethod]
        public string GetUserName(string UserID)
        {
            using (SqlConnection conn = DBHelp.GetConnection())
            {
                string sql = @"select UserName from dbo.Users where UserID='{0}'";



                SqlCommand cmd = conn.CreateCommand();
                sql = string.Format(sql, UserID);
                cmd.CommandText = sql;
                conn.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    return dr["UserName"].ToString();
                }

                //Users u = PopUserFromDataReader(dr);

                dr.Close();
                conn.Close();

                return "";
            }
        }
    }
}
