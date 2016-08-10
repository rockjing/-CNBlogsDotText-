<%@ Control Language="c#" AutoEventWireup="false" Inherits="Dottext.Web.UI.Controls.BlogSearch" %>
<%@ Register TagPrefix="uc1" TagName="Search" Src="~/AggSite/Search.ascx" %>
<p class="date"><span>Search</span></p>
<uc1:Search id=Search1 runat="server" FilterByBlog="true"></uc1:Search>