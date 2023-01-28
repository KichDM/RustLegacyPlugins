using System;
using UnityEngine;

// Token: 0x020005BD RID: 1469
public class SimpleHitbox : global::BaseHitBox
{
	// Token: 0x0600305C RID: 12380 RVA: 0x000B8408 File Offset: 0x000B6608
	public SimpleHitbox()
	{
	}

	// Token: 0x0600305D RID: 12381 RVA: 0x000B8428 File Offset: 0x000B6628
	private void Start()
	{
		this.myCap = (base.collider as global::UnityEngine.CapsuleCollider);
		this.parent = base.transform.parent;
		this.root = this.parent.root;
		this.offset = global::UnityEngine.Vector3.zero;
		base.transform.parent = null;
		this.rootTransform = this.root.transform;
		this.myTransform = base.transform;
	}

	// Token: 0x0600305E RID: 12382 RVA: 0x000B849C File Offset: 0x000B669C
	private void Snap()
	{
		if (base.idMain.stateFlags.crouch != this.oldCrouch)
		{
			if (base.idMain.stateFlags.crouch)
			{
				this.myCap.height = this.crouchHeight;
			}
			else
			{
				this.myCap.height = this.standingHeight;
			}
			this.oldCrouch = base.idMain.stateFlags.crouch;
		}
		global::UnityEngine.Vector3 position = this.parent.TransformPoint(this.offset);
		position.y = this.rootTransform.position.y + this.myCap.height * 0.5f;
		this.myTransform.position = position;
	}

	// Token: 0x0600305F RID: 12383 RVA: 0x000B8560 File Offset: 0x000B6760
	private void Update()
	{
		if (!this.fixedUpdate)
		{
			this.Snap();
		}
	}

	// Token: 0x06003060 RID: 12384 RVA: 0x000B8574 File Offset: 0x000B6774
	private void FixedUpdate()
	{
		if (this.fixedUpdate)
		{
			this.Snap();
		}
	}

	// Token: 0x04001A05 RID: 6661
	private bool oldCrouch;

	// Token: 0x04001A06 RID: 6662
	private global::UnityEngine.CapsuleCollider myCap;

	// Token: 0x04001A07 RID: 6663
	public bool fixedUpdate;

	// Token: 0x04001A08 RID: 6664
	private global::UnityEngine.Transform parent;

	// Token: 0x04001A09 RID: 6665
	private global::UnityEngine.Transform root;

	// Token: 0x04001A0A RID: 6666
	private global::UnityEngine.Vector3 offset;

	// Token: 0x04001A0B RID: 6667
	public float crouchHeight = 1f;

	// Token: 0x04001A0C RID: 6668
	public float standingHeight = 1.85f;

	// Token: 0x04001A0D RID: 6669
	private global::UnityEngine.Transform rootTransform;

	// Token: 0x04001A0E RID: 6670
	private global::UnityEngine.Transform myTransform;
}
