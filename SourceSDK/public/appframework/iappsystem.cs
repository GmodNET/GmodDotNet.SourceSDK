using GmodNET.SourceSDK.Tier1;
using System;
using System.Runtime.InteropServices;

namespace GmodNET.SourceSDK.AppFramework
{
	public enum InitReturnVal_t
	{
		INIT_FAILED = 0,
		INIT_OK = 1,

		INIT_LAST_VAL = 2,
	};

	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
	public struct AppSystemInfo_t
	{
		[MarshalAs(UnmanagedType.LPStr)]
		public string m_pModuleName;
		[MarshalAs(UnmanagedType.LPStr)]
		public string m_pInterfaceName;
	};

	public enum AppSystemTier_t
	{
		APP_SYSTEM_TIER0 = 0,
		APP_SYSTEM_TIER1 = 1,
		APP_SYSTEM_TIER2 = 2,
		APP_SYSTEM_TIER3 = 3,

		APP_SYSTEM_TIER_OTHER = 4,
	};

	public abstract class IAppSystem
	{
		protected readonly IntPtr ptr;

		public IAppSystem(IntPtr ptr)
		{
			if (ptr == IntPtr.Zero) throw new ArgumentNullException(nameof(ptr), "Passing invalid pointer will cause crash");
			this.ptr = ptr;
		}

		[DllImport("sourcesdkc")]
		internal static extern bool IAppSystem_Connect(IntPtr ptr, CreateInterfaceFn factory);
		public bool Connect(CreateInterfaceFn factory)
		{
			return IAppSystem_Connect(ptr, factory);
		}

		[DllImport("sourcesdkc")]
		internal static extern void IAppSystem_Disconnect(IntPtr ptr);
		public void Disconnect()
		{
			IAppSystem_Disconnect(ptr);
		}

		[DllImport("sourcesdkc")]
		internal static extern IntPtr IAppSystem_QueryInterface(IntPtr ptr, string interfaceName);
		public IntPtr QueryInterface(string interfaceName)
		{
			return IAppSystem_QueryInterface(ptr, interfaceName);
		}

		[DllImport("sourcesdkc")]
		internal static extern InitReturnVal_t IAppSystem_Init(IntPtr ptr);
		public InitReturnVal_t Init()
		{
			return IAppSystem_Init(ptr);
		}

		[DllImport("sourcesdkc")]
		internal static extern void IAppSystem_Shutdown(IntPtr ptr);
		public void Shutdown()
		{
			IAppSystem_Shutdown(ptr);
		}

		[DllImport("sourcesdkc", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		internal static extern AppSystemInfo_t[] IAppSystem_GetDependencies(IntPtr ptr);
		public AppSystemInfo_t[] GetDependencies() => IAppSystem_GetDependencies(ptr);

		[DllImport("sourcesdkc")]
		internal static extern AppSystemTier_t IAppSystem_GetTier(IntPtr ptr);
		public AppSystemTier_t GetTier()
		{
			return IAppSystem_GetTier(ptr);
		}

		[DllImport("sourcesdkc")]
		internal static extern void IAppSystem_Reconnect(IntPtr ptr, CreateInterfaceFn factory, string interfaceName);
		public void Reconnect(CreateInterfaceFn factory, string interfaceName)
		{
			IAppSystem_Reconnect(ptr, factory, interfaceName);
		}

		[DllImport("sourcesdkc")]
		internal static extern bool IAppSystem_IsSingleton(IntPtr ptr);
		public bool IsSingleton()
		{
			return IAppSystem_IsSingleton(ptr);
		}
	}
}
