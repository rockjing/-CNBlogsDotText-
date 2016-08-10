<%@ Control Language="c#" AutoEventWireup="false" Inherits="Dottext.Web.UI.Controls.Comments" %>
<h3>Feedback</h3>
	<asp:Repeater id="CommentList" runat="server" OnItemCreated="CommentsCreated" OnItemCommand="RemoveComment_ItemCommand">
		<ItemTemplate>
			<div class="post">
				<div class="posthead">
					<h2>
						<asp:Literal Runat = "server" ID = "Title" />
						<asp:LinkButton Runat="server" ID="EditLink" CausesValidation="False" />
					</h2>
					<asp:Literal id = "PostDate" Runat = "server" /> by <asp:HyperLink Target="_blank" Runat="server" ID="NameLink" />
				</div>
				<div class="postbody"><asp:Literal id = "PostText" Runat = "server" /></div>
			</div>
		</ItemTemplate>

	</asp:Repeater>