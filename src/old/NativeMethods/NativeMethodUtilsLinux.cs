using System;
namespace rclcs
{
    public static class NativeMethodUtils
    {
        public static unsafe string GetRclErrorString()
        {
            rcl_error_string_t rclErrorString = NativeMethodsLinux.rcl_get_error_string();
            int maxMessageLength = 1024;
            char[] charArray = new char[maxMessageLength];
            for (int i = 0; i < maxMessageLength; i++)
            {
                charArray[i] = rclErrorString.str[i];
            }
            return new string(charArray).Trim('\0');
        }

        public static string PopRclErrorString()
        {
            string errorString = GetRclErrorString();
            NativeMethodsLinux.rcl_reset_error();
            return errorString;
        }
    }
}
