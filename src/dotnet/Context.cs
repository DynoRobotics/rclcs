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
        internal rcl_context_t handle;

        public Context()
        {
            handle = NativeMethods.rcl_get_zero_initialized_context();
        }

        public bool Ok
        {
            get { return false; }
        }

        ~Context()
        {
        }

    }

}

