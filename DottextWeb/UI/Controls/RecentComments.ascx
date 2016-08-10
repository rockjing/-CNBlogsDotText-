<%@ Control Language="c#" AutoEventWireup="false" Codebehind="RecentComments.ascx.cs" Inherits="Dottext.Web.UI.Controls.RecentComments" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<h3>×îÐÂÆÀÂÛ
	<asp:hyperlink id="RSSHyperlink1" runat="server" ImageUrl="~/images/xml.gif"></asp:hyperlink></h3>
<div class="RecentComment">
	<asp:Repeater id="CommentList" runat="server">
		<HeaderTemplate>
			<ul style="word-break:break-all;width:100%">
		</HeaderTemplate>
		<ItemTemplate>
			<li>
				<asp:HyperLink Runat="server" NavigateUrl='<%# DataBinder.Eval(Container.DataItem, "Link") %>' Text='<%# (index++).ToString()+".&nbsp;"+DataBinder.Eval(Container.DataItem, "Title").ToString() %>' ID="Hyperlink1">
				</asp:HyperLink>
			</li>
			<li>
				<%# CheckLength(DataBinder.Eval(Container.DataItem, "Body").ToString()) %>
			</li>
			<li style="text-align:right;margin-right:4px">
				--<%# DataBinder.Eval(Container.DataItem, "Author") %></li>
		</ItemTemplate>
		<FooterTemplate>
			</ul>
		</FooterTemplate>
	</asp:Repeater>
</div>
