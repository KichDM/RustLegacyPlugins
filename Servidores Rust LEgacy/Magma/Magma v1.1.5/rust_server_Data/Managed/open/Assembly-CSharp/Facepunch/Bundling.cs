using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using Facepunch.Load;
using UnityEngine;

namespace Facepunch
{
	// Token: 0x0200010D RID: 269
	public static class Bundling
	{
		// Token: 0x14000001 RID: 1
		// (add) Token: 0x060005D5 RID: 1493 RVA: 0x0001B4A8 File Offset: 0x000196A8
		// (remove) Token: 0x060005D6 RID: 1494 RVA: 0x0001B4E0 File Offset: 0x000196E0
		public static event global::Facepunch.Bundling.OnLoadedEventHandler OnceLoaded
		{
			add
			{
				if (global::Facepunch.Bundling.Loaded)
				{
					value();
				}
				else
				{
					global::Facepunch.Bundling.nextLoadEvents = (global::Facepunch.Bundling.OnLoadedEventHandler)global::System.Delegate.Combine(global::Facepunch.Bundling.nextLoadEvents, value);
				}
			}
			remove
			{
				global::Facepunch.Bundling.nextLoadEvents = (global::Facepunch.Bundling.OnLoadedEventHandler)global::System.Delegate.Remove(global::Facepunch.Bundling.nextLoadEvents, value);
			}
		}

		// Token: 0x060005D7 RID: 1495 RVA: 0x0001B4F8 File Offset: 0x000196F8
		public static bool Load(string path, global::System.Type type, out global::UnityEngine.Object asset)
		{
			if (!global::Facepunch.Bundling.HasLoadedBundleMap)
			{
				throw new global::System.InvalidOperationException("Bundles were not loaded");
			}
			if (path == null)
			{
				throw new global::System.ArgumentNullException("path");
			}
			if (path.Length == 0)
			{
				asset = null;
				return false;
			}
			return global::Facepunch.Bundling.Map.Assets.Load(path, type, out asset);
		}

		// Token: 0x060005D8 RID: 1496 RVA: 0x0001B550 File Offset: 0x00019750
		public static global::UnityEngine.Object Load(string path, global::System.Type type)
		{
			global::UnityEngine.Object result;
			global::Facepunch.Bundling.Load(path, type, out result);
			return result;
		}

		// Token: 0x060005D9 RID: 1497 RVA: 0x0001B568 File Offset: 0x00019768
		public static bool Load<T>(string path, out T asset) where T : global::UnityEngine.Object
		{
			global::UnityEngine.Object @object;
			if (global::Facepunch.Bundling.Load(path, typeof(T), out @object))
			{
				asset = (T)((object)@object);
				return true;
			}
			asset = (T)((object)null);
			return false;
		}

		// Token: 0x060005DA RID: 1498 RVA: 0x0001B5A8 File Offset: 0x000197A8
		public static T Load<T>(string path) where T : global::UnityEngine.Object
		{
			T result;
			global::Facepunch.Bundling.Load<T>(path, out result);
			return result;
		}

		// Token: 0x060005DB RID: 1499 RVA: 0x0001B5C0 File Offset: 0x000197C0
		public static bool Load<T>(string path, global::System.Type type, out T asset) where T : global::UnityEngine.Object
		{
			if (!typeof(T).IsAssignableFrom(type))
			{
				throw new global::System.ArgumentException(string.Format("The given type ({1}) cannot cast to {0}", typeof(T), type), "type");
			}
			global::UnityEngine.Object @object;
			if (global::Facepunch.Bundling.Load(path, type, out @object))
			{
				asset = (T)((object)@object);
				return true;
			}
			asset = (T)((object)null);
			return false;
		}

		// Token: 0x060005DC RID: 1500 RVA: 0x0001B62C File Offset: 0x0001982C
		public static T Load<T>(string path, global::System.Type type) where T : global::UnityEngine.Object
		{
			T result;
			global::Facepunch.Bundling.Load<T>(path, type, out result);
			return result;
		}

		// Token: 0x060005DD RID: 1501 RVA: 0x0001B644 File Offset: 0x00019844
		[global::System.Obsolete("This only works outside of editor for now, avoid it")]
		public static bool LoadAsync(string path, global::System.Type type, out global::UnityEngine.AssetBundleRequest request)
		{
			if (!global::Facepunch.Bundling.HasLoadedBundleMap)
			{
				throw new global::System.InvalidOperationException("Bundles were not loaded");
			}
			if (path == null)
			{
				throw new global::System.ArgumentNullException("path");
			}
			if (path.Length == 0)
			{
				request = null;
				return false;
			}
			return global::Facepunch.Bundling.Map.Assets.LoadAsync(path, type, out request);
		}

		// Token: 0x060005DE RID: 1502 RVA: 0x0001B69C File Offset: 0x0001989C
		[global::System.Obsolete("This only works outside of editor for now, avoid it")]
		public static global::UnityEngine.AssetBundleRequest LoadAsync(string path, global::System.Type type)
		{
			global::UnityEngine.AssetBundleRequest result;
			global::Facepunch.Bundling.LoadAsync(path, type, out result);
			return result;
		}

		// Token: 0x060005DF RID: 1503 RVA: 0x0001B6B4 File Offset: 0x000198B4
		[global::System.Obsolete("This only works outside of editor for now, avoid it")]
		public static bool LoadAsync<T>(string path, out global::UnityEngine.AssetBundleRequest request) where T : global::UnityEngine.Object
		{
			return global::Facepunch.Bundling.LoadAsync(path, typeof(T), out request);
		}

		// Token: 0x060005E0 RID: 1504 RVA: 0x0001B6C8 File Offset: 0x000198C8
		[global::System.Obsolete("This only works outside of editor for now, avoid it")]
		public static global::UnityEngine.AssetBundleRequest LoadAsync<T>(string path)
		{
			return global::Facepunch.Bundling.LoadAsync(path, typeof(T));
		}

		// Token: 0x060005E1 RID: 1505 RVA: 0x0001B6DC File Offset: 0x000198DC
		public static global::UnityEngine.Object[] LoadAll()
		{
			if (!global::Facepunch.Bundling.HasLoadedBundleMap)
			{
				throw new global::System.InvalidOperationException("Bundles were not loaded");
			}
			return new global::System.Collections.Generic.List<global::UnityEngine.Object>(global::Facepunch.Bundling.Map.Assets.LoadAll()).ToArray();
		}

		// Token: 0x060005E2 RID: 1506 RVA: 0x0001B718 File Offset: 0x00019918
		public static global::UnityEngine.Object[] LoadAll(global::System.Type type)
		{
			if (type == typeof(global::UnityEngine.Object))
			{
				return global::Facepunch.Bundling.LoadAll();
			}
			if (!global::Facepunch.Bundling.HasLoadedBundleMap)
			{
				throw new global::System.InvalidOperationException("Bundles were not loaded");
			}
			return new global::System.Collections.Generic.List<global::UnityEngine.Object>(global::Facepunch.Bundling.Map.Assets.LoadAll(type)).ToArray();
		}

