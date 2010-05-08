using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using OnLineExamBLLWS.DALWS_Role;
using System.Data.SqlClient;

namespace OnLineExamBLLWS
{
    /// <summary>
    /// BLLWS_Role 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class BLLWS_Role : System.Web.Services.WebService
    {
        DALWS_Role.DALWS_Role service = new DALWS_Role.DALWS_Role();

        [WebMethod]
        public bool InsertRoles(Role role)
        {
            return service.InsertRole(role);
        }

        [WebMethod]
        public List<Role> SelectRoles()
        {
            return service.SelectRole().ToList();
        }

        [WebMethod]
        public string GetRoleName(String UserID)
        {
            return service.GetRoleName(UserID);
        }

        [WebMethod]
        public bool Delect(string RoleID)
        {
            return service.Delect(RoleID);
        }
    }
}
