<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TwitterFeedWidget.ascx.cs" Inherits="SitefinityWebApp.Widgets.Social.Twitter.TwitterFeedWidget" %>
<%@ Register Assembly="Telerik.Sitefinity" Namespace="Telerik.Sitefinity.Web.UI" TagPrefix="sitefinity" %>

<sitefinity:ResourceLinks runat="server">
	<sitefinity:ResourceFile Name="~/widgets/social/twitter/TwitterFeedWidget.css" Static="True" />
</sitefinity:ResourceLinks>

<asp:Repeater ID="TwitterRepeater" runat="server">
	<HeaderTemplate>
		<div class="twitterfeed">
			<div class="twitterheader">
				<a href="http://twitter.com/<%=Username %>" target="_blank">@<%=Username %></a> on Twitter
			</div>
			<ul>
	</HeaderTemplate>
	<ItemTemplate>
		<li class="twittertweet">
			<p>
				<%# Eval("Tweet") %></p>
			<p class="reply">
				<%# ShowTimeStamp ? string.Format("<a href=\"{0}\" target=\"_blank\">{1}</a> &bull; ", Eval("Url"), Eval("Timestamp")) : string.Empty %>
				<a href="http://twitter.com/?status=@<%= Username %>%20&in_reply_to_status_id=<%# Eval("TweetID") %>&in_reply_to=<%= Username %>" target="_blank">Reply</a></p>
		</li>
	</ItemTemplate>
	<FooterTemplate>
		</ul>
		<div class="twitterfooter">
			<a href="http://twitter.com/<%= Username %>" target="_blank">
				<img src="/images/widget-logo.png" alt="Twitter Logo" /></a> <a href="http://twitter.com/<%= Username %>" target="_blank">Join the Conversation</a>
		</div>
		</div>
	</FooterTemplate>
</asp:Repeater>