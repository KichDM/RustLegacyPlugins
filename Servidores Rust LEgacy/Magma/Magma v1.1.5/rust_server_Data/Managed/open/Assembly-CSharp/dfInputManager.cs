using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x02000810 RID: 2064
[global::System.Serializable]
[global::UnityEngine.AddComponentMenu("Daikon Forge/User Interface/Input Manager")]
public class dfInputManager : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06004564 RID: 17764 RVA: 0x000FDFA0 File Offset: 0x000FC1A0
	public dfInputManager()
	{
	}

	// Token: 0x06004565 RID: 17765 RVA: 0x000FDFF0 File Offset: 0x000FC1F0
	// Note: this type is marked as 'beforefieldinit'.
	static dfInputManager()
	{
	}

	// Token: 0x17000CE0 RID: 3296
	// (get) Token: 0x06004566 RID: 17766 RVA: 0x000FE044 File Offset: 0x000FC244
	public static global::dfControl ControlUnderMouse
	{
		get
		{
			return global::dfInputManager.controlUnderMouse;
		}
	}

	// Token: 0x17000CE1 RID: 3297
	// (get) Token: 0x06004567 RID: 17767 RVA: 0x000FE04C File Offset: 0x000FC24C
	// (set) Token: 0x06004568 RID: 17768 RVA: 0x000FE054 File Offset: 0x000FC254
	public global::UnityEngine.Camera RenderCamera
	{
		get
		{
			return this.renderCamera;
		}
		set
		{
			this.renderCamera = value;
		}
	}

	// Token: 0x17000CE2 RID: 3298
	// (get) Token: 0x06004569 RID: 17769 RVA: 0x000FE060 File Offset: 0x000FC260
	// (set) Token: 0x0600456A RID: 17770 RVA: 0x000FE068 File Offset: 0x000FC268
	public bool UseTouch
	{
		get
		{
			return this.useTouch;
		}
		set
		{
			this.useTouch = value;
		}
	}

	// Token: 0x17000CE3 RID: 3299
	// (get) Token: 0x0600456B RID: 17771 RVA: 0x000FE074 File Offset: 0x000FC274
	// (set) Token: 0x0600456C RID: 17772 RVA: 0x000FE07C File Offset: 0x000FC27C
	public int TouchClickRadius
	{
		get
		{
			return this.touchClickRadius;
		}
		set
		{
			this.touchClickRadius = global::UnityEngine.Mathf.Max(0, value);
		}
	}

	// Token: 0x17000CE4 RID: 3300
	// (get) Token: 0x0600456D RID: 17773 RVA: 0x000FE08C File Offset: 0x000FC28C
	// (set) Token: 0x0600456E RID: 17774 RVA: 0x000FE094 File Offset: 0x000FC294
	public bool UseJoystick
	{
		get
		{
			return this.useJoystick;
		}
		set
		{
			this.useJoystick = value;
		}
	}

	// Token: 0x17000CE5 RID: 3301
	// (get) Token: 0x0600456F RID: 17775 RVA: 0x000FE0A0 File Offset: 0x000FC2A0
	// (set) Token: 0x06004570 RID: 17776 RVA: 0x000FE0A8 File Offset: 0x000FC2A8
	public global::UnityEngine.KeyCode JoystickClickButton
	{
		get
		{
			return this.joystickClickButton;
		}
		set
		{
			this.joystickClickButton = value;
		}
	}

	// Token: 0x17000CE6 RID: 3302
	// (get) Token: 0x06004571 RID: 17777 RVA: 0x000FE0B4 File Offset: 0x000FC2B4
	// (set) Token: 0x06004572 RID: 17778 RVA: 0x000FE0BC File Offset: 0x000FC2BC
	public string HorizontalAxis
	{
		get
		{
			return this.horizontalAxis;
		}
		set
		{
			this.horizontalAxis = value;
		}
	}

	// Token: 0x17000CE7 RID: 3303
	// (get) Token: 0x06004573 RID: 17779 RVA: 0x000FE0C8 File Offset: 0x000FC2C8
	// (set) Token: 0x06004574 RID: 17780 RVA: 0x000FE0D0 File Offset: 0x000FC2D0
	public string VerticalAxis
	{
		get
		{
			return this.verticalAxis;
		}
		set
		{
			this.verticalAxis = value;
		}
	}

	// Token: 0x17000CE8 RID: 3304
	// (get) Token: 0x06004575 RID: 17781 RVA: 0x000FE0DC File Offset: 0x000FC2DC
	// (set) Token: 0x06004576 RID: 17782 RVA: 0x000FE0E4 File Offset: 0x000FC2E4
	public global::IInputAdapter Adapter
	{
		get
		{
			return this.adapter;
		}
		set
		{
			this.adapter = (value ?? new global::dfInputManager.DefaultInput());
		}
	}

	// Token: 0x17000CE9 RID: 3305
	// (get) Token: 0x06004577 RID: 17783 RVA: 0x000FE0FC File Offset: 0x000FC2FC
	// (set) Token: 0x06004578 RID: 17784 RVA: 0x000FE104 File Offset: 0x000FC304
	public bool RetainFocus
	{
		get
		{
			return this.retainFocus;
		}
		set
		{
			this.retainFocus = value;
		}
	}

	// Token: 0x06004579 RID: 17785 RVA: 0x000FE110 File Offset: 0x000FC310
	public void Awake()
	{
	}

	// Token: 0x0600457A RID: 17786 RVA: 0x000FE114 File Offset: 0x000FC314
	public void Start()
	{
	}

	// Token: 0x0600457B RID: 17787 RVA: 0x000FE118 File Offset: 0x000FC318
	public void OnEnable()
	{
		this.mouseHandler = new global::dfInputManager.MouseInputManager();
		if (this.adapter == null)
		{
			global::UnityEngine.Component component = (from c in base.GetComponents(typeof(global::UnityEngine.MonoBehaviour))
			where typeof(global::IInputAdapter).IsAssignableFrom(c.GetType())
			select c).FirstOrDefault<global::UnityEngine.Component>();
			this.adapter = (((global::IInputAdapter)component) ?? new global::dfInputManager.DefaultInput());
		}
	}

	// Token: 0x0600457C RID: 17788 RVA: 0x000FE18C File Offset: 0x000FC38C
	public void Update()
	{
		if (!global::UnityEngine.Application.isPlaying)
		{
			return;
		}
		global::dfControl activeControl = global::dfGUIManager.ActiveControl;
		this.processMouseInput();
		if (activeControl == null)
		{
			return;
		}
		if (this.processKeyboard())
		{
			return;
		}
		if (this.useJoystick)
		{
			for (int i = 0; i < global::dfInputManager.wasd.Length; i++)
			{
				if (global::UnityEngine.Input.GetKey(global::dfInputManager.wasd[i]) || global::UnityEngine.Input.GetKeyDown(global::dfInputManager.wasd[i]) || global::UnityEngine.Input.GetKeyUp(global::dfInputManager.wasd[i]))
				{
					return;
				}
			}
			this.processJoystick();
		}
	}

	// Token: 0x0600457D RID: 17789 RVA: 0x000FE228 File Offset: 0x000FC428
	public void OnGUI()
	{
		global::UnityEngine.Event current = global::UnityEngine.Event.current;
		if (current == null)
		{
			return;
		}
		if (current.isKey && current.keyCode != null)
		{
			this.processKeyEvent(current.type, current.keyCode, current.modifiers);
			return;
		}
	}

	// Token: 0x0600457E RID: 17790 RVA: 0x000FE274 File Offset: 0x000FC474
	private void processJoystick()
	{
		try
		{
			global::dfControl activeControl = global::dfGUIManager.ActiveControl;
			if (!(activeControl == null) && activeControl.transform.IsChildOf(base.transform))
			{
				float axis = this.adapter.GetAxis(this.horizontalAxis);
				float axis2 = this.adapter.GetAxis(this.verticalAxis);
				if (global::UnityEngine.Mathf.Abs(axis) < 0.5f && global::UnityEngine.Mathf.Abs(axis2) <= 0.5f)
				{
					this.lastAxisCheck = global::UnityEngine.Time.deltaTime - this.axisPollingInterval;
				}
				if (global::UnityEngine.Time.realtimeSinceStartup - this.lastAxisCheck > this.axisPollingInterval)
				{
					if (global::UnityEngine.Mathf.Abs(axis) >= 0.5f)
					{
						this.lastAxisCheck = global::UnityEngine.Time.realtimeSinceStartup;
						global::UnityEngine.KeyCode key = (axis <= 0f) ? 0x114 : 0x113;
						activeControl.OnKeyDown(new global::dfKeyEventArgs(activeControl, key, false, false, false));
					}
					if (global::UnityEngine.Mathf.Abs(axis2) >= 0.5f)
					{
						this.lastAxisCheck = global::UnityEngine.Time.realtimeSinceStartup;
						global::UnityEngine.KeyCode key2 = (axis2 <= 0f) ? 0x112 : 0x111;
						activeControl.OnKeyDown(new global::dfKeyEventArgs(activeControl, key2, false, false, false));
					}
				}
				if (this.joystickClickButton != null)
				{
					bool keyDown = this.adapter.GetKeyDown(this.joystickClickButton);
					if (keyDown)
					{
						global::UnityEngine.Vector3 center = activeControl.GetCenter();
						global::UnityEngine.Camera camera = activeControl.GetCamera();
						global::UnityEngine.Ray ray = camera.ScreenPointToRay(camera.WorldToScreenPoint(center));
						global::dfMouseEventArgs args = new global::dfMouseEventArgs(activeControl, global::dfMouseButtons.Left, 0, ray, center, 0f);
						activeControl.OnMouseDown(args);
						this.buttonDownTarget = activeControl;
					}
					bool keyUp = this.adapter.GetKeyUp(this.joystickClickButton);
					if (keyUp)
					{
						if (this.buttonDownTarget == activeControl)
						{
							activeControl.DoClick();
						}
						global::UnityEngine.Vector3 center2 = activeControl.GetCenter();
						global::UnityEngine.Camera camera2 = activeControl.GetCamera();
						global::UnityEngine.Ray ray2 = camera2.ScreenPointToRay(camera2.WorldToScreenPoint(center2));
						global::dfMouseEventArgs args2 = new global::dfMouseEventArgs(activeControl, global::dfMouseButtons.Left, 0, ray2, center2, 0f);
						activeControl.OnMouseUp(args2);
						this.buttonDownTarget = null;
					}
				}
				for (global::UnityEngine.KeyCode keyCode = 0x15E; keyCode <= 0x171; keyCode++)
				{
					bool keyDown2 = this.adapter.GetKeyDown(keyCode);
					if (keyDown2)
					{
						activeControl.OnKeyDown(new global::dfKeyEventArgs(activeControl, keyCode, false, false, false));
					}
				}
			}
		}
		catch (global::UnityEngine.UnityException ex)
		{
			global::UnityEngine.Debug.LogError(ex.ToString(), this);
			this.useJoystick = false;
		}
	}

	// Token: 0x0600457F RID: 17791 RVA: 0x000FE514 File Offset: 0x000FC714
	private void processKeyEvent(global::UnityEngine.EventType eventType, global::UnityEngine.KeyCode keyCode, global::UnityEngine.EventModifiers modifiers)
	{
		global::dfControl activeControl = global::dfGUIManager.ActiveControl;
		if (activeControl == null || !activeControl.IsEnabled || !activeControl.transform.IsChildOf(base.transform))
		{
			return;
		}
		bool control = (modifiers & 2) == 2;
		bool flag = (modifiers & 1) == 1;
		bool alt = (modifiers & 4) == 4;
		global::dfKeyEventArgs dfKeyEventArgs = new global::dfKeyEventArgs(activeControl, keyCode, control, flag, alt);
		if (keyCode >= 0x20 && keyCode <= 0x7A)
		{
			char c = keyCode;
			dfKeyEventArgs.Character = ((!flag) ? char.ToLower(c) : char.ToUpper(c));
		}
		if (eventType == 4)
		{
			activeControl.OnKeyDown(dfKeyEventArgs);
		}
		else if (eventType == 5)
		{
			activeControl.OnKeyUp(dfKeyEventArgs);
		}
		if (dfKeyEventArgs.Used || eventType == 5)
		{
			return;
		}
	}

	// Token: 0x06004580 RID: 17792 RVA: 0x000FE5E4 File Offset: 0x000FC7E4
	private bool processKeyboard()
	{
		global::dfControl activeControl = global::dfGUIManager.ActiveControl;
		if (activeControl == null || string.IsNullOrEmpty(global::UnityEngine.Input.inputString) || !activeControl.transform.IsChildOf(base.transform))
		{
			return false;
		}
		foreach (char c in global::UnityEngine.Input.inputString)
		{
			if (c != '\b' && c != '\n')
			{
				global::UnityEngine.KeyCode key = c;
				activeControl.OnKeyPress(new global::dfKeyEventArgs(activeControl, key, false, false, false)
				{
					Character = c
				});
			}
		}
		return true;
	}

	// Token: 0x06004581 RID: 17793 RVA: 0x000FE684 File Offset: 0x000FC884
	private void processMouseInput()
	{
		global::UnityEngine.Vector2 mousePosition = this.adapter.GetMousePosition();
		global::UnityEngine.Ray ray = this.renderCamera.ScreenPointToRay(mousePosition);
		float num = this.renderCamera.farClipPlane - this.renderCamera.nearClipPlane;
		global::UnityEngine.RaycastHit[] array = global::UnityEngine.Physics.RaycastAll(ray, num, this.renderCamera.cullingMask);
		global::System.Array.Sort<global::UnityEngine.RaycastHit>(array, new global::System.Comparison<global::UnityEngine.RaycastHit>(global::dfInputManager.raycastHitSorter));
		global::dfInputManager.controlUnderMouse = this.clipCast(array);
		this.mouseHandler.ProcessInput(this.adapter, ray, global::dfInputManager.controlUnderMouse, this.retainFocus);
	}

	// Token: 0x06004582 RID: 17794 RVA: 0x000FE718 File Offset: 0x000FC918
	internal static int raycastHitSorter(global::UnityEngine.RaycastHit lhs, global::UnityEngine.RaycastHit rhs)
	{
		return lhs.distance.CompareTo(rhs.distance);
	}

	// Token: 0x06004583 RID: 17795 RVA: 0x000FE73C File Offset: 0x000FC93C
	internal global::dfControl clipCast(global::UnityEngine.RaycastHit[] hits)
	{
		if (hits == null || hits.Length == 0)
		{
			return null;
		}
		global::dfControl dfControl = null;
		global::dfControl modalControl = global::dfGUIManager.GetModalControl();
		for (int i = hits.Length - 1; i >= 0; i--)
		{
			global::UnityEngine.RaycastHit hit = hits[i];
			global::dfControl component = hit.transform.GetComponent<global::dfControl>();
			bool flag = component == null || (modalControl != null && !component.transform.IsChildOf(modalControl.transform)) || !component.enabled || global::dfInputManager.combinedOpacity(component) <= 0.01f || !component.IsEnabled || !component.IsVisible || !component.transform.IsChildOf(base.transform);
			if (!flag)
			{
				if (global::dfInputManager.isInsideClippingRegion(hit, component) && (dfControl == null || component.RenderOrder > dfControl.RenderOrder))
				{
					dfControl = component;
				}
			}
		}
		return dfControl;
	}

	// Token: 0x06004584 RID: 17796 RVA: 0x000FE84C File Offset: 0x000FCA4C
	internal static bool isInsideClippingRegion(global::UnityEngine.RaycastHit hit, global::dfControl control)
	{
		global::UnityEngine.Vector3 point = hit.point;
		while (control != null)
		{
			global::UnityEngine.Plane[] array = (!control.ClipChildren) ? null : control.GetClippingPlanes();
			if (array != null && array.Length > 0)
			{
				for (int i = 0; i < array.Length; i++)
				{
					if (!array[i].GetSide(point))
					{
						return false;
					}
				}
			}
			control = control.Parent;
		}
		return true;
	}

	// Token: 0x06004585 RID: 17797 RVA: 0x000FE8CC File Offset: 0x000FCACC
	private static float combinedOpacity(global::dfControl control)
	{
		float num = 1f;
		while (control != null)
		{
			num *= control.Opacity;
			control = control.Parent;
		}
		return num;
	}

	// Token: 0x06004586 RID: 17798 RVA: 0x000FE904 File Offset: 0x000FCB04
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private static bool <OnEnable>m__23(global::UnityEngine.Component c)
	{
		return typeof(global::IInputAdapter).IsAssignableFrom(c.GetType());
	}

	// Token: 0x040024EE RID: 9454
	private static global::UnityEngine.KeyCode[] wasd = new global::UnityEngine.KeyCode[]
	{
		0x77,
		0x61,
		0x73,
		0x64,
		0x114,
		0x111,
		0x113,
		0x112
	};

	// Token: 0x040024EF RID: 9455
	private static global::dfControl controlUnderMouse = null;

	// Token: 0x040024F0 RID: 9456
	[global::UnityEngine.SerializeField]
	protected global::UnityEngine.Camera renderCamera;

	// Token: 0x040024F1 RID: 9457
	[global::UnityEngine.SerializeField]
	protected bool useTouch = true;

	// Token: 0x040024F2 RID: 9458
	[global::UnityEngine.SerializeField]
	protected bool useJoystick;

	// Token: 0x040024F3 RID: 9459
	[global::UnityEngine.SerializeField]
	protected global::UnityEngine.KeyCode joystickClickButton = 0x15F;

	// Token: 0x040024F4 RID: 9460
	[global::UnityEngine.SerializeField]
	protected string horizontalAxis = "Horizontal";

	// Token: 0x040024F5 RID: 9461
	[global::UnityEngine.SerializeField]
	protected string verticalAxis = "Vertical";

	// Token: 0x040024F6 RID: 9462
	[global::UnityEngine.SerializeField]
	protected float axisPollingInterval = 0.15f;

	// Token: 0x040024F7 RID: 9463
	[global::UnityEngine.SerializeField]
	protected bool retainFocus;

	// Token: 0x040024F8 RID: 9464
	[global::UnityEngine.SerializeField]
	protected int touchClickRadius = 0x14;

	// Token: 0x040024F9 RID: 9465
	private global::dfControl buttonDownTarget;

	// Token: 0x040024FA RID: 9466
	private global::dfInputManager.MouseInputManager mouseHandler;

	// Token: 0x040024FB RID: 9467
	private global::IInputAdapter adapter;

	// Token: 0x040024FC RID: 9468
	private float lastAxisCheck;

	// Token: 0x040024FD RID: 9469
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private static global::System.Func<global::UnityEngine.Component, bool> <>f__am$cacheF;

	// Token: 0x02000811 RID: 2065
	private class TouchInputManager
	{
		// Token: 0x06004587 RID: 17799 RVA: 0x000FE91C File Offset: 0x000FCB1C
		private TouchInputManager()
		{
		}

		// Token: 0x06004588 RID: 17800 RVA: 0x000FE93C File Offset: 0x000FCB3C
		public TouchInputManager(global::dfInputManager manager)
		{
			this.manager = manager;
		}

		// Token: 0x06004589 RID: 17801 RVA: 0x000FE964 File Offset: 0x000FCB64
		internal void Process(global::UnityEngine.Transform transform, global::UnityEngine.Camera renderCamera, global::dfList<global::UnityEngine.Touch> touches, bool retainFocus)
		{
			for (int i = 0; i < touches.Count; i++)
			{
				global::UnityEngine.Touch touch = touches[i];
				global::UnityEngine.Ray ray = renderCamera.ScreenPointToRay(touch.position);
				float num = renderCamera.farClipPlane - renderCamera.nearClipPlane;
				global::UnityEngine.RaycastHit[] hits = global::UnityEngine.Physics.RaycastAll(ray, num, renderCamera.cullingMask);
				global::dfInputManager.controlUnderMouse = this.clipCast(transform, hits);
				if (global::dfInputManager.controlUnderMouse == null && touch.phase == null)
				{
					this.untracked.Add(touch.fingerId);
				}
				else if (this.untracked.Contains(touch.fingerId))
				{
					if (touch.phase == 3)
					{
						this.untracked.Remove(touch.fingerId);
					}
				}
				else
				{
					global::dfInputManager.TouchInputManager.TouchRaycast info = new global::dfInputManager.TouchInputManager.TouchRaycast(global::dfInputManager.controlUnderMouse, touch, ray);
					global::dfInputManager.TouchInputManager.ControlTouchTracker controlTouchTracker = this.tracked.FirstOrDefault((global::dfInputManager.TouchInputManager.ControlTouchTracker x) => x.IsTrackingFinger(info.FingerID));
					if (controlTouchTracker != null)
					{
						controlTouchTracker.Process(info);
					}
					else
					{
						bool flag = false;
						for (int j = 0; j < this.tracked.Count; j++)
						{
							if (this.tracked[j].Process(info))
							{
								flag = true;
								break;
							}
						}
						if (!flag && global::dfInputManager.controlUnderMouse != null)
						{
							if (!this.tracked.Any((global::dfInputManager.TouchInputManager.ControlTouchTracker x) => x.control == global::dfInputManager.controlUnderMouse))
							{
								if (global::dfInputManager.controlUnderMouse == null)
								{
									global::UnityEngine.Debug.Log("Tracking touch with no control: " + touch.fingerId);
								}
								global::dfInputManager.TouchInputManager.ControlTouchTracker controlTouchTracker2 = new global::dfInputManager.TouchInputManager.ControlTouchTracker(this.manager, global::dfInputManager.controlUnderMouse);
								this.tracked.Add(controlTouchTracker2);
								controlTouchTracker2.Process(info);
							}
						}
					}
				}
			}
		}

		// Token: 0x0600458A RID: 17802 RVA: 0x000FEB74 File Offset: 0x000FCD74
		private global::dfControl clipCast(global::UnityEngine.Transform transform, global::UnityEngine.RaycastHit[] hits)
		{
			if (hits == null || hits.Length == 0)
			{
				return null;
			}
			global::dfControl dfControl = null;
			global::dfControl modalControl = global::dfGUIManager.GetModalControl();
			for (int i = hits.Length - 1; i >= 0; i--)
			{
				global::UnityEngine.RaycastHit hit = hits[i];
				global::dfControl component = hit.transform.GetComponent<global::dfControl>();
				bool flag = component == null || (modalControl != null && !component.transform.IsChildOf(modalControl.transform)) || !component.enabled || component.Opacity < 0.01f || !component.IsEnabled || !component.IsVisible || !component.transform.IsChildOf(transform);
				if (!flag)
				{
					if (this.isInsideClippingRegion(hit, component) && (dfControl == null || component.RenderOrder > dfControl.RenderOrder))
					{
						dfControl = component;
					}
				}
			}
			return dfControl;
		}

		// Token: 0x0600458B RID: 17803 RVA: 0x000FEC80 File Offset: 0x000FCE80
		private bool isInsideClippingRegion(global::UnityEngine.RaycastHit hit, global::dfControl control)
		{
			global::UnityEngine.Vector3 point = hit.point;
			while (control != null)
			{
				global::UnityEngine.Plane[] array = (!control.ClipChildren) ? null : control.GetClippingPlanes();
				if (array != null && array.Length > 0)
				{
					for (int i = 0; i < array.Length; i++)
					{
						if (!array[i].GetSide(point))
						{
							return false;
						}
					}
				}
				control = control.Parent;
			}
			return true;
		}

		// Token: 0x0600458C RID: 17804 RVA: 0x000FED00 File Offset: 0x000FCF00
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static bool <Process>m__25(global::dfInputManager.TouchInputManager.ControlTouchTracker x)
		{
			return x.control == global::dfInputManager.controlUnderMouse;
		}

		// Token: 0x040024FE RID: 9470
		private global::System.Collections.Generic.List<global::dfInputManager.TouchInputManager.ControlTouchTracker> tracked = new global::System.Collections.Generic.List<global::dfInputManager.TouchInputManager.ControlTouchTracker>();

		// Token: 0x040024FF RID: 9471
		private global::System.Collections.Generic.List<int> untracked = new global::System.Collections.Generic.List<int>();

		// Token: 0x04002500 RID: 9472
		private global::dfInputManager manager;

		// Token: 0x04002501 RID: 9473
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static global::System.Func<global::dfInputManager.TouchInputManager.ControlTouchTracker, bool> <>f__am$cache3;

		// Token: 0x02000812 RID: 2066
		private class ControlTouchTracker
		{
			// Token: 0x0600458D RID: 17805 RVA: 0x000FED14 File Offset: 0x000FCF14
			public ControlTouchTracker(global::dfInputManager manager, global::dfControl control)
			{
				this.manager = manager;
				this.control = control;
			}

			// Token: 0x17000CEA RID: 3306
			// (get) Token: 0x0600458E RID: 17806 RVA: 0x000FED4C File Offset: 0x000FCF4C
			public bool IsDragging
			{
				get
				{
					return this.dragState == global::dfDragDropState.Dragging;
				}
			}

			// Token: 0x17000CEB RID: 3307
			// (get) Token: 0x0600458F RID: 17807 RVA: 0x000FED58 File Offset: 0x000FCF58
			public int TouchCount
			{
				get
				{
					return this.touches.Count;
				}
			}

			// Token: 0x06004590 RID: 17808 RVA: 0x000FED68 File Offset: 0x000FCF68
			public bool IsTrackingFinger(int fingerID)
			{
				return this.touches.ContainsKey(fingerID);
			}

			// Token: 0x06004591 RID: 17809 RVA: 0x000FED78 File Offset: 0x000FCF78
			public bool Process(global::dfInputManager.TouchInputManager.TouchRaycast info)
			{
				if (this.IsDragging)
				{
					if (!this.capture.Contains(info.FingerID))
					{
						return false;
					}
					if (info.Phase == 2)
					{
						return true;
					}
					if (info.Phase == 4)
					{
						this.control.OnDragEnd(new global::dfDragEventArgs(this.control, global::dfDragDropState.Cancelled, this.dragData, info.ray, info.position));
						this.dragState = global::dfDragDropState.None;
						this.touches.Clear();
						this.capture.Clear();
						return true;
					}
					if (info.Phase != 3)
					{
						return true;
					}
					if (info.control == null || info.control == this.control)
					{
						this.control.OnDragEnd(new global::dfDragEventArgs(this.control, global::dfDragDropState.CancelledNoTarget, this.dragData, info.ray, info.position));
						this.dragState = global::dfDragDropState.None;
						this.touches.Clear();
						this.capture.Clear();
						return true;
					}
					global::dfDragEventArgs dfDragEventArgs = new global::dfDragEventArgs(info.control, global::dfDragDropState.Dragging, this.dragData, info.ray, info.position);
					info.control.OnDragDrop(dfDragEventArgs);
					if (!dfDragEventArgs.Used || dfDragEventArgs.State != global::dfDragDropState.Dropped)
					{
						dfDragEventArgs.State = global::dfDragDropState.Cancelled;
					}
					global::dfDragEventArgs dfDragEventArgs2 = new global::dfDragEventArgs(this.control, dfDragEventArgs.State, this.dragData, info.ray, info.position);
					dfDragEventArgs2.Target = info.control;
					this.control.OnDragEnd(dfDragEventArgs2);
					this.dragState = global::dfDragDropState.None;
					this.touches.Clear();
					this.capture.Clear();
					return true;
				}
				else if (!this.touches.ContainsKey(info.FingerID))
				{
					if (info.control != this.control)
					{
						return false;
					}
					this.touches[info.FingerID] = info;
					if (this.touches.Count == 1)
					{
						this.control.OnMouseEnter(info);
						if (info.Phase == null)
						{
							this.capture.Add(info.FingerID);
							this.control.OnMouseDown(info);
						}
						return true;
					}
					if (info.Phase == null)
					{
						this.control.OnMouseUp(info);
						this.control.OnMouseLeave(info);
						global::System.Collections.Generic.List<global::UnityEngine.Touch> activeTouches = this.getActiveTouches();
						global::dfTouchEventArgs args = new global::dfTouchEventArgs(this.control, activeTouches, info.ray);
						this.control.OnMultiTouch(args);
					}
					return true;
				}
				else
				{
					if (info.Phase == 4 || info.Phase == 3)
					{
						global::dfInputManager.TouchInputManager.TouchRaycast touch = this.touches[info.FingerID];
						this.touches.Remove(info.FingerID);
						if (this.touches.Count == 0)
						{
							if (this.capture.Contains(info.FingerID))
							{
								if (this.canFireClickEvent(info, touch) && info.control == this.control)
								{
									if (info.touch.tapCount > 1)
									{
										this.control.OnDoubleClick(info);
									}
									else
									{
										this.control.OnClick(info);
									}
								}
								this.control.OnMouseUp(info);
							}
							this.control.OnMouseLeave(info);
							this.capture.Remove(info.FingerID);
							return true;
						}
						this.capture.Remove(info.FingerID);
						if (this.touches.Count == 1)
						{
							global::dfTouchEventArgs args2 = this.touches.Values.First<global::dfInputManager.TouchInputManager.TouchRaycast>();
							this.control.OnMouseEnter(args2);
							this.control.OnMouseDown(args2);
							return true;
						}
					}
					if (this.touches.Count > 1)
					{
						global::System.Collections.Generic.List<global::UnityEngine.Touch> activeTouches2 = this.getActiveTouches();
						global::dfTouchEventArgs args3 = new global::dfTouchEventArgs(this.control, activeTouches2, info.ray);
						this.control.OnMultiTouch(args3);
						return true;
					}
					if (!this.IsDragging && info.Phase == 2)
					{
						if (info.control == this.control)
						{
							this.control.OnMouseHover(info);
							return true;
						}
						return false;
					}
					else
					{
						bool flag = this.capture.Contains(info.FingerID) && this.dragState == global::dfDragDropState.None && info.Phase == 1;
						if (flag)
						{
							global::dfDragEventArgs dfDragEventArgs3 = info;
							this.control.OnDragStart(dfDragEventArgs3);
							if (dfDragEventArgs3.State == global::dfDragDropState.Dragging && dfDragEventArgs3.Used)
							{
								this.dragState = global::dfDragDropState.Dragging;
								this.dragData = dfDragEventArgs3.Data;
								return true;
							}
							this.dragState = global::dfDragDropState.Denied;
						}
						if (info.control != this.control && !this.capture.Contains(info.FingerID))
						{
							this.control.OnMouseLeave(info);
							this.touches.Remove(info.FingerID);
							return true;
						}
						this.control.OnMouseMove(info);
						return true;
					}
				}
			}

			// Token: 0x06004592 RID: 17810 RVA: 0x000FF2C0 File Offset: 0x000FD4C0
			private bool canFireClickEvent(global::dfInputManager.TouchInputManager.TouchRaycast info, global::dfInputManager.TouchInputManager.TouchRaycast touch)
			{
				if (this.manager.TouchClickRadius <= 0)
				{
					return true;
				}
				float num = global::UnityEngine.Vector2.Distance(info.position, touch.position);
				return num < (float)this.manager.TouchClickRadius;
			}

			// Token: 0x06004593 RID: 17811 RVA: 0x000FF304 File Offset: 0x000FD504
			private global::System.Collections.Generic.List<global::UnityEngine.Touch> getActiveTouches()
			{
				global::dfInputManager.TouchInputManager.ControlTouchTracker.<getActiveTouches>c__AnonStorey6B <getActiveTouches>c__AnonStorey6B = new global::dfInputManager.TouchInputManager.ControlTouchTracker.<getActiveTouches>c__AnonStorey6B();
				global::UnityEngine.Touch[] source = global::UnityEngine.Input.touches;
				<getActiveTouches>c__AnonStorey6B.result = (from x in this.touches
				select x.Value.touch).ToList<global::UnityEngine.Touch>();
				int i;
				for (i = 0; i < <getActiveTouches>c__AnonStorey6B.result.Count; i++)
				{
					<getActiveTouches>c__AnonStorey6B.result[i] = source.First((global::UnityEngine.Touch x) => x.fingerId == <getActiveTouches>c__AnonStorey6B.result[i].fingerId);
				}
				return <getActiveTouches>c__AnonStorey6B.result;
			}

			// Token: 0x06004594 RID: 17812 RVA: 0x000FF3B8 File Offset: 0x000FD5B8
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			private static global::UnityEngine.Touch <getActiveTouches>m__26(global::System.Collections.Generic.KeyValuePair<int, global::dfInputManager.TouchInputManager.TouchRaycast> x)
			{
				return x.Value.touch;
			}

			// Token: 0x04002502 RID: 9474
			public global::dfControl control;

			// Token: 0x04002503 RID: 9475
			public global::System.Collections.Generic.Dictionary<int, global::dfInputManager.TouchInputManager.TouchRaycast> touches = new global::System.Collections.Generic.Dictionary<int, global::dfInputManager.TouchInputManager.TouchRaycast>();

			// Token: 0x04002504 RID: 9476
			public global::System.Collections.Generic.List<int> capture = new global::System.Collections.Generic.List<int>();

			// Token: 0x04002505 RID: 9477
			private global::dfInputManager manager;

			// Token: 0x04002506 RID: 9478
			private global::dfDragDropState dragState;

			// Token: 0x04002507 RID: 9479
			private object dragData;

			// Token: 0x04002508 RID: 9480
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			private static global::System.Func<global::System.Collections.Generic.KeyValuePair<int, global::dfInputManager.TouchInputManager.TouchRaycast>, global::UnityEngine.Touch> <>f__am$cache6;

			// Token: 0x02000813 RID: 2067
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			private sealed class <getActiveTouches>c__AnonStorey6B
			{
				// Token: 0x06004595 RID: 17813 RVA: 0x000FF3C8 File Offset: 0x000FD5C8
				public <getActiveTouches>c__AnonStorey6B()
				{
				}

				// Token: 0x04002509 RID: 9481
				internal global::System.Collections.Generic.List<global::UnityEngine.Touch> result;
			}

			// Token: 0x02000814 RID: 2068
			[global::System.Runtime.CompilerServices.CompilerGenerated]
			private sealed class <getActiveTouches>c__AnonStorey6C
			{
				// Token: 0x06004596 RID: 17814 RVA: 0x000FF3D0 File Offset: 0x000FD5D0
				public <getActiveTouches>c__AnonStorey6C()
				{
				}

				// Token: 0x06004597 RID: 17815 RVA: 0x000FF3D8 File Offset: 0x000FD5D8
				internal bool <>m__27(global::UnityEngine.Touch x)
				{
					return x.fingerId == this.<>f__ref$107.result[this.i].fingerId;
				}

				// Token: 0x0400250A RID: 9482
				internal int i;

				// Token: 0x0400250B RID: 9483
				internal global::dfInputManager.TouchInputManager.ControlTouchTracker.<getActiveTouches>c__AnonStorey6B <>f__ref$107;
			}
		}

		// Token: 0x02000815 RID: 2069
		private class TouchRaycast
		{
			// Token: 0x06004598 RID: 17816 RVA: 0x000FF40C File Offset: 0x000FD60C
			public TouchRaycast(global::dfControl control, global::UnityEngine.Touch touch, global::UnityEngine.Ray ray)
			{
				this.control = control;
				this.touch = touch;
				this.ray = ray;
				this.position = touch.position;
			}

			// Token: 0x17000CEC RID: 3308
			// (get) Token: 0x06004599 RID: 17817 RVA: 0x000FF444 File Offset: 0x000FD644
			public int FingerID
			{
				get
				{
					return this.touch.fingerId;
				}
			}

			// Token: 0x17000CED RID: 3309
			// (get) Token: 0x0600459A RID: 17818 RVA: 0x000FF454 File Offset: 0x000FD654
			public global::UnityEngine.TouchPhase Phase
			{
				get
				{
					return this.touch.phase;
				}
			}

			// Token: 0x0600459B RID: 17819 RVA: 0x000FF464 File Offset: 0x000FD664
			public static implicit operator global::dfTouchEventArgs(global::dfInputManager.TouchInputManager.TouchRaycast touch)
			{
				return new global::dfTouchEventArgs(touch.control, touch.touch, touch.ray);
			}

			// Token: 0x0600459C RID: 17820 RVA: 0x000FF48C File Offset: 0x000FD68C
			public static implicit operator global::dfDragEventArgs(global::dfInputManager.TouchInputManager.TouchRaycast touch)
			{
				return new global::dfDragEventArgs(touch.control, global::dfDragDropState.None, null, touch.ray, touch.position);
			}

			// Token: 0x0400250C RID: 9484
			public global::dfControl control;

			// Token: 0x0400250D RID: 9485
			public global::UnityEngine.Touch touch;

			// Token: 0x0400250E RID: 9486
			public global::UnityEngine.Ray ray;

			// Token: 0x0400250F RID: 9487
			public global::UnityEngine.Vector2 position;
		}

		// Token: 0x02000816 RID: 2070
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private sealed class <Process>c__AnonStorey6A
		{
			// Token: 0x0600459D RID: 17821 RVA: 0x000FF4B4 File Offset: 0x000FD6B4
			public <Process>c__AnonStorey6A()
			{
			}

			// Token: 0x0600459E RID: 17822 RVA: 0x000FF4BC File Offset: 0x000FD6BC
			internal bool <>m__24(global::dfInputManager.TouchInputManager.ControlTouchTracker x)
			{
				return x.IsTrackingFinger(this.info.FingerID);
			}

			// Token: 0x04002510 RID: 9488
			internal global::dfInputManager.TouchInputManager.TouchRaycast info;
		}
	}

	// Token: 0x02000817 RID: 2071
	private class MouseInputManager
	{
		// Token: 0x0600459F RID: 17823 RVA: 0x000FF4D0 File Offset: 0x000FD6D0
		public MouseInputManager()
		{
		}

		// Token: 0x060045A0 RID: 17824 RVA: 0x000FF504 File Offset: 0x000FD704
		public void ProcessInput(global::IInputAdapter adapter, global::UnityEngine.Ray ray, global::dfControl control, bool retainFocusSetting)
		{
			global::UnityEngine.Vector2 mousePosition = adapter.GetMousePosition();
			this.buttonsDown = global::dfMouseButtons.None;
			this.buttonsReleased = global::dfMouseButtons.None;
			this.buttonsPressed = global::dfMouseButtons.None;
			global::dfInputManager.MouseInputManager.getMouseButtonInfo(adapter, ref this.buttonsDown, ref this.buttonsReleased, ref this.buttonsPressed);
			float num = adapter.GetAxis("Mouse ScrollWheel");
			if (!global::UnityEngine.Mathf.Approximately(num, 0f))
			{
				num = global::UnityEngine.Mathf.Sign(num) * global::UnityEngine.Mathf.Max(1f, global::UnityEngine.Mathf.Abs(num));
			}
			this.mouseMoveDelta = mousePosition - this.lastPosition;
			this.lastPosition = mousePosition;
			if (this.dragState == global::dfDragDropState.Dragging)
			{
				if (this.buttonsReleased != global::dfMouseButtons.None)
				{
					if (control != null && control != this.activeControl)
					{
						global::dfDragEventArgs dfDragEventArgs = new global::dfDragEventArgs(control, global::dfDragDropState.Dragging, this.dragData, ray, mousePosition);
						control.OnDragDrop(dfDragEventArgs);
						if (!dfDragEventArgs.Used || dfDragEventArgs.State == global::dfDragDropState.Dragging)
						{
							dfDragEventArgs.State = global::dfDragDropState.Cancelled;
						}
						dfDragEventArgs = new global::dfDragEventArgs(this.activeControl, dfDragEventArgs.State, dfDragEventArgs.Data, ray, mousePosition);
						dfDragEventArgs.Target = control;
						this.activeControl.OnDragEnd(dfDragEventArgs);
					}
					else
					{
						global::dfDragDropState state = (!(control == null)) ? global::dfDragDropState.Cancelled : global::dfDragDropState.CancelledNoTarget;
						global::dfDragEventArgs args = new global::dfDragEventArgs(this.activeControl, state, this.dragData, ray, mousePosition);
						this.activeControl.OnDragEnd(args);
					}
					this.dragState = global::dfDragDropState.None;
					this.lastDragControl = null;
					this.activeControl = null;
					this.lastClickTime = 0f;
					this.lastHoverTime = 0f;
					this.lastPosition = mousePosition;
					return;
				}
				if (control == this.activeControl)
				{
					return;
				}
				if (control != this.lastDragControl)
				{
					if (this.lastDragControl != null)
					{
						global::dfDragEventArgs args2 = new global::dfDragEventArgs(this.lastDragControl, this.dragState, this.dragData, ray, mousePosition);
						this.lastDragControl.OnDragLeave(args2);
					}
					if (control != null)
					{
						global::dfDragEventArgs args3 = new global::dfDragEventArgs(control, this.dragState, this.dragData, ray, mousePosition);
						control.OnDragEnter(args3);
					}
					this.lastDragControl = control;
					return;
				}
				if (control != null && global::UnityEngine.Vector2.Distance(mousePosition, this.lastPosition) > 1f)
				{
					global::dfDragEventArgs args4 = new global::dfDragEventArgs(control, this.dragState, this.dragData, ray, mousePosition);
					control.OnDragOver(args4);
				}
				return;
			}
			else if (this.buttonsReleased != global::dfMouseButtons.None)
			{
				this.lastHoverTime = global::UnityEngine.Time.realtimeSinceStartup + 0.25f;
				if (this.activeControl == null)
				{
					this.setActive(control, mousePosition, ray);
					return;
				}
				if (this.activeControl == control && this.buttonsDown == global::dfMouseButtons.None)
				{
					if (global::UnityEngine.Time.realtimeSinceStartup - this.lastClickTime < 0.25f)
					{
						this.lastClickTime = 0f;
						this.activeControl.OnDoubleClick(new global::dfMouseEventArgs(this.activeControl, this.buttonsReleased, 1, ray, mousePosition, num));
					}
					else
					{
						this.lastClickTime = global::UnityEngine.Time.realtimeSinceStartup;
						this.activeControl.OnClick(new global::dfMouseEventArgs(this.activeControl, this.buttonsReleased, 1, ray, mousePosition, num));
					}
				}
				this.activeControl.OnMouseUp(new global::dfMouseEventArgs(this.activeControl, this.buttonsReleased, 0, ray, mousePosition, num));
				if (this.buttonsDown == global::dfMouseButtons.None && this.activeControl != control)
				{
					this.setActive(null, mousePosition, ray);
				}
				return;
			}
			else
			{
				if (this.buttonsPressed != global::dfMouseButtons.None)
				{
					this.lastHoverTime = global::UnityEngine.Time.realtimeSinceStartup + 0.25f;
					if (this.activeControl != null)
					{
						this.activeControl.OnMouseDown(new global::dfMouseEventArgs(this.activeControl, this.buttonsPressed, 0, ray, mousePosition, num));
					}
					else
					{
						this.setActive(control, mousePosition, ray);
						if (control != null)
						{
							control.OnMouseDown(new global::dfMouseEventArgs(control, this.buttonsPressed, 0, ray, mousePosition, num));
						}
						else if (!retainFocusSetting)
						{
							global::dfControl dfControl = global::dfGUIManager.ActiveControl;
							if (dfControl != null)
							{
								dfControl.Unfocus();
							}
						}
					}
					return;
				}
				if (this.activeControl != null && this.activeControl == control && this.mouseMoveDelta.magnitude == 0f && global::UnityEngine.Time.realtimeSinceStartup - this.lastHoverTime > 0.1f)
				{
					this.activeControl.OnMouseHover(new global::dfMouseEventArgs(this.activeControl, this.buttonsDown, 0, ray, mousePosition, num));
					this.lastHoverTime = global::UnityEngine.Time.realtimeSinceStartup;
				}
				if (this.buttonsDown == global::dfMouseButtons.None)
				{
					if (num != 0f && control != null)
					{
						this.setActive(control, mousePosition, ray);
						control.OnMouseWheel(new global::dfMouseEventArgs(control, this.buttonsDown, 0, ray, mousePosition, num));
						return;
					}
					this.setActive(control, mousePosition, ray);
				}
				else if (this.activeControl != null)
				{
					if (!(control != null) || control.RenderOrder > this.activeControl.RenderOrder)
					{
					}
					if (this.mouseMoveDelta.magnitude >= 2f && (this.buttonsDown & (global::dfMouseButtons.Left | global::dfMouseButtons.Right)) != global::dfMouseButtons.None && this.dragState != global::dfDragDropState.Denied)
					{
						global::dfDragEventArgs dfDragEventArgs2 = new global::dfDragEventArgs(this.activeControl)
						{
							Position = mousePosition
						};
						this.activeControl.OnDragStart(dfDragEventArgs2);
						if (dfDragEventArgs2.State == global::dfDragDropState.Dragging)
						{
							this.dragState = global::dfDragDropState.Dragging;
							this.dragData = dfDragEventArgs2.Data;
							return;
						}
						this.dragState = global::dfDragDropState.Denied;
					}
				}
				if (this.activeControl != null && this.mouseMoveDelta.magnitude >= 1f)
				{
					global::dfMouseEventArgs args5 = new global::dfMouseEventArgs(this.activeControl, this.buttonsDown, 0, ray, mousePosition, num)
					{
						MoveDelta = this.mouseMoveDelta
					};
					this.activeControl.OnMouseMove(args5);
				}
				return;
			}
		}

		// Token: 0x060045A1 RID: 17825 RVA: 0x000FFAF0 File Offset: 0x000FDCF0
		private static void getMouseButtonInfo(global::IInputAdapter adapter, ref global::dfMouseButtons buttonsDown, ref global::dfMouseButtons buttonsReleased, ref global::dfMouseButtons buttonsPressed)
		{
			for (int i = 0; i < 3; i++)
			{
				if (adapter.GetMouseButton(i))
				{
					buttonsDown |= (global::dfMouseButtons)(1 << i);
				}
				if (adapter.GetMouseButtonUp(i))
				{
					buttonsReleased |= (global::dfMouseButtons)(1 << i);
				}
				if (adapter.GetMouseButtonDown(i))
				{
					buttonsPressed |= (global::dfMouseButtons)(1 << i);
				}
			}
		}

		// Token: 0x060045A2 RID: 17826 RVA: 0x000FFB54 File Offset: 0x000FDD54
		private void setActive(global::dfControl control, global::UnityEngine.Vector2 position, global::UnityEngine.Ray ray)
		{
			if (this.activeControl != null && this.activeControl != control)
			{
				this.activeControl.OnMouseLeave(new global::dfMouseEventArgs(this.activeControl)
				{
					Position = position,
					Ray = ray
				});
			}
			if (control != null && control != this.activeControl)
			{
				this.lastClickTime = 0f;
				this.lastHoverTime = global::UnityEngine.Time.realtimeSinceStartup + 0.25f;
				control.OnMouseEnter(new global::dfMouseEventArgs(control)
				{
					Position = position,
					Ray = ray
				});
			}
			this.activeControl = control;
			this.lastPosition = position;
			this.dragState = global::dfDragDropState.None;
		}

		// Token: 0x04002511 RID: 9489
		private const string scrollAxisName = "Mouse ScrollWheel";

		// Token: 0x04002512 RID: 9490
		private const float DOUBLECLICK_TIME = 0.25f;

		// Token: 0x04002513 RID: 9491
		private const int DRAG_START_DELTA = 2;

		// Token: 0x04002514 RID: 9492
		private const float HOVER_NOTIFICATION_FREQUENCY = 0.1f;

		// Token: 0x04002515 RID: 9493
		private const float HOVER_NOTIFICATION_BEGIN = 0.25f;

		// Token: 0x04002516 RID: 9494
		private global::dfControl activeControl;

		// Token: 0x04002517 RID: 9495
		private global::UnityEngine.Vector2 lastPosition = global::UnityEngine.Vector2.one * -2.1474836E+09f;

		// Token: 0x04002518 RID: 9496
		private global::UnityEngine.Vector2 mouseMoveDelta = global::UnityEngine.Vector2.zero;

		// Token: 0x04002519 RID: 9497
		private float lastClickTime;

		// Token: 0x0400251A RID: 9498
		private float lastHoverTime;

		// Token: 0x0400251B RID: 9499
		private global::dfDragDropState dragState;

		// Token: 0x0400251C RID: 9500
		private object dragData;

		// Token: 0x0400251D RID: 9501
		private global::dfControl lastDragControl;

		// Token: 0x0400251E RID: 9502
		private global::dfMouseButtons buttonsDown;

		// Token: 0x0400251F RID: 9503
		private global::dfMouseButtons buttonsReleased;

		// Token: 0x04002520 RID: 9504
		private global::dfMouseButtons buttonsPressed;
	}

	// Token: 0x02000818 RID: 2072
	private class DefaultInput : global::IInputAdapter
	{
		// Token: 0x060045A3 RID: 17827 RVA: 0x000FFC14 File Offset: 0x000FDE14
		public DefaultInput()
		{
		}

		// Token: 0x060045A4 RID: 17828 RVA: 0x000FFC1C File Offset: 0x000FDE1C
		public bool GetKeyDown(global::UnityEngine.KeyCode key)
		{
			return global::UnityEngine.Input.GetKeyDown(key);
		}

		// Token: 0x060045A5 RID: 17829 RVA: 0x000FFC24 File Offset: 0x000FDE24
		public bool GetKeyUp(global::UnityEngine.KeyCode key)
		{
			return global::UnityEngine.Input.GetKeyUp(key);
		}

		// Token: 0x060045A6 RID: 17830 RVA: 0x000FFC2C File Offset: 0x000FDE2C
		public float GetAxis(string axisName)
		{
			return global::UnityEngine.Input.GetAxis(axisName);
		}

		// Token: 0x060045A7 RID: 17831 RVA: 0x000FFC34 File Offset: 0x000FDE34
		public global::UnityEngine.Vector2 GetMousePosition()
		{
			return global::UnityEngine.Input.mousePosition;
		}

		// Token: 0x060045A8 RID: 17832 RVA: 0x000FFC40 File Offset: 0x000FDE40
		public bool GetMouseButton(int button)
		{
			return global::UnityEngine.Input.GetMouseButton(button);
		}

		// Token: 0x060045A9 RID: 17833 RVA: 0x000FFC48 File Offset: 0x000FDE48
		public bool GetMouseButtonDown(int button)
		{
			return global::UnityEngine.Input.GetMouseButtonDown(button);
		}

		// Token: 0x060045AA RID: 17834 RVA: 0x000FFC50 File Offset: 0x000FDE50
		public bool GetMouseButtonUp(int button)
		{
			return global::UnityEngine.Input.GetMouseButtonUp(button);
		}
	}
}
