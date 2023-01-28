using System;
using System.Text;

namespace Mono.Cecil.Cil
{
	// Token: 0x0200008A RID: 138
	public sealed class Instruction
	{
		// Token: 0x1700023A RID: 570
		// (get) Token: 0x060005EC RID: 1516 RVA: 0x0000E642 File Offset: 0x0000C842
		// (set) Token: 0x060005ED RID: 1517 RVA: 0x0000E64A File Offset: 0x0000C84A
		public int Offset
		{
			get
			{
				return this.offset;
			}
			set
			{
				this.offset = value;
			}
		}

		// Token: 0x1700023B RID: 571
		// (get) Token: 0x060005EE RID: 1518 RVA: 0x0000E653 File Offset: 0x0000C853
		// (set) Token: 0x060005EF RID: 1519 RVA: 0x0000E65B File Offset: 0x0000C85B
		public global::Mono.Cecil.Cil.OpCode OpCode
		{
			get
			{
				return this.opcode;
			}
			set
			{
				this.opcode = value;
			}
		}

		// Token: 0x1700023C RID: 572
		// (get) Token: 0x060005F0 RID: 1520 RVA: 0x0000E664 File Offset: 0x0000C864
		// (set) Token: 0x060005F1 RID: 1521 RVA: 0x0000E66C File Offset: 0x0000C86C
		public object Operand
		{
			get
			{
				return this.operand;
			}
			set
			{
				this.operand = value;
			}
		}

		// Token: 0x1700023D RID: 573
		// (get) Token: 0x060005F2 RID: 1522 RVA: 0x0000E675 File Offset: 0x0000C875
		// (set) Token: 0x060005F3 RID: 1523 RVA: 0x0000E67D File Offset: 0x0000C87D
		public global::Mono.Cecil.Cil.Instruction Previous
		{
			get
			{
				return this.previous;
			}
			set
			{
				this.previous = value;
			}
		}

		// Token: 0x1700023E RID: 574
		// (get) Token: 0x060005F4 RID: 1524 RVA: 0x0000E686 File Offset: 0x0000C886
		// (set) Token: 0x060005F5 RID: 1525 RVA: 0x0000E68E File Offset: 0x0000C88E
		public global::Mono.Cecil.Cil.Instruction Next
		{
			get
			{
				return this.next;
			}
			set
			{
				this.next = value;
			}
		}

		// Token: 0x1700023F RID: 575
		// (get) Token: 0x060005F6 RID: 1526 RVA: 0x0000E697 File Offset: 0x0000C897
		// (set) Token: 0x060005F7 RID: 1527 RVA: 0x0000E69F File Offset: 0x0000C89F
		public global::Mono.Cecil.Cil.SequencePoint SequencePoint
		{
			get
			{
				return this.sequence_point;
			}
			set
			{
				this.sequence_point = value;
			}
		}

		// Token: 0x060005F8 RID: 1528 RVA: 0x0000E6A8 File Offset: 0x0000C8A8
		internal Instruction(int offset, global::Mono.Cecil.Cil.OpCode opCode)
		{
			this.offset = offset;
			this.opcode = opCode;
		}

		// Token: 0x060005F9 RID: 1529 RVA: 0x0000E6BE File Offset: 0x0000C8BE
		internal Instruction(global::Mono.Cecil.Cil.OpCode opcode, object operand)
		{
			this.opcode = opcode;
			this.operand = operand;
		}

		// Token: 0x060005FA RID: 1530 RVA: 0x0000E6D4 File Offset: 0x0000C8D4
		public int GetSize()
		{
			int size = this.opcode.Size;
			switch (this.opcode.OperandType)
			{
			case global::Mono.Cecil.Cil.OperandType.InlineBrTarget:
			case global::Mono.Cecil.Cil.OperandType.InlineField:
			case global::Mono.Cecil.Cil.OperandType.InlineI:
			case global::Mono.Cecil.Cil.OperandType.InlineMethod:
			case global::Mono.Cecil.Cil.OperandType.InlineSig:
			case global::Mono.Cecil.Cil.OperandType.InlineString:
			case global::Mono.Cecil.Cil.OperandType.InlineTok:
			case global::Mono.Cecil.Cil.OperandType.InlineType:
			case global::Mono.Cecil.Cil.OperandType.ShortInlineR:
				return size + 4;
			case global::Mono.Cecil.Cil.OperandType.InlineI8:
			case global::Mono.Cecil.Cil.OperandType.InlineR:
				return size + 8;
			case global::Mono.Cecil.Cil.OperandType.InlineSwitch:
				return size + (1 + ((global::Mono.Cecil.Cil.Instruction[])this.operand).Length) * 4;
			case global::Mono.Cecil.Cil.OperandType.InlineVar:
			case global::Mono.Cecil.Cil.OperandType.InlineArg:
				return size + 2;
			case global::Mono.Cecil.Cil.OperandType.ShortInlineBrTarget:
			case global::Mono.Cecil.Cil.OperandType.ShortInlineI:
			case global::Mono.Cecil.Cil.OperandType.ShortInlineVar:
			case global::Mono.Cecil.Cil.OperandType.ShortInlineArg:
				return size + 1;
			}
			return size;
		}

