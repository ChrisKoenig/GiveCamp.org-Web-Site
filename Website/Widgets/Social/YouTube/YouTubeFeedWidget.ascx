<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="YouTubeFeedWidget.ascx.cs" Inherits="SitefinityWebApp.Widgets.Social.YouTube.YouTubeFeedWidget" %>
<%@ Register Assembly="Telerik.Sitefinity" Namespace="Telerik.Sitefinity.Web.UI" TagPrefix="sitefinity" %>

<sitefinity:ResourceLinks ID="ResourceLinks1" runat="server">
	<sitefinity:ResourceFile Name="~/widgets/social/youtube/youtubefeedwidget.css" Static="True" />
</sitefinity:ResourceLinks>

<asp:Repeater ID="YouTubeRepeater" runat="server">
	<HeaderTemplate>
		<div class="youtubefeed">
			<div class="youtubeheader">
				<a href="http://youtube.com/user/<%=Username %>" target="_blank">
					<%=Username %></a> on YouTube
			</div>
			<ul>
	</HeaderTemplate>
	<ItemTemplate>
		<li><a href="<%# Eval("Url") %>" title="<%# Eval("Title") %>" target="_blank">
			<img src="<%# Eval("Thumbnail") %>" alt="<%# Eval("Title") %>" />
		</a>
			<p class="youtubetitle">
				<%# VideoTitle(Eval("Title"), Eval("Url")) %>
			</p>
			<div style="clear: both">
			</div>
		</li>
	</ItemTemplate>
	<FooterTemplate>
		</ul>
		<div class="youtubefooter">
			<a href="http://youtube.com/user/<%=Username %>" target="_blank">More videos on YouTube...</a>
		</div>
		</div>
	</FooterTemplate>
</asp:Repeater>