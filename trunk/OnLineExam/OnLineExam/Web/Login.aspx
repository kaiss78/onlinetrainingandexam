<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Login.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>在线练习考试系统</title>
        <style type="text/css">
        div.RoundedCorner{background: #BAD4F7; width:350px;}
        b.rtop, b.rbottom{display:block;background: #FFF}
        b.rtop b, b.rbottom b{display:block;height: 1px;overflow: hidden; background: #CCFF99}
        b.r1{margin: 0 5px}
        b.r2{margin: 0 3px}
        b.r3{margin: 0 2px}
        b.rtop b.r4, b.rbottom b.r4{margin: 0 1px;height: 2px}
        table.content{border:0px;height:100px; font-family:Tahoma; font-size:9.5pt;color:#363A36;}
        body
        {
            topmargin="0";
            bottommargin="0"; 
            leftmargin="0"; 
            rightmargin="0";
        }
</style>

</head>
<body>
    <form id="form1" runat="server" defaultbutton="imgBtnLogin">
    <div align="center"><br /><br /><br /><br /><br /><br /><br /><div class="RoundedCorner">
    <b class="rtop"><b class="r1"></b><b class="r2"></b><b class="r3"></b><b class="r4"></b></b>
                <table class="content" style="FONT-SIZE: 12px; FONT-FAMILY: Tahoma; BORDER-COLLAPSE: collapse; " cellspacing="0" cellpadding="1" width=350 align="center"
				 border="1" bgColor="#ffffff" bordercolor="#CCFF99">
				<tr height=40>
					<td colspan="3" align="center">	<br />					
						<font color=#4D2600><h4 style="font-family: 楷体_GB2312; font-size: 16px;">在线练习考试系统登陆</h4></font>
					</td>
				</tr>							
				<tr>
					<td height="30" align="center" width=80>帐 &nbsp;号：</td>
					<td height="30"><div align="left">						
							<asp:TextBox id="txtUserID" runat="server" MaxLength="20" Width="150px"></asp:TextBox>   
                        </div>                   
                       </td>
                       <td>
                           <div align="left"> <asp:CheckBox ID="cbxRemeberUser" runat="server" Text="记住用户名" 
                                   Checked="True" /> 
                           <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUserID"
                            ErrorMessage="不能为空！"></asp:RequiredFieldValidator></div>
                       </td>
				</tr>
				<TR>
					<TD align="center" height="30">密 &nbsp;码：</TD>
					<TD height="30"><div align="left">
						<asp:TextBox id="txtPwd"  runat="server" MaxLength="20" TextMode="Password" Width="150px"></asp:TextBox>
                       </div>
                    </TD>
                    <td>
                      <div align="center">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPwd"
                            ErrorMessage="不能为空！"></asp:RequiredFieldValidator>
                      </div>
                    </td>
				</TR>
				<TR>
					<TD align="center" height="30">验证码：</TD>
					<TD height="30"><div align="left">
						<asp:TextBox ID="Validator" runat="server" Width="150px" ></asp:TextBox>                        
                        </div>
                     </TD>
                     <td>
                       <div align="left">
                          <asp:ImageButton ID="ChangeCode" runat="server" Width="55px" ToolTip="看不清楚？点击图片换一个验证码"  ImageUrl="ValidateImage.aspx"  CausesValidation="false" OnClick="ChangeCode_Click" />
                         
                       </div>
                     </td>
				</TR>
				<tr height=50>
					<td align=center colspan="3">
                        <asp:Label ID="lblMessage" runat="server" ForeColor=red></asp:Label><br />
						<asp:ImageButton ID="imgBtnLogin" runat="server" ImageUrl="~/Images/Login.GIF" OnClick="imgBtnLogin_Click" />
					</td>
				</tr>
			</table>
          <b class="rbottom"><b class="r4"></b><b class="r3"></b><b class="r2"></b><b class="r1"></b></b>
    </div>
    </div>
    </form>
</body>
</html>
