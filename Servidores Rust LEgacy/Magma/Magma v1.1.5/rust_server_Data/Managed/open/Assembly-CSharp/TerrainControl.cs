using System;
using Facepunch;
using UnityEngine;

// Token: 0x020007C8 RID: 1992
[global::UnityEngine.ExecuteInEditMode]
public sealed class TerrainControl : global::UnityEngine.MonoBehaviour
{
	// Token: 0x060041FC RID: 16892 RVA: 0x000EFC90 File Offset: 0x000EDE90
	public TerrainControl()
	{
	}

	// Token: 0x060041FD RID: 16893 RVA: 0x000EFCB8 File Offset: 0x000EDEB8
	[global::UnityEngine.ContextMenu("Get settings from terrain")]
	private void CopyTerrainSettings()
	{
		this.settings.CopyFrom(this.terrain);
	}

	// Token: 0x060041FE RID: 16894 RVA: 0x000EFCCC File Offset: 0x000EDECC
	[global::UnityEngine.ContextMenu("Set settings to terrain")]
	private void RestoreTerrainSettings()
	{
		this.settings.CopyTo(this.terrain);
	}

	// Token: 0x17000C1C RID: 3100
	// (get) Token: 0x060041FF RID: 16895 RVA: 0x000EFCE0 File Offset: 0x000EDEE0
	// (set) Token: 0x06004200 RID: 16896 RVA: 0x000EFCE8 File Offset: 0x000EDEE8
	public float customBasemapDistance
	{
		get
		{
			return this._customBasemapDistance;
		}
		set
		{
			this._customBasemapDistance = value;
			this.BindTerrainSettings();
		}
	}

	// Token: 0x17000C1D RID: 3101
	// (get) Token: 0x06004201 RID: 16897 RVA: 0x000EFCF8 File Offset: 0x000EDEF8
	public global::UnityEngine.Terrain terrain
	{
		get
		{
			return this._terrain;
		}
	}

	// Token: 0x06004202 RID: 16898 RVA: 0x000EFD00 File Offset: 0x000EDF00
	private void Reset()
	{
		global::UnityEngine.GameObject[] array = global::UnityEngine.GameObject.FindGameObjectsWithTag("Main Terrain");
		if (array.Length > 0)
		{
			for (int i = 0; i < array.Length; i++)
			{
				this._terrain = array[i].GetComponent<global::UnityEngine.Terrain>();
				if (this._terrain)
				{
					break;
				}
			}
		}
	}

	// Token: 0x06004203 RID: 16899 RVA: 0x000EFD58 File Offset: 0x000EDF58
	private void OnApplicationQuit()
	{
		this.quitting = true;
	}

	// Token: 0x06004204 RID: 16900 RVA: 0x000EFD64 File Offset: 0x000EDF64
	private void OnEnable()
	{
		global::TerrainControl.activeTerrainControl = this;
		this.quitting = false;
		if (!this.running)
		{
			this.running = true;
			this.BindTerrainSettings();
		}
		if (this.reassignTerrainDataInterval > 0f)
		{
			base.Invoke("ReassignTerrainData", this.reassignTerrainDataInterval);
		}
	}

	// Token: 0x06004205 RID: 16901 RVA: 0x000EFDB8 File Offset: 0x000EDFB8
	internal static void ter_reassign()
	{
		if (global::TerrainControl.activeTerrainControl)
		{
			global::TerrainControl.activeTerrainControl.DoReassignmentOfTerrainData(true, false, false, false);
		}
	}

	// Token: 0x06004206 RID: 16902 RVA: 0x000EFDD8 File Offset: 0x000EDFD8
	internal static void ter_reassign_nocopy()
	{
		if (global::TerrainControl.activeTerrainControl)
		{
			global::TerrainControl.activeTerrainControl.DoReassignmentOfTerrainData(true, false, false, true);
		}
	}

	// Token: 0x06004207 RID: 16903 RVA: 0x000EFDF8 File Offset: 0x000EDFF8
	internal static void ter_flush()
	{
		if (global::TerrainControl.activeTerrainControl)
		{
			global::TerrainControl.activeTerrainControl.DoReassignmentOfTerrainData(false, true, false, false);
		}
	}

