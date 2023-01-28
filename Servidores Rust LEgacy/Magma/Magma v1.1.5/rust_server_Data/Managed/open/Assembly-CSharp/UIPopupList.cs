using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020008CB RID: 2251
[global::UnityEngine.AddComponentMenu("NGUI/Interaction/Popup List")]
[global::UnityEngine.ExecuteInEditMode]
public class UIPopupList : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06004D6F RID: 19823 RVA: 0x00127834 File Offset: 0x00125A34
	public UIPopupList()
	{
	}

	// Token: 0x17000E60 RID: 3680
	// (get) Token: 0x06004D70 RID: 19824 RVA: 0x001278CC File Offset: 0x00125ACC
	public bool isOpen
	{
		get
		{
			return this.mChild != null;
		}
	}

	// Token: 0x17000E61 RID: 3681
	// (get) Token: 0x06004D71 RID: 19825 RVA: 0x001278DC File Offset: 0x00125ADC
	// (set) Token: 0x06004D72 RID: 19826 RVA: 0x001278E4 File Offset: 0x00125AE4
	public string selection
	{
		get
		{
			return this.mSelectedItem;
		}
		set
		{
			if (this.mSelectedItem != value)
			{
				this.mSelectedItem = value;
				if (this.textLabel != null)
				{
					this.textLabel.text = ((!this.isLocalized || !(global::Localization.instance != null)) ? value : global::Localization.instance.Get(value));
				}
				if (this.eventReceiver != null && !string.IsNullOrEmpty(this.functionName) && global::UnityEngine.Application.isPlaying)
				{
					this.eventReceiver.SendMessage(this.functionName, this.mSelectedItem, 1);
				}
			}
		}
	}

	// Token: 0x17000E62 RID: 3682
	// (get) Token: 0x06004D73 RID: 19827 RVA: 0x00127994 File Offset: 0x00125B94
	// (set) Token: 0x06004D74 RID: 19828 RVA: 0x001279C0 File Offset: 0x00125BC0
	private bool handleEvents
	{
		get
		{
			global::UIButtonKeys component = base.GetComponent<global::UIButtonKeys>();
			return component == null || !component.enabled;
		}
		set
		{
			global::UIButtonKeys component = base.GetComponent<global::UIButtonKeys>();
			if (component != null)
			{
				component.enabled = !value;
			}
		}
	}

	// Token: 0x06004D75 RID: 19829 RVA: 0x001279EC File Offset: 0x00125BEC
	private void Start()
	{
		if (string.IsNullOrEmpty(this.mSelectedItem))
		{
			if (this.items.Count > 0)
			{
				this.selection = this.items[0];
			}
		}
		else
		{
			string selection = this.mSelectedItem;
			this.mSelectedItem = null;
			this.selection = selection;
		}
	}

	// Token: 0x06004D76 RID: 19830 RVA: 0x00127A48 File Offset: 0x00125C48
	private void OnLocalize(global::Localization loc)
	{
		if (this.isLocalized && this.textLabel != null)
		{
			this.textLabel.text = loc.Get(this.mSelectedItem);
		}
	}

	// Token: 0x06004D77 RID: 19831 RVA: 0x00127A80 File Offset: 0x00125C80
	private void Highlight(global::UILabel lbl, bool instant)
	{
		if (this.mHighlight != null)
		{
			global::TweenPosition component = lbl.GetComponent<global::TweenPosition>();
			if (component != null && component.enabled)
			{
				return;
			}
			this.mHighlightedLabel = lbl;
			global::UIAtlas.Sprite sprite = this.mHighlight.sprite;
			float num = sprite.inner.xMin - sprite.outer.xMin;
			float num2 = sprite.inner.yMin - sprite.outer.yMin;
			global::UnityEngine.Vector3 vector = lbl.cachedTransform.localPosition + new global::UnityEngine.Vector3(-num, num2, 0f);
			if (instant || !this.isAnimated)
			{
				this.mHighlight.cachedTransform.localPosition = vector;
			}
			else
			{
				global::TweenPosition.Begin(this.mHighlight.gameObject, 0.1f, vector).method = global::UITweener.Method.EaseOut;
			}
		}
	}

	// Token: 0x06004D78 RID: 19832 RVA: 0x00127B64 File Offset: 0x00125D64
	private void OnItemHover(global::UnityEngine.GameObject go, bool isOver)
	{
		if (isOver)
		{
			global::UILabel component = go.GetComponent<global::UILabel>();
			this.Highlight(component, false);
		}
	}

	// Token: 0x06004D79 RID: 19833 RVA: 0x00127B88 File Offset: 0x00125D88
	private void Select(global::UILabel lbl, bool instant)
	{
		this.Highlight(lbl, instant);
		global::UIEventListener component = lbl.gameObject.GetComponent<global::UIEventListener>();
		this.selection = (component.parameter as string);
		global::UIButtonSound[] components = base.GetComponents<global::UIButtonSound>();
		int i = 0;
		int num = components.Length;
		while (i < num)
		{
			global::UIButtonSound uibuttonSound = components[i];
			if (uibuttonSound.trigger == global::UIButtonSound.Trigger.OnClick)
			{
				global::NGUITools.PlaySound(uibuttonSound.audioClip, uibuttonSound.volume, 1f);
			}
			i++;
		}
	}

	// Token: 0x06004D7A RID: 19834 RVA: 0x00127C04 File Offset: 0x00125E04
	private void OnItemPress(global::UnityEngine.GameObject go, bool isPressed)
	{
		if (isPressed)
		{
			this.Select(go.GetComponent<global::UILabel>(), true);
		}
	}

	// Token: 0x06004D7B RID: 19835 RVA: 0x00127C1C File Offset: 0x00125E1C
	private void OnKey(global::UnityEngine.KeyCode key)
	{
		if (base.enabled && base.gameObject.activeInHierarchy && this.handleEvents)
		{
			int num = this.mLabelList.IndexOf(this.mHighlightedLabel);
			if (key == 0x111)
			{
				if (num > 0)
				{
					this.Select(this.mLabelList[num - 1], false);
				}
			}
			else if (key == 0x112)
			{
				if (num + 1 < this.mLabelList.Count)
				{
					this.Select(this.mLabelList[num + 1], false);
				}
			}
			else if (key == 0x1B)
			{
				this.OnSelect(false);
			}
		}
	}

	// Token: 0x06004D7C RID: 19836 RVA: 0x00127CD8 File Offset: 0x00125ED8
	private void OnSelect(bool isSelected)
	{
		if (!isSelected && this.mChild != null)
		{
			this.mLabelList.Clear();
			this.handleEvents = false;
			if (this.isAnimated)
			{
				global::UIWidget[] componentsInChildren = this.mChild.GetComponentsInChildren<global::UIWidget>();
				int i = 0;
				int num = componentsInChildren.Length;
				while (i < num)
				{
					global::UIWidget uiwidget = componentsInChildren[i];
					global::UnityEngine.Color color = uiwidget.color;
					color.a = 0f;
					global::TweenColor.Begin(uiwidget.gameObject, 0.15f, color).method = global::UITweener.Method.EaseOut;
					i++;
				}
				global::NGUITools.SetAllowClickChildren(this.mChild, false);
				global::UpdateManager.AddDestroy(this.mChild, 0.15f);
			}
			else
			{
				global::UnityEngine.Object.Destroy(this.mChild);
			}
			this.mBackground = null;
			this.mHighlight = null;
			this.mChild = null;
		}
	}

	// Token: 0x06004D7D RID: 19837 RVA: 0x00127DAC File Offset: 0x00125FAC
	private void AnimateColor(global::UIWidget widget)
	{
		global::UnityEngine.Color color = widget.color;
		widget.color = new global::UnityEngine.Color(color.r, color.g, color.b, 0f);
		global::TweenColor.Begin(widget.gameObject, 0.15f, color).method = global::UITweener.Method.EaseOut;
	}

	// Token: 0x06004D7E RID: 19838 RVA: 0x00127DFC File Offset: 0x00125FFC
	private void AnimatePosition(global::UIWidget widget, bool placeAbove, float bottom)
	{
		global::UnityEngine.Vector3 localPosition = widget.cachedTransform.localPosition;
		global::UnityEngine.Vector3 localPosition2 = (!placeAbove) ? new global::UnityEngine.Vector3(localPosition.x, 0f, localPosition.z) : new global::UnityEngine.Vector3(localPosition.x, bottom, localPosition.z);
		widget.cachedTransform.localPosition = localPosition2;
		global::UnityEngine.GameObject gameObject = widget.gameObject;
		global::TweenPosition.Begin(gameObject, 0.15f, localPosition).method = global::UITweener.Method.EaseOut;
	}

	// Token: 0x06004D7F RID: 19839 RVA: 0x00127E74 File Offset: 0x00126074
	private void AnimateScale(global::UIWidget widget, bool placeAbove, float bottom)
	{
		global::UnityEngine.GameObject gameObject = widget.gameObject;
		global::UnityEngine.Transform cachedTransform = widget.cachedTransform;
		float num = (float)this.font.size * this.textScale + this.mBgBorder * 2f;
		global::UnityEngine.Vector3 localScale = cachedTransform.localScale;
		cachedTransform.localScale = new global::UnityEngine.Vector3(localScale.x, num, localScale.z);
		global::TweenScale.Begin(gameObject, 0.15f, localScale).method = global::UITweener.Method.EaseOut;
		if (placeAbove)
		{
			global::UnityEngine.Vector3 localPosition = cachedTransform.localPosition;
			cachedTransform.localPosition = new global::UnityEngine.Vector3(localPosition.x, localPosition.y - localScale.y + num, localPosition.z);
			global::TweenPosition.Begin(gameObject, 0.15f, localPosition).method = global::UITweener.Method.EaseOut;
		}
	}

	// Token: 0x06004D80 RID: 19840 RVA: 0x00127F30 File Offset: 0x00126130
	private void Animate(global::UIWidget widget, bool placeAbove, float bottom)
	{
		this.AnimateColor(widget);
		this.AnimatePosition(widget, placeAbove, bottom);
	}

	// Token: 0x06004D81 RID: 19841 RVA: 0x00127F44 File Offset: 0x00126144
	private void OnClick()
	{
		if (this.mChild == null && this.atlas != null && this.font != null && this.items.Count > 1)
		{
			this.mLabelList.Clear();
			this.handleEvents = true;
			if (this.mPanel == null)
			{
				this.mPanel = global::UIPanel.Find(base.transform, true);
			}
			global::UnityEngine.Transform transform = base.transform;
			global::AABBox aabbox = global::NGUIMath.CalculateRelativeWidgetBounds(transform.parent, transform);
			this.mChild = new global::UnityEngine.GameObject("Drop-down List");
			this.mChild.layer = base.gameObject.layer;
			global::UnityEngine.Transform transform2 = this.mChild.transform;
			transform2.parent = transform.parent;
			transform2.localPosition = aabbox.min;
			transform2.localRotation = global::UnityEngine.Quaternion.identity;
			transform2.localScale = global::UnityEngine.Vector3.one;
			this.mBackground = global::NGUITools.AddSprite(this.mChild, this.atlas, this.backgroundSprite);
			this.mBackground.pivot = global::UIWidget.Pivot.TopLeft;
			this.mBackground.depth = global::NGUITools.CalculateNextDepth(this.mPanel.gameObject);
			this.mBackground.color = this.backgroundColor;
			global::UnityEngine.Vector4 border = this.mBackground.border;
			this.mBgBorder = border.y;
			this.mBackground.cachedTransform.localPosition = new global::UnityEngine.Vector3(0f, border.y, 0f);
			this.mHighlight = global::NGUITools.AddSprite(this.mChild, this.atlas, this.highlightSprite);
			this.mHighlight.pivot = global::UIWidget.Pivot.TopLeft;
			this.mHighlight.color = this.highlightColor;
			global::UIAtlas.Sprite sprite = this.mHighlight.sprite;
			float num = sprite.inner.yMin - sprite.outer.yMin;
			float num2 = (float)this.font.size * this.textScale;
			float num3 = 0f;
			float num4 = -this.padding.y;
			global::System.Collections.Generic.List<global::UILabel> list = new global::System.Collections.Generic.List<global::UILabel>();
			int i = 0;
			int count = this.items.Count;
			while (i < count)
			{
				string text = this.items[i];
				global::UILabel uilabel = global::NGUITools.AddWidget<global::UILabel>(this.mChild);
				uilabel.pivot = global::UIWidget.Pivot.TopLeft;
				uilabel.font = this.font;
				uilabel.text = ((!this.isLocalized || !(global::Localization.instance != null)) ? text : global::Localization.instance.Get(text));
				uilabel.color = this.textColor;
				uilabel.cachedTransform.localPosition = new global::UnityEngine.Vector3(border.x, num4, 0f);
				uilabel.MakePixelPerfect();
				if (this.textScale != 1f)
				{
					global::UnityEngine.Vector3 localScale = uilabel.cachedTransform.localScale;
					uilabel.cachedTransform.localScale = localScale * this.textScale;
				}
				list.Add(uilabel);
				num4 -= num2;
				num4 -= this.padding.y;
				num3 = global::UnityEngine.Mathf.Max(num3, uilabel.relativeSize.x * num2);
				global::UIEventListener uieventListener = global::UIEventListener.Get(uilabel.gameObject);
				uieventListener.onHover = new global::UIEventListener.BoolDelegate(this.OnItemHover);
				uieventListener.onPress = new global::UIEventListener.BoolDelegate(this.OnItemPress);
				uieventListener.parameter = text;
				if (this.mSelectedItem == text)
				{
					this.Highlight(uilabel, true);
				}
				this.mLabelList.Add(uilabel);
				i++;
			}
			num3 = global::UnityEngine.Mathf.Max(num3, aabbox.size.x - border.x * 2f);
			global::UnityEngine.Vector3 center;
			center..ctor(num3 * 0.5f / num2, -0.5f, 0f);
			global::UnityEngine.Vector3 size;
			size..ctor(num3 / num2, (num2 + this.padding.y) / num2, 1f);
			int j = 0;
			int count2 = list.Count;
			while (j < count2)
			{
				global::UILabel uilabel2 = list[j];
				global::UIHotSpot uihotSpot = global::NGUITools.AddWidgetHotSpot(uilabel2.gameObject);
				center.z = uihotSpot.center.z;
				uihotSpot.center = center;
				uihotSpot.size = size;
				j++;
			}
			num3 += border.x * 2f;
			num4 -= border.y;
			this.mBackground.cachedTransform.localScale = new global::UnityEngine.Vector3(num3, -num4 + border.y, 1f);
			this.mHighlight.cachedTransform.localScale = new global::UnityEngine.Vector3(num3 - border.x * 2f + (sprite.inner.xMin - sprite.outer.xMin) * 2f, num2 + num * 2f, 1f);
			bool flag = this.position == global::UIPopupList.Position.Above;
			if (this.position == global::UIPopupList.Position.Auto)
			{
				global::UICamera uicamera = global::UICamera.FindCameraForLayer(base.gameObject.layer);
				if (uicamera != null)
				{
					flag = (uicamera.cachedCamera.WorldToViewportPoint(transform.position).y < 0.5f);
				}
			}
			if (this.isAnimated)
			{
				float bottom = num4 + num2;
				this.Animate(this.mHighlight, flag, bottom);
				int k = 0;
				int count3 = list.Count;
				while (k < count3)
				{
					this.Animate(list[k], flag, bottom);
					k++;
				}
				this.AnimateColor(this.mBackground);
				this.AnimateScale(this.mBackground, flag, bottom);
			}
			if (flag)
			{
				transform2.localPosition = new global::UnityEngine.Vector3(aabbox.min.x, aabbox.max.y - num4 - border.y, aabbox.min.z);
			}
		}
		else
		{
			this.OnSelect(false);
		}
	}

	// Token: 0x04002A6A RID: 10858
	private const float animSpeed = 0.15f;

	// Token: 0x04002A6B RID: 10859
	public global::UIAtlas atlas;

	// Token: 0x04002A6C RID: 10860
	public global::UIFont font;

	// Token: 0x04002A6D RID: 10861
	public global::UILabel textLabel;

	// Token: 0x04002A6E RID: 10862
	public string backgroundSprite;

	// Token: 0x04002A6F RID: 10863
	public string highlightSprite;

	// Token: 0x04002A70 RID: 10864
	public global::UIPopupList.Position position;

	// Token: 0x04002A71 RID: 10865
	public global::System.Collections.Generic.List<string> items = new global::System.Collections.Generic.List<string>();

	// Token: 0x04002A72 RID: 10866
	public global::UnityEngine.Vector2 padding = new global::UnityEngine.Vector3(4f, 4f);

	// Token: 0x04002A73 RID: 10867
	public float textScale = 1f;

	// Token: 0x04002A74 RID: 10868
	public global::UnityEngine.Color textColor = global::UnityEngine.Color.white;

	// Token: 0x04002A75 RID: 10869
	public global::UnityEngine.Color backgroundColor = global::UnityEngine.Color.white;

	// Token: 0x04002A76 RID: 10870
	public global::UnityEngine.Color highlightColor = new global::UnityEngine.Color(0.59607846f, 1f, 0.2f, 1f);

	// Token: 0x04002A77 RID: 10871
	public bool isAnimated = true;

	// Token: 0x04002A78 RID: 10872
	public bool isLocalized;

	// Token: 0x04002A79 RID: 10873
	public global::UnityEngine.GameObject eventReceiver;

	// Token: 0x04002A7A RID: 10874
	public string functionName = "OnSelectionChange";

	// Token: 0x04002A7B RID: 10875
	[global::UnityEngine.HideInInspector]
	[global::UnityEngine.SerializeField]
	private string mSelectedItem;

	// Token: 0x04002A7C RID: 10876
	private global::UIPanel mPanel;

	// Token: 0x04002A7D RID: 10877
	private global::UnityEngine.GameObject mChild;

	// Token: 0x04002A7E RID: 10878
	private global::UISprite mBackground;

	// Token: 0x04002A7F RID: 10879
	private global::UISprite mHighlight;

	// Token: 0x04002A80 RID: 10880
	private global::UILabel mHighlightedLabel;

	// Token: 0x04002A81 RID: 10881
	private global::System.Collections.Generic.List<global::UILabel> mLabelList = new global::System.Collections.Generic.List<global::UILabel>();

	// Token: 0x04002A82 RID: 10882
	private float mBgBorder;

	// Token: 0x020008CC RID: 2252
	public enum Position
	{
		// Token: 0x04002A84 RID: 10884
		Auto,
		// Token: 0x04002A85 RID: 10885
		Above,
		// Token: 0x04002A86 RID: 10886
		Below
	}
}
