<%@ Control Language="c#" AutoEventWireup="false" Codebehind="PostRate.ascx.cs" Inherits="Dottext.Web.UI.Controls.PostRate" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<div id="commentform"><FONT face="����"></FONT><br>
	<br>
	<TABLE cellSpacing="0" cellPadding="0" border="0">
		<TR>
			<TD colSpan="3"><strong>����</strong>
			</TD>
		</TR>
		<TR>
			<td>��</td>
			<TD vAlign="bottom"><asp:radiobuttonlist id="rbtRate" TextAlign="Left" RepeatDirection="Horizontal" runat="server">
					<asp:ListItem Value="1">1</asp:ListItem>
					<asp:ListItem Value="2">2</asp:ListItem>
					<asp:ListItem Value="3">3</asp:ListItem>
					<asp:ListItem Value="4">4</asp:ListItem>
					<asp:ListItem Value="5">5</asp:ListItem>
					<asp:ListItem Value="6">6</asp:ListItem>
					<asp:ListItem Value="7">7</asp:ListItem>
					<asp:ListItem Value="8">8</asp:ListItem>
					<asp:ListItem Value="9">9</asp:ListItem>
				</asp:radiobuttonlist></TD>
			<td>��</td>
		</TR>
		<TR>
			<TD colSpan="3" align="left"><asp:button id="btnSubmit" runat="server" CausesValidation="False" CssClass="commentTextBox"
					Text="����"></asp:button></TD>
		</TR>
	</TABLE>
	<br>
	<TABLE cellSpacing="0" cellPadding="0" border="0" height="30" runat="server" id="ScoreTable1">
		<tr>
			<td>ƽ������:&nbsp;<strong><asp:Literal ID="LiteralAverage" Runat="server"></asp:Literal></strong></td>
		</tr>
	</TABLE>
	<TABLE cellSpacing="0" cellPadding="0" border="0" runat="server" id="ScoreTable">
	</TABLE>
	<TABLE cellSpacing="0" cellPadding="0" border="0" height="30" runat="server" id="ScoreTable3">
		<tr>
			<td><strong><asp:Literal ID="LiteralPeople" Runat="server"></asp:Literal></strong>&nbsp;�˲���������</td>
		</tr>
	</TABLE>
</div>
