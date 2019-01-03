using NUnit.Framework;
using System;

using rclcs;
using System.Runtime.InteropServices;

namespace rclcs.Test
{
    [TestFixture]
    public class InitTest:AssertionHelper
    {
        [Test]
        public void CreateAndDeleteManual()
        {

            RCL rcl = new RCL();
            //Assert.IsNotNull(rcl);
            //Assert.IsFalse(rcl.IsInit);

            //Action<string[]> init_delegate = new Action<string[]>(rcl.Init);
            //Assert.DoesNotThrow(() => init_delegate(new string[] { }));
            //Assert.Throws<ArgumentNullException>(() => init_delegate(null));

            rcl.Dispose();
        }

        //[Test]
        //public void CreateAndDelete()
        //{
        //    using (RCL rcl = new RCL()) 
        //    {
        //       Assert.IsNotNull(rcl);
        //        //if (!rcl.IsInit) {
        //        //    Action<string[]> init_delegate = new Action<string[]>(rcl.Init);
        //        //    Assert.DoesNotThrow(() => init_delegate(new string[]{ }));
        //        //    Assert.IsTrue(rcl.IsInit);
        //        //    Assert.Throws<ArgumentNullException>(() => init_delegate(null));
        //        //}
        //    }

        //}

    }

}
