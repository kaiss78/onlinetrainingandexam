using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace OnLineExamBLLWS
{
    /// <summary>
    /// BLLWS_DbBackup 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class BLLWS_DbBackup : System.Web.Services.WebService
    {
        DALWS_DbBackup.DALWS_DbBackup service = new DALWS_DbBackup.DALWS_DbBackup();

        [WebMethod]
        public bool Backup()
        {
            return service.Backup();
        }

        [WebMethod]
        public bool Restore()
        {
            return service.Restore();
        }
    }
}
