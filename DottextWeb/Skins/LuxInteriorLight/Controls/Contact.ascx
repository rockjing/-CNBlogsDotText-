<%@ Control Language="c#" AutoEventWireup="false" Inherits="Dottext.Web.UI.Controls.Contact" %>
<P>Please&nbsp;use the form below if you have any comments, questions, or 
	suggestions.</P>
	<fieldset><legend>Contact Me</legend>
<div>Name<asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" ErrorMessage="Please enter your email address"
				ControlToValidate="tbEmail" Display="Dynamic">*</asp:RequiredFieldValidator></div><div>
			<asp:TextBox id="tbName" CssClass="Textbox" Size="50" runat="server" Width="400px"></asp:TextBox></div>
	<div>Email<asp:RegularExpressionValidator id="RegularExpressionValidator1" runat="server" ErrorMessage="Invalid email address format"
				ControlToValidate="tbEmail" Display="Dynamic" ValidationExpression="^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$">*</asp:RegularExpressionValidator></div><div>
			<asp:TextBox id="tbEmail" CssClass="Textbox" runat="server" Size="50" Width="400px"></asp:TextBox></div><div>Subject</div>
			<div><asp:TextBox id="tbSubject" CssClass="Textbox" runat="server" Size="50" Width="400px"></asp:TextBox></div><div>Message<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ErrorMessage="Please tell me something"
				ControlToValidate="tbMessage" Display="Dynamic">*</asp:RequiredFieldValidator></div>
			<div>
			<asp:TextBox id="tbMessage" CssClass="Textbox" runat="server" Rows="10" Columns="40" Width="400px"
				TextMode="MultiLine" Height="131px"></asp:TextBox></div><div>
			<asp:Button id="btnSend" CssClass="Button" runat="server" Text="Send"></asp:Button></div>
			<div><asp:Label id="lblMessage" runat="server" ForeColor="Red"></asp:Label>
			<asp:ValidationSummary id="ValidationSummary1" runat="server" HeaderText="There is an error:"></asp:ValidationSummary></div></fieldset>
