<%@ Page language="c#" Codebehind="InsertCode.aspx.cs" AutoEventWireup="false" Inherits="Dottext.Web.InsertCode" %>
<%@ Register TagPrefix="CH" Namespace="ActiproSoftware.CodeHighlighter" Assembly="ActiproSoftware.CodeHighlighter" %>
<%@ Register TagPrefix="FTB" Namespace="FreeTextBoxControls" Assembly="FreeTextBox" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>InsertCode</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<base target="_self">
		<style>BODY { BACKGROUND-COLOR: #e5e5e5 }
	.tb { FONT-SIZE: 13px }
		</style>
		
	</HEAD>
	<body MS_POSITIONING="FlowLayout">
		<form id="Form1" method="post" runat="server">
			<div>
				<table class="tb" id="Table1" cellSpacing="0" cellPadding="3" border="0" runat="server">
					<tr>
						<th align="right">
							编程语言:</th>
						<td><asp:dropdownlist id="LanguageDropDownList" Runat="server"></asp:dropdownlist></td>
					</tr>
					<tr>
						<th vAlign="top" align="right">
							代&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;码:</th>
						<td><asp:textbox id="CodeText" runat="server" TextMode="MultiLine" Width="400" Height="280"></asp:textbox></td>
					</tr>
					<tr>
						<td>&nbsp;</td>
						<td><asp:button id="HighlightButton" Runat="server" Text="确定"></asp:button>&nbsp;&nbsp;&nbsp;&nbsp;<input onclick="return window.close()" type="button" value="关闭"></td>
					</tr>
					<tr>
						<td></td>
						<td><pre><CH:CODEHIGHLIGHTER id=Codehighlighter1 runat="server" OnPostRender="CodeHighlighter_PostRender"></CH:CODEHIGHLIGHTER></pre>
						</td>
					</tr>
				</table>
			</div>
		</form>
		
	</body>
</HTML>
