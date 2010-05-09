<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master"  CodeFile="PaperAnalysis.aspx.cs" Inherits="Web_PaperAnalysis" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" height="100%" width="100%">
        <tr>
            <td valign="top" align="left" width="750px">
                        <h4 style="font-family: 楷体_GB2312">
                            &nbsp;</h4>
                        <hr />
                        请选择试卷名称：<asp:DropDownList ID="DropDownList1" runat="server"
                            DataTextField="PaperID" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"
                            AutoPostBack="True">
                        </asp:DropDownList>
                        
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;平均分：<asp:Label ID="Label1" runat="server"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:GridView ID="GridView1" runat="server" AllowPaging="True" PageSize="12" AutoGenerateColumns="False"
                          CellPadding="4" Font-Size="13px" Width="100%" 
                            ForeColor="#333333" GridLines="None" 
                            OnRowDataBound="GridView1_RowDataBound">
                            <RowStyle ForeColor="#333333" BackColor="#F7F6F3" />                      
                            <Columns>
                                <asp:BoundField HeaderText="试卷编号" DataField="试卷编号"   />
                                <asp:BoundField HeaderText="课程名称" DataField="课程名称" />
                                <asp:BoundField HeaderText="试卷名称" DataField="试卷名称" />
                                 <asp:BoundField HeaderText="学生姓名" DataField="学生姓名" />
                                <asp:BoundField HeaderText="学生成绩" DataField="学生成绩" />
                                <asp:BoundField HeaderText="考试时间" DataField="考试时间" />
                                <asp:BoundField HeaderText="评卷时间" DataField="评卷时间" />
                            </Columns>          
                            <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" />
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <EditRowStyle BackColor="#999999" />
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        </asp:GridView>
                        <br />
                    </td>
        </tr>
    </table>
</asp:Content>
