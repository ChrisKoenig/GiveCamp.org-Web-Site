using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using Telerik.Sitefinity.Web.UI.ControlDesign;

namespace SitefinityWebApp.Widgets.Social.YouTube
{
	/// <summary>
	/// Sitefinity Widget to show recent videos from a YouTube account
	/// </summary>
	[ControlDesigner(typeof(Widgets.Social.YouTube.YouTubeFeedWidgetDesigner)), PropertyEditorTitle("YouTube Latest Videos")]
	public partial class YouTubeFeedWidget : System.Web.UI.UserControl
	{
		#region Private Properties

		private string _username = "cityofmcallen";
		private bool _showTitles = true;
		private int _maxVideos = 5;

		#endregion

		#region Public Properties

		/// <summary>
		/// Gets or sets the YouTube username.
		/// </summary>
		/// <value>
		/// The YouTube username.
		/// </value>
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
		/// Gets or sets the max nnumber of videos to retrieve.
		/// </summary>
		/// <value>
		/// The max number of videos.
		/// </value>
		public int MaxVideos
		{
			get { return _maxVideos; }
			set { _maxVideos = value; }
		}

		#endregion

		#region Constants

		const string FEED_URL = "http://gdata.youtube.com/feeds/base/users/{0}/uploads?alt=rss";

		#endregion

		/// <summary>
		/// Handles the Load event of the Page control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		protected void Page_Load(object sender, EventArgs e)
		{
			// ensure the username is valid
			if (string.IsNullOrEmpty(Username)) return;

			// retrieve contents
			var url = string.Format(FEED_URL, Username);
			var vidXml = XDocument.Load(url);
			if (vidXml == null) return;

			// parse to collection
			var query = from t in vidXml.Descendants("item") select new { Url = t.Element("link").Value, Title = t.Element("title").Value, Thumbnail = ToThumbnail(t.Element("link").Value) };

			// empty set?
			if (query.Count() == 0) return;

			// bind, limiting count
			YouTubeRepeater.DataSource = query.Take(MaxVideos);
			YouTubeRepeater.DataBind();
		}

		/// <summary>
		/// Retrieves a thumbnail for a youtube video link
		/// </summary>
		/// <param name="input">The url to the video.</param>
		/// <returns></returns>
		protected string ToThumbnail(string input)
		{
			// retrieve url
			var uri = new Uri(input);

			// parse to querystring
			var qs = HttpUtility.ParseQueryString(uri.Query);
			var vidID = qs["v"];

			// create thumbnail from qs
			return string.IsNullOrEmpty(vidID) ? string.Empty : string.Format("http://img.youtube.com/vi/{0}/2.jpg", vidID);
		}

		protected string VideoTitle(object Title, object Url)
		{
			// hide titles?
			if (!ShowTitles) return string.Empty;
			if (Title == null || Url == null) return string.Empty;

			// format title
			return string.Format("<a href=\"{0}\" target=\"_blank\">{1}</a>", Url, Title);
		}
	}
}