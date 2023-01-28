using System;
using Mono.Collections.Generic;

namespace Mono.Cecil.Cil
{
	// Token: 0x0200005D RID: 93
	public sealed class ILProcessor
	{
		// Token: 0x17000173 RID: 371
		// (get) Token: 0x060003D6 RID: 982 RVA: 0x0000A3F8 File Offset: 0x000085F8
		public global::Mono.Cecil.Cil.MethodBody Body
		{
			get
			{
				return this.body;
			}
		}

		// Token: 0x060003D7 RID: 983 RVA: 0x0000A400 File Offset: 0x00008600
		internal ILProcessor(global::Mono.Cecil.Cil.MethodBody body)
		{
			this.body = body;
			this.instructions = body.Instructions;
		}

		// Token: 0x060003D8 RID: 984 RVA: 0x0000A41B File Offset: 0x0000861B
		public global::Mono.Cecil.Cil.Instruction Create(global::Mono.Cecil.Cil.OpCode opcode)
		{
			return global::Mono.Cecil.Cil.Instruction.Create(opcode);
		}

		// Token: 0x060003D9 RID: 985 RVA: 0x0000A423 File Offset: 0x00008623
		public global::Mono.Cecil.Cil.Instruction Create(global::Mono.Cecil.Cil.OpCode opcode, global::Mono.Cecil.TypeReference type)
		{
			return global::Mono.Cecil.Cil.Instruction.Create(opcode, type);
		}

		// Token: 0x060003DA RID: 986 RVA: 0x0000A42C File Offset: 0x0000862C
		public global::Mono.Cecil.Cil.Instruction Create(global::Mono.Cecil.Cil.OpCode opcode, global::Mono.Cecil.CallSite site)
		{
			return global::Mono.Cecil.Cil.Instruction.Create(opcode, site);
		}

		// Token: 0x060003DB RID: 987 RVA: 0x0000A435 File Offset: 0x00008635
		public global::Mono.Cecil.Cil.Instruction Create(global::Mono.Cecil.Cil.OpCode opcode, global::Mono.Cecil.MethodReference method)
		{
			return global::Mono.Cecil.Cil.Instruction.Create(opcode, method);
		}

		// Token: 0x060003DC RID: 988 RVA: 0x0000A43E File Offset: 0x0000863E
		public global::Mono.Cecil.Cil.Instruction Create(global::Mono.Cecil.Cil.OpCode opcode, global::Mono.Cecil.FieldReference field)
		{
			return global::Mono.Cecil.Cil.Instruction.Create(opcode, field);
		}

		// Token: 0x060003DD RID: 989 RVA: 0x0000A447 File Offset: 0x00008647
		public global::Mono.Cecil.Cil.Instruction Create(global::Mono.Cecil.Cil.OpCode opcode, string value)
		{
			return global::Mono.Cecil.Cil.Instruction.Create(opcode, value);
		}

		// Token: 0x060003DE RID: 990 RVA: 0x0000A450 File Offset: 0x00008650
		public global::Mono.Cecil.Cil.Instruction Create(global::Mono.Cecil.Cil.OpCode opcode, sbyte value)
		{
			return global::Mono.Cecil.Cil.Instruction.Create(opcode, value);
		}

		// Token: 0x060003DF RID: 991 RVA: 0x0000A45C File Offset: 0x0000865C
		public global::Mono.Cecil.Cil.Instruction Create(global::Mono.Cecil.Cil.OpCode opcode, byte value)
		{
			if (opcode.OperandType == global::Mono.Cecil.Cil.OperandType.ShortInlineVar)
			{
				return global::Mono.Cecil.Cil.Instruction.Create(opcode, this.body.Variables[(int)value]);
			}
			if (opcode.OperandType == global::Mono.Cecil.Cil.OperandType.ShortInlineArg)
			{
				return global::Mono.Cecil.Cil.Instruction.Create(opcode, this.body.GetParameter((int)value));
			}
			return global::Mono.Cecil.Cil.Instruction.Create(opcode, value);
		}

		// Token: 0x060003E0 RID: 992 RVA: 0x0000A4B4 File Offset: 0x000086B4
		public global::Mono.Cecil.Cil.Instruction Create(global::Mono.Cecil.Cil.OpCode opcode, int value)
		{
			if (opcode.OperandType == global::Mono.Cecil.Cil.OperandType.InlineVar)
			{
				return global::Mono.Cecil.Cil.Instruction.Create(opcode, this.body.Variables[value]);
			}
			if (opcode.OperandType == global::Mono.Cecil.Cil.OperandType.InlineArg)
			{
				return global::Mono.Cecil.Cil.Instruction.Create(opcode, this.body.GetParameter(value));
			}
			return global::Mono.Cecil.Cil.Instruction.Create(opcode, value);
		}

