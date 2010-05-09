<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="UserScore.aspx.cs" Inherits="Web_UserScore" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="updatePanel" runat="server">
        <ContentTemplate>
            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td valign="top" align="left" width="750px">
                        <h4 style="font-family: 楷体_GB2312">
                            &nbsp;</h4>
                        <hr />
                        请选择试卷的编号：<asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1"
                            DataTextField="PaperID" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"
                            AutoPostBack="True">
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:OnLineExamConnectionString %>"
                            SelectCommand="SELECT DISTINCT [PaperID] FROM [Score]"></asp:SqlDataSource>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="Label12" runat="server" ForeColor="Red"></asp:Label>
                        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" PageSize="12" AutoGenerateColumns="False"
                            DataKeyNames="ID" CellPadding="4" Font-Size="13px" Width="100%" OnRowDeleting="GridView1_RowDeleting"
                            ForeColor="Black" GridLines="Vertical" 
                            OnRowDataBound="GridView1_RowDataBound" BackColor="White" BorderColor="#DEDFDE" 
                            BorderStyle="None" BorderWidth="1px">
                            <RowStyle BackColor="#F7F7DE" />
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkSelected" runat="server" Checked="False" Visible="True" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="用户编号">
                                    <ItemTemplate>
                                        <asp:Label ID="lblUserID" Text='<%# Eval("UserID") %>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="用户姓名">
                                    <ItemTemplate>
                                        <asp:Label ID="lblUserName" Text='<%# Eval("UserName") %>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="试卷编号">
                                    <ItemTemplate>
                                        <asp:Label ID="Label11" Text='<%# Eval("PaperID") %>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="成绩">
                                    <ItemTemplate>
                                        <asp:Label ID="Label4" Text='<%# Eval("Score") %>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle Wrap="False"></HeaderStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="考试时间">
                                    <ItemTemplate>
                                        <asp:Label ID="Label5" Text='<%# Eval("ExamTime") %>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle Wrap="False"></HeaderStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="评卷时间">
                                    <ItemTemplate>
                                        <asp:Label ID="Label6" Text='<%# Eval("JudgeTime") %>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle Wrap="False"></HeaderStyle>
                                </asp:TemplateField>
                                <asp:CommandField ShowDeleteButton="True" HeaderText="删除">
                                    <HeaderStyle Wrap="False"></HeaderStyle>
                                </asp:CommandField>
                            </Columns>
                            <FooterStyle BackColor="#CCCC99" />
                            <PagerStyle BackColor="#90BBC5" ForeColor="Black" HorizontalAlign="Right" />
                            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#90BBC5" Font-Bold="True" ForeColor="White" />
                            <AlternatingRowStyle BackColor="White" />
                        </asp:GridView>
                        <br />
                        <asp:RadioButton ID="RadioButton1" runat="server" AutoPostBack="true" GroupName="radio"
                            OnCheckedChanged="RadioButton1_CheckedChanged" Text="全选" Width="54px" /><asp:RadioButton
                                ID="RadioButton2" runat="server" AutoPostBack="true" GroupName="radio" OnCheckedChanged="RadioButton2_CheckedChanged"
                                Text="反选" Width="54px" />
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Images/Excel.GIF" OnClick="ImageButton2_Click" />
</asp:Content>
