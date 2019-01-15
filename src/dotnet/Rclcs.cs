using System;
namespace rclcs
{
    public static class Rclcs
    {
        public static void Init(Context context)
        {
            rcl_init_options_t init_options = NativeMethods.rcl_get_zero_initialized_init_options();
            rcl_allocator_t allocator = NativeMethods.rcl_get_default_allocator();

            Utils.CheckReturnEnum(NativeMethods.rcl_init_options_init(ref init_options, allocator));
            Utils.CheckReturnEnum(NativeMethods.rcl_init(0, null, ref init_options, ref context.rclContext));
        }
    

        public static void Shutdown(Context context)
        {
            Utils.CheckReturnEnum(NativeMethods.rcl_shutdown(ref context.rclContext));
            Utils.CheckReturnEnum(NativeMethods.rcl_context_fini(ref context.rclContext));
        }
    

        public static Node CreateNode(string nodeName, Context context, string nodeNamespace = null)
        {
            return new Node(nodeName, context, nodeNamespace: nodeNamespace);
        }
    }
}
