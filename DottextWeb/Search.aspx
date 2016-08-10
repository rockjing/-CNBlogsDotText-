<%@ Register TagPrefix="uc1" TagName="Search" Src="~/AggSite/SiteAllSearch.ascx" %>
<%@ Register TagPrefix="DT" Namespace="Dottext.Web.UI.WebControls" Assembly="Dottext.Web" %>
<%@ Page language="c#" Codebehind="Search.aspx.cs" EnableViewState="false" AutoEventWireup="false" Inherits="Dottext.Web.Search" %>
<STYLE>BODY { MARGIN-TOP: 10px; FONT-WEIGHT: normal; FONT-FAMILY: Arial; BACKGROUND-COLOR: #fff }
	#main1 .post { MARGIN-TOP: 10px; FONT-WEIGHT: normal; FONT-SIZE: 12px; FONT-FAMILY: Arial }
	#main1 H3 { MARGIN-TOP: 0px; FONT-WEIGHT: normal; FONT-SIZE: 14px; MARGIN-BOTTOM: 0px; PADDING-BOTTOM: 0px; PADDING-TOP: 0px; FONT-FAMILY: Arial }
	#main1 H4 { PADDING-RIGHT: 0px; MARGIN-TOP: 0px; PADDING-LEFT: 0px; FONT-WEIGHT: normal; FONT-SIZE: 13px; MARGIN-BOTTOM: 0px; PADDING-BOTTOM: 0px; PADDING-TOP: 5px; FONT-FAMILY: Arial }
	#main1 H5 { MARGIN-TOP: 0px; FONT-WEIGHT: normal; FONT-SIZE: 12px; MARGIN-BOTTOM: 10px; PADDING-BOTTOM: 0px; PADDING-TOP: 0px; FONT-FAMILY: Arial }
	H3 A:link { COLOR: #00c }
	H3 A:visited { COLOR: #551a8b }
	H3 A:active { COLOR: #f00 }
	H5 A:link { COLOR: #008000; TEXT-DECORATION: none }
	H5 A:visited { COLOR: #008000; TEXT-DECORATION: none }
	H5 A:active { COLOR: #008000; TEXT-DECORATION: none }
	.SearchText { WIDTH: 300px }
	</STYLE>
<form id="Form1" method="post" runat="server" onsubmit="return false">
	<DT:contentregion id="LeftColumn" runat="server"></DT:contentregion>
	<DT:contentregion id="MainBodyRegion" runat="server">
		<uc1:Search id="Search1" runat="server" FilterByBlog="false"></uc1:Search>
	</DT:contentregion>
</form>
</DT:MASTERPAGE>
