<%@ Control Language="c#" AutoEventWireup="false" Codebehind="BloggerNav.ascx.cs" Inherits="Dottext.Web.AggSite.BloggerNav" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<H2>博客列表</H2>
<UL>
	<LI class="NavLinkli">
		<asp:hyperlink id="Hyperlink2" runat="server" NavigateUrl="~/BlogList.aspx" Text="最新更新"></asp:hyperlink>
	<LI class="NavLinkli">
		<asp:hyperlink id="Hyperlink1" runat="server" NavigateUrl="~/BlogList.aspx?id=1" Text="最新注册"></asp:hyperlink>
	</LI>
</UL>
