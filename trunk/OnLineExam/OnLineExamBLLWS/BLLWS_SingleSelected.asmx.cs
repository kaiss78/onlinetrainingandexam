using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using OnLineExamBLLWS.DALWS_SingleSelected;

namespace OnLineExamBLLWS
{
    /// <summary>
    /// BLLWS_SingleSelected 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class BLLWS_SingleSelected : System.Web.Services.WebService
    {
        DALWS_SingleSelected.DALWS_SingleSelected service = new DALWS_SingleSelected.DALWS_SingleSelected();

        [WebMethod]
        public bool AddSingleSelected(SingleProblem sp)
        {
            return service.InsertQuestion(sp);
        }

        [WebMethod]
        public bool UpdateSingleSelected(SingleProblem spp)
        {
            return service.UpdateQuestion(spp);
        }

        [WebMethod]
        public List<SingleProblem> GetSingleProblemList(string selectvalue)
        {
            return service.GetSingleProblemList(selectvalue).ToList();
        }

        [WebMethod]
        public List<SingleProblem> GetSingQuestion(string UsersID, int PaperID)
        {
            return service.selectSingQuestion(UsersID, PaperID).ToList();
        }
    }
}
