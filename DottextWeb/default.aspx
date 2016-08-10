<%@ Page language="c#" Codebehind="default.aspx.cs" AutoEventWireup="false" Inherits="Dottext.Web.UI.Pages.DottextMasterPage"%>
<%@ Register TagPrefix="DT" Namespace="Dottext.Web.UI.WebControls" Assembly="Dottext.Web" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title><asp:Literal ID="pageTitle" Runat="server" /></title>
		<meta content=".Text" name="GENERATOR">
		<link id="MainStyle" type="text/css" rel="stylesheet" runat="Server"/>
		<link id="SecondaryCss" type="text/css" rel="stylesheet" runat="Server"/>
		<link id="RSSLink" title="RSS" type="application/rss+xml" rel="alternate" runat="Server"/>
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<DT:MASTERPAGE id="MPContainer" runat="server">
				<DT:contentregion id="MPMain" runat="server">
					<asp:PlaceHolder id="CenterBodyControl" runat="server"></asp:PlaceHolder>
				</DT:contentregion>
			</DT:MASTERPAGE></form>
	</body>
</HTML>