<%@ Control Language="c#" AutoEventWireup="false" Inherits="Dottext.Web.UI.Controls.Comments" %>
<a name = "feedback" />
<br>
<div id="comments">
	<h3>Feedback</h3>
		<asp:Literal ID = "NoCommentMessage" Runat ="server" />
		<asp:Repeater id="CommentList" runat="server" OnItemCreated="CommentsCreated" OnItemCommand="RemoveComment_ItemCommand">
			<ItemTemplate>
				<div class="post">			
					<div class="postTitle">
						<asp:Literal Runat = "server" ID = "Title" />
							<span>
								<asp:Literal id = "PostDate" Runat = "server" />
							</span>
						<asp:HyperLink Target="_blank" Runat="server" ID="NameLink" />
					</div>
					<div class="postText">
						<asp:Literal id = "PostText" Runat = "server" />
						<br>
						<asp:LinkButton Runat="server" ID="EditLink" CausesValidation="False" />
					</div>
				</div>
				<br>
			</ItemTemplate>

		</asp:Repeater>
</div>