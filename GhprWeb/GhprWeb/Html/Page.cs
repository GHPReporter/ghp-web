using System.Collections.Generic;
using System.IO;
using System.Web.UI;
using GhprWeb.Extensions.HtmlTextWriterExtensions;
using GhprWeb.Extensions.HtmlTextWriterExtensions.Styles;
using GhprWeb.Extensions.HtmlTextWriterExtensions.Tags;

// ReSharper disable AccessToDisposedClosure

namespace GhprWeb.Html
{
    public class HtmlPage
    {
        public string FullPage { get; private set; }

        public string PageTitle;
        public string PageBodyCode = "";
        public string PageScriptString = "";
        public string PageFooterCode = "";
        public List<string> PageStylePaths = new List<string>();
        public List<string> ScriptFilePaths = new List<string>();

        public HtmlPage(string pageTitle)
        {
            PageTitle = pageTitle;
        }

        private void GeneratePageString()
        {
            var strWr = new StringWriter();
            using (var writer = new HtmlTextWriter(strWr))
            {
                writer
                    .WriteString("<!DOCTYPE html>")
                    .NewLine()
                    .Tag(HtmlTextWriterTag.Head, () => writer
                        .Tag(HtmlTextWriterTag.Meta, new Dictionary<string, string>
                        {
                            {"http-equiv", "X-UA-Compatible"},
                            {"content", @"IE=edge"},
                            {"charset", "utf-8"}
                        })
                        .Title(PageTitle)
                        .Scripts(ScriptFilePaths)
                        .TagIf(!PageScriptString.Equals(""), HtmlTextWriterTag.Script, PageScriptString)
                        .Type(@"text/css")
                        .Tag(HtmlTextWriterTag.Style)
                        .Stylesheets(PageStylePaths)

                    )
                    .Tag(HtmlTextWriterTag.Body, () => writer
                        .Class("border-bottom p-3 mb-3 bg-gray")
                        .Div(() => writer
                            .Class("container")
                            .Div(() => writer
                                .TextAlign("center")
                                .Div(() => writer
                                    .H1(PageTitle)
                                )
                            )
                        )
                        .Class("container")
                        .Tag(HtmlTextWriterTag.Div, () => writer
                            .Write(PageBodyCode)
                        )
                    )
                    .NewLine()
                    .Footer()
                    .NewLine()
                    .WriteString("</html>")
                    .NewLine();
            }
            FullPage = strWr.ToString();
        }

        public void SavePage(string path, string name = "index.html")
        {
            GeneratePageString();
            File.WriteAllText(Path.Combine(path, name), FullPage);
        }
    }
}
