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
        public bool insertCourse(Course ic)
        {
            string sql = "insert into Course ([Name]) values(@Name)";
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@Name",ic.DepartmentName)
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
        public bool DeleteCourse(Course id)
        {
            using (SqlConnection con = DBHelp.GetConnection())
            {
                string sql = "delete from Course where ID=@id";
                SqlParameter[] sp = new SqlParameter[] 
                {
                    new SqlParameter("@id",id.DepartmentId),
                };
                int i = DBHelp.ExecuteCommand(sql, sp);
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
    }
}
