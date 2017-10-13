using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renam3r.Classes.FileNamer
{
    public static class Id3FileMessages
    {
        public static string InvalidFilePath => "Invalid file path";

        public static string MissingDataForFrame => "Missing data for '{0}'";

        public static string MissingDirectory => "Directory '{0}' does not exist";

        public static string MissingFile => "File does not exist";

        public static string MissingId3v23TagInFile => "File does not contain a ID3v2.3 tag";

        public static string MissingPlaceholdersInPattern => "The naming patter '{0}' does not contain any placeholders";

        public static string MissingTagProperty => "A tag property by name '{0}' does not exist";
    }
}
