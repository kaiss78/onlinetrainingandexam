using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using OnLineExamBLLWS.DALWS_Course;

namespace OnLineExamBLLWS
{
    /// <summary>
    /// BLLWS_Course 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class BLLWS_Course : System.Web.Services.WebService
    {
        DALWS_Course.DALWS_Course service = new DALWS_Course.DALWS_Course();

        [WebMethod]
        public void ModifyPwd(string Name, string ID)
        {
            service.Update(Name, ID);
        }

        [WebMethod]
        public bool courseInsert(Course ci, string userID)
        {
            return service.insertCourse(ci, userID);
        }

        [WebMethod]
        public DataSet QueryCourse()//科目
        {
            return service.QueryCourse();
        }

        [WebMethod]
        public bool GetDeleteCourse(Course id)
        {
            return service.DeleteCourse(id);
        }

        [WebMethod]
        public List<Course> GetSelect()
        {
            return service.SelectCourse().ToList();
        }

        [WebMethod]
        public List<Users> SelectUser(int courseID)
        {
            return service.SelectUser(courseID).ToList();
        }

        [WebMethod]
        public List<Users> SelectOtherUser(int courseID)
        {
            return service.SelectOtherUser(courseID).ToList();
        }

        [WebMethod]
        public bool AddUser(string courseID, string userID)
        {
            return service.AddUser(courseID, userID);
        }

        [WebMethod]
        public bool DelUser(string courseID, string userID)
        {
            return service.DelUser(courseID, userID);
        }
    }
}
