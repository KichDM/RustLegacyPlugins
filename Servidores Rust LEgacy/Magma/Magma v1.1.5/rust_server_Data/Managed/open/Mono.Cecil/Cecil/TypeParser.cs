using System;
using System.Text;
using Mono.Cecil.Metadata;
using Mono.Collections.Generic;

namespace Mono.Cecil
{
	// Token: 0x02000032 RID: 50
	internal class TypeParser
	{
		// Token: 0x060002C6 RID: 710 RVA: 0x00008526 File Offset: 0x00006726
		private TypeParser(string fullname)
		{
			this.fullname = fullname;
			this.length = fullname.Length;
		}

		// Token: 0x060002C7 RID: 711 RVA: 0x00008544 File Offset: 0x00006744
		private global::Mono.Cecil.TypeParser.Type ParseType(bool fq_name)
		{
			global::Mono.Cecil.TypeParser.Type type = new global::Mono.Cecil.TypeParser.Type();
			type.type_fullname = this.ParsePart();
			type.nested_names = this.ParseNestedNames();
			if (global::Mono.Cecil.TypeParser.TryGetArity(type))
			{
				type.generic_arguments = this.ParseGenericArguments(type.arity);
			}
			type.specs = this.ParseSpecs();
			if (fq_name)
			{
				type.assembly = this.ParseAssemblyName();
			}
			return type;
		}

		// Token: 0x060002C8 RID: 712 RVA: 0x000085A8 File Offset: 0x000067A8
		private static bool TryGetArity(global::Mono.Cecil.TypeParser.Type type)
		{
			int num = 0;
			global::Mono.Cecil.TypeParser.TryAddArity(type.type_fullname, ref num);
			string[] nested_names = type.nested_names;
			if (!nested_names.IsNullOrEmpty<string>())
			{
				for (int i = 0; i < nested_names.Length; i++)
				{
					global::Mono.Cecil.TypeParser.TryAddArity(nested_names[i], ref num);
				}
			}
			type.arity = num;
			return num > 0;
		}

		// Token: 0x060002C9 RID: 713 RVA: 0x000085F8 File Offset: 0x000067F8
		private static bool TryGetArity(string name, out int arity)
		{
			arity = 0;
			int num = name.LastIndexOf('`');
			return num != -1 && global::Mono.Cecil.TypeParser.ParseInt32(name.Substring(num + 1), out arity);
		}

		// Token: 0x060002CA RID: 714 RVA: 0x00008626 File Offset: 0x00006826
		private static bool ParseInt32(string value, out int result)
		{
			return int.TryParse(value, out result);
		}

		// Token: 0x060002CB RID: 715 RVA: 0x00008630 File Offset: 0x00006830
		private static void TryAddArity(string name, ref int arity)
		{
			int num;
			if (!global::Mono.Cecil.TypeParser.TryGetArity(name, out num))
			{
				return;
			}
			arity += num;
		}

		// Token: 0x060002CC RID: 716 RVA: 0x00008650 File Offset: 0x00006850
		private string ParsePart()
		{
			int num = this.position;
			while (this.position < this.length && !global::Mono.Cecil.TypeParser.IsDelimiter(this.fullname[this.position]))
			{
				this.position++;
			}
			return this.fullname.Substring(num, this.position - num);
		}

		// Token: 0x060002CD RID: 717 RVA: 0x000086AE File Offset: 0x000068AE
		private static bool IsDelimiter(char chr)
		{
			return "+,[]*&".IndexOf(chr) != -1;
		}

		// Token: 0x060002CE RID: 718 RVA: 0x000086C1 File Offset: 0x000068C1
		private void TryParseWhiteSpace()
		{
			while (this.position < this.length && char.IsWhiteSpace(this.fullname[this.position]))
			{
				this.position++;
			}
		}

		// Token: 0x060002CF RID: 719 RVA: 0x000086FC File Offset: 0x000068FC
		private string[] ParseNestedNames()
		{
			string[] result = null;
			while (this.TryParse('+'))
			{
				global::Mono.Cecil.TypeParser.Add<string>(ref result, this.ParsePart());
			}
			return result;
		}

		// Token: 0x060002D0 RID: 720 RVA: 0x00008725 File Offset: 0x00006925
		private bool TryParse(char chr)
		{
			if (this.position < this.length && this.fullname[this.position] == chr)
			{
				this.position++;
				return true;
			}
			return false;
		}

