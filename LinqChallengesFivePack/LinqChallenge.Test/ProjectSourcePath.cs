using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LinqChallenge.Test
{
    internal static class ProjectSourcePath
    {
        private const string myRelativePath = nameof(ProjectSourcePath) + ".cs";
        private static string? lazyValue;
        public static string Value => lazyValue ??= calculatePath();

        private static string calculatePath()
        {
            string pathName = GetSourceFilePathName();
            
            return pathName.Substring(0, pathName.Length - myRelativePath.Length);
        }

        public static string GetSourceFilePathName([CallerFilePath] string? callerFilePath = null) //
        => callerFilePath ?? "";
    }
}
