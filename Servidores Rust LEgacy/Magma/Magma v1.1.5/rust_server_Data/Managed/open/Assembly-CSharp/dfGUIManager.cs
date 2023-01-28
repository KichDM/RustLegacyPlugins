using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x02000807 RID: 2055
[global::System.Serializable]
[global::UnityEngine.AddComponentMenu("Daikon Forge/User Interface/GUI Manager")]
[global::UnityEngine.ExecuteInEditMode]
[global::UnityEngine.RequireComponent(typeof(global::UnityEngine.MeshFilter))]
[global::UnityEngine.RequireComponent(typeof(global::dfInputManager))]
[global::UnityEngine.RequireComponent(typeof(global::UnityEngine.BoxCollider))]
[global::UnityEngine.RequireComponent(typeof(global::UnityEngine.MeshRenderer))]
public class dfGUIManager : global::UnityEngine.MonoBehaviour
{
	// Token: 0x060044E6 RID: 17638 RVA: 0x000FB72C File Offset: 0x000F992C
	public dfGUIManager()
	{
	}

	// Token: 0x060044E7 RID: 17639 RVA: 0x000FB7C0 File Offset: 0x000F99C0
	// Note: this type is marked as 'beforefieldinit'.
	static dfGUIManager()
	{
	}

	// Token: 0x14000048 RID: 72
	// (add) Token: 0x060044E8 RID: 17640 RVA: 0x000FB7E4 File Offset: 0x000F99E4
	// (remove) Token: 0x060044E9 RID: 17641 RVA: 0x000FB7FC File Offset: 0x000F99FC
	public static event global::dfGUIManager.RenderCallback BeforeRender
	{
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		add
		{
			global::dfGUIManager.BeforeRender = (global::dfGUIManager.RenderCallback)global::System.Delegate.Combine(global::dfGUIManager.BeforeRender, value);
		}
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		remove
		{
			global::dfGUIManager.BeforeRender = (global::dfGUIManager.RenderCallback)global::System.Delegate.Remove(global::dfGUIManager.BeforeRender, value);
		}
	}

	// Token: 0x14000049 RID: 73
	// (add) Token: 0x060044EA RID: 17642 RVA: 0x000FB814 File Offset: 0x000F9A14
	// (remove) Token: 0x060044EB RID: 17643 RVA: 0x000FB82C File Offset: 0x000F9A2C
	public static event global::dfGUIManager.RenderCallback AfterRender
	{
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		add
		{
			global::dfGUIManager.AfterRender = (global::dfGUIManager.RenderCallback)global::System.Delegate.Combine(global::dfGUIManager.AfterRender, value);
		}
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		remove
		{
			global::dfGUIManager.AfterRender = (global::dfGUIManager.RenderCallback)global::System.Delegate.Remove(global::dfGUIManager.AfterRender, value);
		}
	}

	// Token: 0x17000CCF RID: 3279
	// (get) Token: 0x060044EC RID: 17644 RVA: 0x000FB844 File Offset: 0x000F9A44
	// (set) Token: 0x060044ED RID: 17645 RVA: 0x000FB84C File Offset: 0x000F9A4C
	public int TotalDrawCalls
	{
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		get
		{
			return this.<TotalDrawCalls>k__BackingField;
		}
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private set
		{
			this.<TotalDrawCalls>k__BackingField = value;
		}
	}

	// Token: 0x17000CD0 RID: 3280
	// (get) Token: 0x060044EE RID: 17646 RVA: 0x000FB858 File Offset: 0x000F9A58
	// (set) Token: 0x060044EF RID: 17647 RVA: 0x000FB860 File Offset: 0x000F9A60
	public int TotalTriangles
	{
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		get
		{
			return this.<TotalTriangles>k__BackingField;
		}
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private set
		{
			this.<TotalTriangles>k__BackingField = value;
		}
	}

	// Token: 0x17000CD1 RID: 3281
	// (get) Token: 0x060044F0 RID: 17648 RVA: 0x000FB86C File Offset: 0x000F9A6C
	// (set) Token: 0x060044F1 RID: 17649 RVA: 0x000FB874 File Offset: 0x000F9A74
	public int ControlsRendered
	{
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		get
		{
			return this.<ControlsRendered>k__BackingField;
		}
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private set
		{
			this.<ControlsRendered>k__BackingField = value;
		}
	}

	// Token: 0x17000CD2 RID: 3282
	// (get) Token: 0x060044F2 RID: 17650 RVA: 0x000FB880 File Offset: 0x000F9A80
	// (set) Token: 0x060044F3 RID: 17651 RVA: 0x000FB888 File Offset: 0x000F9A88
	public int FramesRendered
	{
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		get
		{
			return this.<FramesRendered>k__BackingField;
		}
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private set
		{
			this.<FramesRendered>k__BackingField = value;
		}
	}

	// Token: 0x17000CD3 RID: 3283
	// (get) Token: 0x060044F4 RID: 17652 RVA: 0x000FB894 File Offset: 0x000F9A94
	public static global::dfControl ActiveControl
	{
		get
		{
			return global::dfGUIManager.activeControl;
		}
	}

	// Token: 0x17000CD4 RID: 3284
	// (get) Token: 0x060044F5 RID: 17653 RVA: 0x000FB89C File Offset: 0x000F9A9C
	// (set) Token: 0x060044F6 RID: 17654 RVA: 0x000FB8A4 File Offset: 0x000F9AA4
	public float UIScale
	{
		get
		{
			return this.uiScale;
		}
		set
		{
			if (!global::UnityEngine.Mathf.Approximately(value, this.uiScale))
			{
				this.uiScale = value;
				this.onResolutionChanged();
			}
		}
	}

	// Token: 0x17000CD5 RID: 3285
	// (get) Token: 0x060044F7 RID: 17655 RVA: 0x000FB8C4 File Offset: 0x000F9AC4
	// (set) Token: 0x060044F8 RID: 17656 RVA: 0x000FB8CC File Offset: 0x000F9ACC
	public global::UnityEngine.Vector2 UIOffset
	{
		get
		{
			return this.uiOffset;
		}
		set
		{
			if (!object.Equals(this.uiOffset, value))
			{
				this.uiOffset = value;
				this.Invalidate();
			}
		}
	}

	// Token: 0x17000CD6 RID: 3286
	// (get) Token: 0x060044F9 RID: 17657 RVA: 0x000FB904 File Offset: 0x000F9B04
	// (set) Token: 0x060044FA RID: 17658 RVA: 0x000FB90C File Offset: 0x000F9B0C
	public global::UnityEngine.Camera RenderCamera
	{
		get
		{
			return this.renderCamera;
		}
		set
		{
			if (!object.ReferenceEquals(this.renderCamera, value))
			{
				this.renderCamera = value;
				this.Invalidate();
				if (value != null && value.gameObject.GetComponent<global::dfGUICamera>() == null)
				{
					value.gameObject.AddComponent<global::dfGUICamera>();
				}
				if (this.inputManager != null)
				{
					this.inputManager.RenderCamera = value;
				}
			}
		}
	}

	// Token: 0x17000CD7 RID: 3287
	// (get) Token: 0x060044FB RID: 17659 RVA: 0x000FB984 File Offset: 0x000F9B84
	// (set) Token: 0x060044FC RID: 17660 RVA: 0x000FB98C File Offset: 0x000F9B8C
	public bool MergeMaterials
	{
		get
		{
			return this.mergeMaterials;
		}
		set
		{
			if (value != this.mergeMaterials)
			{
				this.mergeMaterials = value;
				this.invalidateAllControls();
			}
		}
	}

	// Token: 0x17000CD8 RID: 3288
	// (get) Token: 0x060044FD RID: 17661 RVA: 0x000FB9A8 File Offset: 0x000F9BA8
	// (set) Token: 0x060044FE RID: 17662 RVA: 0x000FB9B0 File Offset: 0x000F9BB0
	public bool GenerateNormals
	{
		get
		{
			return this.generateNormals;
		}
		set
		{
			if (value != this.generateNormals)
			{
				this.generateNormals = value;
				if (this.renderMesh != null)
				{
					this.renderMesh[0].Clear();
					this.renderMesh[1].Clear();
				}
				global::dfRenderData.FlushObjectPool();
				this.invalidateAllControls();
			}
		}
	}

	// Token: 0x17000CD9 RID: 3289
	// (get) Token: 0x060044FF RID: 17663 RVA: 0x000FBA00 File Offset: 0x000F9C00
	// (set) Token: 0x06004500 RID: 17664 RVA: 0x000FBA08 File Offset: 0x000F9C08
	public bool PixelPerfectMode
	{
		get
		{
			return this.pixelPerfectMode;
		}
		set
		{
			if (value != this.pixelPerfectMode)
			{
				this.pixelPerfectMode = value;
				this.onResolutionChanged();
				this.Invalidate();
			}
		}
	}

