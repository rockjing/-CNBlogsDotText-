<%@ Control Language="c#" AutoEventWireup="false" Inherits="Dottext.Web.UI.Controls.Contact" %>
<P>Please&nbsp;use the form below if you have any comments, questions, or 
	suggestions.</P>
<TABLE cellSpacing="1" cellPadding="1" border="0">
	<TR>
		<TD colspan="2">Name<asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" ErrorMessage="Please enter your email address"
				ControlToValidate="tbEmail" Display="Dynamic">*</asp:RequiredFieldValidator><br>
			<asp:TextBox id="tbName" CssClass="Textbox" Size="50" runat="server" Width="400px"></asp:TextBox></TD>
	</TR>
	<TR>
		<TD colspan="2">Email<asp:RegularExpressionValidator id="RegularExpressionValidator1" runat="server" ErrorMessage="Invalid email address format"
				ControlToValidate="tbEmail" Display="Dynamic" ValidationExpression="^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$">*</asp:RegularExpressionValidator><br>
			<asp:TextBox id="tbEmail" CssClass="Textbox" runat="server" Size="50" Width="400px"></asp:TextBox></TD>
	</TR>
	<TR>
		<TD colspan="2">Subject<br>
			<asp:TextBox id="tbSubject" CssClass="Textbox" runat="server" Size="50" Width="400px"></asp:TextBox></TD>
	</TR>
	<TR>
		<TD colspan="2">Message
			<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ErrorMessage="Please tell me something"
				ControlToValidate="tbMessage" Display="Dynamic">*</asp:RequiredFieldValidator><br>
			<asp:TextBox id="tbMessage" CssClass="Textbox" runat="server" Rows="10" Columns="40" Width="400px"
				TextMode="MultiLine" Height="131px"></asp:TextBox></TD>
	</TR>
	<TR>
		<TD valign="top">
			<asp:Button id="btnSend" CssClass="Button" runat="server" Text="Send"></asp:Button></TD>
		<TD>
			<asp:Label id="lblMessage" runat="server" ForeColor="Red"></asp:Label>
			<asp:ValidationSummary id="ValidationSummary1" runat="server" HeaderText="There is an error:"></asp:ValidationSummary></TD>
	</TR>
</TABLE>
