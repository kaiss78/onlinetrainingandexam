using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using OnLineExamBLLWS.DALWS_QuestionProblem;

namespace OnLineExamBLLWS
{
    /// <summary>
    /// BLLWS_QuestionProblem 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class BLLWS_QuestionProblem : System.Web.Services.WebService
    {
        DALWS_QuestionProblem.DALWS_QuestionProblem service = new DALWS_QuestionProblem.DALWS_QuestionProblem();

        [WebMethod]
        public bool QuestionProblemInsert(QuestionProblem qi)
        {
            return service.QuestionProblemInsert(qi);
        }

        [WebMethod]
        public bool QuestionProblemUpdate(QuestionProblem qu)
        {
            return service.QuestionProblemUpdate(qu);
        }
        
        [WebMethod]
        public List<QuestionProblem> GetQuestionProblem(string selectvalue)
        {
            return service.GetQuestionProblemList(selectvalue).ToList();
        }

        [WebMethod]
        public List<QuestionProblem> GetQuesQuestion(string UsersID, int PaperID)
        {

            return service.selectQuesQuestion(UsersID, PaperID).ToList();
        }
    }
}
