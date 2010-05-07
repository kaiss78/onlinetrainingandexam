using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using System.Data.OleDb;
using OnLineExamBLLWS.DALWS_UploadPaper;

namespace OnLineExamBLLWS
{
    /// <summary>
    /// BLLWS_UploadPaper 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class BLLWS_UploadPaper : System.Web.Services.WebService
    {
        DALWS_UploadPaper.UploadPaper service = new DALWS_UploadPaper.UploadPaper();

        [WebMethod]
        public DataSet importExcelToDataSet(string FilePath)
        {
            DataSet ds = service.importExcelToDataSet(FilePath);
            if (!updatepaper(ds)) return null;
           else 
            return ds;
        }

        [WebMethod]
        public void insert(string sql)
        {
             service.insert(sql);
        }

        [WebMethod]
        public DataSet select(string sql)
        {
            return service.select(sql);
        }

        [WebMethod]
        public bool updatepaper(DataSet ds)
        {
            try
            {
                string km = ds.Tables[0].Rows[0][0].ToString();
                string mc = ds.Tables[0].Rows[0][1].ToString();
                string danf = ds.Tables[0].Rows[0][2].ToString();
                string duof = ds.Tables[0].Rows[0][3].ToString();
                string panf = ds.Tables[0].Rows[0][4].ToString();
                string tianf = ds.Tables[0].Rows[0][5].ToString();
                string wenf = ds.Tables[0].Rows[0][6].ToString();
                DataSet da = select("select ID from Course where Name='" + km + "'");
                if (da != null)
                {
                    string id = da.Tables[0].Rows[0][0].ToString();
                    da.Dispose();
                    insert("insert into Paper(courseid,papername,paperstate) values('" + id + "','" + mc + "','true')");
                    DataSet da1 = select("select PaperID from Paper where papername='" + mc + "'");
                    string paperid = da1.Tables[0].Rows[0][0].ToString();
                    da1.Dispose();
                    int i = 7;
                   while (i < ds.Tables[0].Columns.Count)
                    {
                        if (ds.Tables[0].Columns[i].Caption.Contains("单选题"))
                        {
                            string question = ds.Tables[0].Rows[0][i].ToString().Trim();
                            string qa = ds.Tables[0].Rows[1][i].ToString().Trim();
                            string qb = ds.Tables[0].Rows[2][i].ToString().Trim();
                            string qc = ds.Tables[0].Rows[3][i].ToString().Trim();
                            string qd = ds.Tables[0].Rows[4][i].ToString().Trim();
                            string answer = ds.Tables[0].Rows[5][i].ToString().Trim();
                            insert("insert into singleproblem(courseid,title,answera,answerb,answerc,answerd,answer) values('" + id + "','" + question + "','" + qa + "','" + qb + "','" + qc + "','" + qd + "','" + answer + "')");
                            DataSet da2 = select("select ID from singleproblem where title='" + question + "'");
                            string titleid = da2.Tables[0].Rows[0][0].ToString();
                           da2.Dispose();
                           insert("insert into Paperdetail(paperid,type,titleid,mark) values('" + paperid + "','单选题','" + titleid + "','" + danf + "')");
                        }
                        else if (ds.Tables[0].Columns[i].Caption.Contains("多选题"))
                        {
                            string question = ds.Tables[0].Rows[0][i].ToString().Trim();
                            string qa = ds.Tables[0].Rows[1][i].ToString().Trim();
                            string qb = ds.Tables[0].Rows[2][i].ToString().Trim();
                            string qc = ds.Tables[0].Rows[3][i].ToString().Trim();
                            string qd = ds.Tables[0].Rows[4][i].ToString().Trim();
                            string answer = ds.Tables[0].Rows[5][i].ToString().Trim();
                            insert("insert into multiproblem(courseid,title,answera,answerb,answerc,answerd,answer) values('" + id + "','" + question + "','" + qa + "','" + qb + "','" + qc + "','" + qd + "','" + answer + "')");
                            DataSet da2 = select("select ID from multiproblem where title='" + question + "'");
                            string titleid = da2.Tables[0].Rows[0][0].ToString();
                            da2.Dispose();
                            insert("insert into Paperdetail(paperid,type,titleid,mark) values('" + paperid + "','多选题','" + titleid + "','" + duof + "')");
                        }
                        else if (ds.Tables[0].Columns[i].Caption.Contains("判断题"))
                        {
                            string question = ds.Tables[0].Rows[0][i].ToString().Trim();
                            string answer = ds.Tables[0].Rows[1][i].ToString().Trim();
                            if (answer.Equals("正确"))
                                answer = "true";
                            else answer = "false";
                            insert("insert into judgeproblem(courseid,title,answer) values('" + id + "','" + question  + "','" + answer + "')");
                            DataSet da2 = select("select ID from judgeproblem where title='" + question + "'");
                            string titleid = da2.Tables[0].Rows[0][0].ToString();
                            da2.Dispose();
                            insert("insert into Paperdetail(paperid,type,titleid,mark) values('" + paperid + "','判断题','" + titleid + "','" + panf + "')");
                        }
                        else if (ds.Tables[0].Columns[i].Caption.Contains("填空题"))
                        {
                            string question = ds.Tables[0].Rows[0][i].ToString().Trim();
                            string answer = ds.Tables[0].Rows[1][i].ToString().Trim();
                            insert("insert into fillblankproblem(courseid,fronttitle,backtitle,answer) values('" + id + "','" + question + "','?','" + answer + "')");
                            DataSet da2 = select("select ID from fillblankproblem where fronttitle='" + question + "'");
                            string titleid = da2.Tables[0].Rows[0][0].ToString();
                            da2.Dispose();
                            insert("insert into Paperdetail(paperid,type,titleid,mark) values('" + paperid + "','填空题','" + titleid + "','" + tianf + "')");
                        }
                        else if (ds.Tables[0].Columns[i].Caption.Contains("问答题"))
                        {
                            string question = ds.Tables[0].Rows[0][i].ToString().Trim();
                            string answer = ds.Tables[0].Rows[1][i].ToString().Trim();
                            insert("insert into questionproblem(courseid,title,answer) values('" + id + "','" + question + "','" + answer + "')");
                            DataSet da2 = select("select ID from questionproblem where title='" + question + "'");
                            string titleid = da2.Tables[0].Rows[0][0].ToString();
                            da2.Dispose();
                            insert("insert into Paperdetail(paperid,type,titleid,mark) values('" + paperid + "','问答题','" + titleid + "','" + wenf + "')");
                        }
                        i++;
                    }
                }
                return true;
            }
            catch (Exception e) { 
                Console.Write(e.Message);
            return false;
            }
        }


    }
}
