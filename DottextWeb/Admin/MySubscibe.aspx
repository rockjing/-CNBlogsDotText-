<%@ Register TagPrefix="ANW" Namespace="Dottext.Web.Admin.WebUI" Assembly="Dottext.Web.Admin" %>
<%@ Page language="c#" Codebehind="MySubscibe.aspx.cs" AutoEventWireup="false" Inherits="Dottext.Web.Admin.Pages.MySubscribe" %>
<ANW:Page runat="server" id="PageContainer" TabSectionID="MySubscibe">
	<ANW:MESSAGEPANEL id="Messages" runat="server"></ANW:MESSAGEPANEL>
	<ANW:ADVANCEDPANEL id="Results" runat="server" DisplayHeader="true" HeaderCssClass="CollapsibleHeader"
		HeaderText="我订阅的文章" Collapsible="False">
		<asp:Repeater id="rprSelectionList" runat="server">
			<HeaderTemplate>
				<table id="Listing" class="Listing" cellSpacing="0" cellPadding="0" border="0">
					<tr style="text-align:center">
						<th width="320">
							标题</th>
						<th width="40" style="text-align:center">
							作者</th>
						<th width="80" style="text-align:center">
							发表时间</th>
						<th width="60" style="text-align:center">
							评论数</th>
						<th width="60" style="text-align:center">
							阅读数</th>
						<th width="40" style="text-align:center">
							操作</th>
					</tr>
			</HeaderTemplate>
			<ItemTemplate>
				<tr>
					<td>
						<asp:HyperLink Runat="server" CssClass="titlelink" NavigateUrl='<%# DataBinder.Eval(Container.DataItem, "TitleUrl") %>' Text='<%# DataBinder.Eval(Container.DataItem, "Title") %>' ID="LinkTitle">
						</asp:HyperLink>
					</td>
					<td style="text-align:center">
						<%# DataBinder.Eval(Container.DataItem, "Author") %>
					</td>
					<td style="text-align:center">
						<%# (DateTime.Parse(DataBinder.Eval(((RepeaterItem)Container).DataItem,"DateCreated").ToString())).ToString("yyyy-MM-dd HH:mm") %>
					</td>
					<td style="text-align:center">
						<%# DataBinder.Eval(Container.DataItem, "FeedbackCount") %>
					</td>
					<td style="text-align:center">
						<%# DataBinder.Eval(Container.DataItem, "ViewCount") %>
					</td>
					<td style="text-align:center">
						<asp:LinkButton id="lnkEdit" CommandName="Delete" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "EntryID") %>' Text="取消订阅" runat="server" on/>
					</td>
				</tr>
			</ItemTemplate>
			<FooterTemplate>
				</table>
			</FooterTemplate>
		</asp:Repeater>
		<ANW:Pager id="ResultsPager" runat="server" CssClass="Pager" UrlFormat="MyMessages.aspx?pg={0}"
			LinkFormatActive='<a href="{0}" class="Current">{1}</a>' PrefixText="<div>Goto page</div>"
			UseSpacer="False"></ANW:Pager>
	</ANW:ADVANCEDPANEL>
</ANW:Page>
