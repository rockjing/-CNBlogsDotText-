<%@ Control Language="c#" AutoEventWireup="false" Codebehind="AggStats.ascx.cs" Inherits="Dottext.Web.AggSite.AggStats" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<%@ OutputCache Duration="600" VaryByParam="none" VaryByCustom="Url" %>
<h2>统计信息</h2>
<ul>
	<li>
		博客 -
		<asp:literal id="BlogCount" Runat="server"></asp:literal>
	<li>
		随笔 -
		<asp:literal id="PostCount" Runat="server"></asp:literal>
	<li>
		文章 -
		<asp:literal id="StoryCount" Runat="server"></asp:literal>
	<li>
		评论 -
		<asp:literal id="CommentCount" Runat="server"></asp:literal>
	<li>
		<asp:HyperLink id="PingtrackCount" Runat="server" NavigateUrl="~/default.aspx?id=-12" Text="TrackBacks - " CssClass="TrackBackLink"></asp:HyperLink>
	</li>
</ul>
