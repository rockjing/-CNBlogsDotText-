<%@ Register TagPrefix="dt" Namespace="Dottext.Web.UI.WebControls" Assembly="Dottext.Web"%>
<%@ Control Language="c#" AutoEventWireup="false" Codebehind="PagedPosts.ascx.cs" Inherits="Dottext.Web.AggSite.PagedPosts" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<%@ OutputCache Duration="60" VaryByParam="page;date;cate;onlytitle;cateid;group;id;author" VaryByCustom="Url" %>
<h2><asp:literal id="CatalogTitle" runat="server"></asp:literal></h2>
<dt:pager id="ResultsPager" runat="server" CssClass="Pager" LinkFormatActive="{1}" UseSpacer="True"
	DisplayMode="Block"></dt:pager>
<asp:repeater id="RecentPostsRepeater" runat="server">
	<ItemTemplate>
		<div class="post">
			<h3>
				<asp:HyperLink Runat = "server" NavigateUrl = '<%# BuildUrl(DataBinder.Eval(((RepeaterItem)Container).DataItem,"TitleUrl").ToString(),DataBinder.Eval(((RepeaterItem)Container).DataItem,"Link").ToString(),DataBinder.Eval(((RepeaterItem)Container).DataItem,"SourceUrl").ToString(),DataBinder.Eval(((RepeaterItem)Container).DataItem,"PostType").ToString()) %>' Text = '<%# DataBinder.Eval(((RepeaterItem)Container).DataItem,"Title") %>' ID="lnkTitle"/>
				<%--<asp:HyperLink Runat="server" CssClass="Top" id="lnkTop" NavigateUrl=' GetTopUrl() '>Top</asp:HyperLink>--%>
			</h3>
			<h4>
				<asp:Literal runat = "server" Text = '<%# CheckLength(DataBinder.Eval(((RepeaterItem)Container).DataItem,"Body").ToString()) %>' ID="BlogContentLabel" />
			</h4>
			<p class="postfoot" align="right">
				<asp:Literal runat = "server" Text = '<%# (DateTime.Parse(DataBinder.Eval(((RepeaterItem)Container).DataItem,"DateCreated").ToString())).ToString("yyyy-MM-dd HH:mm") %>' ID="Label5"/>
				×÷Õß:
				<asp:HyperLink Runat = "server" CssClass = "clsSubText" NavigateUrl='<%# GetBlogUrl() %>' Text = '<%# Dottext.Web.UI.Globals.RemoveHtml(DataBinder.Eval(((RepeaterItem)Container).DataItem,"Author").ToString()) %>' ID="Hyperlink3"/>
				<asp:HyperLink runat = "server" CssClass = "CommentLink" NavigateUrl='<%# GetUrl()+"#Post" %>' Text = '<%# "¡¾ÆÀÂÛ:"+DataBinder.Eval(((RepeaterItem)Container).DataItem,"FeedBackCount")+"¡¿" %>' ID="lnkComments"/>¡¾ÔÄ¶Á:
				<asp:Literal runat = "server" Text = '<%# (int.Parse(CheckViewCount(DataBinder.Eval(((RepeaterItem)Container).DataItem,"WebCount").ToString()))+int.Parse(CheckViewCount(DataBinder.Eval(((RepeaterItem)Container).DataItem,"AggCount").ToString()))).ToString()+"¡¿" %>' ID="Literal2"/>
			</p>
		</div>
	</ItemTemplate>
</asp:repeater>
<h6><dt:pager id="ResultsPager2" runat="server" CssClass="Pager" LinkFormatActive="{1}" UseSpacer="True"></dt:pager></h6>
