<%@ Control Language="c#" AutoEventWireup="false" Inherits="Dottext.Web.UI.Controls.PostComment" %>
<div id="commentform">
	<TABLE cellSpacing="1" cellPadding="1" border="0">
		<TR>
			<TD width="75">标题</TD>
			<TD>
				<asp:TextBox id="tbTitle" runat="server" Size="40" Width="300px"></asp:TextBox></TD>
			<TD>
				<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ErrorMessage="请输入标题" ControlToValidate="tbTitle"></asp:RequiredFieldValidator></TD>
		</TR>
		<TR>
			<TD width="75">姓名</TD>
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
		<TR>
			<TD colSpan="3">
				<asp:CheckBox id="chkRemember" runat="server" Text="Remember Me?"></asp:CheckBox></TD>
		</TR>
		<TR>
			<TD>
				<asp:Button id="btnSubmit" runat="server" Text="提交" CssClass="commentTextBox"></asp:Button></TD>
			<td colspan="2"><asp:Button id="lbLoginComment" runat="server" Text="使用高级评论" Width="80"></asp:Button>&nbsp;			
				<asp:Label id="Message" runat="server" ForeColor="Red"></asp:Label></TD>
		</TR>
	</TABLE>
</div>
