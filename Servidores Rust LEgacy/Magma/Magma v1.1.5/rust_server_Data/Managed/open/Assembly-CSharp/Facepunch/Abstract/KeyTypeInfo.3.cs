using System;

namespace Facepunch.Abstract
{
	// Token: 0x0200021D RID: 541
	internal static class KeyTypeInfo<Key, T> where Key : global::TraitKey where T : Key
	{
		// Token: 0x06000EA4 RID: 3748 RVA: 0x00037F5C File Offset: 0x0003615C
		static KeyTypeInfo()
		{
			if (typeof(T) == typeof(Key))
			{
				throw new global::Facepunch.Abstract.KeyArgumentIsKeyTypeException("<T>", "You cannot use GetTrait<Key>. Must use a types inheriting Key");
			}
			global::Facepunch.Abstract.KeyTypeInfo<Key, T>.Info = global::Facepunch.Abstract.KeyTypeInfo<Key>.Registration.GetUnsafe(typeof(T));
		}

		// Token: 0x04000952 RID: 2386
		internal static readonly global::Facepunch.Abstract.KeyTypeInfo<Key> Info;
	}
}
