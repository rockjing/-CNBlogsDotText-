<%@ Control Language="c#" Inherits="Dottext.Web.UI.Controls.EntryList" %>
<%@ Import Namespace = "Dottext.Framework" %>
<h1><asp:Literal ID = "EntryCollectionTitle" Runat = "server" /></h1>
<div class="postText">
	<asp:Literal ID = "EntryCollectionDescription" Runat = "server" />
</div>
<asp:Repeater runat="Server" Runat="server" ID="Entries" OnItemCreated="PostCreated">
	<ItemTemplate>
			<div class="post">
				<div class="postTitle">
					<asp:HyperLink Runat="server" ID="TitleUrl" />
				</div>
				
				<div class="postText">
					<asp:Literal  runat="server" ID="PostText" />
				</div>
				
				<div class="postfoot">
					<asp:Literal ID = "PostDesc" Runat = "server" />
				</div>
			</div>
			<br>
	</ItemTemplate>
</asp:Repeater>

<p>
<asp:HyperLink Runat="server" ID="EntryCollectionReadMoreLink" />
</p>
