using System;
using UnityEngine;

// Token: 0x0200013F RID: 319
public struct CharacterStateInterpolatorData
{
	// Token: 0x0600085E RID: 2142 RVA: 0x0002253C File Offset: 0x0002073C
	public static void Lerp(ref global::CharacterStateInterpolatorData a, ref global::CharacterStateInterpolatorData b, float t, out global::CharacterStateInterpolatorData result)
	{
		if (t == 0f)
		{
			result = a;
		}
		else if (t == 1f)
		{
			result = b;
		}
		else
		{
			float num = 1f - t;
			result.origin.x = a.origin.x * num + b.origin.x * t;
			result.origin.y = a.origin.y * num + b.origin.y * t;
			result.origin.z = a.origin.z * num + b.origin.z * t;
			result.eyesAngles = default(global::Angle2);
			result.eyesAngles.yaw = a.eyesAngles.yaw + global::UnityEngine.Mathf.DeltaAngle(a.eyesAngles.yaw, b.eyesAngles.yaw) * t;
			result.eyesAngles.pitch = global::UnityEngine.Mathf.DeltaAngle(0f, a.eyesAngles.pitch + global::UnityEngine.Mathf.DeltaAngle(a.eyesAngles.pitch, b.eyesAngles.pitch) * t);
			if (t > 1f)
			{
				result.state = b.state;
			}
			else if (t < 0f)
			{
				result.state = a.state;
			}
			else
			{
				result.state = a.state;
				result.state.flags = (result.state.flags | (ushort)((byte)(b.state.flags & 0x43)));
				if (result.state.grounded != b.state.grounded)
				{
					result.state.grounded = false;
				}
			}
		}
	}

	// Token: 0x04000650 RID: 1616
	public global::UnityEngine.Vector3 origin;

	// Token: 0x04000651 RID: 1617
	public global::Angle2 eyesAngles;

	// Token: 0x04000652 RID: 1618
	public global::CharacterStateFlags state;
}
