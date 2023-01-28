using System;
using Facepunch.Movement;
using Facepunch.Precision;
using UnityEngine;

// Token: 0x020000BA RID: 186
public class PlayerAnimation : global::IDLocalCharacter
{
	// Token: 0x060003B4 RID: 948 RVA: 0x00011DE0 File Offset: 0x0000FFE0
	public PlayerAnimation()
	{
	}

	// Token: 0x17000086 RID: 134
	// (get) Token: 0x060003B5 RID: 949 RVA: 0x00011DF0 File Offset: 0x0000FFF0
	public global::Socket.LocalSpace itemAttachment
	{
		get
		{
			if (!this._madeItemAttachment && base.idMain)
			{
				global::Socket.ConfigBodyPart socket = base.GetTrait<global::CharacterItemAttachmentTrait>().socket;
				if (socket == null)
				{
					return null;
				}
				this._madeItemAttachment = socket.Extract(ref this._itemAttachmentSocket, base.idMain.hitBoxSystem);
			}
			return this._itemAttachmentSocket;
		}
	}

	// Token: 0x060003B6 RID: 950 RVA: 0x00011E50 File Offset: 0x00010050
	private void OnDrawGizmosSelected()
	{
		if (this._itemAttachmentSocket != null)
		{
			this.itemAttachment.DrawGizmos("itemAttachment");
		}
		else
		{
			global::Socket.ConfigBodyPart socket = base.GetTrait<global::CharacterItemAttachmentTrait>().socket;
			if (socket != null)
			{
				try
				{
					if (socket.Extract(ref global::PlayerAnimation.EditorHelper.tempSocketForGizmos, base.GetComponentInChildren<global::HitBoxSystem>()))
					{
						global::PlayerAnimation.EditorHelper.tempSocketForGizmos.DrawGizmos("itemAttachment");
					}
				}
				finally
				{
					if (global::PlayerAnimation.EditorHelper.tempSocketForGizmos != null)
					{
						global::PlayerAnimation.EditorHelper.tempSocketForGizmos.parent = null;
					}
				}
			}
		}
	}

	// Token: 0x060003B7 RID: 951 RVA: 0x00011EEC File Offset: 0x000100EC
	[global::UnityEngine.ContextMenu("Rebind Item Attachment")]
	private void RebindItemAttachment()
	{
		if (this._itemAttachmentSocket != null)
		{
			this._itemAttachmentSocket.eulerRotate = base.GetTrait<global::CharacterItemAttachmentTrait>().socket.eulerRotate;
			this._itemAttachmentSocket.offset = base.GetTrait<global::CharacterItemAttachmentTrait>().socket.offset;
		}
	}

	// Token: 0x0400035A RID: 858
	public const double MIN_ANIM_SPEED = 0.05;

	// Token: 0x0400035B RID: 859
	[global::PrefetchComponent]
	public global::UnityEngine.Animation animation;

	// Token: 0x0400035C RID: 860
	[global::PrefetchComponent]
	public global::InventoryHolder itemHolder;

	// Token: 0x0400035D RID: 861
	private global::UnityEngine.Transform characterTransform;

	// Token: 0x0400035E RID: 862
	private global::UnityEngine.Vector3 localVelocity;

	// Token: 0x0400035F RID: 863
	private global::UnityEngine.Vector3 lastPos;

	// Token: 0x04000360 RID: 864
	private global::UnityEngine.Vector2 movementNormal;

	// Token: 0x04000361 RID: 865
	private global::UnityEngine.Vector4 times;

	// Token: 0x04000362 RID: 866
	private global::Facepunch.Movement.Weights lastHeadingWeights;

	// Token: 0x04000363 RID: 867
	private global::Facepunch.Movement.Weights baseDecay;

	// Token: 0x04000364 RID: 868
	private global::Facepunch.Precision.Vector3G localVelocityPrecise;

	// Token: 0x04000365 RID: 869
	private global::Facepunch.Precision.Vector3G lastPosPrecise;

	// Token: 0x04000366 RID: 870
	private global::Facepunch.Precision.Vector2G movementNormalPrecise;

	// Token: 0x04000367 RID: 871
	private double speedPrecise;

	// Token: 0x04000368 RID: 872
	private double anglePrecise;

	// Token: 0x04000369 RID: 873
	private double lastAngleSpeedPrecise;

	// Token: 0x0400036A RID: 874
	private float speed;

	// Token: 0x0400036B RID: 875
	private float angle;

	// Token: 0x0400036C RID: 876
	private float positionTime;

	// Token: 0x0400036D RID: 877
	private float lastUnitScale;

	// Token: 0x0400036E RID: 878
	private float lastVelocityCalc;

	// Token: 0x0400036F RID: 879
	private bool wasAirborne;

	// Token: 0x04000370 RID: 880
	private bool decaying;

	// Token: 0x04000371 RID: 881
	private global::Facepunch.Movement.Configuration configuration;

	// Token: 0x04000372 RID: 882
	[global::System.NonSerialized]
	private string idealGroupName;

	// Token: 0x04000373 RID: 883
	[global::System.NonSerialized]
	private string usingGroupName;

	// Token: 0x04000374 RID: 884
	[global::System.NonSerialized]
	private int usingGroupIndex;

	// Token: 0x04000375 RID: 885
	[global::System.NonSerialized]
	private global::CharacterAnimationTrait animationTrait;

	// Token: 0x04000376 RID: 886
	private bool _madeItemAttachment;

	// Token: 0x04000377 RID: 887
	private int group_unarmed;

	// Token: 0x04000378 RID: 888
	private int group_armed = 1;

	// Token: 0x04000379 RID: 889
	[global::System.NonSerialized]
	private global::Socket.LocalSpace _itemAttachmentSocket;

	// Token: 0x020000BB RID: 187
	private static class EditorHelper
	{
		// Token: 0x0400037A RID: 890
		public static global::Socket.LocalSpace tempSocketForGizmos;
	}
}
