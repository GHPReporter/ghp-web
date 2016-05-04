using System.Collections.Generic;
using System.Web.UI;

namespace GhprWeb.Extensions.HtmlTextWriterExtensions.Tags
{
    public static class ScriptTag
    {
        public static HtmlTextWriter Script(this HtmlTextWriter writer, string src)
        {
            return writer
                .Src(src)
                .Tag(HtmlTextWriterTag.Script);
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
    }
}
