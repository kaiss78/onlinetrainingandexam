<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StudentIndex.aspx.cs" Inherits="Web_StudentIndex" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>在线考试系统</title>

    <script src="../JS/Morning_JS.js" type="text/javascript"></script>

    <link href="../CSS/CSS.css" rel="stylesheet" type="text/css" />
</head>
<body style="margin: 0px" onload="showTime();">
    <form id="Form1" method="post" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td style="height: 4px;" colspan="3">
                <img src="../Images/logo.jpg" style="border: 0px; left: 0px; position: relative;
                    top: 0px;" title="" width="100%" />
            </td>
        </tr>
        <tr style="background: url(../Images/lineS.jpg) repeat-x;">
            <td style="height: 25px;" colspan="3">
                &nbsp;&nbsp;&nbsp;欢迎您：<asp:Label ID="labUser" runat="server" Text="Label" Width="70px"></asp:Label>&nbsp;&nbsp;姓名：<asp:Label
                    ID="lblName" runat="server" Text="Label" Width="70px"></asp:Label>

                <script type="text/javascript">                    getDate();</script>

                <span id="ShowTime"></span>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                <asp:LinkButton ID="exit" runat="server" CausesValidation="false" OnClick="exit_Click"
                    PostBackUrl="~/Web/Login.aspx">退出系统</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td align="left" colspan="3" valign="top">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <table cellpadding="0" cellspacing="0" border="1" bordercolor="#cccccc" style="border-collapse: collapse"
                            width="100%" frame="below">
                            <tr>
                                <td style="text-align: right; width: 100%;" colspan="2">
                                    <div class="title" align="left">
                                        <h4>
                                            考试：<asp:Label ID="lblMessage" runat="server" ForeColor="red"></asp:Label></h4>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                        ForeColor="Black" GridLines="Vertical" OnRowDataBound="GridView1_RowDataBound"
                                        Width="100%" RowStyle-HorizontalAlign="Center" 
                                        onselectedindexchanging="GridView2_SelectedIndexChanging" 
                                        BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px">
                                        <RowStyle BackColor="#F7F7DE" />
                                        <Columns>
                                            <asp:BoundField DataField="ExamId" HeaderText="编号" Visible="False" />
                                            <asp:BoundField DataField="CourseName" HeaderText="科目" />
                                            <asp:BoundField DataField="PaperName" HeaderText="试卷" />
                                            <asp:BoundField DataField="StartTime" HeaderText="开始时间" />
                                            <asp:BoundField DataField="EndTime" HeaderText="结束时间" />
                                            <asp:CommandField HeaderText="开始考试" SelectText="开始考试" ShowSelectButton="True" />
                                        </Columns>
                                        <FooterStyle BackColor="#CCCC99" />
                                        <PagerStyle BackColor="#90BBC5" ForeColor="Black" HorizontalAlign="Right" />
                                        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="#90BBC5" Font-Bold="True" ForeColor="White" />
                                        <AlternatingRowStyle BackColor="White" />
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right; width: 100%; height: 25px;" colspan="2">
                                    <div class="title" align="left">
                                        <h4>
                                            考试记录：<asp:Label ID="lblScore" runat="server" Text="" Width="126px"></asp:Label>
                                        </h4>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right;" colspan="2">
                                    <div align="left">
                                        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" OnRowDataBound="GridView1_RowDataBound"
                                            OnPageIndexChanging="GridView1_PageIndexChanging" PageSize="8" AutoGenerateColumns="False"
                                            DataKeyNames="ID" CellPadding="4" Font-Size="13px" Width="100%" ForeColor="Black"
                                            GridLines="Vertical" RowStyle-HorizontalAlign="Center" BackColor="White" 
                                            BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px">
                                            <Columns>
                                                <asp:TemplateField HeaderText="成绩编号" Visible="False">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label1" runat="server"><%# Eval("ID") %></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="姓名">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label2" runat="server"><%# Eval("UserName") %></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Wrap="False" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="试卷">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label3" runat="server"><%# Eval("PaperName") %></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Wrap="False" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="成绩">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label4" runat="server"><%# Eval("Score") %></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Wrap="False" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="考试时间">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label5" runat="server"><%# Eval("ExamTime") %></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Wrap="False" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="阅卷时间">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label5" runat="server"><%# Eval("JudgeTime") %></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Wrap="False" />
                                                </asp:TemplateField>
                                            </Columns>
                                            <FooterStyle BackColor="#CCCC99" />
                                            <RowStyle BackColor="#F7F7DE" />
                                            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle BackColor="#90BBC5" ForeColor="Black" HorizontalAlign="Right" />
                                            <HeaderStyle BackColor="#90BBC5" Font-Bold="True" ForeColor="White" />
                                            <AlternatingRowStyle BackColor="White" />
                                        </asp:GridView>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right; width: 100%;" colspan="2">
                                    <div class="title" align="left">
                                        <h4>
                                            修改密码</h4>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right;">
                                    原密码：
                                </td>
                                <td>
                                    &nbsp;<div align="left">
                                        <asp:TextBox ID="txtOldPwd" runat="server" Width="124px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtOldPwd"
                                            ErrorMessage="不能为空！"></asp:RequiredFieldValidator></div>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right;">
                                    新密码：
                                </td>
                                <td>
                                    &nbsp;<div align="left">
                                        <asp:TextBox ID="txtNewPwd" runat="server" TextMode="Password" Width="124px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtNewPwd"
                                            ErrorMessage="不能为空！"></asp:RequiredFieldValidator></div>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right;">
                                    确认密码：
                                </td>
                                <td>
                                    &nbsp;<div align="left">
                                        <asp:TextBox ID="txtConfirmPwd" runat="server" MaxLength="20" TextMode="password"
                                            Width="124px"></asp:TextBox>
                                        <asp:CompareValidator ID="cpv_newpassword" runat="server" ErrorMessage="确认密码不一致"
                                            ControlToValidate="txtConfirmPwd" ControlToCompare="txtNewPwd"></asp:CompareValidator></div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                    &nbsp;
                                    <asp:Label ID="lblPwd" runat="server" ForeColor="red"></asp:Label><br />
                                    <asp:ImageButton ID="imgBtnModifyPwd" runat="server" ImageUrl="../Images/Update.GIF"
                                        OnClick="imgBtnModifyPwd_Click1" />
                                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                    <asp:ImageButton ID="imgBtnReset" runat="server" CausesValidation="false" ImageUrl="../Images/RESET.GIF"
                                        OnClick="imgBtnReset_Click" />
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
