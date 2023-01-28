using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using Jint.Marshal;

namespace Jint.Native
{
	// Token: 0x02000062 RID: 98
	[global::System.Serializable]
	public sealed class JsArray : global::Jint.Native.JsObject
	{
		// Token: 0x060004EF RID: 1263 RVA: 0x000272D4 File Offset: 0x000254D4
		public JsArray(global::Jint.Native.JsObject prototype) : base(prototype)
		{
		}

		// Token: 0x060004F0 RID: 1264 RVA: 0x000272E8 File Offset: 0x000254E8
		private JsArray(global::System.Collections.Generic.SortedList<int, global::Jint.Native.JsInstance> data, int len, global::Jint.Native.JsObject prototype) : base(prototype)
		{
			this.m_data = data;
			this.length = len;
		}

		// Token: 0x170000DB RID: 219
		// (get) Token: 0x060004F1 RID: 1265 RVA: 0x0002730C File Offset: 0x0002550C
		public override bool IsClr
		{
			get
			{
				return false;
			}
		}

		// Token: 0x170000DC RID: 220
		// (get) Token: 0x060004F2 RID: 1266 RVA: 0x00027310 File Offset: 0x00025510
		public override string Class
		{
			get
			{
				return "Array";
			}
		}

		// Token: 0x060004F3 RID: 1267 RVA: 0x00027318 File Offset: 0x00025518
		public override bool ToBoolean()
		{
			return true;
		}

		// Token: 0x170000DD RID: 221
		// (get) Token: 0x060004F4 RID: 1268 RVA: 0x0002731C File Offset: 0x0002551C
		// (set) Token: 0x060004F5 RID: 1269 RVA: 0x00027324 File Offset: 0x00025524
		public override int Length
		{
			get
			{
				return this.length;
			}
			set
			{
				this.setLength(value);
			}
		}

		// Token: 0x170000DE RID: 222
		public override global::Jint.Native.JsInstance this[string index]
		{
			get
			{
				int i;
				if (int.TryParse(index, out i))
				{
					return this.get(i);
				}
				return base[index];
			}
			set
			{
				int i;
				if (int.TryParse(index, out i))
				{
					this.put(i, value);
					return;
				}
				base[index] = value;
			}
		}

		// Token: 0x170000DF RID: 223
		public override global::Jint.Native.JsInstance this[global::Jint.Native.JsInstance key]
		{
			get
			{
				double num = key.ToNumber();
				int num2 = (int)num;
				if ((double)num2 == num && num2 >= 0)
				{
					return this.get(num2);
				}
				return base[key.ToString()];
			}
			set
			{
				double num = key.ToNumber();
				int num2 = (int)num;
				if ((double)num2 == num && num2 >= 0)
				{
					this.put(num2, value);
					return;
				}
				base[key.ToString()] = value;
			}
		}

		// Token: 0x060004FA RID: 1274 RVA: 0x00027414 File Offset: 0x00025614
		public override void DefineOwnProperty(global::Jint.Native.Descriptor d)
		{
			int i;
			if (int.TryParse(d.Name, out i))
			{
				this.put(i, d.Get(this));
				return;
			}
			base.DefineOwnProperty(d);
		}

		// Token: 0x060004FB RID: 1275 RVA: 0x00027450 File Offset: 0x00025650
		public global::Jint.Native.JsInstance get(int i)
		{
			global::Jint.Native.JsInstance jsInstance;
			if (!this.m_data.TryGetValue(i, out jsInstance) || jsInstance == null)
			{
				return global::Jint.Native.JsUndefined.Instance;
			}
			return jsInstance;
		}

		// Token: 0x060004FC RID: 1276 RVA: 0x00027484 File Offset: 0x00025684
		public global::Jint.Native.JsInstance put(int i, global::Jint.Native.JsInstance value)
		{
			if (i >= this.length)
			{
				this.length = i + 1;
			}
			this.m_data[i] = value;
			return value;
		}

