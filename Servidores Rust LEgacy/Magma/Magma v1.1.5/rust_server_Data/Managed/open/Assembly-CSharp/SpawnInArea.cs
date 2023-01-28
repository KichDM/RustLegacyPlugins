using System;
using UnityEngine;

// Token: 0x020009B1 RID: 2481
public class SpawnInArea : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06005350 RID: 21328 RVA: 0x0015DD3C File Offset: 0x0015BF3C
	public SpawnInArea()
	{
	}

	// Token: 0x06005351 RID: 21329 RVA: 0x0015DD64 File Offset: 0x0015BF64
	private void RandomPositionOnTerrain(global::UnityEngine.GameObject obj)
	{
		global::UnityEngine.Vector3 size = global::UnityEngine.Terrain.activeTerrain.terrainData.size;
		global::UnityEngine.Vector3 vector = default(global::UnityEngine.Vector3);
		bool flag = false;
		while (!flag)
		{
			vector = global::UnityEngine.Terrain.activeTerrain.transform.position;
			float num = global::UnityEngine.Random.Range(0f, size.x);
			float num2 = global::UnityEngine.Random.Range(0f, size.z);
			vector.x += num;
			vector.y += size.y + this.Offset;
			vector.z += num2;
			if (this.SpawnMap)
			{
				int num3 = global::UnityEngine.Mathf.RoundToInt((float)this.SpawnMap.width * num / size.x);
				int num4 = global::UnityEngine.Mathf.RoundToInt((float)this.SpawnMap.height * num2 / size.z);
				float grayscale = this.SpawnMap.GetPixel(num3, num4).grayscale;
				flag = (grayscale > 0f && global::UnityEngine.Random.Range(0f, 1f) < grayscale);
			}
			else
			{
				flag = true;
			}
			if (flag)
			{
				global::UnityEngine.RaycastHit raycastHit;
				if (global::UnityEngine.Physics.Raycast(vector, -global::UnityEngine.Vector3.up, ref raycastHit))
				{
					float distance = raycastHit.distance;
					if (raycastHit.transform.name != "Terrain" && this.TerrainOnly)
					{
						flag = false;
					}
					vector.y -= distance - this.AboveGround;
				}
				else
				{
					flag = false;
				}
			}
		}
		obj.transform.position = vector;
		base.transform.Rotate(global::UnityEngine.Vector3.up * (float)global::UnityEngine.Random.Range(0, 0x168), 0);
	}

	// Token: 0x040030DD RID: 12509
	public global::UnityEngine.Texture2D SpawnMap;

	// Token: 0x040030DE RID: 12510
	private float Offset = 10f;

	// Token: 0x040030DF RID: 12511
	private float AboveGround = 1f;

	// Token: 0x040030E0 RID: 12512
	private bool TerrainOnly = true;
}
