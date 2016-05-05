using System.IO;
using GhprWeb;
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
        public static void GenerateTestPage(string path = "", string name = "")
        {
            var pageResources = new[]
            {
                Resource.Octicons,
                Resource.Primer,
                Resource.Tablesort,
                Resource.Github
            };

            var re = new ResourceExtractor(Path.Combine(Utils.CurrentPath, "src"), @".\src");
            re.Extract(pageResources);

            var page = new HtmlPage("Test page")
            {
                PageBodyCode = HtmlBuilder
                    .Build(w => w
                        .Div(() => w
                            .H2("Text")
                            .Id("table-example")
                            .Table(() => w
                                .THead(() => w
                                    .Tr(() => w
                                        .NoSortTh("Name")
                                        .Th("City")
                                        .Th("Score")
                                    )
                                )
                                .TBody(() => w
                                    .Tr(() => w
                                        .Td("Elvis")
                                        .Td("NYC")
                                        .Td("150"))
                                    .Tr(() => w
                                        .Td("Jane")
                                        .Td("Moscow")
                                        .Td("123"))
                                    .Tr(() => w
                                        .Td("John")
                                        .Td("Saint-Peterburg")
                                        .Td("154"))
                                )
                            )
                            .Script(@"new Tablesort(document.getElementById('table-example'));")
                        )
                    ),
                PageStylePaths = re.GetResoucresPaths(pageResources, Extension.Css),
                ScriptFilePaths = re.GetResoucresPaths(pageResources, Extension.Js)
            };
            
            page.SavePage(path.Equals("") ? Utils.CurrentPath : path, name.Equals("") ? "index.html" : name);
        }
    }
}
