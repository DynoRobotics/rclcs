using NUnit.Framework;
using System;
using System.Text;
using rclcs;

namespace rclcs.Test
{
    [TestFixture]
    public class NativeMethodsLinuxTest : AssertionHelper
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
            NativeMethodsLinux.rcl_reset_error();
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

        [Test]
        public void TestResetError()
        {
            NativeMethodsLinux.rcl_reset_error();
        }

        [Test]
        public void TestRclShutdown()
        {
            rcl_context_t context = SafeNativeMethodsLinux.rcl_get_zero_initialized_context();
            rcl_allocator_t allocator = SafeNativeMethodsLinux.rcl_get_default_allocator();
            RCLReturnEnum ret = (RCLReturnEnum)NativeMethodsLinux.rcl_shutdown(ref context);
            Assert.That(ret, Is.EqualTo(RCLReturnEnum.RCL_RET_INVALID_ARGUMENT));
        }

        [Test]
        public void TestContextIsValid()
        {
            rcl_init_options_t init_options = SafeNativeMethodsLinux.rcl_get_zero_initialized_init_options();
            rcl_allocator_t allocator = SafeNativeMethodsLinux.rcl_get_default_allocator();
            NativeMethodsLinux.rcl_init_options_init(ref init_options, allocator);
            rcl_context_t context = SafeNativeMethodsLinux.rcl_get_zero_initialized_context();

            NativeMethodsLinux.rcl_shutdown(ref context);

            Assert.That(SafeNativeMethodsLinux.rcl_context_is_valid(ref context), Is.False);
        }

        [Test]
        public void TestInitShutdownFinalize()
        {
            rcl_init_options_t init_options = SafeNativeMethodsLinux.rcl_get_zero_initialized_init_options();
            rcl_allocator_t allocator = SafeNativeMethodsLinux.rcl_get_default_allocator();
            NativeMethodsLinux.rcl_init_options_init(ref init_options, allocator);
            rcl_context_t context = SafeNativeMethodsLinux.rcl_get_zero_initialized_context();

            RCLReturnEnum ret = (RCLReturnEnum)NativeMethodsLinux.rcl_init(0, null, ref init_options, ref context);
            Assert.That(ret, Is.EqualTo(RCLReturnEnum.RCL_RET_OK));

            Assert.That(SafeNativeMethodsLinux.rcl_context_is_valid(ref context), Is.True);
            ret = (RCLReturnEnum)NativeMethodsLinux.rcl_shutdown(ref context);
            Assert.That(ret, Is.EqualTo(RCLReturnEnum.RCL_RET_OK));

            ret = (RCLReturnEnum)NativeMethodsLinux.rcl_context_fini(ref context);
            Assert.That(ret, Is.EqualTo(RCLReturnEnum.RCL_RET_OK));
        }

        [Test]
        public void TestInitValidArgs()
        {
            rcl_init_options_t init_options = SafeNativeMethodsLinux.rcl_get_zero_initialized_init_options();
            rcl_allocator_t allocator = SafeNativeMethodsLinux.rcl_get_default_allocator();
            NativeMethodsLinux.rcl_init_options_init(ref init_options, allocator);
            rcl_context_t context = SafeNativeMethodsLinux.rcl_get_zero_initialized_context();

            RCLReturnEnum ret = (RCLReturnEnum)NativeMethodsLinux.rcl_init(2, new string[] { "foo", "bar"}, ref init_options, ref context);
            Assert.That(ret, Is.EqualTo(RCLReturnEnum.RCL_RET_OK));

            Assert.That(SafeNativeMethodsLinux.rcl_context_is_valid(ref context), Is.True);
            ret = (RCLReturnEnum)NativeMethodsLinux.rcl_shutdown(ref context);
            Assert.That(ret, Is.EqualTo(RCLReturnEnum.RCL_RET_OK));

            ret = (RCLReturnEnum)NativeMethodsLinux.rcl_context_fini(ref context);
            Assert.That(ret, Is.EqualTo(RCLReturnEnum.RCL_RET_OK));
        }

    }
}
