using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using NGUI.MessageUtil;
using NGUIHack;
using UnityEngine;

// Token: 0x02000924 RID: 2340
[global::UnityEngine.AddComponentMenu("NGUI/UI/Camera")]
[global::UnityEngine.ExecuteInEditMode]
[global::UnityEngine.RequireComponent(typeof(global::UnityEngine.Camera))]
public class UICamera : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06004FCA RID: 20426 RVA: 0x00136890 File Offset: 0x00134A90
	public UICamera()
	{
	}

	// Token: 0x06004FCB RID: 20427 RVA: 0x00136968 File Offset: 0x00134B68
	// Note: this type is marked as 'beforefieldinit'.
	static UICamera()
	{
	}

	// Token: 0x06004FCC RID: 20428 RVA: 0x00136A00 File Offset: 0x00134C00
	public static bool PopupPanel(global::UIPanel panel)
	{
		if (global::UICamera.popupPanel == panel)
		{
			return false;
		}
		if (global::UICamera.popupPanel)
		{
			global::UICamera.popupPanel.gameObject.NGUIMessage("PopupEnd");
			global::UICamera.popupPanel = null;
		}
		if (panel)
		{
			global::UICamera.popupPanel = panel;
			global::UICamera.popupPanel.gameObject.NGUIMessage("PopupStart");
		}
		return true;
	}

	// Token: 0x06004FCD RID: 20429 RVA: 0x00136A70 File Offset: 0x00134C70
	public static bool UnPopupPanel(global::UIPanel panel)
	{
		if (global::UICamera.popupPanel == panel && panel)
		{
			global::UICamera.popupPanel.gameObject.NGUIMessage("PopupEnd");
			global::UICamera.popupPanel = null;
			return true;
		}
		return false;
	}

	// Token: 0x17000EB7 RID: 3767
	// (get) Token: 0x06004FCE RID: 20430 RVA: 0x00136AB8 File Offset: 0x00134CB8
	public static global::UICamera.CursorSampler Cursor
	{
		get
		{
			return global::UICamera.LateLoadCursor.Sampler;
		}
	}

	// Token: 0x17000EB8 RID: 3768
	// (get) Token: 0x06004FCF RID: 20431 RVA: 0x00136AC0 File Offset: 0x00134CC0
	public static bool IsPressing
	{
		get
		{
			return global::UICamera.Cursor.Buttons.LeftValue.Held && global::UICamera.Cursor.Buttons.LeftValue.Pressed;
		}
	}

	// Token: 0x06004FD0 RID: 20432 RVA: 0x00136AF8 File Offset: 0x00134CF8
	private void OnEvent(global::NGUIHack.Event @event, global::UnityEngine.EventType type)
	{
		global::UnityEngine.Camera camera = global::UICamera.currentCamera;
		try
		{
			global::UICamera.currentCamera = this.cachedCamera;
			switch (type)
			{
			case 0:
			case 1:
			case 2:
			case 3:
				if ((this.mouseMode & global::UIInputMode.UseEvents) == global::UIInputMode.UseEvents)
				{
					this.OnMouseEvent(@event, type);
				}
				break;
			case 4:
			case 5:
				if ((this.keyboardMode & global::UIInputMode.UseEvents) == global::UIInputMode.UseEvents)
				{
					this.OnKeyboardEvent(@event, type);
				}
				break;
			case 6:
				if ((this.scrollWheelMode & global::UIInputMode.UseEvents) == global::UIInputMode.UseEvents)
				{
					this.OnScrollWheelEvent(@event, type);
				}
				break;
			}
		}
		finally
		{
			global::UICamera.currentCamera = camera;
		}
	}

	// Token: 0x06004FD1 RID: 20433 RVA: 0x00136BB8 File Offset: 0x00134DB8
	private void OnMouseEvent(global::NGUIHack.Event @event, global::UnityEngine.EventType type)
	{
		if (this.OnEventShared(@event, type))
		{
			return;
		}
		global::UICamera.Cursor.MouseEvent(@event, type);
	}

	// Token: 0x06004FD2 RID: 20434 RVA: 0x00136BD4 File Offset: 0x00134DD4
	private void OnScrollWheelEvent(global::NGUIHack.Event @event, global::UnityEngine.EventType type)
	{
		if (global::UICamera.mHover != null)
		{
			global::UnityEngine.Vector2 delta = @event.delta;
			bool flag = false;
			bool flag2 = false;
			if (delta.y != 0f)
			{
				global::UICamera.SwallowScroll = false;
				global::UICamera.mHover.Scroll(delta.y);
				flag2 = !global::UICamera.SwallowScroll;
			}
			if (delta.x != 0f)
			{
				global::UICamera.SwallowScroll = false;
				global::UICamera.mHover.ScrollX(delta.x);
				flag = !global::UICamera.SwallowScroll;
			}
			if (flag2 || flag)
			{
				global::UIPanel uipanel = global::UIPanel.Find(global::UICamera.mHover.transform);
				if (uipanel)
				{
					if (flag2)
					{
						uipanel.gameObject.NGUIMessage("OnHoverScroll", delta.y);
					}
					if (flag)
					{
						uipanel.gameObject.NGUIMessage("OnHoverScrollX", delta.x);
					}
				}
			}
			@event.Use();
		}
	}

	// Token: 0x06004FD3 RID: 20435 RVA: 0x00136CC8 File Offset: 0x00134EC8
	private void OnSubmitEvent(global::NGUIHack.Event @event, global::UnityEngine.EventType type)
	{
	}

	// Token: 0x06004FD4 RID: 20436 RVA: 0x00136CCC File Offset: 0x00134ECC
	private void OnCancelEvent(global::NGUIHack.Event @event, global::UnityEngine.EventType type)
	{
		if (type == 4)
		{
			global::UICamera.mSel.SendMessage("OnKey", 0x1B, 1);
			@event.Use();
		}
	}

	// Token: 0x06004FD5 RID: 20437 RVA: 0x00136D00 File Offset: 0x00134F00
	private void OnDirectionEvent(global::NGUIHack.Event @event, int x, int y, global::UnityEngine.EventType type)
	{
		bool flag = false;
		if (type == 4)
		{
			if (x != 0)
			{
				global::UICamera.mSel.SendMessage("OnKey", (x >= 0) ? 0x113 : 0x114, 1);
				flag = true;
			}
			if (y != 0)
			{
				global::UICamera.mSel.SendMessage("OnKey", (y >= 0) ? 0x111 : 0x112, 1);
				flag = true;
			}
		}
		if (flag)
		{
			@event.Use();
		}
	}

	// Token: 0x06004FD6 RID: 20438 RVA: 0x00136D8C File Offset: 0x00134F8C
	private void OnKeyboardEvent(global::NGUIHack.Event @event, global::UnityEngine.EventType type)
	{
		if (this.OnEventShared(@event, type))
		{
			return;
		}
		char character = @event.character;
		global::UnityEngine.KeyCode keyCode = @event.keyCode;
		bool flag = global::UICamera.mSelInput;
		if (flag)
		{
			global::UICamera.mSelInput.OnEvent(this, @event, type);
		}
		if (global::UICamera.mSel != null)
		{
			global::UnityEngine.KeyCode keyCode2 = keyCode;
			if (keyCode2 != 9)
			{
				if (keyCode2 != 0x7F)
				{
					if (type == 4 && character != '\0')
					{
						global::UICamera.mSel.Input(character.ToString());
					}
					if (keyCode == this.submitKey0 || keyCode == this.submitKey1)
					{
						if (!flag || @event.type == type)
						{
							this.OnSubmitEvent(@event, type);
						}
					}
					else if (keyCode == this.cancelKey0 || keyCode == this.cancelKey1)
					{
						if (!flag || @event.type == type)
						{
							this.OnCancelEvent(@event, type);
						}
					}
					else if (global::UICamera.inputHasFocus)
					{
						if (!flag || @event.type == type)
						{
							if (keyCode == 0x111)
							{
								this.OnDirectionEvent(@event, 0, 1, type);
							}
							else if (keyCode == 0x112)
							{
								this.OnDirectionEvent(@event, 0, -1, type);
							}
							else if (keyCode == 0x114)
							{
								this.OnDirectionEvent(@event, -1, 0, type);
							}
							else if (keyCode == 0x113)
							{
								this.OnDirectionEvent(@event, 1, 0, type);
							}
						}
					}
					else if (!flag || @event.type == type)
					{
						if (keyCode == 0x111 || keyCode == 0x77)
						{
							this.OnDirectionEvent(@event, 0, 1, type);
						}
						else if (keyCode == 0x112 || keyCode == 0x73)
						{
							this.OnDirectionEvent(@event, 0, -1, type);
						}
						else if (keyCode == 0x114 || keyCode == 0x61)
						{
							this.OnDirectionEvent(@event, -1, 0, type);
						}
						else if (keyCode == 0x113 || keyCode == 0x64)
						{
							this.OnDirectionEvent(@event, 1, 0, type);
						}
					}
				}
				else if (type == 4)
				{
					global::UICamera.mSel.Input("\b");
				}
			}
			else if (type == 4)
			{
				global::UICamera.mSel.Key(9);
			}
		}
	}

	// Token: 0x06004FD7 RID: 20439 RVA: 0x00136FD8 File Offset: 0x001351D8
	private bool OnEventShared(global::NGUIHack.Event @event, global::UnityEngine.EventType type)
	{
		return false;
	}

	// Token: 0x06004FD8 RID: 20440 RVA: 0x00136FDC File Offset: 0x001351DC
	private static void IssueEvent(global::NGUIHack.Event @event, global::UnityEngine.EventType type)
	{
		int button = @event.button;
		global::UnityEngine.KeyCode keyCode = @event.keyCode;
		global::UICamera uicamera = null;
		switch (type)
		{
		case 0:
			if (button != 0 && global::UICamera.mMouseCamera.TryGetValue(0, out uicamera) && uicamera)
			{
				uicamera.OnEvent(@event, type);
				if (@event.type != null)
				{
					global::UICamera.mMouseCamera[button] = uicamera;
					return;
				}
			}
			break;
		case 1:
			if (global::UICamera.mMouseCamera.TryGetValue(button, out uicamera))
			{
				if (uicamera)
				{
					uicamera.OnEvent(@event, type);
					if (@event.type == 1)
					{
						@event.Use();
					}
				}
				else
				{
					@event.Use();
				}
				global::UICamera.mMouseCamera.Remove(button);
			}
			return;
		case 3:
			if (global::UICamera.mMouseCamera.TryGetValue(0, out uicamera))
			{
				if (uicamera)
				{
					uicamera.OnEvent(@event, type);
				}
				else
				{
					@event.Use();
				}
			}
			return;
		case 5:
			if (global::UICamera.mKeyCamera.TryGetValue(keyCode, out uicamera))
			{
				if (uicamera)
				{
					uicamera.OnEvent(@event, type);
					if (@event.type == 5)
					{
						@event.Use();
					}
				}
				else
				{
					@event.Use();
				}
				global::UICamera.mKeyCamera.Remove(keyCode);
			}
			return;
		}
		for (int i = 0; i < global::UICamera.mListCount; i++)
		{
			global::UICamera uicamera2 = global::UICamera.mList[(int)global::UICamera.mListSort[i]];
			if (!(uicamera2 == uicamera))
			{
				if (uicamera2.usesAnyEvents)
				{
					uicamera2.OnEvent(@event, type);
					global::UnityEngine.EventType type2 = @event.type;
					if (type2 != type)
					{
						if (type != null)
						{
							if (type == 4)
							{
								global::UICamera.mKeyCamera[keyCode] = uicamera2;
							}
						}
						else
						{
							global::UICamera.mMouseCamera[button] = uicamera2;
						}
						return;
					}
				}
			}
		}
	}

	// Token: 0x06004FD9 RID: 20441 RVA: 0x001371DC File Offset: 0x001353DC
	public static void HandleEvent(global::NGUIHack.Event @event, global::UnityEngine.EventType type)
	{
		switch (type)
		{
		case 0:
			using (new global::UICamera.Mouse.Button.ButtonPressEventHandler(@event))
			{
				global::UICamera.IssueEvent(@event, 0);
			}
			return;
		case 1:
			using (new global::UICamera.Mouse.Button.ButtonReleaseEventHandler(@event))
			{
				global::UICamera.IssueEvent(@event, 1);
			}
			return;
		case 2:
			if (!global::UICamera.Mouse.Button.AllowMove)
			{
				return;
			}
			break;
		case 3:
			if (!global::UICamera.Mouse.Button.AllowDrag)
			{
				return;
			}
			break;
		case 7:
		case 8:
		case 0xB:
		case 0xC:
			return;
		}
		global::UICamera.IssueEvent(@event, type);
		if (type == 2 && @event.type == 0xC)
		{
			global::UnityEngine.Debug.LogWarning("Mouse move was used.");
		}
	}

	// Token: 0x06004FDA RID: 20442 RVA: 0x001372EC File Offset: 0x001354EC
	public static void Render()
	{
		for (int i = 0; i < global::UICamera.mListCount; i++)
		{
			if (global::UICamera.mList[i] && global::UICamera.mList[i].enabled && global::UICamera.mList[i].camera && !global::UICamera.mList[i].camera.enabled)
			{
				global::UICamera.mList[i].camera.Render();
			}
		}
	}

	// Token: 0x06004FDB RID: 20443 RVA: 0x00137370 File Offset: 0x00135570
	public global::UITextPosition RaycastText(global::UnityEngine.Vector3 inPos, global::UILabel label)
	{
		if (!base.enabled || !base.camera.enabled || !base.camera.pixelRect.Contains(inPos) || !label)
		{
			global::UnityEngine.Debug.Log("No Sir");
			return default(global::UITextPosition);
		}
		global::UnityEngine.Ray ray = base.camera.ScreenPointToRay(inPos);
		global::UnityEngine.Vector3 forward = label.transform.forward;
		if (global::UnityEngine.Vector3.Dot(ray.direction, forward) <= 0f)
		{
			global::UnityEngine.Debug.Log("Bad Dir");
			return default(global::UITextPosition);
		}
		global::UnityEngine.Plane plane;
		plane..ctor(forward, label.transform.position);
		float num;
		if (!plane.Raycast(ray, ref num))
		{
			global::UnityEngine.Debug.Log("Paralell");
			return default(global::UITextPosition);
		}
		global::UnityEngine.Vector3 point = ray.GetPoint(num);
		global::UnityEngine.Vector3[] points = new global::UnityEngine.Vector3[]
		{
			label.transform.InverseTransformPoint(point)
		};
		global::UITextPosition[] array = new global::UITextPosition[]
		{
			default(global::UITextPosition)
		};
		if (label.CalculateTextPosition(1, points, array) == 0)
		{
			global::UnityEngine.Debug.Log("Zero");
		}
		return array[0];
	}

	// Token: 0x17000EB9 RID: 3769
	// (get) Token: 0x06004FDC RID: 20444 RVA: 0x001374C0 File Offset: 0x001356C0
	public bool usesAnyEvents
	{
		get
		{
			return ((this.mouseMode | this.keyboardMode | this.scrollWheelMode) & global::UIInputMode.UseEvents) == global::UIInputMode.UseEvents;
		}
	}

	// Token: 0x17000EBA RID: 3770
	// (get) Token: 0x06004FDD RID: 20445 RVA: 0x001374DC File Offset: 0x001356DC
	[global::System.Obsolete("Use UICamera.currentCamera instead")]
	public static global::UnityEngine.Camera lastCamera
	{
		get
		{
			return global::UICamera.currentCamera;
		}
	}

	// Token: 0x17000EBB RID: 3771
	// (get) Token: 0x06004FDE RID: 20446 RVA: 0x001374E4 File Offset: 0x001356E4
	[global::System.Obsolete("Use UICamera.currentTouchID instead")]
	public static int lastTouchID
	{
		get
		{
			return global::UICamera.currentTouchID;
		}
	}

	// Token: 0x17000EBC RID: 3772
	// (get) Token: 0x06004FDF RID: 20447 RVA: 0x001374EC File Offset: 0x001356EC
	private bool handlesEvents
	{
		get
		{
			return global::UICamera.eventHandler == this;
		}
	}

	// Token: 0x17000EBD RID: 3773
	// (get) Token: 0x06004FE0 RID: 20448 RVA: 0x001374FC File Offset: 0x001356FC
	public global::UnityEngine.Camera cachedCamera
	{
		get
		{
			if (this.mCam == null)
			{
				this.mCam = base.camera;
			}
			return this.mCam;
		}
	}

	// Token: 0x17000EBE RID: 3774
	// (get) Token: 0x06004FE1 RID: 20449 RVA: 0x00137524 File Offset: 0x00135724
	public static global::UnityEngine.GameObject hoveredObject
	{
		get
		{
			return global::UICamera.mHover;
		}
	}

	// Token: 0x17000EBF RID: 3775
	// (get) Token: 0x06004FE2 RID: 20450 RVA: 0x0013752C File Offset: 0x0013572C
	// (set) Token: 0x06004FE3 RID: 20451 RVA: 0x00137534 File Offset: 0x00135734
	public static global::UnityEngine.GameObject selectedObject
	{
		get
		{
			return global::UICamera.mSel;
		}
		set
		{
			if (!global::UICamera.SetSelectedObject(value))
			{
				throw new global::System.InvalidOperationException("Do not set selectedObject within a OnSelect message.");
			}
		}
	}

	// Token: 0x06004FE4 RID: 20452 RVA: 0x0013754C File Offset: 0x0013574C
	public static bool SetSelectedObject(global::UnityEngine.GameObject value)
	{
		if (global::UICamera.mSel != value)
		{
			if (global::UICamera.inSelectionCallback)
			{
				return false;
			}
			global::UIInput uiinput = (!value) ? null : value.GetComponent<global::UIInput>();
			if (global::UICamera.mSelInput != uiinput)
			{
				if (global::UICamera.mSelInput)
				{
					global::UICamera.mSelInput.LoseFocus();
				}
				global::UICamera.mSelInput = uiinput;
				if (uiinput && global::UICamera.mPressInput != uiinput)
				{
					uiinput.GainFocus();
				}
			}
			if (global::UICamera.mSel != null)
			{
				global::UICamera uicamera = global::UICamera.FindCameraForLayer(global::UICamera.mSel.layer);
				if (uicamera != null)
				{
					global::UnityEngine.Camera camera = global::UICamera.currentCamera;
					try
					{
						global::UICamera.currentCamera = uicamera.mCam;
						global::UICamera.inSelectionCallback = true;
						global::UICamera.mSel.Select(false);
						if (uicamera.useController || uicamera.useKeyboard)
						{
							global::UICamera.Highlight(global::UICamera.mSel, false);
						}
					}
					finally
					{
						global::UICamera.currentCamera = camera;
						global::UICamera.inSelectionCallback = false;
					}
				}
			}
			global::UICamera.mSel = value;
			if (global::UICamera.mSel != null)
			{
				global::UICamera uicamera2 = global::UICamera.FindCameraForLayer(global::UICamera.mSel.layer);
				if (uicamera2 != null)
				{
					global::UICamera.currentCamera = uicamera2.mCam;
					if (uicamera2.useController || uicamera2.useKeyboard)
					{
						global::UICamera.Highlight(global::UICamera.mSel, true);
					}
					global::UICamera.mSel.Select(true);
				}
			}
		}
		return true;
	}

	// Token: 0x06004FE5 RID: 20453 RVA: 0x001376E4 File Offset: 0x001358E4
	private void OnApplicationQuit()
	{
		global::UICamera.mHighlighted.Clear();
	}

	// Token: 0x17000EC0 RID: 3776
	// (get) Token: 0x06004FE6 RID: 20454 RVA: 0x001376F0 File Offset: 0x001358F0
	public static global::UnityEngine.Camera mainCamera
	{
		get
		{
			global::UICamera eventHandler = global::UICamera.eventHandler;
			return (!(eventHandler != null)) ? null : eventHandler.cachedCamera;
		}
	}

	// Token: 0x17000EC1 RID: 3777
	// (get) Token: 0x06004FE7 RID: 20455 RVA: 0x0013771C File Offset: 0x0013591C
	public static global::UICamera eventHandler
	{
		get
		{
			return global::UICamera.mList[(int)global::UICamera.mListSort[0]];
		}
	}

	// Token: 0x06004FE8 RID: 20456 RVA: 0x0013772C File Offset: 0x0013592C
	private static int CompareFunc(global::UICamera a, global::UICamera b)
	{
		return b.cachedCamera.depth.CompareTo(a.cachedCamera.depth);
	}

	// Token: 0x06004FE9 RID: 20457 RVA: 0x00137758 File Offset: 0x00135958
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

	// Token: 0x06004FEA RID: 20458 RVA: 0x00137808 File Offset: 0x00135A08
	private static bool Raycast(global::UnityEngine.Vector3 inPos, ref global::UIHotSpot.Hit hit, out global::UICamera cam)
	{
		if (!global::UnityEngine.Screen.lockCursor)
		{
			for (int i = 0; i < global::UICamera.mListCount; i++)
			{
				cam = global::UICamera.mList[(int)global::UICamera.mListSort[i]];
				if (cam.enabled && cam.gameObject.activeInHierarchy)
				{
					global::UICamera.currentCamera = cam.cachedCamera;
					global::UnityEngine.Vector3 vector = global::UICamera.currentCamera.ScreenToViewportPoint(inPos);
					if (vector.x >= -1f && vector.x <= 1f && vector.y >= -1f && vector.y <= 1f)
					{
						global::UICamera.RaycastCheckWork raycastCheckWork;
						raycastCheckWork.ray = global::UICamera.currentCamera.ScreenPointToRay(inPos);
						raycastCheckWork.mask = (global::UICamera.currentCamera.cullingMask & cam.eventReceiverMask);
						raycastCheckWork.dist = ((cam.rangeDistance <= 0f) ? (global::UICamera.currentCamera.farClipPlane - global::UICamera.currentCamera.nearClipPlane) : cam.rangeDistance);
						if (!cam.onlyHotSpots)
						{
							bool flag = global::UnityEngine.Physics.Raycast(raycastCheckWork.ray, ref raycastCheckWork.hit, raycastCheckWork.dist, raycastCheckWork.mask) && raycastCheckWork.Check();
							if (flag)
							{
								global::UIHotSpot.Hit hit2;
								if (global::UIHotSpot.Raycast(raycastCheckWork.ray, out hit2, raycastCheckWork.dist) && hit2.distance <= raycastCheckWork.hit.distance)
								{
									hit = hit2;
								}
								else
								{
									global::UIHotSpot.ConvertRaycastHit(ref raycastCheckWork.ray, ref raycastCheckWork.hit, out hit);
								}
								return true;
							}
						}
						if (global::UIHotSpot.Raycast(raycastCheckWork.ray, out hit, raycastCheckWork.dist))
						{
							return true;
						}
					}
				}
			}
		}
		cam = null;
		return false;
	}

	// Token: 0x06004FEB RID: 20459 RVA: 0x001379E8 File Offset: 0x00135BE8
	private static bool Raycast(global::UICamera cam, global::UnityEngine.Vector3 inPos, ref global::UnityEngine.RaycastHit hit)
	{
		if (global::UnityEngine.Screen.lockCursor)
		{
			return false;
		}
		if (!cam.enabled || !cam.gameObject.activeInHierarchy)
		{
			return false;
		}
		if (!cam.cachedCamera.pixelRect.Contains(inPos))
		{
			return false;
		}
		global::UICamera.RaycastCheckWork raycastCheckWork;
		raycastCheckWork.ray = cam.cachedCamera.ScreenPointToRay(inPos);
		raycastCheckWork.mask = (global::UICamera.currentCamera.cullingMask & cam.eventReceiverMask);
		raycastCheckWork.dist = ((cam.rangeDistance <= 0f) ? (global::UICamera.currentCamera.farClipPlane - global::UICamera.currentCamera.nearClipPlane) : cam.rangeDistance);
		bool result = global::UnityEngine.Physics.Raycast(raycastCheckWork.ray, ref raycastCheckWork.hit, raycastCheckWork.dist, raycastCheckWork.mask) && raycastCheckWork.Check();
		hit = raycastCheckWork.hit;
		return result;
	}

	// Token: 0x06004FEC RID: 20460 RVA: 0x00137AE0 File Offset: 0x00135CE0
	public static global::UICamera FindCameraForLayer(int layer)
	{
		return global::UICamera.mList[layer];
	}

	// Token: 0x06004FED RID: 20461 RVA: 0x00137AEC File Offset: 0x00135CEC
	private static int GetDirection(global::UnityEngine.KeyCode up, global::UnityEngine.KeyCode down)
	{
		bool keyDown = global::UnityEngine.Input.GetKeyDown(up);
		bool keyDown2 = global::UnityEngine.Input.GetKeyDown(down);
		if (keyDown == keyDown2)
		{
			return 0;
		}
		if (keyDown)
		{
			return (!global::UnityEngine.Input.GetKey(down)) ? 1 : 0;
		}
		return (!global::UnityEngine.Input.GetKey(up)) ? -1 : 0;
	}

	// Token: 0x06004FEE RID: 20462 RVA: 0x00137B3C File Offset: 0x00135D3C
	private static int GetDirection(global::UnityEngine.KeyCode up0, global::UnityEngine.KeyCode up1, global::UnityEngine.KeyCode down0, global::UnityEngine.KeyCode down1)
	{
		bool flag = global::UnityEngine.Input.GetKeyDown(up0) | global::UnityEngine.Input.GetKeyDown(up1);
		bool flag2 = global::UnityEngine.Input.GetKeyDown(down0) | global::UnityEngine.Input.GetKeyDown(down1);
		if (flag == flag2)
		{
			return 0;
		}
		if (flag)
		{
			return (!global::UnityEngine.Input.GetKey(down0) && !global::UnityEngine.Input.GetKey(down1)) ? 1 : 0;
		}
		return (!global::UnityEngine.Input.GetKey(up0) && !global::UnityEngine.Input.GetKey(up1)) ? -1 : 0;
	}

	// Token: 0x06004FEF RID: 20463 RVA: 0x00137BB0 File Offset: 0x00135DB0
	private static int GetDirection(string axis)
	{
		float realtimeSinceStartup = global::UnityEngine.Time.realtimeSinceStartup;
		if (global::UICamera.mNextEvent < realtimeSinceStartup)
		{
			float axis2 = global::UnityEngine.Input.GetAxis(axis);
			if (axis2 > 0.75f)
			{
				global::UICamera.mNextEvent = realtimeSinceStartup + 0.25f;
				return 1;
			}
			if (axis2 < -0.75f)
			{
				global::UICamera.mNextEvent = realtimeSinceStartup + 0.25f;
				return -1;
			}
		}
		return 0;
	}

	// Token: 0x06004FF0 RID: 20464 RVA: 0x00137C08 File Offset: 0x00135E08
	public static bool IsHighlighted(global::UnityEngine.GameObject go)
	{
		int i = global::UICamera.mHighlighted.Count;
		while (i > 0)
		{
			global::UICamera.Highlighted highlighted = global::UICamera.mHighlighted[--i];
			if (highlighted.go == go)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06004FF1 RID: 20465 RVA: 0x00137C50 File Offset: 0x00135E50
	private static void Highlight(global::UnityEngine.GameObject go, bool highlighted)
	{
		if (go != null)
		{
			int i = global::UICamera.mHighlighted.Count;
			while (i > 0)
			{
				global::UICamera.Highlighted highlighted2 = global::UICamera.mHighlighted[--i];
				if (highlighted2 == null || highlighted2.go == null)
				{
					global::UICamera.mHighlighted.RemoveAt(i);
				}
				else if (highlighted2.go == go)
				{
					if (highlighted)
					{
						highlighted2.counter++;
					}
					else if (--highlighted2.counter < 1)
					{
						global::UICamera.mHighlighted.Remove(highlighted2);
						go.Hover(false);
					}
					return;
				}
			}
			if (highlighted)
			{
				global::UICamera.Highlighted highlighted3 = new global::UICamera.Highlighted();
				highlighted3.go = go;
				highlighted3.counter = 1;
				global::UICamera.mHighlighted.Add(highlighted3);
				go.Hover(true);
			}
		}
	}

	// Token: 0x06004FF2 RID: 20466 RVA: 0x00137D38 File Offset: 0x00135F38
	private void Awake()
	{
		if (global::UnityEngine.Application.platform == 0xB || global::UnityEngine.Application.platform == 8)
		{
			this.useMouse = false;
			this.useTouch = true;
			this.useKeyboard = false;
			this.useController = false;
		}
		else if (global::UnityEngine.Application.platform == 9 || global::UnityEngine.Application.platform == 0xA)
		{
			this.useMouse = false;
			this.useTouch = false;
			this.useKeyboard = false;
			this.useController = true;
		}
		else if (global::UnityEngine.Application.platform == 7 || global::UnityEngine.Application.platform == null)
		{
			this.mIsEditor = true;
		}
		this.AddToList();
		if (this.eventReceiverMask == -1)
		{
			this.eventReceiverMask = base.camera.cullingMask;
		}
		if (this.usesAnyEvents && global::UnityEngine.Application.isPlaying)
		{
			global::UIUnityEvents.CameraCreated(this);
		}
	}

	// Token: 0x06004FF3 RID: 20467 RVA: 0x00137E1C File Offset: 0x0013601C
	private void OnDestroy()
	{
		this.RemoveFromList();
	}

	// Token: 0x06004FF4 RID: 20468 RVA: 0x00137E24 File Offset: 0x00136024
	private void AddToList()
	{
		int layer = base.gameObject.layer;
		if (layer != this.lastBoundLayerIndex)
		{
			bool flag;
			if (this.lastBoundLayerIndex != -1 && global::UICamera.mList[this.lastBoundLayerIndex] == this)
			{
				global::UICamera.mList[this.lastBoundLayerIndex] = null;
				for (int i = 0; i < global::UICamera.mListCount; i++)
				{
					if ((int)global::UICamera.mListSort[i] == this.lastBoundLayerIndex)
					{
						global::UICamera.mListSort[i] = (byte)layer;
					}
				}
				flag = false;
			}
			else
			{
				global::UICamera.mListSort[global::UICamera.mListCount++] = (byte)layer;
				flag = true;
			}
			global::UICamera.mList[layer] = this;
			this.lastBoundLayerIndex = layer;
			if (flag)
			{
				global::System.Array.Sort<byte>(global::UICamera.mListSort, 0, global::UICamera.mListCount, global::UICamera.sorter);
			}
		}
	}

	// Token: 0x06004FF5 RID: 20469 RVA: 0x00137EF4 File Offset: 0x001360F4
	private void RemoveFromList()
	{
		if (this.lastBoundLayerIndex != -1)
		{
			global::UICamera.mList[this.lastBoundLayerIndex] = null;
			int num = 0;
			for (int i = 0; i < global::UICamera.mListCount; i++)
			{
				if ((int)global::UICamera.mListSort[i] != this.lastBoundLayerIndex)
				{
					global::UICamera.mListSort[num++] = global::UICamera.mListSort[i];
				}
			}
			global::UICamera.mListCount = num;
			this.lastBoundLayerIndex = -1;
		}
	}

	// Token: 0x06004FF6 RID: 20470 RVA: 0x00137F64 File Offset: 0x00136164
	private void Update()
	{
		if (!global::UnityEngine.Application.isPlaying || !this.handlesEvents)
		{
			return;
		}
		if (global::UICamera.mSel != null)
		{
			this.ProcessOthers();
		}
		else
		{
			global::UICamera.inputHasFocus = false;
		}
		if (this.useMouse && global::UICamera.mHover != null)
		{
			if ((this.mouseMode & global::UIInputMode.UseInput) == global::UIInputMode.UseInput)
			{
				float axis = global::UnityEngine.Input.GetAxis(this.scrollAxisName);
				if (axis != 0f)
				{
					global::UICamera.mHover.Scroll(axis);
				}
			}
			if (this.mTooltipTime != 0f && this.mTooltipTime < global::UnityEngine.Time.realtimeSinceStartup)
			{
				this.mTooltip = global::UICamera.mHover;
				this.ShowTooltip(true);
			}
		}
	}

	// Token: 0x06004FF7 RID: 20471 RVA: 0x00138028 File Offset: 0x00136228
	private void ProcessOthers()
	{
		int num = 0;
		int num2 = 0;
		if (this.useController)
		{
			if (!string.IsNullOrEmpty(this.verticalAxisName))
			{
				num += global::UICamera.GetDirection(this.verticalAxisName);
			}
			if (!string.IsNullOrEmpty(this.horizontalAxisName))
			{
				num2 += global::UICamera.GetDirection(this.horizontalAxisName);
			}
		}
		if (num != 0)
		{
			global::UICamera.mSel.SendMessage("OnKey", (num <= 0) ? 0x112 : 0x111, 1);
		}
		if (num2 != 0)
		{
			global::UICamera.mSel.SendMessage("OnKey", (num2 <= 0) ? 0x114 : 0x113, 1);
		}
	}

	// Token: 0x06004FF8 RID: 20472 RVA: 0x001380E4 File Offset: 0x001362E4
	internal bool SetKeyboardFocus(global::UIInput input)
	{
		return global::UICamera.mSelInput == input || (!global::UICamera.mSelInput && input && global::UICamera.SetSelectedObject(input.gameObject));
	}

	// Token: 0x06004FF9 RID: 20473 RVA: 0x0013812C File Offset: 0x0013632C
	public void ShowTooltip(bool val)
	{
		this.mTooltipTime = 0f;
		if (this.mTooltip != null)
		{
			this.mTooltip.Tooltip(val);
		}
		if (!val)
		{
			this.mTooltip = null;
		}
	}

	// Token: 0x04002C6E RID: 11374
	private const int kMouseButton0Flag = 1;

	// Token: 0x04002C6F RID: 11375
	private const int kMouseButton1Flag = 2;

	// Token: 0x04002C70 RID: 11376
	private const int kMouseButton2Flag = 4;

	// Token: 0x04002C71 RID: 11377
	private const int kMouseButton3Flag = 8;

	// Token: 0x04002C72 RID: 11378
	private const int kMouseButton4Flag = 0x10;

	// Token: 0x04002C73 RID: 11379
	private const int kMouseButtonCount = 3;

	// Token: 0x04002C74 RID: 11380
	private static global::UIPanel popupPanel;

	// Token: 0x04002C75 RID: 11381
	public static global::UICamera.BackwardsCompatabilitySupport currentTouch;

	// Token: 0x04002C76 RID: 11382
	public static bool SwallowScroll;

	// Token: 0x04002C77 RID: 11383
	public bool useMouse = true;

	// Token: 0x04002C78 RID: 11384
	public bool useTouch = true;

	// Token: 0x04002C79 RID: 11385
	public bool allowMultiTouch = true;

	// Token: 0x04002C7A RID: 11386
	public bool useKeyboard = true;

	// Token: 0x04002C7B RID: 11387
	public bool useController = true;

	// Token: 0x04002C7C RID: 11388
	public global::UnityEngine.LayerMask eventReceiverMask = -1;

	// Token: 0x04002C7D RID: 11389
	public float tooltipDelay = 1f;

	// Token: 0x04002C7E RID: 11390
	public bool stickyTooltip = true;

	// Token: 0x04002C7F RID: 11391
	public float mouseClickThreshold = 10f;

	// Token: 0x04002C80 RID: 11392
	public float touchClickThreshold = 40f;

	// Token: 0x04002C81 RID: 11393
	public float rangeDistance = -1f;

	// Token: 0x04002C82 RID: 11394
	public string scrollAxisName = "Mouse ScrollWheel";

	// Token: 0x04002C83 RID: 11395
	public string verticalAxisName = "Vertical";

	// Token: 0x04002C84 RID: 11396
	public string horizontalAxisName = "Horizontal";

	// Token: 0x04002C85 RID: 11397
	public global::UnityEngine.KeyCode submitKey0 = 0xD;

	// Token: 0x04002C86 RID: 11398
	public global::UnityEngine.KeyCode submitKey1 = 0x14A;

	// Token: 0x04002C87 RID: 11399
	public global::UnityEngine.KeyCode cancelKey0 = 0x1B;

	// Token: 0x04002C88 RID: 11400
	public global::UnityEngine.KeyCode cancelKey1 = 0x14B;

	// Token: 0x04002C89 RID: 11401
	public global::UIInputMode mouseMode = global::UIInputMode.UseEvents;

	// Token: 0x04002C8A RID: 11402
	public global::UIInputMode keyboardMode = global::UIInputMode.UseInputAndEvents;

	// Token: 0x04002C8B RID: 11403
	public global::UIInputMode scrollWheelMode = global::UIInputMode.UseEvents;

	// Token: 0x04002C8C RID: 11404
	public bool onlyHotSpots;

	// Token: 0x04002C8D RID: 11405
	public static global::UnityEngine.Vector2 lastTouchPosition = global::UnityEngine.Vector2.zero;

	// Token: 0x04002C8E RID: 11406
	public static global::UnityEngine.Vector2 lastMousePosition = global::UnityEngine.Vector2.zero;

	// Token: 0x04002C8F RID: 11407
	public static global::UIHotSpot.Hit lastHit;

	// Token: 0x04002C90 RID: 11408
	public static global::UnityEngine.Camera currentCamera = null;

	// Token: 0x04002C91 RID: 11409
	public static int currentTouchID = -1;

	// Token: 0x04002C92 RID: 11410
	public static bool inputHasFocus = false;

	// Token: 0x04002C93 RID: 11411
	public static global::UnityEngine.GameObject fallThrough;

	// Token: 0x04002C94 RID: 11412
	private static global::UICamera[] mList = new global::UICamera[0x20];

	// Token: 0x04002C95 RID: 11413
	private static byte[] mListSort = new byte[0x20];

	// Token: 0x04002C96 RID: 11414
	private static int mListCount = 0;

	// Token: 0x04002C97 RID: 11415
	private static global::System.Collections.Generic.Dictionary<int, global::UICamera> mMouseCamera = new global::System.Collections.Generic.Dictionary<int, global::UICamera>();

	// Token: 0x04002C98 RID: 11416
	private static global::System.Collections.Generic.Dictionary<global::UnityEngine.KeyCode, global::UICamera> mKeyCamera = new global::System.Collections.Generic.Dictionary<global::UnityEngine.KeyCode, global::UICamera>();

	// Token: 0x04002C99 RID: 11417
	private static global::System.Collections.Generic.List<global::UICamera.Highlighted> mHighlighted = new global::System.Collections.Generic.List<global::UICamera.Highlighted>();

	// Token: 0x04002C9A RID: 11418
	private static global::UnityEngine.GameObject mSel = null;

	// Token: 0x04002C9B RID: 11419
	private static global::UIInput mSelInput = null;

	// Token: 0x04002C9C RID: 11420
	private static global::UIInput mPressInput = null;

	// Token: 0x04002C9D RID: 11421
	private static global::UnityEngine.GameObject mHover;

	// Token: 0x04002C9E RID: 11422
	private static float mNextEvent = 0f;

	// Token: 0x04002C9F RID: 11423
	private global::UnityEngine.GameObject mTooltip;

	// Token: 0x04002CA0 RID: 11424
	private global::UnityEngine.Camera mCam;

	// Token: 0x04002CA1 RID: 11425
	private global::UnityEngine.LayerMask mLayerMask;

	// Token: 0x04002CA2 RID: 11426
	private float mTooltipTime;

	// Token: 0x04002CA3 RID: 11427
	private bool mIsEditor;

	// Token: 0x04002CA4 RID: 11428
	private int lastBoundLayerIndex = -1;

	// Token: 0x04002CA5 RID: 11429
	private static bool inSelectionCallback;

	// Token: 0x04002CA6 RID: 11430
	private static readonly global::UICamera.CamSorter sorter = new global::UICamera.CamSorter();

	// Token: 0x02000925 RID: 2341
	public static class Mouse
	{
		// Token: 0x02000926 RID: 2342
		public static class Button
		{
			// Token: 0x06004FFA RID: 20474 RVA: 0x00138164 File Offset: 0x00136364
			// Note: this type is marked as 'beforefieldinit'.
			static Button()
			{
			}

			// Token: 0x17000EC2 RID: 3778
			// (get) Token: 0x06004FFB RID: 20475 RVA: 0x00138174 File Offset: 0x00136374
			internal static global::UICamera.Mouse.Button.Flags NewlyPressed
			{
				get
				{
					return global::UICamera.Mouse.Button.pressed;
				}
			}

			// Token: 0x17000EC3 RID: 3779
			// (get) Token: 0x06004FFC RID: 20476 RVA: 0x0013817C File Offset: 0x0013637C
			internal static global::UICamera.Mouse.Button.Flags NewlyReleased
			{
				get
				{
					return global::UICamera.Mouse.Button.released;
				}
			}

			// Token: 0x17000EC4 RID: 3780
			// (get) Token: 0x06004FFD RID: 20477 RVA: 0x00138184 File Offset: 0x00136384
			internal static global::UICamera.Mouse.Button.Flags Held
			{
				get
				{
					return global::UICamera.Mouse.Button.held;
				}
			}

			// Token: 0x17000EC5 RID: 3781
			// (get) Token: 0x06004FFE RID: 20478 RVA: 0x0013818C File Offset: 0x0013638C
			internal static bool AnyNewlyPressed
			{
				get
				{
					return global::UICamera.Mouse.Button.pressed != (global::UICamera.Mouse.Button.Flags)0;
				}
			}

			// Token: 0x17000EC6 RID: 3782
			// (get) Token: 0x06004FFF RID: 20479 RVA: 0x0013819C File Offset: 0x0013639C
			internal static bool AnyNewlyReleased
			{
				get
				{
					return global::UICamera.Mouse.Button.released != (global::UICamera.Mouse.Button.Flags)0;
				}
			}

			// Token: 0x17000EC7 RID: 3783
			// (get) Token: 0x06005000 RID: 20480 RVA: 0x001381AC File Offset: 0x001363AC
			internal static bool AnyNewlyPressedOrReleased
			{
				get
				{
					return (global::UICamera.Mouse.Button.pressed | global::UICamera.Mouse.Button.released) != (global::UICamera.Mouse.Button.Flags)0;
				}
			}

			// Token: 0x17000EC8 RID: 3784
			// (get) Token: 0x06005001 RID: 20481 RVA: 0x001381C0 File Offset: 0x001363C0
			internal static bool AnyNewlyPressedThatCancelTooltips
			{
				get
				{
					return (global::UICamera.Mouse.Button.pressed & (global::UICamera.Mouse.Button.Flags.Left | global::UICamera.Mouse.Button.Flags.Right | global::UICamera.Mouse.Button.Flags.Middle)) != (global::UICamera.Mouse.Button.Flags)0;
				}
			}

			// Token: 0x06005002 RID: 20482 RVA: 0x001381D0 File Offset: 0x001363D0
			internal static bool IsNewlyPressed(global::UICamera.Mouse.Button.Flags flag)
			{
				return (global::UICamera.Mouse.Button.pressed & flag) == flag;
			}

			// Token: 0x06005003 RID: 20483 RVA: 0x001381DC File Offset: 0x001363DC
			internal static bool IsNewlyReleased(global::UICamera.Mouse.Button.Flags flag)
			{
				return (global::UICamera.Mouse.Button.released & flag) == flag;
			}

			// Token: 0x17000EC9 RID: 3785
			// (get) Token: 0x06005004 RID: 20484 RVA: 0x001381E8 File Offset: 0x001363E8
			public static bool AllowDrag
			{
				get
				{
					return global::UICamera.Mouse.Button.held != (global::UICamera.Mouse.Button.Flags)0;
				}
			}

			// Token: 0x17000ECA RID: 3786
			// (get) Token: 0x06005005 RID: 20485 RVA: 0x001381F8 File Offset: 0x001363F8
			public static bool AllowMove
			{
				get
				{
					return (global::UICamera.Mouse.Button.held | global::UICamera.Mouse.Button.released | global::UICamera.Mouse.Button.pressed) == (global::UICamera.Mouse.Button.Flags)0;
				}
			}

			// Token: 0x06005006 RID: 20486 RVA: 0x00138210 File Offset: 0x00136410
			public static global::UICamera.Mouse.Button.Flags Index(int index)
			{
				if (index < 0 || index >= 3)
				{
					throw new global::System.ArgumentOutOfRangeException("index");
				}
				return (global::UICamera.Mouse.Button.Flags)(1 << index);
			}

			// Token: 0x04002CA7 RID: 11431
			private const global::UICamera.Mouse.Button.Flags kCancelsTooltips = global::UICamera.Mouse.Button.Flags.Left | global::UICamera.Mouse.Button.Flags.Right | global::UICamera.Mouse.Button.Flags.Middle;

			// Token: 0x04002CA8 RID: 11432
			public const global::UICamera.Mouse.Button.Flags Left = global::UICamera.Mouse.Button.Flags.Left;

			// Token: 0x04002CA9 RID: 11433
			public const global::UICamera.Mouse.Button.Flags Right = global::UICamera.Mouse.Button.Flags.Right;

			// Token: 0x04002CAA RID: 11434
			public const global::UICamera.Mouse.Button.Flags Middle = global::UICamera.Mouse.Button.Flags.Middle;

			// Token: 0x04002CAB RID: 11435
			public const global::UICamera.Mouse.Button.Flags Mouse0 = global::UICamera.Mouse.Button.Flags.Left;

			// Token: 0x04002CAC RID: 11436
			public const global::UICamera.Mouse.Button.Flags Mouse1 = global::UICamera.Mouse.Button.Flags.Right;

			// Token: 0x04002CAD RID: 11437
			public const global::UICamera.Mouse.Button.Flags Mouse2 = global::UICamera.Mouse.Button.Flags.Middle;

			// Token: 0x04002CAE RID: 11438
			public const global::UICamera.Mouse.Button.Flags None = (global::UICamera.Mouse.Button.Flags)0;

			// Token: 0x04002CAF RID: 11439
			public const global::UICamera.Mouse.Button.Flags All = global::UICamera.Mouse.Button.Flags.Left | global::UICamera.Mouse.Button.Flags.Right | global::UICamera.Mouse.Button.Flags.Middle;

			// Token: 0x04002CB0 RID: 11440
			public const int Count = 3;

			// Token: 0x04002CB1 RID: 11441
			private static global::UICamera.Mouse.Button.Flags pressed;

			// Token: 0x04002CB2 RID: 11442
			private static global::UICamera.Mouse.Button.Flags released;

			// Token: 0x04002CB3 RID: 11443
			private static global::UICamera.Mouse.Button.Flags held;

			// Token: 0x04002CB4 RID: 11444
			private static int indexPressed = -1;

			// Token: 0x04002CB5 RID: 11445
			private static int indexReleased = -1;

			// Token: 0x02000927 RID: 2343
			public struct ButtonPressEventHandler : global::System.IDisposable
			{
				// Token: 0x06005007 RID: 20487 RVA: 0x00138234 File Offset: 0x00136434
				public ButtonPressEventHandler(global::NGUIHack.Event @event)
				{
					this.@event = @event;
					global::UICamera.Mouse.Button.pressed = global::UICamera.Mouse.Button.Index(@event.button);
					global::UICamera.Mouse.Button.indexPressed = @event.button;
				}

				// Token: 0x06005008 RID: 20488 RVA: 0x00138264 File Offset: 0x00136464
				public void Dispose()
				{
					if (global::UICamera.Mouse.Button.indexPressed != -1)
					{
						if (this.@event.type == 0xC)
						{
							global::UICamera.Mouse.Button.held |= global::UICamera.Mouse.Button.pressed;
						}
						global::UICamera.Mouse.Button.indexPressed = -1;
						global::UICamera.Mouse.Button.pressed = (global::UICamera.Mouse.Button.Flags)0;
					}
				}

				// Token: 0x04002CB6 RID: 11446
				private global::NGUIHack.Event @event;
			}

			// Token: 0x02000928 RID: 2344
			public struct ButtonReleaseEventHandler : global::System.IDisposable
			{
				// Token: 0x06005009 RID: 20489 RVA: 0x001382A0 File Offset: 0x001364A0
				public ButtonReleaseEventHandler(global::NGUIHack.Event @event)
				{
					this.@event = @event;
					global::UICamera.Mouse.Button.released = global::UICamera.Mouse.Button.Index(@event.button);
					global::UICamera.Mouse.Button.indexReleased = @event.button;
				}

				// Token: 0x0600500A RID: 20490 RVA: 0x001382D0 File Offset: 0x001364D0
				public void Dispose()
				{
					if (global::UICamera.Mouse.Button.indexReleased != -1)
					{
						if (this.@event.type == 0xC)
						{
							global::UICamera.Mouse.Button.held &= ~global::UICamera.Mouse.Button.released;
						}
						global::UICamera.Mouse.Button.indexReleased = -1;
						global::UICamera.Mouse.Button.released = (global::UICamera.Mouse.Button.Flags)0;
					}
				}

				// Token: 0x04002CB7 RID: 11447
				private global::NGUIHack.Event @event;
			}

			// Token: 0x02000929 RID: 2345
			[global::System.Flags]
			public enum Flags
			{
				// Token: 0x04002CB9 RID: 11449
				Left = 1,
				// Token: 0x04002CBA RID: 11450
				Right = 2,
				// Token: 0x04002CBB RID: 11451
				Middle = 4
			}

			// Token: 0x0200092A RID: 2346
			public struct Pair<T>
			{
				// Token: 0x0600500B RID: 20491 RVA: 0x00138318 File Offset: 0x00136518
				public Pair(global::UICamera.Mouse.Button.Flags Button, T Value)
				{
					this.Button = Button;
					this.Value = Value;
				}

				// Token: 0x0600500C RID: 20492 RVA: 0x00138328 File Offset: 0x00136528
				public Pair(global::UICamera.Mouse.Button.Flags Button, ref T Value)
				{
					this.Button = Button;
					this.Value = Value;
				}

				// Token: 0x0600500D RID: 20493 RVA: 0x00138340 File Offset: 0x00136540
				public Pair(global::UICamera.Mouse.Button.Flags Button)
				{
					this = new global::UICamera.Mouse.Button.Pair<T>(Button, default(T));
				}

				// Token: 0x04002CBC RID: 11452
				public readonly global::UICamera.Mouse.Button.Flags Button;

				// Token: 0x04002CBD RID: 11453
				public readonly T Value;
			}

			// Token: 0x0200092B RID: 2347
			public struct ValCollection<T> : global::System.Collections.IEnumerable, global::System.Collections.Generic.IEnumerable<global::UICamera.Mouse.Button.Pair<T>>
			{
				// Token: 0x0600500E RID: 20494 RVA: 0x00138360 File Offset: 0x00136560
				global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
				{
					return this.GetEnumerator();
				}

				// Token: 0x17000ECB RID: 3787
				public T this[global::UICamera.Mouse.Button.Flags button]
				{
					get
					{
						switch (button)
						{
						case global::UICamera.Mouse.Button.Flags.Left:
							return this.LeftValue;
						case global::UICamera.Mouse.Button.Flags.Right:
							return this.RightValue;
						case global::UICamera.Mouse.Button.Flags.Middle:
							return this.MiddleValue;
						}
						throw new global::System.ArgumentOutOfRangeException("button", "button should not be None or a Combination of multiple buttons");
					}
					set
					{
						switch (button)
						{
						case global::UICamera.Mouse.Button.Flags.Left:
							this.LeftValue = value;
							return;
						case global::UICamera.Mouse.Button.Flags.Right:
							this.RightValue = value;
							return;
						case global::UICamera.Mouse.Button.Flags.Middle:
							this.MiddleValue = value;
							return;
						}
						throw new global::System.ArgumentOutOfRangeException("button", "button should not be None or a Combination of multiple buttons");
					}
				}

				// Token: 0x17000ECC RID: 3788
				public T this[int i]
				{
					get
					{
						return this[global::UICamera.Mouse.Button.Flags.Left];
					}
					set
					{
						this[global::UICamera.Mouse.Button.Flags.Left] = value;
					}
				}

				// Token: 0x17000ECD RID: 3789
				public global::System.Collections.Generic.IEnumerable<global::UICamera.Mouse.Button.Pair<T>> this[global::UICamera.Mouse.Button.PressState state]
				{
					get
					{
						foreach (global::UICamera.Mouse.Button.Flags flag in state)
						{
							yield return new global::UICamera.Mouse.Button.Pair<T>(flag, this[flag]);
						}
						yield break;
					}
				}

				// Token: 0x06005014 RID: 20500 RVA: 0x00138468 File Offset: 0x00136668
				public global::System.Collections.Generic.IEnumerator<global::UICamera.Mouse.Button.Pair<T>> GetEnumerator()
				{
					yield return new global::UICamera.Mouse.Button.Pair<T>(global::UICamera.Mouse.Button.Flags.Left, this.LeftValue);
					yield return new global::UICamera.Mouse.Button.Pair<T>(global::UICamera.Mouse.Button.Flags.Right, this.RightValue);
					yield return new global::UICamera.Mouse.Button.Pair<T>(global::UICamera.Mouse.Button.Flags.Middle, this.MiddleValue);
					yield break;
				}

				// Token: 0x04002CBE RID: 11454
				public T LeftValue;

				// Token: 0x04002CBF RID: 11455
				public T RightValue;

				// Token: 0x04002CC0 RID: 11456
				public T MiddleValue;

				// Token: 0x0200092C RID: 2348
				[global::System.Runtime.CompilerServices.CompilerGenerated]
				private sealed class <>c__Iterator5A : global::System.IDisposable, global::System.Collections.IEnumerator, global::System.Collections.IEnumerable, global::System.Collections.Generic.IEnumerable<global::UICamera.Mouse.Button.Pair<!0>>, global::System.Collections.Generic.IEnumerator<global::UICamera.Mouse.Button.Pair<!0>>
				{
					// Token: 0x06005015 RID: 20501 RVA: 0x00138488 File Offset: 0x00136688
					public <>c__Iterator5A()
					{
					}

					// Token: 0x17000ECE RID: 3790
					// (get) Token: 0x06005016 RID: 20502 RVA: 0x00138490 File Offset: 0x00136690
					global::UICamera.Mouse.Button.Pair<T> global::System.Collections.Generic.IEnumerator<global::UICamera.Mouse.Button.Pair<!0>>.Current
					{
						[global::System.Diagnostics.DebuggerHidden]
						get
						{
							return this.$current;
						}
					}

					// Token: 0x17000ECF RID: 3791
					// (get) Token: 0x06005017 RID: 20503 RVA: 0x00138498 File Offset: 0x00136698
					object global::System.Collections.IEnumerator.Current
					{
						[global::System.Diagnostics.DebuggerHidden]
						get
						{
							return this.$current;
						}
					}

					// Token: 0x06005018 RID: 20504 RVA: 0x001384A8 File Offset: 0x001366A8
					[global::System.Diagnostics.DebuggerHidden]
					global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
					{
						return this.System.Collections.Generic.IEnumerable<UICamera.Mouse.Button.Pair<T>>.GetEnumerator();
					}

					// Token: 0x06005019 RID: 20505 RVA: 0x001384B0 File Offset: 0x001366B0
					[global::System.Diagnostics.DebuggerHidden]
					global::System.Collections.Generic.IEnumerator<global::UICamera.Mouse.Button.Pair<T>> global::System.Collections.Generic.IEnumerable<global::UICamera.Mouse.Button.Pair<!0>>.GetEnumerator()
					{
						if (global::System.Threading.Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
						{
							return this;
						}
						global::UICamera.Mouse.Button.ValCollection<T>.<>c__Iterator5A <>c__Iterator5A = new global::UICamera.Mouse.Button.ValCollection<T>.<>c__Iterator5A();
						<>c__Iterator5A.<>f__this = ref this;
						<>c__Iterator5A.state = state;
						return <>c__Iterator5A;
					}

					// Token: 0x0600501A RID: 20506 RVA: 0x001384F0 File Offset: 0x001366F0
					public bool MoveNext()
					{
						uint num = (uint)this.$PC;
						this.$PC = -1;
						bool flag2 = false;
						switch (num)
						{
						case 0U:
							enumerator = state.GetEnumerator();
							num = 0xFFFFFFFDU;
							break;
						case 1U:
							break;
						default:
							return false;
						}
						try
						{
							switch (num)
							{
							}
							if (enumerator.MoveNext())
							{
								flag = enumerator.Current;
								this.$current = new global::UICamera.Mouse.Button.Pair<T>(flag, base[flag]);
								this.$PC = 1;
								flag2 = true;
								return true;
							}
						}
						finally
						{
							if (!flag2)
							{
								if (enumerator != null)
								{
									((global::System.IDisposable)enumerator).Dispose();
								}
							}
						}
						this.$PC = -1;
						return false;
					}

					// Token: 0x0600501B RID: 20507 RVA: 0x001385DC File Offset: 0x001367DC
					[global::System.Diagnostics.DebuggerHidden]
					public void Dispose()
					{
						uint num = (uint)this.$PC;
						this.$PC = -1;
						switch (num)
						{
						case 1U:
							try
							{
							}
							finally
							{
								if (enumerator != null)
								{
									((global::System.IDisposable)enumerator).Dispose();
								}
							}
							break;
						}
					}

					// Token: 0x0600501C RID: 20508 RVA: 0x00138640 File Offset: 0x00136840
					[global::System.Diagnostics.DebuggerHidden]
					public void Reset()
					{
						throw new global::System.NotSupportedException();
					}

					// Token: 0x04002CC1 RID: 11457
					internal global::UICamera.Mouse.Button.PressState state;

					// Token: 0x04002CC2 RID: 11458
					internal global::UICamera.Mouse.Button.PressState.Enumerator <$s_654>__0;

					// Token: 0x04002CC3 RID: 11459
					internal global::UICamera.Mouse.Button.Flags <flag>__1;

					// Token: 0x04002CC4 RID: 11460
					internal int $PC;

					// Token: 0x04002CC5 RID: 11461
					internal global::UICamera.Mouse.Button.Pair<T> $current;

					// Token: 0x04002CC6 RID: 11462
					internal global::UICamera.Mouse.Button.PressState <$>state;

					// Token: 0x04002CC7 RID: 11463
					internal global::UICamera.Mouse.Button.ValCollection<T> <>f__this;
				}

				// Token: 0x0200092D RID: 2349
				[global::System.Runtime.CompilerServices.CompilerGenerated]
				private sealed class <GetEnumerator>c__Iterator5B : global::System.IDisposable, global::System.Collections.IEnumerator, global::System.Collections.Generic.IEnumerator<global::UICamera.Mouse.Button.Pair<!0>>
				{
					// Token: 0x0600501D RID: 20509 RVA: 0x00138648 File Offset: 0x00136848
					public <GetEnumerator>c__Iterator5B()
					{
					}

					// Token: 0x17000ED0 RID: 3792
					// (get) Token: 0x0600501E RID: 20510 RVA: 0x00138650 File Offset: 0x00136850
					global::UICamera.Mouse.Button.Pair<T> global::System.Collections.Generic.IEnumerator<global::UICamera.Mouse.Button.Pair<!0>>.Current
					{
						[global::System.Diagnostics.DebuggerHidden]
						get
						{
							return this.$current;
						}
					}

					// Token: 0x17000ED1 RID: 3793
					// (get) Token: 0x0600501F RID: 20511 RVA: 0x00138658 File Offset: 0x00136858
					object global::System.Collections.IEnumerator.Current
					{
						[global::System.Diagnostics.DebuggerHidden]
						get
						{
							return this.$current;
						}
					}

					// Token: 0x06005020 RID: 20512 RVA: 0x00138668 File Offset: 0x00136868
					public bool MoveNext()
					{
						uint num = (uint)this.$PC;
						this.$PC = -1;
						switch (num)
						{
						case 0U:
							this.$current = new global::UICamera.Mouse.Button.Pair<T>(global::UICamera.Mouse.Button.Flags.Left, this.LeftValue);
							this.$PC = 1;
							return true;
						case 1U:
							this.$current = new global::UICamera.Mouse.Button.Pair<T>(global::UICamera.Mouse.Button.Flags.Right, this.RightValue);
							this.$PC = 2;
							return true;
						case 2U:
							this.$current = new global::UICamera.Mouse.Button.Pair<T>(global::UICamera.Mouse.Button.Flags.Middle, this.MiddleValue);
							this.$PC = 3;
							return true;
						case 3U:
							this.$PC = -1;
							break;
						}
						return false;
					}

					// Token: 0x06005021 RID: 20513 RVA: 0x00138714 File Offset: 0x00136914
					[global::System.Diagnostics.DebuggerHidden]
					public void Dispose()
					{
						this.$PC = -1;
					}

					// Token: 0x06005022 RID: 20514 RVA: 0x00138720 File Offset: 0x00136920
					[global::System.Diagnostics.DebuggerHidden]
					public void Reset()
					{
						throw new global::System.NotSupportedException();
					}

					// Token: 0x04002CC8 RID: 11464
					internal int $PC;

					// Token: 0x04002CC9 RID: 11465
					internal global::UICamera.Mouse.Button.Pair<T> $current;

					// Token: 0x04002CCA RID: 11466
					internal global::UICamera.Mouse.Button.ValCollection<T> <>f__this;
				}
			}

			// Token: 0x0200092E RID: 2350
			public struct RefCollection<T> : global::System.Collections.IEnumerable, global::System.Collections.Generic.IEnumerable<global::UICamera.Mouse.Button.Pair<!0>>
			{
				// Token: 0x06005023 RID: 20515 RVA: 0x00138728 File Offset: 0x00136928
				global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
				{
					return this.GetEnumerator();
				}

				// Token: 0x17000ED2 RID: 3794
				public T this[global::UICamera.Mouse.Button.Flags button]
				{
					get
					{
						switch (button)
						{
						case global::UICamera.Mouse.Button.Flags.Left:
							return this.LeftValue;
						case global::UICamera.Mouse.Button.Flags.Right:
							return this.RightValue;
						case global::UICamera.Mouse.Button.Flags.Middle:
							return this.MiddleValue;
						}
						throw new global::System.ArgumentOutOfRangeException("button", "button should not be None or a Combination of multiple buttons");
					}
					set
					{
						switch (button)
						{
						case global::UICamera.Mouse.Button.Flags.Left:
							this.LeftValue = value;
							return;
						case global::UICamera.Mouse.Button.Flags.Right:
							this.RightValue = value;
							return;
						case global::UICamera.Mouse.Button.Flags.Middle:
							this.MiddleValue = value;
							return;
						}
						throw new global::System.ArgumentOutOfRangeException("button", "button should not be None or a Combination of multiple buttons");
					}
				}

				// Token: 0x17000ED3 RID: 3795
				public T this[int i]
				{
					get
					{
						return this[global::UICamera.Mouse.Button.Flags.Left];
					}
					set
					{
						this[global::UICamera.Mouse.Button.Flags.Left] = value;
					}
				}

				// Token: 0x17000ED4 RID: 3796
				public global::System.Collections.Generic.IEnumerable<global::UICamera.Mouse.Button.Pair<T>> this[global::UICamera.Mouse.Button.PressState state]
				{
					get
					{
						foreach (global::UICamera.Mouse.Button.Flags flag in state)
						{
							yield return new global::UICamera.Mouse.Button.Pair<T>(flag, this[flag]);
						}
						yield break;
					}
				}

				// Token: 0x06005029 RID: 20521 RVA: 0x00138830 File Offset: 0x00136A30
				public global::System.Collections.Generic.IEnumerator<global::UICamera.Mouse.Button.Pair<T>> GetEnumerator()
				{
					yield return new global::UICamera.Mouse.Button.Pair<T>(global::UICamera.Mouse.Button.Flags.Left, this.LeftValue);
					yield return new global::UICamera.Mouse.Button.Pair<T>(global::UICamera.Mouse.Button.Flags.Right, this.RightValue);
					yield return new global::UICamera.Mouse.Button.Pair<T>(global::UICamera.Mouse.Button.Flags.Middle, this.MiddleValue);
					yield break;
				}

				// Token: 0x04002CCB RID: 11467
				public T LeftValue;

				// Token: 0x04002CCC RID: 11468
				public T RightValue;

				// Token: 0x04002CCD RID: 11469
				public T MiddleValue;

				// Token: 0x0200092F RID: 2351
				[global::System.Runtime.CompilerServices.CompilerGenerated]
				private sealed class <>c__Iterator5C : global::System.IDisposable, global::System.Collections.IEnumerator, global::System.Collections.IEnumerable, global::System.Collections.Generic.IEnumerable<global::UICamera.Mouse.Button.Pair<!0>>, global::System.Collections.Generic.IEnumerator<global::UICamera.Mouse.Button.Pair<!0>>
				{
					// Token: 0x0600502A RID: 20522 RVA: 0x00138850 File Offset: 0x00136A50
					public <>c__Iterator5C()
					{
					}

					// Token: 0x17000ED5 RID: 3797
					// (get) Token: 0x0600502B RID: 20523 RVA: 0x00138858 File Offset: 0x00136A58
					global::UICamera.Mouse.Button.Pair<T> global::System.Collections.Generic.IEnumerator<global::UICamera.Mouse.Button.Pair<!0>>.Current
					{
						[global::System.Diagnostics.DebuggerHidden]
						get
						{
							return this.$current;
						}
					}

					// Token: 0x17000ED6 RID: 3798
					// (get) Token: 0x0600502C RID: 20524 RVA: 0x00138860 File Offset: 0x00136A60
					object global::System.Collections.IEnumerator.Current
					{
						[global::System.Diagnostics.DebuggerHidden]
						get
						{
							return this.$current;
						}
					}

					// Token: 0x0600502D RID: 20525 RVA: 0x00138870 File Offset: 0x00136A70
					[global::System.Diagnostics.DebuggerHidden]
					global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
					{
						return this.System.Collections.Generic.IEnumerable<UICamera.Mouse.Button.Pair<T>>.GetEnumerator();
					}

					// Token: 0x0600502E RID: 20526 RVA: 0x00138878 File Offset: 0x00136A78
					[global::System.Diagnostics.DebuggerHidden]
					global::System.Collections.Generic.IEnumerator<global::UICamera.Mouse.Button.Pair<T>> global::System.Collections.Generic.IEnumerable<global::UICamera.Mouse.Button.Pair<!0>>.GetEnumerator()
					{
						if (global::System.Threading.Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
						{
							return this;
						}
						global::UICamera.Mouse.Button.RefCollection<T>.<>c__Iterator5C <>c__Iterator5C = new global::UICamera.Mouse.Button.RefCollection<T>.<>c__Iterator5C();
						<>c__Iterator5C.<>f__this = ref this;
						<>c__Iterator5C.state = state;
						return <>c__Iterator5C;
					}

					// Token: 0x0600502F RID: 20527 RVA: 0x001388B8 File Offset: 0x00136AB8
					public bool MoveNext()
					{
						uint num = (uint)this.$PC;
						this.$PC = -1;
						bool flag2 = false;
						switch (num)
						{
						case 0U:
							enumerator = state.GetEnumerator();
							num = 0xFFFFFFFDU;
							break;
						case 1U:
							break;
						default:
							return false;
						}
						try
						{
							switch (num)
							{
							}
							if (enumerator.MoveNext())
							{
								flag = enumerator.Current;
								this.$current = new global::UICamera.Mouse.Button.Pair<T>(flag, base[flag]);
								this.$PC = 1;
								flag2 = true;
								return true;
							}
						}
						finally
						{
							if (!flag2)
							{
								if (enumerator != null)
								{
									((global::System.IDisposable)enumerator).Dispose();
								}
							}
						}
						this.$PC = -1;
						return false;
					}

					// Token: 0x06005030 RID: 20528 RVA: 0x001389A4 File Offset: 0x00136BA4
					[global::System.Diagnostics.DebuggerHidden]
					public void Dispose()
					{
						uint num = (uint)this.$PC;
						this.$PC = -1;
						switch (num)
						{
						case 1U:
							try
							{
							}
							finally
							{
								if (enumerator != null)
								{
									((global::System.IDisposable)enumerator).Dispose();
								}
							}
							break;
						}
					}

					// Token: 0x06005031 RID: 20529 RVA: 0x00138A08 File Offset: 0x00136C08
					[global::System.Diagnostics.DebuggerHidden]
					public void Reset()
					{
						throw new global::System.NotSupportedException();
					}

					// Token: 0x04002CCE RID: 11470
					internal global::UICamera.Mouse.Button.PressState state;

					// Token: 0x04002CCF RID: 11471
					internal global::UICamera.Mouse.Button.PressState.Enumerator <$s_655>__0;

					// Token: 0x04002CD0 RID: 11472
					internal global::UICamera.Mouse.Button.Flags <flag>__1;

					// Token: 0x04002CD1 RID: 11473
					internal int $PC;

					// Token: 0x04002CD2 RID: 11474
					internal global::UICamera.Mouse.Button.Pair<T> $current;

					// Token: 0x04002CD3 RID: 11475
					internal global::UICamera.Mouse.Button.PressState <$>state;

					// Token: 0x04002CD4 RID: 11476
					internal global::UICamera.Mouse.Button.RefCollection<T> <>f__this;
				}

				// Token: 0x02000930 RID: 2352
				[global::System.Runtime.CompilerServices.CompilerGenerated]
				private sealed class <GetEnumerator>c__Iterator5D : global::System.IDisposable, global::System.Collections.IEnumerator, global::System.Collections.Generic.IEnumerator<global::UICamera.Mouse.Button.Pair<!0>>
				{
					// Token: 0x06005032 RID: 20530 RVA: 0x00138A10 File Offset: 0x00136C10
					public <GetEnumerator>c__Iterator5D()
					{
					}

					// Token: 0x17000ED7 RID: 3799
					// (get) Token: 0x06005033 RID: 20531 RVA: 0x00138A18 File Offset: 0x00136C18
					global::UICamera.Mouse.Button.Pair<T> global::System.Collections.Generic.IEnumerator<global::UICamera.Mouse.Button.Pair<!0>>.Current
					{
						[global::System.Diagnostics.DebuggerHidden]
						get
						{
							return this.$current;
						}
					}

					// Token: 0x17000ED8 RID: 3800
					// (get) Token: 0x06005034 RID: 20532 RVA: 0x00138A20 File Offset: 0x00136C20
					object global::System.Collections.IEnumerator.Current
					{
						[global::System.Diagnostics.DebuggerHidden]
						get
						{
							return this.$current;
						}
					}

					// Token: 0x06005035 RID: 20533 RVA: 0x00138A30 File Offset: 0x00136C30
					public bool MoveNext()
					{
						uint num = (uint)this.$PC;
						this.$PC = -1;
						switch (num)
						{
						case 0U:
							this.$current = new global::UICamera.Mouse.Button.Pair<T>(global::UICamera.Mouse.Button.Flags.Left, this.LeftValue);
							this.$PC = 1;
							return true;
						case 1U:
							this.$current = new global::UICamera.Mouse.Button.Pair<T>(global::UICamera.Mouse.Button.Flags.Right, this.RightValue);
							this.$PC = 2;
							return true;
						case 2U:
							this.$current = new global::UICamera.Mouse.Button.Pair<T>(global::UICamera.Mouse.Button.Flags.Middle, this.MiddleValue);
							this.$PC = 3;
							return true;
						case 3U:
							this.$PC = -1;
							break;
						}
						return false;
					}

					// Token: 0x06005036 RID: 20534 RVA: 0x00138ADC File Offset: 0x00136CDC
					[global::System.Diagnostics.DebuggerHidden]
					public void Dispose()
					{
						this.$PC = -1;
					}

					// Token: 0x06005037 RID: 20535 RVA: 0x00138AE8 File Offset: 0x00136CE8
					[global::System.Diagnostics.DebuggerHidden]
					public void Reset()
					{
						throw new global::System.NotSupportedException();
					}

					// Token: 0x04002CD5 RID: 11477
					internal int $PC;

					// Token: 0x04002CD6 RID: 11478
					internal global::UICamera.Mouse.Button.Pair<T> $current;

					// Token: 0x04002CD7 RID: 11479
					internal global::UICamera.Mouse.Button.RefCollection<T> <>f__this;
				}
			}

			// Token: 0x02000931 RID: 2353
			public struct PressState : global::System.Collections.IEnumerable, global::System.Collections.Generic.IEnumerable<global::UICamera.Mouse.Button.Flags>
			{
				// Token: 0x06005038 RID: 20536 RVA: 0x00138AF0 File Offset: 0x00136CF0
				global::System.Collections.Generic.IEnumerator<global::UICamera.Mouse.Button.Flags> global::System.Collections.Generic.IEnumerable<global::UICamera.Mouse.Button.Flags>.GetEnumerator()
				{
					return this.GetEnumerator();
				}

				// Token: 0x06005039 RID: 20537 RVA: 0x00138AF8 File Offset: 0x00136CF8
				global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
				{
					return this.GetEnumerator();
				}

				// Token: 0x17000ED9 RID: 3801
				// (get) Token: 0x0600503A RID: 20538 RVA: 0x00138B00 File Offset: 0x00136D00
				// (set) Token: 0x0600503B RID: 20539 RVA: 0x00138B10 File Offset: 0x00136D10
				public bool LeftPressed
				{
					get
					{
						return (this.Pressed & global::UICamera.Mouse.Button.Flags.Left) == global::UICamera.Mouse.Button.Flags.Left;
					}
					set
					{
						if (value)
						{
							this.Pressed |= global::UICamera.Mouse.Button.Flags.Left;
						}
						else
						{
							this.Pressed &= ~global::UICamera.Mouse.Button.Flags.Left;
						}
					}
				}

				// Token: 0x17000EDA RID: 3802
				// (get) Token: 0x0600503C RID: 20540 RVA: 0x00138B48 File Offset: 0x00136D48
				// (set) Token: 0x0600503D RID: 20541 RVA: 0x00138B58 File Offset: 0x00136D58
				public bool RightPressed
				{
					get
					{
						return (this.Pressed & global::UICamera.Mouse.Button.Flags.Right) == global::UICamera.Mouse.Button.Flags.Right;
					}
					set
					{
						if (value)
						{
							this.Pressed |= global::UICamera.Mouse.Button.Flags.Right;
						}
						else
						{
							this.Pressed &= ~global::UICamera.Mouse.Button.Flags.Right;
						}
					}
				}

				// Token: 0x17000EDB RID: 3803
				// (get) Token: 0x0600503E RID: 20542 RVA: 0x00138B90 File Offset: 0x00136D90
				// (set) Token: 0x0600503F RID: 20543 RVA: 0x00138BA0 File Offset: 0x00136DA0
				public bool MiddlePressed
				{
					get
					{
						return (this.Pressed & global::UICamera.Mouse.Button.Flags.Middle) == global::UICamera.Mouse.Button.Flags.Middle;
					}
					set
					{
						if (value)
						{
							this.Pressed |= global::UICamera.Mouse.Button.Flags.Middle;
						}
						else
						{
							this.Pressed &= ~global::UICamera.Mouse.Button.Flags.Middle;
						}
					}
				}

				// Token: 0x17000EDC RID: 3804
				// (get) Token: 0x06005040 RID: 20544 RVA: 0x00138BD8 File Offset: 0x00136DD8
				// (set) Token: 0x06005041 RID: 20545 RVA: 0x00138BE4 File Offset: 0x00136DE4
				public global::UICamera.Mouse.Button.Flags Released
				{
					get
					{
						return ~this.Pressed & (global::UICamera.Mouse.Button.Flags.Left | global::UICamera.Mouse.Button.Flags.Right | global::UICamera.Mouse.Button.Flags.Middle);
					}
					set
					{
						this.Pressed = (~value & (global::UICamera.Mouse.Button.Flags.Left | global::UICamera.Mouse.Button.Flags.Right | global::UICamera.Mouse.Button.Flags.Middle));
					}
				}

				// Token: 0x17000EDD RID: 3805
				// (get) Token: 0x06005042 RID: 20546 RVA: 0x00138BF0 File Offset: 0x00136DF0
				public bool AnyPressed
				{
					get
					{
						return (this.Pressed & (global::UICamera.Mouse.Button.Flags.Left | global::UICamera.Mouse.Button.Flags.Right | global::UICamera.Mouse.Button.Flags.Middle)) != (global::UICamera.Mouse.Button.Flags)0;
					}
				}

				// Token: 0x17000EDE RID: 3806
				// (get) Token: 0x06005043 RID: 20547 RVA: 0x00138C00 File Offset: 0x00136E00
				public bool AllPressed
				{
					get
					{
						return (this.Pressed & (global::UICamera.Mouse.Button.Flags.Left | global::UICamera.Mouse.Button.Flags.Right | global::UICamera.Mouse.Button.Flags.Middle)) == (global::UICamera.Mouse.Button.Flags.Left | global::UICamera.Mouse.Button.Flags.Right | global::UICamera.Mouse.Button.Flags.Middle);
					}
				}

				// Token: 0x17000EDF RID: 3807
				// (get) Token: 0x06005044 RID: 20548 RVA: 0x00138C10 File Offset: 0x00136E10
				public bool NonePressed
				{
					get
					{
						return (this.Pressed & (global::UICamera.Mouse.Button.Flags.Left | global::UICamera.Mouse.Button.Flags.Right | global::UICamera.Mouse.Button.Flags.Middle)) == (global::UICamera.Mouse.Button.Flags)0;
					}
				}

				// Token: 0x17000EE0 RID: 3808
				// (get) Token: 0x06005045 RID: 20549 RVA: 0x00138C20 File Offset: 0x00136E20
				public int PressedCount
				{
					get
					{
						int num = 0;
						uint num2 = (uint)(this.Pressed & (global::UICamera.Mouse.Button.Flags.Left | global::UICamera.Mouse.Button.Flags.Right | global::UICamera.Mouse.Button.Flags.Middle));
						while (num2 != 0U)
						{
							num2 &= num2 - 1U;
							num++;
						}
						return num;
					}
				}

				// Token: 0x17000EE1 RID: 3809
				// (get) Token: 0x06005046 RID: 20550 RVA: 0x00138C50 File Offset: 0x00136E50
				// (set) Token: 0x06005047 RID: 20551 RVA: 0x00138C5C File Offset: 0x00136E5C
				public bool LeftReleased
				{
					get
					{
						return !this.LeftPressed;
					}
					set
					{
						this.LeftPressed = !value;
					}
				}

				// Token: 0x17000EE2 RID: 3810
				// (get) Token: 0x06005048 RID: 20552 RVA: 0x00138C68 File Offset: 0x00136E68
				// (set) Token: 0x06005049 RID: 20553 RVA: 0x00138C74 File Offset: 0x00136E74
				public bool RightReleased
				{
					get
					{
						return !this.RightPressed;
					}
					set
					{
						this.RightPressed = !value;
					}
				}

				// Token: 0x17000EE3 RID: 3811
				// (get) Token: 0x0600504A RID: 20554 RVA: 0x00138C80 File Offset: 0x00136E80
				// (set) Token: 0x0600504B RID: 20555 RVA: 0x00138C8C File Offset: 0x00136E8C
				public bool MiddleReleased
				{
					get
					{
						return !this.MiddlePressed;
					}
					set
					{
						this.MiddlePressed = !value;
					}
				}

				// Token: 0x17000EE4 RID: 3812
				// (get) Token: 0x0600504C RID: 20556 RVA: 0x00138C98 File Offset: 0x00136E98
				public bool AnyReleased
				{
					get
					{
						return !this.AllPressed;
					}
				}

				// Token: 0x17000EE5 RID: 3813
				// (get) Token: 0x0600504D RID: 20557 RVA: 0x00138CA4 File Offset: 0x00136EA4
				public bool AllReleased
				{
					get
					{
						return !this.AnyPressed;
					}
				}

				// Token: 0x17000EE6 RID: 3814
				// (get) Token: 0x0600504E RID: 20558 RVA: 0x00138CB0 File Offset: 0x00136EB0
				public bool NoneReleased
				{
					get
					{
						return !this.AllPressed;
					}
				}

				// Token: 0x0600504F RID: 20559 RVA: 0x00138CBC File Offset: 0x00136EBC
				public void Clear()
				{
					this.Pressed &= ~(global::UICamera.Mouse.Button.Flags.Left | global::UICamera.Mouse.Button.Flags.Right | global::UICamera.Mouse.Button.Flags.Middle);
				}

				// Token: 0x17000EE7 RID: 3815
				public bool this[int index]
				{
					get
					{
						global::UICamera.Mouse.Button.Flags flags = global::UICamera.Mouse.Button.Index(index);
						return (this.Pressed & flags) == flags;
					}
					set
					{
						global::UICamera.Mouse.Button.Flags flags = global::UICamera.Mouse.Button.Index(index);
						if (value)
						{
							this.Pressed |= flags;
						}
						else
						{
							this.Pressed &= ~flags;
						}
					}
				}

				// Token: 0x06005052 RID: 20562 RVA: 0x00138D2C File Offset: 0x00136F2C
				public global::UICamera.Mouse.Button.PressState.Enumerator GetEnumerator()
				{
					return global::UICamera.Mouse.Button.PressState.Enumerator.Enumerate(this.Pressed);
				}

				// Token: 0x06005053 RID: 20563 RVA: 0x00138D3C File Offset: 0x00136F3C
				public static implicit operator global::UICamera.Mouse.Button.Flags(global::UICamera.Mouse.Button.PressState state)
				{
					return state.Pressed & (global::UICamera.Mouse.Button.Flags.Left | global::UICamera.Mouse.Button.Flags.Right | global::UICamera.Mouse.Button.Flags.Middle);
				}

				// Token: 0x06005054 RID: 20564 RVA: 0x00138D48 File Offset: 0x00136F48
				public static implicit operator global::UICamera.Mouse.Button.PressState(global::UICamera.Mouse.Button.Flags buttons)
				{
					global::UICamera.Mouse.Button.PressState result;
					result.Pressed = (buttons & (global::UICamera.Mouse.Button.Flags.Left | global::UICamera.Mouse.Button.Flags.Right | global::UICamera.Mouse.Button.Flags.Middle));
					return result;
				}

				// Token: 0x06005055 RID: 20565 RVA: 0x00138D60 File Offset: 0x00136F60
				public static bool operator true(global::UICamera.Mouse.Button.PressState state)
				{
					return state.AnyPressed;
				}

				// Token: 0x06005056 RID: 20566 RVA: 0x00138D6C File Offset: 0x00136F6C
				public static bool operator false(global::UICamera.Mouse.Button.PressState state)
				{
					return state.NonePressed;
				}

				// Token: 0x06005057 RID: 20567 RVA: 0x00138D78 File Offset: 0x00136F78
				public static global::UICamera.Mouse.Button.PressState operator -(global::UICamera.Mouse.Button.PressState s)
				{
					global::UICamera.Mouse.Button.PressState result;
					result.Pressed = s.Released;
					return result;
				}

				// Token: 0x06005058 RID: 20568 RVA: 0x00138D94 File Offset: 0x00136F94
				public static global::UICamera.Mouse.Button.PressState operator +(global::UICamera.Mouse.Button.PressState l, global::UICamera.Mouse.Button.PressState r)
				{
					global::UICamera.Mouse.Button.PressState result;
					result.Pressed = (l.Pressed | r.Pressed);
					return result;
				}

				// Token: 0x06005059 RID: 20569 RVA: 0x00138DB8 File Offset: 0x00136FB8
				public static global::UICamera.Mouse.Button.PressState operator +(global::UICamera.Mouse.Button.PressState l, global::UICamera.Mouse.Button.Flags r)
				{
					global::UICamera.Mouse.Button.PressState result;
					result.Pressed = (l.Pressed | r);
					return result;
				}

				// Token: 0x0600505A RID: 20570 RVA: 0x00138DD8 File Offset: 0x00136FD8
				public static global::UICamera.Mouse.Button.PressState operator +(global::UICamera.Mouse.Button.Flags l, global::UICamera.Mouse.Button.PressState r)
				{
					global::UICamera.Mouse.Button.PressState result;
					result.Pressed = (l | r.Pressed);
					return result;
				}

				// Token: 0x0600505B RID: 20571 RVA: 0x00138DF8 File Offset: 0x00136FF8
				public static global::UICamera.Mouse.Button.PressState operator -(global::UICamera.Mouse.Button.PressState l, global::UICamera.Mouse.Button.PressState r)
				{
					global::UICamera.Mouse.Button.PressState result;
					result.Pressed = (l.Pressed & ~r.Pressed);
					return result;
				}

				// Token: 0x0600505C RID: 20572 RVA: 0x00138E20 File Offset: 0x00137020
				public static global::UICamera.Mouse.Button.PressState operator -(global::UICamera.Mouse.Button.PressState l, global::UICamera.Mouse.Button.Flags r)
				{
					global::UICamera.Mouse.Button.PressState result;
					result.Pressed = (l.Pressed & ~r);
					return result;
				}

				// Token: 0x0600505D RID: 20573 RVA: 0x00138E40 File Offset: 0x00137040
				public static global::UICamera.Mouse.Button.PressState operator -(global::UICamera.Mouse.Button.Flags l, global::UICamera.Mouse.Button.PressState r)
				{
					global::UICamera.Mouse.Button.PressState result;
					result.Pressed = (l & ~r.Pressed);
					return result;
				}

				// Token: 0x0600505E RID: 20574 RVA: 0x00138E60 File Offset: 0x00137060
				public static global::UICamera.Mouse.Button.PressState operator *(global::UICamera.Mouse.Button.PressState l, global::UICamera.Mouse.Button.PressState r)
				{
					global::UICamera.Mouse.Button.PressState result;
					result.Pressed = (l.Pressed & r.Pressed);
					return result;
				}

				// Token: 0x0600505F RID: 20575 RVA: 0x00138E84 File Offset: 0x00137084
				public static global::UICamera.Mouse.Button.PressState operator *(global::UICamera.Mouse.Button.PressState l, global::UICamera.Mouse.Button.Flags r)
				{
					global::UICamera.Mouse.Button.PressState result;
					result.Pressed = (l.Pressed & r);
					return result;
				}

				// Token: 0x06005060 RID: 20576 RVA: 0x00138EA4 File Offset: 0x001370A4
				public static global::UICamera.Mouse.Button.PressState operator *(global::UICamera.Mouse.Button.Flags l, global::UICamera.Mouse.Button.PressState r)
				{
					global::UICamera.Mouse.Button.PressState result;
					result.Pressed = (l & r.Pressed);
					return result;
				}

				// Token: 0x06005061 RID: 20577 RVA: 0x00138EC4 File Offset: 0x001370C4
				public static global::UICamera.Mouse.Button.PressState operator /(global::UICamera.Mouse.Button.PressState l, global::UICamera.Mouse.Button.PressState r)
				{
					global::UICamera.Mouse.Button.PressState result;
					result.Pressed = (l.Pressed ^ r.Pressed);
					return result;
				}

				// Token: 0x06005062 RID: 20578 RVA: 0x00138EE8 File Offset: 0x001370E8
				public static global::UICamera.Mouse.Button.PressState operator /(global::UICamera.Mouse.Button.PressState l, global::UICamera.Mouse.Button.Flags r)
				{
					global::UICamera.Mouse.Button.PressState result;
					result.Pressed = (l.Pressed ^ r);
					return result;
				}

				// Token: 0x06005063 RID: 20579 RVA: 0x00138F08 File Offset: 0x00137108
				public static global::UICamera.Mouse.Button.PressState operator /(global::UICamera.Mouse.Button.Flags l, global::UICamera.Mouse.Button.PressState r)
				{
					global::UICamera.Mouse.Button.PressState result;
					result.Pressed = (l ^ r.Pressed);
					return result;
				}

				// Token: 0x04002CD8 RID: 11480
				public global::UICamera.Mouse.Button.Flags Pressed;

				// Token: 0x02000932 RID: 2354
				public class Enumerator : global::System.IDisposable, global::System.Collections.IEnumerator, global::System.Collections.Generic.IEnumerator<global::UICamera.Mouse.Button.Flags>
				{
					// Token: 0x06005064 RID: 20580 RVA: 0x00138F28 File Offset: 0x00137128
					private Enumerator()
					{
					}

					// Token: 0x06005065 RID: 20581 RVA: 0x00138F30 File Offset: 0x00137130
					static Enumerator()
					{
						for (global::UICamera.Mouse.Button.Flags flags = (global::UICamera.Mouse.Button.Flags)0; flags <= (global::UICamera.Mouse.Button.Flags.Left | global::UICamera.Mouse.Button.Flags.Right | global::UICamera.Mouse.Button.Flags.Middle); flags++)
						{
							int num = 0;
							uint num2 = (uint)flags;
							while (num2 != 0U)
							{
								num2 &= num2 - 1U;
								num++;
							}
							global::UICamera.Mouse.Button.Flags[] array = new global::UICamera.Mouse.Button.Flags[num];
							int num3 = 0;
							int num4 = 0;
							while (num4 < 3 && num3 < num)
							{
								if ((flags & (global::UICamera.Mouse.Button.Flags)(1 << num4)) == (global::UICamera.Mouse.Button.Flags)(1 << num4))
								{
									array[num3++] = (global::UICamera.Mouse.Button.Flags)(1 << num4);
								}
								num4++;
							}
							global::UICamera.Mouse.Button.PressState.Enumerator.combos[(int)flags] = array;
						}
					}

					// Token: 0x17000EE8 RID: 3816
					// (get) Token: 0x06005066 RID: 20582 RVA: 0x00138FC8 File Offset: 0x001371C8
					object global::System.Collections.IEnumerator.Current
					{
						get
						{
							return this.flags[this.pos];
						}
					}

					// Token: 0x06005067 RID: 20583 RVA: 0x00138FDC File Offset: 0x001371DC
					public static global::UICamera.Mouse.Button.PressState.Enumerator Enumerate(global::UICamera.Mouse.Button.Flags flags)
					{
						global::UICamera.Mouse.Button.PressState.Enumerator enumerator;
						if (global::UICamera.Mouse.Button.PressState.Enumerator.dumpCount == 0U)
						{
							enumerator = new global::UICamera.Mouse.Button.PressState.Enumerator();
						}
						else
						{
							enumerator = global::UICamera.Mouse.Button.PressState.Enumerator.dump;
							global::UICamera.Mouse.Button.PressState.Enumerator.dump = enumerator.nextDump;
							global::UICamera.Mouse.Button.PressState.Enumerator.dumpCount -= 1U;
							enumerator.nextDump = null;
						}
						enumerator.pos = -1;
						enumerator.value = flags;
						enumerator.inDump = false;
						enumerator.flags = global::UICamera.Mouse.Button.PressState.Enumerator.combos[(int)flags];
						return enumerator;
					}

					// Token: 0x17000EE9 RID: 3817
					// (get) Token: 0x06005068 RID: 20584 RVA: 0x00139048 File Offset: 0x00137248
					public global::UICamera.Mouse.Button.Flags Current
					{
						get
						{
							return this.flags[this.pos];
						}
					}

					// Token: 0x06005069 RID: 20585 RVA: 0x00139058 File Offset: 0x00137258
					public bool MoveNext()
					{
						return ++this.pos < this.flags.Length;
					}

					// Token: 0x0600506A RID: 20586 RVA: 0x00139080 File Offset: 0x00137280
					public void Reset()
					{
						this.pos = -1;
					}

					// Token: 0x0600506B RID: 20587 RVA: 0x0013908C File Offset: 0x0013728C
					public void Dispose()
					{
						if (!this.inDump)
						{
							this.nextDump = global::UICamera.Mouse.Button.PressState.Enumerator.dump;
							this.inDump = true;
							global::UICamera.Mouse.Button.PressState.Enumerator.dump = this;
							global::UICamera.Mouse.Button.PressState.Enumerator.dumpCount += 1U;
						}
					}

					// Token: 0x04002CD9 RID: 11481
					private static readonly global::UICamera.Mouse.Button.Flags[][] combos = new global::UICamera.Mouse.Button.Flags[8][];

					// Token: 0x04002CDA RID: 11482
					private global::UICamera.Mouse.Button.Flags[] flags;

					// Token: 0x04002CDB RID: 11483
					private global::UICamera.Mouse.Button.Flags value;

					// Token: 0x04002CDC RID: 11484
					private int pos;

					// Token: 0x04002CDD RID: 11485
					private global::UICamera.Mouse.Button.PressState.Enumerator nextDump;

					// Token: 0x04002CDE RID: 11486
					private bool inDump;

					// Token: 0x04002CDF RID: 11487
					private static global::UICamera.Mouse.Button.PressState.Enumerator dump;

					// Token: 0x04002CE0 RID: 11488
					private static uint dumpCount;
				}
			}

			// Token: 0x02000933 RID: 2355
			public sealed class Sampler
			{
				// Token: 0x0600506C RID: 20588 RVA: 0x001390C0 File Offset: 0x001372C0
				public Sampler(global::UICamera.Mouse.Button.Flags Button, global::UICamera.CursorSampler Cursor)
				{
					this.Button = Button;
					this.Cursor = Cursor;
				}

				// Token: 0x04002CE1 RID: 11489
				public readonly global::UICamera.Mouse.Button.Flags Button;

				// Token: 0x04002CE2 RID: 11490
				public readonly global::UICamera.CursorSampler Cursor;

				// Token: 0x04002CE3 RID: 11491
				public global::UnityEngine.GameObject Pressed;

				// Token: 0x04002CE4 RID: 11492
				public global::UIHotSpot.Hit Hit;

				// Token: 0x04002CE5 RID: 11493
				public global::UnityEngine.Vector2 Point;

				// Token: 0x04002CE6 RID: 11494
				public global::UnityEngine.Vector2 TotalDelta;

				// Token: 0x04002CE7 RID: 11495
				public ulong ClickCount;

				// Token: 0x04002CE8 RID: 11496
				public ulong DragClickNumber;

				// Token: 0x04002CE9 RID: 11497
				public float PressTime;

				// Token: 0x04002CEA RID: 11498
				public float ReleaseTime;

				// Token: 0x04002CEB RID: 11499
				public global::UICamera.ClickNotification ClickNotification;

				// Token: 0x04002CEC RID: 11500
				public bool PressedNow;

				// Token: 0x04002CED RID: 11501
				public bool Held;

				// Token: 0x04002CEE RID: 11502
				public bool ReleasedNow;

				// Token: 0x04002CEF RID: 11503
				public bool DidHit;

				// Token: 0x04002CF0 RID: 11504
				public bool Once;

				// Token: 0x04002CF1 RID: 11505
				public bool DragClick;
			}
		}

		// Token: 0x02000934 RID: 2356
		public struct State
		{
			// Token: 0x04002CF2 RID: 11506
			public global::UnityEngine.Vector2 Point;

			// Token: 0x04002CF3 RID: 11507
			public global::UnityEngine.Vector2 Delta;

			// Token: 0x04002CF4 RID: 11508
			public global::UnityEngine.Vector2 Scroll;

			// Token: 0x04002CF5 RID: 11509
			public global::UICamera.Mouse.Button.PressState Buttons;
		}
	}

	// Token: 0x02000935 RID: 2357
	public sealed class CursorSampler
	{
		// Token: 0x0600506D RID: 20589 RVA: 0x001390D8 File Offset: 0x001372D8
		public CursorSampler()
		{
			this.Buttons.LeftValue = new global::UICamera.Mouse.Button.Sampler(global::UICamera.Mouse.Button.Flags.Left, this);
			this.Buttons.RightValue = new global::UICamera.Mouse.Button.Sampler(global::UICamera.Mouse.Button.Flags.Right, this);
			this.Buttons.MiddleValue = new global::UICamera.Mouse.Button.Sampler(global::UICamera.Mouse.Button.Flags.Middle, this);
		}

		// Token: 0x17000EEA RID: 3818
		// (get) Token: 0x0600506E RID: 20590 RVA: 0x0013912C File Offset: 0x0013732C
		public global::UnityEngine.Vector2 Point
		{
			get
			{
				return this.Current.Mouse.Point;
			}
		}

		// Token: 0x17000EEB RID: 3819
		// (get) Token: 0x0600506F RID: 20591 RVA: 0x00139140 File Offset: 0x00137340
		public global::UnityEngine.Vector2 FrameDelta
		{
			get
			{
				return this.Current.Mouse.Delta;
			}
		}

		// Token: 0x06005070 RID: 20592 RVA: 0x00139154 File Offset: 0x00137354
		private static void ExitDragHover(global::UnityEngine.GameObject lander, global::UnityEngine.GameObject drop, global::DropNotificationFlags flags)
		{
			if ((flags & global::DropNotificationFlags.ReverseHover) == global::DropNotificationFlags.ReverseHover)
			{
				if ((flags & global::DropNotificationFlags.DragHover) == global::DropNotificationFlags.DragHover)
				{
					drop.NGUIMessage("OnDragHoverExit", lander);
				}
				if ((flags & global::DropNotificationFlags.LandHover) == global::DropNotificationFlags.LandHover)
				{
					lander.NGUIMessage("OnLandHoverExit", drop);
				}
			}
			else
			{
				if ((flags & global::DropNotificationFlags.LandHover) == global::DropNotificationFlags.LandHover)
				{
					lander.NGUIMessage("OnLandHoverExit", drop);
				}
				if ((flags & global::DropNotificationFlags.DragHover) == global::DropNotificationFlags.DragHover)
				{
					drop.NGUIMessage("OnDragHoverExit", lander);
				}
			}
		}

		// Token: 0x06005071 RID: 20593 RVA: 0x001391EC File Offset: 0x001373EC
		private static void EnterDragHover(global::UnityEngine.GameObject lander, global::UnityEngine.GameObject drop, global::DropNotificationFlags flags)
		{
			if ((flags & global::DropNotificationFlags.ReverseHover) == global::DropNotificationFlags.ReverseHover)
			{
				if ((flags & global::DropNotificationFlags.LandHover) == global::DropNotificationFlags.LandHover)
				{
					lander.NGUIMessage("OnLandHoverEnter", drop);
				}
				if ((flags & global::DropNotificationFlags.DragHover) == global::DropNotificationFlags.DragHover)
				{
					drop.NGUIMessage("OnDragHoverEnter", lander);
				}
			}
			else
			{
				if ((flags & global::DropNotificationFlags.DragHover) == global::DropNotificationFlags.DragHover)
				{
					drop.NGUIMessage("OnDragHoverEnter", lander);
				}
				if ((flags & global::DropNotificationFlags.LandHover) == global::DropNotificationFlags.LandHover)
				{
					lander.NGUIMessage("OnLandHoverEnter", drop);
				}
			}
		}

		// Token: 0x06005072 RID: 20594 RVA: 0x00139284 File Offset: 0x00137484
		private void CheckDragHover(bool HasCurrent, global::UnityEngine.GameObject Current, global::UnityEngine.GameObject Pressed)
		{
			if (HasCurrent)
			{
				if (this.DragHover == Current)
				{
					return;
				}
				if (this.DragHover && this.DragHover != Pressed)
				{
					global::UICamera.CursorSampler.ExitDragHover(Pressed, this.DragHover, this.LastHoverDropNotification);
				}
				this.DragHover = Current;
				if (Current != Pressed)
				{
					this.LastHoverDropNotification = this.DropNotification;
					global::UICamera.CursorSampler.EnterDragHover(Pressed, this.DragHover, this.LastHoverDropNotification);
				}
			}
			else
			{
				this.ClearDragHover(Pressed);
			}
		}

		// Token: 0x06005073 RID: 20595 RVA: 0x0013931C File Offset: 0x0013751C
		private void ClearDragHover(global::UnityEngine.GameObject Pressed)
		{
			if (this.DragHover)
			{
				if (this.DragHover != Pressed)
				{
					global::UICamera.CursorSampler.ExitDragHover(Pressed, this.DragHover, this.LastHoverDropNotification);
				}
				this.DragHover = null;
			}
		}

		// Token: 0x06005074 RID: 20596 RVA: 0x00139364 File Offset: 0x00137564
		internal void MouseEvent(global::NGUIHack.Event @event, global::UnityEngine.EventType type)
		{
			global::UICamera.CursorSampler.Sample current;
			current.Mouse.Scroll = default(global::UnityEngine.Vector2);
			current.Mouse.Buttons.Pressed = (global::UICamera.Mouse.Button.Held | global::UICamera.Mouse.Button.NewlyPressed);
			current.Mouse.Point = @event.mousePosition;
			if (this.Current.Valid)
			{
				current.IsFirst = false;
				if (this.Current.Mouse.Point.x != current.Mouse.Point.x)
				{
					current.Mouse.Delta.x = current.Mouse.Point.x - this.Current.Mouse.Point.x;
					if (this.Current.Mouse.Point.y != current.Mouse.Point.y)
					{
						current.Mouse.Delta.y = current.Mouse.Point.y - this.Current.Mouse.Point.y;
					}
					else
					{
						current.Mouse.Delta.y = 0f;
					}
					current.DidMove = true;
				}
				else if (this.Current.Mouse.Point.y != current.Mouse.Point.y)
				{
					current.Mouse.Delta.x = 0f;
					current.Mouse.Delta.y = current.Mouse.Point.y - this.Current.Mouse.Point.y;
					current.DidMove = true;
				}
				else
				{
					current.DidMove = false;
					current.Mouse.Delta.x = (current.Mouse.Delta.y = 0f);
				}
			}
			else
			{
				current.IsFirst = true;
				current.DidMove = false;
				current.Mouse.Delta.x = (current.Mouse.Delta.y = 0f);
			}
			current.Hit = global::UIHotSpot.Hit.invalid;
			if (current.DidHit = global::UICamera.Raycast(current.Mouse.Point, ref current.Hit, out current.UICamera))
			{
				global::UICamera.lastHit = current.Hit;
				current.Under = current.Hit.gameObject;
				current.HasUnder = true;
			}
			else if (global::UICamera.fallThrough)
			{
				current.Under = global::UICamera.fallThrough;
				current.HasUnder = true;
				current.UICamera = global::UICamera.FindCameraForLayer(global::UICamera.fallThrough.layer);
				if (!current.UICamera)
				{
					current.UICamera = ((current.IsFirst || !this.Current.UICamera) ? global::UICamera.mList[(int)global::UICamera.mListSort[0]] : this.Current.UICamera);
				}
			}
			else
			{
				current.Under = null;
				current.HasUnder = false;
				current.UICamera = ((current.IsFirst || !this.Current.UICamera) ? global::UICamera.mList[(int)global::UICamera.mListSort[0]] : this.Current.UICamera);
			}
			current.UnderChange = (current.IsFirst || ((!current.HasUnder) ? this.Current.HasUnder : (!this.Current.HasUnder || this.Current.Under != current.Under)));
			current.HoverChange = (current.UnderChange && current.Under != global::UICamera.mHover);
			current.ButtonChange = global::UICamera.Mouse.Button.AnyNewlyPressedOrReleased;
			bool flag = false;
			if (current.ButtonChange && global::UICamera.Mouse.Button.AnyNewlyPressedThatCancelTooltips)
			{
				current.UICamera.mTooltipTime = 0f;
			}
			else
			{
				if (current.DidMove && (current.HoverChange || !current.UICamera.stickyTooltip))
				{
					if (current.UICamera.mTooltipTime != 0f)
					{
						current.UICamera.mTooltipTime = global::UnityEngine.Time.realtimeSinceStartup + current.UICamera.tooltipDelay;
					}
					else if (current.UICamera.mTooltip != null)
					{
						flag = true;
						current.UICamera.ShowTooltip(false);
					}
				}
				if (current.HoverChange && global::UICamera.mHover)
				{
					if (current.UICamera.mTooltip != null)
					{
						current.UICamera.ShowTooltip(false);
					}
					global::UICamera.Highlight(global::UICamera.mHover, false);
					global::UICamera.mHover = null;
				}
			}
			current.Time = global::UnityEngine.Time.realtimeSinceStartup;
			current.ButtonsPressed = global::UICamera.Mouse.Button.NewlyPressed;
			current.ButtonsReleased = global::UICamera.Mouse.Button.NewlyReleased;
			if (!flag && current.ButtonsPressed != (global::UICamera.Mouse.Button.Flags)0 && current.UICamera.mTooltip)
			{
				current.UICamera.ShowTooltip(false);
				flag = true;
			}
			for (global::UICamera.Mouse.Button.Flags flags = global::UICamera.Mouse.Button.Flags.Left; flags < (global::UICamera.Mouse.Button.Flags.Left | global::UICamera.Mouse.Button.Flags.Right | global::UICamera.Mouse.Button.Flags.Middle); flags <<= 1)
			{
				global::UICamera.Mouse.Button.Sampler sampler = this.Buttons[flags];
				try
				{
					this.CurrentButton = sampler;
					sampler.PressedNow = (sampler.ReleasedNow = false);
					if ((current.ButtonsPressed & flags) == flags)
					{
						if (sampler.Once)
						{
							float releaseTime = sampler.ReleaseTime;
						}
						else
						{
							float num = sampler.ReleaseTime = current.Time - 120f;
							sampler.Once = true;
						}
						sampler.PressTime = current.Time;
						sampler.Pressed = current.Under;
						sampler.DidHit = current.DidHit;
						sampler.PressedNow = true;
						sampler.Hit = current.Hit;
						sampler.ReleasedNow = false;
						sampler.Held = true;
						sampler.Point = current.Mouse.Point;
						sampler.TotalDelta.x = (sampler.TotalDelta.y = 0f);
						sampler.ClickNotification = global::UICamera.ClickNotification.Always;
						if (flags == global::UICamera.Mouse.Button.Flags.Left)
						{
							this.Dragging = false;
							this.DropNotification = global::DropNotificationFlags.DragDrop;
							sampler.DragClick = false;
							sampler.DragClickNumber = 0UL;
						}
						else if (this.Dragging)
						{
							sampler.DragClick = true;
							sampler.DragClickNumber = this.Buttons.LeftValue.ClickCount;
						}
						else
						{
							sampler.DragClick = false;
							sampler.DragClickNumber = 0UL;
						}
						if (current.DidHit)
						{
							if (flags == global::UICamera.Mouse.Button.Flags.Left)
							{
								global::UICamera.mPressInput = current.Under.GetComponent<global::UIInput>();
								if (global::UICamera.mSelInput)
								{
									if (global::UICamera.mPressInput)
									{
										if (global::UICamera.mSelInput == global::UICamera.mPressInput)
										{
											global::UICamera.mSelInput.OnEvent(current.UICamera, @event, type);
										}
										else
										{
											global::UICamera.mSelInput.LoseFocus();
											global::UICamera.mSelInput = null;
											global::UICamera.mPressInput.GainFocus();
											global::UICamera.mPressInput.OnEvent(current.UICamera, @event, type);
										}
									}
									else
									{
										global::UICamera.mSelInput.LoseFocus();
										global::UICamera.mSelInput = null;
									}
								}
								else if (global::UICamera.mPressInput)
								{
									global::UICamera.mPressInput.GainFocus();
									global::UICamera.mPressInput.OnEvent(current.UICamera, @event, type);
								}
								if (global::UICamera.mSel && global::UICamera.mSel != current.Under)
								{
									if (!flag && current.UICamera.mTooltip)
									{
										current.UICamera.ShowTooltip(false);
									}
									global::UICamera.SetSelectedObject(null);
								}
								this.Panel = global::UIPanel.FindRoot(current.Under.transform);
								if (this.Panel)
								{
									if (this.Panel != global::UICamera.popupPanel && global::UICamera.popupPanel)
									{
										global::UICamera.PopupPanel(null);
									}
									current.Under.Press(true);
									this.Panel.gameObject.NGUIMessage("OnChildPress", true);
								}
								else
								{
									if (global::UICamera.popupPanel)
									{
										global::UICamera.PopupPanel(null);
									}
									current.Under.Press(true);
								}
								this.PressDropNotification = this.DropNotification;
							}
							else
							{
								if (global::UICamera.mSelInput)
								{
									global::UICamera.mSelInput.OnEvent(current.UICamera, @event, type);
								}
								if (!sampler.DragClick)
								{
									if (flags == global::UICamera.Mouse.Button.Flags.Right)
									{
										global::UIPanel uipanel = global::UIPanel.FindRoot(current.Under.transform);
										if (global::UICamera.popupPanel && global::UICamera.popupPanel != uipanel)
										{
											global::UICamera.PopupPanel(null);
										}
										current.Under.AltPress(true);
									}
									else if (flags == global::UICamera.Mouse.Button.Flags.Middle)
									{
										current.Under.MidPress(true);
									}
								}
							}
							@event.Use();
						}
						else if (flags == global::UICamera.Mouse.Button.Flags.Left)
						{
							if (global::UICamera.popupPanel)
							{
								global::UICamera.PopupPanel(null);
							}
							global::UICamera.mPressInput = null;
							if (global::UICamera.mSelInput)
							{
								global::UICamera.mSelInput.LoseFocus();
								global::UICamera.mSelInput = null;
							}
							if (global::UICamera.mSel)
							{
								if (!flag && current.UICamera.mTooltip)
								{
									current.UICamera.ShowTooltip(false);
								}
								global::UICamera.SetSelectedObject(null);
							}
						}
					}
					else if (sampler.Held && sampler.DidHit)
					{
						if (type == 3 && flags == global::UICamera.Mouse.Button.Flags.Left)
						{
							if (global::UICamera.mPressInput)
							{
								global::UICamera.mPressInput.OnEvent(current.UICamera, @event, type);
							}
							@event.Use();
						}
						if (current.DidMove)
						{
							if (!flag && current.UICamera.mTooltip)
							{
								current.UICamera.ShowTooltip(false);
							}
							global::UICamera.Mouse.Button.Sampler sampler2 = sampler;
							sampler2.TotalDelta.x = sampler2.TotalDelta.x + current.Mouse.Delta.x;
							global::UICamera.Mouse.Button.Sampler sampler3 = sampler;
							sampler3.TotalDelta.y = sampler3.TotalDelta.y + current.Mouse.Delta.y;
							bool flag2 = sampler.ClickNotification == global::UICamera.ClickNotification.None;
							if (flags == global::UICamera.Mouse.Button.Flags.Left && !sampler.DragClick && (this.PressDropNotification & (global::DropNotificationFlags.DragDrop | global::DropNotificationFlags.DragLand | global::DropNotificationFlags.AltDrop | global::DropNotificationFlags.AltLand | global::DropNotificationFlags.MidDrop | global::DropNotificationFlags.MidLand)) != (global::DropNotificationFlags)0)
							{
								if (!this.Dragging)
								{
									sampler.Pressed.DragState(true);
									this.Dragging = true;
								}
								sampler.Pressed.Drag(current.Mouse.Delta);
								this.CheckDragHover(current.DidHit, current.Under, sampler.Pressed);
							}
							if (flag2)
							{
								sampler.ClickNotification = global::UICamera.ClickNotification.None;
							}
							else if (sampler.ClickNotification == global::UICamera.ClickNotification.BasedOnDelta)
							{
								float num2;
								if (flags == global::UICamera.Mouse.Button.Flags.Left)
								{
									num2 = current.UICamera.mouseClickThreshold;
								}
								else
								{
									num2 = (float)global::UnityEngine.Screen.height * 0.1f;
									if (num2 < current.UICamera.touchClickThreshold)
									{
										num2 = current.UICamera.touchClickThreshold;
									}
								}
								if (sampler.TotalDelta.x * sampler.TotalDelta.x + sampler.TotalDelta.y * sampler.TotalDelta.y > num2 * num2)
								{
									sampler.ClickNotification = global::UICamera.ClickNotification.None;
								}
							}
						}
					}
				}
				finally
				{
					this.CurrentButton = null;
				}
			}
			for (global::UICamera.Mouse.Button.Flags flags2 = global::UICamera.Mouse.Button.Flags.Middle; flags2 != (global::UICamera.Mouse.Button.Flags)0; flags2 >>= 1)
			{
				global::UICamera.Mouse.Button.Sampler sampler4 = this.Buttons[flags2];
				try
				{
					this.CurrentButton = sampler4;
					if ((current.ButtonsReleased & flags2) == flags2)
					{
						sampler4.ReleasedNow = true;
						if (sampler4.DidHit)
						{
							if (flags2 == global::UICamera.Mouse.Button.Flags.Left)
							{
								if ((type == 1 || type == 5) && global::UICamera.mPressInput && sampler4.Pressed == global::UICamera.mPressInput.gameObject)
								{
									global::UICamera.mPressInput.OnEvent(current.UICamera, @event, type);
									global::UICamera.mSelInput = global::UICamera.mPressInput;
								}
								global::UICamera.mPressInput = null;
								if (current.HasUnder)
								{
									if (sampler4.Pressed == current.Under)
									{
										if (this.Dragging && (this.PressDropNotification & (global::DropNotificationFlags.DragDrop | global::DropNotificationFlags.DragLand | global::DropNotificationFlags.AltDrop | global::DropNotificationFlags.AltLand | global::DropNotificationFlags.MidDrop | global::DropNotificationFlags.MidLand)) != (global::DropNotificationFlags)0)
										{
											this.ClearDragHover(sampler4.Pressed);
											if (!sampler4.DragClick)
											{
												sampler4.Pressed.DragState(false);
											}
										}
										if (this.Panel)
										{
											this.Panel.gameObject.NGUIMessage("OnChildPress", false);
										}
										sampler4.Pressed.Press(false);
										if (sampler4.Pressed == global::UICamera.mHover)
										{
											sampler4.Pressed.Hover(true);
										}
										if (sampler4.Pressed != global::UICamera.mSel)
										{
											global::UICamera.mSel = sampler4.Pressed;
											sampler4.Pressed.Select(true);
										}
										else
										{
											global::UICamera.mSel = sampler4.Pressed;
										}
										if (!sampler4.DragClick && sampler4.ClickNotification != global::UICamera.ClickNotification.None)
										{
											if (this.Panel)
											{
												this.Panel.gameObject.NGUIMessage("OnChildClick", sampler4.Pressed);
											}
											if (sampler4.ClickNotification != global::UICamera.ClickNotification.None)
											{
												sampler4.Pressed.Click();
												if (sampler4.ClickNotification != global::UICamera.ClickNotification.None && sampler4.ReleaseTime + 0.25f > current.Time)
												{
													sampler4.Pressed.DoubleClick();
												}
											}
										}
										else if (this.Panel)
										{
											this.Panel.gameObject.NGUIMessage("OnChildClickCanceled", sampler4.Pressed);
										}
									}
									else
									{
										if (this.Dragging && !sampler4.DragClick && (this.PressDropNotification & (global::DropNotificationFlags.DragDrop | global::DropNotificationFlags.DragLand | global::DropNotificationFlags.AltDrop | global::DropNotificationFlags.AltLand | global::DropNotificationFlags.MidDrop | global::DropNotificationFlags.MidLand)) != (global::DropNotificationFlags)0)
										{
											global::DropNotification.DropMessage(ref this.DropNotification, global::DragEventKind.Drag, sampler4.Pressed, current.Under);
											this.ClearDragHover(sampler4.Pressed);
											sampler4.Pressed.DragState(false);
										}
										if (this.Panel)
										{
											this.Panel.gameObject.NGUIMessage("OnChildPress", false);
										}
										sampler4.Pressed.Press(false);
										if (sampler4.Pressed == global::UICamera.mHover)
										{
											sampler4.Pressed.Hover(true);
										}
									}
								}
								else if (this.Dragging)
								{
									this.ClearDragHover(sampler4.Pressed);
									if (!sampler4.DragClick)
									{
										global::DropNotification.DropMessage(ref this.DropNotification, global::DragEventKind.Drag, sampler4.Pressed, current.Under);
										sampler4.Pressed.DragState(false);
									}
									if (this.Panel)
									{
										this.Panel.gameObject.NGUIMessage("OnChildPress", false);
									}
									sampler4.Pressed.Press(false);
									if (sampler4.Pressed == global::UICamera.mHover)
									{
										sampler4.Pressed.Hover(true);
									}
									this.Dragging = false;
								}
							}
							else if (sampler4.DragClick)
							{
								if (!this.Buttons.LeftValue.DragClick && this.Buttons.LeftValue.ClickCount == sampler4.DragClickNumber)
								{
									bool flag3;
									if (flags2 == global::UICamera.Mouse.Button.Flags.Right)
									{
										flag3 = global::DropNotification.DropMessage(ref this.DropNotification, global::DragEventKind.Alt, this.Buttons.LeftValue.Pressed, sampler4.Pressed);
									}
									else
									{
										flag3 = (flags2 == global::UICamera.Mouse.Button.Flags.Middle && global::DropNotification.DropMessage(ref this.DropNotification, global::DragEventKind.Mid, this.Buttons.LeftValue.Pressed, sampler4.Pressed));
									}
									if (flag3)
									{
										this.Buttons.LeftValue.DragClick = true;
										this.ClearDragHover(this.Buttons.LeftValue.Pressed);
										sampler4.Pressed.DragState(false);
									}
								}
							}
							else if (flags2 == global::UICamera.Mouse.Button.Flags.Right)
							{
								sampler4.Pressed.AltPress(false);
								if (current.HasUnder && sampler4.Pressed == current.Under && sampler4.ClickNotification != global::UICamera.ClickNotification.None)
								{
									sampler4.Pressed.AltClick();
									if (sampler4.ClickNotification != global::UICamera.ClickNotification.None && sampler4.ReleaseTime + 0.25f > current.Time)
									{
										sampler4.Pressed.AltDoubleClick();
									}
								}
							}
							else if (flags2 == global::UICamera.Mouse.Button.Flags.Middle)
							{
								sampler4.Pressed.MidPress(false);
								if (current.HasUnder && sampler4.Pressed == current.Under && sampler4.ClickNotification != global::UICamera.ClickNotification.None)
								{
									sampler4.Pressed.MidClick();
									if (sampler4.ClickNotification != global::UICamera.ClickNotification.None && sampler4.ReleaseTime + 0.25f > current.Time)
									{
										sampler4.Pressed.MidDoubleClick();
									}
								}
							}
						}
						sampler4.ReleasedNow = true;
						sampler4.ClickNotification = global::UICamera.ClickNotification.None;
						sampler4.ReleaseTime = current.Time;
						sampler4.Held = false;
						sampler4.ClickCount += 1UL;
						sampler4.DragClick = false;
						sampler4.DragClickNumber = 0UL;
						if (flags2 == global::UICamera.Mouse.Button.Flags.Left)
						{
							this.Dragging = false;
							this.Panel = null;
						}
						if (@event.type == 1 || @event.type == 5)
						{
							@event.Use();
						}
					}
				}
				finally
				{
					this.CurrentButton = null;
				}
			}
			global::UICamera.lastMousePosition = ((!current.IsFirst) ? this.Current.Mouse.Point : current.Mouse.Point);
			if (current.HasUnder && (current.Mouse.Buttons.NonePressed || (this.Dragging && (this.DropNotification & global::DropNotificationFlags.RegularHover) == global::DropNotificationFlags.RegularHover)) && global::UICamera.mHover != current.Under)
			{
				current.UICamera.mTooltipTime = current.Time + current.UICamera.tooltipDelay;
				global::UICamera.mHover = current.Under;
				global::UICamera.Highlight(global::UICamera.mHover, true);
			}
			current.Valid = true;
			this.Last = this.Current;
			this.Current = current;
		}

		// Token: 0x04002CF6 RID: 11510
		private const float kDoubleClickLimit = 0.25f;

		// Token: 0x04002CF7 RID: 11511
		public global::UICamera.Mouse.Button.ValCollection<global::UICamera.Mouse.Button.Sampler> Buttons;

		// Token: 0x04002CF8 RID: 11512
		public global::DropNotificationFlags DropNotification;

		// Token: 0x04002CF9 RID: 11513
		public bool Dragging;

		// Token: 0x04002CFA RID: 11514
		public global::UICamera.CursorSampler.Sample Current;

		// Token: 0x04002CFB RID: 11515
		public global::UICamera.CursorSampler.Sample Last;

		// Token: 0x04002CFC RID: 11516
		public float LastClickTime = float.MaxValue;

		// Token: 0x04002CFD RID: 11517
		public bool IsFirst;

		// Token: 0x04002CFE RID: 11518
		public bool IsLast;

		// Token: 0x04002CFF RID: 11519
		public bool IsCurrent;

		// Token: 0x04002D00 RID: 11520
		public global::UICamera.Mouse.Button.Sampler CurrentButton;

		// Token: 0x04002D01 RID: 11521
		private global::DropNotificationFlags LastHoverDropNotification;

		// Token: 0x04002D02 RID: 11522
		private global::DropNotificationFlags PressDropNotification;

		// Token: 0x04002D03 RID: 11523
		private global::UnityEngine.GameObject DragHover;

		// Token: 0x04002D04 RID: 11524
		private global::UIPanel Panel;

		// Token: 0x02000936 RID: 2358
		public struct Sample
		{
			// Token: 0x17000EEC RID: 3820
			// (get) Token: 0x06005075 RID: 20597 RVA: 0x0013A6C4 File Offset: 0x001388C4
			public global::UnityEngine.Camera Camera
			{
				get
				{
					return (!this.UICamera) ? null : this.UICamera.cachedCamera;
				}
			}

			// Token: 0x06005076 RID: 20598 RVA: 0x0013A6E8 File Offset: 0x001388E8
			public static bool operator true(global::UICamera.CursorSampler.Sample sample)
			{
				return sample.Valid;
			}

			// Token: 0x06005077 RID: 20599 RVA: 0x0013A6F4 File Offset: 0x001388F4
			public static bool operator false(global::UICamera.CursorSampler.Sample sample)
			{
				return !sample.Valid;
			}

			// Token: 0x04002D05 RID: 11525
			public global::UnityEngine.GameObject Under;

			// Token: 0x04002D06 RID: 11526
			public global::UICamera UICamera;

			// Token: 0x04002D07 RID: 11527
			public global::UICamera.Mouse.State Mouse;

			// Token: 0x04002D08 RID: 11528
			public global::UIHotSpot.Hit Hit;

			// Token: 0x04002D09 RID: 11529
			public float Time;

			// Token: 0x04002D0A RID: 11530
			public bool DidHit;

			// Token: 0x04002D0B RID: 11531
			public bool HasUnder;

			// Token: 0x04002D0C RID: 11532
			public bool Valid;

			// Token: 0x04002D0D RID: 11533
			public bool DidMove;

			// Token: 0x04002D0E RID: 11534
			public bool IsFirst;

			// Token: 0x04002D0F RID: 11535
			public bool ButtonChange;

			// Token: 0x04002D10 RID: 11536
			public bool UnderChange;

			// Token: 0x04002D11 RID: 11537
			public bool HoverChange;

			// Token: 0x04002D12 RID: 11538
			public global::UICamera.Mouse.Button.Flags ButtonsPressed;

			// Token: 0x04002D13 RID: 11539
			public global::UICamera.Mouse.Button.Flags ButtonsReleased;
		}
	}

	// Token: 0x02000937 RID: 2359
	private static class LateLoadCursor
	{
		// Token: 0x06005078 RID: 20600 RVA: 0x0013A700 File Offset: 0x00138900
		// Note: this type is marked as 'beforefieldinit'.
		static LateLoadCursor()
		{
		}

		// Token: 0x04002D14 RID: 11540
		public static readonly global::UICamera.CursorSampler Sampler = new global::UICamera.CursorSampler();
	}

	// Token: 0x02000938 RID: 2360
	public struct BackwardsCompatabilitySupport
	{
		// Token: 0x17000EED RID: 3821
		// (get) Token: 0x06005079 RID: 20601 RVA: 0x0013A70C File Offset: 0x0013890C
		// (set) Token: 0x0600507A RID: 20602 RVA: 0x0013A724 File Offset: 0x00138924
		public global::UICamera.ClickNotification clickNotification
		{
			get
			{
				return global::UICamera.Cursor.Buttons.LeftValue.ClickNotification;
			}
			set
			{
				global::UICamera.Cursor.Buttons.LeftValue.ClickNotification = value;
			}
		}

		// Token: 0x17000EEE RID: 3822
		// (get) Token: 0x0600507B RID: 20603 RVA: 0x0013A73C File Offset: 0x0013893C
		public global::UnityEngine.Vector2 pos
		{
			get
			{
				return (global::UICamera.Cursor.CurrentButton != null) ? (global::UICamera.Cursor.CurrentButton.Point + global::UICamera.Cursor.CurrentButton.TotalDelta) : global::UICamera.Cursor.Current.Mouse.Point;
			}
		}

		// Token: 0x17000EEF RID: 3823
		// (get) Token: 0x0600507C RID: 20604 RVA: 0x0013A794 File Offset: 0x00138994
		public global::UnityEngine.Vector2 delta
		{
			get
			{
				return global::UICamera.Cursor.FrameDelta;
			}
		}

		// Token: 0x17000EF0 RID: 3824
		// (get) Token: 0x0600507D RID: 20605 RVA: 0x0013A7A0 File Offset: 0x001389A0
		public global::UnityEngine.Vector2 totalDelta
		{
			get
			{
				return global::UICamera.Cursor.Buttons.LeftValue.TotalDelta;
			}
		}

		// Token: 0x0600507E RID: 20606 RVA: 0x0013A7B8 File Offset: 0x001389B8
		public override bool Equals(object obj)
		{
			return false;
		}

		// Token: 0x0600507F RID: 20607 RVA: 0x0013A7BC File Offset: 0x001389BC
		public override int GetHashCode()
		{
			return -1;
		}

		// Token: 0x06005080 RID: 20608 RVA: 0x0013A7C0 File Offset: 0x001389C0
		public override string ToString()
		{
			return string.Format("[BackwardsCompatabilitySupport: clickNotification={0}, pos={1}, delta={2}, totalDelta={3}]", new object[]
			{
				this.clickNotification,
				this.pos,
				this.delta,
				this.totalDelta
			});
		}

		// Token: 0x06005081 RID: 20609 RVA: 0x0013A818 File Offset: 0x00138A18
		public static bool operator ==(global::UICamera.BackwardsCompatabilitySupport b, bool? s)
		{
			return global::UICamera.Cursor.Current.Valid == (s != null);
		}

		// Token: 0x06005082 RID: 20610 RVA: 0x0013A834 File Offset: 0x00138A34
		public static bool operator !=(global::UICamera.BackwardsCompatabilitySupport b, bool? s)
		{
			return global::UICamera.Cursor.Current.Valid != (s != null);
		}
	}

	// Token: 0x02000939 RID: 2361
	public enum ClickNotification
	{
		// Token: 0x04002D16 RID: 11542
		None,
		// Token: 0x04002D17 RID: 11543
		Always,
		// Token: 0x04002D18 RID: 11544
		BasedOnDelta
	}

	// Token: 0x0200093A RID: 2362
	private class Highlighted
	{
		// Token: 0x06005083 RID: 20611 RVA: 0x0013A854 File Offset: 0x00138A54
		public Highlighted()
		{
		}

		// Token: 0x04002D19 RID: 11545
		public global::UnityEngine.GameObject go;

		// Token: 0x04002D1A RID: 11546
		public int counter;
	}

	// Token: 0x0200093B RID: 2363
	private struct RaycastCheckWork
	{
		// Token: 0x06005084 RID: 20612 RVA: 0x0013A85C File Offset: 0x00138A5C
		public bool Check()
		{
			global::UIPanel uipanel = global::UIPanel.Find(this.hit.collider.transform, false);
			if (!uipanel)
			{
				return true;
			}
			if (uipanel.enabled && (uipanel.clipping == global::UIDrawCall.Clipping.None || global::UICamera.CheckRayEnterClippingRect(this.ray, uipanel.transform, uipanel.clipRange)))
			{
				return true;
			}
			global::UnityEngine.Collider collider = this.hit.collider;
			bool result;
			try
			{
				collider.enabled = false;
				if (global::UnityEngine.Physics.Raycast(this.ray, ref this.hit, this.dist, this.mask))
				{
					result = this.Check();
				}
				else
				{
					result = false;
				}
			}
			finally
			{
				collider.enabled = true;
			}
			return result;
		}

		// Token: 0x04002D1B RID: 11547
		public global::UnityEngine.Ray ray;

		// Token: 0x04002D1C RID: 11548
		public global::UnityEngine.RaycastHit hit;

		// Token: 0x04002D1D RID: 11549
		public float dist;

		// Token: 0x04002D1E RID: 11550
		public int mask;
	}

	// Token: 0x0200093C RID: 2364
	private class CamSorter : global::System.Collections.Generic.Comparer<byte>
	{
		// Token: 0x06005085 RID: 20613 RVA: 0x0013A934 File Offset: 0x00138B34
		public CamSorter()
		{
		}

		// Token: 0x06005086 RID: 20614 RVA: 0x0013A93C File Offset: 0x00138B3C
		public override int Compare(byte a, byte b)
		{
			return global::UICamera.mList[(int)b].cachedCamera.depth.CompareTo(global::UICamera.mList[(int)a].cachedCamera.depth);
		}
	}
}
