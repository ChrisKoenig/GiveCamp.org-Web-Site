<%@ Control Language="C#" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Assembly="Telerik.SiteFinity" Namespace="Telerik.Sitefinity.Web.UI"
    TagPrefix="sitefinity" %>
<telerik:RadFormDecorator ID="FormDecorator1" runat="server" DecoratedControls="all" />
<sitefinity:Message runat="server" ID="Message" ElementTag="div" RemoveAfter="30000"
    FadeDuration="10" />
<telerik:RadGrid ID="FundingRequestDataGrid" runat="server" Width="100%" PageSize="15" AllowSorting="True" AllowPaging="True" AllowMultiSelection="True" Gridlines="None">
    <PagerStyle Mode="NextPrevAndNumeric" />
    <MasterTableView AutoGenerateColumns="False" DataKeyNames="Id" Summary="RadGrid Table">
        <Columns>
            <telerik:GridBoundColumn DataField="EventName" HeaderText="<%$ Resources:FundingRequestResources, EventName %>" />
            <telerik:GridBoundColumn DataField="EventDate" HeaderText="<%$ Resources:FundingRequestResources, EventDate %>" />
            <telerik:GridBoundColumn DataField="FirstName" HeaderText="<%$ Resources:FundingRequestResources, FirstName %>" />
            <telerik:GridBoundColumn DataField="LastName"  HeaderText="<%$ Resources:FundingRequestResources, LastName %>" />
            <telerik:GridBoundColumn DataField="Address" HeaderText="<%$ Resources:FundingRequestResources, Address %>" />
            <telerik:GridBoundColumn DataField="City" HeaderText="<%$ Resources:FundingRequestResources, City %>" />
            <telerik:GridBoundColumn DataField="State" HeaderText="<%$ Resources:FundingRequestResources, State %>" />
            <telerik:GridBoundColumn DataField="ZipCode" HeaderText="<%$ Resources:FundingRequestResources, ZipCode %>" />
            <telerik:GridBoundColumn DataField="EmailAddress" HeaderText="<%$ Resources:FundingRequestResources, EmailAddress %>" />
            <telerik:GridBoundColumn DataField="AmountRequested" HeaderText="<%$ Resources:FundingRequestResources, AmountRequested %>" />
        </Columns>
    </MasterTableView>
</telerik:RadGrid>