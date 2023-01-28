using System;

namespace Facepunch.Collections
{
	// Token: 0x020001A6 RID: 422
	public abstract class StaticQueue<KEY, T> where T : class
	{
		// Token: 0x06000C7E RID: 3198 RVA: 0x0002F82C File Offset: 0x0002DA2C
		protected StaticQueue()
		{
		}

		// Token: 0x06000C7F RID: 3199 RVA: 0x0002F834 File Offset: 0x0002DA34
		protected static bool validate(T instance, ref global::Facepunch.Collections.StaticQueue<KEY, T>.Entry state, bool must_be_contained = false)
		{
			return (!state.inside) ? (!must_be_contained) : (!object.ReferenceEquals(state.node, null) && object.ReferenceEquals(state.node.v, instance));
		}

		// Token: 0x06000C80 RID: 3200 RVA: 0x0002F884 File Offset: 0x0002DA84
		protected static bool contains(ref global::Facepunch.Collections.StaticQueue<KEY, T>.Entry state)
		{
			return state.inside;
		}

		// Token: 0x1700034A RID: 842
		// (get) Token: 0x06000C81 RID: 3201 RVA: 0x0002F88C File Offset: 0x0002DA8C
		protected static int num
		{
			get
			{
				return global::Facepunch.Collections.StaticQueue<KEY, T>.count;
			}
		}

		// Token: 0x06000C82 RID: 3202 RVA: 0x0002F894 File Offset: 0x0002DA94
		protected static bool enqueue(T instance, ref global::Facepunch.Collections.StaticQueue<KEY, T>.Entry state)
		{
			if (!state.inside)
			{
				state.inside = true;
				state.node = global::Facepunch.Collections.StaticQueue<KEY, T>.reg.insert_end(global::Facepunch.Collections.StaticQueue<KEY, T>.reg.make_node(instance));
				return true;
			}
			return false;
		}

		// Token: 0x06000C83 RID: 3203 RVA: 0x0002F8C8 File Offset: 0x0002DAC8
		protected static bool dequeue(T instance, ref global::Facepunch.Collections.StaticQueue<KEY, T>.Entry state)
		{
			if (state.inside)
			{
				state.inside = false;
				return global::Facepunch.Collections.StaticQueue<KEY, T>.reg.dispose(ref state.node);
			}
			return false;
		}

		// Token: 0x06000C84 RID: 3204 RVA: 0x0002F8EC File Offset: 0x0002DAEC
		protected static bool requeue(T instance, ref global::Facepunch.Collections.StaticQueue<KEY, T>.Entry state)
		{
			if (!state.inside)
			{
				return false;
			}
			if (object.ReferenceEquals(global::Facepunch.Collections.StaticQueue<KEY, T>.reg.last, state.node))
			{
				return true;
			}
			state.node = global::Facepunch.Collections.StaticQueue<KEY, T>.reg.insert_end(state.node);
			return true;
		}

		// Token: 0x06000C85 RID: 3205 RVA: 0x0002F930 File Offset: 0x0002DB30
		protected static bool enrequeue(T instance, ref global::Facepunch.Collections.StaticQueue<KEY, T>.Entry state)
		{
			return (!state.inside) ? global::Facepunch.Collections.StaticQueue<KEY, T>.enqueue(instance, ref state) : global::Facepunch.Collections.StaticQueue<KEY, T>.requeue(instance, ref state);
		}

		// Token: 0x06000C86 RID: 3206 RVA: 0x0002F950 File Offset: 0x0002DB50
		protected static bool requeue(T instance, ref global::Facepunch.Collections.StaticQueue<KEY, T>.Entry state, bool enqueue_if_missing)
		{
			return (!enqueue_if_missing) ? global::Facepunch.Collections.StaticQueue<KEY, T>.enqueue(instance, ref state) : global::Facepunch.Collections.StaticQueue<KEY, T>.enrequeue(instance, ref state);
		}

		// Token: 0x06000C87 RID: 3207 RVA: 0x0002F96C File Offset: 0x0002DB6C
		protected static void drain()
		{
			if (global::Facepunch.Collections.StaticQueue<KEY, T>.reg_made)
			{
				global::Facepunch.Collections.StaticQueue<KEY, T>.reg.drain();
			}
		}

		// Token: 0x04000824 RID: 2084
		private static bool reg_made;

		// Token: 0x04000825 RID: 2085
		private static int count;

		// Token: 0x020001A7 RID: 423
		internal struct way
		{
			// Token: 0x04000826 RID: 2086
			public global::Facepunch.Collections.StaticQueue<KEY, T>.node v;

			// Token: 0x04000827 RID: 2087
			public bool e;
		}

