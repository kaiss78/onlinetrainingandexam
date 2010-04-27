<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="UserManage.aspx.cs" Inherits="Web_UserManage" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="updatePanel" runat="server">
        <ContentTemplate>
            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                <tbody>
                    <tr>
                        <td style="height: 25px" valign="top" align="left" width="960">
                            <h4 style="font-family: 楷体_GB2312">
                                >>用户管理</h4>
                            <hr />
                            ※用户ID：
                            <asp:TextBox ID="tbxUserID" runat="server" Width="66px"></asp:TextBox>
                            ※姓名：
                            <asp:TextBox ID="tbxUserName" runat="server" Width="66px"></asp:TextBox>
                            <asp:ImageButton ID="ImageButtonQuery" OnClick="ImageButtonQuery_Click" runat="server"
                                ImageUrl="../Images/BtnQuery.gif"></asp:ImageButton>
                            <asp:ImageButton ID="ImageButton1" OnClick="ImageButtonBack_Click" runat="server"
                                ImageUrl="../Images/BtnBack.gif"></asp:ImageButton>
                            <br />
                            <asp:GridView ID="GridView1" runat="server" Width="100%" Font-Size="13px" CellPadding="4"
                                PageSize="8" AllowPaging="True" AutoGenerateColumns="False" ForeColor="#333333"
                                GridLines="None" OnRowDataBound="GridView1_RowDataBound">
                                <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkSelected" runat="server" Checked="False" Visible="True" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="用户ID">
                                        <ItemTemplate>
                                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("UserID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--<asp:TemplateField HeaderText="用户姓名"><ItemTemplate>                                
       <asp:TextBox runat="server" ID="UserName" Text = '<%# Eval("UserName") %>'></asp:TextBox>                     
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="角色名"><ItemTemplate>                                
          <asp:TextBox runat="server" ID="RoleName" Text = '<%# Eval("RoleName") %>'></asp:TextBox>
</ItemTemplate>
</asp:TemplateField>--%>
                                    <asp:BoundField DataField="UserName" SortExpression="UserName" HeaderText="姓名"></asp:BoundField>
                                    <asp:BoundField DataField="RoleName" SortExpression="RoleName" HeaderText="角色名">
                                    </asp:BoundField>
                                </Columns>
                                <RowStyle ForeColor="#333333" BackColor="#F7F6F3"></RowStyle>
                                <SelectedRowStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>
                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center"></PagerStyle>
                                <HeaderStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></HeaderStyle>
                                <EditRowStyle BackColor="#999999" />
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            </asp:GridView>
                            <asp:Label ID="LabelPageInfo" runat="server"></asp:Label>&nbsp;<br />
                            &nbsp;
                            <asp:RadioButton ID="RadioButton1" runat="server" Width="54px" Text="全选" OnCheckedChanged="RadioButton1_CheckedChanged"
                                AutoPostBack="true" GroupName="radio"></asp:RadioButton>
                            <asp:RadioButton ID="RadioButton2" runat="server" Width="54px" Text="反选" OnCheckedChanged="RadioButton2_CheckedChanged"
                                AutoPostBack="true" GroupName="radio"></asp:RadioButton>
                        </td>
                    </tr>
                </tbody>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:HyperLink ID="HyperLinkAdd" runat="server" ImageUrl="../Images/BtnAdd.gif" NavigateUrl="UserAdd.aspx">添加</asp:HyperLink>
    <asp:ImageButton ID="ImageButtonResetPassword" runat="server" ImageUrl="../Images/BtnResetPassword.gif"
        OnClick="ImageButtonResetPassword_Click"></asp:ImageButton>&nbsp;<asp:ImageButton
            ID="ImageButtonDelete" runat="server" ImageUrl="../Images/BtnDelete.gif" OnClick="ImageButtonDelete_Click">
        </asp:ImageButton>
</asp:Content>
