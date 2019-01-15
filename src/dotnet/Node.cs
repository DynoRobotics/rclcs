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
                rclNode = NativeMethods.rcl_get_zero_initialized_node();
                rcl_node_options_t defaultNodeOptions = NativeMethods.rcl_node_get_default_options();

                Utils.CheckReturnEnum(NativeMethods.rcl_node_init(ref rclNode, nodeName, nodeNamespace, ref context.rclContext, ref defaultNodeOptions));

            }
            else
            {
                throw new NotInitializedException();
            }
        }

        public string Name
        {
            get { return MarshallingHelpers.PtrToString(NativeMethods.rcl_node_get_name(ref rclNode)); }
        }

        public string Namespace
        {
            get { return MarshallingHelpers.PtrToString(NativeMethods.rcl_node_get_namespace(ref rclNode)); }
        }

        public void DestroyNode()
        {
            NativeMethods.rcl_node_fini(ref rclNode);
        }

    }


}

