using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using OnLineExamBLLWS.DALWS_QuestionAnalysis;

namespace OnLineExamBLLWS
{
    /// <summary>
    /// BLWS_QuestionAnalysis 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class BLWS_QuestionAnalysis : System.Web.Services.WebService
    {
        DALWS_QuestionAnalysis.DALWS_QuestionAnalysis service = new DALWS_QuestionAnalysis.DALWS_QuestionAnalysis();
        DALWS_UploadPaper.UploadPaper up = new OnLineExamBLLWS.DALWS_UploadPaper.UploadPaper();

        [WebMethod]
        public DataSet select(string sql)
        {
            return up.select(sql);
        }


        [WebMethod]
        public void insert(string sql)
        {
           up.insert(sql);
        }


        [WebMethod]
        public DataSet getdetails(string type)
        {
           DataSet ds= up.select("select id,userid,paperid,mark,useranswer,examtime,usermark from useranswer where (type='" + type.Trim() + "')");
           return ds;
        }

        [WebMethod]
        public DataSet getusername(string userid)
        {
            DataSet ds = up.select("select username from users where (userid='"+userid +"')");
            return ds;
        }

        [WebMethod]
        public DataSet getpapername(string paperid)
        {
            DataSet ds = up.select("select papername from paper where (paperid='" + paperid + "')");
            return ds;
        }


        [WebMethod]
        public string[] GetList(string lb)
        {
            string[] fh = new string[100];
            int i = 0;
            int j = 0;
            if (lb.Equals("单选题"))
            {
                SingleProblem[] sp=service.GetSingleProblemList();
                while (j < sp.Length)
                {
                    fh[i] = sp[j].ID.ToString();
                    fh[++i] = sp[j].CourseID.ToString();
                    fh[++i] = sp[j].Title;
                    j++;
                    i++;
                }
            }
            else if (lb.Equals("多选题"))
            {
                MultiProblem[] sp = service.GetMultiProblemList();
                while (j < sp.Length)
                {
                    fh[i] = sp[j].ID.ToString();
                    fh[++i] = sp[j].CourseID.ToString();
                    fh[++i] = sp[j].Title;
                    j++;
                    i++;
                }
            }
            else if (lb.Equals("判断题"))
            {
                JudgeProblem[] sp = service.GetJudgeProblemList();
                while (j < sp.Length)
                {
                    fh[i] = sp[j].ID.ToString();
                    fh[++i] = sp[j].CourseID.ToString();
                    fh[++i] = sp[j].Title;
                    j++;
                    i++;
                }
            }
            else if (lb.Equals("填空题"))
            {
                FillBlankProblem[] sp = service.GeFillBlankProblemList();
                while (j < sp.Length)
                {
                    fh[i] = sp[j].ID.ToString();
                    fh[++i] = sp[j].CourseID.ToString();
                    fh[++i] = sp[j].FrontTitle;
                    j++;
                    i++;
                }
            }
            else if (lb.Equals("问答题"))
            {
                QuestionProblem[] sp = service.GetQuestionProblemList();
                while (j < sp.Length)
                {
                    fh[i] = sp[j].ID.ToString();
                    fh[++i] = sp[j].CourseID.ToString();
                    fh[++i] = sp[j].Title;
                    j++;
                    i++;
                }
            }
            return fh;
        }
    }
}
