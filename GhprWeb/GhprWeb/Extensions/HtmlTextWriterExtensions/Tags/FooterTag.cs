using System.Web.UI;

namespace GhprWeb.Extensions.HtmlTextWriterExtensions.Tags
{
    public static class FooterTag
    {
        public static HtmlTextWriter Footer(this HtmlTextWriter writer, string value)
        {
            return writer.Tag("footer", value);
        }
    }
}