	// Token: 0x17000CDA RID: 3290
	// (get) Token: 0x06004501 RID: 17665 RVA: 0x000FBA2C File Offset: 0x000F9C2C
	// (set) Token: 0x06004502 RID: 17666 RVA: 0x000FBA34 File Offset: 0x000F9C34
	public global::dfAtlas DefaultAtlas
	{
		get
		{
			return this.atlas;
		}
		set
		{
			if (!global::dfAtlas.Equals(value, this.atlas))
			{
				this.atlas = value;
				this.invalidateAllControls();
			}
		}
	}

	// Token: 0x17000CDB RID: 3291
	// (get) Token: 0x06004503 RID: 17667 RVA: 0x000FBA54 File Offset: 0x000F9C54
	// (set) Token: 0x06004504 RID: 17668 RVA: 0x000FBA5C File Offset: 0x000F9C5C
	public global::dfFont DefaultFont
	{
		get
		{
			return this.defaultFont;
		}
		set
		{
			if (value != this.defaultFont)
			{
				this.defaultFont = value;
				this.invalidateAllControls();
			}
		}
	}

	// Token: 0x17000CDC RID: 3292
	// (get) Token: 0x06004505 RID: 17669 RVA: 0x000FBA7C File Offset: 0x000F9C7C
	// (set) Token: 0x06004506 RID: 17670 RVA: 0x000FBA84 File Offset: 0x000F9C84
	public int FixedWidth
	{
		get
		{
			return this.fixedWidth;
		}
		set
		{
			if (value != this.fixedWidth)
			{
				this.fixedWidth = value;
				this.onResolutionChanged();
			}
		}
	}

	// Token: 0x17000CDD RID: 3293
	// (get) Token: 0x06004507 RID: 17671 RVA: 0x000FBAA0 File Offset: 0x000F9CA0
	// (set) Token: 0x06004508 RID: 17672 RVA: 0x000FBAA8 File Offset: 0x000F9CA8
	public int FixedHeight
	{
		get
		{
			return this.fixedHeight;
		}
		set
		{
			if (value != this.fixedHeight)
			{
				int oldSize = this.fixedHeight;
				this.fixedHeight = value;
				this.onResolutionChanged(oldSize, value);
			}
		}
	}

	// Token: 0x17000CDE RID: 3294
	// (get) Token: 0x06004509 RID: 17673 RVA: 0x000FBAD8 File Offset: 0x000F9CD8
	// (set) Token: 0x0600450A RID: 17674 RVA: 0x000FBAE0 File Offset: 0x000F9CE0
	public bool ConsumeMouseEvents
	{
		get
		{
			return this.consumeMouseEvents;
		}
		set
		{
			this.consumeMouseEvents = value;
		}
	}

	// Token: 0x17000CDF RID: 3295
	// (get) Token: 0x0600450B RID: 17675 RVA: 0x000FBAEC File Offset: 0x000F9CEC
	// (set) Token: 0x0600450C RID: 17676 RVA: 0x000FBAF4 File Offset: 0x000F9CF4
	public bool OverrideCamera
	{
		get
		{
			return this.overrideCamera;
		}
		set
		{
			this.overrideCamera = value;
		}
	}

	// Token: 0x0600450D RID: 17677 RVA: 0x000FBB00 File Offset: 0x000F9D00
	public void OnGUI()
	{
		if (this.overrideCamera || !this.consumeMouseEvents || !global::UnityEngine.Application.isPlaying || this.occluders == null)
		{
			return;
		}
		global::UnityEngine.Vector3 mousePosition = global::UnityEngine.Input.mousePosition;
		mousePosition.y = (float)global::UnityEngine.Screen.height - mousePosition.y;
		if (global::dfGUIManager.modalControlStack.Count > 0)
		{
			global::UnityEngine.GUI.Box(new global::UnityEngine.Rect(0f, 0f, (float)global::UnityEngine.Screen.width, (float)global::UnityEngine.Screen.height), global::UnityEngine.GUIContent.none, global::UnityEngine.GUIStyle.none);
		}
		for (int i = 0; i < this.occluders.Count; i++)
		{
			if (this.occluders[i].Contains(mousePosition))
			{
				global::UnityEngine.GUI.Box(this.occluders[i], global::UnityEngine.GUIContent.none, global::UnityEngine.GUIStyle.none);
				break;
			}
		}
		if (global::UnityEngine.Event.current.isMouse && global::UnityEngine.Input.touchCount > 0)
		{
			int touchCount = global::UnityEngine.Input.touchCount;
			for (int j = 0; j < touchCount; j++)
			{
				global::UnityEngine.Touch touch = global::UnityEngine.Input.GetTouch(j);
				if (touch.phase == null)
				{
					global::UnityEngine.Vector2 touchPosition = touch.position;
					touchPosition.y = (float)global::UnityEngine.Screen.height - touchPosition.y;
					if (this.occluders.Any((global::UnityEngine.Rect x) => x.Contains(touchPosition)))
					{
						global::UnityEngine.Event.current.Use();
						break;
					}
				}
			}
		}
	}

	// Token: 0x0600450E RID: 17678 RVA: 0x000FBC8C File Offset: 0x000F9E8C
	public virtual void OnDestroy()
	{
		if (this.meshRenderer != null)
		{
			this.renderFilter.sharedMesh = null;
			global::UnityEngine.Object.DestroyImmediate(this.renderMesh[0]);
			global::UnityEngine.Object.DestroyImmediate(this.renderMesh[1]);
			this.renderMesh = null;
		}
	}

	// Token: 0x0600450F RID: 17679 RVA: 0x000FBCD8 File Offset: 0x000F9ED8
	public virtual void Awake()
	{
		global::dfRenderData.FlushObjectPool();
	}

	// Token: 0x06004510 RID: 17680 RVA: 0x000FBCE0 File Offset: 0x000F9EE0
	public virtual void OnEnable()
	{
		this.FramesRendered = 0;
		this.TotalDrawCalls = 0;
		this.TotalTriangles = 0;
		if (this.meshRenderer != null)
		{
			this.meshRenderer.enabled = true;
		}
		if (global::UnityEngine.Application.isPlaying)
		{
			this.onResolutionChanged();
		}
	}

	// Token: 0x06004511 RID: 17681 RVA: 0x000FBD30 File Offset: 0x000F9F30
	public virtual void OnDisable()
	{
		if (this.meshRenderer != null)
		{
			this.meshRenderer.enabled = false;
		}
	}

	// Token: 0x06004512 RID: 17682 RVA: 0x000FBD50 File Offset: 0x000F9F50
	public virtual void Start()
	{
		global::UnityEngine.Camera[] array = global::UnityEngine.Object.FindObjectsOfType(typeof(global::UnityEngine.Camera)) as global::UnityEngine.Camera[];
		for (int i = 0; i < array.Length; i++)
		{
			array[i].eventMask &= ~(1 << base.gameObject.layer);
		}
		this.inputManager = (base.GetComponent<global::dfInputManager>() ?? base.gameObject.AddComponent<global::dfInputManager>());
		this.inputManager.RenderCamera = this.RenderCamera;
		this.FramesRendered = 0;
		this.invalidateAllControls();
		this.updateRenderOrder(null);
		if (this.meshRenderer != null)
		{
			this.meshRenderer.enabled = true;
		}
	}

	// Token: 0x06004513 RID: 17683 RVA: 0x000FBE0C File Offset: 0x000FA00C
	public virtual void Update()
	{
		if (this.renderCamera == null || !base.enabled)
		{
			if (this.meshRenderer != null)
			{
				this.meshRenderer.enabled = false;
			}
			return;
		}
		if (this.renderMesh == null || this.renderMesh.Length == 0)
		{
			this.initialize();
			if (global::UnityEngine.Application.isEditor && !global::UnityEngine.Application.isPlaying)
			{
				this.Render();
			}
		}
		if (this.cachedChildCount != base.transform.childCount)
		{
			this.cachedChildCount = base.transform.childCount;
			this.Invalidate();
		}
		global::UnityEngine.Vector2 screenSize = this.GetScreenSize();
		if ((screenSize - this.cachedScreenSize).sqrMagnitude > 1E-45f)
		{
			this.onResolutionChanged(this.cachedScreenSize, screenSize);
			this.cachedScreenSize = screenSize;
		}
	}

	// Token: 0x06004514 RID: 17684 RVA: 0x000FBEF4 File Offset: 0x000FA0F4
	public virtual void LateUpdate()
	{
		if (this.renderMesh == null || this.renderMesh.Length == 0)
		{
			this.initialize();
		}
		if (!global::UnityEngine.Application.isPlaying)
		{
			global::UnityEngine.BoxCollider boxCollider = base.collider as global::UnityEngine.BoxCollider;
			if (boxCollider != null)
			{
				global::UnityEngine.Vector2 vector = this.GetScreenSize() * this.PixelsToUnits();
				boxCollider.center = global::UnityEngine.Vector3.zero;
				boxCollider.size = vector;
			}
		}
		if (this.isDirty)
		{
			this.isDirty = false;
			this.Render();
		}
	}

