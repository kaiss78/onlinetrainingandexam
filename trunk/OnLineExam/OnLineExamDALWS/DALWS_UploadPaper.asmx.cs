using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using System.Data.OleDb;
using OnLineExamModel;
using System.Data.Sql;
using System.Data.SqlClient;

namespace OnLineExamDALWS
{
    /// <summary>
    /// UploadPaper 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class UploadPaper : System.Web.Services.WebService
    {

        [WebMethod]
        public DataSet importExcelToDataSet(string FilePath)
        {
           
            string strConn;

            strConn = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + FilePath + ";Extended Properties=Excel 8.0;";

            OleDbConnection conn = new OleDbConnection(strConn);

            OleDbDataAdapter myCommand = new OleDbDataAdapter("SELECT * FROM [Sheet1$]", strConn);

            DataSet myDataSet = new DataSet();

            try
            {
                myCommand.Fill(myDataSet,"table");      
                conn.Close();

            }
            catch (Exception ex)
            {

                Console.Write("该Excel文件的工作表的名字不正确," + ex.Message);

            }

            return myDataSet;

        }

        [WebMethod]
        public void insert(string sql)
        {
            try
            {
                string[] str = new string[2];
                string sel = "Data Source=.\\SqlExpress;Initial Catalog=OnLineExam;User ID=sa;Password=";
                SqlConnection conn = new SqlConnection(sel);
                conn.Open();
                SqlCommand sqlc = new SqlCommand(sql, conn);
                sqlc.ExecuteNonQuery();
                sqlc.Dispose();
                conn.Close();
            }
            catch (Exception e)
            {
            }
        }
        [WebMethod]
        public DataSet select(string sql)
        {
            try
            {
                string sel = "Data Source=.\\SqlExpress;Initial Catalog=OnLineExam;User ID=sa;Password=";
                SqlConnection conn = new SqlConnection(sel);
                conn.Open();
                SqlCommand sqlc = new SqlCommand(sql, conn);
                SqlDataAdapter ada = new SqlDataAdapter(sqlc);
                DataSet data1 = new DataSet();
                ada.Fill(data1, "t1");
                conn.Close();
                return data1;
            }
            catch (Exception e)
            {
                return null;
            }
        }

    }
}
