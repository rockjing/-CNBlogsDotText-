<%@ Import Namespace = "Dottext.Framework.Components" %>
<%@ Control Language="c#" Inherits="Dottext.Web.UI.Controls.DayCollection" %>
<%@ Register TagPrefix="uc1" TagName="Day" Src="Day.ascx" %>
<asp:Repeater id="DaysList" runat="server">
	<ItemTemplate>
		<uc1:Day id="DayItem" CurrentDay = '<%# (EntryDay) Container.DataItem %>' runat="server" />
	</ItemTemplate>
</asp:Repeater>
