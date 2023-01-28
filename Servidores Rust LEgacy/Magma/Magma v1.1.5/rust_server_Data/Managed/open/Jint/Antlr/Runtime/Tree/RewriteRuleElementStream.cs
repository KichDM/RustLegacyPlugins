using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Antlr.Runtime.Tree
{
	// Token: 0x020000CE RID: 206
	[global::System.Runtime.InteropServices.ComVisible(false)]
	[global::System.Serializable]
	public abstract class RewriteRuleElementStream
	{
		// Token: 0x0600099E RID: 2462 RVA: 0x00033F28 File Offset: 0x00032128
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public RewriteRuleElementStream(global::Antlr.Runtime.Tree.ITreeAdaptor adaptor, string elementDescription)
		{
			this.elementDescription = elementDescription;
			this.adaptor = adaptor;
		}

		// Token: 0x0600099F RID: 2463 RVA: 0x00033F40 File Offset: 0x00032140
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public RewriteRuleElementStream(global::Antlr.Runtime.Tree.ITreeAdaptor adaptor, string elementDescription, object oneElement) : this(adaptor, elementDescription)
		{
			this.Add(oneElement);
		}

		// Token: 0x060009A0 RID: 2464 RVA: 0x00033F54 File Offset: 0x00032154
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public RewriteRuleElementStream(global::Antlr.Runtime.Tree.ITreeAdaptor adaptor, string elementDescription, global::System.Collections.IList elements) : this(adaptor, elementDescription)
		{
			this.singleElement = null;
			this.elements = elements;
		}

		// Token: 0x060009A1 RID: 2465 RVA: 0x00033F6C File Offset: 0x0003216C
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual void Reset()
		{
			this.cursor = 0;
			this.dirty = true;
		}

		// Token: 0x060009A2 RID: 2466 RVA: 0x00033F7C File Offset: 0x0003217C
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual void Add(object el)
		{
			if (el == null)
			{
				return;
			}
			if (this.elements != null)
			{
				this.elements.Add(el);
				return;
			}
			if (this.singleElement == null)
			{
				this.singleElement = el;
				return;
			}
			this.elements = new global::System.Collections.Generic.List<object>(5);
			this.elements.Add(this.singleElement);
			this.singleElement = null;
			this.elements.Add(el);
		}

		// Token: 0x060009A3 RID: 2467 RVA: 0x00033FF4 File Offset: 0x000321F4
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual object NextTree()
		{
			int count = this.Count;
			if (this.dirty || (this.cursor >= count && count == 1))
			{
				object el = this.NextCore();
				return this.Dup(el);
			}
			return this.NextCore();
		}

		// Token: 0x060009A4 RID: 2468 RVA: 0x00034044 File Offset: 0x00032244
		protected virtual object NextCore()
		{
			int count = this.Count;
			if (count == 0)
			{
				throw new global::Antlr.Runtime.Tree.RewriteEmptyStreamException(this.elementDescription);
			}
			if (this.cursor >= count)
			{
				if (count == 1)
				{
					return this.ToTree(this.singleElement);
				}
				throw new global::Antlr.Runtime.Tree.RewriteCardinalityException(this.elementDescription);
			}
			else
			{
				if (this.singleElement != null)
				{
					this.cursor++;
					return this.ToTree(this.singleElement);
				}
				object result = this.ToTree(this.elements[this.cursor]);
				this.cursor++;
				return result;
			}
		}

		// Token: 0x060009A5 RID: 2469
		protected abstract object Dup(object el);

		// Token: 0x060009A6 RID: 2470 RVA: 0x000340E8 File Offset: 0x000322E8
		protected virtual object ToTree(object el)
		{
			return el;
		}

		// Token: 0x170001D9 RID: 473
		// (get) Token: 0x060009A7 RID: 2471 RVA: 0x000340EC File Offset: 0x000322EC
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual bool HasNext
		{
			[global::System.Runtime.InteropServices.ComVisible(false)]
			get
			{
				return (this.singleElement != null && this.cursor < 1) || (this.elements != null && this.cursor < this.elements.Count);
			}
		}

		// Token: 0x170001DA RID: 474
		// (get) Token: 0x060009A8 RID: 2472 RVA: 0x00034128 File Offset: 0x00032328
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual int Count
		{
			[global::System.Runtime.InteropServices.ComVisible(false)]
			get
			{
				int result = 0;
				if (this.singleElement != null)
				{
					result = 1;
				}
				if (this.elements != null)
				{
					return this.elements.Count;
				}
				return result;
			}
		}

		// Token: 0x170001DB RID: 475
		// (get) Token: 0x060009A9 RID: 2473 RVA: 0x00034160 File Offset: 0x00032360
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public virtual string Description
		{
			[global::System.Runtime.InteropServices.ComVisible(false)]
			get
			{
				return this.elementDescription;
			}
		}

		// Token: 0x040003FB RID: 1019
		protected int cursor;

		// Token: 0x040003FC RID: 1020
		protected object singleElement;

		// Token: 0x040003FD RID: 1021
		protected global::System.Collections.IList elements;

		// Token: 0x040003FE RID: 1022
		protected bool dirty;

		// Token: 0x040003FF RID: 1023
		protected string elementDescription;

		// Token: 0x04000400 RID: 1024
		protected global::Antlr.Runtime.Tree.ITreeAdaptor adaptor;
	}
}