		// Token: 0x060004FD RID: 1277 RVA: 0x000274BC File Offset: 0x000256BC
		private void setLength(int newLength)
		{
			if (newLength < 0)
			{
				throw new global::System.ArgumentOutOfRangeException("New length is out of range");
			}
			if (newLength < this.length)
			{
				int num = this.FindKeyOrNext(newLength);
				if (num >= 0)
				{
					for (int i = this.m_data.Count - 1; i >= num; i--)
					{
						this.m_data.RemoveAt(i);
					}
				}
			}
			this.length = newLength;
		}

		// Token: 0x060004FE RID: 1278 RVA: 0x00027528 File Offset: 0x00025728
		public override bool TryGetProperty(string key, out global::Jint.Native.JsInstance result)
		{
			result = global::Jint.Native.JsUndefined.Instance;
			int value;
			if (int.TryParse(key, out value))
			{
				return this.m_data.TryGetValue(global::System.Convert.ToInt32(value), out result);
			}
			return base.TryGetProperty(key, out result);
		}

		// Token: 0x060004FF RID: 1279 RVA: 0x00027568 File Offset: 0x00025768
		private int FindKeyOrNext(int key)
		{
			int i = 0;
			int num = this.m_data.Count - 1;
			int num2 = 0;
			while (i <= num)
			{
				int num3 = this.m_data.Keys[num2];
				if (num3 == key)
				{
					return num2;
				}
				if (num3 > key)
				{
					num = num2 - 1;
				}
				else
				{
					i = num2 + 1;
				}
				num2 = (i + num) / 2;
			}
			if (i >= this.m_data.Count)
			{
				return -1;
			}
			return i;
		}

		// Token: 0x06000500 RID: 1280 RVA: 0x000275E0 File Offset: 0x000257E0
		private int FindKeyOrPrev(int key)
		{
			int i = 0;
			int num = this.m_data.Count - 1;
			int num2 = 0;
			while (i <= num)
			{
				int num3 = this.m_data.Keys[num2];
				if (num3 == key)
				{
					return num2;
				}
				if (num3 > key)
				{
					num = num2 - 1;
				}
				else
				{
					i = num2 + 1;
				}
				num2 = (i + num) / 2;
			}
			return num;
		}

		// Token: 0x06000501 RID: 1281 RVA: 0x00027644 File Offset: 0x00025844
		public override void Delete(global::Jint.Native.JsInstance key)
		{
			double num = key.ToNumber();
			int num2 = (int)num;
			if ((double)num2 == num)
			{
				this.m_data.Remove(num2);
				return;
			}
			base.Delete(key.ToString());
		}

		// Token: 0x06000502 RID: 1282 RVA: 0x00027684 File Offset: 0x00025884
		public override void Delete(string key)
		{
			int key2;
			if (int.TryParse(key, out key2))
			{
				this.m_data.Remove(key2);
				return;
			}
			base.Delete(key);
		}

		// Token: 0x06000503 RID: 1283 RVA: 0x000276B8 File Offset: 0x000258B8
		[global::Jint.Marshal.RawJsMethod]
		public global::Jint.Native.JsArray concat(global::Jint.Native.IGlobal global, global::Jint.Native.JsInstance[] args)
		{
			global::System.Collections.Generic.SortedList<int, global::Jint.Native.JsInstance> sortedList = new global::System.Collections.Generic.SortedList<int, global::Jint.Native.JsInstance>(this.m_data);
			int num = this.length;
			foreach (global::Jint.Native.JsInstance jsInstance in args)
			{
				if (jsInstance is global::Jint.Native.JsArray)
				{
					foreach (global::System.Collections.Generic.KeyValuePair<int, global::Jint.Native.JsInstance> keyValuePair in ((global::Jint.Native.JsArray)jsInstance).m_data)
					{
						sortedList.Add(keyValuePair.Key + num, keyValuePair.Value);
					}
					num += ((global::Jint.Native.JsArray)jsInstance).Length;
				}
				else if (global.ArrayClass.HasInstance(jsInstance as global::Jint.Native.JsObject))
				{
					global::Jint.Native.JsObject jsObject = (global::Jint.Native.JsObject)jsInstance;
					for (int j = 0; j < jsObject.Length; j++)
					{
						global::Jint.Native.JsInstance value;
						if (jsObject.TryGetProperty(j.ToString(), out value))
						{
							sortedList.Add(num + j, value);
						}
					}
				}
				else
				{
					sortedList.Add(num, jsInstance);
					num++;
				}
			}
			return new global::Jint.Native.JsArray(sortedList, num, global.ArrayClass.PrototypeProperty);
		}

