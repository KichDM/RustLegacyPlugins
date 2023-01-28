using System;
using UnityEngine;

// Token: 0x02000833 RID: 2099
[global::System.Serializable]
[global::UnityEngine.AddComponentMenu("Daikon Forge/User Interface/Sprite/Sliced")]
[global::UnityEngine.ExecuteInEditMode]
[global::UnityEngine.RequireComponent(typeof(global::UnityEngine.BoxCollider))]
public class dfSlicedSprite : global::dfSprite
{
	// Token: 0x060047E7 RID: 18407 RVA: 0x0010A5B0 File Offset: 0x001087B0
	public dfSlicedSprite()
	{
	}

	// Token: 0x060047E8 RID: 18408 RVA: 0x0010A5B8 File Offset: 0x001087B8
	// Note: this type is marked as 'beforefieldinit'.
	static dfSlicedSprite()
	{
		int[][] array = new int[4][];
		int num = 0;
		int[] array2 = new int[4];
		array2[0] = 0xB;
		array2[1] = 8;
		array2[2] = 3;
		array[num] = array2;
		array[1] = new int[]
		{
			0xA,
			9,
			2,
			1
		};
		array[2] = new int[]
		{
			0xF,
			0xC,
			7,
			4
		};
		array[3] = new int[]
		{
			0xE,
			0xD,
			6,
			5
		};
		global::dfSlicedSprite.vertFill = array;
		global::dfSlicedSprite.fillIndices = new int[][]
		{
			new int[4],
			new int[4],
			new int[4],
			new int[4]
		};
		global::dfSlicedSprite.verts = new global::UnityEngine.Vector3[0x10];
		global::dfSlicedSprite.uv = new global::UnityEngine.Vector2[0x10];
	}

	// Token: 0x060047E9 RID: 18409 RVA: 0x0010A6DC File Offset: 0x001088DC
	protected override void OnRebuildRenderData()
	{
		if (base.Atlas == null)
		{
			return;
		}
		global::dfAtlas.ItemInfo spriteInfo = base.SpriteInfo;
		if (spriteInfo == null)
		{
			return;
		}
		this.renderData.Material = base.Atlas.Material;
		if (spriteInfo.border.horizontal == 0 && spriteInfo.border.vertical == 0)
		{
			base.OnRebuildRenderData();
			return;
		}
		global::UnityEngine.Color32 color = base.ApplyOpacity((!base.IsEnabled) ? this.disabledColor : this.color);
		global::dfSprite.RenderOptions options = new global::dfSprite.RenderOptions
		{
			atlas = this.atlas,
			color = color,
			fillAmount = this.fillAmount,
			fillDirection = this.fillDirection,
			flip = this.flip,
			invertFill = this.invertFill,
			offset = this.pivot.TransformToUpperLeft(base.Size),
			pixelsToUnits = base.PixelsToUnits(),
			size = base.Size,
			spriteInfo = base.SpriteInfo
		};
		global::dfSlicedSprite.renderSprite(this.renderData, options);
	}

	// Token: 0x060047EA RID: 18410 RVA: 0x0010A810 File Offset: 0x00108A10
	internal new static void renderSprite(global::dfRenderData renderData, global::dfSprite.RenderOptions options)
	{
		options.baseIndex = renderData.Vertices.Count;
		global::dfSlicedSprite.rebuildTriangles(renderData, options);
		global::dfSlicedSprite.rebuildVertices(renderData, options);
		global::dfSlicedSprite.rebuildUV(renderData, options);
		global::dfSlicedSprite.rebuildColors(renderData, options);
		if (options.fillAmount < 1f)
		{
			global::dfSlicedSprite.doFill(renderData, options);
		}
	}