	// Token: 0x06004515 RID: 17685 RVA: 0x000FBF84 File Offset: 0x000FA184
	public global::dfControl HitTest(global::UnityEngine.Vector2 screenPosition)
	{
		global::UnityEngine.Ray ray = this.renderCamera.ScreenPointToRay(screenPosition);
		float num = this.renderCamera.farClipPlane - this.renderCamera.nearClipPlane;
		global::UnityEngine.RaycastHit[] array = global::UnityEngine.Physics.RaycastAll(ray, num, this.renderCamera.cullingMask);
		global::System.Array.Sort<global::UnityEngine.RaycastHit>(array, new global::System.Comparison<global::UnityEngine.RaycastHit>(global::dfInputManager.raycastHitSorter));
		return this.inputManager.clipCast(array);
	}

	// Token: 0x06004516 RID: 17686 RVA: 0x000FBFEC File Offset: 0x000FA1EC
	public global::UnityEngine.Vector2 WorldPointToGUI(global::UnityEngine.Vector3 worldPoint)
	{
		global::UnityEngine.Vector2 screenSize = this.GetScreenSize();
		global::UnityEngine.Camera main = global::UnityEngine.Camera.main;
		global::UnityEngine.Vector3 vector = global::UnityEngine.Camera.main.WorldToScreenPoint(worldPoint);
		vector.x = screenSize.x * (vector.x / main.pixelWidth);
		vector.y = screenSize.y * (vector.y / main.pixelHeight);
		return this.ScreenToGui(vector);
	}

	// Token: 0x06004517 RID: 17687 RVA: 0x000FC058 File Offset: 0x000FA258
	public float PixelsToUnits()
	{
		float num = 2f / (float)this.FixedHeight;
		return num * this.UIScale;
	}

	// Token: 0x06004518 RID: 17688 RVA: 0x000FC07C File Offset: 0x000FA27C
	public virtual global::UnityEngine.Plane[] GetClippingPlanes()
	{
		global::UnityEngine.Vector3[] array = this.GetCorners();
		global::UnityEngine.Vector3 vector = base.transform.TransformDirection(global::UnityEngine.Vector3.right);
		global::UnityEngine.Vector3 vector2 = base.transform.TransformDirection(global::UnityEngine.Vector3.left);
		global::UnityEngine.Vector3 vector3 = base.transform.TransformDirection(global::UnityEngine.Vector3.up);
		global::UnityEngine.Vector3 vector4 = base.transform.TransformDirection(global::UnityEngine.Vector3.down);
		return new global::UnityEngine.Plane[]
		{
			new global::UnityEngine.Plane(vector, array[0]),
			new global::UnityEngine.Plane(vector2, array[1]),
			new global::UnityEngine.Plane(vector3, array[2]),
			new global::UnityEngine.Plane(vector4, array[0])
		};
	}

	// Token: 0x06004519 RID: 17689 RVA: 0x000FC154 File Offset: 0x000FA354
	public global::UnityEngine.Vector3[] GetCorners()
	{
		float num = this.PixelsToUnits();
		global::UnityEngine.Vector2 vector = this.GetScreenSize() * num;
		float x = vector.x;
		float y = vector.y;
		global::UnityEngine.Vector3 vector2;
		vector2..ctor(-x * 0.5f, y * 0.5f);
		global::UnityEngine.Vector3 vector3 = vector2 + new global::UnityEngine.Vector3(x, 0f);
		global::UnityEngine.Vector3 vector4 = vector2 + new global::UnityEngine.Vector3(0f, -y);
		global::UnityEngine.Vector3 vector5 = vector3 + new global::UnityEngine.Vector3(0f, -y);
		global::UnityEngine.Matrix4x4 localToWorldMatrix = base.transform.localToWorldMatrix;
		this.corners[0] = localToWorldMatrix.MultiplyPoint(vector2);
		this.corners[1] = localToWorldMatrix.MultiplyPoint(vector3);
		this.corners[2] = localToWorldMatrix.MultiplyPoint(vector5);
		this.corners[3] = localToWorldMatrix.MultiplyPoint(vector4);
		return this.corners;
	}

	// Token: 0x0600451A RID: 17690 RVA: 0x000FC254 File Offset: 0x000FA454
	public global::UnityEngine.Vector2 GetScreenSize()
	{
		global::UnityEngine.Camera camera = this.RenderCamera;
		bool flag = global::UnityEngine.Application.isPlaying && camera != null;
		if (flag)
		{
			float num = (!this.PixelPerfectMode) ? (camera.pixelHeight / (float)this.fixedHeight * this.uiScale) : 1f;
			return (new global::UnityEngine.Vector2(camera.pixelWidth, camera.pixelHeight) / num).CeilToInt();
		}
		return new global::UnityEngine.Vector2((float)this.FixedWidth, (float)this.FixedHeight);
	}

	// Token: 0x0600451B RID: 17691 RVA: 0x000FC2E0 File Offset: 0x000FA4E0
	public T AddControl<T>() where T : global::dfControl
	{
		return (T)((object)this.AddControl(typeof(T)));
	}

	// Token: 0x0600451C RID: 17692 RVA: 0x000FC2F8 File Offset: 0x000FA4F8
	public global::dfControl AddControl(global::System.Type type)
	{
		if (!typeof(global::dfControl).IsAssignableFrom(type))
		{
			throw new global::System.InvalidCastException();
		}
		global::dfControl dfControl = new global::UnityEngine.GameObject(type.Name, new global::System.Type[]
		{
			type
		})
		{
			transform = 
			{
				parent = base.transform
			},
			layer = base.gameObject.layer
		}.GetComponent(type) as global::dfControl;
		dfControl.ZOrder = this.getMaxZOrder() + 1;
		return dfControl;
	}

	// Token: 0x0600451D RID: 17693 RVA: 0x000FC374 File Offset: 0x000FA574
	private int getMaxZOrder()
	{
		int num = -1;
		using (global::dfList<global::dfControl> topLevelControls = this.getTopLevelControls())
		{
			for (int i = 0; i < topLevelControls.Count; i++)
			{
				num = global::UnityEngine.Mathf.Max(num, topLevelControls[i].ZOrder);
			}
		}
		return num;
	}

	// Token: 0x0600451E RID: 17694 RVA: 0x000FC3E4 File Offset: 0x000FA5E4
	public global::dfRenderData GetDrawCallBuffer(int drawCallNumber)
	{
		return this.drawCallBuffers[drawCallNumber];
	}

	// Token: 0x0600451F RID: 17695 RVA: 0x000FC3F4 File Offset: 0x000FA5F4
	public static global::dfControl GetModalControl()
	{
		return (global::dfGUIManager.modalControlStack.Count <= 0) ? null : global::dfGUIManager.modalControlStack.Peek().control;
	}

	// Token: 0x06004520 RID: 17696 RVA: 0x000FC42C File Offset: 0x000FA62C
	public global::UnityEngine.Vector2 ScreenToGui(global::UnityEngine.Vector2 position)
	{
		position.y = this.GetScreenSize().y - position.y;
		return position;
	}

	// Token: 0x06004521 RID: 17697 RVA: 0x000FC458 File Offset: 0x000FA658
	public static void PushModal(global::dfControl control, global::dfGUIManager.ModalPoppedCallback callback = null)
	{
		if (control == null)
		{
			throw new global::System.NullReferenceException("Cannot call PushModal() with a null reference");
		}
		global::dfGUIManager.modalControlStack.Push(new global::dfGUIManager.ModalControlReference
		{
			control = control,
			callback = callback
		});
	}

	// Token: 0x06004522 RID: 17698 RVA: 0x000FC4A0 File Offset: 0x000FA6A0
	public static void PopModal()
	{
		if (global::dfGUIManager.modalControlStack.Count == 0)
		{
			throw new global::System.InvalidOperationException("Modal stack is empty");
		}
		global::dfGUIManager.ModalControlReference modalControlReference = global::dfGUIManager.modalControlStack.Pop();
		if (modalControlReference.callback != null)
		{
			modalControlReference.callback(modalControlReference.control);
		}
	}

