Type.registerNamespace("SitefinityWebApp.Widgets.Social.YouTube");

SitefinityWebApp.Widgets.Social.YouTube.YouTubeFeedWidgetDesigner = function (element) {
    SitefinityWebApp.Widgets.Social.YouTube.YouTubeFeedWidgetDesigner.initializeBase(this, [element]);
}


SitefinityWebApp.Widgets.Social.YouTube.YouTubeFeedWidgetDesigner.prototype = {
    initialize: function () {
        SitefinityWebApp.Widgets.Social.YouTube.YouTubeFeedWidgetDesigner.callBaseMethod(this, 'initialize');

    },
    dispose: function () {
        SitefinityWebApp.Widgets.Social.YouTube.YouTubeFeedWidgetDesigner.callBaseMethod(this, 'dispose');
    },
    refreshUI: function () {
        var data = this._propertyEditor.get_control();
        jQuery("#Username").val(data.Username);
        jQuery("#MaxVideos").val(data.MaxVideos);
        jQuery("#ShowTitles").attr('checked', data.ShowTitles);
    },
    applyChanges: function () {

        var controlData = this._propertyEditor.get_control();

        controlData.Username = jQuery("#Username").val();
        controlData.MaxVideos = jQuery("#MaxVideos").val();
        controlData.ShowTitles = jQuery("#ShowTitles").attr('checked');
    }
}

SitefinityWebApp.Widgets.Social.YouTube.YouTubeFeedWidgetDesigner.registerClass('SitefinityWebApp.Widgets.Social.YouTube.YouTubeFeedWidgetDesigner', Telerik.Sitefinity.Web.UI.ControlDesign.ControlDesignerBase);
if (typeof (Sys) !== 'undefined') Sys.Application.notifyScriptLoaded();