using System;
namespace rclcs
{
    public static class Utils
    {
        internal static void CheckReturnEnum(int ret)
        {
            string errorMessage = Utils.PopRclErrorString();

            switch ((RCLReturnEnum)ret)
            {
                case RCLReturnEnum.RCL_RET_OK:
                    break;
                case RCLReturnEnum.RCL_RET_NODE_INVALID_NAME:
                    throw new InvalidNodeNameException(errorMessage);
                case RCLReturnEnum.RCL_RET_NODE_INVALID_NAMESPACE:
                    throw new InvalidNamespaceException(errorMessage);
                default:
                    throw new RuntimeError(errorMessage);
            }
        }

        public static unsafe string GetRclErrorString()
        {
            rcl_error_string_t rclErrorString = NativeMethods.rcl_get_error_string();
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
            NativeMethods.rcl_reset_error();
            return errorString;
        }

        public static ulong TimeoutSecToNsec(double timeoutSec)
        {
            if(timeoutSec < 0)
            {
                throw new RuntimeError("Negative timeouts are not allowed, timeout was " + timeoutSec + " seconds.");
            }
            return (ulong)(timeoutSec * Constants.S_TO_NS);
        }
    }
}
