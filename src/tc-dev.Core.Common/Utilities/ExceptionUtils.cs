using System;

namespace tc_dev.Core.Common.Utilities
{
    public static class ExceptionUtils
    {
        public static void ThrowIfNull<T>(
            this T source, string paramName = null, string message = null) 
                where T : class
        {
            if (source == null)
                throw new ArgumentNullException(paramName, message);
        }

        public static void ThrowIfNull<T>(
            this T? source, string paramName = null, string message = null)
                where T : struct 
        {
            if (source == null)
                throw new ArgumentNullException(paramName, message);
        }
    }
}
