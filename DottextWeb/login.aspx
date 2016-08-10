<%@ Page language="c#" EnableViewState="False" Codebehind="login.aspx.cs" AutoEventWireup="false" Inherits="Dottext.Web.Pages.login" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<HTML>
	<HEAD>
		<title>博客登录</title>
		<style>BODY { PADDING-RIGHT: 32px; MARGIN-TOP: 60px; PADDING-LEFT: 32px; FONT-SIZE: 13px; BACKGROUND: #eee; PADDING-BOTTOM: 32px; WIDTH: 270px; COLOR: #000; PADDING-TOP: 32px; FONT-FAMILY: arial }
	DIV#Main { BORDER-RIGHT: #bbb 1px solid; PADDING-RIGHT: 32px; BORDER-TOP: #bbb 1px solid; PADDING-LEFT: 32px; BACKGROUND: #fff; PADDING-BOTTOM: 32px; MARGIN-LEFT: 300px; BORDER-LEFT: #bbb 1px solid; WIDTH: 270px; PADDING-TOP: 20px; BORDER-BOTTOM: #bbb 1px solid }
	DIV#Heading { PADDING-RIGHT: 0px; PADDING-LEFT: 0px; FONT-WEIGHT: bold; FONT-SIZE: 150%; PADDING-BOTTOM: 15px; MARGIN: 0px; COLOR: #904; PADDING-TOP: 0px; FONT-FAMILY: arial }
	H2 { PADDING-RIGHT: 0px; PADDING-LEFT: 0px; FONT-WEIGHT: bold; FONT-SIZE: 105%; PADDING-BOTTOM: 0px; MARGIN: 0px 0px 8px; TEXT-TRANSFORM: uppercase; COLOR: #999; PADDING-TOP: 0px; BORDER-BOTTOM: #ddd 1px solid; FONT-FAMILY: "trebuchet ms", ""lucida grande"", verdana, arial, sans-serif }
	P { PADDING-RIGHT: 0px; PADDING-LEFT: 0px; PADDING-BOTTOM: 6px; MARGIN: 0px; PADDING-TOP: 6px }
	A:link { COLOR: #002c99; TEXT-DECORATION: none }
	A:visited { COLOR: #002c99; TEXT-DECORATION: none }
	A:hover { COLOR: #cc0066; BACKGROUND-COLOR: #f5f5f5; TEXT-DECORATION: underline }
	LABEL { DISPLAY: block; FONT-WEIGHT: bold; FONT-SIZE: 12px; MARGIN: 6px 0px 2px; TEXT-TRANSFORM: uppercase; COLOR: #999 }
	INPUT.Textbox { PADDING-RIGHT: 2px; PADDING-LEFT: 2px; PADDING-BOTTOM: 2px; WIDTH: 200px; PADDING-TOP: 2px; FONT-FAMILY: verdana, arial, sans-serif }
	A.Button:link { BORDER-RIGHT: #999 1px solid; PADDING-RIGHT: 12px; BORDER-TOP: #999 1px solid; DISPLAY: block; PADDING-LEFT: 12px; FONT-WEIGHT: bold; BACKGROUND: #904; FLOAT: left; PADDING-BOTTOM: 3px; BORDER-LEFT: #999 1px solid; COLOR: #fff; PADDING-TOP: 3px; BORDER-BOTTOM: #999 1px solid }
	A.Button:visited { BORDER-RIGHT: #999 1px solid; PADDING-RIGHT: 12px; BORDER-TOP: #999 1px solid; DISPLAY: block; PADDING-LEFT: 12px; FONT-WEIGHT: bold; BACKGROUND: #904; FLOAT: left; PADDING-BOTTOM: 3px; BORDER-LEFT: #999 1px solid; COLOR: #fff; PADDING-TOP: 3px; BORDER-BOTTOM: #999 1px solid }
	SPAN.ErrorMessage { DISPLAY: block; FONT-WEIGHT: bold; COLOR: #904 }
	P.Small { MARGIN-TOP: 12px; FONT-SIZE: 85% }
	</style>
	</HEAD>
	<body onload="document.forms[0]['tbUserName'].focus()">
		<form id="frmLogin" method="post" runat="server">
			<div id="Main">
				<div id="Heading">请登录</div>
				<label>用户名</label>
				<asp:textbox id="tbUserName" runat="server" CssClass="Textbox"></asp:textbox><br>
				<asp:requiredfieldvalidator id="Required_UserName" runat="server" ErrorMessage="用户名不能为空" ControlToValidate="tbUserName"></asp:requiredfieldvalidator><label>密码</label>
				<asp:textbox id="tbPassword" runat="server" CssClass="Textbox" TextMode="Password"></asp:textbox><br>
				<asp:requiredfieldvalidator id="Required＿Password" runat="server" ErrorMessage="密码不能为空" ControlToValidate="tbPassword"></asp:requiredfieldvalidator>
				<table runat="server" id="tbAuthenCode">
					<tr>
						<td>
							<asp:RequiredFieldValidator id="Requiredfieldvalidator4" runat="server" Display="Dynamic" ErrorMessage="请输入验证码"
								ControlToValidate="CodeNumberTextBox"></asp:RequiredFieldValidator><br>
							<asp:Label Runat="server" ID="lblImage" Font-Bold="true" ForeColor="RED" />
							<img src="~/Modules/CaptchaImage/JpegImage.aspx" runat="server" ID="Img1">
							<label>请输入验证码:</label>
							<asp:TextBox ID="CodeNumberTextBox" Runat="server" />
						</td>
					</tr>
				</table>
				<asp:linkbutton id="lblLogin" style="MARGIN-TOP: 8px" runat="server" CssClass="Button" Text="Login">登录</asp:linkbutton>
				<p style="MARGIN: 4px 0px 0px 70px"><asp:checkbox id="chkRemember" runat="server" CssClass="LoginFloat"></asp:checkbox>Remember 
					me?
				</p>
				<p class="Small"><asp:hyperlink id="lbSendPassword" runat="server" NavigateUrl="GetMyPassword.aspx">忘记密码</asp:hyperlink>&nbsp;&nbsp;<asp:hyperlink id="lnkHome" runat="server" NavigateUrl="~">返回首页</asp:hyperlink>
				</p>
				<br style="CLEAR: both">
				<asp:label id="Message" runat="server" CssClass="ErrorMessage" FontBold="true" ForeColor="Red"></asp:label></div>
		</form>
		<P></P>
		<DIV></DIV>
		</FORM>
	</body>
</HTML>
