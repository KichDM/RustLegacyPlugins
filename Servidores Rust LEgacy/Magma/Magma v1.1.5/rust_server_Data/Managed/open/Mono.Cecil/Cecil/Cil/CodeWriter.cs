using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Mono.Cecil.Metadata;
using Mono.Cecil.PE;
using Mono.Collections.Generic;

namespace Mono.Cecil.Cil
{
	// Token: 0x020000BB RID: 187
	internal sealed class CodeWriter : global::Mono.Cecil.PE.ByteBuffer
	{
		// Token: 0x0600076F RID: 1903 RVA: 0x00013877 File Offset: 0x00011A77
		public CodeWriter(global::Mono.Cecil.MetadataBuilder metadata) : base(0)
		{
			this.code_base = metadata.text_map.GetNextRVA(global::Mono.Cecil.PE.TextSegment.CLIHeader);
			this.current = this.code_base;
			this.metadata = metadata;
			this.standalone_signatures = new global::System.Collections.Generic.Dictionary<uint, global::Mono.Cecil.MetadataToken>();
		}

		// Token: 0x06000770 RID: 1904 RVA: 0x000138B0 File Offset: 0x00011AB0
		public uint WriteMethodBody(global::Mono.Cecil.MethodDefinition method)
		{
			uint result = this.BeginMethod();
			if (global::Mono.Cecil.Cil.CodeWriter.IsUnresolved(method))
			{
				if (method.rva == 0U)
				{
					return 0U;
				}
				this.WriteUnresolvedMethodBody(method);
			}
			else
			{
				if (global::Mono.Cecil.Cil.CodeWriter.IsEmptyMethodBody(method.Body))
				{
					return 0U;
				}
				this.WriteResolvedMethodBody(method);
			}
			this.Align(4);
			this.EndMethod();
			return result;
		}

		// Token: 0x06000771 RID: 1905 RVA: 0x00013903 File Offset: 0x00011B03
		private static bool IsEmptyMethodBody(global::Mono.Cecil.Cil.MethodBody body)
		{
			return body.instructions.IsNullOrEmpty<global::Mono.Cecil.Cil.Instruction>() && body.variables.IsNullOrEmpty<global::Mono.Cecil.Cil.VariableDefinition>();
		}

		// Token: 0x06000772 RID: 1906 RVA: 0x0001391F File Offset: 0x00011B1F
		private static bool IsUnresolved(global::Mono.Cecil.MethodDefinition method)
		{
			return method.HasBody && method.HasImage && method.body == null;
		}

		// Token: 0x06000773 RID: 1907 RVA: 0x00013944 File Offset: 0x00011B44
		private void WriteUnresolvedMethodBody(global::Mono.Cecil.MethodDefinition method)
		{
			global::Mono.Cecil.Cil.CodeReader codeReader = this.metadata.module.Read<global::Mono.Cecil.MethodDefinition, global::Mono.Cecil.Cil.CodeReader>(method, (global::Mono.Cecil.MethodDefinition _, global::Mono.Cecil.MetadataReader reader) => reader.code);
			global::Mono.Cecil.Cil.MethodSymbols methodSymbols;
			global::Mono.Cecil.PE.ByteBuffer buffer = codeReader.PatchRawMethodBody(method, this, out methodSymbols);
			base.WriteBytes(buffer);
			if (methodSymbols.instructions.IsNullOrEmpty<global::Mono.Cecil.Cil.InstructionSymbol>())
			{
				return;
			}
			methodSymbols.method_token = method.token;
			methodSymbols.local_var_token = global::Mono.Cecil.Cil.CodeWriter.GetLocalVarToken(buffer, methodSymbols);
			global::Mono.Cecil.Cil.ISymbolWriter symbol_writer = this.metadata.symbol_writer;
			if (symbol_writer != null)
			{
				symbol_writer.Write(methodSymbols);
			}
		}

		// Token: 0x06000774 RID: 1908 RVA: 0x000139CF File Offset: 0x00011BCF
		private static global::Mono.Cecil.MetadataToken GetLocalVarToken(global::Mono.Cecil.PE.ByteBuffer buffer, global::Mono.Cecil.Cil.MethodSymbols symbols)
		{
			if (symbols.variables.IsNullOrEmpty<global::Mono.Cecil.Cil.VariableDefinition>())
			{
				return global::Mono.Cecil.MetadataToken.Zero;
			}
			buffer.position = 8;
			return new global::Mono.Cecil.MetadataToken(buffer.ReadUInt32());
		}

