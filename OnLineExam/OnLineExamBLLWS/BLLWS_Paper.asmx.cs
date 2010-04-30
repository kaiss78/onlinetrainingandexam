using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using OnLineExamBLLWS.DALWS_Paper;

namespace OnLineExamBLLWS
{
    /// <summary>
    /// BLLWS_Paper 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class BLLWS_Paper : System.Web.Services.WebService
    {
        DALWS_Paper.DALWS_Paper service = new DALWS_Paper.DALWS_Paper();

        [WebMethod]
        public DataSet QueryAllPaper()
        {
            return service.QueryAllPaper();
        }

        //修改试卷状态
        [WebMethod]
        public bool UpdatePate(int spp)
        {
            return service.UpdatePaperState(spp);
        }

        //修改试卷状态
        [WebMethod]
        public bool UpdatePate1(int spp)
        {
            return service.UpdatePaperState1(spp);
        }

        /// <summary>
        /// 根据PaperId删除试卷
        /// </summary>
        /// <param name="PaperId"></param>
        /// <returns></returns>
        [WebMethod]
        public bool DeletePaper(int PaperId)
        {
            return service.DeletePaper(PaperId);
        }

        /// <summary>
        /// 根据PaperId删除试卷的题
        /// </summary>
        /// <param name="PaperId"></param>
        /// <returns></returns>
        [WebMethod]
        public bool DeletePaperDetail(int PaperId)
        {
            return service.DeletePaperDetail(PaperId);
        }

        [WebMethod]
        public DataSet GetAllPaperSing(int PapperId, string sb)
        {
            return service.GetAllPaperSing(PapperId, sb);
        }

        [WebMethod]
        public DataSet GetAllPaperSingMark(int PapperId, string sb)
        {
            return service.GetAllPaperSingMark(PapperId, sb);
        }

        [WebMethod]
        public DataSet GetAllPaperMult(int PapperId, string sb)
        {
            return service.GetAllPaperMult(PapperId, sb);
        }

        [WebMethod]
        public DataSet GetAllPaperMultMark(int PapperId, string sb)
        {
            return service.GetAllPaperMultMark(PapperId, sb);
        }

        [WebMethod]
        public DataSet GetAllPaperJudg(int PapperId, string sb)
        {
            return service.GetAllPaperJudg(PapperId, sb);
        }

        [WebMethod]
        public DataSet GetAllPaperJudgMark(int PapperId, string sb)
        {
            return service.GetAllPaperJudgMark(PapperId, sb);
        }

        [WebMethod]
        public DataSet GetAllPaperFill(int PapperId, string sb)
        {
            return service.GetAllPaperFill(PapperId, sb);
        }

        [WebMethod]
        public DataSet GetAllPaperFillMark(int PapperId, string sb)
        {
            return service.GetAllPaperFillMark(PapperId, sb);
        }

        [WebMethod]
        public DataSet GetAllPaperQues(int PapperId, string sb)
        {
            return service.GetAllPaperQues(PapperId, sb);
        }

        [WebMethod]
        public DataSet GetAllPaperQuesMark(int PapperId, string sb)
        {
            return service.GetAllPaperQuesMark(PapperId, sb);
        }

        [WebMethod]
        public DataSet QueryPaper()
        {
            return service.QueryPaper();
        }

        [WebMethod]
        public string GetPaperType(int id)
        {
            return service.GetPaperType(id);
        }

        [WebMethod]
        public List<Paper> SelectPaper()
        {
            return service.SelectPaper().ToList();
        }
    }
}