		// Token: 0x060005FB RID: 1531 RVA: 0x0000E778 File Offset: 0x0000C978
		public override string ToString()
		{
			global::System.Text.StringBuilder stringBuilder = new global::System.Text.StringBuilder();
			global::Mono.Cecil.Cil.Instruction.AppendLabel(stringBuilder, this);
			stringBuilder.Append(':');
			stringBuilder.Append(' ');
			stringBuilder.Append(this.opcode.Name);
			if (this.operand == null)
			{
				return stringBuilder.ToString();
			}
			stringBuilder.Append(' ');
			global::Mono.Cecil.Cil.OperandType operandType = this.opcode.OperandType;
			if (operandType != global::Mono.Cecil.Cil.OperandType.InlineBrTarget)
			{
				switch (operandType)
				{
				case global::Mono.Cecil.Cil.OperandType.InlineString:
					stringBuilder.Append('"');
					stringBuilder.Append(this.operand);
					stringBuilder.Append('"');
					goto IL_E2;
				case global::Mono.Cecil.Cil.OperandType.InlineSwitch:
				{
					global::Mono.Cecil.Cil.Instruction[] array = (global::Mono.Cecil.Cil.Instruction[])this.operand;
					for (int i = 0; i < array.Length; i++)
					{
						if (i > 0)
						{
							stringBuilder.Append(',');
						}
						global::Mono.Cecil.Cil.Instruction.AppendLabel(stringBuilder, array[i]);
					}
					goto IL_E2;
				}
				default:
					if (operandType != global::Mono.Cecil.Cil.OperandType.ShortInlineBrTarget)
					{
						stringBuilder.Append(this.operand);
						goto IL_E2;
					}
					break;
				}
			}
			global::Mono.Cecil.Cil.Instruction.AppendLabel(stringBuilder, (global::Mono.Cecil.Cil.Instruction)this.operand);
			IL_E2:
			return stringBuilder.ToString();
		}

		// Token: 0x060005FC RID: 1532 RVA: 0x0000E86D File Offset: 0x0000CA6D
		private static void AppendLabel(global::System.Text.StringBuilder builder, global::Mono.Cecil.Cil.Instruction instruction)
		{
			builder.Append("IL_");
			builder.Append(instruction.offset.ToString("x4"));
		}

		// Token: 0x060005FD RID: 1533 RVA: 0x0000E892 File Offset: 0x0000CA92
		public static global::Mono.Cecil.Cil.Instruction Create(global::Mono.Cecil.Cil.OpCode opcode)
		{
			if (opcode.OperandType != global::Mono.Cecil.Cil.OperandType.InlineNone)
			{
				throw new global::System.ArgumentException("opcode");
			}
			return new global::Mono.Cecil.Cil.Instruction(opcode, null);
		}

		// Token: 0x060005FE RID: 1534 RVA: 0x0000E8B0 File Offset: 0x0000CAB0
		public static global::Mono.Cecil.Cil.Instruction Create(global::Mono.Cecil.Cil.OpCode opcode, global::Mono.Cecil.TypeReference type)
		{
			if (type == null)
			{
				throw new global::System.ArgumentNullException("type");
			}
			if (opcode.OperandType != global::Mono.Cecil.Cil.OperandType.InlineType && opcode.OperandType != global::Mono.Cecil.Cil.OperandType.InlineTok)
			{
				throw new global::System.ArgumentException("opcode");
			}
			return new global::Mono.Cecil.Cil.Instruction(opcode, type);
		}

		// Token: 0x060005FF RID: 1535 RVA: 0x0000E8E8 File Offset: 0x0000CAE8
		public static global::Mono.Cecil.Cil.Instruction Create(global::Mono.Cecil.Cil.OpCode opcode, global::Mono.Cecil.CallSite site)
		{
			if (site == null)
			{
				throw new global::System.ArgumentNullException("site");
			}
			if (opcode.Code != global::Mono.Cecil.Cil.Code.Calli)
			{
				throw new global::System.ArgumentException("code");
			}
			return new global::Mono.Cecil.Cil.Instruction(opcode, site);
		}

