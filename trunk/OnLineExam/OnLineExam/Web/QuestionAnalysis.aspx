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
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;平均分：&nbsp;&nbsp;&nbsp;<asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Label ID="Label2" runat="server" ForeColor="Red"></asp:Label>
                        </p>
                        <asp:GridView ID="GridView1" runat="server" Width="100%"
                            Font-Size="13px" CellPadding="4"
                            OnRowDataBound="GridView1_RowDataBound" PageSize="12" AllowPaging="True" AutoGenerateColumns="False"
                            ForeColor="Black" GridLines="Vertical" BackColor="White" 
                            BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px">
                            <RowStyle BackColor="#F7F7DE"></RowStyle>
                   <Columns>
                                <asp:BoundField HeaderText="题目序号" DataField="题目序号"   />
                                <asp:BoundField HeaderText="学生" DataField="学生" />
                                <asp:BoundField HeaderText="试卷" DataField="试卷" />
                                 <asp:BoundField HeaderText="类型" DataField="类型" />
                                 <asp:BoundField HeaderText="分值" DataField="分值" />
                                  <asp:BoundField HeaderText="答案" DataField="答案" />
                                   <asp:BoundField HeaderText="考试时间" DataField="考试时间" />
                                   <asp:BoundField HeaderText="学生得分" DataField="学生得分" />
                            </Columns>       
                            <FooterStyle BackColor="#CCCC99"></FooterStyle>
                            <PagerStyle HorizontalAlign="Right" BackColor="#90BBC5" ForeColor="Black"></PagerStyle>
                            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White"></SelectedRowStyle>
                            <HeaderStyle BackColor="#90BBC5" Font-Bold="True" ForeColor="White"></HeaderStyle>
                            <AlternatingRowStyle BackColor="White" />
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <br />
 </td>
        </tr>
    </table>
</asp:Content>
