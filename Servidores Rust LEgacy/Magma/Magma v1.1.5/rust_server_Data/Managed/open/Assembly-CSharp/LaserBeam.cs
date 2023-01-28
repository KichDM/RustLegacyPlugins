using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000726 RID: 1830
[global::UnityEngine.ExecuteInEditMode]
public sealed class LaserBeam : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06003E02 RID: 15874 RVA: 0x000D9308 File Offset: 0x000D7508
	public LaserBeam()
	{
	}

	// Token: 0x06003E03 RID: 15875 RVA: 0x000D9398 File Offset: 0x000D7598
	public static global::System.Collections.Generic.List<global::LaserBeam> Collect()
	{
		global::LaserBeam.g.currentRendering.Clear();
		global::LaserBeam.g.currentRendering.AddRange(global::LaserBeam.g.allActiveBeams);
		return global::LaserBeam.g.currentRendering;
	}

	// Token: 0x06003E04 RID: 15876 RVA: 0x000D93B8 File Offset: 0x000D75B8
	private void OnEnable()
	{
		global::LaserBeam.g.allActiveBeams.Add(this);
		global::LaserGraphics.EnsureGraphicsExist();
	}

	// Token: 0x06003E05 RID: 15877 RVA: 0x000D93CC File Offset: 0x000D75CC
	private void OnDisable()
	{
		global::LaserBeam.g.allActiveBeams.Remove(this);
	}

	// Token: 0x04001F52 RID: 8018
	public float beamMaxDistance = 100f;

	// Token: 0x04001F53 RID: 8019
	public global::UnityEngine.Vector4 beamColor = global::UnityEngine.Color.red;

	// Token: 0x04001F54 RID: 8020
	public float beamOutput = 1f;

	// Token: 0x04001F55 RID: 8021
	public float beamWidthStart = 0.1f;

	// Token: 0x04001F56 RID: 8022
	public float beamWidthEnd = 0.2f;

	// Token: 0x04001F57 RID: 8023
	public float dotRadiusStart = 0.15f;

	// Token: 0x04001F58 RID: 8024
	public float dotRadiusEnd = 0.25f;

	// Token: 0x04001F59 RID: 8025
	public bool isViewModel;

	// Token: 0x04001F5A RID: 8026
	public global::UnityEngine.Vector4 dotColor = global::UnityEngine.Color.red;

	// Token: 0x04001F5B RID: 8027
	public global::UnityEngine.Material beamMaterial;

	// Token: 0x04001F5C RID: 8028
	public global::UnityEngine.Material dotMaterial;

	// Token: 0x04001F5D RID: 8029
	public global::UnityEngine.LayerMask beamLayers = 1;

	// Token: 0x04001F5E RID: 8030
	public global::UnityEngine.LayerMask cullLayers = 1;

	// Token: 0x04001F5F RID: 8031
	public global::LaserBeam.FrameData frame;

	// Token: 0x02000727 RID: 1831
	public struct Quad<T>
	{
		// Token: 0x04001F60 RID: 8032
		public T m0;

		// Token: 0x04001F61 RID: 8033
		public T m1;

		// Token: 0x04001F62 RID: 8034
		public T m2;

		// Token: 0x04001F63 RID: 8035
		public T m3;
	}

	// Token: 0x02000728 RID: 1832
	public struct FrameData
	{
		// Token: 0x04001F64 RID: 8036
		public global::UnityEngine.MaterialPropertyBlock block;

		// Token: 0x04001F65 RID: 8037
		public global::UnityEngine.Bounds bounds;

		// Token: 0x04001F66 RID: 8038
		public bool hit;

		// Token: 0x04001F67 RID: 8039
		public global::UnityEngine.Vector3 hitPoint;

		// Token: 0x04001F68 RID: 8040
		public global::UnityEngine.Vector3 hitNormal;

		// Token: 0x04001F69 RID: 8041
		public global::LaserBeam.Quad<global::UnityEngine.Vector3> beamVertices;

		// Token: 0x04001F6A RID: 8042
		public global::LaserBeam.Quad<global::UnityEngine.Vector3> beamNormals;

		// Token: 0x04001F6B RID: 8043
		public global::LaserBeam.Quad<global::UnityEngine.Vector2> beamUVs;

		// Token: 0x04001F6C RID: 8044
		public global::LaserBeam.Quad<global::UnityEngine.Vector3> dotVertices1;

		// Token: 0x04001F6D RID: 8045
		public global::LaserBeam.Quad<global::UnityEngine.Vector3> dotVertices2;

		// Token: 0x04001F6E RID: 8046
		public global::LaserBeam.Quad<global::UnityEngine.Color> beamColor;

		// Token: 0x04001F6F RID: 8047
		public global::LaserBeam.Quad<global::UnityEngine.Color> dotColor1;

		// Token: 0x04001F70 RID: 8048
		public global::LaserBeam.Quad<global::UnityEngine.Color> dotColor2;

		// Token: 0x04001F71 RID: 8049
		public global::UnityEngine.Vector3 direction;

		// Token: 0x04001F72 RID: 8050
		public global::UnityEngine.Vector3 origin;

		// Token: 0x04001F73 RID: 8051
		public global::UnityEngine.Vector3 point;

		// Token: 0x04001F74 RID: 8052
		public float distance;

		// Token: 0x04001F75 RID: 8053
		public float distanceFraction;

		// Token: 0x04001F76 RID: 8054
		public float pointWidth;

		// Token: 0x04001F77 RID: 8055
		public float originWidth;

		// Token: 0x04001F78 RID: 8056
		public float dotRadius;

		// Token: 0x04001F79 RID: 8057
		public bool didHit;

		// Token: 0x04001F7A RID: 8058
		public bool drawDot;

		// Token: 0x04001F7B RID: 8059
		public int beamsLayer;

		// Token: 0x04001F7C RID: 8060
		internal global::LaserGraphics.MeshBuffer bufBeam;

		// Token: 0x04001F7D RID: 8061
		internal global::LaserGraphics.MeshBuffer bufDot;
	}

	// Token: 0x02000729 RID: 1833
	private static class g
	{
		// Token: 0x06003E06 RID: 15878 RVA: 0x000D93DC File Offset: 0x000D75DC
		// Note: this type is marked as 'beforefieldinit'.
		static g()
		{
		}

		// Token: 0x04001F7E RID: 8062
		public static global::System.Collections.Generic.HashSet<global::LaserBeam> allActiveBeams = new global::System.Collections.Generic.HashSet<global::LaserBeam>();

		// Token: 0x04001F7F RID: 8063
		public static global::System.Collections.Generic.List<global::LaserBeam> currentRendering = new global::System.Collections.Generic.List<global::LaserBeam>();
	}
}
