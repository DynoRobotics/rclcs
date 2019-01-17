using System;
using ROS2.Interfaces;

namespace rclcs
{
    public static class Rclcs
    {
        // NOTE: Init context when created instaid?

        public static void Init(Context context)
        {
            context.Init();
        }
    

        public static void Shutdown(Context context)
        {
            context.Shutdown();
        }

        public static Node CreateNode(string nodeName, Context context, string nodeNamespace = null)
        {
            return new Node(nodeName, context, nodeNamespace: nodeNamespace);
        }

        public static void Spin(INode node)
        {
            SpinOnce(node, 0.1);
        }

        public static void SpinOnce(INode node, double timeoutSec)
        {
            // NOTE: Only single thread, add support for other executors?
            WaitSet waitSet = new WaitSet(node.Subscriptions);
            waitSet.Wait(timeoutSec);

            foreach(ISubscriptionBase subscription in node.Subscriptions)
            {
                IRclcsMessage message = subscription.CreateMessage();
                bool gotMessage = Take(subscription, message);

                if (gotMessage)
                {
                    subscription.TriggerCallback(message);
                }
            }

        }

        public static bool Take(ISubscriptionBase subscription, IRclcsMessage message)
        {
            rcl_subscription_t subscription_handle = subscription.Handle;
            IntPtr message_handle = message.Handle;
            RCLReturnEnum ret = (RCLReturnEnum)NativeMethods.rcl_take(ref subscription_handle, message_handle, IntPtr.Zero);
            return ret == RCLReturnEnum.RCL_RET_OK;
        }
    }
}
