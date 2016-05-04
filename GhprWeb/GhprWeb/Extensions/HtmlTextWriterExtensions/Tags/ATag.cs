using System.Web.UI;

namespace GhprWeb.Extensions.HtmlTextWriterExtensions.Tags
{
    public static class ATag
    {
        public static HtmlTextWriter A(this HtmlTextWriter writer, string value)
        {
            return writer.Tag(HtmlTextWriterTag.A, value);
        }
    }
}
