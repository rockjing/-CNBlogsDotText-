<%@ Control Language="c#" Inherits="Dottext.Web.UI.Controls.CategoryList" %>
<%@ Import Namespace = "Dottext.Framework" %>
<!--done-->
<asp:Repeater ID="CatList" Runat="server" OnItemCreated="CategoryCreated">
	<ItemTemplate>
		<h1 class = "catListTitle"><asp:Literal runat="server" ID="Title" /></h1>
		<asp:Repeater id="LinkList" runat="server" OnItemCreated="LinkCreated">
			<HeaderTemplate>
				<ul class = "catList">
			</HeaderTemplate>
			<ItemTemplate>
				<li class = "catListItem"> <asp:HyperLink Runat="server" CssClass="listitem" ID="Link" /><asp:HyperLink CssClass = "listitem" Runat = "server" ID = "RssLink" ImageUrl="../Images/xml.gif" Visible = "False"/></li>
			</ItemTemplate>
			<FooterTemplate>
				</ul>
			</FooterTemplate>
		</asp:Repeater>
	</ItemTemplate>
</asp:Repeater>