	// Token: 0x060047EB RID: 18411 RVA: 0x0010A864 File Offset: 0x00108A64
	private static void rebuildTriangles(global::dfRenderData renderData, global::dfSprite.RenderOptions options)
	{
		int baseIndex = options.baseIndex;
		global::dfList<int> triangles = renderData.Triangles;
		for (int i = 0; i < global::dfSlicedSprite.triangleIndices.Length; i++)
		{
			triangles.Add(baseIndex + global::dfSlicedSprite.triangleIndices[i]);
		}
	}

	// Token: 0x060047EC RID: 18412 RVA: 0x0010A8A8 File Offset: 0x00108AA8
	private static void doFill(global::dfRenderData renderData, global::dfSprite.RenderOptions options)
	{
		int baseIndex = options.baseIndex;
		global::dfList<global::UnityEngine.Vector3> vertices = renderData.Vertices;
		global::dfList<global::UnityEngine.Vector2> dfList = renderData.UV;
		int[][] array = global::dfSlicedSprite.getFillIndices(options.fillDirection, baseIndex);
		bool flag = options.invertFill;
		if (options.fillDirection == global::dfFillDirection.Vertical)
		{
			flag = !flag;
		}
		if (flag)
		{
			for (int i = 0; i < array.Length; i++)
			{
				global::System.Array.Reverse(array[i]);
			}
		}
		int num = (options.fillDirection != global::dfFillDirection.Horizontal) ? 1 : 0;
		float num2 = vertices[array[0][flag ? 3 : 0]][num];
		float num3 = vertices[array[0][flag ? 0 : 3]][num];
		float num4 = global::UnityEngine.Mathf.Abs(num3 - num2);
		float num5 = flag ? (num3 - options.fillAmount * num4) : (num2 + options.fillAmount * num4);
		for (int j = 0; j < array.Length; j++)
		{
			if (!flag)
			{
				for (int k = 3; k > 0; k--)
				{
					float num6 = vertices[array[j][k]][num];
					if (num6 >= num5)
					{
						global::UnityEngine.Vector3 value = vertices[array[j][k]];
						value[num] = num5;
						vertices[array[j][k]] = value;
						float num7 = vertices[array[j][k - 1]][num];
						if (num7 <= num5)
						{
							float num8 = num6 - num7;
							float num9 = (num5 - num7) / num8;
							float num10 = dfList[array[j][k]][num];
							float num11 = dfList[array[j][k - 1]][num];
							global::UnityEngine.Vector2 value2 = dfList[array[j][k]];
							value2[num] = global::UnityEngine.Mathf.Lerp(num11, num10, num9);
							dfList[array[j][k]] = value2;
						}
					}
				}
			}
			else
			{
				for (int l = 1; l < 4; l++)
				{
					float num12 = vertices[array[j][l]][num];
					if (num12 <= num5)
					{
						global::UnityEngine.Vector3 value3 = vertices[array[j][l]];
						value3[num] = num5;
						vertices[array[j][l]] = value3;
						float num13 = vertices[array[j][l - 1]][num];
						if (num13 >= num5)
						{
							float num14 = num12 - num13;
							float num15 = (num5 - num13) / num14;
							float num16 = dfList[array[j][l]][num];
							float num17 = dfList[array[j][l - 1]][num];
							global::UnityEngine.Vector2 value4 = dfList[array[j][l]];
							value4[num] = global::UnityEngine.Mathf.Lerp(num17, num16, num15);
							dfList[array[j][l]] = value4;
						}
					}
				}
			}
		}
	}

	// Token: 0x060047ED RID: 18413 RVA: 0x0010ABEC File Offset: 0x00108DEC
	private static int[][] getFillIndices(global::dfFillDirection fillDirection, int baseIndex)
	{
		int[][] array = (fillDirection != global::dfFillDirection.Horizontal) ? global::dfSlicedSprite.vertFill : global::dfSlicedSprite.horzFill;
		for (int i = 0; i < 4; i++)
		{
			for (int j = 0; j < 4; j++)
			{
				global::dfSlicedSprite.fillIndices[i][j] = baseIndex + array[i][j];
			}
		}
		return global::dfSlicedSprite.fillIndices;
	}

