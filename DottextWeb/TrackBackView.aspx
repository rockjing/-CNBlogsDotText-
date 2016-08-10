<%@ Register TagPrefix="uc1" TagName="PagedPosts" Src="AggSite/PagedPosts.ascx" %>
<%@ Register TagPrefix="DT" Namespace="Dottext.Web.UI.WebControls" Assembly="Dottext.Web" %>
<%@ Page language="c#" Codebehind="TrackBackView.aspx.cs" AutoEventWireup="false" Inherits="Dottext.Web.TrackBackView" %>
<DT:MASTERPAGE id="MPContainer" runat="server" TemplateFile="~/AggSite/TrackBackTemplate.ascx">
	<DT:contentregion id="MainBodyRegion" runat="server">
		<uc1:PagedPosts id="PagedPosts1" runat="server" Title="TrackBackÁÐ±í" EntryType="PingTrack" EntryPostConfig="IsActive"></uc1:PagedPosts>
	</DT:contentregion>
</DT:MASTERPAGE>
