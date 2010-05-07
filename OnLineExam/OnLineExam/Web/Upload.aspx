<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Upload.aspx.cs" Inherits="Web_cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>上传</title>
</head>
<body>
    <form id="form1" runat="server" method="post" encType="multipart/form-data">
    <div>
    
                          <p>
                              <asp:FileUpload ID="FileUpload1" runat="server" Width="475px" />
                              <asp:Button ID="bt_upload" runat="server" Text="上传" OnClick="Upload_Click" />
                              <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
                          </p>
    </div>
    <asp:GridView ID="GridView1" runat="server">
    </asp:GridView>
    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" />
    </form>
</body>
</html>