		// Token: 0x06000600 RID: 1536 RVA: 0x0000E915 File Offset: 0x0000CB15
		public static global::Mono.Cecil.Cil.Instruction Create(global::Mono.Cecil.Cil.OpCode opcode, global::Mono.Cecil.MethodReference method)
		{
			if (method == null)
			{
				throw new global::System.ArgumentNullException("method");
			}
			if (opcode.OperandType != global::Mono.Cecil.Cil.OperandType.InlineMethod && opcode.OperandType != global::Mono.Cecil.Cil.OperandType.InlineTok)
			{
				throw new global::System.ArgumentException("opcode");
			}
			return new global::Mono.Cecil.Cil.Instruction(opcode, method);
		}

		// Token: 0x06000601 RID: 1537 RVA: 0x0000E94C File Offset: 0x0000CB4C
		public static global::Mono.Cecil.Cil.Instruction Create(global::Mono.Cecil.Cil.OpCode opcode, global::Mono.Cecil.FieldReference field)
		{
			if (field == null)
			{
				throw new global::System.ArgumentNullException("field");
			}
			if (opcode.OperandType != global::Mono.Cecil.Cil.OperandType.InlineField && opcode.OperandType != global::Mono.Cecil.Cil.OperandType.InlineTok)
			{
				throw new global::System.ArgumentException("opcode");
			}
			return new global::Mono.Cecil.Cil.Instruction(opcode, field);
		}

		// Token: 0x06000602 RID: 1538 RVA: 0x0000E983 File Offset: 0x0000CB83
		public static global::Mono.Cecil.Cil.Instruction Create(global::Mono.Cecil.Cil.OpCode opcode, string value)
		{
			if (value == null)
			{
				throw new global::System.ArgumentNullException("value");
			}
			if (opcode.OperandType != global::Mono.Cecil.Cil.OperandType.InlineString)
			{
				throw new global::System.ArgumentException("opcode");
			}
			return new global::Mono.Cecil.Cil.Instruction(opcode, value);
		}

		// Token: 0x06000603 RID: 1539 RVA: 0x0000E9B0 File Offset: 0x0000CBB0
		public static global::Mono.Cecil.Cil.Instruction Create(global::Mono.Cecil.Cil.OpCode opcode, sbyte value)
		{
			if (opcode.OperandType != global::Mono.Cecil.Cil.OperandType.ShortInlineI && opcode != global::Mono.Cecil.Cil.OpCodes.Ldc_I4_S)
			{
				throw new global::System.ArgumentException("opcode");
			}
			return new global::Mono.Cecil.Cil.Instruction(opcode, value);
		}

		// Token: 0x06000604 RID: 1540 RVA: 0x0000E9E1 File Offset: 0x0000CBE1
		public static global::Mono.Cecil.Cil.Instruction Create(global::Mono.Cecil.Cil.OpCode opcode, byte value)
		{
			if (opcode.OperandType != global::Mono.Cecil.Cil.OperandType.ShortInlineI || opcode == global::Mono.Cecil.Cil.OpCodes.Ldc_I4_S)
			{
				throw new global::System.ArgumentException("opcode");
			}
			return new global::Mono.Cecil.Cil.Instruction(opcode, value);
		}

		// Token: 0x06000605 RID: 1541 RVA: 0x0000EA12 File Offset: 0x0000CC12
		public static global::Mono.Cecil.Cil.Instruction Create(global::Mono.Cecil.Cil.OpCode opcode, int value)
		{
			if (opcode.OperandType != global::Mono.Cecil.Cil.OperandType.InlineI)
			{
				throw new global::System.ArgumentException("opcode");
			}
			return new global::Mono.Cecil.Cil.Instruction(opcode, value);
		}

		// Token: 0x06000606 RID: 1542 RVA: 0x0000EA35 File Offset: 0x0000CC35
		public static global::Mono.Cecil.Cil.Instruction Create(global::Mono.Cecil.Cil.OpCode opcode, long value)
		{
			if (opcode.OperandType != global::Mono.Cecil.Cil.OperandType.InlineI8)
			{
				throw new global::System.ArgumentException("opcode");
			}
			return new global::Mono.Cecil.Cil.Instruction(opcode, value);
		}

