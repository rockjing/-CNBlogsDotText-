<%@ Register TagPrefix="ANW" Namespace="Dottext.Web.Admin.WebUI" Assembly="Dottext.Web.Admin" %>
<%@ Page language="c#" Codebehind="EditFavorite.aspx.cs" AutoEventWireup="false" Inherits="Dottext.Web.Admin.Pages.EditFavorite" %>
<ANW:PAGE id="PageContainer" CategoryType="FavoriteCollention" TabSectionID="Favorites" runat="server">
	<FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT>
	<ANW:MessagePanel id="Messages" runat="server">
		<FONT face="宋体"></FONT>
	</ANW:MessagePanel>
	<ANW:AdvancedPanel id="Results" runat="server" LinkStyle="Image" LinkBeforeHeader="True" DisplayHeader="True"
		HeaderCssClass="CollapsibleHeader" HeaderText="收藏夹" LinkText="[toggle]" Collapsible="True">
		<ASP:Repeater id="rprSelectionList" runat="server">
			<HeaderTemplate>
				<table id="Listing" class="Listing" cellSpacing="0" cellPadding="0" border="0" style="<%= CheckHiddenStyle() %>">
					<tr>
						<th>
							标题</th>
						<th width="50">
							&nbsp;</th>
						<th width="50">
							&nbsp;</th>
					</tr>
			</HeaderTemplate>
			<ItemTemplate>
				<tr>
					<td>
						<asp:HyperLink Runat="server" CssClass="titlelink" NavigateUrl='<%# DataBinder.Eval(Container.DataItem, "Url") %>' Text='<%# DataBinder.Eval(Container.DataItem, "Title") %>' ID="LinkTitle">
						</asp:HyperLink>
					</td>
					<td>
						<asp:linkbutton id="lnkEdit" CommandName="Edit" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "LinkID") %>' Text="Edit" runat="server" /></td>
					<td>
						<asp:linkbutton id="lnkDelete" CommandName="Delete" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "LinkID") %>' Text="Delete" runat="server" /></td>
				</tr>
			</ItemTemplate>
			<FooterTemplate>
				</table>
			</FooterTemplate>
		</ASP:Repeater>
		<ANW:Pager id="ResultsPager" runat="server" UseSpacer="False" PrefixText="<div>Goto page</div>"
			LinkFormatActive='<a href="{0}" class="Current">{1}</a>' UrlFormat="EditFavorite.aspx?pg={0}"
			CssClass="Pager"></ANW:Pager>
		<BR class="Clear">
	</ANW:AdvancedPanel>
	<ANW:AdvancedPanel id="Edit" runat="server" LinkStyle="Image" DisplayHeader="True" HeaderCssClass="CollapsibleTitle"
		HeaderText="编辑收藏夹" Collapsible="False">
		<DIV class="Edit">
			<TABLE width="100%" border="0">
				<TBODY>
					<TR>
						<TD>
							<asp:Label id="lblEntryID" runat="server" visible="false"></asp:Label></TD>
					</TR>
					<TR>
						<TD>Link Title
							<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ErrorMessage="Your link must have a title"
								ForeColor="#990066" ControlToValidate="txbTitle"></asp:RequiredFieldValidator></TD>
					</TR>
					<TR>
						<TD>
							<asp:TextBox id="txbTitle" runat="server" width="98%" columns="255"></asp:TextBox></TD>
					</TR>
					<TR>
						<TD>Web Url
							<asp:RequiredFieldValidator id="Requiredfieldvalidator2" runat="server" ErrorMessage="Your link must have a url"
								ForeColor="#990066" ControlToValidate="txbUrl"></asp:RequiredFieldValidator></TD>
					</TR>
					<TR>
						<TD>Rss Url
							<asp:TextBox id="txbRss" runat="server" width="98%" columns="255"></asp:TextBox></TD>
					</TR>
					<TR>
						<TD>Categories</TD>
					</TR>
					<TR>
						<TD>
							<ASP:DropDownList id="ddlCategories" runat="server"></ASP:DropDownList></TD>
					</TR>
					<TR>
						<TD>Visible
							<asp:CheckBox id="ckbIsActive" runat="server" textalign="Left"></asp:CheckBox>&nbsp; 
							New Window
							<asp:CheckBox id="chkNewWindow" runat="server" textalign="Left"></asp:CheckBox></TD>
					</TR>
					<TR>
						<TD>
							<asp:LinkButton id="lkbPost" runat="server" CssClass="Button" Text="Post"></asp:LinkButton>
							<asp:LinkButton id="lkbCancel" runat="server" CssClass="Button" Text="Cancel"></asp:LinkButton><BR>
							&nbsp;
						</TD>
					</TR>
					<TR>
						<TD>
							<DIV></DIV>
	</ANW:AdvancedPanel>
</ANW:PAGE></TD></TR></TBODY>
<DIV></DIV>
<DIV></DIV>
<DIV></DIV>
</DIV>