		// Token: 0x020001A8 RID: 424
		internal struct fork
		{
			// Token: 0x04000828 RID: 2088
			public global::Facepunch.Collections.StaticQueue<KEY, T>.way p;

			// Token: 0x04000829 RID: 2089
			public global::Facepunch.Collections.StaticQueue<KEY, T>.way n;
		}

		// Token: 0x020001A9 RID: 425
		internal class node
		{
			// Token: 0x06000C88 RID: 3208 RVA: 0x0002F980 File Offset: 0x0002DB80
			public node()
			{
			}

			// Token: 0x0400082A RID: 2090
			public T v;

			// Token: 0x0400082B RID: 2091
			public bool e;

			// Token: 0x0400082C RID: 2092
			public global::Facepunch.Collections.StaticQueue<KEY, T>.fork w;
		}

		// Token: 0x020001AA RID: 426
		private static class reg
		{
			// Token: 0x06000C89 RID: 3209 RVA: 0x0002F988 File Offset: 0x0002DB88
			static reg()
			{
				global::Facepunch.Collections.StaticQueue<KEY, T>.reg_made = true;
			}

			// Token: 0x06000C8A RID: 3210 RVA: 0x0002F990 File Offset: 0x0002DB90
			internal static global::Facepunch.Collections.StaticQueue<KEY, T>.node make_node(T v)
			{
				global::Facepunch.Collections.StaticQueue<KEY, T>.node node;
				if (global::Facepunch.Collections.StaticQueue<KEY, T>.reg.dump_size > 0)
				{
					global::Facepunch.Collections.StaticQueue<KEY, T>.reg.dump_size--;
					node = global::Facepunch.Collections.StaticQueue<KEY, T>.reg.dump;
					global::Facepunch.Collections.StaticQueue<KEY, T>.reg.dump = node.w.p.v;
					node.w = default(global::Facepunch.Collections.StaticQueue<KEY, T>.fork);
				}
				else
				{
					node = new global::Facepunch.Collections.StaticQueue<KEY, T>.node();
				}
				node.v = v;
				node.e = false;
				return node;
			}

			// Token: 0x06000C8B RID: 3211 RVA: 0x0002F9F8 File Offset: 0x0002DBF8
			internal static void delete(global::Facepunch.Collections.StaticQueue<KEY, T>.node r)
			{
				r.v = (T)((object)null);
				r.w.n = default(global::Facepunch.Collections.StaticQueue<KEY, T>.way);
				r.e = false;
				int num = global::Facepunch.Collections.StaticQueue<KEY, T>.reg.dump_size;
				global::Facepunch.Collections.StaticQueue<KEY, T>.reg.dump_size = num + 1;
				r.w.p.e = (num > 0);
				r.w.p.v = global::Facepunch.Collections.StaticQueue<KEY, T>.reg.dump;
				global::Facepunch.Collections.StaticQueue<KEY, T>.reg.dump = r;
			}

			// Token: 0x06000C8C RID: 3212 RVA: 0x0002FA68 File Offset: 0x0002DC68
			internal static global::Facepunch.Collections.StaticQueue<KEY, T>.node insert_begin(global::Facepunch.Collections.StaticQueue<KEY, T>.node node)
			{
				if (node.e)
				{
					global::Facepunch.Collections.StaticQueue<KEY, T>.reg.deref(node);
				}
				int count = global::Facepunch.Collections.StaticQueue<KEY, T>.count;
				global::Facepunch.Collections.StaticQueue<KEY, T>.count = count + 1;
				if (count == 0)
				{
					global::Facepunch.Collections.StaticQueue<KEY, T>.reg.first = node;
					global::Facepunch.Collections.StaticQueue<KEY, T>.reg.last = node;
				}
				else
				{
					node.w.n.e = true;
					node.w.n.v = global::Facepunch.Collections.StaticQueue<KEY, T>.reg.first;
					global::Facepunch.Collections.StaticQueue<KEY, T>.reg.first.w.p.e = true;
					global::Facepunch.Collections.StaticQueue<KEY, T>.reg.first.w.p.v = node;
					global::Facepunch.Collections.StaticQueue<KEY, T>.reg.first = node;
				}
				node.e = true;
				return global::Facepunch.Collections.StaticQueue<KEY, T>.reg.first;
			}

