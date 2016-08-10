<%@ Control Language="c#" AutoEventWireup="false" Inherits="Dottext.Web.UI.Controls.GalleryThumbNailViewer" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<h1><asp:Literal id="GalleryTitle" runat="server" /></h1>
<asp:Literal ID = "Description" Runat = "server" />
<asp:DataList id="ThumbNails" runat="server" OnItemCreated = "ImageCreated" RepeatColumns = "6" RepeatDirection = "Vertical">
	<ItemTemplate>
		<asp:HyperLink Runat="server" ID="ThumbNailImage" CssClass="ThumbNail" />
	</ItemTemplate>
</asp:DataList>
