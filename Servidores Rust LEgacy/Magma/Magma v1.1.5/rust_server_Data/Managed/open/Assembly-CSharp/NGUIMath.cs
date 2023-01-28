using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020008E5 RID: 2277
public static class NGUIMath
{
	// Token: 0x06004DFE RID: 19966 RVA: 0x0012B314 File Offset: 0x00129514
	public static float WrapAngle(float angle)
	{
		while (angle > 180f)
		{
			angle -= 360f;
		}
		while (angle < -180f)
		{
			angle += 360f;
		}
		return angle;
	}

	// Token: 0x06004DFF RID: 19967 RVA: 0x0012B34C File Offset: 0x0012954C
	public static int HexToDecimal(char ch)
	{
		switch (ch)
		{
		case '0':
			return 0;
		case '1':
			return 1;
		case '2':
			return 2;
		case '3':
			return 3;
		case '4':
			return 4;
		case '5':
			return 5;
		case '6':
			return 6;
		case '7':
			return 7;
		case '8':
			return 8;
		case '9':
			return 9;
		default:
			switch (ch)
			{
			case 'a':
				break;
			case 'b':
				return 0xB;
			case 'c':
				return 0xC;
			case 'd':
				return 0xD;
			case 'e':
				return 0xE;
			case 'f':
				return 0xF;
			default:
				return 0xF;
			}
			break;
		case 'A':
			break;
		case 'B':
			return 0xB;
		case 'C':
			return 0xC;
		case 'D':
			return 0xD;
		case 'E':
			return 0xE;
		case 'F':
			return 0xF;
		}
		return 0xA;
	}

	// Token: 0x06004E00 RID: 19968 RVA: 0x0012B410 File Offset: 0x00129610
	public static int ColorToInt(global::UnityEngine.Color c)
	{
		int num = 0;
		num |= global::UnityEngine.Mathf.RoundToInt(c.r * 255f) << 0x18;
		num |= global::UnityEngine.Mathf.RoundToInt(c.g * 255f) << 0x10;
		num |= global::UnityEngine.Mathf.RoundToInt(c.b * 255f) << 8;
		return num | global::UnityEngine.Mathf.RoundToInt(c.a * 255f);
	}

	// Token: 0x06004E01 RID: 19969 RVA: 0x0012B47C File Offset: 0x0012967C
	public static global::UnityEngine.Color IntToColor(int val)
	{
		float num = 0.003921569f;
		global::UnityEngine.Color black = global::UnityEngine.Color.black;
		black.r = num * (float)(val >> 0x18 & 0xFF);
		black.g = num * (float)(val >> 0x10 & 0xFF);
		black.b = num * (float)(val >> 8 & 0xFF);
		black.a = num * (float)(val & 0xFF);
		return black;
	}

	// Token: 0x06004E02 RID: 19970 RVA: 0x0012B4E4 File Offset: 0x001296E4
	public static string IntToBinary(int val, int bits)
	{
		string text = string.Empty;
		int i = bits;
		while (i > 0)
		{
			if (i == 8 || i == 0x10 || i == 0x18)
			{
				text += " ";
			}
			text += (((val & 1 << --i) == 0) ? '0' : '1');
		}
		return text;
	}

	// Token: 0x06004E03 RID: 19971 RVA: 0x0012B554 File Offset: 0x00129754
	public static global::UnityEngine.Color HexToColor(uint val)
	{
		return global::NGUIMath.IntToColor((int)val);
	}

	// Token: 0x06004E04 RID: 19972 RVA: 0x0012B55C File Offset: 0x0012975C
	public static global::UnityEngine.Rect ConvertToTexCoords(global::UnityEngine.Rect rect, int width, int height)
	{
		global::UnityEngine.Rect result = rect;
		if ((float)width != 0f && (float)height != 0f)
		{
			result.xMin = rect.xMin / (float)width;
			result.xMax = rect.xMax / (float)width;
			result.yMin = 1f - rect.yMax / (float)height;
			result.yMax = 1f - rect.yMin / (float)height;
		}
		return result;
	}

