<%@ Control Language="c#" AutoEventWireup="false" Codebehind="FavoriteList.ascx.cs" Inherits="Dottext.Web.UI.Controls.FavoriteList" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<style>
.entrylistTitle {
	font-family:verdana;
	font-size:16px;
	font-weight:bold;
	color:Black;
}

.entrylistDescription {
	margin-bottom:20px;
}
</style>
<div class="entrylistTitle"><asp:Literal ID="Title" Runat="server" /></div>
<div class="entrylistDescription"><asp:Literal ID="Description" Runat="server" /></div>
<asp:Repeater runat="Server" Runat="server" ID="Favorites">
	<ItemTemplate>
		<div class="post">
			<h5>
				<asp:HyperLink Runat="server" ID="TitleUrl" NavigateUrl='<%# DataBinder.Eval(((RepeaterItem)Container).DataItem,"Url") %>' Text='<%# DataBinder.Eval(((RepeaterItem)Container).DataItem,"Title") %>' Target='<%# GetTarget(DataBinder.Eval(((RepeaterItem)Container).DataItem,"NewWindow").ToString())%>'/>
			</h5>
		</div>
	</ItemTemplate>
</asp:Repeater>
