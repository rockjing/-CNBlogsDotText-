<%@ Control Language="c#" AutoEventWireup="false" Inherits="Dottext.Web.UI.Controls.AnonymousPostComment" CodeBehind="AnonymousPostComment.ascx.cs" %>
<style>
TD { FONT-SIZE: 12px }
.commentTextBox { FONT-SIZE: 12px }
</style>
<div class="commentform">
	<TABLE cellSpacing="1" cellPadding="1" border="0">
		<TR>
			<TD width="55">����</TD>
			<TD>
				<asp:TextBox id="tbTitle" runat="server" Size="40" Width="300px"></asp:TextBox></TD>
			<TD>
				<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ErrorMessage="���������" ControlToValidate="tbTitle"></asp:RequiredFieldValidator></TD>
		</TR>
		<TR>
			<TD>����</TD>
			<TD>
				<asp:TextBox id="tbName" runat="server" Size="40" Width="300px"></asp:TextBox></TD>
			<TD>
				<asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" ErrorMessage="�������������" ControlToValidate="tbName"></asp:RequiredFieldValidator></TD>
		</TR>
		<TR>
			<TD>��ҳ</TD>
			<TD>
				<asp:TextBox id="tbUrl" runat="server" Size="40" Width="300px"></asp:TextBox></TD>
			<TD></TD>
		</TR>
		<TR>
			<TD colSpan="3">����&nbsp;
				<asp:RequiredFieldValidator id="RequiredFieldValidator3" runat="server" ErrorMessage="��������������" ControlToValidate="tbComment"></asp:RequiredFieldValidator><BR>
				<asp:TextBox id="tbComment" runat="server" Rows="10" Columns="50" Width="400px" Height="193px"
					TextMode="MultiLine" CssClass="commentTextBox"></asp:TextBox></TD>
		</TR>
		<TR>
			<TD colSpan="3">
				<asp:CheckBox id="chkRemember" runat="server" Text="Remember Me?" tabIndex="-1"></asp:CheckBox></TD>
		</TR>
		<TR>
			<TD height="23">
				<asp:Button id="btnSubmit" runat="server" Text="�ύ" CssClass="commentTextBox"></asp:Button></TD>
			<td colspan="2" height="23">&nbsp;
				<asp:HyperLink id="lnkLogin" runat="server">��¼</asp:HyperLink>&nbsp;&nbsp;<asp:HyperLink id="linkLoginComment" runat="server">ʹ�ø߼�����</asp:HyperLink>&nbsp;&nbsp;<a href="#Top">Top</a>
				<asp:Label id="Message" runat="server" ForeColor="Red"></asp:Label></td>
		</TR>
		<TR>
			<TD colSpan="3">[ʹ��Ctrl+Enter������ֱ���ύ]</TD>
		</TR>
	</TABLE>
</div>
<asp:ValidationSummary id="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False"></asp:ValidationSummary>
