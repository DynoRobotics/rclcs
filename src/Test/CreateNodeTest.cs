using NUnit.Framework;
using System;
namespace rclcs.Test
{
    [TestFixture]
    public class CreateNodeTest
    {
        RCL rclcs = new RCL();
        Context context;

        [SetUp]
        public void SetUp()
        {
            context = new Context();
            rclcs.Init(context);
        }

        [TearDown]
        public void TearDown()
        {
            rclcs.Shutdown(context);
        }

        [Test]
        public void CreateNode()
        {
            string nodeName = "create_node_test";
            rclcs.CreateNode(nodeName, context).DestroyNode();
        }

        [Test]
        public void CreateNodeWithNamespace()
        {
            string nodeName = "create_node_test";
            string nodeNamespace = "/ns";
            Node node = rclcs.CreateNode(nodeName, context, nodeNamespace: nodeNamespace);
            Assert.That(node.Namespace, Is.EqualTo("/ns"));
            node.DestroyNode();
        }

        [Test]
        public void CreateNodeWithEmptyNamespace()
        {
            string nodeName = "create_node_test";
            string nodeNamespace = "";
            Node node = rclcs.CreateNode(nodeName, context, nodeNamespace: nodeNamespace);
            Assert.That(node.Namespace, Is.EqualTo("/"));
            node.DestroyNode();
        }

        [Test]
        public void CreateNodeWithRelativeNamespace()
        {
            string nodeName = "create_node_test";
            string nodeNamespace = "ns";
            Node node = rclcs.CreateNode(nodeName, context, nodeNamespace: nodeNamespace);
            Assert.That(node.Namespace, Is.EqualTo("/ns"));
            node.DestroyNode();
        }

        [Test]
        public void CreateNodeWithInvalidName()
        {
            string nodeName = "create_node_test_invaild_name?";
            Assert.That( () => { rclcs.CreateNode(nodeName, context).DestroyNode(); }, 
                         Throws.TypeOf<InvalidNodeNameException>());
        }

        [Test]
        public void CreateNodeWithInvalidRelativeNamespace()
        {
            string nodeName = "create_node_test_invalid_namespace";
            string nodeNamespace = "invalid_namespace?";

            Assert.That( () => { rclcs.CreateNode(nodeName, context, nodeNamespace: nodeNamespace).DestroyNode(); }, 
                         Throws.TypeOf<InvalidNamespaceException>());
        }
    }
}