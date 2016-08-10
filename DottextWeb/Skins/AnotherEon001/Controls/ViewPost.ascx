<%@ Control Language="c#" Inherits="Dottext.Web.UI.Controls.ViewPost" %>
	<div class="post">
		<h2>
			<asp:HyperLink Runat="server" ID="TitleUrl" />
		</h2>
		<div class="postbody">
		<asp:Literal id="Body"  runat="server" />
		</div>
		<p class="postfoot">
			posted on <asp:Literal id="PostDescription"  runat="server" />
		</p>
	</div>
	<asp:Literal ID = "PingBack" Runat = "server" />
	<asp:Literal ID = "TrackBack" Runat = "server" />
	