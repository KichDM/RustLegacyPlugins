using System;
using System.Collections;
using System.Collections.Generic;
using Jint.Native;

namespace Jint.PropertyBags
{
	// Token: 0x0200008A RID: 138
	public class ScopedPropertyBag : global::Jint.IPropertyBag, global::System.Collections.Generic.IEnumerable<global::System.Collections.Generic.KeyValuePair<string, global::Jint.Native.Descriptor>>, global::System.Collections.IEnumerable
	{
		// Token: 0x06000615 RID: 1557 RVA: 0x0002B4F4 File Offset: 0x000296F4
		public void EnterScope()
		{
			this.currentScope = new global::System.Collections.Generic.List<global::System.Collections.Generic.Stack<global::Jint.Native.Descriptor>>();
			this.scopes.Push(this.currentScope);
		}

		// Token: 0x06000616 RID: 1558 RVA: 0x0002B514 File Offset: 0x00029714
		public void ExitScope()
		{
			foreach (global::System.Collections.Generic.Stack<global::Jint.Native.Descriptor> stack in this.currentScope)
			{
				stack.Pop();
			}
			this.scopes.Pop();
			this.currentScope = this.scopes.Peek();
		}

		// Token: 0x06000617 RID: 1559 RVA: 0x0002B58C File Offset: 0x0002978C
		public global::Jint.Native.Descriptor Put(string name, global::Jint.Native.Descriptor descriptor)
		{
			global::System.Collections.Generic.Stack<global::Jint.Native.Descriptor> stack;
			if (!this.bag.TryGetValue(name, out stack))
			{
				stack = new global::System.Collections.Generic.Stack<global::Jint.Native.Descriptor>();
				this.bag.Add(name, stack);
			}
			stack.Push(descriptor);
			this.currentScope.Add(stack);
			return descriptor;
		}

		// Token: 0x06000618 RID: 1560 RVA: 0x0002B5D8 File Offset: 0x000297D8
		public void Delete(string name)
		{
			global::System.Collections.Generic.Stack<global::Jint.Native.Descriptor> stack;
			if (this.bag.TryGetValue(name, out stack) && this.currentScope.Contains(stack))
			{
				stack.Pop();
				this.currentScope.Remove(stack);
			}
		}

		// Token: 0x06000619 RID: 1561 RVA: 0x0002B624 File Offset: 0x00029824
		public global::Jint.Native.Descriptor Get(string name)
		{
			global::System.Collections.Generic.Stack<global::Jint.Native.Descriptor> stack;
			if (!this.bag.TryGetValue(name, out stack))
			{
				return null;
			}
			if (stack.Count <= 0)
			{
				return null;
			}
			return stack.Peek();
		}

		// Token: 0x0600061A RID: 1562 RVA: 0x0002B660 File Offset: 0x00029860
		public bool TryGet(string name, out global::Jint.Native.Descriptor descriptor)
		{
			descriptor = this.Get(name);
			return descriptor != null;
		}

		// Token: 0x17000126 RID: 294
		// (get) Token: 0x0600061B RID: 1563 RVA: 0x0002B674 File Offset: 0x00029874
		public int Count
		{
			get
			{
				return this.bag.Count;
			}
		}

		// Token: 0x17000127 RID: 295
		// (get) Token: 0x0600061C RID: 1564 RVA: 0x0002B684 File Offset: 0x00029884
		public global::System.Collections.Generic.IEnumerable<global::Jint.Native.Descriptor> Values
		{
			get
			{
				throw new global::System.NotImplementedException();
			}
		}

		// Token: 0x0600061D RID: 1565 RVA: 0x0002B68C File Offset: 0x0002988C
		public global::System.Collections.Generic.IEnumerator<global::System.Collections.Generic.KeyValuePair<string, global::Jint.Native.Descriptor>> GetEnumerator()
		{
			throw new global::System.NotImplementedException();
		}

		// Token: 0x0600061E RID: 1566 RVA: 0x0002B694 File Offset: 0x00029894
		global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
		{
			throw new global::System.NotImplementedException();
		}

		// Token: 0x0600061F RID: 1567 RVA: 0x0002B69C File Offset: 0x0002989C
		public ScopedPropertyBag()
		{
		}

		// Token: 0x040002CB RID: 715
		private global::System.Collections.Generic.Dictionary<string, global::System.Collections.Generic.Stack<global::Jint.Native.Descriptor>> bag = new global::System.Collections.Generic.Dictionary<string, global::System.Collections.Generic.Stack<global::Jint.Native.Descriptor>>();

		// Token: 0x040002CC RID: 716
		private global::System.Collections.Generic.Stack<global::System.Collections.Generic.List<global::System.Collections.Generic.Stack<global::Jint.Native.Descriptor>>> scopes = new global::System.Collections.Generic.Stack<global::System.Collections.Generic.List<global::System.Collections.Generic.Stack<global::Jint.Native.Descriptor>>>();

		// Token: 0x040002CD RID: 717
		private global::System.Collections.Generic.List<global::System.Collections.Generic.Stack<global::Jint.Native.Descriptor>> currentScope;
	}
}
