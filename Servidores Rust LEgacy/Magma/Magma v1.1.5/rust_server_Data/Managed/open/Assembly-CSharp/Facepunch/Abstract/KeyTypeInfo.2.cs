using System;
using System.Collections.Generic;

namespace Facepunch.Abstract
{
	// Token: 0x02000215 RID: 533
	internal class KeyTypeInfo<Key> where Key : global::TraitKey
	{
		// Token: 0x06000E75 RID: 3701 RVA: 0x000378DC File Offset: 0x00035ADC
		private KeyTypeInfo(global::System.Type Type, global::Facepunch.Abstract.KeyTypeInfo<Key> Base, global::Facepunch.Abstract.KeyTypeInfo<Key> Root, int TraitDepth)
		{
			this.Type = Type;
			this.Base = Base;
			this.Root = (Root ?? this);
			this.TraitDepth = TraitDepth;
			if (this.Root == this)
			{
				this.AssignableTo = new global::System.Collections.Generic.HashSet<global::Facepunch.Abstract.KeyTypeInfo<Key>>();
			}
			else
			{
				this.AssignableTo = new global::System.Collections.Generic.HashSet<global::Facepunch.Abstract.KeyTypeInfo<Key>>(this.Base.AssignableTo);
			}
			this.AssignableTo.Add(this);
			global::Facepunch.Abstract.KeyTypeInfo<Key>.Registration.Add(this);
		}

		// Token: 0x17000378 RID: 888
		// (get) Token: 0x06000E76 RID: 3702 RVA: 0x0003795C File Offset: 0x00035B5C
		public bool IsBaseTrait
		{
			get
			{
				return this.TraitDepth == 0;
			}
		}

		// Token: 0x06000E77 RID: 3703 RVA: 0x00037968 File Offset: 0x00035B68
		public static global::Facepunch.Abstract.KeyTypeInfo<Key> Find(global::System.Type traitType)
		{
			if (!typeof(Key).IsAssignableFrom(traitType))
			{
				throw new global::System.ArgumentOutOfRangeException("traitType", "Must be a type assignable to Key");
			}
			if (traitType == typeof(Key))
			{
				throw new global::Facepunch.Abstract.KeyArgumentIsKeyTypeException("You cannot use GetTrait(typeof(Key). Must use a types inheriting Key");
			}
			return global::Facepunch.Abstract.KeyTypeInfo<Key>.Registration.GetUnsafe(traitType);
		}

		// Token: 0x06000E78 RID: 3704 RVA: 0x000379BC File Offset: 0x00035BBC
		public static bool Find(global::System.Type traitType, out global::Facepunch.Abstract.KeyTypeInfo<Key> info)
		{
			if (typeof(Key).IsAssignableFrom(traitType) && traitType != typeof(Key))
			{
				info = null;
				return false;
			}
			info = global::Facepunch.Abstract.KeyTypeInfo<Key>.Registration.GetUnsafe(traitType);
			return true;
		}

		// Token: 0x06000E79 RID: 3705 RVA: 0x000379F4 File Offset: 0x00035BF4
		public static global::Facepunch.Abstract.KeyTypeInfo<Key> Find<T>() where T : Key
		{
			return global::Facepunch.Abstract.KeyTypeInfo<Key, T>.Info;
		}

		// Token: 0x06000E7A RID: 3706 RVA: 0x000379FC File Offset: 0x00035BFC
		public static bool Find<T>(out global::Facepunch.Abstract.KeyTypeInfo<Key> info) where T : Key
		{
			bool result;
			try
			{
				info = global::Facepunch.Abstract.KeyTypeInfo<Key, T>.Info;
				result = true;
			}
			catch (global::Facepunch.Abstract.KeyArgumentIsKeyTypeException)
			{
				info = null;
				result = false;
			}
			return result;
		}

		// Token: 0x06000E7B RID: 3707 RVA: 0x00037A4C File Offset: 0x00035C4C
		public bool IsAssignableFrom(global::Facepunch.Abstract.KeyTypeInfo<Key> info)
		{
			return info.Root == this.Root && info.TraitDepth >= this.TraitDepth && info.AssignableTo.Contains(this);
		}

		// Token: 0x04000949 RID: 2377
		public readonly global::System.Type Type;