		// Token: 0x06000504 RID: 1284 RVA: 0x000277FC File Offset: 0x000259FC
		[global::Jint.Marshal.RawJsMethod]
		public global::Jint.Native.JsString join(global::Jint.Native.IGlobal global, global::Jint.Native.JsInstance separator)
		{
			if (this.length == 0)
			{
				return global.StringClass.New();
			}
			string separator2 = (separator == global::Jint.Native.JsUndefined.Instance) ? "," : separator.ToString();
			string[] array = new string[this.length];
			for (int i = 0; i < this.length; i++)
			{
				global::Jint.Native.JsInstance jsInstance;
				array[i] = ((this.m_data.TryGetValue(i, out jsInstance) && jsInstance != global::Jint.Native.JsNull.Instance && jsInstance != global::Jint.Native.JsUndefined.Instance) ? jsInstance.ToString() : "");
			}
			return global.StringClass.New(string.Join(separator2, array));
		}

		// Token: 0x06000505 RID: 1285 RVA: 0x000278B0 File Offset: 0x00025AB0
		public override string ToString()
		{
			global::System.Collections.Generic.IList<global::Jint.Native.JsInstance> values = this.m_data.Values;
			string[] array = new string[values.Count];
			for (int i = 0; i < values.Count; i++)
			{
				if (values[i] != null)
				{
					array[i] = values[i].ToString();
				}
			}
			return string.Join(",", array);
		}

		// Token: 0x06000506 RID: 1286 RVA: 0x00027918 File Offset: 0x00025B18
		public override global::Jint.Native.JsInstance ToPrimitive(global::Jint.Native.IGlobal global)
		{
			if (global == null)
			{
				throw new global::System.ArgumentNullException();
			}
			return global.StringClass.New(this.ToString());
		}

		// Token: 0x06000507 RID: 1287 RVA: 0x00027938 File Offset: 0x00025B38
		private global::System.Collections.Generic.IEnumerable<string> baseGetKeys()
		{
			return base.GetKeys();
		}

		// Token: 0x06000508 RID: 1288 RVA: 0x00027940 File Offset: 0x00025B40
		public override global::System.Collections.Generic.IEnumerable<string> GetKeys()
		{
			global::System.Collections.Generic.IList<int> keys = this.m_data.Keys;
			for (int i = 0; i < keys.Count; i++)
			{
				yield return keys[i].ToString();
			}
			foreach (string key in this.baseGetKeys())
			{
				yield return key;
			}
			yield break;
		}

		// Token: 0x06000509 RID: 1289 RVA: 0x00027964 File Offset: 0x00025B64
		private global::System.Collections.Generic.IEnumerable<global::Jint.Native.JsInstance> baseGetValues()
		{
			return base.GetValues();
		}

		// Token: 0x0600050A RID: 1290 RVA: 0x0002796C File Offset: 0x00025B6C
		public override global::System.Collections.Generic.IEnumerable<global::Jint.Native.JsInstance> GetValues()
		{
			global::System.Collections.Generic.IList<global::Jint.Native.JsInstance> vals = this.m_data.Values;
			for (int i = 0; i < vals.Count; i++)
			{
				yield return vals[i];
			}
			foreach (global::Jint.Native.JsInstance val in this.baseGetValues())
			{
				yield return val;
			}
			yield break;
		}

