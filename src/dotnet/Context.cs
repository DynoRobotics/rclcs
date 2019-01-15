using System;
using System.Collections.Concurrent;
using System.Runtime.InteropServices;

namespace rclcs
{
	/// <summary>
	/// Represents a managed ROS context
	/// </summary>
	public class Context
	{
        //TODO: Change to IDisposable?

        internal rcl_context_t handle;

        public Context()
        {
            handle = NativeMethods.rcl_get_zero_initialized_context();
        }

        public bool Ok
        {
            get { return NativeMethods.rcl_context_is_valid(ref handle); }
        }

        ~Context()
        {
            //TODO: figure out if this is correct...
            NativeMethods.rcl_context_fini(ref handle);
        }

    }

}

