using System;
using UnityEngine;

// Token: 0x020008EF RID: 2287
[global::UnityEngine.AddComponentMenu("NGUI/Internal/Event Listener")]
public class UIEventListener : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06004E7B RID: 20091 RVA: 0x0012E444 File Offset: 0x0012C644
	public UIEventListener()
	{
	}

	// Token: 0x06004E7C RID: 20092 RVA: 0x0012E44C File Offset: 0x0012C64C
	private void OnSubmit()
	{
		if (this.onSubmit != null)
		{
			this.onSubmit(base.gameObject);
		}
	}

	// Token: 0x06004E7D RID: 20093 RVA: 0x0012E46C File Offset: 0x0012C66C
	private void OnClick()
	{
		if (this.onClick != null)
		{
			this.onClick(base.gameObject);
		}
	}

	// Token: 0x06004E7E RID: 20094 RVA: 0x0012E48C File Offset: 0x0012C68C
	private void OnDoubleClick()
	{
		if (this.onDoubleClick != null)
		{
			this.onDoubleClick(base.gameObject);
		}
	}

	// Token: 0x06004E7F RID: 20095 RVA: 0x0012E4AC File Offset: 0x0012C6AC
	private void OnHover(bool isOver)
	{
		if (this.onHover != null)
		{
			this.onHover(base.gameObject, isOver);
		}
	}

	// Token: 0x06004E80 RID: 20096 RVA: 0x0012E4CC File Offset: 0x0012C6CC
	private void OnPress(bool isPressed)
	{
		if (this.onPress != null)
		{
			this.onPress(base.gameObject, isPressed);
		}
	}

	// Token: 0x06004E81 RID: 20097 RVA: 0x0012E4EC File Offset: 0x0012C6EC
	private void OnSelect(bool selected)
	{
		if (this.onSelect != null)
		{
			this.onSelect(base.gameObject, selected);
		}
	}

	// Token: 0x06004E82 RID: 20098 RVA: 0x0012E50C File Offset: 0x0012C70C
	private void OnScroll(float delta)
	{
		if (this.onScroll != null)
		{
			this.onScroll(base.gameObject, delta);
		}
	}

	// Token: 0x06004E83 RID: 20099 RVA: 0x0012E52C File Offset: 0x0012C72C
	private void OnDrag(global::UnityEngine.Vector2 delta)
	{
		if (this.onDrag != null)
		{
			this.onDrag(base.gameObject, delta);
		}
	}

	// Token: 0x06004E84 RID: 20100 RVA: 0x0012E54C File Offset: 0x0012C74C
	private void OnDrop(global::UnityEngine.GameObject go)
	{
		if (this.onDrop != null)
		{
			this.onDrop(base.gameObject, go);
		}
	}

	// Token: 0x06004E85 RID: 20101 RVA: 0x0012E56C File Offset: 0x0012C76C
	private void OnInput(string text)
	{
		if (this.onInput != null)
		{
			this.onInput(base.gameObject, text);
		}
	}

	// Token: 0x06004E86 RID: 20102 RVA: 0x0012E58C File Offset: 0x0012C78C
	public static global::UIEventListener Get(global::UnityEngine.GameObject go)
	{
		global::UIEventListener uieventListener = go.GetComponent<global::UIEventListener>();
		if (uieventListener == null)
		{
			uieventListener = go.AddComponent<global::UIEventListener>();
		}
		return uieventListener;
	}

	// Token: 0x06004E87 RID: 20103 RVA: 0x0012E5B4 File Offset: 0x0012C7B4
	[global::System.Obsolete("Please use UIEventListener.Get instead of UIEventListener.Add")]
	public static global::UIEventListener Add(global::UnityEngine.GameObject go)
	{
		return global::UIEventListener.Get(go);
	}

	// Token: 0x04002B45 RID: 11077
	public object parameter;

	// Token: 0x04002B46 RID: 11078
	public global::UIEventListener.VoidDelegate onSubmit;

	// Token: 0x04002B47 RID: 11079
	public global::UIEventListener.VoidDelegate onClick;

	// Token: 0x04002B48 RID: 11080
	public global::UIEventListener.VoidDelegate onDoubleClick;

	// Token: 0x04002B49 RID: 11081
	public global::UIEventListener.BoolDelegate onHover;

	// Token: 0x04002B4A RID: 11082
	public global::UIEventListener.BoolDelegate onPress;

	// Token: 0x04002B4B RID: 11083
	public global::UIEventListener.BoolDelegate onSelect;

	// Token: 0x04002B4C RID: 11084
	public global::UIEventListener.FloatDelegate onScroll;

	// Token: 0x04002B4D RID: 11085
	public global::UIEventListener.VectorDelegate onDrag;

	// Token: 0x04002B4E RID: 11086
	public global::UIEventListener.ObjectDelegate onDrop;

	// Token: 0x04002B4F RID: 11087
	public global::UIEventListener.StringDelegate onInput;

	// Token: 0x020008F0 RID: 2288
	// (Invoke) Token: 0x06004E89 RID: 20105
	public delegate void VoidDelegate(global::UnityEngine.GameObject go);

	// Token: 0x020008F1 RID: 2289
	// (Invoke) Token: 0x06004E8D RID: 20109
	public delegate void BoolDelegate(global::UnityEngine.GameObject go, bool state);

	// Token: 0x020008F2 RID: 2290
	// (Invoke) Token: 0x06004E91 RID: 20113
	public delegate void FloatDelegate(global::UnityEngine.GameObject go, float delta);

	// Token: 0x020008F3 RID: 2291
	// (Invoke) Token: 0x06004E95 RID: 20117
	public delegate void VectorDelegate(global::UnityEngine.GameObject go, global::UnityEngine.Vector2 delta);

	// Token: 0x020008F4 RID: 2292
	// (Invoke) Token: 0x06004E99 RID: 20121
	public delegate void StringDelegate(global::UnityEngine.GameObject go, string text);

	// Token: 0x020008F5 RID: 2293
	// (Invoke) Token: 0x06004E9D RID: 20125
	public delegate void ObjectDelegate(global::UnityEngine.GameObject go, global::UnityEngine.GameObject draggedObject);
}
