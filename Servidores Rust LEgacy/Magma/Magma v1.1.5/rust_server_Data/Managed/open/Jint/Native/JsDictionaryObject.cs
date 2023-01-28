using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using Jint.Expressions;
using Jint.PropertyBags;

namespace Jint.Native
{
	// Token: 0x0200000F RID: 15
	[global::System.Serializable]
	public abstract class JsDictionaryObject : global::Jint.Native.JsInstance, global::System.Collections.Generic.IEnumerable<global::System.Collections.Generic.KeyValuePair<string, global::Jint.Native.JsInstance>>, global::System.Collections.IEnumerable
	{
		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000040 RID: 64 RVA: 0x0000459C File Offset: 0x0000279C
		// (set) Token: 0x06000041 RID: 65 RVA: 0x000045A4 File Offset: 0x000027A4
		public bool Extensible
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			get
			{
				return this.<Extensible>k__BackingField;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			set
			{
				this.<Extensible>k__BackingField = value;
			}
		}

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000042 RID: 66 RVA: 0x000045B0 File Offset: 0x000027B0
		// (set) Token: 0x06000043 RID: 67 RVA: 0x000045B8 File Offset: 0x000027B8
		public bool hasChildren
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			get
			{
				return this.<hasChildren>k__BackingField;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			private set
			{
				this.<hasChildren>k__BackingField = value;
			}
		}

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000044 RID: 68 RVA: 0x000045C4 File Offset: 0x000027C4
		// (set) Token: 0x06000045 RID: 69 RVA: 0x000045CC File Offset: 0x000027CC
		public virtual int Length
		{
			get
			{
				return this.m_length;
			}
			set
			{
			}
		}

		// Token: 0x06000046 RID: 70 RVA: 0x000045D0 File Offset: 0x000027D0
		public JsDictionaryObject()
		{
			this.Extensible = true;
			this.Prototype = global::Jint.Native.JsNull.Instance;
		}

		// Token: 0x06000047 RID: 71 RVA: 0x000045F8 File Offset: 0x000027F8
		public JsDictionaryObject(global::Jint.Native.JsDictionaryObject prototype)
		{
			this.Prototype = prototype;
			this.Extensible = true;
			prototype.hasChildren = true;
		}

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000048 RID: 72 RVA: 0x00004630 File Offset: 0x00002830
		// (set) Token: 0x06000049 RID: 73 RVA: 0x00004638 File Offset: 0x00002838
		private global::Jint.Native.JsDictionaryObject Prototype
		{
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			get
			{
				return this.<Prototype>k__BackingField;
			}
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			set
			{
				this.<Prototype>k__BackingField = value;
			}
		}

