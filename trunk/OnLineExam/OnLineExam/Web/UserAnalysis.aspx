<%@ Page Language="C#"  MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="UserAnalysis.aspx.cs" Inherits="Web_Userscore1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="updatePanel" runat="server">
        <ContentTemplate>
            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td valign="top" align="left" width="750px">
                        <h4 style="font-family: 楷体_GB2312">
                            &nbsp;</h4>
                        <hr />
                        请选择学生姓名：<asp:DropDownList ID="DropDownList1" runat="server"
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
                                <asp:BoundField HeaderText="用户编号" DataField="用户编号"   />
                                <asp:BoundField HeaderText="用户姓名" DataField="用户姓名" />
                                <asp:BoundField HeaderText="试卷" DataField="试卷" />
                                <asp:BoundField HeaderText="成绩" DataField="成绩" />
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
        </ContentTemplate>
    </asp:UpdatePanel>
    </asp:Content>
