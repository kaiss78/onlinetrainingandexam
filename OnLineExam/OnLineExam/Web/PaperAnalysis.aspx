<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master"  CodeFile="PaperAnalysis.aspx.cs" Inherits="Web_PaperAnalysis" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" height="100%" width="100%">
        <tr>
            <td valign="top" align="left" width="860">
                <h4 style="font-family: 楷体_GB2312">
                    &nbsp;</h4>
                <hr />
                <asp:Label runat="server" ID="lblMessage" Text=""></asp:Label>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging"
                            PageSize="12" OnRowDataBound="GridView1_RowDataBound" Width="100%" AutoGenerateColumns="False"
                            DataKeyNames="PaperID" CellPadding="4" Font-Size="13px"
                            OnRowDeleting="GridView1_RowDeleting"
                            ForeColor="Black" GridLines="Vertical" BackColor="White" 
                            BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px">
                            <Columns>
                                <asp:TemplateField HeaderText="编号" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server"><%# Eval("PaperID") %></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="考试科目">
                                    <ItemTemplate>
                                        <asp:Label ID="Label2" runat="server"><%# Eval("Name") %></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle Wrap="False" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="试卷名称">
                                    <ItemTemplate>
                                        <asp:Label ID="Label3" runat="server"><%# Eval("PaperName") %></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle Wrap="False" />
                                </asp:TemplateField>
                                <asp:HyperLinkField DataNavigateUrlFields="PaperID" DataNavigateUrlFormatString="PaperDetail.aspx?PaperID={0}"
                                    HeaderText="详细..." Text="详细...">
                                    <HeaderStyle Wrap="False" />
                                </asp:HyperLinkField>
                                <asp:CommandField ShowDeleteButton="True" HeaderText="删除">
                                    <HeaderStyle Wrap="False" />
                                </asp:CommandField>
                            </Columns>
                            <FooterStyle BackColor="#CCCC99" />
                            <RowStyle BackColor="#F7F7DE" />
                            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#90BBC5" ForeColor="Black" HorizontalAlign="Right" />
                            <HeaderStyle BackColor="#90BBC5" Font-Bold="True" ForeColor="White" />
                            <AlternatingRowStyle BackColor="White" />
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>
