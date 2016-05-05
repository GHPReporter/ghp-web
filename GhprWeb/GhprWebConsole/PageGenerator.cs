using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using GhprWeb.EmbeddedResources;
using GhprWeb.Extensions;
using GhprWeb.Extensions.HtmlTextWriterExtensions;
using GhprWeb.Extensions.HtmlTextWriterExtensions.Tags;
using GhprWeb.Html;
using static GhprWeb.EmbeddedResources.Resources;

namespace GhprWebConsole
{
    public static class PageGenerator
    {
        public static string CurrentPath
        {
            get
            {
                var codeBase = Assembly.GetExecutingAssembly().CodeBase;
                var uri = new UriBuilder(codeBase);
                var path = Uri.UnescapeDataString(uri.Path);

                return Path.GetDirectoryName(path);
            }
        }

        public static void GenerateTestPage(string path = "", string name = "")
        {
            var pageResources = new[] {Resource.Octicons, Resource.Primer};

            var re = new ResourceExtractor(Path.Combine(CurrentPath, "src"));
            re.Extract(pageResources);

            var page = new HtmlPage("Test page")
            {
                PageBodyCode = HtmlBuilder.Build(w => w.Div(() => w.Text("Text"))),
                PageStylePaths = re.GetResoucresPaths(pageResources)
            };
            
            page.SavePage(path.Equals("") ? CurrentPath : path, name.Equals("") ? "index.html" : name);
        }
    }
}