		// Token: 0x060005E3 RID: 1507 RVA: 0x0001B76C File Offset: 0x0001996C
		public static T[] LoadAll<T>() where T : global::UnityEngine.Object
		{
			if (!global::Facepunch.Bundling.HasLoadedBundleMap)
			{
				throw new global::System.InvalidOperationException("Bundles were not loaded");
			}
			global::System.Collections.Generic.List<T> list = new global::System.Collections.Generic.List<T>();
			foreach (global::UnityEngine.Object @object in global::Facepunch.Bundling.Map.Assets.LoadAll(typeof(T)))
			{
				list.Add((T)((object)@object));
			}
			return list.ToArray();
		}

		// Token: 0x060005E4 RID: 1508 RVA: 0x0001B808 File Offset: 0x00019A08
		public static T[] LoadAll<T>(global::System.Type type) where T : global::UnityEngine.Object
		{
			if (!typeof(T).IsAssignableFrom(type))
			{
				throw new global::System.ArgumentException(string.Format("The given type ({1}) cannot cast to {0}", typeof(T), type), "type");
			}
			if (!global::Facepunch.Bundling.HasLoadedBundleMap)
			{
				throw new global::System.InvalidOperationException("Bundles were not loaded");
			}
			global::System.Collections.Generic.List<T> list = new global::System.Collections.Generic.List<T>();
			foreach (global::UnityEngine.Object @object in global::Facepunch.Bundling.Map.Assets.LoadAll(type))
			{
				list.Add((T)((object)@object));
			}
			return list.ToArray();
		}

		// Token: 0x060005E5 RID: 1509 RVA: 0x0001B8D0 File Offset: 0x00019AD0
		public static void BindToLoader(global::Facepunch.Load.Loader loader)
		{
			global::Facepunch.Bundling.BundleBridger @object = new global::Facepunch.Bundling.BundleBridger();
			loader.OnGroupedAssetBundlesLoaded += @object.AddArrays;
			loader.OnAllAssetBundlesLoaded += @object.FinalizeAndInstall;
		}

		// Token: 0x060005E6 RID: 1510 RVA: 0x0001B908 File Offset: 0x00019B08
		public static void Unload()
		{
			if (global::Facepunch.Bundling.HasLoadedBundleMap)
			{
				global::Facepunch.Bundling.Map.Dispose();
			}
		}

		// Token: 0x170000F1 RID: 241
		// (get) Token: 0x060005E7 RID: 1511 RVA: 0x0001B920 File Offset: 0x00019B20
		public static bool Loaded
		{
			get
			{
				return global::Facepunch.Bundling.HasLoadedBundleMap;
			}
		}

		// Token: 0x04000531 RID: 1329
		private const bool kBundleUnloadClearsEverything = true;

		// Token: 0x04000532 RID: 1330
		private const string kUnloadedBundlesMessage = "Bundles were not loaded";

		// Token: 0x04000533 RID: 1331
		private static global::Facepunch.Bundling.LoadedBundleMap Map;

		// Token: 0x04000534 RID: 1332
		private static bool HasLoadedBundleMap;

		// Token: 0x04000535 RID: 1333
		private static global::Facepunch.Bundling.OnLoadedEventHandler nextLoadEvents;

		// Token: 0x0200010E RID: 270
		private class BundleBridger
		{
			// Token: 0x060005E8 RID: 1512 RVA: 0x0001B928 File Offset: 0x00019B28
			public BundleBridger()
			{
			}

			// Token: 0x060005E9 RID: 1513 RVA: 0x0001B948 File Offset: 0x00019B48
			private global::System.Collections.Generic.List<global::Facepunch.Bundling.LoadedBundle> AssetListOfType(global::System.Type type)
			{
				if (type != this.lastAssetMapSearchKey)
				{
					global::System.Collections.Generic.Dictionary<global::System.Type, global::System.Collections.Generic.List<global::Facepunch.Bundling.LoadedBundle>> dictionary = this.assetsMap;
					this.lastAssetMapSearchKey = type;
					if (!dictionary.TryGetValue(type, out this.lastAssetMapSearchValue))
					{
						this.assetsMap[this.lastAssetMapSearchKey] = (this.lastAssetMapSearchValue = new global::System.Collections.Generic.List<global::Facepunch.Bundling.LoadedBundle>());
					}
				}
				return this.lastAssetMapSearchValue;
			}

			// Token: 0x060005EA RID: 1514 RVA: 0x0001B9A8 File Offset: 0x00019BA8
			private bool Remove(global::System.Type type)
			{
				if (this.assetsMap.Remove(type))
				{
					if (type == this.lastAssetMapSearchKey)
					{
						this.lastAssetMapSearchValue = null;
						this.lastAssetMapSearchKey = null;
					}
					return true;
				}
				return false;
			}

			// Token: 0x060005EB RID: 1515 RVA: 0x0001B9E4 File Offset: 0x00019BE4
			public void Add(global::UnityEngine.AssetBundle bundle, global::Facepunch.Load.Item item)
			{
				if (item.ContentType == global::Facepunch.Load.ContentType.Assets)
				{
					this.AssetListOfType(item.TypeOfAssets).Add(new global::Facepunch.Bundling.LoadedBundle(bundle, item));
				}
				else
				{
					this.scenes.Add(new global::Facepunch.Bundling.LoadedBundle(bundle, item));
				}
			}

			// Token: 0x060005EC RID: 1516 RVA: 0x0001BA30 File Offset: 0x00019C30
			public void AddArrays(global::UnityEngine.AssetBundle[] bundles, global::Facepunch.Load.Item[] items)
			{
				for (int i = 0; i < bundles.Length; i++)
				{
					this.Add(bundles[i], items[i]);
				}
			}

			// Token: 0x060005ED RID: 1517 RVA: 0x0001BA68 File Offset: 0x00019C68
			public void FinalizeAndInstall(global::UnityEngine.AssetBundle[] bundles, global::Facepunch.Load.Item[] items)
			{
				global::Facepunch.Bundling.LoadedBundleMap loadedBundleMap = new global::Facepunch.Bundling.LoadedBundleMap(this.assetsMap, this.scenes);
				if (loadedBundleMap == global::Facepunch.Bundling.Map && global::Facepunch.Bundling.nextLoadEvents != null)
				{
					global::Facepunch.Bundling.OnLoadedEventHandler nextLoadEvents = global::Facepunch.Bundling.nextLoadEvents;
					global::Facepunch.Bundling.nextLoadEvents = null;
					try
					{
						nextLoadEvents();
					}
					catch (global::System.Exception ex)
					{
						global::UnityEngine.Debug.LogException(ex);
					}
				}
			}

			// Token: 0x04000536 RID: 1334
			private readonly global::System.Collections.Generic.List<global::Facepunch.Bundling.LoadedBundle> scenes = new global::System.Collections.Generic.List<global::Facepunch.Bundling.LoadedBundle>();

			// Token: 0x04000537 RID: 1335
			private readonly global::System.Collections.Generic.Dictionary<global::System.Type, global::System.Collections.Generic.List<global::Facepunch.Bundling.LoadedBundle>> assetsMap = new global::System.Collections.Generic.Dictionary<global::System.Type, global::System.Collections.Generic.List<global::Facepunch.Bundling.LoadedBundle>>();

