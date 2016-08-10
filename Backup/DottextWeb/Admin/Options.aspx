<%@ Register TagPrefix="ANW" Namespace="Dottext.Web.Admin.WebUI" Assembly="Dottext.Web.Admin" %>
<%@ Page language="c#" Codebehind="Options.aspx.cs" AutoEventWireup="false" Inherits="Dottext.Web.Admin.Pages.Options" %>
<ANW:PAGE id="PageContainer" runat="server" TabSectionID="Options">
	<ANW:AdvancedPanel id="Results" runat="server" BodyCssClass="Edit" DisplayHeader="true" HeaderCssClass="CollapsibleHeader"
		HeaderText="Options" Collapsible="False">
		<BR>
		<P><A href="Configure.aspx">Configure</A>: Manage your blog.
		</P>
		<P><A href="EditKeyWords.aspx">Key Words</A>: Auto transform specific 
			words/patterns to links.
		</P>
		<P><A href="Password.aspx">Password</A>: Update your password.
		</P>
		<P><A href="Preferences.aspx">Preferences</A>: Set common preferences.
		</P>
		<BR class="Clear">
	</ANW:AdvancedPanel>
</ANW:PAGE>
