<%@ Control Language="c#" AutoEventWireup="false" Codebehind="AggStats.ascx.cs" Inherits="Dottext.Web.AggSite.AggStats" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<%@ OutputCache Duration="600" VaryByParam="none" VaryByCustom="Url" %>
<h2>ͳ����Ϣ</h2>
<ul>
	<li>
		���� -
		<asp:literal id="BlogCount" Runat="server"></asp:literal>
	<li>
		��� -
		<asp:literal id="PostCount" Runat="server"></asp:literal>
	<li>
		���� -
		<asp:literal id="StoryCount" Runat="server"></asp:literal>
	<li>
		���� -
		<asp:literal id="CommentCount" Runat="server"></asp:literal>
	<li>
		<asp:HyperLink id="PingtrackCount" Runat="server" NavigateUrl="~/default.aspx?id=-12" Text="TrackBacks - " CssClass="TrackBackLink"></asp:HyperLink>
	</li>
</ul>
