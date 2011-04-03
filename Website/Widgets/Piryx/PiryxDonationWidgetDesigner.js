Type.registerNamespace("SitefinityWebApp.Widgets.Piryx");

SitefinityWebApp.Widgets.Piryx.PiryxDonationWidgetDesigner = function (element) {
    SitefinityWebApp.Widgets.Piryx.PiryxDonationWidgetDesigner.initializeBase(this, [element]);
}

SitefinityWebApp.Widgets.Piryx.PiryxDonationWidgetDesigner.prototype = {
    initialize: function () {
        SitefinityWebApp.Widgets.Piryx.PiryxDonationWidgetDesigner.callBaseMethod(this, 'initialize');
    },
    dispose: function () {
        SitefinityWebApp.Widgets.Piryx.PiryxDonationWidgetDesigner.callBaseMethod(this, 'dispose');
    },
    refreshUI: function () {
        var data = this._propertyEditor.get_control();
        jQuery("#PiryxId").val(data.PiryxId);
        jQuery("#OrganizationName").val(data.OrganizationName);
        jQuery("#ShowCreditCardLogos").attr('checked', data.ShowCreditCardLogos);
    },
    applyChanges: function () {
        var controlData = this._propertyEditor.get_control();

        controlData.PiryxId = jQuery("#PiryxId").val();
        controlData.OrganizationName = jQuery("#OrganizationName").val();
        controlData.ShowCreditCardLogos = jQuery("#ShowCreditCardLogos").attr('checked');
    }
}

SitefinityWebApp.Widgets.Piryx.PiryxDonationWidgetDesigner.registerClass('SitefinityWebApp.Widgets.Piryx.PiryxDonationWidgetDesigner', Telerik.Sitefinity.Web.UI.ControlDesign.ControlDesignerBase);
if (typeof (Sys) !== 'undefined') Sys.Application.notifyScriptLoaded();