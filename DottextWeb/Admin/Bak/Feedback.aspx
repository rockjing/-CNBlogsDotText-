<%@ Page language="c#" Codebehind="Feedback.aspx.cs" AutoEventWireup="false" Inherits="Dottext.Web.Admin.Pages.Feedback" %>
<%@ Register TagPrefix="ANW" Namespace="Dottext.Web.Admin.WebUI" Assembly="Dottext.Web.Admin" %>
<ANW:Page runat="server" id="PageContainer" TabSectionID="Feedback">

	<ANW:MessagePanel id="Messages" runat="server" />

	<ANW:AdvancedPanel id="Results" runat="server" Collapsible="False" HeaderText="Comments" HeaderCssClass="CollapsibleHeader" DisplayHeader="true">
		<ASP:Repeater id="rprSelectionList" runat="server">
			<HeaderTemplate>
				<table id="Listing" class="Listing" cellSpacing="0" cellPadding="0" border="0" style="<%= CheckHiddenStyle() %>">
					<tr>
						<th>Title</th>
						<th width="*">Posted By</th>
						<th width="100">Date</th>
						<th width="50">&nbsp;</th>
					</tr>
			</HeaderTemplate>
			<ItemTemplate>
				<tr>
					<td class="FeedfackTitle">
						<b><asp:HyperLink Runat="server" CssClass="titlelink" NavigateUrl='<%# DataBinder.Eval(Container.DataItem, "SourceUrl") %>' Text='<%# DataBinder.Eval(Container.DataItem, "Title") %>'  ID="LinkTitle"></asp:HyperLink></b>						
					</td>
					<td nowrap  class="FeedfackTitle">
						<%# DataBinder.Eval(Container.DataItem, "Author") %>
					</td>
					<td nowrap  class="FeedfackTitle">
						<%# DataBinder.Eval(Container.DataItem, "DateCreated", "{0:M/d/yy h:mmt}") %>
					</td>
					<td  class="FeedfackTitle">
						<asp:linkbutton id="lkbDelete" CommandName="Delete" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "EntryID") %>' Text="Delete" runat="server" />
					</td>
				</tr>
				<tr>
					<td colspan="4" class="FeedfackBody">
						<%# GetBody(Container.DataItem) %>						
					</td>
				</tr>
			</ItemTemplate>
			
			<FooterTemplate>
			</table>
		</FooterTemplate>
		</ASP:Repeater>
		<ANW:Pager id="ResultsPager" runat="server" UseSpacer="False" PrefixText="<div>Goto page</div>" LinkFormatActive='<a href="{0}" class="Current">{1}</a>' UrlFormat="Feedback.aspx?pg={0}" CssClass="Pager" />
		<br class="Clear">
	</ANW:AdvancedPanel>
</ANW:Page>
