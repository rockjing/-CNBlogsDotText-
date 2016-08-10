<%@ Control Language="c#" AutoEventWireup="false" Codebehind="PostsList.ascx.cs" Inherits="Dottext.Web.AggSite.PostsList" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<h2><asp:hyperlink id="Title" runat="server"></asp:hyperlink></h2>
<asp:repeater id="RecentPostsRepeater" runat="server">
	<HeaderTemplate>
		<ul class="NavLink">
	</HeaderTemplate>
	<ItemTemplate>
		<li class="NavLinkli">
			<%#Container.ItemIndex +1 %>
			.&nbsp;
			<asp:HyperLink Runat = "server" NavigateUrl = '<%# BuildUrl(DataBinder.Eval(((RepeaterItem)Container).DataItem,"TitleUrl").ToString(),DataBinder.Eval(((RepeaterItem)Container).DataItem,"Link").ToString(),DataBinder.Eval(((RepeaterItem)Container).DataItem,"SourceUrl").ToString(),DataBinder.Eval(((RepeaterItem)Container).DataItem,"PostType").ToString()) %>' Text = '<%# DataBinder.Eval(((RepeaterItem)Container).DataItem,"Title") %>' ID="lnkTitle"/>
			(
			<asp:Literal runat = "server" Text = '<%# Dottext.Web.UI.Globals.RemoveHtml(DataBinder.Eval(((RepeaterItem)Container).DataItem,"Author").ToString()) %>' ID="Literal1"/>)
		</li>
	</ItemTemplate>
	<FooterTemplate>
		</ul>
	</FooterTemplate>
</asp:repeater>
