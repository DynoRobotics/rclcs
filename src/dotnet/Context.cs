using System;
using System.Collections.Concurrent;
using System.Runtime.InteropServices;

namespace rclcs
{
	/// <summary>
	/// Represents a managed ROS context
	/// </summary>
	public class Context: IDisposable
	{
        //TODO: Init context when created?

        internal rcl_context_t handle;
        private rcl_allocator_t allocator;

        private bool isInit;
        private bool disposed;

        public Context()
        {
            handle = NativeMethods.rcl_get_zero_initialized_context();
            allocator = NativeMethods.rcl_get_default_allocator();
        }

        public void Init()
        {
            rcl_init_options_t init_options = NativeMethods.rcl_get_zero_initialized_init_options();

            Utils.CheckReturnEnum(NativeMethods.rcl_init_options_init(ref init_options, allocator));
            Utils.CheckReturnEnum(NativeMethods.rcl_init(0, null, ref init_options, ref handle));

            isInit = true;
        }

        public void Shutdown()
        {
            Utils.CheckReturnEnum(NativeMethods.rcl_shutdown(ref handle));
            isInit = false;
        }

        public bool Ok
        {
            get { return NativeMethods.rcl_context_is_valid(ref handle); }
        }

        public void Dispose()
        {
            Dispose(true);
        }

        private void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    // Dispose managed resources.
                }

                if(isInit)
                {
                    Shutdown();
                }
                NativeMethods.rcl_context_fini(ref handle);

                disposed = true;
            }
        }

        ~Context()
        {
            Dispose(false);
        }

    }

}

