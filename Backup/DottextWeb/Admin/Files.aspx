<%@ Page language="c#" Codebehind="Files.aspx.cs" AutoEventWireup="false" Inherits="Dottext.Web.Admin.Pages.Files" %>
<%@ Register TagPrefix="ANW" Namespace="Dottext.Web.Admin.WebUI" Assembly="Dottext.Web.Admin" %>
<ANW:PAGE id="PageContainer" TabSectionID="Files" runat="server">
	<ANW:MessagePanel id="Messages" runat="server"></ANW:MessagePanel>
	<ANW:AdvancedPanel id="Results" runat="server" Collapsible="true" LinkText="[toggle]" HeaderText="Files"
		HeaderCssClass="CollapsibleHeader" DisplayHeader="True" LinkBeforeHeader="True" LinkStyle="Image">
		<asp:Repeater id="fileRepeater" runat="server">
			<HeaderTemplate>
				<table id="Listing" class="Listing" cellSpacing="0" cellPadding="0" border="0">
					<tr>
						<th>
							File</th>
						<th>
							Links To</th>
						<th>
							Size</th>
						<th width="50">
							&nbsp;</th>
						<th width="50">
							&nbsp;</th>
					</tr>
			</HeaderTemplate>
			<ItemTemplate>
				<tr>
					<td><%# DataBinder.Eval(Container.DataItem, "Name").ToString().Substring(Container.DataItem.ToString().LastIndexOf("\\") + 1) %></td>
					<td><%# DataBinder.Eval(Container.DataItem, "WebURL") %></td>
					<td><%# DataBinder.Eval(Container.DataItem, "SizeKB") %></td>
					<td><a href='<%# DataBinder.Eval(Container.DataItem, "WebURL") %>'>Download</a></td>
					<td>
						<asp:linkbutton id="lnkDelete" CommandName="Delete" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "Name") %>' Text="Delete" runat="server" /></td>
				</tr>
			</ItemTemplate>
			<FooterTemplate>
			</table>
			</FooterTemplate>
		</asp:Repeater>
	</ANW:AdvancedPanel>
	<ANW:AdvancedPanel id="AddFiles" runat="server" Collapsible="True" HeaderText="Add New File" HeaderCssClass="CollapsibleTitle"
		DisplayHeader="true" LinkBeforeHeader="True" LinkStyle="Image" LinkImage="~/admin/resources/toggle_gray_up.gif"
		LinkImageCollapsed="~/admin/resources/toggle_gray_down.gif" BodyCssClass="Edit">
		<LABEL class="Block">Local File Location</LABEL>
		<INPUT class="FileUpload" id="myFile" type="file" size="82" name="myFile" runat="server">
		<BR class="Clear">
		<DIV style="MARGIN-TOP: 8px">
			<asp:linkbutton id="lbkAddFile" runat="server" CssClass="Button" Text="Add"></asp:linkbutton><BR>
			&nbsp;
		</DIV>
		<DIV>
			<TABLE height="10" cellSpacing="5" cellPadding="0" border="0">
				<TR>
					<TD>&nbsp;</TD>
					<TD>�����ϴ��ļ�����:
						<asp:Literal id="ltFileType" Runat="server"></asp:Literal></TD>
					<TD>�ռ�������:
						<asp:Literal id="TotalSize" Runat="server"></asp:Literal>KB</TD>
					<TD>һ���ϴ��ļ���С����:
						<asp:Literal id="OnceSize" Runat="server"></asp:Literal>KB</TD>
					<TD>Ŀǰ���ÿռ�:
						<asp:Literal id="UsedSize" Runat="server"></asp:Literal>KB</TD>
					<TD>ʣ��ռ�:
						<asp:Literal id="LeftSize" Runat="server"></asp:Literal>KB</TD>
				</TR>
			</TABLE>
		</DIV>
	</ANW:AdvancedPanel>
</ANW:PAGE>
