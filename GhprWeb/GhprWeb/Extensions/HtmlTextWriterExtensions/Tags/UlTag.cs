using System;
using System.Web.UI;

namespace GhprWeb.Extensions.HtmlTextWriterExtensions.Tags
{
    public static class UlTag
    {
        public static HtmlTextWriter Ul(this HtmlTextWriter writer, Action someAction)
        {
            return writer.Tag(HtmlTextWriterTag.Ul, someAction);
        }
    }
}
