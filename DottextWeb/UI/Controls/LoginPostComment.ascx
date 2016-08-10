<%@ Control Language="c#" AutoEventWireup="false" Codebehind="LoginPostComment.ascx.cs" Inherits="Dottext.Web.UI.Controls.LoginPostComment" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<%@ Register TagPrefix="FTB" Namespace="FreeTextBoxControls" Assembly="FreeTextBox" %>
<div class="logincomment">
	<TABLE cellSpacing="1" cellPadding="1" border="0">
		<TR>
			<TD width="75">����</TD>
			<TD><asp:textbox id="tbTitle" Width="300px" Size="40" runat="server"></asp:textbox></TD>
			<TD><asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" ControlToValidate="tbTitle" ErrorMessage="���������"></asp:requiredfieldvalidator></TD>
		</TR>
		<TR>
			<TD colSpan="3">����&nbsp;
				<asp:RequiredFieldValidator id="RequiredFieldValidator3" runat="server" ErrorMessage="��������������" ControlToValidate="ftbComment"></asp:RequiredFieldValidator>
				<ftb:FreeTextBox language="zh-cn" id="ftbComment" runat="server" Visible="true" ToolbarStyleConfiguration="OfficeXP"
					Height="400" Width="98%"></ftb:FreeTextBox><BR>
			</TD>
		</TR>
		<TR>
			<TD colSpan="3"></TD>
		</TR>
		<TR>
			<TD align="center"><asp:Button id="btnSubmit" runat="server" Text="�ύ" CssClass="commentTextBox"></asp:Button></TD>
			<TD colSpan="2">
				<asp:HyperLink id="linkReturn" runat="server">����</asp:HyperLink>&nbsp;&nbsp;<a href="#Top">Top</a>
				<asp:linkbutton id="btnSubscibe" runat="server" CausesValidation="False">���Ļظ�</asp:linkbutton>&nbsp;&nbsp;<asp:linkbutton id="btnUnSubscibe" runat="server" CausesValidation="False">ȡ������</asp:linkbutton>
				<asp:Label id="Message" runat="server" ForeColor="Red"></asp:Label>
			</TD>
		</TR>
	</TABLE>
	<asp:ValidationSummary id="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False"></asp:ValidationSummary>
</div>
