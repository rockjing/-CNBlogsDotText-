<%@ Register TagPrefix="uc1" TagName="Syndication" Src="AggSite/Syndication.ascx" %>
<%@ Register TagPrefix="uc1" TagName="SiteSearch" Src="AggSite/SiteSearch.ascx" %>
<%@ Register TagPrefix="uc1" TagName="SiteNavigate" Src="AggSite/SiteNavigate.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="AggSite/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="BlogList" Src="AggSite/BlogList.ascx" %>
<%@ Page language="c#" Codebehind="homepage.aspx.cs" AutoEventWireup="false" Inherits="Dottext.Web.HomePage" %>
<%@ Register TagPrefix="uc1" TagName="SiteCategory" Src="AggSite/SiteCategory.ascx" %>
<%@ Register TagPrefix="uc1" TagName="CategoryPosts" Src="AggSite/CategoryPosts.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>HomePage</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="AggSite/style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="FlowLayout">
		<form id="Form1" method="post" runat="server">
			<uc1:Header id="Header1" runat="server"></uc1:Header>
			<div id="authors">
				<uc1:SiteNavigate id="SiteNavigate1" runat="server"></uc1:SiteNavigate>
				<uc1:SiteCategory id="SiteCategory1" runat="server"></uc1:SiteCategory>
				<uc1:SiteSearch id="SiteSearch1" runat="server"></uc1:SiteSearch>
				<uc1:Syndication id="Syndication1" runat="server"></uc1:Syndication>
				<uc1:BlogList id="BlogList1" runat="server"></uc1:BlogList>
			</div>
			<div id="main">
				<uc1:CategoryPosts id="CategoryPosts1" runat="server" CategoryID="76"></uc1:CategoryPosts>
				<uc1:CategoryPosts id="Categoryposts2" runat="server" CategoryID="-1"></uc1:CategoryPosts>
			</div>
			<div id="footer"><FONT face="ËÎÌו"></FONT>
			</div>
			<FONT face="ËÎÌו"></FONT>
		</form>
	</body>
</HTML>
