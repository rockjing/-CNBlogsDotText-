<%@ Control Language="c#" AutoEventWireup="false" Inherits="Dottext.Web.UI.Controls.PostComment" %>
<div id="commentform">
<TABLE cellSpacing="1" cellPadding="1"  border="0" >
	<TR>
		<TD width="75">Title</TD>
		<TD>
			<asp:TextBox id="tbTitle" runat="server" Size = "40" Width="300px"></asp:TextBox></TD>
		<TD>
			<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ErrorMessage="Please enter a title" ControlToValidate="tbTitle"></asp:RequiredFieldValidator></TD>
	</TR>
	<TR>
		<TD width="75">Name</TD>
		<TD>
			<asp:TextBox id="tbName" runat="server" Size = "40" Width="300px"></asp:TextBox></TD>
		<TD>
			<asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" ErrorMessage="Please enter your name" ControlToValidate="tbName"></asp:RequiredFieldValidator></TD>
	</TR>
	<TR>
		<TD>Url</TD>
		<TD>
			<asp:TextBox id="tbUrl" runat="server" Size = "40" Width="300px"></asp:TextBox></TD>
		<TD></TD>
	</TR>
	<TR>
		<TD colSpan="3">Comments&nbsp;
			<asp:RequiredFieldValidator id="RequiredFieldValidator3" runat="server" ErrorMessage="Please enter a comment" ControlToValidate="tbComment"></asp:RequiredFieldValidator><BR>
			<asp:TextBox id="tbComment" runat="server" Rows = "10" Columns = "50" Width="400px" Height="193px" TextMode="MultiLine"></asp:TextBox></TD>
	</TR>
	<TR>
		<TD colSpan="3">
			<asp:CheckBox id="chkRemember" runat="server" Text="Remember Me?"></asp:CheckBox></TD>
	</TR>
	<TR>
		<TD>
			<asp:Button id="btnSubmit" runat="server" Text="Submit"></asp:Button></TD>
		<TD colspan="2">
			<asp:Label id="Message" runat="server" ForeColor="Red"></asp:Label></TD>
	</TR>
</TABLE>
</div>