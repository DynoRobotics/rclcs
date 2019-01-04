using NUnit.Framework;
using System;

using rclcs;

namespace rclcs.Test
{
    [TestFixture]
    public class InitShutdownTest
    {
        Rclcs rclcs = new Rclcs();

        [Test]
        public void Init()
        {
            Context context = new Context();
            rclcs.Init(context);
            try
            {
                rclcs.Shutdown(context);
            }
            catch (RuntimeError)
            {
            }
        }

        [Test]
        public void InitShutdown()
        {
            Context context = new Context();
            rclcs.Init(context);
            rclcs.Shutdown(context);
        }

        [Test]
        public void InitShutdownSequence()
        {
            // local
            Context context = new Context();
            rclcs.Init(context);
            rclcs.Shutdown(context);
            context = new Context();
            rclcs.Init(context);
            rclcs.Shutdown(context);

            // global
            rclcs.Init();
            rclcs.Shutdown();
            rclcs.Init();
            rclcs.Shutdown();
        }

        [Test]
        public void DoubleInit()
        {
            Context context = new Context();
            rclcs.Init(context);
            Assert.That(() => { rclcs.Init(context); }, Throws.TypeOf<RuntimeError>());
            rclcs.Shutdown(context);
        }

        [Test]
        public void DoubleShutdown()
        {
            Context context = new Context();
            rclcs.Init(context);
            rclcs.Shutdown(context);
            Assert.That(() => { rclcs.Shutdown(context); }, Throws.TypeOf<RuntimeError>());
        }

        [Test]
        public void CreateNodeWithoutInit()
        {
            Context context = new Context();
            Assert.That(() => { rclcs.CreateNode("foo", context); }, Throws.TypeOf<NotInitializedException>());
        }

        
    }

}