		// Token: 0x060002D1 RID: 721 RVA: 0x0000875C File Offset: 0x0000695C
		private static void Add<T>(ref T[] array, T item)
		{
			if (array == null)
			{
				array = new T[]
				{
					item
				};
				return;
			}
			global::System.Array.Resize<T>(ref array, array.Length + 1);
			array[array.Length - 1] = item;
		}

		// Token: 0x060002D2 RID: 722 RVA: 0x0000879C File Offset: 0x0000699C
		private int[] ParseSpecs()
		{
			int[] result = null;
			while (this.position < this.length)
			{
				char c = this.fullname[this.position];
				if (c != '&')
				{
					if (c != '*')
					{
						if (c != '[')
						{
							return result;
						}
						this.position++;
						char c2 = this.fullname[this.position];
						if (c2 != '*')
						{
							if (c2 == ']')
							{
								this.position++;
								global::Mono.Cecil.TypeParser.Add<int>(ref result, -3);
							}
							else
							{
								int num = 1;
								while (this.TryParse(','))
								{
									num++;
								}
								global::Mono.Cecil.TypeParser.Add<int>(ref result, num);
								this.TryParse(']');
							}
						}
						else
						{
							this.position++;
							global::Mono.Cecil.TypeParser.Add<int>(ref result, 1);
						}
					}
					else
					{
						this.position++;
						global::Mono.Cecil.TypeParser.Add<int>(ref result, -1);
					}
				}
				else
				{
					this.position++;
					global::Mono.Cecil.TypeParser.Add<int>(ref result, -2);
				}
			}
			return result;
		}

		// Token: 0x060002D3 RID: 723 RVA: 0x000088A4 File Offset: 0x00006AA4
		private global::Mono.Cecil.TypeParser.Type[] ParseGenericArguments(int arity)
		{
			global::Mono.Cecil.TypeParser.Type[] result = null;
			if (this.position == this.length || this.fullname[this.position] != '[')
			{
				return result;
			}
			this.TryParse('[');
			for (int i = 0; i < arity; i++)
			{
				bool flag = this.TryParse('[');
				global::Mono.Cecil.TypeParser.Add<global::Mono.Cecil.TypeParser.Type>(ref result, this.ParseType(flag));
				if (flag)
				{
					this.TryParse(']');
				}
				this.TryParse(',');
				this.TryParseWhiteSpace();
			}
			this.TryParse(']');
			return result;
		}

		// Token: 0x060002D4 RID: 724 RVA: 0x0000892C File Offset: 0x00006B2C
		private string ParseAssemblyName()
		{
			if (!this.TryParse(','))
			{
				return string.Empty;
			}
			this.TryParseWhiteSpace();
			int num = this.position;
			while (this.position < this.length)
			{
				char c = this.fullname[this.position];
				if (c == '[' || c == ']')
				{
					break;
				}
				this.position++;
			}
			return this.fullname.Substring(num, this.position - num);
		}

		// Token: 0x060002D5 RID: 725 RVA: 0x000089A4 File Offset: 0x00006BA4
		public static global::Mono.Cecil.TypeReference ParseType(global::Mono.Cecil.ModuleDefinition module, string fullname)
		{
			if (fullname == null)
			{
				return null;
			}
			global::Mono.Cecil.TypeParser typeParser = new global::Mono.Cecil.TypeParser(fullname);
			return global::Mono.Cecil.TypeParser.GetTypeReference(module, typeParser.ParseType(true));
		}

		// Token: 0x060002D6 RID: 726 RVA: 0x000089CC File Offset: 0x00006BCC
		private static global::Mono.Cecil.TypeReference GetTypeReference(global::Mono.Cecil.ModuleDefinition module, global::Mono.Cecil.TypeParser.Type type_info)
		{
			global::Mono.Cecil.TypeReference type;
			if (!global::Mono.Cecil.TypeParser.TryGetDefinition(module, type_info, out type))
			{
				type = global::Mono.Cecil.TypeParser.CreateReference(type_info, module, global::Mono.Cecil.TypeParser.GetMetadataScope(module, type_info));
			}
			return global::Mono.Cecil.TypeParser.CreateSpecs(type, type_info);
		}

