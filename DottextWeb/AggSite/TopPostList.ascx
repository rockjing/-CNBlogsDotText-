<%@ OutputCache Duration="60" VaryByParam="GroupID;OnlyTitle;cate" VaryByCustom="Url" %>
<%@ Control Language="c#" AutoEventWireup="false" Codebehind="TopPostList.ascx.cs" Inherits="Dottext.Web.AggSite.TopPostList" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<asp:repeater id="RecentPostsRepeater" runat="server">
	<ItemTemplate>
		<div class="post">
			<h3>
				<asp:HyperLink Runat = "server" NavigateUrl = '<%# GetEntryUrl(DataBinder.Eval(((RepeaterItem)Container).DataItem,"host").ToString(),DataBinder.Eval(((RepeaterItem)Container).DataItem,"Application").ToString(), DataBinder.Eval(((RepeaterItem)Container).DataItem,"EntryName").ToString(), (DateTime)DataBinder.Eval(((RepeaterItem)Container).DataItem,"DateAdded")) %>' Text = '<%# DataBinder.Eval(((RepeaterItem)Container).DataItem,"Title") %>' ID="Hyperlink2"/>
			</h3>
			<p class="postfoot" align="right">
				<asp:Literal runat = "server" Text = '<%# (DateTime.Parse(DataBinder.Eval(((RepeaterItem)Container).DataItem,"DateAdded").ToString())).ToString("yyyy-MM-dd HH:mm") %>' ID="Label5"/>
				×÷Õß:
				<asp:HyperLink Runat = "server" CssClass = "clsSubText" NavigateUrl = '<%# GetFullUrl(DataBinder.Eval(((RepeaterItem)Container).DataItem,"Application").ToString())  %>' Text = '<%# Dottext.Web.UI.Globals.RemoveHtml(DataBinder.Eval(((RepeaterItem)Container).DataItem,"Author").ToString()) %>' ID="Hyperlink3"/>
				<asp:HyperLink Runat = "server" CssClass = "CommentLink"¡¡NavigateUrl = '<%# GetEntryUrl(DataBinder.Eval(((RepeaterItem)Container).DataItem,"host").ToString(),DataBinder.Eval(((RepeaterItem)Container).DataItem,"Application").ToString(), DataBinder.Eval(((RepeaterItem)Container).DataItem,"EntryName").ToString(), (DateTime)DataBinder.Eval(((RepeaterItem)Container).DataItem,"DateAdded")) %>' ID="Hyperlink4">¡¾ÆÀÂÛ:
				<asp:Literal runat = "server" Text = '<%# DataBinder.Eval(((RepeaterItem)Container).DataItem,"FeedBackCount") %>' ID="Literal1"/>¡¿</asp:HyperLink>¡¾ÔÄ¶Á:
				<asp:Literal runat = "server" Text = '<%# CheckViewCount(DataBinder.Eval(((RepeaterItem)Container).DataItem,"ViewCount").ToString()) %>' ID="Literal2"/>¡¿
			</p>
		</div>
	</ItemTemplate>
</asp:repeater>
