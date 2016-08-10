<%@ OutputCache Duration="10000" VaryByParam="GroupID" VaryByCustom="Url" %>
<%@ Control Language="c#" AutoEventWireup="false" Codebehind="Syndication.ascx.cs" Inherits="Dottext.Web.AggSite.Syndication" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<h2>聚合</h2>
<ul>
	<li>
		<asp:hyperlink id="RssLink1" runat="server" NavigateUrl="~/rss.html" Text="RSS (所有文章)"></asp:hyperlink>
	<li>
		<asp:hyperlink id="OpmlLink" runat="server" NavigateUrl="~/Opml.aspx" Text="OPML (博客列表)"></asp:hyperlink>
	<li>
		<asp:hyperlink id="CalalogOpmlLink" runat="server" NavigateUrl="~/CatalogOpml.aspx" Text="OPML (网站分类)"></asp:hyperlink>
	
	</li>
</ul>
