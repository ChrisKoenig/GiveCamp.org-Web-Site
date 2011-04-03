<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TwitterProfile.ascx.cs" Inherits="SitefinityWebApp.Widgets.Social.Twitter.TwitterProfileWidget" %>

<script type="text/javascript">

	new TWTR.Widget({
		version: 2,
		type: 'profile',
		rpp: <%= MaxTweets %>,
		interval: 6000,
		width: <%= AutoWidth ? "'auto'" : Width.ToString() %>,
		height: <%= Height %>,
		features: {
			scrollbar: false,
			loop: false,
			live: false,
			hashtags: true,
			timestamp: <%= ShowTimeStamp.ToString().ToLower() %>,
			avatars: false,
			behavior: 'all'
		}
	}).render().setUser('<%= Username %>').start();

</script>
