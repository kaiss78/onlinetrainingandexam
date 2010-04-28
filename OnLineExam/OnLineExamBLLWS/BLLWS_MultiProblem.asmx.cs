using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using OnLineExamBLLWS.DALWS_MultiProblem;

namespace OnLineExamBLLWS
{
    /// <summary>
    /// BLLWS_MultiProblem 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class BLLWS_MultiProblem : System.Web.Services.WebService
    {
        DALWS_MultiProblem.DALWS_MultiProblem service = new DALWS_MultiProblem.DALWS_MultiProblem();

        [WebMethod]
        public bool multiProblemInsert(MultiProblem mi)
        {
            return service.MultiProblemInsert(mi);
        }

        [WebMethod]
        public bool multiProblemUpdate(MultiProblem mu)
        {
            return service.MultiProblemUpdate(mu);
        }

        [WebMethod]
        public List<MultiProblem> GetMultiProblemList(string selectvalue)
        {
            return service.GetMultiProblemList(selectvalue).ToList();
        }

        [WebMethod]
        public List<MultiProblem> GetMutiQuestion(string UsersID, int PaperID)
        {
            return service.selectMutiQuestion(UsersID, PaperID).ToList();
        }
    }
}