		// Token: 0x0400094A RID: 2378
		public readonly global::Facepunch.Abstract.KeyTypeInfo<Key> Base;

		// Token: 0x0400094B RID: 2379
		public readonly global::Facepunch.Abstract.KeyTypeInfo<Key> Root;

		// Token: 0x0400094C RID: 2380
		public readonly int TraitDepth;

		// Token: 0x0400094D RID: 2381
		public readonly global::System.Collections.Generic.HashSet<global::Facepunch.Abstract.KeyTypeInfo<Key>> AssignableTo;

		// Token: 0x02000216 RID: 534
		internal static class Registration
		{
			// Token: 0x06000E7C RID: 3708 RVA: 0x00037A80 File Offset: 0x00035C80
			// Note: this type is marked as 'beforefieldinit'.
			static Registration()
			{
			}

			// Token: 0x06000E7D RID: 3709 RVA: 0x00037A8C File Offset: 0x00035C8C
			public static void Add(global::Facepunch.Abstract.KeyTypeInfo<Key> info)
			{
				global::Facepunch.Abstract.KeyTypeInfo<Key>.Registration.dict.Add(info.Type, info);
			}

			// Token: 0x06000E7E RID: 3710 RVA: 0x00037AA0 File Offset: 0x00035CA0
			public static global::Facepunch.Abstract.KeyTypeInfo<Key> GetUnsafe(global::System.Type type)
			{
				global::Facepunch.Abstract.KeyTypeInfo<Key> result;
				if (global::Facepunch.Abstract.KeyTypeInfo<Key>.Registration.dict.TryGetValue(type, out result))
				{
					return result;
				}
				global::System.Type baseType = type.BaseType;
				if (typeof(Key) == baseType)
				{
					return new global::Facepunch.Abstract.KeyTypeInfo<Key>(type, null, null, 0);
				}
				global::Facepunch.Abstract.KeyTypeInfo<Key> @unsafe = global::Facepunch.Abstract.KeyTypeInfo<Key>.Registration.GetUnsafe(baseType);
				return new global::Facepunch.Abstract.KeyTypeInfo<Key>(type, @unsafe, @unsafe.Root, @unsafe.TraitDepth + 1);
			}

			// Token: 0x0400094E RID: 2382
			private static readonly global::System.Collections.Generic.Dictionary<global::System.Type, global::Facepunch.Abstract.KeyTypeInfo<Key>> dict = new global::System.Collections.Generic.Dictionary<global::System.Type, global::Facepunch.Abstract.KeyTypeInfo<Key>>();
		}

		// Token: 0x02000217 RID: 535
		public static class Comparison
		{
			// Token: 0x17000379 RID: 889
			// (get) Token: 0x06000E7F RID: 3711 RVA: 0x00037B00 File Offset: 0x00035D00
			public static global::System.Collections.Generic.IEqualityComparer<global::Facepunch.Abstract.KeyTypeInfo<Key>> EqualityComparer
			{
				get
				{
					return global::Facepunch.Abstract.KeyTypeInfo<Key>.Comparison.RootEqualityComparer.Singleton.Instance;
				}
			}

			// Token: 0x1700037A RID: 890
			// (get) Token: 0x06000E80 RID: 3712 RVA: 0x00037B08 File Offset: 0x00035D08
			public static global::System.Collections.Generic.IComparer<global::Facepunch.Abstract.KeyTypeInfo<Key>> Comparer
			{
				get
				{
					return global::Facepunch.Abstract.KeyTypeInfo<Key>.Comparison.HierarchyComparer.Singleton.Instance;
				}
			}

			// Token: 0x02000218 RID: 536
			private class RootEqualityComparer : global::System.Collections.Generic.EqualityComparer<global::Facepunch.Abstract.KeyTypeInfo<Key>>
			{
				// Token: 0x06000E81 RID: 3713 RVA: 0x00037B10 File Offset: 0x00035D10
				private RootEqualityComparer()
				{
				}

				// Token: 0x06000E82 RID: 3714 RVA: 0x00037B18 File Offset: 0x00035D18
				public override bool Equals(global::Facepunch.Abstract.KeyTypeInfo<Key> x, global::Facepunch.Abstract.KeyTypeInfo<Key> y)
				{
					return x.Root == y.Root;
				}

