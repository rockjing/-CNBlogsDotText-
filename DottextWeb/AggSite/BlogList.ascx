<%@ OutputCache Duration="1" VaryByParam="GroupID" VaryByCustom="Url" %>
<%@ Control Language="c#" AutoEventWireup="false" Codebehind="BlogList.ascx.cs" Inherits="Dottext.Web.AggSite.BlogList" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<h2><asp:Literal ID="LiteralTitle" Runat="server"></asp:Literal><font style="FONT-SIZE:11px">[«∞<asp:Literal Runat="server" ID="literalBloggerCount"></asp:Literal>»À]</font></h2>
<ul>
	<asp:repeater id="Bloggers" runat="server">
		<ItemTemplate>
			<li>
				<%#Container.ItemIndex +1+"." %>
				<asp:HyperLink Runat = "server" NavigateUrl = '<%# GetFullUrl(DataBinder.Eval(((RepeaterItem)Container).DataItem,"Application",null)) %>' Text = '<%# Dottext.Web.UI.Globals.RemoveHtml((DataBinder.Eval(((RepeaterItem)Container).DataItem,"Author")).ToString()) %>' ID="Hyperlink1" />
				<asp:HyperLink Runat = "server" NavigateUrl = '<%# GetFullUrl(DataBinder.Eval(((RepeaterItem)Container).DataItem,"Application",null))+"rss.aspx" %>' Text="(rss)" ID="Hyperlink3" CssClass="BlogRss"/>
				<br>
				<small>(
					<asp:Literal runat = "server" Text = '<%# DataBinder.Eval(((RepeaterItem)Container).DataItem,"PostCount") %>' ID="Label2"/>,
					<asp:Literal runat = "server" Text = '<%# (DateTime.Parse(DataBinder.Eval(((RepeaterItem)Container).DataItem,"LastUpdated",null))).ToString("MM-dd HH:mm")  %>' ID="Label1"/>)</small>
			</li>
		</ItemTemplate>
	</asp:repeater>
</ul>
