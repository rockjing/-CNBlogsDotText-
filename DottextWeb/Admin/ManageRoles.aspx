<%@ Register TagPrefix="ANW" Namespace="Dottext.Web.Admin.WebUI" Assembly="Dottext.Web.Admin" %>
<%@ Page language="c#" Codebehind="ManageRoles.aspx.cs" AutoEventWireup="false" Inherits="Dottext.Web.Admin.Pages.ManageRoles" %>
<ANW:PAGE id="PageContainer" TabSectionID="ManageSite" runat="server">
	<ANW:MessagePanel id="Messages" runat="server"></ANW:MessagePanel>
	<ANW:AdvancedPanel id="RolesGroup" runat="server" Collapsible="true" LinkText="[toggle]" HeaderCssClass="CollapsibleHeader"
		DisplayHeader="true" LinkBeforeHeader="True" LinkStyle="Image" HeaderText="Ȩ����">Ȩ���飺 
<asp:dropdownlist id="ddlModuleList" runat="server" AutoPostBack="True"></asp:dropdownlist></ANW:AdvancedPanel>
	<ANW:AdvancedPanel id="Roles" runat="server" Collapsible="true" LinkText="[toggle]" HeaderCssClass="CollapsibleHeader"
		DisplayHeader="true" LinkBeforeHeader="True" LinkStyle="Image" HeaderText="Ȩ�����û��б�" Visible="false">
<asp:repeater id="rptRoleUsers" runat="server">
			<HeaderTemplate>
				<table id="Listing" class="Listing" cellSpacing="0" cellPadding="0" border="0">
					<tr>
						<th width="70">
							�û�ID</th>
						<th width="200">
							�û���</th>
						<th width="100">
							����</th>
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
						<asp:LinkButton id="lbDelete" CausesValidation = "False" CommandName="Delete" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "BlogID") %>' Text="�ų�" runat="server" />
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
						<asp:LinkButton id="lbDelete2" CausesValidation = "False" CommandName="Delete" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "BlogID") %>' Text="�ų�" runat="server" />
					</td>
				</tr>
			</AlternatingItemTemplate>
			<FooterTemplate>
	</TABLE>
			</FooterTemplate>
		</asp:repeater>�û����� 
<asp:TextBox id="tbUserName" runat="server"></asp:TextBox>
<asp:Button id="btnAddUserToRole" runat="server" Enabled="False" Text="��ӵ�����"></asp:Button></ANW:AdvancedPanel>
</ANW:PAGE>
