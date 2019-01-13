using NUnit.Framework;
using System;
namespace rclcs.Test
{
    [TestFixture]
    public class NodeTest
    {
        const string NODE_NAME = "test_node";
        const string NODE_NAMESPACE = "/test_ns";

        RCL rclcs = new RCL();
        Context context;
        Node node;

        [SetUp]
        public void SetUp()
        {
            context = new Context();
            rclcs.Init(context);
            node = new Node(NODE_NAME, context, nodeNamespace: NODE_NAMESPACE);
        }

        [TearDown]
        public void TearDown()
        {
            node.DestroyNode();
            rclcs.Shutdown(context);
        }

        [Test]
        public void Accesors()
        {
            Assert.That(node.Name, Is.EqualTo(NODE_NAME));
            Assert.That(node.Namespace, Is.EqualTo(NODE_NAMESPACE));
            // TODO: add clock accessor
        }

        [Test]
        public void CreatePublisher()
        {
            //node.CreatePublisher()
            rosidl_generator_cs.msg.Bool msg = new rosidl_generator_cs.msg.Bool();
        }
    }
}
