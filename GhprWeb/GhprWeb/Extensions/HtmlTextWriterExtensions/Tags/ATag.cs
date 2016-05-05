using System;
using System.Web.UI;

namespace GhprWeb.Extensions.HtmlTextWriterExtensions.Tags
{
    public static class ATag
    {
        public static HtmlTextWriter A(this HtmlTextWriter writer, string value)
        {
            return writer.Tag(HtmlTextWriterTag.A, value);
        }

        public static HtmlTextWriter A(this HtmlTextWriter writer, Action someAction)
        {
            return writer.Tag(HtmlTextWriterTag.A, someAction);
        }

        public static HtmlTextWriter MenuItem(this HtmlTextWriter writer, string itemText, string itemHref = "", string itemOcticon = "")
        {
            writer
                .Class("menu-item")
                .If(!itemHref.Equals(""), () => writer
                    .Href(itemHref))
                .A(() => writer
                    .If(!itemOcticon.Equals(""), () => writer
                        .Class(itemOcticon)
                        .Span()
                    )
                    .Text(itemText)
                );
            return writer;
        }
    }
}
