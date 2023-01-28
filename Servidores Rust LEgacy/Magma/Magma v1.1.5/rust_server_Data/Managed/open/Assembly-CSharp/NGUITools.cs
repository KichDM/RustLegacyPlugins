using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

// Token: 0x020008E7 RID: 2279
public static class NGUITools
{
	// Token: 0x06004E20 RID: 20000 RVA: 0x0012C2C0 File Offset: 0x0012A4C0
	// Note: this type is marked as 'beforefieldinit'.
	static NGUITools()
	{
	}

	// Token: 0x06004E21 RID: 20001 RVA: 0x0012C2F0 File Offset: 0x0012A4F0
	public static bool ZeroAlpha(float alpha)
	{
		return (alpha >= 0f) ? (alpha < 0.0019607844f) : (alpha > -0.0019607844f);
	}

	// Token: 0x17000E7B RID: 3707
	// (get) Token: 0x06004E22 RID: 20002 RVA: 0x0012C320 File Offset: 0x0012A520
	// (set) Token: 0x06004E23 RID: 20003 RVA: 0x0012C34C File Offset: 0x0012A54C
	public static float soundVolume
	{
		get
		{
			if (!global::NGUITools.mLoaded)
			{
				global::NGUITools.mLoaded = true;
				global::NGUITools.mGlobalVolume = global::UnityEngine.PlayerPrefs.GetFloat("Sound", 1f);
			}
			return global::NGUITools.mGlobalVolume;
		}
		set
		{
			if (global::NGUITools.mGlobalVolume != value)
			{
				global::NGUITools.mLoaded = true;
				global::NGUITools.mGlobalVolume = value;
				global::UnityEngine.PlayerPrefs.SetFloat("Sound", value);
			}
		}
	}

	// Token: 0x06004E24 RID: 20004 RVA: 0x0012C37C File Offset: 0x0012A57C
	public static global::UnityEngine.AudioSource PlaySound(global::UnityEngine.AudioClip clip)
	{
		return global::NGUITools.PlaySound(clip, 1f, 1f);
	}

	// Token: 0x06004E25 RID: 20005 RVA: 0x0012C390 File Offset: 0x0012A590
	public static global::UnityEngine.AudioSource PlaySound(global::UnityEngine.AudioClip clip, float volume)
	{
		return global::NGUITools.PlaySound(clip, volume, 1f);
	}

	// Token: 0x06004E26 RID: 20006 RVA: 0x0012C3A0 File Offset: 0x0012A5A0
	public static global::UnityEngine.AudioSource PlaySound(global::UnityEngine.AudioClip clip, float volume, float pitch)
	{
		volume *= global::NGUITools.soundVolume;
		if (clip != null && volume > 0.01f)
		{
			if (global::NGUITools.mListener == null)
			{
				global::NGUITools.mListener = (global::UnityEngine.Object.FindObjectOfType(typeof(global::UnityEngine.AudioListener)) as global::UnityEngine.AudioListener);
				if (global::NGUITools.mListener == null)
				{
					global::UnityEngine.Camera camera = global::UnityEngine.Camera.main;
					if (camera == null)
					{
						camera = (global::UnityEngine.Object.FindObjectOfType(typeof(global::UnityEngine.Camera)) as global::UnityEngine.Camera);
					}
					if (camera != null)
					{
						global::NGUITools.mListener = camera.gameObject.AddComponent<global::UnityEngine.AudioListener>();
					}
				}
			}
			if (global::NGUITools.mListener != null)
			{
				global::UnityEngine.AudioSource audioSource = global::NGUITools.mListener.audio;
				if (audioSource == null)
				{
					audioSource = global::NGUITools.mListener.gameObject.AddComponent<global::UnityEngine.AudioSource>();
				}
				audioSource.pitch = pitch;
				audioSource.PlayOneShot(clip, volume);
				return audioSource;
			}
		}
		return null;
	}

	// Token: 0x06004E27 RID: 20007 RVA: 0x0012C494 File Offset: 0x0012A694
	public static global::UnityEngine.WWW OpenURL(string url)
	{
		global::UnityEngine.WWW result = null;
		try
		{
			result = new global::UnityEngine.WWW(url);
		}
		catch (global::System.Exception ex)
		{
			global::UnityEngine.Debug.LogError(ex.Message);
		}
		return result;
	}

	// Token: 0x06004E28 RID: 20008 RVA: 0x0012C4E0 File Offset: 0x0012A6E0
	public static int RandomRange(int min, int max)
	{
		if (min == max)
		{
			return min;
		}
		return global::UnityEngine.Random.Range(min, max + 1);
	}

	// Token: 0x06004E29 RID: 20009 RVA: 0x0012C4F4 File Offset: 0x0012A6F4
	public static string GetHierarchy(global::UnityEngine.GameObject obj)
	{
		string text = obj.name;
		while (obj.transform.parent != null)
		{
			obj = obj.transform.parent.gameObject;
			text = obj.name + "/" + text;
		}
		return "\"" + text + "\"";
	}

