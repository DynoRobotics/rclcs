using System;
using System.Runtime.InteropServices;

using ROS2.Utils;
using ROS2.Interfaces;


namespace rclcs
{
    internal static class NativeMethods
    {
        private static readonly DllLoadUtils dllLoadUtils = DllLoadUtilsFactory.GetDllLoadUtils();
        // --- RCL ---
        private static readonly IntPtr nativeRCL = dllLoadUtils.LoadLibraryNoSuffix("rcl");

        // rcl_get_zero_initialized_context
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate rcl_context_t GetZeroInitializedContextType();
        internal static GetZeroInitializedContextType 
            rcl_get_zero_initialized_context = 
            (GetZeroInitializedContextType) Marshal.GetDelegateForFunctionPointer(dllLoadUtils.GetProcAddress(
            nativeRCL, 
            "rcl_get_zero_initialized_context"), 
            typeof(GetZeroInitializedContextType));

        // rcl_get_zero_initialized_init_options
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate rcl_init_options_t GetZeroInitializedInitOptionsType();
        internal static GetZeroInitializedInitOptionsType
            rcl_get_zero_initialized_init_options = 
            (GetZeroInitializedInitOptionsType)Marshal.GetDelegateForFunctionPointer(dllLoadUtils.GetProcAddress(
            nativeRCL,
            "rcl_get_zero_initialized_init_options"),
            typeof(GetZeroInitializedInitOptionsType));

        // rcl_init_options_init
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate int InitOptionsInitType(ref rcl_init_options_t init_options, rcl_allocator_t allocator);
        internal static InitOptionsInitType
        rcl_init_options_init =
        (InitOptionsInitType)Marshal.GetDelegateForFunctionPointer(dllLoadUtils.GetProcAddress(
        nativeRCL,
        "rcl_init_options_init"),
        typeof(InitOptionsInitType));

        // rcl_shutdown
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate int ShutdownType(ref rcl_context_t context);
        internal static ShutdownType
            rcl_shutdown =
            (ShutdownType)Marshal.GetDelegateForFunctionPointer(dllLoadUtils.GetProcAddress(
            nativeRCL,
            "rcl_shutdown"),
            typeof(ShutdownType));

        // rcl_context_is_valid
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool ContextIsValidType(ref rcl_context_t context);
        internal static ContextIsValidType
            rcl_context_is_valid =
            (ContextIsValidType)Marshal.GetDelegateForFunctionPointer(dllLoadUtils.GetProcAddress(
            nativeRCL,
            "rcl_context_is_valid"),
            typeof(ContextIsValidType));

        // rcl_init
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate int InitType(int argc, [In, Out] string[] argv, ref rcl_init_options_t option, ref rcl_context_t context);
        internal static InitType
            rcl_init =
            (InitType)Marshal.GetDelegateForFunctionPointer(dllLoadUtils.GetProcAddress(
            nativeRCL,
            "rcl_init"),
            typeof(InitType));

        // rcl_context_fini
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate int ContextFiniType(ref rcl_context_t context);
        internal static ContextFiniType
            rcl_context_fini =
            (ContextFiniType)Marshal.GetDelegateForFunctionPointer(dllLoadUtils.GetProcAddress(
            nativeRCL,
            "rcl_context_fini"),
            typeof(ContextFiniType));

        // rcl_get_zero_initialized_node
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate rcl_node_t GetZeroInitializedNodeType();
        internal static GetZeroInitializedNodeType
            rcl_get_zero_initialized_node =
            (GetZeroInitializedNodeType)Marshal.GetDelegateForFunctionPointer(dllLoadUtils.GetProcAddress(
            nativeRCL,
            "rcl_get_zero_initialized_node"),
            typeof(GetZeroInitializedNodeType));

        // rcl_node_get_default_options
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate rcl_node_options_t NodeGetDefaultOptionsType();
        internal static NodeGetDefaultOptionsType
            rcl_node_get_default_options =
            (NodeGetDefaultOptionsType)Marshal.GetDelegateForFunctionPointer(dllLoadUtils.GetProcAddress(
            nativeRCL,
            "rcl_node_get_default_options"),
            typeof(NodeGetDefaultOptionsType));

        // rcl_node_init
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate int NodeInitType(ref rcl_node_t node, string name, string node_namespace, ref rcl_context_t context, ref rcl_node_options_t default_options);
        internal static NodeInitType
            rcl_node_init =
            (NodeInitType)Marshal.GetDelegateForFunctionPointer(dllLoadUtils.GetProcAddress(
            nativeRCL,
            "rcl_node_init"),
            typeof(NodeInitType));

