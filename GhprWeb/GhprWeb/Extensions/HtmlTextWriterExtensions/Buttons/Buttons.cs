using System.Web.UI;
using GhprWeb.Extensions.HtmlTextWriterExtensions.Tags;

namespace GhprWeb.Extensions.HtmlTextWriterExtensions.Buttons
{
    public static class Buttons
    {
        public static HtmlTextWriter DangerButton(this HtmlTextWriter writer, string text, string href)
        {
            writer
                .Class("btn btn-danger")
                .Href(href)
                .Type("button")
                .A(text);
            return writer;
        }

        public static HtmlTextWriter ViewButton(this HtmlTextWriter writer, string text, string href)
        {
            writer
                .Class("btn btn-sm")
                .Href(href)
                .Type("button")
                .OpenTag(HtmlTextWriterTag.A)
                .Class("octicon octicon-eye")
                .Tag(HtmlTextWriterTag.Span)
                .Text("  " + text)
                .CloseTag();//A
            return writer;
        }
    }
}
