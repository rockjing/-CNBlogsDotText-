<%@ Page language="c#" Codebehind="EditPosts.aspx.cs" AutoEventWireup="false" Inherits="Dottext.Web.Admin.Pages.EditPosts" %>
<%@ Register TagPrefix="EED" TagName="EntryEditor" Src="UserControls/EntryEditor.ascx" %>
<%@ Register TagPrefix="ANW" Namespace="Dottext.Web.Admin.WebUI" Assembly="Dottext.Web.Admin" %>
<ANW:PAGE id="PageContainer" runat="server" TabSectionID="Posts" CategoryType="PostCollection">
	<EED:EntryEditor id="Editor" CategoryType="PostCollection" runat="server" ResultsTitle="Posts" EntryType="BlogPost"></EED:EntryEditor>
</ANW:PAGE>
