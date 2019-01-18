using System;
using System.Reflection;
using ROS2.Interfaces;
namespace rclcs
{

    public class Publisher<T>: IPublisher<T> where T : IRclcsMessage
    {
        rcl_publisher_t handle;
        rcl_node_t nodeHandle;

        private bool disposed;

        public Publisher(string topic, Node node)
        {
            nodeHandle = node.handle;
            handle = NativeMethods.rcl_get_zero_initialized_publisher();
            rcl_publisher_options_t publisherOptions = NativeMethods.rcl_publisher_get_default_options();

            MethodInfo m = typeof(T).GetTypeInfo().GetDeclaredMethod("_GET_TYPE_SUPPORT");
            IntPtr typeSupportHandle = (IntPtr)m.Invoke(null, new object[] { });

            Utils.CheckReturnEnum(NativeMethods.rcl_publisher_init(
                                    ref handle, 
                                    ref nodeHandle, 
                                    typeSupportHandle, 
                                    topic,
                                    ref publisherOptions));

        }

        ~Publisher()
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
            Utils.CheckReturnEnum(NativeMethods.rcl_publisher_fini(ref handle, ref nodeHandle));
        }


        public void Publish(T msg)
        {
            Utils.CheckReturnEnum(NativeMethods.rcl_publish(ref handle, msg.Handle));
        }
    }
}
