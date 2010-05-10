<%--   <script language="javascript">
   var i=0;
   window.onresize=function()
   {
   i++;
    if(i=3)
    {
        
    }
   }
   </script>--%>

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserExercise.aspx.cs" Inherits="Web_UserExercise" %>

<!DOCTYPE html PUBLIC "-//W3C//Dtd XHTML 1.0 transitional//EN" "http://www.w3.org/tr/xhtml1/Dtd/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>在线练习界面</title>
    <link href="../CSS/CSS.css" rel="stylesheet" type="text/css" />
</head>
<body onload="init();">


    <form id="form1" runat="server">
    <div>
        <table cellspacing="0" style="font-size: 12px; font-family: Tahoma; border-collapse: collapse;
            width: 100%; height: 100%;" cellpadding="0" align="center" border="1">
            <tr>
                <td style="height: 4px;" colspan="3">
                    <img src="../Images/logo.jpg" style="border: 0px; left: 0px; position: relative;
                        top: 0px;" title="" alt="" />
                </td>
            </tr>
            <tr style="background: url(../Images/lineS.jpg) repeat-x;">
                <td style="height: 25;" colspan="3">
                    &nbsp;&nbsp;&nbsp;欢迎您：<asp:Label ID="labUser" runat="server" Text="Label" Width="70px"></asp:Label>&nbsp;&nbsp;
                    <%--<input type="text" name="time_spent" id="timeBox" runat="server" onfocus="this.blur()" />--%>
                 
                </td>
            </tr>
            <tr>
                <td align="center">
                    <a id="top"></a><font color="#4D2600" size="5" style="font-family: 楷体_GB2312">
                        <asp:Label ID="Label7" runat="server" Text="练习题：" /><asp:Label ID="Label1" runat="server"
                            Text="<<" /><asp:Label ID="lblExerciseName" runat="server"></asp:Label><asp:Label ID="Label12"
                                runat="server" Text=">>" /></font>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:SqlDataSource ID="sqlQuestion" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                        SelectCommand="SELECT QuestionProblem.* FROM &#13;&#10;QuestionProblem,ExerciseDetail &#13;&#10;WHERE QuestionProblem.ID = ExerciseDetail.TitleID AND ExerciseDetail.ExerciseID = @ExerciseID AND ExerciseDetail.Type = '问答题'">
                        <SelectParameters>
                            <asp:QueryStringParameter Name="ExerciseID" QueryStringField="exerciseId" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <asp:SqlDataSource ID="sqlJudge" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                        SelectCommand="SELECT JudgeProblem.* FROM &#13;&#10;JudgeProblem ,ExerciseDetail &#13;&#10;WHERE JudgeProblem.ID = ExerciseDetail.TitleID AND ExerciseDetail.ExerciseID = @ExerciseID AND ExerciseDetail.Type = '填空题'">
                        <SelectParameters>
                            <asp:QueryStringParameter Name="ExerciseID" QueryStringField="exerciseId" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <asp:SqlDataSource ID="sqlFillBlank" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                        SelectCommand="SELECT FillBlankProblem.* FROM &#13;&#10;FillBlankProblem ,ExerciseDetail &#13;&#10;WHERE FillBlankProblem.ID = ExerciseDetail.TitleID AND ExerciseDetail.ExerciseID = @ExerciseID AND ExerciseDetail.Type = '填空题'">
                        <SelectParameters>
                            <asp:QueryStringParameter Name="ExerciseID" QueryStringField="exerciseId" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <asp:SqlDataSource ID="sqlMulti" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                        SelectCommand="SELECT MultiProblem.* FROM &#13;&#10;MultiProblem ,ExerciseDetail &#13;&#10;WHERE MultiProblem.ID =ExerciseDetail.TitleID AND ExerciseDetail.ExerciseID = @ExerciseID AND ExerciseDetail.Type = '多选题'">
                        <SelectParameters>
                            <asp:QueryStringParameter Name="ExerciseID" QueryStringField="exerciseId" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <asp:SqlDataSource ID="sqlSingle" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                        SelectCommand="SELECT SingleProblem.* FROM &#13;&#10;SingleProblem ,ExerciseDetail &#13;&#10;WHERE SingleProblem.ID = ExerciseDetail.TitleID AND ExerciseDetail.ExerciseID = @ExerciseID AND ExerciseDetail.Type = '单选题'">
                        <SelectParameters>
                            <asp:QueryStringParameter Name="ExerciseID" QueryStringField="exerciseId" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <asp:SqlDataSource ID="sqlSingleMark" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                        SelectCommand="SELECT Mark FROM ExerciseDetail WHERE ExerciseDetail.ExerciseID = @ExerciseId AND Type= '单选题'">
                        <SelectParameters>
                            <asp:QueryStringParameter Name="ExerciseId" QueryStringField="exerciseId" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <asp:SqlDataSource ID="SqlMultiMark" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                        SelectCommand="SELECT Mark FROM ExerciseDetail WHERE ExerciseDetail.ExerciseID = @ExerciseId AND Type= '多选题'">
                        <SelectParameters>
                            <asp:QueryStringParameter Name="ExerciseId" QueryStringField="exerciseId" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <asp:SqlDataSource ID="SqlFillMark" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                        SelectCommand="SELECT Mark FROM ExerciseDetail WHERE ExerciseDetail.ExerciseID = @ExerciseId AND Type='填空题'">
                        <SelectParameters>
                            <asp:QueryStringParameter Name="ExerciseId" QueryStringField="exerciseId" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <asp:SqlDataSource ID="SqlJudgeMark" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                        SelectCommand="SELECT Mark FROM ExerciseDetail WHERE ExerciseDetail.ExerciseID = @ExerciseId AND Type='判断题'">
                        <SelectParameters>
                            <asp:QueryStringParameter Name="ExerciseId" QueryStringField="exerciseId" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <asp:SqlDataSource ID="SqlQuestionMark" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                        SelectCommand="SELECT Mark FROM ExerciseDetail WHERE ExerciseDetail.ExerciseID = @ExerciseId AND Type= '问答题'">
                        <SelectParameters>
                            <asp:QueryStringParameter Name="ExerciseId" QueryStringField="exerciseId" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <br />
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
                    <a style="font-family: 楷体_GB2312; font-size: 15px; font-weight: bold;">一.单选题（每题<asp:Label
                        ID="labSingle" runat="server" Text="Label"></asp:Label>分） </a>
                    <br />
                    <asp:Repeater runat="server" ID="singleRep" DataSourceID="sqlSingle">
                        <ItemTemplate>
                            <a>&nbsp;
                                <%# singeCount++ %>
                                .<%# Eval("Title") %>
                                <asp:HiddenField runat="server" Value='<%# Eval("ID") %>' ID="titleId" />
                            </a>
                            <div>
                                &nbsp; &nbsp;&nbsp; &nbsp;A.<asp:RadioButton ID="rbA" GroupName="option" runat="server"
                                    Text='<%# Eval("AnswerA") %>' />
                                <br />
                                &nbsp; &nbsp;&nbsp; &nbsp;B.<asp:RadioButton ID="rbB" GroupName="option" runat="server"
                                    Text='<%# Eval("AnswerB") %>' />
                                <br />
                                &nbsp; &nbsp;&nbsp; &nbsp;C.<asp:RadioButton ID="rbC" GroupName="option" runat="server"
                                    Text='<%# Eval("AnswerC") %>' />
                                <br />
                                &nbsp; &nbsp;&nbsp; &nbsp;D.<asp:RadioButton ID="rbD" GroupName="option" runat="server"
                                    Text='<%# Eval("AnswerD") %>' />
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                    <a style="font-family: 楷体_GB2312; font-size: 15px; font-weight: bold;">
                        <br />
                        二.多选题（每题<asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>分） </a>
                    <br />
                    <asp:Repeater runat="server" ID="Repeater2" DataSourceID="sqlMulti">
                        <ItemTemplate>
                            <a>&nbsp;<%# singeCount++ %>
                                .<%# Eval("Title") %>
                                <asp:HiddenField runat="server" Value='<%# Eval("ID") %>' ID="titleId" />
                            </a>
                            <div>
                                &nbsp; &nbsp;&nbsp; &nbsp;A.<asp:CheckBox ID="CheckBox1" runat="server" Text='<%# Eval("AnswerA") %>'>
                                </asp:CheckBox>
                                <br />
                                &nbsp; &nbsp;&nbsp; &nbsp;B.<asp:CheckBox ID="CheckBox2" runat="server" Text='<%# Eval("AnswerB") %>'>
                                </asp:CheckBox>
                                <br />
                                &nbsp; &nbsp;&nbsp; &nbsp;C.<asp:CheckBox ID="CheckBox3" runat="server" Text='<%# Eval("AnswerC") %>'>
                                </asp:CheckBox>
                                <br />
                                &nbsp; &nbsp;&nbsp; &nbsp;D.<asp:CheckBox ID="CheckBox4" runat="server" Text='<%# Eval("AnswerD") %>'>
                                </asp:CheckBox>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                    <a style="font-family: 楷体_GB2312; font-size: 15px; font-weight: bold;">
                        <br />
                        三.判断题（每题<asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>分） </a>
                    <br />
                    <asp:Repeater runat="server" ID="Repeater3" DataSourceID="sqlJudge">
                        <ItemTemplate>
                            <a>&nbsp;<%# singeCount++ %>
                                .<%# Eval("Title") %>
                                <asp:HiddenField runat="server" Value='<%# Eval("ID") %>' ID="titleId" />
                            </a>
                            <div>
                                <%--<asp:Label ID="Label10" runat="server" Text='<%# Eval("Title","{0}") %>'>--%>
                                &nbsp; &nbsp;&nbsp; &nbsp;<asp:RadioButton ID="rbA" GroupName="option" runat="server"
                                    Text="正确" />
                                <br />
                                &nbsp; &nbsp;&nbsp; &nbsp;<asp:RadioButton ID="rbB" GroupName="option" runat="server"
                                    Text="错误" />
                                <%--<asp:CheckBox ID="CheckBox5" runat="server" Text="正确"></asp:CheckBox>--%>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                    <a style="font-family: 楷体_GB2312; font-size: 15px; font-weight: bold;">
                        <br />
                        四.填空题（每题<asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>分） </a>
                    <br />
                    <asp:Repeater runat="server" ID="Repeater1" DataSourceID="sqlFillBlank">
                        <ItemTemplate>
                            <a>&nbsp;<%# singeCount++ %>
                                .<%# Eval("FrontTitle") %>
                                <asp:HiddenField runat="server" Value='<%# Eval("ID") %>' ID="titleId" />
                            </a>
                            <div>
                                <asp:TextBox ID="TextBox1" runat="server" Width="1000px" Style="border-bottom: gray   1px   solid"
                                    BorderStyle="None"></asp:TextBox>
                                <asp:Label ID="Label15" runat="server" Text='<%# Eval("BackTitle") %>'>
                                </asp:Label>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                    <a style="font-family: 楷体_GB2312; font-size: 15px; font-weight: bold;">
                        <br />
                        五.问答题（每题<asp:Label ID="Label6" runat="server" Text="Label"></asp:Label>分） </a>
                    <br />
                    <asp:Repeater runat="server" ID="Repeater4" DataSourceID="sqlQuestion">
                        <ItemTemplate>
                            <a>&nbsp;<%# singeCount++ %>
                                .<%# Eval("Title") %>
                                <asp:HiddenField runat="server" Value='<%# Eval("ID") %>' ID="titleId" />
                            </a>
                            <div>
                                <asp:TextBox ID="TextBox2" runat="server" Width="1000px" TextMode="MultiLine"></asp:TextBox>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                    <br />
                    <br />
                    <br />
                    <div align="center">
                        <asp:ImageButton ID="ImageButton2" runat="server"
                            ImageUrl="~/Images/Answer.GIF" OnClick="imgBtnAnswer_Click" align="center" /></div>
    <table cellspacing="0" style="font-size: 12px; font-family: Tahoma; border-collapse: collapse;"
        cellpadding="0" width="100%" bgcolor="#ffffff" border="1" bordercolor="gray">
        <tr>
            <td>
                <asp:GridView ID="GridView1" runat="server" Width="100%" AutoGenerateColumns="False"
                    BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"
                    CellPadding="3" >
                    <Columns>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <asp:Label ID="Label24" runat="server" Text="一、单选题"></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <table id="Table2" cellspacing="1" cellpadding="1" width="100%" align="center" border="0">
                                    <br />
                                    <tr>
                                        <td >
                                        <asp:Label ID="Label16" runat="server" Text='<%# Container.DataItemIndex+1 %>'>
                                            </asp:Label>
                                            参考答案：
                                            <asp:Label ID="Label23" runat="server" Text='<%# Eval("SingleAnswer") %>'></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            (本题得分：<asp:TextBox ID="tbxqueScore1" runat="server" Width="50px"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="tbxqueScore1"
                                                ValidationExpression="^\d+$" ErrorMessage="只能为正整数或0" Display="dynamic"></asp:RegularExpressionValidator>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="不能为空"
                                                ControlToValidate="tbxqueScore1" Display="dynamic"></asp:RequiredFieldValidator>)
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
                <asp:GridView ID="GridView2" runat="server" Width="100%" AutoGenerateColumns="False"
                    BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"
                    CellPadding="3" >
                    <Columns>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <asp:Label ID="Label22" runat="server" Text="二、多选题"></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <table id="Table3" cellspacing="1" cellpadding="1" width="100%" align="center" border="0">
                                    <br />
                                    
                                    <tr>
                                    
                                        <td >
                                        <asp:Label ID="Label10" runat="server" Text='<%# Container.DataItemIndex+1 %>'>
                                            </asp:Label>
                                            参考答案：<asp:Label ID="Label27" runat="server" Text='<%# Eval("MultiAnswer") %>'></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            (本题得分：<asp:TextBox ID="tbxqueScore2" runat="server" Width="50px"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="tbxqueScore2"
                                                ValidationExpression="^\d+$" ErrorMessage="只能为正整数或0" Display="dynamic"></asp:RegularExpressionValidator>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="不能为空"
                                                ControlToValidate="tbxqueScore2" Display="dynamic"></asp:RequiredFieldValidator>)
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
                    CellPadding="3" >
                    <Columns>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <asp:Label ID="Label20" runat="server" Text="三、判断题"></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <table id="Table4" cellspacing="1" cellpadding="1" width="100%" align="center" border="0">
                                    <br />
                                    
                                    <tr>
                                        <td >
                                        <asp:Label ID="Label8" runat="server" Text='<%# Container.DataItemIndex+1 %>'>
                                            </asp:Label>
                                            参考答案：
                                            <asp:Label ID="Label21" runat="server" Text='<%# Eval("JudgeAnswer").ToString()=="True"?"正确":"错误" %>'></asp:Label>
                                            <asp:Label ID="Label41" runat="server" Text='<%# Eval("JudgeAnswer")%>' Visible="false"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            (本题得分：<asp:TextBox ID="tbxqueScore3" runat="server" Width="50px"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="tbxqueScore3"
                                                ValidationExpression="^\d+$" ErrorMessage="只能为正整数或0" Display="dynamic"></asp:RegularExpressionValidator>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="不能为空"
                                                ControlToValidate="tbxqueScore3" Display="dynamic"></asp:RequiredFieldValidator>)
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
                <asp:GridView ID="GridView4" runat="server" Width="100%" AutoGenerateColumns="False"
                    >
                    <Columns>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <asp:Label ID="Label18" runat="server" Text="四、填空题"> </asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <table id="Table5" cellspacing="1" cellpadding="1" width="100%" align="center" border="0">
                                    <br />
                                    
                                    <tr>
                                        
                                        <td>
                                            <asp:Label ID="Label9" runat="server" Text='<%# Container.DataItemIndex+1 %>'>
                                            </asp:Label>
                                            参考答案：
                                            <asp:Label ID="Label26" runat="server" Text='<%# Eval("FillBlankAnswer") %>'></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            (本题得分：<asp:TextBox ID="tbxqueScore4" runat="server" Width="50px"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="tbxqueScore4"
                                                ValidationExpression="^\d+$" ErrorMessage="只能为正整数或0" Display="dynamic"></asp:RegularExpressionValidator>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="不能为空"
                                                ControlToValidate="tbxqueScore4" Display="dynamic"></asp:RequiredFieldValidator>)
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
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <asp:Label ID="Label32" runat="server" Text="五、问答题"></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <table id="Table6" cellspacing="1" cellpadding="1" width="100%" align="center" border="0">
                                    <br>
                                    
                                    <tr>
                                        
                                            <td><asp:Label ID="Label18" runat="server" Text='<%# Container.DataItemIndex+1 %>'>
                                            </asp:Label>参考答案：
                                            <br />
                                            <asp:TextBox ID="TextBox4" runat="server" TextMode="multiLine" Width="100%" Height="60px"
                                                ReadOnly="true" Text='<%#Eval("QuestionAnswer") %>'></asp:TextBox>
                                        </td>
                                    </tr>
                                    
                                    <tr>
                                        <td>
                                            (本题得分：<asp:TextBox ID="tbxqueScore5" runat="server" Width="50px"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="tbxqueScore5"
                                                ValidationExpression="^\d+$" ErrorMessage="只能为正整数或0" Display="dynamic"></asp:RegularExpressionValidator>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="不能为空"
                                                ControlToValidate="tbxqueScore5" Display="dynamic"></asp:RequiredFieldValidator>)
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
                <br />
                <center>
                </center>
            </td>
        </tr>
    </table>
                    <div align="center">
                        <a href="#top">返回顶端</a> &nbsp; &nbsp;<asp:ImageButton ID="imgBtnSubmit" runat="server"
                            ImageUrl="~/Images/Submit.GIF" OnClick="imgBtnSubmit_Click" align="center" /></div>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
