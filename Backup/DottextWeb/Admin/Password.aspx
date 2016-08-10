<%@ Page language="c#" Codebehind="Password.aspx.cs" AutoEventWireup="false" Inherits="Dottext.Web.Admin.Pages.Password" %>
<%@ Register TagPrefix="ANW" Namespace="Dottext.Web.Admin.WebUI" Assembly="Dottext.Web.Admin" %>
<ANW:Page runat="server" id="PageContainer" TabSectionID="Options">
	<ANW:MessagePanel id="Messages" runat="server"></ANW:MessagePanel>
	<ANW:AdvancedPanel id="Results" runat="server" Collapsible="False" HeaderCssClass="CollapsibleHeader"
		DisplayHeader="True" LinkStyle="Image" HeaderText="Password">
		<DIV class="Edit">
			<P class="Label">Current Password
				<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ForeColor="#990066" ErrorMessage="Please enter your current passowrd"
					ControlToValidate="tbCurrent" Display="Dynamic"></asp:RequiredFieldValidator></P>
			<P>
				<asp:TextBox id="tbCurrent" runat="server" Width="200px" TextMode="Password"></asp:TextBox></P>
			<P class="Label">New Password
				<asp:RequiredFieldValidator id="RequiredFieldValidator5" runat="server" ForeColor="#990066" ErrorMessage="Please enter a password"
					ControlToValidate="tbPassword" Display="Dynamic"></asp:RequiredFieldValidator>
				<asp:CompareValidator id="CompareValidator1" runat="server" ForeColor="#990066" ErrorMessage="Your passwords do not match"
					ControlToValidate="tbPasswordConfirm" Display="Dynamic" ControlToCompare="tbPassword"></asp:CompareValidator></P>
			<P>
				<asp:TextBox id="tbPassword" runat="server" Width="200px" TextMode="Password"></asp:TextBox></P>
			<P class="Label">Confirm Password
				<asp:RequiredFieldValidator id="RequiredFieldValidator6" runat="server" ForeColor="#990066" ErrorMessage="Please confirm your password"
					ControlToValidate="tbPasswordConfirm" Display="Dynamic"></asp:RequiredFieldValidator></P>
			<P>
				<asp:TextBox id="tbPasswordConfirm" runat="server" Width="200px" TextMode="Password"></asp:TextBox></P>
			<DIV>
				<asp:LinkButton id="btnSave" runat="server" Text="Save" CssClass="Button"></asp:LinkButton><BR>
				<BR>
			</DIV>
		</DIV>
	</ANW:AdvancedPanel>
</ANW:Page>
