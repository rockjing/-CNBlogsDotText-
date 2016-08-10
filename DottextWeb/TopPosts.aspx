<%@ Page language="c#" Codebehind="TopPosts.aspx.cs" AutoEventWireup="false" Inherits="Dottext.Web.TopPosts" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="AggSite/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="BlogList" Src="AggSite/BlogList.ascx" %>
<%@ OutputCache Duration="180" VaryByParam="id" VaryByCustom="Url" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>
			<asp:Literal runat="server" id="Title"></asp:Literal></title>
		<LINK href="AggSite/style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="FlowLayout">
		<form id="Form1" method="post" runat="server">
			<uc1:Header id="Header1" runat="server"></uc1:Header>
			<div id="authors">
				<H2>博 客 园 排 行 榜</H2>
				<UL class="NavLink">
					<LI class="NavLinkli">
						<asp:hyperlink id="Hyperlink6" runat="server" NavigateUrl="~/TopPosts.aspx?id=4" Text="今日阅读排行"></asp:hyperlink>
					<LI class="NavLinkli">
						<asp:hyperlink id="Hyperlink7" runat="server" NavigateUrl="~/TopPosts.aspx?id=5" Text="今日回复排行"></asp:hyperlink>
					<LI class="NavLinkli">
						<asp:hyperlink id="RegisterLink" runat="server" NavigateUrl="~/TopPosts.aspx" Text="本月阅读排行"></asp:hyperlink>
					<LI class="NavLinkli">
						<asp:hyperlink id="Hyperlink1" runat="server" NavigateUrl="~/TopPosts.aspx?id=1" Text="本月回复排行"></asp:hyperlink>
					
					<LI class="NavLinkli">
						<asp:hyperlink id="Hyperlink4" runat="server" NavigateUrl="~/TopPosts.aspx?id=2" Text="回复排行"></asp:hyperlink>
					<LI class="NavLinkli">
						<asp:hyperlink id="Hyperlink5" runat="server" NavigateUrl="~/TopPosts.aspx?id=3" Text="阅读排行"></asp:hyperlink>
					</LI>
				</UL>
			</div>
			<div id="main">
				<h2><asp:Literal runat="server" id="TopTitle"></asp:Literal></h2>
				<asp:repeater id="RecentPosts" runat="server">
					<ItemTemplate>
						<div class="post">
							<h3>
								<asp:HyperLink Runat = "server" NavigateUrl = '<%# GetEntryUrl(DataBinder.Eval(((RepeaterItem)Container).DataItem,"host").ToString(),DataBinder.Eval(((RepeaterItem)Container).DataItem,"Application").ToString(), DataBinder.Eval(((RepeaterItem)Container).DataItem,"EntryName").ToString(), (DateTime)DataBinder.Eval(((RepeaterItem)Container).DataItem,"DateAdded")) %>' Text = '<%# AddSn(DataBinder.Eval(((RepeaterItem)Container).DataItem,"Title").ToString()) %>' ID="Hyperlink2"/></h3>
							<p class="postfoot" align="right">
								<asp:Literal runat = "server" Text = '<%# (DateTime.Parse(DataBinder.Eval(((RepeaterItem)Container).DataItem,"DateAdded").ToString())).ToString("yyyy-MM-dd HH:mm") %>' ID="Label5"/>
								作者:
								<asp:HyperLink Runat = "server" CssClass = "clsSubText" NavigateUrl = '<%# GetFullUrl(DataBinder.Eval(((RepeaterItem)Container).DataItem,"host").ToString(),DataBinder.Eval(((RepeaterItem)Container).DataItem,"Application").ToString())  %>' Text = '<%# Dottext.Web.UI.Globals.RemoveHtml(DataBinder.Eval(((RepeaterItem)Container).DataItem,"Author").ToString()) %>' ID="Hyperlink3"/>【评论:
								<asp:Literal runat = "server" Text = '<%# DataBinder.Eval(((RepeaterItem)Container).DataItem,"FeedBackCount") %>' ID="Literal1"/>】【阅读:
								<asp:Literal runat = "server" Text = '<%# CheckViewCount(DataBinder.Eval(((RepeaterItem)Container).DataItem,"ViewCount").ToString()) %>' ID="Literal2"/>】
							</p>
						</div>
					</ItemTemplate>
				</asp:repeater>
		</form>
		</DIV>
	</body>
</HTML>
