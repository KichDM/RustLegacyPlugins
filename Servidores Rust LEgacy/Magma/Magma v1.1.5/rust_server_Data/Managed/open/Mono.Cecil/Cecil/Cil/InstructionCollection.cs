using System;
using Mono.Collections.Generic;

namespace Mono.Cecil.Cil
{
	// Token: 0x02000046 RID: 70
	internal class InstructionCollection : global::Mono.Collections.Generic.Collection<global::Mono.Cecil.Cil.Instruction>
	{
		// Token: 0x06000365 RID: 869 RVA: 0x0000962F File Offset: 0x0000782F
		internal InstructionCollection()
		{
		}

		// Token: 0x06000366 RID: 870 RVA: 0x00009637 File Offset: 0x00007837
		internal InstructionCollection(int capacity) : base(capacity)
		{
		}

		// Token: 0x06000367 RID: 871 RVA: 0x00009640 File Offset: 0x00007840
		protected override void OnAdd(global::Mono.Cecil.Cil.Instruction item, int index)
		{
			if (index == 0)
			{
				return;
			}
			global::Mono.Cecil.Cil.Instruction instruction = this.items[index - 1];
			instruction.next = item;
			item.previous = instruction;
		}

		// Token: 0x06000368 RID: 872 RVA: 0x0000966C File Offset: 0x0000786C
		protected override void OnInsert(global::Mono.Cecil.Cil.Instruction item, int index)
		{
			if (this.size == 0)
			{
				return;
			}
			global::Mono.Cecil.Cil.Instruction instruction = this.items[index];
			if (instruction == null)
			{
				global::Mono.Cecil.Cil.Instruction instruction2 = this.items[index - 1];
				instruction2.next = item;
				item.previous = instruction2;
				return;
			}
			global::Mono.Cecil.Cil.Instruction previous = instruction.previous;
			if (previous != null)
			{
				previous.next = item;
				item.previous = previous;
			}
			instruction.previous = item;
			item.next = instruction;
		}

		// Token: 0x06000369 RID: 873 RVA: 0x000096D0 File Offset: 0x000078D0
		protected override void OnSet(global::Mono.Cecil.Cil.Instruction item, int index)
		{
			global::Mono.Cecil.Cil.Instruction instruction = this.items[index];
			item.previous = instruction.previous;
			item.next = instruction.next;
			instruction.previous = null;
			instruction.next = null;
		}

		// Token: 0x0600036A RID: 874 RVA: 0x0000970C File Offset: 0x0000790C
		protected override void OnRemove(global::Mono.Cecil.Cil.Instruction item, int index)
		{
			global::Mono.Cecil.Cil.Instruction previous = item.previous;
			if (previous != null)
			{
				previous.next = item.next;
			}
			global::Mono.Cecil.Cil.Instruction next = item.next;
			if (next != null)
			{
				next.previous = item.previous;
			}
			item.previous = null;
			item.next = null;
		}
	}
}
