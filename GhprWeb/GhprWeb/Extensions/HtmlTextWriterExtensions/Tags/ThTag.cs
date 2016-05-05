using System;
using System.Web.UI;

namespace GhprWeb.Extensions.HtmlTextWriterExtensions.Tags
{
    public static class ThTag
    {
        public static HtmlTextWriter Th(this HtmlTextWriter writer, Action someAction)
        {
            return writer.Tag(HtmlTextWriterTag.Th, someAction);
        }

        public static HtmlTextWriter Th(this HtmlTextWriter writer, string value)
        {
            return writer.Tag(HtmlTextWriterTag.Th, value);
        }

        public static HtmlTextWriter NoSortTh(this HtmlTextWriter writer, string value)
        {
            return writer.Class("no-sort").Th(value);
        }
    }
}
