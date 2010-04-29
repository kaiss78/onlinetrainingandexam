using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using OnLineExamBLLWS.DALWS_StudentAnalysis;
using System.Collections.Generic;

namespace OnLineExamBLLWS
{
    /// <summary>
    /// DALWS_StudentAnalysis 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class BLLWS_StudentAnalysis : System.Web.Services.WebService
    {
        DALWS_StudentAnalysis.WebService1 service = new DALWS_StudentAnalysis.WebService1();

        [WebMethod]
        public Users[] SelectUserName()
        {
             Users[] user=service.SelectUserName();
             return user;
        }

        [WebMethod]
        public Scores[] SelectUserScores(string userID)
        {
            Scores[] score = service.SelectUserScores(userID);
            return score;
        }

        [WebMethod]
        public string GetPaperName(int id)
        {
            string papername = service.GetPaperType(id);
            return papername;
        }
    }
}