		// Token: 0x06000775 RID: 1909 RVA: 0x000139F8 File Offset: 0x00011BF8
		private void WriteResolvedMethodBody(global::Mono.Cecil.MethodDefinition method)
		{
			this.body = method.Body;
			this.ComputeHeader();
			if (this.RequiresFatHeader())
			{
				this.WriteFatHeader();
			}
			else
			{
				base.WriteByte((byte)(2 | this.body.CodeSize << 2));
			}
			this.WriteInstructions();
			if (this.body.HasExceptionHandlers)
			{
				this.WriteExceptionHandlers();
			}
			global::Mono.Cecil.Cil.ISymbolWriter symbol_writer = this.metadata.symbol_writer;
			if (symbol_writer != null)
			{
				symbol_writer.Write(this.body);
			}
		}

		// Token: 0x06000776 RID: 1910 RVA: 0x00013A74 File Offset: 0x00011C74
		private void WriteFatHeader()
		{
			global::Mono.Cecil.Cil.MethodBody methodBody = this.body;
			byte b = 3;
			if (methodBody.InitLocals)
			{
				b |= 0x10;
			}
			if (methodBody.HasExceptionHandlers)
			{
				b |= 8;
			}
			base.WriteByte(b);
			base.WriteByte(0x30);
			base.WriteInt16((short)methodBody.max_stack_size);
			base.WriteInt32(methodBody.code_size);
			methodBody.local_var_token = (methodBody.HasVariables ? this.GetStandAloneSignature(methodBody.Variables) : global::Mono.Cecil.MetadataToken.Zero);
			this.WriteMetadataToken(methodBody.local_var_token);
		}

		// Token: 0x06000777 RID: 1911 RVA: 0x00013AFC File Offset: 0x00011CFC
		private void WriteInstructions()
		{
			global::Mono.Collections.Generic.Collection<global::Mono.Cecil.Cil.Instruction> instructions = this.body.Instructions;
			global::Mono.Cecil.Cil.Instruction[] items = instructions.items;
			int size = instructions.size;
			for (int i = 0; i < size; i++)
			{
				global::Mono.Cecil.Cil.Instruction instruction = items[i];
				this.WriteOpCode(instruction.opcode);
				this.WriteOperand(instruction);
			}
		}

		// Token: 0x06000778 RID: 1912 RVA: 0x00013B49 File Offset: 0x00011D49
		private void WriteOpCode(global::Mono.Cecil.Cil.OpCode opcode)
		{
			if (opcode.Size == 1)
			{
				base.WriteByte(opcode.Op2);
				return;
			}
			base.WriteByte(opcode.Op1);
			base.WriteByte(opcode.Op2);
		}