	// Token: 0x06004523 RID: 17699 RVA: 0x000FC4F4 File Offset: 0x000FA6F4
	public static void SetFocus(global::dfControl control)
	{
		if (global::dfGUIManager.activeControl == control)
		{
			return;
		}
		global::dfControl dfControl = global::dfGUIManager.activeControl;
		global::dfGUIManager.activeControl = control;
		global::dfFocusEventArgs args = new global::dfFocusEventArgs(control, dfControl);
		global::dfList<global::dfControl> prevFocusChain = global::dfList<global::dfControl>.Obtain();
		if (dfControl != null)
		{
			global::dfControl dfControl2 = dfControl;
			while (dfControl2 != null)
			{
				prevFocusChain.Add(dfControl2);
				dfControl2 = dfControl2.Parent;
			}
		}
		global::dfList<global::dfControl> newFocusChain = global::dfList<global::dfControl>.Obtain();
		if (control != null)
		{
			global::dfControl dfControl3 = control;
			while (dfControl3 != null)
			{
				newFocusChain.Add(dfControl3);
				dfControl3 = dfControl3.Parent;
			}
		}
		if (dfControl != null)
		{
			prevFocusChain.ForEach(delegate(global::dfControl c)
			{
				if (!newFocusChain.Contains(c))
				{
					c.OnLeaveFocus(args);
				}
			});
			dfControl.OnLostFocus(args);
		}
		if (control != null)
		{
			newFocusChain.ForEach(delegate(global::dfControl c)
			{
				if (!prevFocusChain.Contains(c))
				{
					c.OnEnterFocus(args);
				}
			});
			control.OnGotFocus(args);
		}
		newFocusChain.Release();
		prevFocusChain.Release();
	}

	// Token: 0x06004524 RID: 17700 RVA: 0x000FC620 File Offset: 0x000FA820
	public static bool HasFocus(global::dfControl control)
	{
		return !(control == null) && global::dfGUIManager.activeControl == control;
	}

	// Token: 0x06004525 RID: 17701 RVA: 0x000FC63C File Offset: 0x000FA83C
	public static bool ContainsFocus(global::dfControl control)
	{
		return global::dfGUIManager.activeControl == control || (!(global::dfGUIManager.activeControl == null) && !(control == null) && global::dfGUIManager.activeControl.transform.IsChildOf(control.transform));
	}

	// Token: 0x06004526 RID: 17702 RVA: 0x000FC690 File Offset: 0x000FA890
	public void BringToFront(global::dfControl control)
	{
		if (control.Parent != null)
		{
			control = control.GetRootContainer();
		}
		using (global::dfList<global::dfControl> topLevelControls = this.getTopLevelControls())
		{
			int zorder = 0;
			for (int i = 0; i < topLevelControls.Count; i++)
			{
				global::dfControl dfControl = topLevelControls[i];
				if (dfControl != control)
				{
					dfControl.ZOrder = zorder++;
				}
			}
			control.ZOrder = zorder;
			this.Invalidate();
		}
	}

	// Token: 0x06004527 RID: 17703 RVA: 0x000FC730 File Offset: 0x000FA930
	public void SendToBack(global::dfControl control)
	{
		if (control.Parent != null)
		{
			control = control.GetRootContainer();
		}
		using (global::dfList<global::dfControl> topLevelControls = this.getTopLevelControls())
		{
			int num = 1;
			for (int i = 0; i < topLevelControls.Count; i++)
			{
				global::dfControl dfControl = topLevelControls[i];
				if (dfControl != control)
				{
					dfControl.ZOrder = num++;
				}
			}
			control.ZOrder = 0;
			this.Invalidate();
		}
	}

	// Token: 0x06004528 RID: 17704 RVA: 0x000FC7D0 File Offset: 0x000FA9D0
	public void Invalidate()
	{
		if (this.isDirty)
		{
			return;
		}
		this.isDirty = true;
		this.updateRenderSettings();
	}

	// Token: 0x06004529 RID: 17705 RVA: 0x000FC7EC File Offset: 0x000FA9EC
	public static void RefreshAll(bool force = false)
	{
		global::dfGUIManager[] array = global::UnityEngine.Object.FindObjectsOfType(typeof(global::dfGUIManager)) as global::dfGUIManager[];
		for (int i = 0; i < array.Length; i++)
		{
			array[i].invalidateAllControls();
			if (force || !global::UnityEngine.Application.isPlaying)
			{
				array[i].Render();
			}
		}
	}

	// Token: 0x0600452A RID: 17706 RVA: 0x000FC844 File Offset: 0x000FAA44
	public void Render()
	{
		this.FramesRendered++;
		if (global::dfGUIManager.BeforeRender != null)
		{
			global::dfGUIManager.BeforeRender(this);
		}
		try
		{
			this.updateRenderSettings();
			this.ControlsRendered = 0;
			this.occluders.Clear();
			this.TotalDrawCalls = 0;
			this.TotalTriangles = 0;
			if (this.RenderCamera == null || !base.enabled)
			{
				if (this.meshRenderer != null)
				{
					this.meshRenderer.enabled = false;
				}
			}
			else
			{
				if (this.meshRenderer != null && !this.meshRenderer.enabled)
				{
					this.meshRenderer.enabled = true;
				}
				if (this.renderMesh == null || this.renderMesh.Length == 0)
				{
					global::UnityEngine.Debug.LogError("GUI Manager not initialized before Render() called");
				}
				else
				{
					this.resetDrawCalls();
					global::dfRenderData dfRenderData = null;
					this.clipStack.Clear();
					this.clipStack.Push(global::dfGUIManager.ClipRegion.Obtain());
					uint start_VALUE = global::dfChecksumUtil.START_VALUE;
					using (global::dfList<global::dfControl> topLevelControls = this.getTopLevelControls())
					{
						this.updateRenderOrder(topLevelControls);
						for (int i = 0; i < topLevelControls.Count; i++)
						{
							global::dfControl control = topLevelControls[i];
							this.renderControl(ref dfRenderData, control, start_VALUE, 1f);
						}
					}
					this.drawCallBuffers.RemoveAll((global::dfRenderData x) => x.Vertices.Count == 0);
					this.drawCallCount = this.drawCallBuffers.Count;
					this.TotalDrawCalls = this.drawCallCount;
					if (this.drawCallBuffers.Count == 0)
					{
						if (this.renderFilter.sharedMesh != null)
						{
							this.renderFilter.sharedMesh.Clear();
						}
					}
					else
					{
						this.meshRenderer.sharedMaterials = this.gatherMaterials();
						global::dfRenderData dfRenderData2 = this.compileMasterBuffer();
						this.TotalTriangles = dfRenderData2.Triangles.Count / 3;
						global::UnityEngine.Mesh mesh = this.getRenderMesh();
						this.renderFilter.sharedMesh = mesh;
						global::UnityEngine.Mesh mesh2 = mesh;
						mesh2.Clear();
						mesh2.vertices = dfRenderData2.Vertices.Items;
						mesh2.uv = dfRenderData2.UV.Items;
						mesh2.colors32 = dfRenderData2.Colors.Items;
						if (this.generateNormals && dfRenderData2.Normals.Items.Length == dfRenderData2.Vertices.Items.Length)
						{
							mesh2.normals = dfRenderData2.Normals.Items;
							mesh2.tangents = dfRenderData2.Tangents.Items;
						}
						mesh2.subMeshCount = this.submeshes.Count;
						for (int j = 0; j < this.submeshes.Count; j++)
						{
							int num = this.submeshes[j];
							int num2 = dfRenderData2.Triangles.Count - num;
							if (j < this.submeshes.Count - 1)
							{
								num2 = this.submeshes[j + 1] - num;
							}
							int[] array = new int[num2];
							dfRenderData2.Triangles.CopyTo(num, array, 0, num2);
							mesh2.SetTriangles(array, j);
						}
						if (this.clipStack.Count != 1)
						{
							global::UnityEngine.Debug.LogError("Clip stack not properly maintained");
						}
						this.clipStack.Pop().Release();
						this.clipStack.Clear();
					}
				}
			}
		}
		catch (global::dfAbortRenderingException)
		{
			this.isDirty = true;
		}
		finally
		{
			if (global::dfGUIManager.AfterRender != null)
			{
				global::dfGUIManager.AfterRender(this);
			}
		}
	}

	// Token: 0x0600452B RID: 17707 RVA: 0x000FCC48 File Offset: 0x000FAE48
	private global::dfList<global::dfControl> getTopLevelControls()
	{
		int childCount = base.transform.childCount;
		global::dfList<global::dfControl> dfList = global::dfList<global::dfControl>.Obtain(childCount);
		for (int i = 0; i < childCount; i++)
		{
			global::dfControl component = base.transform.GetChild(i).GetComponent<global::dfControl>();
			if (component != null)
			{
				dfList.Add(component);
			}
		}
		dfList.Sort();
		return dfList;
	}

	// Token: 0x0600452C RID: 17708 RVA: 0x000FCCA8 File Offset: 0x000FAEA8
	private void updateRenderSettings()
	{
		global::UnityEngine.Camera camera = this.RenderCamera;
		if (camera == null)
		{
			return;
		}
		if (!this.overrideCamera)
		{
			this.updateRenderCamera(camera);
		}
		if (base.transform.hasChanged)
		{
			global::UnityEngine.Vector3 localScale = base.transform.localScale;
			bool flag = localScale.x < float.Epsilon || !global::UnityEngine.Mathf.Approximately(localScale.x, localScale.y) || !global::UnityEngine.Mathf.Approximately(localScale.x, localScale.z);
			if (flag)
			{
				localScale.y = (localScale.z = (localScale.x = global::UnityEngine.Mathf.Max(localScale.x, 0.001f)));
				base.transform.localScale = localScale;
			}
		}
		if (!this.overrideCamera)
		{
			if (global::UnityEngine.Application.isPlaying && this.PixelPerfectMode)
			{
				float num = camera.pixelHeight / (float)this.fixedHeight;
				camera.orthographicSize = num;
				camera.fieldOfView = 60f * num;
			}
			else
			{
				camera.orthographicSize = 1f;
				camera.fieldOfView = 60f;
			}
		}
		camera.transparencySortMode = 2;
		if (this.cachedScreenSize.sqrMagnitude <= 1E-45f)
		{
			this.cachedScreenSize = new global::UnityEngine.Vector2((float)this.FixedWidth, (float)this.FixedHeight);
		}
		base.transform.hasChanged = false;
	}

