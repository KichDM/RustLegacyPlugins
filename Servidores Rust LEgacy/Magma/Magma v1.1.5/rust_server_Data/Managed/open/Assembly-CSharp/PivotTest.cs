using System;
using UnityEngine;

// Token: 0x020007C0 RID: 1984
[global::UnityEngine.ExecuteInEditMode]
public class PivotTest : global::UnityEngine.MonoBehaviour
{
	// Token: 0x060041DD RID: 16861 RVA: 0x000EE5DC File Offset: 0x000EC7DC
	public PivotTest()
	{
	}

	// Token: 0x060041DE RID: 16862 RVA: 0x000EE5E4 File Offset: 0x000EC7E4
	public void Update()
	{
		if (this.child)
		{
			global::UnityEngine.Quaternion quaternion = global::UnityEngine.Quaternion.Euler(this.pivotAngles);
			global::UnityEngine.Vector3 vector = quaternion * -this.pivot + this.pivot;
			vector += this.offsetTranslation;
			this.child.localRotation = quaternion;
			this.child.localPosition = vector;
		}
	}

	// Token: 0x060041DF RID: 16863 RVA: 0x000EE650 File Offset: 0x000EC850
	private void OnDrawGizmos()
	{
		global::UnityEngine.Gizmos.matrix = base.transform.localToWorldMatrix;
		global::UnityEngine.Gizmos.DrawWireSphere(this.pivot, 0.01f);
		global::UnityEngine.Gizmos.color = new global::UnityEngine.Color(0f, 0f, 0f, 0.5f);
		global::UnityEngine.Gizmos.DrawLine(global::UnityEngine.Vector3.zero, this.offsetTranslation);
		global::UnityEngine.Quaternion quaternion = global::UnityEngine.Quaternion.Euler(this.pivotAngles);
		global::UnityEngine.Gizmos.color = new global::UnityEngine.Color(0.5f, 0.5f, 0.5f, 0.5f);
		global::UnityEngine.Gizmos.DrawLine(this.offsetTranslation, quaternion * -this.pivot + this.pivot + this.offsetTranslation);
		global::UnityEngine.Gizmos.matrix *= global::UnityEngine.Matrix4x4.TRS(this.pivot + this.offsetTranslation, global::UnityEngine.Quaternion.Euler(this.pivotAngles), global::UnityEngine.Vector3.one);
		global::UnityEngine.Gizmos.color = global::UnityEngine.Color.blue;
		global::UnityEngine.Gizmos.DrawLine(global::UnityEngine.Vector3.zero, global::UnityEngine.Vector3.forward);
		global::UnityEngine.Gizmos.color = global::UnityEngine.Color.red;
		global::UnityEngine.Gizmos.DrawLine(global::UnityEngine.Vector3.zero, global::UnityEngine.Vector3.right);
		global::UnityEngine.Gizmos.color = global::UnityEngine.Color.green;
		global::UnityEngine.Gizmos.DrawLine(global::UnityEngine.Vector3.zero, global::UnityEngine.Vector3.up);
		if (this.child)
		{
			global::UnityEngine.Gizmos.matrix = this.child.localToWorldMatrix;
			global::UnityEngine.Gizmos.color = global::UnityEngine.Color.white;
			global::UnityEngine.Gizmos.DrawWireCube(global::UnityEngine.Vector3.zero, new global::UnityEngine.Vector3(0.02f, 0.02f, 0.02f));
			global::UnityEngine.Gizmos.color = global::UnityEngine.Color.blue;
			global::UnityEngine.Gizmos.DrawLine(global::UnityEngine.Vector3.zero, global::UnityEngine.Vector3.forward);
			global::UnityEngine.Gizmos.color = global::UnityEngine.Color.red;
			global::UnityEngine.Gizmos.DrawLine(global::UnityEngine.Vector3.zero, global::UnityEngine.Vector3.right);
			global::UnityEngine.Gizmos.color = global::UnityEngine.Color.green;
			global::UnityEngine.Gizmos.DrawLine(global::UnityEngine.Vector3.zero, global::UnityEngine.Vector3.up);
		}
	}

	// Token: 0x0400228F RID: 8847
	public global::UnityEngine.Transform child;

	// Token: 0x04002290 RID: 8848
	public global::UnityEngine.Vector3 pivot;

	// Token: 0x04002291 RID: 8849
	public global::UnityEngine.Vector3 pivotAngles;

	// Token: 0x04002292 RID: 8850
	public global::UnityEngine.Vector3 offsetTranslation;

	// Token: 0x04002293 RID: 8851
	public global::UnityEngine.Vector3 offsetRotation;
}
