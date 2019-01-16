using System;
namespace rclcs
{
    public interface ISubscriptionBase : IDisposable
    {
        rcl_subscription_t Handle { get; }
    }

}
