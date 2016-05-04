using System.Web.UI;

namespace GhprWeb.Extensions.HtmlTextWriterExtensions.Tags
{
    public static class LiTag
    {
        public static HtmlTextWriter Li(this HtmlTextWriter writer, string value)
        {
            return writer.Tag(HtmlTextWriterTag.Li, value);
        }
    }
}
