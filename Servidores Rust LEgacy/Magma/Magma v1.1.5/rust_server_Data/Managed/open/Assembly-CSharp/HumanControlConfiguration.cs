using System;
using UnityEngine;

// Token: 0x02000178 RID: 376
public class HumanControlConfiguration : global::ControlConfiguration
{
	// Token: 0x06000A58 RID: 2648 RVA: 0x0002A5D0 File Offset: 0x000287D0
	public HumanControlConfiguration()
	{
	}

	// Token: 0x1700029F RID: 671
	// (get) Token: 0x06000A59 RID: 2649 RVA: 0x0002A730 File Offset: 0x00028930
	public global::UnityEngine.AnimationCurve curveSprintAddSpeedByTime
	{
		get
		{
			return this.sprintAddSpeedByTime;
		}
	}

	// Token: 0x170002A0 RID: 672
	// (get) Token: 0x06000A5A RID: 2650 RVA: 0x0002A738 File Offset: 0x00028938
	public global::UnityEngine.AnimationCurve curveCrouchMulSpeedByTime
	{
		get
		{
			return this.crouchMulSpeedByTime;
		}
	}

	// Token: 0x170002A1 RID: 673
	// (get) Token: 0x06000A5B RID: 2651 RVA: 0x0002A740 File Offset: 0x00028940
	public global::UnityEngine.AnimationCurve curveLandingSpeedPenalty
	{
		get
		{
			return this.landingSpeedPenalty;
		}
	}

	// Token: 0x170002A2 RID: 674
	// (get) Token: 0x06000A5C RID: 2652 RVA: 0x0002A748 File Offset: 0x00028948
	public float sprintScaleX
	{
		get
		{
			return this.sprintScalars.x;
		}
	}

	// Token: 0x170002A3 RID: 675
	// (get) Token: 0x06000A5D RID: 2653 RVA: 0x0002A758 File Offset: 0x00028958
	public float sprintScaleY
	{
		get
		{
			return this.sprintScalars.y;
		}
	}

	// Token: 0x170002A4 RID: 676
	// (get) Token: 0x06000A5E RID: 2654 RVA: 0x0002A768 File Offset: 0x00028968
	public global::UnityEngine.Vector2 sprintScale
	{
		get
		{
			return this.sprintScalars;
		}
	}

	// Token: 0x0400078F RID: 1935
	[global::UnityEngine.SerializeField]
	private global::UnityEngine.AnimationCurve sprintAddSpeedByTime = new global::UnityEngine.AnimationCurve(new global::UnityEngine.Keyframe[]
	{
		new global::UnityEngine.Keyframe(0f, 0f, 0f, 0f),
		new global::UnityEngine.Keyframe(0.4f, 1f, 0f, 0f)
	});

	// Token: 0x04000790 RID: 1936
	[global::UnityEngine.SerializeField]
	private global::UnityEngine.AnimationCurve crouchMulSpeedByTime = new global::UnityEngine.AnimationCurve(new global::UnityEngine.Keyframe[]
	{
		new global::UnityEngine.Keyframe(0f, 1f, 0f, 0f),
		new global::UnityEngine.Keyframe(0.4f, 0.55f, 0f, 0f)
	});

	// Token: 0x04000791 RID: 1937
	[global::UnityEngine.SerializeField]
	private global::UnityEngine.AnimationCurve landingSpeedPenalty = new global::UnityEngine.AnimationCurve(new global::UnityEngine.Keyframe[]
	{
		new global::UnityEngine.Keyframe(0f, 1f, 0f, 0f),
		new global::UnityEngine.Keyframe(0.25f, 0.5f, -2f, -2f),
		new global::UnityEngine.Keyframe(0.75f, 1f, 0f, 0f)
	});

	// Token: 0x04000792 RID: 1938
	[global::UnityEngine.SerializeField]
	private global::UnityEngine.Vector2 sprintScalars = new global::UnityEngine.Vector2(0.2f, 1f);
}
