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
                                &nbsp;</h4>
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
                                PageSize="8" AllowPaging="True" AutoGenerateColumns="False" ForeColor="Black"
                                GridLines="Vertical" OnRowDataBound="GridView1_RowDataBound" 
                                RowStyle-HorizontalAlign="Center" BackColor="White" BorderColor="#DEDFDE" 
                                BorderStyle="None" BorderWidth="1px">
                                <FooterStyle BackColor="#CCCC99"></FooterStyle>
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
                                    <asp:BoundField DataField="Phone" SortExpression="Phone" HeaderText="电话号码" />
                                    <asp:BoundField DataField="Email" SortExpression="Email" HeaderText="邮箱" />
                                </Columns>
                                <RowStyle ForeColor="#333333" BackColor="#F7F7DE"></RowStyle>
                                <SelectedRowStyle BackColor="#CE5D5A" ForeColor="White" Font-Bold="True"></SelectedRowStyle>
                                <PagerStyle BackColor="#90BBC5" ForeColor="Black" HorizontalAlign="Right"></PagerStyle>
                                <HeaderStyle BackColor="#90BBC5" ForeColor="White" Font-Bold="True"></HeaderStyle>
                                <AlternatingRowStyle BackColor="White" />
                            </asp:GridView>
                            <asp:Label ID="LabelPageInfo" runat="server"></asp:Label>&nbsp;<br />
                            &nbsp;
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
