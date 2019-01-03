using System;
//using System.Runtime.InteropServices;
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

    public struct rcl_arguments_t
    {
        public IntPtr impl;
    }

    public struct rcl_context_t
    {
        public rcl_arguments_t global_arguments;
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

