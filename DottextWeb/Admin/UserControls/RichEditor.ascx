<%@ Control Language="c#" AutoEventWireup="false" Codebehind="RichEditor.ascx.cs" Inherits="Dottext.Web.Admin.UserControls.RichEditor" %>
<%@ Register TagPrefix="FTB" Namespace="FreeTextBoxControls" Assembly="FreeTextBox" %>
<%@ Register TagPrefix="ANW" Namespace="Dottext.Web.Admin.WebUI" Assembly="Dottext.Web.Admin" %>
<%@ Import Namespace = "Dottext.Web.Admin" %>
<ANW:MessagePanel id="Messages" runat="server"></ANW:MessagePanel>
<ANW:AdvancedPanel id="Results" runat="server" LinkStyle="Image" LinkBeforeHeader="True" DisplayHeader="True"
	HeaderCssClass="CollapsibleHeader" LinkText="[toggle]" Collapsible="True">
	<asp:Repeater id="rprSelectionList" runat="server">
		<HeaderTemplate>
			<table id="Listing" class="Listing" cellSpacing="0" cellPadding="0" border="0" style='<%= CheckHiddenStyle() %>'>
				<tr>
					<th>
						Description</th>
					<th width="50">
						Active</th>
					<th width="75">
						Web Views</th>
					<th width="75">
						Agg Views</th>
					<th width="50">
						Referrals</th>
					<th width="50">
						&nbsp;</th>
					<th width="50">
						&nbsp;</th>
				</tr>
		</HeaderTemplate>
		<ItemTemplate>
			<tr>
				<td>
					<a href = '<%# DataBinder.Eval(Container.DataItem, "Link")%>'>
						<%# Server.HtmlEncode(DataBinder.Eval(Container.DataItem, "Title").ToString()) %>
					</a>
				</td>
				<td>
					<%# DataBinder.Eval(Container.DataItem, "IsActive") %>
				</td>
				<td>
					<%# DataBinder.Eval(Container.DataItem, "WebCount") %>
				</td>
				<td>
					<%# DataBinder.Eval(Container.DataItem, "AggCount") %>
				</td>
				<td>
					<a href='Referrers.aspx?EntryID=<%# DataBinder.Eval(Container.DataItem, "EntryID") %>'>
						View</a>
				</td>
				<td>
					<asp:LinkButton id="lnkEdit" CausesValidation = "False" CommandName="Edit" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "EntryID") %>' Text="Edit" runat="server" />
				</td>
				<td>
					<asp:LinkButton id="lnkDelete" CausesValidation = "False" CommandName="Delete" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "EntryID") %>' Text="Delete" runat="server" />
				</td>
			</tr>
		</ItemTemplate>
		<AlternatingItemTemplate>
			<tr class="Alt">
				<td>
					<a href = '<%# DataBinder.Eval(Container.DataItem, "Link")%>'>
						<%# Server.HtmlEncode(DataBinder.Eval(Container.DataItem, "Title").ToString()) %>
					</a>
				</td>
				<td>
					<%# DataBinder.Eval(Container.DataItem, "IsActive") %>
				</td>
				<td>
					<%# DataBinder.Eval(Container.DataItem, "WebCount") %>
				</td>
				<td>
					<%# DataBinder.Eval(Container.DataItem, "AggCount") %>
				</td>
				<td>
					<a href='Referrers.aspx?EntryID=<%# DataBinder.Eval(Container.DataItem, "EntryID") %>'>
						View</a>
				</td>
				<td>
					<asp:LinkButton id="lnkEditAlt" CommandName="Edit" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "EntryID") %>' Text="Edit" runat="server" />
				</td>
				<td>
					<asp:LinkButton id="lnkDeleteAlt" CommandName="Delete" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "EntryID") %>' Text="Delete" runat="server" />
				</td>
			</tr>
		</AlternatingItemTemplate>
		<FooterTemplate>
			</table>
		</FooterTemplate>
	</asp:Repeater>
	<P id="NoMessagesLabel" runat="server" visible="false">No entries found.</P>
	<ANW:Pager id="ResultsPager" runat="server" UseSpacer="False" PrefixText="<div>Goto page</div>"
		LinkFormatActive='<a href="{0}" class="Current">{1}</a>' UrlFormat="EditPosts.aspx?pg={0}"
		CssClass="Pager"></ANW:Pager>
	<BR class="Clear">
