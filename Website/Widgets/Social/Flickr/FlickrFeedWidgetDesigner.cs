using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telerik.Sitefinity.Web.UI.ControlDesign;
using System.Web.UI;

namespace SitefinityWebApp.Widgets.Social.Flickr
{
    public class FlickrFeedWidgetDesigner : ControlDesignerBase
    {
        protected override void InitializeControls(Telerik.Sitefinity.Web.UI.GenericContainer container)
        {
            base.DesignerMode = ControlDesignerModes.Simple;
        }

        private string _layoutTemplatePath = "~/Widgets/Social/Flickr/FlickrFeedWidgetDesignerTemplate.ascx";
        public override string LayoutTemplatePath
        {
            get { return _layoutTemplatePath; }
            set { _layoutTemplatePath = value; }
        }

        private string _scriptPath = "~/Widgets/Social/Flickr/FlickrFeedWidgetDesigner.js";
        public string DesignerScriptPath
        {
            get { return _scriptPath; }
            set { _scriptPath = value; }
        }

        protected override string LayoutTemplateName
        {
            get { return "Flickr Feed Widget Designer Template"; }
        }

        public override IEnumerable<ScriptReference> GetScriptReferences()
        {
            var scripts = base.GetScriptReferences() as List<ScriptReference>;
            if (scripts == null) return base.GetScriptReferences();

            scripts.Add(new ScriptReference(DesignerScriptPath));
            return scripts.ToArray();
        }
    }
}