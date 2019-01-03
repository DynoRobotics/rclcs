using System;
namespace rclcs
{
    // rcl
    public struct rcl_allocator_t
    {
        public IntPtr allocate;
        public IntPtr deallocate;
        public IntPtr reallocate;
        public IntPtr zero_allocate;
        public IntPtr state;
    }

    public struct rcl_context_t
    {
        public IntPtr global_arguments;
        public IntPtr impl;
        public IntPtr instance_id_storage;
    }

    public unsafe struct rcl_error_string_t
    {
        public fixed char str[1024];
    }

    public struct rcl_init_options_t
    {
        public IntPtr impl;
    }
     
}

