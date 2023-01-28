using System;
using System.Runtime.CompilerServices;
using Mono.Cecil.PE;
using Mono.Collections.Generic;

namespace Mono.Cecil.Cil
{
	// Token: 0x020000BC RID: 188
	internal sealed class CodeReader : global::Mono.Cecil.PE.ByteBuffer
	{
		// Token: 0x1700029B RID: 667
		// (get) Token: 0x0600079A RID: 1946 RVA: 0x000145D4 File Offset: 0x000127D4
		private int Offset
		{
			get
			{
				return this.position - this.start;
			}
		}

		// Token: 0x0600079B RID: 1947 RVA: 0x000145E3 File Offset: 0x000127E3
		public CodeReader(global::Mono.Cecil.PE.Section section, global::Mono.Cecil.MetadataReader reader) : base(section.Data)
		{
			this.code_section = section;
			this.reader = reader;
		}

		// Token: 0x0600079C RID: 1948 RVA: 0x000145FF File Offset: 0x000127FF
		public global::Mono.Cecil.Cil.MethodBody ReadMethodBody(global::Mono.Cecil.MethodDefinition method)
		{
			this.method = method;
			this.body = new global::Mono.Cecil.Cil.MethodBody(method);
			this.reader.context = method;
			this.ReadMethodBody();
			return this.body;
		}

		// Token: 0x0600079D RID: 1949 RVA: 0x0001462C File Offset: 0x0001282C
		public void MoveTo(int rva)
		{
			if (!this.IsInSection(rva))
			{
				this.code_section = this.reader.image.GetSectionAtVirtualAddress((uint)rva);
				base.Reset(this.code_section.Data);
			}
			this.position = rva - (int)this.code_section.VirtualAddress;
		}

		// Token: 0x0600079E RID: 1950 RVA: 0x0001467D File Offset: 0x0001287D
		private bool IsInSection(int rva)
		{
			return (ulong)this.code_section.VirtualAddress <= (ulong)((long)rva) && (long)rva < (long)((ulong)(this.code_section.VirtualAddress + this.code_section.SizeOfRawData));
		}

		// Token: 0x0600079F RID: 1951 RVA: 0x000146C4 File Offset: 0x000128C4
		private void ReadMethodBody()
		{
			this.MoveTo(this.method.RVA);
			byte b = base.ReadByte();
			switch (b & 3)
			{
			case 2:
				this.body.code_size = b >> 2;
				this.body.MaxStackSize = 8;
				this.ReadCode();
				break;
			case 3:
				this.position--;
				this.ReadFatMethod();
				break;
			default:
				throw new global::System.InvalidOperationException();
			}
			global::Mono.Cecil.Cil.ISymbolReader symbolReader = this.reader.module.SymbolReader;
			if (symbolReader != null)
			{
				global::Mono.Collections.Generic.Collection<global::Mono.Cecil.Cil.Instruction> instructions = this.body.Instructions;
				symbolReader.Read(this.body, (int offset) => global::Mono.Cecil.Cil.CodeReader.GetInstruction(instructions, offset));
			}
		}

		// Token: 0x060007A0 RID: 1952 RVA: 0x00014780 File Offset: 0x00012980
		private void ReadFatMethod()
		{
			ushort num = base.ReadUInt16();
			this.body.max_stack_size = (int)base.ReadUInt16();
			this.body.code_size = (int)base.ReadUInt32();
			this.body.local_var_token = new global::Mono.Cecil.MetadataToken(base.ReadUInt32());
			this.body.init_locals = ((num & 0x10) != 0);
			if (this.body.local_var_token.RID != 0U)
			{
				this.body.variables = this.ReadVariables(this.body.local_var_token);
			}
			this.ReadCode();
			if ((num & 8) != 0)
			{
				this.ReadSection();
			}
		}

