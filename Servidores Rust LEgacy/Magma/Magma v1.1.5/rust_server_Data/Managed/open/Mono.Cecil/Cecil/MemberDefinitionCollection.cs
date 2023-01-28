using System;
using Mono.Collections.Generic;

namespace Mono.Cecil
{
	// Token: 0x02000021 RID: 33
	internal class MemberDefinitionCollection<T> : global::Mono.Collections.Generic.Collection<T> where T : global::Mono.Cecil.IMemberDefinition
	{
		// Token: 0x060001A4 RID: 420 RVA: 0x000053A8 File Offset: 0x000035A8
		internal MemberDefinitionCollection(global::Mono.Cecil.TypeDefinition container)
		{
			this.container = container;
		}

		// Token: 0x060001A5 RID: 421 RVA: 0x000053B7 File Offset: 0x000035B7
		internal MemberDefinitionCollection(global::Mono.Cecil.TypeDefinition container, int capacity) : base(capacity)
		{
			this.container = container;
		}

		// Token: 0x060001A6 RID: 422 RVA: 0x000053C7 File Offset: 0x000035C7
		protected override void OnAdd(T item, int index)
		{
			this.Attach(item);
		}

		// Token: 0x060001A7 RID: 423 RVA: 0x000053D0 File Offset: 0x000035D0
		protected sealed override void OnSet(T item, int index)
		{
			this.Attach(item);
		}

		// Token: 0x060001A8 RID: 424 RVA: 0x000053D9 File Offset: 0x000035D9
		protected sealed override void OnInsert(T item, int index)
		{
			this.Attach(item);
		}

		// Token: 0x060001A9 RID: 425 RVA: 0x000053E2 File Offset: 0x000035E2
		protected sealed override void OnRemove(T item, int index)
		{
			global::Mono.Cecil.MemberDefinitionCollection<T>.Detach(item);
		}

		// Token: 0x060001AA RID: 426 RVA: 0x000053EC File Offset: 0x000035EC
		protected sealed override void OnClear()
		{
			foreach (T element in this)
			{
				global::Mono.Cecil.MemberDefinitionCollection<T>.Detach(element);
			}
		}

		// Token: 0x060001AB RID: 427 RVA: 0x0000543C File Offset: 0x0000363C
		private void Attach(T element)
		{
			if (element.DeclaringType == this.container)
			{
				return;
			}
			if (element.DeclaringType != null)
			{
				throw new global::System.ArgumentException("Member already attached");
			}
			element.DeclaringType = this.container;
		}

		// Token: 0x060001AC RID: 428 RVA: 0x0000548C File Offset: 0x0000368C
		private static void Detach(T element)
		{
			element.DeclaringType = null;
		}

		// Token: 0x0400009C RID: 156
		private global::Mono.Cecil.TypeDefinition container;
	}
}
