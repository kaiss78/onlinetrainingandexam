<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="CourseEdit.aspx.cs" Inherits="Web_CourseManage1" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" height="100%" width="100%">
        <tr>
            <td style="width: 4px; background: url(../Images/line.gif) repeat-y;">
            </td>
            <td valign="top" align="left">
                <h4 style="font-family: 楷体_GB2312">
                    >><%# courseName %>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lblMessger" runat="server" ForeColor="Red"></asp:Label>
                </h4>
                <hr />
                <asp:Label ID="Label1" runat="server" Text="任课老师："></asp:Label>
                <asp:Label ID="lbTeacher" runat="server" Text=""></asp:Label><br />
                <asp:Label ID="Label2" runat="server" Text="已加入本课程的学生："></asp:Label>
                <asp:ListBox ID="lstbStudent" runat="server" SelectionMode="Multiple"></asp:ListBox>
                <asp:Button ID="BtnDel" runat="server" Text="移除" onclick="BtnDel_Click" /><br />
                <asp:Label ID="Label3" runat="server" Text="没有加入本课程学生："></asp:Label>
                <asp:ListBox ID="lstbStudent2" runat="server" SelectionMode="Multiple"></asp:ListBox>
                <asp:Button ID="BtnAdd" runat="server" Text="加入" onclick="BtnAdd_Click" />
                <br />
            </td>
        </tr>
    </table>
</asp:Content>
