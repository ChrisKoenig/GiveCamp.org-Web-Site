<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MapWidget.ascx.cs" Inherits="SitefinityWebApp.Widgets.Maps.MapWidget" %>

<script type="text/javascript" src="http://ecn.dev.virtualearth.net/mapcontrol/mapcontrol.ashx?v=6.2"></script>
<script type="text/javascript">
<!--
	function GetMap() {
		map = new VEMap('MyMap');
		map.SetDashboardSize(VEDashboardSize.<%= DashboardSize %>);
		map.LoadMap(new VELatLong(<%= Latitude %>, <%= Longitude %>), <%= Zoom %>);
		
		var shape;

		shape = new VEShape(VEShapeType.Pushpin, new VELatLong(<%= Latitude %>,	<%= Longitude %>));
		shape.SetTitle("<%= Location %>");
		shape.SetDescription('<p><strong><%= Street %></strong><br /><%= City %>, <%= State %> <%= Zipcode %></p>');
		map.AddShape(shape);
		}

		$(function() { GetMap();});
	-->
</script>

<div id="MyMap" style="width: <%= Width %>px; height: <%= Height %>px; position: relative;">
	<address>
		<p>Loading Map (Requires Javascript) ...</p>
		<p>
			<strong><%= Location %></strong><br />
			<%= Street %><br />
			<%= City %>, <%= State %> <%= Zipcode %>
		</p>
	</address>
</div>