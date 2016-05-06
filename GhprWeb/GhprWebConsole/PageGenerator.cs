using System.IO;
using GhprWeb;
using GhprWeb.EmbeddedResources;
using GhprWeb.Extensions;
using GhprWeb.Extensions.HtmlTextWriterExtensions;
using GhprWeb.Extensions.HtmlTextWriterExtensions.Buttons;
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
                Resource.Github,
                Resource.JQuery 
            };

            var re = new ResourceExtractor(Path.Combine(Utils.CurrentPath, "src"), @".\src");
            re.Extract(pageResources);

            var page = new HtmlPage("Test page")
            {
                PageBodyCode = HtmlBuilder
                    .Build(w => w
                        .Columns(() => w
                            .H1("Text size h1")
                            .OneThirdColumn(() => w
                                .H2("One third: Table (h2)")
                                .SortableTable(
                                    new[] {"Name", "City", "Score"},
                                    new[] {"John", "Saint-Petersburg", "154"},
                                    new[] {"Elvis", "NYC", "150"},
                                    new[] {"Jane", "Moscow", "123"})
                                .Menu("Menu heading", () => w
                                    .MenuItem("button 1")
                                    .MenuItem("button 2")
                                    .MenuItem("button 3")
                                )
                            )
                            .TwoThirdsColumn(() => w
                                .H2("Two thirds")
                                .Menu(
                                    new[] { "Graph", "#", "octicon octicon-graph" },
                                    new[] { "Checklist", "#", "octicon octicon-checklist" },
                                    new[] { "Clock", "#", "octicon octicon-clock" }
                                )
                                .SortableTable(() => w
                                    .THead(() => w
                                        .Tr(() => w
                                            .Th("Name").Th("City (no sortable)", false).Th("Score")
                                        )
                                    )
                                    .TBody(() => w
                                        .Tr(() => w.Td("Elvis").Td("NYC").Td("150"))
                                        .Tr(() => w.Td("Jane").Td("Moscow").Td("123"))
                                        .Tr(() => w.Td("John").Td("Saint-Peterburg").Td("154"))
                                    )
                                )
                            )
                        )
                        .TabNav(() => w
                            .TabNavTabs(() => w
                                .TabNavTab("Flame", "#flame-div", "octicon octicon-flame", true)
                                .TabNavTab("Bug", "#bug-div", "octicon octicon-bug")
                                .TabNavTab("Dashboard", "#dashboard-div", "octicon octicon-dashboard")
                                .TabNavTab("Globe", "#globe-div", "octicon octicon-globe")
                            )
                        )
                        .ShowHideButton("show/hide togglable div", "#flame-div")
                        .TogglableDiv("flame-div", false, () => w
                            .H1("Flame!")
                        )
                    ),
                PageStylePaths = re.GetResoucresPaths(pageResources, Extension.Css),
                ScriptFilePaths = re.GetResoucresPaths(pageResources, Extension.Js)
            };

            page.SavePage(path.Equals("") ? Utils.CurrentPath : path, name.Equals("") ? "index.html" : name);
        }
    }
}