		// Token: 0x060003E1 RID: 993 RVA: 0x0000A509 File Offset: 0x00008709
		public global::Mono.Cecil.Cil.Instruction Create(global::Mono.Cecil.Cil.OpCode opcode, long value)
		{
			return global::Mono.Cecil.Cil.Instruction.Create(opcode, value);
		}

		// Token: 0x060003E2 RID: 994 RVA: 0x0000A512 File Offset: 0x00008712
		public global::Mono.Cecil.Cil.Instruction Create(global::Mono.Cecil.Cil.OpCode opcode, float value)
		{
			return global::Mono.Cecil.Cil.Instruction.Create(opcode, value);
		}

		// Token: 0x060003E3 RID: 995 RVA: 0x0000A51B File Offset: 0x0000871B
		public global::Mono.Cecil.Cil.Instruction Create(global::Mono.Cecil.Cil.OpCode opcode, double value)
		{
			return global::Mono.Cecil.Cil.Instruction.Create(opcode, value);
		}

		// Token: 0x060003E4 RID: 996 RVA: 0x0000A524 File Offset: 0x00008724
		public global::Mono.Cecil.Cil.Instruction Create(global::Mono.Cecil.Cil.OpCode opcode, global::Mono.Cecil.Cil.Instruction target)
		{
			return global::Mono.Cecil.Cil.Instruction.Create(opcode, target);
		}

		// Token: 0x060003E5 RID: 997 RVA: 0x0000A52D File Offset: 0x0000872D
		public global::Mono.Cecil.Cil.Instruction Create(global::Mono.Cecil.Cil.OpCode opcode, global::Mono.Cecil.Cil.Instruction[] targets)
		{
			return global::Mono.Cecil.Cil.Instruction.Create(opcode, targets);
		}

		// Token: 0x060003E6 RID: 998 RVA: 0x0000A536 File Offset: 0x00008736
		public global::Mono.Cecil.Cil.Instruction Create(global::Mono.Cecil.Cil.OpCode opcode, global::Mono.Cecil.Cil.VariableDefinition variable)
		{
			return global::Mono.Cecil.Cil.Instruction.Create(opcode, variable);
		}

		// Token: 0x060003E7 RID: 999 RVA: 0x0000A53F File Offset: 0x0000873F
		public global::Mono.Cecil.Cil.Instruction Create(global::Mono.Cecil.Cil.OpCode opcode, global::Mono.Cecil.ParameterDefinition parameter)
		{
			return global::Mono.Cecil.Cil.Instruction.Create(opcode, parameter);
		}

		// Token: 0x060003E8 RID: 1000 RVA: 0x0000A548 File Offset: 0x00008748
		public void Emit(global::Mono.Cecil.Cil.OpCode opcode)
		{
			this.Append(this.Create(opcode));
		}

		// Token: 0x060003E9 RID: 1001 RVA: 0x0000A557 File Offset: 0x00008757
		public void Emit(global::Mono.Cecil.Cil.OpCode opcode, global::Mono.Cecil.TypeReference type)
		{
			this.Append(this.Create(opcode, type));
		}

		// Token: 0x060003EA RID: 1002 RVA: 0x0000A567 File Offset: 0x00008767
		public void Emit(global::Mono.Cecil.Cil.OpCode opcode, global::Mono.Cecil.MethodReference method)
		{
			this.Append(this.Create(opcode, method));
		}

		// Token: 0x060003EB RID: 1003 RVA: 0x0000A577 File Offset: 0x00008777
		public void Emit(global::Mono.Cecil.Cil.OpCode opcode, global::Mono.Cecil.CallSite site)
		{
			this.Append(this.Create(opcode, site));
		}

		// Token: 0x060003EC RID: 1004 RVA: 0x0000A587 File Offset: 0x00008787
		public void Emit(global::Mono.Cecil.Cil.OpCode opcode, global::Mono.Cecil.FieldReference field)
		{
			this.Append(this.Create(opcode, field));
		}

		// Token: 0x060003ED RID: 1005 RVA: 0x0000A597 File Offset: 0x00008797
		public void Emit(global::Mono.Cecil.Cil.OpCode opcode, string value)
		{
			this.Append(this.Create(opcode, value));
		}

		// Token: 0x060003EE RID: 1006 RVA: 0x0000A5A7 File Offset: 0x000087A7
		public void Emit(global::Mono.Cecil.Cil.OpCode opcode, byte value)
		{
			this.Append(this.Create(opcode, value));
		}

		// Token: 0x060003EF RID: 1007 RVA: 0x0000A5B7 File Offset: 0x000087B7
		public void Emit(global::Mono.Cecil.Cil.OpCode opcode, sbyte value)
		{
			this.Append(this.Create(opcode, value));
		}

		// Token: 0x060003F0 RID: 1008 RVA: 0x0000A5C7 File Offset: 0x000087C7
		public void Emit(global::Mono.Cecil.Cil.OpCode opcode, int value)
		{
			this.Append(this.Create(opcode, value));
		}

