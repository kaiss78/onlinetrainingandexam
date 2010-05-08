<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="CourseAdd.aspx.cs" Inherits="_Default" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table cellpadding="0" cellspacing="0" border="1" style="border-collapse: collapse"
                width="100%" frame="below">
                <tr>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td bgcolor="#ffffff" style="text-align: right; height: 25px;">
                        科目名称：
                    </td>
                    <td style="height: 25px">
                        &nbsp;<div align="left">
                            <asp:TextBox ID="txtName" runat="server" MaxLength="20" Width="128px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName"
                                ErrorMessage="不能为空！"></asp:RequiredFieldValidator></div>
                    </td>
                </tr>
                <tr>
                    <td bgcolor="#ffffff" style="text-align: right; height: 25px;">
                        授课教师：
                    </td>
                    <td style="height: 25px">
                        &nbsp;<div align="left">
                            <asp:TextBox ID="txtTeacher" runat="server" MaxLength="20" Width="128px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtTeacher"
                                ErrorMessage="不能为空！"></asp:RequiredFieldValidator></div>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        &nbsp;
                        <asp:Label ID="lblMessage" runat="server" ForeColor="red"></asp:Label><br />
                        <asp:ImageButton ID="imgBtnSave" runat="server" ImageUrl="../Images/Save.GIF" OnClick="imgBtnSave_Click" />
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        <asp:ImageButton ID="imgBtnReturn" runat="server" CausesValidation="false" ImageUrl="../Images/Return.GIF"
                            OnClick="imgBtnReturn_Click" />
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