	// Token: 0x06004E2A RID: 20010 RVA: 0x0012C558 File Offset: 0x0012A758
	public static global::UnityEngine.Color ParseColor(string text, int offset)
	{
		int num = global::NGUIMath.HexToDecimal(text[offset]) << 4 | global::NGUIMath.HexToDecimal(text[offset + 1]);
		int num2 = global::NGUIMath.HexToDecimal(text[offset + 2]) << 4 | global::NGUIMath.HexToDecimal(text[offset + 3]);
		int num3 = global::NGUIMath.HexToDecimal(text[offset + 4]) << 4 | global::NGUIMath.HexToDecimal(text[offset + 5]);
		float num4 = 0.003921569f;
		return new global::UnityEngine.Color(num4 * (float)num, num4 * (float)num2, num4 * (float)num3);
	}

	// Token: 0x06004E2B RID: 20011 RVA: 0x0012C5DC File Offset: 0x0012A7DC
	public static string EncodeColor(global::UnityEngine.Color c)
	{
		return (0xFFFFFF & global::NGUIMath.ColorToInt(c) >> 8).ToString("X6");
	}

	// Token: 0x06004E2C RID: 20012 RVA: 0x0012C604 File Offset: 0x0012A804
	public static string UnformattedString(string str)
	{
		int num = str.IndexOf("[»]");
		int num2 = str.IndexOf("[«]");
		if (num == -1)
		{
			if (num2 == -1)
			{
				return "[»]" + str + "[«]";
			}
			int num3 = 1;
			while (++num2 < str.Length)
			{
				num2 = str.IndexOf("[«]", num2);
				if (num2 == -1)
				{
					break;
				}
				num3++;
			}
			if (num3 == 1)
			{
				return "[»]" + "[»]" + str + "[«]";
			}
			global::System.Text.StringBuilder stringBuilder = new global::System.Text.StringBuilder();
			stringBuilder.Append("[»]");
			while (num3-- > 0)
			{
				stringBuilder.Append("[»]");
			}
			stringBuilder.Append(str);
			stringBuilder.Append("[«]");
			return stringBuilder.ToString();
		}
		else
		{
			if (num2 != -1)
			{
				global::System.Collections.Generic.List<int> list = new global::System.Collections.Generic.List<int>();
				global::System.Collections.Generic.List<bool> list2 = new global::System.Collections.Generic.List<bool>();
				list.Add(num);
				list.Add(num2);
				list2.Add(true);
				list2.Add(false);
				while (++num < str.Length)
				{
					num = str.IndexOf("[«]", num);
					if (num == -1)
					{
						break;
					}
					list.Add(num);
					list2.Add(true);
				}
				while (++num2 < str.Length)
				{
					num2 = str.IndexOf("[«]", num2);
					if (num2 == -1)
					{
						break;
					}
					list.Add(num2);
					list2.Add(false);
				}
				bool[] array = list2.ToArray();
				global::System.Array.Sort<int, bool>(list.ToArray(), array);
				int num4 = 0;
				int num5 = 0;
				for (int i = 0; i < array.Length; i++)
				{
					if (array[i])
					{
						num4++;
						while (++i < array.Length)
						{
							if (array[i])
							{
								num4++;
							}
							else if (--num4 == 0)
							{
								break;
							}
						}
					}
					else
					{
						num5++;
						while (++i < array.Length)
						{
							if (array[i])
							{
								if (--num5 == 0)
								{
									break;
								}
							}
							else
							{
								num5++;
							}
						}
					}
				}
				global::System.Text.StringBuilder stringBuilder2 = new global::System.Text.StringBuilder();
				stringBuilder2.Append("[»]");
				for (int j = 0; j < num5; j++)
				{
					stringBuilder2.Append("[»]");
				}
				stringBuilder2.Append(str);
				for (int k = 0; k < num4; k++)
				{
					stringBuilder2.Append("[«]");
				}
				stringBuilder2.Append("[«]");
				return stringBuilder2.ToString();
			}
			int num6 = 1;
			while (++num < str.Length)
			{
				num = str.IndexOf("[«]", num);
				if (num == -1)
				{
					break;
				}
				num6++;
			}
			if (num6 == 1)
			{
				return "[»]" + str + "[«]" + "[«]";
			}
			global::System.Text.StringBuilder stringBuilder3 = new global::System.Text.StringBuilder();
			stringBuilder3.Append("[»]");
			stringBuilder3.Append(str);
			while (num6-- > 0)
			{
				stringBuilder3.Append("[«]");
			}
			stringBuilder3.Append("[«]");
			return stringBuilder3.ToString();
		}
	}

	// Token: 0x06004E2D RID: 20013 RVA: 0x0012C97C File Offset: 0x0012AB7C
	public static int ParseSymbol(string text, int index, global::System.Collections.Generic.List<global::UnityEngine.Color> colors, ref int symbolSkipCount)
	{
		int length = text.Length;
		if (index + 2 < length)
		{
			if (text[index + 2] == ']')
			{
				if (text[index + 1] == '-')
				{
					if (symbolSkipCount == 0)
					{
						if (colors != null && colors.Count > 1)
						{
							colors.RemoveAt(colors.Count - 1);
						}
						return 3;
					}
				}
				else if (text[index + 1] == '»')
				{
					if (symbolSkipCount++ == 0)
					{
						return 3;
					}
				}
				else if (text[index + 1] == '«' && --symbolSkipCount == 0)
				{
					return 3;
				}
			}
			else if (index + 7 < length && text[index + 7] == ']' && symbolSkipCount == 0)
			{
				if (colors != null)
				{
					global::UnityEngine.Color item = global::NGUITools.ParseColor(text, index + 1);
					item.a = colors[colors.Count - 1].a;
					colors.Add(item);
				}
				return 8;
			}
		}
		return 0;
	}

