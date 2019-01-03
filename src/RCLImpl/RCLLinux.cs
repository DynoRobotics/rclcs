using System;
using System.Runtime.InteropServices;
using System.Security;

namespace rclcs
{
	/// <summary>
	/// The RCL class handles the initialisation of the ros client librarie and wraps the functions defined in the rcl/rcl.h.
	/// It furthermore defines the paths to the rcl and rmw libs that are used in the DllImport statement for native interop.
	/// This class implements IDisposable.
	/// </summary>
	internal class RCLLinux:RCLBase
	{

        /// <summary>
        /// This method does the initilisation of the ros client lib.
        /// <remarks>Call this method before you do any other calls to ros</remarks>
        /// </summary>
        /// <param name="args">Commandline arguments</param>
        /// <exception cref="RCLAlreadInitExcption">In case rcl was alread initialised</exception>
        public override void Init(String[] args)
		{
            rcl_context_t context = ZeroInitializedContext;

		}
		
        /// <summary>
        /// Gets a zero initialization context object.
        /// </summary>

        public override rcl_context_t ZeroInitializedContext
        {
            get { return new rcl_context_t(); }
        }
              
        /// <summary>
        /// Implementation of IDisposable
        /// </summary>
        /// <param name="disposing">If set to <c>true</c> disposing.</param>
        protected override void Dispose(bool disposing)
		{
			if (disposed)
				return;
			if (disposing) {

				// Free any other managed objects here.
			}
			// Free any unmanaged objects here.
			//RCLReturnValues retVal = (RCLReturnValues)rcl_shutdown();
			//}
			disposed = true;
		}
		/// <summary>
		/// Releases unmanaged resources and performs other cleanup operations before the <see cref="rclcs.RCL"/> is reclaimed
		/// by garbage collection.
		/// </summary>
		~RCLLinux()
		{
			Dispose (false);
		}

       
    }
}

