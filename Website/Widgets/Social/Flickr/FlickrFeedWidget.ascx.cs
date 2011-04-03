using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using Telerik.Sitefinity.Web.UI.ControlDesign;

namespace SitefinityWebApp.Widgets.Social.Flickr
{
	/// <summary>
	/// Sitefinity widget to display recent images from a Flickr account
	/// </summary>
	[ControlDesigner(typeof(Widgets.Social.Flickr.FlickrFeedWidgetDesigner)), PropertyEditorTitle("Flickr Feed")]
	public partial class FlickrFeedWidget : System.Web.UI.UserControl
	{
		#region Private Properties

		private string _userID = "57076622@N02";
		private string _username = "sitefinity";
		private bool _showTitles = true;
		private int _maxPhotos = 10;

		#endregion

		#region Public Properies

		/// <summary>
		/// Gets or sets the Flickr user ID.
		/// </summary>
		/// <value>
		/// The Flickr user ID.
		/// </value>
		public string UserID
		{
			get { return _userID; }
			set { _userID = value; }
		}

		public string Username
		{
			get { return _username; }
			set { _username = value; }
		}

		public bool ShowTitles
		{
			get { return _showTitles; }
			set { _showTitles = value; }
		}

		/// <summary>
		/// Gets or sets the max number photos to show.
		/// </summary>
		/// <value>
		/// The max number of photos.
		/// </value>
		public int MaxPhotos
		{
			get { return _maxPhotos; }
			set { _maxPhotos = value; }
		}

		/// <summary>
		/// Gets or sets the flickr tags to match/search.
		/// </summary>
		/// <value>
		/// The Flickr tags.
		/// </value>
		public string Tags { get; set; }

		#endregion

		#region Constants

		const string FEED_URL = "http://api.flickr.com/services/feeds/photos_public.gne?id={0}&lang=en-us&format=rss_200";

		#endregion

		protected void Page_Load(object sender, EventArgs e)
		{
			// ensure the username is valid
			if (string.IsNullOrEmpty(UserID)) return;

			// retrieve contents
			var url = string.Format(FEED_URL, UserID);
			var flickrXml = XDocument.Load(url);
			if (flickrXml == null) return;

			// parse to collection
			XNamespace media = "http://search.yahoo.com/mrss/";
			var query = from t in flickrXml.Descendants("item") select new { Thumbnail = t.Element(media + "thumbnail").Attribute("url").Value, Url = t.Element("link").Value, Title = t.Element("title").Value };

			// empty result?
			if (query.Count() == 0) return;

			// bind, limiting count
			FlickrRepeater.DataSource = query.Take(MaxPhotos);
			FlickrRepeater.DataBind();
		}

		protected string PhotoTitle(object Title, object Url)
		{
			// hide titles?
			if (!ShowTitles) return string.Empty;
			if (Title == null || Url == null) return string.Empty;

			// format title
			return string.Format("<a href=\"{0}\" target=\"_blank\">{1}</a>", Url, Title);
		}
	}
}