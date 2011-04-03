Type.registerNamespace("SitefinityWebApp.Widgets.Social.Facebook");

SitefinityWebApp.Widgets.Social.Facebook.LikeBoxWidgetDesigner = function (element) {
    SitefinityWebApp.Widgets.Social.Facebook.LikeBoxWidgetDesigner.initializeBase(this, [element]);
}


SitefinityWebApp.Widgets.Social.Facebook.LikeBoxWidgetDesigner.prototype = {
    initialize: function () {
        SitefinityWebApp.Widgets.Social.Facebook.LikeBoxWidgetDesigner.callBaseMethod(this, 'initialize');

    },
    dispose: function () {
        SitefinityWebApp.Widgets.Social.Facebook.LikeBoxWidgetDesigner.callBaseMethod(this, 'dispose');
    },
    refreshUI: function () {
        var data = this._propertyEditor.get_control();
        jQuery("#WidgetMode").val(data.WidgetMode);
        jQuery("#Url").val(data.Url);
        jQuery("#Width").val(data.Width);
        jQuery("#Height").val(data.Height);
        jQuery("#NumConnections").val(data.NumConnections);
        jQuery("#ColorScheme").val(data.ColorScheme);
        jQuery("#ShowHeader").attr('checked', data.ShowHeader);
        jQuery("#ShowStream").attr('checked', data.ShowStream);

    },
    applyChanges: function () {

        var controlData = this._propertyEditor.get_control();

        controlData.WidgetMode = jQuery("#WidgetMode").val();
        controlData.Url = jQuery("#Url").val();
        controlData.Width = jQuery("#Width").val();
        controlData.Height = jQuery("#Height").val();
        controlData.NumConnections = jQuery("#NumConnections").val();
        controlData.ColorScheme = jQuery("#ColorScheme").val();
        controlData.ShowHeader = jQuery("#ShowHeader").attr('checked');
        controlData.ShowStream = jQuery("#ShowStream").attr('checked');
    }
}

SitefinityWebApp.Widgets.Social.Facebook.LikeBoxWidgetDesigner.registerClass('SitefinityWebApp.Widgets.Social.Facebook.LikeBoxWidgetDesigner', Telerik.Sitefinity.Web.UI.ControlDesign.ControlDesignerBase);
if (typeof (Sys) !== 'undefined') Sys.Application.notifyScriptLoaded();