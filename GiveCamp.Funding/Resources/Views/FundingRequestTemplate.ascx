<%@ Control Language="C#" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Assembly="Telerik.SiteFinity" Namespace="Telerik.Sitefinity.Web.UI"
    TagPrefix="sitefinity" %>
<telerik:RadFormDecorator ID="FormDecorator1" runat="server" DecoratedControls="all" />
<sitefinity:Message runat="server" ID="Message" ElementTag="div" RemoveAfter="30000"
    FadeDuration="10" />
<!-- Event Name -->
<asp:Label runat="server" ID="EventNameLabel" Text="<%$ Resources:FundingResources, EventName %>"
    AssociatedControlID="EventNameTextBox" Font-Bold="true" />
<asp:TextBox runat="server" ID="EventNameTextBox" Width="100%" />
<asp:RequiredFieldValidator runat="server" ID="EventNameRequired" CssClass="sfError"
    Display="Dynamic" ControlToValidate="EventNameTextBox" SetFocusOnError="true">
<strong><%$ Resources:FundingResources, EventNameRequired %></strong>
</asp:RequiredFieldValidator>
<br />
<br />
<!-- Event Date -->
<asp:Label runat="server" ID="EventDateLabel" Text="<%$ Resources:FundingResources, EventDate %>"
    AssociatedControlID="EventDateSelector" Font-Bold="true" />
<telerik:RadDatePicker ID="RadDatePicker1" Runat="server" />
<asp:RequiredFieldValidator runat="server" ID="EventDateRequired" CssClass="sfError"
    Display="Dynamic" ControlToValidate="EventDateSelector" SetFocusOnError="true">
<strong><%$ Resources:FundingResources, EventDateRequired %></strong>
</asp:RequiredFieldValidator>
<br />
<br />
<!-- First Name -->
<asp:Label runat="server" ID="FirstNameLabel" Text="<%$ Resources:FundingResources, FirstName %>"
    AssociatedControlID="FirstNameTextBox" Font-Bold="true" />
<asp:TextBox runat="server" ID="FirstNameTextBox" Width="100%" />
<asp:RequiredFieldValidator runat="server" ID="FirstNameRequired" CssClass="sfError"
    Display="Dynamic" ControlToValidate="FirstNameTextBox" SetFocusOnError="true">
<strong><%$ Resources:FundingResources, FirstNameRequired %></strong>
</asp:RequiredFieldValidator>
<br />
<br />
<!-- Last Name -->
<asp:Label runat="server" ID="LastNameLabel" Text="<%$ Resources:FundingResources, LastName %>"
    AssociatedControlID="LastNameTextBox" Font-Bold="true" />
<asp:TextBox runat="server" ID="LastNameTextBox" Width="100%" />
<asp:RequiredFieldValidator runat="server" ID="LastNameRequired" CssClass="sfError"
    Display="Dynamic" ControlToValidate="LastNameTextBox" SetFocusOnError="true">
<strong><%$ Resources:FundingResources, LastNameRequired %></strong>
</asp:RequiredFieldValidator>
<br />
<br />
<!-- Email Address -->
<asp:Label runat="server" ID="EmailAddressLabel" Text="<%$ Resources:FundingResources, EmailAddress %>"
    AssociatedControlID="EmailAddressTextBox" Font-Bold="true" />
<asp:TextBox runat="server" ID="TextBox1" Width="100%" />
<asp:RequiredFieldValidator runat="server" ID="EmailAddressRequired" CssClass="sfError"
    Display="Dynamic" ControlToValidate="EmailAddressTextBox" SetFocusOnError="true">
<strong><%$ Resources:FundingResources, EmailAddressRequired %></strong>
</asp:RequiredFieldValidator>
<br />
<br />
<!-- Mailing Address -->
<asp:Label runat="server" ID="MailingAddress" Text="<%$ Resources:FundingResources, MailingAddress %>"
    AssociatedControlID="MailingAddressTextBox" Font-Bold="true" />
<asp:TextBox runat="server" ID="MailingAddressTextBox" Width="100%" />
<asp:RequiredFieldValidator runat="server" ID="MailingAddressRequired" CssClass="sfError"
    Display="Dynamic" ControlToValidate="MailingAddressTextBox" SetFocusOnError="true">
<strong><%$ Resources:FundingResources, MailingAddressRequired %></strong>
</asp:RequiredFieldValidator>
<br />
<br />
<!-- City -->
<asp:Label runat="server" ID="CityLabel" Text="<%$ Resources:FundingResources, City %>"
    AssociatedControlID="CityTextBox" Font-Bold="true" />
<asp:TextBox runat="server" ID="CityTextBox" Width="100%" />
<asp:RequiredFieldValidator runat="server" ID="CityRequired" CssClass="sfError" Display="Dynamic"
    ControlToValidate="CityTextBox" SetFocusOnError="true">
<strong><%$ Resources:FundingResources, CityRequired %></strong>
</asp:RequiredFieldValidator>
<br />
<br />
<!-- State -->
<asp:Label runat="server" ID="StateLabel" Text="<%$ Resources:FundingResources, State %>"
    AssociatedControlID="StateTextBox" Font-Bold="true" />
<asp:TextBox runat="server" ID="StateTextBox" Width="100%" />
<asp:RequiredFieldValidator runat="server" ID="StateRequired" CssClass="sfError"
    Display="Dynamic" ControlToValidate="StateTextBox" SetFocusOnError="true">
<strong><%$ Resources:FundingResources, StateRequired %></strong>
</asp:RequiredFieldValidator>
<br />
<br />
<!-- ZipCode -->
<asp:Label runat="server" ID="ZipCodeLabel" Text="<%$ Resources:FundingResources, ZipCode %>"
    AssociatedControlID="ZipCodeTextBox" Font-Bold="true" />
<asp:TextBox runat="server" ID="ZipCodeTextBox" Width="100%" />
<asp:RequiredFieldValidator runat="server" ID="ZipCodeRequired" CssClass="sfError"
    Display="Dynamic" ControlToValidate="ZipCodeTextBox" SetFocusOnError="true">
<strong><%$ Resources:FundingResources, ZipCodeRequired %></strong>
</asp:RequiredFieldValidator>
<br />
<br />
<!-- AmountRequested -->
<asp:Label runat="server" ID="AmountRequestedLabel" Text="<%$ Resources:FundingResources, AmountRequested %>"
    AssociatedControlID="AmountRequestedTextBox" Font-Bold="true" />
<asp:TextBox runat="server" ID="AmountRequestedTextBox" Width="100%" />
<asp:RequiredFieldValidator runat="server" ID="AmountRequestedRequired" CssClass="sfError"
    Display="Dynamic" ControlToValidate="AmountRequestedTextBox" SetFocusOnError="true">
<strong><%$ Resources:FundingResources, AmountRequestedRequired %></strong>
</asp:RequiredFieldValidator>
<br />
<br />