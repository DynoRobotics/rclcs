using System;
using System.Collections.Generic;
using ROS2.Interfaces;

namespace rclcs
{
    /// <summary>
    /// Represents a managed ROS node
    /// </summary>
    public class Node: System.IDisposable
    {
        internal rcl_node_t handle;

        private bool disposed;
        
        public Node(string nodeName, Context context, string nodeNamespace = null)
        {
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
            // TODO(samiam): Add to list and call dispose for all publishers before destroying node?
            return new Publisher<T>(topic, this);
        }

    }


}

