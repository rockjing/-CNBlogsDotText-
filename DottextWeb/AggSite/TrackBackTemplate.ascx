<%@ Control Language="c#" AutoEventWireup="false" Codebehind="TrackBackTemplate.ascx.cs" Inherits="Dottext.Web.AggSite.TrackBackTemplate" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<%@ Register TagPrefix="DT" Namespace="Dottext.Web.UI.WebControls" Assembly="Dottext.Web" %>
<%@ Register TagPrefix="uc2" TagName="AggStats" Src="AggStats.ascx" %>
<HTML>
	<HEAD>
		<title>
			<asp:Literal id="TitleTag" runat="Server" />
		</title>
		<LINK href="AggSite/style.css" type="text/css" rel="stylesheet">
	</HEAD>	
	<BODY>
		<style>
			#main { PADDING-RIGHT: 0px; MARGIN-LEFT: 40px; MARGIN-RIGHT: 40px }
			#main H4 { MARGIN-BOTTOM: 0px }
			#main .postfoot { MARGIN-TOP: 0px; MARGIN-RIGHT: 10px }
		</style>
	
		<form id="Form1" method="post" runat="server">
			<div id="header">
				<h1><asp:hyperlink id="TitleLink" ImageUrl="~/images/blogyuanFirst.gif" Runat="server"></asp:hyperlink></h1>
			</div>
			<div id="main">
				<DT:contentregion id="MainBodyRegion" runat="server"></DT:contentregion>
			</div>
		</form>
	</BODY>
</HTML>
