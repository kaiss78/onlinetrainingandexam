<%@ Page Language="C#"  MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
 CodeFile="QuestionAnalysis.aspx.cs" Inherits="Web_QuestionAnalysis" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" height="100%" width="100%">
        <tr>
            <td valign="top" align="left" width="960px">
                <h4 style="font-family: 楷体_GB2312">
                    &nbsp;</h4>
                <hr />
                <asp:UpdatePanel ID="up" runat="server">
                    <ContentTemplate>
                        <p align="left">
                            <asp:DropDownList ID="DropDownList1" runat="server" Width="130px" OnSelectedIndexChanged="ddlCourse_SelectedIndexChanged"
                                AutoPostBack="True">
                                <asp:ListItem>单选题</asp:ListItem>
                                <asp:ListItem>多选题</asp:ListItem>
                                <asp:ListItem>判断题</asp:ListItem>
                                <asp:ListItem>填空题</asp:ListItem>
                                <asp:ListItem>问答题</asp:ListItem>
                            </asp:DropDownList>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Label ID="Label2" runat="server" ForeColor="Red"></asp:Label>
                        </p>
                        <asp:GridView ID="GridView1" runat="server" Width="100%"
                            Font-Size="13px" CellPadding="4"
                            OnRowDataBound="GridView1_RowDataBound" PageSize="12" AllowPaging="True" AutoGenerateColumns="False"
                            ForeColor="#333333" GridLines="None">
                            <RowStyle ForeColor="#333333" BackColor="#F7F6F3"></RowStyle>
                   <Columns>
                                <asp:BoundField HeaderText="题目序号" DataField="题目序号"   />
                                <asp:BoundField HeaderText="课程序号" DataField="课程序号" />
                                <asp:BoundField HeaderText="题目" DataField="题目" />
                            </Columns>       
                            <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True"></FooterStyle>
                            <PagerStyle HorizontalAlign="Center" BackColor="#284775" ForeColor="White"></PagerStyle>
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></HeaderStyle>
                            <EditRowStyle BackColor="#999999" />
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <br />
 </td>
        </tr>
    </table>
</asp:Content>