	// Token: 0x0600452D RID: 17709 RVA: 0x000FCE1C File Offset: 0x000FB01C
	private void updateRenderCamera(global::UnityEngine.Camera camera)
	{
		if (global::UnityEngine.Application.isPlaying && camera.targetTexture != null)
		{
			camera.clearFlags = 2;
			camera.backgroundColor = global::UnityEngine.Color.clear;
		}
		else
		{
			camera.clearFlags = 3;
		}
		global::UnityEngine.Vector3 vector = (!global::UnityEngine.Application.isPlaying) ? global::UnityEngine.Vector3.zero : (-this.uiOffset * this.PixelsToUnits());
		if (camera.isOrthoGraphic)
		{
			camera.nearClipPlane = global::UnityEngine.Mathf.Min(camera.nearClipPlane, -1f);
			camera.farClipPlane = global::UnityEngine.Mathf.Max(camera.farClipPlane, 1f);
		}
		else
		{
			float num = camera.fieldOfView * 0.017453292f;
			global::UnityEngine.Vector3[] array = this.GetCorners();
			float num2 = global::UnityEngine.Vector3.Distance(array[3], array[0]);
			float num3 = num2 / (2f * global::UnityEngine.Mathf.Tan(num / 2f));
			global::UnityEngine.Vector3 vector2 = base.transform.TransformDirection(global::UnityEngine.Vector3.back) * num3;
			camera.farClipPlane = global::UnityEngine.Mathf.Max(num3 * 2f, camera.farClipPlane);
			vector += vector2;
		}
		if (global::UnityEngine.Application.isPlaying && this.needHalfPixelOffset())
		{
			float pixelHeight = camera.pixelHeight;
			float num4 = 2f / pixelHeight * (pixelHeight / (float)this.FixedHeight);
			global::UnityEngine.Vector3 vector3;
			vector3..ctor(num4 * 0.5f, num4 * -0.5f, 0f);
			vector += vector3;
		}
		if (!this.overrideCamera)
		{
			if (global::UnityEngine.Vector3.SqrMagnitude(camera.transform.localPosition - vector) > 1E-45f)
			{
				camera.transform.localPosition = vector;
			}
			camera.transform.hasChanged = false;
		}
	}

	// Token: 0x0600452E RID: 17710 RVA: 0x000FCFEC File Offset: 0x000FB1EC
	private global::dfRenderData compileMasterBuffer()
	{
		this.submeshes.Clear();
		global::dfGUIManager.masterBuffer.Clear();
		for (int i = 0; i < this.drawCallCount; i++)
		{
			this.submeshes.Add(global::dfGUIManager.masterBuffer.Triangles.Count);
			global::dfRenderData dfRenderData = this.drawCallBuffers[i];
			if (this.generateNormals && dfRenderData.Normals.Count == 0)
			{
				this.generateNormalsAndTangents(dfRenderData);
			}
			global::dfGUIManager.masterBuffer.Merge(dfRenderData, false);
		}
		global::dfGUIManager.masterBuffer.ApplyTransform(base.transform.worldToLocalMatrix);
		return global::dfGUIManager.masterBuffer;
	}

	// Token: 0x0600452F RID: 17711 RVA: 0x000FD094 File Offset: 0x000FB294
	private void generateNormalsAndTangents(global::dfRenderData buffer)
	{
		global::UnityEngine.Vector3 normalized = buffer.Transform.MultiplyVector(global::UnityEngine.Vector3.back).normalized;
		global::UnityEngine.Vector4 item = buffer.Transform.MultiplyVector(global::UnityEngine.Vector3.right).normalized;
		item.w = -1f;
		for (int i = 0; i < buffer.Vertices.Count; i++)
		{
			buffer.Normals.Add(normalized);
			buffer.Tangents.Add(item);
		}
	}

	// Token: 0x06004530 RID: 17712 RVA: 0x000FD124 File Offset: 0x000FB324
	private bool needHalfPixelOffset()
	{
		if (this.applyHalfPixelOffset != null)
		{
			return this.applyHalfPixelOffset.Value;
		}
		global::UnityEngine.RuntimePlatform platform = global::UnityEngine.Application.platform;
		bool flag = this.pixelPerfectMode && (platform == 2 || platform == 5 || platform == 7) && global::UnityEngine.SystemInfo.graphicsShaderLevel < 0x28;
		this.applyHalfPixelOffset = new bool?(global::UnityEngine.Application.isEditor || flag);
		return flag;
	}

	// Token: 0x06004531 RID: 17713 RVA: 0x000FD19C File Offset: 0x000FB39C
	private global::UnityEngine.Material[] gatherMaterials()
	{
		int num = this.renderQueueBase;
		global::dfGUIManager.MaterialCache.Reset();
		int num2 = this.drawCallBuffers.Matching((global::dfRenderData buff) => buff != null && buff.Material != null);
		int num3 = 0;
		global::UnityEngine.Material[] array = new global::UnityEngine.Material[num2];
		for (int i = 0; i < this.drawCallBuffers.Count; i++)
		{
			if (!(this.drawCallBuffers[i].Material == null))
			{
				global::UnityEngine.Material material = global::dfGUIManager.MaterialCache.Lookup(this.drawCallBuffers[i].Material);
				material.renderQueue = num++;
				array[num3++] = material;
			}
		}
		return array;
	}

	// Token: 0x06004532 RID: 17714 RVA: 0x000FD258 File Offset: 0x000FB458
	private void resetDrawCalls()
	{
		this.drawCallCount = 0;
		for (int i = 0; i < this.drawCallBuffers.Count; i++)
		{
			this.drawCallBuffers[i].Release();
		}
		this.drawCallBuffers.Clear();
	}

	// Token: 0x06004533 RID: 17715 RVA: 0x000FD2A4 File Offset: 0x000FB4A4
	private global::dfRenderData getDrawCallBuffer(global::UnityEngine.Material material)
	{
		global::dfRenderData dfRenderData;
		if (this.MergeMaterials && material != null)
		{
			dfRenderData = this.findDrawCallBufferByMaterial(material);
			if (dfRenderData != null)
			{
				return dfRenderData;
			}
		}
		dfRenderData = global::dfRenderData.Obtain();
		dfRenderData.Material = material;
		this.drawCallBuffers.Add(dfRenderData);
		this.drawCallCount++;
		return dfRenderData;
	}

	// Token: 0x06004534 RID: 17716 RVA: 0x000FD304 File Offset: 0x000FB504
	private global::dfRenderData findDrawCallBufferByMaterial(global::UnityEngine.Material material)
	{
		for (int i = 0; i < this.drawCallCount; i++)
		{
			if (this.drawCallBuffers[i].Material == material)
			{
				return this.drawCallBuffers[i];
			}
		}
		return null;
	}

	// Token: 0x06004535 RID: 17717 RVA: 0x000FD354 File Offset: 0x000FB554
	private global::UnityEngine.Mesh getRenderMesh()
	{
		this.activeRenderMesh = ((this.activeRenderMesh != 1) ? 1 : 0);
		return this.renderMesh[this.activeRenderMesh];
	}

	// Token: 0x06004536 RID: 17718 RVA: 0x000FD388 File Offset: 0x000FB588
	private void renderControl(ref global::dfRenderData buffer, global::dfControl control, uint checksum, float opacity)
	{
		if (!control.GetIsVisibleRaw())
		{
			return;
		}
		float opacity2 = opacity * control.Opacity;
		if (opacity <= 0.005f)
		{
			return;
		}
		global::dfGUIManager.ClipRegion clipRegion = this.clipStack.Peek();
		checksum = global::dfChecksumUtil.Calculate(checksum, control.Version);
		global::UnityEngine.Bounds bounds = control.GetBounds();
		bool flag = false;
		if (!(control is global::IDFMultiRender))
		{
			global::dfRenderData dfRenderData = control.Render();
			if (dfRenderData == null)
			{
				return;
			}
			if (this.processRenderData(ref buffer, dfRenderData, bounds, checksum, clipRegion))
			{
				flag = true;
			}
		}
		else
		{
			global::dfList<global::dfRenderData> dfList = ((global::IDFMultiRender)control).RenderMultiple();
			if (dfList != null)
			{
				for (int i = 0; i < dfList.Count; i++)
				{
					global::dfRenderData controlData = dfList[i];
					if (this.processRenderData(ref buffer, controlData, bounds, checksum, clipRegion))
					{
						flag = true;
					}
				}
			}
		}
		if (flag)
		{
			this.ControlsRendered++;
			this.occluders.Add(this.getControlOccluder(control));
		}
		if (control.ClipChildren)
		{
			clipRegion = global::dfGUIManager.ClipRegion.Obtain(clipRegion, control);
			this.clipStack.Push(clipRegion);
		}
		for (int j = 0; j < control.Controls.Count; j++)
		{
			global::dfControl control2 = control.Controls[j];
			this.renderControl(ref buffer, control2, checksum, opacity2);
		}
		if (control.ClipChildren)
		{
			this.clipStack.Pop().Release();
		}
	}