	// Token: 0x06004E2E RID: 20014 RVA: 0x0012CA90 File Offset: 0x0012AC90
	public static string StripSymbols(string text)
	{
		if (text != null)
		{
			text = text.Replace("\\n", "\n");
			int num = 0;
			int i = 0;
			int length = text.Length;
			while (i < length)
			{
				char c = text[i];
				if (c == '[')
				{
					int num2 = global::NGUITools.ParseSymbol(text, i, null, ref num);
					if (num2 > 0)
					{
						text = text.Remove(i, num2);
						length = text.Length;
						continue;
					}
				}
				i++;
			}
		}
		return text;
	}

	// Token: 0x06004E2F RID: 20015 RVA: 0x0012CB0C File Offset: 0x0012AD0C
	public static T[] FindActive<T>() where T : global::UnityEngine.Component
	{
		return global::UnityEngine.Object.FindObjectsOfType(typeof(T)) as T[];
	}

	// Token: 0x06004E30 RID: 20016 RVA: 0x0012CB24 File Offset: 0x0012AD24
	public static global::UnityEngine.Camera FindCameraForLayer(int layer)
	{
		int num = 1 << layer;
		global::UnityEngine.Camera[] array = global::NGUITools.FindActive<global::UnityEngine.Camera>();
		int i = 0;
		int num2 = array.Length;
		while (i < num2)
		{
			global::UnityEngine.Camera camera = array[i];
			if ((camera.cullingMask & num) != 0)
			{
				return camera;
			}
			i++;
		}
		return null;
	}

	// Token: 0x06004E31 RID: 20017 RVA: 0x0012CB6C File Offset: 0x0012AD6C
	[global::System.Obsolete("Use AddWidgetHotSpot")]
	public static global::UnityEngine.BoxCollider AddWidgetCollider(global::UnityEngine.GameObject go)
	{
		if (go != null)
		{
			global::UnityEngine.Collider component = go.GetComponent<global::UnityEngine.Collider>();
			global::UnityEngine.BoxCollider boxCollider = component as global::UnityEngine.BoxCollider;
			if (boxCollider == null)
			{
				if (component != null)
				{
					if (global::UnityEngine.Application.isPlaying)
					{
						global::UnityEngine.Object.Destroy(component);
					}
					else
					{
						global::UnityEngine.Object.DestroyImmediate(component);
					}
				}
				boxCollider = go.AddComponent<global::UnityEngine.BoxCollider>();
			}
			int num = global::NGUITools.CalculateNextDepth(go);
			global::AABBox aabbox = global::NGUIMath.CalculateRelativeWidgetBounds(go.transform);
			boxCollider.isTrigger = true;
			boxCollider.center = aabbox.center + global::UnityEngine.Vector3.back * ((float)num * 0.25f);
			boxCollider.size = new global::UnityEngine.Vector3(aabbox.size.x, aabbox.size.y, 0f);
			return boxCollider;
		}
		return null;
	}

	// Token: 0x06004E32 RID: 20018 RVA: 0x0012CC40 File Offset: 0x0012AE40
	private static void ColliderDestroy(global::UnityEngine.Collider component)
	{
		if (global::UnityEngine.Application.isPlaying)
		{
			global::UnityEngine.Object.Destroy(component);
		}
		else
		{
			global::UnityEngine.Object.DestroyImmediate(component);
		}
	}

	// Token: 0x06004E33 RID: 20019 RVA: 0x0012CC60 File Offset: 0x0012AE60
	private static global::UIBoxHotSpot ColliderToHotSpotBox(global::UnityEngine.BoxCollider collider, bool nullChecked)
	{
		if (nullChecked || collider)
		{
			global::UnityEngine.Vector3 center = collider.center;
			global::UnityEngine.Vector3 size = collider.size;
			global::UnityEngine.GameObject gameObject = collider.gameObject;
			bool enabled = collider.enabled;
			global::NGUITools.ColliderDestroy(collider);
			global::UIBoxHotSpot uiboxHotSpot = gameObject.AddComponent<global::UIBoxHotSpot>();
			uiboxHotSpot.center = center;
			uiboxHotSpot.size = size;
			uiboxHotSpot.enabled = enabled;
			return uiboxHotSpot;
		}
		return null;
	}

	// Token: 0x06004E34 RID: 20020 RVA: 0x0012CCC4 File Offset: 0x0012AEC4
	public static global::UIBoxHotSpot ColliderToHotSpotBox(global::UnityEngine.BoxCollider collider)
	{
		return global::NGUITools.ColliderToHotSpotBox(collider, false);
	}

