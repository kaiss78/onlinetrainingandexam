<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="CourseEdit.aspx.cs" Inherits="Web_CourseManage1" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table border="1" cellpadding="0" cellspacing="0">
        <tr>
            <td style="background: url(../Images/line.gif) repeat-y;" align="center">
                <h4 style="font-family: 楷体_GB2312">
                    科目名称：
                </h4>
            </td>
            <td align="left">
                <h4 style="font-family: 楷体_GB2312">
                    <%# courseName %>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </h4>
            </td>
            <td></td>
        </tr>
        <tr>
            <td align="center">
                <asp:Label ID="Label1" runat="server" Text="任课老师："></asp:Label>
            </td>
            <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lbTeacher" runat="server" Text=""></asp:Label><br />
            </td>
            <td></td>
        </tr>
        <tr>
            <td align="center">
                <asp:Label ID="Label2" runat="server" Text="已加入本课程的学生："></asp:Label>
            </td>
            <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:ListBox ID="lstbStudent" runat="server" SelectionMode="Multiple"></asp:ListBox>
            </td>
            <td>
                <asp:Button ID="BtnDel" runat="server" Text="移除" OnClick="BtnDel_Click" /><br />
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Label ID="Label3" runat="server" Text="没有加入本课程学生："></asp:Label>
            </td>
            <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:ListBox ID="lstbStudent2" runat="server" SelectionMode="Multiple"></asp:ListBox>
            </td>
            <td>
                <asp:Button ID="BtnAdd" runat="server" Text="加入" OnClick="BtnAdd_Click" />
                <br />
            </td>
        </tr>
    </table>
</asp:Content>
