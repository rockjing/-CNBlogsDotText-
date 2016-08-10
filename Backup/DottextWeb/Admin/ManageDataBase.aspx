<%@ Register TagPrefix="ANW" Namespace="Dottext.Web.Admin.WebUI" Assembly="Dottext.Web.Admin" %>
<%@ Page language="c#" Codebehind="ManageDataBase.aspx.cs" AutoEventWireup="false" Inherits="Dottext.Web.Admin.Pages.ManageDataBase" %>
<ANW:PAGE id="PageContainer" TabSectionID="ManageSite" runat="server">
	<ANW:MESSAGEPANEL id="Messages" runat="server"></ANW:MESSAGEPANEL>
	<ANW:ADVANCEDPANEL id="SqlPanel" runat="server" Collapsible="true" LinkText="[toggle]" HeaderCssClass="CollapsibleHeader"
		DisplayHeader="true" LinkBeforeHeader="True" LinkStyle="Image" HeaderText="SQL" Visible="true">SQL: <BR>
<asp:TextBox id="tbSqlText" runat="server" Height="200px" TextMode="MultiLine" Width="400px"></asp:TextBox><BR>
<asp:Button id="btnExecSql" runat="server" Text="Ö´ÐÐ"></asp:Button></ANW:ADVANCEDPANEL>
</ANW:PAGE>