	// Token: 0x06004E35 RID: 20021 RVA: 0x0012CCD0 File Offset: 0x0012AED0
	private static global::UIRectHotSpot ColliderToHotSpotRect(global::UnityEngine.BoxCollider collider, bool nullChecked)
	{
		if (nullChecked || collider)
		{
			global::UnityEngine.Vector3 center = collider.center;
			global::UnityEngine.Vector2 size = collider.size;
			global::UnityEngine.GameObject gameObject = collider.gameObject;
			bool enabled = collider.enabled;
			global::NGUITools.ColliderDestroy(collider);
			global::UIRectHotSpot uirectHotSpot = gameObject.AddComponent<global::UIRectHotSpot>();
			uirectHotSpot.center = center;
			uirectHotSpot.size = size;
			uirectHotSpot.enabled = enabled;
			return uirectHotSpot;
		}
		return null;
	}

	// Token: 0x06004E36 RID: 20022 RVA: 0x0012CD3C File Offset: 0x0012AF3C
	public static global::UIRectHotSpot ColliderToHotSpotRect(global::UnityEngine.BoxCollider collider)
	{
		return global::NGUITools.ColliderToHotSpotRect(collider, false);
	}

	// Token: 0x06004E37 RID: 20023 RVA: 0x0012CD48 File Offset: 0x0012AF48
	private static global::UIHotSpot ColliderToHotSpot(global::UnityEngine.BoxCollider collider, bool nullChecked)
	{
		if (!nullChecked && !collider)
		{
			return null;
		}
		global::UnityEngine.Vector3 center = collider.center;
		global::UnityEngine.Vector3 size = collider.size;
		global::UnityEngine.GameObject gameObject = collider.gameObject;
		bool enabled = collider.enabled;
		global::NGUITools.ColliderDestroy(collider);
		if (size.z <= 0.001f)
		{
			global::UIRectHotSpot uirectHotSpot = gameObject.AddComponent<global::UIRectHotSpot>();
			uirectHotSpot.center = center;
			uirectHotSpot.size = size;
			uirectHotSpot.enabled = enabled;
			return uirectHotSpot;
		}
		global::UIBoxHotSpot uiboxHotSpot = gameObject.AddComponent<global::UIBoxHotSpot>();
		uiboxHotSpot.center = center;
		uiboxHotSpot.size = size;
		uiboxHotSpot.enabled = enabled;
		return uiboxHotSpot;
	}

	// Token: 0x06004E38 RID: 20024 RVA: 0x0012CDE8 File Offset: 0x0012AFE8
	public static global::UIHotSpot ColliderToHotSpot(global::UnityEngine.BoxCollider collider)
	{
		return global::NGUITools.ColliderToHotSpot(collider, false);
	}

	// Token: 0x06004E39 RID: 20025 RVA: 0x0012CDF4 File Offset: 0x0012AFF4
	private static global::UIHotSpot ColliderToHotSpot(global::UnityEngine.Collider collider, bool nullChecked)
	{
		if (!nullChecked && !collider)
		{
			return null;
		}
		if (collider is global::UnityEngine.BoxCollider)
		{
			return global::NGUITools.ColliderToHotSpot((global::UnityEngine.BoxCollider)collider);
		}
		if (collider is global::UnityEngine.SphereCollider)
		{
			return global::NGUITools.ColliderToHotSpot((global::UnityEngine.SphereCollider)collider);
		}
		if (collider is global::UnityEngine.TerrainCollider)
		{
			global::UnityEngine.Debug.Log("Sorry not going to convert a terrain collider.. that sounds destructive.", collider);
			return null;
		}
		global::UnityEngine.Bounds bounds = collider.bounds;
		global::UnityEngine.Matrix4x4 worldToLocalMatrix = collider.transform.worldToLocalMatrix;
		global::UnityEngine.Bounds bounds2;
		global::AABBox.Transform3x4(ref bounds, ref worldToLocalMatrix, out bounds2);
		bool enabled = collider.enabled;
		global::UnityEngine.GameObject gameObject = collider.gameObject;
		global::NGUITools.ColliderDestroy(collider);
		global::UnityEngine.Vector3 size = bounds2.size;
		if (size.z <= 0.001f)
		{
			global::UIRectHotSpot uirectHotSpot = gameObject.AddComponent<global::UIRectHotSpot>();
			uirectHotSpot.size = size;
			uirectHotSpot.center = bounds2.center;
			uirectHotSpot.enabled = enabled;
			return uirectHotSpot;
		}
		global::UIBoxHotSpot uiboxHotSpot = gameObject.AddComponent<global::UIBoxHotSpot>();
		uiboxHotSpot.size = size;
		uiboxHotSpot.center = bounds2.center;
		uiboxHotSpot.enabled = enabled;
		return uiboxHotSpot;
	}

	// Token: 0x06004E3A RID: 20026 RVA: 0x0012CF04 File Offset: 0x0012B104
	public static global::UIHotSpot ColliderToHotSpot(global::UnityEngine.Collider collider)
	{
		return global::NGUITools.ColliderToHotSpot(collider, false);
	}

