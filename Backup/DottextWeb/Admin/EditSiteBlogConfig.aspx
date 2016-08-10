<%@ Page language="c#" Codebehind="EditSiteBlogConfig.aspx.cs" AutoEventWireup="false" Inherits="Dottext.Web.Admin.Pages.EditSiteBlogConfig" %>
<%@ Register TagPrefix="ANW" Namespace="Dottext.Web.Admin.WebUI" Assembly="Dottext.Web.Admin" %>
<ANW:PAGE id="PageContainer" TabSectionID="ManageSite" runat="server">
	<ANW:MESSAGEPANEL id="Messages" runat="server"></ANW:MESSAGEPANEL>
	<ANW:ADVANCEDPANEL id="GlobalCategoryPanel" runat="server" HeaderText="网站分类管理>>站点分类配置" Collapsible="true"
		HeaderCssClass="CollapsibleHeader" LinkStyle="Image" LinkBeforeHeader="True" DisplayHeader="true">
		<TABLE class="listing" width="400" align="center">
			<TR>
				<TD class="header" align="center" colSpan="2">站点分类配置
					<P></P>
				</TD>
			</TR>
			<TR>
				<TD>BlogID:</TD>
				<TD>
					<asp:textbox id="txbBlogID" runat="server"></asp:textbox></TD>
			</TR>
			<TR>
				<TD>分类ID:</TD>
				<TD>
					<asp:textbox id="txbCategoryID" runat="server"></asp:textbox></TD>
			</TR>
			<TR>
				<TD>分类标题:</TD>
				<TD>
					<asp:textbox id="txbTitle" runat="server"></asp:textbox></TD>
			</TR>
			<TR>
				<TD>显示文章数:</TD>
				<TD>
					<asp:textbox id="txbItemCount" runat="server"></asp:textbox></TD>
			</TR>
			<TR>
				<TD align="center" colSpan="2">
					<asp:Button id="btnSave" runat="server" CssClass="Button" Text="保存"></asp:Button>&nbsp;
					<asp:Button id="btnDelete" runat="server" CssClass="Button" Text="删除"></asp:Button>&nbsp;
					<A href="ManageGlobalCategory.aspx">返回</A></TD>
			</TR>
		</TABLE>
	</ANW:ADVANCEDPANEL>
</ANW:PAGE>
