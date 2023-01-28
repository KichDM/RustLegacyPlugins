using System;
using AnimationOrTween;
using UnityEngine;

// Token: 0x020008B9 RID: 2233
[global::UnityEngine.AddComponentMenu("NGUI/Interaction/Checkbox")]
public class UICheckbox : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06004D0D RID: 19725 RVA: 0x00124AD8 File Offset: 0x00122CD8
	public UICheckbox()
	{
	}

	// Token: 0x17000E55 RID: 3669
	// (get) Token: 0x06004D0E RID: 19726 RVA: 0x00124AFC File Offset: 0x00122CFC
	// (set) Token: 0x06004D0F RID: 19727 RVA: 0x00124B04 File Offset: 0x00122D04
	public bool isChecked
	{
		get
		{
			return this.mChecked;
		}
		set
		{
			if (this.radioButtonRoot == null || value || this.optionCanBeNone || !this.mStarted)
			{
				this.Set(value);
			}
		}
	}

	// Token: 0x06004D10 RID: 19728 RVA: 0x00124B48 File Offset: 0x00122D48
	private void Awake()
	{
		this.mTrans = base.transform;
		if (this.checkSprite != null)
		{
			this.checkSprite.alpha = ((!this.startsChecked) ? 0f : 1f);
		}
		if (this.option)
		{
			this.option = false;
			if (this.radioButtonRoot == null)
			{
				this.radioButtonRoot = this.mTrans.parent;
			}
		}
	}

	// Token: 0x06004D11 RID: 19729 RVA: 0x00124BCC File Offset: 0x00122DCC
	private void Start()
	{
		if (this.eventReceiver == null)
		{
			this.eventReceiver = base.gameObject;
		}
		this.mChecked = !this.startsChecked;
		this.mStarted = true;
		this.Set(this.startsChecked);
	}

	// Token: 0x06004D12 RID: 19730 RVA: 0x00124C18 File Offset: 0x00122E18
	private void OnClick()
	{
		if (base.enabled)
		{
			this.isChecked = !this.isChecked;
		}
	}

	// Token: 0x06004D13 RID: 19731 RVA: 0x00124C34 File Offset: 0x00122E34
	private void Set(bool state)
	{
		if (!this.mStarted)
		{
			this.mChecked = state;
			this.startsChecked = state;
			if (this.checkSprite != null)
			{
				this.checkSprite.alpha = ((!state) ? 0f : 1f);
			}
		}
		else if (this.mChecked != state)
		{
			if (this.radioButtonRoot != null && state)
			{
				global::UICheckbox[] componentsInChildren = this.radioButtonRoot.GetComponentsInChildren<global::UICheckbox>(true);
				int i = 0;
				int num = componentsInChildren.Length;
				while (i < num)
				{
					global::UICheckbox uicheckbox = componentsInChildren[i];
					if (uicheckbox != this && uicheckbox.radioButtonRoot == this.radioButtonRoot)
					{
						uicheckbox.Set(false);
					}
					i++;
				}
			}
			this.mChecked = state;
			if (this.checkSprite != null)
			{
				global::UnityEngine.Color color = this.checkSprite.color;
				color.a = ((!this.mChecked) ? 0f : 1f);
				global::TweenColor.Begin(this.checkSprite.gameObject, 0.2f, color);
			}
			if (this.eventReceiver != null && !string.IsNullOrEmpty(this.functionName))
			{
				global::UICheckbox.current = this;
				this.eventReceiver.SendMessage(this.functionName, this.mChecked, 1);
			}
			if (this.checkAnimation != null)
			{
				global::ActiveAnimation.Play(this.checkAnimation, (!state) ? global::AnimationOrTween.Direction.Reverse : global::AnimationOrTween.Direction.Forward);
			}
		}
	}

	// Token: 0x040029EE RID: 10734
	public static global::UICheckbox current;

	// Token: 0x040029EF RID: 10735
	public global::UISprite checkSprite;

	// Token: 0x040029F0 RID: 10736
	public global::UnityEngine.Animation checkAnimation;

	// Token: 0x040029F1 RID: 10737
	public global::UnityEngine.GameObject eventReceiver;

	// Token: 0x040029F2 RID: 10738
	public string functionName = "OnActivate";

	// Token: 0x040029F3 RID: 10739
	public bool startsChecked = true;

	// Token: 0x040029F4 RID: 10740
	public global::UnityEngine.Transform radioButtonRoot;

	// Token: 0x040029F5 RID: 10741
	public bool optionCanBeNone;

	// Token: 0x040029F6 RID: 10742
	[global::UnityEngine.HideInInspector]
	[global::UnityEngine.SerializeField]
	private bool option;

	// Token: 0x040029F7 RID: 10743
	private bool mChecked = true;

	// Token: 0x040029F8 RID: 10744
	private bool mStarted;

	// Token: 0x040029F9 RID: 10745
	private global::UnityEngine.Transform mTrans;
}