				// Token: 0x06000E83 RID: 3715 RVA: 0x00037B28 File Offset: 0x00035D28
				public override int GetHashCode(global::Facepunch.Abstract.KeyTypeInfo<Key> obj)
				{
					return obj.Root.Type.GetHashCode();
				}

				// Token: 0x02000219 RID: 537
				public static class Singleton
				{
					// Token: 0x06000E84 RID: 3716 RVA: 0x00037B3C File Offset: 0x00035D3C
					static Singleton()
					{
					}

					// Token: 0x0400094F RID: 2383
					public static readonly global::System.Collections.Generic.IEqualityComparer<global::Facepunch.Abstract.KeyTypeInfo<Key>> Instance = new global::Facepunch.Abstract.KeyTypeInfo<Key>.Comparison.RootEqualityComparer();
				}
			}

			// Token: 0x0200021A RID: 538
			internal class HierarchyComparer : global::System.Collections.Generic.Comparer<global::Facepunch.Abstract.KeyTypeInfo<Key>>
			{
				// Token: 0x06000E85 RID: 3717 RVA: 0x00037B48 File Offset: 0x00035D48
				public HierarchyComparer()
				{
				}

				// Token: 0x06000E86 RID: 3718 RVA: 0x00037B50 File Offset: 0x00035D50
				private static int BaseCompare(global::Facepunch.Abstract.KeyTypeInfo<Key> x, global::Facepunch.Abstract.KeyTypeInfo<Key> y)
				{
					if (x.TraitDepth == 0 || x == y)
					{
						return 0;
					}
					int num = global::Facepunch.Abstract.KeyTypeInfo<Key>.Comparison.HierarchyComparer.BaseCompare(x.Base, y.Base);
					if (num == 0)
					{
						num = global::Facepunch.Abstract.KeyTypeInfo.ForcedDifCompareValue(x.Type, y.Type);
					}
					return num;
				}

				// Token: 0x06000E87 RID: 3719 RVA: 0x00037B9C File Offset: 0x00035D9C
				private int CompareForward(global::Facepunch.Abstract.KeyTypeInfo<Key> x, global::Facepunch.Abstract.KeyTypeInfo<Key> y)
				{
					if (x.Root != y.Root)
					{
						return global::Facepunch.Abstract.KeyTypeInfo.ForcedDifCompareValue(x.Root.Type, y.Root.Type);
					}
					if (x.TraitDepth == y.TraitDepth)
					{
						return global::Facepunch.Abstract.KeyTypeInfo<Key>.Comparison.HierarchyComparer.BaseCompare(x, y);
					}
					return x.TraitDepth.CompareTo(y.TraitDepth);
				}

				// Token: 0x06000E88 RID: 3720 RVA: 0x00037C04 File Offset: 0x00035E04
				public override int Compare(global::Facepunch.Abstract.KeyTypeInfo<Key> x, global::Facepunch.Abstract.KeyTypeInfo<Key> y)
				{
					return -this.CompareForward(x, y);
				}

				// Token: 0x0200021B RID: 539
				public static class Singleton
				{
					// Token: 0x06000E89 RID: 3721 RVA: 0x00037C10 File Offset: 0x00035E10
					static Singleton()
					{
					}

					// Token: 0x04000950 RID: 2384
					public static readonly global::System.Collections.Generic.IComparer<global::Facepunch.Abstract.KeyTypeInfo<Key>> Instance = new global::Facepunch.Abstract.KeyTypeInfo<Key>.Comparison.HierarchyComparer();
				}
			}
		}

		// Token: 0x0200021C RID: 540
		internal class TraitDictionary
		{
			// Token: 0x06000E8A RID: 3722 RVA: 0x00037C1C File Offset: 0x00035E1C
			public TraitDictionary(Key[] traitKeys)
			{
				if (traitKeys == null || traitKeys.Length == 0)
				{
					this.rootToKey = new global::System.Collections.Generic.Dictionary<global::Facepunch.Abstract.KeyTypeInfo<Key>, Key>(0);
				}
				else
				{
					this.rootToKey = new global::System.Collections.Generic.Dictionary<global::Facepunch.Abstract.KeyTypeInfo<Key>, Key>(traitKeys.Length, global::Facepunch.Abstract.KeyTypeInfo<Key>.Comparison.EqualityComparer);
					foreach (Key key in traitKeys)
					{
						if (key)
						{
							this.rootToKey.Add(global::Facepunch.Abstract.KeyTypeInfo<Key>.Find(key.GetType()), key);
						}
					}
				}
			}

