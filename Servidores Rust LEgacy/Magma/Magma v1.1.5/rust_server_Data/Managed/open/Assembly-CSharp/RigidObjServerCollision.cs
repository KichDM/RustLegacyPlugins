using System;
using UnityEngine;

// Token: 0x0200042E RID: 1070
[global::UnityEngine.AddComponentMenu("")]
public sealed class RigidObjServerCollision : global::UnityEngine.MonoBehaviour
{
	// Token: 0x0600253E RID: 9534 RVA: 0x0008E65C File Offset: 0x0008C85C
	public RigidObjServerCollision()
	{
	}

	// Token: 0x0600253F RID: 9535 RVA: 0x0008E664 File Offset: 0x0008C864
	private void OnCollisionEnter(global::UnityEngine.Collision collision)
	{
		if (this.rigidObj)
		{
			this.rigidObj.OnServerCollision(0, collision);
		}
	}

	// Token: 0x06002540 RID: 9536 RVA: 0x0008E684 File Offset: 0x0008C884
	private void OnCollisionExit(global::UnityEngine.Collision collision)
	{
		if (this.rigidObj)
		{
			this.rigidObj.OnServerCollision(1, collision);
		}
	}

	// Token: 0x06002541 RID: 9537 RVA: 0x0008E6A4 File Offset: 0x0008C8A4
	private void OnCollisionStay(global::UnityEngine.Collision collision)
	{
		if (this.rigidObj)
		{
			this.rigidObj.OnServerCollision(2, collision);
		}
	}

	// Token: 0x040012FC RID: 4860
	public const byte Enter = 0;

	// Token: 0x040012FD RID: 4861
	public const byte Exit = 1;

	// Token: 0x040012FE RID: 4862
	public const byte Stay = 2;

	// Token: 0x040012FF RID: 4863
	[global::System.NonSerialized]
	public global::RigidObj rigidObj;
}
