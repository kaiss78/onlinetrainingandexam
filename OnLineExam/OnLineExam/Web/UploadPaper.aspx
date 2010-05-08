<%@ Page Language="C#"  MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="UploadPaper.aspx.cs" Inherits="UploadPaper" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="updatePanel" runat="server">
        <ContentTemplate>
            <table cellpadding="0" cellspacing="0" border="1" style="border-collapse: collapse"
                width="100%" frame="below">
                <tr>
                    <td style="text-align: right; width: 100%;" colspan="2">
                        <div class="title" align="left">
                            <h4 style="font-family: 楷体_GB2312">
                                </h4>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right;">
                        上传试卷：
                    </td>
                    <td style="width: 80%">
                        &nbsp;<div align="left">
                            <asp:Button ID="bt_upload" runat="server" Text="上传" OnClick="Upload_Click" />
                            <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
                        </div>
                    </td>
                </tr>
                
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
