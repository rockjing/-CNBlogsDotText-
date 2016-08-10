<%@ Register TagPrefix="ANW" Namespace="Dottext.Web.Admin.WebUI" Assembly="Dottext.Web.Admin" %>
<%@ Register TagPrefix="EED" TagName="EntryEditor" Src="UserControls/EntryEditor.ascx" %>
<%@ Page language="c#" Codebehind="EditArticles.aspx.cs" AutoEventWireup="false" Inherits="Dottext.Web.Admin.Pages.EditArticles" %>
<ANW:Page id="PageContainer" CategoryType="StoryCollection" TabSectionID="Articles" runat="server">
	<EED:EntryEditor id="Editor" runat="server" CategoryType="StoryCollection" ResultsTitle="Articles"
		EntryType="Article"></EED:EntryEditor>
</ANW:Page>
