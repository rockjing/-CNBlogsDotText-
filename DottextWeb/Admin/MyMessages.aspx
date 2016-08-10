<%@ Register TagPrefix="ANW" Namespace="Dottext.Web.Admin.WebUI" Assembly="Dottext.Web.Admin" %>
<%@ Page language="c#" Codebehind="MyMessages.aspx.cs" AutoEventWireup="false" Inherits="Dottext.Web.Admin.Pages.MyMessages" %>
<ANW:Page runat="server" id="PageContainer" TabSectionID="MyMessages">
	<ANW:MessagePanel id="Messages" runat="server"></ANW:MessagePanel>
	<ANW:AdvancedPanel id="Results" runat="server" Collapsible="False" HeaderText="我的留言" HeaderCssClass="CollapsibleHeader"
		DisplayHeader="true">
		<ASP:Repeater id="rprSelectionList" runat="server">
			<HeaderTemplate>
				<table id="Listing" class="Listing" cellSpacing="0" cellPadding="0" border="0" style="<%= CheckHiddenStyle() %>">
					<tr>
						<th>
							标题</th>
						<th width="*">
							发件人</th>
						<th width="100">
							EMAIL</th>
						<th width="100" align="center">
							时间</th>
						<th width="100" align="center">
							留言方式</th>
						<th width="50">
							&nbsp;</th>
					</tr>
			</HeaderTemplate>
			<ItemTemplate>
				<tr>
					<td class="FeedfackTitle">
						<b>
							<asp:HyperLink Runat="server" CssClass="titlelink" NavigateUrl='<%# DataBinder.Eval(Container.DataItem, "Link") %>' Text='<%# DataBinder.Eval(Container.DataItem, "Title") %>' ID="LinkTitle">
							</asp:HyperLink></b>
					</td>
					<td nowrap class="FeedfackTitle">
						<%# DataBinder.Eval(Container.DataItem, "Author") %>
					</td>
					<td nowrap class="FeedfackTitle">
						<%# DataBinder.Eval(Container.DataItem, "EMail") %>
					</td>
					<td nowrap class="FeedfackTitle" align="center">
						<%# DataBinder.Eval(Container.DataItem, "DateCreated", "{0:MM-dd HH:mm}") %>
					</td>
					<td nowrap class="FeedfackTitle" align="center">
						<%# GetPostConfig(DataBinder.Eval(Container.DataItem, "PostConfig").ToString()) %>
					</td>
					<td class="FeedfackTitle">
						<asp:linkbutton id="lkbDelete" CommandName="Delete" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "EntryID") %>' Text="Delete" runat="server" />
					</td>
				</tr>
				<tr>
					<td colspan="4" class="FeedfackBody">
						<%# DataBinder.Eval(Container.DataItem, "Body") %>
					</td>
				</tr>
			</ItemTemplate>
			<FooterTemplate>
			</table>
		</FooterTemplate>
		</ASP:Repeater>
		<ANW:Pager id="ResultsPager" runat="server" UseSpacer="False" PrefixText="<div>Goto page</div>"
			LinkFormatActive='<a href="{0}" class="Current">{1}</a>' UrlFormat="MyMessages.aspx?pg={0}"
			CssClass="Pager"></ANW:Pager>
		<BR class="Clear">
	</ANW:AdvancedPanel>
</ANW:Page>
