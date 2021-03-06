﻿Type.registerNamespace("SitefinityWebApp.Widgets.Social.Twitter");

SitefinityWebApp.Widgets.Social.Twitter.TwitterProfileWidgetDesigner = function (element) {
	SitefinityWebApp.Widgets.Social.Twitter.TwitterProfileWidgetDesigner.initializeBase(this, [element]);
}


SitefinityWebApp.Widgets.Social.Twitter.TwitterProfileWidgetDesigner.prototype = {
	initialize: function () {
		SitefinityWebApp.Widgets.Social.Twitter.TwitterProfileWidgetDesigner.callBaseMethod(this, 'initialize');

	},
	dispose: function () {
		SitefinityWebApp.Widgets.Social.Twitter.TwitterProfileWidgetDesigner.callBaseMethod(this, 'dispose');
	},
	refreshUI: function () {
		var data = this._propertyEditor.get_control();
		jQuery("#Username").val(data.Username);
		jQuery("#MaxTweets").val(data.MaxTweets);
		jQuery("#Width").val(data.Width);
		jQuery("#Height").val(data.Height);
		jQuery("#ShowTimeStamp").attr('checked', data.ShowTimeStamp);


	},
	applyChanges: function () {

		var controlData = this._propertyEditor.get_control();

		controlData.Username = jQuery("#Username").val();
		controlData.MaxTweets = jQuery("#MaxTweets").val();
		controlData.Width = jQuery("#Width").val();
		controlData.Height = jQuery("#Height").val();
		controlData.ShowTimeStamp = jQuery("#ShowTimeStamp").attr('checked');


	}
}

SitefinityWebApp.Widgets.Social.Twitter.TwitterProfileWidgetDesigner.registerClass('SitefinityWebApp.Widgets.Social.Twitter.TwitterProfileWidgetDesigner', Telerik.Sitefinity.Web.UI.ControlDesign.ControlDesignerBase);
if (typeof (Sys) !== 'undefined') Sys.Application.notifyScriptLoaded();