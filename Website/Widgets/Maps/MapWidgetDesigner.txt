Type.registerNamespace("SitefinityWebApp.Widgets.Maps");

SitefinityWebApp.Widgets.Maps.MapWidgetDesigner = function (element) {
	SitefinityWebApp.Widgets.Maps.MapWidgetDesigner.initializeBase(this, [element]);
}


SitefinityWebApp.Widgets.Maps.MapWidgetDesigner.SearchMap = function () {
	jQuery("#LoadingPanel").css("display", "block");

	var street = jQuery.trim($("#Street").val());
	var city = jQuery.trim($("#City").val());
	var state = jQuery.trim($("#State").val());
	var zipcode = jQuery.trim($("#Zipcode").val());

	var address = street + ' ' + city + ' ' + state + ' ' + zipcode;
	if (address.length < 1 || city.length < 1 || state.length < 1) {
		jQuery("#LoadingPanel").css("display", "none");
		alert("Address cannot be blank");
		return;
	}

	map = new VEMap('hiddenmap');
	map.LoadMap();
	map.Find("", address, null, null, 0, 1, true, true, true, true, SitefinityWebApp.Widgets.Maps.FindCallBack);
}

SitefinityWebApp.Widgets.Maps.FindCallBack = function(layer, resultsArray, places, hasMore, VEErrorMessage) {

	if (places == null) {
		jQuery("#LoadingPanel").css("display", "none");
		alert("Address not found, please try again.");
		return;
	}

	$.each(places, function (i, item) {
		$("#Latitude").val(item.LatLong.Latitude.toString());
		$("#Longitude").val(item.LatLong.Longitude.toString());
	});
	jQuery("#LoadingPanel").css("display", "none");
}

SitefinityWebApp.Widgets.Maps.MapWidgetDesigner.prototype = {
	initialize: function () {
		SitefinityWebApp.Widgets.Maps.MapWidgetDesigner.callBaseMethod(this, 'initialize');
		jQuery("#Geocode").click(SitefinityWebApp.Widgets.Maps.MapWidgetDesigner.SearchMap);
	},
	dispose: function () {
		SitefinityWebApp.Widgets.Maps.MapWidgetDesigner.callBaseMethod(this, 'dispose');
	},
	refreshUI: function () {
		var data = this._propertyEditor.get_control();
		jQuery("#Location").val(data.Location);
		jQuery("#Street").val(data.Street);
		jQuery("#City").val(data.City);
		jQuery("#State").val(data.State);
		jQuery("#Zipcode").val(data.Zipcode);

		jQuery("#Width").val(data.Width);
		jQuery("#Height").val(data.Height);
		jQuery("#Zoom").val(data.Zoom);
		jQuery("#DashboardSize").val(data.DashboardSize);

		jQuery("#Latitude").val(data.Latitude);
		jQuery("#Longitude").val(data.Longitude);


	},
	applyChanges: function () {

		var controlData = this._propertyEditor.get_control();

		controlData.Location = jQuery("#Location").val();
		controlData.Street = jQuery("#Street").val();
		controlData.City = jQuery("#City").val();
		controlData.State = jQuery("#State").val();
		controlData.Zipcode = jQuery("#Zipcode").val();

		controlData.Width = jQuery("#Width").val();
		controlData.Height = jQuery("#Height").val();
		controlData.Zoom = jQuery("#Zoom").val();
		controlData.DashboardSize = jQuery("#DashboardSize").val();

		controlData.Latitude = jQuery("#Latitude").val();
		controlData.Longitude = jQuery("#Longitude").val();

	}
}

SitefinityWebApp.Widgets.Maps.MapWidgetDesigner.registerClass('SitefinityWebApp.Widgets.Maps.MapWidgetDesigner', Telerik.Sitefinity.Web.UI.ControlDesign.ControlDesignerBase);
if (typeof (Sys) !== 'undefined') Sys.Application.notifyScriptLoaded();