			// Token: 0x06000E8B RID: 3723 RVA: 0x00037CB0 File Offset: 0x00035EB0
			private bool TryGet(global::Facepunch.Abstract.KeyTypeInfo<Key> info, out Key key)
			{
				return this.rootToKey.TryGetValue(info, out key);
			}

			// Token: 0x06000E8C RID: 3724 RVA: 0x00037CC0 File Offset: 0x00035EC0
			private bool TryGetSoftCast<T>(global::Facepunch.Abstract.KeyTypeInfo<Key> info, out T tkey) where T : Key
			{
				Key key;
				if (this.TryGet(info, out key))
				{
					tkey = (key as T);
					return true;
				}
				tkey = (T)((object)null);
				return false;
			}

			// Token: 0x06000E8D RID: 3725 RVA: 0x00037D00 File Offset: 0x00035F00
			private bool TryGetHardCast<T>(global::Facepunch.Abstract.KeyTypeInfo<Key> info, out T tkey) where T : Key
			{
				Key key;
				if (this.TryGet(info, out key))
				{
					tkey = (T)((object)key);
					return true;
				}
				tkey = (T)((object)null);
				return false;
			}

			// Token: 0x06000E8E RID: 3726 RVA: 0x00037D3C File Offset: 0x00035F3C
			public bool TryGet<T>(out Key key) where T : Key
			{
				return this.TryGet(global::Facepunch.Abstract.KeyTypeInfo<Key, T>.Info, out key);
			}

			// Token: 0x06000E8F RID: 3727 RVA: 0x00037D4C File Offset: 0x00035F4C
			public bool TryGetSoftCast<T>(out T key) where T : Key
			{
				return this.TryGetSoftCast<T>(global::Facepunch.Abstract.KeyTypeInfo<Key, T>.Info, out key);
			}

			// Token: 0x06000E90 RID: 3728 RVA: 0x00037D5C File Offset: 0x00035F5C
			public bool TryGetHardCast<T>(out T key) where T : Key
			{
				return this.TryGetHardCast<T>(global::Facepunch.Abstract.KeyTypeInfo<Key, T>.Info, out key);
			}

			// Token: 0x06000E91 RID: 3729 RVA: 0x00037D6C File Offset: 0x00035F6C
			public bool TryGet(global::System.Type traitType, out Key key)
			{
				return this.TryGet(global::Facepunch.Abstract.KeyTypeInfo<Key>.Find(traitType), out key);
			}

			// Token: 0x06000E92 RID: 3730 RVA: 0x00037D7C File Offset: 0x00035F7C
			public bool TryGetSoftCast<T>(global::System.Type traitType, out T key) where T : Key
			{
				return this.TryGetSoftCast<T>(global::Facepunch.Abstract.KeyTypeInfo<Key>.Find(traitType), out key);
			}

			// Token: 0x06000E93 RID: 3731 RVA: 0x00037D8C File Offset: 0x00035F8C
			public bool TryGetHardCast<T>(global::System.Type traitType, out T key) where T : Key
			{
				return this.TryGetHardCast<T>(global::Facepunch.Abstract.KeyTypeInfo<Key>.Find(traitType), out key);
			}

			// Token: 0x06000E94 RID: 3732 RVA: 0x00037D9C File Offset: 0x00035F9C
			public Key TryGet<T>() where T : Key
			{
				Key result;
				this.TryGet<T>(out result);
				return result;
			}

			// Token: 0x06000E95 RID: 3733 RVA: 0x00037DB4 File Offset: 0x00035FB4
			public T TryGetSoftCast<T>() where T : Key
			{
				T result;
				this.TryGetSoftCast<T>(out result);
				return result;
			}

			// Token: 0x06000E96 RID: 3734 RVA: 0x00037DCC File Offset: 0x00035FCC
			public T TryGetHardCast<T>() where T : Key
			{
				T result;
				this.TryGetHardCast<T>(out result);
				return result;
			}

