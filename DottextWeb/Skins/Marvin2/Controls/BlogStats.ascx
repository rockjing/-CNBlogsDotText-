<%@ Control Language="c#" Inherits="Dottext.Web.UI.Controls.BlogStats" %>
<h3>统计</h3>
<ul>
	<li>
		随笔 -
		<asp:Literal ID="PostCount" Runat="server" />
	<li>
		文章 -
		<asp:Literal ID="StoryCount" Runat="server" />
	<li>
		评论 -
		<asp:Literal ID="CommentCount" Runat="server" />
	<li>
		引用 -
		<asp:Literal ID="PingTrackCount" Runat="server" />
	</li>
</ul>
