using System;
using ROS2.Utils;
using System.Runtime.InteropServices;


namespace rclcs
{
    public static class NumberTest
    {
        public static int Number
        {
            get
            {
                rosidl_generator_cs.msg.Bool testMessage = new rosidl_generator_cs.msg.Bool();
                return testMessage.TestValue;
            }
        }
    }
}
