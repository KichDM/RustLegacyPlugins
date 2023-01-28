using System;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x0200098C RID: 2444
public class TOD_Animation : global::UnityEngine.MonoBehaviour
{
	// Token: 0x060052C3 RID: 21187 RVA: 0x00158D94 File Offset: 0x00156F94
	public TOD_Animation()
	{
	}

	// Token: 0x17000F7A RID: 3962
	// (get) Token: 0x060052C4 RID: 21188 RVA: 0x00158DA8 File Offset: 0x00156FA8
	// (set) Token: 0x060052C5 RID: 21189 RVA: 0x00158DB0 File Offset: 0x00156FB0
	internal global::UnityEngine.Vector4 CloudUV
	{
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		get
		{
			return this.<CloudUV>k__BackingField;
		}
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		set
		{
			this.<CloudUV>k__BackingField = value;
		}
	}

	// Token: 0x17000F7B RID: 3963
	// (get) Token: 0x060052C6 RID: 21190 RVA: 0x00158DBC File Offset: 0x00156FBC
	internal global::UnityEngine.Vector4 OffsetUV
	{
		get
		{
			global::UnityEngine.Vector3 position = base.transform.position;
			global::UnityEngine.Vector3 lossyScale = base.transform.lossyScale;
			global::UnityEngine.Vector3 vector;
			vector..ctor(position.x / lossyScale.x, 0f, position.z / lossyScale.z);
			vector = -base.transform.TransformDirection(vector);
			return new global::UnityEngine.Vector4(vector.x, vector.z, vector.x, vector.z);
		}
	}

	// Token: 0x060052C7 RID: 21191 RVA: 0x00158E40 File Offset: 0x00157040
	protected void Update()
	{
		global::UnityEngine.Vector2 vector;
		vector..ctor(global::UnityEngine.Mathf.Cos(0.017453292f * (this.WindDegrees + 15f)), global::UnityEngine.Mathf.Sin(0.017453292f * (this.WindDegrees + 15f)));
		global::UnityEngine.Vector2 vector2;
		vector2..ctor(global::UnityEngine.Mathf.Cos(0.017453292f * (this.WindDegrees - 15f)), global::UnityEngine.Mathf.Sin(0.017453292f * (this.WindDegrees - 15f)));
		global::UnityEngine.Vector4 vector3 = this.WindSpeed / 100f * new global::UnityEngine.Vector4(vector.x, vector.y, vector2.x, vector2.y);
		this.CloudUV += global::UnityEngine.Time.deltaTime * vector3;
	}

	// Token: 0x04002FB2 RID: 12210
	public float WindDegrees;

	// Token: 0x04002FB3 RID: 12211
	public float WindSpeed = 3f;

	// Token: 0x04002FB4 RID: 12212
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private global::UnityEngine.Vector4 <CloudUV>k__BackingField;
}
