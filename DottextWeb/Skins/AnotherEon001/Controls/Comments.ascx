<%@ Control Language="c#" AutoEventWireup="false" Inherits="Dottext.Web.UI.Controls.Comments" %>
<a name = "фюбш" />
<div id="comments">
<h3>фюбш</h3>
	<asp:Literal ID = "NoCommentMessage" Runat ="server" />
	<asp:Repeater id="CommentList" runat="server" OnItemCreated="CommentsCreated" OnItemCommand="RemoveComment_ItemCommand">
		<ItemTemplate>
			<div class="post">
				<h2>
					<asp:Literal Runat = "server" ID = "Title" />
					<asp:LinkButton Runat="server" ID="EditLink" CausesValidation="False" />
				</h2>
				<asp:Literal id = "PostText" Runat = "server" />
				<div class="postfoot">
					<asp:Literal id = "PostDate" Runat = "server" /> | <asp:HyperLink Target="_blank" Runat="server" ID="NameLink" />
				</div>
			</div>
		</ItemTemplate>

	</asp:Repeater>
</div>
