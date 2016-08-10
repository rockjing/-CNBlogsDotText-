<%@ Control Language="c#" AutoEventWireup="false" Codebehind="AllBlogList.ascx.cs" Inherits="Dottext.Web.AggSite.AllBlogList" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<%@ OutputCache Duration="300" VaryByParam="page;id" VaryByCustom="Url" %>
<%@ Register TagPrefix="dt" Namespace="Dottext.Web.UI.WebControls" Assembly="Dottext.Web"%>
<h2>�����б�(<asp:Literal runat="server" Text="������ʱ��" ID="ltTitle"></asp:Literal>)<font style="FONT-SIZE: 11px">[��<asp:literal id="literalBloggerCount" Runat="server"></asp:literal>��]</font></h2>
<dt:pager id="ResultsPager" runat="server" CssClass="Pager" LinkFormatActive="{1}" UseSpacer="True"
	DisplayMode="Block"></dt:pager>
<asp:repeater id="RecentbloggerRepeater" runat="server">
	<ItemTemplate>
		<div class="post">
			<h3>
				<asp:HyperLink Runat = "server" NavigateUrl = '<%# GetFullUrl(DataBinder.Eval(((RepeaterItem)Container).DataItem,"Application",null)) %>' Text = '<%# DataBinder.Eval(((RepeaterItem)Container).DataItem,"Title") %>' ID="lnkTitle"/>
			</h3>
			<h4>
				<asp:Literal runat = "server" Text = '<%# CheckContent(DataBinder.Eval(((RepeaterItem)Container).DataItem,"SubTitle",null)) %>' ID="BlogContentLabel" />
			</h4>
			<p class="postfoot" align="right">
				<asp:Literal runat="server" Text='<%# GetTimeText() %>' ID="ltTimeTitle"></asp:Literal>
				<asp:Literal runat = "server" Text = '<%# (DateTime.Parse(DataBinder.Eval(((RepeaterItem)Container).DataItem," LastUpdated",null))).ToString("yyyy-MM-dd HH:mm") %>' ID="Label5"/>
				<asp:HyperLink Runat = "server" CssClass = "clsSubText" NavigateUrl = '<%# GetFullUrl(DataBinder.Eval(((RepeaterItem)Container).DataItem,"Application",null)) %>' Text = '<%# DataBinder.Eval(((RepeaterItem)Container).DataItem,"Author",null) %>' ID="Hyperlink3"/>
				�����:
				<asp:Literal runat = "server" Text = '<%# DataBinder.Eval(((RepeaterItem)Container).DataItem,"PostCount") %>' ID="lnkPostCount"/>
				����:
				<asp:Literal runat = "server" Text = '<%# DataBinder.Eval(((RepeaterItem)Container).DataItem,"StoryCount") %>' ID="lnkStoryCount"/>
				����:
				<asp:Literal runat = "server" Text = '<%# DataBinder.Eval(((RepeaterItem)Container).DataItem," CommentCount") %>' ID="lnkCommentCount"/>
				����:
				<asp:Literal runat = "server" Text = '<%# DataBinder.Eval(((RepeaterItem)Container).DataItem,"PingTrackCount") %>' ID="lnkPingTrackCount"/>��
			</p>
		</div>
	</ItemTemplate>
</asp:repeater>
<h6><dt:pager id="ResultsPager2" runat="server" CssClass="Pager" LinkFormatActive="{1}" UseSpacer="True"></dt:pager></h6>