		// Token: 0x06000779 RID: 1913 RVA: 0x00013B80 File Offset: 0x00011D80
		private void WriteOperand(global::Mono.Cecil.Cil.Instruction instruction)
		{
			global::Mono.Cecil.Cil.OpCode opcode = instruction.opcode;
			global::Mono.Cecil.Cil.OperandType operandType = opcode.OperandType;
			if (operandType == global::Mono.Cecil.Cil.OperandType.InlineNone)
			{
				return;
			}
			object operand = instruction.operand;
			if (operand == null)
			{
				throw new global::System.ArgumentException();
			}
			switch (operandType)
			{
			case global::Mono.Cecil.Cil.OperandType.InlineBrTarget:
			{
				global::Mono.Cecil.Cil.Instruction instruction2 = (global::Mono.Cecil.Cil.Instruction)operand;
				base.WriteInt32(this.GetTargetOffset(instruction2) - (instruction.Offset + opcode.Size + 4));
				return;
			}
			case global::Mono.Cecil.Cil.OperandType.InlineField:
			case global::Mono.Cecil.Cil.OperandType.InlineMethod:
			case global::Mono.Cecil.Cil.OperandType.InlineTok:
			case global::Mono.Cecil.Cil.OperandType.InlineType:
				this.WriteMetadataToken(this.metadata.LookupToken((global::Mono.Cecil.IMetadataTokenProvider)operand));
				return;
			case global::Mono.Cecil.Cil.OperandType.InlineI:
				base.WriteInt32((int)operand);
				return;
			case global::Mono.Cecil.Cil.OperandType.InlineI8:
				base.WriteInt64((long)operand);
				return;
			case global::Mono.Cecil.Cil.OperandType.InlineR:
				base.WriteDouble((double)operand);
				return;
			case global::Mono.Cecil.Cil.OperandType.InlineSig:
				this.WriteMetadataToken(this.GetStandAloneSignature((global::Mono.Cecil.CallSite)operand));
				return;
			case global::Mono.Cecil.Cil.OperandType.InlineString:
				this.WriteMetadataToken(new global::Mono.Cecil.MetadataToken(global::Mono.Cecil.TokenType.String, this.GetUserStringIndex((string)operand)));
				return;
			case global::Mono.Cecil.Cil.OperandType.InlineSwitch:
			{
				global::Mono.Cecil.Cil.Instruction[] array = (global::Mono.Cecil.Cil.Instruction[])operand;
				base.WriteInt32(array.Length);
				int num = instruction.Offset + opcode.Size + 4 * (array.Length + 1);
				for (int i = 0; i < array.Length; i++)
				{
					base.WriteInt32(this.GetTargetOffset(array[i]) - num);
				}
				return;
			}
			case global::Mono.Cecil.Cil.OperandType.InlineVar:
				base.WriteInt16((short)global::Mono.Cecil.Cil.CodeWriter.GetVariableIndex((global::Mono.Cecil.Cil.VariableDefinition)operand));
				return;
			case global::Mono.Cecil.Cil.OperandType.InlineArg:
				base.WriteInt16((short)this.GetParameterIndex((global::Mono.Cecil.ParameterDefinition)operand));
				return;
			case global::Mono.Cecil.Cil.OperandType.ShortInlineBrTarget:
			{
				global::Mono.Cecil.Cil.Instruction instruction3 = (global::Mono.Cecil.Cil.Instruction)operand;
				base.WriteSByte((sbyte)(this.GetTargetOffset(instruction3) - (instruction.Offset + opcode.Size + 1)));
				return;
			}
			case global::Mono.Cecil.Cil.OperandType.ShortInlineI:
				if (opcode == global::Mono.Cecil.Cil.OpCodes.Ldc_I4_S)
				{
					base.WriteSByte((sbyte)operand);
					return;
				}
				base.WriteByte((byte)operand);
				return;
			case global::Mono.Cecil.Cil.OperandType.ShortInlineR:
				base.WriteSingle((float)operand);
				return;
			case global::Mono.Cecil.Cil.OperandType.ShortInlineVar:
				base.WriteByte((byte)global::Mono.Cecil.Cil.CodeWriter.GetVariableIndex((global::Mono.Cecil.Cil.VariableDefinition)operand));
				return;
			case global::Mono.Cecil.Cil.OperandType.ShortInlineArg:
				base.WriteByte((byte)this.GetParameterIndex((global::Mono.Cecil.ParameterDefinition)operand));
				return;
			}
			throw new global::System.ArgumentException();
		}

		// Token: 0x0600077A RID: 1914 RVA: 0x00013DA8 File Offset: 0x00011FA8
		private int GetTargetOffset(global::Mono.Cecil.Cil.Instruction instruction)
		{
			if (instruction == null)
			{
				global::Mono.Cecil.Cil.Instruction instruction2 = this.body.instructions[this.body.instructions.size - 1];
				return instruction2.offset + instruction2.GetSize();
			}
			return instruction.offset;
		}

		// Token: 0x0600077B RID: 1915 RVA: 0x00013DEF File Offset: 0x00011FEF
		private uint GetUserStringIndex(string @string)
		{
			if (@string == null)
			{
				return 0U;
			}
			return this.metadata.user_string_heap.GetStringIndex(@string);
		}

		// Token: 0x0600077C RID: 1916 RVA: 0x00013E07 File Offset: 0x00012007
		private static int GetVariableIndex(global::Mono.Cecil.Cil.VariableDefinition variable)
		{
			return variable.Index;
		}

