using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Sitefinity.Web.UI.ControlDesign;

namespace SitefinityWebApp.Widgets.Social.Twitter
{
	/// <summary>
	/// Sitefinity Widget for displaying a twitter user profile
	/// </summary>
	[ControlDesigner(typeof(Widgets.Social.Twitter.TwitterProfileWidgetDesigner)), PropertyEditorTitle("Twitter Profile")]
	public partial class TwitterProfileWidget : System.Web.UI.UserControl
	{
		#region Private Properties

		private string _username = "sitefinity";
		private int _maxTweets = 10;
		private int _width = 240;
		private bool _autoWidth = false;
		private int _height = 400;
		private bool _showTimeStamp = false;

		#endregion

		#region Public Properties
		/// <summary>
		/// Gets or sets the twitter username.
		/// </summary>
		/// <value>
		/// The twitter username.
		/// </value>
		public string Username
		{
			get { return _username; }
			set { _username = value; }
		}

		/// <summary>
		/// Gets or sets the number of tweets to retreive.
		/// </summary>
		/// <value>
		/// The number tweets to retreive.
		/// </value>
		public int MaxTweets
		{
			get { return _maxTweets; }
			set { _maxTweets = value; }
		}

		/// <summary>
		/// Gets or sets the width of the widget container.
		/// </summary>
		/// <value>
		/// The width of the widget container.
		/// </value>
		public int Width
		{
			get { return _width; }
			set { _width = value; }
		}

		public bool AutoWidth
		{
			get { return _autoWidth; }
			set { _autoWidth = value; }
		}

		/// <summary>
		/// Gets or sets the height of the widget container.
		/// </summary>
		/// <value>
		/// The height of the widget container.
		/// </value>
		public int Height
		{
			get { return _height; }
			set { _height = value; }
		}

		/// <summary>
		/// Gets or sets a value indicating whether to show twitter time stamp.
		/// </summary>
		/// <value>
		///   <c>true</c> if time stamp should be shown; otherwise, <c>false</c>.
		/// </value>
		public bool ShowTimeStamp
		{
			get { return _showTimeStamp; }
			set { _showTimeStamp = value; }
		}

		#endregion

		protected override void OnInit(EventArgs e)
		{
			base.OnInit(e);
			Page.ClientScript.RegisterClientScriptInclude("TwitterProfile", "http://widgets.twimg.com/j/2/widget.js");
		}
	}
}