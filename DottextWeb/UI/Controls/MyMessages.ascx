<%@ Control Language="c#" AutoEventWireup="false" Codebehind="MyMessages.ascx.cs" Inherits="Dottext.Web.UI.Controls.MyMessages" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<%@ OutputCache Duration="120" VaryByParam="none" VaryByCustom="Blogger"%>
<H3>���Բ�(<asp:Literal id="ltMsgCount" runat="server"></asp:Literal>)</H3>
<ul>
	<li>
		<asp:HyperLink id="lnkMessages" runat="server">��������</asp:HyperLink>
	<li>
		<asp:HyperLink id="lnkPublicMsgView" runat="server">�鿴��������</asp:HyperLink>
	<li>
		<asp:HyperLink id="lnkPrivateMsgView" runat="server">�鿴˽������</asp:HyperLink>
	</li>
</ul>
