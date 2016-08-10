<%@ Register TagPrefix="uc1" TagName="Calendar" Src="Calendar.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="Header.ascx" %>
<%@ Control Language="c#" AutoEventWireup="false" Codebehind="AdvPageTemplate.ascx.cs" Inherits="Dottext.Web.AggSite.AdvPageTemplate" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<%@ Register TagPrefix="uc1" TagName="SiteSearch" Src="SiteSearch.ascx" %>
<%@ Register TagPrefix="uc2" TagName="AggStats" Src="AggStats.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Syndication" Src="~/AggSite/Syndication.ascx" %>
<%@ Register TagPrefix="uc1" TagName="AggStats" Src="~/AggSite/AggStats.ascx" %>
<%@ Register TagPrefix="uc1" TagName="BlogList" Src="~/AggSite/BlogList.ascx" %>
<%@ Register TagPrefix="DT" Namespace="Dottext.Web.UI.WebControls" Assembly="Dottext.Web" %>
<uc1:Header id="Header1" runat="server"></uc1:Header>
<div id="authors">
	<DT:contentregion id="LeftColumn" runat="server">
		<H2>����԰�߼����ҳ��</H2>
		<UL class="NavLink">
			<LI class="NavLinkli">
				<asp:hyperlink id="lnkReturn" runat="server" NavigateUrl="." Text="����԰��ҳ"></asp:hyperlink>
			<LI class="NavLinkli">
				<asp:hyperlink id="Hyperlink1" runat="server" NavigateUrl="~/AdvancedView.aspx" Text="��ǰ��ҳ"></asp:hyperlink>
			<LI class="NavLinkli">
				<asp:hyperlink id="lnkReturnDefault" runat="server" NavigateUrl="AdvancedView.aspx" Text="���ط�ҳ���"
					Visible="False"></asp:hyperlink></LI></UL>
		<div id="main"><DT:CONTENTREGION id="Contentregion1" runat="server"></DT:CONTENTREGION></div>
		<div id="footer"><FONT face="����"> </FONT>
		</div>
		<H2>
			<asp:Literal id="CalTitle" runat="Server"></asp:Literal>����
			<uc1:SiteSearch id="SiteSearch1" runat="server"></uc1:SiteSearch></H2>
		<uc1:Calendar id="Calendar1" runat="server"></uc1:Calendar>
		<H2>��վ����</H2>
		<asp:Repeater id="LinkList" runat="server">
			<HeaderTemplate>
				<ul class="NavLink">
			</HeaderTemplate>
			<ItemTemplate>
				<li class="NavLinkli" runat="server" Visible='<%# CheckVisible(DataBinder.Eval(((RepeaterItem)Container).DataItem,"CategoryID").ToString()) %>' ID="Li1" NAME="Li1">
					<asp:HyperLink Runat="server" ID="Link" NavigateUrl='<%# "~/AdvancedView.aspx?cate="+DataBinder.Eval(((RepeaterItem)Container).DataItem,"CategoryID").ToString()+"&title="+Server.UrlEncode(DataBinder.Eval(((RepeaterItem)Container).DataItem,"title").ToString())%>' Text='<%# DataBinder.Eval(((RepeaterItem)Container).DataItem,"title").ToString() %>'/>
				</li>
			</ItemTemplate>
			<FooterTemplate>
				<li class="NavLinkl">
					<asp:HyperLink Runat="server" ID="Link" NavigateUrl="MoreComments.aspx" Text="�����б�"></asp:HyperLink></li>
				</ul>
			</FooterTemplate>
		</asp:Repeater>
	</DT:contentregion>
</div>
<div id="main"><DT:CONTENTREGION id="MPMain" runat="server"></DT:CONTENTREGION></div>
<div id="footer"><FONT face="����"> </FONT>
</div>
