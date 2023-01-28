using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000974 RID: 2420
[global::UnityEngine.AddComponentMenu("Terrain/Terrain Toolkit")]
[global::UnityEngine.ExecuteInEditMode]
public class TerrainToolkit : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06005274 RID: 21108 RVA: 0x001535B8 File Offset: 0x001517B8
	public TerrainToolkit()
	{
	}

	// Token: 0x06005275 RID: 21109 RVA: 0x00153818 File Offset: 0x00151A18
	public void addPresets()
	{
		this.presetsInitialised = true;
		this.voronoiPresets = new global::System.Collections.ArrayList();
		this.fractalPresets = new global::System.Collections.ArrayList();
		this.perlinPresets = new global::System.Collections.ArrayList();
		this.thermalErosionPresets = new global::System.Collections.ArrayList();
		this.fastHydraulicErosionPresets = new global::System.Collections.ArrayList();
		this.fullHydraulicErosionPresets = new global::System.Collections.ArrayList();
		this.velocityHydraulicErosionPresets = new global::System.Collections.ArrayList();
		this.tidalErosionPresets = new global::System.Collections.ArrayList();
		this.windErosionPresets = new global::System.Collections.ArrayList();
		this.voronoiPresets.Add(new global::TerrainToolkit.voronoiPresetData("Scattered Peaks", global::TerrainToolkit.VoronoiType.Linear, 0x10, 8f, 0.5f, 1f));
		this.voronoiPresets.Add(new global::TerrainToolkit.voronoiPresetData("Rolling Hills", global::TerrainToolkit.VoronoiType.Sine, 8, 8f, 0f, 1f));
		this.voronoiPresets.Add(new global::TerrainToolkit.voronoiPresetData("Jagged Mountains", global::TerrainToolkit.VoronoiType.Linear, 0x20, 32f, 0.5f, 1f));
		this.fractalPresets.Add(new global::TerrainToolkit.fractalPresetData("Rolling Plains", 0.4f, 1f));
		this.fractalPresets.Add(new global::TerrainToolkit.fractalPresetData("Rough Mountains", 0.5f, 1f));
		this.fractalPresets.Add(new global::TerrainToolkit.fractalPresetData("Add Noise", 0.75f, 0.05f));
		this.perlinPresets.Add(new global::TerrainToolkit.perlinPresetData("Rough Plains", 2, 0.5f, 9, 1f));
		this.perlinPresets.Add(new global::TerrainToolkit.perlinPresetData("Rolling Hills", 5, 0.75f, 3, 1f));
		this.perlinPresets.Add(new global::TerrainToolkit.perlinPresetData("Rocky Mountains", 4, 1f, 8, 1f));
		this.perlinPresets.Add(new global::TerrainToolkit.perlinPresetData("Hellish Landscape", 0xB, 1f, 7, 1f));
		this.perlinPresets.Add(new global::TerrainToolkit.perlinPresetData("Add Noise", 0xA, 1f, 8, 0.2f));
		this.thermalErosionPresets.Add(new global::TerrainToolkit.thermalErosionPresetData("Gradual, Weak Erosion", 0x19, 7.5f, 0.5f));
		this.thermalErosionPresets.Add(new global::TerrainToolkit.thermalErosionPresetData("Fast, Harsh Erosion", 0x19, 2.5f, 0.1f));
		this.thermalErosionPresets.Add(new global::TerrainToolkit.thermalErosionPresetData("Thermal Erosion Brush", 0x19, 0.1f, 0f));
		this.fastHydraulicErosionPresets.Add(new global::TerrainToolkit.fastHydraulicErosionPresetData("Rainswept Earth", 0x19, 70f, 1f));
		this.fastHydraulicErosionPresets.Add(new global::TerrainToolkit.fastHydraulicErosionPresetData("Terraced Slopes", 0x19, 30f, 0.4f));
		this.fastHydraulicErosionPresets.Add(new global::TerrainToolkit.fastHydraulicErosionPresetData("Hydraulic Erosion Brush", 0x19, 85f, 1f));
		this.fullHydraulicErosionPresets.Add(new global::TerrainToolkit.fullHydraulicErosionPresetData("Low Rainfall, Hard Rock", 0x19, 0.01f, 0.5f, 0.01f, 0.1f));
		this.fullHydraulicErosionPresets.Add(new global::TerrainToolkit.fullHydraulicErosionPresetData("Low Rainfall, Soft Earth", 0x19, 0.01f, 0.5f, 0.06f, 0.15f));
		this.fullHydraulicErosionPresets.Add(new global::TerrainToolkit.fullHydraulicErosionPresetData("Heavy Rainfall, Hard Rock", 0x19, 0.02f, 0.5f, 0.01f, 0.1f));
		this.fullHydraulicErosionPresets.Add(new global::TerrainToolkit.fullHydraulicErosionPresetData("Heavy Rainfall, Soft Earth", 0x19, 0.02f, 0.5f, 0.06f, 0.15f));
		this.velocityHydraulicErosionPresets.Add(new global::TerrainToolkit.velocityHydraulicErosionPresetData("Low Rainfall, Hard Rock", 0x19, 0.01f, 0.5f, 0.01f, 0.1f, 1f, 1f, 0.05f, 0.12f));
		this.velocityHydraulicErosionPresets.Add(new global::TerrainToolkit.velocityHydraulicErosionPresetData("Low Rainfall, Soft Earth", 0x19, 0.01f, 0.5f, 0.06f, 0.15f, 1.2f, 2.8f, 0.05f, 0.12f));
		this.velocityHydraulicErosionPresets.Add(new global::TerrainToolkit.velocityHydraulicErosionPresetData("Heavy Rainfall, Hard Rock", 0x19, 0.02f, 0.5f, 0.01f, 0.1f, 1.1f, 2.2f, 0.05f, 0.12f));
		this.velocityHydraulicErosionPresets.Add(new global::TerrainToolkit.velocityHydraulicErosionPresetData("Heavy Rainfall, Soft Earth", 0x19, 0.02f, 0.5f, 0.06f, 0.15f, 1.2f, 2.4f, 0.05f, 0.12f));
		this.velocityHydraulicErosionPresets.Add(new global::TerrainToolkit.velocityHydraulicErosionPresetData("Carved Stone", 0x19, 0.01f, 0.5f, 0.01f, 0.1f, 2f, 1.25f, 0.05f, 0.35f));
		this.tidalErosionPresets.Add(new global::TerrainToolkit.tidalErosionPresetData("Low Tidal Range, Calm Waves", 0x19, 5f, 65f));
		this.tidalErosionPresets.Add(new global::TerrainToolkit.tidalErosionPresetData("Low Tidal Range, Strong Waves", 0x19, 5f, 35f));
		this.tidalErosionPresets.Add(new global::TerrainToolkit.tidalErosionPresetData("High Tidal Range, Calm Water", 0x19, 15f, 55f));
		this.tidalErosionPresets.Add(new global::TerrainToolkit.tidalErosionPresetData("High Tidal Range, Strong Waves", 0x19, 15f, 25f));
		this.windErosionPresets.Add(new global::TerrainToolkit.windErosionPresetData("Default (Northerly)", 0x19, 180f, 0.5f, 0.01f, 0.5f, 0.01f, 0.1f, 0.25f));
		this.windErosionPresets.Add(new global::TerrainToolkit.windErosionPresetData("Default (Southerly)", 0x19, 0f, 0.5f, 0.01f, 0.5f, 0.01f, 0.1f, 0.25f));
		this.windErosionPresets.Add(new global::TerrainToolkit.windErosionPresetData("Default (Easterly)", 0x19, 270f, 0.5f, 0.01f, 0.5f, 0.01f, 0.1f, 0.25f));
		this.windErosionPresets.Add(new global::TerrainToolkit.windErosionPresetData("Default (Westerly)", 0x19, 90f, 0.5f, 0.01f, 0.5f, 0.01f, 0.1f, 0.25f));
	}

	// Token: 0x06005276 RID: 21110 RVA: 0x00153E44 File Offset: 0x00152044
	public void setVoronoiPreset(global::TerrainToolkit.voronoiPresetData preset)
	{
		this.generatorTypeInt = 0;
		this.generatorType = global::TerrainToolkit.GeneratorType.Voronoi;
		this.voronoiTypeInt = (int)preset.voronoiType;
		this.voronoiType = preset.voronoiType;
		this.voronoiCells = preset.voronoiCells;
		this.voronoiFeatures = preset.voronoiFeatures;
		this.voronoiScale = preset.voronoiScale;
		this.voronoiBlend = preset.voronoiBlend;
	}

	// Token: 0x06005277 RID: 21111 RVA: 0x00153EA8 File Offset: 0x001520A8
	public void setFractalPreset(global::TerrainToolkit.fractalPresetData preset)
	{
		this.generatorTypeInt = 1;
		this.generatorType = global::TerrainToolkit.GeneratorType.DiamondSquare;
		this.diamondSquareDelta = preset.diamondSquareDelta;
		this.diamondSquareBlend = preset.diamondSquareBlend;
	}

	// Token: 0x06005278 RID: 21112 RVA: 0x00153EDC File Offset: 0x001520DC
	public void setPerlinPreset(global::TerrainToolkit.perlinPresetData preset)
	{
		this.generatorTypeInt = 2;
		this.generatorType = global::TerrainToolkit.GeneratorType.Perlin;
		this.perlinFrequency = preset.perlinFrequency;
		this.perlinAmplitude = preset.perlinAmplitude;
		this.perlinOctaves = preset.perlinOctaves;
		this.perlinBlend = preset.perlinBlend;
	}

	// Token: 0x06005279 RID: 21113 RVA: 0x00153F28 File Offset: 0x00152128
	public void setThermalErosionPreset(global::TerrainToolkit.thermalErosionPresetData preset)
	{
		this.erosionTypeInt = 0;
		this.erosionType = global::TerrainToolkit.ErosionType.Thermal;
		this.thermalIterations = preset.thermalIterations;
		this.thermalMinSlope = preset.thermalMinSlope;
		this.thermalFalloff = preset.thermalFalloff;
	}

	// Token: 0x0600527A RID: 21114 RVA: 0x00153F68 File Offset: 0x00152168
	public void setFastHydraulicErosionPreset(global::TerrainToolkit.fastHydraulicErosionPresetData preset)
	{
		this.erosionTypeInt = 1;
		this.erosionType = global::TerrainToolkit.ErosionType.Hydraulic;
		this.hydraulicTypeInt = 0;
		this.hydraulicType = global::TerrainToolkit.HydraulicType.Fast;
		this.hydraulicIterations = preset.hydraulicIterations;
		this.hydraulicMaxSlope = preset.hydraulicMaxSlope;
		this.hydraulicFalloff = preset.hydraulicFalloff;
	}

	// Token: 0x0600527B RID: 21115 RVA: 0x00153FB8 File Offset: 0x001521B8
	public void setFullHydraulicErosionPreset(global::TerrainToolkit.fullHydraulicErosionPresetData preset)
	{
		this.erosionTypeInt = 1;
		this.erosionType = global::TerrainToolkit.ErosionType.Hydraulic;
		this.hydraulicTypeInt = 1;
		this.hydraulicType = global::TerrainToolkit.HydraulicType.Full;
		this.hydraulicIterations = preset.hydraulicIterations;
		this.hydraulicRainfall = preset.hydraulicRainfall;
		this.hydraulicEvaporation = preset.hydraulicEvaporation;
		this.hydraulicSedimentSolubility = preset.hydraulicSedimentSolubility;
		this.hydraulicSedimentSaturation = preset.hydraulicSedimentSaturation;
	}

	// Token: 0x0600527C RID: 21116 RVA: 0x00154020 File Offset: 0x00152220
	public void setVelocityHydraulicErosionPreset(global::TerrainToolkit.velocityHydraulicErosionPresetData preset)
	{
		this.erosionTypeInt = 1;
		this.erosionType = global::TerrainToolkit.ErosionType.Hydraulic;
		this.hydraulicTypeInt = 2;
		this.hydraulicType = global::TerrainToolkit.HydraulicType.Velocity;
		this.hydraulicIterations = preset.hydraulicIterations;
		this.hydraulicVelocityRainfall = preset.hydraulicVelocityRainfall;
		this.hydraulicVelocityEvaporation = preset.hydraulicVelocityEvaporation;
		this.hydraulicVelocitySedimentSolubility = preset.hydraulicVelocitySedimentSolubility;
		this.hydraulicVelocitySedimentSaturation = preset.hydraulicVelocitySedimentSaturation;
		this.hydraulicVelocity = preset.hydraulicVelocity;
		this.hydraulicMomentum = preset.hydraulicMomentum;
		this.hydraulicEntropy = preset.hydraulicEntropy;
		this.hydraulicDowncutting = preset.hydraulicDowncutting;
	}

	// Token: 0x0600527D RID: 21117 RVA: 0x001540B8 File Offset: 0x001522B8
	public void setTidalErosionPreset(global::TerrainToolkit.tidalErosionPresetData preset)
	{
		this.erosionTypeInt = 2;
		this.erosionType = global::TerrainToolkit.ErosionType.Tidal;
		this.tidalIterations = preset.tidalIterations;
		this.tidalRangeAmount = preset.tidalRangeAmount;
		this.tidalCliffLimit = preset.tidalCliffLimit;
	}

	// Token: 0x0600527E RID: 21118 RVA: 0x001540F8 File Offset: 0x001522F8
	public void setWindErosionPreset(global::TerrainToolkit.windErosionPresetData preset)
	{
		this.erosionTypeInt = 3;
		this.erosionType = global::TerrainToolkit.ErosionType.Wind;
		this.windIterations = preset.windIterations;
		this.windDirection = preset.windDirection;
		this.windForce = preset.windForce;
		this.windLift = preset.windLift;
		this.windGravity = preset.windGravity;
		this.windCapacity = preset.windCapacity;
		this.windEntropy = preset.windEntropy;
		this.windSmoothing = preset.windSmoothing;
	}

	// Token: 0x0600527F RID: 21119 RVA: 0x00154174 File Offset: 0x00152374
	public void Update()
	{
		if (this.isBrushOn && (this.toolModeInt != 1 || this.erosionTypeInt > 2 || (this.erosionTypeInt == 1 && this.hydraulicTypeInt > 0)))
		{
			this.isBrushOn = false;
		}
	}

	// Token: 0x06005280 RID: 21120 RVA: 0x001541C4 File Offset: 0x001523C4
	public void OnDrawGizmos()
	{
		global::UnityEngine.Terrain terrain = (global::UnityEngine.Terrain)base.GetComponent(typeof(global::UnityEngine.Terrain));
		if (terrain == null)
		{
			return;
		}
		if (this.isBrushOn && !this.isBrushHidden)
		{
			if (this.isBrushPainting)
			{
				global::UnityEngine.Gizmos.color = global::UnityEngine.Color.red;
			}
			else
			{
				global::UnityEngine.Gizmos.color = global::UnityEngine.Color.white;
			}
			float num = this.brushSize / 4f;
			global::UnityEngine.Gizmos.DrawLine(this.brushPosition + new global::UnityEngine.Vector3(-num, 0f, 0f), this.brushPosition + new global::UnityEngine.Vector3(num, 0f, 0f));
			global::UnityEngine.Gizmos.DrawLine(this.brushPosition + new global::UnityEngine.Vector3(0f, -num, 0f), this.brushPosition + new global::UnityEngine.Vector3(0f, num, 0f));
			global::UnityEngine.Gizmos.DrawLine(this.brushPosition + new global::UnityEngine.Vector3(0f, 0f, -num), this.brushPosition + new global::UnityEngine.Vector3(0f, 0f, num));
			global::UnityEngine.Gizmos.DrawWireCube(this.brushPosition, new global::UnityEngine.Vector3(this.brushSize, 0f, this.brushSize));
			global::UnityEngine.Gizmos.DrawWireSphere(this.brushPosition, this.brushSize / 2f);
		}
		global::UnityEngine.TerrainData terrainData = terrain.terrainData;
		global::UnityEngine.Vector3 size = terrainData.size;
		if (this.toolModeInt == 1 && this.erosionTypeInt == 2)
		{
			global::UnityEngine.Gizmos.color = global::UnityEngine.Color.blue;
			global::UnityEngine.Gizmos.DrawWireCube(new global::UnityEngine.Vector3(base.transform.position.x + size.x / 2f, this.tidalSeaLevel, base.transform.position.z + size.z / 2f), new global::UnityEngine.Vector3(size.x, 0f, size.z));
			global::UnityEngine.Gizmos.color = global::UnityEngine.Color.white;
			global::UnityEngine.Gizmos.DrawWireCube(new global::UnityEngine.Vector3(base.transform.position.x + size.x / 2f, this.tidalSeaLevel, base.transform.position.z + size.z / 2f), new global::UnityEngine.Vector3(size.x, this.tidalRangeAmount * 2f, size.z));
		}
		if (this.toolModeInt == 1 && this.erosionTypeInt == 3)
		{
			global::UnityEngine.Gizmos.color = global::UnityEngine.Color.blue;
			global::UnityEngine.Quaternion quaternion = global::UnityEngine.Quaternion.Euler(0f, this.windDirection, 0f);
			global::UnityEngine.Vector3 vector = quaternion * global::UnityEngine.Vector3.forward;
			global::UnityEngine.Vector3 vector2;
			vector2..ctor(base.transform.position.x + size.x / 2f, base.transform.position.y + size.y, base.transform.position.z + size.z / 2f);
			global::UnityEngine.Vector3 vector3 = vector2 + vector * (size.x / 4f);
			global::UnityEngine.Vector3 vector4 = vector2 + vector * (size.x / 6f);
			global::UnityEngine.Gizmos.DrawLine(vector2, vector3);
			global::UnityEngine.Gizmos.DrawLine(vector3, vector4 + new global::UnityEngine.Vector3(0f, size.x / 16f, 0f));
			global::UnityEngine.Gizmos.DrawLine(vector3, vector4 - new global::UnityEngine.Vector3(0f, size.x / 16f, 0f));
		}
	}

	// Token: 0x06005281 RID: 21121 RVA: 0x00154588 File Offset: 0x00152788
	public void paint()
	{
		this.convertIntVarsToEnums();
		this.erodeTerrainWithBrush();
	}

	// Token: 0x06005282 RID: 21122 RVA: 0x00154598 File Offset: 0x00152798
	private void erodeTerrainWithBrush()
	{
		this.erosionMode = global::TerrainToolkit.ErosionMode.Brush;
		global::UnityEngine.Terrain terrain = (global::UnityEngine.Terrain)base.GetComponent(typeof(global::UnityEngine.Terrain));
		if (terrain == null)
		{
			return;
		}
		try
		{
			global::UnityEngine.TerrainData terrainData = terrain.terrainData;
			int heightmapWidth = terrainData.heightmapWidth;
			int heightmapHeight = terrainData.heightmapHeight;
			global::UnityEngine.Vector3 size = terrainData.size;
			int num = (int)global::UnityEngine.Mathf.Floor((float)heightmapWidth / size.x * this.brushSize);
			int num2 = (int)global::UnityEngine.Mathf.Floor((float)heightmapHeight / size.z * this.brushSize);
			global::UnityEngine.Vector3 vector = base.transform.InverseTransformPoint(this.brushPosition);
			int num3 = (int)global::UnityEngine.Mathf.Round(vector.x / size.x * (float)heightmapWidth - (float)(num / 2));
			int num4 = (int)global::UnityEngine.Mathf.Round(vector.z / size.z * (float)heightmapHeight - (float)(num2 / 2));
			if (num3 < 0)
			{
				num += num3;
				num3 = 0;
			}
			if (num4 < 0)
			{
				num2 += num4;
				num4 = 0;
			}
			if (num3 + num > heightmapWidth)
			{
				num = heightmapWidth - num3;
			}
			if (num4 + num2 > heightmapHeight)
			{
				num2 = heightmapHeight - num4;
			}
			float[,] heights = terrainData.GetHeights(num3, num4, num, num2);
			num = heights.GetLength(1);
			num2 = heights.GetLength(0);
			float[,] array = (float[,])heights.Clone();
			global::TerrainToolkit.ErosionProgressDelegate erosionProgressDelegate = new global::TerrainToolkit.ErosionProgressDelegate(this.dummyErosionProgress);
			array = this.fastErosion(array, new global::UnityEngine.Vector2((float)num, (float)num2), 1, erosionProgressDelegate);
			float num5 = (float)num / 2f;
			for (int i = 0; i < num; i++)
			{
				for (int j = 0; j < num2; j++)
				{
					float num6 = heights[j, i];
					float num7 = array[j, i];
					float num8 = global::UnityEngine.Vector2.Distance(new global::UnityEngine.Vector2((float)j, (float)i), new global::UnityEngine.Vector2(num5, num5));
					float num9 = 1f - (num8 - (num5 - num5 * this.brushSoftness)) / (num5 * this.brushSoftness);
					if (num9 < 0f)
					{
						num9 = 0f;
					}
					else if (num9 > 1f)
					{
						num9 = 1f;
					}
					num9 *= this.brushOpacity;
					float num10 = num7 * num9 + num6 * (1f - num9);
					heights[j, i] = num10;
				}
			}
			terrainData.SetHeights(num3, num4, heights);
		}
		catch (global::System.Exception arg)
		{
			global::UnityEngine.Debug.LogError("A brush error occurred: " + arg);
		}
	}

	// Token: 0x06005283 RID: 21123 RVA: 0x00154838 File Offset: 0x00152A38
	public void erodeAllTerrain(global::TerrainToolkit.ErosionProgressDelegate erosionProgressDelegate)
	{
		this.erosionMode = global::TerrainToolkit.ErosionMode.Filter;
		this.convertIntVarsToEnums();
		global::UnityEngine.Terrain terrain = (global::UnityEngine.Terrain)base.GetComponent(typeof(global::UnityEngine.Terrain));
		if (terrain == null)
		{
			return;
		}
		try
		{
			global::UnityEngine.TerrainData terrainData = terrain.terrainData;
			int heightmapWidth = terrainData.heightmapWidth;
			int heightmapHeight = terrainData.heightmapHeight;
			float[,] array = terrainData.GetHeights(0, 0, heightmapWidth, heightmapHeight);
			switch (this.erosionType)
			{
			case global::TerrainToolkit.ErosionType.Thermal:
			{
				int iterations = this.thermalIterations;
				array = this.fastErosion(array, new global::UnityEngine.Vector2((float)heightmapWidth, (float)heightmapHeight), iterations, erosionProgressDelegate);
				break;
			}
			case global::TerrainToolkit.ErosionType.Hydraulic:
			{
				int iterations = this.hydraulicIterations;
				switch (this.hydraulicType)
				{
				case global::TerrainToolkit.HydraulicType.Fast:
					array = this.fastErosion(array, new global::UnityEngine.Vector2((float)heightmapWidth, (float)heightmapHeight), iterations, erosionProgressDelegate);
					break;
				case global::TerrainToolkit.HydraulicType.Full:
					array = this.fullHydraulicErosion(array, new global::UnityEngine.Vector2((float)heightmapWidth, (float)heightmapHeight), iterations, erosionProgressDelegate);
					break;
				case global::TerrainToolkit.HydraulicType.Velocity:
					array = this.velocityHydraulicErosion(array, new global::UnityEngine.Vector2((float)heightmapWidth, (float)heightmapHeight), iterations, erosionProgressDelegate);
					break;
				}
				break;
			}
			case global::TerrainToolkit.ErosionType.Tidal:
			{
				global::UnityEngine.Vector3 size = terrainData.size;
				if (this.tidalSeaLevel >= base.transform.position.y && this.tidalSeaLevel <= base.transform.position.y + size.y)
				{
					int iterations = this.tidalIterations;
					array = this.fastErosion(array, new global::UnityEngine.Vector2((float)heightmapWidth, (float)heightmapHeight), iterations, erosionProgressDelegate);
				}
				else
				{
					global::UnityEngine.Debug.LogError("Sea level does not intersect terrain object. Erosion operation failed.");
				}
				break;
			}
			case global::TerrainToolkit.ErosionType.Wind:
			{
				int iterations = this.windIterations;
				array = this.windErosion(array, new global::UnityEngine.Vector2((float)heightmapWidth, (float)heightmapHeight), iterations, erosionProgressDelegate);
				break;
			}
			default:
				return;
			}
			terrainData.SetHeights(0, 0, array);
		}
		catch (global::System.Exception arg)
		{
			global::UnityEngine.Debug.LogError("An error occurred: " + arg);
		}
	}

	// Token: 0x06005284 RID: 21124 RVA: 0x00154A48 File Offset: 0x00152C48
	private float[,] fastErosion(float[,] heightMap, global::UnityEngine.Vector2 arraySize, int iterations, global::TerrainToolkit.ErosionProgressDelegate erosionProgressDelegate)
	{
		int num = (int)arraySize.y;
		int num2 = (int)arraySize.x;
		float[,] array = new float[num, num2];
		global::UnityEngine.Terrain terrain = (global::UnityEngine.Terrain)base.GetComponent(typeof(global::UnityEngine.Terrain));
		global::UnityEngine.TerrainData terrainData = terrain.terrainData;
		global::UnityEngine.Vector3 size = terrainData.size;
		float num3 = 0f;
		float num4 = 0f;
		float num5 = 0f;
		float num6 = 0f;
		float num7 = 0f;
		float num8 = 0f;
		float num9 = 0f;
		float num10 = 0f;
		float num11 = 0f;
		switch (this.erosionType)
		{
		case global::TerrainToolkit.ErosionType.Thermal:
		{
			num3 = size.x / (float)num * global::UnityEngine.Mathf.Tan(this.thermalMinSlope * 0.017453292f) / size.y;
			if (num3 > 1f)
			{
				num3 = 1f;
			}
			if (this.thermalFalloff == 1f)
			{
				this.thermalFalloff = 0.999f;
			}
			float num12 = this.thermalMinSlope + (90f - this.thermalMinSlope) * this.thermalFalloff;
			num4 = size.x / (float)num * global::UnityEngine.Mathf.Tan(num12 * 0.017453292f) / size.y;
			if (num4 > 1f)
			{
				num4 = 1f;
			}
			break;
		}
		case global::TerrainToolkit.ErosionType.Hydraulic:
		{
			num6 = size.x / (float)num * global::UnityEngine.Mathf.Tan(this.hydraulicMaxSlope * 0.017453292f) / size.y;
			if (this.hydraulicFalloff == 0f)
			{
				this.hydraulicFalloff = 0.001f;
			}
			float num13 = this.hydraulicMaxSlope * (1f - this.hydraulicFalloff);
			num5 = size.x / (float)num * global::UnityEngine.Mathf.Tan(num13 * 0.017453292f) / size.y;
			break;
		}
		case global::TerrainToolkit.ErosionType.Tidal:
			num7 = (this.tidalSeaLevel - base.transform.position.y) / (base.transform.position.y + size.y);
			num8 = (this.tidalSeaLevel - base.transform.position.y - this.tidalRangeAmount) / (base.transform.position.y + size.y);
			num9 = (this.tidalSeaLevel - base.transform.position.y + this.tidalRangeAmount) / (base.transform.position.y + size.y);
			num10 = num9 - num7;
			num11 = size.x / (float)num * global::UnityEngine.Mathf.Tan(this.tidalCliffLimit * 0.017453292f) / size.y;
			break;
		default:
			return heightMap;
		}
		for (int i = 0; i < iterations; i++)
		{
			for (int j = 0; j < num2; j++)
			{
				int num14;
				int num15;
				int num16;
				if (j == 0)
				{
					num14 = 2;
					num15 = 0;
					num16 = 0;
				}
				else if (j == num2 - 1)
				{
					num14 = 2;
					num15 = -1;
					num16 = 1;
				}
				else
				{
					num14 = 3;
					num15 = -1;
					num16 = 1;
				}
				for (int k = 0; k < num; k++)
				{
					int num17;
					int num18;
					int num19;
					if (k == 0)
					{
						num17 = 2;
						num18 = 0;
						num19 = 0;
					}
					else if (k == num - 1)
					{
						num17 = 2;
						num18 = -1;
						num19 = 1;
					}
					else
					{
						num17 = 3;
						num18 = -1;
						num19 = 1;
					}
					float num20 = 1f;
					float num21 = 0f;
					float num22 = 0f;
					float num23 = heightMap[k + num19 + num18, j + num16 + num15];
					float num24 = num23;
					int num25 = 0;
					for (int l = 0; l < num14; l++)
					{
						for (int m = 0; m < num17; m++)
						{
							if ((m != num19 || l != num16) && (this.neighbourhood == global::TerrainToolkit.Neighbourhood.Moore || (this.neighbourhood == global::TerrainToolkit.Neighbourhood.VonNeumann && (m == num19 || l == num16))))
							{
								float num26 = heightMap[k + m + num18, j + l + num15];
								num24 += num26;
								float num27 = num23 - num26;
								if (num27 > 0f)
								{
									num22 += num27;
									if (num27 < num20)
									{
										num20 = num27;
									}
									if (num27 > num21)
									{
										num21 = num27;
									}
								}
								num25++;
							}
						}
					}
					float num28 = num22 / (float)num25;
					bool flag = false;
					switch (this.erosionType)
					{
					case global::TerrainToolkit.ErosionType.Thermal:
						if (num28 >= num3)
						{
							flag = true;
						}
						break;
					case global::TerrainToolkit.ErosionType.Hydraulic:
						if (num28 > 0f && num28 <= num6)
						{
							flag = true;
						}
						break;
					case global::TerrainToolkit.ErosionType.Tidal:
						if (num28 > 0f && num28 <= num11 && num23 < num9 && num23 > num8)
						{
							flag = true;
						}
						break;
					default:
						return heightMap;
					}
					if (flag)
					{
						if (this.erosionType == global::TerrainToolkit.ErosionType.Tidal)
						{
							float num29 = num24 / (float)(num25 + 1);
							float num30 = global::UnityEngine.Mathf.Abs(num7 - num23);
							float num31 = num30 / num10;
							float num32 = num23 * num31 + num29 * (1f - num31);
							float num33 = global::UnityEngine.Mathf.Pow(num30, 3f);
							heightMap[k + num19 + num18, j + num16 + num15] = num7 * num33 + num32 * (1f - num33);
						}
						else
						{
							float num31;
							if (this.erosionType == global::TerrainToolkit.ErosionType.Thermal)
							{
								if (num28 > num4)
								{
									num31 = 1f;
								}
								else
								{
									float num34 = num4 - num3;
									num31 = (num28 - num3) / num34;
								}
							}
							else if (num28 < num5)
							{
								num31 = 1f;
							}
							else
							{
								float num34 = num6 - num5;
								num31 = 1f - (num28 - num5) / num34;
							}
							float num35 = num20 / 2f * num31;
							float num36 = heightMap[k + num19 + num18, j + num16 + num15];
							if (this.erosionMode == global::TerrainToolkit.ErosionMode.Filter || (this.erosionMode == global::TerrainToolkit.ErosionMode.Brush && this.useDifferenceMaps))
							{
								float num37 = array[k + num19 + num18, j + num16 + num15];
								float num38 = num37 - num35;
								array[k + num19 + num18, j + num16 + num15] = num38;
							}
							else
							{
								float num39 = num36 - num35;
								if (num39 < 0f)
								{
									num39 = 0f;
								}
								heightMap[k + num19 + num18, j + num16 + num15] = num39;
							}
							for (int l = 0; l < num14; l++)
							{
								for (int m = 0; m < num17; m++)
								{
									if ((m != num19 || l != num16) && (this.neighbourhood == global::TerrainToolkit.Neighbourhood.Moore || (this.neighbourhood == global::TerrainToolkit.Neighbourhood.VonNeumann && (m == num19 || l == num16))))
									{
										float num40 = heightMap[k + m + num18, j + l + num15];
										float num27 = num36 - num40;
										if (num27 > 0f)
										{
											float num41 = num35 * (num27 / num22);
											if (this.erosionMode == global::TerrainToolkit.ErosionMode.Filter || (this.erosionMode == global::TerrainToolkit.ErosionMode.Brush && this.useDifferenceMaps))
											{
												float num42 = array[k + m + num18, j + l + num15];
												float num43 = num42 + num41;
												array[k + m + num18, j + l + num15] = num43;
											}
											else
											{
												num40 += num41;
												if (num40 < 0f)
												{
													num40 = 0f;
												}
												heightMap[k + m + num18, j + l + num15] = num40;
											}
										}
									}
								}
							}
						}
					}
				}
			}
			if ((this.erosionMode == global::TerrainToolkit.ErosionMode.Filter || (this.erosionMode == global::TerrainToolkit.ErosionMode.Brush && this.useDifferenceMaps)) && this.erosionType != global::TerrainToolkit.ErosionType.Tidal)
			{
				for (int j = 0; j < num2; j++)
				{
					for (int k = 0; k < num; k++)
					{
						float num44 = heightMap[k, j] + array[k, j];
						if (num44 > 1f)
						{
							num44 = 1f;
						}
						else if (num44 < 0f)
						{
							num44 = 0f;
						}
						heightMap[k, j] = num44;
						array[k, j] = 0f;
					}
				}
			}
			if (this.erosionMode == global::TerrainToolkit.ErosionMode.Filter)
			{
				string titleString = string.Empty;
				string displayString = string.Empty;
				switch (this.erosionType)
				{
				case global::TerrainToolkit.ErosionType.Thermal:
					titleString = "Applying Thermal Erosion";
					displayString = "Applying thermal erosion.";
					break;
				case global::TerrainToolkit.ErosionType.Hydraulic:
					titleString = "Applying Hydraulic Erosion";
					displayString = "Applying hydraulic erosion.";
					break;
				case global::TerrainToolkit.ErosionType.Tidal:
					titleString = "Applying Tidal Erosion";
					displayString = "Applying tidal erosion.";
					break;
				default:
					return heightMap;
				}
				float percentComplete = (float)i / (float)iterations;
				erosionProgressDelegate(titleString, displayString, i, iterations, percentComplete);
			}
		}
		return heightMap;
	}

	// Token: 0x06005285 RID: 21125 RVA: 0x00155340 File Offset: 0x00153540
	private float[,] velocityHydraulicErosion(float[,] heightMap, global::UnityEngine.Vector2 arraySize, int iterations, global::TerrainToolkit.ErosionProgressDelegate erosionProgressDelegate)
	{
		int num = (int)arraySize.x;
		int num2 = (int)arraySize.y;
		float[,] array = new float[num, num2];
		float[,] array2 = new float[num, num2];
		float[,] array3 = new float[num, num2];
		float[,] array4 = new float[num, num2];
		float[,] array5 = new float[num, num2];
		float[,] array6 = new float[num, num2];
		float[,] array7 = new float[num, num2];
		float[,] array8 = new float[num, num2];
		for (int i = 0; i < num2; i++)
		{
			for (int j = 0; j < num; j++)
			{
				array3[j, i] = 0f;
				array4[j, i] = 0f;
				array5[j, i] = 0f;
				array6[j, i] = 0f;
				array7[j, i] = 0f;
				array8[j, i] = 0f;
			}
		}
		for (int i = 0; i < num2; i++)
		{
			for (int j = 0; j < num; j++)
			{
				float num3 = heightMap[j, i];
				array[j, i] = num3;
			}
		}
		for (int i = 0; i < num2; i++)
		{
			int num4;
			int num5;
			int num6;
			if (i == 0)
			{
				num4 = 2;
				num5 = 0;
				num6 = 0;
			}
			else if (i == num2 - 1)
			{
				num4 = 2;
				num5 = -1;
				num6 = 1;
			}
			else
			{
				num4 = 3;
				num5 = -1;
				num6 = 1;
			}
			for (int j = 0; j < num; j++)
			{
				int num7;
				int num8;
				int num9;
				if (j == 0)
				{
					num7 = 2;
					num8 = 0;
					num9 = 0;
				}
				else if (j == num - 1)
				{
					num7 = 2;
					num8 = -1;
					num9 = 1;
				}
				else
				{
					num7 = 3;
					num8 = -1;
					num9 = 1;
				}
				float num10 = 0f;
				float num11 = heightMap[j + num9 + num8, i + num6 + num5];
				int num12 = 0;
				for (int k = 0; k < num4; k++)
				{
					for (int l = 0; l < num7; l++)
					{
						if ((l != num9 || k != num6) && (this.neighbourhood == global::TerrainToolkit.Neighbourhood.Moore || (this.neighbourhood == global::TerrainToolkit.Neighbourhood.VonNeumann && (l == num9 || k == num6))))
						{
							float num13 = heightMap[j + l + num8, i + k + num5];
							float num14 = global::UnityEngine.Mathf.Abs(num11 - num13);
							num10 += num14;
							num12++;
						}
					}
				}
				float num15 = num10 / (float)num12;
				array2[j + num9 + num8, i + num6 + num5] = num15;
			}
		}
		for (int m = 0; m < iterations; m++)
		{
			for (int i = 0; i < num2; i++)
			{
				for (int j = 0; j < num; j++)
				{
					float num16 = array3[j, i] + array[j, i] * this.hydraulicVelocityRainfall;
					if (num16 > 1f)
					{
						num16 = 1f;
					}
					array3[j, i] = num16;
				}
			}
			for (int i = 0; i < num2; i++)
			{
				for (int j = 0; j < num; j++)
				{
					float num17 = array7[j, i];
					float num18 = array3[j, i] * this.hydraulicVelocitySedimentSaturation;
					if (num17 < num18)
					{
						float num19 = array3[j, i] * array5[j, i] * this.hydraulicVelocitySedimentSolubility;
						if (num17 + num19 > num18)
						{
							num19 = num18 - num17;
						}
						float num11 = heightMap[j, i];
						if (num19 > num11)
						{
							num19 = num11;
						}
						array7[j, i] = num17 + num19;
						heightMap[j, i] = num11 - num19;
					}
				}
			}
			for (int i = 0; i < num2; i++)
			{
				int num4;
				int num5;
				int num6;
				if (i == 0)
				{
					num4 = 2;
					num5 = 0;
					num6 = 0;
				}
				else if (i == num2 - 1)
				{
					num4 = 2;
					num5 = -1;
					num6 = 1;
				}
				else
				{
					num4 = 3;
					num5 = -1;
					num6 = 1;
				}
				for (int j = 0; j < num; j++)
				{
					int num7;
					int num8;
					int num9;
					if (j == 0)
					{
						num7 = 2;
						num8 = 0;
						num9 = 0;
					}
					else if (j == num - 1)
					{
						num7 = 2;
						num8 = -1;
						num9 = 1;
					}
					else
					{
						num7 = 3;
						num8 = -1;
						num9 = 1;
					}
					float num10 = 0f;
					float num11 = heightMap[j, i];
					float num20 = num11;
					float num21 = array3[j, i];
					int num12 = 0;
					for (int k = 0; k < num4; k++)
					{
						for (int l = 0; l < num7; l++)
						{
							if ((l != num9 || k != num6) && (this.neighbourhood == global::TerrainToolkit.Neighbourhood.Moore || (this.neighbourhood == global::TerrainToolkit.Neighbourhood.VonNeumann && (l == num9 || k == num6))))
							{
								float num13 = heightMap[j + l + num8, i + k + num5];
								float num22 = array3[j + l + num8, i + k + num5];
								float num14 = num11 + num21 - (num13 + num22);
								if (num14 > 0f)
								{
									num10 += num14;
									num20 += num11 + num21;
									num12++;
								}
							}
						}
					}
					float num23 = array5[j, i];
					float num24 = array2[j, i];
					float num25 = array7[j, i];
					float num26 = num23 + this.hydraulicVelocity * num24;
					float num27 = num20 / (float)(num12 + 1);
					float num28 = num11 + num21 - num27;
					float num29 = global::UnityEngine.Mathf.Min(num21, num28 * (1f + num23));
					float num30 = array4[j, i];
					float num31 = num30 - num29;
					array4[j, i] = num31;
					float num32 = num26 * (num29 / num21);
					float num33 = num25 * (num29 / num21);
					for (int k = 0; k < num4; k++)
					{
						for (int l = 0; l < num7; l++)
						{
							if ((l != num9 || k != num6) && (this.neighbourhood == global::TerrainToolkit.Neighbourhood.Moore || (this.neighbourhood == global::TerrainToolkit.Neighbourhood.VonNeumann && (l == num9 || k == num6))))
							{
								float num13 = heightMap[j + l + num8, i + k + num5];
								float num22 = array3[j + l + num8, i + k + num5];
								float num14 = num11 + num21 - (num13 + num22);
								if (num14 > 0f)
								{
									float num34 = array4[j + l + num8, i + k + num5];
									float num35 = num29 * (num14 / num10);
									float num36 = num34 + num35;
									array4[j + l + num8, i + k + num5] = num36;
									float num37 = array6[j + l + num8, i + k + num5];
									float num38 = num32 * this.hydraulicMomentum * (num14 / num10);
									float num39 = num37 + num38;
									array6[j + l + num8, i + k + num5] = num39;
									float num40 = array8[j + l + num8, i + k + num5];
									float num41 = num33 * this.hydraulicMomentum * (num14 / num10);
									float num42 = num40 + num41;
									array8[j + l + num8, i + k + num5] = num42;
								}
							}
						}
					}
					float num43 = array6[j, i];
					array6[j, i] = num43 - num32;
				}
			}
			for (int i = 0; i < num2; i++)
			{
				for (int j = 0; j < num; j++)
				{
					float num44 = array5[j, i] + array6[j, i];
					num44 *= 1f - this.hydraulicEntropy;
					if (num44 > 1f)
					{
						num44 = 1f;
					}
					else if (num44 < 0f)
					{
						num44 = 0f;
					}
					array5[j, i] = num44;
					array6[j, i] = 0f;
				}
			}
			for (int i = 0; i < num2; i++)
			{
				for (int j = 0; j < num; j++)
				{
					float num45 = array3[j, i] + array4[j, i];
					float num46 = num45 * this.hydraulicVelocityEvaporation;
					num45 -= num46;
					if (num45 > 1f)
					{
						num45 = 1f;
					}
					else if (num45 < 0f)
					{
						num45 = 0f;
					}
					array3[j, i] = num45;
					array4[j, i] = 0f;
				}
			}
			for (int i = 0; i < num2; i++)
			{
				for (int j = 0; j < num; j++)
				{
					float num47 = array7[j, i] + array8[j, i];
					if (num47 > 1f)
					{
						num47 = 1f;
					}
					else if (num47 < 0f)
					{
						num47 = 0f;
					}
					array7[j, i] = num47;
					array8[j, i] = 0f;
				}
			}
			for (int i = 0; i < num2; i++)
			{
				for (int j = 0; j < num; j++)
				{
					float num18 = array3[j, i] * this.hydraulicVelocitySedimentSaturation;
					float num47 = array7[j, i];
					if (num47 > num18)
					{
						float num48 = num47 - num18;
						array7[j, i] = num18;
						float num49 = heightMap[j, i];
						heightMap[j, i] = num49 + num48;
					}
				}
			}
			for (int i = 0; i < num2; i++)
			{
				for (int j = 0; j < num; j++)
				{
					float num44 = array3[j, i];
					float num49 = heightMap[j, i];
					float num50 = 1f - global::UnityEngine.Mathf.Abs(0.5f - num49) * 2f;
					float num51 = this.hydraulicDowncutting * num44 * num50;
					num49 -= num51;
					heightMap[j, i] = num49;
				}
			}
			float percentComplete = (float)m / (float)iterations;
			erosionProgressDelegate("Applying Hydraulic Erosion", "Applying hydraulic erosion.", m, iterations, percentComplete);
		}
		return heightMap;
	}

	// Token: 0x06005286 RID: 21126 RVA: 0x00155DDC File Offset: 0x00153FDC
	private float[,] fullHydraulicErosion(float[,] heightMap, global::UnityEngine.Vector2 arraySize, int iterations, global::TerrainToolkit.ErosionProgressDelegate erosionProgressDelegate)
	{
		int num = (int)arraySize.x;
		int num2 = (int)arraySize.y;
		float[,] array = new float[num, num2];
		float[,] array2 = new float[num, num2];
		float[,] array3 = new float[num, num2];
		float[,] array4 = new float[num, num2];
		for (int i = 0; i < num2; i++)
		{
			for (int j = 0; j < num; j++)
			{
				array[j, i] = 0f;
				array2[j, i] = 0f;
				array3[j, i] = 0f;
				array4[j, i] = 0f;
			}
		}
		for (int k = 0; k < iterations; k++)
		{
			for (int i = 0; i < num2; i++)
			{
				for (int j = 0; j < num; j++)
				{
					float num3 = array[j, i] + this.hydraulicRainfall;
					if (num3 > 1f)
					{
						num3 = 1f;
					}
					array[j, i] = num3;
				}
			}
			for (int i = 0; i < num2; i++)
			{
				for (int j = 0; j < num; j++)
				{
					float num4 = array3[j, i];
					float num5 = array[j, i] * this.hydraulicSedimentSaturation;
					if (num4 < num5)
					{
						float num6 = array[j, i] * this.hydraulicSedimentSolubility;
						if (num4 + num6 > num5)
						{
							num6 = num5 - num4;
						}
						float num7 = heightMap[j, i];
						if (num6 > num7)
						{
							num6 = num7;
						}
						array3[j, i] = num4 + num6;
						heightMap[j, i] = num7 - num6;
					}
				}
			}
			for (int i = 0; i < num2; i++)
			{
				int num8;
				int num9;
				int num10;
				if (i == 0)
				{
					num8 = 2;
					num9 = 0;
					num10 = 0;
				}
				else if (i == num2 - 1)
				{
					num8 = 2;
					num9 = -1;
					num10 = 1;
				}
				else
				{
					num8 = 3;
					num9 = -1;
					num10 = 1;
				}
				for (int j = 0; j < num; j++)
				{
					int num11;
					int num12;
					int num13;
					if (j == 0)
					{
						num11 = 2;
						num12 = 0;
						num13 = 0;
					}
					else if (j == num - 1)
					{
						num11 = 2;
						num12 = -1;
						num13 = 1;
					}
					else
					{
						num11 = 3;
						num12 = -1;
						num13 = 1;
					}
					float num14 = 0f;
					float num15 = 0f;
					float num7 = heightMap[j + num13 + num12, i + num10 + num9];
					float num16 = array[j + num13 + num12, i + num10 + num9];
					float num17 = num7;
					int num18 = 0;
					for (int l = 0; l < num8; l++)
					{
						for (int m = 0; m < num11; m++)
						{
							if ((m != num13 || l != num10) && (this.neighbourhood == global::TerrainToolkit.Neighbourhood.Moore || (this.neighbourhood == global::TerrainToolkit.Neighbourhood.VonNeumann && (m == num13 || l == num10))))
							{
								float num19 = heightMap[j + m + num12, i + l + num9];
								float num20 = array[j + m + num12, i + l + num9];
								float num21 = num7 + num16 - (num19 + num20);
								if (num21 > 0f)
								{
									num14 += num21;
									num17 += num19 + num20;
									num18++;
									if (num21 > num15)
									{
									}
								}
							}
						}
					}
					float num22 = num17 / (float)(num18 + 1);
					float num23 = num7 + num16 - num22;
					float num24 = global::UnityEngine.Mathf.Min(num16, num23);
					float num25 = array2[j + num13 + num12, i + num10 + num9];
					float num26 = num25 - num24;
					array2[j + num13 + num12, i + num10 + num9] = num26;
					float num27 = array3[j + num13 + num12, i + num10 + num9];
					float num28 = num27 * (num24 / num16);
					float num29 = array4[j + num13 + num12, i + num10 + num9];
					float num30 = num29 - num28;
					array4[j + num13 + num12, i + num10 + num9] = num30;
					for (int l = 0; l < num8; l++)
					{
						for (int m = 0; m < num11; m++)
						{
							if ((m != num13 || l != num10) && (this.neighbourhood == global::TerrainToolkit.Neighbourhood.Moore || (this.neighbourhood == global::TerrainToolkit.Neighbourhood.VonNeumann && (m == num13 || l == num10))))
							{
								float num19 = heightMap[j + m + num12, i + l + num9];
								float num20 = array[j + m + num12, i + l + num9];
								float num21 = num7 + num16 - (num19 + num20);
								if (num21 > 0f)
								{
									float num31 = array2[j + m + num12, i + l + num9];
									float num32 = num24 * (num21 / num14);
									float num33 = num31 + num32;
									array2[j + m + num12, i + l + num9] = num33;
									float num34 = array4[j + m + num12, i + l + num9];
									float num35 = num28 * (num21 / num14);
									float num36 = num34 + num35;
									array4[j + m + num12, i + l + num9] = num36;
								}
							}
						}
					}
				}
			}
			for (int i = 0; i < num2; i++)
			{
				for (int j = 0; j < num; j++)
				{
					float num37 = array[j, i] + array2[j, i];
					float num38 = num37 * this.hydraulicEvaporation;
					num37 -= num38;
					if (num37 < 0f)
					{
						num37 = 0f;
					}
					array[j, i] = num37;
					array2[j, i] = 0f;
				}
			}
			for (int i = 0; i < num2; i++)
			{
				for (int j = 0; j < num; j++)
				{
					float num39 = array3[j, i] + array4[j, i];
					if (num39 > 1f)
					{
						num39 = 1f;
					}
					else if (num39 < 0f)
					{
						num39 = 0f;
					}
					array3[j, i] = num39;
					array4[j, i] = 0f;
				}
			}
			for (int i = 0; i < num2; i++)
			{
				for (int j = 0; j < num; j++)
				{
					float num5 = array[j, i] * this.hydraulicSedimentSaturation;
					float num39 = array3[j, i];
					if (num39 > num5)
					{
						float num40 = num39 - num5;
						array3[j, i] = num5;
						float num41 = heightMap[j, i];
						heightMap[j, i] = num41 + num40;
					}
				}
			}
			float percentComplete = (float)k / (float)iterations;
			erosionProgressDelegate("Applying Hydraulic Erosion", "Applying hydraulic erosion.", k, iterations, percentComplete);
		}
		return heightMap;
	}

	// Token: 0x06005287 RID: 21127 RVA: 0x001564FC File Offset: 0x001546FC
	private float[,] windErosion(float[,] heightMap, global::UnityEngine.Vector2 arraySize, int iterations, global::TerrainToolkit.ErosionProgressDelegate erosionProgressDelegate)
	{
		global::UnityEngine.Terrain terrain = (global::UnityEngine.Terrain)base.GetComponent(typeof(global::UnityEngine.Terrain));
		global::UnityEngine.TerrainData terrainData = terrain.terrainData;
		global::UnityEngine.Quaternion quaternion = global::UnityEngine.Quaternion.Euler(0f, this.windDirection + 180f, 0f);
		global::UnityEngine.Vector3 vector = quaternion * global::UnityEngine.Vector3.forward;
		int num = (int)arraySize.x;
		int num2 = (int)arraySize.y;
		float[,] array = new float[num, num2];
		float[,] array2 = new float[num, num2];
		float[,] array3 = new float[num, num2];
		float[,] array4 = new float[num, num2];
		float[,] array5 = new float[num, num2];
		float[,] array6 = new float[num, num2];
		float[,] array7 = new float[num, num2];
		for (int i = 0; i < num2; i++)
		{
			for (int j = 0; j < num; j++)
			{
				array[j, i] = 0f;
				array2[j, i] = 0f;
				array3[j, i] = 0f;
				array4[j, i] = 0f;
				array5[j, i] = 0f;
				array6[j, i] = 0f;
				array7[j, i] = 0f;
			}
		}
		for (int k = 0; k < iterations; k++)
		{
			for (int i = 0; i < num2; i++)
			{
				for (int j = 0; j < num; j++)
				{
					float num3 = array3[j, i];
					float num4 = heightMap[j, i];
					float num5 = array5[j, i];
					float num6 = num5 * this.windGravity;
					array5[j, i] = num5 - num6;
					heightMap[j, i] = num4 + num6;
				}
			}
			for (int i = 0; i < num2; i++)
			{
				for (int j = 0; j < num; j++)
				{
					float num7 = heightMap[j, i];
					global::UnityEngine.Vector3 interpolatedNormal = terrainData.GetInterpolatedNormal((float)j / (float)num, (float)i / (float)num2);
					float num8 = (global::UnityEngine.Vector3.Angle(interpolatedNormal, vector) - 90f) / 90f;
					if (num8 < 0f)
					{
						num8 = 0f;
					}
					array[j, i] = num8 * num7;
					float num9 = 1f - global::UnityEngine.Mathf.Abs(global::UnityEngine.Vector3.Angle(interpolatedNormal, vector) - 90f) / 90f;
					array2[j, i] = num9 * num7;
					float num10 = num9 * num7 * this.windForce;
					float num11 = array3[j, i];
					float num12 = num11 + num10;
					array3[j, i] = num12;
					float num13 = array5[j, i];
					float num14 = this.windLift * num12;
					if (num13 + num14 > this.windCapacity)
					{
						num14 = this.windCapacity - num13;
					}
					array5[j, i] = num13 + num14;
					heightMap[j, i] = num7 - num14;
				}
			}
			for (int i = 0; i < num2; i++)
			{
				int num15;
				int num16;
				int num17;
				if (i == 0)
				{
					num15 = 2;
					num16 = 0;
					num17 = 0;
				}
				else if (i == num2 - 1)
				{
					num15 = 2;
					num16 = -1;
					num17 = 1;
				}
				else
				{
					num15 = 3;
					num16 = -1;
					num17 = 1;
				}
				for (int j = 0; j < num; j++)
				{
					int num18;
					int num19;
					int num20;
					if (j == 0)
					{
						num18 = 2;
						num19 = 0;
						num20 = 0;
					}
					else if (j == num - 1)
					{
						num18 = 2;
						num19 = -1;
						num20 = 1;
					}
					else
					{
						num18 = 3;
						num19 = -1;
						num20 = 1;
					}
					float num21 = array2[j, i];
					float num22 = array[j, i];
					float num13 = array5[j, i];
					for (int l = 0; l < num15; l++)
					{
						for (int m = 0; m < num18; m++)
						{
							if ((m != num20 || l != num17) && (this.neighbourhood == global::TerrainToolkit.Neighbourhood.Moore || (this.neighbourhood == global::TerrainToolkit.Neighbourhood.VonNeumann && (m == num20 || l == num17))))
							{
								global::UnityEngine.Vector3 vector2;
								vector2..ctor((float)(m + num19), 0f, (float)(-1 * (l + num16)));
								float num23 = (90f - global::UnityEngine.Vector3.Angle(vector2, vector)) / 90f;
								if (num23 < 0f)
								{
									num23 = 0f;
								}
								float num24 = array4[j + m + num19, i + l + num16];
								float num25 = num23 * (num21 - num22) * 0.1f;
								if (num25 < 0f)
								{
									num25 = 0f;
								}
								float num26 = num24 + num25;
								array4[j + m + num19, i + l + num16] = num26;
								float num27 = array4[j, i];
								float num28 = num27 - num25;
								array4[j, i] = num28;
								float num29 = array6[j + m + num19, i + l + num16];
								float num30 = num13 * num25;
								float num31 = num29 + num30;
								array6[j + m + num19, i + l + num16] = num31;
								float num32 = array6[j, i];
								float num33 = num32 - num30;
								array6[j, i] = num33;
							}
						}
					}
				}
			}
			for (int i = 0; i < num2; i++)
			{
				for (int j = 0; j < num; j++)
				{
					float num34 = array5[j, i] + array6[j, i];
					if (num34 > 1f)
					{
						num34 = 1f;
					}
					else if (num34 < 0f)
					{
						num34 = 0f;
					}
					array5[j, i] = num34;
					array6[j, i] = 0f;
				}
			}
			for (int i = 0; i < num2; i++)
			{
				for (int j = 0; j < num; j++)
				{
					float num3 = array3[j, i] + array4[j, i];
					num3 *= 1f - this.windEntropy;
					if (num3 > 1f)
					{
						num3 = 1f;
					}
					else if (num3 < 0f)
					{
						num3 = 0f;
					}
					array3[j, i] = num3;
					array4[j, i] = 0f;
				}
			}
			this.smoothIterations = 1;
			this.smoothBlend = 0.25f;
			float[,] array8 = (float[,])heightMap.Clone();
			global::TerrainToolkit.GeneratorProgressDelegate generatorProgressDelegate = new global::TerrainToolkit.GeneratorProgressDelegate(this.dummyGeneratorProgress);
			array8 = this.smooth(array8, arraySize, generatorProgressDelegate);
			for (int i = 0; i < num2; i++)
			{
				for (int j = 0; j < num; j++)
				{
					float num35 = heightMap[j, i];
					float num36 = array8[j, i];
					float num37 = array[j, i] * this.windSmoothing;
					float num38 = num36 * num37 + num35 * (1f - num37);
					heightMap[j, i] = num38;
				}
			}
			float percentComplete = (float)k / (float)iterations;
			erosionProgressDelegate("Applying Wind Erosion", "Applying wind erosion.", k, iterations, percentComplete);
		}
		return heightMap;
	}

	// Token: 0x06005288 RID: 21128 RVA: 0x00156C6C File Offset: 0x00154E6C
	public void textureTerrain(global::TerrainToolkit.TextureProgressDelegate textureProgressDelegate)
	{
		global::UnityEngine.Terrain terrain = (global::UnityEngine.Terrain)base.GetComponent(typeof(global::UnityEngine.Terrain));
		if (terrain == null)
		{
			return;
		}
		global::UnityEngine.TerrainData terrainData = terrain.terrainData;
		this.splatPrototypes = terrainData.splatPrototypes;
		int num = this.splatPrototypes.Length;
		if (num < 2)
		{
			global::UnityEngine.Debug.LogError("Error: You must assign at least 2 textures.");
			return;
		}
		textureProgressDelegate("Procedural Terrain Texture", "Generating height and slope maps. Please wait.", 0.1f);
		int num2 = terrainData.heightmapWidth - 1;
		int num3 = terrainData.heightmapHeight - 1;
		float[,] array = new float[num2, num3];
		float[,] array2 = new float[num2, num3];
		terrainData.alphamapResolution = num2;
		float[,,] alphamaps = terrainData.GetAlphamaps(0, 0, num2, num2);
		global::UnityEngine.Vector3 size = terrainData.size;
		float num4 = size.x / (float)num2 * global::UnityEngine.Mathf.Tan(this.slopeBlendMinAngle * 0.017453292f) / size.y;
		float num5 = size.x / (float)num2 * global::UnityEngine.Mathf.Tan(this.slopeBlendMaxAngle * 0.017453292f) / size.y;
		try
		{
			float num6 = 0f;
			float[,] heights = terrainData.GetHeights(0, 0, num2, num3);
			for (int i = 0; i < num3; i++)
			{
				int num7;
				int num8;
				int num9;
				if (i == 0)
				{
					num7 = 2;
					num8 = 0;
					num9 = 0;
				}
				else if (i == num3 - 1)
				{
					num7 = 2;
					num8 = -1;
					num9 = 1;
				}
				else
				{
					num7 = 3;
					num8 = -1;
					num9 = 1;
				}
				for (int j = 0; j < num2; j++)
				{
					int num10;
					int num11;
					int num12;
					if (j == 0)
					{
						num10 = 2;
						num11 = 0;
						num12 = 0;
					}
					else if (j == num2 - 1)
					{
						num10 = 2;
						num11 = -1;
						num12 = 1;
					}
					else
					{
						num10 = 3;
						num11 = -1;
						num12 = 1;
					}
					float num13 = heights[j + num12 + num11, i + num9 + num8];
					if (num13 > num6)
					{
						num6 = num13;
					}
					array[j, i] = num13;
					float num14 = 0f;
					float num15 = (float)(num10 * num7 - 1);
					for (int k = 0; k < num7; k++)
					{
						for (int l = 0; l < num10; l++)
						{
							if (l != num12 || k != num9)
							{
								float num16 = global::UnityEngine.Mathf.Abs(num13 - heights[j + l + num11, i + k + num8]);
								num14 += num16;
							}
						}
					}
					float num17 = num14 / num15;
					array2[j, i] = num17;
				}
			}
			for (int m = 0; m < num3; m++)
			{
				for (int n = 0; n < num2; n++)
				{
					float num18 = array2[n, m];
					if (num18 < num4)
					{
						num18 = 0f;
					}
					else if (num18 < num5)
					{
						num18 = (num18 - num4) / (num5 - num4);
					}
					else if (num18 > num5)
					{
						num18 = 1f;
					}
					array2[n, m] = num18;
					alphamaps[n, m, 0] = num18;
				}
			}
			for (int num19 = 1; num19 < num; num19++)
			{
				for (int m = 0; m < num3; m++)
				{
					for (int n = 0; n < num2; n++)
					{
						float num20 = 0f;
						float num21 = 0f;
						float num22 = 1f;
						float num23 = 1f;
						float num24 = 0f;
						if (num19 > 1)
						{
							num20 = this.heightBlendPoints[num19 * 2 - 4];
							num21 = this.heightBlendPoints[num19 * 2 - 3];
						}
						if (num19 < num - 1)
						{
							num22 = this.heightBlendPoints[num19 * 2 - 2];
							num23 = this.heightBlendPoints[num19 * 2 - 1];
						}
						float num25 = array[n, m];
						if (num25 >= num21 && num25 <= num22)
						{
							num24 = 1f;
						}
						else if (num25 >= num20 && num25 < num21)
						{
							num24 = (num25 - num20) / (num21 - num20);
						}
						else if (num25 > num22 && num25 <= num23)
						{
							num24 = 1f - (num25 - num22) / (num23 - num22);
						}
						float num26 = array2[n, m];
						num24 -= num26;
						if (num24 < 0f)
						{
							num24 = 0f;
						}
						alphamaps[n, m, num19] = num24;
					}
				}
			}
			textureProgressDelegate("Procedural Terrain Texture", "Generating splat map. Please wait.", 0.9f);
			terrainData.SetAlphamaps(0, 0, alphamaps);
		}
		catch (global::System.Exception arg)
		{
			global::UnityEngine.Debug.LogError("An error occurred: " + arg);
		}
	}

	// Token: 0x06005289 RID: 21129 RVA: 0x0015714C File Offset: 0x0015534C
	public void addSplatPrototype(global::UnityEngine.Texture2D tex, int index)
	{
		global::UnityEngine.SplatPrototype[] array = new global::UnityEngine.SplatPrototype[index + 1];
		for (int i = 0; i <= index; i++)
		{
			array[i] = new global::UnityEngine.SplatPrototype();
			if (i == index)
			{
				array[i].texture = tex;
				array[i].tileSize = new global::UnityEngine.Vector2(15f, 15f);
			}
			else
			{
				array[i].texture = this.splatPrototypes[i].texture;
				array[i].tileSize = this.splatPrototypes[i].tileSize;
			}
		}
		this.splatPrototypes = array;
		if (index + 1 > 2)
		{
			this.addBlendPoints();
		}
	}

	// Token: 0x0600528A RID: 21130 RVA: 0x001571E8 File Offset: 0x001553E8
	public void deleteSplatPrototype(global::UnityEngine.Texture2D tex, int index)
	{
		int num = this.splatPrototypes.Length;
		global::UnityEngine.SplatPrototype[] array = new global::UnityEngine.SplatPrototype[num - 1];
		int num2 = 0;
		for (int i = 0; i < num; i++)
		{
			if (i != index)
			{
				array[num2] = new global::UnityEngine.SplatPrototype();
				array[num2].texture = this.splatPrototypes[i].texture;
				array[num2].tileSize = this.splatPrototypes[i].tileSize;
				num2++;
			}
		}
		this.splatPrototypes = array;
		if (num - 1 > 1)
		{
			this.deleteBlendPoints();
		}
	}

	// Token: 0x0600528B RID: 21131 RVA: 0x00157270 File Offset: 0x00155470
	public void deleteAllSplatPrototypes()
	{
		global::UnityEngine.SplatPrototype[] array = new global::UnityEngine.SplatPrototype[0];
		this.splatPrototypes = array;
	}

	// Token: 0x0600528C RID: 21132 RVA: 0x0015728C File Offset: 0x0015548C
	public void addBlendPoints()
	{
		float num = 0f;
		if (this.heightBlendPoints.Count > 0)
		{
			num = this.heightBlendPoints[this.heightBlendPoints.Count - 1];
		}
		float item = num + (1f - num) * 0.33f;
		this.heightBlendPoints.Add(item);
		item = num + (1f - num) * 0.66f;
		this.heightBlendPoints.Add(item);
	}

	// Token: 0x0600528D RID: 21133 RVA: 0x00157304 File Offset: 0x00155504
	public void deleteBlendPoints()
	{
		if (this.heightBlendPoints.Count > 0)
		{
			this.heightBlendPoints.RemoveAt(this.heightBlendPoints.Count - 1);
		}
		if (this.heightBlendPoints.Count > 0)
		{
			this.heightBlendPoints.RemoveAt(this.heightBlendPoints.Count - 1);
		}
	}

	// Token: 0x0600528E RID: 21134 RVA: 0x00157364 File Offset: 0x00155564
	public void deleteAllBlendPoints()
	{
		this.heightBlendPoints = new global::System.Collections.Generic.List<float>();
	}

	// Token: 0x0600528F RID: 21135 RVA: 0x00157374 File Offset: 0x00155574
	public void generateTerrain(global::TerrainToolkit.GeneratorProgressDelegate generatorProgressDelegate)
	{
		this.convertIntVarsToEnums();
		global::UnityEngine.Terrain terrain = (global::UnityEngine.Terrain)base.GetComponent(typeof(global::UnityEngine.Terrain));
		if (terrain == null)
		{
			return;
		}
		global::UnityEngine.TerrainData terrainData = terrain.terrainData;
		int heightmapWidth = terrainData.heightmapWidth;
		int heightmapHeight = terrainData.heightmapHeight;
		float[,] heights = terrainData.GetHeights(0, 0, heightmapWidth, heightmapHeight);
		float[,] array = (float[,])heights.Clone();
		switch (this.generatorType)
		{
		case global::TerrainToolkit.GeneratorType.Voronoi:
			array = this.generateVoronoi(array, new global::UnityEngine.Vector2((float)heightmapWidth, (float)heightmapHeight), generatorProgressDelegate);
			break;
		case global::TerrainToolkit.GeneratorType.DiamondSquare:
			array = this.generateDiamondSquare(array, new global::UnityEngine.Vector2((float)heightmapWidth, (float)heightmapHeight), generatorProgressDelegate);
			break;
		case global::TerrainToolkit.GeneratorType.Perlin:
			array = this.generatePerlin(array, new global::UnityEngine.Vector2((float)heightmapWidth, (float)heightmapHeight), generatorProgressDelegate);
			break;
		case global::TerrainToolkit.GeneratorType.Smooth:
			array = this.smooth(array, new global::UnityEngine.Vector2((float)heightmapWidth, (float)heightmapHeight), generatorProgressDelegate);
			break;
		case global::TerrainToolkit.GeneratorType.Normalise:
			array = this.normalise(array, new global::UnityEngine.Vector2((float)heightmapWidth, (float)heightmapHeight), generatorProgressDelegate);
			break;
		default:
			return;
		}
		for (int i = 0; i < heightmapHeight; i++)
		{
			for (int j = 0; j < heightmapWidth; j++)
			{
				float num = heights[j, i];
				float num2 = array[j, i];
				float num3 = 0f;
				switch (this.generatorType)
				{
				case global::TerrainToolkit.GeneratorType.Voronoi:
					num3 = num2 * this.voronoiBlend + num * (1f - this.voronoiBlend);
					break;
				case global::TerrainToolkit.GeneratorType.DiamondSquare:
					num3 = num2 * this.diamondSquareBlend + num * (1f - this.diamondSquareBlend);
					break;
				case global::TerrainToolkit.GeneratorType.Perlin:
					num3 = num2 * this.perlinBlend + num * (1f - this.perlinBlend);
					break;
				case global::TerrainToolkit.GeneratorType.Smooth:
					num3 = num2 * this.smoothBlend + num * (1f - this.smoothBlend);
					break;
				case global::TerrainToolkit.GeneratorType.Normalise:
					num3 = num2 * this.normaliseBlend + num * (1f - this.normaliseBlend);
					break;
				}
				heights[j, i] = num3;
			}
		}
		terrainData.SetHeights(0, 0, heights);
	}

	// Token: 0x06005290 RID: 21136 RVA: 0x001575AC File Offset: 0x001557AC
	private float[,] generateVoronoi(float[,] heightMap, global::UnityEngine.Vector2 arraySize, global::TerrainToolkit.GeneratorProgressDelegate generatorProgressDelegate)
	{
		int num = (int)arraySize.x;
		int num2 = (int)arraySize.y;
		global::System.Collections.ArrayList arrayList = new global::System.Collections.ArrayList();
		for (int i = 0; i < this.voronoiCells; i++)
		{
			global::TerrainToolkit.Peak peak = default(global::TerrainToolkit.Peak);
			int num3 = (int)global::UnityEngine.Mathf.Floor(global::UnityEngine.Random.value * (float)num);
			int num4 = (int)global::UnityEngine.Mathf.Floor(global::UnityEngine.Random.value * (float)num2);
			float peakHeight = global::UnityEngine.Random.value;
			if (global::UnityEngine.Random.value > this.voronoiFeatures)
			{
				peakHeight = 0f;
			}
			peak.peakPoint = new global::UnityEngine.Vector2((float)num3, (float)num4);
			peak.peakHeight = peakHeight;
			arrayList.Add(peak);
		}
		float num5 = 0f;
		for (int j = 0; j < num2; j++)
		{
			for (int k = 0; k < num; k++)
			{
				global::System.Collections.ArrayList arrayList2 = new global::System.Collections.ArrayList();
				for (int i = 0; i < this.voronoiCells; i++)
				{
					global::UnityEngine.Vector2 peakPoint = ((global::TerrainToolkit.Peak)arrayList[i]).peakPoint;
					float dist = global::UnityEngine.Vector2.Distance(peakPoint, new global::UnityEngine.Vector2((float)k, (float)j));
					arrayList2.Add(new global::TerrainToolkit.PeakDistance
					{
						id = i,
						dist = dist
					});
				}
				arrayList2.Sort();
				global::TerrainToolkit.PeakDistance peakDistance = (global::TerrainToolkit.PeakDistance)arrayList2[0];
				global::TerrainToolkit.PeakDistance peakDistance2 = (global::TerrainToolkit.PeakDistance)arrayList2[1];
				int id = peakDistance.id;
				float dist2 = peakDistance.dist;
				float dist3 = peakDistance2.dist;
				float num6 = global::UnityEngine.Mathf.Abs(dist2 - dist3) / ((float)(num + num2) / global::UnityEngine.Mathf.Sqrt((float)this.voronoiCells));
				float num7 = ((global::TerrainToolkit.Peak)arrayList[id]).peakHeight;
				float num8 = num7 - global::UnityEngine.Mathf.Abs(dist2 / dist3) * num7;
				switch (this.voronoiType)
				{
				case global::TerrainToolkit.VoronoiType.Sine:
				{
					float num9 = num8 * 3.1415927f - 1.5707964f;
					num8 = 0.5f + global::UnityEngine.Mathf.Sin(num9) / 2f;
					break;
				}
				case global::TerrainToolkit.VoronoiType.Tangent:
				{
					float num9 = num8 * 3.1415927f / 2f;
					num8 = 0.5f + global::UnityEngine.Mathf.Tan(num9) / 2f;
					break;
				}
				}
				num8 = num8 * num6 * this.voronoiScale + num8 * (1f - this.voronoiScale);
				if (num8 < 0f)
				{
					num8 = 0f;
				}
				else if (num8 > 1f)
				{
					num8 = 1f;
				}
				heightMap[k, j] = num8;
				if (num8 > num5)
				{
					num5 = num8;
				}
			}
			float num10 = (float)(j * num2);
			float num11 = (float)(num * num2);
			float percentComplete = num10 / num11;
			generatorProgressDelegate("Voronoi Generator", "Generating height map. Please wait.", percentComplete);
		}
		for (int j = 0; j < num2; j++)
		{
			for (int k = 0; k < num; k++)
			{
				float num12 = heightMap[k, j] * (1f / num5);
				heightMap[k, j] = num12;
			}
		}
		return heightMap;
	}

	// Token: 0x06005291 RID: 21137 RVA: 0x001578D0 File Offset: 0x00155AD0
	private float[,] generateDiamondSquare(float[,] heightMap, global::UnityEngine.Vector2 arraySize, global::TerrainToolkit.GeneratorProgressDelegate generatorProgressDelegate)
	{
		int num = (int)arraySize.x;
		int num2 = (int)arraySize.y;
		float num3 = 1f;
		int i = num - 1;
		heightMap[0, 0] = 0.5f;
		heightMap[num - 1, 0] = 0.5f;
		heightMap[0, num2 - 1] = 0.5f;
		heightMap[num - 1, num2 - 1] = 0.5f;
		generatorProgressDelegate("Fractal Generator", "Generating height map. Please wait.", 0f);
		while (i > 1)
		{
			for (int j = 0; j < num - 1; j += i)
			{
				for (int k = 0; k < num2 - 1; k += i)
				{
					int tx = j + (i >> 1);
					int ty = k + (i >> 1);
					global::UnityEngine.Vector2[] points = new global::UnityEngine.Vector2[]
					{
						new global::UnityEngine.Vector2((float)j, (float)k),
						new global::UnityEngine.Vector2((float)(j + i), (float)k),
						new global::UnityEngine.Vector2((float)j, (float)(k + i)),
						new global::UnityEngine.Vector2((float)(j + i), (float)(k + i))
					};
					this.dsCalculateHeight(heightMap, arraySize, tx, ty, points, num3);
				}
			}
			for (int l = 0; l < num - 1; l += i)
			{
				for (int m = 0; m < num2 - 1; m += i)
				{
					int num4 = i >> 1;
					int num5 = l + num4;
					int num6 = m;
					int num7 = l;
					int num8 = m + num4;
					global::UnityEngine.Vector2[] points2 = new global::UnityEngine.Vector2[]
					{
						new global::UnityEngine.Vector2((float)(num5 - num4), (float)num6),
						new global::UnityEngine.Vector2((float)num5, (float)(num6 - num4)),
						new global::UnityEngine.Vector2((float)(num5 + num4), (float)num6),
						new global::UnityEngine.Vector2((float)num5, (float)(num6 + num4))
					};
					global::UnityEngine.Vector2[] points3 = new global::UnityEngine.Vector2[]
					{
						new global::UnityEngine.Vector2((float)(num7 - num4), (float)num8),
						new global::UnityEngine.Vector2((float)num7, (float)(num8 - num4)),
						new global::UnityEngine.Vector2((float)(num7 + num4), (float)num8),
						new global::UnityEngine.Vector2((float)num7, (float)(num8 + num4))
					};
					this.dsCalculateHeight(heightMap, arraySize, num5, num6, points2, num3);
					this.dsCalculateHeight(heightMap, arraySize, num7, num8, points3, num3);
				}
			}
			num3 *= this.diamondSquareDelta;
			i >>= 1;
		}
		generatorProgressDelegate("Fractal Generator", "Generating height map. Please wait.", 1f);
		return heightMap;
	}

	// Token: 0x06005292 RID: 21138 RVA: 0x00157B8C File Offset: 0x00155D8C
	private void dsCalculateHeight(float[,] heightMap, global::UnityEngine.Vector2 arraySize, int Tx, int Ty, global::UnityEngine.Vector2[] points, float heightRange)
	{
		int num = (int)arraySize.x;
		int num2 = (int)arraySize.y;
		float num3 = 0f;
		for (int i = 0; i < 4; i++)
		{
			if (points[i].x < 0f)
			{
				int num4 = i;
				points[num4].x = points[num4].x + (float)(num - 1);
			}
			else if (points[i].x > (float)num)
			{
				int num5 = i;
				points[num5].x = points[num5].x - (float)(num - 1);
			}
			else if (points[i].y < 0f)
			{
				int num6 = i;
				points[num6].y = points[num6].y + (float)(num2 - 1);
			}
			else if (points[i].y > (float)num2)
			{
				int num7 = i;
				points[num7].y = points[num7].y - (float)(num2 - 1);
			}
			num3 += heightMap[(int)points[i].x, (int)points[i].y] / 4f;
		}
		num3 += global::UnityEngine.Random.value * heightRange - heightRange / 2f;
		if (num3 < 0f)
		{
			num3 = 0f;
		}
		else if (num3 > 1f)
		{
			num3 = 1f;
		}
		heightMap[Tx, Ty] = num3;
		if (Tx == 0)
		{
			heightMap[num - 1, Ty] = num3;
		}
		else if (Tx == num - 1)
		{
			heightMap[0, Ty] = num3;
		}
		else if (Ty == 0)
		{
			heightMap[Tx, num2 - 1] = num3;
		}
		else if (Ty == num2 - 1)
		{
			heightMap[Tx, 0] = num3;
		}
	}

	// Token: 0x06005293 RID: 21139 RVA: 0x00157D54 File Offset: 0x00155F54
	private float[,] generatePerlin(float[,] heightMap, global::UnityEngine.Vector2 arraySize, global::TerrainToolkit.GeneratorProgressDelegate generatorProgressDelegate)
	{
		int num = (int)arraySize.x;
		int num2 = (int)arraySize.y;
		for (int i = 0; i < num2; i++)
		{
			for (int j = 0; j < num; j++)
			{
				heightMap[j, i] = 0f;
			}
		}
		global::TerrainToolkit.PerlinNoise2D[] array = new global::TerrainToolkit.PerlinNoise2D[this.perlinOctaves];
		int num3 = this.perlinFrequency;
		float num4 = 1f;
		for (int k = 0; k < this.perlinOctaves; k++)
		{
			array[k] = new global::TerrainToolkit.PerlinNoise2D(num3, num4);
			num3 *= 2;
			num4 /= 2f;
		}
		for (int k = 0; k < this.perlinOctaves; k++)
		{
			double num5 = (double)((float)num / (float)array[k].Frequency);
			double num6 = (double)((float)num2 / (float)array[k].Frequency);
			for (int l = 0; l < num; l++)
			{
				for (int m = 0; m < num2; m++)
				{
					int num7 = (int)((double)l / num5);
					int xb = num7 + 1;
					int num8 = (int)((double)m / num6);
					int yb = num8 + 1;
					double interpolatedPoint = array[k].getInterpolatedPoint(num7, xb, num8, yb, (double)l / num5 - (double)num7, (double)m / num6 - (double)num8);
					heightMap[l, m] += (float)(interpolatedPoint * (double)array[k].Amplitude);
				}
			}
			float percentComplete = (float)((k + 1) / this.perlinOctaves);
			generatorProgressDelegate("Perlin Generator", "Generating height map. Please wait.", percentComplete);
		}
		global::TerrainToolkit.GeneratorProgressDelegate generatorProgressDelegate2 = new global::TerrainToolkit.GeneratorProgressDelegate(this.dummyGeneratorProgress);
		float num9 = this.normaliseMin;
		float num10 = this.normaliseMax;
		float num11 = this.normaliseBlend;
		this.normaliseMin = 0f;
		this.normaliseMax = 1f;
		this.normaliseBlend = 1f;
		heightMap = this.normalise(heightMap, arraySize, generatorProgressDelegate2);
		this.normaliseMin = num9;
		this.normaliseMax = num10;
		this.normaliseBlend = num11;
		for (int n = 0; n < num; n++)
		{
			for (int num12 = 0; num12 < num2; num12++)
			{
				heightMap[n, num12] *= this.perlinAmplitude;
			}
		}
		for (int k = 0; k < this.perlinOctaves; k++)
		{
			array[k] = null;
		}
		return heightMap;
	}

	// Token: 0x06005294 RID: 21140 RVA: 0x00157FBC File Offset: 0x001561BC
	private float[,] smooth(float[,] heightMap, global::UnityEngine.Vector2 arraySize, global::TerrainToolkit.GeneratorProgressDelegate generatorProgressDelegate)
	{
		int num = (int)arraySize.x;
		int num2 = (int)arraySize.y;
		for (int i = 0; i < this.smoothIterations; i++)
		{
			for (int j = 0; j < num2; j++)
			{
				int num3;
				int num4;
				int num5;
				if (j == 0)
				{
					num3 = 2;
					num4 = 0;
					num5 = 0;
				}
				else if (j == num2 - 1)
				{
					num3 = 2;
					num4 = -1;
					num5 = 1;
				}
				else
				{
					num3 = 3;
					num4 = -1;
					num5 = 1;
				}
				for (int k = 0; k < num; k++)
				{
					int num6;
					int num7;
					int num8;
					if (k == 0)
					{
						num6 = 2;
						num7 = 0;
						num8 = 0;
					}
					else if (k == num - 1)
					{
						num6 = 2;
						num7 = -1;
						num8 = 1;
					}
					else
					{
						num6 = 3;
						num7 = -1;
						num8 = 1;
					}
					float num9 = 0f;
					int num10 = 0;
					for (int l = 0; l < num3; l++)
					{
						for (int m = 0; m < num6; m++)
						{
							if (this.neighbourhood == global::TerrainToolkit.Neighbourhood.Moore || (this.neighbourhood == global::TerrainToolkit.Neighbourhood.VonNeumann && (m == num8 || l == num5)))
							{
								float num11 = heightMap[k + m + num7, j + l + num4];
								num9 += num11;
								num10++;
							}
						}
					}
					float num12 = num9 / (float)num10;
					heightMap[k + num8 + num7, j + num5 + num4] = num12;
				}
			}
			float percentComplete = (float)((i + 1) / this.smoothIterations);
			generatorProgressDelegate("Smoothing Filter", "Smoothing height map. Please wait.", percentComplete);
		}
		return heightMap;
	}

	// Token: 0x06005295 RID: 21141 RVA: 0x00158150 File Offset: 0x00156350
	private float[,] normalise(float[,] heightMap, global::UnityEngine.Vector2 arraySize, global::TerrainToolkit.GeneratorProgressDelegate generatorProgressDelegate)
	{
		int num = (int)arraySize.x;
		int num2 = (int)arraySize.y;
		float num3 = 0f;
		float num4 = 1f;
		generatorProgressDelegate("Normalise Filter", "Normalising height map. Please wait.", 0f);
		for (int i = 0; i < num2; i++)
		{
			for (int j = 0; j < num; j++)
			{
				float num5 = heightMap[j, i];
				if (num5 < num4)
				{
					num4 = num5;
				}
				else if (num5 > num3)
				{
					num3 = num5;
				}
			}
		}
		generatorProgressDelegate("Normalise Filter", "Normalising height map. Please wait.", 0.5f);
		float num6 = num3 - num4;
		float num7 = this.normaliseMax - this.normaliseMin;
		for (int i = 0; i < num2; i++)
		{
			for (int j = 0; j < num; j++)
			{
				float num8 = (heightMap[j, i] - num4) / num6 * num7;
				heightMap[j, i] = this.normaliseMin + num8;
			}
		}
		generatorProgressDelegate("Normalise Filter", "Normalising height map. Please wait.", 1f);
		return heightMap;
	}

	// Token: 0x06005296 RID: 21142 RVA: 0x00158268 File Offset: 0x00156468
	public void FastThermalErosion(int iterations, float minSlope, float blendAmount)
	{
		this.erosionTypeInt = 0;
		this.erosionType = global::TerrainToolkit.ErosionType.Thermal;
		this.thermalIterations = iterations;
		this.thermalMinSlope = minSlope;
		this.thermalFalloff = blendAmount;
		this.neighbourhood = global::TerrainToolkit.Neighbourhood.Moore;
		global::TerrainToolkit.ErosionProgressDelegate erosionProgressDelegate = new global::TerrainToolkit.ErosionProgressDelegate(this.dummyErosionProgress);
		this.erodeAllTerrain(erosionProgressDelegate);
	}

	// Token: 0x06005297 RID: 21143 RVA: 0x001582B4 File Offset: 0x001564B4
	public void FastHydraulicErosion(int iterations, float maxSlope, float blendAmount)
	{
		this.erosionTypeInt = 1;
		this.erosionType = global::TerrainToolkit.ErosionType.Hydraulic;
		this.hydraulicTypeInt = 0;
		this.hydraulicType = global::TerrainToolkit.HydraulicType.Fast;
		this.hydraulicIterations = iterations;
		this.hydraulicMaxSlope = maxSlope;
		this.hydraulicFalloff = blendAmount;
		this.neighbourhood = global::TerrainToolkit.Neighbourhood.Moore;
		global::TerrainToolkit.ErosionProgressDelegate erosionProgressDelegate = new global::TerrainToolkit.ErosionProgressDelegate(this.dummyErosionProgress);
		this.erodeAllTerrain(erosionProgressDelegate);
	}

	// Token: 0x06005298 RID: 21144 RVA: 0x00158310 File Offset: 0x00156510
	public void FullHydraulicErosion(int iterations, float rainfall, float evaporation, float solubility, float saturation)
	{
		this.erosionTypeInt = 1;
		this.erosionType = global::TerrainToolkit.ErosionType.Hydraulic;
		this.hydraulicTypeInt = 1;
		this.hydraulicType = global::TerrainToolkit.HydraulicType.Full;
		this.hydraulicIterations = iterations;
		this.hydraulicRainfall = rainfall;
		this.hydraulicEvaporation = evaporation;
		this.hydraulicSedimentSolubility = solubility;
		this.hydraulicSedimentSaturation = saturation;
		this.neighbourhood = global::TerrainToolkit.Neighbourhood.Moore;
		global::TerrainToolkit.ErosionProgressDelegate erosionProgressDelegate = new global::TerrainToolkit.ErosionProgressDelegate(this.dummyErosionProgress);
		this.erodeAllTerrain(erosionProgressDelegate);
	}

	// Token: 0x06005299 RID: 21145 RVA: 0x0015837C File Offset: 0x0015657C
	public void VelocityHydraulicErosion(int iterations, float rainfall, float evaporation, float solubility, float saturation, float velocity, float momentum, float entropy, float downcutting)
	{
		this.erosionTypeInt = 1;
		this.erosionType = global::TerrainToolkit.ErosionType.Hydraulic;
		this.hydraulicTypeInt = 2;
		this.hydraulicType = global::TerrainToolkit.HydraulicType.Velocity;
		this.hydraulicIterations = iterations;
		this.hydraulicVelocityRainfall = rainfall;
		this.hydraulicVelocityEvaporation = evaporation;
		this.hydraulicVelocitySedimentSolubility = solubility;
		this.hydraulicVelocitySedimentSaturation = saturation;
		this.hydraulicVelocity = velocity;
		this.hydraulicMomentum = momentum;
		this.hydraulicEntropy = entropy;
		this.hydraulicDowncutting = downcutting;
		this.neighbourhood = global::TerrainToolkit.Neighbourhood.Moore;
		global::TerrainToolkit.ErosionProgressDelegate erosionProgressDelegate = new global::TerrainToolkit.ErosionProgressDelegate(this.dummyErosionProgress);
		this.erodeAllTerrain(erosionProgressDelegate);
	}

	// Token: 0x0600529A RID: 21146 RVA: 0x00158408 File Offset: 0x00156608
	public void TidalErosion(int iterations, float seaLevel, float tidalRange, float cliffLimit)
	{
		this.erosionTypeInt = 2;
		this.erosionType = global::TerrainToolkit.ErosionType.Tidal;
		this.tidalIterations = iterations;
		this.tidalSeaLevel = seaLevel;
		this.tidalRangeAmount = tidalRange;
		this.tidalCliffLimit = cliffLimit;
		this.neighbourhood = global::TerrainToolkit.Neighbourhood.Moore;
		global::TerrainToolkit.ErosionProgressDelegate erosionProgressDelegate = new global::TerrainToolkit.ErosionProgressDelegate(this.dummyErosionProgress);
		this.erodeAllTerrain(erosionProgressDelegate);
	}

	// Token: 0x0600529B RID: 21147 RVA: 0x0015845C File Offset: 0x0015665C
	public void WindErosion(int iterations, float direction, float force, float lift, float gravity, float capacity, float entropy, float smoothing)
	{
		this.erosionTypeInt = 3;
		this.erosionType = global::TerrainToolkit.ErosionType.Wind;
		this.windIterations = iterations;
		this.windDirection = direction;
		this.windForce = force;
		this.windLift = lift;
		this.windGravity = gravity;
		this.windCapacity = capacity;
		this.windEntropy = entropy;
		this.windSmoothing = smoothing;
		this.neighbourhood = global::TerrainToolkit.Neighbourhood.Moore;
		global::TerrainToolkit.ErosionProgressDelegate erosionProgressDelegate = new global::TerrainToolkit.ErosionProgressDelegate(this.dummyErosionProgress);
		this.erodeAllTerrain(erosionProgressDelegate);
	}

	// Token: 0x0600529C RID: 21148 RVA: 0x001584D0 File Offset: 0x001566D0
	public void TextureTerrain(float[] slopeStops, float[] heightStops, global::UnityEngine.Texture2D[] textures)
	{
		if (slopeStops.Length != 2)
		{
			global::UnityEngine.Debug.LogError("Error: slopeStops must have 2 values");
			return;
		}
		if (heightStops.Length > 8)
		{
			global::UnityEngine.Debug.LogError("Error: heightStops must have no more than 8 values");
			return;
		}
		if (heightStops.Length % 2 != 0)
		{
			global::UnityEngine.Debug.LogError("Error: heightStops must have an even number of values");
			return;
		}
		int num = textures.Length;
		int num2 = heightStops.Length / 2 + 2;
		if (num != num2)
		{
			global::UnityEngine.Debug.LogError("Error: heightStops contains an incorrect number of values");
			return;
		}
		foreach (float num3 in slopeStops)
		{
			if (num3 < 0f || num3 > 90f)
			{
				global::UnityEngine.Debug.LogError("Error: The value of all slopeStops must be in the range 0.0 to 90.0");
				return;
			}
		}
		foreach (float num4 in heightStops)
		{
			if (num4 < 0f || num4 > 1f)
			{
				global::UnityEngine.Debug.LogError("Error: The value of all heightStops must be in the range 0.0 to 1.0");
				return;
			}
		}
		global::UnityEngine.Terrain terrain = (global::UnityEngine.Terrain)base.GetComponent(typeof(global::UnityEngine.Terrain));
		global::UnityEngine.TerrainData terrainData = terrain.terrainData;
		this.splatPrototypes = terrainData.splatPrototypes;
		this.deleteAllSplatPrototypes();
		int num5 = 0;
		foreach (global::UnityEngine.Texture2D tex in textures)
		{
			this.addSplatPrototype(tex, num5);
			num5++;
		}
		this.slopeBlendMinAngle = slopeStops[0];
		this.slopeBlendMaxAngle = slopeStops[1];
		num5 = 0;
		foreach (float value in heightStops)
		{
			this.heightBlendPoints[num5] = value;
			num5++;
		}
		terrainData.splatPrototypes = this.splatPrototypes;
		global::TerrainToolkit.TextureProgressDelegate textureProgressDelegate = new global::TerrainToolkit.TextureProgressDelegate(this.dummyTextureProgress);
		this.textureTerrain(textureProgressDelegate);
	}

	// Token: 0x0600529D RID: 21149 RVA: 0x0015869C File Offset: 0x0015689C
	public void VoronoiGenerator(global::TerrainToolkit.FeatureType featureType, int cells, float features, float scale, float blend)
	{
		this.generatorTypeInt = 0;
		this.generatorType = global::TerrainToolkit.GeneratorType.Voronoi;
		switch (featureType)
		{
		case global::TerrainToolkit.FeatureType.Mountains:
			this.voronoiTypeInt = 0;
			this.voronoiType = global::TerrainToolkit.VoronoiType.Linear;
			break;
		case global::TerrainToolkit.FeatureType.Hills:
			this.voronoiTypeInt = 1;
			this.voronoiType = global::TerrainToolkit.VoronoiType.Sine;
			break;
		case global::TerrainToolkit.FeatureType.Plateaus:
			this.voronoiTypeInt = 2;
			this.voronoiType = global::TerrainToolkit.VoronoiType.Tangent;
			break;
		}
		this.voronoiCells = cells;
		this.voronoiFeatures = features;
		this.voronoiScale = scale;
		this.voronoiBlend = blend;
		global::TerrainToolkit.GeneratorProgressDelegate generatorProgressDelegate = new global::TerrainToolkit.GeneratorProgressDelegate(this.dummyGeneratorProgress);
		this.generateTerrain(generatorProgressDelegate);
	}

	// Token: 0x0600529E RID: 21150 RVA: 0x0015873C File Offset: 0x0015693C
	public void FractalGenerator(float fractalDelta, float blend)
	{
		this.generatorTypeInt = 1;
		this.generatorType = global::TerrainToolkit.GeneratorType.DiamondSquare;
		this.diamondSquareDelta = fractalDelta;
		this.diamondSquareBlend = blend;
		global::TerrainToolkit.GeneratorProgressDelegate generatorProgressDelegate = new global::TerrainToolkit.GeneratorProgressDelegate(this.dummyGeneratorProgress);
		this.generateTerrain(generatorProgressDelegate);
	}

	// Token: 0x0600529F RID: 21151 RVA: 0x0015877C File Offset: 0x0015697C
	public void PerlinGenerator(int frequency, float amplitude, int octaves, float blend)
	{
		this.generatorTypeInt = 2;
		this.generatorType = global::TerrainToolkit.GeneratorType.Perlin;
		this.perlinFrequency = frequency;
		this.perlinAmplitude = amplitude;
		this.perlinOctaves = octaves;
		this.perlinBlend = blend;
		global::TerrainToolkit.GeneratorProgressDelegate generatorProgressDelegate = new global::TerrainToolkit.GeneratorProgressDelegate(this.dummyGeneratorProgress);
		this.generateTerrain(generatorProgressDelegate);
	}

	// Token: 0x060052A0 RID: 21152 RVA: 0x001587C8 File Offset: 0x001569C8
	public void SmoothTerrain(int iterations, float blend)
	{
		this.generatorTypeInt = 3;
		this.generatorType = global::TerrainToolkit.GeneratorType.Smooth;
		this.smoothIterations = iterations;
		this.smoothBlend = blend;
		global::TerrainToolkit.GeneratorProgressDelegate generatorProgressDelegate = new global::TerrainToolkit.GeneratorProgressDelegate(this.dummyGeneratorProgress);
		this.generateTerrain(generatorProgressDelegate);
	}

	// Token: 0x060052A1 RID: 21153 RVA: 0x00158808 File Offset: 0x00156A08
	public void NormaliseTerrain(float minHeight, float maxHeight, float blend)
	{
		this.generatorTypeInt = 4;
		this.generatorType = global::TerrainToolkit.GeneratorType.Normalise;
		this.normaliseMin = minHeight;
		this.normaliseMax = maxHeight;
		this.normaliseBlend = blend;
		global::TerrainToolkit.GeneratorProgressDelegate generatorProgressDelegate = new global::TerrainToolkit.GeneratorProgressDelegate(this.dummyGeneratorProgress);
		this.generateTerrain(generatorProgressDelegate);
	}

	// Token: 0x060052A2 RID: 21154 RVA: 0x0015884C File Offset: 0x00156A4C
	public void NormalizeTerrain(float minHeight, float maxHeight, float blend)
	{
		this.NormaliseTerrain(minHeight, maxHeight, blend);
	}

	// Token: 0x060052A3 RID: 21155 RVA: 0x00158858 File Offset: 0x00156A58
	private void convertIntVarsToEnums()
	{
		switch (this.erosionTypeInt)
		{
		case 0:
			this.erosionType = global::TerrainToolkit.ErosionType.Thermal;
			break;
		case 1:
			this.erosionType = global::TerrainToolkit.ErosionType.Hydraulic;
			break;
		case 2:
			this.erosionType = global::TerrainToolkit.ErosionType.Tidal;
			break;
		case 3:
			this.erosionType = global::TerrainToolkit.ErosionType.Wind;
			break;
		case 4:
			this.erosionType = global::TerrainToolkit.ErosionType.Glacial;
			break;
		}
		switch (this.hydraulicTypeInt)
		{
		case 0:
			this.hydraulicType = global::TerrainToolkit.HydraulicType.Fast;
			break;
		case 1:
			this.hydraulicType = global::TerrainToolkit.HydraulicType.Full;
			break;
		case 2:
			this.hydraulicType = global::TerrainToolkit.HydraulicType.Velocity;
			break;
		}
		switch (this.generatorTypeInt)
		{
		case 0:
			this.generatorType = global::TerrainToolkit.GeneratorType.Voronoi;
			break;
		case 1:
			this.generatorType = global::TerrainToolkit.GeneratorType.DiamondSquare;
			break;
		case 2:
			this.generatorType = global::TerrainToolkit.GeneratorType.Perlin;
			break;
		case 3:
			this.generatorType = global::TerrainToolkit.GeneratorType.Smooth;
			break;
		case 4:
			this.generatorType = global::TerrainToolkit.GeneratorType.Normalise;
			break;
		}
		switch (this.voronoiTypeInt)
		{
		case 0:
			this.voronoiType = global::TerrainToolkit.VoronoiType.Linear;
			break;
		case 1:
			this.voronoiType = global::TerrainToolkit.VoronoiType.Sine;
			break;
		case 2:
			this.voronoiType = global::TerrainToolkit.VoronoiType.Tangent;
			break;
		}
		int num = this.neighbourhoodInt;
		if (num != 0)
		{
			if (num == 1)
			{
				this.neighbourhood = global::TerrainToolkit.Neighbourhood.VonNeumann;
			}
		}
		else
		{
			this.neighbourhood = global::TerrainToolkit.Neighbourhood.Moore;
		}
	}

	// Token: 0x060052A4 RID: 21156 RVA: 0x001589E0 File Offset: 0x00156BE0
	public void dummyErosionProgress(string titleString, string displayString, int iteration, int nIterations, float percentComplete)
	{
	}

	// Token: 0x060052A5 RID: 21157 RVA: 0x001589E4 File Offset: 0x00156BE4
	public void dummyTextureProgress(string titleString, string displayString, float percentComplete)
	{
	}

	// Token: 0x060052A6 RID: 21158 RVA: 0x001589E8 File Offset: 0x00156BE8
	public void dummyGeneratorProgress(string titleString, string displayString, float percentComplete)
	{
	}

	// Token: 0x04002EF2 RID: 12018
	public global::UnityEngine.GUISkin guiSkin;

	// Token: 0x04002EF3 RID: 12019
	public global::UnityEngine.Texture2D createIcon;

	// Token: 0x04002EF4 RID: 12020
	public global::UnityEngine.Texture2D erodeIcon;

	// Token: 0x04002EF5 RID: 12021
	public global::UnityEngine.Texture2D textureIcon;

	// Token: 0x04002EF6 RID: 12022
	public global::UnityEngine.Texture2D mooreIcon;

	// Token: 0x04002EF7 RID: 12023
	public global::UnityEngine.Texture2D vonNeumannIcon;

	// Token: 0x04002EF8 RID: 12024
	public global::UnityEngine.Texture2D mountainsIcon;

	// Token: 0x04002EF9 RID: 12025
	public global::UnityEngine.Texture2D hillsIcon;

	// Token: 0x04002EFA RID: 12026
	public global::UnityEngine.Texture2D plateausIcon;

	// Token: 0x04002EFB RID: 12027
	public global::UnityEngine.Texture2D defaultTexture;

	// Token: 0x04002EFC RID: 12028
	public int toolModeInt;

	// Token: 0x04002EFD RID: 12029
	private global::TerrainToolkit.ErosionMode erosionMode;

	// Token: 0x04002EFE RID: 12030
	private global::TerrainToolkit.ErosionType erosionType;

	// Token: 0x04002EFF RID: 12031
	public int erosionTypeInt;

	// Token: 0x04002F00 RID: 12032
	private global::TerrainToolkit.GeneratorType generatorType;

	// Token: 0x04002F01 RID: 12033
	public int generatorTypeInt;

	// Token: 0x04002F02 RID: 12034
	public bool isBrushOn;

	// Token: 0x04002F03 RID: 12035
	public bool isBrushHidden;

	// Token: 0x04002F04 RID: 12036
	public bool isBrushPainting;

	// Token: 0x04002F05 RID: 12037
	public global::UnityEngine.Vector3 brushPosition;

	// Token: 0x04002F06 RID: 12038
	public float brushSize = 50f;

	// Token: 0x04002F07 RID: 12039
	public float brushOpacity = 1f;

	// Token: 0x04002F08 RID: 12040
	public float brushSoftness = 0.5f;

	// Token: 0x04002F09 RID: 12041
	public int neighbourhoodInt;

	// Token: 0x04002F0A RID: 12042
	private global::TerrainToolkit.Neighbourhood neighbourhood;

	// Token: 0x04002F0B RID: 12043
	public bool useDifferenceMaps = true;

	// Token: 0x04002F0C RID: 12044
	public int thermalIterations = 0x19;

	// Token: 0x04002F0D RID: 12045
	public float thermalMinSlope = 1f;

	// Token: 0x04002F0E RID: 12046
	public float thermalFalloff = 0.5f;

	// Token: 0x04002F0F RID: 12047
	public int hydraulicTypeInt;

	// Token: 0x04002F10 RID: 12048
	public global::TerrainToolkit.HydraulicType hydraulicType;

	// Token: 0x04002F11 RID: 12049
	public int hydraulicIterations = 0x19;

	// Token: 0x04002F12 RID: 12050
	public float hydraulicMaxSlope = 60f;

	// Token: 0x04002F13 RID: 12051
	public float hydraulicFalloff = 0.5f;

	// Token: 0x04002F14 RID: 12052
	public float hydraulicRainfall = 0.01f;

	// Token: 0x04002F15 RID: 12053
	public float hydraulicEvaporation = 0.5f;

	// Token: 0x04002F16 RID: 12054
	public float hydraulicSedimentSolubility = 0.01f;

	// Token: 0x04002F17 RID: 12055
	public float hydraulicSedimentSaturation = 0.1f;

	// Token: 0x04002F18 RID: 12056
	public float hydraulicVelocityRainfall = 0.01f;

	// Token: 0x04002F19 RID: 12057
	public float hydraulicVelocityEvaporation = 0.5f;

	// Token: 0x04002F1A RID: 12058
	public float hydraulicVelocitySedimentSolubility = 0.01f;

	// Token: 0x04002F1B RID: 12059
	public float hydraulicVelocitySedimentSaturation = 0.1f;

	// Token: 0x04002F1C RID: 12060
	public float hydraulicVelocity = 20f;

	// Token: 0x04002F1D RID: 12061
	public float hydraulicMomentum = 1f;

	// Token: 0x04002F1E RID: 12062
	public float hydraulicEntropy;

	// Token: 0x04002F1F RID: 12063
	public float hydraulicDowncutting = 0.1f;

	// Token: 0x04002F20 RID: 12064
	public int tidalIterations = 0x19;

	// Token: 0x04002F21 RID: 12065
	public float tidalSeaLevel = 50f;

	// Token: 0x04002F22 RID: 12066
	public float tidalRangeAmount = 5f;

	// Token: 0x04002F23 RID: 12067
	public float tidalCliffLimit = 60f;

	// Token: 0x04002F24 RID: 12068
	public int windIterations = 0x19;

	// Token: 0x04002F25 RID: 12069
	public float windDirection;

	// Token: 0x04002F26 RID: 12070
	public float windForce = 0.5f;

	// Token: 0x04002F27 RID: 12071
	public float windLift = 0.01f;

	// Token: 0x04002F28 RID: 12072
	public float windGravity = 0.5f;

	// Token: 0x04002F29 RID: 12073
	public float windCapacity = 0.01f;

	// Token: 0x04002F2A RID: 12074
	public float windEntropy = 0.1f;

	// Token: 0x04002F2B RID: 12075
	public float windSmoothing = 0.25f;

	// Token: 0x04002F2C RID: 12076
	public global::UnityEngine.SplatPrototype[] splatPrototypes;

	// Token: 0x04002F2D RID: 12077
	public global::UnityEngine.Texture2D tempTexture;

	// Token: 0x04002F2E RID: 12078
	public float slopeBlendMinAngle = 60f;

	// Token: 0x04002F2F RID: 12079
	public float slopeBlendMaxAngle = 75f;

	// Token: 0x04002F30 RID: 12080
	public global::System.Collections.Generic.List<float> heightBlendPoints;

	// Token: 0x04002F31 RID: 12081
	public string[] gradientStyles;

	// Token: 0x04002F32 RID: 12082
	public int voronoiTypeInt;

	// Token: 0x04002F33 RID: 12083
	public global::TerrainToolkit.VoronoiType voronoiType;

	// Token: 0x04002F34 RID: 12084
	public int voronoiCells = 0x10;

	// Token: 0x04002F35 RID: 12085
	public float voronoiFeatures = 1f;

	// Token: 0x04002F36 RID: 12086
	public float voronoiScale = 1f;

	// Token: 0x04002F37 RID: 12087
	public float voronoiBlend = 1f;

	// Token: 0x04002F38 RID: 12088
	public float diamondSquareDelta = 0.5f;

	// Token: 0x04002F39 RID: 12089
	public float diamondSquareBlend = 1f;

	// Token: 0x04002F3A RID: 12090
	public int perlinFrequency = 4;

	// Token: 0x04002F3B RID: 12091
	public float perlinAmplitude = 1f;

	// Token: 0x04002F3C RID: 12092
	public int perlinOctaves = 8;

	// Token: 0x04002F3D RID: 12093
	public float perlinBlend = 1f;

	// Token: 0x04002F3E RID: 12094
	public float smoothBlend = 1f;

	// Token: 0x04002F3F RID: 12095
	public int smoothIterations;

	// Token: 0x04002F40 RID: 12096
	public float normaliseMin;

	// Token: 0x04002F41 RID: 12097
	public float normaliseMax = 1f;

	// Token: 0x04002F42 RID: 12098
	public float normaliseBlend = 1f;

	// Token: 0x04002F43 RID: 12099
	[global::System.NonSerialized]
	public bool presetsInitialised;

	// Token: 0x04002F44 RID: 12100
	[global::System.NonSerialized]
	public int voronoiPresetId;

	// Token: 0x04002F45 RID: 12101
	[global::System.NonSerialized]
	public int fractalPresetId;

	// Token: 0x04002F46 RID: 12102
	[global::System.NonSerialized]
	public int perlinPresetId;

	// Token: 0x04002F47 RID: 12103
	[global::System.NonSerialized]
	public int thermalErosionPresetId;

	// Token: 0x04002F48 RID: 12104
	[global::System.NonSerialized]
	public int fastHydraulicErosionPresetId;

	// Token: 0x04002F49 RID: 12105
	[global::System.NonSerialized]
	public int fullHydraulicErosionPresetId;

	// Token: 0x04002F4A RID: 12106
	[global::System.NonSerialized]
	public int velocityHydraulicErosionPresetId;

	// Token: 0x04002F4B RID: 12107
	[global::System.NonSerialized]
	public int tidalErosionPresetId;

	// Token: 0x04002F4C RID: 12108
	[global::System.NonSerialized]
	public int windErosionPresetId;

	// Token: 0x04002F4D RID: 12109
	public global::System.Collections.ArrayList voronoiPresets = new global::System.Collections.ArrayList();

	// Token: 0x04002F4E RID: 12110
	public global::System.Collections.ArrayList fractalPresets = new global::System.Collections.ArrayList();

	// Token: 0x04002F4F RID: 12111
	public global::System.Collections.ArrayList perlinPresets = new global::System.Collections.ArrayList();

	// Token: 0x04002F50 RID: 12112
	public global::System.Collections.ArrayList thermalErosionPresets = new global::System.Collections.ArrayList();

	// Token: 0x04002F51 RID: 12113
	public global::System.Collections.ArrayList fastHydraulicErosionPresets = new global::System.Collections.ArrayList();

	// Token: 0x04002F52 RID: 12114
	public global::System.Collections.ArrayList fullHydraulicErosionPresets = new global::System.Collections.ArrayList();

	// Token: 0x04002F53 RID: 12115
	public global::System.Collections.ArrayList velocityHydraulicErosionPresets = new global::System.Collections.ArrayList();

	// Token: 0x04002F54 RID: 12116
	public global::System.Collections.ArrayList tidalErosionPresets = new global::System.Collections.ArrayList();

	// Token: 0x04002F55 RID: 12117
	public global::System.Collections.ArrayList windErosionPresets = new global::System.Collections.ArrayList();

	// Token: 0x02000975 RID: 2421
	public class PeakDistance : global::System.IComparable
	{
		// Token: 0x060052A7 RID: 21159 RVA: 0x001589EC File Offset: 0x00156BEC
		public PeakDistance()
		{
		}

		// Token: 0x060052A8 RID: 21160 RVA: 0x001589F4 File Offset: 0x00156BF4
		public int CompareTo(object obj)
		{
			global::TerrainToolkit.PeakDistance peakDistance = (global::TerrainToolkit.PeakDistance)obj;
			int num = this.dist.CompareTo(peakDistance.dist);
			if (num == 0)
			{
				num = this.dist.CompareTo(peakDistance.dist);
			}
			return num;
		}

		// Token: 0x04002F56 RID: 12118
		public int id;

		// Token: 0x04002F57 RID: 12119
		public float dist;
	}

	// Token: 0x02000976 RID: 2422
	public struct Peak
	{
		// Token: 0x04002F58 RID: 12120
		public global::UnityEngine.Vector2 peakPoint;

		// Token: 0x04002F59 RID: 12121
		public float peakHeight;
	}

	// Token: 0x02000977 RID: 2423
	public class voronoiPresetData
	{
		// Token: 0x060052A9 RID: 21161 RVA: 0x00158A34 File Offset: 0x00156C34
		public voronoiPresetData(string pn, global::TerrainToolkit.VoronoiType vt, int c, float vf, float vs, float vb)
		{
			this.presetName = pn;
			this.voronoiType = vt;
			this.voronoiCells = c;
			this.voronoiFeatures = vf;
			this.voronoiScale = vs;
			this.voronoiBlend = vb;
		}

		// Token: 0x04002F5A RID: 12122
		public string presetName;

		// Token: 0x04002F5B RID: 12123
		public global::TerrainToolkit.VoronoiType voronoiType;

		// Token: 0x04002F5C RID: 12124
		public int voronoiCells;

		// Token: 0x04002F5D RID: 12125
		public float voronoiFeatures;

		// Token: 0x04002F5E RID: 12126
		public float voronoiScale;

		// Token: 0x04002F5F RID: 12127
		public float voronoiBlend;
	}

	// Token: 0x02000978 RID: 2424
	public class fractalPresetData
	{
		// Token: 0x060052AA RID: 21162 RVA: 0x00158A6C File Offset: 0x00156C6C
		public fractalPresetData(string pn, float dsd, float dsb)
		{
			this.presetName = pn;
			this.diamondSquareDelta = dsd;
			this.diamondSquareBlend = dsb;
		}

		// Token: 0x04002F60 RID: 12128
		public string presetName;

		// Token: 0x04002F61 RID: 12129
		public float diamondSquareDelta;

		// Token: 0x04002F62 RID: 12130
		public float diamondSquareBlend;
	}

	// Token: 0x02000979 RID: 2425
	public class perlinPresetData
	{
		// Token: 0x060052AB RID: 21163 RVA: 0x00158A8C File Offset: 0x00156C8C
		public perlinPresetData(string pn, int pf, float pa, int po, float pb)
		{
			this.presetName = pn;
			this.perlinFrequency = pf;
			this.perlinAmplitude = pa;
			this.perlinOctaves = po;
			this.perlinBlend = pb;
		}

		// Token: 0x04002F63 RID: 12131
		public string presetName;

		// Token: 0x04002F64 RID: 12132
		public int perlinFrequency;

		// Token: 0x04002F65 RID: 12133
		public float perlinAmplitude;

		// Token: 0x04002F66 RID: 12134
		public int perlinOctaves;

		// Token: 0x04002F67 RID: 12135
		public float perlinBlend;
	}

	// Token: 0x0200097A RID: 2426
	public class thermalErosionPresetData
	{
		// Token: 0x060052AC RID: 21164 RVA: 0x00158ABC File Offset: 0x00156CBC
		public thermalErosionPresetData(string pn, int ti, float tms, float tba)
		{
			this.presetName = pn;
			this.thermalIterations = ti;
			this.thermalMinSlope = tms;
			this.thermalFalloff = tba;
		}

		// Token: 0x04002F68 RID: 12136
		public string presetName;

		// Token: 0x04002F69 RID: 12137
		public int thermalIterations;

		// Token: 0x04002F6A RID: 12138
		public float thermalMinSlope;

		// Token: 0x04002F6B RID: 12139
		public float thermalFalloff;
	}

	// Token: 0x0200097B RID: 2427
	public class fastHydraulicErosionPresetData
	{
		// Token: 0x060052AD RID: 21165 RVA: 0x00158AE4 File Offset: 0x00156CE4
		public fastHydraulicErosionPresetData(string pn, int hi, float hms, float hba)
		{
			this.presetName = pn;
			this.hydraulicIterations = hi;
			this.hydraulicMaxSlope = hms;
			this.hydraulicFalloff = hba;
		}

		// Token: 0x04002F6C RID: 12140
		public string presetName;

		// Token: 0x04002F6D RID: 12141
		public int hydraulicIterations;

		// Token: 0x04002F6E RID: 12142
		public float hydraulicMaxSlope;

		// Token: 0x04002F6F RID: 12143
		public float hydraulicFalloff;
	}

	// Token: 0x0200097C RID: 2428
	public class fullHydraulicErosionPresetData
	{
		// Token: 0x060052AE RID: 21166 RVA: 0x00158B0C File Offset: 0x00156D0C
		public fullHydraulicErosionPresetData(string pn, int hi, float hr, float he, float hso, float hsa)
		{
			this.presetName = pn;
			this.hydraulicIterations = hi;
			this.hydraulicRainfall = hr;
			this.hydraulicEvaporation = he;
			this.hydraulicSedimentSolubility = hso;
			this.hydraulicSedimentSaturation = hsa;
		}

		// Token: 0x04002F70 RID: 12144
		public string presetName;

		// Token: 0x04002F71 RID: 12145
		public int hydraulicIterations;

		// Token: 0x04002F72 RID: 12146
		public float hydraulicRainfall;

		// Token: 0x04002F73 RID: 12147
		public float hydraulicEvaporation;

		// Token: 0x04002F74 RID: 12148
		public float hydraulicSedimentSolubility;

		// Token: 0x04002F75 RID: 12149
		public float hydraulicSedimentSaturation;
	}

	// Token: 0x0200097D RID: 2429
	public class velocityHydraulicErosionPresetData
	{
		// Token: 0x060052AF RID: 21167 RVA: 0x00158B44 File Offset: 0x00156D44
		public velocityHydraulicErosionPresetData(string pn, int hi, float hvr, float hve, float hso, float hsa, float hv, float hm, float he, float hd)
		{
			this.presetName = pn;
			this.hydraulicIterations = hi;
			this.hydraulicVelocityRainfall = hvr;
			this.hydraulicVelocityEvaporation = hve;
			this.hydraulicVelocitySedimentSolubility = hso;
			this.hydraulicVelocitySedimentSaturation = hsa;
			this.hydraulicVelocity = hv;
			this.hydraulicMomentum = hm;
			this.hydraulicEntropy = he;
			this.hydraulicDowncutting = hd;
		}

		// Token: 0x04002F76 RID: 12150
		public string presetName;

		// Token: 0x04002F77 RID: 12151
		public int hydraulicIterations;

		// Token: 0x04002F78 RID: 12152
		public float hydraulicVelocityRainfall;

		// Token: 0x04002F79 RID: 12153
		public float hydraulicVelocityEvaporation;

		// Token: 0x04002F7A RID: 12154
		public float hydraulicVelocitySedimentSolubility;

		// Token: 0x04002F7B RID: 12155
		public float hydraulicVelocitySedimentSaturation;

		// Token: 0x04002F7C RID: 12156
		public float hydraulicVelocity;

		// Token: 0x04002F7D RID: 12157
		public float hydraulicMomentum;

		// Token: 0x04002F7E RID: 12158
		public float hydraulicEntropy;

		// Token: 0x04002F7F RID: 12159
		public float hydraulicDowncutting;
	}

	// Token: 0x0200097E RID: 2430
	public class tidalErosionPresetData
	{
		// Token: 0x060052B0 RID: 21168 RVA: 0x00158BA4 File Offset: 0x00156DA4
		public tidalErosionPresetData(string pn, int ti, float tra, float tcl)
		{
			this.presetName = pn;
			this.tidalIterations = ti;
			this.tidalRangeAmount = tra;
			this.tidalCliffLimit = tcl;
		}

		// Token: 0x04002F80 RID: 12160
		public string presetName;

		// Token: 0x04002F81 RID: 12161
		public int tidalIterations;

		// Token: 0x04002F82 RID: 12162
		public float tidalRangeAmount;

		// Token: 0x04002F83 RID: 12163
		public float tidalCliffLimit;
	}

	// Token: 0x0200097F RID: 2431
	public class windErosionPresetData
	{
		// Token: 0x060052B1 RID: 21169 RVA: 0x00158BCC File Offset: 0x00156DCC
		public windErosionPresetData(string pn, int wi, float wd, float wf, float wl, float wg, float wc, float we, float ws)
		{
			this.presetName = pn;
			this.windIterations = wi;
			this.windDirection = wd;
			this.windForce = wf;
			this.windLift = wl;
			this.windGravity = wg;
			this.windCapacity = wc;
			this.windEntropy = we;
			this.windSmoothing = ws;
		}

		// Token: 0x04002F84 RID: 12164
		public string presetName;

		// Token: 0x04002F85 RID: 12165
		public int windIterations;

		// Token: 0x04002F86 RID: 12166
		public float windDirection;

		// Token: 0x04002F87 RID: 12167
		public float windForce;

		// Token: 0x04002F88 RID: 12168
		public float windLift;

		// Token: 0x04002F89 RID: 12169
		public float windGravity;

		// Token: 0x04002F8A RID: 12170
		public float windCapacity;

		// Token: 0x04002F8B RID: 12171
		public float windEntropy;

		// Token: 0x04002F8C RID: 12172
		public float windSmoothing;
	}

	// Token: 0x02000980 RID: 2432
	public enum ToolMode
	{
		// Token: 0x04002F8E RID: 12174
		Create,
		// Token: 0x04002F8F RID: 12175
		Erode,
		// Token: 0x04002F90 RID: 12176
		Texture
	}

	// Token: 0x02000981 RID: 2433
	public enum ErosionMode
	{
		// Token: 0x04002F92 RID: 12178
		Filter,
		// Token: 0x04002F93 RID: 12179
		Brush
	}

	// Token: 0x02000982 RID: 2434
	public enum ErosionType
	{
		// Token: 0x04002F95 RID: 12181
		Thermal,
		// Token: 0x04002F96 RID: 12182
		Hydraulic,
		// Token: 0x04002F97 RID: 12183
		Tidal,
		// Token: 0x04002F98 RID: 12184
		Wind,
		// Token: 0x04002F99 RID: 12185
		Glacial
	}

	// Token: 0x02000983 RID: 2435
	public enum HydraulicType
	{
		// Token: 0x04002F9B RID: 12187
		Fast,
		// Token: 0x04002F9C RID: 12188
		Full,
		// Token: 0x04002F9D RID: 12189
		Velocity
	}

	// Token: 0x02000984 RID: 2436
	public enum Neighbourhood
	{
		// Token: 0x04002F9F RID: 12191
		Moore,
		// Token: 0x04002FA0 RID: 12192
		VonNeumann
	}

	// Token: 0x02000985 RID: 2437
	public enum GeneratorType
	{
		// Token: 0x04002FA2 RID: 12194
		Voronoi,
		// Token: 0x04002FA3 RID: 12195
		DiamondSquare,
		// Token: 0x04002FA4 RID: 12196
		Perlin,
		// Token: 0x04002FA5 RID: 12197
		Smooth,
		// Token: 0x04002FA6 RID: 12198
		Normalise
	}

	// Token: 0x02000986 RID: 2438
	public enum VoronoiType
	{
		// Token: 0x04002FA8 RID: 12200
		Linear,
		// Token: 0x04002FA9 RID: 12201
		Sine,
		// Token: 0x04002FAA RID: 12202
		Tangent
	}

	// Token: 0x02000987 RID: 2439
	public enum FeatureType
	{
		// Token: 0x04002FAC RID: 12204
		Mountains,
		// Token: 0x04002FAD RID: 12205
		Hills,
		// Token: 0x04002FAE RID: 12206
		Plateaus
	}

	// Token: 0x02000988 RID: 2440
	public class PerlinNoise2D
	{
		// Token: 0x060052B2 RID: 21170 RVA: 0x00158C24 File Offset: 0x00156E24
		public PerlinNoise2D(int freq, float _amp)
		{
			global::System.Random random = new global::System.Random(global::System.Environment.TickCount);
			this.noiseValues = new double[freq, freq];
			this.amplitude = _amp;
			this.frequency = freq;
			for (int i = 0; i < freq; i++)
			{
				for (int j = 0; j < freq; j++)
				{
					this.noiseValues[i, j] = random.NextDouble();
				}
			}
		}

		// Token: 0x060052B3 RID: 21171 RVA: 0x00158CA8 File Offset: 0x00156EA8
		public double getInterpolatedPoint(int _xa, int _xb, int _ya, int _yb, double Px, double Py)
		{
			double pa = this.interpolate(this.noiseValues[_xa % this.Frequency, _ya % this.frequency], this.noiseValues[_xb % this.Frequency, _ya % this.frequency], Px);
			double pb = this.interpolate(this.noiseValues[_xa % this.Frequency, _yb % this.frequency], this.noiseValues[_xb % this.Frequency, _yb % this.frequency], Px);
			return this.interpolate(pa, pb, Py);
		}

		// Token: 0x060052B4 RID: 21172 RVA: 0x00158D40 File Offset: 0x00156F40
		private double interpolate(double Pa, double Pb, double Px)
		{
			double num = Px * 3.1415927410125732;
			double num2 = (double)(1f - global::UnityEngine.Mathf.Cos((float)num)) * 0.5;
			return Pa * (1.0 - num2) + Pb * num2;
		}

		// Token: 0x17000F78 RID: 3960
		// (get) Token: 0x060052B5 RID: 21173 RVA: 0x00158D84 File Offset: 0x00156F84
		public float Amplitude
		{
			get
			{
				return this.amplitude;
			}
		}

		// Token: 0x17000F79 RID: 3961
		// (get) Token: 0x060052B6 RID: 21174 RVA: 0x00158D8C File Offset: 0x00156F8C
		public int Frequency
		{
			get
			{
				return this.frequency;
			}
		}

		// Token: 0x04002FAF RID: 12207
		private double[,] noiseValues;

		// Token: 0x04002FB0 RID: 12208
		private float amplitude = 1f;

		// Token: 0x04002FB1 RID: 12209
		private int frequency = 1;
	}

	// Token: 0x02000989 RID: 2441
	// (Invoke) Token: 0x060052B8 RID: 21176
	public delegate void ErosionProgressDelegate(string titleString, string displayString, int iteration, int nIterations, float percentComplete);

	// Token: 0x0200098A RID: 2442
	// (Invoke) Token: 0x060052BC RID: 21180
	public delegate void TextureProgressDelegate(string titleString, string displayString, float percentComplete);

	// Token: 0x0200098B RID: 2443
	// (Invoke) Token: 0x060052C0 RID: 21184
	public delegate void GeneratorProgressDelegate(string titleString, string displayString, float percentComplete);
}