		// Token: 0x060007A1 RID: 1953 RVA: 0x00014820 File Offset: 0x00012A20
		public global::Mono.Cecil.Cil.VariableDefinitionCollection ReadVariables(global::Mono.Cecil.MetadataToken local_var_token)
		{
			int position = this.reader.position;
			global::Mono.Cecil.Cil.VariableDefinitionCollection result = this.reader.ReadVariables(local_var_token);
			this.reader.position = position;
			return result;
		}

		// Token: 0x060007A2 RID: 1954 RVA: 0x00014854 File Offset: 0x00012A54
		private void ReadCode()
		{
			this.start = this.position;
			int num = this.body.code_size;
			if (num < 0 || (long)this.buffer.Length <= (long)((ulong)(num + this.position)))
			{
				num = 0;
			}
			int num2 = this.start + num;
			global::Mono.Collections.Generic.Collection<global::Mono.Cecil.Cil.Instruction> collection = this.body.instructions = new global::Mono.Cecil.Cil.InstructionCollection(num / 3);
			while (this.position < num2)
			{
				int offset = this.position - this.start;
				global::Mono.Cecil.Cil.OpCode opCode = this.ReadOpCode();
				global::Mono.Cecil.Cil.Instruction instruction = new global::Mono.Cecil.Cil.Instruction(offset, opCode);
				if (opCode.OperandType != global::Mono.Cecil.Cil.OperandType.InlineNone)
				{
					instruction.operand = this.ReadOperand(instruction);
				}
				collection.Add(instruction);
			}
			this.ResolveBranches(collection);
		}

		// Token: 0x060007A3 RID: 1955 RVA: 0x00014908 File Offset: 0x00012B08
		private global::Mono.Cecil.Cil.OpCode ReadOpCode()
		{
			byte b = base.ReadByte();
			if (b == 0xFE)
			{
				return global::Mono.Cecil.Cil.OpCodes.TwoBytesOpCode[(int)base.ReadByte()];
			}
			return global::Mono.Cecil.Cil.OpCodes.OneByteOpCode[(int)b];
		}

		// Token: 0x060007A4 RID: 1956 RVA: 0x0001494C File Offset: 0x00012B4C
		private object ReadOperand(global::Mono.Cecil.Cil.Instruction instruction)
		{
			switch (instruction.opcode.OperandType)
			{
			case global::Mono.Cecil.Cil.OperandType.InlineBrTarget:
				return base.ReadInt32() + this.Offset;
			case global::Mono.Cecil.Cil.OperandType.InlineField:
			case global::Mono.Cecil.Cil.OperandType.InlineMethod:
			case global::Mono.Cecil.Cil.OperandType.InlineTok:
			case global::Mono.Cecil.Cil.OperandType.InlineType:
				return this.reader.LookupToken(this.ReadToken());
			case global::Mono.Cecil.Cil.OperandType.InlineI:
				return base.ReadInt32();
			case global::Mono.Cecil.Cil.OperandType.InlineI8:
				return base.ReadInt64();
			case global::Mono.Cecil.Cil.OperandType.InlineR:
				return base.ReadDouble();
			case global::Mono.Cecil.Cil.OperandType.InlineSig:
				return this.GetCallSite(this.ReadToken());
			case global::Mono.Cecil.Cil.OperandType.InlineString:
				return this.GetString(this.ReadToken());
			case global::Mono.Cecil.Cil.OperandType.InlineSwitch:
			{
				int num = base.ReadInt32();
				int num2 = this.Offset + 4 * num;
				int[] array = new int[num];
				for (int i = 0; i < num; i++)
				{
					array[i] = num2 + base.ReadInt32();
				}
				return array;
			}
			case global::Mono.Cecil.Cil.OperandType.InlineVar:
				return this.GetVariable((int)base.ReadUInt16());
			case global::Mono.Cecil.Cil.OperandType.InlineArg:
				return this.GetParameter((int)base.ReadUInt16());
			case global::Mono.Cecil.Cil.OperandType.ShortInlineBrTarget:
				return (int)base.ReadSByte() + this.Offset;
			case global::Mono.Cecil.Cil.OperandType.ShortInlineI:
				if (instruction.opcode == global::Mono.Cecil.Cil.OpCodes.Ldc_I4_S)
				{
					return base.ReadSByte();
				}
				return base.ReadByte();
			case global::Mono.Cecil.Cil.OperandType.ShortInlineR:
				return base.ReadSingle();
			case global::Mono.Cecil.Cil.OperandType.ShortInlineVar:
				return this.GetVariable((int)base.ReadByte());
			case global::Mono.Cecil.Cil.OperandType.ShortInlineArg:
				return this.GetParameter((int)base.ReadByte());
			}
			throw new global::System.NotSupportedException();
		}

