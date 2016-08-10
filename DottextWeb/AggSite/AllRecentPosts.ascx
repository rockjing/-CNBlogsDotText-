<%@ Control Language="c#" AutoEventWireup="false" Codebehind="AllRecentPosts.ascx.cs" Inherits="Dottext.Web.AggSite.AllRecentPosts" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<%@ OutputCache Duration="60" VaryByParam="GroupID;OnlyTitle;cate;cateid" VaryByCustom="Url" %>
<h2>综合区最新随笔 |<font class="h2font"><asp:HyperLink Runat="server" Text="发表随笔" NavigateUrl="~/EnterMyBlog.aspx?NewPost=1" ID="Hyperlink1"></asp:HyperLink></font>|<font class="h2font"><asp:HyperLink Runat="server" Text="发表文章" NavigateUrl="~/EnterMyBlog.aspx?NewArticle=1" ID="Hyperlink5"></asp:HyperLink></font>|
	<asp:HyperLink Runat="server" NavigateUrl="~/AdvancedView.aspx" text="分页浏览" CssClass="More" id="Hyperlink6"></asp:HyperLink></h2>
<asp:repeater id="RecentPostsRepeater" runat="server" EnableViewState="False">
	<ItemTemplate>
		<div class="post">
			<p>
				<h3>
					<asp:HyperLink Runat = "server" NavigateUrl = '<%# GetEntryUrl(DataBinder.Eval(((RepeaterItem)Container).DataItem,"host").ToString(),DataBinder.Eval(((RepeaterItem)Container).DataItem,"Application").ToString(), DataBinder.Eval(((RepeaterItem)Container).DataItem,"EntryName").ToString(), (DateTime)DataBinder.Eval(((RepeaterItem)Container).DataItem,"DateAdded")) %>' Text = '<%# DataBinder.Eval(((RepeaterItem)Container).DataItem,"Title")+"["+DataBinder.Eval(((RepeaterItem)Container).DataItem,"CategoryTitle")+"]" %>' ID="Hyperlink2"/>
				<asp:HyperLink Runat="server" NavigateUrl="../#Top" CssClass="More" id="Hyperlink7">Top</asp:HyperLink>
				</h3>
				<h4>
					<asp:Literal runat = "server" Text = '<%# CheckLength(DataBinder.Eval(((RepeaterItem)Container).DataItem,"Description").ToString(),GetEntryUrl(DataBinder.Eval(((RepeaterItem)Container).DataItem,"host").ToString(),DataBinder.Eval(((RepeaterItem)Container).DataItem,"Application").ToString(), DataBinder.Eval(((RepeaterItem)Container).DataItem,"EntryName").ToString(), (DateTime)DataBinder.Eval(((RepeaterItem)Container).DataItem,"DateAdded"))) %>' ID="BlogContentLabel" />
				</h4>
			<p class="postfoot" align="right">
				<asp:Literal runat = "server" Text = '<%# (DateTime.Parse(DataBinder.Eval(((RepeaterItem)Container).DataItem,"DateAdded").ToString())).ToString("yyyy-MM-dd HH:mm") %>' ID="Label5"/>
				作者:
				<asp:HyperLink Runat = "server" CssClass = "clsSubText" NavigateUrl = '<%# GetFullUrl(DataBinder.Eval(((RepeaterItem)Container).DataItem,"Application").ToString())  %>' Text = '<%# Dottext.Web.UI.Globals.RemoveHtml(DataBinder.Eval(((RepeaterItem)Container).DataItem,"Author").ToString()) %>' ID="Hyperlink3"/>
				<asp:HyperLink Runat = "server" CssClass = "CommentLink"　NavigateUrl = '<%# GetEntryUrl(DataBinder.Eval(((RepeaterItem)Container).DataItem,"host").ToString(),DataBinder.Eval(((RepeaterItem)Container).DataItem,"Application").ToString(), DataBinder.Eval(((RepeaterItem)Container).DataItem,"EntryName").ToString(), (DateTime)DataBinder.Eval(((RepeaterItem)Container).DataItem,"DateAdded")) %>' ID="Hyperlink4">【评论:
				<asp:Literal runat = "server" Text = '<%# DataBinder.Eval(((RepeaterItem)Container).DataItem,"FeedBackCount") %>' ID="Literal1"/>】</asp:HyperLink>【阅读:
				<asp:Literal runat = "server" Text = '<%# CheckViewCount(DataBinder.Eval(((RepeaterItem)Container).DataItem,"ViewCount").ToString()) %>' ID="Literal2"/>】
			</p>
		</div>
	</ItemTemplate>
</asp:repeater>
<h6><asp:HyperLink Runat="server" Text="分页浏览" NavigateUrl="~/AdvancedView.aspx" ID="lnkMore"></asp:HyperLink></h6>
