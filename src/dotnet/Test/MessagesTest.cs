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

        [Test]
        public void SetStringData()
        {
            std_msgs.msg.String msg = new std_msgs.msg.String();
            Assert.That(msg.data, Is.EqualTo(""));
            msg.data = "Show me what you got!";
            Assert.That(msg.data, Is.EqualTo("Show me what you got!"));
        }

        [Test]
        public void SetPrimitives()
        {
            test_msgs.msg.Primitives msg = new test_msgs.msg.Primitives();
            msg.int32_value = 24;
            Assert.That(msg.int32_value, Is.EqualTo(24));
            msg.string_value = "Turtles all the way down";
            Assert.That(msg.string_value, Is.EqualTo("Turtles all the way down"));
            msg.float32_value = 3.14F;
            Assert.That(msg.float32_value, Is.EqualTo(3.14F));
        }

        [Test]
        public void SetDynamicArrayPrimitives()
        {
            test_msgs.msg.DynamicArrayPrimitives msg = new test_msgs.msg.DynamicArrayPrimitives();
        }


    }
}