		// Token: 0x060007A5 RID: 1957 RVA: 0x00014AD9 File Offset: 0x00012CD9
		public string GetString(global::Mono.Cecil.MetadataToken token)
		{
			return this.reader.image.UserStringHeap.Read(token.RID);
		}

		// Token: 0x060007A6 RID: 1958 RVA: 0x00014AF7 File Offset: 0x00012CF7
		public global::Mono.Cecil.ParameterDefinition GetParameter(int index)
		{
			return this.body.GetParameter(index);
		}

		// Token: 0x060007A7 RID: 1959 RVA: 0x00014B05 File Offset: 0x00012D05
		public global::Mono.Cecil.Cil.VariableDefinition GetVariable(int index)
		{
			return this.body.GetVariable(index);
		}

		// Token: 0x060007A8 RID: 1960 RVA: 0x00014B13 File Offset: 0x00012D13
		public global::Mono.Cecil.CallSite GetCallSite(global::Mono.Cecil.MetadataToken token)
		{
			return this.reader.ReadCallSite(token);
		}

		// Token: 0x060007A9 RID: 1961 RVA: 0x00014B24 File Offset: 0x00012D24
		private void ResolveBranches(global::Mono.Collections.Generic.Collection<global::Mono.Cecil.Cil.Instruction> instructions)
		{
			global::Mono.Cecil.Cil.Instruction[] items = instructions.items;
			int size = instructions.size;
			int i = 0;
			while (i < size)
			{
				global::Mono.Cecil.Cil.Instruction instruction = items[i];
				global::Mono.Cecil.Cil.OperandType operandType = instruction.opcode.OperandType;
				if (operandType == global::Mono.Cecil.Cil.OperandType.InlineBrTarget)
				{
					goto IL_37;
				}
				if (operandType != global::Mono.Cecil.Cil.OperandType.InlineSwitch)
				{
					if (operandType == global::Mono.Cecil.Cil.OperandType.ShortInlineBrTarget)
					{
						goto IL_37;
					}
				}
				else
				{
					int[] array = (int[])instruction.operand;
					global::Mono.Cecil.Cil.Instruction[] array2 = new global::Mono.Cecil.Cil.Instruction[array.Length];
					for (int j = 0; j < array.Length; j++)
					{
						array2[j] = this.GetInstruction(array[j]);
					}
					instruction.operand = array2;
				}
				IL_93:
				i++;
				continue;
				IL_37:
				instruction.operand = this.GetInstruction((int)instruction.operand);
				goto IL_93;
			}
		}

		// Token: 0x060007AA RID: 1962 RVA: 0x00014BCF File Offset: 0x00012DCF
		private global::Mono.Cecil.Cil.Instruction GetInstruction(int offset)
		{
			return global::Mono.Cecil.Cil.CodeReader.GetInstruction(this.body.Instructions, offset);
		}

		// Token: 0x060007AB RID: 1963 RVA: 0x00014BE4 File Offset: 0x00012DE4
		private static global::Mono.Cecil.Cil.Instruction GetInstruction(global::Mono.Collections.Generic.Collection<global::Mono.Cecil.Cil.Instruction> instructions, int offset)
		{
			int size = instructions.size;
			global::Mono.Cecil.Cil.Instruction[] items = instructions.items;
			if (offset < 0 || offset > items[size - 1].offset)
			{
				return null;
			}
			int i = 0;
			int num = size - 1;
			while (i <= num)
			{
				int num2 = i + (num - i) / 2;
				global::Mono.Cecil.Cil.Instruction instruction = items[num2];
				int offset2 = instruction.offset;
				if (offset == offset2)
				{
					return instruction;
				}
				if (offset < offset2)
				{
					num = num2 - 1;
				}
				else
				{
					i = num2 + 1;
				}
			}
			return null;
		}