	// Token: 0x06004537 RID: 17719 RVA: 0x000FD4F8 File Offset: 0x000FB6F8
	private global::UnityEngine.Rect getControlOccluder(global::dfControl control)
	{
		global::UnityEngine.Rect screenRect = control.GetScreenRect();
		global::UnityEngine.Vector2 vector;
		vector..ctor(screenRect.width * control.HotZoneScale.x, screenRect.height * control.HotZoneScale.y);
		global::UnityEngine.Vector2 vector2 = new global::UnityEngine.Vector2(vector.x - screenRect.width, vector.y - screenRect.height) * 0.5f;
		return new global::UnityEngine.Rect(screenRect.x - vector2.x, screenRect.y - vector2.y, vector.x, vector.y);
	}

	// Token: 0x06004538 RID: 17720 RVA: 0x000FD5A0 File Offset: 0x000FB7A0
	private bool processRenderData(ref global::dfRenderData buffer, global::dfRenderData controlData, global::UnityEngine.Bounds bounds, uint checksum, global::dfGUIManager.ClipRegion clipInfo)
	{
		bool flag = buffer == null || (controlData.IsValid() && (!object.Equals(buffer.Shader, controlData.Shader) || (controlData.Material != null && !controlData.Material.Equals(buffer.Material))));
		if (flag && controlData.IsValid())
		{
			buffer = this.getDrawCallBuffer(controlData.Material);
		}
		return controlData != null && controlData.IsValid() && clipInfo.PerformClipping(buffer, bounds, checksum, controlData);
	}

	// Token: 0x06004539 RID: 17721 RVA: 0x000FD650 File Offset: 0x000FB850
	private void initialize()
	{
		if (this.renderCamera == null)
		{
			global::UnityEngine.Debug.LogError("No camera is assigned to the GUIManager");
			return;
		}
		this.meshRenderer = base.GetComponent<global::UnityEngine.MeshRenderer>();
		this.meshRenderer.hideFlags = 2;
		this.renderFilter = base.GetComponent<global::UnityEngine.MeshFilter>();
		this.renderFilter.hideFlags = 2;
		this.renderMesh = new global::UnityEngine.Mesh[]
		{
			new global::UnityEngine.Mesh
			{
				hideFlags = 4
			},
			new global::UnityEngine.Mesh
			{
				hideFlags = 4
			}
		};
		this.renderMesh[0].MarkDynamic();
		this.renderMesh[1].MarkDynamic();
		if (this.fixedWidth < 0)
		{
			this.fixedWidth = global::UnityEngine.Mathf.RoundToInt((float)this.fixedHeight * 1.33333f);
			base.GetComponentsInChildren<global::dfControl>().ToList<global::dfControl>().ForEach(delegate(global::dfControl x)
			{
				x.ResetLayout(false, false);
			});
		}
	}

	// Token: 0x0600453A RID: 17722 RVA: 0x000FD744 File Offset: 0x000FB944
	private global::dfGUICamera findCameraComponent()
	{
		if (this.guiCamera != null)
		{
			return this.guiCamera;
		}
		if (this.renderCamera == null)
		{
			return null;
		}
		this.guiCamera = this.renderCamera.GetComponent<global::dfGUICamera>();
		if (this.guiCamera == null)
		{
			this.guiCamera = this.renderCamera.gameObject.AddComponent<global::dfGUICamera>();
			this.guiCamera.transform.position = base.transform.position;
		}
		return this.guiCamera;
	}

	// Token: 0x0600453B RID: 17723 RVA: 0x000FD7D8 File Offset: 0x000FB9D8
	private void onResolutionChanged()
	{
		int currentSize = (!global::UnityEngine.Application.isPlaying) ? this.FixedHeight : ((int)this.renderCamera.pixelHeight);
		this.onResolutionChanged(this.FixedHeight, currentSize);
	}

	// Token: 0x0600453C RID: 17724 RVA: 0x000FD814 File Offset: 0x000FBA14
	private void onResolutionChanged(int oldSize, int currentSize)
	{
		float aspect = this.RenderCamera.aspect;
		float num = (float)oldSize * aspect;
		float num2 = (float)currentSize * aspect;
		global::UnityEngine.Vector2 oldSize2;
		oldSize2..ctor(num, (float)oldSize);
		global::UnityEngine.Vector2 currentSize2;
		currentSize2..ctor(num2, (float)currentSize);
		this.onResolutionChanged(oldSize2, currentSize2);
	}