		// Token: 0x0600050B RID: 1291 RVA: 0x00027990 File Offset: 0x00025B90
		public override bool HasOwnProperty(string key)
		{
			int num;
			if (int.TryParse(key, out num))
			{
				return num >= 0 && num < this.length && this.m_data.ContainsKey(num);
			}
			return base.HasOwnProperty(key);
		}

		// Token: 0x0600050C RID: 1292 RVA: 0x000279D8 File Offset: 0x00025BD8
		public override double ToNumber()
		{
			return (double)this.Length;
		}

		// Token: 0x0600050D RID: 1293 RVA: 0x000279E4 File Offset: 0x00025BE4
		public override bool Equals(object obj)
		{
			return this == obj;
		}

		// Token: 0x04000241 RID: 577
		private int length;

		// Token: 0x04000242 RID: 578
		private global::System.Collections.Generic.SortedList<int, global::Jint.Native.JsInstance> m_data = new global::System.Collections.Generic.SortedList<int, global::Jint.Native.JsInstance>();

		// Token: 0x02000152 RID: 338
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private sealed class <GetKeys>d__0 : global::System.Collections.Generic.IEnumerable<string>, global::System.Collections.IEnumerable, global::System.Collections.Generic.IEnumerator<string>, global::System.Collections.IEnumerator, global::System.IDisposable
		{
			// Token: 0x06000BFC RID: 3068 RVA: 0x0003C464 File Offset: 0x0003A664
			[global::System.Diagnostics.DebuggerHidden]
			global::System.Collections.Generic.IEnumerator<string> global::System.Collections.Generic.IEnumerable<string>.GetEnumerator()
			{
				global::Jint.Native.JsArray.<GetKeys>d__0 <GetKeys>d__;
				if (global::System.Threading.Thread.CurrentThread.ManagedThreadId == this.<>l__initialThreadId && this.<>1__state == -2)
				{
					this.<>1__state = 0;
					<GetKeys>d__ = this;
				}
				else
				{
					<GetKeys>d__ = new global::Jint.Native.JsArray.<GetKeys>d__0(0);
					<GetKeys>d__.<>4__this = this;
				}
				return <GetKeys>d__;
			}

			// Token: 0x06000BFD RID: 3069 RVA: 0x0003C4BC File Offset: 0x0003A6BC
			[global::System.Diagnostics.DebuggerHidden]
			global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
			{
				return this.System.Collections.Generic.IEnumerable<System.String>.GetEnumerator();
			}

			// Token: 0x06000BFE RID: 3070 RVA: 0x0003C4C4 File Offset: 0x0003A6C4
			bool global::System.Collections.IEnumerator.MoveNext()
			{
				bool result;
				try
				{
					switch (this.<>1__state)
					{
					case 0:
						this.<>1__state = -1;
						keys = this.m_data.Keys;
						i = 0;
						break;
					case 1:
						this.<>1__state = -1;
						i++;
						break;
					case 2:
						goto IL_107;
					case 3:
						this.<>1__state = 2;
						goto IL_F4;
					default:
						goto IL_107;
					}
					if (i < keys.Count)
					{
						this.<>2__current = keys[i].ToString();
						this.<>1__state = 1;
						return true;
					}
					enumerator = this.baseGetKeys().GetEnumerator();
					this.<>1__state = 2;
					IL_F4:
					if (enumerator.MoveNext())
					{
						key = enumerator.Current;
						this.<>2__current = key;
						this.<>1__state = 3;
						return true;
					}
					this.<>m__Finally5();
					IL_107:
					result = false;
				}
				catch
				{
					this.System.IDisposable.Dispose();
					throw;
				}
				return result;
			}

			// Token: 0x170002A8 RID: 680
			// (get) Token: 0x06000BFF RID: 3071 RVA: 0x0003C604 File Offset: 0x0003A804
			string global::System.Collections.Generic.IEnumerator<string>.Current
			{
				[global::System.Diagnostics.DebuggerHidden]
				get
				{
					return this.<>2__current;
				}
			}

			// Token: 0x06000C00 RID: 3072 RVA: 0x0003C60C File Offset: 0x0003A80C
			[global::System.Diagnostics.DebuggerHidden]
			void global::System.Collections.IEnumerator.Reset()
			{
				throw new global::System.NotSupportedException();
			}

			// Token: 0x06000C01 RID: 3073 RVA: 0x0003C614 File Offset: 0x0003A814
			void global::System.IDisposable.Dispose()
			{
				switch (this.<>1__state)
				{
				case 2:
				case 3:
					try
					{
					}
					finally
					{
						this.<>m__Finally5();
					}
					return;
				default:
					return;
				}
			}

			// Token: 0x170002A9 RID: 681
			// (get) Token: 0x06000C02 RID: 3074 RVA: 0x0003C658 File Offset: 0x0003A858
			object global::System.Collections.IEnumerator.Current
			{
				[global::System.Diagnostics.DebuggerHidden]
				get
				{
					return this.<>2__current;
				}
			}

			// Token: 0x06000C03 RID: 3075 RVA: 0x0003C660 File Offset: 0x0003A860
			[global::System.Diagnostics.DebuggerHidden]
			public <GetKeys>d__0(int <>1__state)
			{
				this.<>1__state = <>1__state;
				this.<>l__initialThreadId = global::System.Threading.Thread.CurrentThread.ManagedThreadId;
			}

			// Token: 0x06000C04 RID: 3076 RVA: 0x0003C680 File Offset: 0x0003A880
			private void <>m__Finally5()
			{
				this.<>1__state = -1;
				if (enumerator != null)
				{
					enumerator.Dispose();
				}
			}

			// Token: 0x040006D2 RID: 1746
			private string <>2__current;

			// Token: 0x040006D3 RID: 1747
			private int <>1__state;

			// Token: 0x040006D4 RID: 1748
			private int <>l__initialThreadId;

			// Token: 0x040006D5 RID: 1749
			public global::Jint.Native.JsArray <>4__this;

			// Token: 0x040006D6 RID: 1750
			public global::System.Collections.Generic.IList<int> <keys>5__1;

			// Token: 0x040006D7 RID: 1751
			public int <i>5__2;

			// Token: 0x040006D8 RID: 1752
			public string <key>5__3;

			// Token: 0x040006D9 RID: 1753
			public global::System.Collections.Generic.IEnumerator<string> <>7__wrap4;
		}

