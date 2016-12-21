using System;
using System.Runtime.InteropServices;

public static class NativeWrapper {
	// The name of the external library containing the native functions
	#if UNITY_EDITOR
	private const string LIBRARY_NAME = "thread_test";   
	#else
	private const string LIBRARY_NAME = "thread_test";
	#endif

	[DllImport(LIBRARY_NAME, CallingConvention=CallingConvention.Cdecl)]
	[return: MarshalAsAttribute(UnmanagedType.I1)]
	public static extern bool StartThread(Dispatcher.Callback cb);

	[DllImport(LIBRARY_NAME, CallingConvention=CallingConvention.Cdecl)]
	[return: MarshalAsAttribute(UnmanagedType.I1)]
	public static extern bool StopThread();
}