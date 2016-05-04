using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GhprWeb.EmbeddedResources
{
    public class ResourceExtractor
    {
        public void Extract(Resources.Resource resource, string destinationPath, bool replaceExisting = false)
        {
            switch (resource)
            {
                case Resources.Resource.JQuery:
                    ExtractResource("jquery-1.11.0.min.js", destinationPath, replaceExisting);
                    break;
                case Resources.Resource.Octicons:
                    ExtractResources(
                        new List<string>
                        {
                            "octicons.css",
                            "octicons.eot",
                            "octicons.svg",
                            "octicons.ttf",
                            "octicons.woff"
                        },
                        destinationPath,
                        replaceExisting
                        );
                    break;
                case Resources.Resource.Primer:
                    ExtractResource("primer.css", destinationPath, replaceExisting);
                    break;
                case Resources.Resource.Tablesort:
                    ExtractResource("tablesort.min.js", destinationPath, replaceExisting);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(resource), resource, null);
            }
        }

        public void ExtractResource(string embeddedFileName, string destinationPath, bool replaceExisting = false)
        {
            var currentAssembly = GetType().Assembly;
            var arrResources = GetType().Assembly.GetManifestResourceNames();
            var destinationFullPath = Path.Combine(destinationPath, embeddedFileName);
            if (!File.Exists(destinationFullPath) || replaceExisting)
            {
                foreach (var resourceName in arrResources.Where(resourceName => resourceName.ToUpper().EndsWith(embeddedFileName.ToUpper())))
                {
                    using (var resourceToSave = currentAssembly.GetManifestResourceStream(resourceName))
                    {
                        using (var output = File.Create(destinationFullPath))
                        {
                            resourceToSave?.CopyTo(output);
                        }
                        resourceToSave?.Close();
                    }
                }
            }
        }

        public void ExtractResources(IEnumerable<string> embeddedFileNames, string destinationPath, bool replaceExisting = false)
        {
            foreach (var embeddedFileName in embeddedFileNames)
            {
                ExtractResource(embeddedFileName, destinationPath, replaceExisting);
            }
        }
    }
}
