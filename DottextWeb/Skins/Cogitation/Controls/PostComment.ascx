<%@ Control Language="c#" AutoEventWireup="false" Inherits="Dottext.Web.UI.Controls.PostComment" %>
<div id="CommentForm">
	<h3>ÆÀÂÛ</h3>
	<TABLE class="CommentForm">
		<TR>
			<TD width="75">Title:</TD>
			<TD>
				<asp:TextBox id="tbTitle" runat="server" Size = "40" Width="300px"></asp:TextBox>
				<asp:RequiredFieldValidator id="RequiredFieldValidator1" Display="Dynamic" runat="server" ErrorMessage="<br>Please enter a title" ControlToValidate="tbTitle"></asp:RequiredFieldValidator>
			</TD>
		</TR>
		<TR>
			<TD width="75">Name:</TD>
			<TD>
				<asp:TextBox id="tbName" runat="server" Size = "40" Width="300px"></asp:TextBox>
				<asp:RequiredFieldValidator id="RequiredFieldValidator2" Display="Dynamic" runat="server" ErrorMessage="<br>Please enter your name" ControlToValidate="tbName"></asp:RequiredFieldValidator>
			</TD>
		</TR>
		<TR>
			<TD>Url:</TD>
			<TD>
				<asp:TextBox id="tbUrl" runat="server" Size = "40" Width="300px"></asp:TextBox>
			</TD>
		</TR>
		<TR>
			<TD colSpan="3">Comments:&nbsp;
				<asp:RequiredFieldValidator id="RequiredFieldValidator3" runat="server" Display="Dynamic" ErrorMessage="<br>Please enter a comment" ControlToValidate="tbComment"></asp:RequiredFieldValidator>
				<BR>
				<asp:TextBox id="tbComment" runat="server" Rows = "10" Columns = "50" Width="381px" Height="193px" TextMode="MultiLine"></asp:TextBox>
			</TD>
		</TR>
		<TR>
			<TD colspan="3">
				<asp:Button  CssClass="Button" id="btnSubmit" runat="server" Text="Submit"></asp:Button>&nbsp;&nbsp;&nbsp;
				<asp:CheckBox id="chkRemember" runat="server" Text="Remember Me?"></asp:CheckBox></TD>
		</TR>
		<tr>
			<TD>
				<asp:Label id="Message" runat="server" ForeColor="Red"></asp:Label></TD>
		</tr>
	</TABLE>
</div>
