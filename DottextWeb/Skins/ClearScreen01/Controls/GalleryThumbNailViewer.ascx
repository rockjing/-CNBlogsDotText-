<%@ Control Language="c#" AutoEventWireup="false" Inherits="Dottext.Web.UI.Controls.GalleryThumbNailViewer" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>

<div class="gallery">
	<div class="galleryTitle"><asp:Literal id="GalleryTitle" runat="server" /></div>
	<div class="galleryDescription"><asp:Literal ID = "Description" Runat = "server" /></div>

	<asp:DataList id="ThumbNails" runat="server" OnItemCreated = "ImageCreated" RepeatColumns = "6" RepeatDirection = "Vertical">
		<ItemTemplate>
			<asp:HyperLink Runat="server" ID="ThumbNailImage" CssClass="galleryThumbnail" />
		</ItemTemplate>
	</asp:DataList>
</div>