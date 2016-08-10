<%@ Page language="c#" Codebehind="EditLinks.aspx.cs" AutoEventWireup="false" Inherits="Dottext.Web.Admin.Pages.EditLinks" %>
<%@ Register TagPrefix="ANW" Namespace="Dottext.Web.Admin.WebUI" Assembly="Dottext.Web.Admin" %>
<ANW:Page runat="server" id="PageContainer" TabSectionID="Links" CategoryType="LinkCollection">
	<ANW:MessagePanel id="Messages" runat="server"></ANW:MessagePanel>
	<ANW:AdvancedPanel id="Results" runat="server" Collapsible="True" LinkText="[toggle]" HeaderText="Links"
		HeaderCssClass="CollapsibleHeader" DisplayHeader="True" LinkBeforeHeader="True" LinkStyle="Image">
		<ASP:Repeater id="rprSelectionList" runat="server">
			<HeaderTemplate>
				<table id="Listing" class="Listing" cellSpacing="0" cellPadding="0" border="0" style="<%= CheckHiddenStyle() %>">
					<tr>
						<th style="text-align:center">
							Description</th>
						<th width="50" style="text-align:center">
							Url</th>
						<th width="50">
							&nbsp;</th>
						<th width="50">
							&nbsp;</th>
					</tr>
			</HeaderTemplate>
			<ItemTemplate>
				<tr>
					<td>
						<%# DataBinder.Eval(Container.DataItem, "Title") %>
					</td>
					<td>
						<asp:HyperLink Runat="server" CssClass="titlelink" NavigateUrl='<%# DataBinder.Eval(Container.DataItem, "Url") %>' Text='<%# DataBinder.Eval(Container.DataItem, "Url") %>' ID="LinkTitle">
						</asp:HyperLink>
					</td>
					<td>
						<asp:linkbutton id="lnkEdit" CommandName="Edit" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "LinkID") %>' Text="Edit" runat="server" /></td>
					<td>
						<asp:linkbutton id="lnkDelete" CommandName="Delete" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "LinkID") %>' Text="Delete" runat="server" /></td>
				</tr>
			</ItemTemplate>
			<AlternatingItemTemplate>
				<tr class="Alt">
					<td>
						<%# DataBinder.Eval(Container.DataItem, "Title") %>
					</td>
					<td>
						<asp:HyperLink Runat="server" CssClass="titlelink" NavigateUrl='<%# DataBinder.Eval(Container.DataItem, "Url") %>' Text='<%# DataBinder.Eval(Container.DataItem, "Url") %>' ID="Hyperlink1">
						</asp:HyperLink>
					</td>
					<td>
						<asp:linkbutton id="lnkEdit" CommandName="Edit" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "LinkID") %>' Text="Edit" runat="server" /></td>
					<td>
						<asp:linkbutton id="lnkDelete" CommandName="Delete" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "LinkID") %>' Text="Delete" runat="server" /></td>
				</tr>
			</AlternatingItemTemplate>
			<FooterTemplate>
				</table>
			</FooterTemplate>
		</ASP:Repeater>
		<ANW:Pager id="ResultsPager" runat="server" CssClass="Pager" UrlFormat="EditLinks.aspx?pg={0}"
			LinkFormatActive='<a href="{0}" class="Current">{1}</a>' PrefixText="<div>Goto page</div>"
			UseSpacer="False"></ANW:Pager>
		<BR class="Clear">
	</ANW:AdvancedPanel>
	<ANW:AdvancedPanel id="ImportExport" runat="server" Collapsible="True" HeaderText="Import/Export" HeaderCssClass="CollapsibleTitle"
		DisplayHeader="True" LinkBeforeHeader="True" LinkStyle="Image" visible="false" BodyCssClass="Edit">
		<DIV style="HEIGHT: 0px"><!-- IE bug hides label in following div without this -->
			<DIV>
				<DIV>
					<P class="Block"><LABEL class="Block">Local File Location (*.opml)</LABEL></P>
					<INPUT class="FileUpload" id="OpmlImportFile" type="file" size="62" name="ImageFile" runat="server">
					<P class="Label">Categories</P>
					<P>
						<ASP:DropDownList id="ddlImportExportCategories" runat="server"></ASP:DropDownList></P>
				</DIV>
				<DIV style="MARGIN-TOP: 8px">
					<asp:linkbutton id="lkbImportOpml" runat="server" CssClass="Button" Text="Import"></asp:linkbutton><A class="Button" href="Export.aspx?command=opml">Export</A>
					<BR class="Clear">
					&nbsp;
				</DIV>
	</ANW:AdvancedPanel>
	<ANW:AdvancedPanel id="Edit" runat="server" Collapsible="False" HeaderText="Edit Link" HeaderCssClass="CollapsibleTitle"
		DisplayHeader="True" LinkStyle="Image">
		<DIV class="Edit">
			<TABLE width="100%" border="0">
				<TR>
					<TD>
						<asp:Label id="lblEntryID" runat="server" visible="false"></asp:Label></TD>
				</TR>
				<TR>
					<TD>
						<asp:Label id="Label1" runat="server">Link Title</asp:Label>
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
					<TD>
						<asp:TextBox id="txbUrl" runat="server" width="98%" columns="255"></asp:TextBox></TD>
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
			</TABLE>
		</DIV>
	</ANW:AdvancedPanel>
</ANW:Page></DIV></DIV>
