<%@ Control Language="c#" Inherits="Dottext.Web.UI.Controls.EntryList" %>
<%@ Import Namespace = "Dottext.Framework" %>

<div class="entrylist">
	<div class="entrylistTitle"><asp:Literal ID = "EntryCollectionTitle" Runat = "server" /></div>
	<div class="entrylistDescription"><asp:Literal ID = "EntryCollectionDescription" Runat = "server" /></div>
	<asp:Repeater runat="Server" Runat="server" ID="Entries" OnItemCreated="PostCreated">
		<ItemTemplate>
			<div class="entrylistItem">
				<asp:HyperLink  CssClass="entrylistItemTitle" Runat="server" ID="TitleUrl" />
				<asp:Literal ID = "PostText" Runat = "server" />
				<div class="entrylistItemPostDesc">
					<asp:Literal ID = "PostDesc" Runat = "server" />
				</div>
			</div>
		</ItemTemplate>
		<SeparatorTemplate>
			<div class="postSeparator"></div>
		</SeparatorTemplate>
	</asp:Repeater>
	<p>
	<asp:HyperLink Runat="server" ID="EntryCollectionReadMoreLink" />
	</p>
</div>