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
    /// DALWS_Course 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class DALWS_Course : System.Web.Services.WebService
    {

        [WebMethod]
        public void Update(string Name, string ID)
        {
            using (SqlConnection conn = DBHelp.GetConnection())
            {
                string sql = "update Users set Name='{0}' where ID='{1}'";

                SqlCommand cmd = conn.CreateCommand();
                sql = string.Format(sql, Name, ID);
                cmd.CommandText = sql;
                conn.Open();

                cmd.ExecuteNonQuery();

                conn.Close();
            }
        }

        [WebMethod]
        public bool insertCourse(Course ic, string userID)
        {
            string sql = "insert into Course ([Name]) values(@Name)";
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@Name",ic.DepartmentName)
            };
            int i = DBHelp.ExecuteCommand(sql, para);
            if (i <= 0)
            {
                return false;
            }

            sql = "select ID from Course where Name = '" + ic.DepartmentName + "'";
            SqlConnection con = DBHelp.GetConnection();
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            int courseID = 0;
            while (dr.Read())
            {
                courseID = Convert.ToInt32(dr["ID"].ToString());
            }
            dr.Close();
            con.Close();

            sql = "insert into Course_User (CourseID, UserID) values(@CourseID, @UserID)";
            para = new SqlParameter[]
            {
                new SqlParameter("@CourseID", courseID),
                new SqlParameter("@UserID", userID)
            };
            i = DBHelp.ExecuteCommand(sql, para);
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
        public bool DeleteCourse(Course id)
        {
            using (SqlConnection con = DBHelp.GetConnection())
            {
                string sql = "delete from Course where ID=@id";
                SqlParameter[] sp = new SqlParameter[] 
                {
                    new SqlParameter("@id",id.DepartmentId),
                };

                string sql2 = "delete from Course_User where CourseID=@id";
                SqlParameter[] sp2 = new SqlParameter[] 
                {
                    new SqlParameter("@id",id.DepartmentId),
                };

                if (DBHelp.ExecuteCommand(sql, sp) > 0 && DBHelp.ExecuteCommand(sql2, sp2) > 0)
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
        public List<Course> SelectCourse()
        {
            using (SqlConnection con = DBHelp.GetConnection())
            {
                string sql = "select * from Course";
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                List<Course> list = new List<Course>();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Course c = new Course();
                    c.DepartmentId = Convert.ToInt32(dr["ID"].ToString());
                    c.DepartmentName = dr["Name"].ToString();
                    list.Add(c);
                }
                dr.Close();
                con.Close();
                return list;
            }
        }

        [WebMethod]
        public DataSet QueryCourse()//科目
        {
            DBHelp DB = new DBHelp();
            return DB.GetDataSets("Proc_CourseList");
        }

        [WebMethod]
        public List<Users> SelectUser(int courseID)
        {
            using (SqlConnection con = DBHelp.GetConnection())
            {
                string sql = "select Users.UserID, UserName, RoleId from Course_User, Users where Course_User.UserID = Users.UserID and CourseID = " + courseID.ToString();
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                List<Users> list = new List<Users>();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Users u = new Users();
                    u.UserID = dr["UserID"].ToString();
                    u.UserName = dr["UserName"].ToString();
                    u.RoleId = Convert.ToInt32(dr["RoleId"].ToString());
                    list.Add(u);
                }
                dr.Close();
                con.Close();
                return list;
            }
        }

        [WebMethod]
        public List<Users> SelectOtherUser(int courseID)
        {
            using (SqlConnection con = DBHelp.GetConnection())
            {
                string sql = "select UserID, UserName, RoleId from Users where RoleId=3 and UserID not in (select UserID from Course_User where CourseID = " + courseID.ToString() + ")";
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                List<Users> list = new List<Users>();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Users u = new Users();
                    u.UserID = dr["UserID"].ToString();
                    u.UserName = dr["UserName"].ToString();
                    u.RoleId = Convert.ToInt32(dr["RoleId"].ToString());
                    list.Add(u);
                }
                dr.Close();
                con.Close();
                return list;
            }
        }

        [WebMethod]
        public bool AddUser(string courseID, string userID)
        {
            string sql = "insert into Course_User (CourseID, UserID) values(@CourseID, @UserID)";
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@CourseID", courseID),
                new SqlParameter("@UserID", userID)
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
        public bool DelUser(string courseID, string userID)
        {
            string sql = "delete from Course_User where CourseID=@CourseID and UserID=@UserID";
            SqlParameter[] sp = new SqlParameter[] 
                {
                    new SqlParameter("@CourseID", courseID),
                    new SqlParameter("@UserID", userID)
                };

            if (DBHelp.ExecuteCommand(sql, sp) > 0)
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
