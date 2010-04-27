using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using OnLineExamDAL;
using OnLineExamModel;

namespace OnLineExamBLL
{
    public class RoleManager
    {
        public static bool InsertRoles(Role role)
        {
            if (RoleService.InsertRole(role))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static List<Role> SelectRoles()
        {
            RoleService roleservice = new RoleService();

            List<Role> list = roleservice.SelectRole();

            return list;
        }

        public static string GetRoleName(String UserID)
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
