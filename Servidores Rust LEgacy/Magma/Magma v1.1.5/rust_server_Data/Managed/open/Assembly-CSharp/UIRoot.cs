using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x0200095E RID: 2398
[global::UnityEngine.AddComponentMenu("NGUI/UI/Root")]
[global::UnityEngine.ExecuteInEditMode]
public class UIRoot : global::UnityEngine.MonoBehaviour
{
	// Token: 0x060051C5 RID: 20933 RVA: 0x00144710 File Offset: 0x00142910
	public UIRoot()
	{
	}

	// Token: 0x060051C6 RID: 20934 RVA: 0x0014472C File Offset: 0x0014292C
	// Note: this type is marked as 'beforefieldinit'.
	static UIRoot()
	{
	}

	// Token: 0x060051C7 RID: 20935 RVA: 0x00144738 File Offset: 0x00142938
	private void Awake()
	{
		global::UIRoot.mRoots.Add(this);
	}

	// Token: 0x060051C8 RID: 20936 RVA: 0x00144748 File Offset: 0x00142948
	private void OnDestroy()
	{
		global::UIRoot.mRoots.Remove(this);
	}

	// Token: 0x060051C9 RID: 20937 RVA: 0x00144758 File Offset: 0x00142958
	private void Start()
	{
		this.mTrans = base.transform;
		global::UIOrthoCamera componentInChildren = base.GetComponentInChildren<global::UIOrthoCamera>();
		if (componentInChildren != null)
		{
			global::UnityEngine.Debug.LogWarning("UIRoot should not be active at the same time as UIOrthoCamera. Disabling UIOrthoCamera.", componentInChildren);
			global::UnityEngine.Camera component = componentInChildren.gameObject.GetComponent<global::UnityEngine.Camera>();
			componentInChildren.enabled = false;
			if (component != null)
			{
				component.orthographicSize = 1f;
			}
		}
	}

	// Token: 0x060051CA RID: 20938 RVA: 0x001447BC File Offset: 0x001429BC
	private void Update()
	{
		this.manualHeight = global::UnityEngine.Mathf.Max(2, (!this.automatic) ? this.manualHeight : global::UnityEngine.Screen.height);
		float num = 2f / (float)this.manualHeight;
		global::UnityEngine.Vector3 localScale = this.mTrans.localScale;
		if (global::UnityEngine.Mathf.Abs(localScale.x - num) > 1E-45f || global::UnityEngine.Mathf.Abs(localScale.y - num) > 1E-45f || global::UnityEngine.Mathf.Abs(localScale.z - num) > 1E-45f)
		{
			this.mTrans.localScale = new global::UnityEngine.Vector3(num, num, num);
		}
	}

	// Token: 0x060051CB RID: 20939 RVA: 0x00144868 File Offset: 0x00142A68
	public static void Broadcast(string funcName)
	{
		int i = 0;
		int count = global::UIRoot.mRoots.Count;
		while (i < count)
		{
			global::UIRoot uiroot = global::UIRoot.mRoots[i];
			if (uiroot != null)
			{
				uiroot.BroadcastMessage(funcName, 1);
			}
			i++;
		}
	}

	// Token: 0x060051CC RID: 20940 RVA: 0x001448B4 File Offset: 0x00142AB4
	public static void Broadcast(string funcName, object param)
	{
		if (param == null)
		{
			global::UnityEngine.Debug.LogError("SendMessage is bugged when you try to pass 'null' in the parameter field. It behaves as if no parameter was specified.");
		}
		else
		{
			int i = 0;
			int count = global::UIRoot.mRoots.Count;
			while (i < count)
			{
				global::UIRoot uiroot = global::UIRoot.mRoots[i];
				if (uiroot != null)
				{
					uiroot.BroadcastMessage(funcName, param, 1);
				}
				i++;
			}
		}
	}

	// Token: 0x04002E44 RID: 11844
	private static global::System.Collections.Generic.List<global::UIRoot> mRoots = new global::System.Collections.Generic.List<global::UIRoot>();

	// Token: 0x04002E45 RID: 11845
	public bool automatic = true;

	// Token: 0x04002E46 RID: 11846
	public int manualHeight = 0x320;

	// Token: 0x04002E47 RID: 11847
	private global::UnityEngine.Transform mTrans;
}
