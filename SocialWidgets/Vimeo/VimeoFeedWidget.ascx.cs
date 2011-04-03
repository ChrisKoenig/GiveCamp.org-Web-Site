using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using Telerik.Sitefinity.Web.UI.ControlDesign;

namespace Sitefinity.Widgets.Social.Vimeo
{
    /// <summary>
    /// Sitefinity widget to show videos from a Vimeo account
    /// </summary>
    [ControlDesigner(typeof(VimeoFeedWidgetDesigner)), PropertyEditorTitle("Vimeo Latest Videos")]
    public partial class VimeoFeedWidget : System.Web.UI.UserControl
    {
        #region Private Properties

        private string _username = "givecamp";
        private bool _showTitles = true;
        private int _maxVideos = 5;
        private XNamespace media_ns = "http://search.yahoo.com/mrss/";

        #endregion Private Properties

        #region Public Properties

        /// <summary>
        /// Gets or sets the Vimeo username.
        /// </summary>
        /// <value>
        /// The Vimeo username.
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

        #endregion Public Properties

        #region Constants

        const string FEED_URL = "http://vimeo.com/{0}/videos/rss";

        #endregion Constants

        protected void Page_Load(object sender, EventArgs e)
        {
            // ensure the username is valid
            if (string.IsNullOrEmpty(Username)) return;

            // retrieve contents
            var url = string.Format(FEED_URL, Username);
            var vidXml = XDocument.Load(url);
            if (vidXml == null) return;

            // parse to collection
            var query = from t in vidXml.Descendants("item")
                        select new
                        {
                            Url = t.Element("link").Value,
                            Title = t.Element("title").Value,
                            Thumbnail = t.Element(media_ns + "content").Element(media_ns + "thumbnail").Attribute("url").Value,
                        };

            // empty set?
            if (query.Count() == 0) return;

            // bind, limiting count
            VimeoRepeater.DataSource = query.Take(MaxVideos);
            VimeoRepeater.DataBind();
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