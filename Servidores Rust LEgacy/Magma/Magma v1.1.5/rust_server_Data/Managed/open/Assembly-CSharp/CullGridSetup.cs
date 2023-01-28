using System;

// Token: 0x0200032C RID: 812
[global::System.Serializable]
public class CullGridSetup
{
	// Token: 0x06001B2C RID: 6956 RVA: 0x0006C118 File Offset: 0x0006A318
	public CullGridSetup()
	{
		this.cellSquareDimension = 0xC8;
		this.cellsWide = 0x50;
		this.cellsTall = 0x50;
		this.groupBegin = 0x64;
		this.gatheringCellsWide = 3;
		this.gatheringCellsTall = 3;
		this.gatheringCellsCenter = 4;
		this.gatheringCellsBits = new int[]
		{
			-0x2001,
			-0x18E09
		};
	}

	// Token: 0x06001B2D RID: 6957 RVA: 0x0006C180 File Offset: 0x0006A380
	protected CullGridSetup(global::CullGridSetup copyFrom)
	{
		this.cellSquareDimension = copyFrom.cellSquareDimension;
		this.cellsWide = copyFrom.cellsWide;
		this.cellsTall = copyFrom.cellsTall;
		this.groupBegin = copyFrom.groupBegin;
		this.gatheringCellsWide = copyFrom.gatheringCellsWide;
		this.gatheringCellsTall = copyFrom.gatheringCellsTall;
		this.gatheringCellsCenter = copyFrom.gatheringCellsCenter;
		this.gatheringCellsBits = (int[])copyFrom.gatheringCellsBits.Clone();
	}

	// Token: 0x06001B2E RID: 6958 RVA: 0x0006C200 File Offset: 0x0006A400
	public bool GetGatheringBit(int x, int y)
	{
		if (x >= this.gatheringCellsWide || x < 0)
		{
			throw new global::System.ArgumentOutOfRangeException("x", "must be < gatheringCellsWide && >= 0");
		}
		if (y >= this.gatheringCellsTall || y < 0)
		{
			throw new global::System.ArgumentOutOfRangeException("y", "must be < gatheringCellsTall && >= 0");
		}
		int num = y * this.gatheringCellsWide + x;
		int num2 = num / 0x20;
		int num3 = num % 0x20;
		return this.gatheringCellsBits == null || this.gatheringCellsBits.Length <= num2 || (this.gatheringCellsBits[num2] & 1 << num3) == 1 << num3;
	}

	// Token: 0x06001B2F RID: 6959 RVA: 0x0006C29C File Offset: 0x0006A49C
	public void SetGatheringBit(int x, int y, bool v)
	{
		if (x >= this.gatheringCellsWide || x < 0)
		{
			throw new global::System.ArgumentOutOfRangeException("x", "must be < gatheringCellsWide && >= 0");
		}
		if (y >= this.gatheringCellsTall || y < 0)
		{
			throw new global::System.ArgumentOutOfRangeException("y", "must be < gatheringCellsTall && >= 0");
		}
		int num = y * this.gatheringCellsWide + x;
		int num2 = num / 0x20;
		int num3 = num % 0x20;
		if (this.gatheringCellsBits == null)
		{
			global::System.Array.Resize<int>(ref this.gatheringCellsBits, num2 + 1);
			for (int i = 0; i < num2; i++)
			{
				this.gatheringCellsBits[i] = -1;
			}
			if (!v)
			{
				this.gatheringCellsBits[num2] = ~(1 << num3);
			}
			else
			{
				this.gatheringCellsBits[num2] = -1;
			}
		}
		else if (this.gatheringCellsBits.Length <= num2)
		{
			int num4 = this.gatheringCellsBits.Length;
			global::System.Array.Resize<int>(ref this.gatheringCellsBits, num2 + 1);
			for (int j = num4 + 1; j <= num2; j++)
			{
				this.gatheringCellsBits[j] = -1;
			}
			if (!v)
			{
				this.gatheringCellsBits[num2] &= ~(1 << num3);
			}
		}
		else if (v)
		{
			this.gatheringCellsBits[num2] |= 1 << num3;
		}
		else
		{
			this.gatheringCellsBits[num2] &= ~(1 << num3);
		}
	}

	// Token: 0x06001B30 RID: 6960 RVA: 0x0006C40C File Offset: 0x0006A60C
	public void ToggleGatheringBit(int x, int y)
	{
		if (x >= this.gatheringCellsWide || x < 0)
		{
			throw new global::System.ArgumentOutOfRangeException("x", "must be < gatheringCellsWide && >= 0");
		}
		if (y >= this.gatheringCellsTall || y < 0)
		{
			throw new global::System.ArgumentOutOfRangeException("y", "must be < gatheringCellsTall && >= 0");
		}
		int num = y * this.gatheringCellsWide + x;
		int num2 = num / 0x20;
		int num3 = num % 0x20;
		if (this.gatheringCellsBits == null)
		{
			global::System.Array.Resize<int>(ref this.gatheringCellsBits, num2 + 1);
			for (int i = 0; i < num2; i++)
			{
				this.gatheringCellsBits[i] = -1;
			}
			this.gatheringCellsBits[num2] = ~(1 << num3);
		}
		else if (this.gatheringCellsBits.Length <= num2)
		{
			int num4 = this.gatheringCellsBits.Length;
			global::System.Array.Resize<int>(ref this.gatheringCellsBits, num2 + 1);
			for (int j = num4 + 1; j < num2; j++)
			{
				this.gatheringCellsBits[j] = -1;
			}
			this.gatheringCellsBits[num2] = ~(1 << num3);
		}
		else
		{
			this.gatheringCellsBits[num2] ^= 1 << num3;
		}
	}

	// Token: 0x06001B31 RID: 6961 RVA: 0x0006C534 File Offset: 0x0006A734
	public void SetGatheringDimensions(int gatheringCellsWide, int gatheringCellsTall)
	{
		if (this.gatheringCellsWide == gatheringCellsWide && this.gatheringCellsTall == gatheringCellsTall)
		{
			return;
		}
		this.gatheringCellsWide = gatheringCellsWide;
		this.gatheringCellsTall = gatheringCellsTall;
		this.gatheringCellsCenter = this.gatheringCellsWide / 2 + this.gatheringCellsTall / 2 * this.gatheringCellsWide;
	}

	// Token: 0x04000FF9 RID: 4089
	public int cellSquareDimension;

	// Token: 0x04000FFA RID: 4090
	public int cellsWide;

	// Token: 0x04000FFB RID: 4091
	public int cellsTall;

	// Token: 0x04000FFC RID: 4092
	public int groupBegin;

	// Token: 0x04000FFD RID: 4093
	public int gatheringCellsWide;

	// Token: 0x04000FFE RID: 4094
	public int gatheringCellsTall;

	// Token: 0x04000FFF RID: 4095
	public int gatheringCellsCenter;

	// Token: 0x04001000 RID: 4096
	public int[] gatheringCellsBits;
}