	// Token: 0x06004E05 RID: 19973 RVA: 0x0012B5D4 File Offset: 0x001297D4
	public static global::UnityEngine.Rect ConvertToPixels(global::UnityEngine.Rect rect, int width, int height, bool round)
	{
		global::UnityEngine.Rect result = rect;
		if (round)
		{
			result.xMin = (float)global::UnityEngine.Mathf.RoundToInt(rect.xMin * (float)width);
			result.xMax = (float)global::UnityEngine.Mathf.RoundToInt(rect.xMax * (float)width);
			result.yMin = (float)global::UnityEngine.Mathf.RoundToInt((1f - rect.yMax) * (float)height);
			result.yMax = (float)global::UnityEngine.Mathf.RoundToInt((1f - rect.yMin) * (float)height);
		}
		else
		{
			result.xMin = rect.xMin * (float)width;
			result.xMax = rect.xMax * (float)width;
			result.yMin = (1f - rect.yMax) * (float)height;
			result.yMax = (1f - rect.yMin) * (float)height;
		}
		return result;
	}

	// Token: 0x06004E06 RID: 19974 RVA: 0x0012B6A8 File Offset: 0x001298A8
	public static global::UnityEngine.Rect MakePixelPerfect(global::UnityEngine.Rect rect)
	{
		rect.xMin = (float)global::UnityEngine.Mathf.RoundToInt(rect.xMin);
		rect.yMin = (float)global::UnityEngine.Mathf.RoundToInt(rect.yMin);
		rect.xMax = (float)global::UnityEngine.Mathf.RoundToInt(rect.xMax);
		rect.yMax = (float)global::UnityEngine.Mathf.RoundToInt(rect.yMax);
		return rect;
	}

	// Token: 0x06004E07 RID: 19975 RVA: 0x0012B708 File Offset: 0x00129908
	public static global::UnityEngine.Rect MakePixelPerfect(global::UnityEngine.Rect rect, int width, int height)
	{
		rect = global::NGUIMath.ConvertToPixels(rect, width, height, true);
		rect.xMin = (float)global::UnityEngine.Mathf.RoundToInt(rect.xMin);
		rect.yMin = (float)global::UnityEngine.Mathf.RoundToInt(rect.yMin);
		rect.xMax = (float)global::UnityEngine.Mathf.RoundToInt(rect.xMax);
		rect.yMax = (float)global::UnityEngine.Mathf.RoundToInt(rect.yMax);
		return global::NGUIMath.ConvertToTexCoords(rect, width, height);
	}

	// Token: 0x06004E08 RID: 19976 RVA: 0x0012B778 File Offset: 0x00129978
	public static global::UnityEngine.Vector3 ApplyHalfPixelOffset(global::UnityEngine.Vector3 pos)
	{
		global::UnityEngine.RuntimePlatform platform = global::UnityEngine.Application.platform;
		if (platform == 2 || platform == 5 || platform == 7)
		{
			pos.x -= 0.5f;
			pos.y += 0.5f;
		}
		return pos;
	}

	// Token: 0x06004E09 RID: 19977 RVA: 0x0012B7CC File Offset: 0x001299CC
	public static global::UnityEngine.Vector3 ApplyHalfPixelOffset(global::UnityEngine.Vector3 pos, global::UnityEngine.Vector3 scale)
	{
		global::UnityEngine.RuntimePlatform platform = global::UnityEngine.Application.platform;
		if (platform == 2 || platform == 5 || platform == 7)
		{
			if (global::UnityEngine.Mathf.RoundToInt(scale.x) == global::UnityEngine.Mathf.RoundToInt(scale.x * 0.5f) * 2)
			{
				pos.x -= 0.5f;
			}
			if (global::UnityEngine.Mathf.RoundToInt(scale.y) == global::UnityEngine.Mathf.RoundToInt(scale.y * 0.5f) * 2)
			{
				pos.y += 0.5f;
			}
		}
		return pos;
	}