		// Token: 0x0600077D RID: 1917 RVA: 0x00013E0F File Offset: 0x0001200F
		private int GetParameterIndex(global::Mono.Cecil.ParameterDefinition parameter)
		{
			if (!this.body.method.HasThis)
			{
				return parameter.Index;
			}
			if (parameter == this.body.this_parameter)
			{
				return 0;
			}
			return parameter.Index + 1;
		}

		// Token: 0x0600077E RID: 1918 RVA: 0x00013E44 File Offset: 0x00012044
		private bool RequiresFatHeader()
		{
			global::Mono.Cecil.Cil.MethodBody methodBody = this.body;
			return methodBody.CodeSize >= 0x40 || methodBody.InitLocals || methodBody.HasVariables || methodBody.HasExceptionHandlers || methodBody.MaxStackSize > 8;
		}

		// Token: 0x0600077F RID: 1919 RVA: 0x00013E88 File Offset: 0x00012088
		private void ComputeHeader()
		{
			int num = 0;
			global::Mono.Collections.Generic.Collection<global::Mono.Cecil.Cil.Instruction> instructions = this.body.instructions;
			global::Mono.Cecil.Cil.Instruction[] items = instructions.items;
			int size = instructions.size;
			int num2 = 0;
			int max_stack_size = 0;
			global::System.Collections.Generic.Dictionary<global::Mono.Cecil.Cil.Instruction, int> dictionary = null;
			if (this.body.HasExceptionHandlers)
			{
				this.ComputeExceptionHandlerStackSize(ref dictionary);
			}
			for (int i = 0; i < size; i++)
			{
				global::Mono.Cecil.Cil.Instruction instruction = items[i];
				instruction.offset = num;
				num += instruction.GetSize();
				global::Mono.Cecil.Cil.CodeWriter.ComputeStackSize(instruction, ref dictionary, ref num2, ref max_stack_size);
			}
			this.body.code_size = num;
			this.body.max_stack_size = max_stack_size;
		}

		// Token: 0x06000780 RID: 1920 RVA: 0x00013F20 File Offset: 0x00012120
		private void ComputeExceptionHandlerStackSize(ref global::System.Collections.Generic.Dictionary<global::Mono.Cecil.Cil.Instruction, int> stack_sizes)
		{
			global::Mono.Collections.Generic.Collection<global::Mono.Cecil.Cil.ExceptionHandler> exceptionHandlers = this.body.ExceptionHandlers;
			for (int i = 0; i < exceptionHandlers.Count; i++)
			{
				global::Mono.Cecil.Cil.ExceptionHandler exceptionHandler = exceptionHandlers[i];
				switch (exceptionHandler.HandlerType)
				{
				case global::Mono.Cecil.Cil.ExceptionHandlerType.Catch:
					global::Mono.Cecil.Cil.CodeWriter.AddExceptionStackSize(exceptionHandler.HandlerStart, ref stack_sizes);
					break;
				case global::Mono.Cecil.Cil.ExceptionHandlerType.Filter:
					global::Mono.Cecil.Cil.CodeWriter.AddExceptionStackSize(exceptionHandler.FilterStart, ref stack_sizes);
					global::Mono.Cecil.Cil.CodeWriter.AddExceptionStackSize(exceptionHandler.HandlerStart, ref stack_sizes);
					break;
				}
			}
		}

		// Token: 0x06000781 RID: 1921 RVA: 0x00013F8F File Offset: 0x0001218F
		private static void AddExceptionStackSize(global::Mono.Cecil.Cil.Instruction handler_start, ref global::System.Collections.Generic.Dictionary<global::Mono.Cecil.Cil.Instruction, int> stack_sizes)
		{
			if (handler_start == null)
			{
				return;
			}
			if (stack_sizes == null)
			{
				stack_sizes = new global::System.Collections.Generic.Dictionary<global::Mono.Cecil.Cil.Instruction, int>();
			}
			stack_sizes[handler_start] = 1;
		}

