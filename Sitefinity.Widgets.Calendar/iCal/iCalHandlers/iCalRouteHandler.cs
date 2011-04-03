using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Routing;
using System.Web;


namespace Sitefinity.Widgets.Calendar.iCal.iCalHandler
{
	public class iCalRouteHandler : IRouteHandler
	{
		public IHttpHandler GetHttpHandler(RequestContext requestContext)
		{
			var eventID = (string)requestContext.RouteData.Values["id"];
			if (string.IsNullOrEmpty(eventID))
				return new iCalFeedHttpHandler(DateTime.Now.Year, DateTime.Now.Month);
			else
				return new iCalReminderHttpHandler(new Guid(eventID));
		}
	}
}