	// Token: 0x06004E0A RID: 19978 RVA: 0x0012B868 File Offset: 0x00129A68
	public static global::UnityEngine.Vector2 ConstrainRect(global::UnityEngine.Vector2 minRect, global::UnityEngine.Vector2 maxRect, global::UnityEngine.Vector2 minArea, global::UnityEngine.Vector2 maxArea)
	{
		global::UnityEngine.Vector2 zero = global::UnityEngine.Vector2.zero;
		float num = maxRect.x - minRect.x;
		float num2 = maxRect.y - minRect.y;
		float num3 = maxArea.x - minArea.x;
		float num4 = maxArea.y - minArea.y;
		if (num > num3)
		{
			float num5 = num - num3;
			minArea.x -= num5;
			maxArea.x += num5;
		}
		if (num2 > num4)
		{
			float num6 = num2 - num4;
			minArea.y -= num6;
			maxArea.y += num6;
		}
		if (minRect.x < minArea.x)
		{
			zero.x += minArea.x - minRect.x;
		}
		if (maxRect.x > maxArea.x)
		{
			zero.x -= maxRect.x - maxArea.x;
		}
		if (minRect.y < minArea.y)
		{
			zero.y += minArea.y - minRect.y;
		}
		if (maxRect.y > maxArea.y)
		{
			zero.y -= maxRect.y - maxArea.y;
		}
		return zero;
	}

	// Token: 0x06004E0B RID: 19979 RVA: 0x0012B9D8 File Offset: 0x00129BD8
	public static global::AABBox CalculateAbsoluteWidgetBounds(global::UnityEngine.Transform trans)
	{
		global::AABBox result;
		using (global::NGUIMath.WidgetList widgetsInChildren = global::NGUIMath.GetWidgetsInChildren(trans))
		{
			if (widgetsInChildren.empty)
			{
				result = default(global::AABBox);
			}
			else
			{
				global::AABBox aabbox = default(global::AABBox);
				bool flag = true;
				foreach (global::UIWidget uiwidget in widgetsInChildren)
				{
					global::UnityEngine.Vector2 vector;
					global::UnityEngine.Vector2 vector2;
					uiwidget.GetPivotOffsetAndRelativeSize(out vector, out vector2);
					global::UnityEngine.Vector3 vector3;
					vector3.x = (vector.x + 0.5f) * vector2.x;
					vector3.y = (vector.y - 0.5f) * vector2.y;
					global::UnityEngine.Vector3 vector4;
					vector4.x = vector3.x + vector2.x * 0.5f;
					vector4.y = vector3.y + vector2.y * 0.5f;
					vector3.x -= vector2.x * 0.5f;
					vector3.y -= vector2.y * 0.5f;
					vector3.z = 0f;
					vector4.z = 0f;
					global::AABBox aabbox2 = new global::AABBox(ref vector3, ref vector4);
					global::UnityEngine.Matrix4x4 localToWorldMatrix = uiwidget.cachedTransform.localToWorldMatrix;
					global::AABBox aabbox3;
					aabbox2.TransformedAABB3x4(ref localToWorldMatrix, out aabbox3);
					if (flag)
					{
						aabbox = aabbox3;
						flag = false;
					}
					else
					{
						aabbox.Encapsulate(ref aabbox3);
					}
				}
				if (flag)
				{
					result = new global::AABBox(trans.position);
				}
				else
				{
					result = aabbox;
				}
			}
		}
		return result;
	}

	// Token: 0x06004E0C RID: 19980 RVA: 0x0012BBB8 File Offset: 0x00129DB8
	private static void FillWidgetListWithChildren(global::UnityEngine.Transform trans, ref global::NGUIMath.WidgetList list, ref bool madeList)
	{
		global::UIWidget component = trans.GetComponent<global::UIWidget>();
		if (component)
		{
			if (!madeList)
			{
				list = global::NGUIMath.WidgetList.Generate();
				madeList = true;
			}
			list.Add(component);
		}
		int childCount = trans.childCount;
		while (childCount-- > 0)
		{
			global::NGUIMath.FillWidgetListWithChildren(trans.GetChild(childCount), ref list, ref madeList);
		}
	}

