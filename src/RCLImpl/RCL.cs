using System;
namespace rclcs
{
    internal abstract class RCLBase
    {
        /// <summary>
        /// This method does the initilisation of the ros client lib.
        /// <remarks>Call this method before you do any other calls to ros</remarks>
        /// </summary>
        public abstract void Init(Context context);

        /// <summary>
        /// This method does the shutdown of the ros client lib.
        /// <remarks>Call this method before you run init again</remarks>
        /// </summary>
        public abstract void Shutdown();
        /// <summary>
        /// This method does the shutdown of the ros client lib.
        /// <remarks>Call this method before you run init again</remarks>
        /// </summary>
        public abstract void Shutdown(Context context);

	}

    public class Rclcs
    {
        RCLBase Impl;
        public Rclcs()
        {
            if (Environment.OSVersion.Platform == PlatformID.Win32NT) {
                //FIXME: add windows impl
                //Impl = new RCLWindows();
                Impl = new RCLLinux();
            }
            else if (Environment.OSVersion.Platform == PlatformID.Unix) {
                Impl = new RCLLinux();
            } else {
                throw new Exception("Operating system: " + Environment.OSVersion.Platform.ToString() + " not supported");
            }
        }

        public void Init()
        {
            Init(new Context());
        }

        public void Init(Context context)
        {
            Impl.Init(context);
        }

        public Node CreateNode(string name, Context context)
        {
            throw new NotInitializedException();
            //return new Node();
        }

        public void Shutdown()
        {
            Impl.Shutdown();
        }

        public void Shutdown(Context context)
        {
            Impl.Shutdown(context);
        }
    }		
}