	// Token: 0x06004208 RID: 16904 RVA: 0x000EFE18 File Offset: 0x000EE018
	internal static void ter_mat()
	{
		if (global::TerrainControl.activeTerrainControl)
		{
			global::TerrainControl.activeTerrainControl.DoReassignmentOfTerrainData(false, false, true, false);
		}
	}

	// Token: 0x06004209 RID: 16905 RVA: 0x000EFE38 File Offset: 0x000EE038
	internal static void ter_flushtrees()
	{
		if (global::TerrainControl.activeTerrainControl && global::TerrainControl.activeTerrainControl._terrain)
		{
			global::TerrainHack.RefreshTreeTextures(global::TerrainControl.activeTerrainControl._terrain);
		}
	}

	// Token: 0x0600420A RID: 16906 RVA: 0x000EFE78 File Offset: 0x000EE078
	private bool DoReassignmentOfTerrainData(bool td, bool andFlush, bool mats, bool doNotCopySettings)
	{
		if (!this.terrainDataFromBundle && !global::Facepunch.Bundling.Load<global::UnityEngine.TerrainData>(this.bundlePathToTerrainData, out this.terrainDataFromBundle))
		{
			global::UnityEngine.Debug.LogError("Bad terrain data path " + this.bundlePathToTerrainData);
			return true;
		}
		if (td)
		{
			if (doNotCopySettings)
			{
				this.terrain.terrainData = this.terrainDataFromBundle;
			}
			else
			{
				this.terrain.terrainData = this.terrainDataFromBundle;
				this.RestoreTerrainSettings();
			}
		}
		if (mats)
		{
			this.terrain.materialTemplate = this._terrainMaterialTemplate;
		}
		if (andFlush)
		{
			this.terrain.Flush();
			if (mats)
			{
				this.terrain.materialTemplate = this._terrainMaterialTemplate;
			}
		}
		return !this.terrainDataFromBundle;
	}

	// Token: 0x0600420B RID: 16907 RVA: 0x000EFF4C File Offset: 0x000EE14C
	private void ReassignTerrainData()
	{
		if (global::UnityEngine.Application.isPlaying && !global::terrain.manual)
		{
			if (!global::Facepunch.Bundling.Load<global::UnityEngine.TerrainData>(this.bundlePathToTerrainData, out this.terrainDataFromBundle))
			{
				global::UnityEngine.Debug.LogError("Bad terrain data path " + this.bundlePathToTerrainData);
			}
			try
			{
				this.terrain.terrainData = this.terrainDataFromBundle;
				this.RestoreTerrainSettings();
			}
			catch (global::System.Exception ex)
			{
				global::UnityEngine.Debug.Log(ex, this);
				base.Invoke("ReassignTerrainData", this.reassignTerrainDataInterval);
			}
		}
	}

	// Token: 0x0600420C RID: 16908 RVA: 0x000EFFF0 File Offset: 0x000EE1F0
	private void OnDisable()
	{
		if (!this.quitting && this.running)
		{
			this.running = false;
		}
	}

	// Token: 0x0600420D RID: 16909 RVA: 0x000F0010 File Offset: 0x000EE210
	private void BindTerrainSettings()
	{
		if (this.forceCustomBasemapDistance && this.terrain)
		{
			this.terrain.basemapDistance = this.customBasemapDistance;
		}
	}

	// Token: 0x040022CE RID: 8910
	[global::UnityEngine.SerializeField]
	private global::UnityEngine.Terrain _terrain;

	// Token: 0x040022CF RID: 8911
	[global::UnityEngine.SerializeField]
	private float _customBasemapDistance = 10000f;

	// Token: 0x040022D0 RID: 8912
	[global::System.NonSerialized]
	private bool running;

	// Token: 0x040022D1 RID: 8913
	[global::System.NonSerialized]
	private bool quitting;

	// Token: 0x040022D2 RID: 8914
	[global::UnityEngine.SerializeField]
	private global::UnityEngine.Material _terrainMaterialTemplate;

	// Token: 0x040022D3 RID: 8915
	private static global::TerrainControl activeTerrainControl;

