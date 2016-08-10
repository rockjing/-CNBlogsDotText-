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
		</tr>
	</table>
</div>
<div class="HeaderBar">
	<table id="HeaderBar" class="HeaderBar">
		<tr>
		    <td class="HeaderBarTab" nowrap>
		        <asp:Image ID="StartButton" ImageUrl="../Images/WinXP-Olive_Spacer.gif" Runat="server" ImageAlign="AbsMiddle"></asp:Image>
		        <uc1:MyLinks id="MyLinks1" runat="server"></uc1:MyLinks>
			</td>
			<td class="HeaderBarTabBack" nowrap width="100%">
				<uc1:BlogStats id="BlogStats" runat="server"></uc1:BlogStats>
			</td>
		</tr>
	</table>
</div>
