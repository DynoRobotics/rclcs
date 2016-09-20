﻿using System;
using System.Runtime.InteropServices;
namespace rclcs
{
	
	public class RCL:IDisposable
	{
		bool disposed = false;
		#if (__MonoCS__)
		[DllImport("librcl.so")]
		#else
		[DllImport("rcl.dll")]
		#endif
	    static extern int rcl_init(int argc, [In, Out] String[] argv, rcl_allocator_t allocator);

		/**
		 * Call this function instead of rcl_init
		 */
		public void Init(String[] args)
		{
			RCLReturnValues retVal = (RCLReturnValues)rcl_init (args.Length, args, Allocator.rcl_get_default_allocator ());
			switch (retVal) {
			case RCLReturnValues.RCL_RET_OK:
				break;
			case RCLReturnValues.RCL_RET_ALREADY_INIT:
				throw new RCLAlreadyInitExcption ();
				break;
			case RCLReturnValues.RCL_RET_BAD_ALLOC:
				throw new RCLBadAllocException ();
				break;
			case RCLReturnValues.RCL_RET_ERROR:
				throw new RCLErrorException (RCLErrorHandling.GetRMWErrorState());
				break;
			default:
				break;
			}

		}
		public void Init(String[] args, rcl_allocator_t custom_allocator)
		{
			RCLReturnValues retVal = (RCLReturnValues)rcl_init (args.Length, args, custom_allocator);
			switch (retVal) {
			case RCLReturnValues.RCL_RET_OK:
				break;
			case RCLReturnValues.RCL_RET_ALREADY_INIT:
				throw new RCLAlreadyInitExcption ();
				break;
			case RCLReturnValues.RCL_RET_BAD_ALLOC:
				throw new RCLBadAllocException ();
				break;
			case RCLReturnValues.RCL_RET_ERROR:
				throw new RCLErrorException (RCLErrorHandling.GetRMWErrorState());
				break;
			default:
				break;
			}

		}

		#if (__MonoCS__)
		[DllImport("librcl.so")]
		#else
		[DllImport("rcl.dll")]
		#endif
	    static extern int rcl_shutdown ();

		#if (__MonoCS__)
		[DllImport("librcl.so")]
		#else
		[DllImport("rcl.dll")]
		#endif
	    static extern UInt64 rcl_get_instance_id ();

		#if (__MonoCS__)
		[DllImport("librcl.so")]
		#else
		[DllImport("rcl.dll")]
		#endif
		static extern bool rcl_ok ();

		public void Dispose()
		{
			// Dispose of unmanaged resources.
			Dispose(true);
			// Suppress finalization.
			GC.SuppressFinalize(this);
		}
		protected virtual void Dispose(bool disposing)
		{
			if (disposed)
				return;
			if (disposing) {
				
				// Free any other managed objects here.
			}
			// Free any unmanaged objects here.
			RCLReturnValues retVal = (RCLReturnValues)rcl_shutdown ();
			switch (retVal) {
			case RCLReturnValues.RCL_RET_OK:
				break;
			case RCLReturnValues.RCL_RET_NOT_INIT:
				//throw new RCLNotInitException ();
				break;
			case RCLReturnValues.RCL_RET_ERROR:
				//throw new RCLErrorException (RCLErrorHandling.GetRMWErrorState());
				break;
			default:
				break;
			}
			disposed = true;
		}
		~RCL()
		{
			Dispose (false);
		}


	}
	public enum RCLReturnValues
	{
		RCL_RET_OK = 0,
		RCL_RET_ERROR = 1,
		RCL_RET_TIMEOUT = 2,
		// rcl specific ret codes start at 100
		RCL_RET_ALREADY_INIT = 100,
		RCL_RET_NOT_INIT = 101,
		RCL_RET_BAD_ALLOC = 102,
		RCL_RET_INVALID_ARGUMENT = 103,
		RCL_REG_MISMATCHED_RMW_ID = 104,
		// rcl node specific ret codes in 2XX
		RCL_RET_NODE_INVALID = 200,
		// rcl publisher specific ret codes in 3XX
		RCL_RET_PUBLISHER_INVALID =  300,
		// rcl subscription specific ret codes in 4XX
		RCL_RET_SUBSCRIPTION_INVALID = 400,
		RCL_RET_SUBSCRIPTION_TAKE_FAILED = 401,
		// rcl service client specific ret codes in 5XX
		RCL_RET_CLIENT_INVALID = 500,
		RCL_RET_CLIENT_TAKE_FAILED = 501,
		// rcl service server specific ret codes in 6XX
		RCL_RET_SERVICE_INVALID =600,
		RCL_RET_SERIVCE_TAKE_FAILD = 601,
		// rcl guard condition specific ret codes in 7XX
		// rcl timer specific ret codes in 8XX
		RCL_RET_TIMER_INVALID = 800,
		RCL_RET_TIMER_CANCELED = 801,
		// rcl wait and wait set specific ret codes in 9XX
		RCL_RET_WAIT_SET_INVALID = 900,
		RCL_RET_WAIT_SET_EMPTY = 901,
		RCL_RET_WAIT_SET_FULL = 902
	}
			
}

