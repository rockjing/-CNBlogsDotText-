<%@ Control Language="c#" Inherits="Dottext.Web.UI.Controls.ViewPost" %>
<div class = "singlepost">
	<div class = "posttitle">
		<asp:HyperLink  CssClass="singleposttitle" Runat="server" ID="TitleUrl" />
	</div>
	
	<asp:Literal id="Body"  runat="server" />
	<div class = "itemdesc">
		posted on <asp:Literal id="PostDescription"  runat="server" />
	</div>

</div>
	<asp:Literal ID = "PingBack" Runat = "server" />
	<asp:Literal ID = "TrackBack" Runat = "server" />
