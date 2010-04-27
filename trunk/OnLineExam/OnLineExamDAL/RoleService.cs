using System;
using System.Collections.Generic;
using System.Text;
using OnLineExamModel;
using System.Data.SqlClient;

namespace OnLineExamDAL
{
    public class RoleService
    {
        public static bool InsertRole(Role role)
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

        public static bool Delect(string RoleID)
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

    }
}
