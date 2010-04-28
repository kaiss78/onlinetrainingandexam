using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using OnLineExamBLLWS.DALWS_FillBlankProblem;

namespace OnLineExamBLLWS
{
    /// <summary>
    /// BLLWS_FillBlankProblem 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class BLLWS_FillBlankProblem : System.Web.Services.WebService
    {
        DALWS_FillBlankProblem.DALWS_FillBlankProblem service = new DALWS_FillBlankProblem.DALWS_FillBlankProblem();

        [WebMethod]
        public bool FillBlankProblemUpdate(FillBlankProblem fu)
        {
            return service.FillBlankProbleUpdate(fu);
        }

        [WebMethod]
        public bool FillBlankProblemInsert(FillBlankProblem fi)
        {
            return service.FillBlankProbleInsert(fi);
        }

        [WebMethod]
        public bool FillBlankProblemDelete(FillBlankProblem fd)
        {
            return service.FillBlankProbleDelete(fd);
        }

        [WebMethod]
        public List<FillBlankProblem> GeFillBlankProblemList(string selectvalue)
        {
            return service.GeFillBlankProblemList(selectvalue).ToList();
        }

        [WebMethod]
        public List<FillBlankProblem> GetFillQuestion(string UsersID, int PaperID)
        {
            return service.FillQuestion(UsersID, PaperID).ToList();
        }
    }
}