		// Token: 0x060007AC RID: 1964 RVA: 0x00014C50 File Offset: 0x00012E50
		private void ReadSection()
		{
			this.Align(4);
			byte b = base.ReadByte();
			if ((b & 0x40) == 0)
			{
				this.ReadSmallSection();
			}
			else
			{
				this.ReadFatSection();
			}
			if ((b & 0x80) != 0)
			{
				this.ReadSection();
			}
		}

		// Token: 0x060007AD RID: 1965 RVA: 0x00014CA0 File Offset: 0x00012EA0
		private void ReadSmallSection()
		{
			int count = (int)(base.ReadByte() / 0xC);
			base.Advance(2);
			this.ReadExceptionHandlers(count, () => (int)base.ReadUInt16(), () => (int)base.ReadByte());
		}

		// Token: 0x060007AE RID: 1966 RVA: 0x00014CE0 File Offset: 0x00012EE0
		private void ReadFatSection()
		{
			this.position--;
			int count = (base.ReadInt32() >> 8) / 0x18;
			this.ReadExceptionHandlers(count, new global::System.Func<int>(base.ReadInt32), new global::System.Func<int>(base.ReadInt32));
		}

		// Token: 0x060007AF RID: 1967 RVA: 0x00014D28 File Offset: 0x00012F28
		private void ReadExceptionHandlers(int count, global::System.Func<int> read_entry, global::System.Func<int> read_length)
		{
			for (int i = 0; i < count; i++)
			{
				global::Mono.Cecil.Cil.ExceptionHandler exceptionHandler = new global::Mono.Cecil.Cil.ExceptionHandler((global::Mono.Cecil.Cil.ExceptionHandlerType)(read_entry() & 7));
				exceptionHandler.TryStart = this.GetInstruction(read_entry());
				exceptionHandler.TryEnd = this.GetInstruction(exceptionHandler.TryStart.Offset + read_length());
				exceptionHandler.HandlerStart = this.GetInstruction(read_entry());
				exceptionHandler.HandlerEnd = this.GetInstruction(exceptionHandler.HandlerStart.Offset + read_length());
				this.ReadExceptionHandlerSpecific(exceptionHandler);
				this.body.ExceptionHandlers.Add(exceptionHandler);
			}
		}

		// Token: 0x060007B0 RID: 1968 RVA: 0x00014DD0 File Offset: 0x00012FD0
		private void ReadExceptionHandlerSpecific(global::Mono.Cecil.Cil.ExceptionHandler handler)
		{
			switch (handler.HandlerType)
			{
			case global::Mono.Cecil.Cil.ExceptionHandlerType.Catch:
				handler.CatchType = (global::Mono.Cecil.TypeReference)this.reader.LookupToken(this.ReadToken());
				return;
			case global::Mono.Cecil.Cil.ExceptionHandlerType.Filter:
				handler.FilterStart = this.GetInstruction(base.ReadInt32());
				return;
			default:
				base.Advance(4);
				return;
			}
		}

		// Token: 0x060007B1 RID: 1969 RVA: 0x00014E2B File Offset: 0x0001302B
		private void Align(int align)
		{
			align--;
			base.Advance((this.position + align & ~align) - this.position);
		}

		// Token: 0x060007B2 RID: 1970 RVA: 0x00014E4A File Offset: 0x0001304A
		public global::Mono.Cecil.MetadataToken ReadToken()
		{
			return new global::Mono.Cecil.MetadataToken(base.ReadUInt32());
		}

