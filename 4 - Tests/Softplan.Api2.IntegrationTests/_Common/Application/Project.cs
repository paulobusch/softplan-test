using System;
using System.IO;
using System.Linq;

namespace Softplan.IntegrationTests._Common.Application
{
    public static class Project
    {
        public static string GetDirectory(string projectName)
        {
            var projectFile = $"{projectName}.csproj";
            var applicationBasePath = AppContext.BaseDirectory;
            var directoryInfo = new DirectoryInfo(applicationBasePath);

            do
            {
                directoryInfo = directoryInfo.Parent;
                if (!directoryInfo.Exists) break;
                 
                var projectPath = Directory.GetFiles(directoryInfo.FullName, "*.*", SearchOption.AllDirectories)
                    .FirstOrDefault(s => s.EndsWith(projectFile));

                if (!string.IsNullOrWhiteSpace(projectPath))
                    return Path.GetDirectoryName(projectPath);
            }
            while (directoryInfo.Parent != null);
            throw new Exception($"Project root could not be located using the application root {applicationBasePath}.");
        }
    }
}
