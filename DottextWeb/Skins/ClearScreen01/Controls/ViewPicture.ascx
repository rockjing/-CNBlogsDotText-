<%@ Control Language="c#" AutoEventWireup="false" Inherits="Dottext.Web.UI.Controls.ViewPicture" %>
<div class="gallery">
	<div class="galleryTitle"><asp:Literal id="Title" runat="server" /></div>
	<br>
	<asp:Image ID="GalleryImage" Runat="server" />
	<br>
	<br>
	<asp:HyperLink ID="ReturnUrl" Text="Return to Gallery" Runat="server" />&nbsp;|
	<asp:HyperLink ID="OriginalImage" Text="Original Image" Runat="server" Target="_New" />
</div>
