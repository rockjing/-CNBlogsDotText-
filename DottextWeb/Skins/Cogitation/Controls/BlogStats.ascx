<%@ Control Language="c#" Inherits="Dottext.Web.UI.Controls.BlogStats" %>
<div class="BlogStatsBar">
	<table class="BlogStatsBar">
		<tr>
			<td width="100%">
			</td>
			<td class="BlogStatsBar" nowrap>
				&nbsp;
				<asp:Literal ID="PostCount" Runat="server" /> 
				���&nbsp;::
				<asp:Literal ID="StoryCount" Runat="server" /> ����
				::
				<asp:Literal ID="CommentCount" Runat="server" /> ����
				::
				<asp:Literal ID="PingTrackCount" Runat="server" /> Trackbacks
			</td>
		</tr>
	</table>
</div>
