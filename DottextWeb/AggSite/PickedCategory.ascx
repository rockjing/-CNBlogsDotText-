<%@ Control Language="c#" AutoEventWireup="false" Codebehind="PickedCategory.ascx.cs" Inherits="Dottext.Web.AggSite.PickedCategory" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<style>
.NavLink1 a
{
	 font-family : Verdana;
	 font-size:13px;	
}

 .NavLink1
{
	
	font-family:Verdana;
	font-size:13px;	
	margin-bottom:5px;  
   	margin-left:40px;
   	color:Blue;
   	    
}
</style>
<H2>精华文章分类</H2>
<asp:Repeater id="LinkList" runat="server">
	<HeaderTemplate>
		<ul class="NavLink">
	</HeaderTemplate>
	<ItemTemplate>
		<li class="NavLinkli">
			<asp:HyperLink Runat="server" ID="Link" Text = '<%# GetTitle(DataBinder.Eval(((RepeaterItem)Container).DataItem,"Title").ToString(),DataBinder.Eval(((RepeaterItem)Container).DataItem,"CategoryID").ToString()) %>' NavigateUrl='<%# "~/default.aspx?id=-10&cateid="+DataBinder.Eval(((RepeaterItem)Container).DataItem,"CategoryID") %>'/>
		</li>
	</ItemTemplate>
	<FooterTemplate>
		</ul>
	</FooterTemplate>
</asp:Repeater>
