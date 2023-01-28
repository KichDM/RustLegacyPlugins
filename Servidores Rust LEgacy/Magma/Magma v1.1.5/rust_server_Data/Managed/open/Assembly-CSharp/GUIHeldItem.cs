using System;
using UnityEngine;

// Token: 0x0200050A RID: 1290
public class GUIHeldItem : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06002C31 RID: 11313 RVA: 0x000A6538 File Offset: 0x000A4738
	public GUIHeldItem()
	{
	}

	// Token: 0x06002C32 RID: 11314 RVA: 0x000A654C File Offset: 0x000A474C
	public static global::GUIHeldItem Get()
	{
		return global::GUIHeldItem._guiHeldItem;
	}

	// Token: 0x06002C33 RID: 11315 RVA: 0x000A6554 File Offset: 0x000A4754
	public static global::IInventoryItem CurrentItem()
	{
		return global::GUIHeldItem.Get()._itemHolding;
	}

	// Token: 0x06002C34 RID: 11316 RVA: 0x000A6560 File Offset: 0x000A4760
	private void Start()
	{
		this.startingIconColor = this._icon.color;
		this._icon.enabled = false;
		global::GUIHeldItem._guiHeldItem = this;
		this._myMaterial = this._icon.material.Clone();
		this._icon.material = this._myMaterial;
		this.mTrans = base.transform;
		if (this.uiCamera == null)
		{
			this.uiCamera = global::NGUITools.FindCameraForLayer(base.gameObject.layer);
		}
		this.planeTest = new global::UnityEngine.Plane(this.uiCamera.transform.forward * 1f, new global::UnityEngine.Vector3(0f, 0f, 2f));
		this.started = true;
	}

	// Token: 0x06002C35 RID: 11317 RVA: 0x000A662C File Offset: 0x000A482C
	private void OnDestroy()
	{
		global::UnityEngine.Object.Destroy(this._myMaterial);
	}

	// Token: 0x06002C36 RID: 11318 RVA: 0x000A663C File Offset: 0x000A483C
	private void SetPosition(global::UnityEngine.Vector3 world)
	{
		global::UnityEngine.Vector3 localPosition = this.mTrans.localPosition + this.mTrans.InverseTransformPoint(world);
		localPosition.z = -190f;
		this.mTrans.localPosition = localPosition;
	}

	// Token: 0x06002C37 RID: 11319 RVA: 0x000A6680 File Offset: 0x000A4880
	private void Update()
	{
		if (this.hasItem)
		{
			global::UnityEngine.Vector3 vector = global::UICamera.lastMousePosition + this.offsetPoint;
			global::UnityEngine.Ray ray = this.uiCamera.ScreenPointToRay(vector);
			float num = 0f;
			if (this.planeTest.Raycast(ray, ref num))
			{
				this.SetPosition(ray.GetPoint(num));
			}
			this.offsetPoint = global::UnityEngine.Vector3.SmoothDamp(this.offsetPoint, global::UnityEngine.Vector3.zero, ref this.offsetVelocity, 0.06f, 600f);
		}
		else if (this.fadingOut)
		{
			this.fadeOutPoint = global::UnityEngine.Vector3.SmoothDamp(this.fadeOutPoint, this.fadeOutPointEnd, ref this.fadeOutVelocity, 0.1f, 50f);
			this.fadeOutAlpha = this.startingIconColor.a * (1f - global::UnityEngine.Mathf.Clamp01(global::UnityEngine.Mathf.Abs(global::UnityEngine.Vector3.Dot(this.fadeOutPointNormal, this.fadeOutPoint) - this.fadeOutPointDistance) / this.fadeOutPointMagnitude));
			if ((double)this.fadeOutAlpha <= 0.00390625)
			{
				this.fadingOut = false;
				this.MakeEmpty();
			}
			else
			{
				global::UnityEngine.Color color = this._icon.color;
				this.SetPosition(this.fadeOutPoint);
				color.a = this.fadeOutAlpha;
				this._icon.color = color;
			}
		}
	}

	// Token: 0x06002C38 RID: 11320 RVA: 0x000A67E8 File Offset: 0x000A49E8
	private void Opaque()
	{
		this.fadeOutAlpha = 1f;
		this.fadeOutPointStart = global::UnityEngine.Vector3.zero;
		this.fadeOutPointEnd = global::UnityEngine.Vector3.right;
		this.fadeOutPointDistance = 1f;
		this.fadeOutPointMagnitude = 1f;
		this.fadeOutPointNormal = global::UnityEngine.Vector3.right;
		this.fadeOutVelocity = global::UnityEngine.Vector3.zero;
		this.fadingOut = false;
		if (this.started)
		{
			this._icon.color = this.startingIconColor;
		}
	}

	// Token: 0x06002C39 RID: 11321 RVA: 0x000A6868 File Offset: 0x000A4A68
	public bool SetHeldItem(global::IInventoryItem item)
	{
		if (item == null)
		{
			this.MakeEmpty();
			if (!this.fadingOut)
			{
				this.Opaque();
			}
			return false;
		}
		this.hasItem = true;
		global::UnityEngine.Texture iconTex = item.datablock.iconTex;
		global::ItemDataBlock.LoadIconOrUnknown<global::UnityEngine.Texture>(item.datablock.icon, ref iconTex);
		this._icon.enabled = true;
		this._myMaterial.Set("_MainTex", iconTex);
		this._itemHolding = item;
		this.offsetVelocity = (this.offsetPoint = default(global::UnityEngine.Vector2));
		this.Opaque();
		return true;
	}

	// Token: 0x06002C3A RID: 11322 RVA: 0x000A6904 File Offset: 0x000A4B04
	public bool SetHeldItem(global::RPOSInventoryCell cell)
	{
		global::IInventoryItem heldItem;
		if (cell)
		{
			global::IInventoryItem slotItem = cell.slotItem;
			heldItem = slotItem;
		}
		else
		{
			heldItem = null;
		}
		if (this.SetHeldItem(heldItem))
		{
			try
			{
				global::UnityEngine.Vector3 vector;
				if (global::NGUITools.GetCentroid(cell, out vector))
				{
					global::UnityEngine.Vector2 vector2 = global::UICamera.FindCameraForLayer(cell.gameObject.layer).cachedCamera.WorldToScreenPoint(vector);
					this.offsetPoint = vector2 - global::UICamera.lastMousePosition;
				}
			}
			catch
			{
				this.offsetPoint = global::UnityEngine.Vector3.zero;
			}
			return true;
		}
		return false;
	}

	// Token: 0x06002C3B RID: 11323 RVA: 0x000A69B0 File Offset: 0x000A4BB0
	public void FadeOutToPoint(global::UnityEngine.Vector3 worldPoint)
	{
		this.Opaque();
		this.fadeOutPointStart = this.mTrans.position;
		this.fadeOutPointEnd = new global::UnityEngine.Vector3(worldPoint.x, worldPoint.y, worldPoint.z);
		if (this.fadeOutPointStart == this.fadeOutPointEnd)
		{
			this.fadeOutPointEnd.z = this.fadeOutPointEnd.z + 1f;
		}
		this.fadeOutPointNormal = this.fadeOutPointEnd - this.fadeOutPointStart;
		this.fadeOutPointMagnitude = this.fadeOutPointNormal.magnitude;
		this.fadeOutPointNormal /= this.fadeOutPointMagnitude;
		this.fadeOutPointDistance = global::UnityEngine.Vector3.Dot(this.fadeOutPointNormal, this.fadeOutPointStart);
		this.fadeOutAlpha = 1f;
		this.fadingOut = true;
		this._icon.enabled = true;
		this.fadeOutPoint = this.fadeOutPointStart;
	}

	// Token: 0x06002C3C RID: 11324 RVA: 0x000A6AA4 File Offset: 0x000A4CA4
	public void ClearHeldItem()
	{
		if (this.hasItem)
		{
			this.SetHeldItem(null);
			if (!this.fadingOut)
			{
				this.Opaque();
			}
		}
	}

	// Token: 0x06002C3D RID: 11325 RVA: 0x000A6AD8 File Offset: 0x000A4CD8
	public void ClearHeldItem(global::RPOSInventoryCell fadeToCell)
	{
		if (this.hasItem)
		{
			this.fadingOut = true;
			this.ClearHeldItem();
			try
			{
				global::UnityEngine.Vector3 worldPoint;
				if (global::NGUITools.GetCentroid(fadeToCell, out worldPoint))
				{
					this.FadeOutToPoint(worldPoint);
				}
				return;
			}
			catch
			{
			}
			this.Opaque();
		}
	}

	// Token: 0x06002C3E RID: 11326 RVA: 0x000A6B44 File Offset: 0x000A4D44
	private void MakeEmpty()
	{
		if (this._icon)
		{
			this._icon.enabled = false;
		}
		this._itemHolding = null;
		this.hasItem = false;
	}

	// Token: 0x04001675 RID: 5749
	private const float kOffsetSpeed = 600f;

	// Token: 0x04001676 RID: 5750
	private const float kFadeSpeed = 50f;

	// Token: 0x04001677 RID: 5751
	private const float kOffsetSmoothTime = 0.06f;

	// Token: 0x04001678 RID: 5752
	private const float kFadeSmoothTime = 0.1f;

	// Token: 0x04001679 RID: 5753
	private static global::GUIHeldItem _guiHeldItem;

	// Token: 0x0400167A RID: 5754
	public global::UITexture _icon;

	// Token: 0x0400167B RID: 5755
	private global::UIMaterial _myMaterial;

	// Token: 0x0400167C RID: 5756
	public global::UnityEngine.Camera uiCamera;

	// Token: 0x0400167D RID: 5757
	private global::UnityEngine.Transform mTrans;

	// Token: 0x0400167E RID: 5758
	private global::UnityEngine.Plane planeTest;

	// Token: 0x0400167F RID: 5759
	private global::IInventoryItem _itemHolding;

	// Token: 0x04001680 RID: 5760
	private global::UnityEngine.Vector3 offsetPoint;

	// Token: 0x04001681 RID: 5761
	private global::UnityEngine.Vector3 offsetVelocity;

	// Token: 0x04001682 RID: 5762
	private float lastTime;

	// Token: 0x04001683 RID: 5763
	private bool hasItem;

	// Token: 0x04001684 RID: 5764
	private bool fadingOut;

	// Token: 0x04001685 RID: 5765
	private global::UnityEngine.Vector3 fadeOutPointStart;

	// Token: 0x04001686 RID: 5766
	private global::UnityEngine.Vector3 fadeOutPointEnd;

	// Token: 0x04001687 RID: 5767
	private global::UnityEngine.Vector3 fadeOutPoint;

	// Token: 0x04001688 RID: 5768
	private global::UnityEngine.Vector3 fadeOutVelocity;

	// Token: 0x04001689 RID: 5769
	private global::UnityEngine.Vector3 fadeOutPointNormal;

	// Token: 0x0400168A RID: 5770
	private float fadeOutPointDistance;

	// Token: 0x0400168B RID: 5771
	private float fadeOutPointMagnitude;

	// Token: 0x0400168C RID: 5772
	private float fadeOutAlpha;

	// Token: 0x0400168D RID: 5773
	private global::UnityEngine.Color startingIconColor = global::UnityEngine.Color.white;

	// Token: 0x0400168E RID: 5774
	private bool started;
}
