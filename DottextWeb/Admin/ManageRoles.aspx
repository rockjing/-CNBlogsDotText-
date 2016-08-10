<%@ Register TagPrefix="ANW" Namespace="Dottext.Web.Admin.WebUI" Assembly="Dottext.Web.Admin" %>
<%@ Page language="c#" Codebehind="ManageRoles.aspx.cs" AutoEventWireup="false" Inherits="Dottext.Web.Admin.Pages.ManageRoles" %>
<ANW:PAGE id="PageContainer" TabSectionID="ManageSite" runat="server">
	<ANW:MessagePanel id="Messages" runat="server"></ANW:MessagePanel>
	<ANW:AdvancedPanel id="RolesGroup" runat="server" Collapsible="true" LinkText="[toggle]" HeaderCssClass="CollapsibleHeader"
		DisplayHeader="true" LinkBeforeHeader="True" LinkStyle="Image" HeaderText="权限组">权限组： 
<asp:dropdownlist id="ddlModuleList" runat="server" AutoPostBack="True"></asp:dropdownlist></ANW:AdvancedPanel>
	<ANW:AdvancedPanel id="Roles" runat="server" Collapsible="true" LinkText="[toggle]" HeaderCssClass="CollapsibleHeader"
		DisplayHeader="true" LinkBeforeHeader="True" LinkStyle="Image" HeaderText="权限组用户列表" Visible="false">
<asp:repeater id="rptRoleUsers" runat="server">
			<HeaderTemplate>
				<table id="Listing" class="Listing" cellSpacing="0" cellPadding="0" border="0">
					<tr>
						<th width="70">
							用户ID</th>
						<th width="200">
							用户名</th>
						<th width="100">
							操作</th>
					</tr>
			</HeaderTemplate>
			<ItemTemplate>
				<tr>
					<td>
						<%# DataBinder.Eval(Container.DataItem, "BlogID") %>
					</td>
					<td>
						<%# DataBinder.Eval(Container.DataItem, "UserName") %>
					</td>
					<td>
						<asp:LinkButton id="lbDelete" CausesValidation = "False" CommandName="Delete" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "BlogID") %>' Text="排除" runat="server" />
					</td>
				</tr>
			</ItemTemplate>
			<AlternatingItemTemplate>
				<tr class="Alt">
					<td>
						<%# DataBinder.Eval(Container.DataItem, "BlogID") %>
					</td>
					<td>
						<%# DataBinder.Eval(Container.DataItem, "UserName") %>
					</td>
					<td>
						<asp:LinkButton id="lbDelete2" CausesValidation = "False" CommandName="Delete" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "BlogID") %>' Text="排除" runat="server" />
					</td>
				</tr>
			</AlternatingItemTemplate>
			<FooterTemplate>
	</TABLE>
			</FooterTemplate>
		</asp:repeater>用户名： 
<asp:TextBox id="tbUserName" runat="server"></asp:TextBox>
<asp:Button id="btnAddUserToRole" runat="server" Enabled="False" Text="添加到该组"></asp:Button></ANW:AdvancedPanel>
</ANW:PAGE>
