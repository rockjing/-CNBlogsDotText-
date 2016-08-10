<%@ Control Language="c#" AutoEventWireup="false" Codebehind="TopFeedbackPosts.ascx.cs" Inherits="Dottext.Web.UI.Controls.TopFeedbackPosts" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<%@ OutputCache Duration="600" VaryByParam="none" VaryByCustom="Blogger"%>
<h3>фюбшеепп╟Я</h3>
<div class="RecentComment">
	<asp:Repeater id="TopList" runat="server">
		<HeaderTemplate>
			<ul style="word-break:break-all;width:100%">
		</HeaderTemplate>
		<ItemTemplate>
			<li>
				<asp:HyperLink Runat="server" NavigateUrl='<%# BuildUrl(DataBinder.Eval(Container.DataItem, "DateAdded").ToString(),DataBinder.Eval(Container.DataItem, "ID").ToString()) %>' Text='<%# Container.ItemIndex+1+".&nbsp;"+DataBinder.Eval(Container.DataItem, "Title").ToString()+"("+DataBinder.Eval(Container.DataItem, "FeedBackCount").ToString()+")" %>' ID="Hyperlink1">
				</asp:HyperLink>
			</li>
		</ItemTemplate>
		<FooterTemplate>
			</ul>
		</FooterTemplate>
	</asp:Repeater>
</div>