		// Token: 0x060007B3 RID: 1971 RVA: 0x00014E58 File Offset: 0x00013058
		public global::Mono.Cecil.PE.ByteBuffer PatchRawMethodBody(global::Mono.Cecil.MethodDefinition method, global::Mono.Cecil.Cil.CodeWriter writer, out global::Mono.Cecil.Cil.MethodSymbols symbols)
		{
			global::Mono.Cecil.PE.ByteBuffer byteBuffer = new global::Mono.Cecil.PE.ByteBuffer();
			symbols = new global::Mono.Cecil.Cil.MethodSymbols(method.Name);
			this.method = method;
			this.reader.context = method;
			this.MoveTo(method.RVA);
			byte b = base.ReadByte();
			global::Mono.Cecil.MetadataToken zero;
			switch (b & 3)
			{
			case 2:
				byteBuffer.WriteByte(b);
				zero = global::Mono.Cecil.MetadataToken.Zero;
				symbols.code_size = b >> 2;
				this.PatchRawCode(byteBuffer, symbols.code_size, writer);
				break;
			case 3:
				this.position--;
				this.PatchRawFatMethod(byteBuffer, symbols, writer, out zero);
				break;
			default:
				throw new global::System.NotSupportedException();
			}
			global::Mono.Cecil.Cil.ISymbolReader symbolReader = this.reader.module.SymbolReader;
			if (symbolReader != null && writer.metadata.write_symbols)
			{
				symbols.method_token = global::Mono.Cecil.Cil.CodeReader.GetOriginalToken(writer.metadata, method);
				symbols.local_var_token = zero;
				symbolReader.Read(symbols);
			}
			return byteBuffer;
		}

		// Token: 0x060007B4 RID: 1972 RVA: 0x00014F48 File Offset: 0x00013148
		private void PatchRawFatMethod(global::Mono.Cecil.PE.ByteBuffer buffer, global::Mono.Cecil.Cil.MethodSymbols symbols, global::Mono.Cecil.Cil.CodeWriter writer, out global::Mono.Cecil.MetadataToken local_var_token)
		{
			ushort num = base.ReadUInt16();
			buffer.WriteUInt16(num);
			buffer.WriteUInt16(base.ReadUInt16());
			symbols.code_size = base.ReadInt32();
			buffer.WriteInt32(symbols.code_size);
			local_var_token = this.ReadToken();
			if (local_var_token.RID > 0U)
			{
				buffer.WriteUInt32(((symbols.variables = this.ReadVariables(local_var_token)) != null) ? writer.GetStandAloneSignature(symbols.variables).ToUInt32() : 0U);
			}
			else
			{
				buffer.WriteUInt32(0U);
			}
			this.PatchRawCode(buffer, symbols.code_size, writer);
			if ((num & 8) != 0)
			{
				this.PatchRawSection(buffer, writer.metadata);
			}
		}

		// Token: 0x060007B5 RID: 1973 RVA: 0x00015000 File Offset: 0x00013200
		private static global::Mono.Cecil.MetadataToken GetOriginalToken(global::Mono.Cecil.MetadataBuilder metadata, global::Mono.Cecil.MethodDefinition method)
		{
			global::Mono.Cecil.MetadataToken result;
			if (metadata.TryGetOriginalMethodToken(method.token, out result))
			{
				return result;
			}
			return global::Mono.Cecil.MetadataToken.Zero;
		}

