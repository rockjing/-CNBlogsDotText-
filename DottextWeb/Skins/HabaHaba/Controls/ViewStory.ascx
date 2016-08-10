<%@ Control Language="c#" Inherits="Dottext.Web.UI.Controls.ViewStory" %>
<div class = "singlepost">
	<div class = "singleposttitle">
		<asp:Literal  Runat="server" ID="Title" />
	</div>
	<p>
	by: <asp:Literal id=Author runat="server" /><br />
	posted on <asp:Literal id="PostDescription"  runat="server" /><br />
	<asp:HyperLink id=PrintLink CssClass="PrintLink" Runat="server">Printer Friendly</asp:HyperLink>
	</p>
	<asp:Literal id="Body"  runat="server" />
	<div class = "itemdesc">&nbsp;</div>
</div>