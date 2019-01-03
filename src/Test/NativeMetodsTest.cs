using NUnit.Framework;
using System;
using System.Text;
using rclcs;

namespace rclcs.Test
{
    [TestFixture]
    public class NativeMethodsLinuxTest
    {
        [Test]
        public void GetZeroInitializedContext()
        {
            rcl_context_t context = SafeNativeMethodsLinux.rcl_get_zero_initialized_context();
        }

        [Test]
        public void GetDefaultAllocator()
        {
            rcl_allocator_t allocator = SafeNativeMethodsLinux.rcl_get_default_allocator();
        }

        [Test]
        public void GetZeroInitializedInitOptions()
        {
            rcl_init_options_t init_options = SafeNativeMethodsLinux.rcl_get_zero_initialized_init_options();
        }

        [Test]
        public void InitOptionsInit()
        {
            rcl_init_options_t init_options = SafeNativeMethodsLinux.rcl_get_zero_initialized_init_options();
            rcl_allocator_t allocator = SafeNativeMethodsLinux.rcl_get_default_allocator();
            int ret = NativeMethodsLinux.rcl_init_options_init(ref init_options, allocator);
            Assert.That((RCLReturnEnum)ret, Is.EqualTo(RCLReturnEnum.RCL_RET_OK));
        }

        [Test]
        public void GetErrorString()
        {
            NativeMethodsLinux.rcl_reset_error();
            string messageString = NativeMethodUtils.GetRclErrorString();
            Assert.That(messageString, Is.EqualTo("error not set"));

        }


        [Test]
        public void ResetError()
        {
            NativeMethodsLinux.rcl_reset_error();
        }

        [Test]
        public void RclShutdown()
        {
            rcl_context_t context = SafeNativeMethodsLinux.rcl_get_zero_initialized_context();
            rcl_allocator_t allocator = SafeNativeMethodsLinux.rcl_get_default_allocator();
            RCLReturnEnum ret = (RCLReturnEnum)NativeMethodsLinux.rcl_shutdown(ref context);
            Assert.That(ret, Is.EqualTo(RCLReturnEnum.RCL_RET_INVALID_ARGUMENT));
        }

        [Test]
        public void ContextIsValid()
        {
            rcl_init_options_t init_options = SafeNativeMethodsLinux.rcl_get_zero_initialized_init_options();
            rcl_allocator_t allocator = SafeNativeMethodsLinux.rcl_get_default_allocator();
            NativeMethodsLinux.rcl_init_options_init(ref init_options, allocator);
            rcl_context_t context = SafeNativeMethodsLinux.rcl_get_zero_initialized_context();

            NativeMethodsLinux.rcl_shutdown(ref context);

            Assert.That(SafeNativeMethodsLinux.rcl_context_is_valid(ref context), Is.False);
        }

        [Test]
        public void InitShutdownFinalize()
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
        public void InitValidArgs()
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
