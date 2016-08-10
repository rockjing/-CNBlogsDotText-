<%@ Control Language="c#" Inherits="Dottext.Web.UI.Controls.CategoryList" %>
<%@ Import Namespace = "Dottext.Framework" %>
<asp:Repeater ID="CatList" Runat="server" OnItemCreated="CategoryCreated">
	<ItemTemplate>
		<h3><asp:Literal runat="server" ID="Title" /></h3>
		<asp:Repeater id="LinkList" runat="server" OnItemCreated="LinkCreated">
			<HeaderTemplate>
				<ul>
			</HeaderTemplate>
			<ItemTemplate>
				<li><asp:HyperLink Runat="server" ID="Link" /><asp:HyperLink Runat = "server" ID = "RssLink" ImageUrl = "images/xml_small.gif" Visible = "False"/></li>
			</ItemTemplate>
			<FooterTemplate>
				</ul>
			</FooterTemplate>
		</asp:Repeater>
	</ItemTemplate>
</asp:Repeater>