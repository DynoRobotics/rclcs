using System;
namespace rclcs
{
    public static class Rclcs
    {
        //TODO: Change context to IDisposable?

        public static void Init(Context context)
        {
            rcl_init_options_t init_options = NativeMethods.rcl_get_zero_initialized_init_options();
            rcl_allocator_t allocator = NativeMethods.rcl_get_default_allocator();

            Utils.CheckReturnEnum(NativeMethods.rcl_init_options_init(ref init_options, allocator));
            Utils.CheckReturnEnum(NativeMethods.rcl_init(0, null, ref init_options, ref context.handle));
        }
    

        public static void Shutdown(Context context)
        {
            Utils.CheckReturnEnum(NativeMethods.rcl_shutdown(ref context.handle));
            Utils.CheckReturnEnum(NativeMethods.rcl_context_fini(ref context.handle));
        }


        public static Node CreateNode(string nodeName, Context context, string nodeNamespace = null)
        {
            return new Node(nodeName, context, nodeNamespace: nodeNamespace);
        }
    }
}
