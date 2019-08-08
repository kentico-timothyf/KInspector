using System;
using System.Collections.Generic;
using System.Text;

namespace KenticoInspector.Core.Models
{
    public class SemVer
    {
        public int Major { get; set; }
        public int Minor { get; set; }
        public int Patch { get; set; }
        public string Prerelease { get; set; }
        public string Build { get; set; }

        public override string ToString()
        {
            return $"v{Major}.{Minor}.{Patch}-{Prerelease}.{Build}";
        }
    }
}
