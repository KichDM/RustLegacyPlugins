using System;
using UnityEngine;

// Token: 0x020005D2 RID: 1490
public class SurfaceInfoTerrain : global::SurfaceInfo
{
	// Token: 0x060030A3 RID: 12451 RVA: 0x000B9088 File Offset: 0x000B7288
	public SurfaceInfoTerrain()
	{
	}

	// Token: 0x060030A4 RID: 12452 RVA: 0x000B9090 File Offset: 0x000B7290
	public override global::SurfaceInfoObject SurfaceObj()
	{
		return this.surfaces[0];
	}

	// Token: 0x060030A5 RID: 12453 RVA: 0x000B909C File Offset: 0x000B729C
	public override global::SurfaceInfoObject SurfaceObj(global::UnityEngine.Vector3 worldPos)
	{
		int textureIndex = global::TerrainTextureHelper.GetTextureIndex(worldPos);
		if (textureIndex >= this.surfaces.Length)
		{
			global::UnityEngine.Debug.Log("Missing surface info for splat index " + textureIndex);
			return this.surfaces[0];
		}
		return this.surfaces[textureIndex];
	}

	// Token: 0x04001A4C RID: 6732
	public global::SurfaceInfoObject[] surfaces;
}
