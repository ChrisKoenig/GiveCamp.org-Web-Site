<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FlickrFeedWidget.ascx.cs" Inherits="Sitefinity.Widgets.Social.Flickr.FlickrFeedWidget" %>
<%@ Register Assembly="Telerik.Sitefinity" Namespace="Telerik.Sitefinity.Web.UI" TagPrefix="sitefinity" %>

<sitefinity:ResourceLinks ID="ResourceLinks1" runat="server">
	<sitefinity:ResourceFile Name="~/widgets/social/flickr/Flickrfeedwidget.css" Static="True" />
</sitefinity:ResourceLinks>

<asp:Repeater ID="FlickrRepeater" runat="server">
	<HeaderTemplate>
		<div class="flickrfeed">
			<div class="flickrheader">
				<a href="http://flickr.com/photos/<%= Username %>" target="_blank">
					<%= Username %>
					on Flickr</a>
			</div>
			<ul>
	</HeaderTemplate>
	<ItemTemplate>
		<li><a href="<%# Eval("Url") %>" target="_blank" title="<%# Eval("Title") %>">
			<img src="<%# Eval("Thumbnail") %>" alt="<%# Eval("Title") %>" /></a>
			<%# PhotoTitle(Eval("Title"), Eval("Url")) %>
		</li>
	</ItemTemplate>
	<FooterTemplate>
		</ul>
		<div style="clear: both;">
		</div>
		<div class="flickrfooter">
			<a href="http://flickr.com/photos/<%= Username %>" target="_blank">More Photos on Flickr...</a>
		</div>
		</div>
	</FooterTemplate>
</asp:Repeater>