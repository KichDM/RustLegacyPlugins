using System;
using System.Collections.Generic;

namespace Mono.Cecil.Metadata
{
	// Token: 0x0200005B RID: 91
	internal sealed class RowEqualityComparer : global::System.Collections.Generic.IEqualityComparer<global::Mono.Cecil.Metadata.Row<string, string>>, global::System.Collections.Generic.IEqualityComparer<global::Mono.Cecil.Metadata.Row<uint, uint>>, global::System.Collections.Generic.IEqualityComparer<global::Mono.Cecil.Metadata.Row<uint, uint, uint>>
	{
		// Token: 0x060003CF RID: 975 RVA: 0x0000A30A File Offset: 0x0000850A
		public bool Equals(global::Mono.Cecil.Metadata.Row<string, string> x, global::Mono.Cecil.Metadata.Row<string, string> y)
		{
			return x.Col1 == y.Col1 && x.Col2 == y.Col2;
		}

		// Token: 0x060003D0 RID: 976 RVA: 0x0000A338 File Offset: 0x00008538
		public int GetHashCode(global::Mono.Cecil.Metadata.Row<string, string> obj)
		{
			string col = obj.Col1;
			string col2 = obj.Col2;
			return ((col != null) ? col.GetHashCode() : 0) ^ ((col2 != null) ? col2.GetHashCode() : 0);
		}

		// Token: 0x060003D1 RID: 977 RVA: 0x0000A36E File Offset: 0x0000856E
		public bool Equals(global::Mono.Cecil.Metadata.Row<uint, uint> x, global::Mono.Cecil.Metadata.Row<uint, uint> y)
		{
			return x.Col1 == y.Col1 && x.Col2 == y.Col2;
		}

		// Token: 0x060003D2 RID: 978 RVA: 0x0000A392 File Offset: 0x00008592
		public int GetHashCode(global::Mono.Cecil.Metadata.Row<uint, uint> obj)
		{
			return (int)(obj.Col1 ^ obj.Col2);
		}

		// Token: 0x060003D3 RID: 979 RVA: 0x0000A3A3 File Offset: 0x000085A3
		public bool Equals(global::Mono.Cecil.Metadata.Row<uint, uint, uint> x, global::Mono.Cecil.Metadata.Row<uint, uint, uint> y)
		{
			return x.Col1 == y.Col1 && x.Col2 == y.Col2 && x.Col3 == y.Col3;
		}

		// Token: 0x060003D4 RID: 980 RVA: 0x0000A3D7 File Offset: 0x000085D7
		public int GetHashCode(global::Mono.Cecil.Metadata.Row<uint, uint, uint> obj)
		{
			return (int)(obj.Col1 ^ obj.Col2 ^ obj.Col3);
		}

		// Token: 0x060003D5 RID: 981 RVA: 0x0000A3F0 File Offset: 0x000085F0
		public RowEqualityComparer()
		{
		}
	}
}