	// Token: 0x06004E0D RID: 19981 RVA: 0x0012BC18 File Offset: 0x00129E18
	private static global::NGUIMath.WidgetList GetWidgetsInChildren(global::UnityEngine.Transform trans)
	{
		if (trans)
		{
			bool flag = false;
			global::NGUIMath.WidgetList result = null;
			global::NGUIMath.FillWidgetListWithChildren(trans, ref result, ref flag);
			if (flag)
			{
				return result;
			}
		}
		return global::NGUIMath.WidgetList.Empty;
	}

	// Token: 0x06004E0E RID: 19982 RVA: 0x0012BC4C File Offset: 0x00129E4C
	public static global::AABBox CalculateRelativeWidgetBounds(global::UnityEngine.Transform root, global::UnityEngine.Transform child)
	{
		global::AABBox result;
		using (global::NGUIMath.WidgetList widgetsInChildren = global::NGUIMath.GetWidgetsInChildren(child))
		{
			if (widgetsInChildren.empty)
			{
				result = default(global::AABBox);
			}
			else
			{
				bool flag = true;
				global::AABBox aabbox = default(global::AABBox);
				global::UnityEngine.Matrix4x4 worldToLocalMatrix = root.worldToLocalMatrix;
				foreach (global::UIWidget uiwidget in widgetsInChildren)
				{
					global::UnityEngine.Vector2 vector;
					global::UnityEngine.Vector2 vector2;
					uiwidget.GetPivotOffsetAndRelativeSize(out vector, out vector2);
					global::UnityEngine.Vector3 vector3;
					vector3.x = (vector.x + 0.5f) * vector2.x;
					vector3.y = (vector.x - 0.5f) * vector2.y;
					vector3.z = 0f;
					global::UnityEngine.Vector3 vector4;
					vector4.x = vector3.x + vector2.x * 0.5f;
					vector4.y = vector3.y + vector2.y * 0.5f;
					vector4.z = 0f;
					vector3.x -= vector2.x * 0.5f;
					vector3.y -= vector2.y * 0.5f;
					global::UnityEngine.Matrix4x4 matrix4x = worldToLocalMatrix * uiwidget.cachedTransform.localToWorldMatrix;
					global::AABBox aabbox2 = new global::AABBox(ref vector3, ref vector4);
					global::AABBox aabbox3;
					aabbox2.TransformedAABB3x4(ref matrix4x, out aabbox3);
					if (flag)
					{
						aabbox = aabbox3;
						flag = false;
					}
					else
					{
						aabbox.Encapsulate(ref aabbox3);
					}
				}
				result = aabbox;
			}
		}
		return result;
	}

	// Token: 0x06004E0F RID: 19983 RVA: 0x0012BE20 File Offset: 0x0012A020
	public static global::AABBox CalculateRelativeInnerBounds(global::UnityEngine.Transform root, global::UISlicedSprite sprite)
	{
		global::UnityEngine.Transform cachedTransform = sprite.cachedTransform;
		global::UnityEngine.Matrix4x4 matrix4x = root.worldToLocalMatrix * cachedTransform.localToWorldMatrix;
		global::UnityEngine.Vector2 vector;
		global::UnityEngine.Vector2 vector2;
		sprite.GetPivotOffsetAndRelativeSize(out vector, out vector2);
		float num = (vector.x + 0.5f) * vector2.x;
		float num2 = (vector.y - 0.5f) * vector2.y;
		vector2 *= 0.5f;
		global::UnityEngine.Vector3 localScale = cachedTransform.localScale;
		float x = localScale.x;
		float y = localScale.y;
		global::UnityEngine.Vector4 border = sprite.border;
		if (x != 0f)
		{
			border.x /= x;
			border.z /= x;
		}
		if (y != 0f)
		{
			border.y /= y;
			border.w /= y;
		}
		global::UnityEngine.Vector3 vector3;
		vector3.x = num - vector2.x + border.x;
		global::UnityEngine.Vector3 vector4;
		vector4.x = num + vector2.x - border.z;
		vector3.y = num2 - vector2.y + border.y;
		vector4.y = num2 + vector2.y - border.w;
		vector3.z = (vector4.z = 0f);
		global::AABBox aabbox = new global::AABBox(ref vector3, ref vector4);
		global::AABBox result;
		aabbox.TransformedAABB3x4(ref matrix4x, out result);
		return result;
	}

