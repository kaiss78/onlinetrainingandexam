using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using OnLineExamBLLWS.DALWS_JudgeProblem;

namespace OnLineExamBLLWS
{
    /// <summary>
    /// BLLWS_JudgeProblem 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class BLLWS_JudgeProblem : System.Web.Services.WebService
    {
        DALWS_JudgeProblem.DALWS_JudgeProblem service = new DALWS_JudgeProblem.DALWS_JudgeProblem();

        [WebMethod]
        public bool judgeProblemUpdate(JudgeProblem jp)
        {
            return service.judgeProblemUpdate(jp);
        }

        [WebMethod]
        public bool judgeProblemInsert(JudgeProblem ji)
        {
            return service.judgeProblemInsert(ji);
        }

        [WebMethod]
        public List<JudgeProblem> GetJudgeProblemList(string selectvalue)
        {
            return service.GetJudgeProblemList(selectvalue).ToList();
        }

        [WebMethod]
        public List<JudgeProblem> GetJudgeQuestion(string UsersID, int PaperID)
        {
            return service.selectJudgeQuestion(UsersID, PaperID).ToList();
        }
    }
}
