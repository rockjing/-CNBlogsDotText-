<%@ Control Language="c#" Inherits="Dottext.Web.UI.Controls.ViewPost" %>
<!--done-->
<div class = "post">
	<div class = "postTitle">
		<asp:HyperLink  CssClass="postTitle2" Runat="server" ID="TitleUrl" />
	</div>
	<asp:Literal id="Body"  runat="server" />
	<div class = "postDesc">posted on <asp:Literal id="PostDescription"  runat="server" /></div>
</div>
<asp:Literal ID = "PingBack" Runat = "server" />
<asp:Literal ID = "TrackBack" Runat = "server" />
