<%@ Control Language="c#" AutoEventWireup="false" Codebehind="SiteCategory.ascx.cs" Inherits="Dottext.Web.AggSite.SiteCategory" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<H2>Õ¯’æ∑÷¿‡</H2>
<asp:Repeater id="CategoryLevel1" runat="server">
	<ItemTemplate>
		<HeaderTemplate>
			<ul class="NavLink">
		</HeaderTemplate>
		<li>
			<asp:HyperLink Runat="server" ID="Link" NavigateUrl='<%#  GetUrl(DataBinder.Eval(Container.DataItem,"CategoryID",null)) %>'>
				<%# CheckTitle(DataBinder.Eval(Container.DataItem,"Title",null),DataBinder.Eval(((RepeaterItem)Container).DataItem,"CategoryID",null)) %>
			</asp:HyperLink>
			<asp:HyperLink Runat="server" ID="RssLink" Text="(rss)" NavigateUrl='<%# GetRssUrl(DataBinder.Eval(((RepeaterItem)Container).DataItem,"CategoryID",null)) %>' />
		</li>
		<ul class="NavLink">
			<asp:Repeater id="CategoryLevel2" runat="server" DataSource='<%# GetGlobalCategory(int.Parse(DataBinder.Eval(Container.DataItem, "CategoryID").ToString())) %>' Visible='<%# Dottext.Framework.Configuration.Config.Settings.CategoryDepth==2 %>'>
				<ItemTemplate>
					<li>
						<asp:HyperLink Runat="server" ID="Hyperlink1" NavigateUrl='<%# GetUrl(DataBinder.Eval(Container.DataItem,"CategoryID",null)) %>'>
							<%# DataBinder.Eval(Container.DataItem,"Title") %>
						</asp:HyperLink>
						<asp:HyperLink Runat="server" ID="Hyperlink2" Text="(rss)" NavigateUrl='<%# GetRssUrl(DataBinder.Eval(((RepeaterItem)Container).DataItem,"CategoryID",null)) %>' />
					</li>
				</ItemTemplate>
			</asp:Repeater>
		</ul>
		<FooterTemplate>
		</ul>
		</FooterTemplate>
	</ItemTemplate>
</asp:Repeater>
