<%@ Register TagPrefix="ANW" Namespace="Dottext.Web.Admin.WebUI" Assembly="Dottext.Web.Admin" %>
<%@ Page language="c#" Codebehind="ManageCategory.aspx.cs" AutoEventWireup="false" Inherits="Dottext.Web.Admin.Pages.ManageCategory" %>
<%@ Register TagPrefix="iewc" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls, Version=1.0.2.226, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<ANW:PAGE id="PageContainer" runat="server" TabSectionID="ManageSite">
	<ANW:MessagePanel id="Messages" runat="server"></ANW:MessagePanel>
	<ANW:AdvancedPanel id="GlobalCats" runat="server" DisplayHeader="true" LinkBeforeHeader="True" LinkStyle="Image"
		HeaderCssClass="CollapsibleHeader" Collapsible="true" HeaderText="��վ�������">
		<TABLE id="Table1" cellSpacing="0" cellPadding="1" width="98%" align="center" border="1">
			<TR>
				<TD colSpan="2">
					<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ControlToValidate="txbCategory" ErrorMessage="�������Ʋ�Ϊ��"></asp:RequiredFieldValidator></TD>
			</TR>
			<TR>
				<TD vAlign="top" bgColor="#f5f8fe" colSpan="2" height="19">��������:
					<asp:textbox id="txbCategory" runat="server"></asp:textbox>&nbsp;&nbsp;
					<asp:button id="btnAdd" runat="server" Text="����"></asp:button>&nbsp;&nbsp;
					<asp:button id="btnRename" runat="server" Text="�޸�" CausesValidation="False"></asp:button>&nbsp;&nbsp;
					<asp:button id="btnDel" runat="server" Text="ɾ��" CausesValidation="False"></asp:button>&nbsp;&nbsp;
					<asp:Button id="btnCategoryConfig" runat="server" Text="����"></asp:Button></TD>
			</TR>
			<TR>
				<TD vAlign="top" bgColor="#f5f8fe" height="600">
					<iewc:TreeView id="TreeViewCategory" runat="server"></iewc:TreeView></TD>
				<TD bgColor="#f5f8fe" height="600"><IFRAME id="detail" name="detail" frameBorder="0" width="100%" height="100%" runat="server"></IFRAME></TD>
			</TR>
		</TABLE>
	</ANW:AdvancedPanel>
</ANW:PAGE>
