using NUnit.Framework;
using System;
namespace rclcs.Test
{
    [TestFixture]
    public class ClockTest
    {
        Context context;

        [SetUp]
        public void SetUp()
        {
            context = new Context();
            Rclcs.Init(context);
        }

        [TearDown]
        public void TearDown()
        {
            Rclcs.Shutdown(context);
        }

        [Test]
        public void CreateClock()
        {
            Clock clock = new Clock();
        }

        [Test]
        public void ClockGetNow()
        {
            Clock clock = new Clock();
            Clock.RosTime timeNow = clock.Now;
            //Assert.That(timeNow.sec, Is.EqualTo(10));
        }

    }
}
