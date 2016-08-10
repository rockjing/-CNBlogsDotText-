<%@ Control Language="c#" Inherits="Dottext.Web.UI.Controls.BlogStats" %>
<!--done-->
<div class="blogStats">
posts - <asp:Literal ID = "PostCount" Runat = "server" />,&nbsp;
comments - <asp:Literal ID = "CommentCount" Runat = "server" />,&nbsp;
trackbacks - <asp:Literal ID = "PingTrackCount" Runat = "server" />
<asp:Literal ID = "StoryCount" Runat = "server" visible="False"/>
</div>