<%@ Register TagPrefix="DT" Namespace="Dottext.Web.UI.WebControls" Assembly="Dottext.Web" %>
<%@ Register TagPrefix="uc1" TagName="SiteSearch" Src="AggSite/SiteSearch.ascx" %>
<%@ Register TagPrefix="uc1" TagName="SiteNavigate" Src="AggSite/SiteNavigate.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="AggSite/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="BloggerNav" Src="AggSite/BloggerNav.ascx" %>
<%@ Page language="c#" Codebehind="BlogList.aspx.cs" AutoEventWireup="false" Inherits="Dottext.Web.BlogList" %>
<%@ Register TagPrefix="uc1" TagName="AllBlogList" Src="AggSite/AllBlogList.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>
			<asp:Literal ID="pageTitle" Runat="server" />-²©¿ÍÁÐ±í</title>
		<meta content=".Text" name="GENERATOR">
		<LINK href="AggSite/style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<uc1:Header id="Header1" runat="server"></uc1:Header>
			<div id="authors"><DT:CONTENTREGION id="LeftColumn" runat="server">
					<uc1:BloggerNav id="BloggerNav1" runat="server"></uc1:BloggerNav>
				</DT:CONTENTREGION>
			</div>
			<div id="main"><DT:CONTENTREGION id="MPMain" runat="server">
					<uc1:AllBlogList id="AllBlogList1" runat="server"></uc1:AllBlogList>
				</DT:CONTENTREGION></div>
			<div id="footer">
				
			</div>
		</form>
	</body>
</HTML>
