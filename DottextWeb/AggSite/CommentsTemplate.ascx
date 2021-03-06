<%@ Register TagPrefix="uc1" TagName="SiteCategory" Src="SiteCategory.ascx" %>
<%@ Register TagPrefix="uc1" TagName="PostsList" Src="PostsList.ascx" %>
<%@ Register TagPrefix="uc1" TagName="CommentAuthorList" Src="CommentAuthorList.ascx" %>
<%@ Register TagPrefix="uc1" TagName="RecentPosts" Src="~/AggSite/PagedPosts.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="SiteSearch" Src="SiteSearch.ascx" %>
<%@ Register TagPrefix="uc1" TagName="PagedPosts" Src="PagedPosts.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Calendar" Src="Calendar.ascx" %>
<%@ Register TagPrefix="uc1" TagName="SiteNavigate" Src="SiteNavigate.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Syndication" Src="~/AggSite/Syndication.ascx" %>
<%@ Register TagPrefix="uc1" TagName="AggStats" Src="~/AggSite/AggStats.ascx" %>
<%@ Register TagPrefix="uc1" TagName="BlogList" Src="~/AggSite/BlogList.ascx" %>
<%@ Register TagPrefix="DT" Namespace="Dottext.Web.UI.WebControls" Assembly="Dottext.Web" %>
<%@ Register TagPrefix="uc1" TagName="AuthorSearch" Src="AuthorSearch.ascx" %>
<uc1:Header id="Header1" runat="server"></uc1:Header>
<div id="authors"><DT:CONTENTREGION id="LeftColumn" runat="server">
		<uc1:SiteNavigate id="SiteNavigate1" runat="server"></uc1:SiteNavigate>
		<uc1:SiteCategory id="SiteCategory1" runat="server"></uc1:SiteCategory>
		<uc1:SiteSearch id="SiteSearch1" runat="server"></uc1:SiteSearch>
		<uc1:Syndication id="Syndication1" runat="server"></uc1:Syndication>
		<uc1:AggStats id="AggStats1" runat="server"></uc1:AggStats>
		<uc1:AuthorSearch id="AuthorSearch1" runat="server"></uc1:AuthorSearch>
		<uc1:CommentAuthorList id="CommentAuthorList1" runat="server"></uc1:CommentAuthorList>		
</DT:CONTENTREGION>
</div>
<div id="main"><DT:CONTENTREGION id="MPMain" runat="server"></DT:CONTENTREGION></div>
<div id="footer"></div>
