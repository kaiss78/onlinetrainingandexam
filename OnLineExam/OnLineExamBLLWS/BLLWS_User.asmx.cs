using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using OnLineExamBLLWS.localhost;

namespace OnLineExamBLLWS
{
    /// <summary>
    /// Service1 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class BLLWS_User : System.Web.Services.WebService
    {
        static localhost.DALWS_User service = new localhost.DALWS_User();

        [WebMethod]
        public List<Scores> selectAllScore(string PaperID)
        {
            List<Scores> list = service.SelectAll(PaperID).ToList();
            return list;
        }

        [WebMethod]
        public List<Scores> selectAlls()
        {
            List<Scores> list = service.SelectAll(null).ToList();
            return list;
        }

        [WebMethod]
        public string GetTime(int id)
        {
            return service.GetTime(id);
        }

        [WebMethod]
        public List<Users> seluserName(string userName)
        {
            List<Users> list = service.SelectUserName(userName).ToList();
            return list;
        }

        [WebMethod]
        public List<Users> seluser(string userID)
        {
            List<Users> list = service.SelectUserID(userID).ToList();
            return list;
        }

        [WebMethod]
        public List<Users> listuser()
        {
            List<Users> list = service.SelectUser().ToList();
            return list;
        }

        [WebMethod]
        public bool AddUsers(Users user)
        {
            return service.insertUsers(user);
        }

        [WebMethod]
        public bool InsertScores(Scores scores, string PaperName, string userId, int paperId)
        {
            return service.InsertScore(scores, PaperName, userId, paperId);
        }

        [WebMethod]
        public bool Login(ref Users user)
        {
            user = service.LoginUser(user.UserID, user.UserPwd);

            if (user == null)
            {
                return false;
            }

            return true;
        }

        [WebMethod]
        public string GetUserName(string UserID)
        {
            return service.GetUserName(UserID);
        }

        [WebMethod]
        public void ModifyPwd(string UserPwd, string UserId)
        {
            service.Update(UserPwd, UserId);
        }

        [WebMethod]
        public List<UserAnswer> GetselectUserPaperList()
        {
            List<UserAnswer> list = service.selectUserPaperList().ToList();
            return list;
        }

        [WebMethod]
        public bool DeleteUserPaperList(string UsersID, int PapersID)
        {
            return service.DeleteUserPaperList(UsersID, PapersID);
        }

        [WebMethod]
        public List<UserAnswer> GetselectExaminfo(string name)
        {
            return service.selectExamInfo(name).ToList();
        }

        [WebMethod]
        public bool GetSelectPwd(string Pwd)
        {
            return service.SelectPwd(Pwd);
        }
    }
}
