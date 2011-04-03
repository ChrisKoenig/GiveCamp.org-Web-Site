<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PiryxDonationWidget.ascx.cs"
    Inherits="SitefinityWebApp.Widgets.Piryx.PiryxDonationWidget" %>
<!--

Put in a bunch of hidden fields, etc. that are required for posting back to Piryx and then an ImageButton
with the PiryxLogo with a PostBackUrl set to the Piryx Endpoint

-->
<input type="hidden" name="cmd" value="_donations">
<input type="hidden" name="business" value="<%= PiryxId %>">
<input type="hidden" name="lc" value="US">
<input type="hidden" name="item_name" value="<%= OrganizationName %>">
<input type="hidden" name="no_note" value="0">
<input type="hidden" name="currency_code" value="USD">
<asp:ImageButton ID="btnSubmit" runat="server" PostBackUrl="https://www.piryx.com/.../..."
    AlternateText="Piryx - The safer, easier way to pay online!" />