</ANW:AdvancedPanel>
<ANW:AdvancedPanel id="Edit" runat="server" LinkImageCollapsed="~/admin/resources/toggle_gray_down.gif"
	LinkImage="~/admin/resources/toggle_gray_up.gif" LinkStyle="Image" DisplayHeader="True" HeaderCssClass="CollapsibleTitle"
	Collapsible="False" HeaderText="Edit Post">
	<DIV class="Edit"><!-- DEBUG -->
		<P class="Label">
			<asp:HyperLink id="hlEntryLink" Runat="server" Target="_blank"></asp:HyperLink></P>
		<P class="Label">Post Title&nbsp;
			<asp:RequiredFieldValidator id="valTitleRequired" runat="server" ErrorMessage="Your post must have a title"
				ForeColor="#990066" ControlToValidate="txbTitle"></asp:RequiredFieldValidator></P>
		<P>
			<asp:TextBox id="txbTitle" runat="server" MaxLength="250" width="98%" columns="255"></asp:TextBox></P>
		<P class="Label">Post Body&nbsp;
			<asp:RequiredFieldValidator id="valftbBodyRequired" runat="server" ErrorMessage="Your post must have a body"
				ForeColor="#990066" ControlToValidate="ftbBody"></asp:RequiredFieldValidator></P>
		<P>
			<DIV id="FTBMozWorkaround" onmouseout="FTB_CopyHtmlToHidden('Editor_Edit_ftbBody')">
				<FTB:FreeTextBox id="ftbBody" runat="server" width="99%"></FTB:FreeTextBox></DIV>
		<P></P>
		<P class="Label">Individual Categories</P>
		<P>
			<asp:CheckBoxList id="cklCategories" runat="server" RepeatDirection="Horizontal" RepeatColumns="5"></asp:CheckBoxList></P>
		<asp:Panel id="GlobalCategoriesSection" Runat="server" Visible="False">
			<P class="Label">Global Categories</P>
			<P>
				<asp:CheckBoxList id="chkGlobalCategories" runat="server" RepeatDirection="Horizontal" RepeatColumns="5"></asp:CheckBoxList></P>
		</asp:Panel>
		<DIV>
			<asp:LinkButton id="lkbPost" runat="server" CssClass="Button" Text="Post"></asp:LinkButton>
			<asp:LinkButton id="lkbCancel" runat="server" CssClass="Button" Text="Cancel" CausesValidation="False"></asp:LinkButton><BR>
			&nbsp;
		</DIV>
	</DIV>
	<ANW:AdvancedPanel id="Advanced" runat="server" Collapsible="True" LinkText="[toggle]" HeaderCssClass="CollapsibleTitle"
		DisplayHeader="True" LinkBeforeHeader="True" LinkStyle="Image" HeaderText="Advanced Options" HeaderTextCssClass="CollapsibleTitle"
		Collapsed="true" BodyCssClass="Edit">
		<P class="ValueLabel">
			<asp:CheckBox id="ckbPublished" runat="server" Text="Published" textalign="Left"></asp:CheckBox>
			<asp:CheckBox id="chkComments" runat="server" Text="Allow Comments" textalign="Left"></asp:CheckBox>
			<asp:CheckBox id="chkDisplayHomePage" runat="server" Text="Display on HomePage" textalign="Left"></asp:CheckBox>
			<asp:CheckBox id="chkMainSyndication" runat="server" Text="Syndicate on Main Feed" textalign="Left"></asp:CheckBox>
			<asp:CheckBox id="chkSyndicateDescriptionOnly" runat="server" Text="Syndicate Description Only"
				textalign="Left"></asp:CheckBox>
			<asp:CheckBox id="chkIsAggregated" runat="server" Text="Include in Aggregated Site" textalign="Left"></asp:CheckBox></P>
		<P class="Label">EntryName (page name)
			<asp:RegularExpressionValidator id="vRegexEntryName" runat="server" ControlToValidate="txbEntryName" Text="Invalid EntryName Format. Must match the follwing pattern: ^[a-zA-Z][\w-]{1,149}$"
				ValidationExpression="^[a-zA-Z][\w-]{1,149}$"></asp:RegularExpressionValidator></P>
		<P>
			<asp:TextBox id="txbEntryName" runat="server" MaxLength="150" width="98%" columns="255"></asp:TextBox></P>
		<P class="Label">Excerpt</P>
		<P>
			<asp:TextBox id="txbExcerpt" runat="server" MaxLength="500" width="98%" textmode="MultiLine"
				rows="5"></asp:TextBox></P>
		<P class="Label">Title Url</P>
		<P>
			<asp:TextBox id="txbTitleUrl" runat="server" MaxLength="250" width="98%" columns="255"></asp:TextBox></P>
		<P class="Label">Source Name</P>
		<P>
			<asp:TextBox id="txbSourceName" runat="server" width="98%" columns="255"></asp:TextBox></P>
		<P class="Label">Source Url</P>
		<P>
			<asp:TextBox id="txbSourceUrl" runat="server" width="98%" columns="255"></asp:TextBox></P>
	</ANW:AdvancedPanel>
</ANW:AdvancedPanel>
