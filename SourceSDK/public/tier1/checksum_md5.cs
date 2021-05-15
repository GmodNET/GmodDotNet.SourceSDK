using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace GmodNET.SourceSDK.tier1
{
	public static partial class Global
	{
		public const int MD5_DIGEST_LENGTH = 16; // 16 bytes == 128 bit digest
	}
	public struct MD5Value_t : IEquatable<MD5Value_t>
	{
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = Global.MD5_DIGEST_LENGTH)]
		public byte[] bits;// MD5_DIGEST_LENGTH

		public void Zero()
		{
			bits = new byte[Global.MD5_DIGEST_LENGTH];
		}

		public bool IsZero()
		{
			for (int i = 0; i < bits.Length; ++i)
			{
				if (bits[i] != 0)
					return false;
			}

			return true;
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator ==(MD5Value_t obj1, MD5Value_t obj2) => obj1.bits.SequenceEqual(obj2.bits);
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator !=(MD5Value_t obj1, MD5Value_t obj2) => !(obj1 == obj2);

		public override bool Equals(object obj) => this == (MD5Value_t)obj;
		public override int GetHashCode() => base.GetHashCode();

		public bool Equals(MD5Value_t other) => this == other;

		public void MD5_ProcessSingleBuffer(byte[] buffer) => throw new NotImplementedException("todo");
	}

	// todo
	public struct MD5Context_t
	{
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		public uint[] buf;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
		public uint[] bits;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
		public byte[] input;

		public void MD5Init()
		{
			buf[0] = 0x67452301;
			buf[1] = 0xefcdab89;
			buf[2] = 0x98badcfe;
			buf[3] = 0x10325476;

			bits[0] = 0;
			bits[1] = 0;
		}
		public void MD5Update(byte[] buffer) => throw new NotImplementedException("todo");
		public void MD5Final(byte[] buffer) => throw new NotImplementedException("todo");
		public void MD5_Print() => throw new NotImplementedException("todo");
		public void MD5_PseudoRandom() => throw new NotImplementedException("todo");
	}

}
