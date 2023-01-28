using System;
using System.Reflection;

namespace Facepunch.Util
{
	// Token: 0x020001BD RID: 445
	public class Reflection
	{
		// Token: 0x06000D12 RID: 3346 RVA: 0x000329AC File Offset: 0x00030BAC
		public Reflection()
		{
		}

		// Token: 0x06000D13 RID: 3347 RVA: 0x000329B4 File Offset: 0x00030BB4
		public static bool HasAttribute(global::System.Reflection.MemberInfo method, global::System.Type attribute)
		{
			object[] customAttributes = method.GetCustomAttributes(attribute, true);
			return customAttributes.Length > 0;
		}
	}
}