		// Token: 0x060007B6 RID: 1974 RVA: 0x00015024 File Offset: 0x00013224
		private void PatchRawCode(global::Mono.Cecil.PE.ByteBuffer buffer, int code_size, global::Mono.Cecil.Cil.CodeWriter writer)
		{
			global::Mono.Cecil.MetadataBuilder metadata = writer.metadata;
			buffer.WriteBytes(base.ReadBytes(code_size));
			int position = buffer.position;
			buffer.position -= code_size;
			while (buffer.position < position)
			{
				byte b = buffer.ReadByte();
				global::Mono.Cecil.Cil.OpCode opCode;
				if (b != 0xFE)
				{
					opCode = global::Mono.Cecil.Cil.OpCodes.OneByteOpCode[(int)b];
				}
				else
				{
					byte b2 = buffer.ReadByte();
					opCode = global::Mono.Cecil.Cil.OpCodes.TwoBytesOpCode[(int)b2];
				}
				switch (opCode.OperandType)
				{
				case global::Mono.Cecil.Cil.OperandType.InlineBrTarget:
				case global::Mono.Cecil.Cil.OperandType.InlineI:
				case global::Mono.Cecil.Cil.OperandType.ShortInlineR:
					buffer.position += 4;
					break;
				case global::Mono.Cecil.Cil.OperandType.InlineField:
				case global::Mono.Cecil.Cil.OperandType.InlineMethod:
				case global::Mono.Cecil.Cil.OperandType.InlineTok:
				case global::Mono.Cecil.Cil.OperandType.InlineType:
				{
					global::Mono.Cecil.IMetadataTokenProvider provider = this.reader.LookupToken(new global::Mono.Cecil.MetadataToken(buffer.ReadUInt32()));
					buffer.position -= 4;
					buffer.WriteUInt32(metadata.LookupToken(provider).ToUInt32());
					break;
				}
				case global::Mono.Cecil.Cil.OperandType.InlineI8:
				case global::Mono.Cecil.Cil.OperandType.InlineR:
					buffer.position += 8;
					break;
				case global::Mono.Cecil.Cil.OperandType.InlineSig:
				{
					global::Mono.Cecil.CallSite callSite = this.GetCallSite(new global::Mono.Cecil.MetadataToken(buffer.ReadUInt32()));
					buffer.position -= 4;
					buffer.WriteUInt32(writer.GetStandAloneSignature(callSite).ToUInt32());
					break;
				}
				case global::Mono.Cecil.Cil.OperandType.InlineString:
				{
					string @string = this.GetString(new global::Mono.Cecil.MetadataToken(buffer.ReadUInt32()));
					buffer.position -= 4;
					buffer.WriteUInt32(new global::Mono.Cecil.MetadataToken(global::Mono.Cecil.TokenType.String, metadata.user_string_heap.GetStringIndex(@string)).ToUInt32());
					break;
				}
				case global::Mono.Cecil.Cil.OperandType.InlineSwitch:
				{
					int num = buffer.ReadInt32();
					buffer.position += num * 4;
					break;
				}
				case global::Mono.Cecil.Cil.OperandType.InlineVar:
				case global::Mono.Cecil.Cil.OperandType.InlineArg:
					buffer.position += 2;
					break;
				case global::Mono.Cecil.Cil.OperandType.ShortInlineBrTarget:
				case global::Mono.Cecil.Cil.OperandType.ShortInlineI:
				case global::Mono.Cecil.Cil.OperandType.ShortInlineVar:
				case global::Mono.Cecil.Cil.OperandType.ShortInlineArg:
					buffer.position++;
					break;
				}
			}
		}

		// Token: 0x060007B7 RID: 1975 RVA: 0x00015238 File Offset: 0x00013438
		private void PatchRawSection(global::Mono.Cecil.PE.ByteBuffer buffer, global::Mono.Cecil.MetadataBuilder metadata)
		{
			int position = this.position;
			this.Align(4);
			buffer.WriteBytes(this.position - position);
			byte b = base.ReadByte();
			if ((b & 0x40) == 0)
			{
				buffer.WriteByte(b);
				this.PatchRawSmallSection(buffer, metadata);
			}
			else
			{
				this.PatchRawFatSection(buffer, metadata);
			}
			if ((b & 0x80) != 0)
			{
				this.PatchRawSection(buffer, metadata);
			}
		}

		// Token: 0x060007B8 RID: 1976 RVA: 0x00015298 File Offset: 0x00013498
		private void PatchRawSmallSection(global::Mono.Cecil.PE.ByteBuffer buffer, global::Mono.Cecil.MetadataBuilder metadata)
		{
			byte b = base.ReadByte();
			buffer.WriteByte(b);
			base.Advance(2);
			buffer.WriteUInt16(0);
			int count = (int)(b / 0xC);
			this.PatchRawExceptionHandlers(buffer, metadata, count, false);
		}