		// Token: 0x02000153 RID: 339
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private sealed class <GetValues>d__8 : global::System.Collections.Generic.IEnumerable<global::Jint.Native.JsInstance>, global::System.Collections.IEnumerable, global::System.Collections.Generic.IEnumerator<global::Jint.Native.JsInstance>, global::System.Collections.IEnumerator, global::System.IDisposable
		{
			// Token: 0x06000C05 RID: 3077 RVA: 0x0003C6A0 File Offset: 0x0003A8A0
			[global::System.Diagnostics.DebuggerHidden]
			global::System.Collections.Generic.IEnumerator<global::Jint.Native.JsInstance> global::System.Collections.Generic.IEnumerable<global::Jint.Native.JsInstance>.GetEnumerator()
			{
				global::Jint.Native.JsArray.<GetValues>d__8 <GetValues>d__;
				if (global::System.Threading.Thread.CurrentThread.ManagedThreadId == this.<>l__initialThreadId && this.<>1__state == -2)
				{
					this.<>1__state = 0;
					<GetValues>d__ = this;
				}
				else
				{
					<GetValues>d__ = new global::Jint.Native.JsArray.<GetValues>d__8(0);
					<GetValues>d__.<>4__this = this;
				}
				return <GetValues>d__;
			}

			// Token: 0x06000C06 RID: 3078 RVA: 0x0003C6F8 File Offset: 0x0003A8F8
			[global::System.Diagnostics.DebuggerHidden]
			global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
			{
				return this.System.Collections.Generic.IEnumerable<Jint.Native.JsInstance>.GetEnumerator();
			}

			// Token: 0x06000C07 RID: 3079 RVA: 0x0003C700 File Offset: 0x0003A900
			bool global::System.Collections.IEnumerator.MoveNext()
			{
				bool result;
				try
				{
					switch (this.<>1__state)
					{
					case 0:
						this.<>1__state = -1;
						vals = this.m_data.Values;
						i = 0;
						break;
					case 1:
						this.<>1__state = -1;
						i++;
						break;
					case 2:
						goto IL_FF;
					case 3:
						this.<>1__state = 2;
						goto IL_EC;
					default:
						goto IL_FF;
					}
					if (i < vals.Count)
					{
						this.<>2__current = vals[i];
						this.<>1__state = 1;
						return true;
					}
					enumerator = this.baseGetValues().GetEnumerator();
					this.<>1__state = 2;
					IL_EC:
					if (enumerator.MoveNext())
					{
						val = enumerator.Current;
						this.<>2__current = val;
						this.<>1__state = 3;
						return true;
					}
					this.<>m__Finallyd();
					IL_FF:
					result = false;
				}
				catch
				{
					this.System.IDisposable.Dispose();
					throw;
				}
				return result;
			}

			// Token: 0x170002AA RID: 682
			// (get) Token: 0x06000C08 RID: 3080 RVA: 0x0003C838 File Offset: 0x0003AA38
			global::Jint.Native.JsInstance global::System.Collections.Generic.IEnumerator<global::Jint.Native.JsInstance>.Current
			{
				[global::System.Diagnostics.DebuggerHidden]
				get
				{
					return this.<>2__current;
				}
			}

			// Token: 0x06000C09 RID: 3081 RVA: 0x0003C840 File Offset: 0x0003AA40
			[global::System.Diagnostics.DebuggerHidden]
			void global::System.Collections.IEnumerator.Reset()
			{
				throw new global::System.NotSupportedException();
			}

			// Token: 0x06000C0A RID: 3082 RVA: 0x0003C848 File Offset: 0x0003AA48
			void global::System.IDisposable.Dispose()
			{
				switch (this.<>1__state)
				{
				case 2:
				case 3:
					try
					{
					}
					finally
					{
						this.<>m__Finallyd();
					}
					return;
				default:
					return;
				}
			}

			// Token: 0x170002AB RID: 683
			// (get) Token: 0x06000C0B RID: 3083 RVA: 0x0003C88C File Offset: 0x0003AA8C
			object global::System.Collections.IEnumerator.Current
			{
				[global::System.Diagnostics.DebuggerHidden]
				get
				{
					return this.<>2__current;
				}
			}

			// Token: 0x06000C0C RID: 3084 RVA: 0x0003C894 File Offset: 0x0003AA94
			[global::System.Diagnostics.DebuggerHidden]
			public <GetValues>d__8(int <>1__state)
			{
				this.<>1__state = <>1__state;
				this.<>l__initialThreadId = global::System.Threading.Thread.CurrentThread.ManagedThreadId;
			}

			// Token: 0x06000C0D RID: 3085 RVA: 0x0003C8B4 File Offset: 0x0003AAB4
			private void <>m__Finallyd()
			{
				this.<>1__state = -1;
				if (enumerator != null)
				{
					enumerator.Dispose();
				}
			}

			// Token: 0x040006DA RID: 1754
			private global::Jint.Native.JsInstance <>2__current;

			// Token: 0x040006DB RID: 1755
			private int <>1__state;

			// Token: 0x040006DC RID: 1756
			private int <>l__initialThreadId;

			// Token: 0x040006DD RID: 1757
			public global::Jint.Native.JsArray <>4__this;

			// Token: 0x040006DE RID: 1758
			public global::System.Collections.Generic.IList<global::Jint.Native.JsInstance> <vals>5__9;

			// Token: 0x040006DF RID: 1759
			public int <i>5__a;

			// Token: 0x040006E0 RID: 1760
			public global::Jint.Native.JsInstance <val>5__b;

			// Token: 0x040006E1 RID: 1761
			public global::System.Collections.Generic.IEnumerator<global::Jint.Native.JsInstance> <>7__wrapc;
		}
	}
}
