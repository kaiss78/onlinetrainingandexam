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
    /// DALWS_Role 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class DALWS_Role : System.Web.Services.WebService
    {

        [WebMethod]
        public bool InsertRole(Role role)
        {
            using (SqlConnection conn = DBHelp.GetConnection())
            {
                string sql = @"insert into Role (RoleName) values (@RoleName)";

                SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@RoleName",role.RoleName)
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

        [WebMethod]
        public bool Delect(string RoleID)
        {
            using (SqlConnection conn = DBHelp.GetConnection())
            {
                string sql = @"delete from Role where RoleID = '" + RoleID + "'";

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = sql;

                conn.Open();

                cmd.ExecuteNonQuery();

                conn.Close();
            }

            return true;
        }

        [WebMethod]
        public List<Role> SelectRole()
        {
            using (SqlConnection conn = DBHelp.GetConnection())
            {
                string sql = @"select RoleID,RoleName from Role";

                SqlCommand cmd = conn.CreateCommand();

                cmd.CommandText = sql;
                conn.Open();

                SqlDataReader sdr = cmd.ExecuteReader();

                List<Role> list = new List<Role>();

                while (sdr.Read())
                {
                    Role role = new Role();
                    role.RoleId = Convert.ToInt32(sdr["RoleID"]);
                    role.RoleName = sdr["RoleName"].ToString();

                    list.Add(role);
                }

                sdr.Close();

                conn.Close();

                return list;

            }
        }

        [WebMethod]
        public string GetRoleName(String UserID)
        {
            using (SqlConnection conn = DBHelp.GetConnection())
            {
                string sql = @"select RoleName from dbo.Role where RoleId =(select RoleId from dbo.Users where UserID='{0}')";



                SqlCommand cmd = conn.CreateCommand();
                sql = string.Format(sql, UserID);
                cmd.CommandText = sql;
                conn.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    return dr["RoleName"].ToString();
                }



                dr.Close();
                conn.Close();

                return "";
            }
        }
    }
}
