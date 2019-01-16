using System;
using ROS2.Interfaces;

namespace rclcs
{
    public interface IPublisher<T>: IPublisherBase
        where T: IRclcsMessage
    {
    }
}
