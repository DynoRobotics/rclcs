/*
© Dyno Robotics, 2019
Author: Samuel Lindgren (samuel@dynorobotics.se)
Licensed under the Apache License, Version 2.0 (the "License");

You may not use this file except in compliance with the License.
You may obtain a copy of the License at
<http://www.apache.org/licenses/LICENSE-2.0>.

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
*/

using System;

namespace rclcs
{
    public class Clock : IDisposable
    {
        private bool disposed;

        internal IntPtr handle;

        public struct RosTime
        {
            public int sec;
            public uint nanosec;
        }

        public RosTime Now
        {
            get
            {
                RosTime time = new RosTime();
                long queryNowNanoseconds = 0;
                NativeMethods.rcl_clock_get_now(handle, ref queryNowNanoseconds);
                time.sec = (int)(queryNowNanoseconds / (long)1e9);
                time.nanosec = (uint)(queryNowNanoseconds - time.sec*((long)1e9));
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
