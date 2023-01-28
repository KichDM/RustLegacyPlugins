using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x020009AE RID: 2478
public class CraterMaker : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06005344 RID: 21316 RVA: 0x0015D590 File Offset: 0x0015B790
	public CraterMaker()
	{
	}

	// Token: 0x06005345 RID: 21317 RVA: 0x0015D598 File Offset: 0x0015B798
	public void Create(global::UnityEngine.Vector3 position, float radius, float depth, float noise)
	{
		this.Create(new global::UnityEngine.Vector2(position.x, position.z), radius, depth, noise);
	}

	// Token: 0x06005346 RID: 21318 RVA: 0x0015D5B8 File Offset: 0x0015B7B8
	public void Create(global::UnityEngine.Vector2 position, float radius, float depth, float noise)
	{
		base.StartCoroutine(this.RealCreate(position, radius, depth, noise));
	}

	// Token: 0x06005347 RID: 21319 RVA: 0x0015D5CC File Offset: 0x0015B7CC
	public global::System.Collections.IEnumerator RealCreate(global::UnityEngine.Vector2 position, float radius, float depth, float noise)
	{
		global::UnityEngine.TerrainData tdata = this.MyTerrain.terrainData;
		global::UnityEngine.Vector3 size = tdata.size;
		global::UnityEngine.Vector3 pos = this.MyTerrain.transform.position;
		position.x -= pos.x;
		position.y -= pos.y;
		float scale = (float)tdata.heightmapResolution / size.x;
		int width = (int)global::UnityEngine.Mathf.Floor(radius * scale);
		int xpos = (int)global::UnityEngine.Mathf.Floor((position.x - radius) * scale);
		int ypos = (int)global::UnityEngine.Mathf.Floor((position.y - radius) * scale);
		float[,] heights = tdata.GetHeights(xpos, ypos, width * 2, width * 2);
		float heightscale = depth / (size.y * 2f);
		for (int i = 0; i < width * 2; i++)
		{
			for (int j = 0; j < width * 2; j++)
			{
				float mod = global::UnityEngine.Mathf.SmoothStep(1f, 0f, global::UnityEngine.Mathf.Abs((float)width - (float)i) / (float)width) * global::UnityEngine.Mathf.SmoothStep(1f, 0f, global::UnityEngine.Mathf.Abs((float)width - (float)j) / (float)width);
				mod *= heightscale;
				if (noise > 0f)
				{
					mod += mod * heightscale * depth * global::UnityEngine.Random.value * noise;
				}
				heights[i, j] -= mod;
			}
		}
		tdata.SetHeights(xpos, ypos, heights);
		yield return new global::UnityEngine.WaitForFixedUpdate();
		yield return new global::UnityEngine.WaitForFixedUpdate();
		scale = (float)tdata.alphamapResolution / size.x;
		width = (int)global::UnityEngine.Mathf.Floor(radius * scale);
		xpos = (int)global::UnityEngine.Mathf.Floor((position.x - radius) * scale);
		ypos = (int)global::UnityEngine.Mathf.Floor((position.y - radius) * scale);
		float[,,] textures = tdata.GetAlphamaps(xpos, ypos, width * 2, width * 2);
		int splats = textures.Length / (width * width * 4);
		for (int k = 0; k < width * 2; k++)
		{
			for (int l = 0; l < width * 2; l++)
			{
				float mod2 = global::UnityEngine.Mathf.SmoothStep(1f, 0f, global::UnityEngine.Mathf.Abs((float)width - (float)k) / (float)width) * global::UnityEngine.Mathf.SmoothStep(1f, 0f, global::UnityEngine.Mathf.Abs((float)width - (float)l) / (float)width);
				textures[k, l, this.insidetextureindex] += mod2;
				for (int s = 0; s < splats; s++)
				{
					if (s == this.insidetextureindex)
					{
						textures[k, l, s] += mod2;
					}
					else
					{
						textures[k, l, s] -= textures[k, l, s] * mod2;
					}
				}
				float sum = 0f;
				for (int s2 = 0; s2 < splats; s2++)
				{
					sum += textures[k, l, s2];
				}
				for (int s3 = 0; s3 < splats; s3++)
				{
					textures[k, l, s3] *= 1f / sum;
				}
			}
		}
		tdata.SetAlphamaps(xpos, ypos, textures);
		yield break;
	}

	// Token: 0x040030B7 RID: 12471
	public global::UnityEngine.Terrain MyTerrain;

	// Token: 0x040030B8 RID: 12472
	public int insidetextureindex;

	// Token: 0x020009AF RID: 2479
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private sealed class <RealCreate>c__Iterator5E : global::System.IDisposable, global::System.Collections.IEnumerator, global::System.Collections.Generic.IEnumerator<object>
	{
		// Token: 0x06005348 RID: 21320 RVA: 0x0015D624 File Offset: 0x0015B824
		public <RealCreate>c__Iterator5E()
		{
		}

		// Token: 0x17000F95 RID: 3989
		// (get) Token: 0x06005349 RID: 21321 RVA: 0x0015D62C File Offset: 0x0015B82C
		object global::System.Collections.Generic.IEnumerator<object>.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17000F96 RID: 3990
		// (get) Token: 0x0600534A RID: 21322 RVA: 0x0015D634 File Offset: 0x0015B834
		object global::System.Collections.IEnumerator.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x0600534B RID: 21323 RVA: 0x0015D63C File Offset: 0x0015B83C
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			switch (num)
			{
			case 0U:
				tdata = this.MyTerrain.terrainData;
				size = tdata.size;
				pos = this.MyTerrain.transform.position;
				position.x -= pos.x;
				position.y -= pos.y;
				scale = (float)tdata.heightmapResolution / size.x;
				width = (int)global::UnityEngine.Mathf.Floor(radius * scale);
				xpos = (int)global::UnityEngine.Mathf.Floor((position.x - radius) * scale);
				ypos = (int)global::UnityEngine.Mathf.Floor((position.y - radius) * scale);
				heights = tdata.GetHeights(xpos, ypos, width * 2, width * 2);
				heightscale = depth / (size.y * 2f);
				for (i = 0; i < width * 2; i++)
				{
					for (j = 0; j < width * 2; j++)
					{
						mod = global::UnityEngine.Mathf.SmoothStep(1f, 0f, global::UnityEngine.Mathf.Abs((float)width - (float)i) / (float)width) * global::UnityEngine.Mathf.SmoothStep(1f, 0f, global::UnityEngine.Mathf.Abs((float)width - (float)j) / (float)width);
						mod *= heightscale;
						if (noise > 0f)
						{
							mod += mod * heightscale * depth * global::UnityEngine.Random.value * noise;
						}
						heights[i, j] -= mod;
					}
				}
				tdata.SetHeights(xpos, ypos, heights);
				this.$current = new global::UnityEngine.WaitForFixedUpdate();
				this.$PC = 1;
				return true;
			case 1U:
				this.$current = new global::UnityEngine.WaitForFixedUpdate();
				this.$PC = 2;
				return true;
			case 2U:
				scale = (float)tdata.alphamapResolution / size.x;
				width = (int)global::UnityEngine.Mathf.Floor(radius * scale);
				xpos = (int)global::UnityEngine.Mathf.Floor((position.x - radius) * scale);
				ypos = (int)global::UnityEngine.Mathf.Floor((position.y - radius) * scale);
				textures = tdata.GetAlphamaps(xpos, ypos, width * 2, width * 2);
				splats = textures.Length / (width * width * 4);
				for (k = 0; k < width * 2; k++)
				{
					for (l = 0; l < width * 2; l++)
					{
						mod2 = global::UnityEngine.Mathf.SmoothStep(1f, 0f, global::UnityEngine.Mathf.Abs((float)width - (float)k) / (float)width) * global::UnityEngine.Mathf.SmoothStep(1f, 0f, global::UnityEngine.Mathf.Abs((float)width - (float)l) / (float)width);
						textures[k, l, this.insidetextureindex] += mod2;
						for (s = 0; s < splats; s++)
						{
							if (s == this.insidetextureindex)
							{
								textures[k, l, s] += mod2;
							}
							else
							{
								textures[k, l, s] -= textures[k, l, s] * mod2;
							}
						}
						sum = 0f;
						for (s2 = 0; s2 < splats; s2++)
						{
							sum += textures[k, l, s2];
						}
						for (s3 = 0; s3 < splats; s3++)
						{
							textures[k, l, s3] *= 1f / sum;
						}
					}
				}
				tdata.SetAlphamaps(xpos, ypos, textures);
				this.$PC = -1;
				break;
			}
			return false;
		}

		// Token: 0x0600534C RID: 21324 RVA: 0x0015DC70 File Offset: 0x0015BE70
		[global::System.Diagnostics.DebuggerHidden]
		public void Dispose()
		{
			this.$PC = -1;
		}

		// Token: 0x0600534D RID: 21325 RVA: 0x0015DC7C File Offset: 0x0015BE7C
		[global::System.Diagnostics.DebuggerHidden]
		public void Reset()
		{
			throw new global::System.NotSupportedException();
		}

		// Token: 0x040030B9 RID: 12473
		internal global::UnityEngine.TerrainData <tdata>__0;

		// Token: 0x040030BA RID: 12474
		internal global::UnityEngine.Vector3 <size>__1;

		// Token: 0x040030BB RID: 12475
		internal global::UnityEngine.Vector3 <pos>__2;

		// Token: 0x040030BC RID: 12476
		internal global::UnityEngine.Vector2 position;

		// Token: 0x040030BD RID: 12477
		internal float <scale>__3;

		// Token: 0x040030BE RID: 12478
		internal float radius;

		// Token: 0x040030BF RID: 12479
		internal int <width>__4;

		// Token: 0x040030C0 RID: 12480
		internal int <xpos>__5;

		// Token: 0x040030C1 RID: 12481
		internal int <ypos>__6;

		// Token: 0x040030C2 RID: 12482
		internal float[,] <heights>__7;

		// Token: 0x040030C3 RID: 12483
		internal float depth;

		// Token: 0x040030C4 RID: 12484
		internal float <heightscale>__8;

		// Token: 0x040030C5 RID: 12485
		internal int <i>__9;

		// Token: 0x040030C6 RID: 12486
		internal int <j>__10;

		// Token: 0x040030C7 RID: 12487
		internal float <mod>__11;

		// Token: 0x040030C8 RID: 12488
		internal float noise;

		// Token: 0x040030C9 RID: 12489
		internal float[,,] <textures>__12;

		// Token: 0x040030CA RID: 12490
		internal int <splats>__13;

		// Token: 0x040030CB RID: 12491
		internal int <i>__14;

		// Token: 0x040030CC RID: 12492
		internal int <j>__15;

		// Token: 0x040030CD RID: 12493
		internal float <mod>__16;

		// Token: 0x040030CE RID: 12494
		internal int <s>__17;

		// Token: 0x040030CF RID: 12495
		internal float <sum>__18;

		// Token: 0x040030D0 RID: 12496
		internal int <s>__19;

		// Token: 0x040030D1 RID: 12497
		internal int <s>__20;

		// Token: 0x040030D2 RID: 12498
		internal int $PC;

		// Token: 0x040030D3 RID: 12499
		internal object $current;

		// Token: 0x040030D4 RID: 12500
		internal global::UnityEngine.Vector2 <$>position;

		// Token: 0x040030D5 RID: 12501
		internal float <$>radius;

		// Token: 0x040030D6 RID: 12502
		internal float <$>depth;

		// Token: 0x040030D7 RID: 12503
		internal float <$>noise;

		// Token: 0x040030D8 RID: 12504
		internal global::CraterMaker <>f__this;
	}
}
