using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using System.IO;
using System.Data;

namespace OnLineExamDALWS
{
    /// <summary>
    /// DALWS_SQLBackup 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class DALWS_DbBackup : System.Web.Services.WebService
    {

        [WebMethod]
        public bool Backup()
        {
            using (SqlConnection conn = DBHelp.GetConnection())
            {
                if (!Directory.Exists(@"C:\Backup"))
                {
                    Directory.CreateDirectory(@"C:\Backup");
                }

                string sql = @"BACKUP DATABASE OnLineExam TO  DISK = N'C:\Backup\OnLineExam.bak'";

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = sql;
                conn.Open();

                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    return false;
                }
                finally
                {
                    conn.Close();
                }

                return true;
            }
        }

        [WebMethod]
        public bool Restore()
        {
            string connStr = "Data Source=.\\SqlExpress;Initial Catalog=master;User ID=sa;Password=";
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                //获取所有用户进程 
                string strSQL = @"select spid from master..sysprocesses where dbid=db_id('OnLineExam')";
                SqlDataAdapter Da = new SqlDataAdapter(strSQL, conn);

                DataTable spidTable = new DataTable();
                Da.Fill(spidTable);

                SqlCommand Cmd = new SqlCommand();
                Cmd.CommandType = CommandType.Text;
                Cmd.Connection = conn;

                for (int iRow = 0; iRow <= spidTable.Rows.Count - 1; iRow++)
                {
                    Cmd.CommandText = "kill " + spidTable.Rows[iRow][0].ToString();//强行关闭用户进程 
                    try
                    {
                        Cmd.ExecuteNonQuery();
                    }
                    catch { }
                }
            }

            using (SqlConnection conn = DBHelp.GetConnection())
            {
                string sql = @"use master RESTORE DATABASE OnLineExam FROM  DISK = N'C:\Backup\OnLineExam.bak'";

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = sql;
                conn.Open();

                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    return false;
                }
                finally
                {
                    conn.Close();
                }

                return true;
            }
        }
    }
}
