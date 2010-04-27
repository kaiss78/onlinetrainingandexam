using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using OnLineExamBLLWS.DALWS_User;

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
        DALWS_User.DALWS_User service = new DALWS_User.DALWS_User();

        [WebMethod]
        public List<Scores> selectAllScore(string PaperID)
        {
            return service.SelectAll(PaperID).ToList();
        }

        [WebMethod]
        public List<Scores> selectAlls()
        {
            return service.SelectAll(null).ToList();
        }

        [WebMethod]
        public string GetTime(int id)
        {
            return service.GetTime(id);
        }

        [WebMethod]
        public List<Users> seluserName(string userName)
        {
            return service.SelectUserName(userName).ToList();
        }

        [WebMethod]
        public List<Users> seluser(string userID)
        {
            return service.SelectUserID(userID).ToList();
        }

        [WebMethod]
        public List<Users> listuser()
        {
            return service.SelectUser().ToList();
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
            return service.selectUserPaperList().ToList();
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
