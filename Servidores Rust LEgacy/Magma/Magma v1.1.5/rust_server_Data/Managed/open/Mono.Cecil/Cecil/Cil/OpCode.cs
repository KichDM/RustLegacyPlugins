using System;

namespace Mono.Cecil.Cil
{
	// Token: 0x0200007E RID: 126
	public struct OpCode
	{
		// Token: 0x170001F5 RID: 501
		// (get) Token: 0x06000544 RID: 1348 RVA: 0x0000C9E7 File Offset: 0x0000ABE7
		public string Name
		{
			get
			{
				return global::Mono.Cecil.Cil.OpCodeNames.names[(int)this.Code];
			}
		}

		// Token: 0x170001F6 RID: 502
		// (get) Token: 0x06000545 RID: 1349 RVA: 0x0000C9F5 File Offset: 0x0000ABF5
		public int Size
		{
			get
			{
				if (this.op1 != 0xFF)
				{
					return 2;
				}
				return 1;
			}
		}

		// Token: 0x170001F7 RID: 503
		// (get) Token: 0x06000546 RID: 1350 RVA: 0x0000CA07 File Offset: 0x0000AC07
		public byte Op1
		{
			get
			{
				return this.op1;
			}
		}

		// Token: 0x170001F8 RID: 504
		// (get) Token: 0x06000547 RID: 1351 RVA: 0x0000CA0F File Offset: 0x0000AC0F
		public byte Op2
		{
			get
			{
				return this.op2;
			}
		}

		// Token: 0x170001F9 RID: 505
		// (get) Token: 0x06000548 RID: 1352 RVA: 0x0000CA17 File Offset: 0x0000AC17
		public short Value
		{
			get
			{
				if (this.op1 != 0xFF)
				{
					return (short)((int)this.op1 << 8 | (int)this.op2);
				}
				return (short)this.op2;
			}
		}

		// Token: 0x170001FA RID: 506
		// (get) Token: 0x06000549 RID: 1353 RVA: 0x0000CA3D File Offset: 0x0000AC3D
		public global::Mono.Cecil.Cil.Code Code
		{
			get
			{
				return (global::Mono.Cecil.Cil.Code)this.code;
			}
		}

		// Token: 0x170001FB RID: 507
		// (get) Token: 0x0600054A RID: 1354 RVA: 0x0000CA45 File Offset: 0x0000AC45
		public global::Mono.Cecil.Cil.FlowControl FlowControl
		{
			get
			{
				return (global::Mono.Cecil.Cil.FlowControl)this.flow_control;
			}
		}

		// Token: 0x170001FC RID: 508
		// (get) Token: 0x0600054B RID: 1355 RVA: 0x0000CA4D File Offset: 0x0000AC4D
		public global::Mono.Cecil.Cil.OpCodeType OpCodeType
		{
			get
			{
				return (global::Mono.Cecil.Cil.OpCodeType)this.opcode_type;
			}
		}

		// Token: 0x170001FD RID: 509
		// (get) Token: 0x0600054C RID: 1356 RVA: 0x0000CA55 File Offset: 0x0000AC55
		public global::Mono.Cecil.Cil.OperandType OperandType
		{
			get
			{
				return (global::Mono.Cecil.Cil.OperandType)this.operand_type;
			}
		}

		// Token: 0x170001FE RID: 510
		// (get) Token: 0x0600054D RID: 1357 RVA: 0x0000CA5D File Offset: 0x0000AC5D
		public global::Mono.Cecil.Cil.StackBehaviour StackBehaviourPop
		{
			get
			{
				return (global::Mono.Cecil.Cil.StackBehaviour)this.stack_behavior_pop;
			}
		}

		// Token: 0x170001FF RID: 511
		// (get) Token: 0x0600054E RID: 1358 RVA: 0x0000CA65 File Offset: 0x0000AC65
		public global::Mono.Cecil.Cil.StackBehaviour StackBehaviourPush
		{
			get
			{
				return (global::Mono.Cecil.Cil.StackBehaviour)this.stack_behavior_push;
			}
		}

		// Token: 0x0600054F RID: 1359 RVA: 0x0000CA70 File Offset: 0x0000AC70
		internal OpCode(int x, int y)
		{
			this.op1 = (byte)(x & 0xFF);
			this.op2 = (byte)(x >> 8 & 0xFF);
			this.code = (byte)(x >> 0x10 & 0xFF);
			this.flow_control = (byte)(x >> 0x18 & 0xFF);
			this.opcode_type = (byte)(y & 0xFF);
			this.operand_type = (byte)(y >> 8 & 0xFF);
			this.stack_behavior_pop = (byte)(y >> 0x10 & 0xFF);
			this.stack_behavior_push = (byte)(y >> 0x18 & 0xFF);
			if (this.op1 == 0xFF)
			{
				global::Mono.Cecil.Cil.OpCodes.OneByteOpCode[(int)this.op2] = this;
				return;
			}
			global::Mono.Cecil.Cil.OpCodes.TwoBytesOpCode[(int)this.op2] = this;
		}

		// Token: 0x06000550 RID: 1360 RVA: 0x0000CB41 File Offset: 0x0000AD41
		public override int GetHashCode()
		{
			return (int)this.Value;
		}

		// Token: 0x06000551 RID: 1361 RVA: 0x0000CB4C File Offset: 0x0000AD4C
		public override bool Equals(object obj)
		{
			if (!(obj is global::Mono.Cecil.Cil.OpCode))
			{
				return false;
			}
			global::Mono.Cecil.Cil.OpCode opCode = (global::Mono.Cecil.Cil.OpCode)obj;
			return this.op1 == opCode.op1 && this.op2 == opCode.op2;
		}

		// Token: 0x06000552 RID: 1362 RVA: 0x0000CB8A File Offset: 0x0000AD8A
		public bool Equals(global::Mono.Cecil.Cil.OpCode opcode)
		{
			return this.op1 == opcode.op1 && this.op2 == opcode.op2;
		}

		// Token: 0x06000553 RID: 1363 RVA: 0x0000CBAC File Offset: 0x0000ADAC
		public static bool operator ==(global::Mono.Cecil.Cil.OpCode one, global::Mono.Cecil.Cil.OpCode other)
		{
			return one.op1 == other.op1 && one.op2 == other.op2;
		}

		// Token: 0x06000554 RID: 1364 RVA: 0x0000CBD0 File Offset: 0x0000ADD0
		public static bool operator !=(global::Mono.Cecil.Cil.OpCode one, global::Mono.Cecil.Cil.OpCode other)
		{
			return one.op1 != other.op1 || one.op2 != other.op2;
		}

		// Token: 0x06000555 RID: 1365 RVA: 0x0000CBF7 File Offset: 0x0000ADF7
		public override string ToString()
		{
			return this.Name;
		}

		// Token: 0x04000353 RID: 851
		private readonly byte op1;

		// Token: 0x04000354 RID: 852
		private readonly byte op2;

		// Token: 0x04000355 RID: 853
		private readonly byte code;

		// Token: 0x04000356 RID: 854
		private readonly byte flow_control;

		// Token: 0x04000357 RID: 855
		private readonly byte opcode_type;

		// Token: 0x04000358 RID: 856
		private readonly byte operand_type;

		// Token: 0x04000359 RID: 857
		private readonly byte stack_behavior_pop;

		// Token: 0x0400035A RID: 858
		private readonly byte stack_behavior_push;
	}
}