	// Token: 0x060047EE RID: 18414 RVA: 0x0010AC48 File Offset: 0x00108E48
	private static void rebuildVertices(global::dfRenderData renderData, global::dfSprite.RenderOptions options)
	{
		float num = 0f;
		float num2 = 0f;
		float num3 = global::UnityEngine.Mathf.Ceil(options.size.x);
		float num4 = global::UnityEngine.Mathf.Ceil(-options.size.y);
		global::dfAtlas.ItemInfo spriteInfo = options.spriteInfo;
		float num5 = (float)spriteInfo.border.left;
		float num6 = (float)spriteInfo.border.top;
		float num7 = (float)spriteInfo.border.right;
		float num8 = (float)spriteInfo.border.bottom;
		if (options.flip.IsSet(global::dfSpriteFlip.FlipHorizontal))
		{
			float num9 = num7;
			num7 = num5;
			num5 = num9;
		}
		if (options.flip.IsSet(global::dfSpriteFlip.FlipVertical))
		{
			float num10 = num8;
			num8 = num6;
			num6 = num10;
		}
		global::dfSlicedSprite.verts[0] = new global::UnityEngine.Vector3(num, num2, 0f) + options.offset;
		global::dfSlicedSprite.verts[1] = global::dfSlicedSprite.verts[0] + new global::UnityEngine.Vector3(num5, 0f, 0f);
		global::dfSlicedSprite.verts[2] = global::dfSlicedSprite.verts[0] + new global::UnityEngine.Vector3(num5, -num6, 0f);
		global::dfSlicedSprite.verts[3] = global::dfSlicedSprite.verts[0] + new global::UnityEngine.Vector3(0f, -num6, 0f);
		global::dfSlicedSprite.verts[4] = new global::UnityEngine.Vector3(num3 - num7, num2, 0f) + options.offset;
		global::dfSlicedSprite.verts[5] = global::dfSlicedSprite.verts[4] + new global::UnityEngine.Vector3(num7, 0f, 0f);
		global::dfSlicedSprite.verts[6] = global::dfSlicedSprite.verts[4] + new global::UnityEngine.Vector3(num7, -num6, 0f);
		global::dfSlicedSprite.verts[7] = global::dfSlicedSprite.verts[4] + new global::UnityEngine.Vector3(0f, -num6, 0f);
		global::dfSlicedSprite.verts[8] = new global::UnityEngine.Vector3(num, num4 + num8, 0f) + options.offset;
		global::dfSlicedSprite.verts[9] = global::dfSlicedSprite.verts[8] + new global::UnityEngine.Vector3(num5, 0f, 0f);
		global::dfSlicedSprite.verts[0xA] = global::dfSlicedSprite.verts[8] + new global::UnityEngine.Vector3(num5, -num8, 0f);
		global::dfSlicedSprite.verts[0xB] = global::dfSlicedSprite.verts[8] + new global::UnityEngine.Vector3(0f, -num8, 0f);
		global::dfSlicedSprite.verts[0xC] = new global::UnityEngine.Vector3(num3 - num7, num4 + num8, 0f) + options.offset;
		global::dfSlicedSprite.verts[0xD] = global::dfSlicedSprite.verts[0xC] + new global::UnityEngine.Vector3(num7, 0f, 0f);
		global::dfSlicedSprite.verts[0xE] = global::dfSlicedSprite.verts[0xC] + new global::UnityEngine.Vector3(num7, -num8, 0f);
		global::dfSlicedSprite.verts[0xF] = global::dfSlicedSprite.verts[0xC] + new global::UnityEngine.Vector3(0f, -num8, 0f);
		for (int i = 0; i < global::dfSlicedSprite.verts.Length; i++)
		{
			renderData.Vertices.Add((global::dfSlicedSprite.verts[i] * options.pixelsToUnits).Quantize(options.pixelsToUnits));
		}
	}

