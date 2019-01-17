using NUnit.Framework;
using System;
namespace rclcs.Test
{
    [TestFixture]
    public class SubscriptionTest
    {
        Context context;
        Node node;
        Publisher<std_msgs.msg.Int32> publisher;

        [SetUp]
        public void SetUp()
        {
            context = new Context();
            Rclcs.Init(context);
            node = new Node("subscription_test_node", context);
            publisher = node.CreatePublisher<std_msgs.msg.Int32>("subscription_test_topic");
        }

        [Test]
        public void SubscriptionTriggerCallback()
        {
            bool callbackTriggered = false;
            node.CreateSubscription<std_msgs.msg.Int32>("subscription_test_topic", (msg) => { callbackTriggered = true; });
            publisher.Publish(new std_msgs.msg.Int32());
            Rclcs.SpinOnce(node, 0.1);

            Assert.That(callbackTriggered, Is.True);
        }

        [Test]
        public void SubscriptionCallbackMessageData()
        {
            int messageData = 0;
            node.CreateSubscription<std_msgs.msg.Int32>("subscription_test_topic", (msg) => { messageData = msg.data; });
            std_msgs.msg.Int32 published_msg = new std_msgs.msg.Int32();
            published_msg.data = 42;
            publisher.Publish(published_msg);
            Rclcs.SpinOnce(node, 0.1);

            Assert.That(messageData, Is.EqualTo(42));
        }
    }
}
