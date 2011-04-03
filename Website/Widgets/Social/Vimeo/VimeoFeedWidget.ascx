<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="VimeoFeedWidget.ascx.cs"
    Inherits="SitefinityWebApp.Widgets.Social.Vimeo.VimeoFeedWidget" %>
<%@ Register Assembly="Telerik.Sitefinity" Namespace="Telerik.Sitefinity.Web.UI"
    TagPrefix="sitefinity" %>
<sitefinity:ResourceLinks ID="ResourceLinks1" runat="server">
    <sitefinity:ResourceFile Name="~/widgets/social/vimeo/vimeofeedwidget.css" Static="True" />
</sitefinity:ResourceLinks>
<asp:Repeater ID="VimeoRepeater" runat="server">
    <HeaderTemplate>
        <div class="vimeofeed">
            <div class="vimeoheader">
                <a href="http://vimeo.com/<%=Username %>" target="_blank">
                    <%=Username %></a> on Vimeo
            </div>
            <ul>
    </HeaderTemplate>
    <ItemTemplate>
        <li><a href="<%# Eval("Url") %>" title="<%# Eval("Title") %>" target="_blank">
            <img src="<%# Eval("Thumbnail") %>" alt="<%# Eval("Title") %>" width="150" height="113" />
        </a>
            <p class="vimeotitle">
                <%# VideoTitle(Eval("Title"), Eval("Url")) %>
            </p>
            <div style="clear: both">
            </div>
        </li>
    </ItemTemplate>
    <FooterTemplate>
        </ul>
        <div class="vimeofooter">
            <a href="http://vimeo.com/<%=Username %>" target="_blank">More videos on Vimeo...</a>
        </div>
        </div>
    </FooterTemplate>
</asp:Repeater>