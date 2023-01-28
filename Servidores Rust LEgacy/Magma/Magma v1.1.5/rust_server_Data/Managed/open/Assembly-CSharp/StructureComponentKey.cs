using System;
using UnityEngine;

// Token: 0x020007A9 RID: 1961
public struct StructureComponentKey : global::System.IEquatable<global::StructureComponentKey>
{
	// Token: 0x0600414B RID: 16715 RVA: 0x000EAA08 File Offset: 0x000E8C08
	private StructureComponentKey(int iX, int iY, int iZ)
	{
		this.hashCode = ((iX << 8 | (iX >> 8 & 0xFFFFFF)) ^ (iY << 0x10 | (iY >> 0x10 & 0xFFFF)) ^ (iZ << 0x18 | (iZ >> 0x18 & 0xFF)) ^ iX * iY * iZ);
		this.iX = iX;
		this.iY = iY;
		this.iZ = iZ;
	}

	// Token: 0x0600414C RID: 16716 RVA: 0x000EAA64 File Offset: 0x000E8C64
	public StructureComponentKey(float x, float y, float z)
	{
		this = new global::StructureComponentKey(global::StructureComponentKey.ROUND(x, 0.4f), global::StructureComponentKey.ROUND(y, 0.25f), global::StructureComponentKey.ROUND(z, 0.4f));
	}

	// Token: 0x0600414D RID: 16717 RVA: 0x000EAA90 File Offset: 0x000E8C90
	public StructureComponentKey(global::UnityEngine.Vector3 v)
	{
		this = new global::StructureComponentKey(v.x, v.y, v.z);
	}

	// Token: 0x17000C06 RID: 3078
	// (get) Token: 0x0600414E RID: 16718 RVA: 0x000EAAB0 File Offset: 0x000E8CB0
	public float x
	{
		get
		{
			return (float)this.iX * 2.5f;
		}
	}

	// Token: 0x17000C07 RID: 3079
	// (get) Token: 0x0600414F RID: 16719 RVA: 0x000EAAC0 File Offset: 0x000E8CC0
	public float y
	{
		get
		{
			return (float)this.iY * 4f;
		}
	}

	// Token: 0x17000C08 RID: 3080
	// (get) Token: 0x06004150 RID: 16720 RVA: 0x000EAAD0 File Offset: 0x000E8CD0
	public float z
	{
		get
		{
			return (float)this.iZ * 2.5f;
		}
	}

	// Token: 0x17000C09 RID: 3081
	// (get) Token: 0x06004151 RID: 16721 RVA: 0x000EAAE0 File Offset: 0x000E8CE0
	public global::UnityEngine.Vector3 vector
	{
		get
		{
			global::UnityEngine.Vector3 result;
			result.x = (float)this.iX * 2.5f;
			result.y = (float)this.iY * 4f;
			result.z = (float)this.iZ * 2.5f;
			return result;
		}
	}

	// Token: 0x06004152 RID: 16722 RVA: 0x000EAB2C File Offset: 0x000E8D2C
	public static int ROUND(float v, float inverseStepSize)
	{
		if (v < 0f)
		{
			return -global::UnityEngine.Mathf.RoundToInt(v * -inverseStepSize);
		}
		if (v > 0f)
		{
			return global::UnityEngine.Mathf.RoundToInt(v * inverseStepSize);
		}
		return 0;
	}

	// Token: 0x06004153 RID: 16723 RVA: 0x000EAB5C File Offset: 0x000E8D5C
	public override int GetHashCode()
	{
		return this.hashCode;
	}

	// Token: 0x06004154 RID: 16724 RVA: 0x000EAB64 File Offset: 0x000E8D64
	public override bool Equals(object obj)
	{
		if (!(obj is global::StructureComponentKey))
		{
			return false;
		}
		global::StructureComponentKey structureComponentKey = (global::StructureComponentKey)obj;
		return structureComponentKey.iX == this.iX && structureComponentKey.iZ == this.iZ && structureComponentKey.iY == this.iY;
	}

	// Token: 0x06004155 RID: 16725 RVA: 0x000EABBC File Offset: 0x000E8DBC
	public bool Equals(global::StructureComponentKey other)
	{
		return this.iX == other.iX && other.iZ == this.iZ && other.iY == this.iY;
	}

	// Token: 0x06004156 RID: 16726 RVA: 0x000EAC00 File Offset: 0x000E8E00
	public override string ToString()
	{
		return string.Format("[{0},{1},{2}]", this.iX, this.iY, this.iZ);
	}

	// Token: 0x06004157 RID: 16727 RVA: 0x000EAC30 File Offset: 0x000E8E30
	public static bool operator ==(global::StructureComponentKey l, global::StructureComponentKey r)
	{
		return l.hashCode == r.hashCode && l.iX == r.iX && l.iY == r.iY && l.iZ == r.iZ;
	}

	// Token: 0x06004158 RID: 16728 RVA: 0x000EAC8C File Offset: 0x000E8E8C
	public static bool operator !=(global::StructureComponentKey l, global::StructureComponentKey r)
	{
		return l.hashCode != r.hashCode || l.iX != r.iX || l.iY != r.iY || l.iZ != r.iZ;
	}

	// Token: 0x06004159 RID: 16729 RVA: 0x000EACE8 File Offset: 0x000E8EE8
	public static explicit operator global::StructureComponentKey(global::UnityEngine.Vector3 v)
	{
		return new global::StructureComponentKey(global::StructureComponentKey.ROUND(v.x, 0.4f), global::StructureComponentKey.ROUND(v.y, 0.25f), global::StructureComponentKey.ROUND(v.z, 0.4f));
	}

	// Token: 0x0600415A RID: 16730 RVA: 0x000EAD30 File Offset: 0x000E8F30
	public static implicit operator global::UnityEngine.Vector3(global::StructureComponentKey key)
	{
		global::UnityEngine.Vector3 result;
		result.x = (float)key.iX * 2.5f;
		result.y = (float)key.iY * 4f;
		result.z = (float)key.iZ * 2.5f;
		return result;
	}

	// Token: 0x04002212 RID: 8722
	private const float kStepX = 2.5f;

	// Token: 0x04002213 RID: 8723
	private const float kStepY = 4f;

	// Token: 0x04002214 RID: 8724
	private const float kStepZ = 2.5f;

	// Token: 0x04002215 RID: 8725
	private const float kInverseStepX = 0.4f;

	// Token: 0x04002216 RID: 8726
	private const float kInverseStepY = 0.25f;

	// Token: 0x04002217 RID: 8727
	private const float kInverseStepZ = 0.4f;

	// Token: 0x04002218 RID: 8728
	public readonly int iX;

	// Token: 0x04002219 RID: 8729
	public readonly int iY;

	// Token: 0x0400221A RID: 8730
	public readonly int iZ;

	// Token: 0x0400221B RID: 8731
	public readonly int hashCode;
}
