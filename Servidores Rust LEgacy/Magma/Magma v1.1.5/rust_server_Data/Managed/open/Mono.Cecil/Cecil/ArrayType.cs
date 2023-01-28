using System;
using System.Text;
using Mono.Cecil.Metadata;
using Mono.Collections.Generic;

namespace Mono.Cecil
{
	// Token: 0x0200004F RID: 79
	public sealed class ArrayType : global::Mono.Cecil.TypeSpecification
	{
		// Token: 0x17000155 RID: 341
		// (get) Token: 0x06000394 RID: 916 RVA: 0x00009AD0 File Offset: 0x00007CD0
		public global::Mono.Collections.Generic.Collection<global::Mono.Cecil.ArrayDimension> Dimensions
		{
			get
			{
				if (this.dimensions != null)
				{
					return this.dimensions;
				}
				this.dimensions = new global::Mono.Collections.Generic.Collection<global::Mono.Cecil.ArrayDimension>();
				this.dimensions.Add(default(global::Mono.Cecil.ArrayDimension));
				return this.dimensions;
			}
		}

		// Token: 0x17000156 RID: 342
		// (get) Token: 0x06000395 RID: 917 RVA: 0x00009B11 File Offset: 0x00007D11
		public int Rank
		{
			get
			{
				if (this.dimensions != null)
				{
					return this.dimensions.Count;
				}
				return 1;
			}
		}

		// Token: 0x17000157 RID: 343
		// (get) Token: 0x06000396 RID: 918 RVA: 0x00009B28 File Offset: 0x00007D28
		public bool IsVector
		{
			get
			{
				return this.dimensions == null || (this.dimensions.Count <= 1 && !this.dimensions[0].IsSized);
			}
		}

		// Token: 0x17000158 RID: 344
		// (get) Token: 0x06000397 RID: 919 RVA: 0x00009B66 File Offset: 0x00007D66
		// (set) Token: 0x06000398 RID: 920 RVA: 0x00009B69 File Offset: 0x00007D69
		public override bool IsValueType
		{
			get
			{
				return false;
			}
			set
			{
				throw new global::System.InvalidOperationException();
			}
		}

		// Token: 0x17000159 RID: 345
		// (get) Token: 0x06000399 RID: 921 RVA: 0x00009B70 File Offset: 0x00007D70
		public override string Name
		{
			get
			{
				return base.Name + this.Suffix;
			}
		}

		// Token: 0x1700015A RID: 346
		// (get) Token: 0x0600039A RID: 922 RVA: 0x00009B83 File Offset: 0x00007D83
		public override string FullName
		{
			get
			{
				return base.FullName + this.Suffix;
			}
		}

		// Token: 0x1700015B RID: 347
		// (get) Token: 0x0600039B RID: 923 RVA: 0x00009B98 File Offset: 0x00007D98
		private string Suffix
		{
			get
			{
				if (this.IsVector)
				{
					return "[]";
				}
				global::System.Text.StringBuilder stringBuilder = new global::System.Text.StringBuilder();
				stringBuilder.Append("[");
				for (int i = 0; i < this.dimensions.Count; i++)
				{
					if (i > 0)
					{
						stringBuilder.Append(",");
					}
					stringBuilder.Append(this.dimensions[i].ToString());
				}
				stringBuilder.Append("]");
				return stringBuilder.ToString();
			}
		}

		// Token: 0x1700015C RID: 348
		// (get) Token: 0x0600039C RID: 924 RVA: 0x00009C1E File Offset: 0x00007E1E
		public override bool IsArray
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600039D RID: 925 RVA: 0x00009C21 File Offset: 0x00007E21
		public ArrayType(global::Mono.Cecil.TypeReference type) : base(type)
		{
			global::Mono.Cecil.Mixin.CheckType(type);
			this.etype = global::Mono.Cecil.Metadata.ElementType.Array;
		}

		// Token: 0x0600039E RID: 926 RVA: 0x00009C38 File Offset: 0x00007E38
		public ArrayType(global::Mono.Cecil.TypeReference type, int rank) : this(type)
		{
			global::Mono.Cecil.Mixin.CheckType(type);
			if (rank == 1)
			{
				return;
			}
			this.dimensions = new global::Mono.Collections.Generic.Collection<global::Mono.Cecil.ArrayDimension>(rank);
			for (int i = 0; i < rank; i++)
			{
				this.dimensions.Add(default(global::Mono.Cecil.ArrayDimension));
			}
			this.etype = global::Mono.Cecil.Metadata.ElementType.Array;
		}

		// Token: 0x04000242 RID: 578
		private global::Mono.Collections.Generic.Collection<global::Mono.Cecil.ArrayDimension> dimensions;
	}
}