	// Token: 0x06004E10 RID: 19984 RVA: 0x0012BF98 File Offset: 0x0012A198
	public static global::AABBox CalculateRelativeInnerBounds(global::UnityEngine.Transform root, global::UISprite sprite)
	{
		if (sprite is global::UISlicedSprite)
		{
			return global::NGUIMath.CalculateRelativeInnerBounds(root, sprite as global::UISlicedSprite);
		}
		return global::NGUIMath.CalculateRelativeWidgetBounds(root, sprite.cachedTransform);
	}

	// Token: 0x06004E11 RID: 19985 RVA: 0x0012BFCC File Offset: 0x0012A1CC
	public static global::AABBox CalculateRelativeWidgetBounds(global::UnityEngine.Transform trans)
	{
		return global::NGUIMath.CalculateRelativeWidgetBounds(trans, trans);
	}

	// Token: 0x06004E12 RID: 19986 RVA: 0x0012BFD8 File Offset: 0x0012A1D8
	public static global::UnityEngine.Vector3 SpringDampen(ref global::UnityEngine.Vector3 velocity, float strength, float deltaTime)
	{
		if (global::UnityEngine.Mathf.Approximately(velocity.x, 0f) && global::UnityEngine.Mathf.Approximately(velocity.y, 0f) && global::UnityEngine.Mathf.Approximately(velocity.z, 0f))
		{
			velocity = global::UnityEngine.Vector3.zero;
			return global::UnityEngine.Vector3.zero;
		}
		float num = 1f - strength * 0.001f;
		int num2 = global::UnityEngine.Mathf.RoundToInt(deltaTime * 1000f);
		global::UnityEngine.Vector3 vector = global::UnityEngine.Vector3.zero;
		for (int i = 0; i < num2; i++)
		{
			vector += velocity * 0.06f;
			velocity *= num;
		}
		return vector;
	}

	// Token: 0x06004E13 RID: 19987 RVA: 0x0012C094 File Offset: 0x0012A294
	public static global::UnityEngine.Vector2 SpringDampen(ref global::UnityEngine.Vector2 velocity, float strength, float deltaTime)
	{
		float num = 1f - strength * 0.001f;
		int num2 = global::UnityEngine.Mathf.RoundToInt(deltaTime * 1000f);
		global::UnityEngine.Vector2 vector = global::UnityEngine.Vector2.zero;
		for (int i = 0; i < num2; i++)
		{
			vector += velocity * 0.06f;
			velocity *= num;
		}
		return vector;
	}

	// Token: 0x06004E14 RID: 19988 RVA: 0x0012C100 File Offset: 0x0012A300
	public static float SpringLerp(float strength, float deltaTime)
	{
		int num = global::UnityEngine.Mathf.RoundToInt(deltaTime * 1000f);
		deltaTime = 0.001f * strength;
		float num2 = 0f;
		for (int i = 0; i < num; i++)
		{
			num2 = global::UnityEngine.Mathf.Lerp(num2, 1f, deltaTime);
		}
		return num2;
	}

	// Token: 0x06004E15 RID: 19989 RVA: 0x0012C14C File Offset: 0x0012A34C
	public static float SpringLerp(float from, float to, float strength, float deltaTime)
	{
		int num = global::UnityEngine.Mathf.RoundToInt(deltaTime * 1000f);
		deltaTime = 0.001f * strength;
		for (int i = 0; i < num; i++)
		{
			from = global::UnityEngine.Mathf.Lerp(from, to, deltaTime);
		}
		return from;
	}

	// Token: 0x06004E16 RID: 19990 RVA: 0x0012C18C File Offset: 0x0012A38C
	public static global::UnityEngine.Vector2 SpringLerp(global::UnityEngine.Vector2 from, global::UnityEngine.Vector2 to, float strength, float deltaTime)
	{
		return global::UnityEngine.Vector2.Lerp(from, to, global::NGUIMath.SpringLerp(strength, deltaTime));
	}

