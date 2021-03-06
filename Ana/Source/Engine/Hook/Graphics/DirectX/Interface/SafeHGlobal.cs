﻿namespace Ana.Source.Engine.Hook.Graphics.DirectX.Interface
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Provides a safe handle around a block of unmanaged memory.
    /// </summary>
    public class SafeHGlobal : SafeHandle
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SafeHGlobal"/> class.
        /// </summary>
        /// <param name="sizeInBytes">The size of the block of memory to allocate, in bytes.</param>
        public SafeHGlobal(Int32 sizeInBytes) : base(Marshal.AllocHGlobal(sizeInBytes), true)
        {
        }

        /// <summary>
        /// When overridden in a derived class, gets a value indicating whether the handle value is invalid.
        /// </summary>
        /// <returns>true if the handle value is invalid; otherwise, false.</returns>
        public override Boolean IsInvalid
        {
            get
            {
                return this.handle == IntPtr.Zero;
            }
        }

        /// <summary>
        /// When overridden in a derived class, executes the code required to free the handle.
        /// </summary>
        /// <returns>
        /// true if the handle is released successfully; otherwise, in the event of a catastrophic failure, false. In this case, it generates a releaseHandleFailed MDA Managed Debugging Assistant.
        /// </returns>
        protected override Boolean ReleaseHandle()
        {
            Marshal.FreeHGlobal(this.handle);
            return true;
        }
    }
    //// End class
}
//// End namespace