		// Token: 0x06000607 RID: 1543 RVA: 0x0000EA58 File Offset: 0x0000CC58
		public static global::Mono.Cecil.Cil.Instruction Create(global::Mono.Cecil.Cil.OpCode opcode, float value)
		{
			if (opcode.OperandType != global::Mono.Cecil.Cil.OperandType.ShortInlineR)
			{
				throw new global::System.ArgumentException("opcode");
			}
			return new global::Mono.Cecil.Cil.Instruction(opcode, value);
		}

		// Token: 0x06000608 RID: 1544 RVA: 0x0000EA7C File Offset: 0x0000CC7C
		public static global::Mono.Cecil.Cil.Instruction Create(global::Mono.Cecil.Cil.OpCode opcode, double value)
		{
			if (opcode.OperandType != global::Mono.Cecil.Cil.OperandType.InlineR)
			{
				throw new global::System.ArgumentException("opcode");
			}
			return new global::Mono.Cecil.Cil.Instruction(opcode, value);
		}

		// Token: 0x06000609 RID: 1545 RVA: 0x0000EA9F File Offset: 0x0000CC9F
		public static global::Mono.Cecil.Cil.Instruction Create(global::Mono.Cecil.Cil.OpCode opcode, global::Mono.Cecil.Cil.Instruction target)
		{
			if (target == null)
			{
				throw new global::System.ArgumentNullException("target");
			}
			if (opcode.OperandType != global::Mono.Cecil.Cil.OperandType.InlineBrTarget && opcode.OperandType != global::Mono.Cecil.Cil.OperandType.ShortInlineBrTarget)
			{
				throw new global::System.ArgumentException("opcode");
			}
			return new global::Mono.Cecil.Cil.Instruction(opcode, target);
		}

		// Token: 0x0600060A RID: 1546 RVA: 0x0000EAD5 File Offset: 0x0000CCD5
		public static global::Mono.Cecil.Cil.Instruction Create(global::Mono.Cecil.Cil.OpCode opcode, global::Mono.Cecil.Cil.Instruction[] targets)
		{
			if (targets == null)
			{
				throw new global::System.ArgumentNullException("targets");
			}
			if (opcode.OperandType != global::Mono.Cecil.Cil.OperandType.InlineSwitch)
			{
				throw new global::System.ArgumentException("opcode");
			}
			return new global::Mono.Cecil.Cil.Instruction(opcode, targets);
		}

		// Token: 0x0600060B RID: 1547 RVA: 0x0000EB02 File Offset: 0x0000CD02
		public static global::Mono.Cecil.Cil.Instruction Create(global::Mono.Cecil.Cil.OpCode opcode, global::Mono.Cecil.Cil.VariableDefinition variable)
		{
			if (variable == null)
			{
				throw new global::System.ArgumentNullException("variable");
			}
			if (opcode.OperandType != global::Mono.Cecil.Cil.OperandType.ShortInlineVar && opcode.OperandType != global::Mono.Cecil.Cil.OperandType.InlineVar)
			{
				throw new global::System.ArgumentException("opcode");
			}
			return new global::Mono.Cecil.Cil.Instruction(opcode, variable);
		}

		// Token: 0x0600060C RID: 1548 RVA: 0x0000EB3A File Offset: 0x0000CD3A
		public static global::Mono.Cecil.Cil.Instruction Create(global::Mono.Cecil.Cil.OpCode opcode, global::Mono.Cecil.ParameterDefinition parameter)
		{
			if (parameter == null)
			{
				throw new global::System.ArgumentNullException("parameter");
			}
			if (opcode.OperandType != global::Mono.Cecil.Cil.OperandType.ShortInlineArg && opcode.OperandType != global::Mono.Cecil.Cil.OperandType.InlineArg)
			{
				throw new global::System.ArgumentException("opcode");
			}
			return new global::Mono.Cecil.Cil.Instruction(opcode, parameter);
		}

		// Token: 0x040003A5 RID: 933
		internal int offset;

		// Token: 0x040003A6 RID: 934
		internal global::Mono.Cecil.Cil.OpCode opcode;

		// Token: 0x040003A7 RID: 935
		internal object operand;

		// Token: 0x040003A8 RID: 936
		internal global::Mono.Cecil.Cil.Instruction previous;

		// Token: 0x040003A9 RID: 937
		internal global::Mono.Cecil.Cil.Instruction next;

		// Token: 0x040003AA RID: 938
		private global::Mono.Cecil.Cil.SequencePoint sequence_point;
	}
}
