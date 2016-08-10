<%@ Register TagPrefix="uc1" TagName="Header" Src="Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="PickedCategory" Src="PickedCategory.ascx" %>
<%@ Control Language="c#" AutoEventWireup="false" Codebehind="PickedTeample.ascx.cs" Inherits="Dottext.Web.PickedTeample" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<%@ Register TagPrefix="uc1" TagName="ListTitle" Src="ListTitle.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Syndication" Src="~/AggSite/Syndication.ascx" %>
<%@ Register TagPrefix="DT" Namespace="Dottext.Web.UI.WebControls" Assembly="Dottext.Web" %>
<uc1:Header id="Header1" runat="server"></uc1:Header>
<div id="authors"><DT:CONTENTREGION id="LeftColumn" runat="server">
		<H2>博 客 园 精 华 区</H2>
		<UL class="NavLink">
			<LI class="NavLinkli">
				<asp:hyperlink id="lnkCategoryAll" runat="server" text="博客园首页" NavigateUrl="~"></asp:hyperlink>
			<LI class="NavLinkli">
				<asp:hyperlink id="Hyperlink1" runat="server" NavigateUrl="~/default.aspx?id=-10" Text="精华区首页"></asp:hyperlink>
			<LI class="NavLinkli">
				<uc1:ListTitle id="ListTitle1" runat="server"></uc1:ListTitle></LI></UL>
		<uc1:PickedCategory id="PickedCategory1" runat="server"></uc1:PickedCategory>
	</DT:CONTENTREGION>
</div>
<div id="main"><DT:CONTENTREGION id="MPMain" runat="server"></DT:CONTENTREGION></div>
<div id="footer"><FONT face="宋体"> </FONT>
</div>
