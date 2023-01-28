using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Facepunch.Attributes
{
	// Token: 0x020004EF RID: 1263
	public abstract class ObjectLookupFieldAttribute : global::Facepunch.Attributes.FieldAttribute
	{
		// Token: 0x06002BB3 RID: 11187 RVA: 0x000A3DD0 File Offset: 0x000A1FD0
		protected ObjectLookupFieldAttribute(global::Facepunch.Attributes.PrefabLookupKinds kinds, global::System.Type minimumType, global::Facepunch.Attributes.SearchMode searchModeDefault, global::System.Type[] interfaceTypes)
		{
			this.Kinds = kinds;
			this.MinimumType = minimumType;
			if (searchModeDefault != global::Facepunch.Attributes.SearchMode.Default)
			{
				this.searchModeDefault = searchModeDefault;
			}
			this.RequiredInterfaces = (interfaceTypes ?? global::Facepunch.Attributes.ObjectLookupFieldAttribute.Empty.TypeArray);
		}

		// Token: 0x1700099A RID: 2458
		// (get) Token: 0x06002BB4 RID: 11188 RVA: 0x000A3E2C File Offset: 0x000A202C
		// (set) Token: 0x06002BB5 RID: 11189 RVA: 0x000A3E34 File Offset: 0x000A2034
		public bool AllowNull
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			get
			{
				return this.<AllowNull>k__BackingField;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			set
			{
				this.<AllowNull>k__BackingField = value;
			}
		}

		// Token: 0x1700099B RID: 2459
		// (get) Token: 0x06002BB6 RID: 11190 RVA: 0x000A3E40 File Offset: 0x000A2040
		// (set) Token: 0x06002BB7 RID: 11191 RVA: 0x000A3E60 File Offset: 0x000A2060
		public global::Facepunch.Attributes.SearchMode SearchMode
		{
			get
			{
				return (this.searchMode != global::Facepunch.Attributes.SearchMode.Default) ? this.searchMode : this.searchModeDefault;
			}
			protected set
			{
				this.searchMode = value;
			}
		}

		// Token: 0x1700099C RID: 2460
		// (get) Token: 0x06002BB8 RID: 11192 RVA: 0x000A3E6C File Offset: 0x000A206C
		// (set) Token: 0x06002BB9 RID: 11193 RVA: 0x000A3E84 File Offset: 0x000A2084
		public global::System.Type MinimumType
		{
			get
			{
				return this.minType ?? this.attributeMinimumType;
			}
			set
			{
				if (value != null && !this.attributeMinimumType.IsAssignableFrom(value) && !this.CompliantMinimumType(value))
				{
					throw new global::System.ArgumentOutOfRangeException("value", value, "The type is not assignable given restrictions");
				}
				this.minType = value;
			}
		}

		// Token: 0x06002BBA RID: 11194 RVA: 0x000A3EC4 File Offset: 0x000A20C4
		protected virtual global::Facepunch.Attributes.CustomLookupResult CustomLookup(object value, global::System.Type type, ref global::UnityEngine.Object find)
		{
			return global::Facepunch.Attributes.CustomLookupResult.Fallback;
		}

		// Token: 0x06002BBB RID: 11195 RVA: 0x000A3EC8 File Offset: 0x000A20C8
		public global::Facepunch.Attributes.CustomLookupResult Lookup(object value, out global::UnityEngine.Object find)
		{
			return this.Lookup(value, this.MinimumType, out find);
		}

		// Token: 0x06002BBC RID: 11196 RVA: 0x000A3ED8 File Offset: 0x000A20D8
		public global::Facepunch.Attributes.CustomLookupResult Lookup(object value, global::System.Type type, out global::UnityEngine.Object find)
		{
			find = null;
			if (!this.MinimumType.IsAssignableFrom(type))
			{
				return global::Facepunch.Attributes.CustomLookupResult.FailCast;
			}
			foreach (global::System.Type type2 in this.RequiredInterfaces)
			{
				if (!type2.IsAssignableFrom(type))
				{
					return global::Facepunch.Attributes.CustomLookupResult.FailInterface;
				}
			}
			global::Facepunch.Attributes.CustomLookupResult customLookupResult;
			try
			{
				customLookupResult = this.CustomLookup(value, type, ref find);
			}
			catch (global::System.Exception ex)
			{
				global::UnityEngine.Debug.LogException(ex, find);
				return global::Facepunch.Attributes.CustomLookupResult.FailCustomException;
			}
			if (customLookupResult == global::Facepunch.Attributes.CustomLookupResult.Fallback)
			{
				customLookupResult = global::Facepunch.Attributes.CustomLookupResult.Accept;
			}
			if (customLookupResult == global::Facepunch.Attributes.CustomLookupResult.Accept)
			{
				try
				{
					customLookupResult = this.Confirm(find);
				}
				catch (global::System.Exception ex2)
				{
					global::UnityEngine.Debug.LogException(ex2, find);
					return global::Facepunch.Attributes.CustomLookupResult.FailConfirmException;
				}
			}
			return customLookupResult;
		}

		// Token: 0x06002BBD RID: 11197 RVA: 0x000A3FC0 File Offset: 0x000A21C0
		public global::Facepunch.Attributes.CustomLookupResult Lookup<TObj>(object value, out TObj find) where TObj : global::UnityEngine.Object
		{
			return this.Lookup<TObj>(value, typeof(TObj), out find);
		}

		// Token: 0x06002BBE RID: 11198 RVA: 0x000A3FD4 File Offset: 0x000A21D4
		public global::Facepunch.Attributes.CustomLookupResult Lookup<TObj>(object value, global::System.Type type, out TObj find) where TObj : global::UnityEngine.Object
		{
			if (!typeof(TObj).IsAssignableFrom(type))
			{
				throw new global::System.ArgumentOutOfRangeException("type", type, "type is not assignable to the generic " + typeof(TObj));
			}
			global::UnityEngine.Object @object;
			global::Facepunch.Attributes.CustomLookupResult customLookupResult;
			try
			{
				customLookupResult = this.Lookup(value, typeof(TObj), out @object);
			}
			catch (global::System.Exception ex)
			{
				global::UnityEngine.Debug.LogException(ex);
				find = (TObj)((object)null);
				return global::Facepunch.Attributes.CustomLookupResult.FailCustomException;
			}
			if (customLookupResult > global::Facepunch.Attributes.CustomLookupResult.Fallback)
			{
				try
				{
					find = (TObj)((object)@object);
				}
				catch (global::System.Exception ex2)
				{
					global::UnityEngine.Debug.LogException(ex2, @object);
					find = (TObj)((object)null);
					return global::Facepunch.Attributes.CustomLookupResult.FailCast;
				}
			}
			else
			{
				try
				{
					find = (TObj)((object)@object);
				}
				catch
				{
					find = (TObj)((object)null);
				}
			}
			return customLookupResult;
		}

		// Token: 0x06002BBF RID: 11199 RVA: 0x000A4104 File Offset: 0x000A2304
		protected virtual global::Facepunch.Attributes.CustomLookupResult CustomConfirm(global::UnityEngine.Object obj, bool isNull, global::System.Type type)
		{
			return global::Facepunch.Attributes.CustomLookupResult.Fallback;
		}

		// Token: 0x06002BC0 RID: 11200 RVA: 0x000A4108 File Offset: 0x000A2308
		public global::Facepunch.Attributes.CustomLookupResult Confirm(global::UnityEngine.Object obj)
		{
			bool flag;
			if (!this.AllowNull)
			{
				if (!obj)
				{
					return global::Facepunch.Attributes.CustomLookupResult.FailNull;
				}
				flag = false;
			}
			else
			{
				flag = !obj;
			}
			global::Facepunch.Attributes.CustomLookupResult customLookupResult;
			if (!flag)
			{
				global::System.Type type;
				try
				{
					type = obj.GetType();
				}
				catch (global::System.Exception ex)
				{
					global::UnityEngine.Debug.LogException(ex, obj);
					return global::Facepunch.Attributes.CustomLookupResult.FailNull;
				}
				try
				{
					customLookupResult = this.CustomConfirm(obj, false, type);
				}
				catch (global::System.Exception ex2)
				{
					global::UnityEngine.Debug.LogException(ex2, obj);
					customLookupResult = global::Facepunch.Attributes.CustomLookupResult.FailConfirmException;
				}
			}
			else
			{
				try
				{
					customLookupResult = this.CustomConfirm(null, true, null);
				}
				catch (global::System.Exception ex3)
				{
					global::UnityEngine.Debug.LogException(ex3);
					customLookupResult = global::Facepunch.Attributes.CustomLookupResult.FailConfirmException;
				}
			}
			if (customLookupResult == global::Facepunch.Attributes.CustomLookupResult.Fallback)
			{
				return global::Facepunch.Attributes.CustomLookupResult.AcceptConfirmed;
			}
			return customLookupResult;
		}

		// Token: 0x06002BC1 RID: 11201 RVA: 0x000A4204 File Offset: 0x000A2404
		protected virtual bool CompliantMinimumType(global::System.Type type)
		{
			return true;
		}

		// Token: 0x04001625 RID: 5669
		public readonly global::Facepunch.Attributes.PrefabLookupKinds Kinds;

		// Token: 0x04001626 RID: 5670
		private global::System.Type minType;

		// Token: 0x04001627 RID: 5671
		private global::Facepunch.Attributes.SearchMode searchMode;

		// Token: 0x04001628 RID: 5672
		private readonly global::System.Type attributeMinimumType = typeof(global::UnityEngine.Object);

		// Token: 0x04001629 RID: 5673
		private readonly global::Facepunch.Attributes.SearchMode searchModeDefault = global::Facepunch.Attributes.SearchMode.MainAsset;

		// Token: 0x0400162A RID: 5674
		public readonly global::System.Type[] RequiredInterfaces;

		// Token: 0x0400162B RID: 5675
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private bool <AllowNull>k__BackingField;

		// Token: 0x020004F0 RID: 1264
		private static class Empty
		{
			// Token: 0x06002BC2 RID: 11202 RVA: 0x000A4208 File Offset: 0x000A2408
			// Note: this type is marked as 'beforefieldinit'.
			static Empty()
			{
			}

			// Token: 0x0400162C RID: 5676
			public static readonly global::System.Type[] TypeArray = new global::System.Type[0];
		}
	}
}