		// Token: 0x060002D7 RID: 727 RVA: 0x000089FC File Offset: 0x00006BFC
		private static global::Mono.Cecil.TypeReference CreateSpecs(global::Mono.Cecil.TypeReference type, global::Mono.Cecil.TypeParser.Type type_info)
		{
			type = global::Mono.Cecil.TypeParser.TryCreateGenericInstanceType(type, type_info);
			int[] specs = type_info.specs;
			if (specs.IsNullOrEmpty<int>())
			{
				return type;
			}
			for (int i = 0; i < specs.Length; i++)
			{
				switch (specs[i])
				{
				case -3:
					type = new global::Mono.Cecil.ArrayType(type);
					break;
				case -2:
					type = new global::Mono.Cecil.ByReferenceType(type);
					break;
				case -1:
					type = new global::Mono.Cecil.PointerType(type);
					break;
				default:
				{
					global::Mono.Cecil.ArrayType arrayType = new global::Mono.Cecil.ArrayType(type);
					arrayType.Dimensions.Clear();
					for (int j = 0; j < specs[i]; j++)
					{
						arrayType.Dimensions.Add(default(global::Mono.Cecil.ArrayDimension));
					}
					type = arrayType;
					break;
				}
				}
			}
			return type;
		}

		// Token: 0x060002D8 RID: 728 RVA: 0x00008AA8 File Offset: 0x00006CA8
		private static global::Mono.Cecil.TypeReference TryCreateGenericInstanceType(global::Mono.Cecil.TypeReference type, global::Mono.Cecil.TypeParser.Type type_info)
		{
			global::Mono.Cecil.TypeParser.Type[] generic_arguments = type_info.generic_arguments;
			if (generic_arguments.IsNullOrEmpty<global::Mono.Cecil.TypeParser.Type>())
			{
				return type;
			}
			global::Mono.Cecil.GenericInstanceType genericInstanceType = new global::Mono.Cecil.GenericInstanceType(type);
			global::Mono.Collections.Generic.Collection<global::Mono.Cecil.TypeReference> genericArguments = genericInstanceType.GenericArguments;
			for (int i = 0; i < generic_arguments.Length; i++)
			{
				genericArguments.Add(global::Mono.Cecil.TypeParser.GetTypeReference(type.Module, generic_arguments[i]));
			}
			return genericInstanceType;
		}

		// Token: 0x060002D9 RID: 729 RVA: 0x00008AF8 File Offset: 0x00006CF8
		public static void SplitFullName(string fullname, out string @namespace, out string name)
		{
			int num = fullname.LastIndexOf('.');
			if (num == -1)
			{
				@namespace = string.Empty;
				name = fullname;
				return;
			}
			@namespace = fullname.Substring(0, num);
			name = fullname.Substring(num + 1);
		}

		// Token: 0x060002DA RID: 730 RVA: 0x00008B34 File Offset: 0x00006D34
		private static global::Mono.Cecil.TypeReference CreateReference(global::Mono.Cecil.TypeParser.Type type_info, global::Mono.Cecil.ModuleDefinition module, global::Mono.Cecil.IMetadataScope scope)
		{
			string @namespace;
			string name;
			global::Mono.Cecil.TypeParser.SplitFullName(type_info.type_fullname, out @namespace, out name);
			global::Mono.Cecil.TypeReference typeReference = new global::Mono.Cecil.TypeReference(@namespace, name, module, scope);
			global::Mono.Cecil.MetadataSystem.TryProcessPrimitiveType(typeReference);
			global::Mono.Cecil.TypeParser.AdjustGenericParameters(typeReference);
			string[] nested_names = type_info.nested_names;
			if (nested_names.IsNullOrEmpty<string>())
			{
				return typeReference;
			}
			for (int i = 0; i < nested_names.Length; i++)
			{
				typeReference = new global::Mono.Cecil.TypeReference(string.Empty, nested_names[i], module, null)
				{
					DeclaringType = typeReference
				};
				global::Mono.Cecil.TypeParser.AdjustGenericParameters(typeReference);
			}
			return typeReference;
		}

		// Token: 0x060002DB RID: 731 RVA: 0x00008BB0 File Offset: 0x00006DB0
		private static void AdjustGenericParameters(global::Mono.Cecil.TypeReference type)
		{
			int num;
			if (!global::Mono.Cecil.TypeParser.TryGetArity(type.Name, out num))
			{
				return;
			}
			for (int i = 0; i < num; i++)
			{
				type.GenericParameters.Add(new global::Mono.Cecil.GenericParameter(type));
			}
		}

