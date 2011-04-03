using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using System.Text.RegularExpressions;
using Telerik.Sitefinity.Web.UI.ControlDesign;

namespace SitefinityWebApp.Widgets.Social.Twitter
{
	[ControlDesigner(typeof(Widgets.Social.Twitter.TwitterFeedWidgetDesigner)), PropertyEditorTitle("Twitter Feed")]
	public partial class TwitterFeedWidget : System.Web.UI.UserControl
	{
		#region Private Properties
		
		private string _username = "sitefinity";
		private int _maxTweets = 10;
		private int _width = 240;
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

		#region Constants

		const string FEED_URL = "http://twitter.com/statuses/user_timeline/{0}.rss?count={1}";

		private const RegexOptions Options = RegexOptions.Compiled | RegexOptions.IgnoreCase;

		/// <summary>
		/// Jon Gruber's URL Regex: http://daringfireball.net/2009/11/liberal_regex_for_matching_urls
		/// </summary>
		private static readonly Regex _parseUrls = new Regex(@"\b(([\w-]+://?|www[.])[^\s()<>]+(?:\([\w\d]+\)|([^\p{P}\s]|/)))", Options);

		/// <summary>
		/// Diego Sevilla's @ (mention) Regex: http://stackoverflow.com/questions/529965/how-could-i-combine-these-regex-rules
		/// </summary>
		private static readonly Regex _parseMentions = new Regex(@"(^|\W)@([A-Za-z0-9_]+)", Options);

		/// <summary>
		/// Simon Whatley's # (hashtag) Regex: http://www.simonwhatley.co.uk/parsing-twitter-usernames-hashtags-and-urls-with-javascript
		/// </summary>
		private static readonly Regex _parseHashtags = new Regex("[#]+[A-Za-z0-9-_]+", Options);

		#endregion

		protected void Page_Load(object sender, EventArgs e)
		{
			// ensure the username is valid
			if (string.IsNullOrEmpty(Username)) return;

			// retrieve contents
			var url = string.Format(FEED_URL, Username, MaxTweets);
			var twitterXML = XDocument.Load(url);
			if (twitterXML == null) return;

			// parse to collection
			var query = from t in twitterXML.Descendants("item") select new { TweetID = ToGuid(t.Element("guid").Value), Tweet = ToHtml(t.Element("title").Value), TimeStamp = ToDate(t.Element("pubDate").Value), Url = t.Element("link").Value };

			// bind if not empty
			if (query.Count() == 0) return;

			// bind
			TwitterRepeater.DataSource = query;
			TwitterRepeater.DataBind();
		}

		protected string ToGuid(string input)
		{
			// empty string
			if (string.IsNullOrEmpty(input)) { return string.Empty; }

			var url = input.Split('/');
			if (url.Length == 0) return string.Empty;

			return url[url.Length - 1];
		}

		/// <summary>
		/// Converts the string date to a DateTime
		/// </summary>
		/// <param name="input">The input string.</param>
		/// <returns>DateTime of the timestamp</returns>
		protected string ToDate(string input)
		{
			// empty string
			if (string.IsNullOrEmpty(input)) { return string.Empty; }

			DateTime d;
			if (!DateTime.TryParse(input, out d)) return string.Empty;

			var ts = DateTime.Now.Subtract(d);
			if (ts.Days >= 1)
				return string.Concat(ts.Days, " Days Ago");

			if (ts.Hours >= 1)
				return string.Concat(ts.Hours, " Hours Ago");

			return string.Concat(ts.Minutes, " Minutes Ago");
		}

		/// <summary>
		/// Linkified hashtags, usernames, and links in the text.
		/// </summary>
		/// <param name="input">The input text to be linkified.</param>
		/// <returns></returns>
		protected string ToHtml(string input)
		{
			// empty string
			if (string.IsNullOrEmpty(input)) { return input; }

			// match URLs
			foreach (Match match in _parseUrls.Matches(input))
			{
				var url = match.Value.StartsWith("http") ? match.Value : string.Concat("http://", match.Value);
				input = input.Replace(match.Value, string.Format("<a href=\"{0}\" target=\"_blank\">{0}</a>", url));
			}

			// match @ mentinos
			foreach (Match match in _parseMentions.Matches(input))
			{
				if (match.Groups.Count != 3)
				{
					continue;
				}

				var screenName = match.Groups[2].Value;
				var mention = "@" + screenName;

				input = input.Replace(mention, string.Format("<a href=\"http://twitter.com/{0}\" target=\"_blank\">{1}</a>", screenName, match.Value));
			}

			// match # hashtags
			foreach (Match match in _parseHashtags.Matches(input))
			{
				var hashtag = Server.UrlEncode(match.Value);
				input = input.Replace(match.Value, string.Format("<a href=\"http://search.twitter.com/search?q={0}\" target=\"_blank\">{1}</a>", hashtag, match.Value));
			}

			return input;
		}
	}
}