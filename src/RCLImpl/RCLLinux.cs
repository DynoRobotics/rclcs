using System;
using System.Runtime.InteropServices;
using System.Security;

namespace rclcs
{
	/// <summary>
	/// The RCL class handles the initialisation of the ros client librarie and wraps the functions defined in the rcl/rcl.h.
	/// It furthermore defines the paths to the rcl and rmw libs that are used in the DllImport statement for native interop.
	/// This class implements IDisposable.
	/// </summary>
	internal class RCLLinux:RCLBase
    {
        private Context activeContext;

        public override void Init(Context context)
        {
            rcl_init_options_t init_options = SafeNativeMethodsLinux.rcl_get_zero_initialized_init_options();
            rcl_allocator_t allocator = SafeNativeMethodsLinux.rcl_get_default_allocator();

            activeContext = context;
            RclHelpers.CheckReturnEnum(NativeMethodsLinux.rcl_init_options_init(ref init_options, allocator));
            RclHelpers.CheckReturnEnum(NativeMethodsLinux.rcl_init(0, null, ref init_options, ref context.rclContext));
        }


        public override void Shutdown()
        {
            Shutdown(activeContext);
        }

        public override void Shutdown(Context context)
        {
            RclHelpers.CheckReturnEnum(NativeMethodsLinux.rcl_shutdown(ref context.rclContext));
            RclHelpers.CheckReturnEnum(NativeMethodsLinux.rcl_context_fini(ref context.rclContext));
        }
    }
}

