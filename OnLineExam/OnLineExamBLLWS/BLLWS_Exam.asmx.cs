using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using OnLineExamBLLWS.DALWS_Exam;

namespace OnLineExamBLLWS
{
    /// <summary>
    /// BLLWS_Exam 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class BLLWS_Exam : System.Web.Services.WebService
    {
        DALWS_Exam.DALWS_Exam service = new DALWS_Exam.DALWS_Exam();

        [WebMethod]
        public bool AddExam(Exam exam)
        {
            return service.AddExam(exam);
        }

        [WebMethod]
        public void DelExam(int examID)
        {
            service.DelExam(examID);
        }

        [WebMethod]
        public List<Exam> ListExam()
        {
            return service.ListExam().ToList();
        }

        [WebMethod]
        public List<Exam> ListUserExam(string userID)
        {
            return service.ListUserExam(userID).ToList();
        }

        [WebMethod]
        public DateTime GetServerTime()
        {
            return service.GetServerTime();
        }

        [WebMethod]
        public Exam GetExam(int examID)
        {
            return service.GetExam(examID);
        }
    }
}