			// Token: 0x04000538 RID: 1336
			private global::System.Type lastAssetMapSearchKey;

			// Token: 0x04000539 RID: 1337
			private global::System.Collections.Generic.List<global::Facepunch.Bundling.LoadedBundle> lastAssetMapSearchValue;
		}

		// Token: 0x0200010F RID: 271
		private class LoadedBundle
		{
			// Token: 0x060005EE RID: 1518 RVA: 0x0001BADC File Offset: 0x00019CDC
			public LoadedBundle(global::UnityEngine.AssetBundle bundle, global::Facepunch.Load.Item item)
			{
				this.Bundle = bundle;
				this.Item = item;
			}

			// Token: 0x060005EF RID: 1519 RVA: 0x0001BAF4 File Offset: 0x00019CF4
			internal void Unload()
			{
				if (this.Bundle)
				{
					this.Bundle.Unload(true);
				}
				this.Bundle = null;
			}

			// Token: 0x060005F0 RID: 1520 RVA: 0x0001BB1C File Offset: 0x00019D1C
			public global::UnityEngine.Object Load(string path)
			{
				return this.Bundle.Load(path);
			}

			// Token: 0x060005F1 RID: 1521 RVA: 0x0001BB2C File Offset: 0x00019D2C
			public global::UnityEngine.Object Load(string path, global::System.Type type)
			{
				return this.Bundle.Load(path, type);
			}

			// Token: 0x060005F2 RID: 1522 RVA: 0x0001BB3C File Offset: 0x00019D3C
			public global::UnityEngine.AssetBundleRequest LoadAsync(string path, global::System.Type type)
			{
				return this.Bundle.LoadAsync(path, type);
			}

			// Token: 0x060005F3 RID: 1523 RVA: 0x0001BB4C File Offset: 0x00019D4C
			public global::UnityEngine.Object[] LoadAll()
			{
				return this.Bundle.LoadAll();
			}

			// Token: 0x060005F4 RID: 1524 RVA: 0x0001BB5C File Offset: 0x00019D5C
			public global::UnityEngine.Object[] LoadAll(global::System.Type type)
			{
				return this.Bundle.LoadAll(type);
			}

			// Token: 0x060005F5 RID: 1525 RVA: 0x0001BB6C File Offset: 0x00019D6C
			public bool Contains(string path)
			{
				return this.Bundle.Contains(path);
			}

			// Token: 0x0400053A RID: 1338
			public readonly global::Facepunch.Load.Item Item;

			// Token: 0x0400053B RID: 1339
			private global::UnityEngine.AssetBundle Bundle;
		}

		// Token: 0x02000110 RID: 272
		private class LoadedBundleAssetMap
		{
			// Token: 0x060005F6 RID: 1526 RVA: 0x0001BB7C File Offset: 0x00019D7C
			internal LoadedBundleAssetMap(global::System.Collections.Generic.IEnumerable<global::System.Collections.Generic.KeyValuePair<global::System.Type, global::System.Collections.Generic.List<global::Facepunch.Bundling.LoadedBundle>>> assets)
			{
				global::System.Collections.Generic.List<global::System.Collections.Generic.KeyValuePair<global::System.Type, global::System.Collections.Generic.List<global::Facepunch.Bundling.LoadedBundle>>> list = new global::System.Collections.Generic.List<global::System.Collections.Generic.KeyValuePair<global::System.Type, global::System.Collections.Generic.List<global::Facepunch.Bundling.LoadedBundle>>>(assets);
				list.Sort(delegate(global::System.Collections.Generic.KeyValuePair<global::System.Type, global::System.Collections.Generic.List<global::Facepunch.Bundling.LoadedBundle>> x, global::System.Collections.Generic.KeyValuePair<global::System.Type, global::System.Collections.Generic.List<global::Facepunch.Bundling.LoadedBundle>> y)
				{
					int num = (!typeof(global::UnityEngine.GameObject).IsAssignableFrom(x.Key)) ? ((!typeof(global::UnityEngine.ScriptableObject).IsAssignableFrom(x.Key)) ? 2 : 1) : 0;
					int value = (!typeof(global::UnityEngine.GameObject).IsAssignableFrom(y.Key)) ? ((!typeof(global::UnityEngine.ScriptableObject).IsAssignableFrom(y.Key)) ? 2 : 1) : 0;
					return num.CompareTo(value);
				});
				this.AllLoadedBundleAssetLists = new global::Facepunch.Bundling.LoadedBundleListOfAssets[list.Count];
				for (int i = 0; i < this.AllLoadedBundleAssetLists.Length; i++)
				{
					global::System.Collections.Generic.KeyValuePair<global::System.Type, global::System.Collections.Generic.List<global::Facepunch.Bundling.LoadedBundle>> keyValuePair = list[i];
					this.AllLoadedBundleAssetLists[i] = new global::Facepunch.Bundling.LoadedBundleListOfAssets(keyValuePair.Key, keyValuePair.Value);
				}
				this.tempBuffer = new short[this.AllLoadedBundleAssetLists.Length];
			}

			// Token: 0x060005F7 RID: 1527 RVA: 0x0001BC24 File Offset: 0x00019E24
			internal void Unload()
			{
				foreach (global::Facepunch.Bundling.LoadedBundleListOfAssets loadedBundleListOfAssets in this.AllLoadedBundleAssetLists)
				{
					loadedBundleListOfAssets.Unload();
				}
			}

			// Token: 0x060005F8 RID: 1528 RVA: 0x0001BC58 File Offset: 0x00019E58
			private bool TypeIndices(global::System.Type key, out short[] value)
			{
				if (key == null)
				{
					throw new global::System.ArgumentNullException("type");
				}
				if (this.typeMap.TryGetValue(key, out value))
				{
					return value != null;
				}
				if (!typeof(global::UnityEngine.Object).IsAssignableFrom(key))
				{
					throw new global::System.ArgumentOutOfRangeException("type", string.Format("type {0} is not assignable to UnityEngine.Object", key));
				}
				if (typeof(global::UnityEngine.Component).IsAssignableFrom(key))
				{
					if (typeof(global::UnityEngine.Component) == key)
					{
						bool result = this.TypeIndices(typeof(global::UnityEngine.GameObject), out value);
						value = (short[])value.Clone();
						for (int i = 0; i < value.Length; i++)
						{
							if (value[i] >= 0)
							{
								value[i] = -(value[i] + 1);
							}
						}
						this.typeMap[key] = value;
						return result;
					}
					bool result2 = this.TypeIndices(typeof(global::UnityEngine.Component), out value);
					this.typeMap[key] = value;
					return result2;
				}
				else
				{
					int num = 0;
					for (int j = 0; j < this.AllLoadedBundleAssetLists.Length; j++)
					{
						if (key.IsAssignableFrom(this.AllLoadedBundleAssetLists[j].TypeOfAssets))
						{
							this.tempBuffer[num++] = (short)j;
						}
					}
					int num2 = 0;
					int num3 = num;
					for (int k = 0; k < this.AllLoadedBundleAssetLists.Length; k++)
					{
						if (num2 < num3 && k == (int)this.tempBuffer[num2])
						{
							num2++;
						}
						else if (this.AllLoadedBundleAssetLists[k].TypeOfAssets.IsAssignableFrom(key))
						{
							this.tempBuffer[num++] = (short)(-(short)(k + 1));
						}
					}
					if (num == 0)
					{
						global::System.Collections.Generic.Dictionary<global::System.Type, short[]> dictionary = this.typeMap;
						short[] value2;
						value = (value2 = null);
						dictionary[key] = value2;
						return false;
					}
					value = new short[num];
					while (--num >= 0)
					{
						value[num] = this.tempBuffer[num];
					}
					this.typeMap[key] = value;
					return true;
				}
			}

