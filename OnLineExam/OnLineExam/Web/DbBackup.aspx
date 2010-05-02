<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="DbBackup.aspx.cs" Inherits="Web_PwdModify1" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="updatePanel" runat="server">
        <ContentTemplate>
            <table cellpadding="0" cellspacing="0" border="1" style="border-collapse: collapse"
                width="100%" frame="below">
                <tr>
                    <td bgcolor="#eeeeee" style="text-align: right; width: 100%;" colspan="2">
                        <div class="title" align="left">
                            <h4 style="font-family: 楷体_GB2312">
                                &gt;&gt;备份恢复</h4>
                        </div>
                        <hr />
                    </td>
                </tr>
                <tr>
                    <td bgcolor="#eeeeee" style="text-align: right;">
                        数据库备份：
                    </td>
                    <td style="width: 80%">
                        &nbsp;<div align="left">
                            <asp:Button ID="btnBackup" runat="server" Text="备份" OnClick="btnBackup_Click" />
                            <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td bgcolor="#eeeeee" style="text-align: right; height: 25px;">
                        数据库恢复：
                    </td>
                    <td style="width: 80%">
                        &nbsp;<div align="left">
                            <asp:Button ID="btnRestore" runat="server" Text="恢复" OnClick="btnRestore_Click" />
                            <asp:Label ID="lblMessage2" runat="server" ForeColor="Red"></asp:Label>
                        </div>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
