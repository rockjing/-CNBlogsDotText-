<%@ Control Language="c#" AutoEventWireup="false" Codebehind="MyMessages.ascx.cs" Inherits="Dottext.Web.UI.Controls.MyMessages" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<%@ OutputCache Duration="120" VaryByParam="none" VaryByCustom="Blogger"%>
<H3>留言簿(<asp:Literal id="ltMsgCount" runat="server"></asp:Literal>)</H3>
<ul>
	<li>
		<asp:HyperLink id="lnkMessages" runat="server">给我留言</asp:HyperLink>
	<li>
		<asp:HyperLink id="lnkPublicMsgView" runat="server">查看公开留言</asp:HyperLink>
	<li>
		<asp:HyperLink id="lnkPrivateMsgView" runat="server">查看私人留言</asp:HyperLink>
	</li>
</ul>