	// Token: 0x040022D4 RID: 8916
	[global::UnityEngine.SerializeField]
	private global::TerrainControl.TerrainSettingsHack settings;

	// Token: 0x040022D5 RID: 8917
	public bool forceCustomBasemapDistance = true;

	// Token: 0x040022D6 RID: 8918
	public string bundlePathToTerrainData = "Env/ter/rust_island_2013-2";

	// Token: 0x040022D7 RID: 8919
	public float reassignTerrainDataInterval;

	// Token: 0x040022D8 RID: 8920
	private global::UnityEngine.TerrainData terrainDataFromBundle;

	// Token: 0x040022D9 RID: 8921
	[global::System.NonSerialized]
	private float timeNoticedCameraChange;

	// Token: 0x040022DA RID: 8922
	[global::System.NonSerialized]
	private global::UnityEngine.Vector3 lastCameraPosition;

	// Token: 0x040022DB RID: 8923
	[global::System.NonSerialized]
	private global::UnityEngine.Vector3 lastCameraForward;

	// Token: 0x020007C9 RID: 1993
	[global::System.Serializable]
	private class TerrainSettingsHack
	{
		// Token: 0x0600420E RID: 16910 RVA: 0x000F004C File Offset: 0x000EE24C
		public TerrainSettingsHack()
		{
		}

		// Token: 0x0600420F RID: 16911 RVA: 0x000F0054 File Offset: 0x000EE254
		public void CopyFrom(global::UnityEngine.Terrain terrain)
		{
			this.basemapDistance = terrain.basemapDistance;
			this.castShadows = terrain.castShadows;
			this.detailObjectDensity = terrain.detailObjectDensity;
			this.detailObjectDistance = terrain.detailObjectDistance;
			this.heightmapMaximumLOD = terrain.heightmapMaximumLOD;
			this.heightmapPixelError = terrain.heightmapPixelError;
			this.materialTemplate = terrain.materialTemplate;
			this.treeBillboardDistance = terrain.treeBillboardDistance;
			this.treeCrossFadeLength = terrain.treeCrossFadeLength;
			this.treeDistance = terrain.treeDistance;
			this.treeMaximumFullLODCount = terrain.treeMaximumFullLODCount;
		}

		// Token: 0x06004210 RID: 16912 RVA: 0x000F00E8 File Offset: 0x000EE2E8
		public void CopyTo(global::UnityEngine.Terrain terrain)
		{
			terrain.basemapDistance = this.basemapDistance;
			terrain.castShadows = this.castShadows;
			terrain.detailObjectDensity = this.detailObjectDensity;
			terrain.detailObjectDistance = this.detailObjectDistance;
			terrain.heightmapMaximumLOD = this.heightmapMaximumLOD;
			terrain.heightmapPixelError = this.heightmapPixelError;
			terrain.materialTemplate = this.materialTemplate;
			terrain.treeBillboardDistance = this.treeBillboardDistance;
			terrain.treeCrossFadeLength = this.treeCrossFadeLength;
			terrain.treeDistance = this.treeDistance;
			terrain.treeMaximumFullLODCount = this.treeMaximumFullLODCount;
		}

		// Token: 0x040022DC RID: 8924
		public float basemapDistance;

		// Token: 0x040022DD RID: 8925
		public bool castShadows;

		// Token: 0x040022DE RID: 8926
		public float detailObjectDensity;

		// Token: 0x040022DF RID: 8927
		public float detailObjectDistance;

		// Token: 0x040022E0 RID: 8928
		public int heightmapMaximumLOD;

		// Token: 0x040022E1 RID: 8929
		public float heightmapPixelError;

		// Token: 0x040022E2 RID: 8930
		public global::UnityEngine.Material materialTemplate;

		// Token: 0x040022E3 RID: 8931
		public float treeBillboardDistance;

		// Token: 0x040022E4 RID: 8932
		public float treeCrossFadeLength;

		// Token: 0x040022E5 RID: 8933
		public float treeDistance;

		// Token: 0x040022E6 RID: 8934
		public int treeMaximumFullLODCount;
	}
}