		// Token: 0x06000782 RID: 1922 RVA: 0x00013FAC File Offset: 0x000121AC
		private static void ComputeStackSize(global::Mono.Cecil.Cil.Instruction instruction, ref global::System.Collections.Generic.Dictionary<global::Mono.Cecil.Cil.Instruction, int> stack_sizes, ref int stack_size, ref int max_stack)
		{
			int num;
			if (stack_sizes != null && stack_sizes.TryGetValue(instruction, out num))
			{
				stack_size = num;
			}
			max_stack = global::System.Math.Max(max_stack, stack_size);
			global::Mono.Cecil.Cil.CodeWriter.ComputeStackDelta(instruction, ref stack_size);
			max_stack = global::System.Math.Max(max_stack, stack_size);
			global::Mono.Cecil.Cil.CodeWriter.CopyBranchStackSize(instruction, ref stack_sizes, stack_size);
			global::Mono.Cecil.Cil.CodeWriter.ComputeStackSize(instruction, ref stack_size);
		}

		// Token: 0x06000783 RID: 1923 RVA: 0x00013FFC File Offset: 0x000121FC
		private static void CopyBranchStackSize(global::Mono.Cecil.Cil.Instruction instruction, ref global::System.Collections.Generic.Dictionary<global::Mono.Cecil.Cil.Instruction, int> stack_sizes, int stack_size)
		{
			if (stack_size == 0)
			{
				return;
			}
			global::Mono.Cecil.Cil.OperandType operandType = instruction.opcode.OperandType;
			if (operandType != global::Mono.Cecil.Cil.OperandType.InlineBrTarget)
			{
				if (operandType == global::Mono.Cecil.Cil.OperandType.InlineSwitch)
				{
					global::Mono.Cecil.Cil.Instruction[] array = (global::Mono.Cecil.Cil.Instruction[])instruction.operand;
					for (int i = 0; i < array.Length; i++)
					{
						global::Mono.Cecil.Cil.CodeWriter.CopyBranchStackSize(ref stack_sizes, array[i], stack_size);
					}
					return;
				}
				if (operandType != global::Mono.Cecil.Cil.OperandType.ShortInlineBrTarget)
				{
					return;
				}
			}
			global::Mono.Cecil.Cil.CodeWriter.CopyBranchStackSize(ref stack_sizes, (global::Mono.Cecil.Cil.Instruction)instruction.operand, stack_size);
		}

		// Token: 0x06000784 RID: 1924 RVA: 0x00014060 File Offset: 0x00012260
		private static void CopyBranchStackSize(ref global::System.Collections.Generic.Dictionary<global::Mono.Cecil.Cil.Instruction, int> stack_sizes, global::Mono.Cecil.Cil.Instruction target, int stack_size)
		{
			if (stack_sizes == null)
			{
				stack_sizes = new global::System.Collections.Generic.Dictionary<global::Mono.Cecil.Cil.Instruction, int>();
			}
			int num = stack_size;
			int val;
			if (stack_sizes.TryGetValue(target, out val))
			{
				num = global::System.Math.Max(num, val);
			}
			stack_sizes[target] = num;
		}

		// Token: 0x06000785 RID: 1925 RVA: 0x00014098 File Offset: 0x00012298
		private static void ComputeStackSize(global::Mono.Cecil.Cil.Instruction instruction, ref int stack_size)
		{
			global::Mono.Cecil.Cil.FlowControl flowControl = instruction.opcode.FlowControl;
			switch (flowControl)
			{
			case global::Mono.Cecil.Cil.FlowControl.Branch:
			case global::Mono.Cecil.Cil.FlowControl.Break:
				break;
			default:
				switch (flowControl)
				{
				case global::Mono.Cecil.Cil.FlowControl.Return:
				case global::Mono.Cecil.Cil.FlowControl.Throw:
					break;
				default:
					return;
				}
				break;
			}
			stack_size = 0;
		}

		// Token: 0x06000786 RID: 1926 RVA: 0x000140D4 File Offset: 0x000122D4
		private static void ComputeStackDelta(global::Mono.Cecil.Cil.Instruction instruction, ref int stack_size)
		{
			global::Mono.Cecil.Cil.FlowControl flowControl = instruction.opcode.FlowControl;
			if (flowControl == global::Mono.Cecil.Cil.FlowControl.Call)
			{
				global::Mono.Cecil.IMethodSignature methodSignature = (global::Mono.Cecil.IMethodSignature)instruction.operand;
				stack_size -= (methodSignature.HasParameters ? methodSignature.Parameters.Count : 0) + ((methodSignature.HasThis && instruction.opcode.Code != global::Mono.Cecil.Cil.Code.Newobj) ? 1 : 0);
				stack_size += ((methodSignature.ReturnType.etype == global::Mono.Cecil.Metadata.ElementType.Void) ? 0 : 1) + ((methodSignature.HasThis && instruction.opcode.Code == global::Mono.Cecil.Cil.Code.Newobj) ? 1 : 0);
				return;
			}
			global::Mono.Cecil.Cil.CodeWriter.ComputePopDelta(instruction.opcode.StackBehaviourPop, ref stack_size);
			global::Mono.Cecil.Cil.CodeWriter.ComputePushDelta(instruction.opcode.StackBehaviourPush, ref stack_size);
		}