	// Token: 0x060047EF RID: 18415 RVA: 0x0010B094 File Offset: 0x00109294
	private static void rebuildUV(global::dfRenderData renderData, global::dfSprite.RenderOptions options)
	{
		global::dfAtlas atlas = options.atlas;
		global::UnityEngine.Vector2 vector;
		vector..ctor((float)atlas.Texture.width, (float)atlas.Texture.height);
		global::dfAtlas.ItemInfo spriteInfo = options.spriteInfo;
		float num = (float)spriteInfo.border.top / vector.y;
		float num2 = (float)spriteInfo.border.bottom / vector.y;
		float num3 = (float)spriteInfo.border.left / vector.x;
		float num4 = (float)spriteInfo.border.right / vector.x;
		global::UnityEngine.Rect region = spriteInfo.region;
		global::dfSlicedSprite.uv[0] = new global::UnityEngine.Vector2(region.x, region.yMax);
		global::dfSlicedSprite.uv[1] = new global::UnityEngine.Vector2(region.x + num3, region.yMax);
		global::dfSlicedSprite.uv[2] = new global::UnityEngine.Vector2(region.x + num3, region.yMax - num);
		global::dfSlicedSprite.uv[3] = new global::UnityEngine.Vector2(region.x, region.yMax - num);
		global::dfSlicedSprite.uv[4] = new global::UnityEngine.Vector2(region.xMax - num4, region.yMax);
		global::dfSlicedSprite.uv[5] = new global::UnityEngine.Vector2(region.xMax, region.yMax);
		global::dfSlicedSprite.uv[6] = new global::UnityEngine.Vector2(region.xMax, region.yMax - num);
		global::dfSlicedSprite.uv[7] = new global::UnityEngine.Vector2(region.xMax - num4, region.yMax - num);
		global::dfSlicedSprite.uv[8] = new global::UnityEngine.Vector2(region.x, region.y + num2);
		global::dfSlicedSprite.uv[9] = new global::UnityEngine.Vector2(region.x + num3, region.y + num2);
		global::dfSlicedSprite.uv[0xA] = new global::UnityEngine.Vector2(region.x + num3, region.y);
		global::dfSlicedSprite.uv[0xB] = new global::UnityEngine.Vector2(region.x, region.y);
		global::dfSlicedSprite.uv[0xC] = new global::UnityEngine.Vector2(region.xMax - num4, region.y + num2);
		global::dfSlicedSprite.uv[0xD] = new global::UnityEngine.Vector2(region.xMax, region.y + num2);
		global::dfSlicedSprite.uv[0xE] = new global::UnityEngine.Vector2(region.xMax, region.y);
		global::dfSlicedSprite.uv[0xF] = new global::UnityEngine.Vector2(region.xMax - num4, region.y);
		if (options.flip != global::dfSpriteFlip.None)
		{
			for (int i = 0; i < global::dfSlicedSprite.uv.Length; i += 4)
			{
				global::UnityEngine.Vector2 vector2 = global::UnityEngine.Vector2.zero;
				if (options.flip.IsSet(global::dfSpriteFlip.FlipHorizontal))
				{
					vector2 = global::dfSlicedSprite.uv[i];
					global::dfSlicedSprite.uv[i] = global::dfSlicedSprite.uv[i + 1];
					global::dfSlicedSprite.uv[i + 1] = vector2;
					vector2 = global::dfSlicedSprite.uv[i + 2];
					global::dfSlicedSprite.uv[i + 2] = global::dfSlicedSprite.uv[i + 3];
					global::dfSlicedSprite.uv[i + 3] = vector2;
				}
				if (options.flip.IsSet(global::dfSpriteFlip.FlipVertical))
				{
					vector2 = global::dfSlicedSprite.uv[i];
					global::dfSlicedSprite.uv[i] = global::dfSlicedSprite.uv[i + 3];
					global::dfSlicedSprite.uv[i + 3] = vector2;
					vector2 = global::dfSlicedSprite.uv[i + 1];
					global::dfSlicedSprite.uv[i + 1] = global::dfSlicedSprite.uv[i + 2];
					global::dfSlicedSprite.uv[i + 2] = vector2;
				}
			}
			if (options.flip.IsSet(global::dfSpriteFlip.FlipHorizontal))
			{
				global::UnityEngine.Vector2[] array = new global::UnityEngine.Vector2[global::dfSlicedSprite.uv.Length];
				global::System.Array.Copy(global::dfSlicedSprite.uv, array, global::dfSlicedSprite.uv.Length);
				global::System.Array.Copy(global::dfSlicedSprite.uv, 0, global::dfSlicedSprite.uv, 4, 4);
				global::System.Array.Copy(array, 4, global::dfSlicedSprite.uv, 0, 4);
				global::System.Array.Copy(global::dfSlicedSprite.uv, 8, global::dfSlicedSprite.uv, 0xC, 4);
				global::System.Array.Copy(array, 0xC, global::dfSlicedSprite.uv, 8, 4);
			}
			if (options.flip.IsSet(global::dfSpriteFlip.FlipVertical))
			{
				global::UnityEngine.Vector2[] array2 = new global::UnityEngine.Vector2[global::dfSlicedSprite.uv.Length];
				global::System.Array.Copy(global::dfSlicedSprite.uv, array2, global::dfSlicedSprite.uv.Length);
				global::System.Array.Copy(global::dfSlicedSprite.uv, 0, global::dfSlicedSprite.uv, 8, 4);
				global::System.Array.Copy(array2, 8, global::dfSlicedSprite.uv, 0, 4);
				global::System.Array.Copy(global::dfSlicedSprite.uv, 4, global::dfSlicedSprite.uv, 0xC, 4);
				global::System.Array.Copy(array2, 0xC, global::dfSlicedSprite.uv, 4, 4);
			}
		}
		for (int j = 0; j < global::dfSlicedSprite.uv.Length; j++)
		{
			renderData.UV.Add(global::dfSlicedSprite.uv[j]);
		}
	}

