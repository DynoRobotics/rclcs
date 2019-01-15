using System;
namespace rclcs
{
    public static class Rclcs
    {
        //TODO: Init context when created instaid?

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
    }
}
