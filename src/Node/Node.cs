using System;

namespace rclcs
{
    /// <summary>
    /// Represents a managed ROS node
    /// </summary>
    public class Node
    {
        rcl_node_t rclNode;

        public Node(string nodeName, Context context, string nodeNamespace = null)
        {
            if (nodeNamespace == null) { nodeNamespace = "/";  }
            if (context.Ok)
            {
                rclNode = SafeNativeMethodsLinux.rcl_get_zero_initialized_node();
                rcl_node_options_t defaultNodeOptions = SafeNativeMethodsLinux.rcl_node_get_default_options();

                RclHelpers.CheckReturnEnum(NativeMethodsLinux.rcl_node_init(ref rclNode, nodeName, nodeNamespace, ref context.rclContext, ref defaultNodeOptions));

            }
            else
            {
                throw new NotInitializedException();
            }
        }

        public string Name
        {
            get { return MarshallingHelpers.PtrToString(SafeNativeMethodsLinux.rcl_node_get_name(ref rclNode)); }
        }

        public string Namespace
        {
            get { return MarshallingHelpers.PtrToString(SafeNativeMethodsLinux.rcl_node_get_namespace(ref rclNode)); }
        }

        public void DestroyNode()
        {
            NativeMethodsLinux.rcl_node_fini(ref rclNode);
        }

    }


}

