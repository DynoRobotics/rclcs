using NUnit.Framework;
using System;
namespace rclcs.Test
{
    [TestFixture]
    public class WaitTest
    {
        [Test]
        public void TimeoutSecToNsec()
        {
            Assert.That(Utils.TimeoutSecToNsec(0.1), Is.EqualTo(100000000));
            Assert.That(Utils.TimeoutSecToNsec(0), Is.EqualTo(0));

            Assert.Throws<RuntimeError>( () => { Utils.TimeoutSecToNsec(-0.1); });
        }
    }
}
