﻿<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="UserAdd.aspx.cs" Inherits="Web_UserAdd" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="updatePanel" runat="server">
        <ContentTemplate>
            <table cellpadding="0" cellspacing="0" border="1" bordercolor="#cccccc" style="border-collapse: collapse"
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
                        帐号：
                    </td>
                    <td>
                        &nbsp;<div align="left">
                            <asp:TextBox ID="txtUserID" runat="server" MaxLength="20" BackColor="White" 
                                BorderColor="White" BorderStyle="None"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUserID"
                                ErrorMessage="不能为空！"></asp:RequiredFieldValidator>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right;">
                        姓名：
                    </td>
                    <td>
                        &nbsp;<div align="left">
                            <asp:TextBox ID="txtUserName" runat="server" MaxLength="20" Width="124px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtUserName"
                                ErrorMessage="不能为空！"></asp:RequiredFieldValidator></div>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right;">
                        密码：
                    </td>
                    <td>
                        &nbsp;<div align="left">
                            <asp:TextBox ID="txtUserPwd" runat="server" MaxLength="20" TextMode="password" Width="124px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtUserPwd"
                                ErrorMessage="不能为空！"></asp:RequiredFieldValidator></div>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right;">
                        确认密码：
                    </td>
                    <td>
                        &nbsp;<div align="left">
                            <asp:TextBox ID="txtPwdCfm" runat="server" MaxLength="20" TextMode="password" Width="124px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtPwdCfm"
                                ErrorMessage="不能为空！"></asp:RequiredFieldValidator></div>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="请再次确认密码！" ControlToCompare="txtUserPwd" ControlToValidate="txtPwdCfm"></asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right;">
                        电话号码：
                    </td>
                    <td>
                        &nbsp;<div align="left">
                            <asp:TextBox ID="txtPhone" runat="server" MaxLength="20" Width="124px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right;">
                        邮箱：
                    </td>
                    <td>
                        &nbsp;<div align="left">
                            <asp:TextBox ID="txtEmail" runat="server" MaxLength="20" Width="124px"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="请输入正确格式的邮箱地址" ControlToValidate="txtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right; height: 25px;">
                        角色：
                    </td>
                    <td style="height: 25px">
                        <div align="left">
                            <asp:DropDownList ID="ddlRole" runat="server" DataSourceID="SqlDataSource2" DataTextField="RoleName"
                                DataValueField="RoleId">
                            </asp:DropDownList>
                            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                                SelectCommand="SELECT * FROM [Role]"></asp:SqlDataSource>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right;">
                    </td>
                    <td>
                        &nbsp;<asp:Label ID="lblMessage" runat="server" ForeColor="red"></asp:Label><br />
                        <asp:ImageButton ID="imgBtnSave" runat="server" ImageUrl="../Images/Save.GIF" OnClick="imgBtnSave_Click" />
                        <asp:ImageButton ID="imgBtnReturn" runat="server" CausesValidation="false" ImageUrl="../Images/Return.GIF"
                            OnClick="imgBtnReturn_Click" PostBackUrl="~/Web/UserManage.aspx" />
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
            </table>
            <hr />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
