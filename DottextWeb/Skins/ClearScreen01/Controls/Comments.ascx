<%@ Control Language="c#" AutoEventWireup="false" Inherits="Dottext.Web.UI.Controls.Comments" %>
<!--done-->
<a name = "feedback" />
<div class = "feedback">
	<div class = "feedbackTitle">
		Feedback
	</div>
	<div class="feedbackNoItems"><asp:Literal ID = "NoCommentMessage" Runat ="server" /></div>
	
	<asp:Repeater id="CommentList" runat="server" OnItemCreated="CommentsCreated" OnItemCommand="RemoveComment_ItemCommand">
		<ItemTemplate>
			<div class="feedbackItem">
				<div class = "feedbackListTitle"><asp:Literal Runat = "server" ID = "Title" /></div>
				<div class = "feedbackListSubtitle">
					<asp:Literal id = "PostDate" Runat = "server" /> | <asp:HyperLink Target="_blank" Runat="server" ID="NameLink" />
				</div>
				<asp:Literal id = "PostText" Runat = "server" /><br>
				<asp:LinkButton Runat="server" ID="EditLink" CausesValidation="False" />
			</div>
		</ItemTemplate>
	</asp:Repeater>
</div>


