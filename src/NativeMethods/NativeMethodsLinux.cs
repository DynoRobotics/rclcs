using System;
using System.Runtime.InteropServices;
using System.Security;

namespace rclcs
{
    internal static class LibPathsLinux
    {
        public const string RCL = "librcl.so";
        public const string RMW = "librmw.so";
        public const string RCUtils = "librcutils.so";
    }

    internal static class NativeMethodsLinux
    {
        // RCL
        [DllImport(LibPathsLinux.RCL)]
        internal static extern int rcl_init(int argc, [In, Out] string[] argv, ref rcl_init_options_t option, ref rcl_context_t context);

        [DllImport(LibPathsLinux.RCL)]
        internal static extern int rcl_init_options_init(ref rcl_init_options_t init_options, rcl_allocator_t allocator);

        [DllImport(LibPathsLinux.RCL)]
        internal static extern int rcl_shutdown(ref rcl_context_t context);

        [DllImport(LibPathsLinux.RCL)]
        internal static extern int rcl_context_fini(ref rcl_context_t context);

        [DllImport(LibPathsLinux.RCL)]
        internal static extern int rcl_node_init(ref rcl_node_t node, string name, string node_namespace, ref rcl_context_t context, ref rcl_node_options_t default_options);

        [DllImport(LibPathsLinux.RCL)]
        internal static extern int rcl_node_fini(ref rcl_node_t node);

        [DllImport(LibPathsLinux.RCL)]
        internal static extern int rcl_publisher_init(ref rcl_publisher_t publisher, ref rcl_node_t node, ref rosidl_message_type_support_t type_support, string topic_name, rcl_publisher_options_t options);

        // RCUtils
        [DllImport(LibPathsLinux.RCUtils, EntryPoint = "rcutils_get_error_string")]
        internal static extern rcl_error_string_t rcl_get_error_string();

        [DllImport(LibPathsLinux.RCUtils, EntryPoint = "rcutils_reset_error")]
        internal static extern void rcl_reset_error();

    }

    [SuppressUnmanagedCodeSecurity]
    internal static class SafeNativeMethodsLinux
    {
        // RCL
        [DllImport(LibPathsLinux.RCL)]
        internal static extern rcl_context_t rcl_get_zero_initialized_context();

        [DllImport(LibPathsLinux.RCL)]
        internal static extern rcl_init_options_t rcl_get_zero_initialized_init_options();

        [DllImport(LibPathsLinux.RCL)]
        internal static extern bool rcl_context_is_valid(ref rcl_context_t context);

        [DllImport(LibPathsLinux.RCL)]
        internal static extern rcl_node_t rcl_get_zero_initialized_node();

        [DllImport(LibPathsLinux.RCL)]
        internal static extern rcl_node_options_t rcl_node_get_default_options();

        [DllImport(LibPathsLinux.RCL)]
        internal static extern IntPtr rcl_node_get_namespace(ref rcl_node_t node);

        [DllImport(LibPathsLinux.RCL)]
        internal static extern IntPtr rcl_node_get_name(ref rcl_node_t node);

        [DllImport(LibPathsLinux.RCL)]
        internal static extern rcl_publisher_options_t rcl_publisher_get_default_options();

        [DllImport(LibPathsLinux.RCL)]
        internal static extern rcl_publisher_t rcl_get_zero_initialized_publisher();

        // RCUtils
        [DllImport(LibPathsLinux.RCUtils, EntryPoint = "rcutils_get_default_allocator")]
        internal static extern rcl_allocator_t rcl_get_default_allocator();
    
    }

}