		// Token: 0x06000787 RID: 1927 RVA: 0x0001418C File Offset: 0x0001238C
		private static void ComputePopDelta(global::Mono.Cecil.Cil.StackBehaviour pop_behavior, ref int stack_size)
		{
			switch (pop_behavior)
			{
			case global::Mono.Cecil.Cil.StackBehaviour.Pop1:
			case global::Mono.Cecil.Cil.StackBehaviour.Popi:
			case global::Mono.Cecil.Cil.StackBehaviour.Popref:
				stack_size--;
				return;
			case global::Mono.Cecil.Cil.StackBehaviour.Pop1_pop1:
			case global::Mono.Cecil.Cil.StackBehaviour.Popi_pop1:
			case global::Mono.Cecil.Cil.StackBehaviour.Popi_popi:
			case global::Mono.Cecil.Cil.StackBehaviour.Popi_popi8:
			case global::Mono.Cecil.Cil.StackBehaviour.Popi_popr4:
			case global::Mono.Cecil.Cil.StackBehaviour.Popi_popr8:
			case global::Mono.Cecil.Cil.StackBehaviour.Popref_pop1:
			case global::Mono.Cecil.Cil.StackBehaviour.Popref_popi:
				stack_size -= 2;
				return;
			case global::Mono.Cecil.Cil.StackBehaviour.Popi_popi_popi:
			case global::Mono.Cecil.Cil.StackBehaviour.Popref_popi_popi:
			case global::Mono.Cecil.Cil.StackBehaviour.Popref_popi_popi8:
			case global::Mono.Cecil.Cil.StackBehaviour.Popref_popi_popr4:
			case global::Mono.Cecil.Cil.StackBehaviour.Popref_popi_popr8:
			case global::Mono.Cecil.Cil.StackBehaviour.Popref_popi_popref:
				stack_size -= 3;
				return;
			case global::Mono.Cecil.Cil.StackBehaviour.PopAll:
				stack_size = 0;
				return;
			default:
				return;
			}
		}

		// Token: 0x06000788 RID: 1928 RVA: 0x00014204 File Offset: 0x00012404
		private static void ComputePushDelta(global::Mono.Cecil.Cil.StackBehaviour push_behaviour, ref int stack_size)
		{
			switch (push_behaviour)
			{
			case global::Mono.Cecil.Cil.StackBehaviour.Push1:
			case global::Mono.Cecil.Cil.StackBehaviour.Pushi:
			case global::Mono.Cecil.Cil.StackBehaviour.Pushi8:
			case global::Mono.Cecil.Cil.StackBehaviour.Pushr4:
			case global::Mono.Cecil.Cil.StackBehaviour.Pushr8:
			case global::Mono.Cecil.Cil.StackBehaviour.Pushref:
				stack_size++;
				return;
			case global::Mono.Cecil.Cil.StackBehaviour.Push1_push1:
				stack_size += 2;
				return;
			default:
				return;
			}
		}

		// Token: 0x06000789 RID: 1929 RVA: 0x00014248 File Offset: 0x00012448
		private void WriteExceptionHandlers()
		{
			this.Align(4);
			global::Mono.Collections.Generic.Collection<global::Mono.Cecil.Cil.ExceptionHandler> exceptionHandlers = this.body.ExceptionHandlers;
			if (exceptionHandlers.Count < 0x15 && !global::Mono.Cecil.Cil.CodeWriter.RequiresFatSection(exceptionHandlers))
			{
				this.WriteSmallSection(exceptionHandlers);
				return;
			}
			this.WriteFatSection(exceptionHandlers);
		}

