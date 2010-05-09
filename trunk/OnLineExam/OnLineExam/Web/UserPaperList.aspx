<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="UserPaperList.aspx.cs" Inherits="Web_UserPaperList" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td valign="top" align="left" width="960px">
                        <h4 style="font-family: 楷体_GB2312">
                            &nbsp;</h4>
                        <hr />
                        <asp:GridView ID="GridView1" runat="server" Width="100%" AllowPaging="True" DataKeyNames="UserID,PaperID"
                            OnRowDataBound="GridView1_RowDataBound" PageSize="8" AutoGenerateColumns="False"
                            CellPadding="4" Font-Size="13px" OnRowDeleting="GridView1_RowDeleting" ForeColor="Black"
                            GridLines="Vertical" BackColor="White" BorderColor="#DEDFDE" 
                            BorderStyle="None" BorderWidth="1px">
                            <RowStyle BackColor="#F7F7DE"></RowStyle>
                            <Columns>
                                <asp:TemplateField HeaderText="序号">
                                    <EditItemTemplate>
                                        <asp:Label runat="server" ID="Label1"></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="Label1"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="PaperID" HeaderText="PaperID" ReadOnly="True" Visible="False">
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="用户姓名">
                                    <ItemTemplate>
                                        <asp:Label ID="Label2" runat="server"><%# Eval("UserName") %></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle Wrap="False"></HeaderStyle>
                                </asp:TemplateField>
                                <asp:HyperLinkField DataNavigateUrlFields="UserID,PaperID" DataNavigateUrlFormatString="UserPaper.aspx?UserID={0}&amp;PaperID={1}"
                                    DataTextField="PaperName" HeaderText="试卷评阅(点击查看)">
                                    <ItemStyle Font-Bold="True"></ItemStyle>
                                </asp:HyperLinkField>
                                <asp:TemplateField HeaderText="考试时间">
                                    <ItemTemplate>
                                        <asp:Label ID="Label5" runat="server"><%# Eval("ExamTime") %></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle Wrap="False"></HeaderStyle>
                                </asp:TemplateField>
                                <asp:CommandField DeleteText="&lt;div onclick=&quot;return confirm('确定要删除吗？')&quot;&gt;删除&lt;/div&gt;"
                                    ShowDeleteButton="True" HeaderText="删除"></asp:CommandField>
                            </Columns>
                            <FooterStyle BackColor="#CCCC99"></FooterStyle>
                            <PagerStyle HorizontalAlign="Right" BackColor="#90BBC5" ForeColor="Black"></PagerStyle>
                            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White"></SelectedRowStyle>
                            <HeaderStyle BackColor="#90BBC5" Font-Bold="True" ForeColor="White"></HeaderStyle>
                            <AlternatingRowStyle BackColor="White" />
                        </asp:GridView>
                        <asp:Label ID="LabelPageInfo" runat="server" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
