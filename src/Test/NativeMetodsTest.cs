using NUnit.Framework;
using System;
using System.Text;
using rclcs;

namespace rclcs.Test
{
    [TestFixture]
    public class NativeMethodsTest:AssertionHelper
    {
        [Test]
        public void TestGetZeroInitializedContext()
        {
            rcl_context_t context = SafeNativeMethodsLinux.rcl_get_zero_initialized_context();
        }

        [Test]
        public void TestGetDefaultAllocator()
        {
            rcl_allocator_t allocator = SafeNativeMethodsLinux.rcl_get_default_allocator();
        }

        [Test]
        public void TestGetZeroInitializedInitOptions()
        {
            rcl_init_options_t init_options = SafeNativeMethodsLinux.rcl_get_zero_initialized_init_options();
        }

        [Test]
        public void TestInitOptionsInit()
        {
            rcl_init_options_t init_options = SafeNativeMethodsLinux.rcl_get_zero_initialized_init_options();
            rcl_allocator_t allocator = SafeNativeMethodsLinux.rcl_get_default_allocator();
            int ret = NativeMethodsLinux.rcl_init_options_init(ref init_options, allocator);
            Assert.That((RCLReturnEnum)ret, Is.EqualTo(RCLReturnEnum.RCL_RET_OK));
        }

        [Test]
        public void TestGetErrorString()
        {
            rcl_error_string_t rclErrorMessage = NativeMethodsLinux.rcl_get_error_string();
            string messageString = RclErrorMessageToString(rclErrorMessage);
            Assert.That(messageString, Is.EqualTo("error not set"));
        }

        internal unsafe string RclErrorMessageToString(rcl_error_string_t rclErrorString) 
        {
            int maxMessageLength = 1024;
            char[] charArray = new char[maxMessageLength];
            for (int i = 0; i < maxMessageLength; i++)
            {
                charArray[i] = rclErrorString.str[i];
            }
            return new string(charArray).Trim('\0');
        }

    }
}
