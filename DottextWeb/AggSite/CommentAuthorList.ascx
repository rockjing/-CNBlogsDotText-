<%@ Control Language="c#" AutoEventWireup="false" Codebehind="CommentAuthorList.ascx.cs" Inherits="Dottext.Web.AggSite.CommentAuthorList" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<%@ OutputCache Duration="1800" VaryByParam="vipcate" VaryByCustom="Url" %>
<h2>评论排行榜<font style="FONT-SIZE:11px">[前<asp:Literal Runat="server" ID="literalBloggerCount"></asp:Literal>人]</font></h2>
<ul>
	<asp:repeater id="Authors" runat="server">
		<HeaderTemplate>
		</HeaderTemplate>
		<ItemTemplate>
			<li>
				<asp:Literal Runat="server" ID="sn" Text='<%# Container.ItemIndex+1+"." %>'>
				</asp:Literal>
				<asp:HyperLink Runat = "server" NavigateUrl='<%# GetUrl((DataBinder.Eval(((RepeaterItem)Container).DataItem,"Author")).ToString())%>' Text = '<%# Dottext.Web.UI.Globals.RemoveHtml((DataBinder.Eval(((RepeaterItem)Container).DataItem,"Author")).ToString()) %>' ID="Hyperlink1" style="color:blue"/>
				<br>
				<small>(
					<asp:Literal runat = "server" Text = '<%# DataBinder.Eval(((RepeaterItem)Container).DataItem,"PostCount") %>' ID="Label2"/>,
					<asp:Literal runat = "server" Text = '<%# (DateTime.Parse(DataBinder.Eval(((RepeaterItem)Container).DataItem,"LastUpdated").ToString())).ToShortDateString() + " " + (DateTime.Parse(DataBinder.Eval(((RepeaterItem)Container).DataItem,"LastUpdated").ToString())).ToShortTimeString() %>' ID="Label1"/>)</small>
			</li>
		</ItemTemplate>
		<FooterTemplate>
		</FooterTemplate>
	</asp:repeater>
</ul>
