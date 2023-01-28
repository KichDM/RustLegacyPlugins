using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using NGUI.Meshing;
using UnityEngine;

// Token: 0x0200095A RID: 2394
[global::UnityEngine.AddComponentMenu("NGUI/UI/Panel")]
[global::UnityEngine.ExecuteInEditMode]
public class UIPanel : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06005182 RID: 20866 RVA: 0x00142A4C File Offset: 0x00140C4C
	public UIPanel()
	{
	}

	// Token: 0x06005183 RID: 20867 RVA: 0x00142AF4 File Offset: 0x00140CF4
	// Note: this type is marked as 'beforefieldinit'.
	static UIPanel()
	{
	}

	// Token: 0x06005184 RID: 20868 RVA: 0x00142B0C File Offset: 0x00140D0C
	public static void GlobalUpdate()
	{
		global::UIPanel.Global.PanelUpdate();
	}

	// Token: 0x17000F36 RID: 3894
	// (get) Token: 0x06005185 RID: 20869 RVA: 0x00142B14 File Offset: 0x00140D14
	// (set) Token: 0x06005186 RID: 20870 RVA: 0x00142B34 File Offset: 0x00140D34
	public global::UIPanel RootPanel
	{
		get
		{
			return (!this._rootPanel) ? this : this._rootPanel;
		}
		set
		{
			if (value == this)
			{
				this._rootPanel = null;
			}
			else
			{
				this._rootPanel = value;
			}
		}
	}

	// Token: 0x17000F37 RID: 3895
	// (get) Token: 0x06005187 RID: 20871 RVA: 0x00142B58 File Offset: 0x00140D58
	public global::UnityEngine.Transform cachedTransform
	{
		get
		{
			if (this.mTrans == null)
			{
				this.mTrans = base.transform;
			}
			return this.mTrans;
		}
	}

	// Token: 0x17000F38 RID: 3896
	// (get) Token: 0x06005188 RID: 20872 RVA: 0x00142B80 File Offset: 0x00140D80
	public bool changedLastFrame
	{
		get
		{
			return this.mChangedLastFrame;
		}
	}

	// Token: 0x17000F39 RID: 3897
	// (get) Token: 0x06005189 RID: 20873 RVA: 0x00142B88 File Offset: 0x00140D88
	// (set) Token: 0x0600518A RID: 20874 RVA: 0x00142B90 File Offset: 0x00140D90
	public global::UIPanel.DebugInfo debugInfo
	{
		get
		{
			return this.mDebugInfo;
		}
		set
		{
			if (this.mDebugInfo != value)
			{
				this.mDebugInfo = value;
				global::UIDrawCall.Iterator iterator = (global::UIDrawCall.Iterator)this.mDrawCalls;
				global::UnityEngine.HideFlags hideFlags = (this.mDebugInfo != global::UIPanel.DebugInfo.Geometry) ? 0xD : 0xC;
				while (iterator.Has)
				{
					global::UnityEngine.GameObject gameObject = iterator.Current.gameObject;
					iterator = iterator.Next;
					gameObject.SetActive(false);
					gameObject.hideFlags = hideFlags;
					gameObject.SetActive(true);
				}
			}
		}
	}

	// Token: 0x17000F3A RID: 3898
	// (get) Token: 0x0600518B RID: 20875 RVA: 0x00142C10 File Offset: 0x00140E10
	// (set) Token: 0x0600518C RID: 20876 RVA: 0x00142C18 File Offset: 0x00140E18
	public global::UIDrawCall.Clipping clipping
	{
		get
		{
			return this.mClipping;
		}
		set
		{
			if (this.mClipping != value)
			{
				this.mCheckVisibility = true;
				this.mClipping = value;
				this.UpdateDrawcalls();
			}
		}
	}

	// Token: 0x17000F3B RID: 3899
	// (get) Token: 0x0600518D RID: 20877 RVA: 0x00142C48 File Offset: 0x00140E48
	// (set) Token: 0x0600518E RID: 20878 RVA: 0x00142C50 File Offset: 0x00140E50
	public global::UnityEngine.Vector4 clipRange
	{
		get
		{
			return this.mClipRange;
		}
		set
		{
			if (this.mClipRange != value)
			{
				this.mCullTime = ((this.mCullTime != 0f) ? (global::UnityEngine.Time.realtimeSinceStartup + 0.15f) : 0.001f);
				this.mCheckVisibility = true;
				this.mClipRange = value;
				this.UpdateDrawcalls();
			}
		}
	}

	// Token: 0x17000F3C RID: 3900
	// (get) Token: 0x0600518F RID: 20879 RVA: 0x00142CB0 File Offset: 0x00140EB0
	// (set) Token: 0x06005190 RID: 20880 RVA: 0x00142CB8 File Offset: 0x00140EB8
	public global::UnityEngine.Vector2 clipSoftness
	{
		get
		{
			return this.mClipSoftness;
		}
		set
		{
			if (this.mClipSoftness != value)
			{
				this.mClipSoftness = value;
				this.UpdateDrawcalls();
			}
		}
	}

	// Token: 0x17000F3D RID: 3901
	// (get) Token: 0x06005191 RID: 20881 RVA: 0x00142CD8 File Offset: 0x00140ED8
	public global::System.Collections.Generic.List<global::UIWidget> widgets
	{
		get
		{
			return this.mWidgets;
		}
	}

	// Token: 0x17000F3E RID: 3902
	// (get) Token: 0x06005192 RID: 20882 RVA: 0x00142CE0 File Offset: 0x00140EE0
	public global::UIDrawCall.Iterator drawCalls
	{
		get
		{
			return (global::UIDrawCall.Iterator)this.mDrawCalls;
		}
	}

	// Token: 0x17000F3F RID: 3903
	// (get) Token: 0x06005193 RID: 20883 RVA: 0x00142CF0 File Offset: 0x00140EF0
	public int drawCallCount
	{
		get
		{
			return this.mDrawCallCount;
		}
	}

	// Token: 0x17000F40 RID: 3904
	// (get) Token: 0x06005194 RID: 20884 RVA: 0x00142CF8 File Offset: 0x00140EF8
	public bool manUp
	{
		get
		{
			return this.manualPanelUpdate;
		}
	}

	// Token: 0x06005195 RID: 20885 RVA: 0x00142D00 File Offset: 0x00140F00
	private global::UINode GetNode(global::UnityEngine.Transform t)
	{
		global::UINode result = null;
		if (t != null && this.mChildren.Contains(t))
		{
			result = (global::UINode)this.mChildren[t];
		}
		return result;
	}

	// Token: 0x06005196 RID: 20886 RVA: 0x00142D40 File Offset: 0x00140F40
	private bool IsVisible(global::UnityEngine.Vector3 a, global::UnityEngine.Vector3 b, global::UnityEngine.Vector3 c, global::UnityEngine.Vector3 d)
	{
		this.UpdateTransformMatrix();
		a = this.mWorldToLocal.MultiplyPoint3x4(a);
		b = this.mWorldToLocal.MultiplyPoint3x4(b);
		c = this.mWorldToLocal.MultiplyPoint3x4(c);
		d = this.mWorldToLocal.MultiplyPoint3x4(d);
		global::UIPanel.mTemp[0] = a.x;
		global::UIPanel.mTemp[1] = b.x;
		global::UIPanel.mTemp[2] = c.x;
		global::UIPanel.mTemp[3] = d.x;
		float num = global::UnityEngine.Mathf.Min(global::UIPanel.mTemp);
		float num2 = global::UnityEngine.Mathf.Max(global::UIPanel.mTemp);
		global::UIPanel.mTemp[0] = a.y;
		global::UIPanel.mTemp[1] = b.y;
		global::UIPanel.mTemp[2] = c.y;
		global::UIPanel.mTemp[3] = d.y;
		float num3 = global::UnityEngine.Mathf.Min(global::UIPanel.mTemp);
		float num4 = global::UnityEngine.Mathf.Max(global::UIPanel.mTemp);
		return num2 >= this.mMin.x && num4 >= this.mMin.y && num <= this.mMax.x && num3 <= this.mMax.y;
	}

	// Token: 0x06005197 RID: 20887 RVA: 0x00142E78 File Offset: 0x00141078
	public bool IsVisible(global::UIWidget w)
	{
		if (!w.enabled || !w.gameObject.activeInHierarchy || w.color.a < 0.001f)
		{
			return false;
		}
		if (this.mClipping == global::UIDrawCall.Clipping.None)
		{
			return true;
		}
		global::UnityEngine.Vector2 relativeSize = w.relativeSize;
		global::UnityEngine.Vector2 vector = global::UnityEngine.Vector2.Scale(w.pivotOffset, relativeSize);
		global::UnityEngine.Vector2 vector2 = vector;
		vector.x += relativeSize.x;
		vector.y -= relativeSize.y;
		global::UnityEngine.Transform cachedTransform = w.cachedTransform;
		global::UnityEngine.Vector3 a = cachedTransform.TransformPoint(vector);
		global::UnityEngine.Vector3 b = cachedTransform.TransformPoint(new global::UnityEngine.Vector2(vector.x, vector2.y));
		global::UnityEngine.Vector3 c = cachedTransform.TransformPoint(new global::UnityEngine.Vector2(vector2.x, vector.y));
		global::UnityEngine.Vector3 d = cachedTransform.TransformPoint(vector2);
		return this.IsVisible(a, b, c, d);
	}

	// Token: 0x06005198 RID: 20888 RVA: 0x00142F7C File Offset: 0x0014117C
	public void MarkMaterialAsChanged(global::UIMaterial mat, bool sort)
	{
		if (mat)
		{
			if (sort)
			{
				this.mDepthChanged = true;
			}
			if (this.mChanged.Add(mat))
			{
				this.mChangedLastFrame = true;
			}
		}
	}

	// Token: 0x06005199 RID: 20889 RVA: 0x00142FBC File Offset: 0x001411BC
	public bool WatchesTransform(global::UnityEngine.Transform t)
	{
		return t == this.cachedTransform || this.mChildren.Contains(t);
	}

	// Token: 0x0600519A RID: 20890 RVA: 0x00142FEC File Offset: 0x001411EC
	private global::UINode AddTransform(global::UnityEngine.Transform t)
	{
		global::UINode uinode = null;
		while (t != null && t != this.cachedTransform)
		{
			if (this.mChildren.Contains(t))
			{
				if (uinode == null)
				{
					uinode = (global::UINode)this.mChildren[t];
				}
				break;
			}
			global::UINode uinode2 = new global::UINode(t);
			if (uinode == null)
			{
				uinode = uinode2;
			}
			this.mChildren.Add(t, uinode2);
			t = t.parent;
		}
		return uinode;
	}

	// Token: 0x0600519B RID: 20891 RVA: 0x00143074 File Offset: 0x00141274
	private void RemoveTransform(global::UnityEngine.Transform t)
	{
		if (t != null)
		{
			while (this.mChildren.Contains(t))
			{
				this.mChildren.Remove(t);
				t = t.parent;
				if (t == null || t == this.mTrans || t.childCount > 1)
				{
					break;
				}
			}
		}
	}

	// Token: 0x0600519C RID: 20892 RVA: 0x001430E8 File Offset: 0x001412E8
	public void AddWidget(global::UIWidget w)
	{
		if (w != null)
		{
			global::UINode uinode = this.AddTransform(w.cachedTransform);
			if (uinode != null)
			{
				uinode.widget = w;
				if (!this.mWidgets.Contains(w))
				{
					this.mWidgets.Add(w);
					if (!this.mChanged.Contains(w.material))
					{
						this.mChanged.Add(w.material);
						this.mChangedLastFrame = true;
					}
					this.mDepthChanged = true;
				}
			}
			else
			{
				global::UnityEngine.Debug.LogError("Unable to find an appropriate UIRoot for " + global::NGUITools.GetHierarchy(w.gameObject) + "\nPlease make sure that there is at least one game object above this widget!", w.gameObject);
			}
		}
	}

	// Token: 0x0600519D RID: 20893 RVA: 0x00143198 File Offset: 0x00141398
	public void RemoveWidget(global::UIWidget w)
	{
		if (w != null)
		{
			global::UINode node = this.GetNode(w.cachedTransform);
			if (node != null)
			{
				if (node.visibleFlag == 1 && !this.mChanged.Contains(w.material))
				{
					this.mChanged.Add(w.material);
					this.mChangedLastFrame = true;
				}
				this.RemoveTransform(w.cachedTransform);
			}
			this.mWidgets.Remove(w);
		}
	}

	// Token: 0x0600519E RID: 20894 RVA: 0x00143218 File Offset: 0x00141418
	private global::UIDrawCall.Iterator GetDrawCall(global::UIMaterial mat, bool createIfMissing)
	{
		global::UIDrawCall.Iterator result = (global::UIDrawCall.Iterator)this.mDrawCalls;
		while (result.Has)
		{
			if (result.Current.material == mat)
			{
				return result;
			}
			result = result.Next;
		}
		global::UIDrawCall uidrawCall = null;
		if (createIfMissing)
		{
			uidrawCall = new global::UnityEngine.GameObject("_UIDrawCall [" + mat.name + "]")
			{
				hideFlags = 4,
				layer = base.gameObject.layer
			}.AddComponent<global::UIDrawCall>();
			uidrawCall.material = mat;
			uidrawCall.LinkedList__Insert(ref this.mDrawCalls);
			this.mDrawCallCount++;
		}
		return (global::UIDrawCall.Iterator)uidrawCall;
	}

	// Token: 0x0600519F RID: 20895 RVA: 0x001432CC File Offset: 0x001414CC
	protected void Awake()
	{
		global::UIPanel.Global.RegisterPanel(this);
	}

	// Token: 0x060051A0 RID: 20896 RVA: 0x001432D4 File Offset: 0x001414D4
	protected void Start()
	{
		this.mLayer = base.gameObject.layer;
		global::UICamera uicamera = global::UICamera.FindCameraForLayer(this.mLayer);
		this.mCam = ((!(uicamera != null)) ? global::NGUITools.FindCameraForLayer(this.mLayer) : uicamera.cachedCamera);
	}

	// Token: 0x060051A1 RID: 20897 RVA: 0x00143328 File Offset: 0x00141528
	protected void OnEnable()
	{
		global::UIPanel.Global.PanelEnabled(this);
		if (this.mHotSpots != null)
		{
			foreach (global::UIHotSpot uihotSpot in this.mHotSpots)
			{
				uihotSpot.OnPanelEnable();
			}
		}
		int i = 0;
		int count = this.mWidgets.Count;
		while (i < count)
		{
			this.AddWidget(this.mWidgets[i]);
			i++;
		}
		this.mRebuildAll = true;
	}

	// Token: 0x060051A2 RID: 20898 RVA: 0x001433D8 File Offset: 0x001415D8
	protected void OnDisable()
	{
		global::UIPanel.Global.PanelDisabled(this);
		if (this.mHotSpots != null)
		{
			foreach (global::UIHotSpot uihotSpot in this.mHotSpots)
			{
				uihotSpot.OnPanelDisable();
			}
		}
		global::UIDrawCall.Iterator iterator = (global::UIDrawCall.Iterator)this.mDrawCalls;
		while (iterator.Has)
		{
			global::UIDrawCall current = iterator.Current;
			iterator = iterator.Next;
			global::NGUITools.DestroyImmediate(current.gameObject);
		}
		this.mDrawCalls = null;
		this.mChanged.Clear();
		this.mChildren.Clear();
	}

	// Token: 0x060051A3 RID: 20899 RVA: 0x001434A4 File Offset: 0x001416A4
	protected void OnDestroy()
	{
		global::UIPanel.Global.UnregisterPanel(this);
		if (this.mHotSpots != null)
		{
			global::System.Collections.Generic.HashSet<global::UIHotSpot> hashSet = this.mHotSpots;
			this.mHotSpots = null;
			foreach (global::UIHotSpot uihotSpot in hashSet)
			{
				uihotSpot.OnPanelDestroy();
			}
		}
	}

	// Token: 0x060051A4 RID: 20900 RVA: 0x00143524 File Offset: 0x00141724
	private int GetChangeFlag(global::UINode start)
	{
		int num = start.changeFlag;
		if (num == -1)
		{
			global::UnityEngine.Transform parent = start.trans.parent;
			while (this.mChildren.Contains(parent))
			{
				global::UINode uinode = (global::UINode)this.mChildren[parent];
				num = uinode.changeFlag;
				parent = parent.parent;
				if (num != -1)
				{
					IL_7D:
					int i = 0;
					int count = global::UIPanel.mHierarchy.Count;
					while (i < count)
					{
						global::UINode uinode2 = global::UIPanel.mHierarchy[i];
						uinode2.changeFlag = num;
						i++;
					}
					global::UIPanel.mHierarchy.Clear();
					return num;
				}
				global::UIPanel.mHierarchy.Add(uinode);
			}
			num = 0;
			goto IL_7D;
		}
		return num;
	}

	// Token: 0x060051A5 RID: 20901 RVA: 0x001435F0 File Offset: 0x001417F0
	private void UpdateTransformMatrix()
	{
		float realtimeSinceStartup = global::UnityEngine.Time.realtimeSinceStartup;
		if (realtimeSinceStartup == 0f || this.mMatrixTime != realtimeSinceStartup)
		{
			this.mMatrixTime = realtimeSinceStartup;
			this.mWorldToLocal = this.cachedTransform.worldToLocalMatrix;
			if (this.mClipping != global::UIDrawCall.Clipping.None)
			{
				global::UnityEngine.Vector2 vector;
				vector..ctor(this.mClipRange.z, this.mClipRange.w);
				if (vector.x == 0f)
				{
					vector.x = ((!(this.mCam == null)) ? this.mCam.pixelWidth : ((float)global::UnityEngine.Screen.width));
				}
				if (vector.y == 0f)
				{
					vector.y = ((!(this.mCam == null)) ? this.mCam.pixelHeight : ((float)global::UnityEngine.Screen.height));
				}
				vector *= 0.5f;
				this.mMin.x = this.mClipRange.x - vector.x;
				this.mMin.y = this.mClipRange.y - vector.y;
				this.mMax.x = this.mClipRange.x + vector.x;
				this.mMax.y = this.mClipRange.y + vector.y;
			}
		}
	}

	// Token: 0x060051A6 RID: 20902 RVA: 0x0014375C File Offset: 0x0014195C
	private void UpdateTransforms()
	{
		this.mChangedLastFrame = false;
		bool flag = false;
		bool flag2 = global::UnityEngine.Time.realtimeSinceStartup > this.mCullTime;
		if (!this.widgetsAreStatic || flag2 != this.mCulled)
		{
			int i = 0;
			int count = this.mChildren.Count;
			while (i < count)
			{
				global::UINode uinode = (global::UINode)this.mChildren[i];
				if (uinode.trans == null)
				{
					this.mRemoved.Add(uinode.trans);
				}
				else if (uinode.HasChanged())
				{
					uinode.changeFlag = 1;
					flag = true;
				}
				else
				{
					uinode.changeFlag = -1;
				}
				i++;
			}
			int j = 0;
			int count2 = this.mRemoved.Count;
			while (j < count2)
			{
				this.mChildren.Remove(this.mRemoved[j]);
				j++;
			}
			this.mRemoved.Clear();
		}
		if (!this.mCulled && flag2)
		{
			this.mCheckVisibility = true;
		}
		if (this.mCheckVisibility || flag || this.mRebuildAll)
		{
			int k = 0;
			int count3 = this.mChildren.Count;
			while (k < count3)
			{
				global::UINode uinode2 = (global::UINode)this.mChildren[k];
				if (uinode2.widget != null)
				{
					int num = 1;
					if (flag2 || flag)
					{
						if (uinode2.changeFlag == -1)
						{
							uinode2.changeFlag = this.GetChangeFlag(uinode2);
						}
						if (flag2)
						{
							num = ((!this.mCheckVisibility && uinode2.changeFlag != 1) ? uinode2.visibleFlag : ((!this.IsVisible(uinode2.widget)) ? 0 : 1));
						}
					}
					if (uinode2.visibleFlag != num)
					{
						uinode2.changeFlag = 1;
					}
					if (uinode2.changeFlag == 1 && (num == 1 || uinode2.visibleFlag != 0))
					{
						uinode2.visibleFlag = num;
						global::UIMaterial material = uinode2.widget.material;
						if (!this.mChanged.Contains(material))
						{
							this.mChanged.Add(material);
							this.mChangedLastFrame = true;
						}
					}
				}
				k++;
			}
		}
		this.mCulled = flag2;
		this.mCheckVisibility = false;
	}

	// Token: 0x060051A7 RID: 20903 RVA: 0x001439CC File Offset: 0x00141BCC
	private void UpdateWidgets()
	{
		int i = 0;
		int count = this.mChildren.Count;
		while (i < count)
		{
			global::UINode uinode = (global::UINode)this.mChildren[i];
			global::UIWidget widget = uinode.widget;
			if (uinode.visibleFlag == 1 && widget != null && widget.UpdateGeometry(ref this.mWorldToLocal, uinode.changeFlag == 1, this.generateNormals) && !this.mChanged.Contains(widget.material))
			{
				this.mChanged.Add(widget.material);
				this.mChangedLastFrame = true;
			}
			uinode.changeFlag = 0;
			i++;
		}
	}

	// Token: 0x060051A8 RID: 20904 RVA: 0x00143A80 File Offset: 0x00141C80
	public void UpdateDrawcalls()
	{
		global::UnityEngine.Vector4 zero = global::UnityEngine.Vector4.zero;
		if (this.mClipping != global::UIDrawCall.Clipping.None)
		{
			zero..ctor(this.mClipRange.x, this.mClipRange.y, this.mClipRange.z * 0.5f, this.mClipRange.w * 0.5f);
		}
		if (zero.z == 0f)
		{
			zero.z = (float)global::UnityEngine.Screen.width * 0.5f;
		}
		if (zero.w == 0f)
		{
			zero.w = (float)global::UnityEngine.Screen.height * 0.5f;
		}
		global::UnityEngine.RuntimePlatform platform = global::UnityEngine.Application.platform;
		if (platform == 2 || platform == 5 || platform == 7)
		{
			zero.x -= 0.5f;
			zero.y += 0.5f;
		}
		global::UnityEngine.Vector3 position = this.cachedTransform.position;
		global::UnityEngine.Quaternion rotation = this.cachedTransform.rotation;
		global::UnityEngine.Vector3 lossyScale = this.cachedTransform.lossyScale;
		global::UIDrawCall.Iterator iterator = (global::UIDrawCall.Iterator)this.mDrawCalls;
		while (iterator.Has)
		{
			global::UIDrawCall current = iterator.Current;
			iterator = iterator.Next;
			current.clipping = this.mClipping;
			current.clipRange = zero;
			current.clipSoftness = this.mClipSoftness;
			current.depthPass = this.depthPass;
			current.panelPropertyBlock = this.propertyBlock;
			global::UnityEngine.Transform transform = current.transform;
			transform.position = position;
			transform.rotation = rotation;
			transform.localScale = lossyScale;
		}
	}

	// Token: 0x060051A9 RID: 20905 RVA: 0x00143C1C File Offset: 0x00141E1C
	private void Fill(global::UIMaterial mat)
	{
		int i = this.mWidgets.Count;
		while (i > 0)
		{
			if (this.mWidgets[--i] == null)
			{
				this.mWidgets.RemoveAt(i);
			}
		}
		int j = 0;
		int count = this.mWidgets.Count;
		while (j < count)
		{
			global::UIWidget uiwidget = this.mWidgets[j];
			if (uiwidget.visibleFlag == 1 && uiwidget.material == mat)
			{
				global::UINode node = this.GetNode(uiwidget.cachedTransform);
				if (node != null)
				{
					uiwidget.WriteToBuffers(this.mCacheBuffer);
				}
				else
				{
					global::UnityEngine.Debug.LogError("No transform found for " + global::NGUITools.GetHierarchy(uiwidget.gameObject), this);
				}
			}
			j++;
		}
		if (this.mCacheBuffer.vSize > 0)
		{
			global::UIDrawCall current = this.GetDrawCall(mat, true).Current;
			current.depthPass = this.depthPass;
			current.panelPropertyBlock = this.propertyBlock;
			current.Set(this.mCacheBuffer);
		}
		else
		{
			global::UIDrawCall.Iterator drawCall = this.GetDrawCall(mat, false);
			if (drawCall.Has)
			{
				this.Delete(ref drawCall);
			}
		}
		this.mCacheBuffer.Clear();
	}

	// Token: 0x060051AA RID: 20906 RVA: 0x00143D6C File Offset: 0x00141F6C
	private void Delete(ref global::UIDrawCall.Iterator iter)
	{
		if (iter.Has)
		{
			global::UIDrawCall current = iter.Current;
			if (object.ReferenceEquals(current, this.mDrawCalls))
			{
				this.mDrawCalls = iter.Next.Current;
			}
			iter = iter.Next;
			current.LinkedList__Remove();
			this.mDrawCallCount--;
			global::NGUITools.DestroyImmediate(current.gameObject);
		}
	}

	// Token: 0x060051AB RID: 20907 RVA: 0x00143DDC File Offset: 0x00141FDC
	private void PanelUpdate(bool letFill)
	{
		this.UpdateTransformMatrix();
		this.UpdateTransforms();
		if (this.mLayer != base.gameObject.layer)
		{
			this.mLayer = base.gameObject.layer;
			global::UICamera uicamera = global::UICamera.FindCameraForLayer(this.mLayer);
			this.mCam = ((!(uicamera != null)) ? global::NGUITools.FindCameraForLayer(this.mLayer) : uicamera.cachedCamera);
			global::UIPanel.SetChildLayer(this.cachedTransform, this.mLayer);
			global::UIDrawCall.Iterator iterator = (global::UIDrawCall.Iterator)this.mDrawCalls;
			while (iterator.Has)
			{
				iterator.Current.gameObject.layer = this.mLayer;
				iterator = iterator.Next;
			}
		}
		this.UpdateWidgets();
		if (this.mDepthChanged)
		{
			this.mDepthChanged = false;
			this.mWidgets.Sort(new global::System.Comparison<global::UIWidget>(global::UIWidget.CompareFunc));
		}
		if (letFill)
		{
			this.FillUpdate();
		}
		else
		{
			this.UpdateDrawcalls();
		}
		this.mRebuildAll = false;
	}

	// Token: 0x060051AC RID: 20908 RVA: 0x00143EEC File Offset: 0x001420EC
	public bool Contains(global::UIDrawCall drawcall)
	{
		global::UIDrawCall.Iterator iterator = (global::UIDrawCall.Iterator)this.mDrawCalls;
		while (iterator.Has)
		{
			if (object.ReferenceEquals(drawcall, iterator.Current))
			{
				return true;
			}
			iterator = iterator.Next;
		}
		return false;
	}

	// Token: 0x060051AD RID: 20909 RVA: 0x00143F34 File Offset: 0x00142134
	private void FillUpdate()
	{
		foreach (global::UIMaterial mat in this.mChanged)
		{
			this.Fill(mat);
		}
		this.UpdateDrawcalls();
		this.mChanged.Clear();
	}

	// Token: 0x060051AE RID: 20910 RVA: 0x00143FAC File Offset: 0x001421AC
	private void DefaultLateUpdate()
	{
		if (!this.manualPanelUpdate)
		{
			this.PanelUpdate(true);
		}
		else
		{
			this.FillUpdate();
		}
	}

	// Token: 0x060051AF RID: 20911 RVA: 0x00143FCC File Offset: 0x001421CC
	public bool ManualPanelUpdate()
	{
		if (this.manualPanelUpdate && base.enabled)
		{
			this.PanelUpdate(false);
			return true;
		}
		return false;
	}

	// Token: 0x060051B0 RID: 20912 RVA: 0x00143FFC File Offset: 0x001421FC
	public void Refresh()
	{
		base.BroadcastMessage("Update", 1);
		this.DefaultLateUpdate();
	}

	// Token: 0x060051B1 RID: 20913 RVA: 0x00144010 File Offset: 0x00142210
	private static bool CheckRayEnterClippingRect(global::UnityEngine.Ray ray, global::UnityEngine.Transform transform, global::UnityEngine.Vector4 clipRange)
	{
		global::UnityEngine.Plane plane;
		plane..ctor(transform.forward, transform.position);
		float num;
		if (plane.Raycast(ray, ref num))
		{
			global::UnityEngine.Vector3 vector = transform.InverseTransformPoint(ray.GetPoint(num));
			clipRange.z = global::UnityEngine.Mathf.Abs(clipRange.z);
			clipRange.w = global::UnityEngine.Mathf.Abs(clipRange.w);
			global::UnityEngine.Rect rect;
			rect..ctor(clipRange.x - clipRange.z / 2f, clipRange.y - clipRange.w / 2f, clipRange.z, clipRange.w);
			return rect.Contains(vector);
		}
		return false;
	}

	// Token: 0x060051B2 RID: 20914 RVA: 0x001440C0 File Offset: 0x001422C0
	internal bool InsideClippingRect(global::UnityEngine.Ray ray, int traceID)
	{
		if (this.clipping == global::UIDrawCall.Clipping.None)
		{
			return true;
		}
		if (traceID != this.traceID || ray.origin != this.lastRayTrace.origin || ray.direction != this.lastRayTrace.direction)
		{
			this.traceID = traceID;
			this.lastRayTrace = ray;
			this.lastRayTraceInside = global::UIPanel.CheckRayEnterClippingRect(ray, base.transform, this.clipRange);
		}
		return this.lastRayTraceInside;
	}

	// Token: 0x060051B3 RID: 20915 RVA: 0x0014414C File Offset: 0x0014234C
	public global::UnityEngine.Vector3 CalculateConstrainOffset(global::UnityEngine.Vector2 min, global::UnityEngine.Vector2 max)
	{
		float num = this.clipRange.z * 0.5f;
		float num2 = this.clipRange.w * 0.5f;
		global::UnityEngine.Vector2 minRect;
		minRect..ctor(min.x, min.y);
		global::UnityEngine.Vector2 maxRect;
		maxRect..ctor(max.x, max.y);
		global::UnityEngine.Vector2 minArea;
		minArea..ctor(this.clipRange.x - num, this.clipRange.y - num2);
		global::UnityEngine.Vector2 maxArea;
		maxArea..ctor(this.clipRange.x + num, this.clipRange.y + num2);
		if (this.clipping == global::UIDrawCall.Clipping.SoftClip)
		{
			minArea.x += this.clipSoftness.x;
			minArea.y += this.clipSoftness.y;
			maxArea.x -= this.clipSoftness.x;
			maxArea.y -= this.clipSoftness.y;
		}
		return global::NGUIMath.ConstrainRect(minRect, maxRect, minArea, maxArea);
	}

	// Token: 0x060051B4 RID: 20916 RVA: 0x00144294 File Offset: 0x00142494
	public bool ConstrainTargetToBounds(global::UnityEngine.Transform target, ref global::AABBox targetBounds, bool immediate)
	{
		global::UnityEngine.Vector3 vector = this.CalculateConstrainOffset(targetBounds.min, targetBounds.max);
		if (vector.magnitude > 0f)
		{
			if (immediate)
			{
				target.localPosition += vector;
				targetBounds.center += vector;
				global::SpringPosition component = target.GetComponent<global::SpringPosition>();
				if (component != null)
				{
					component.enabled = false;
				}
			}
			else
			{
				global::SpringPosition springPosition = global::SpringPosition.Begin(target.gameObject, target.localPosition + vector, 13f);
				springPosition.ignoreTimeScale = true;
				springPosition.worldSpace = false;
			}
			return true;
		}
		return false;
	}

	// Token: 0x060051B5 RID: 20917 RVA: 0x00144348 File Offset: 0x00142548
	public bool ConstrainTargetToBounds(global::UnityEngine.Transform target, bool immediate)
	{
		global::AABBox aabbox = global::NGUIMath.CalculateRelativeWidgetBounds(this.cachedTransform, target);
		return this.ConstrainTargetToBounds(target, ref aabbox, immediate);
	}

	// Token: 0x060051B6 RID: 20918 RVA: 0x0014436C File Offset: 0x0014256C
	private static void SetChildLayer(global::UnityEngine.Transform t, int layer)
	{
		for (int i = 0; i < t.childCount; i++)
		{
			global::UnityEngine.Transform child = t.GetChild(i);
			if (child.GetComponent<global::UIPanel>() == null)
			{
				child.gameObject.layer = layer;
				global::UIPanel.SetChildLayer(child, layer);
			}
		}
	}

	// Token: 0x060051B7 RID: 20919 RVA: 0x001443BC File Offset: 0x001425BC
	public static global::UIPanel Find(global::UnityEngine.Transform trans, bool createIfMissing)
	{
		global::UnityEngine.Transform transform = trans;
		global::UIPanel uipanel = null;
		while (uipanel == null && trans != null)
		{
			uipanel = trans.GetComponent<global::UIPanel>();
			if (uipanel != null)
			{
				break;
			}
			if (trans.parent == null)
			{
				break;
			}
			trans = trans.parent;
		}
		if (createIfMissing && uipanel == null && trans != transform)
		{
			uipanel = trans.gameObject.AddComponent<global::UIPanel>();
			global::UIPanel.SetChildLayer(uipanel.cachedTransform, uipanel.gameObject.layer);
		}
		return uipanel;
	}

	// Token: 0x060051B8 RID: 20920 RVA: 0x00144464 File Offset: 0x00142664
	public static global::UIPanel Find(global::UnityEngine.Transform trans)
	{
		return global::UIPanel.Find(trans, true);
	}

	// Token: 0x060051B9 RID: 20921 RVA: 0x00144470 File Offset: 0x00142670
	public static global::UIPanel FindRoot(global::UnityEngine.Transform trans)
	{
		global::UIPanel uipanel = global::UIPanel.Find(trans);
		return (!uipanel) ? null : uipanel.RootPanel;
	}

	// Token: 0x060051BA RID: 20922 RVA: 0x0014449C File Offset: 0x0014269C
	internal static void RegisterHotSpot(global::UIPanel panel, global::UIHotSpot hotSpot)
	{
		if (panel.mHotSpots == null)
		{
			panel.mHotSpots = new global::System.Collections.Generic.HashSet<global::UIHotSpot>();
		}
		if (panel.mHotSpots.Add(hotSpot))
		{
			if (panel.enabled)
			{
				hotSpot.OnPanelEnable();
			}
			else
			{
				hotSpot.OnPanelDisable();
			}
		}
	}

	// Token: 0x060051BB RID: 20923 RVA: 0x001444EC File Offset: 0x001426EC
	internal static void UnregisterHotSpot(global::UIPanel panel, global::UIHotSpot hotSpot)
	{
		if (panel.mHotSpots == null || !panel.mHotSpots.Remove(hotSpot))
		{
			return;
		}
		if (panel.enabled)
		{
			hotSpot.OnPanelDisable();
		}
	}

	// Token: 0x17000F41 RID: 3905
	// (get) Token: 0x060051BC RID: 20924 RVA: 0x00144528 File Offset: 0x00142728
	// (set) Token: 0x060051BD RID: 20925 RVA: 0x00144530 File Offset: 0x00142730
	public global::UIPanelMaterialPropertyBlock propertyBlock
	{
		get
		{
			return this._propertyBlock;
		}
		set
		{
			this._propertyBlock = value;
		}
	}

	// Token: 0x04002E17 RID: 11799
	[global::UnityEngine.SerializeField]
	private global::UIPanel _rootPanel;

	// Token: 0x04002E18 RID: 11800
	public bool showInPanelTool = true;

	// Token: 0x04002E19 RID: 11801
	public bool generateNormals;

	// Token: 0x04002E1A RID: 11802
	public bool depthPass;

	// Token: 0x04002E1B RID: 11803
	public bool widgetsAreStatic;

	// Token: 0x04002E1C RID: 11804
	[global::UnityEngine.HideInInspector]
	[global::UnityEngine.SerializeField]
	private global::UIPanel.DebugInfo mDebugInfo = global::UIPanel.DebugInfo.Gizmos;

	// Token: 0x04002E1D RID: 11805
	[global::UnityEngine.HideInInspector]
	[global::UnityEngine.SerializeField]
	private global::UIDrawCall.Clipping mClipping;

	// Token: 0x04002E1E RID: 11806
	[global::UnityEngine.HideInInspector]
	[global::UnityEngine.SerializeField]
	private global::UnityEngine.Vector4 mClipRange = global::UnityEngine.Vector4.zero;

	// Token: 0x04002E1F RID: 11807
	[global::UnityEngine.HideInInspector]
	[global::UnityEngine.SerializeField]
	private global::UnityEngine.Vector2 mClipSoftness = new global::UnityEngine.Vector2(40f, 40f);

	// Token: 0x04002E20 RID: 11808
	[global::UnityEngine.HideInInspector]
	[global::UnityEngine.SerializeField]
	private bool manualPanelUpdate;

	// Token: 0x04002E21 RID: 11809
	private global::System.Collections.Specialized.OrderedDictionary mChildren = new global::System.Collections.Specialized.OrderedDictionary();

	// Token: 0x04002E22 RID: 11810
	private global::System.Collections.Generic.List<global::UIWidget> mWidgets = new global::System.Collections.Generic.List<global::UIWidget>();

	// Token: 0x04002E23 RID: 11811
	private global::System.Collections.Generic.HashSet<global::UIMaterial> mChanged = new global::System.Collections.Generic.HashSet<global::UIMaterial>();

	// Token: 0x04002E24 RID: 11812
	private global::UIDrawCall mDrawCalls;

	// Token: 0x04002E25 RID: 11813
	private int mDrawCallCount;

	// Token: 0x04002E26 RID: 11814
	private global::NGUI.Meshing.MeshBuffer mCacheBuffer = new global::NGUI.Meshing.MeshBuffer();

	// Token: 0x04002E27 RID: 11815
	private global::System.Collections.Generic.HashSet<global::UIHotSpot> mHotSpots;

	// Token: 0x04002E28 RID: 11816
	private global::UnityEngine.Transform mTrans;

	// Token: 0x04002E29 RID: 11817
	private global::UnityEngine.Camera mCam;

	// Token: 0x04002E2A RID: 11818
	private int mLayer = -1;

	// Token: 0x04002E2B RID: 11819
	private bool mDepthChanged;

	// Token: 0x04002E2C RID: 11820
	private bool mRebuildAll;

	// Token: 0x04002E2D RID: 11821
	private bool mChangedLastFrame;

	// Token: 0x04002E2E RID: 11822
	private float mMatrixTime;

	// Token: 0x04002E2F RID: 11823
	private global::UnityEngine.Matrix4x4 mWorldToLocal = global::UnityEngine.Matrix4x4.identity;

	// Token: 0x04002E30 RID: 11824
	private static float[] mTemp = new float[4];

	// Token: 0x04002E31 RID: 11825
	private global::UnityEngine.Vector2 mMin = global::UnityEngine.Vector2.zero;

	// Token: 0x04002E32 RID: 11826
	private global::UnityEngine.Vector2 mMax = global::UnityEngine.Vector2.zero;

	// Token: 0x04002E33 RID: 11827
	private global::System.Collections.Generic.List<global::UnityEngine.Transform> mRemoved = new global::System.Collections.Generic.List<global::UnityEngine.Transform>();

	// Token: 0x04002E34 RID: 11828
	private bool mCheckVisibility;

	// Token: 0x04002E35 RID: 11829
	private float mCullTime;

	// Token: 0x04002E36 RID: 11830
	private bool mCulled;

	// Token: 0x04002E37 RID: 11831
	private int globalIndex = -1;

	// Token: 0x04002E38 RID: 11832
	private static global::System.Collections.Generic.List<global::UINode> mHierarchy = new global::System.Collections.Generic.List<global::UINode>();

	// Token: 0x04002E39 RID: 11833
	private int traceID;

	// Token: 0x04002E3A RID: 11834
	private global::UnityEngine.Ray lastRayTrace;

	// Token: 0x04002E3B RID: 11835
	private bool lastRayTraceInside;

	// Token: 0x04002E3C RID: 11836
	[global::System.NonSerialized]
	private global::UIPanelMaterialPropertyBlock _propertyBlock;

	// Token: 0x0200095B RID: 2395
	private static class Global
	{
		// Token: 0x17000F42 RID: 3906
		// (get) Token: 0x060051BE RID: 20926 RVA: 0x0014453C File Offset: 0x0014273C
		public static bool noGlobal
		{
			get
			{
				return !global::UnityEngine.Application.isPlaying;
			}
		}

		// Token: 0x060051BF RID: 20927 RVA: 0x00144548 File Offset: 0x00142748
		public static void RegisterPanel(global::UIPanel panel)
		{
			if (global::UIPanel.Global.noGlobal)
			{
				return;
			}
			global::UIGlobal.EnsureGlobal();
			if (panel.globalIndex == -1)
			{
				panel.globalIndex = global::UIPanel.Global.g.allPanels.Count;
				global::UIPanel.Global.g.allPanels.Add(panel);
			}
		}

		// Token: 0x060051C0 RID: 20928 RVA: 0x00144584 File Offset: 0x00142784
		public static void UnregisterPanel(global::UIPanel panel)
		{
			if (global::UIPanel.Global.noGlobal)
			{
				return;
			}
			if (panel.globalIndex != -1)
			{
				global::UIPanel.Global.g.allPanels.RemoveAt(panel.globalIndex);
				int i = panel.globalIndex;
				int count = global::UIPanel.Global.g.allPanels.Count;
				while (i < count)
				{
					global::UIPanel.Global.g.allPanels[i].globalIndex = i;
					i++;
				}
				panel.globalIndex = -1;
			}
		}

		// Token: 0x060051C1 RID: 20929 RVA: 0x001445F4 File Offset: 0x001427F4
		public static void PanelEnabled(global::UIPanel panel)
		{
			if (global::UIPanel.Global.noGlobal)
			{
				return;
			}
			global::UIPanel.Global.g.allEnabled.Add(panel);
		}

		// Token: 0x060051C2 RID: 20930 RVA: 0x00144610 File Offset: 0x00142810
		public static void PanelDisabled(global::UIPanel panel)
		{
			if (global::UIPanel.Global.noGlobal)
			{
				return;
			}
			global::UIPanel.Global.g.allEnabled.Remove(panel);
		}

		// Token: 0x060051C3 RID: 20931 RVA: 0x0014462C File Offset: 0x0014282C
		public static void PanelUpdate()
		{
			if (global::UIPanel.Global.noGlobal)
			{
				return;
			}
			try
			{
				global::UIPanel.Global.g.allEnableSwap.AddRange(global::UIPanel.Global.g.allEnabled);
				foreach (global::UIPanel uipanel in global::UIPanel.Global.g.allEnableSwap)
				{
					if (uipanel && uipanel.enabled)
					{
						uipanel.DefaultLateUpdate();
					}
				}
			}
			finally
			{
				global::UIPanel.Global.g.allEnableSwap.Clear();
			}
		}

		// Token: 0x0200095C RID: 2396
		private static class g
		{
			// Token: 0x060051C4 RID: 20932 RVA: 0x001446E8 File Offset: 0x001428E8
			static g()
			{
				global::UIGlobal.EnsureGlobal();
			}

			// Token: 0x04002E3D RID: 11837
			public static global::System.Collections.Generic.HashSet<global::UIPanel> allEnabled = new global::System.Collections.Generic.HashSet<global::UIPanel>();

			// Token: 0x04002E3E RID: 11838
			public static global::System.Collections.Generic.List<global::UIPanel> allEnableSwap = new global::System.Collections.Generic.List<global::UIPanel>();

			// Token: 0x04002E3F RID: 11839
			public static global::System.Collections.Generic.List<global::UIPanel> allPanels = new global::System.Collections.Generic.List<global::UIPanel>();
		}
	}

	// Token: 0x0200095D RID: 2397
	public enum DebugInfo
	{
		// Token: 0x04002E41 RID: 11841
		None,
		// Token: 0x04002E42 RID: 11842
		Gizmos,
		// Token: 0x04002E43 RID: 11843
		Geometry
	}
}
