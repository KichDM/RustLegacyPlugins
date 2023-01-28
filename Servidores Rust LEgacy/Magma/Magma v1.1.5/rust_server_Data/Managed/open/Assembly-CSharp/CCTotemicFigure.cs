using System;
using UnityEngine;

// Token: 0x0200031B RID: 795
[global::UnityEngine.AddComponentMenu("")]
[global::UnityEngine.RequireComponent(typeof(global::CCDesc))]
public sealed class CCTotemicFigure : global::CCTotem<global::CCTotem.TotemicFigure, global::CCTotemicFigure>
{
	// Token: 0x06001ADF RID: 6879 RVA: 0x00069FEC File Offset: 0x000681EC
	public CCTotemicFigure()
	{
	}

	// Token: 0x06001AE0 RID: 6880 RVA: 0x00069FF4 File Offset: 0x000681F4
	private void OnDrawGizmos()
	{
		if (this.totemicObject != null)
		{
			float num = 3.1415927f * global::UnityEngine.Time.time + 0.7853982f * (float)this.totemicObject.BottomUpIndex;
			global::UnityEngine.Vector3 vector = global::UnityEngine.Camera.current.cameraToWorldMatrix.MultiplyVector(new global::UnityEngine.Vector3(global::UnityEngine.Mathf.Sin(num) * 0.25f + 0.75f, 0f, 0f));
			global::UnityEngine.Vector3 vector2 = -vector;
			global::UnityEngine.Gizmos.color = global::UnityEngine.Color.green;
			global::UnityEngine.Gizmos.DrawLine(this.totemicObject.TopOrigin, this.totemicObject.TopOrigin + vector);
			global::UnityEngine.Gizmos.DrawLine(this.totemicObject.SlideTopOrigin + vector, this.totemicObject.TopOrigin + vector);
			global::UnityEngine.Gizmos.color = global::UnityEngine.Color.blue;
			global::UnityEngine.Gizmos.DrawLine(this.totemicObject.BottomOrigin, this.totemicObject.BottomOrigin + vector2);
			global::UnityEngine.Gizmos.DrawLine(this.totemicObject.BottomOrigin + vector2, this.totemicObject.SlideBottomOrigin + vector2);
			global::UnityEngine.Gizmos.color = (((this.totemicObject.BottomUpIndex & 1) != 1) ? global::UnityEngine.Color.red : new global::UnityEngine.Color(1f, 0.4f, 0.4f, 1f));
			global::UnityEngine.Gizmos.DrawLine(this.totemicObject.SlideBottomOrigin + vector, this.totemicObject.SlideBottomOrigin + vector2);
			global::UnityEngine.Gizmos.DrawLine(this.totemicObject.SlideTopOrigin + vector, this.totemicObject.SlideTopOrigin + vector2);
			global::UnityEngine.Gizmos.DrawLine(this.totemicObject.SlideBottomOrigin + vector2, this.totemicObject.SlideTopOrigin + vector2);
			global::UnityEngine.Gizmos.DrawLine(this.totemicObject.SlideBottomOrigin + vector, this.totemicObject.SlideTopOrigin + vector);
		}
	}
}
