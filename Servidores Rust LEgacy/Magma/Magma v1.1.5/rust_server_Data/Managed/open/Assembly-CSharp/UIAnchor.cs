using System;
using UnityEngine;

// Token: 0x02000919 RID: 2329
[global::UnityEngine.AddComponentMenu("NGUI/UI/Anchor")]
[global::UnityEngine.ExecuteInEditMode]
public class UIAnchor : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06004F9F RID: 20383 RVA: 0x00135540 File Offset: 0x00133740
	public UIAnchor()
	{
	}

	// Token: 0x17000EAF RID: 3759
	// (get) Token: 0x06004FA0 RID: 20384 RVA: 0x00135564 File Offset: 0x00133764
	protected global::UnityEngine.Transform mTrans
	{
		get
		{
			if (!this.mTransGot)
			{
				this.__mTrans = base.transform;
				this.mTransGot = true;
			}
			return this.__mTrans;
		}
	}

	// Token: 0x06004FA1 RID: 20385 RVA: 0x00135598 File Offset: 0x00133798
	private void OnEnable()
	{
		if (!this.uiCamera)
		{
			this.uiCamera = global::NGUITools.FindCameraForLayer(base.gameObject.layer);
		}
	}

	// Token: 0x06004FA2 RID: 20386 RVA: 0x001355CC File Offset: 0x001337CC
	public static void ScreenOrigin(global::UIAnchor.Side side, float xMin, float xMax, float yMin, float yMax, out float x, out float y)
	{
		switch (side)
		{
		case global::UIAnchor.Side.BottomLeft:
			x = xMin;
			y = yMin;
			break;
		case global::UIAnchor.Side.Left:
			x = xMin;
			y = (yMin + yMax) / 2f;
			break;
		case global::UIAnchor.Side.TopLeft:
			x = xMin;
			y = yMax;
			break;
		case global::UIAnchor.Side.Top:
			x = (xMin + xMax) / 2f;
			y = yMax;
			break;
		case global::UIAnchor.Side.TopRight:
			x = xMax;
			y = yMax;
			break;
		case global::UIAnchor.Side.Right:
			x = xMax;
			y = (yMin + yMax) / 2f;
			break;
		case global::UIAnchor.Side.BottomRight:
			x = xMax;
			y = yMin;
			break;
		case global::UIAnchor.Side.Bottom:
			x = (xMin + xMax) / 2f;
			y = yMin;
			break;
		case global::UIAnchor.Side.Center:
			x = (xMin + xMax) / 2f;
			y = (yMin + yMax) / 2f;
			break;
		default:
			throw new global::System.ArgumentOutOfRangeException();
		}
	}

	// Token: 0x06004FA3 RID: 20387 RVA: 0x001356BC File Offset: 0x001338BC
	public static void ScreenOrigin(global::UIAnchor.Side side, float xMin, float xMax, float yMin, float yMax, float relativeOffsetX, float relativeOffsetY, out float x, out float y)
	{
		float num;
		float num2;
		global::UIAnchor.ScreenOrigin(side, xMin, xMax, yMin, yMax, out num, out num2);
		x = num + relativeOffsetX * (xMax - xMin);
		y = num2 + relativeOffsetY * (yMax - yMin);
	}

	// Token: 0x06004FA4 RID: 20388 RVA: 0x001356F0 File Offset: 0x001338F0
	public static void ScreenOrigin(global::UIAnchor.Side side, float xMin, float xMax, float yMin, float yMax, float relativeOffsetX, float relativeOffsetY, global::UIAnchor.Flags flags, out float x, out float y)
	{
		switch ((byte)(flags & (global::UIAnchor.Flags.CameraIsOrthographic | global::UIAnchor.Flags.HalfPixelOffset)))
		{
		case 1:
		{
			float num;
			float num2;
			global::UIAnchor.ScreenOrigin(side, xMin, xMax, yMin, yMax, relativeOffsetX, relativeOffsetY, out num, out num2);
			x = global::UnityEngine.Mathf.Round(num);
			y = global::UnityEngine.Mathf.Round(num2);
			return;
		}
		case 3:
		{
			float num3;
			float num4;
			global::UIAnchor.ScreenOrigin(side, xMin, xMax, yMin, yMax, relativeOffsetX, relativeOffsetY, out num3, out num4);
			x = global::UnityEngine.Mathf.Round(num3) - 0.5f;
			y = global::UnityEngine.Mathf.Round(num4) + 0.5f;
			return;
		}
		}
		global::UIAnchor.ScreenOrigin(side, xMin, xMax, yMin, yMax, relativeOffsetX, relativeOffsetY, out x, out y);
	}

	// Token: 0x06004FA5 RID: 20389 RVA: 0x00135798 File Offset: 0x00133998
	public static void ScreenOrigin(global::UIAnchor.Side side, float xMin, float xMax, float yMin, float yMax, global::UIAnchor.Flags flags, out float x, out float y)
	{
		switch ((byte)(flags & ((!global::UIAnchor.Info.isWindows) ? global::UIAnchor.Flags.CameraIsOrthographic : (global::UIAnchor.Flags.CameraIsOrthographic | global::UIAnchor.Flags.HalfPixelOffset))))
		{
		case 1:
		{
			float num;
			float num2;
			global::UIAnchor.ScreenOrigin(side, xMin, xMax, yMin, yMax, out num, out num2);
			x = global::UnityEngine.Mathf.Round(num);
			y = global::UnityEngine.Mathf.Round(num2);
			return;
		}
		case 3:
		{
			float num3;
			float num4;
			global::UIAnchor.ScreenOrigin(side, xMin, xMax, yMin, yMax, out num3, out num4);
			x = global::UnityEngine.Mathf.Round(num3) - 0.5f;
			y = global::UnityEngine.Mathf.Round(num4) + 0.5f;
			return;
		}
		}
		global::UIAnchor.ScreenOrigin(side, xMin, xMax, yMin, yMax, out x, out y);
	}

	// Token: 0x06004FA6 RID: 20390 RVA: 0x00135844 File Offset: 0x00133A44
	public static global::UnityEngine.Vector3 WorldOrigin(global::UnityEngine.Camera camera, global::UIAnchor.Side side, float depthOffset, float relativeOffsetX, float relativeOffsetY, bool halfPixel)
	{
		global::UnityEngine.Vector3 vector;
		vector.z = depthOffset;
		global::UnityEngine.Rect pixelRect = camera.pixelRect;
		float xMin = pixelRect.xMin;
		float xMax = pixelRect.xMax;
		float yMin = pixelRect.yMin;
		float yMax = pixelRect.yMax;
		global::UIAnchor.ScreenOrigin(side, xMin, xMax, yMin, yMax, relativeOffsetX, relativeOffsetY, (!camera.isOrthoGraphic) ? ((!halfPixel) ? ((global::UIAnchor.Flags)0) : global::UIAnchor.Flags.HalfPixelOffset) : ((!halfPixel) ? global::UIAnchor.Flags.CameraIsOrthographic : (global::UIAnchor.Flags.CameraIsOrthographic | global::UIAnchor.Flags.HalfPixelOffset)), out vector.x, out vector.y);
		return camera.ScreenToWorldPoint(vector);
	}

	// Token: 0x06004FA7 RID: 20391 RVA: 0x001358D4 File Offset: 0x00133AD4
	public static global::UnityEngine.Vector3 WorldOrigin(global::UnityEngine.Camera camera, global::UIAnchor.Side side, float relativeOffsetX, float relativeOffsetY, bool halfPixel)
	{
		global::UnityEngine.Vector3 vector;
		vector.z = 0f;
		global::UnityEngine.Rect pixelRect = camera.pixelRect;
		float xMin = pixelRect.xMin;
		float xMax = pixelRect.xMax;
		float yMin = pixelRect.yMin;
		float yMax = pixelRect.yMax;
		global::UIAnchor.ScreenOrigin(side, xMin, xMax, yMin, yMax, relativeOffsetX, relativeOffsetY, (!camera.isOrthoGraphic) ? ((!halfPixel) ? ((global::UIAnchor.Flags)0) : global::UIAnchor.Flags.HalfPixelOffset) : ((!halfPixel) ? global::UIAnchor.Flags.CameraIsOrthographic : (global::UIAnchor.Flags.CameraIsOrthographic | global::UIAnchor.Flags.HalfPixelOffset)), out vector.x, out vector.y);
		return camera.ScreenToWorldPoint(vector);
	}

	// Token: 0x06004FA8 RID: 20392 RVA: 0x00135964 File Offset: 0x00133B64
	public static global::UnityEngine.Vector3 WorldOrigin(global::UnityEngine.Camera camera, global::UIAnchor.Side side, float depthOffset, bool halfPixel)
	{
		global::UnityEngine.Vector3 vector;
		vector.z = depthOffset;
		global::UnityEngine.Rect pixelRect = camera.pixelRect;
		float xMin = pixelRect.xMin;
		float xMax = pixelRect.xMax;
		float yMin = pixelRect.yMin;
		float yMax = pixelRect.yMax;
		global::UIAnchor.ScreenOrigin(side, xMin, xMax, yMin, yMax, (!camera.isOrthoGraphic) ? ((!halfPixel) ? ((global::UIAnchor.Flags)0) : global::UIAnchor.Flags.HalfPixelOffset) : ((!halfPixel) ? global::UIAnchor.Flags.CameraIsOrthographic : (global::UIAnchor.Flags.CameraIsOrthographic | global::UIAnchor.Flags.HalfPixelOffset)), out vector.x, out vector.y);
		return camera.ScreenToWorldPoint(vector);
	}

	// Token: 0x06004FA9 RID: 20393 RVA: 0x001359EC File Offset: 0x00133BEC
	public static global::UnityEngine.Vector3 WorldOrigin(global::UnityEngine.Camera camera, global::UIAnchor.Side side, bool halfPixel)
	{
		global::UnityEngine.Vector3 vector;
		vector.z = 0f;
		global::UnityEngine.Rect pixelRect = camera.pixelRect;
		float xMin = pixelRect.xMin;
		float xMax = pixelRect.xMax;
		float yMin = pixelRect.yMin;
		float yMax = pixelRect.yMax;
		global::UIAnchor.ScreenOrigin(side, xMin, xMax, yMin, yMax, (!camera.isOrthoGraphic) ? ((!halfPixel) ? ((global::UIAnchor.Flags)0) : global::UIAnchor.Flags.HalfPixelOffset) : ((!halfPixel) ? global::UIAnchor.Flags.CameraIsOrthographic : (global::UIAnchor.Flags.CameraIsOrthographic | global::UIAnchor.Flags.HalfPixelOffset)), out vector.x, out vector.y);
		return camera.ScreenToWorldPoint(vector);
	}

	// Token: 0x06004FAA RID: 20394 RVA: 0x00135A78 File Offset: 0x00133C78
	public static global::UnityEngine.Vector3 WorldOrigin(global::UnityEngine.Camera camera, global::UIAnchor.Side side, global::UnityEngine.RectOffset offset, float depthOffset, float relativeOffsetX, float relativeOffsetY, bool halfPixel)
	{
		global::UnityEngine.Vector3 vector;
		vector.z = depthOffset;
		global::UnityEngine.Rect rect = offset.Add(camera.pixelRect);
		float xMin = rect.xMin;
		float xMax = rect.xMax;
		float yMin = rect.yMin;
		float yMax = rect.yMax;
		global::UIAnchor.ScreenOrigin(side, xMin, xMax, yMin, yMax, relativeOffsetX, relativeOffsetY, (!camera.isOrthoGraphic) ? ((!halfPixel) ? ((global::UIAnchor.Flags)0) : global::UIAnchor.Flags.HalfPixelOffset) : ((!halfPixel) ? global::UIAnchor.Flags.CameraIsOrthographic : (global::UIAnchor.Flags.CameraIsOrthographic | global::UIAnchor.Flags.HalfPixelOffset)), out vector.x, out vector.y);
		return camera.ScreenToWorldPoint(vector);
	}

	// Token: 0x06004FAB RID: 20395 RVA: 0x00135B0C File Offset: 0x00133D0C
	public static global::UnityEngine.Vector3 WorldOrigin(global::UnityEngine.Camera camera, global::UIAnchor.Side side, global::UnityEngine.RectOffset offset, float relativeOffsetX, float relativeOffsetY, bool halfPixel)
	{
		global::UnityEngine.Vector3 vector;
		vector.z = 0f;
		global::UnityEngine.Rect rect = offset.Add(camera.pixelRect);
		float xMin = rect.xMin;
		float xMax = rect.xMax;
		float yMin = rect.yMin;
		float yMax = rect.yMax;
		global::UIAnchor.ScreenOrigin(side, xMin, xMax, yMin, yMax, relativeOffsetX, relativeOffsetY, (!camera.isOrthoGraphic) ? ((!halfPixel) ? ((global::UIAnchor.Flags)0) : global::UIAnchor.Flags.HalfPixelOffset) : ((!halfPixel) ? global::UIAnchor.Flags.CameraIsOrthographic : (global::UIAnchor.Flags.CameraIsOrthographic | global::UIAnchor.Flags.HalfPixelOffset)), out vector.x, out vector.y);
		return camera.ScreenToWorldPoint(vector);
	}

	// Token: 0x06004FAC RID: 20396 RVA: 0x00135BA4 File Offset: 0x00133DA4
	public static global::UnityEngine.Vector3 WorldOrigin(global::UnityEngine.Camera camera, global::UIAnchor.Side side, global::UnityEngine.RectOffset offset, float depthOffset, bool halfPixel)
	{
		global::UnityEngine.Vector3 vector;
		vector.z = depthOffset;
		global::UnityEngine.Rect rect = offset.Add(camera.pixelRect);
		float xMin = rect.xMin;
		float xMax = rect.xMax;
		float yMin = rect.yMin;
		float yMax = rect.yMax;
		global::UIAnchor.ScreenOrigin(side, xMin, xMax, yMin, yMax, (!camera.isOrthoGraphic) ? ((!halfPixel) ? ((global::UIAnchor.Flags)0) : global::UIAnchor.Flags.HalfPixelOffset) : ((!halfPixel) ? global::UIAnchor.Flags.CameraIsOrthographic : (global::UIAnchor.Flags.CameraIsOrthographic | global::UIAnchor.Flags.HalfPixelOffset)), out vector.x, out vector.y);
		return camera.ScreenToWorldPoint(vector);
	}

	// Token: 0x06004FAD RID: 20397 RVA: 0x00135C34 File Offset: 0x00133E34
	public static global::UnityEngine.Vector3 WorldOrigin(global::UnityEngine.Camera camera, global::UIAnchor.Side side, global::UnityEngine.RectOffset offset, bool halfPixel)
	{
		global::UnityEngine.Vector3 vector;
		vector.z = 0f;
		global::UnityEngine.Rect rect = offset.Add(camera.pixelRect);
		float xMin = rect.xMin;
		float xMax = rect.xMax;
		float yMin = rect.yMin;
		float yMax = rect.yMax;
		global::UIAnchor.ScreenOrigin(side, xMin, xMax, yMin, yMax, (!camera.isOrthoGraphic) ? ((!halfPixel) ? ((global::UIAnchor.Flags)0) : global::UIAnchor.Flags.HalfPixelOffset) : ((!halfPixel) ? global::UIAnchor.Flags.CameraIsOrthographic : (global::UIAnchor.Flags.CameraIsOrthographic | global::UIAnchor.Flags.HalfPixelOffset)), out vector.x, out vector.y);
		return camera.ScreenToWorldPoint(vector);
	}

	// Token: 0x06004FAE RID: 20398 RVA: 0x00135CC8 File Offset: 0x00133EC8
	protected void SetPosition(ref global::UnityEngine.Vector3 newPosition)
	{
		global::UnityEngine.Transform mTrans = this.mTrans;
		if (this.otherThingsMightMoveThis || !this.mOnce)
		{
			this.mLastPosition = mTrans.position;
			this.mOnce = true;
		}
		if (newPosition.x != this.mLastPosition.x || newPosition.y != this.mLastPosition.y || newPosition.z != this.mLastPosition.z)
		{
			mTrans.position = newPosition;
		}
	}

	// Token: 0x06004FAF RID: 20399 RVA: 0x00135D54 File Offset: 0x00133F54
	protected void Update()
	{
		if (this.uiCamera)
		{
			global::UnityEngine.Vector3 vector = global::UIAnchor.WorldOrigin(this.uiCamera, this.side, this.depthOffset, this.relativeOffset.x, this.relativeOffset.y, this.halfPixelOffset);
			this.SetPosition(ref vector);
		}
	}

	// Token: 0x04002C18 RID: 11288
	public global::UnityEngine.Camera uiCamera;

	// Token: 0x04002C19 RID: 11289
	public global::UIAnchor.Side side = global::UIAnchor.Side.Center;

	// Token: 0x04002C1A RID: 11290
	public bool halfPixelOffset = true;

	// Token: 0x04002C1B RID: 11291
	public bool otherThingsMightMoveThis;

	// Token: 0x04002C1C RID: 11292
	public float depthOffset;

	// Token: 0x04002C1D RID: 11293
	public global::UnityEngine.Vector2 relativeOffset = global::UnityEngine.Vector2.zero;

	// Token: 0x04002C1E RID: 11294
	[global::System.NonSerialized]
	private global::UnityEngine.Transform __mTrans;

	// Token: 0x04002C1F RID: 11295
	[global::System.NonSerialized]
	private bool mTransGot;

	// Token: 0x04002C20 RID: 11296
	[global::System.NonSerialized]
	private bool mOnce;

	// Token: 0x04002C21 RID: 11297
	[global::System.NonSerialized]
	private global::UnityEngine.Vector3 mLastPosition;

	// Token: 0x0200091A RID: 2330
	public enum Side
	{
		// Token: 0x04002C23 RID: 11299
		BottomLeft,
		// Token: 0x04002C24 RID: 11300
		Left,
		// Token: 0x04002C25 RID: 11301
		TopLeft,
		// Token: 0x04002C26 RID: 11302
		Top,
		// Token: 0x04002C27 RID: 11303
		TopRight,
		// Token: 0x04002C28 RID: 11304
		Right,
		// Token: 0x04002C29 RID: 11305
		BottomRight,
		// Token: 0x04002C2A RID: 11306
		Bottom,
		// Token: 0x04002C2B RID: 11307
		Center
	}

	// Token: 0x0200091B RID: 2331
	protected static class Info
	{
		// Token: 0x06004FB0 RID: 20400 RVA: 0x00135DB0 File Offset: 0x00133FB0
		static Info()
		{
			global::UnityEngine.RuntimePlatform platform = global::UnityEngine.Application.platform;
			global::UIAnchor.Info.isWindows = (platform == 2 || platform == 5 || platform == 7);
		}

		// Token: 0x04002C2C RID: 11308
		public static readonly bool isWindows;
	}

	// Token: 0x0200091C RID: 2332
	[global::System.Flags]
	public enum Flags : byte
	{
		// Token: 0x04002C2E RID: 11310
		CameraIsOrthographic = 1,
		// Token: 0x04002C2F RID: 11311
		HalfPixelOffset = 2
	}
}
