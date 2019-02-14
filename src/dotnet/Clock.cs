using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rclcs
{
    class Clock : IDisposable
    {
        private bool disposed;

        internal IntPtr handle;

        public builtin_interfaces.msg.Time Now
        {
            get
            {
                builtin_interfaces.msg.Time time = new builtin_interfaces.msg.Time();
                long queryNowNanoseconds = 0;
                NativeMethods.rcl_clock_get_now(handle, ref queryNowNanoseconds);
                time.sec = (int)(queryNowNanoseconds / (long)1e9);
                time.nanosec = (uint)(queryNowNanoseconds - queryNowNanoseconds/((long)10e9));
                return time;
            }
        }

        public Clock()
        {
            rcl_allocator_t allocator = NativeMethods.rcl_get_default_allocator();
            handle = NativeMethods.rclcs_ros_clock_create(ref allocator);
        }

        ~Clock()
        {
            Dispose();
        }

        public void Dispose()
        {
            if(!disposed)
            {
                NativeMethods.rclcs_ros_clock_dispose(handle);
                disposed = true;
            }
        }
    }
}