	// Token: 0x0600453D RID: 17725 RVA: 0x000FD854 File Offset: 0x000FBA54
	private void onResolutionChanged(global::UnityEngine.Vector2 oldSize, global::UnityEngine.Vector2 currentSize)
	{
		this.cachedScreenSize = currentSize;
		this.applyHalfPixelOffset = null;
		float aspect = this.RenderCamera.aspect;
		float num = oldSize.y * aspect;
		float num2 = currentSize.y * aspect;
		global::UnityEngine.Vector2 previousResolution;
		previousResolution..ctor(num, oldSize.y);
		global::UnityEngine.Vector2 currentResolution;
		currentResolution..ctor(num2, currentSize.y);
		global::dfControl[] componentsInChildren = base.GetComponentsInChildren<global::dfControl>();
		global::System.Array.Sort<global::dfControl>(componentsInChildren, new global::System.Comparison<global::dfControl>(this.renderSortFunc));
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			if (this.pixelPerfectMode && componentsInChildren[i].Parent == null)
			{
				componentsInChildren[i].MakePixelPerfect(true);
			}
			componentsInChildren[i].OnResolutionChanged(previousResolution, currentResolution);
		}
		for (int j = 0; j < componentsInChildren.Length; j++)
		{
			componentsInChildren[j].PerformLayout();
		}
		int num3 = 0;
		while (num3 < componentsInChildren.Length && this.pixelPerfectMode)
		{
			if (componentsInChildren[num3].Parent == null)
			{
				componentsInChildren[num3].MakePixelPerfect(true);
			}
			num3++;
		}
	}

	// Token: 0x0600453E RID: 17726 RVA: 0x000FD98C File Offset: 0x000FBB8C
	private void invalidateAllControls()
	{
		global::dfControl[] componentsInChildren = base.GetComponentsInChildren<global::dfControl>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			componentsInChildren[i].Invalidate();
		}
		this.updateRenderOrder(null);
	}

	// Token: 0x0600453F RID: 17727 RVA: 0x000FD9C4 File Offset: 0x000FBBC4
	private int renderSortFunc(global::dfControl lhs, global::dfControl rhs)
	{
		return lhs.RenderOrder.CompareTo(rhs.RenderOrder);
	}

	// Token: 0x06004540 RID: 17728 RVA: 0x000FD9E8 File Offset: 0x000FBBE8
	private void updateRenderOrder(global::dfList<global::dfControl> list = null)
	{
		global::dfList<global::dfControl> dfList = (list == null) ? this.getTopLevelControls() : list;
		dfList.Sort();
		int num = 0;
		for (int i = 0; i < dfList.Count; i++)
		{
			global::dfControl dfControl = dfList[i];
			if (dfControl.Parent == null)
			{
				dfControl.setRenderOrder(ref num);
			}
		}
	}

	// Token: 0x06004541 RID: 17729 RVA: 0x000FDA48 File Offset: 0x000FBC48
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private static bool <Render>m__20(global::dfRenderData x)
	{
		return x.Vertices.Count == 0;
	}

	// Token: 0x06004542 RID: 17730 RVA: 0x000FDA58 File Offset: 0x000FBC58
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private static bool <gatherMaterials>m__21(global::dfRenderData buff)
	{
		return buff != null && buff.Material != null;
	}

	// Token: 0x06004543 RID: 17731 RVA: 0x000FDA70 File Offset: 0x000FBC70
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private static void <initialize>m__22(global::dfControl x)
	{
		x.ResetLayout(false, false);
	}

	// Token: 0x040024B8 RID: 9400
	[global::UnityEngine.SerializeField]
	protected float uiScale = 1f;

	// Token: 0x040024B9 RID: 9401
	[global::UnityEngine.SerializeField]
	protected global::dfInputManager inputManager;

	// Token: 0x040024BA RID: 9402
	[global::UnityEngine.SerializeField]
	protected int fixedWidth = -1;

	// Token: 0x040024BB RID: 9403
	[global::UnityEngine.SerializeField]
	protected int fixedHeight = 0x258;

	// Token: 0x040024BC RID: 9404
	[global::UnityEngine.SerializeField]
	protected global::dfAtlas atlas;

	// Token: 0x040024BD RID: 9405
	[global::UnityEngine.SerializeField]
	protected global::dfFont defaultFont;

	// Token: 0x040024BE RID: 9406
	[global::UnityEngine.SerializeField]
	protected bool mergeMaterials;

	// Token: 0x040024BF RID: 9407
	[global::UnityEngine.SerializeField]
	protected bool pixelPerfectMode = true;

	// Token: 0x040024C0 RID: 9408
	[global::UnityEngine.SerializeField]
	protected global::UnityEngine.Camera renderCamera;

	// Token: 0x040024C1 RID: 9409
	[global::UnityEngine.SerializeField]
	protected bool generateNormals;

	// Token: 0x040024C2 RID: 9410
	[global::UnityEngine.SerializeField]
	protected bool consumeMouseEvents = true;

	// Token: 0x040024C3 RID: 9411
	[global::UnityEngine.SerializeField]
	protected bool overrideCamera;

	// Token: 0x040024C4 RID: 9412
	[global::UnityEngine.SerializeField]
	protected int renderQueueBase = 0xBB8;

	// Token: 0x040024C5 RID: 9413
	private static global::dfControl activeControl = null;

	// Token: 0x040024C6 RID: 9414
	private static global::System.Collections.Generic.Stack<global::dfGUIManager.ModalControlReference> modalControlStack = new global::System.Collections.Generic.Stack<global::dfGUIManager.ModalControlReference>();

	// Token: 0x040024C7 RID: 9415
	private global::dfGUICamera guiCamera;

	// Token: 0x040024C8 RID: 9416
	private global::UnityEngine.Mesh[] renderMesh;

	// Token: 0x040024C9 RID: 9417
	private global::UnityEngine.MeshFilter renderFilter;

	// Token: 0x040024CA RID: 9418
	private global::UnityEngine.MeshRenderer meshRenderer;

	// Token: 0x040024CB RID: 9419
	private int activeRenderMesh;

	// Token: 0x040024CC RID: 9420
	private int cachedChildCount;

	// Token: 0x040024CD RID: 9421
	private bool isDirty;

	// Token: 0x040024CE RID: 9422
	private global::UnityEngine.Vector2 cachedScreenSize;

	// Token: 0x040024CF RID: 9423
	private global::UnityEngine.Vector3[] corners = new global::UnityEngine.Vector3[4];

	// Token: 0x040024D0 RID: 9424
	private global::dfList<global::UnityEngine.Rect> occluders = new global::dfList<global::UnityEngine.Rect>(0x100);

	// Token: 0x040024D1 RID: 9425
	private global::System.Collections.Generic.Stack<global::dfGUIManager.ClipRegion> clipStack = new global::System.Collections.Generic.Stack<global::dfGUIManager.ClipRegion>();

	// Token: 0x040024D2 RID: 9426
	private static global::dfRenderData masterBuffer = new global::dfRenderData(0x1000);

	// Token: 0x040024D3 RID: 9427
	private global::dfList<global::dfRenderData> drawCallBuffers = new global::dfList<global::dfRenderData>();

	// Token: 0x040024D4 RID: 9428
	private global::System.Collections.Generic.List<int> submeshes = new global::System.Collections.Generic.List<int>();

	// Token: 0x040024D5 RID: 9429
	private int drawCallCount;

	// Token: 0x040024D6 RID: 9430
	private global::UnityEngine.Vector2 uiOffset = global::UnityEngine.Vector2.zero;

	// Token: 0x040024D7 RID: 9431
	private bool? applyHalfPixelOffset;

	// Token: 0x040024D8 RID: 9432
	private static global::dfGUIManager.RenderCallback BeforeRender;

	// Token: 0x040024D9 RID: 9433
	private static global::dfGUIManager.RenderCallback AfterRender;

	// Token: 0x040024DA RID: 9434
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private int <TotalDrawCalls>k__BackingField;

	// Token: 0x040024DB RID: 9435
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private int <TotalTriangles>k__BackingField;

	// Token: 0x040024DC RID: 9436
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private int <ControlsRendered>k__BackingField;

	// Token: 0x040024DD RID: 9437
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private int <FramesRendered>k__BackingField;

	// Token: 0x040024DE RID: 9438
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private static global::System.Predicate<global::dfRenderData> <>f__am$cache26;

	// Token: 0x040024DF RID: 9439
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private static global::System.Func<global::dfRenderData, bool> <>f__am$cache27;

	// Token: 0x040024E0 RID: 9440
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private static global::System.Action<global::dfControl> <>f__am$cache28;

	// Token: 0x02000808 RID: 2056
	private class ClipRegion
	{
		// Token: 0x06004544 RID: 17732 RVA: 0x000FDA7C File Offset: 0x000FBC7C
		private ClipRegion()
		{
			this.planes = new global::dfList<global::UnityEngine.Plane>();
		}

		// Token: 0x06004545 RID: 17733 RVA: 0x000FDA90 File Offset: 0x000FBC90
		// Note: this type is marked as 'beforefieldinit'.
		static ClipRegion()
		{
		}

		// Token: 0x06004546 RID: 17734 RVA: 0x000FDA9C File Offset: 0x000FBC9C
		public static global::dfGUIManager.ClipRegion Obtain()
		{
			return (global::dfGUIManager.ClipRegion.pool.Count <= 0) ? new global::dfGUIManager.ClipRegion() : global::dfGUIManager.ClipRegion.pool.Dequeue();
		}

		// Token: 0x06004547 RID: 17735 RVA: 0x000FDAD0 File Offset: 0x000FBCD0
		public static global::dfGUIManager.ClipRegion Obtain(global::dfGUIManager.ClipRegion parent, global::dfControl control)
		{
			global::dfGUIManager.ClipRegion clipRegion = (global::dfGUIManager.ClipRegion.pool.Count <= 0) ? new global::dfGUIManager.ClipRegion() : global::dfGUIManager.ClipRegion.pool.Dequeue();
			clipRegion.planes.AddRange(control.GetClippingPlanes());
			if (parent != null)
			{
				clipRegion.planes.AddRange(parent.planes);
			}
			return clipRegion;
		}

		// Token: 0x06004548 RID: 17736 RVA: 0x000FDB2C File Offset: 0x000FBD2C
		public void Release()
		{
			this.planes.Clear();
			global::dfGUIManager.ClipRegion.pool.Enqueue(this);
		}

		// Token: 0x06004549 RID: 17737 RVA: 0x000FDB44 File Offset: 0x000FBD44
		public bool PerformClipping(global::dfRenderData dest, global::UnityEngine.Bounds bounds, uint checksum, global::dfRenderData controlData)
		{
			if (controlData.Checksum == checksum)
			{
				if (controlData.Intersection == global::dfIntersectionType.Inside)
				{
					dest.Merge(controlData, true);
					return true;
				}
				if (controlData.Intersection == global::dfIntersectionType.None)
				{
					return false;
				}
			}
			bool result = false;
			global::dfIntersectionType dfIntersectionType;
			using (global::dfList<global::UnityEngine.Plane> dfList = this.TestIntersection(bounds, out dfIntersectionType))
			{
				if (dfIntersectionType == global::dfIntersectionType.Inside)
				{
					dest.Merge(controlData, true);
					result = true;
				}
				else if (dfIntersectionType == global::dfIntersectionType.Intersecting)
				{
					this.clipToPlanes(dfList, controlData, dest, checksum);
					result = true;
				}
				controlData.Checksum = checksum;
				controlData.Intersection = dfIntersectionType;
			}
			return result;
		}

		// Token: 0x0600454A RID: 17738 RVA: 0x000FDBFC File Offset: 0x000FBDFC
		public global::dfList<global::UnityEngine.Plane> TestIntersection(global::UnityEngine.Bounds bounds, out global::dfIntersectionType type)
		{
			if (this.planes == null || this.planes.Count == 0)
			{
				type = global::dfIntersectionType.Inside;
				return null;
			}
			global::dfList<global::UnityEngine.Plane> dfList = global::dfList<global::UnityEngine.Plane>.Obtain(this.planes.Count);
			global::UnityEngine.Vector3 center = bounds.center;
			global::UnityEngine.Vector3 extents = bounds.extents;
			bool flag = false;
			for (int i = 0; i < this.planes.Count; i++)
			{
				global::UnityEngine.Plane item = this.planes[i];
				global::UnityEngine.Vector3 normal = item.normal;
				float distance = item.distance;
				float num = extents.x * global::UnityEngine.Mathf.Abs(normal.x) + extents.y * global::UnityEngine.Mathf.Abs(normal.y) + extents.z * global::UnityEngine.Mathf.Abs(normal.z);
				float num2 = global::UnityEngine.Vector3.Dot(normal, center) + distance;
				if (global::UnityEngine.Mathf.Abs(num2) <= num)
				{
					flag = true;
					dfList.Add(item);
				}
				else if (num2 < -num)
				{
					type = global::dfIntersectionType.None;
					dfList.Release();
					return null;
				}
			}
			if (flag)
			{
				type = global::dfIntersectionType.Intersecting;
				return dfList;
			}
			type = global::dfIntersectionType.Inside;
			dfList.Release();
			return null;
		}

		// Token: 0x0600454B RID: 17739 RVA: 0x000FDD24 File Offset: 0x000FBF24
		public void clipToPlanes(global::dfList<global::UnityEngine.Plane> planes, global::dfRenderData data, global::dfRenderData dest, uint controlChecksum)
		{
			if (data == null || data.Vertices.Count == 0)
			{
				return;
			}
			if (planes == null || planes.Count == 0)
			{
				dest.Merge(data, true);
				return;
			}
			global::dfClippingUtil.Clip(planes, data, dest);
		}

		// Token: 0x0600454C RID: 17740 RVA: 0x000FDD6C File Offset: 0x000FBF6C
		private static int sortClipPlanes(global::UnityEngine.Plane lhs, global::UnityEngine.Plane rhs)
		{
			return lhs.distance.CompareTo(rhs.distance);
		}

		// Token: 0x040024E1 RID: 9441
		private static global::System.Collections.Generic.Queue<global::dfGUIManager.ClipRegion> pool = new global::System.Collections.Generic.Queue<global::dfGUIManager.ClipRegion>();

		// Token: 0x040024E2 RID: 9442
		private global::dfList<global::UnityEngine.Plane> planes;
	}

	// Token: 0x02000809 RID: 2057
	private struct ModalControlReference
	{
		// Token: 0x040024E3 RID: 9443
		public global::dfControl control;

		// Token: 0x040024E4 RID: 9444
		public global::dfGUIManager.ModalPoppedCallback callback;
	}

	// Token: 0x0200080A RID: 2058
	private class MaterialCache
	{
		// Token: 0x0600454D RID: 17741 RVA: 0x000FDD90 File Offset: 0x000FBF90
		public MaterialCache()
		{
		}

		// Token: 0x0600454E RID: 17742 RVA: 0x000FDD98 File Offset: 0x000FBF98
		// Note: this type is marked as 'beforefieldinit'.
		static MaterialCache()
		{
		}

		// Token: 0x0600454F RID: 17743 RVA: 0x000FDDA4 File Offset: 0x000FBFA4
		public static global::UnityEngine.Material Lookup(global::UnityEngine.Material BaseMaterial)
		{
			if (BaseMaterial == null)
			{
				global::UnityEngine.Debug.LogError("Cache lookup on null material");
				return null;
			}
			global::dfGUIManager.MaterialCache.Cache cache = null;
			if (global::dfGUIManager.MaterialCache.cache.TryGetValue(BaseMaterial, out cache))
			{
				return cache.Obtain();
			}
			global::dfGUIManager.MaterialCache.Cache cache2 = new global::dfGUIManager.MaterialCache.Cache(BaseMaterial);
			global::dfGUIManager.MaterialCache.cache[BaseMaterial] = cache2;
			cache = cache2;
			return cache.Obtain();
		}

		// Token: 0x06004550 RID: 17744 RVA: 0x000FDE00 File Offset: 0x000FC000
		public static void Reset()
		{
			global::dfGUIManager.MaterialCache.Cache.ResetAll();
		}

		// Token: 0x040024E5 RID: 9445
		private static global::System.Collections.Generic.Dictionary<global::UnityEngine.Material, global::dfGUIManager.MaterialCache.Cache> cache = new global::System.Collections.Generic.Dictionary<global::UnityEngine.Material, global::dfGUIManager.MaterialCache.Cache>();

		// Token: 0x0200080B RID: 2059
		private class Cache
		{
			// Token: 0x06004551 RID: 17745 RVA: 0x000FDE08 File Offset: 0x000FC008
			private Cache()
			{
				throw new global::System.NotImplementedException();
			}

			// Token: 0x06004552 RID: 17746 RVA: 0x000FDE24 File Offset: 0x000FC024
			public Cache(global::UnityEngine.Material BaseMaterial)
			{
				this.baseMaterial = BaseMaterial;
				this.instances.Add(BaseMaterial);
				global::dfGUIManager.MaterialCache.Cache.cacheInstances.Add(this);
			}

			// Token: 0x06004553 RID: 17747 RVA: 0x000FDE58 File Offset: 0x000FC058
			// Note: this type is marked as 'beforefieldinit'.
			static Cache()
			{
			}

			// Token: 0x06004554 RID: 17748 RVA: 0x000FDE64 File Offset: 0x000FC064
			public static void ResetAll()
			{
				for (int i = 0; i < global::dfGUIManager.MaterialCache.Cache.cacheInstances.Count; i++)
				{
					global::dfGUIManager.MaterialCache.Cache.cacheInstances[i].Reset();
				}
			}

			// Token: 0x06004555 RID: 17749 RVA: 0x000FDE9C File Offset: 0x000FC09C
			public global::UnityEngine.Material Obtain()
			{
				if (this.currentIndex < this.instances.Count)
				{
					return this.instances[this.currentIndex++];
				}
				this.currentIndex++;
				global::UnityEngine.Material material = new global::UnityEngine.Material(this.baseMaterial)
				{
					hideFlags = 4,
					name = string.Format("{0} (Copy {1})", this.baseMaterial.name, this.currentIndex)
				};
				this.instances.Add(material);
				return material;
			}

			// Token: 0x06004556 RID: 17750 RVA: 0x000FDF34 File Offset: 0x000FC134
			public void Reset()
			{
				this.currentIndex = 0;
			}

			// Token: 0x040024E6 RID: 9446
			private static global::System.Collections.Generic.List<global::dfGUIManager.MaterialCache.Cache> cacheInstances = new global::System.Collections.Generic.List<global::dfGUIManager.MaterialCache.Cache>();

			// Token: 0x040024E7 RID: 9447
			private global::UnityEngine.Material baseMaterial;

			// Token: 0x040024E8 RID: 9448
			private global::System.Collections.Generic.List<global::UnityEngine.Material> instances = new global::System.Collections.Generic.List<global::UnityEngine.Material>(0xA);

			// Token: 0x040024E9 RID: 9449
			private int currentIndex;
		}
	}

	// Token: 0x0200080C RID: 2060
	// (Invoke) Token: 0x06004558 RID: 17752
	[global::dfEventCategory("Modal Dialog")]
	public delegate void ModalPoppedCallback(global::dfControl control);

	// Token: 0x0200080D RID: 2061
	// (Invoke) Token: 0x0600455C RID: 17756
	[global::dfEventCategory("Global Callbacks")]
	public delegate void RenderCallback(global::dfGUIManager manager);

	// Token: 0x0200080E RID: 2062
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private sealed class <OnGUI>c__AnonStorey68
	{
		// Token: 0x0600455F RID: 17759 RVA: 0x000FDF40 File Offset: 0x000FC140
		public <OnGUI>c__AnonStorey68()
		{
		}

		// Token: 0x06004560 RID: 17760 RVA: 0x000FDF48 File Offset: 0x000FC148
		internal bool <>m__1D(global::UnityEngine.Rect x)
		{
			return x.Contains(this.touchPosition);
		}

		// Token: 0x040024EA RID: 9450
		internal global::UnityEngine.Vector2 touchPosition;
	}

	// Token: 0x0200080F RID: 2063
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private sealed class <SetFocus>c__AnonStorey69
	{
		// Token: 0x06004561 RID: 17761 RVA: 0x000FDF58 File Offset: 0x000FC158
		public <SetFocus>c__AnonStorey69()
		{
		}

		// Token: 0x06004562 RID: 17762 RVA: 0x000FDF60 File Offset: 0x000FC160
		internal void <>m__1E(global::dfControl c)
		{
			if (!this.newFocusChain.Contains(c))
			{
				c.OnLeaveFocus(this.args);
			}
		}

		// Token: 0x06004563 RID: 17763 RVA: 0x000FDF80 File Offset: 0x000FC180
		internal void <>m__1F(global::dfControl c)
		{
			if (!this.prevFocusChain.Contains(c))
			{
				c.OnEnterFocus(this.args);
			}
		}

		// Token: 0x040024EB RID: 9451
		internal global::dfList<global::dfControl> newFocusChain;

		// Token: 0x040024EC RID: 9452
		internal global::dfFocusEventArgs args;

		// Token: 0x040024ED RID: 9453
		internal global::dfList<global::dfControl> prevFocusChain;
	}
}
