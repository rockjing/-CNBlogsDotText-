<%@ Control Language="c#" AutoEventWireup="false" Inherits="Dottext.Web.UI.Controls.AnonymousPostComment" CodeBehind="AnonymousPostComment.ascx.cs" %>
<style>
TD { FONT-SIZE: 12px }
.commentTextBox { FONT-SIZE: 12px }
</style>
<div class="commentform">
	<TABLE cellSpacing="1" cellPadding="1" border="0">
		<TR>
			<TD width="55">标题</TD>
			<TD>
				<asp:TextBox id="tbTitle" runat="server" Size="40" Width="300px"></asp:TextBox></TD>
			<TD>
				<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ErrorMessage="请输入标题" ControlToValidate="tbTitle"></asp:RequiredFieldValidator></TD>
		</TR>
		<TR>
			<TD>姓名</TD>
			<TD>
				<asp:TextBox id="tbName" runat="server" Size="40" Width="300px"></asp:TextBox></TD>
			<TD>
				<asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" ErrorMessage="请输入你的姓名" ControlToValidate="tbName"></asp:RequiredFieldValidator></TD>
		</TR>
		<TR>
			<TD>主页</TD>
			<TD>
				<asp:TextBox id="tbUrl" runat="server" Size="40" Width="300px"></asp:TextBox></TD>
			<TD></TD>
		</TR>
		<TR>
			<TD colSpan="3">内容&nbsp;
				<asp:RequiredFieldValidator id="RequiredFieldValidator3" runat="server" ErrorMessage="请输入评论内容" ControlToValidate="tbComment"></asp:RequiredFieldValidator><BR>
				<asp:TextBox id="tbComment" runat="server" Rows="10" Columns="50" Width="400px" Height="193px"
					TextMode="MultiLine" CssClass="commentTextBox"></asp:TextBox></TD>
		</TR>
		<tr>
			<td align="left" colSpan="3">
				<table class="CommentForm" runat="server" id="tbCaptchaImage">
					<tr>
						<td colspan="2">
							<asp:RequiredFieldValidator id="Requiredfieldvalidator4" runat="server" Display="Dynamic" ErrorMessage="请输入验证码"
								ControlToValidate="CodeNumberTextBox"></asp:RequiredFieldValidator>
							<asp:Label Runat="server" ID="lblImage" Font-Bold="true" ForeColor="RED" />
						</td>
					</tr>
					<tr>
						<td align="left">
							<img src="~/Modules/CaptchaImage/JpegImage.aspx" runat="server" ID="Img1">
						</td>
						<td align="left">
							请输入验证码:<br>
							<asp:TextBox ID="CodeNumberTextBox" Runat="server" />*
						</td>
					</tr>
				</table>
			</td>
		</tr>
		<TR>
			<TD colSpan="3">
				<asp:CheckBox id="chkRemember" runat="server" Text="Remember Me?" tabIndex="-1"></asp:CheckBox></TD>
		</TR>
		<TR>
			<TD height="23">
				<asp:Button id="btnSubmit" runat="server" Text="提交" CssClass="commentTextBox"></asp:Button></TD>
			<td colspan="2" height="23">&nbsp;
				<asp:hyperlink id="lnkLogin" runat="server">登录</asp:hyperlink>&nbsp;&nbsp;<asp:hyperlink id="linkLoginComment" runat="server">使用高级评论</asp:hyperlink>&nbsp;&nbsp;<A href="#Top">Top</A>
				<asp:LinkButton id="btnSubscibe" runat="server" CausesValidation="False">订阅回复</asp:LinkButton>&nbsp;&nbsp;<asp:LinkButton id="btnUnSubscibe" runat="server" CausesValidation="False">取消订阅</asp:LinkButton>
				<asp:Label id="Message" runat="server" ForeColor="Red"></asp:Label></td>
		</TR>
		<TR>
			<TD colSpan="3">[使用Ctrl+Enter键可以直接提交]</TD>
		</TR>
	</TABLE>
</div>
<asp:ValidationSummary id="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False"></asp:ValidationSummary>
