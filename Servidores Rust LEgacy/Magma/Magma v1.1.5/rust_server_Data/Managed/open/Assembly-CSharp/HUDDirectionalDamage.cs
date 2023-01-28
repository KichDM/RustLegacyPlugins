using System;
using UnityEngine;

// Token: 0x020005E2 RID: 1506
public class HUDDirectionalDamage : global::HUDIndicator
{
	// Token: 0x060030EB RID: 12523 RVA: 0x000BA558 File Offset: 0x000B8758
	public HUDDirectionalDamage()
	{
	}

	// Token: 0x04001AAB RID: 6827
	[global::UnityEngine.SerializeField]
	private global::UnityEngine.Material skeletonMaterial;

	// Token: 0x04001AAC RID: 6828
	private global::UnityEngine.Vector4 lastBoundMin;

	// Token: 0x04001AAD RID: 6829
	private global::UnityEngine.Vector4 lastBoundMax;

	// Token: 0x04001AAE RID: 6830
	[global::System.NonSerialized]
	public global::UnityEngine.Vector3 worldDirection = global::UnityEngine.Vector3.left;

	// Token: 0x04001AAF RID: 6831
	[global::System.NonSerialized]
	public double damageTime;

	// Token: 0x04001AB0 RID: 6832
	[global::System.NonSerialized]
	public double duration;

	// Token: 0x04001AB1 RID: 6833
	[global::System.NonSerialized]
	public double damageAmount;

	// Token: 0x04001AB2 RID: 6834
	private global::UnityEngine.Vector4 randMin;

	// Token: 0x04001AB3 RID: 6835
	private global::UnityEngine.Vector4 randMax;

	// Token: 0x04001AB4 RID: 6836
	private double speedModX;

	// Token: 0x04001AB5 RID: 6837
	private double speedModY;

	// Token: 0x04001AB6 RID: 6838
	private double speedModZ;

	// Token: 0x04001AB7 RID: 6839
	private double speedModW;

	// Token: 0x04001AB8 RID: 6840
	private bool swapX;

	// Token: 0x04001AB9 RID: 6841
	private bool swapY;

	// Token: 0x04001ABA RID: 6842
	private bool swapZ;

	// Token: 0x04001ABB RID: 6843
	private bool inverseX;

	// Token: 0x04001ABC RID: 6844
	private bool inverseY;

	// Token: 0x04001ABD RID: 6845
	private bool inverseZ;

	// Token: 0x04001ABE RID: 6846
	[global::UnityEngine.SerializeField]
	private global::UIPanel panel;

	// Token: 0x04001ABF RID: 6847
	[global::UnityEngine.SerializeField]
	private global::UITexture texture;
}
