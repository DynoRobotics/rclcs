using System;
using System.Collections.Generic;
using ROS2.Interfaces;

namespace rclcs
{
    /// <summary>
    /// Represents a managed ROS node
    /// </summary>
    public class Node: INode
    {
        internal rcl_node_t handle;

        private bool disposed;

        private IList<ISubscriptionBase> subscriptions;
        private IList<IPublisherBase> publishers;

        public IList<ISubscriptionBase> Subscriptions { get { return subscriptions; } }

        public Node(string nodeName, Context context, string nodeNamespace = null)
        {
            subscriptions = new List<ISubscriptionBase>();
            publishers = new List<IPublisherBase>();

            if (nodeNamespace == null) { nodeNamespace = "/";  }
            if (context.Ok)
            {
                handle = NativeMethods.rcl_get_zero_initialized_node();
                rcl_node_options_t defaultNodeOptions = NativeMethods.rcl_node_get_default_options();

                Utils.CheckReturnEnum(NativeMethods.rcl_node_init(ref handle, nodeName, nodeNamespace, ref context.handle, ref defaultNodeOptions));

            }
            else
            {
                throw new NotInitializedException();
            }
        }

        public string Name
        {
            get { return MarshallingHelpers.PtrToString(NativeMethods.rcl_node_get_name(ref handle)); }
        }

        public string Namespace
        {
            get { return MarshallingHelpers.PtrToString(NativeMethods.rcl_node_get_namespace(ref handle)); }
        }

        ~Node()
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

                foreach(ISubscriptionBase subscription in subscriptions)
                {
                    subscription.Dispose();
                }

                foreach(IPublisherBase publisher in publishers)
                {
                    publisher.Dispose();
                }

                DestroyNode();

                disposed = true;
            }
        }

        public void DestroyNode()
        {
            Utils.CheckReturnEnum(NativeMethods.rcl_node_fini(ref handle));
        }
       

        public Publisher<T> CreatePublisher<T>(string topic) where T : IRclcsMessage
        {
            Publisher<T> publisher = new Publisher<T>(topic, this);
            publishers.Add(publisher);
            return publisher;
        }

        public Subscription<T> CreateSubscription<T>(string topic, Action<T> callback) where T : IRclcsMessage, new ()
        {
            Subscription<T> subscription = new Subscription<T>(topic, this, callback);
            subscriptions.Add(subscription);
            return subscription;
        }

    }


}

