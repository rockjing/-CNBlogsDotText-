<%@ Control Language="c#" Inherits="Dottext.Web.UI.Controls.BlogStats" %>
<div class = "listtitle">统计</div>
	<ul class = "list">
		<li class = "listitem">随笔 - <asp:Literal ID = "PostCount" Runat = "server" />
		<li class = "listitem">文章 - <asp:Literal ID = "StoryCount" Runat = "server" />
		<li class = "listitem">评论 - <asp:Literal ID = "CommentCount" Runat = "server" />
		<li class = "listitem">引用 - <asp:Literal ID = "PingTrackCount" Runat = "server" />
	</li>
</ul>