		// Token: 0x060002DC RID: 732 RVA: 0x00008BEA File Offset: 0x00006DEA
		private static global::Mono.Cecil.IMetadataScope GetMetadataScope(global::Mono.Cecil.ModuleDefinition module, global::Mono.Cecil.TypeParser.Type type_info)
		{
			if (string.IsNullOrEmpty(type_info.assembly))
			{
				return module.TypeSystem.Corlib;
			}
			return global::Mono.Cecil.TypeParser.MatchReference(module, global::Mono.Cecil.AssemblyNameReference.Parse(type_info.assembly));
		}

		// Token: 0x060002DD RID: 733 RVA: 0x00008C18 File Offset: 0x00006E18
		private static global::Mono.Cecil.AssemblyNameReference MatchReference(global::Mono.Cecil.ModuleDefinition module, global::Mono.Cecil.AssemblyNameReference pattern)
		{
			global::Mono.Collections.Generic.Collection<global::Mono.Cecil.AssemblyNameReference> assemblyReferences = module.AssemblyReferences;
			for (int i = 0; i < assemblyReferences.Count; i++)
			{
				global::Mono.Cecil.AssemblyNameReference assemblyNameReference = assemblyReferences[i];
				if (assemblyNameReference.FullName == pattern.FullName)
				{
					return assemblyNameReference;
				}
			}
			return pattern;
		}

		// Token: 0x060002DE RID: 734 RVA: 0x00008C5C File Offset: 0x00006E5C
		private static bool TryGetDefinition(global::Mono.Cecil.ModuleDefinition module, global::Mono.Cecil.TypeParser.Type type_info, out global::Mono.Cecil.TypeReference type)
		{
			type = null;
			if (!global::Mono.Cecil.TypeParser.TryCurrentModule(module, type_info))
			{
				return false;
			}
			global::Mono.Cecil.TypeDefinition typeDefinition = module.GetType(type_info.type_fullname);
			if (typeDefinition == null)
			{
				return false;
			}
			string[] nested_names = type_info.nested_names;
			if (!nested_names.IsNullOrEmpty<string>())
			{
				for (int i = 0; i < nested_names.Length; i++)
				{
					typeDefinition = typeDefinition.GetNestedType(nested_names[i]);
				}
			}
			type = typeDefinition;
			return true;
		}

		// Token: 0x060002DF RID: 735 RVA: 0x00008CB4 File Offset: 0x00006EB4
		private static bool TryCurrentModule(global::Mono.Cecil.ModuleDefinition module, global::Mono.Cecil.TypeParser.Type type_info)
		{
			return string.IsNullOrEmpty(type_info.assembly) || (module.assembly != null && module.assembly.Name.FullName == type_info.assembly);
		}

		// Token: 0x060002E0 RID: 736 RVA: 0x00008CF0 File Offset: 0x00006EF0
		public static string ToParseable(global::Mono.Cecil.TypeReference type)
		{
			if (type == null)
			{
				return null;
			}
			global::System.Text.StringBuilder stringBuilder = new global::System.Text.StringBuilder();
			global::Mono.Cecil.TypeParser.AppendType(type, stringBuilder, true, true);
			return stringBuilder.ToString();
		}

		// Token: 0x060002E1 RID: 737 RVA: 0x00008D18 File Offset: 0x00006F18
		private static void AppendType(global::Mono.Cecil.TypeReference type, global::System.Text.StringBuilder name, bool fq_name, bool top_level)
		{
			global::Mono.Cecil.TypeReference declaringType = type.DeclaringType;
			if (declaringType != null)
			{
				global::Mono.Cecil.TypeParser.AppendType(declaringType, name, false, top_level);
				name.Append('+');
			}
			string @namespace = type.Namespace;
			if (!string.IsNullOrEmpty(@namespace))
			{
				name.Append(@namespace);
				name.Append('.');
			}
			name.Append(type.GetElementType().Name);
			if (!fq_name)
			{
				return;
			}
			if (type.IsTypeSpecification())
			{
				global::Mono.Cecil.TypeParser.AppendTypeSpecification((global::Mono.Cecil.TypeSpecification)type, name);
			}
			if (global::Mono.Cecil.TypeParser.RequiresFullyQualifiedName(type, top_level))
			{
				name.Append(", ");
				name.Append(global::Mono.Cecil.TypeParser.GetScopeFullName(type));
			}
		}

