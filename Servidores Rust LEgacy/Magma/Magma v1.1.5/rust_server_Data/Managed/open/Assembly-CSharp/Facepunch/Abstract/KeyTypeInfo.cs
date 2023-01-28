using System;

namespace Facepunch.Abstract
{
	// Token: 0x02000214 RID: 532
	internal static class KeyTypeInfo
	{
		// Token: 0x06000E74 RID: 3700 RVA: 0x00037858 File Offset: 0x00035A58
		public static int ForcedDifCompareValue(global::System.Type x, global::System.Type y)
		{
			int num = x.GetHashCode().CompareTo(y.GetHashCode());
			if (num == 0)
			{
				num = x.AssemblyQualifiedName.CompareTo(y.AssemblyQualifiedName);
				if (num == 0)
				{
					num = x.TypeHandle.Value.ToInt64().CompareTo(y.TypeHandle.Value);
					if (num == 0)
					{
						throw new global::System.InvalidProgramException();
					}
				}
			}
			return num;
		}
	}
}
