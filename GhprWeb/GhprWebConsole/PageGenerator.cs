using System.Collections.Generic;
using System.IO;
using GhprWeb;
using GhprWeb.EmbeddedResources;
using GhprWeb.Extensions;
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
                        .Columns(() => w
                            .H1("Text size h1")
                            .OneThirdColumn(() => w
                                .H2("Table (h2)")
                                .SortableTable(
                                    new[] {"Name", "City", "Score"},
                                    new[] {"John", "Saint-Petersburg", "154"},
                                    new[] {"Elvis", "NYC", "150"},
                                    new[] {"Jane", "Moscow", "123"})
                            )
                            .TwoThirdsColumn(() => w
                                .SortableTable(
                                    new List<string> { "Name", "City", "Score" },
                                    new List<List<string>>
                                    {
                                        new List<string> {"John", "Saint-Petersburg", "154"},
                                        new List<string> {"Elvis", "NYC", "150"},
                                        new List<string> {"Jane", "Moscow", "123"}
                                    }
                                )
                                .SortableTable(() => w
                                    .THead(() => w
                                        .Tr(() => w
                                            .Th("Name")
                                            .Th("City (no sortable)", false)
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
                            )
                        )
                    ),
                PageStylePaths = re.GetResoucresPaths(pageResources, Extension.Css),
                ScriptFilePaths = re.GetResoucresPaths(pageResources, Extension.Js)
            };

            page.SavePage(path.Equals("") ? Utils.CurrentPath : path, name.Equals("") ? "index.html" : name);
        }
    }
}
