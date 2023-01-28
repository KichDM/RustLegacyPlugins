using System;

namespace Mono.Cecil
{
	// Token: 0x020000CA RID: 202
	internal abstract class MetadataTable<TRow> : global::Mono.Cecil.MetadataTable where TRow : struct
	{
		// Token: 0x170002BB RID: 699
		// (get) Token: 0x0600081B RID: 2075 RVA: 0x00016018 File Offset: 0x00014218
		public sealed override int Length
		{
			get
			{
				return this.length;
			}
		}

		// Token: 0x0600081C RID: 2076 RVA: 0x00016020 File Offset: 0x00014220
		public int AddRow(TRow row)
		{
			if (this.rows.Length == this.length)
			{
				this.Grow();
			}
			this.rows[this.length++] = row;
			return this.length;
		}

		// Token: 0x0600081D RID: 2077 RVA: 0x00016068 File Offset: 0x00014268
		private void Grow()
		{
			TRow[] destinationArray = new TRow[this.rows.Length * 2];
			global::System.Array.Copy(this.rows, destinationArray, this.rows.Length);
			this.rows = destinationArray;
		}

		// Token: 0x0600081E RID: 2078 RVA: 0x000160A0 File Offset: 0x000142A0
		public override void Sort()
		{
		}

		// Token: 0x0600081F RID: 2079 RVA: 0x000160A2 File Offset: 0x000142A2
		protected MetadataTable()
		{
		}

		// Token: 0x040005DC RID: 1500
		internal TRow[] rows = new TRow[2];

		// Token: 0x040005DD RID: 1501
		internal int length;
	}
}