        // rcl_node_fini
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate int NodeFiniType(ref rcl_node_t node);
        internal static NodeFiniType
            rcl_node_fini =
            (NodeFiniType)Marshal.GetDelegateForFunctionPointer(dllLoadUtils.GetProcAddress(
            nativeRCL,
            "rcl_node_fini"),
            typeof(NodeFiniType));

        // rcl_node_get_name
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate IntPtr NodeGetNameType(ref rcl_node_t node);
        internal static NodeGetNameType
            rcl_node_get_name =
            (NodeGetNameType)Marshal.GetDelegateForFunctionPointer(dllLoadUtils.GetProcAddress(
            nativeRCL,
            "rcl_node_get_name"),
            typeof(NodeGetNameType));

        // rcl_node_get_namespace
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate IntPtr NodeGetNamespaceType(ref rcl_node_t node);
        internal static NodeGetNamespaceType
            rcl_node_get_namespace =
            (NodeGetNamespaceType)Marshal.GetDelegateForFunctionPointer(dllLoadUtils.GetProcAddress(
            nativeRCL,
            "rcl_node_get_namespace"),
            typeof(NodeGetNamespaceType));

        // rcl_publisher_get_default_options
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate rcl_publisher_options_t PublisherGetDefaultOptionsType();
        internal static PublisherGetDefaultOptionsType
            rcl_publisher_get_default_options =
            (PublisherGetDefaultOptionsType)Marshal.GetDelegateForFunctionPointer(dllLoadUtils.GetProcAddress(
            nativeRCL,
            "rcl_publisher_get_default_options"),
            typeof(PublisherGetDefaultOptionsType));

        // rcl_get_zero_initialized_publisher
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate rcl_publisher_t GetZeroInitiazizedPublisherType();
        internal static GetZeroInitiazizedPublisherType
            rcl_get_zero_initialized_publisher =
            (GetZeroInitiazizedPublisherType)Marshal.GetDelegateForFunctionPointer(dllLoadUtils.GetProcAddress(
            nativeRCL,
            "rcl_get_zero_initialized_publisher"),
            typeof(GetZeroInitiazizedPublisherType));

        // rcl_publisher_init
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate int PublisherInitType(ref rcl_publisher_t publisher, ref rcl_node_t node, IntPtr type_support_ptr, string topic_name, ref rcl_publisher_options_t publisher_options);
        internal static PublisherInitType
            rcl_publisher_init =
            (PublisherInitType)Marshal.GetDelegateForFunctionPointer(dllLoadUtils.GetProcAddress(
            nativeRCL,
            "rcl_publisher_init"),
            typeof(PublisherInitType));

        // rcl_publisher_fini
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate int PublisherFiniType(ref rcl_publisher_t publisher, ref rcl_node_t node);
        internal static PublisherFiniType
            rcl_publisher_fini =
            (PublisherFiniType)Marshal.GetDelegateForFunctionPointer(dllLoadUtils.GetProcAddress(
            nativeRCL,
            "rcl_publisher_fini"),
            typeof(PublisherFiniType));

        // rcl_publisher_fini
        //[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        //internal delegate int PublisherFiniType(ref rcl_publisher_t publisher, ref rcl_node_t node);
        //internal static PublisherFiniType
            //rcl_publisher_fini =
            //(PublisherFiniType)Marshal.GetDelegateForFunctionPointer(dllLoadUtils.GetProcAddress(
            //nativeRCL,
            //"rcl_publisher_fini"),
            //typeof(PublisherFiniType));

        // --- RCUtils
        private static readonly IntPtr nativeRCUtils = dllLoadUtils.LoadLibraryNoSuffix("rcutils");

        // rcl_get_default_allocator
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate rcl_allocator_t RclGetDefaultAllocatorType();
        internal static RclGetDefaultAllocatorType 
            rcl_get_default_allocator = 
            (RclGetDefaultAllocatorType)Marshal.GetDelegateForFunctionPointer(dllLoadUtils.GetProcAddress(
            nativeRCUtils, 
            "rcutils_get_default_allocator"), 
            typeof(RclGetDefaultAllocatorType));

        // rcl_reset_error
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void ResetErrorType();
        internal static ResetErrorType
            rcl_reset_error =
            (ResetErrorType)Marshal.GetDelegateForFunctionPointer(dllLoadUtils.GetProcAddress(
            nativeRCUtils,
            "rcutils_reset_error"),
            typeof(ResetErrorType));

        // rcl_get_error_string
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate rcl_error_string_t GetErrorStringType();
        internal static GetErrorStringType
            rcl_get_error_string =
            (GetErrorStringType)Marshal.GetDelegateForFunctionPointer(dllLoadUtils.GetProcAddress(
            nativeRCUtils,
            "rcutils_get_error_string"),
            typeof(GetErrorStringType));

    }
}
