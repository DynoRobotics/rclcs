﻿using System;
using System.Collections.Concurrent;
using System.Runtime.InteropServices;

namespace rclcs
{
	/// <summary>
	/// Represents a managed ROS context
	/// </summary>
	public class Context
	{
        internal rcl_context_t rclContext;

        public Context()
        {
            rclContext = SafeNativeMethodsLinux.rcl_get_zero_initialized_context();
        }

        public bool Ok
        {
            get { return SafeNativeMethodsLinux.rcl_context_is_valid(ref rclContext); }
        }

        ~Context()
        {
            //TODO: figure out if this is correct...
            NativeMethodsLinux.rcl_context_fini(ref rclContext);
        }

    }

}

