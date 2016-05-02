using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GhprWeb.EmbeddedResources
{
    public class ResourceExtractor
    {
        private void ExtractResource(string embeddedFileName, string destinationPath, bool replaceExisting = false)
        {
            var currentAssembly = GetType().Assembly;
            var arrResources = GetType().Assembly.GetManifestResourceNames();
            var destinationFullPath = Path.Combine(destinationPath, embeddedFileName);
            if (!File.Exists(destinationFullPath) || replaceExisting)
            {
                foreach (var resourceName in arrResources
                    .Where(resourceName => resourceName.ToUpper().EndsWith(embeddedFileName.ToUpper())))
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

        private void ExtractResources(List<string> embeddedFileNames, string destinationPath, )
        {
            foreach (var embeddedFileName in embeddedFileNames)
            {
                ExtractResource(embeddedFileName, destinationPath);
            }
        }
    }
}
