<%@ Control Language="c#" AutoEventWireup="false" Inherits="Dottext.Web.UI.Controls.PostComment" %>
<!--done-->
<div class = "comments">
Post a new comment about this topic
<br>
<TABLE id="CommentForm" class = "commentsTable" cellSpacing="2" cellPadding="0"  border="0" >
	<TR>
		<TD width="75">Title</TD>
		<TD width=330px><asp:TextBox id="tbTitle" runat="server" Size = "40" Width="322px"></asp:TextBox></TD>
		<TD><asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ErrorMessage="Please enter a title" ControlToValidate="tbTitle"></asp:RequiredFieldValidator></TD>
	</TR>
	<TR>
		<TD width="75">Name</TD>
		<TD><asp:TextBox id="tbName" runat="server" Size = "40" Width="322px"></asp:TextBox></TD>
		<TD><asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" ErrorMessage="Please enter your name" ControlToValidate="tbName"></asp:RequiredFieldValidator></TD>
	</TR>
	<TR>
		<TD>Url</TD>
		<TD><asp:TextBox id="tbUrl" runat="server" Size = "40" Width="322px"></asp:TextBox></TD>
		<TD></TD>
	</TR>
	<TR>
		<TD colSpan="3"><br>Comments&nbsp;
			<asp:RequiredFieldValidator id="RequiredFieldValidator3" runat="server" ErrorMessage="Please enter a comment" ControlToValidate="tbComment"></asp:RequiredFieldValidator><BR>
			<asp:TextBox id="tbComment" runat="server" Rows = "6" Columns = "50" Width="400px"  TextMode="MultiLine"></asp:TextBox>
		</TD>
	</TR>

	<TR>
		<TD colspan=3><asp:Button id="btnSubmit" runat="server" Text="Submit"></asp:Button>&nbsp;&nbsp;&nbsp;<asp:CheckBox id="chkRemember" runat="server" Text="Remember Me?"></asp:CheckBox></TD>
	</TR>
	<TR><TD colSpan="3"><asp:Label id="Message" runat="server" ForeColor="Red"></asp:Label></TD></TR>	
</TABLE>
</div>