		// Token: 0x0600004A RID: 74 RVA: 0x00004644 File Offset: 0x00002844
		public virtual bool HasProperty(string key)
		{
			global::Jint.Native.JsDictionaryObject jsDictionaryObject = this;
			while (!jsDictionaryObject.HasOwnProperty(key))
			{
				jsDictionaryObject = jsDictionaryObject.Prototype;
				if (jsDictionaryObject == global::Jint.Native.JsUndefined.Instance || jsDictionaryObject == global::Jint.Native.JsNull.Instance)
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x0600004B RID: 75 RVA: 0x00004680 File Offset: 0x00002880
		public virtual bool HasOwnProperty(string key)
		{
			global::Jint.Native.Descriptor descriptor;
			return this.properties.TryGet(key, out descriptor) && descriptor.Owner == this;
		}

		// Token: 0x0600004C RID: 76 RVA: 0x000046B0 File Offset: 0x000028B0
		public virtual bool HasProperty(global::Jint.Native.JsInstance key)
		{
			return this.HasProperty(key.ToString());
		}

		// Token: 0x0600004D RID: 77 RVA: 0x000046C0 File Offset: 0x000028C0
		public virtual bool HasOwnProperty(global::Jint.Native.JsInstance key)
		{
			return this.HasOwnProperty(key.ToString());
		}

		// Token: 0x0600004E RID: 78 RVA: 0x000046D0 File Offset: 0x000028D0
		public virtual global::Jint.Native.Descriptor GetDescriptor(string index)
		{
			global::Jint.Native.Descriptor descriptor;
			if (this.properties.TryGet(index, out descriptor))
			{
				if (!descriptor.isDeleted)
				{
					return descriptor;
				}
				this.properties.Delete(index);
			}
			if ((descriptor = this.Prototype.GetDescriptor(index)) != null)
			{
				this.properties.Put(index, descriptor);
			}
			return descriptor;
		}

		// Token: 0x0600004F RID: 79 RVA: 0x00004730 File Offset: 0x00002930
		public virtual bool TryGetDescriptor(global::Jint.Native.JsInstance index, out global::Jint.Native.Descriptor result)
		{
			return this.TryGetDescriptor(index.ToString(), out result);
		}

		// Token: 0x06000050 RID: 80 RVA: 0x00004740 File Offset: 0x00002940
		public virtual bool TryGetDescriptor(string index, out global::Jint.Native.Descriptor result)
		{
			result = this.GetDescriptor(index);
			return result != null;
		}

		// Token: 0x06000051 RID: 81 RVA: 0x00004754 File Offset: 0x00002954
		public virtual bool TryGetProperty(global::Jint.Native.JsInstance index, out global::Jint.Native.JsInstance result)
		{
			return this.TryGetProperty(index.ToString(), out result);
		}

		// Token: 0x06000052 RID: 82 RVA: 0x00004764 File Offset: 0x00002964
		public virtual bool TryGetProperty(string index, out global::Jint.Native.JsInstance result)
		{
			global::Jint.Native.Descriptor descriptor = this.GetDescriptor(index);
			if (descriptor == null)
			{
				result = global::Jint.Native.JsUndefined.Instance;
				return false;
			}
			result = descriptor.Get(this);
			return true;
		}

		// Token: 0x1700000C RID: 12
		public virtual global::Jint.Native.JsInstance this[global::Jint.Native.JsInstance key]
		{
			get
			{
				return this[key.ToString()];
			}
			set
			{
				this[key.ToString()] = value;
			}
		}

		// Token: 0x1700000D RID: 13
		public virtual global::Jint.Native.JsInstance this[string index]
		{
			get
			{
				global::Jint.Native.Descriptor descriptor = this.GetDescriptor(index);
				if (descriptor == null)
				{
					return global::Jint.Native.JsUndefined.Instance;
				}
				return descriptor.Get(this);
			}
			set
			{
				global::Jint.Native.Descriptor descriptor = this.GetDescriptor(index);
				if (descriptor == null || (descriptor.Owner != this && descriptor.DescriptorType == global::Jint.Native.DescriptorType.Value))
				{
					this.DefineOwnProperty(new global::Jint.Native.ValueDescriptor(this, index, value));
					return;
				}
				descriptor.Set(this, value);
			}
		}

		// Token: 0x06000057 RID: 87 RVA: 0x00004834 File Offset: 0x00002A34
		public virtual void Delete(global::Jint.Native.JsInstance key)
		{
			this.Delete(key.ToString());
		}

		// Token: 0x06000058 RID: 88 RVA: 0x00004844 File Offset: 0x00002A44
		public virtual void Delete(string index)
		{
			global::Jint.Native.Descriptor descriptor = null;
			if (!this.TryGetDescriptor(index, out descriptor) || descriptor.Owner != this)
			{
				return;
			}
			if (descriptor.Configurable)
			{
				this.properties.Delete(index);
				descriptor.Delete();
				this.m_length--;
				return;
			}
			throw new global::Jint.JintException("Property " + index + " isn't configurable");
		}

		// Token: 0x06000059 RID: 89 RVA: 0x000048B4 File Offset: 0x00002AB4
		public void DefineOwnProperty(string key, global::Jint.Native.JsInstance value, global::Jint.Native.PropertyAttributes propertyAttributes)
		{
			this.DefineOwnProperty(new global::Jint.Native.ValueDescriptor(this, key, value)
			{
				Writable = ((propertyAttributes & global::Jint.Native.PropertyAttributes.ReadOnly) == global::Jint.Native.PropertyAttributes.None),
				Enumerable = ((propertyAttributes & global::Jint.Native.PropertyAttributes.DontEnum) == global::Jint.Native.PropertyAttributes.None)
			});
		}

		// Token: 0x0600005A RID: 90 RVA: 0x000048F0 File Offset: 0x00002AF0
		public virtual void DefineOwnProperty(string key, global::Jint.Native.JsInstance value)
		{
			this.DefineOwnProperty(new global::Jint.Native.ValueDescriptor(this, key, value));
		}

		// Token: 0x0600005B RID: 91 RVA: 0x00004900 File Offset: 0x00002B00
		public virtual void DefineOwnProperty(global::Jint.Native.Descriptor currentDescriptor)
		{
			string name = currentDescriptor.Name;
			global::Jint.Native.Descriptor descriptor;
			if (!this.properties.TryGet(name, out descriptor) || descriptor.Owner != this)
			{
				if (descriptor != null)
				{
					descriptor.Owner.RedefineProperty(descriptor.Name);
				}
				this.properties.Put(name, currentDescriptor);
				this.m_length++;
				return;
			}
			switch (descriptor.DescriptorType)
			{
			case global::Jint.Native.DescriptorType.Value:
				switch (currentDescriptor.DescriptorType)
				{
				case global::Jint.Native.DescriptorType.Value:
					this.properties.Get(name).Set(this, currentDescriptor.Get(this));
					return;
				case global::Jint.Native.DescriptorType.Accessor:
					this.properties.Delete(name);
					this.properties.Put(name, currentDescriptor);
					return;
				case global::Jint.Native.DescriptorType.Clr:
					throw new global::System.NotSupportedException();
				default:
					return;
				}
				break;
			case global::Jint.Native.DescriptorType.Accessor:
			{
				global::Jint.Native.PropertyDescriptor propertyDescriptor = (global::Jint.Native.PropertyDescriptor)descriptor;
				if (currentDescriptor.DescriptorType == global::Jint.Native.DescriptorType.Accessor)
				{
					propertyDescriptor.GetFunction = (((global::Jint.Native.PropertyDescriptor)currentDescriptor).GetFunction ?? propertyDescriptor.GetFunction);
					propertyDescriptor.SetFunction = (((global::Jint.Native.PropertyDescriptor)currentDescriptor).SetFunction ?? propertyDescriptor.SetFunction);
					return;
				}
				propertyDescriptor.Set(this, currentDescriptor.Get(this));
				return;
			}
			default:
				return;
			}
		}

		// Token: 0x0600005C RID: 92 RVA: 0x00004A3C File Offset: 0x00002C3C
		private void RedefineProperty(string name)
		{
			global::Jint.Native.Descriptor descriptor;
			if (this.properties.TryGet(name, out descriptor) && descriptor.Owner == this)
			{
				this.properties.Put(name, descriptor.Clone());
				descriptor.Delete();
			}
		}

		// Token: 0x0600005D RID: 93 RVA: 0x00004A88 File Offset: 0x00002C88
		public global::System.Collections.Generic.IEnumerator<global::System.Collections.Generic.KeyValuePair<string, global::Jint.Native.JsInstance>> GetEnumerator()
		{
			foreach (global::System.Collections.Generic.KeyValuePair<string, global::Jint.Native.Descriptor> descriptor in this.properties)
			{
				global::System.Collections.Generic.KeyValuePair<string, global::Jint.Native.Descriptor> keyValuePair = descriptor;
				if (keyValuePair.Value.Enumerable)
				{
					global::System.Collections.Generic.KeyValuePair<string, global::Jint.Native.Descriptor> keyValuePair2 = descriptor;
					string key = keyValuePair2.Key;
					global::System.Collections.Generic.KeyValuePair<string, global::Jint.Native.Descriptor> keyValuePair3 = descriptor;
					yield return new global::System.Collections.Generic.KeyValuePair<string, global::Jint.Native.JsInstance>(key, keyValuePair3.Value.Get(this));
				}
			}
			yield break;
		}

		// Token: 0x0600005E RID: 94 RVA: 0x00004AA8 File Offset: 0x00002CA8
		global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
		{
			return this.properties.GetEnumerator();
		}

		// Token: 0x0600005F RID: 95 RVA: 0x00004AB8 File Offset: 0x00002CB8
		public virtual global::System.Collections.Generic.IEnumerable<global::Jint.Native.JsInstance> GetValues()
		{
			foreach (global::Jint.Native.Descriptor descriptor in this.properties.Values)
			{
				if (descriptor.Enumerable)
				{
					yield return descriptor.Get(this);
				}
			}
			yield break;
		}

		// Token: 0x06000060 RID: 96 RVA: 0x00004ADC File Offset: 0x00002CDC
		public virtual global::System.Collections.Generic.IEnumerable<string> GetKeys()
		{
			global::Jint.Native.JsDictionaryObject p = this.Prototype;
			if (p != global::Jint.Native.JsUndefined.Instance && p != global::Jint.Native.JsNull.Instance && p != null)
			{
				foreach (string key in p.GetKeys())
				{
					if (!this.HasOwnProperty(key))
					{
						yield return key;
					}
				}
			}
			foreach (global::System.Collections.Generic.KeyValuePair<string, global::Jint.Native.Descriptor> descriptor in this.properties)
			{
				global::System.Collections.Generic.KeyValuePair<string, global::Jint.Native.Descriptor> keyValuePair = descriptor;
				if (keyValuePair.Value.Enumerable)
				{
					global::System.Collections.Generic.KeyValuePair<string, global::Jint.Native.Descriptor> keyValuePair2 = descriptor;
					if (keyValuePair2.Value.Owner == this)
					{
						global::System.Collections.Generic.KeyValuePair<string, global::Jint.Native.Descriptor> keyValuePair3 = descriptor;
						yield return keyValuePair3.Key;
					}
				}
			}
			yield break;
		}

		// Token: 0x06000061 RID: 97 RVA: 0x00004B00 File Offset: 0x00002D00
		public virtual global::Jint.Native.JsInstance GetGetFunction(global::Jint.Native.JsDictionaryObject target, global::Jint.Native.JsInstance[] parameters)
		{
			if (parameters.Length <= 0)
			{
				throw new global::System.ArgumentException("propertyName");
			}
			if (!target.HasOwnProperty(parameters[0].ToString()))
			{
				return this.GetGetFunction(target.Prototype, parameters);
			}
			global::Jint.Native.PropertyDescriptor propertyDescriptor = target.properties.Get(parameters[0].ToString()) as global::Jint.Native.PropertyDescriptor;
			if (propertyDescriptor == null)
			{
				return global::Jint.Native.JsUndefined.Instance;
			}
			return propertyDescriptor.GetFunction ?? global::Jint.Native.JsUndefined.Instance;
		}

		// Token: 0x06000062 RID: 98 RVA: 0x00004B88 File Offset: 0x00002D88
		public virtual global::Jint.Native.JsInstance GetSetFunction(global::Jint.Native.JsDictionaryObject target, global::Jint.Native.JsInstance[] parameters)
		{
			if (parameters.Length <= 0)
			{
				throw new global::System.ArgumentException("propertyName");
			}
			if (!target.HasOwnProperty(parameters[0].ToString()))
			{
				return this.GetSetFunction(target.Prototype, parameters);
			}
			global::Jint.Native.PropertyDescriptor propertyDescriptor = target.properties.Get(parameters[0].ToString()) as global::Jint.Native.PropertyDescriptor;
			if (propertyDescriptor == null)
			{
				return global::Jint.Native.JsUndefined.Instance;
			}
			return propertyDescriptor.SetFunction ?? global::Jint.Native.JsUndefined.Instance;
		}

		// Token: 0x06000063 RID: 99 RVA: 0x00004C10 File Offset: 0x00002E10
		[global::System.Obsolete("will be removed in 1.2", true)]
		public override object Call(global::Jint.Expressions.IJintVisitor visitor, string function, params global::Jint.Native.JsInstance[] parameters)
		{
			visitor.ExecuteFunction(this[function] as global::Jint.Native.JsFunction, this, parameters);
			return visitor.Returned;
		}

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x06000064 RID: 100 RVA: 0x00004C2C File Offset: 0x00002E2C
		public override bool IsClr
		{
			get
			{
				return false;
			}
		}

		// Token: 0x06000065 RID: 101 RVA: 0x00004C30 File Offset: 0x00002E30
		public bool IsPrototypeOf(global::Jint.Native.JsDictionaryObject target)
		{
			return target != null && target != global::Jint.Native.JsUndefined.Instance && target != global::Jint.Native.JsNull.Instance && (target.Prototype == this || this.IsPrototypeOf(target.Prototype));
		}

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x06000066 RID: 102 RVA: 0x00004C6C File Offset: 0x00002E6C
		// (set) Token: 0x06000067 RID: 103 RVA: 0x00004C70 File Offset: 0x00002E70
		public override object Value
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		// Token: 0x0400002C RID: 44
		protected internal global::Jint.IPropertyBag properties = new global::Jint.PropertyBags.MiniCachedPropertyBag();

		// Token: 0x0400002D RID: 45
		private int m_length;

		// Token: 0x0400002E RID: 46
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private bool <Extensible>k__BackingField;

		// Token: 0x0400002F RID: 47
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private bool <hasChildren>k__BackingField;

		// Token: 0x04000030 RID: 48
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private global::Jint.Native.JsDictionaryObject <Prototype>k__BackingField;

		// Token: 0x020000DF RID: 223
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private sealed class <GetEnumerator>d__1 : global::System.Collections.Generic.IEnumerator<global::System.Collections.Generic.KeyValuePair<string, global::Jint.Native.JsInstance>>, global::System.Collections.IEnumerator, global::System.IDisposable
		{
			// Token: 0x06000A24 RID: 2596 RVA: 0x000359CC File Offset: 0x00033BCC
			bool global::System.Collections.IEnumerator.MoveNext()
			{
				bool result;
				try
				{
					switch (this.<>1__state)
					{
					case 0:
						this.<>1__state = -1;
						enumerator = this.properties.GetEnumerator();
						this.<>1__state = 1;
						break;
					case 1:
						goto IL_CB;
					case 2:
						this.<>1__state = 1;
						break;
					default:
						goto IL_CB;
					}
					while (enumerator.MoveNext())
					{
						descriptor = enumerator.Current;
						global::System.Collections.Generic.KeyValuePair<string, global::Jint.Native.Descriptor> keyValuePair = descriptor;
						if (keyValuePair.Value.Enumerable)
						{
							global::System.Collections.Generic.KeyValuePair<string, global::Jint.Native.Descriptor> keyValuePair2 = descriptor;
							string key = keyValuePair2.Key;
							global::System.Collections.Generic.KeyValuePair<string, global::Jint.Native.Descriptor> keyValuePair3 = descriptor;
							this.<>2__current = new global::System.Collections.Generic.KeyValuePair<string, global::Jint.Native.JsInstance>(key, keyValuePair3.Value.Get(this));
							this.<>1__state = 2;
							return true;
						}
					}
					this.<>m__Finally4();
					IL_CB:
					result = false;
				}
				catch
				{
					this.System.IDisposable.Dispose();
					throw;
				}
				return result;
			}

			// Token: 0x170001E5 RID: 485
			// (get) Token: 0x06000A25 RID: 2597 RVA: 0x00035AC8 File Offset: 0x00033CC8
			global::System.Collections.Generic.KeyValuePair<string, global::Jint.Native.JsInstance> global::System.Collections.Generic.IEnumerator<global::System.Collections.Generic.KeyValuePair<string, global::Jint.Native.JsInstance>>.Current
			{
				[global::System.Diagnostics.DebuggerHidden]
				get
				{
					return this.<>2__current;
				}
			}

			// Token: 0x06000A26 RID: 2598 RVA: 0x00035AD0 File Offset: 0x00033CD0
			[global::System.Diagnostics.DebuggerHidden]
			void global::System.Collections.IEnumerator.Reset()
			{
				throw new global::System.NotSupportedException();
			}

			// Token: 0x06000A27 RID: 2599 RVA: 0x00035AD8 File Offset: 0x00033CD8
			void global::System.IDisposable.Dispose()
			{
				switch (this.<>1__state)
				{
				case 1:
				case 2:
					try
					{
					}
					finally
					{
						this.<>m__Finally4();
					}
					return;
				default:
					return;
				}
			}

			// Token: 0x170001E6 RID: 486
			// (get) Token: 0x06000A28 RID: 2600 RVA: 0x00035B1C File Offset: 0x00033D1C
			object global::System.Collections.IEnumerator.Current
			{
				[global::System.Diagnostics.DebuggerHidden]
				get
				{
					return this.<>2__current;
				}
			}

			// Token: 0x06000A29 RID: 2601 RVA: 0x00035B2C File Offset: 0x00033D2C
			[global::System.Diagnostics.DebuggerHidden]
			public <GetEnumerator>d__1(int <>1__state)
			{
				this.<>1__state = <>1__state;
			}

			// Token: 0x06000A2A RID: 2602 RVA: 0x00035B3C File Offset: 0x00033D3C
			private void <>m__Finally4()
			{
				this.<>1__state = -1;
				if (enumerator != null)
				{
					enumerator.Dispose();
				}
			}

			// Token: 0x04000433 RID: 1075
			private global::System.Collections.Generic.KeyValuePair<string, global::Jint.Native.JsInstance> <>2__current;

			// Token: 0x04000434 RID: 1076
			private int <>1__state;

			// Token: 0x04000435 RID: 1077
			public global::Jint.Native.JsDictionaryObject <>4__this;

			// Token: 0x04000436 RID: 1078
			public global::System.Collections.Generic.KeyValuePair<string, global::Jint.Native.Descriptor> <descriptor>5__2;

			// Token: 0x04000437 RID: 1079
			public global::System.Collections.Generic.IEnumerator<global::System.Collections.Generic.KeyValuePair<string, global::Jint.Native.Descriptor>> <>7__wrap3;
		}

		// Token: 0x020000E0 RID: 224
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private sealed class <GetValues>d__6 : global::System.Collections.Generic.IEnumerable<global::Jint.Native.JsInstance>, global::System.Collections.IEnumerable, global::System.Collections.Generic.IEnumerator<global::Jint.Native.JsInstance>, global::System.Collections.IEnumerator, global::System.IDisposable
		{
			// Token: 0x06000A2B RID: 2603 RVA: 0x00035B5C File Offset: 0x00033D5C
			[global::System.Diagnostics.DebuggerHidden]
			global::System.Collections.Generic.IEnumerator<global::Jint.Native.JsInstance> global::System.Collections.Generic.IEnumerable<global::Jint.Native.JsInstance>.GetEnumerator()
			{
				global::Jint.Native.JsDictionaryObject.<GetValues>d__6 <GetValues>d__;
				if (global::System.Threading.Thread.CurrentThread.ManagedThreadId == this.<>l__initialThreadId && this.<>1__state == -2)
				{
					this.<>1__state = 0;
					<GetValues>d__ = this;
				}
				else
				{
					<GetValues>d__ = new global::Jint.Native.JsDictionaryObject.<GetValues>d__6(0);
					<GetValues>d__.<>4__this = this;
				}
				return <GetValues>d__;
			}

			// Token: 0x06000A2C RID: 2604 RVA: 0x00035BB4 File Offset: 0x00033DB4
			[global::System.Diagnostics.DebuggerHidden]
			global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
			{
				return this.System.Collections.Generic.IEnumerable<Jint.Native.JsInstance>.GetEnumerator();
			}

			// Token: 0x06000A2D RID: 2605 RVA: 0x00035BBC File Offset: 0x00033DBC
			bool global::System.Collections.IEnumerator.MoveNext()
			{
				bool result;
				try
				{
					switch (this.<>1__state)
					{
					case 0:
						this.<>1__state = -1;
						enumerator = this.properties.Values.GetEnumerator();
						this.<>1__state = 1;
						break;
					case 1:
						goto IL_AC;
					case 2:
						this.<>1__state = 1;
						break;
					default:
						goto IL_AC;
					}
					while (enumerator.MoveNext())
					{
						descriptor = enumerator.Current;
						if (descriptor.Enumerable)
						{
							this.<>2__current = descriptor.Get(this);
							this.<>1__state = 2;
							return true;
						}
					}
					this.<>m__Finally9();
					IL_AC:
					result = false;
				}
				catch
				{
					this.System.IDisposable.Dispose();
					throw;
				}
				return result;
			}

			// Token: 0x170001E7 RID: 487
			// (get) Token: 0x06000A2E RID: 2606 RVA: 0x00035C94 File Offset: 0x00033E94
			global::Jint.Native.JsInstance global::System.Collections.Generic.IEnumerator<global::Jint.Native.JsInstance>.Current
			{
				[global::System.Diagnostics.DebuggerHidden]
				get
				{
					return this.<>2__current;
				}
			}

			// Token: 0x06000A2F RID: 2607 RVA: 0x00035C9C File Offset: 0x00033E9C
			[global::System.Diagnostics.DebuggerHidden]
			void global::System.Collections.IEnumerator.Reset()
			{
				throw new global::System.NotSupportedException();
			}

			// Token: 0x06000A30 RID: 2608 RVA: 0x00035CA4 File Offset: 0x00033EA4
			void global::System.IDisposable.Dispose()
			{
				switch (this.<>1__state)
				{
				case 1:
				case 2:
					try
					{
					}
					finally
					{
						this.<>m__Finally9();
					}
					return;
				default:
					return;
				}
			}

			// Token: 0x170001E8 RID: 488
			// (get) Token: 0x06000A31 RID: 2609 RVA: 0x00035CE8 File Offset: 0x00033EE8
			object global::System.Collections.IEnumerator.Current
			{
				[global::System.Diagnostics.DebuggerHidden]
				get
				{
					return this.<>2__current;
				}
			}

			// Token: 0x06000A32 RID: 2610 RVA: 0x00035CF0 File Offset: 0x00033EF0
			[global::System.Diagnostics.DebuggerHidden]
			public <GetValues>d__6(int <>1__state)
			{
				this.<>1__state = <>1__state;
				this.<>l__initialThreadId = global::System.Threading.Thread.CurrentThread.ManagedThreadId;
			}

			// Token: 0x06000A33 RID: 2611 RVA: 0x00035D10 File Offset: 0x00033F10
			private void <>m__Finally9()
			{
				this.<>1__state = -1;
				if (enumerator != null)
				{
					enumerator.Dispose();
				}
			}

			// Token: 0x04000438 RID: 1080
			private global::Jint.Native.JsInstance <>2__current;

			// Token: 0x04000439 RID: 1081
			private int <>1__state;

			// Token: 0x0400043A RID: 1082
			private int <>l__initialThreadId;

			// Token: 0x0400043B RID: 1083
			public global::Jint.Native.JsDictionaryObject <>4__this;

			// Token: 0x0400043C RID: 1084
			public global::Jint.Native.Descriptor <descriptor>5__7;

			// Token: 0x0400043D RID: 1085
			public global::System.Collections.Generic.IEnumerator<global::Jint.Native.Descriptor> <>7__wrap8;
		}

		// Token: 0x020000E1 RID: 225
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private sealed class <GetKeys>d__c : global::System.Collections.Generic.IEnumerable<string>, global::System.Collections.IEnumerable, global::System.Collections.Generic.IEnumerator<string>, global::System.Collections.IEnumerator, global::System.IDisposable
		{
			// Token: 0x06000A34 RID: 2612 RVA: 0x00035D30 File Offset: 0x00033F30
			[global::System.Diagnostics.DebuggerHidden]
			global::System.Collections.Generic.IEnumerator<string> global::System.Collections.Generic.IEnumerable<string>.GetEnumerator()
			{
				global::Jint.Native.JsDictionaryObject.<GetKeys>d__c <GetKeys>d__c;
				if (global::System.Threading.Thread.CurrentThread.ManagedThreadId == this.<>l__initialThreadId && this.<>1__state == -2)
				{
					this.<>1__state = 0;
					<GetKeys>d__c = this;
				}
				else
				{
					<GetKeys>d__c = new global::Jint.Native.JsDictionaryObject.<GetKeys>d__c(0);
					<GetKeys>d__c.<>4__this = this;
				}
				return <GetKeys>d__c;
			}

			// Token: 0x06000A35 RID: 2613 RVA: 0x00035D88 File Offset: 0x00033F88
			[global::System.Diagnostics.DebuggerHidden]
			global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
			{
				return this.System.Collections.Generic.IEnumerable<System.String>.GetEnumerator();
			}

			// Token: 0x06000A36 RID: 2614 RVA: 0x00035D90 File Offset: 0x00033F90
			bool global::System.Collections.IEnumerator.MoveNext()
			{
				bool result;
				try
				{
					switch (this.<>1__state)
					{
					case 0:
						this.<>1__state = -1;
						p = this.Prototype;
						if (p == global::Jint.Native.JsUndefined.Instance || p == global::Jint.Native.JsNull.Instance || p == null)
						{
							goto IL_E6;
						}
						enumerator = p.GetKeys().GetEnumerator();
						this.<>1__state = 1;
						break;
					case 1:
					case 3:
						goto IL_18C;
					case 2:
						this.<>1__state = 1;
						break;
					case 4:
						this.<>1__state = 3;
						goto IL_179;
					default:
						goto IL_18C;
					}
					while (enumerator.MoveNext())
					{
						key = enumerator.Current;
						if (!this.HasOwnProperty(key))
						{
							this.<>2__current = key;
							this.<>1__state = 2;
							return true;
						}
					}
					this.<>m__Finally11();
					goto IL_E6;
					IL_179:
					while (enumerator2.MoveNext())
					{
						descriptor = enumerator2.Current;
						global::System.Collections.Generic.KeyValuePair<string, global::Jint.Native.Descriptor> keyValuePair = descriptor;
						if (keyValuePair.Value.Enumerable)
						{
							global::System.Collections.Generic.KeyValuePair<string, global::Jint.Native.Descriptor> keyValuePair2 = descriptor;
							if (keyValuePair2.Value.Owner == this)
							{
								global::System.Collections.Generic.KeyValuePair<string, global::Jint.Native.Descriptor> keyValuePair3 = descriptor;
								this.<>2__current = keyValuePair3.Key;
								this.<>1__state = 4;
								return true;
							}
						}
					}
					this.<>m__Finally13();
					goto IL_18C;
					IL_E6:
					enumerator2 = this.properties.GetEnumerator();
					this.<>1__state = 3;
					goto IL_179;
					IL_18C:
					result = false;
				}
				catch
				{
					this.System.IDisposable.Dispose();
					throw;
				}
				return result;
			}

			// Token: 0x170001E9 RID: 489
			// (get) Token: 0x06000A37 RID: 2615 RVA: 0x00035F54 File Offset: 0x00034154
			string global::System.Collections.Generic.IEnumerator<string>.Current
			{
				[global::System.Diagnostics.DebuggerHidden]
				get
				{
					return this.<>2__current;
				}
			}

			// Token: 0x06000A38 RID: 2616 RVA: 0x00035F5C File Offset: 0x0003415C
			[global::System.Diagnostics.DebuggerHidden]
			void global::System.Collections.IEnumerator.Reset()
			{
				throw new global::System.NotSupportedException();
			}

			// Token: 0x06000A39 RID: 2617 RVA: 0x00035F64 File Offset: 0x00034164
			void global::System.IDisposable.Dispose()
			{
				switch (this.<>1__state)
				{
				case 1:
				case 2:
					try
					{
					}
					finally
					{
						this.<>m__Finally11();
					}
					break;
				}
				switch (this.<>1__state)
				{
				case 3:
				case 4:
					try
					{
					}
					finally
					{
						this.<>m__Finally13();
					}
					return;
				default:
					return;
				}
			}

			// Token: 0x170001EA RID: 490
			// (get) Token: 0x06000A3A RID: 2618 RVA: 0x00035FDC File Offset: 0x000341DC
			object global::System.Collections.IEnumerator.Current
			{
				[global::System.Diagnostics.DebuggerHidden]
				get
				{
					return this.<>2__current;
				}
			}

			// Token: 0x06000A3B RID: 2619 RVA: 0x00035FE4 File Offset: 0x000341E4
			[global::System.Diagnostics.DebuggerHidden]
			public <GetKeys>d__c(int <>1__state)
			{
				this.<>1__state = <>1__state;
				this.<>l__initialThreadId = global::System.Threading.Thread.CurrentThread.ManagedThreadId;
			}

			// Token: 0x06000A3C RID: 2620 RVA: 0x00036004 File Offset: 0x00034204
			private void <>m__Finally11()
			{
				this.<>1__state = -1;
				if (enumerator != null)
				{
					enumerator.Dispose();
				}
			}

			// Token: 0x06000A3D RID: 2621 RVA: 0x00036024 File Offset: 0x00034224
			private void <>m__Finally13()
			{
				this.<>1__state = -1;
				if (enumerator2 != null)
				{
					enumerator2.Dispose();
				}
			}

			// Token: 0x0400043E RID: 1086
			private string <>2__current;

			// Token: 0x0400043F RID: 1087
			private int <>1__state;

			// Token: 0x04000440 RID: 1088
			private int <>l__initialThreadId;

			// Token: 0x04000441 RID: 1089
			public global::Jint.Native.JsDictionaryObject <>4__this;

			// Token: 0x04000442 RID: 1090
			public global::Jint.Native.JsDictionaryObject <p>5__d;

			// Token: 0x04000443 RID: 1091
			public string <key>5__e;

			// Token: 0x04000444 RID: 1092
			public global::System.Collections.Generic.KeyValuePair<string, global::Jint.Native.Descriptor> <descriptor>5__f;

			// Token: 0x04000445 RID: 1093
			public global::System.Collections.Generic.IEnumerator<string> <>7__wrap10;

			// Token: 0x04000446 RID: 1094
			public global::System.Collections.Generic.IEnumerator<global::System.Collections.Generic.KeyValuePair<string, global::Jint.Native.Descriptor>> <>7__wrap12;
		}
	}
}
