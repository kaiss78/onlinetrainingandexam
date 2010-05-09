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
    /// DALWS_PaperAnalysis 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class DALWS_PaperAnalysis : System.Web.Services.WebService
    {

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