		// Token: 0x060002E2 RID: 738 RVA: 0x00008DB0 File Offset: 0x00006FB0
		private static string GetScopeFullName(global::Mono.Cecil.TypeReference type)
		{
			global::Mono.Cecil.IMetadataScope scope = type.Scope;
			switch (scope.MetadataScopeType)
			{
			case global::Mono.Cecil.MetadataScopeType.AssemblyNameReference:
				return ((global::Mono.Cecil.AssemblyNameReference)scope).FullName;
			case global::Mono.Cecil.MetadataScopeType.ModuleDefinition:
				return ((global::Mono.Cecil.ModuleDefinition)scope).Assembly.Name.FullName;
			}
			throw new global::System.ArgumentException();
		}

		// Token: 0x060002E3 RID: 739 RVA: 0x00008E08 File Offset: 0x00007008
		private static void AppendTypeSpecification(global::Mono.Cecil.TypeSpecification type, global::System.Text.StringBuilder name)
		{
			if (type.ElementType.IsTypeSpecification())
			{
				global::Mono.Cecil.TypeParser.AppendTypeSpecification((global::Mono.Cecil.TypeSpecification)type.ElementType, name);
			}
			global::Mono.Cecil.Metadata.ElementType etype = type.etype;
			switch (etype)
			{
			case global::Mono.Cecil.Metadata.ElementType.Ptr:
				name.Append('*');
				return;
			case global::Mono.Cecil.Metadata.ElementType.ByRef:
				name.Append('&');
				return;
			case global::Mono.Cecil.Metadata.ElementType.ValueType:
			case global::Mono.Cecil.Metadata.ElementType.Class:
			case global::Mono.Cecil.Metadata.ElementType.Var:
				return;
			case global::Mono.Cecil.Metadata.ElementType.Array:
				break;
			case global::Mono.Cecil.Metadata.ElementType.GenericInst:
			{
				global::Mono.Cecil.GenericInstanceType genericInstanceType = (global::Mono.Cecil.GenericInstanceType)type;
				global::Mono.Collections.Generic.Collection<global::Mono.Cecil.TypeReference> genericArguments = genericInstanceType.GenericArguments;
				name.Append('[');
				for (int i = 0; i < genericArguments.Count; i++)
				{
					if (i > 0)
					{
						name.Append(',');
					}
					global::Mono.Cecil.TypeReference typeReference = genericArguments[i];
					bool flag = typeReference.Scope != typeReference.Module;
					if (flag)
					{
						name.Append('[');
					}
					global::Mono.Cecil.TypeParser.AppendType(typeReference, name, true, false);
					if (flag)
					{
						name.Append(']');
					}
				}
				name.Append(']');
				return;
			}
			default:
				if (etype != global::Mono.Cecil.Metadata.ElementType.SzArray)
				{
					return;
				}
				break;
			}
			global::Mono.Cecil.ArrayType arrayType = (global::Mono.Cecil.ArrayType)type;
			if (arrayType.IsVector)
			{
				name.Append("[]");
				return;
			}
			name.Append('[');
			for (int j = 1; j < arrayType.Rank; j++)
			{
				name.Append(',');
			}
			name.Append(']');
		}

		// Token: 0x060002E4 RID: 740 RVA: 0x00008F4B File Offset: 0x0000714B
		private static bool RequiresFullyQualifiedName(global::Mono.Cecil.TypeReference type, bool top_level)
		{
			return type.Scope != type.Module && (!(type.Scope.Name == "mscorlib") || !top_level);
		}

		// Token: 0x040001EB RID: 491
		private readonly string fullname;

		// Token: 0x040001EC RID: 492
		private readonly int length;

		// Token: 0x040001ED RID: 493
		private int position;

		// Token: 0x02000033 RID: 51
		private class Type
		{
			// Token: 0x060002E5 RID: 741 RVA: 0x00008F7A File Offset: 0x0000717A
			public Type()
			{
			}

			// Token: 0x040001EE RID: 494
			public const int Ptr = -1;

			// Token: 0x040001EF RID: 495
			public const int ByRef = -2;

			// Token: 0x040001F0 RID: 496
			public const int SzArray = -3;

			// Token: 0x040001F1 RID: 497
			public string type_fullname;

			// Token: 0x040001F2 RID: 498
			public string[] nested_names;

			// Token: 0x040001F3 RID: 499
			public int arity;

			// Token: 0x040001F4 RID: 500
			public int[] specs;

			// Token: 0x040001F5 RID: 501
			public global::Mono.Cecil.TypeParser.Type[] generic_arguments;

			// Token: 0x040001F6 RID: 502
			public string assembly;
		}
	}
}