			// Token: 0x06000E97 RID: 3735 RVA: 0x00037DE4 File Offset: 0x00035FE4
			public Key TryGet(global::System.Type type)
			{
				Key result;
				this.TryGet(type, out result);
				return result;
			}

			// Token: 0x06000E98 RID: 3736 RVA: 0x00037DFC File Offset: 0x00035FFC
			public T TryGetSoftCast<T>(global::System.Type type) where T : Key
			{
				T result;
				this.TryGetSoftCast<T>(type, out result);
				return result;
			}

			// Token: 0x06000E99 RID: 3737 RVA: 0x00037E14 File Offset: 0x00036014
			public T TryGetHardCast<T>(global::System.Type type) where T : Key
			{
				T result;
				this.TryGetHardCast<T>(type, out result);
				return result;
			}

			// Token: 0x06000E9A RID: 3738 RVA: 0x00037E2C File Offset: 0x0003602C
			private Key Get(global::Facepunch.Abstract.KeyTypeInfo<Key> info)
			{
				return this.rootToKey[info];
			}

			// Token: 0x06000E9B RID: 3739 RVA: 0x00037E3C File Offset: 0x0003603C
			private T GetSoftCast<T>(global::Facepunch.Abstract.KeyTypeInfo<Key> info) where T : Key
			{
				return this.Get(info) as T;
			}

			// Token: 0x06000E9C RID: 3740 RVA: 0x00037E54 File Offset: 0x00036054
			private T GetHardCast<T>(global::Facepunch.Abstract.KeyTypeInfo<Key> info) where T : Key
			{
				return (T)((object)this.Get(info));
			}

			// Token: 0x06000E9D RID: 3741 RVA: 0x00037E68 File Offset: 0x00036068
			public Key Get<T>() where T : Key
			{
				return this.Get(global::Facepunch.Abstract.KeyTypeInfo<Key, T>.Info);
			}

			// Token: 0x06000E9E RID: 3742 RVA: 0x00037E78 File Offset: 0x00036078
			public T GetSoftCast<T>() where T : Key
			{
				return this.GetSoftCast<T>(global::Facepunch.Abstract.KeyTypeInfo<Key, T>.Info);
			}

			// Token: 0x06000E9F RID: 3743 RVA: 0x00037E88 File Offset: 0x00036088
			public T GetHardCast<T>() where T : Key
			{
				return this.GetHardCast<T>(global::Facepunch.Abstract.KeyTypeInfo<Key, T>.Info);
			}

			// Token: 0x06000EA0 RID: 3744 RVA: 0x00037E98 File Offset: 0x00036098
			public Key Get(global::System.Type type)
			{
				return this.Get(global::Facepunch.Abstract.KeyTypeInfo<Key>.Find(type));
			}

			// Token: 0x06000EA1 RID: 3745 RVA: 0x00037EA8 File Offset: 0x000360A8
			public T GetSoftCast<T>(global::System.Type type) where T : Key
			{
				return this.GetSoftCast<T>(global::Facepunch.Abstract.KeyTypeInfo<Key>.Find(type));
			}

			// Token: 0x06000EA2 RID: 3746 RVA: 0x00037EB8 File Offset: 0x000360B8
			public T GetHardCast<T>(global::System.Type type) where T : Key
			{
				return this.GetHardCast<T>(global::Facepunch.Abstract.KeyTypeInfo<Key>.Find(type));
			}

			// Token: 0x06000EA3 RID: 3747 RVA: 0x00037EC8 File Offset: 0x000360C8
			public void MergeUpon(global::Facepunch.Abstract.KeyTypeInfo<Key>.TraitDictionary fillGaps)
			{
				foreach (global::System.Collections.Generic.KeyValuePair<global::Facepunch.Abstract.KeyTypeInfo<Key>, Key> keyValuePair in this.rootToKey)
				{
					if (!fillGaps.rootToKey.ContainsKey(keyValuePair.Key.Root))
					{
						fillGaps.rootToKey.Add(keyValuePair.Key, keyValuePair.Value);
					}
				}
			}

			// Token: 0x04000951 RID: 2385
			[global::System.NonSerialized]
			private readonly global::System.Collections.Generic.Dictionary<global::Facepunch.Abstract.KeyTypeInfo<Key>, Key> rootToKey;
		}
	}
}
