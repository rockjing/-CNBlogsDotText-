<%@ Control Language="c#" AutoEventWireup="false" Codebehind="SiteAllSearch.ascx.cs" Inherits="Dottext.Web.AggSite.SiteAllSearch" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<%@ Register TagPrefix="uc1" TagName="SearchForm" Src="SearchForm.ascx" %>
<%@ Register TagPrefix="dt" Namespace="Dottext.Web.UI.WebControls" Assembly="Dottext.Web"%>
<STYLE>
	BODY { MARGIN-TOP: 10px; FONT-WEIGHT: normal; FONT-SIZE: 13px; FONT-FAMILY: Arial; BACKGROUND-COLOR: #fff }
	TD { FONT-SIZE: 13px; FONT-FAMILY: Arial }
	#main1 .post { MARGIN-TOP: 10px; FONT-WEIGHT: normal; FONT-SIZE: 12px; FONT-FAMILY: Arial }
	#main1 H3 { MARGIN-TOP: 0px; FONT-WEIGHT: normal; FONT-SIZE: 14px; MARGIN-BOTTOM: 0px; PADDING-BOTTOM: 0px; PADDING-TOP: 0px; FONT-FAMILY: Arial }
	#main1 H4 { PADDING-RIGHT: 0px; MARGIN-TOP: 0px; PADDING-LEFT: 0px; FONT-WEIGHT: normal; FONT-SIZE: 13px; MARGIN-BOTTOM: 0px; PADDING-BOTTOM: 0px; PADDING-TOP: 5px; FONT-FAMILY: Arial }
	#main1 H5 { MARGIN-TOP: 0px; FONT-WEIGHT: normal; FONT-SIZE: 12px; MARGIN-BOTTOM: 10px; PADDING-BOTTOM: 0px; PADDING-TOP: 0px; FONT-FAMILY: Arial }
	H3 A:link { COLOR: #00c }
	H3 A:visited { COLOR: #551a8b }
	H3 A:active { COLOR: #f00 }
	H5 A:link { COLOR: #008000; TEXT-DECORATION: none }
	H5 A:visited { COLOR: #008000; TEXT-DECORATION: none }
	H5 A:active { COLOR: #008000; TEXT-DECORATION: none }
</STYLE>
<table>
	<tr>
		<td width="150"><asp:hyperlink id="TitleLink" Runat="server" ImageUrl="~/images/cnblogs_search.gif"></asp:hyperlink>
		</td>
		<td>
			博客园站内搜索:<br>
			<uc1:SearchForm id="SearchForm1" runat="server" Width="300" SearchUrl="Search.aspx?q="></uc1:SearchForm>
		</td>
	</tr>
</table>
<table width="100%" border="0" cellpadding="0" cellspacing="0">
	<tr>
		<td bgcolor="#3366cc"><img width="1" height="1" alt=""></td>
	</tr>
</table>
<table width="100%" border="0" cellpadding="0" cellspacing="0" bgcolor="#e5ecf9" height="24">
	<tr>
		<td bgcolor="#e5ecf9" nowrap><div id="ResultText" runat="server" visible="false">&nbsp;&nbsp;共有<asp:literal id="TotalResults" runat="server"></asp:literal>
				项查询结果。 搜索用时
				<asp:literal id="ExecutionTime" runat="server"></asp:literal>毫秒。
			</div>
		</td>
		<td bgcolor="#e5ecf9" align="right" nowrap>高级搜索: 标题-"title:" 内容-"body:" 博客名-"blog:" 
			作者-"author:"
		</td>
	</tr>
</table>
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
