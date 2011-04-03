Type.registerNamespace("SitefinityWebApp.Widgets.Social.Vimeo");

SitefinityWebApp.Widgets.Social.Vimeo.VimeoFeedWidgetDesigner = function (element) {
    SitefinityWebApp.Widgets.Social.Vimeo.VimeoFeedWidgetDesigner.initializeBase(this, [element]);
}


SitefinityWebApp.Widgets.Social.Vimeo.VimeoFeedWidgetDesigner.prototype = {
    initialize: function () {
        SitefinityWebApp.Widgets.Social.Vimeo.VimeoFeedWidgetDesigner.callBaseMethod(this, 'initialize');

    },
    dispose: function () {
        SitefinityWebApp.Widgets.Social.Vimeo.VimeoFeedWidgetDesigner.callBaseMethod(this, 'dispose');
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

SitefinityWebApp.Widgets.Social.Vimeo.VimeoFeedWidgetDesigner.registerClass('SitefinityWebApp.Widgets.Social.Vimeo.VimeoFeedWidgetDesigner', Telerik.Sitefinity.Web.UI.ControlDesign.ControlDesignerBase);
if (typeof (Sys) !== 'undefined') Sys.Application.notifyScriptLoaded();