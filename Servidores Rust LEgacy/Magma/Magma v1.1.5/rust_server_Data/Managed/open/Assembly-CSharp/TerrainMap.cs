using System;
using UnityEngine;

// Token: 0x020005C6 RID: 1478
public class TerrainMap : global::UnityEngine.ScriptableObject
{
	// Token: 0x0600306E RID: 12398 RVA: 0x000B86E4 File Offset: 0x000B68E4
	public TerrainMap()
	{
	}

	// Token: 0x17000A2D RID: 2605
	// (get) Token: 0x0600306F RID: 12399 RVA: 0x000B86EC File Offset: 0x000B68EC
	public int width
	{
		get
		{
			return this._width;
		}
	}

	// Token: 0x17000A2E RID: 2606
	// (get) Token: 0x06003070 RID: 12400 RVA: 0x000B86F4 File Offset: 0x000B68F4
	public int height
	{
		get
		{
			return this._height;
		}
	}

	// Token: 0x17000A2F RID: 2607
	// (get) Token: 0x06003071 RID: 12401 RVA: 0x000B86FC File Offset: 0x000B68FC
	public int count
	{
		get
		{
			return this._width * this._height;
		}
	}

	// Token: 0x17000A30 RID: 2608
	public string this[int i]
	{
		get
		{
			return this._guids[i];
		}
		set
		{
			this._guids[i] = value;
		}
	}

	// Token: 0x17000A31 RID: 2609
	public string this[int x, int y]
	{
		get
		{
			return this[y * this._width + x];
		}
		set
		{
			this[y * this._width + x] = value;
		}
	}

	// Token: 0x06003076 RID: 12406 RVA: 0x000B874C File Offset: 0x000B694C
	public void ResizeGUIDS(int width, int height)
	{
		int width2 = this._width;
		int height2 = this._height;
		if (width2 != width || height2 != height)
		{
			string[] guids = this._guids;
			this._guids = new string[width * height];
			this._width = width;
			this._height = height;
			int num = global::UnityEngine.Mathf.Min(width2, width);
			int num2 = global::UnityEngine.Mathf.Min(height2, height);
			for (int i = 0; i < num2; i++)
			{
				for (int j = 0; j < num; j++)
				{
					this._guids[i * this._width + j] = guids[i * width2 + j];
				}
			}
		}
	}

	// Token: 0x04001A22 RID: 6690
	[global::UnityEngine.SerializeField]
	private string[] _guids;

	// Token: 0x04001A23 RID: 6691
	[global::UnityEngine.SerializeField]
	private int _width;

	// Token: 0x04001A24 RID: 6692
	[global::UnityEngine.SerializeField]
	private int _height;

	// Token: 0x04001A25 RID: 6693
	public float baseHeight;

	// Token: 0x04001A26 RID: 6694
	public global::UnityEngine.Vector3 scale;

	// Token: 0x04001A27 RID: 6695
	public global::UnityEngine.Terrain copyFrom;

	// Token: 0x04001A28 RID: 6696
	public global::UnityEngine.TerrainData root;
}
