<%@ Register TagPrefix="ANW" Namespace="Dottext.Web.Admin.WebUI" Assembly="Dottext.Web.Admin" %>
<%@ Page language="c#" Codebehind="Confirm.aspx.cs" AutoEventWireup="false" Inherits="Dottext.Web.Admin.Pages.Confirm" %>
<ANW:Page id="PageContainer" runat="server">
	<ANW:MessagePanel id="Messages" runat="server" ErrorIconUrl="~/admin/resources/ico_critical.gif" ErrorCssClass="ErrorPanel"
		MessageIconUrl="~/admin/resources/ico_info.gif" MessageCssClass="MessagePanel"></ANW:MessagePanel>
	<ANW:AdvancedPanel id="Header" runat="server" LinkText="[toggle list]" HeaderText="Confirm Action"
		BodyCssClass="DialogBody" HeaderCssClass="DialogTitle" CssClass="Dialog" DisplayHeader="true">
		<ASP:Label id="lblOutput" runat="server"></ASP:Label>
		<DIV style="MARGIN-TOP: 12px">
			<ASP:HyperLink id="lnkContinue" runat="server" CssClass="Button" visible="false" text="Continue"></ASP:HyperLink>
			<ASP:LinkButton id="lkbYes" runat="server" CssClass="Button" Text="Yes"></ASP:LinkButton>
			<ASP:LinkButton id="lkbNo" runat="server" CssClass="Button" Text="No"></ASP:LinkButton><BR>
			&nbsp;
		</DIV>
	</ANW:AdvancedPanel>
</ANW:Page>
