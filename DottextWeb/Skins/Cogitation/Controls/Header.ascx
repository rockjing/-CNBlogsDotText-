<%@ Register TagPrefix="uc1" TagName="MyLinks" Src="MyLinks.ascx" %>
<%@ Control Language="c#" Inherits="Dottext.Web.UI.Controls.Header" %>
<%@ Register TagPrefix="uc1" TagName="BlogStats" Src="BlogStats.ascx" %>
<div>
	<table>
		<tr>
			<td class="HeaderTitles">
				<h1 class="HeaderTitle"><asp:hyperlink id="HeaderTitle" runat="server" CssClass="HeaderMainTitle"></asp:hyperlink></h1>
				<p id="tagline"><asp:literal id="HeaderSubTitle" runat="server"></asp:literal></p>
			</td>
			<td>
				<!-- WebHost4Life.com Code Begin 
				<a href="http://www.WebHost4Life.com/default.asp?refid=MarkHWagner">
				<asp:Image ID="HeaderAd" Runat="server" AlternateText="Join WebHost4Life.com" ImageUrl="../Images/WebHosting.gif"></asp:Image>
				</a>
				<!-- WebHost4Life.com Code End -->	
			</td>
		</tr>
	</table>
</div>
<div class="HeaderBar">
	<table id="HeaderBar" class="HeaderBar">
		<tr>
			<td class="HeaderBarTab" nowrap>
				<uc1:MyLinks id="MyLinks1" runat="server"></uc1:MyLinks><asp:Image ID="BlueTab" ImageUrl="../Images/BlueTabRight.gif" Runat="server" ImageAlign="AbsMiddle"></asp:Image>
			</td>
			<td class="HeaderBarTabBack" nowrap width="100%">
				<uc1:BlogStats id="BlogStats" runat="server"></uc1:BlogStats>
			</td>
		</tr>
	</table>
</div>