		// Token: 0x0600078A RID: 1930 RVA: 0x0001428C File Offset: 0x0001248C
		private static bool RequiresFatSection(global::Mono.Collections.Generic.Collection<global::Mono.Cecil.Cil.ExceptionHandler> handlers)
		{
			for (int i = 0; i < handlers.Count; i++)
			{
				global::Mono.Cecil.Cil.ExceptionHandler exceptionHandler = handlers[i];
				if (global::Mono.Cecil.Cil.CodeWriter.IsFatRange(exceptionHandler.TryStart, exceptionHandler.TryEnd))
				{
					return true;
				}
				if (global::Mono.Cecil.Cil.CodeWriter.IsFatRange(exceptionHandler.HandlerStart, exceptionHandler.HandlerEnd))
				{
					return true;
				}
				if (exceptionHandler.HandlerType == global::Mono.Cecil.Cil.ExceptionHandlerType.Filter && global::Mono.Cecil.Cil.CodeWriter.IsFatRange(exceptionHandler.FilterStart, exceptionHandler.HandlerStart))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600078B RID: 1931 RVA: 0x000142FB File Offset: 0x000124FB
		private static bool IsFatRange(global::Mono.Cecil.Cil.Instruction start, global::Mono.Cecil.Cil.Instruction end)
		{
			return end == null || end.Offset - start.Offset > 0xFF || start.Offset > 0xFFFF;
		}

		// Token: 0x0600078C RID: 1932 RVA: 0x0001433C File Offset: 0x0001253C
		private void WriteSmallSection(global::Mono.Collections.Generic.Collection<global::Mono.Cecil.Cil.ExceptionHandler> handlers)
		{
			base.WriteByte(1);
			base.WriteByte((byte)(handlers.Count * 0xC + 4));
			base.WriteBytes(2);
			this.WriteExceptionHandlers(handlers, delegate(int i)
			{
				base.WriteUInt16((ushort)i);
			}, delegate(int i)
			{
				base.WriteByte((byte)i);
			});
		}

		// Token: 0x0600078D RID: 1933 RVA: 0x00014388 File Offset: 0x00012588
		private void WriteFatSection(global::Mono.Collections.Generic.Collection<global::Mono.Cecil.Cil.ExceptionHandler> handlers)
		{
			base.WriteByte(0x41);
			int num = handlers.Count * 0x18 + 4;
			base.WriteByte((byte)(num & 0xFF));
			base.WriteByte((byte)(num >> 8 & 0xFF));
			base.WriteByte((byte)(num >> 0x10 & 0xFF));
			this.WriteExceptionHandlers(handlers, new global::System.Action<int>(base.WriteInt32), new global::System.Action<int>(base.WriteInt32));
		}

		// Token: 0x0600078E RID: 1934 RVA: 0x000143F8 File Offset: 0x000125F8
		private void WriteExceptionHandlers(global::Mono.Collections.Generic.Collection<global::Mono.Cecil.Cil.ExceptionHandler> handlers, global::System.Action<int> write_entry, global::System.Action<int> write_length)
		{
			for (int i = 0; i < handlers.Count; i++)
			{
				global::Mono.Cecil.Cil.ExceptionHandler exceptionHandler = handlers[i];
				write_entry((int)exceptionHandler.HandlerType);
				write_entry(exceptionHandler.TryStart.Offset);
				write_length(this.GetTargetOffset(exceptionHandler.TryEnd) - exceptionHandler.TryStart.Offset);
				write_entry(exceptionHandler.HandlerStart.Offset);
				write_length(this.GetTargetOffset(exceptionHandler.HandlerEnd) - exceptionHandler.HandlerStart.Offset);
				this.WriteExceptionHandlerSpecific(exceptionHandler);
			}
		}

		// Token: 0x0600078F RID: 1935 RVA: 0x00014494 File Offset: 0x00012694
		private void WriteExceptionHandlerSpecific(global::Mono.Cecil.Cil.ExceptionHandler handler)
		{
			switch (handler.HandlerType)
			{
			case global::Mono.Cecil.Cil.ExceptionHandlerType.Catch:
				this.WriteMetadataToken(this.metadata.LookupToken(handler.CatchType));
				return;
			case global::Mono.Cecil.Cil.ExceptionHandlerType.Filter:
				base.WriteInt32(handler.FilterStart.Offset);
				return;
			default:
				base.WriteInt32(0);
				return;
			}
		}

		// Token: 0x06000790 RID: 1936 RVA: 0x000144EC File Offset: 0x000126EC
		public global::Mono.Cecil.MetadataToken GetStandAloneSignature(global::Mono.Collections.Generic.Collection<global::Mono.Cecil.Cil.VariableDefinition> variables)
		{
			uint localVariableBlobIndex = this.metadata.GetLocalVariableBlobIndex(variables);
			return this.GetStandAloneSignatureToken(localVariableBlobIndex);
		}

		// Token: 0x06000791 RID: 1937 RVA: 0x00014510 File Offset: 0x00012710
		public global::Mono.Cecil.MetadataToken GetStandAloneSignature(global::Mono.Cecil.CallSite call_site)
		{
			uint callSiteBlobIndex = this.metadata.GetCallSiteBlobIndex(call_site);
			global::Mono.Cecil.MetadataToken standAloneSignatureToken = this.GetStandAloneSignatureToken(callSiteBlobIndex);
			call_site.MetadataToken = standAloneSignatureToken;
			return standAloneSignatureToken;
		}

		// Token: 0x06000792 RID: 1938 RVA: 0x0001453C File Offset: 0x0001273C
		private global::Mono.Cecil.MetadataToken GetStandAloneSignatureToken(uint signature)
		{
			global::Mono.Cecil.MetadataToken metadataToken;
			if (this.standalone_signatures.TryGetValue(signature, out metadataToken))
			{
				return metadataToken;
			}
			metadataToken = new global::Mono.Cecil.MetadataToken(global::Mono.Cecil.TokenType.Signature, this.metadata.AddStandAloneSignature(signature));
			this.standalone_signatures.Add(signature, metadataToken);
			return metadataToken;
		}

		// Token: 0x06000793 RID: 1939 RVA: 0x00014586 File Offset: 0x00012786
		private uint BeginMethod()
		{
			return this.current;
		}

		// Token: 0x06000794 RID: 1940 RVA: 0x0001458E File Offset: 0x0001278E
		private void WriteMetadataToken(global::Mono.Cecil.MetadataToken token)
		{
			base.WriteUInt32(token.ToUInt32());
		}

		// Token: 0x06000795 RID: 1941 RVA: 0x0001459D File Offset: 0x0001279D
		private void Align(int align)
		{
			align--;
			base.WriteBytes((this.position + align & ~align) - this.position);
		}

		// Token: 0x06000796 RID: 1942 RVA: 0x000145BC File Offset: 0x000127BC
		private void EndMethod()
		{
			this.current = (uint)((ulong)this.code_base + (ulong)((long)this.position));
		}

		// Token: 0x06000797 RID: 1943 RVA: 0x0001393C File Offset: 0x00011B3C
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static global::Mono.Cecil.Cil.CodeReader <WriteUnresolvedMethodBody>b__0(global::Mono.Cecil.MethodDefinition _, global::Mono.Cecil.MetadataReader reader)
		{
			return reader.code;
		}

		// Token: 0x06000798 RID: 1944 RVA: 0x00014325 File Offset: 0x00012525
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private void <WriteSmallSection>b__2(int i)
		{
			base.WriteUInt16((ushort)i);
		}

		// Token: 0x06000799 RID: 1945 RVA: 0x0001432F File Offset: 0x0001252F
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private void <WriteSmallSection>b__3(int i)
		{
			base.WriteByte((byte)i);
		}

		// Token: 0x040005B1 RID: 1457
		private readonly uint code_base;

		// Token: 0x040005B2 RID: 1458
		internal readonly global::Mono.Cecil.MetadataBuilder metadata;

		// Token: 0x040005B3 RID: 1459
		private readonly global::System.Collections.Generic.Dictionary<uint, global::Mono.Cecil.MetadataToken> standalone_signatures;

		// Token: 0x040005B4 RID: 1460
		private uint current;

		// Token: 0x040005B5 RID: 1461
		private global::Mono.Cecil.Cil.MethodBody body;

		// Token: 0x040005B6 RID: 1462
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static global::System.Func<global::Mono.Cecil.MethodDefinition, global::Mono.Cecil.MetadataReader, global::Mono.Cecil.Cil.CodeReader> CS$<>9__CachedAnonymousMethodDelegate1;
	}
}
