using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Antlr.Runtime
{
	// Token: 0x02000093 RID: 147
	[global::System.Runtime.InteropServices.ComVisible(false)]
	[global::System.Serializable]
	public sealed class BitSet : global::System.ICloneable
	{
		// Token: 0x06000690 RID: 1680 RVA: 0x0002CBFC File Offset: 0x0002ADFC
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public BitSet() : this(0x40)
		{
		}

		// Token: 0x06000691 RID: 1681 RVA: 0x0002CC08 File Offset: 0x0002AE08
		[global::System.CLSCompliant(false)]
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public BitSet(ulong[] bits)
		{
			this._bits = bits;
		}

		// Token: 0x06000692 RID: 1682 RVA: 0x0002CC18 File Offset: 0x0002AE18
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public BitSet(global::System.Collections.Generic.IEnumerable<int> items) : this()
		{
			foreach (int el in items)
			{
				this.Add(el);
			}
		}

		// Token: 0x06000693 RID: 1683 RVA: 0x0002CC70 File Offset: 0x0002AE70
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public BitSet(int nbits)
		{
			this._bits = new ulong[(nbits - 1 >> 6) + 1];
		}

		// Token: 0x06000694 RID: 1684 RVA: 0x0002CC8C File Offset: 0x0002AE8C
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public static global::Antlr.Runtime.BitSet Of(int el)
		{
			global::Antlr.Runtime.BitSet bitSet = new global::Antlr.Runtime.BitSet(el + 1);
			bitSet.Add(el);
			return bitSet;
		}

		// Token: 0x06000695 RID: 1685 RVA: 0x0002CCB0 File Offset: 0x0002AEB0
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public static global::Antlr.Runtime.BitSet Of(int a, int b)
		{
			global::Antlr.Runtime.BitSet bitSet = new global::Antlr.Runtime.BitSet(global::System.Math.Max(a, b) + 1);
			bitSet.Add(a);
			bitSet.Add(b);
			return bitSet;
		}

		// Token: 0x06000696 RID: 1686 RVA: 0x0002CCE0 File Offset: 0x0002AEE0
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public static global::Antlr.Runtime.BitSet Of(int a, int b, int c)
		{
			global::Antlr.Runtime.BitSet bitSet = new global::Antlr.Runtime.BitSet();
			bitSet.Add(a);
			bitSet.Add(b);
			bitSet.Add(c);
			return bitSet;
		}

		// Token: 0x06000697 RID: 1687 RVA: 0x0002CD10 File Offset: 0x0002AF10
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public static global::Antlr.Runtime.BitSet Of(int a, int b, int c, int d)
		{
			global::Antlr.Runtime.BitSet bitSet = new global::Antlr.Runtime.BitSet();
			bitSet.Add(a);
			bitSet.Add(b);
			bitSet.Add(c);
			bitSet.Add(d);
			return bitSet;
		}

		// Token: 0x06000698 RID: 1688 RVA: 0x0002CD44 File Offset: 0x0002AF44
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public global::Antlr.Runtime.BitSet Or(global::Antlr.Runtime.BitSet a)
		{
			if (a == null)
			{
				return this;
			}
			global::Antlr.Runtime.BitSet bitSet = (global::Antlr.Runtime.BitSet)this.Clone();
			bitSet.OrInPlace(a);
			return bitSet;
		}

		// Token: 0x06000699 RID: 1689 RVA: 0x0002CD74 File Offset: 0x0002AF74
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public void Add(int el)
		{
			int num = global::Antlr.Runtime.BitSet.WordNumber(el);
			if (num >= this._bits.Length)
			{
				this.GrowToInclude(el);
			}
			this._bits[num] |= global::Antlr.Runtime.BitSet.BitMask(el);
		}

		// Token: 0x0600069A RID: 1690 RVA: 0x0002CDB8 File Offset: 0x0002AFB8
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public void GrowToInclude(int bit)
		{
			int size = global::System.Math.Max(this._bits.Length << 1, global::Antlr.Runtime.BitSet.NumWordsToHold(bit));
			this.SetSize(size);
		}

		// Token: 0x0600069B RID: 1691 RVA: 0x0002CDE8 File Offset: 0x0002AFE8
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public void OrInPlace(global::Antlr.Runtime.BitSet a)
		{
			if (a == null)
			{
				return;
			}
			if (a._bits.Length > this._bits.Length)
			{
				this.SetSize(a._bits.Length);
			}
			int num = global::System.Math.Min(this._bits.Length, a._bits.Length);
			for (int i = num - 1; i >= 0; i--)
			{
				this._bits[i] |= a._bits[i];
			}
		}

		// Token: 0x0600069C RID: 1692 RVA: 0x0002CE64 File Offset: 0x0002B064
		private void SetSize(int nwords)
		{
			global::System.Array.Resize<ulong>(ref this._bits, nwords);
		}

		// Token: 0x0600069D RID: 1693 RVA: 0x0002CE74 File Offset: 0x0002B074
		private static ulong BitMask(int bitNumber)
		{
			int num = bitNumber & 0x3F;
			return 1UL << num;
		}

		// Token: 0x0600069E RID: 1694 RVA: 0x0002CE94 File Offset: 0x0002B094
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public object Clone()
		{
			return new global::Antlr.Runtime.BitSet((ulong[])this._bits.Clone());
		}

		// Token: 0x0600069F RID: 1695 RVA: 0x0002CEAC File Offset: 0x0002B0AC
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public int Size()
		{
			int num = 0;
			for (int i = this._bits.Length - 1; i >= 0; i--)
			{
				ulong num2 = this._bits[i];
				if (num2 != 0UL)
				{
					for (int j = 0x3F; j >= 0; j--)
					{
						if ((num2 & 1UL << j) != 0UL)
						{
							num++;
						}
					}
				}
			}
			return num;
		}

		// Token: 0x060006A0 RID: 1696 RVA: 0x0002CF10 File Offset: 0x0002B110
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public override int GetHashCode()
		{
			throw new global::System.NotImplementedException();
		}

		// Token: 0x060006A1 RID: 1697 RVA: 0x0002CF18 File Offset: 0x0002B118
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public override bool Equals(object other)
		{
			if (other == null || !(other is global::Antlr.Runtime.BitSet))
			{
				return false;
			}
			global::Antlr.Runtime.BitSet bitSet = (global::Antlr.Runtime.BitSet)other;
			int num = global::System.Math.Min(this._bits.Length, bitSet._bits.Length);
			for (int i = 0; i < num; i++)
			{
				if (this._bits[i] != bitSet._bits[i])
				{
					return false;
				}
			}
			if (this._bits.Length > num)
			{
				for (int j = num + 1; j < this._bits.Length; j++)
				{
					if (this._bits[j] != 0UL)
					{
						return false;
					}
				}
			}
			else if (bitSet._bits.Length > num)
			{
				for (int k = num + 1; k < bitSet._bits.Length; k++)
				{
					if (bitSet._bits[k] != 0UL)
					{
						return false;
					}
				}
			}
			return true;
		}

		// Token: 0x060006A2 RID: 1698 RVA: 0x0002CFF8 File Offset: 0x0002B1F8
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public bool Member(int el)
		{
			if (el < 0)
			{
				return false;
			}
			int num = global::Antlr.Runtime.BitSet.WordNumber(el);
			return num < this._bits.Length && (this._bits[num] & global::Antlr.Runtime.BitSet.BitMask(el)) != 0UL;
		}

		// Token: 0x060006A3 RID: 1699 RVA: 0x0002D040 File Offset: 0x0002B240
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public void Remove(int el)
		{
			int num = global::Antlr.Runtime.BitSet.WordNumber(el);
			if (num < this._bits.Length)
			{
				this._bits[num] &= ~global::Antlr.Runtime.BitSet.BitMask(el);
			}
		}

		// Token: 0x060006A4 RID: 1700 RVA: 0x0002D080 File Offset: 0x0002B280
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public bool IsNil()
		{
			for (int i = this._bits.Length - 1; i >= 0; i--)
			{
				if (this._bits[i] != 0UL)
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x060006A5 RID: 1701 RVA: 0x0002D0BC File Offset: 0x0002B2BC
		private static int NumWordsToHold(int el)
		{
			return (el >> 6) + 1;
		}

		// Token: 0x060006A6 RID: 1702 RVA: 0x0002D0C4 File Offset: 0x0002B2C4
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public int NumBits()
		{
			return this._bits.Length << 6;
		}

		// Token: 0x060006A7 RID: 1703 RVA: 0x0002D0D0 File Offset: 0x0002B2D0
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public int LengthInLongWords()
		{
			return this._bits.Length;
		}

		// Token: 0x060006A8 RID: 1704 RVA: 0x0002D0DC File Offset: 0x0002B2DC
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public int[] ToArray()
		{
			int[] array = new int[this.Size()];
			int num = 0;
			for (int i = 0; i < this._bits.Length << 6; i++)
			{
				if (this.Member(i))
				{
					array[num++] = i;
				}
			}
			return array;
		}

		// Token: 0x060006A9 RID: 1705 RVA: 0x0002D128 File Offset: 0x0002B328
		private static int WordNumber(int bit)
		{
			return bit >> 6;
		}

		// Token: 0x060006AA RID: 1706 RVA: 0x0002D130 File Offset: 0x0002B330
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public override string ToString()
		{
			return this.ToString(null);
		}

		// Token: 0x060006AB RID: 1707 RVA: 0x0002D13C File Offset: 0x0002B33C
		[global::System.Runtime.InteropServices.ComVisible(false)]
		public string ToString(string[] tokenNames)
		{
			global::System.Text.StringBuilder stringBuilder = new global::System.Text.StringBuilder();
			string value = ",";
			bool flag = false;
			stringBuilder.Append('{');
			for (int i = 0; i < this._bits.Length << 6; i++)
			{
				if (this.Member(i))
				{
					if (i > 0 && flag)
					{
						stringBuilder.Append(value);
					}
					if (tokenNames != null)
					{
						stringBuilder.Append(tokenNames[i]);
					}
					else
					{
						stringBuilder.Append(i);
					}
					flag = true;
				}
			}
			stringBuilder.Append('}');
			return stringBuilder.ToString();
		}

		// Token: 0x04000356 RID: 854
		private const int BITS = 0x40;

		// Token: 0x04000357 RID: 855
		private const int LOG_BITS = 6;

		// Token: 0x04000358 RID: 856
		private const int MOD_MASK = 0x3F;

		// Token: 0x04000359 RID: 857
		private ulong[] _bits;
	}
}