	// Token: 0x06004E3B RID: 20027 RVA: 0x0012CF10 File Offset: 0x0012B110
	public static global::UIHotSpot AddWidgetHotSpot(global::UnityEngine.GameObject go)
	{
		if (!(go != null))
		{
			return null;
		}
		global::UnityEngine.Collider collider = go.collider;
		if (!collider)
		{
			global::UIHotSpot component = go.GetComponent<global::UIHotSpot>();
			int num;
			global::AABBox aabbox;
			if (component)
			{
				if (component.isRect)
				{
					global::UIRectHotSpot asRect = component.asRect;
					num = global::NGUITools.CalculateNextDepth(go);
					aabbox = global::NGUIMath.CalculateRelativeWidgetBounds(go.transform);
					asRect.size = aabbox.size;
					asRect.center = aabbox.center + global::UnityEngine.Vector3.back * ((float)num * 0.25f);
					return asRect;
				}
				if (global::UnityEngine.Application.isPlaying)
				{
					global::UnityEngine.Object.Destroy(component);
				}
				else
				{
					global::UnityEngine.Object.DestroyImmediate(component);
				}
			}
			num = global::NGUITools.CalculateNextDepth(go);
			aabbox = global::NGUIMath.CalculateRelativeWidgetBounds(go.transform);
			global::UIRectHotSpot uirectHotSpot = go.AddComponent<global::UIRectHotSpot>();
			uirectHotSpot.size = aabbox.size;
			uirectHotSpot.center = aabbox.center + global::UnityEngine.Vector3.back * ((float)num * 0.25f);
			return uirectHotSpot;
		}
		global::UIHotSpot uihotSpot = global::NGUITools.ColliderToHotSpot(collider, true);
		if (!uihotSpot)
		{
			return null;
		}
		return uihotSpot;
	}

	// Token: 0x06004E3C RID: 20028 RVA: 0x0012D044 File Offset: 0x0012B244
	[global::System.Obsolete("Use UIAtlas.replacement instead")]
	public static void ReplaceAtlas(global::UIAtlas before, global::UIAtlas after)
	{
		global::UISprite[] array = global::NGUITools.FindActive<global::UISprite>();
		int i = 0;
		int num = array.Length;
		while (i < num)
		{
			global::UISprite uisprite = array[i];
			if (uisprite.atlas == before)
			{
				uisprite.atlas = after;
			}
			i++;
		}
		global::UILabel[] array2 = global::NGUITools.FindActive<global::UILabel>();
		int j = 0;
		int num2 = array2.Length;
		while (j < num2)
		{
			global::UILabel uilabel = array2[j];
			if (uilabel.font != null && uilabel.font.atlas == before)
			{
				uilabel.font.atlas = after;
			}
			j++;
		}
	}

	// Token: 0x06004E3D RID: 20029 RVA: 0x0012D0EC File Offset: 0x0012B2EC
	[global::System.Obsolete("Use UIFont.replacement instead")]
	public static void ReplaceFont(global::UIFont before, global::UIFont after)
	{
		global::UILabel[] array = global::NGUITools.FindActive<global::UILabel>();
		int i = 0;
		int num = array.Length;
		while (i < num)
		{
			global::UILabel uilabel = array[i];
			if (uilabel.font == before)
			{
				uilabel.font = after;
			}
			i++;
		}
	}

	// Token: 0x06004E3E RID: 20030 RVA: 0x0012D134 File Offset: 0x0012B334
	public static string GetName<T>() where T : global::UnityEngine.Component
	{
		string text = typeof(T).ToString();
		if (text.StartsWith("UI"))
		{
			text = text.Substring(2);
		}
		else if (text.StartsWith("UnityEngine."))
		{
			text = text.Substring(0xC);
		}
		return text;
	}

	// Token: 0x06004E3F RID: 20031 RVA: 0x0012D188 File Offset: 0x0012B388
	public static global::UnityEngine.GameObject AddChild(global::UnityEngine.GameObject parent)
	{
		global::UnityEngine.GameObject gameObject = new global::UnityEngine.GameObject();
		if (parent != null)
		{
			global::UnityEngine.Transform transform = gameObject.transform;
			transform.parent = parent.transform;
			transform.localPosition = global::UnityEngine.Vector3.zero;
			transform.localRotation = global::UnityEngine.Quaternion.identity;
			transform.localScale = global::UnityEngine.Vector3.one;
			gameObject.layer = parent.layer;
		}
		return gameObject;
	}

	// Token: 0x06004E40 RID: 20032 RVA: 0x0012D1E8 File Offset: 0x0012B3E8
	public static global::UnityEngine.GameObject AddChild(global::UnityEngine.GameObject parent, global::UnityEngine.GameObject prefab)
	{
		global::UnityEngine.GameObject gameObject = global::UnityEngine.Object.Instantiate(prefab) as global::UnityEngine.GameObject;
		if (gameObject != null && parent != null)
		{
			global::UnityEngine.Transform transform = gameObject.transform;
			transform.parent = parent.transform;
			transform.localPosition = global::UnityEngine.Vector3.zero;
			transform.localRotation = global::UnityEngine.Quaternion.identity;
			transform.localScale = global::UnityEngine.Vector3.one;
			gameObject.layer = parent.layer;
		}
		return gameObject;
	}

