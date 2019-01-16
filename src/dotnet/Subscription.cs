using System;
using System.Reflection;
using ROS2.Interfaces;
namespace rclcs
{

    public class Subscription<T>: ISubscription<T> where T : IRclcsMessage
    {
        private rcl_subscription_t handle;
        rcl_node_t nodeHandle;

        public rcl_subscription_t Handle { get { return handle; } }

        internal Action<T> callback;

        private bool disposed;

        public Subscription(string topic, Node node, Action<T> callback)
        {
            this.callback = callback;
            nodeHandle = node.handle;
            handle = NativeMethods.rcl_get_zero_initialized_subscription();
            rcl_subscription_options_t subscriptionOptions = NativeMethods.rcl_subscription_get_default_options();

            MethodInfo m = typeof(T).GetTypeInfo().GetDeclaredMethod("_GET_TYPE_SUPPORT");
            IntPtr typeSupportHandle = (IntPtr)m.Invoke(null, new object[] { });

            Utils.CheckReturnEnum(NativeMethods.rcl_subscription_init(
                                    ref handle, 
                                    ref nodeHandle, 
                                    typeSupportHandle, 
                                    topic,
                                    ref subscriptionOptions));
        }

        ~Subscription()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
        }

        private void Dispose(bool disposing)
        {
            if(!disposed)
            {
                if(disposing)
                {
                    // Dispose managed resources.
                }

                DestroyPublisher();

                disposed = true;
            }
        }


        private void DestroyPublisher()
        {
            Utils.CheckReturnEnum(NativeMethods.rcl_subscription_fini(ref handle, ref nodeHandle));
        }


        //public void Publish(T msg)
        //{
        //    Utils.CheckReturnEnum(NativeMethods.rcl_(ref handle, msg.Handle));
        //}
    }
}
