using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using localhost;

public partial class Web_cs : System.Web.UI.Page
{
    BLLWS_UploadPaper up = new BLLWS_UploadPaper();
    protected void Upload_Click(object sender, EventArgs e)
    {
        try
        {
            if (FileUpload1.PostedFile.FileName == "")
            {
                this.lblMessage.Text = "请选择文件！";
            }
            else
            {
                string filepath = FileUpload1.PostedFile.FileName;
                lblMessage.Text += filepath;
                string filename = filepath.Substring(filepath.LastIndexOf("\\") + 1);
                lblMessage.Text += filename;
                string serverpath = Server.MapPath("files/") + filename;
                lblMessage.Text += serverpath;
                FileUpload1.PostedFile.SaveAs(serverpath);
                this.lblMessage.Text = "上传成功！";
                DataSet ds = up.importExcelToDataSet(serverpath);
                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
        }
        catch (Exception ex)
        {
            this.lblMessage.Text += "上传发生错误！原因是：" + ex.ToString();
        }
    }

   
}