	// Token: 0x06004E41 RID: 20033 RVA: 0x0012D25C File Offset: 0x0012B45C
	public static int CalculateNextDepth(global::UnityEngine.GameObject go)
	{
		int num = -1;
		global::UIWidget[] componentsInChildren = go.GetComponentsInChildren<global::UIWidget>();
		int i = 0;
		int num2 = componentsInChildren.Length;
		while (i < num2)
		{
			num = global::UnityEngine.Mathf.Max(num, componentsInChildren[i].depth);
			i++;
		}
		return num + 1;
	}

	// Token: 0x06004E42 RID: 20034 RVA: 0x0012D29C File Offset: 0x0012B49C
	public static T AddChild<T>(global::UnityEngine.GameObject parent) where T : global::UnityEngine.Component
	{
		global::UnityEngine.GameObject gameObject = global::NGUITools.AddChild(parent);
		gameObject.name = global::NGUITools.GetName<T>();
		return gameObject.AddComponent<T>();
	}

	// Token: 0x06004E43 RID: 20035 RVA: 0x0012D2C4 File Offset: 0x0012B4C4
	public static T AddWidget<T>(global::UnityEngine.GameObject go) where T : global::UIWidget
	{
		int depth = global::NGUITools.CalculateNextDepth(go);
		T result = global::NGUITools.AddChild<T>(go);
		result.depth = depth;
		global::UnityEngine.Transform transform = result.transform;
		transform.localPosition = global::UnityEngine.Vector3.zero;
		transform.localRotation = global::UnityEngine.Quaternion.identity;
		transform.localScale = new global::UnityEngine.Vector3(100f, 100f, 1f);
		result.gameObject.layer = go.layer;
		return result;
	}

	// Token: 0x06004E44 RID: 20036 RVA: 0x0012D344 File Offset: 0x0012B544
	public static global::UISprite AddSprite(global::UnityEngine.GameObject go, global::UIAtlas atlas, string spriteName)
	{
		global::UIAtlas.Sprite sprite = (!(atlas != null)) ? null : atlas.GetSprite(spriteName);
		global::UISprite uisprite = (sprite != null && !(sprite.inner == sprite.outer)) ? global::NGUITools.AddWidget<global::UISlicedSprite>(go) : global::NGUITools.AddWidget<global::UISprite>(go);
		uisprite.atlas = atlas;
		uisprite.spriteName = spriteName;
		return uisprite;
	}

	// Token: 0x06004E45 RID: 20037 RVA: 0x0012D3A8 File Offset: 0x0012B5A8
	public static T FindInParents<T>(global::UnityEngine.GameObject go) where T : global::UnityEngine.Component
	{
		if (go == null)
		{
			return (T)((object)null);
		}
		object obj = go.GetComponent<T>();
		if (obj == null)
		{
			global::UnityEngine.Transform parent = go.transform.parent;
			while (parent != null && obj == null)
			{
				obj = parent.gameObject.GetComponent<T>();
				parent = parent.parent;
			}
		}
		return (T)((object)obj);
	}

	// Token: 0x06004E46 RID: 20038 RVA: 0x0012D41C File Offset: 0x0012B61C
	public static void Destroy(global::UnityEngine.Object obj)
	{
		if (obj != null)
		{
			if (global::UnityEngine.Application.isPlaying)
			{
				global::UnityEngine.Object.Destroy(obj);
			}
			else
			{
				global::UnityEngine.Object.DestroyImmediate(obj);
			}
		}
	}

	// Token: 0x06004E47 RID: 20039 RVA: 0x0012D448 File Offset: 0x0012B648
	public static void DestroyImmediate(global::UnityEngine.Object obj)
	{
		if (obj != null)
		{
			if (global::UnityEngine.Application.isEditor)
			{
				global::UnityEngine.Object.DestroyImmediate(obj);
			}
			else
			{
				global::UnityEngine.Object.Destroy(obj);
			}
		}
	}

	// Token: 0x06004E48 RID: 20040 RVA: 0x0012D474 File Offset: 0x0012B674
	public static void Broadcast(string funcName)
	{
		global::UnityEngine.GameObject[] array = global::UnityEngine.Object.FindObjectsOfType(typeof(global::UnityEngine.GameObject)) as global::UnityEngine.GameObject[];
		int i = 0;
		int num = array.Length;
		while (i < num)
		{
			array[i].SendMessage(funcName, 1);
			i++;
		}
	}

	// Token: 0x06004E49 RID: 20041 RVA: 0x0012D4B8 File Offset: 0x0012B6B8
	public static void Broadcast(string funcName, object param)
	{
		global::UnityEngine.GameObject[] array = global::UnityEngine.Object.FindObjectsOfType(typeof(global::UnityEngine.GameObject)) as global::UnityEngine.GameObject[];
		int i = 0;
		int num = array.Length;
		while (i < num)
		{
			array[i].SendMessage(funcName, param, 1);
			i++;
		}
	}

	// Token: 0x06004E4A RID: 20042 RVA: 0x0012D4FC File Offset: 0x0012B6FC
	public static bool IsChild(global::UnityEngine.Transform parent, global::UnityEngine.Transform child)
	{
		if (parent == null || child == null)
		{
			return false;
		}
		while (child != null)
		{
			if (child == parent)
			{
				return true;
			}
			child = child.parent;
		}
		return false;
	}

