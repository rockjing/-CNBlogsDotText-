<%@ Control Language="c#" AutoEventWireup="false" Inherits="Dottext.Web.UI.Controls.Contact" %>
<h1 class="block_title">Contact me</h1>
<div class="block">
	<div class="post">
		<div class="moreinfo">
			<div>��������κ����ۡ����⡢���飬�뷢�ʼ�����:</div>
			<div id="postcomment">
				<div>
					����:<br>
					<asp:TextBox id="tbName" Size = "50" runat="server" Width="400px" CssClass="text"></asp:TextBox>
				</div>
				<div>
					Email<br>
					<asp:TextBox id="tbEmail" runat="server" Size = "50" Width="400px" CssClass="text"></asp:TextBox>
					<asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" ErrorMessage="Please enter your email address" ControlToValidate="tbEmail" Display="Dynamic">*</asp:RequiredFieldValidator>
					<asp:RegularExpressionValidator id="RegularExpressionValidator1" runat="server" ErrorMessage="Invalid email address format" ControlToValidate="tbEmail" Display="Dynamic" ValidationExpression="^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$">*</asp:RegularExpressionValidator>
				</div>
				<div>
					����:<br>
					<asp:TextBox id="tbSubject" runat="server" Size = "50" Width="400px" CssClass="text"></asp:TextBox><br>
				</div>
				<div>
					����:<br>
					<asp:TextBox id="tbMessage" runat="server" Rows = "10" Columns = "40" Width="400px" TextMode="MultiLine" Height="131px"></asp:TextBox>
					<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ErrorMessage="Please tell me something" ControlToValidate="tbMessage" Display="Dynamic">*</asp:RequiredFieldValidator></asp:TextBox>
				</div>
				<div>
					<asp:Button id="btnSend" runat="server" Text="����"></asp:Button>
				</div>
				<div>
					<asp:Label id="lblMessage" runat="server" ForeColor="Red"></asp:Label>
					<asp:ValidationSummary id="ValidationSummary1" runat="server" HeaderText="���ִ���:"></asp:ValidationSummary>
				</div>
			</div>
		</div>
	</div>
	<div class="block_footer">&nbsp;</div>
</div>