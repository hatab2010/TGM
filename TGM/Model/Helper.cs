using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebBotCore.Model
{
    public static class Helper
    {
        public static void CopyDirectory(DirectoryInfo source, DirectoryInfo target)
        {
            Directory.CreateDirectory(target.FullName);

            // Copy each file into the new directory.
            foreach (FileInfo fi in source.GetFiles())
            {
                Console.WriteLine(@"Copying {0}\{1}", target.FullName, fi.Name);
                fi.CopyTo(Path.Combine(target.FullName, fi.Name), true);
            }

            // Copy each subdirectory using recursion.
            foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
            {
                DirectoryInfo nextTargetSubDir =
                    target.CreateSubdirectory(diSourceSubDir.Name);
                CopyDirectory(diSourceSubDir, nextTargetSubDir);
            }
        }

        public static bool TryParse<T>(this Enum theEnum, string valueToParse, out T returnValue)
        {
            returnValue = default(T);
            int intEnumValue;
            if (Int32.TryParse(valueToParse, out intEnumValue))
            {
                if (Enum.IsDefined(typeof(T), intEnumValue))
                {
                    returnValue = (T)(object)intEnumValue;
                    return true;
                }
            }
            return false;
        }
    }
}