	// Token: 0x06004E4B RID: 20043 RVA: 0x0012D54C File Offset: 0x0012B74C
	private static void Activate(global::UnityEngine.Transform t)
	{
		t.gameObject.SetActive(true);
	}

	// Token: 0x06004E4C RID: 20044 RVA: 0x0012D55C File Offset: 0x0012B75C
	private static void Deactivate(global::UnityEngine.Transform t)
	{
		t.gameObject.SetActive(false);
	}

	// Token: 0x06004E4D RID: 20045 RVA: 0x0012D56C File Offset: 0x0012B76C
	public static void SetActive(global::UnityEngine.GameObject go, bool state)
	{
		if (state)
		{
			global::NGUITools.Activate(go.transform);
		}
		else
		{
			global::NGUITools.Deactivate(go.transform);
		}
	}

	// Token: 0x06004E4E RID: 20046 RVA: 0x0012D590 File Offset: 0x0012B790
	public static global::UnityEngine.Vector3 Round(global::UnityEngine.Vector3 v)
	{
		v.x = global::UnityEngine.Mathf.Round(v.x);
		v.y = global::UnityEngine.Mathf.Round(v.y);
		v.z = global::UnityEngine.Mathf.Round(v.z);
		return v;
	}

	// Token: 0x06004E4F RID: 20047 RVA: 0x0012D5D8 File Offset: 0x0012B7D8
	public static void MakePixelPerfect(global::UnityEngine.Transform t)
	{
		global::UIWidget component = t.GetComponent<global::UIWidget>();
		if (component != null)
		{
			component.MakePixelPerfect();
		}
		else
		{
			t.localPosition = global::NGUITools.Round(t.localPosition);
			t.localScale = global::NGUITools.Round(t.localScale);
			int i = 0;
			int childCount = t.childCount;
			while (i < childCount)
			{
				global::NGUITools.MakePixelPerfect(t.GetChild(i));
				i++;
			}
		}
	}

	// Token: 0x06004E50 RID: 20048 RVA: 0x0012D64C File Offset: 0x0012B84C
	public static bool SetAllowClick(global::UnityEngine.Component self, bool allow)
	{
		global::UnityEngine.Collider collider = self.collider;
		if (collider)
		{
			collider.enabled = allow;
			return true;
		}
		global::UIHotSpot component = self.GetComponent<global::UIHotSpot>();
		if (component)
		{
			component.enabled = allow;
			return true;
		}
		return false;
	}

	// Token: 0x06004E51 RID: 20049 RVA: 0x0012D690 File Offset: 0x0012B890
	public static bool GetAllowClick(global::UnityEngine.MonoBehaviour self, out bool possible)
	{
		global::UnityEngine.Collider collider = self.collider;
		if (collider)
		{
			possible = true;
			return collider.enabled;
		}
		global::UIHotSpot component = self.GetComponent<global::UIHotSpot>();
		if (component)
		{
			possible = true;
			return component.enabled;
		}
		possible = false;
		return false;
	}

	// Token: 0x06004E52 RID: 20050 RVA: 0x0012D6DC File Offset: 0x0012B8DC
	public static bool GetAllowClick(global::UnityEngine.MonoBehaviour self)
	{
		bool flag;
		return global::NGUITools.GetAllowClick(self, out flag);
	}

	// Token: 0x06004E53 RID: 20051 RVA: 0x0012D6F4 File Offset: 0x0012B8F4
	public static void SetAllowClickChildren(global::UnityEngine.GameObject mChild, bool par1)
	{
		global::UnityEngine.Collider[] componentsInChildren = mChild.GetComponentsInChildren<global::UnityEngine.Collider>();
		int i = 0;
		int num = componentsInChildren.Length;
		while (i < num)
		{
			componentsInChildren[i].enabled = false;
			i++;
		}
		global::UIHotSpot[] componentsInChildren2 = mChild.GetComponentsInChildren<global::UIHotSpot>();
		int j = 0;
		int num2 = componentsInChildren2.Length;
		while (j < num2)
		{
			componentsInChildren2[j].enabled = false;
			j++;
		}
	}

	// Token: 0x06004E54 RID: 20052 RVA: 0x0012D754 File Offset: 0x0012B954
	public static bool HasMeansOfClicking(global::UnityEngine.Component self)
	{
		return self.collider || self.GetComponent<global::UIHotSpot>();
	}

	// Token: 0x06004E55 RID: 20053 RVA: 0x0012D774 File Offset: 0x0012B974
	public static bool GetCentroid(global::UnityEngine.Component cell, out global::UnityEngine.Vector3 centroid)
	{
		if (cell is global::UnityEngine.Collider)
		{
			centroid = ((global::UnityEngine.Collider)cell).bounds.center;
		}
		else if (cell is global::UIHotSpot)
		{
			centroid = ((global::UIHotSpot)cell).worldCenter;
		}
		else
		{
			global::UIHotSpot component = cell.GetComponent<global::UIHotSpot>();
			if (component)
			{
				centroid = component.worldCenter;
				return true;
			}
			global::UnityEngine.Collider collider = cell.collider;
			if (collider)
			{
				centroid = collider.bounds.center;
				return true;
			}
			centroid = global::UnityEngine.Vector3.zero;
			return false;
		}
		return true;
	}

