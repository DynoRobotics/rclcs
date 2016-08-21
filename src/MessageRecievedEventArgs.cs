﻿using System;
namespace ROS2Sharp
{
	public class MessageRecievedEventArgs<T>:EventArgs
		where T : struct
	{
		private T message;
		public MessageRecievedEventArgs(T msg)
		{
			message = msg;
		}
		public T Message
		{
			get { return message; }
		}

	}
}