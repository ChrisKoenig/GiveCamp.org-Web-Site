<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="iCalFeedWidget.ascx.cs" Inherits="SitefinityWebApp.Widgets.Calendar.iCalFeedWidget" %>
<%@ Register Assembly="Telerik.Sitefinity" Namespace="Telerik.Sitefinity.Web.UI" TagPrefix="sitefinity" %>

<sitefinity:ResourceLinks ID="ResourceLinks1" runat="server">
	<sitefinity:ResourceFile Name="~/widgets/Calendar/iCalFeedWidget.css" Static="True" />
</sitefinity:ResourceLinks>

<p class="iCalFeed">
	<asp:HyperLink ID="WidgetLink" runat="server" NavigateUrl="~/ical/feed" ToolTip="Subscribe to iCal Feed" Text="Subscribe to Events (iCal)" />
</p>