		// Token: 0x060007B9 RID: 1977 RVA: 0x000152D0 File Offset: 0x000134D0
		private void PatchRawFatSection(global::Mono.Cecil.PE.ByteBuffer buffer, global::Mono.Cecil.MetadataBuilder metadata)
		{
			this.position--;
			int num = base.ReadInt32();
			buffer.WriteInt32(num);
			int count = (num >> 8) / 0x18;
			this.PatchRawExceptionHandlers(buffer, metadata, count, true);
		}

		// Token: 0x060007BA RID: 1978 RVA: 0x0001530C File Offset: 0x0001350C
		private void PatchRawExceptionHandlers(global::Mono.Cecil.PE.ByteBuffer buffer, global::Mono.Cecil.MetadataBuilder metadata, int count, bool fat_entry)
		{
			for (int i = 0; i < count; i++)
			{
				global::Mono.Cecil.Cil.ExceptionHandlerType exceptionHandlerType;
				if (fat_entry)
				{
					uint num = base.ReadUInt32();
					exceptionHandlerType = (global::Mono.Cecil.Cil.ExceptionHandlerType)(num & 7U);
					buffer.WriteUInt32(num);
				}
				else
				{
					ushort num2 = base.ReadUInt16();
					exceptionHandlerType = (global::Mono.Cecil.Cil.ExceptionHandlerType)(num2 & 7);
					buffer.WriteUInt16(num2);
				}
				buffer.WriteBytes(base.ReadBytes(fat_entry ? 0x10 : 6));
				global::Mono.Cecil.Cil.ExceptionHandlerType exceptionHandlerType2 = exceptionHandlerType;
				if (exceptionHandlerType2 == global::Mono.Cecil.Cil.ExceptionHandlerType.Catch)
				{
					global::Mono.Cecil.IMetadataTokenProvider provider = this.reader.LookupToken(this.ReadToken());
					buffer.WriteUInt32(metadata.LookupToken(provider).ToUInt32());
				}
				else
				{
					buffer.WriteUInt32(base.ReadUInt32());
				}
			}
		}

		// Token: 0x060007BB RID: 1979 RVA: 0x00014C8E File Offset: 0x00012E8E
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private int <ReadSmallSection>b__3()
		{
			return (int)base.ReadUInt16();
		}

		// Token: 0x060007BC RID: 1980 RVA: 0x00014C96 File Offset: 0x00012E96
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private int <ReadSmallSection>b__4()
		{
			return (int)base.ReadByte();
		}

		// Token: 0x040005B7 RID: 1463
		internal readonly global::Mono.Cecil.MetadataReader reader;

		// Token: 0x040005B8 RID: 1464
		private int start;

		// Token: 0x040005B9 RID: 1465
		private global::Mono.Cecil.PE.Section code_section;

		// Token: 0x040005BA RID: 1466
		private global::Mono.Cecil.MethodDefinition method;

		// Token: 0x040005BB RID: 1467
		private global::Mono.Cecil.Cil.MethodBody body;

		// Token: 0x020000FE RID: 254
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private sealed class <>c__DisplayClass1
		{
			// Token: 0x060009CF RID: 2511 RVA: 0x000146AD File Offset: 0x000128AD
			public <>c__DisplayClass1()
			{
			}

			// Token: 0x060009D0 RID: 2512 RVA: 0x000146B5 File Offset: 0x000128B5
			public global::Mono.Cecil.Cil.Instruction <ReadMethodBody>b__0(int offset)
			{
				return global::Mono.Cecil.Cil.CodeReader.GetInstruction(this.instructions, offset);
			}

			// Token: 0x04000629 RID: 1577
			public global::Mono.Collections.Generic.Collection<global::Mono.Cecil.Cil.Instruction> instructions;
		}
	}
}