			// Token: 0x060005F9 RID: 1529 RVA: 0x0001BE68 File Offset: 0x0001A068
			public bool Load(string path, global::System.Type type, out global::UnityEngine.Object asset)
			{
				short[] array;
				if (!this.TypeIndices(type, out array))
				{
					global::UnityEngine.Debug.Log("no type index for " + type);
					asset = null;
					return false;
				}
				int i = 0;
				while (array[i] >= 0)
				{
					if (this.AllLoadedBundleAssetLists[(int)array[i]].Load(path, out asset))
					{
						return true;
					}
					if (++i >= array.Length)
					{
						asset = null;
						return false;
					}
				}
				while (i < array.Length)
				{
					global::Facepunch.Bundling.LoadedBundleListOfAssets loadedBundleListOfAssets = this.AllLoadedBundleAssetLists[(int)(-(int)(array[i] + 1))];
					if (loadedBundleListOfAssets.Load(path, type, out asset))
					{
						return true;
					}
					i++;
				}
				asset = null;
				return false;
			}

			// Token: 0x060005FA RID: 1530 RVA: 0x0001BF08 File Offset: 0x0001A108
			public bool LoadAsync(string path, global::System.Type type, out global::UnityEngine.AssetBundleRequest request)
			{
				short[] array;
				if (!this.TypeIndices(type, out array))
				{
					request = null;
					return false;
				}
				int i = 0;
				while (array[i] >= 0)
				{
					if (this.AllLoadedBundleAssetLists[(int)array[i]].LoadAsync(path, out request))
					{
						return true;
					}
					if (++i >= array.Length)
					{
						request = null;
						return false;
					}
				}
				while (i < array.Length)
				{
					global::Facepunch.Bundling.LoadedBundleListOfAssets loadedBundleListOfAssets = this.AllLoadedBundleAssetLists[(int)(-(int)(array[i] + 1))];
					if (loadedBundleListOfAssets.LoadAsync(path, type, out request))
					{
						return true;
					}
					i++;
				}
				request = null;
				return false;
			}

			// Token: 0x060005FB RID: 1531 RVA: 0x0001BF98 File Offset: 0x0001A198
			public global::System.Collections.Generic.IEnumerable<global::UnityEngine.Object> LoadAll()
			{
				foreach (global::Facepunch.Bundling.LoadedBundleListOfAssets listOfBundles in this.AllLoadedBundleAssetLists)
				{
					foreach (global::Facepunch.Bundling.LoadedBundle bundle in listOfBundles.Bundles)
					{
						foreach (global::UnityEngine.Object asset in bundle.LoadAll())
						{
							yield return asset;
						}
					}
				}
				yield break;
			}

			// Token: 0x060005FC RID: 1532 RVA: 0x0001BFBC File Offset: 0x0001A1BC
			public global::System.Collections.Generic.IEnumerable<global::UnityEngine.Object> LoadAll(global::System.Type type)
			{
				short[] indices;
				if (!this.TypeIndices(type, out indices))
				{
					yield break;
				}
				int i = 0;
				while (indices[i] >= 0)
				{
					foreach (global::Facepunch.Bundling.LoadedBundle bundle in this.AllLoadedBundleAssetLists[(int)indices[i]].Bundles)
					{
						foreach (global::UnityEngine.Object asset in bundle.LoadAll())
						{
							yield return asset;
						}
					}
					if (++i >= indices.Length)
					{
						yield break;
					}
				}
				while (i < indices.Length)
				{
					global::Facepunch.Bundling.LoadedBundleListOfAssets test = this.AllLoadedBundleAssetLists[(int)(-(int)(indices[i] + 1))];
					foreach (global::Facepunch.Bundling.LoadedBundle bundle2 in test.Bundles)
					{
						foreach (global::UnityEngine.Object asset2 in bundle2.LoadAll(type))
						{
							yield return asset2;
						}
					}
					if (++i >= indices.Length)
					{
						break;
					}
				}
				yield break;
			}

			// Token: 0x060005FD RID: 1533 RVA: 0x0001BFF0 File Offset: 0x0001A1F0
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			private static int <LoadedBundleAssetMap>m__2(global::System.Collections.Generic.KeyValuePair<global::System.Type, global::System.Collections.Generic.List<global::Facepunch.Bundling.LoadedBundle>> x, global::System.Collections.Generic.KeyValuePair<global::System.Type, global::System.Collections.Generic.List<global::Facepunch.Bundling.LoadedBundle>> y)
			{
				int num = (!typeof(global::UnityEngine.GameObject).IsAssignableFrom(x.Key)) ? ((!typeof(global::UnityEngine.ScriptableObject).IsAssignableFrom(x.Key)) ? 2 : 1) : 0;
				int value = (!typeof(global::UnityEngine.GameObject).IsAssignableFrom(y.Key)) ? ((!typeof(global::UnityEngine.ScriptableObject).IsAssignableFrom(y.Key)) ? 2 : 1) : 0;
				return num.CompareTo(value);
			}

			// Token: 0x0400053C RID: 1340
			public readonly global::Facepunch.Bundling.LoadedBundleListOfAssets[] AllLoadedBundleAssetLists;

			// Token: 0x0400053D RID: 1341
			private readonly global::System.Collections.Generic.Dictionary<global::System.Type, short[]> typeMap = new global::System.Collections.Generic.Dictionary<global::System.Type, short[]>();

			// Token: 0x0400053E RID: 1342
			private readonly short[] tempBuffer;

			// Token: 0x0400053F RID: 1343
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			private static global::System.Comparison<global::System.Collections.Generic.KeyValuePair<global::System.Type, global::System.Collections.Generic.List<global::Facepunch.Bundling.LoadedBundle>>> <>f__am$cache3;