			// Token: 0x06000C8D RID: 3213 RVA: 0x0002FB0C File Offset: 0x0002DD0C
			internal static global::Facepunch.Collections.StaticQueue<KEY, T>.node insert_end(global::Facepunch.Collections.StaticQueue<KEY, T>.node node)
			{
				if (node.e)
				{
					global::Facepunch.Collections.StaticQueue<KEY, T>.reg.deref(node);
				}
				int count = global::Facepunch.Collections.StaticQueue<KEY, T>.count;
				global::Facepunch.Collections.StaticQueue<KEY, T>.count = count + 1;
				if (count == 0)
				{
					global::Facepunch.Collections.StaticQueue<KEY, T>.reg.first = node;
					global::Facepunch.Collections.StaticQueue<KEY, T>.reg.last = node;
				}
				else
				{
					node.w.p.e = true;
					node.w.p.v = global::Facepunch.Collections.StaticQueue<KEY, T>.reg.last;
					global::Facepunch.Collections.StaticQueue<KEY, T>.reg.last.w.n.e = true;
					global::Facepunch.Collections.StaticQueue<KEY, T>.reg.last.w.n.v = node;
					global::Facepunch.Collections.StaticQueue<KEY, T>.reg.last = node;
				}
				node.e = true;
				return global::Facepunch.Collections.StaticQueue<KEY, T>.reg.last;
			}

			// Token: 0x06000C8E RID: 3214 RVA: 0x0002FBB0 File Offset: 0x0002DDB0
			internal static bool deref(global::Facepunch.Collections.StaticQueue<KEY, T>.node node)
			{
				if (object.ReferenceEquals(node, null))
				{
					return false;
				}
				if (node.e)
				{
					if (--global::Facepunch.Collections.StaticQueue<KEY, T>.count == 0)
					{
						global::Facepunch.Collections.StaticQueue<KEY, T>.reg.first = (global::Facepunch.Collections.StaticQueue<KEY, T>.reg.last = null);
					}
					else
					{
						if (node.w.p.e)
						{
							node.w.p.v.w.n = node.w.n;
						}
						else if (node.w.n.e)
						{
							global::Facepunch.Collections.StaticQueue<KEY, T>.reg.first = node.w.n.v;
						}
						if (node.w.n.e)
						{
							node.w.n.v.w.p = node.w.p;
						}
						else if (node.w.p.e)
						{
							global::Facepunch.Collections.StaticQueue<KEY, T>.reg.last = node.w.p.v;
						}
						node.w = default(global::Facepunch.Collections.StaticQueue<KEY, T>.fork);
					}
					node.e = false;
					return true;
				}
				return false;
			}

			// Token: 0x06000C8F RID: 3215 RVA: 0x0002FCE4 File Offset: 0x0002DEE4
			internal static bool dispose(ref global::Facepunch.Collections.StaticQueue<KEY, T>.node node)
			{
				if (global::Facepunch.Collections.StaticQueue<KEY, T>.reg.deref(node))
				{
					node.v = (T)((object)null);
					global::Facepunch.Collections.StaticQueue<KEY, T>.reg.delete(node);
					node = null;
					return true;
				}
				return false;
			}

			// Token: 0x06000C90 RID: 3216 RVA: 0x0002FD18 File Offset: 0x0002DF18
			public static void drain()
			{
				global::Facepunch.Collections.StaticQueue<KEY, T>.reg.dump = null;
				global::Facepunch.Collections.StaticQueue<KEY, T>.reg.dump_size = 0;
			}

			// Token: 0x0400082D RID: 2093
			private static int dump_size;

			// Token: 0x0400082E RID: 2094
			private static global::Facepunch.Collections.StaticQueue<KEY, T>.node dump;

			// Token: 0x0400082F RID: 2095
			internal static global::Facepunch.Collections.StaticQueue<KEY, T>.node first;

			// Token: 0x04000830 RID: 2096
			internal static global::Facepunch.Collections.StaticQueue<KEY, T>.node last;
		}

		// Token: 0x020001AB RID: 427
		protected enum act
		{
			// Token: 0x04000832 RID: 2098
			none,
			// Token: 0x04000833 RID: 2099
			front,
			// Token: 0x04000834 RID: 2100
			back,
			// Token: 0x04000835 RID: 2101
			delist
		}

		// Token: 0x020001AC RID: 428
		protected struct iterator
		{
			// Token: 0x06000C91 RID: 3217 RVA: 0x0002FD28 File Offset: 0x0002DF28
			public iterator(int maxIterations, int maxFailedIterations)
			{
				if (maxIterations == 0 || maxIterations > global::Facepunch.Collections.StaticQueue<KEY, T>.count)
				{
					this.attempts = global::Facepunch.Collections.StaticQueue<KEY, T>.count;
					this.fail_left = 0;
				}
				else if (maxIterations == global::Facepunch.Collections.StaticQueue<KEY, T>.count)
				{
					this.attempts = global::Facepunch.Collections.StaticQueue<KEY, T>.count;
					this.fail_left = 0;
				}
				else if (maxIterations + maxFailedIterations > global::Facepunch.Collections.StaticQueue<KEY, T>.count)
				{
					this.attempts = maxIterations;
					this.fail_left = global::Facepunch.Collections.StaticQueue<KEY, T>.count - maxIterations;
				}
				else
				{
					this.attempts = maxIterations;
					this.fail_left = maxFailedIterations;
				}
				this.position = 0;
				this.node = null;
				this.next = ((!global::Facepunch.Collections.StaticQueue<KEY, T>.reg_made) ? null : global::Facepunch.Collections.StaticQueue<KEY, T>.reg.first);
			}