	// Token: 0x06004E17 RID: 19991 RVA: 0x0012C19C File Offset: 0x0012A39C
	public static global::UnityEngine.Vector3 SpringLerp(global::UnityEngine.Vector3 from, global::UnityEngine.Vector3 to, float strength, float deltaTime)
	{
		return global::UnityEngine.Vector3.Lerp(from, to, global::NGUIMath.SpringLerp(strength, deltaTime));
	}

	// Token: 0x06004E18 RID: 19992 RVA: 0x0012C1AC File Offset: 0x0012A3AC
	public static global::UnityEngine.Quaternion SpringLerp(global::UnityEngine.Quaternion from, global::UnityEngine.Quaternion to, float strength, float deltaTime)
	{
		return global::UnityEngine.Quaternion.Slerp(from, to, global::NGUIMath.SpringLerp(strength, deltaTime));
	}

	// Token: 0x06004E19 RID: 19993 RVA: 0x0012C1BC File Offset: 0x0012A3BC
	public static float RotateTowards(float from, float to, float maxAngle)
	{
		float num = global::NGUIMath.WrapAngle(to - from);
		if (global::UnityEngine.Mathf.Abs(num) > maxAngle)
		{
			num = maxAngle * global::UnityEngine.Mathf.Sign(num);
		}
		return from + num;
	}

	// Token: 0x020008E6 RID: 2278
	private class WidgetList : global::System.Collections.Generic.List<global::UIWidget>, global::System.IDisposable
	{
		// Token: 0x06004E1A RID: 19994 RVA: 0x0012C1EC File Offset: 0x0012A3EC
		private WidgetList(bool staticEmpty)
		{
			this.staticEmpty = staticEmpty;
		}

		// Token: 0x06004E1B RID: 19995 RVA: 0x0012C1FC File Offset: 0x0012A3FC
		// Note: this type is marked as 'beforefieldinit'.
		static WidgetList()
		{
		}

		// Token: 0x17000E7A RID: 3706
		// (get) Token: 0x06004E1C RID: 19996 RVA: 0x0012C214 File Offset: 0x0012A414
		public bool empty
		{
			get
			{
				return this.staticEmpty;
			}
		}

		// Token: 0x06004E1D RID: 19997 RVA: 0x0012C21C File Offset: 0x0012A41C
		public static global::NGUIMath.WidgetList Generate()
		{
			if (global::NGUIMath.WidgetList.tempWidgetListsSize == 0)
			{
				return new global::NGUIMath.WidgetList(false);
			}
			global::NGUIMath.WidgetList widgetList = global::NGUIMath.WidgetList.tempWidgetLists.Dequeue();
			widgetList.disposed = false;
			global::NGUIMath.WidgetList.tempWidgetListsSize--;
			return widgetList;
		}

		// Token: 0x06004E1E RID: 19998 RVA: 0x0012C25C File Offset: 0x0012A45C
		public new void Add(global::UIWidget widget)
		{
			if (this.staticEmpty)
			{
				throw new global::System.InvalidOperationException();
			}
			base.Add(widget);
		}

		// Token: 0x06004E1F RID: 19999 RVA: 0x0012C278 File Offset: 0x0012A478
		public void Dispose()
		{
			if (!this.disposed && !this.staticEmpty)
			{
				this.Clear();
				global::NGUIMath.WidgetList.tempWidgetLists.Enqueue(this);
				global::NGUIMath.WidgetList.tempWidgetListsSize++;
				this.disposed = true;
			}
		}

		// Token: 0x04002B07 RID: 11015
		private readonly bool staticEmpty;

		// Token: 0x04002B08 RID: 11016
		private bool disposed;

		// Token: 0x04002B09 RID: 11017
		private static int tempWidgetListsSize;

		// Token: 0x04002B0A RID: 11018
		private static global::System.Collections.Generic.Queue<global::NGUIMath.WidgetList> tempWidgetLists = new global::System.Collections.Generic.Queue<global::NGUIMath.WidgetList>();

		// Token: 0x04002B0B RID: 11019
		public static readonly global::NGUIMath.WidgetList Empty = new global::NGUIMath.WidgetList(true);
	}
}
