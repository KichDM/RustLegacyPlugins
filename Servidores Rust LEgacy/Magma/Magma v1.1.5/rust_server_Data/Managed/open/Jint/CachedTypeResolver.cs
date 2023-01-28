using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;

namespace Jint
{
	// Token: 0x02000003 RID: 3
	public class CachedTypeResolver : global::Jint.ITypeResolver
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000002 RID: 2 RVA: 0x00002048 File Offset: 0x00000248
		public static global::Jint.CachedTypeResolver Default
		{
			get
			{
				global::Jint.CachedTypeResolver result;
				lock (typeof(global::Jint.CachedTypeResolver))
				{
					global::Jint.CachedTypeResolver cachedTypeResolver;
					if ((cachedTypeResolver = global::Jint.CachedTypeResolver._default) == null)
					{
						cachedTypeResolver = (global::Jint.CachedTypeResolver._default = new global::Jint.CachedTypeResolver());
					}
					result = cachedTypeResolver;
				}
				return result;
			}
		}

		// Token: 0x06000003 RID: 3 RVA: 0x0000209C File Offset: 0x0000029C
		public global::System.Type ResolveType(string fullname)
		{
			this._lock.AcquireReaderLock(-1);
			global::System.Type result;
			try
			{
				if (this._cache.ContainsKey(fullname))
				{
					result = this._cache[fullname];
				}
				else
				{
					global::System.Type type = null;
					foreach (global::System.Reflection.Assembly assembly in global::System.AppDomain.CurrentDomain.GetAssemblies())
					{
						type = assembly.GetType(fullname, false, false);
						if (type != null)
						{
							break;
						}
					}
					this._lock.UpgradeToWriterLock(-1);
					this._cache.Add(fullname, type);
					result = type;
				}
			}
			finally
			{
				this._lock.ReleaseLock();
			}
			return result;
		}

		// Token: 0x06000004 RID: 4 RVA: 0x00002150 File Offset: 0x00000350
		public CachedTypeResolver()
		{
		}

		// Token: 0x04000001 RID: 1
		private readonly global::System.Collections.Generic.Dictionary<string, global::System.Type> _cache = new global::System.Collections.Generic.Dictionary<string, global::System.Type>();

		// Token: 0x04000002 RID: 2
		private readonly global::System.Threading.ReaderWriterLock _lock = new global::System.Threading.ReaderWriterLock();

		// Token: 0x04000003 RID: 3
		private static global::Jint.CachedTypeResolver _default;
	}
}
