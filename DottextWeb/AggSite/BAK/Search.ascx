<%@ Register TagPrefix="dt" Namespace="Dottext.Web.UI.WebControls" Assembly="Dottext.Web"%>
<%@ Control Language="c#" AutoEventWireup="false" Codebehind="Search.ascx.cs" Inherits="Dottext.Web.AggSite.Search" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<STYLE>BODY {
	MARGIN-TOP: 10px; FONT-WEIGHT: normal; FONT-FAMILY: Arial; BACKGROUND-COLOR: #fff
}
#main1 .post {
	MARGIN-TOP: 10px; FONT-WEIGHT: normal; FONT-SIZE: 12px; FONT-FAMILY: Arial
}
#main1 H3 {
	MARGIN-TOP: 0px; FONT-WEIGHT: normal; FONT-SIZE: 14px; MARGIN-BOTTOM: 0px; PADDING-BOTTOM: 0px; PADDING-TOP: 0px; FONT-FAMILY: Arial
}
#main1 H4 {
	PADDING-RIGHT: 0px; MARGIN-TOP: 0px; PADDING-LEFT: 0px; FONT-WEIGHT: normal; FONT-SIZE: 13px; MARGIN-BOTTOM: 0px; PADDING-BOTTOM: 0px; PADDING-TOP: 5px; FONT-FAMILY: Arial
}
#main1 H5 {
	MARGIN-TOP: 0px; FONT-WEIGHT: normal; FONT-SIZE: 12px; MARGIN-BOTTOM: 10px; PADDING-BOTTOM: 0px; PADDING-TOP: 0px; FONT-FAMILY: Arial
}
H3 A:link {
	COLOR: #00c
}
H3 A:visited {
	COLOR: #551a8b
}
H3 A:active {
	COLOR: #f00
}
H5 A:link {
	COLOR: #008000; TEXT-DECORATION: none
}
H5 A:visited {
	COLOR: #008000; TEXT-DECORATION: none
}
H5 A:active {
	COLOR: #008000; TEXT-DECORATION: none
}
</style>
<P><asp:textbox id="tbSearch" runat="server" width="300" CssClass="SearchText"></asp:textbox><asp:button id="Button1" runat="server" Text="搜索"></asp:button>
	<asp:DropDownList id="DropDownList1" runat="server" Visible="False">
		<asp:ListItem Value="选择一个范围:">选择一个范围:</asp:ListItem>
		<asp:ListItem Value="author">作者</asp:ListItem>
		<asp:ListItem Value="blog">博客名</asp:ListItem>
		<asp:ListItem Value="title">文章标题</asp:ListItem>
		<asp:ListItem Value="body">文章内容</asp:ListItem>
	</asp:DropDownList><BR>
	<asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" Display="Dynamic" ControlToValidate="tbSearch"
		ErrorMessage="请输入搜索关键字!"></asp:requiredfieldvalidator></P>
<div id="ResultText" runat="server" visible="false">共有<asp:literal id="TotalResults" runat="server"></asp:literal>
	项查询结果。 搜索用时
	<asp:literal id="ExecutionTime" runat="server"></asp:literal>毫秒。
</div>
<div id="main1">
	<asp:repeater id="Results" runat="server">
		<ItemTemplate>
			<div class="post">
				<h3>
					<asp:HyperLink Runat = "server" Target="_self" NavigateUrl = '<%# DataBinder.Eval(((RepeaterItem)Container).DataItem,"PermaLink")%>' Text = '<%# "["+DataBinder.Eval(((RepeaterItem)Container).DataItem,"Author").ToString()+"]"+DataBinder.Eval(((RepeaterItem)Container).DataItem,"Title").ToString() %>' ID="Hyperlink2"/>
				</h3>
				<h4>
					<asp:Literal runat = "server" Text = '<%# DataBinder.Eval(((RepeaterItem)Container).DataItem,"RawPost") %>' ID="BlogContentLabel" />
				</h4>
				<h5>
					<asp:HyperLink Runat = "server" NavigateUrl = '<%# DataBinder.Eval(((RepeaterItem)Container).DataItem,"PermaLink")%>' Text = '<%# DataBinder.Eval(((RepeaterItem)Container).DataItem,"PermaLink") %>' ID="Hyperlink1"/>
					<asp:Literal runat = "server" Text = '<%# (DateTime.Parse(DataBinder.Eval(((RepeaterItem)Container).DataItem,"DateCreatedString").ToString())).ToString("yyyy-MM-dd") %>' ID="Label5"/>
					作者:
					<asp:Literal Runat = "server" Text = '<%# DataBinder.Eval(((RepeaterItem)Container).DataItem,"Author") %>' ID="Label6"/>
				</h5>
			</div>
		</ItemTemplate>
	</asp:repeater>
</div>
<dt:pager id="ResultsPager" runat="server" UseSpacer="True" PrefixText="结果页码:" LinkFormatActive='<a href="{0}" class="Current">{1}</a>'
	CssClass="Pager"></dt:pager>
