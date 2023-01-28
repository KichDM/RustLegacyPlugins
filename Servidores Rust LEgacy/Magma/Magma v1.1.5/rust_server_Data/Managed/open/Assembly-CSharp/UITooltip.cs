using System;
using UnityEngine;

// Token: 0x0200096E RID: 2414
[global::UnityEngine.AddComponentMenu("Game/UI/Tooltip")]
public class UITooltip : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06005232 RID: 21042 RVA: 0x00151678 File Offset: 0x0014F878
	public UITooltip()
	{
	}

	// Token: 0x06005233 RID: 21043 RVA: 0x00151694 File Offset: 0x0014F894
	private void Awake()
	{
		global::UITooltip.mInstance = this;
	}

	// Token: 0x06005234 RID: 21044 RVA: 0x0015169C File Offset: 0x0014F89C
	private void OnDestroy()
	{
		global::UITooltip.mInstance = null;
	}

	// Token: 0x06005235 RID: 21045 RVA: 0x001516A4 File Offset: 0x0014F8A4
	private void Start()
	{
		this.mTrans = base.transform;
		this.mWidgets = base.GetComponentsInChildren<global::UIWidget>();
		this.mPos = this.mTrans.localPosition;
		this.mSize = this.mTrans.localScale;
		if (this.uiCamera == null)
		{
			this.uiCamera = global::NGUITools.FindCameraForLayer(base.gameObject.layer);
		}
		this.SetAlpha(0f);
	}

	// Token: 0x06005236 RID: 21046 RVA: 0x00151720 File Offset: 0x0014F920
	private void Update()
	{
		if (this.mCurrent != this.mTarget)
		{
			this.mCurrent = global::UnityEngine.Mathf.Lerp(this.mCurrent, this.mTarget, global::UnityEngine.Time.deltaTime * this.appearSpeed);
			if (global::UnityEngine.Mathf.Abs(this.mCurrent - this.mTarget) < 0.001f)
			{
				this.mCurrent = this.mTarget;
			}
			this.SetAlpha(this.mCurrent * this.mCurrent);
			if (this.scalingTransitions)
			{
				global::UnityEngine.Vector3 vector = this.mSize * 0.25f;
				vector.y = -vector.y;
				global::UnityEngine.Vector3 localScale = global::UnityEngine.Vector3.one * (1.5f - this.mCurrent * 0.5f);
				global::UnityEngine.Vector3 localPosition = global::UnityEngine.Vector3.Lerp(this.mPos - vector, this.mPos, this.mCurrent);
				this.mTrans.localPosition = localPosition;
				this.mTrans.localScale = localScale;
			}
		}
	}

	// Token: 0x06005237 RID: 21047 RVA: 0x0015181C File Offset: 0x0014FA1C
	private void SetAlpha(float val)
	{
		int i = 0;
		int num = this.mWidgets.Length;
		while (i < num)
		{
			global::UIWidget uiwidget = this.mWidgets[i];
			global::UnityEngine.Color color = uiwidget.color;
			color.a = val;
			uiwidget.color = color;
			i++;
		}
	}

	// Token: 0x06005238 RID: 21048 RVA: 0x00151864 File Offset: 0x0014FA64
	private void SetText(string tooltipText)
	{
		if (this.text != null && !string.IsNullOrEmpty(tooltipText))
		{
			this.mTarget = 1f;
			if (this.text != null)
			{
				this.text.text = tooltipText;
			}
			this.mPos = global::UnityEngine.Input.mousePosition;
			if (this.background != null)
			{
				global::UnityEngine.Transform transform = this.background.transform;
				global::UnityEngine.Transform transform2 = this.text.transform;
				global::UnityEngine.Vector3 localPosition = transform2.localPosition;
				global::UnityEngine.Vector3 localScale = transform2.localScale;
				this.mSize = this.text.relativeSize;
				this.mSize.x = this.mSize.x * localScale.x;
				this.mSize.y = this.mSize.y * localScale.y;
				this.mSize.x = this.mSize.x + (this.background.border.x + this.background.border.z + (localPosition.x - this.background.border.x) * 2f);
				this.mSize.y = this.mSize.y + (this.background.border.y + this.background.border.w + (-localPosition.y - this.background.border.y) * 2f);
				this.mSize.z = 1f;
				transform.localScale = this.mSize;
			}
			if (this.uiCamera != null)
			{
				this.mPos.x = global::UnityEngine.Mathf.Clamp01(this.mPos.x / (float)global::UnityEngine.Screen.width);
				this.mPos.y = global::UnityEngine.Mathf.Clamp01(this.mPos.y / (float)global::UnityEngine.Screen.height);
				float num = this.uiCamera.orthographicSize / this.mTrans.parent.lossyScale.y;
				float num2 = (float)global::UnityEngine.Screen.height * 0.5f / num;
				global::UnityEngine.Vector2 vector;
				vector..ctor(num2 * this.mSize.x / (float)global::UnityEngine.Screen.width, num2 * this.mSize.y / (float)global::UnityEngine.Screen.height);
				this.mPos.x = global::UnityEngine.Mathf.Min(this.mPos.x, 1f - vector.x);
				this.mPos.y = global::UnityEngine.Mathf.Max(this.mPos.y, vector.y);
				this.mTrans.position = this.uiCamera.ViewportToWorldPoint(this.mPos);
				this.mPos = this.mTrans.localPosition;
				this.mPos.x = global::UnityEngine.Mathf.Round(this.mPos.x);
				this.mPos.y = global::UnityEngine.Mathf.Round(this.mPos.y);
				this.mTrans.localPosition = this.mPos;
			}
			else
			{
				if (this.mPos.x + this.mSize.x > (float)global::UnityEngine.Screen.width)
				{
					this.mPos.x = (float)global::UnityEngine.Screen.width - this.mSize.x;
				}
				if (this.mPos.y - this.mSize.y < 0f)
				{
					this.mPos.y = this.mSize.y;
				}
				this.mPos.x = this.mPos.x - (float)global::UnityEngine.Screen.width * 0.5f;
				this.mPos.y = this.mPos.y - (float)global::UnityEngine.Screen.height * 0.5f;
			}
		}
		else
		{
			this.mTarget = 0f;
		}
	}

	// Token: 0x06005239 RID: 21049 RVA: 0x00151C5C File Offset: 0x0014FE5C
	public static void ShowText(string tooltipText)
	{
		if (global::UITooltip.mInstance != null)
		{
			global::UITooltip.mInstance.SetText(tooltipText);
		}
	}

	// Token: 0x04002E8B RID: 11915
	private static global::UITooltip mInstance;

	// Token: 0x04002E8C RID: 11916
	public global::UnityEngine.Camera uiCamera;

	// Token: 0x04002E8D RID: 11917
	public global::UILabel text;

	// Token: 0x04002E8E RID: 11918
	public global::UISlicedSprite background;

	// Token: 0x04002E8F RID: 11919
	public float appearSpeed = 10f;

	// Token: 0x04002E90 RID: 11920
	public bool scalingTransitions = true;

	// Token: 0x04002E91 RID: 11921
	private global::UnityEngine.Transform mTrans;

	// Token: 0x04002E92 RID: 11922
	private float mTarget;

	// Token: 0x04002E93 RID: 11923
	private float mCurrent;

	// Token: 0x04002E94 RID: 11924
	private global::UnityEngine.Vector3 mPos;

	// Token: 0x04002E95 RID: 11925
	private global::UnityEngine.Vector3 mSize;

	// Token: 0x04002E96 RID: 11926
	private global::UIWidget[] mWidgets;
}
