using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace SpecialApp.Base
{
    public static class StringExtension
    {
        public static bool IsNullOrEmpty(this string value) => string.IsNullOrEmpty(value);

        public static bool IsNotNullOrEmpty(this string value) => !value.IsNullOrEmpty();

        public static bool IsNullOrWhiteSpace(this string value) => string.IsNullOrWhiteSpace(value);

        public static bool IsNotNullOrWhiteSpace(this string value) => !value.IsNullOrWhiteSpace();

        public static long? AsLong(this string value)
        {
            var result = long.TryParse(value, out long id);
            if (result)
                return id;

            return null;
        }

        public static string ToCamelCase(this string source)
        {
            if (source.HasNoValue())
                return string.Empty;

            return string.Join(" ", Regex.Split(source, @"(?<!^)(?=[A-Z])"));
        }

        public static bool IsPDF(this string source)
        {
            if (source.IsNullOrWhiteSpace())
                return false;

            return source.Split('.').Last().ToLowerInvariant() == "pdf";
        }
    }
}
