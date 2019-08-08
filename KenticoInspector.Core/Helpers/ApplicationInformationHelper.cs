using System;
using System.Diagnostics;
using System.Reflection;
using System.Text.RegularExpressions;
using KenticoInspector.Core.Models;

namespace KenticoInspector.Core.Helpers
{
    public class ApplicationInformationHelper
    {
        private static Regex looseRegex = new Regex(@"^
            [v=\s]*
            (\d+)                     # major version
            \.
            (\d+)                     # minor version
            \.
            (\d+)                     # patch version
            (\-?([0-9A-Za-z\-\.]+))?  # pre-release version
            (\+([0-9A-Za-z\-\.]+))?   # build metadata
            \s*
            $",
            RegexOptions.IgnorePatternWhitespace);
        
        public static string GetStringVersion(bool checkSemFormatting = true)
        {
            var stringVersion = GetVersionFromFile();

            if(checkSemFormatting && !CheckSemVersionFormatting(stringVersion))
                throw new Exception("Version retrieved from the application is not in valid SemVer format.");

            return stringVersion;
        }

        public static SemVer GetSemVersion()
        {
            var semVersion = ParseSemVersion(GetStringVersion());

            return semVersion;
        }

        public static bool CheckSemVersionFormatting(string stringVersion)
        {
            var match = looseRegex.Match(stringVersion);

            return match.Success;
        }

        public static SemVer ParseSemVersion(string stringVersion)
        {
            var match = looseRegex.Match(stringVersion);

            if (!match.Success)
                throw new ArgumentException("String provided is not valid SemVer notation"); // #NOMS

            var version = new SemVer()
            {
                Major = int.Parse(match.Groups[1].Value),
                Minor = int.Parse(match.Groups[2].Value),
                Patch = int.Parse(match.Groups[3].Value),
                Prerelease = match.Groups[4].Value == null ? "" : match.Groups[5].Value,
                Build = match.Groups[6].Value ?? ""
            };

            return version;
        }


        protected static string GetVersionFromFile()
        {
            var coreAssembly = Assembly.GetExecutingAssembly();
            

            var applicationVersion = coreAssembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion;

            return applicationVersion ?? string.Empty;
        }
    }
}
