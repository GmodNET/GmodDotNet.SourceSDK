using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SourceSDK
{
	
	public struct IFileSystem
	{
		public static class Delegates
		{
			public delegate bool rBool();
		}

		public Delegates.rBool IsSteam;
	}
}
