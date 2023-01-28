using System;
using System.Collections.Generic;
using System.Reflection;

// Token: 0x02000130 RID: 304
public static class ReferenceTypeHelper
{
	// Token: 0x06000787 RID: 1927 RVA: 0x00020B28 File Offset: 0x0001ED28
	// Note: this type is marked as 'beforefieldinit'.
	static ReferenceTypeHelper()
	{
	}

	// Token: 0x06000788 RID: 1928 RVA: 0x00020B34 File Offset: 0x0001ED34
	public static bool TreatAsReferenceHolder(global::System.Type type)
	{
		bool flag;
		if (!global::ReferenceTypeHelper.cache.TryGetValue(type, out flag))
		{
			if (type.IsByRef)
			{
				flag = true;
			}
			else if (type.IsEnum)
			{
				flag = false;
			}
			else
			{
				foreach (global::System.Reflection.FieldInfo fieldInfo in type.GetFields(global::System.Reflection.BindingFlags.Instance | global::System.Reflection.BindingFlags.Public | global::System.Reflection.BindingFlags.NonPublic))
				{
					global::System.Type fieldType = fieldInfo.FieldType;
					if (fieldType.IsByRef || !global::ReferenceTypeHelper.TreatAsReferenceHolder(fieldType))
					{
						flag = false;
						break;
					}
				}
			}
			global::ReferenceTypeHelper.cache[type] = flag;
		}
		return flag;
	}

	// Token: 0x040005FE RID: 1534
	private static readonly global::System.Collections.Generic.Dictionary<global::System.Type, bool> cache = new global::System.Collections.Generic.Dictionary<global::System.Type, bool>();
}
