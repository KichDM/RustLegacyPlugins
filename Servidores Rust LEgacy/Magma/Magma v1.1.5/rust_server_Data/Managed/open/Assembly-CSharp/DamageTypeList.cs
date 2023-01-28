using System;
using UnityEngine;

// Token: 0x02000187 RID: 391
[global::System.Serializable]
public sealed class DamageTypeList
{
	// Token: 0x06000B50 RID: 2896 RVA: 0x0002BF88 File Offset: 0x0002A188
	public DamageTypeList()
	{
	}

	// Token: 0x06000B51 RID: 2897 RVA: 0x0002BF90 File Offset: 0x0002A190
	public DamageTypeList(global::DamageTypeList copyFrom) : this()
	{
		if (copyFrom == null || copyFrom.damageArray == null)
		{
			this.damageArray = new float[6];
		}
		else if (copyFrom.damageArray.Length == 6)
		{
			this.damageArray = (float[])copyFrom.damageArray.Clone();
		}
		else
		{
			this.damageArray = new float[6];
			if (copyFrom.damageArray.Length > 6)
			{
				for (int i = 0; i < 6; i++)
				{
					this.damageArray[i] = copyFrom.damageArray[i];
				}
			}
			else
			{
				for (int j = 0; j < copyFrom.damageArray.Length; j++)
				{
					this.damageArray[j] = copyFrom.damageArray[j];
				}
			}
		}
	}

	// Token: 0x06000B52 RID: 2898 RVA: 0x0002C058 File Offset: 0x0002A258
	public DamageTypeList(float generic, float bullet, float melee, float explosion, float radiation, float cold)
	{
		this.damageArray = new float[6];
		this.damageArray[0] = generic;
		this.damageArray[1] = bullet;
		this.damageArray[2] = melee;
		this.damageArray[3] = explosion;
		this.damageArray[4] = radiation;
		this.damageArray[5] = cold;
	}

	// Token: 0x17000315 RID: 789
	public float this[int index]
	{
		get
		{
			if (index < 0 || index >= 6)
			{
				throw new global::System.IndexOutOfRangeException();
			}
			return (this.damageArray != null && this.damageArray.Length > index) ? this.damageArray[index] : 0f;
		}
		set
		{
			if (index < 0 || index >= 6)
			{
				throw new global::System.IndexOutOfRangeException();
			}
			if (this.damageArray == null || this.damageArray.Length <= index)
			{
				global::System.Array.Resize<float>(ref this.damageArray, 6);
			}
			this.damageArray[index] = value;
		}
	}

	// Token: 0x17000316 RID: 790
	public float this[global::DamageTypeIndex index]
	{
		get
		{
			return this[(int)index];
		}
		set
		{
			this[(int)index] = value;
		}
	}

	// Token: 0x06000B57 RID: 2903 RVA: 0x0002C164 File Offset: 0x0002A364
	public void SetArmorValues(global::DamageTypeList copyFrom)
	{
		if (this.damageArray == null || this.damageArray.Length != 6)
		{
			if (copyFrom == null || copyFrom.damageArray == null)
			{
				this.damageArray = new float[6];
			}
			else if (copyFrom.damageArray.Length == 6)
			{
				this.damageArray = (float[])copyFrom.damageArray.Clone();
			}
			else
			{
				this.damageArray = new float[6];
				if (copyFrom.damageArray.Length > 6)
				{
					for (int i = 0; i < 6; i++)
					{
						this.damageArray[i] = copyFrom.damageArray[i];
					}
				}
				else
				{
					for (int j = 0; j < copyFrom.damageArray.Length; j++)
					{
						this.damageArray[j] = copyFrom.damageArray[j];
					}
				}
			}
		}
		else if (copyFrom.damageArray == null)
		{
			if (this.damageArray == null || this.damageArray.Length != 6)
			{
				this.damageArray = new float[6];
			}
			else
			{
				for (int k = 0; k < 6; k++)
				{
					this.damageArray[k] = 0f;
				}
			}
		}
		else if (copyFrom.damageArray.Length >= 6)
		{
			for (int l = 0; l < 6; l++)
			{
				this.damageArray[l] = copyFrom.damageArray[l];
			}
		}
		else
		{
			int m;
			for (m = 0; m < copyFrom.damageArray.Length; m++)
			{
				this.damageArray[m] = copyFrom.damageArray[m];
			}
			while (m < 6)
			{
				this.damageArray[m++] = 0f;
			}
		}
	}

	// Token: 0x040007CC RID: 1996
	private const int kDamageIndexCount = 6;

	// Token: 0x040007CD RID: 1997
	[global::UnityEngine.SerializeField]
	private float[] damageArray;
}
