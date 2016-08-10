<%@ Register TagPrefix="ANW" Namespace="Dottext.Web.Admin.WebUI" Assembly="Dottext.Web.Admin" %>
<%@ Register TagPrefix="EED" TagName="EntryEditor" Src="UserControls/EntryEditor.ascx" %>
<%@ Page language="c#" Codebehind="EditImports.aspx.cs" AutoEventWireup="false" Inherits="Dottext.Web.Admin.Pages.EditImports" %>
<ANW:Page id="PageContainer" CategoryType="StoryCollection" TabSectionID="Articles" runat="server">
	<EED:EntryEditor id="Editor" runat="server" CategoryType="StoryCollection" EntryType="Article" ResultsTitle="Articles"></EED:EntryEditor>
</ANW:Page>
