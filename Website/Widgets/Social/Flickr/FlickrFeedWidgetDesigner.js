Type.registerNamespace("SitefinityWebApp.Widgets.Social.Flickr");

SitefinityWebApp.Widgets.Social.Flickr.FlickrFeedWidgetDesigner = function (element) {
    SitefinityWebApp.Widgets.Social.Flickr.FlickrFeedWidgetDesigner.initializeBase(this, [element]);
}


SitefinityWebApp.Widgets.Social.Flickr.FlickrFeedWidgetDesigner.prototype = {
    initialize: function () {
        SitefinityWebApp.Widgets.Social.Flickr.FlickrFeedWidgetDesigner.callBaseMethod(this, 'initialize');

    },
    dispose: function () {
        SitefinityWebApp.Widgets.Social.Flickr.FlickrFeedWidgetDesigner.callBaseMethod(this, 'dispose');
    },
    refreshUI: function () {
        var data = this._propertyEditor.get_control();
        jQuery("#UserID").val(data.UserID);
        jQuery("#MaxPhotos").val(data.MaxPhotos);
        jQuery("#ShowTitles").attr('checked', data.ShowTitles);
    },
    applyChanges: function () {

        var controlData = this._propertyEditor.get_control();

        controlData.UserID = jQuery("#UserID").val();
        controlData.MaxPhotos = jQuery("#MaxPhotos").val();
        controlData.ShowTitles = jQuery("#ShowTitles").attr('checked');
    }
}

SitefinityWebApp.Widgets.Social.Flickr.FlickrFeedWidgetDesigner.registerClass('SitefinityWebApp.Widgets.Social.Flickr.FlickrFeedWidgetDesigner', Telerik.Sitefinity.Web.UI.ControlDesign.ControlDesignerBase);
if (typeof (Sys) !== 'undefined') Sys.Application.notifyScriptLoaded();