	// Token: 0x060047F0 RID: 18416 RVA: 0x0010B644 File Offset: 0x00109844
	private static void rebuildColors(global::dfRenderData renderData, global::dfSprite.RenderOptions options)
	{
		for (int i = 0; i < 0x10; i++)
		{
			renderData.Colors.Add(options.color);
		}
	}

	// Token: 0x04002699 RID: 9881
	private static int[] triangleIndices = new int[]
	{
		0,
		1,
		2,
		2,
		3,
		0,
		4,
		5,
		6,
		6,
		7,
		4,
		8,
		9,
		0xA,
		0xA,
		0xB,
		8,
		0xC,
		0xD,
		0xE,
		0xE,
		0xF,
		0xC,
		1,
		4,
		7,
		7,
		2,
		1,
		9,
		0xC,
		0xF,
		0xF,
		0xA,
		9,
		3,
		2,
		9,
		9,
		8,
		3,
		7,
		6,
		0xD,
		0xD,
		0xC,
		7,
		2,
		7,
		0xC,
		0xC,
		9,
		2
	};

	// Token: 0x0400269A RID: 9882
	private static int[][] horzFill = new int[][]
	{
		new int[]
		{
			0,
			1,
			4,
			5
		},
		new int[]
		{
			3,
			2,
			7,
			6
		},
		new int[]
		{
			8,
			9,
			0xC,
			0xD
		},
		new int[]
		{
			0xB,
			0xA,
			0xF,
			0xE
		}
	};

	// Token: 0x0400269B RID: 9883
	private static int[][] vertFill;

	// Token: 0x0400269C RID: 9884
	private static int[][] fillIndices;

	// Token: 0x0400269D RID: 9885
	private static global::UnityEngine.Vector3[] verts;

	// Token: 0x0400269E RID: 9886
	private static global::UnityEngine.Vector2[] uv;
}