			// Token: 0x06000C92 RID: 3218 RVA: 0x0002FDDC File Offset: 0x0002DFDC
			public iterator(int maxIter)
			{
				this = new global::Facepunch.Collections.StaticQueue<KEY, T>.iterator(maxIter, (maxIter >= global::Facepunch.Collections.StaticQueue<KEY, T>.count) ? 0 : (global::Facepunch.Collections.StaticQueue<KEY, T>.count - maxIter));
			}

			// Token: 0x06000C93 RID: 3219 RVA: 0x0002FE00 File Offset: 0x0002E000
			public bool Start(out T v)
			{
				if (this.position++ < this.attempts)
				{
					this.node = this.next;
					this.next = this.node.w.n.v;
					v = this.node.v;
					return true;
				}
				this.node = (this.next = null);
				v = (T)((object)null);
				return false;
			}

			// Token: 0x06000C94 RID: 3220 RVA: 0x0002FE80 File Offset: 0x0002E080
			public bool Validate(ref global::Facepunch.Collections.StaticQueue<KEY, T>.Entry key)
			{
				return key.inside;
			}

			// Token: 0x06000C95 RID: 3221 RVA: 0x0002FE88 File Offset: 0x0002E088
			public bool MissingNext(out T v)
			{
				if (this.fail_left-- > 0)
				{
					this.position--;
				}
				global::Facepunch.Collections.StaticQueue<KEY, T>.reg.dispose(ref this.node);
				return this.Start(out v);
			}

			// Token: 0x06000C96 RID: 3222 RVA: 0x0002FED0 File Offset: 0x0002E0D0
			public bool Next(ref global::Facepunch.Collections.StaticQueue<KEY, T>.Entry prev_key, global::Facepunch.Collections.StaticQueue<KEY, T>.act cmd, out T v)
			{
				bool flag = object.ReferenceEquals(prev_key.node, null);
				if (!flag && !object.ReferenceEquals(prev_key.node, this.node))
				{
					throw new global::System.ArgumentException("prev_key did not match that of what was expected", "prev_key");
				}
				if (flag)
				{
					prev_key.inside = false;
				}
				if (!prev_key.inside)
				{
					cmd = global::Facepunch.Collections.StaticQueue<KEY, T>.act.delist;
					if (this.fail_left-- > 0)
					{
						this.position--;
					}
					if (flag)
					{
						global::Facepunch.Collections.StaticQueue<KEY, T>.reg.dispose(ref this.node);
					}
					else
					{
						global::Facepunch.Collections.StaticQueue<KEY, T>.reg.dispose(ref prev_key.node);
					}
				}
				else
				{
					switch (cmd)
					{
					case global::Facepunch.Collections.StaticQueue<KEY, T>.act.front:
						if (global::Facepunch.Collections.StaticQueue<KEY, T>.reg.deref(this.node))
						{
							prev_key.node = global::Facepunch.Collections.StaticQueue<KEY, T>.reg.insert_begin(this.node);
						}
						break;
					case global::Facepunch.Collections.StaticQueue<KEY, T>.act.back:
						if (global::Facepunch.Collections.StaticQueue<KEY, T>.reg.deref(this.node))
						{
							prev_key.node = global::Facepunch.Collections.StaticQueue<KEY, T>.reg.insert_end(this.node);
						}
						break;
					case global::Facepunch.Collections.StaticQueue<KEY, T>.act.delist:
						global::Facepunch.Collections.StaticQueue<KEY, T>.reg.dispose(ref this.node);
						prev_key.node = null;
						break;
					}
				}
				return this.Start(out v);
			}

			// Token: 0x04000836 RID: 2102
			private int attempts;

			// Token: 0x04000837 RID: 2103
			private int fail_left;

			// Token: 0x04000838 RID: 2104
			private int position;

			// Token: 0x04000839 RID: 2105
			private global::Facepunch.Collections.StaticQueue<KEY, T>.node node;

			// Token: 0x0400083A RID: 2106
			private global::Facepunch.Collections.StaticQueue<KEY, T>.node next;
		}

		// Token: 0x020001AD RID: 429
		public struct Entry
		{
			// Token: 0x0400083B RID: 2107
			internal bool inside;

			// Token: 0x0400083C RID: 2108
			internal global::Facepunch.Collections.StaticQueue<KEY, T>.node node;
		}
	}
}
