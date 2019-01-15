using NUnit.Framework;
using System;
namespace rclcs.Test
{
    [TestFixture()]
    public class MessagesTest
    {
    
        [Test]
        public void CreateMessage()
        {
            std_msgs.msg.Bool msg = new std_msgs.msg.Bool();
        }

        [Test]
        public void SetBoolData()
        {
            std_msgs.msg.Bool msg = new std_msgs.msg.Bool();
            Assert.That(msg.data, Is.False);
            msg.data = true;
            Assert.That(msg.data, Is.True);
            msg.data = false;
            Assert.That(msg.data, Is.False);
        }

        [Test]
        public void SetInt64Data()
        {
            std_msgs.msg.Int64 msg = new std_msgs.msg.Int64();
            Assert.That(msg.data, Is.EqualTo(0));
            msg.data = 12345;
            Assert.That(msg.data, Is.EqualTo(12345));
        }

    }
}
