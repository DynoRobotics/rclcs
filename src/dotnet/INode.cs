using System;
using System.Collections.Generic;
namespace rclcs
{
    public interface INode: IDisposable
    {
        IList<ISubscriptionBase> Subscriptions { get; }
    }
}
