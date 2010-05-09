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
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:GridView 
                            ID="GridView1" runat="server" AllowPaging="True" PageSize="12" AutoGenerateColumns="False"
                          CellPadding="4" Font-Size="13px" Width="100%" 
                            ForeColor="Black" GridLines="Vertical" 
                            OnRowDataBound="GridView1_RowDataBound" BackColor="White" 
                            BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px">
                            <RowStyle BackColor="#F7F7DE" />                      
                            <Columns>
                                <asp:BoundField HeaderText="用户编号" DataField="用户编号"   />
                                <asp:BoundField HeaderText="用户姓名" DataField="用户姓名" />
                                <asp:BoundField HeaderText="试卷" DataField="试卷" />
                                <asp:BoundField HeaderText="成绩" DataField="成绩" />
                                <asp:BoundField HeaderText="考试时间" DataField="考试时间" />
                                <asp:BoundField HeaderText="评卷时间" DataField="评卷时间" />
                            </Columns>          
                            <FooterStyle BackColor="#CCCC99" />
                            <PagerStyle BackColor="#90BBC5" ForeColor="Black" HorizontalAlign="Right" />
                            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#90BBC5" Font-Bold="True" ForeColor="White" />
                            <AlternatingRowStyle BackColor="White" />
                        </asp:GridView>
                        <br />
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    </asp:Content>
