using System;
using UnityEngine;

// Token: 0x02000603 RID: 1539
public class MegaTerrain : global::UnityEngine.MonoBehaviour
{
	// Token: 0x0600314F RID: 12623 RVA: 0x000BCD68 File Offset: 0x000BAF68
	public MegaTerrain()
	{
	}

	// Token: 0x06003150 RID: 12624 RVA: 0x000BCD7C File Offset: 0x000BAF7C
	private void Start()
	{
	}

	// Token: 0x06003151 RID: 12625 RVA: 0x000BCD80 File Offset: 0x000BAF80
	private void Update()
	{
	}

	// Token: 0x06003152 RID: 12626 RVA: 0x000BCD84 File Offset: 0x000BAF84
	[global::UnityEngine.ContextMenu("Generate")]
	private void Generate()
	{
		for (int i = 0; i < 0x10; i++)
		{
			for (int j = 0; j < 0x10; j++)
			{
			}
		}
	}

	// Token: 0x06003153 RID: 12627 RVA: 0x000BCDB8 File Offset: 0x000BAFB8
	public global::UnityEngine.Terrain FindTerrain(int x, int y)
	{
		string text = string.Concat(new object[]
		{
			this.name_base,
			"_x",
			x,
			"_y",
			y
		});
		return (!(global::UnityEngine.GameObject.Find(text) != null)) ? null : global::UnityEngine.GameObject.Find(text).GetComponent<global::UnityEngine.Terrain>();
	}

	// Token: 0x06003154 RID: 12628 RVA: 0x000BCE20 File Offset: 0x000BB020
	[global::UnityEngine.ContextMenu("Stitch")]
	private void Stitch()
	{
		for (int i = 0; i < 4; i++)
		{
			for (int j = 0; j < 4; j++)
			{
				global::UnityEngine.Terrain terrain = this.FindTerrain(i, j);
				if (terrain)
				{
					global::UnityEngine.Debug.Log("found terrain");
					global::UnityEngine.Terrain terrain2 = this.FindTerrain(i - 1, j);
					global::UnityEngine.Terrain terrain3 = this.FindTerrain(i + 1, j);
					global::UnityEngine.Terrain terrain4 = this.FindTerrain(i, j + 1);
					global::UnityEngine.Terrain terrain5 = this.FindTerrain(i, j - 1);
					terrain.SetNeighbors(terrain2, terrain4, terrain3, terrain5);
					if (terrain2)
					{
					}
				}
				else
				{
					global::UnityEngine.Debug.Log(string.Concat(new object[]
					{
						"couldnt find terrain :",
						this.name_base,
						"_x",
						i,
						"_y",
						j
					}));
				}
			}
		}
	}

	// Token: 0x04001B75 RID: 7029
	public global::UnityEngine.TerrainData _rootTerrainData;

	// Token: 0x04001B76 RID: 7030
	public global::UnityEngine.Terrain[] _terrains;

	// Token: 0x04001B77 RID: 7031
	public string name_base = "rust_terrain";
}
