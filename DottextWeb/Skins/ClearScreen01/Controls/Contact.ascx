<%@ Control Language="c#" AutoEventWireup="false" Inherits="Dottext.Web.UI.Controls.Contact" %>
<div class = "contact">
Please use the form below if you have any comments, questions, or suggestions.
<br>
<TABLE id="CommentForm" class = "commentsTable" cellSpacing="2" cellPadding="0"  border="0" >
	<TR>
		<TD width="75">Name</TD>
		<TD width=400px><asp:TextBox id="tbName" Size = "50" runat="server" Width="400px"></asp:TextBox></TD>
	</TR>
	<TR>
		<TD width="75">Email</TD>
		<TD>
			<asp:TextBox id="tbEmail" runat="server" Size = "50" Width="400px"></asp:TextBox>
			<asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" ErrorMessage="Please enter your email address" ControlToValidate="tbEmail" Display="Dynamic">*</asp:RequiredFieldValidator>
			<asp:RegularExpressionValidator id="RegularExpressionValidator1" runat="server" ErrorMessage="Invalid email address format" ControlToValidate="tbEmail" Display="Dynamic" ValidationExpression="^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$">*</asp:RegularExpressionValidator>
		</TD>
	</TR>
	<TR>
		<TD>Subject</TD>
		<TD><asp:TextBox id="tbSubject" runat="server" Size = "50" Width="400px"></asp:TextBox></TD>
	</TR>
	<TR>
		<TD>Message</TD>
		<TD>
			<asp:TextBox id="tbMessage" runat="server" Rows = "10" Columns = "40" Width="400px" TextMode="MultiLine" Height="131px"></asp:TextBox>
			<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ErrorMessage="Please tell me something" ControlToValidate="tbMessage" Display="Dynamic">*</asp:RequiredFieldValidator>
		</TD>
	</TR>

	<TR>
		<TD><asp:Button id="btnSend" runat="server" Text="Send"></asp:Button></TD>
		<TD>
			<asp:Label id="lblMessage" runat="server" ForeColor="Red"></asp:Label>
			<asp:ValidationSummary id="ValidationSummary1" runat="server" HeaderText="There is an error:"></asp:ValidationSummary>
		</TD>
	</TR>
</TABLE>
</div>