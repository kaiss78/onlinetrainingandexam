﻿<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="ExamAdd.aspx.cs" Inherits="_Default" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table cellpadding="0" cellspacing="0" border="1" style="border-collapse: collapse"
                width="100%" frame="below">
                <tr>
                    <td bgcolor="#eeeeee" style="text-align: right; width: 100%;" colspan="2">
                        <div class="title" align="left">
                            <h4 style="font-family: 楷体_GB2312">
                                >>添加考试</h4>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td bgcolor="#eeeeee" style="text-align: right; height: 25px;">
                        科目：
                    </td>
                    <td style="height: 25px">
                        &nbsp;<div align="left">
                            <asp:DropDownList ID="ddlCourse" runat="server" OnSelectedIndexChanged="ddlCourse_SelectedIndexChanged" AutoPostBack="true">
                            </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td bgcolor="#eeeeee" style="text-align: right; height: 25px;">
                        试卷：
                    </td>
                    <td style="height: 25px">
                        &nbsp;<div align="left">
                            <asp:DropDownList ID="ddlPaper" runat="server">
                            </asp:DropDownList>
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
