<%@ Control Language="c#" AutoEventWireup="false" Codebehind="BloggerNav.ascx.cs" Inherits="Dottext.Web.AggSite.BloggerNav" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<H2>�����б�</H2>
<UL>
	<LI class="NavLinkli">
		<asp:hyperlink id="Hyperlink2" runat="server" NavigateUrl="~/BlogList.aspx" Text="���¸���"></asp:hyperlink>
	<LI class="NavLinkli">
		<asp:hyperlink id="Hyperlink1" runat="server" NavigateUrl="~/BlogList.aspx?id=1" Text="����ע��"></asp:hyperlink>
	</LI>
</UL>
