using System;
using UnityEngine;

// Token: 0x020007D1 RID: 2001
[global::UnityEngine.AddComponentMenu("Water/Mesher")]
public class WaterMesher : global::UnityEngine.MonoBehaviour
{
	// Token: 0x0600422A RID: 16938 RVA: 0x000F0748 File Offset: 0x000EE948
	public WaterMesher()
	{
	}

	// Token: 0x17000C23 RID: 3107
	// (get) Token: 0x0600422B RID: 16939 RVA: 0x000F0750 File Offset: 0x000EE950
	// (set) Token: 0x0600422C RID: 16940 RVA: 0x000F0798 File Offset: 0x000EE998
	public global::UnityEngine.Vector2 position
	{
		get
		{
			global::UnityEngine.Vector3 position = base.transform.position;
			position.y = position.z;
			position.z = 0f;
			return new global::UnityEngine.Vector2(position.x, position.y);
		}
		set
		{
			global::UnityEngine.Vector3 position = base.transform.position;
			position.x = value.x;
			position.z = value.y;
			base.transform.position = position;
		}
	}

	// Token: 0x17000C24 RID: 3108
	// (get) Token: 0x0600422D RID: 16941 RVA: 0x000F07DC File Offset: 0x000EE9DC
	public global::UnityEngine.Vector3 position3
	{
		get
		{
			return base.transform.position;
		}
	}

	// Token: 0x0600422E RID: 16942 RVA: 0x000F07EC File Offset: 0x000EE9EC
	public global::UnityEngine.Vector2 Point(float t, global::UnityEngine.Vector2 p3)
	{
		global::UnityEngine.Vector2 position = this.position;
		global::UnityEngine.Vector2 vector = position + this.inTangent;
		global::UnityEngine.Vector2 vector2 = p3 + this.outTangent;
		float num = 1f - t;
		position.x = position.x * num + vector.x * t;
		position.y = position.y * num + vector.y * t;
		vector.x = vector.x * num + vector2.x * t;
		vector.y = vector.y * num + vector2.y * t;
		vector2.x = vector2.x * num + p3.x * t;
		vector2.y = vector2.y * num + p3.y * t;
		position.x = position.x * num + vector.x * t;
		position.y = position.y * num + vector.y * t;
		vector.x = vector.x * num + vector2.x * t;
		vector.y = vector.y * num + vector2.y * t;
		position.x = position.x * num + vector.x * t;
		position.y = position.y * num + vector.y * t;
		return position;
	}

	// Token: 0x17000C25 RID: 3109
	// (get) Token: 0x0600422F RID: 16943 RVA: 0x000F095C File Offset: 0x000EEB5C
	public global::UnityEngine.Vector2 smoothInTangent
	{
		get
		{
			return (!this.prev) ? this.inTangent : ((this.inTangent - this.prev.outTangent) / 2f);
		}
	}

	// Token: 0x17000C26 RID: 3110
	// (get) Token: 0x06004230 RID: 16944 RVA: 0x000F099C File Offset: 0x000EEB9C
	public global::UnityEngine.Vector2 smoothOutTangent
	{
		get
		{
			return (!this.next) ? this.inTangent : ((this.outTangent - this.next.inTangent) / 2f);
		}
	}

	// Token: 0x06004231 RID: 16945 RVA: 0x000F09DC File Offset: 0x000EEBDC
	public global::UnityEngine.Vector2 SmoothPoint(float t, global::UnityEngine.Vector2 p3)
	{
		global::UnityEngine.Vector2 position = this.position;
		global::UnityEngine.Vector2 vector = position + this.smoothInTangent;
		global::UnityEngine.Vector2 vector2 = p3 + this.smoothOutTangent;
		float num = 1f - t;
		position.x = position.x * num + vector.x * t;
		position.y = position.y * num + vector.y * t;
		vector.x = vector.x * num + vector2.x * t;
		vector.y = vector.y * num + vector2.y * t;
		vector2.x = vector2.x * num + p3.x * t;
		vector2.y = vector2.y * num + p3.y * t;
		position.x = position.x * num + vector.x * t;
		position.y = position.y * num + vector.y * t;
		vector.x = vector.x * num + vector2.x * t;
		vector.y = vector.y * num + vector2.y * t;
		position.x = position.x * num + vector.x * t;
		position.y = position.y * num + vector.y * t;
		return position;
	}

	// Token: 0x06004232 RID: 16946 RVA: 0x000F0B4C File Offset: 0x000EED4C
	public global::UnityEngine.Vector3 Point3(float t, global::UnityEngine.Vector2 p3)
	{
		global::UnityEngine.Vector2 vector = this.Point(t, p3);
		global::UnityEngine.Vector3 result;
		result.x = vector.x;
		result.y = base.transform.position.y;
		result.z = vector.y;
		return result;
	}

	// Token: 0x04002361 RID: 9057
	private const int kPoints = 0x10;

	// Token: 0x04002362 RID: 9058
	public global::WaterMesher next;

	// Token: 0x04002363 RID: 9059
	public global::WaterMesher prev;

	// Token: 0x04002364 RID: 9060
	public global::UnityEngine.Vector2 inTangent;

	// Token: 0x04002365 RID: 9061
	public global::UnityEngine.Vector2 outTangent;

	// Token: 0x04002366 RID: 9062
	public bool isRoot;
}
