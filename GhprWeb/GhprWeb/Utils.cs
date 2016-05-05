using System;
using System.IO;
using System.Reflection;

namespace GhprWeb
{
    public static class Utils
    {
        public static string CurrentPath
        {
            get
            {
                var codeBase = Assembly.GetExecutingAssembly().CodeBase;
                var uri = new UriBuilder(codeBase);
                var path = Uri.UnescapeDataString(uri.Path);

                return Path.GetDirectoryName(path);
            }
        }
    }
}