		// Token: 0x060003F1 RID: 1009 RVA: 0x0000A5D7 File Offset: 0x000087D7
		public void Emit(global::Mono.Cecil.Cil.OpCode opcode, long value)
		{
			this.Append(this.Create(opcode, value));
		}

		// Token: 0x060003F2 RID: 1010 RVA: 0x0000A5E7 File Offset: 0x000087E7
		public void Emit(global::Mono.Cecil.Cil.OpCode opcode, float value)
		{
			this.Append(this.Create(opcode, value));
		}

		// Token: 0x060003F3 RID: 1011 RVA: 0x0000A5F7 File Offset: 0x000087F7
		public void Emit(global::Mono.Cecil.Cil.OpCode opcode, double value)
		{
			this.Append(this.Create(opcode, value));
		}

		// Token: 0x060003F4 RID: 1012 RVA: 0x0000A607 File Offset: 0x00008807
		public void Emit(global::Mono.Cecil.Cil.OpCode opcode, global::Mono.Cecil.Cil.Instruction target)
		{
			this.Append(this.Create(opcode, target));
		}

		// Token: 0x060003F5 RID: 1013 RVA: 0x0000A617 File Offset: 0x00008817
		public void Emit(global::Mono.Cecil.Cil.OpCode opcode, global::Mono.Cecil.Cil.Instruction[] targets)
		{
			this.Append(this.Create(opcode, targets));
		}

		// Token: 0x060003F6 RID: 1014 RVA: 0x0000A627 File Offset: 0x00008827
		public void Emit(global::Mono.Cecil.Cil.OpCode opcode, global::Mono.Cecil.Cil.VariableDefinition variable)
		{
			this.Append(this.Create(opcode, variable));
		}

		// Token: 0x060003F7 RID: 1015 RVA: 0x0000A637 File Offset: 0x00008837
		public void Emit(global::Mono.Cecil.Cil.OpCode opcode, global::Mono.Cecil.ParameterDefinition parameter)
		{
			this.Append(this.Create(opcode, parameter));
		}

		// Token: 0x060003F8 RID: 1016 RVA: 0x0000A648 File Offset: 0x00008848
		public void InsertBefore(global::Mono.Cecil.Cil.Instruction target, global::Mono.Cecil.Cil.Instruction instruction)
		{
			if (target == null)
			{
				throw new global::System.ArgumentNullException("target");
			}
			if (instruction == null)
			{
				throw new global::System.ArgumentNullException("instruction");
			}
			int num = this.instructions.IndexOf(target);
			if (num == -1)
			{
				throw new global::System.ArgumentOutOfRangeException("target");
			}
			this.instructions.Insert(num, instruction);
		}

		// Token: 0x060003F9 RID: 1017 RVA: 0x0000A69C File Offset: 0x0000889C
		public void InsertAfter(global::Mono.Cecil.Cil.Instruction target, global::Mono.Cecil.Cil.Instruction instruction)
		{
			if (target == null)
			{
				throw new global::System.ArgumentNullException("target");
			}
			if (instruction == null)
			{
				throw new global::System.ArgumentNullException("instruction");
			}
			int num = this.instructions.IndexOf(target);
			if (num == -1)
			{
				throw new global::System.ArgumentOutOfRangeException("target");
			}
			this.instructions.Insert(num + 1, instruction);
		}

		// Token: 0x060003FA RID: 1018 RVA: 0x0000A6F0 File Offset: 0x000088F0
		public void Append(global::Mono.Cecil.Cil.Instruction instruction)
		{
			if (instruction == null)
			{
				throw new global::System.ArgumentNullException("instruction");
			}
			this.instructions.Add(instruction);
		}

		// Token: 0x060003FB RID: 1019 RVA: 0x0000A70C File Offset: 0x0000890C
		public void Replace(global::Mono.Cecil.Cil.Instruction target, global::Mono.Cecil.Cil.Instruction instruction)
		{
			if (target == null)
			{
				throw new global::System.ArgumentNullException("target");
			}
			if (instruction == null)
			{
				throw new global::System.ArgumentNullException("instruction");
			}
			this.InsertAfter(target, instruction);
			this.Remove(target);
		}

		// Token: 0x060003FC RID: 1020 RVA: 0x0000A739 File Offset: 0x00008939
		public void Remove(global::Mono.Cecil.Cil.Instruction instruction)
		{
			if (instruction == null)
			{
				throw new global::System.ArgumentNullException("instruction");
			}
			if (!this.instructions.Remove(instruction))
			{
				throw new global::System.ArgumentOutOfRangeException("instruction");
			}
		}

		// Token: 0x040002A7 RID: 679
		private readonly global::Mono.Cecil.Cil.MethodBody body;

		// Token: 0x040002A8 RID: 680
		private readonly global::Mono.Collections.Generic.Collection<global::Mono.Cecil.Cil.Instruction> instructions;
	}
}
