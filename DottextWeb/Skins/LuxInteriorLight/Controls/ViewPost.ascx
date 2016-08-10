<%@ Control Language="c#" Inherits="Dottext.Web.UI.Controls.ViewPost" %>
	<div class="post">
		<div class="posthead">
			<h2>
				<asp:HyperLink  CssClass="singleposttitle" Runat="server" ID="TitleUrl" />
			</h2>
 			Posted on <asp:Literal id="PostDescription"  runat="server" />
			<asp:Literal ID = "PingBack" Runat = "server" />
			<asp:Literal ID = "TrackBack" Runat = "server" />
		</div>
		<div class="postbody"><asp:Literal id="Body"  runat="server" /></div>
	</div>