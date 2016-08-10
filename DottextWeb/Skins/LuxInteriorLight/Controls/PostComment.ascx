<%@ Control Language="c#" AutoEventWireup="false" Inherits="Dottext.Web.UI.Controls.PostComment" %>
			<fieldset><legend>Post Comment</legend>
			<div>Title</div>
			<div>
				<asp:TextBox id="tbTitle" runat="server" Size="40" Width="300px" CssClass="Textbox"></asp:TextBox><asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ErrorMessage="Please enter a title"
					ControlToValidate="tbTitle"></asp:RequiredFieldValidator></div>

			<div>Name</div>
			
				<div><asp:TextBox id="tbName" runat="server" Size="40" Width="300px" CssClass="Textbox"></asp:TextBox><asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" ErrorMessage="Please enter your name"
					ControlToValidate="tbName"></asp:RequiredFieldValidator></div>
<div>Url</div>
				<div><asp:TextBox id="tbUrl" runat="server" Size="40" Width="300px" CssClass="Textbox"></asp:TextBox></div>
			<div>Comment <asp:RequiredFieldValidator id="RequiredFieldValidator3" runat="server" ErrorMessage="Please enter a comment"
					ControlToValidate="tbComment"></asp:RequiredFieldValidator></div>
				<div> 
				<asp:TextBox id="tbComment" runat="server" Rows="10" Columns="50" Width="100%" Height="193px"
					TextMode="MultiLine"></asp:TextBox></div>
				<div><asp:Button id="btnSubmit" CssClass="Button" runat="server" Text="Submit"></asp:Button>&nbsp;<asp:CheckBox id="chkRemember" runat="server" Text="Remember Me" Checked="True"></asp:CheckBox></div><div>
				<asp:Label id="Message" runat="server" ForeColor="Red"></asp:Label></div>
</div>
</fieldset>