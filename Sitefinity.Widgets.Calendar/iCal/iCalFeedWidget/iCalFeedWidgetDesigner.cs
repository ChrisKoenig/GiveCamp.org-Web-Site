﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telerik.Sitefinity.Web.UI.ControlDesign;
using System.Web.UI;

namespace Sitefinity.Widgets.Calendar.iCalFeed
{
	public class iCalFeedWidgetDesigner : ControlDesignerBase
	{
		// embedded resources
		private const string LayoutTemplateReference = "Sitefinity.Widgets.Calendar.iCalFeed.iCalFeedWidgetDesignerTemplate.ascx";
		private const string DesignerScriptReference = "Sitefinity.Widgets.Calendar.iCalFeed.iCalFeedWidgetDesigner.js";

		/// <summary>
		/// Initializes the controls.
		/// </summary>
		/// <param name="container">The container.</param>
		protected override void InitializeControls(Telerik.Sitefinity.Web.UI.GenericContainer container)
		{
			base.DesignerMode = ControlDesignerModes.Simple;
		}

		/// <summary>
		/// Gets the name of the layout template.
		/// </summary>
		/// <value>
		/// The name of the layout template.
		/// </value>
		protected override string LayoutTemplateName
		{
			get { return LayoutTemplateReference; }
		}

		/// <summary>
		/// Gets the script references.
		/// </summary>
		/// <returns></returns>
		public override IEnumerable<ScriptReference> GetScriptReferences()
		{
			// get script collection
			var scripts = base.GetScriptReferences() as List<ScriptReference>;
			if (scripts == null) return base.GetScriptReferences();

			// add script from embedded resource
			var assemblyName = this.GetType().Assembly.GetName().ToString();
			scripts.Add(new ScriptReference(DesignerScriptReference, assemblyName));
			
			return scripts.ToArray();
		}
	}
}