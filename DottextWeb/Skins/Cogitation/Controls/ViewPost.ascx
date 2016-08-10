<%@ Control Language="c#" Inherits="Dottext.Web.UI.Controls.ViewPost" %>
<div class="post">
	<div class="postTitle">
		<asp:HyperLink Runat="server" ID="TitleUrl" />
	</div>
	
	<div class="postText">
		<asp:Literal id="Body"  runat="server" />
	</div>
	
	<div class="postfoot">
		posted on <asp:Literal id="PostDescription"  runat="server" />
	</div>
</div>
<asp:Literal ID = "PingBack" Runat = "server" />
<asp:Literal ID = "TrackBack" Runat = "server" />
