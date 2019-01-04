using System;
namespace rclcs
{
    // rcl
    public struct rcl_allocator_t
    {
        private IntPtr allocate;
        private IntPtr deallocate;
        private IntPtr reallocate;
        private IntPtr zero_allocate;
        private IntPtr state;
    }

    public struct rcl_arguments_t
    {
        private IntPtr impl;
    }

    public struct rcl_context_t
    {
        private IntPtr global_arguments;
        private IntPtr impl;
        private IntPtr instance_id_storage;
    }

    public unsafe struct rcl_error_string_t
    {
        internal fixed char str[1024];
    }

    public struct rcl_init_options_t
    {
        private IntPtr impl;
    }

    public struct rcl_node_t
    {
        private IntPtr context;
        private IntPtr rcl_node_impl_t;
    }

    public struct rcl_node_options_t
    {
        private UIntPtr domain_id;
        private rcl_allocator_t allocator;
        private bool use_global_arguments;
        private rcl_arguments_t arguments;
    }


}