			// Token: 0x02000111 RID: 273
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			private sealed class <LoadAll>c__Iterator1B : global::System.IDisposable, global::System.Collections.IEnumerator, global::System.Collections.IEnumerable, global::System.Collections.Generic.IEnumerable<global::UnityEngine.Object>, global::System.Collections.Generic.IEnumerator<global::UnityEngine.Object>
			{
				// Token: 0x060005FE RID: 1534 RVA: 0x0001C090 File Offset: 0x0001A290
				public <LoadAll>c__Iterator1B()
				{
				}

				// Token: 0x170000F2 RID: 242
				// (get) Token: 0x060005FF RID: 1535 RVA: 0x0001C098 File Offset: 0x0001A298
				global::UnityEngine.Object global::System.Collections.Generic.IEnumerator<global::UnityEngine.Object>.Current
				{
					[global::System.Diagnostics.DebuggerHidden]
					get
					{
						return this.$current;
					}
				}

				// Token: 0x170000F3 RID: 243
				// (get) Token: 0x06000600 RID: 1536 RVA: 0x0001C0A0 File Offset: 0x0001A2A0
				object global::System.Collections.IEnumerator.Current
				{
					[global::System.Diagnostics.DebuggerHidden]
					get
					{
						return this.$current;
					}
				}

				// Token: 0x06000601 RID: 1537 RVA: 0x0001C0A8 File Offset: 0x0001A2A8
				[global::System.Diagnostics.DebuggerHidden]
				global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
				{
					return this.System.Collections.Generic.IEnumerable<UnityEngine.Object>.GetEnumerator();
				}

				// Token: 0x06000602 RID: 1538 RVA: 0x0001C0B0 File Offset: 0x0001A2B0
				[global::System.Diagnostics.DebuggerHidden]
				global::System.Collections.Generic.IEnumerator<global::UnityEngine.Object> global::System.Collections.Generic.IEnumerable<global::UnityEngine.Object>.GetEnumerator()
				{
					if (global::System.Threading.Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
					{
						return this;
					}
					global::Facepunch.Bundling.LoadedBundleAssetMap.<LoadAll>c__Iterator1B <LoadAll>c__Iterator1B = new global::Facepunch.Bundling.LoadedBundleAssetMap.<LoadAll>c__Iterator1B();
					<LoadAll>c__Iterator1B.<>f__this = this;
					return <LoadAll>c__Iterator1B;
				}

				// Token: 0x06000603 RID: 1539 RVA: 0x0001C0E4 File Offset: 0x0001A2E4
				public bool MoveNext()
				{
					uint num = (uint)this.$PC;
					this.$PC = -1;
					switch (num)
					{
					case 0U:
						allLoadedBundleAssetLists = this.AllLoadedBundleAssetLists;
						i = 0;
						goto IL_119;
					case 1U:
						k++;
						break;
					default:
						return false;
					}
					IL_D7:
					if (k < array.Length)
					{
						asset = array[k];
						this.$current = asset;
						this.$PC = 1;
						return true;
					}
					j++;
					IL_F8:
					if (j < bundles.Length)
					{
						bundle = bundles[j];
						array = bundle.LoadAll();
						k = 0;
						goto IL_D7;
					}
					i++;
					IL_119:
					if (i < allLoadedBundleAssetLists.Length)
					{
						listOfBundles = allLoadedBundleAssetLists[i];
						bundles = listOfBundles.Bundles;
						j = 0;
						goto IL_F8;
					}
					this.$PC = -1;
					return false;
				}

				// Token: 0x06000604 RID: 1540 RVA: 0x0001C22C File Offset: 0x0001A42C
				[global::System.Diagnostics.DebuggerHidden]
				public void Dispose()
				{
					this.$PC = -1;
				}

				// Token: 0x06000605 RID: 1541 RVA: 0x0001C238 File Offset: 0x0001A438
				[global::System.Diagnostics.DebuggerHidden]
				public void Reset()
				{
					throw new global::System.NotSupportedException();
				}

				// Token: 0x04000540 RID: 1344
				internal global::Facepunch.Bundling.LoadedBundleListOfAssets[] <$s_166>__0;

				// Token: 0x04000541 RID: 1345
				internal int <$s_167>__1;

				// Token: 0x04000542 RID: 1346
				internal global::Facepunch.Bundling.LoadedBundleListOfAssets <listOfBundles>__2;

				// Token: 0x04000543 RID: 1347
				internal global::Facepunch.Bundling.LoadedBundle[] <$s_168>__3;

				// Token: 0x04000544 RID: 1348
				internal int <$s_169>__4;

				// Token: 0x04000545 RID: 1349
				internal global::Facepunch.Bundling.LoadedBundle <bundle>__5;

				// Token: 0x04000546 RID: 1350
				internal global::UnityEngine.Object[] <$s_170>__6;

				// Token: 0x04000547 RID: 1351
				internal int <$s_171>__7;

				// Token: 0x04000548 RID: 1352
				internal global::UnityEngine.Object <asset>__8;

				// Token: 0x04000549 RID: 1353
				internal int $PC;

				// Token: 0x0400054A RID: 1354
				internal global::UnityEngine.Object $current;

				// Token: 0x0400054B RID: 1355
				internal global::Facepunch.Bundling.LoadedBundleAssetMap <>f__this;
			}

			// Token: 0x02000112 RID: 274
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			private sealed class <LoadAll>c__Iterator1C : global::System.IDisposable, global::System.Collections.IEnumerator, global::System.Collections.IEnumerable, global::System.Collections.Generic.IEnumerable<global::UnityEngine.Object>, global::System.Collections.Generic.IEnumerator<global::UnityEngine.Object>
			{
				// Token: 0x06000606 RID: 1542 RVA: 0x0001C240 File Offset: 0x0001A440
				public <LoadAll>c__Iterator1C()
				{
				}

				// Token: 0x170000F4 RID: 244
				// (get) Token: 0x06000607 RID: 1543 RVA: 0x0001C248 File Offset: 0x0001A448
				global::UnityEngine.Object global::System.Collections.Generic.IEnumerator<global::UnityEngine.Object>.Current
				{
					[global::System.Diagnostics.DebuggerHidden]
					get
					{
						return this.$current;
					}
				}

				// Token: 0x170000F5 RID: 245
				// (get) Token: 0x06000608 RID: 1544 RVA: 0x0001C250 File Offset: 0x0001A450
				object global::System.Collections.IEnumerator.Current
				{
					[global::System.Diagnostics.DebuggerHidden]
					get
					{
						return this.$current;
					}
				}

				// Token: 0x06000609 RID: 1545 RVA: 0x0001C258 File Offset: 0x0001A458
				[global::System.Diagnostics.DebuggerHidden]
				global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
				{
					return this.System.Collections.Generic.IEnumerable<UnityEngine.Object>.GetEnumerator();
				}

				// Token: 0x0600060A RID: 1546 RVA: 0x0001C260 File Offset: 0x0001A460
				[global::System.Diagnostics.DebuggerHidden]
				global::System.Collections.Generic.IEnumerator<global::UnityEngine.Object> global::System.Collections.Generic.IEnumerable<global::UnityEngine.Object>.GetEnumerator()
				{
					if (global::System.Threading.Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
					{
						return this;
					}
					global::Facepunch.Bundling.LoadedBundleAssetMap.<LoadAll>c__Iterator1C <LoadAll>c__Iterator1C = new global::Facepunch.Bundling.LoadedBundleAssetMap.<LoadAll>c__Iterator1C();
					<LoadAll>c__Iterator1C.<>f__this = this;
					<LoadAll>c__Iterator1C.type = type;
					return <LoadAll>c__Iterator1C;
				}

				// Token: 0x0600060B RID: 1547 RVA: 0x0001C2A0 File Offset: 0x0001A4A0
				public bool MoveNext()
				{
					uint num = (uint)this.$PC;
					this.$PC = -1;
					switch (num)
					{
					case 0U:
						if (!base.TypeIndices(type, out indices))
						{
							return false;
						}
						i = 0;
						goto IL_142;
					case 1U:
						k++;
						break;
					case 2U:
						m++;
						goto IL_208;
					default:
						return false;
					}
					IL_EB:
					if (k < array.Length)
					{
						asset = array[k];
						this.$current = asset;
						this.$PC = 1;
						return true;
					}
					j++;
					IL_10C:
					if (j < bundles.Length)
					{
						bundle = bundles[j];
						array = bundle.LoadAll();
						k = 0;
						goto IL_EB;
					}
					if (++i >= indices.Length)
					{
						return false;
					}
					IL_142:
					if (indices[i] < 0)
					{
						goto IL_25F;
					}
					bundles = this.AllLoadedBundleAssetLists[(int)indices[i]].Bundles;
					j = 0;
					goto IL_10C;
					IL_208:
					if (m < array2.Length)
					{
						asset2 = array2[m];
						this.$current = asset2;
						this.$PC = 2;
						return true;
					}
					l++;
					IL_229:
					if (l < bundles2.Length)
					{
						bundle2 = bundles2[l];
						array2 = bundle2.LoadAll(type);
						m = 0;
						goto IL_208;
					}
					if (++i >= indices.Length)
					{
						goto IL_272;
					}
					IL_25F:
					if (i < indices.Length)
					{
						test = this.AllLoadedBundleAssetLists[(int)(-(int)(indices[i] + 1))];
						bundles2 = test.Bundles;
						l = 0;
						goto IL_229;
					}
					IL_272:
					this.$PC = -1;
					return false;
				}

				// Token: 0x0600060C RID: 1548 RVA: 0x0001C52C File Offset: 0x0001A72C
				[global::System.Diagnostics.DebuggerHidden]
				public void Dispose()
				{
					this.$PC = -1;
				}

				// Token: 0x0600060D RID: 1549 RVA: 0x0001C538 File Offset: 0x0001A738
				[global::System.Diagnostics.DebuggerHidden]
				public void Reset()
				{
					throw new global::System.NotSupportedException();
				}

				// Token: 0x0400054C RID: 1356
				internal global::System.Type type;

				// Token: 0x0400054D RID: 1357
				internal short[] <indices>__0;

				// Token: 0x0400054E RID: 1358
				internal int <i>__1;

				// Token: 0x0400054F RID: 1359
				internal global::Facepunch.Bundling.LoadedBundle[] <$s_172>__2;

				// Token: 0x04000550 RID: 1360
				internal int <$s_173>__3;

				// Token: 0x04000551 RID: 1361
				internal global::Facepunch.Bundling.LoadedBundle <bundle>__4;

				// Token: 0x04000552 RID: 1362
				internal global::UnityEngine.Object[] <$s_174>__5;

				// Token: 0x04000553 RID: 1363
				internal int <$s_175>__6;

				// Token: 0x04000554 RID: 1364
				internal global::UnityEngine.Object <asset>__7;

				// Token: 0x04000555 RID: 1365
				internal global::Facepunch.Bundling.LoadedBundleListOfAssets <test>__8;

				// Token: 0x04000556 RID: 1366
				internal global::Facepunch.Bundling.LoadedBundle[] <$s_176>__9;

				// Token: 0x04000557 RID: 1367
				internal int <$s_177>__10;

				// Token: 0x04000558 RID: 1368
				internal global::Facepunch.Bundling.LoadedBundle <bundle>__11;

				// Token: 0x04000559 RID: 1369
				internal global::UnityEngine.Object[] <$s_178>__12;

				// Token: 0x0400055A RID: 1370
				internal int <$s_179>__13;

				// Token: 0x0400055B RID: 1371
				internal global::UnityEngine.Object <asset>__14;

				// Token: 0x0400055C RID: 1372
				internal int $PC;

				// Token: 0x0400055D RID: 1373
				internal global::UnityEngine.Object $current;

				// Token: 0x0400055E RID: 1374
				internal global::System.Type <$>type;

				// Token: 0x0400055F RID: 1375
				internal global::Facepunch.Bundling.LoadedBundleAssetMap <>f__this;
			}
		}

		// Token: 0x02000113 RID: 275
		private class LoadedBundleListOfAssets
		{
			// Token: 0x0600060E RID: 1550 RVA: 0x0001C540 File Offset: 0x0001A740
			public LoadedBundleListOfAssets(global::System.Type typeOfAssets, global::System.Collections.Generic.List<global::Facepunch.Bundling.LoadedBundle> bundles)
			{
				this.TypeOfAssets = typeOfAssets;
				this.Bundles = bundles.ToArray();
				this.pathsToFoundBundles = new global::System.Collections.Generic.Dictionary<string, short>(global::System.StringComparer.InvariantCultureIgnoreCase);
			}

			// Token: 0x0600060F RID: 1551 RVA: 0x0001C56C File Offset: 0x0001A76C
			private bool PathIndex(string path, out short index)
			{
				if (!this.pathsToFoundBundles.TryGetValue(path, out index))
				{
					for (int i = 0; i < this.Bundles.Length; i++)
					{
						if (this.Bundles[i].Contains(path))
						{
							this.pathsToFoundBundles[path] = (index = (short)i);
							return true;
						}
					}
					this.pathsToFoundBundles[path] = -1;
					return false;
				}
				return index != -1;
			}

			// Token: 0x06000610 RID: 1552 RVA: 0x0001C5E8 File Offset: 0x0001A7E8
			public bool Load(string path, global::System.Type type, out global::UnityEngine.Object asset)
			{
				short num;
				if (this.PathIndex(path, out num))
				{
					global::UnityEngine.Object @object;
					asset = (@object = this.Bundles[(int)num].Load(path, type));
					return @object;
				}
				asset = null;
				return false;
			}

			// Token: 0x06000611 RID: 1553 RVA: 0x0001C624 File Offset: 0x0001A824
			public bool Load(string path, out global::UnityEngine.Object asset)
			{
				short num;
				if (this.PathIndex(path, out num))
				{
					global::UnityEngine.Object @object;
					asset = (@object = this.Bundles[(int)num].Load(path));
					return @object;
				}
				asset = null;
				return false;
			}

			// Token: 0x06000612 RID: 1554 RVA: 0x0001C65C File Offset: 0x0001A85C
			public bool LoadAsync(string path, global::System.Type type, out global::UnityEngine.AssetBundleRequest request)
			{
				short num;
				if (this.PathIndex(path, out num))
				{
					global::UnityEngine.AssetBundleRequest assetBundleRequest;
					request = (assetBundleRequest = this.Bundles[(int)num].LoadAsync(path, type));
					return assetBundleRequest != null;
				}
				request = null;
				return false;
			}

			// Token: 0x06000613 RID: 1555 RVA: 0x0001C698 File Offset: 0x0001A898
			public bool LoadAsync(string path, out global::UnityEngine.AssetBundleRequest request)
			{
				return this.LoadAsync(path, this.TypeOfAssets, out request);
			}

			// Token: 0x06000614 RID: 1556 RVA: 0x0001C6A8 File Offset: 0x0001A8A8
			public global::System.Collections.Generic.IEnumerable<global::UnityEngine.Object> LoadAll()
			{
				foreach (global::Facepunch.Bundling.LoadedBundle bundle in this.Bundles)
				{
					foreach (global::UnityEngine.Object asset in bundle.LoadAll())
					{
						yield return asset;
					}
				}
				yield break;
			}

			// Token: 0x06000615 RID: 1557 RVA: 0x0001C6CC File Offset: 0x0001A8CC
			public global::System.Collections.Generic.IEnumerable<global::UnityEngine.Object> LoadAll(global::System.Type type)
			{
				foreach (global::Facepunch.Bundling.LoadedBundle bundle in this.Bundles)
				{
					foreach (global::UnityEngine.Object asset in bundle.LoadAll(type))
					{
						yield return asset;
					}
				}
				yield break;
			}

			// Token: 0x06000616 RID: 1558 RVA: 0x0001C700 File Offset: 0x0001A900
			internal void Unload()
			{
				foreach (global::Facepunch.Bundling.LoadedBundle loadedBundle in this.Bundles)
				{
					loadedBundle.Unload();
				}
			}

			// Token: 0x04000560 RID: 1376
			public readonly global::System.Type TypeOfAssets;

			// Token: 0x04000561 RID: 1377
			public readonly global::Facepunch.Bundling.LoadedBundle[] Bundles;

			// Token: 0x04000562 RID: 1378
			private readonly global::System.Collections.Generic.Dictionary<string, short> pathsToFoundBundles;

			// Token: 0x02000114 RID: 276
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			private sealed class <LoadAll>c__Iterator1D : global::System.IDisposable, global::System.Collections.IEnumerator, global::System.Collections.IEnumerable, global::System.Collections.Generic.IEnumerable<global::UnityEngine.Object>, global::System.Collections.Generic.IEnumerator<global::UnityEngine.Object>
			{
				// Token: 0x06000617 RID: 1559 RVA: 0x0001C734 File Offset: 0x0001A934
				public <LoadAll>c__Iterator1D()
				{
				}

				// Token: 0x170000F6 RID: 246
				// (get) Token: 0x06000618 RID: 1560 RVA: 0x0001C73C File Offset: 0x0001A93C
				global::UnityEngine.Object global::System.Collections.Generic.IEnumerator<global::UnityEngine.Object>.Current
				{
					[global::System.Diagnostics.DebuggerHidden]
					get
					{
						return this.$current;
					}
				}

				// Token: 0x170000F7 RID: 247
				// (get) Token: 0x06000619 RID: 1561 RVA: 0x0001C744 File Offset: 0x0001A944
				object global::System.Collections.IEnumerator.Current
				{
					[global::System.Diagnostics.DebuggerHidden]
					get
					{
						return this.$current;
					}
				}

				// Token: 0x0600061A RID: 1562 RVA: 0x0001C74C File Offset: 0x0001A94C
				[global::System.Diagnostics.DebuggerHidden]
				global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
				{
					return this.System.Collections.Generic.IEnumerable<UnityEngine.Object>.GetEnumerator();
				}

				// Token: 0x0600061B RID: 1563 RVA: 0x0001C754 File Offset: 0x0001A954
				[global::System.Diagnostics.DebuggerHidden]
				global::System.Collections.Generic.IEnumerator<global::UnityEngine.Object> global::System.Collections.Generic.IEnumerable<global::UnityEngine.Object>.GetEnumerator()
				{
					if (global::System.Threading.Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
					{
						return this;
					}
					global::Facepunch.Bundling.LoadedBundleListOfAssets.<LoadAll>c__Iterator1D <LoadAll>c__Iterator1D = new global::Facepunch.Bundling.LoadedBundleListOfAssets.<LoadAll>c__Iterator1D();
					<LoadAll>c__Iterator1D.<>f__this = this;
					return <LoadAll>c__Iterator1D;
				}

				// Token: 0x0600061C RID: 1564 RVA: 0x0001C788 File Offset: 0x0001A988
				public bool MoveNext()
				{
					uint num = (uint)this.$PC;
					this.$PC = -1;
					switch (num)
					{
					case 0U:
						bundles = this.Bundles;
						i = 0;
						goto IL_C8;
					case 1U:
						j++;
						break;
					default:
						return false;
					}
					IL_A7:
					if (j < array.Length)
					{
						asset = array[j];
						this.$current = asset;
						this.$PC = 1;
						return true;
					}
					i++;
					IL_C8:
					if (i < bundles.Length)
					{
						bundle = bundles[i];
						array = bundle.LoadAll();
						j = 0;
						goto IL_A7;
					}
					this.$PC = -1;
					return false;
				}

				// Token: 0x0600061D RID: 1565 RVA: 0x0001C87C File Offset: 0x0001AA7C
				[global::System.Diagnostics.DebuggerHidden]
				public void Dispose()
				{
					this.$PC = -1;
				}

				// Token: 0x0600061E RID: 1566 RVA: 0x0001C888 File Offset: 0x0001AA88
				[global::System.Diagnostics.DebuggerHidden]
				public void Reset()
				{
					throw new global::System.NotSupportedException();
				}

				// Token: 0x04000563 RID: 1379
				internal global::Facepunch.Bundling.LoadedBundle[] <$s_180>__0;

				// Token: 0x04000564 RID: 1380
				internal int <$s_181>__1;

				// Token: 0x04000565 RID: 1381
				internal global::Facepunch.Bundling.LoadedBundle <bundle>__2;

				// Token: 0x04000566 RID: 1382
				internal global::UnityEngine.Object[] <$s_182>__3;

				// Token: 0x04000567 RID: 1383
				internal int <$s_183>__4;

				// Token: 0x04000568 RID: 1384
				internal global::UnityEngine.Object <asset>__5;

				// Token: 0x04000569 RID: 1385
				internal int $PC;

				// Token: 0x0400056A RID: 1386
				internal global::UnityEngine.Object $current;

				// Token: 0x0400056B RID: 1387
				internal global::Facepunch.Bundling.LoadedBundleListOfAssets <>f__this;
			}

			// Token: 0x02000115 RID: 277
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			private sealed class <LoadAll>c__Iterator1E : global::System.IDisposable, global::System.Collections.IEnumerator, global::System.Collections.IEnumerable, global::System.Collections.Generic.IEnumerable<global::UnityEngine.Object>, global::System.Collections.Generic.IEnumerator<global::UnityEngine.Object>
			{
				// Token: 0x0600061F RID: 1567 RVA: 0x0001C890 File Offset: 0x0001AA90
				public <LoadAll>c__Iterator1E()
				{
				}

				// Token: 0x170000F8 RID: 248
				// (get) Token: 0x06000620 RID: 1568 RVA: 0x0001C898 File Offset: 0x0001AA98
				global::UnityEngine.Object global::System.Collections.Generic.IEnumerator<global::UnityEngine.Object>.Current
				{
					[global::System.Diagnostics.DebuggerHidden]
					get
					{
						return this.$current;
					}
				}

				// Token: 0x170000F9 RID: 249
				// (get) Token: 0x06000621 RID: 1569 RVA: 0x0001C8A0 File Offset: 0x0001AAA0
				object global::System.Collections.IEnumerator.Current
				{
					[global::System.Diagnostics.DebuggerHidden]
					get
					{
						return this.$current;
					}
				}

				// Token: 0x06000622 RID: 1570 RVA: 0x0001C8A8 File Offset: 0x0001AAA8
				[global::System.Diagnostics.DebuggerHidden]
				global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
				{
					return this.System.Collections.Generic.IEnumerable<UnityEngine.Object>.GetEnumerator();
				}

				// Token: 0x06000623 RID: 1571 RVA: 0x0001C8B0 File Offset: 0x0001AAB0
				[global::System.Diagnostics.DebuggerHidden]
				global::System.Collections.Generic.IEnumerator<global::UnityEngine.Object> global::System.Collections.Generic.IEnumerable<global::UnityEngine.Object>.GetEnumerator()
				{
					if (global::System.Threading.Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
					{
						return this;
					}
					global::Facepunch.Bundling.LoadedBundleListOfAssets.<LoadAll>c__Iterator1E <LoadAll>c__Iterator1E = new global::Facepunch.Bundling.LoadedBundleListOfAssets.<LoadAll>c__Iterator1E();
					<LoadAll>c__Iterator1E.<>f__this = this;
					<LoadAll>c__Iterator1E.type = type;
					return <LoadAll>c__Iterator1E;
				}

				// Token: 0x06000624 RID: 1572 RVA: 0x0001C8F0 File Offset: 0x0001AAF0
				public bool MoveNext()
				{
					uint num = (uint)this.$PC;
					this.$PC = -1;
					switch (num)
					{
					case 0U:
						bundles = this.Bundles;
						i = 0;
						goto IL_CE;
					case 1U:
						j++;
						break;
					default:
						return false;
					}
					IL_AD:
					if (j < array.Length)
					{
						asset = array[j];
						this.$current = asset;
						this.$PC = 1;
						return true;
					}
					i++;
					IL_CE:
					if (i < bundles.Length)
					{
						bundle = bundles[i];
						array = bundle.LoadAll(type);
						j = 0;
						goto IL_AD;
					}
					this.$PC = -1;
					return false;
				}

				// Token: 0x06000625 RID: 1573 RVA: 0x0001C9EC File Offset: 0x0001ABEC
				[global::System.Diagnostics.DebuggerHidden]
				public void Dispose()
				{
					this.$PC = -1;
				}

				// Token: 0x06000626 RID: 1574 RVA: 0x0001C9F8 File Offset: 0x0001ABF8
				[global::System.Diagnostics.DebuggerHidden]
				public void Reset()
				{
					throw new global::System.NotSupportedException();
				}

				// Token: 0x0400056C RID: 1388
				internal global::Facepunch.Bundling.LoadedBundle[] <$s_184>__0;

				// Token: 0x0400056D RID: 1389
				internal int <$s_185>__1;

				// Token: 0x0400056E RID: 1390
				internal global::Facepunch.Bundling.LoadedBundle <bundle>__2;

				// Token: 0x0400056F RID: 1391
				internal global::System.Type type;

				// Token: 0x04000570 RID: 1392
				internal global::UnityEngine.Object[] <$s_186>__3;

				// Token: 0x04000571 RID: 1393
				internal int <$s_187>__4;

				// Token: 0x04000572 RID: 1394
				internal global::UnityEngine.Object <asset>__5;

				// Token: 0x04000573 RID: 1395
				internal int $PC;

				// Token: 0x04000574 RID: 1396
				internal global::UnityEngine.Object $current;

				// Token: 0x04000575 RID: 1397
				internal global::System.Type <$>type;

				// Token: 0x04000576 RID: 1398
				internal global::Facepunch.Bundling.LoadedBundleListOfAssets <>f__this;
			}
		}

		// Token: 0x02000116 RID: 278
		private class LoadedBundleListOfScenes
		{
			// Token: 0x06000627 RID: 1575 RVA: 0x0001CA00 File Offset: 0x0001AC00
			public LoadedBundleListOfScenes(global::System.Collections.Generic.IEnumerable<global::Facepunch.Bundling.LoadedBundle> bundles)
			{
				if (bundles is global::System.Collections.Generic.List<global::Facepunch.Bundling.LoadedBundle>)
				{
					this.Bundles = ((global::System.Collections.Generic.List<global::Facepunch.Bundling.LoadedBundle>)bundles).ToArray();
				}
				else
				{
					this.Bundles = new global::System.Collections.Generic.List<global::Facepunch.Bundling.LoadedBundle>(bundles).ToArray();
				}
			}

			// Token: 0x06000628 RID: 1576 RVA: 0x0001CA48 File Offset: 0x0001AC48
			internal void Unload()
			{
				foreach (global::Facepunch.Bundling.LoadedBundle loadedBundle in this.Bundles)
				{
					loadedBundle.Unload();
				}
			}

			// Token: 0x04000577 RID: 1399
			public readonly global::Facepunch.Bundling.LoadedBundle[] Bundles;
		}

		// Token: 0x02000117 RID: 279
		private class LoadedBundleMap : global::System.IDisposable
		{
			// Token: 0x06000629 RID: 1577 RVA: 0x0001CA7C File Offset: 0x0001AC7C
			public LoadedBundleMap(global::System.Collections.Generic.IEnumerable<global::System.Collections.Generic.KeyValuePair<global::System.Type, global::System.Collections.Generic.List<global::Facepunch.Bundling.LoadedBundle>>> assets, global::System.Collections.Generic.IEnumerable<global::Facepunch.Bundling.LoadedBundle> scenes)
			{
				this.Assets = new global::Facepunch.Bundling.LoadedBundleAssetMap(assets);
				this.Scenes = new global::Facepunch.Bundling.LoadedBundleListOfScenes(scenes);
				global::Facepunch.Bundling.Map = this;
				global::Facepunch.Bundling.HasLoadedBundleMap = true;
			}

			// Token: 0x0600062A RID: 1578 RVA: 0x0001CAB4 File Offset: 0x0001ACB4
			public void Dispose()
			{
				if (!this.disposed)
				{
					if (global::Facepunch.Bundling.Map == this)
					{
						global::Facepunch.Bundling.Map = null;
						global::Facepunch.Bundling.HasLoadedBundleMap = false;
					}
					this.disposed = true;
					this.Assets.Unload();
					this.Scenes.Unload();
				}
			}

			// Token: 0x04000578 RID: 1400
			public readonly global::Facepunch.Bundling.LoadedBundleListOfScenes Scenes;

			// Token: 0x04000579 RID: 1401
			public readonly global::Facepunch.Bundling.LoadedBundleAssetMap Assets;

			// Token: 0x0400057A RID: 1402
			private bool disposed;
		}

		// Token: 0x02000118 RID: 280
		// (Invoke) Token: 0x0600062C RID: 1580
		public delegate void OnLoadedEventHandler();
	}
}
