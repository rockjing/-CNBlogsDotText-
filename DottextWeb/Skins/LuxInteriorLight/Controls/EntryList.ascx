<%@ Control Language="c#" Inherits="Dottext.Web.UI.Controls.EntryList" %>
<%@ Import Namespace = "Dottext.Framework" %>
<h2>
	<asp:Literal ID = "EntryCollectionTitle" Runat = "server" />
</h2>
<asp:Literal ID = "EntryCollectionDescription" Runat = "server" />
<asp:Repeater runat="Server" Runat="server" ID="Entries" OnItemCreated="PostCreated">
	<ItemTemplate>
			<div class="post">
				<div class="posthead">
					<h2>
						<asp:HyperLink Runat="server" ID="TitleUrl" />
					</h2>
				</div>
				<div class="postbody"><asp:Literal  runat="server" ID="PostText" /></div>
				
				<p class="postfoot">		
					<asp:Literal ID = "PostDesc" Runat = "server" /> | <asp:HyperLink  CssClass="itemdesc" Runat="server" ID="FeedBackCount" Title = "comments, pingbacks, trackbacks" />
				</p>
			</div>
	</ItemTemplate>
</asp:Repeater>
<p>
	<asp:HyperLink Runat="server" ID="EntryCollectionReadMoreLink" />
</p>

