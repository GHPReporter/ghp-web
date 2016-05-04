using System;
using System.Web.UI;

namespace GhprWeb.Extensions.HtmlTextWriterExtensions.Tags
{
    public static class DivTag
    {
        public static HtmlTextWriter Div(this HtmlTextWriter writer, Action someAction)
        {
            return writer.Tag(HtmlTextWriterTag.Div, someAction);
        }
    }
}