	// Token: 0x06004E56 RID: 20054 RVA: 0x0012D824 File Offset: 0x0012BA24
	public static TComponent QuickGet<TComponent>(global::UnityEngine.GameObject gameObject) where TComponent : global::UnityEngine.Component
	{
		switch (global::NGUITools.SG<TComponent>.V)
		{
		case global::NGUITools.SlipGate.Renderer:
			return gameObject.renderer as TComponent;
		case global::NGUITools.SlipGate.Collider:
			return gameObject.collider as TComponent;
		case global::NGUITools.SlipGate.Transform:
			return gameObject.transform as TComponent;
		}
		return gameObject.GetComponent<TComponent>();
	}

	// Token: 0x06004E57 RID: 20055 RVA: 0x0012D89C File Offset: 0x0012BA9C
	public static TComponent GetOrAddComponent<TComponent>(global::UnityEngine.GameObject gameObject) where TComponent : global::UnityEngine.Component
	{
		TComponent tcomponent = global::NGUITools.QuickGet<TComponent>(gameObject);
		return (!tcomponent) ? gameObject.AddComponent<TComponent>() : tcomponent;
	}

	// Token: 0x06004E58 RID: 20056 RVA: 0x0012D8CC File Offset: 0x0012BACC
	public static TComponent GetOrAddComponent<TComponent>(global::UnityEngine.Component component) where TComponent : global::UnityEngine.Component
	{
		if (component is TComponent)
		{
			return (TComponent)((object)component);
		}
		return global::NGUITools.GetOrAddComponent<TComponent>(component.gameObject);
	}

	// Token: 0x06004E59 RID: 20057 RVA: 0x0012D8EC File Offset: 0x0012BAEC
	public static bool GetOrAddComponent<TComponent>(global::UnityEngine.GameObject gameObject, ref TComponent value) where TComponent : global::UnityEngine.Component
	{
		return (!value) ? (value = global::NGUITools.GetOrAddComponent<TComponent>(gameObject)) : value;
	}

	// Token: 0x06004E5A RID: 20058 RVA: 0x0012D934 File Offset: 0x0012BB34
	public static bool GetOrAddComponent<TComponent>(global::UnityEngine.Component component, ref TComponent value) where TComponent : global::UnityEngine.Component
	{
		return (!value) ? (value = global::NGUITools.GetOrAddComponent<TComponent>(component)) : value;
	}

	// Token: 0x04002B0C RID: 11020
	public const float kMinimumAlpha = 0.0019607844f;

	// Token: 0x04002B0D RID: 11021
	public const float kMaximumNegativeAlpha = -0.0019607844f;

	// Token: 0x04002B0E RID: 11022
	public const string kFormattingOffDisableSymbol = "[«]";

	// Token: 0x04002B0F RID: 11023
	public const string kFormattingOffEnableSymbol = "[»]";

	// Token: 0x04002B10 RID: 11024
	public const char kFormattingOffDisableCharacter = '«';

	// Token: 0x04002B11 RID: 11025
	public const char kFormattingOffEnableCharacter = '»';

	// Token: 0x04002B12 RID: 11026
	private static global::UnityEngine.AudioListener mListener;

	// Token: 0x04002B13 RID: 11027
	private static bool mLoaded = false;

	// Token: 0x04002B14 RID: 11028
	private static float mGlobalVolume = 1f;

	// Token: 0x04002B15 RID: 11029
	private static readonly string[] kFormattingOffSymbols = new string[]
	{
		"[»]",
		"[«]"
	};

	// Token: 0x020008E8 RID: 2280
	private enum SlipGate
	{
		// Token: 0x04002B17 RID: 11031
		Renderer,
		// Token: 0x04002B18 RID: 11032
		Collider,
		// Token: 0x04002B19 RID: 11033
		Behaviour,
		// Token: 0x04002B1A RID: 11034
		Transform,
		// Token: 0x04002B1B RID: 11035
		Component
	}

	// Token: 0x020008E9 RID: 2281
	private static class SG<T> where T : global::UnityEngine.Component
	{
		// Token: 0x06004E5B RID: 20059 RVA: 0x0012D97C File Offset: 0x0012BB7C
		static SG()
		{
			if (typeof(global::UnityEngine.Renderer).IsAssignableFrom(typeof(T)))
			{
				global::NGUITools.SG<T>.V = global::NGUITools.SlipGate.Renderer;
			}
			else if (typeof(global::UnityEngine.Collider).IsAssignableFrom(typeof(T)))
			{
				global::NGUITools.SG<T>.V = global::NGUITools.SlipGate.Collider;
			}
			else if (typeof(global::UnityEngine.Behaviour).IsAssignableFrom(typeof(T)))
			{
				global::NGUITools.SG<T>.V = global::NGUITools.SlipGate.Behaviour;
			}
			else if (typeof(global::UnityEngine.Transform).IsAssignableFrom(typeof(T)))
			{
				global::NGUITools.SG<T>.V = global::NGUITools.SlipGate.Transform;
			}
			else
			{
				global::NGUITools.SG<T>.V = global::NGUITools.SlipGate.Component;
			}
		}

		// Token: 0x04002B1C RID: 11036
		public static readonly global::NGUITools.SlipGate V;
	}
}
