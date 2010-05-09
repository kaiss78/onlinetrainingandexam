using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using OnLineExamBLLWS.DALWS_PaperAnalysis;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace OnLineExamBLLWS
{
    /// <summardy>
    /// BLLWS_PaperAnalysis 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class BLLWS_PaperAnalysis : System.Web.Services.WebService
    {
        DALWS_PaperAnalysis.DALWS_PaperAnalysis service = new OnLineExamBLLWS.DALWS_PaperAnalysis.DALWS_PaperAnalysis();
        [WebMethod]
        public DataSet GetPaperName()
        {
            return service.select("select paperid,papername from paper");
        }

        [WebMethod]
        public string[] GetPaperDetail(string paperid)
        {
            string[] pa = new string[100];
            DataSet da = service.select("select courseid,papername from paper where paperid='" + paperid + "'");
            string courseid = da.Tables[0].Rows[0][0].ToString();
            string papername = da.Tables[0].Rows[0][1].ToString();
            DataSet da2 = service.select("select name from course where id='" + courseid + "'");
            string coursename = da2.Tables[0].Rows[0][0].ToString();
            DataSet da3 = service.select("select userid,score,examtime,judgetime from score where paperid='" + paperid + "'");
            int i = 0;
            int j = 0;
            while (j < da3.Tables[0].Rows.Count)
            {
                pa[i++] = paperid;
                pa[i++] = papername;
                pa[i++] = coursename;
                string userid = da3.Tables[0].Rows[j][0].ToString();
                DataSet da1 = service.select("select username from users where userid='" + userid + "'");
                if (da1.Tables[0].Rows.Count != 0)
                    pa[i++] = da1.Tables[0].Rows[0][0].ToString();
                else
                    pa[i++] = userid;
                pa[i++] = da3.Tables[0].Rows[j][1].ToString();
                pa[i++] = da3.Tables[0].Rows[j][2].ToString();
                pa[i++] = da3.Tables[0].Rows[j][3].ToString();
                j++;
            }
            return pa;

        }

    }
}
