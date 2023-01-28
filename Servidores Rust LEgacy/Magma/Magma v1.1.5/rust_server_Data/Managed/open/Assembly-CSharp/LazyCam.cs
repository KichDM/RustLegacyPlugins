using System;
using UnityEngine;

// Token: 0x02000731 RID: 1841
[global::UnityEngine.RequireComponent(typeof(global::UnityEngine.Camera))]
public class LazyCam : global::UnityEngine.MonoBehaviour, global::ICameraFX
{
	// Token: 0x06003E24 RID: 15908 RVA: 0x000DB71C File Offset: 0x000D991C
	public LazyCam()
	{
	}

	// Token: 0x04001FA6 RID: 8102
	private global::UnityEngine.Quaternion aim;

	// Token: 0x04001FA7 RID: 8103
	private global::UnityEngine.Quaternion view;

	// Token: 0x04001FA8 RID: 8104
	private global::UnityEngine.Quaternion sub;

	// Token: 0x04001FA9 RID: 8105
	private global::UnityEngine.Quaternion add;

	// Token: 0x04001FAA RID: 8106
	public float maxAngle = 10f;

	// Token: 0x04001FAB RID: 8107
	public float damp = 0.01f;

	// Token: 0x04001FAC RID: 8108
	public float targetAngle = 10f;

	// Token: 0x04001FAD RID: 8109
	public float enableSeconds = 0.1f;

	// Token: 0x04001FAE RID: 8110
	public float disableSeconds = 0.1f;

	// Token: 0x04001FAF RID: 8111
	private float enableFraction;

	// Token: 0x04001FB0 RID: 8112
	[global::System.NonSerialized]
	private bool isActivelyLazy;

	// Token: 0x04001FB1 RID: 8113
	[global::System.NonSerialized]
	private bool wasActivelyLazy;

	// Token: 0x04001FB2 RID: 8114
	[global::System.NonSerialized]
	private global::UnityEngine.Matrix4x4 _world2cam;

	// Token: 0x04001FB3 RID: 8115
	[global::System.NonSerialized]
	private global::UnityEngine.Matrix4x4 _cam2world;

	// Token: 0x04001FB4 RID: 8116
	[global::System.NonSerialized]
	private float vel;

	// Token: 0x04001FB5 RID: 8117
	[global::System.NonSerialized]
	private global::UnityEngine.Camera camera;

	// Token: 0x04001FB6 RID: 8118
	[global::System.NonSerialized]
	private global::UnityEngine.Transform transform;

	// Token: 0x04001FB7 RID: 8119
	private bool _allow;

	// Token: 0x04001FB8 RID: 8120
	private global::ViewModel viewModel;

	// Token: 0x04001FB9 RID: 8121
	private bool hasViewModel;
}
