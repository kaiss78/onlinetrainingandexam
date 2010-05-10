<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="ExerciseSetup.aspx.cs" Inherits="Web_PaperSetup" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="0" cellspacing="0" border="1" bordercolor="#cccccc" style="border-collapse: collapse"
        width="100%" frame="below">
        <tr>
            <td style="text-align: right; width: 100%;" colspan="4">
                <div class="title" align="left">
                    <h4 style="font-family: 楷体_GB2312">
                        练习制定(随机出题) &nbsp; &nbsp; <a href="papersetup2.aspx">人工出题</a></h4>
                </div>
            </td>
        </tr>
        <tr>
            <td style="text-align: right;">
                练习科目：
            </td>
            <td>
                &nbsp;<div align="left">
                    <asp:DropDownList ID="ddlCourse" runat="server" Font-Size="9pt" Width="88px">
                    </asp:DropDownList>
                </div>
            </td>
            <td style="text-align: right;">
                练习名称：
            </td>
            <td>
                &nbsp;<div align="left">
                    <asp:TextBox ID="txtExerciseName" runat="server" Width="120px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtExerciseName"
                        ErrorMessage="不能为空！"></asp:RequiredFieldValidator></div>
            </td>
        </tr>
        <tr>
            <td style="text-align: right; width: 100%;" colspan="4">
                <div class="title" align="left">
                    <h4 style="font-family: 楷体_GB2312">
                        单选题：</h4>
                </div>
            </td>
        </tr>
        <tr>
            <td style="text-align: right;">
                题目数目：
            </td>
            <td>
                &nbsp;<div align="left">
                    <asp:TextBox ID="txtSingleNum" runat="server" Width="120px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="不能为空"
                        ControlToValidate="txtSingleNum" Display="Dynamic"></asp:RequiredFieldValidator></div>
            </td>
            <td style="text-align: right;">
                每题分值：
            </td>
            <td>
                &nbsp;<div align="left">
                    <asp:TextBox ID="txtSingleFen" runat="server" Width="120px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="不能为空"
                        ControlToValidate="txtSingleFen" Display="Dynamic"></asp:RequiredFieldValidator></div>
            </td>
        </tr>
        <tr>
            <td style="text-align: right; width: 100%;" colspan="4">
                <div class="title" align="left">
                    <h4 style="font-family: 楷体_GB2312">
                        多选题：</h4>
                </div>
            </td>
        </tr>
        <tr>
            <td style="text-align: right;">
                题目数目：
            </td>
            <td>
                &nbsp;<div align="left">
                    <asp:TextBox ID="txtMultiNum" runat="server" Width="120px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="不能为空"
                        ControlToValidate="txtMultiNum"></asp:RequiredFieldValidator></div>
            </td>
            <td style="text-align: right;">
                每题分值：
            </td>
            <td>
                &nbsp;<div align="left">
                    <asp:TextBox ID="txtMultiFen" runat="server" Width="120px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="不能为空"
                        ControlToValidate="txtMultiFen"></asp:RequiredFieldValidator></div>
            </td>
        </tr>
        <tr>
            <td style="text-align: right; width: 100%;" colspan="4">
                <div class="title" align="left">
                    <h4 style="font-family: 楷体_GB2312">
                        判断题：</h4>
                </div>
            </td>
        </tr>
        <tr>
            <td style="text-align: right;">
                题目数目：
            </td>
            <td>
                &nbsp;<div align="left">
                    <asp:TextBox ID="txtJudgeNum" runat="server" Width="120px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="不能为空"
                        ControlToValidate="txtJudgeNum"></asp:RequiredFieldValidator></div>
            </td>
            <td style="text-align: right;">
                每题分值：
            </td>
            <td>
                &nbsp;<div align="left">
                    <asp:TextBox ID="txtJudgeFen" runat="server" Width="120px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="不能为空"
                        ControlToValidate="txtJudgeFen"></asp:RequiredFieldValidator></div>
            </td>
        </tr>
        <tr>
            <td style="text-align: right; width: 100%;" colspan="4">
                <div class="title" align="left">
                    <h4 style="font-family: 楷体_GB2312">
                        填空题：</h4>
                </div>
            </td>
        </tr>
        <tr>
            <td style="text-align: right;">
                题目数目：
            </td>
            <td>
                &nbsp;<div align="left">
                    <asp:TextBox ID="txtFillNum" runat="server" Width="120px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="不能为空"
                        ControlToValidate="txtFillNum"></asp:RequiredFieldValidator></div>
            </td>
            <td style="text-align: right;">
                每题分值：
            </td>
            <td>
                &nbsp;<div align="left">
                    <asp:TextBox ID="txtFillFen" runat="server" Width="120px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="不能为空"
                        ControlToValidate="txtFillFen"></asp:RequiredFieldValidator></div>
            </td>
        </tr>
        <tr>
            <td style="text-align: right; width: 100%;" colspan="4">
                <div class="title" align="left">
                    <h4 style="font-family: 楷体_GB2312">
                        问答题：</h4>
                </div>
            </td>
        </tr>
        <tr>
            <td style="text-align: right;">
                题目数目：
            </td>
            <td>
                &nbsp;<div align="left">
                    <asp:TextBox ID="txtQuestionNum" runat="server" Width="120px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="不能为空"
                        ControlToValidate="txtQuestionNum"></asp:RequiredFieldValidator></div>
            </td>
            <td style="text-align: right;">
                每题分值：
            </td>
            <td>
                &nbsp;<div align="left">
                    <asp:TextBox ID="txtQuestionFen" runat="server" Width="120px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="不能为空"
                        ControlToValidate="txtQuestionFen"></asp:RequiredFieldValidator></div>
            </td>
        </tr>
        <tr height="40">
            <td colspan="4" align="center">
                <asp:ImageButton ID="imgBtnConfirm" runat="server" ImageUrl="~/Images/Confirm.GIF"
                    OnClick="imgBtnConfirm_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:Panel ID="Panel1" runat="server" Width="100%" Visible="False">
                    <table cellspacing="0" style="font-size: 12px; font-family: Tahoma; border-collapse: collapse;"
                        cellpadding="0" width="100%" bgcolor="#ffffff" border="1" bordercolor="gray">
                        <tr>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <asp:GridView ID="GridView1" runat="server" Width="100%" AutoGenerateColumns="False"
                                            BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"
                                            CellPadding="3">
                                            <Columns>
                                                <asp:TemplateField HeaderText="一、单选题">
                                                    <ItemTemplate>
                                                        <table id="Table2" cellspacing="1" cellpadding="1" width="100%" align="center" border="0">
                                                            <br />
                                                            <tr>
                                                                <td colspan="3">
                                                                    <asp:Label ID="Label1" runat="server" Text='<%# Container.DataItemIndex+1 %>'>
                                                                    </asp:Label>
                                                                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("Title","、{0}") %>'>
                                                                    </asp:Label>
                                                                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("ID") %>' Visible="False">
                                                                    </asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td width="35%">
                                                                    <asp:RadioButton ID="RadioButton1" runat="server" Text='<%# Eval("AnswerA") %>' GroupName="Sl">
                                                                    </asp:RadioButton>
                                                                </td>
                                                                <td width="35%">
                                                                    <asp:RadioButton ID="RadioButton2" runat="server" Text='<%# Eval("AnswerB") %>' GroupName="Sl">
                                                                    </asp:RadioButton>
                                                                </td>
                                                                <td>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td width="35%">
                                                                    <asp:RadioButton ID="RadioButton3" runat="server" Text='<%# Eval("AnswerC") %>' GroupName="Sl">
                                                                    </asp:RadioButton>
                                                                </td>
                                                                <td width="35%">
                                                                    <asp:RadioButton ID="RadioButton4" runat="server" Text='<%# Eval("AnswerD") %>' GroupName="Sl">
                                                                    </asp:RadioButton>
                                                                </td>
                                                                <td>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <HeaderStyle Font-Size="12pt" HorizontalAlign="Left" />
                                        </asp:GridView>
                                        </td> </tr>
                                        <tr>
                                            <td>
                                                <asp:GridView ID="GridView2" runat="server" Width="100%" AutoGenerateColumns="False"
                                                    BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"
                                                    CellPadding="3">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="二、多选题">
                                                            <ItemTemplate>
                                                                <table id="Table3" cellspacing="1" cellpadding="1" width="100%" align="center" border="0">
                                                                    <br />
                                                                    <tr>
                                                                        <td colspan="3">
                                                                            <asp:Label ID="Label9" runat="server" Text='<%# Container.DataItemIndex+1 %>'>
                                                                            </asp:Label>
                                                                            <asp:Label ID="Label10" runat="server" Text='<%# Eval("Title","、{0}") %>'>
                                                                            </asp:Label>
                                                                            <asp:Label ID="Label6" runat="server" Text='<%# Eval("ID") %>' Visible="False">
                                                                            </asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="height: 22px" width="35%">
                                                                            <asp:CheckBox ID="CheckBox1" runat="server" Text='<%# Eval("AnswerA") %>'></asp:CheckBox>
                                                                        </td>
                                                                        <td style="height: 22px" width="35%">
                                                                            <asp:CheckBox ID="CheckBox2" runat="server" Text='<%# Eval("AnswerB") %>'></asp:CheckBox>
                                                                        </td>
                                                                        <td style="height: 22px">
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td width="35%">
                                                                            <asp:CheckBox ID="CheckBox3" runat="server" Text='<%# Eval("AnswerC") %>'></asp:CheckBox>
                                                                        </td>
                                                                        <td width="350%">
                                                                            <asp:CheckBox ID="CheckBox4" runat="server" Text='<%# Eval("AnswerD") %>'></asp:CheckBox>
                                                                        </td>
                                                                        <td>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <HeaderStyle Font-Size="12pt" HorizontalAlign="Left" />
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:GridView ID="GridView3" runat="server" Width="100%" AutoGenerateColumns="False"
                                                    BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"
                                                    CellPadding="3">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="三、判断题">
                                                            <ItemTemplate>
                                                                <table id="Table4" cellspacing="1" cellpadding="1" width="100%" align="center" border="0">
                                                                    <br />
                                                                    <tr>
                                                                        <td width="85%">
                                                                            <asp:Label ID="Label19" runat="server" Text='<%# Container.DataItemIndex+1 %>'>
                                                                            </asp:Label>
                                                                            <asp:Label ID="Label20" runat="server" Text='<%# Eval("Title","、{0}") %>'>
                                                                            </asp:Label>
                                                                            <asp:Label ID="Label7" runat="server" Text='<%# Eval("ID") %>' Visible="False">
                                                                            </asp:Label>
                                                                        </td>
                                                                        <td width="15%">
                                                                            <asp:CheckBox ID="CheckBox5" runat="server" Text="正确"></asp:CheckBox>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <HeaderStyle Font-Size="12pt" HorizontalAlign="Left" />
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:GridView ID="GridView4" runat="server" Width="100%" AutoGenerateColumns="False">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="四、填空题">
                                                            <ItemTemplate>
                                                                <table id="Table5" cellspacing="1" cellpadding="1" width="100%" align="center" border="0">
                                                                    <br />
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Label ID="Label16" runat="server" Text='<%# Container.DataItemIndex+1 %>'>
                                                                            </asp:Label>
                                                                            <asp:Label ID="Label17" runat="server" Text='<%# Eval("FrontTitle","、{0}") %>'>
                                                                            </asp:Label>
                                                                            <asp:TextBox ID="TextBox1" runat="server" Width="100px" Style="border-bottom: gray   1px   solid"
                                                                                BorderStyle="None"></asp:TextBox>
                                                                            <asp:Label ID="Label18" runat="server" Text='<%# Eval("BackTitle") %>'>
                                                                            </asp:Label>
                                                                            <asp:Label ID="Label8" runat="server" Text='<%# Eval("ID") %>' Visible="False">
                                                                            </asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <HeaderStyle Font-Size="12pt" HorizontalAlign="Left" />
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:GridView ID="GridView5" runat="server" Width="100%" AutoGenerateColumns="False"
                                                    BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"
                                                    CellPadding="3">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="四、问答题">
                                                            <ItemTemplate>
                                                                <table id="Table6" cellspacing="1" cellpadding="1" width="100%" align="center" border="0">
                                                                    <br>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Label ID="Label21" runat="server" Text='<%# Container.DataItemIndex+1 %>'>
                                                                            </asp:Label>
                                                                            <asp:Label ID="Label22" runat="server" Text='<%# Eval("Title","、{0}") %>'>
                                                                            </asp:Label>
                                                                            <br />
                                                                            <asp:TextBox ID="txtAnswer" runat="server" Width="100%" TextMode="MultiLine"></asp:TextBox>
                                                                            <asp:Label ID="Label23" runat="server" Text='<%# Eval("ID") %>' Visible="False">
                                                                            </asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <HeaderStyle Font-Size="12pt" HorizontalAlign="Left" />
                                                </asp:GridView>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" style="height: 31px">
                                <asp:ImageButton ID="imgBtnSave" runat="server" ImageUrl="~/Images/Save.GIF" OnClick="imgBtnSave_Click" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
    </table>
</asp:Content>
