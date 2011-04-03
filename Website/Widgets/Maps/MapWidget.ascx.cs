using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Sitefinity.Web.UI.ControlDesign;

namespace SitefinityWebApp.Widgets.Maps
{
	/// <summary>
	/// Sitefinity Widget to display a Bing Map for a given address
	/// </summary>
	[ControlDesigner(typeof(Widgets.Maps.MapWidgetDesigner)), PropertyEditorTitle("Bing Map")]
	public partial class MapWidget : System.Web.UI.UserControl
	{

		#region Private Properties

		private string _location = "Telerik";
		private string _street = "10200 Grogans Mill Rd, Suite 130";
		private string _city = "The Woodlands";
		private string _state = "TX";
		private string _zipcode = "77380";

		private string _latitude = "30.15667";
		private string _longitude = "-95.471005";
		private string _zoom = "14";

		private int _width = 400;
		private int _height = 300;
		private string _dashboardSize = "Normal";

		#endregion

		#region Public Properties

		/// <summary>
		/// Gets or sets the name of the location (company, building, etc).
		/// </summary>
		/// <value>
		/// The location name.
		/// </value>
		public string Location
		{
			get { return _location; }
			set { _location = value; }
		}

		/// <summary>
		/// Gets or sets the street address.
		/// </summary>
		/// <value>
		/// The physical street address.
		/// </value>
		public string Street
		{
			get { return _street; }
			set { _street = value; }
		}

		/// <summary>
		/// Gets or sets the city.
		/// </summary>
		/// <value>
		/// The city.
		/// </value>
		public string City
		{
			get { return _city; }
			set { _city = value; }
		}

		/// <summary>
		/// Gets or sets the state.
		/// </summary>
		/// <value>
		/// The state.
		/// </value>
		public string State
		{
			get { return _state; }
			set { _state = value; }
		}

		/// <summary>
		/// Gets or sets the zipcode.
		/// </summary>
		/// <value>
		/// The zipcode.
		/// </value>
		public string Zipcode
		{
			get { return _zipcode; }
			set { _zipcode = value; }
		}

		/// <summary>
		/// Gets or sets the latitude.
		/// </summary>
		/// <value>
		/// The latitude.
		/// </value>
		public string Latitude
		{
			get { return _latitude; }
			set { _latitude = value; }
		}

		/// <summary>
		/// Gets or sets the longitude.
		/// </summary>
		/// <value>
		/// The longitude.
		/// </value>
		public string Longitude
		{
			get { return _longitude; }
			set { _longitude = value; }
		}

		/// <summary>
		/// Gets or sets the zoom level of the map.
		/// </summary>
		/// <value>
		/// The map zoom level.
		/// </value>
		public string Zoom
		{
			get { return _zoom; }
			set { _zoom = value; }
		}

		/// <summary>
		/// Gets or sets the width (in pixels) of the map.
		/// </summary>
		/// <value>
		/// The map width (in pixels).
		/// </value>
		public int Width
		{
			get { return _width; }
			set { _width = value; }
		}

		/// <summary>
		/// Gets or sets the height (in pixels) of the map.
		/// </summary>
		/// <value>
		/// The map height (in pixels).
		/// </value>
		public int Height
		{
			get { return _height; }
			set { _height = value; }
		}

		/// <summary>
		/// Gets or sets the size of the map dashboard.
		/// </summary>
		/// <value>
		/// The size of the map dashboard.
		/// </value>
		public string DashboardSize
		{
			get { return _dashboardSize; }
			set { _dashboardSize = value; }
		}

		#endregion

		protected void Page_Load(object sender, EventArgs e)
		{

		}
	}
}