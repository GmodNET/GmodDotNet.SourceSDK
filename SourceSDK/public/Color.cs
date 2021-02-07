using System.Runtime.InteropServices;

namespace GmodNET.SourceSDK
{
	/// <summary>
	/// Color struct
	/// </summary>
	/// <example>
	/// Tier0.Dbg.ConColorMsg(new Color(255, 0, 255), "message\n");
	/// </example>
	/// <remarks>
	/// "public/Color.h"
	/// </remarks>
	public struct Color
	{
		/// <summary>
		/// Red
		/// </summary>
		[MarshalAs(UnmanagedType.U1)]
		public byte r;
		/// <summary>
		/// Green
		/// </summary>
		[MarshalAs(UnmanagedType.U1)]
		public byte g;
		/// <summary>
		/// Blue
		/// </summary>
		[MarshalAs(UnmanagedType.U1)]
		public byte b;
		/// <summary>
		/// Alpha
		/// </summary>
		[MarshalAs(UnmanagedType.U1)]
		public byte a;

		/// <param name="r">Red</param>
		/// <param name="g">Green</param>
		/// <param name="b">Blue</param>
		/// <param name="a">Alpha</param>
		public Color(byte r, byte g, byte b, byte a = 255)
		{
			this.r = r;
			this.g = g;
			this.b = b;
			this.a = a;
		}
	}
}
