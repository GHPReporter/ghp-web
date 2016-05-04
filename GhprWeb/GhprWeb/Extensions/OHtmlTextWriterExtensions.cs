using System;
using System.Collections.Generic;
using System.Web.UI;
using GhprWeb.Extensions.HtmlTextWriterExtensions;
using GhprWeb.Extensions.HtmlTextWriterExtensions.Tags;

namespace GhprWeb.Extensions
{
    public static class OHtmlTextWriterExtensions
    {
        public static HtmlTextWriter Label(this HtmlTextWriter writer, string value)
        {
            return writer.Tag(HtmlTextWriterTag.Label, value);
        }

        public static HtmlTextWriter Footer(this HtmlTextWriter writer, string value)
        {
            return writer.Tag("footer", value);
        }

        public static HtmlTextWriter Span(this HtmlTextWriter writer)
        {
            return writer.OpenTag(HtmlTextWriterTag.Span).CloseTag();
        }

        public static HtmlTextWriter Span(this HtmlTextWriter writer, string value)
        {
            writer
                .OpenTag(HtmlTextWriterTag.Span)
                .Text(value)
                .CloseTag();
            return writer;
        }

        public static HtmlTextWriter Div(this HtmlTextWriter writer, Action someAction)
        {
            return writer.Tag(HtmlTextWriterTag.Div, someAction);
        }

        public static HtmlTextWriter Ul(this HtmlTextWriter writer, Action someAction)
        {
            return writer.Tag(HtmlTextWriterTag.Ul, someAction);
        }

        public static HtmlTextWriter Li(this HtmlTextWriter writer, Action someAction)
        {
            return writer.Tag(HtmlTextWriterTag.Li, someAction);
        }

        public static HtmlTextWriter A(this HtmlTextWriter writer, Action someAction)
        {
            return writer.Tag(HtmlTextWriterTag.A, someAction);
        }

        public static HtmlTextWriter Span(this HtmlTextWriter writer, Action someAction)
        {
            return writer.Tag(HtmlTextWriterTag.Span, someAction);
        }

        public static HtmlTextWriter Script(this HtmlTextWriter writer, string src)
        {
            return writer
                .Src(src)
                .Tag(HtmlTextWriterTag.Script);
        }

        public static HtmlTextWriter Stylesheets(this HtmlTextWriter writer, List<string> pathsToCss)
        {
            foreach (var path in pathsToCss)
            {
                writer.Tag(HtmlTextWriterTag.Link, new Dictionary<HtmlTextWriterAttribute, string>
                {
                    {HtmlTextWriterAttribute.Rel, @"stylesheet"},
                    {HtmlTextWriterAttribute.Type, @"text/css"},
                    {HtmlTextWriterAttribute.Href, path}
                });
            }
            return writer;
        }

        public static HtmlTextWriter Scripts(this HtmlTextWriter writer, List<string> pathsToScripts)
        {
            foreach (var path in pathsToScripts)
            {
                writer.WithAttr(HtmlTextWriterAttribute.Src, path)
                    .Tag(HtmlTextWriterTag.Script);
            }
            return writer;
        }

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

        public static HtmlTextWriter TooltippedSpan(this HtmlTextWriter writer, string tooltipText, string text)
        {
            writer
                .Class("tooltipped tooltipped-n")
                .WithAttr("aria-label", tooltipText)
                .Span(text);
            return writer;
        }

        public static HtmlTextWriter TooltippedSpan(this HtmlTextWriter writer, string tooltipText, Action action)
        {
            writer
                .Class("tooltipped tooltipped-n")
                .WithAttr("aria-label", tooltipText)
                .Span(action.Invoke);
            return writer;
        }
    }
}
