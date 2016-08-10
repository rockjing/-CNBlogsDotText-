<%@ Import Namespace = "Dottext.Web.Admin" %>
<%@ Register TagPrefix="ANW" Namespace="Dottext.Web.Admin.WebUI" Assembly="Dottext.Web.Admin" %>
<%@ Control Language="c#" AutoEventWireup="false" Codebehind="PageTemplate.ascx.cs" Inherits="Dottext.Web.Admin.PageTemplate" targetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<HTML>
	<HEAD>
		<title>
			<ANW:PlaceHolder id="PageTitle" runat="server">.Text - Manage</ANW:PlaceHolder></title>
		<ANW:HeaderLink id="Css1" rel="stylesheet" href="resources/admin.css" linkType="text/css" runat="server" />
	</HEAD>
	<body id="AdminSection" runat="server">
		<form id="frmMain" method="post" runat="server">
			<table id="BodyTable" border="0" cellpadding="0" cellspacing="0" width="100%">
				<tr>
					<td id="Header" colspan="2"><div id="SiteNav">Logged in as <strong>
								<asp:Literal Runat="server" ID="LoggedInUser" /></strong> (<asp:LinkButton id="LogoutLink" runat="server" CausesValidation="False">logout</asp:LinkButton>) 
							| <a href="http://scottwater.com/blog">.Text Site</a> | <a href="http://dottextwiki.scottwater.com">
								Help</a>
						</div>
						<div id="BlogTitle"><asp:HyperLink id="BlogTitleLink" runat="server" />
						</div>
						<div id="SiteTitle">
							<asp:hyperlink id="TitleLink" Runat="server"></asp:hyperlink>
						</div>
						<!--<a href="http://scottwater.com/blog"><img id="HeaderLogo" src='<%= Utilities.ResourcePath + "resources/header_logo.gif" %>' height="50" width="103" border = "0"></a>-->
					</td>
				</tr>
				<tr>
					<td>
						<div id="LeftNavHeader"><ANW:PlaceHolder id="LabelActions" runat="server" /></div>
					</td>
					<td class="NavHeaderRow">
						<ul id="TopNav">
							<li>
								<a href="EditPosts.aspx" id="TabPosts">随笔</a>
							<li>
								<a href="EditArticles.aspx" id="TabArticles">文章</a>
							<li>
								<a href="Feedback.aspx" id="TabFeedback">评论</a>
							<li>
								<a href="MyMessages.aspx" id="TabMyMessages">留言</a>
							<li>
								<a href="EditLinks.aspx" id="TabLinks">链接</a>
							<li>
								<a href="EditFavorite.aspx" id="TabFavorites">收藏</a>
							<li runat="server" id="GalleryTab" visible="false">
								<a href="EditGalleries.aspx" id="TabGalleries">相册</a>
							</li>
							<li runat="server" id="FilesTab">
								<a href="Files.aspx" id="TabFiles">文件</a>
							</li>
							<li>
								<a href="Statistics.aspx" id="TabStats">统计</a>
							<li>
								<a href="Options.aspx" id="TabOptions">选项</a>
							<li>
								<a href="MySubscibe.aspx" id="TabMySubscibe">订阅</a>
							<li>
							<li runat="server" id="AdminTab" visible="false">
								<a href="ManageSite.aspx" id="TabManageSite">Manage</a>
							</li>
						</ul>
						<div id="SubNav">
							<ANW:BreadCrumbs id="BreadCrumbs" UsePrefixText="true" IsPanel="false" IncludeRoot="false" runat="server" />
						</div>
					</td>
				</tr>
				<tr>
					<td class="NavLeftCell">
						<div id="LeftNav">
							<ANW:LinkList id="LinksActions" runat="server" />
						</div>
						<div class="LeftNavHeader">
							<ANW:PlaceHolder id="LabelCategories" runat="server" />
						</div>
						<div id="LeftNav">
							<ANW:LinkList id="LinksCategories" runat="server" />
						</div>
					</td>
					<td id="Body">
						<div id="Main">
							<ANW:PlaceHolder id="PageContent" runat="server">Default page content goes here.</ANW:PlaceHolder>
						</div>
					</td>
				</tr>
			</table>
			<table id="Footer" border="0" cellpadding="0" cellspacing="0" width="100%">
				<tr>
					<td id="Footer" colspan="2">
						<div>
							<a href="http://www.asp.net"><img id="PoweredBy" src='<%= Utilities.ResourcePath + "resources/poweredbydotnet.gif" %>' height="33" width="99"></a>
							Copyright <a href="http://scottwater.com/blog">Scott Watermasysk</a>, 2003. All 
							rights reserved.
						</div>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
