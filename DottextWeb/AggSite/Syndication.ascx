<%@ OutputCache Duration="10000" VaryByParam="GroupID" VaryByCustom="Url" %>
<%@ Control Language="c#" AutoEventWireup="false" Codebehind="Syndication.ascx.cs" Inherits="Dottext.Web.AggSite.Syndication" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<h2>�ۺ�</h2>
<ul>
	<li>
		<asp:hyperlink id="RssLink1" runat="server" NavigateUrl="~/rss.html" Text="RSS (��������)"></asp:hyperlink>
	<li>
		<asp:hyperlink id="OpmlLink" runat="server" NavigateUrl="~/Opml.aspx" Text="OPML (�����б�)"></asp:hyperlink>
	<li>
		<asp:hyperlink id="CalalogOpmlLink" runat="server" NavigateUrl="~/CatalogOpml.aspx" Text="OPML (��վ����)"></asp:hyperlink>
	
	</li>
</ul>
