<%@ Control Language="c#" AutoEventWireup="false" Codebehind="CategoryPosts.ascx.cs" Inherits="Dottext.Web.AggSite.CategoryPosts" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<h2><asp:hyperlink id="Title" runat="server"></asp:hyperlink></h2>
<asp:repeater id="RecentPostsRepeater" runat="server">
	<HeaderTemplate>
		<ul class="NavLink">
	</HeaderTemplate>
	<ItemTemplate>
		<li class="NavLinkli">
			<asp:HyperLink Runat = "server" NavigateUrl = '<%# BuildUrl(DataBinder.Eval(((RepeaterItem)Container).DataItem,"TitleUrl").ToString(),DataBinder.Eval(((RepeaterItem)Container).DataItem,"Link").ToString(),DataBinder.Eval(((RepeaterItem)Container).DataItem,"SourceUrl").ToString(),DataBinder.Eval(((RepeaterItem)Container).DataItem,"PostType").ToString()) %>' Text = '<%# DataBinder.Eval(((RepeaterItem)Container).DataItem,"Title") %>' ID="lnkTitle"/>
			(
			<asp:Literal runat = "server" Text = '<%# Dottext.Web.UI.Globals.RemoveHtml(DataBinder.Eval(((RepeaterItem)Container).DataItem,"Author").ToString()) %>' ID="Literal1"/>
			<asp:Literal runat = "server" Text = '<%# (DateTime.Parse(DataBinder.Eval(((RepeaterItem)Container).DataItem,"DateCreated").ToString())).ToString("MM-dd HH:mm") %>' ID="Literal2"/>)
		</li>
	</ItemTemplate>
	<FooterTemplate>
		</ul>
	</FooterTemplate>
</asp:repeater>
