using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

// Token: 0x02000014 RID: 20
public abstract class AuthorShared : global::UnityEngine.MonoBehaviour
{
	// Token: 0x0600008D RID: 141 RVA: 0x000037E0 File Offset: 0x000019E0
	protected AuthorShared()
	{
	}

	// Token: 0x0600008E RID: 142 RVA: 0x000037E8 File Offset: 0x000019E8
	// Note: this type is marked as 'beforefieldinit'.
	static AuthorShared()
	{
	}

	// Token: 0x0600008F RID: 143 RVA: 0x00003808 File Offset: 0x00001A08
	public static global::AuthorShared.ObjectKind GetObjectKind(global::UnityEngine.Object value)
	{
		return global::AuthorShared.ObjectKind.Null;
	}

	// Token: 0x06000090 RID: 144 RVA: 0x0000380C File Offset: 0x00001A0C
	public static bool IsNonModelPrefabAssetOrInstance(global::AuthorShared.ObjectKind kind)
	{
		return kind == global::AuthorShared.ObjectKind.Prefab || kind == global::AuthorShared.ObjectKind.PrefabInstance || kind == global::AuthorShared.ObjectKind.DisconnectedPrefabInstance;
	}

	// Token: 0x06000091 RID: 145 RVA: 0x00003824 File Offset: 0x00001A24
	public static bool IsModelAssetOrInstance(global::AuthorShared.ObjectKind kind)
	{
		return kind == global::AuthorShared.ObjectKind.Model || kind == global::AuthorShared.ObjectKind.ModelInstance || kind == global::AuthorShared.ObjectKind.DisconnectedModelInstance;
	}

	// Token: 0x06000092 RID: 146 RVA: 0x0000383C File Offset: 0x00001A3C
	public static bool IsPrefabAssetOrInstance(global::AuthorShared.ObjectKind kind)
	{
		return kind == global::AuthorShared.ObjectKind.Prefab || kind == global::AuthorShared.ObjectKind.Model || kind == global::AuthorShared.ObjectKind.PrefabInstance || kind == global::AuthorShared.ObjectKind.ModelInstance || kind == global::AuthorShared.ObjectKind.DisconnectedPrefabInstance || kind == global::AuthorShared.ObjectKind.DisconnectedModelInstance;
	}

	// Token: 0x06000093 RID: 147 RVA: 0x00003874 File Offset: 0x00001A74
	public static bool IsScriptableObjectAssetOrInstance(global::AuthorShared.ObjectKind kind)
	{
		return kind == global::AuthorShared.ObjectKind.ScriptableObject || kind == global::AuthorShared.ObjectKind.ScriptableObjectInstance;
	}

	// Token: 0x06000094 RID: 148 RVA: 0x00003888 File Offset: 0x00001A88
	public static bool IsInstance(global::AuthorShared.ObjectKind kind)
	{
		return kind >= global::AuthorShared.ObjectKind.LevelInstance && (kind & global::AuthorShared.ObjectKind.Prefab) == global::AuthorShared.ObjectKind.LevelInstance;
	}

	// Token: 0x06000095 RID: 149 RVA: 0x000038A8 File Offset: 0x00001AA8
	public static bool IsAsset(global::AuthorShared.ObjectKind kind)
	{
		return kind >= global::AuthorShared.ObjectKind.LevelInstance && (kind & global::AuthorShared.ObjectKind.Prefab) == global::AuthorShared.ObjectKind.Prefab;
	}

	// Token: 0x06000096 RID: 150 RVA: 0x000038C8 File Offset: 0x00001AC8
	public static bool IsLevelInstance(global::AuthorShared.ObjectKind kind)
	{
		return kind == global::AuthorShared.ObjectKind.LevelInstance || kind == global::AuthorShared.ObjectKind.MissingPrefabInstance || kind == global::AuthorShared.ObjectKind.PrefabInstance || kind == global::AuthorShared.ObjectKind.ModelInstance || kind == global::AuthorShared.ObjectKind.DisconnectedPrefabInstance || kind == global::AuthorShared.ObjectKind.DisconnectedModelInstance;
	}

	// Token: 0x06000097 RID: 151 RVA: 0x000038F4 File Offset: 0x00001AF4
	public static bool Exists(global::AuthorShared.ObjectKind kind)
	{
		return kind >= global::AuthorShared.ObjectKind.LevelInstance;
	}

	// Token: 0x06000098 RID: 152 RVA: 0x00003900 File Offset: 0x00001B00
	public static void PingObject(global::UnityEngine.Object o)
	{
	}

	// Token: 0x06000099 RID: 153 RVA: 0x00003904 File Offset: 0x00001B04
	public static void PingObject(int instanceID)
	{
	}

	// Token: 0x0600009A RID: 154 RVA: 0x00003908 File Offset: 0x00001B08
	private static global::AuthorShared.Content ObjectContentR(global::UnityEngine.Object o, global::System.Type type)
	{
		return global::UnityEngine.GUIContent.none;
	}

	// Token: 0x0600009B RID: 155 RVA: 0x00003914 File Offset: 0x00001B14
	public static global::AuthorShared.Content ObjectContent(global::UnityEngine.Object o, global::System.Type type)
	{
		return global::AuthorShared.ObjectContentR(o, type);
	}

	// Token: 0x0600009C RID: 156 RVA: 0x00003920 File Offset: 0x00001B20
	public static global::AuthorShared.Content ObjectContent(global::System.Type type)
	{
		return global::AuthorShared.ObjectContentR(null, type);
	}

	// Token: 0x0600009D RID: 157 RVA: 0x0000392C File Offset: 0x00001B2C
	public static global::AuthorShared.Content ObjectContent<T>(T o, global::System.Type type) where T : global::UnityEngine.Object
	{
		return global::AuthorShared.ObjectContentR(o, type ?? typeof(T));
	}

	// Token: 0x0600009E RID: 158 RVA: 0x0000394C File Offset: 0x00001B4C
	public static global::AuthorShared.Content ObjectContent<T>(T o) where T : global::UnityEngine.Object
	{
		return global::AuthorShared.ObjectContentR(o, typeof(T));
	}

	// Token: 0x0600009F RID: 159 RVA: 0x00003964 File Offset: 0x00001B64
	public static global::AuthorShared.Content ObjectContent<T>() where T : global::UnityEngine.Object
	{
		return global::AuthorShared.ObjectContentR(null, typeof(T));
	}

	// Token: 0x060000A0 RID: 160 RVA: 0x00003978 File Offset: 0x00001B78
	public static global::UnityEngine.Object ObjectField(global::AuthorShared.Content label, global::UnityEngine.Object value, global::System.Type type, bool allowScene, params global::UnityEngine.GUILayoutOption[] options)
	{
		return value;
	}

	// Token: 0x060000A1 RID: 161 RVA: 0x0000397C File Offset: 0x00001B7C
	public static global::UnityEngine.Object ObjectField(global::AuthorShared.Content label, global::UnityEngine.Object value, global::System.Type type, global::AuthorShared.ObjectFieldFlags flags, params global::UnityEngine.GUILayoutOption[] options)
	{
		return global::AuthorShared.ObjectField(label, value, type, (flags & global::AuthorShared.ObjectFieldFlags.AllowScene) == global::AuthorShared.ObjectFieldFlags.AllowScene, options);
	}

	// Token: 0x060000A2 RID: 162 RVA: 0x0000399C File Offset: 0x00001B9C
	public static global::UnityEngine.Object ObjectField(global::UnityEngine.Object obj, global::System.Type type, global::AuthorShared.ObjectFieldFlags flags, params global::UnityEngine.GUILayoutOption[] options)
	{
		return global::AuthorShared.ObjectField(default(global::AuthorShared.Content), obj, type, flags, options);
	}

	// Token: 0x060000A3 RID: 163 RVA: 0x000039BC File Offset: 0x00001BBC
	public static global::UnityEngine.Object ObjectField(global::UnityEngine.Object obj, global::System.Type type, params global::UnityEngine.GUILayoutOption[] options)
	{
		return global::AuthorShared.ObjectField(default(global::AuthorShared.Content), obj, type, false, options);
	}

	// Token: 0x060000A4 RID: 164 RVA: 0x000039DC File Offset: 0x00001BDC
	public static bool ObjectField<T>(global::AuthorShared.Content content, ref T reference, global::AuthorShared.ObjectFieldFlags flags, params global::UnityEngine.GUILayoutOption[] options) where T : global::UnityEngine.Object
	{
		return global::AuthorShared.ObjectField<T>(content, ref reference, typeof(T), flags, options);
	}

	// Token: 0x060000A5 RID: 165 RVA: 0x000039F4 File Offset: 0x00001BF4
	public static bool ObjectField<T>(global::AuthorShared.Content content, ref T reference, global::System.Type type, global::AuthorShared.ObjectFieldFlags flags, params global::UnityEngine.GUILayoutOption[] options) where T : global::UnityEngine.Object
	{
		global::UnityEngine.Object @object = global::AuthorShared.ObjectField(content, reference, type ?? typeof(T), flags, options);
		if (global::UnityEngine.GUI.changed)
		{
			reference = (T)((object)@object);
			return true;
		}
		return false;
	}

	// Token: 0x060000A6 RID: 166 RVA: 0x00003A44 File Offset: 0x00001C44
	public static global::UnityEngine.Object[] GetAllSelectedObjects()
	{
		return new global::UnityEngine.Object[0];
	}

	// Token: 0x060000A7 RID: 167 RVA: 0x00003A4C File Offset: 0x00001C4C
	public static void SetAllSelectedObjects(params global::UnityEngine.Object[] objects)
	{
	}

	// Token: 0x060000A8 RID: 168 RVA: 0x00003A50 File Offset: 0x00001C50
	public static void Label(global::AuthorShared.Content content, global::UnityEngine.GUIStyle style, params global::UnityEngine.GUILayoutOption[] options)
	{
		int type = content.type;
		if (type != 1)
		{
			if (type != 2)
			{
				global::UnityEngine.GUILayout.Label(global::UnityEngine.GUIContent.none, style, options);
			}
			else
			{
				global::UnityEngine.GUILayout.Label(content.content, style, options);
			}
		}
		else
		{
			global::UnityEngine.GUILayout.Label(content.text, style, options);
		}
	}

	// Token: 0x060000A9 RID: 169 RVA: 0x00003AB0 File Offset: 0x00001CB0
	public static void Label(global::UnityEngine.Texture content, global::UnityEngine.GUIStyle style, params global::UnityEngine.GUILayoutOption[] options)
	{
		global::UnityEngine.GUILayout.Label(content, style, options);
	}

	// Token: 0x060000AA RID: 170 RVA: 0x00003ABC File Offset: 0x00001CBC
	public static void Label(global::AuthorShared.Content content, params global::UnityEngine.GUILayoutOption[] options)
	{
		int type = content.type;
		if (type != 1)
		{
			if (type != 2)
			{
				global::UnityEngine.GUILayout.Label(global::UnityEngine.GUIContent.none, options);
			}
			else
			{
				global::UnityEngine.GUILayout.Label(content.content, options);
			}
		}
		else
		{
			global::UnityEngine.GUILayout.Label(content.text, options);
		}
	}

	// Token: 0x060000AB RID: 171 RVA: 0x00003B18 File Offset: 0x00001D18
	public static void Label(global::UnityEngine.Texture content, params global::UnityEngine.GUILayoutOption[] options)
	{
		global::UnityEngine.GUILayout.Label(content, options);
	}

	// Token: 0x060000AC RID: 172 RVA: 0x00003B24 File Offset: 0x00001D24
	public static global::UnityEngine.Rect BeginSubSection(global::AuthorShared.Content title, params global::UnityEngine.GUILayoutOption[] options)
	{
		global::UnityEngine.Color backgroundColor = global::UnityEngine.GUI.backgroundColor;
		global::UnityEngine.GUI.backgroundColor = new global::UnityEngine.Color(backgroundColor.r, backgroundColor.g, backgroundColor.b, backgroundColor.a * 0.4f);
		global::UnityEngine.Rect result = global::AuthorShared.BeginVertical(global::AuthorShared.Styles.subSection, new global::UnityEngine.GUILayoutOption[0]);
		global::AuthorShared.Label(title, global::AuthorShared.Styles.subSectionTitle, new global::UnityEngine.GUILayoutOption[0]);
		global::UnityEngine.GUI.backgroundColor = backgroundColor;
		return result;
	}

	// Token: 0x060000AD RID: 173 RVA: 0x00003B8C File Offset: 0x00001D8C
	public static global::UnityEngine.Rect BeginSubSection(global::AuthorShared.Content title, global::AuthorShared.Content infoContent, global::UnityEngine.GUIStyle infoStyle, params global::UnityEngine.GUILayoutOption[] options)
	{
		global::UnityEngine.Rect result = global::AuthorShared.BeginSubSection(title, options);
		if (infoContent.type != 0 && global::UnityEngine.Event.current.type == 7)
		{
			if (infoContent.type == 1)
			{
				global::UnityEngine.GUI.Label(global::UnityEngine.GUILayoutUtility.GetLastRect(), infoContent.text, infoStyle);
			}
			else
			{
				global::UnityEngine.GUI.Label(global::UnityEngine.GUILayoutUtility.GetLastRect(), infoContent.content, infoStyle);
			}
		}
		return result;
	}

	// Token: 0x060000AE RID: 174 RVA: 0x00003BF4 File Offset: 0x00001DF4
	public static global::UnityEngine.Rect BeginSubSection(global::AuthorShared.Content title, global::AuthorShared.Content infoContent, params global::UnityEngine.GUILayoutOption[] options)
	{
		return global::AuthorShared.BeginSubSection(title, infoContent, global::AuthorShared.Styles.infoLabel, options);
	}

	// Token: 0x060000AF RID: 175 RVA: 0x00003C04 File Offset: 0x00001E04
	public static void EndSubSection()
	{
		global::AuthorShared.EndVertical();
	}

	// Token: 0x060000B0 RID: 176 RVA: 0x00003C0C File Offset: 0x00001E0C
	public static string StringField(global::AuthorShared.Content content, string value, global::UnityEngine.GUIStyle style, params global::UnityEngine.GUILayoutOption[] options)
	{
		return value;
	}

	// Token: 0x060000B1 RID: 177 RVA: 0x00003C10 File Offset: 0x00001E10
	public static bool StringField(global::AuthorShared.Content content, ref string value, global::UnityEngine.GUIStyle style, params global::UnityEngine.GUILayoutOption[] options)
	{
		return global::AuthorShared.Change(ref value, global::AuthorShared.StringField(content, value, style, options));
	}

	// Token: 0x060000B2 RID: 178 RVA: 0x00003C24 File Offset: 0x00001E24
	public static TComponent AddComponent<TComponent>(global::UnityEngine.GameObject target, string type) where TComponent : global::UnityEngine.Component
	{
		global::UnityEngine.Component component = target.AddComponent(type);
		if (!component)
		{
			global::UnityEngine.Debug.LogWarning("The string type \"" + type + "\" evaluated to no component type. null returning", target);
			return (TComponent)((object)null);
		}
		if (component is TComponent)
		{
			return (TComponent)((object)component);
		}
		global::UnityEngine.Debug.LogWarning(string.Concat(new string[]
		{
			"The string type \"",
			type,
			"\" is a component class but does not inherit \"",
			typeof(TComponent).AssemblyQualifiedName,
			"\""
		}), target);
		global::UnityEngine.Object.DestroyImmediate(component);
		return (TComponent)((object)null);
	}

	// Token: 0x060000B3 RID: 179 RVA: 0x00003CC0 File Offset: 0x00001EC0
	public static string StringField(global::AuthorShared.Content content, string value, params global::UnityEngine.GUILayoutOption[] options)
	{
		return value;
	}

	// Token: 0x060000B4 RID: 180 RVA: 0x00003CC4 File Offset: 0x00001EC4
	public static bool StringField(global::AuthorShared.Content content, ref string value, params global::UnityEngine.GUILayoutOption[] options)
	{
		return global::AuthorShared.Change(ref value, global::AuthorShared.StringField(content, value, options));
	}

	// Token: 0x060000B5 RID: 181 RVA: 0x00003CD8 File Offset: 0x00001ED8
	public static bool? Ask(string Question)
	{
		return null;
	}

	// Token: 0x060000B6 RID: 182 RVA: 0x00003CF0 File Offset: 0x00001EF0
	public static int IntField(global::AuthorShared.Content content, int value, global::UnityEngine.GUIStyle style, params global::UnityEngine.GUILayoutOption[] options)
	{
		return value;
	}

	// Token: 0x060000B7 RID: 183 RVA: 0x00003CF4 File Offset: 0x00001EF4
	public static bool IntField(global::AuthorShared.Content content, ref int value, global::UnityEngine.GUIStyle style, params global::UnityEngine.GUILayoutOption[] options)
	{
		return global::AuthorShared.Change(ref value, global::AuthorShared.IntField(content, value, style, options));
	}

	// Token: 0x060000B8 RID: 184 RVA: 0x00003D08 File Offset: 0x00001F08
	public static int IntField(global::AuthorShared.Content content, int value, params global::UnityEngine.GUILayoutOption[] options)
	{
		return value;
	}

	// Token: 0x060000B9 RID: 185 RVA: 0x00003D0C File Offset: 0x00001F0C
	public static bool IntField(global::AuthorShared.Content content, ref int value, params global::UnityEngine.GUILayoutOption[] options)
	{
		return global::AuthorShared.Change(ref value, global::AuthorShared.IntField(content, value, options));
	}

	// Token: 0x060000BA RID: 186 RVA: 0x00003D20 File Offset: 0x00001F20
	public static float FloatField(global::AuthorShared.Content content, float value, global::UnityEngine.GUIStyle style, params global::UnityEngine.GUILayoutOption[] options)
	{
		return value;
	}

	// Token: 0x060000BB RID: 187 RVA: 0x00003D24 File Offset: 0x00001F24
	public static bool FloatField(global::AuthorShared.Content content, ref float value, params global::UnityEngine.GUILayoutOption[] options)
	{
		return global::AuthorShared.Change(ref value, global::AuthorShared.FloatField(content, value, options));
	}

	// Token: 0x060000BC RID: 188 RVA: 0x00003D38 File Offset: 0x00001F38
	public static float FloatField(global::AuthorShared.Content content, float value, params global::UnityEngine.GUILayoutOption[] options)
	{
		return value;
	}

	// Token: 0x060000BD RID: 189 RVA: 0x00003D3C File Offset: 0x00001F3C
	public static bool FloatField(global::AuthorShared.Content content, ref float value, global::UnityEngine.GUIStyle style, params global::UnityEngine.GUILayoutOption[] options)
	{
		return global::AuthorShared.Change(ref value, global::AuthorShared.FloatField(content, value, style, options));
	}

	// Token: 0x060000BE RID: 190 RVA: 0x00003D50 File Offset: 0x00001F50
	public static global::UnityEngine.Vector3 Vector3Field(global::AuthorShared.Content content, global::UnityEngine.Vector3 value, params global::UnityEngine.GUILayoutOption[] options)
	{
		return value;
	}

	// Token: 0x060000BF RID: 191 RVA: 0x00003D54 File Offset: 0x00001F54
	public static bool Vector3Field(global::AuthorShared.Content content, ref global::UnityEngine.Vector3 value, params global::UnityEngine.GUILayoutOption[] options)
	{
		return global::AuthorShared.Change(ref value, global::AuthorShared.Vector3Field(content, value, options));
	}

	// Token: 0x060000C0 RID: 192 RVA: 0x00003D6C File Offset: 0x00001F6C
	public static global::System.Enum EnumField(global::AuthorShared.Content content, global::System.Enum value, global::UnityEngine.GUIStyle style, params global::UnityEngine.GUILayoutOption[] options)
	{
		return value;
	}

	// Token: 0x060000C1 RID: 193 RVA: 0x00003D70 File Offset: 0x00001F70
	public static bool EnumField<T>(global::AuthorShared.Content content, ref T value, global::UnityEngine.GUIStyle style, params global::UnityEngine.GUILayoutOption[] options) where T : struct
	{
		return global::AuthorShared.Change<T>(ref value, global::AuthorShared.EnumField(content, (global::System.Enum)global::System.Enum.ToObject(typeof(T), value), style, options));
	}

	// Token: 0x060000C2 RID: 194 RVA: 0x00003DA0 File Offset: 0x00001FA0
	public static global::System.Enum EnumField(global::AuthorShared.Content content, global::System.Enum value, params global::UnityEngine.GUILayoutOption[] options)
	{
		return value;
	}

	// Token: 0x060000C3 RID: 195 RVA: 0x00003DA4 File Offset: 0x00001FA4
	public static bool EnumField<T>(global::AuthorShared.Content content, ref T value, params global::UnityEngine.GUILayoutOption[] options) where T : struct
	{
		return global::AuthorShared.Change<T>(ref value, global::AuthorShared.EnumField(content, (global::System.Enum)global::System.Enum.ToObject(typeof(T), value), options));
	}

	// Token: 0x060000C4 RID: 196 RVA: 0x00003DE0 File Offset: 0x00001FE0
	public static void SetSerializedProperty(global::UnityEngine.Object objSet, string propertyPath, global::UnityEngine.Object value)
	{
	}

	// Token: 0x060000C5 RID: 197 RVA: 0x00003DE4 File Offset: 0x00001FE4
	public static bool SelectionContains(global::UnityEngine.Object obj)
	{
		return false;
	}

	// Token: 0x060000C6 RID: 198 RVA: 0x00003DE8 File Offset: 0x00001FE8
	public static bool SelectionContains(int obj)
	{
		return false;
	}

	// Token: 0x060000C7 RID: 199 RVA: 0x00003DEC File Offset: 0x00001FEC
	public static global::UnityEngine.Rect BeginVertical(params global::UnityEngine.GUILayoutOption[] options)
	{
		return new global::UnityEngine.Rect(0f, 0f, 0f, 0f);
	}

	// Token: 0x060000C8 RID: 200 RVA: 0x00003E08 File Offset: 0x00002008
	public static global::UnityEngine.Rect BeginVertical(global::UnityEngine.GUIStyle style, params global::UnityEngine.GUILayoutOption[] options)
	{
		return new global::UnityEngine.Rect(0f, 0f, 0f, 0f);
	}

	// Token: 0x060000C9 RID: 201 RVA: 0x00003E24 File Offset: 0x00002024
	public static global::UnityEngine.Rect BeginHorizontal(params global::UnityEngine.GUILayoutOption[] options)
	{
		return new global::UnityEngine.Rect(0f, 0f, 0f, 0f);
	}

	// Token: 0x060000CA RID: 202 RVA: 0x00003E40 File Offset: 0x00002040
	public static global::UnityEngine.Rect BeginHorizontal(global::UnityEngine.GUIStyle style, params global::UnityEngine.GUILayoutOption[] options)
	{
		return new global::UnityEngine.Rect(0f, 0f, 0f, 0f);
	}

	// Token: 0x060000CB RID: 203 RVA: 0x00003E5C File Offset: 0x0000205C
	public static global::UnityEngine.Vector2 BeginScrollView(global::UnityEngine.Vector2 scroll, params global::UnityEngine.GUILayoutOption[] options)
	{
		return scroll;
	}

	// Token: 0x060000CC RID: 204 RVA: 0x00003E60 File Offset: 0x00002060
	public static void EndVertical()
	{
	}

	// Token: 0x060000CD RID: 205 RVA: 0x00003E64 File Offset: 0x00002064
	public static void EndHorizontal()
	{
	}

	// Token: 0x060000CE RID: 206 RVA: 0x00003E68 File Offset: 0x00002068
	public static void EndScrollView()
	{
	}

	// Token: 0x060000CF RID: 207 RVA: 0x00003E6C File Offset: 0x0000206C
	public static void SetDirty(global::UnityEngine.Object obj)
	{
	}

	// Token: 0x060000D0 RID: 208 RVA: 0x00003E70 File Offset: 0x00002070
	public static string GetAssetPath(global::UnityEngine.Object obj)
	{
		return string.Empty;
	}

	// Token: 0x060000D1 RID: 209 RVA: 0x00003E78 File Offset: 0x00002078
	public static string PathToProjectPath(string path)
	{
		return path;
	}

	// Token: 0x060000D2 RID: 210 RVA: 0x00003E7C File Offset: 0x0000207C
	public static string TryPathToProjectPath(string path)
	{
		return path;
	}

	// Token: 0x060000D3 RID: 211 RVA: 0x00003E80 File Offset: 0x00002080
	public static string PathToGUID(string path)
	{
		return string.Empty;
	}

	// Token: 0x060000D4 RID: 212 RVA: 0x00003E88 File Offset: 0x00002088
	public static string GUIDToPath(string guid)
	{
		return string.Empty;
	}

	// Token: 0x060000D5 RID: 213 RVA: 0x00003E90 File Offset: 0x00002090
	public static void CustomMenu(global::UnityEngine.Rect position, global::UnityEngine.GUIContent[] options, int selected, global::AuthorShared.CustomMenuProc proc, object userData)
	{
		string[] array = new string[options.Length];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = options[i].text;
		}
		proc(userData, array, selected);
	}

	// Token: 0x060000D6 RID: 214 RVA: 0x00003ED0 File Offset: 0x000020D0
	public static int Popup(global::AuthorShared.Content content, int index, global::UnityEngine.GUIContent[] displayedOptions, global::UnityEngine.GUIStyle style, params global::UnityEngine.GUILayoutOption[] options)
	{
		return index;
	}

	// Token: 0x060000D7 RID: 215 RVA: 0x00003ED4 File Offset: 0x000020D4
	public static bool Popup(global::AuthorShared.Content content, ref int index, global::UnityEngine.GUIContent[] displayedOptions, global::UnityEngine.GUIStyle style, params global::UnityEngine.GUILayoutOption[] options)
	{
		return global::AuthorShared.Change(ref index, global::AuthorShared.Popup(content, index, displayedOptions, style, options));
	}

	// Token: 0x060000D8 RID: 216 RVA: 0x00003EE8 File Offset: 0x000020E8
	public static int Popup(global::AuthorShared.Content content, int index, global::UnityEngine.GUIContent[] displayedOptions, params global::UnityEngine.GUILayoutOption[] options)
	{
		return index;
	}

	// Token: 0x060000D9 RID: 217 RVA: 0x00003EEC File Offset: 0x000020EC
	public static bool Popup(global::AuthorShared.Content content, ref int index, global::UnityEngine.GUIContent[] displayedOptions, params global::UnityEngine.GUILayoutOption[] options)
	{
		return global::AuthorShared.Change(ref index, global::AuthorShared.Popup(content, index, displayedOptions, options));
	}

	// Token: 0x060000DA RID: 218 RVA: 0x00003F00 File Offset: 0x00002100
	public static int Popup(int index, global::UnityEngine.GUIContent[] displayedOptions, global::UnityEngine.GUIStyle style, params global::UnityEngine.GUILayoutOption[] options)
	{
		return index;
	}

	// Token: 0x060000DB RID: 219 RVA: 0x00003F04 File Offset: 0x00002104
	public static bool Popup(ref int index, global::UnityEngine.GUIContent[] displayedOptions, global::UnityEngine.GUIStyle style, params global::UnityEngine.GUILayoutOption[] options)
	{
		return global::AuthorShared.Change(ref index, global::AuthorShared.Popup(index, displayedOptions, style, options));
	}

	// Token: 0x060000DC RID: 220 RVA: 0x00003F18 File Offset: 0x00002118
	public static int Popup(int index, global::UnityEngine.GUIContent[] displayedOptions, params global::UnityEngine.GUILayoutOption[] options)
	{
		return index;
	}

	// Token: 0x060000DD RID: 221 RVA: 0x00003F1C File Offset: 0x0000211C
	public static bool Popup(ref int index, global::UnityEngine.GUIContent[] displayedOptions, params global::UnityEngine.GUILayoutOption[] options)
	{
		return global::AuthorShared.Change(ref index, global::AuthorShared.Popup(index, displayedOptions, options));
	}

	// Token: 0x060000DE RID: 222 RVA: 0x00003F30 File Offset: 0x00002130
	public static int Popup(global::AuthorShared.Content content, int index, string[] displayedOptions, global::UnityEngine.GUIStyle style, params global::UnityEngine.GUILayoutOption[] options)
	{
		return index;
	}

	// Token: 0x060000DF RID: 223 RVA: 0x00003F34 File Offset: 0x00002134
	public static bool Popup(global::AuthorShared.Content content, ref int index, string[] displayedOptions, global::UnityEngine.GUIStyle style, params global::UnityEngine.GUILayoutOption[] options)
	{
		return global::AuthorShared.Change(ref index, global::AuthorShared.Popup(content, index, displayedOptions, style, options));
	}

	// Token: 0x060000E0 RID: 224 RVA: 0x00003F48 File Offset: 0x00002148
	public static int Popup(global::AuthorShared.Content content, int index, string[] displayedOptions, params global::UnityEngine.GUILayoutOption[] options)
	{
		return index;
	}

	// Token: 0x060000E1 RID: 225 RVA: 0x00003F4C File Offset: 0x0000214C
	public static bool Popup(global::AuthorShared.Content content, ref int index, string[] displayedOptions, params global::UnityEngine.GUILayoutOption[] options)
	{
		return global::AuthorShared.Change(ref index, global::AuthorShared.Popup(content, index, displayedOptions, options));
	}

	// Token: 0x060000E2 RID: 226 RVA: 0x00003F60 File Offset: 0x00002160
	public static int Popup(int index, string[] displayedOptions, global::UnityEngine.GUIStyle style, params global::UnityEngine.GUILayoutOption[] options)
	{
		return index;
	}

	// Token: 0x060000E3 RID: 227 RVA: 0x00003F64 File Offset: 0x00002164
	public static bool Popup(ref int index, string[] displayedOptions, global::UnityEngine.GUIStyle style, params global::UnityEngine.GUILayoutOption[] options)
	{
		return global::AuthorShared.Change(ref index, global::AuthorShared.Popup(index, displayedOptions, style, options));
	}

	// Token: 0x060000E4 RID: 228 RVA: 0x00003F78 File Offset: 0x00002178
	public static int Popup(int index, string[] displayedOptions, params global::UnityEngine.GUILayoutOption[] options)
	{
		return index;
	}

	// Token: 0x060000E5 RID: 229 RVA: 0x00003F7C File Offset: 0x0000217C
	public static bool Popup(ref int index, string[] displayedOptions, params global::UnityEngine.GUILayoutOption[] options)
	{
		return global::AuthorShared.Change(ref index, global::AuthorShared.Popup(index, displayedOptions, options));
	}

	// Token: 0x060000E6 RID: 230 RVA: 0x00003F90 File Offset: 0x00002190
	public static bool Change(ref int current, int incoming)
	{
		if (current == incoming)
		{
			return false;
		}
		current = incoming;
		return true;
	}

	// Token: 0x060000E7 RID: 231 RVA: 0x00003FA0 File Offset: 0x000021A0
	public static bool Change(ref float current, float incoming)
	{
		if (current == incoming)
		{
			return false;
		}
		current = incoming;
		return true;
	}

	// Token: 0x060000E8 RID: 232 RVA: 0x00003FB0 File Offset: 0x000021B0
	public static bool Change(ref bool current, bool incoming)
	{
		if (current == incoming)
		{
			return false;
		}
		current = incoming;
		return true;
	}

	// Token: 0x060000E9 RID: 233 RVA: 0x00003FC0 File Offset: 0x000021C0
	public static bool Change(ref string current, string incoming)
	{
		if (current == incoming)
		{
			return false;
		}
		current = incoming;
		return true;
	}

	// Token: 0x060000EA RID: 234 RVA: 0x00003FD8 File Offset: 0x000021D8
	public static bool Change(ref global::UnityEngine.Vector2 current, global::UnityEngine.Vector2 incoming)
	{
		if (current == incoming)
		{
			return false;
		}
		current = incoming;
		return true;
	}

	// Token: 0x060000EB RID: 235 RVA: 0x00003FF8 File Offset: 0x000021F8
	public static bool Change(ref global::UnityEngine.Vector3 current, global::UnityEngine.Vector3 incoming)
	{
		if (current == incoming)
		{
			return false;
		}
		current = incoming;
		return true;
	}

	// Token: 0x060000EC RID: 236 RVA: 0x00004018 File Offset: 0x00002218
	public static bool Change(ref global::UnityEngine.Vector4 current, global::UnityEngine.Vector4 incoming)
	{
		if (current == incoming)
		{
			return false;
		}
		current = incoming;
		return true;
	}

	// Token: 0x060000ED RID: 237 RVA: 0x00004038 File Offset: 0x00002238
	public static bool Change(ref global::UnityEngine.Quaternion current, global::UnityEngine.Quaternion incoming)
	{
		if (current == incoming)
		{
			return false;
		}
		current = incoming;
		return true;
	}

	// Token: 0x060000EE RID: 238 RVA: 0x00004058 File Offset: 0x00002258
	public static bool Change<T>(ref T current, object incoming) where T : struct
	{
		if (current.Equals(incoming))
		{
			return false;
		}
		T t = current;
		bool result;
		try
		{
			current = (T)((object)incoming);
			result = true;
		}
		catch
		{
			current = t;
			result = false;
		}
		return result;
	}

	// Token: 0x060000EF RID: 239 RVA: 0x000040CC File Offset: 0x000022CC
	public static void PrefixLabel(global::AuthorShared.Content content)
	{
	}

	// Token: 0x060000F0 RID: 240 RVA: 0x000040D0 File Offset: 0x000022D0
	public static void PrefixLabel(global::AuthorShared.Content content, global::UnityEngine.GUIStyle followingStyle)
	{
	}

	// Token: 0x060000F1 RID: 241 RVA: 0x000040D4 File Offset: 0x000022D4
	public static void PrefixLabel(global::AuthorShared.Content content, global::UnityEngine.GUIStyle followingStyle, global::UnityEngine.GUIStyle labelStyle)
	{
	}

	// Token: 0x060000F2 RID: 242 RVA: 0x000040D8 File Offset: 0x000022D8
	private static global::UnityEngine.Rect GetControlRect(bool hasLabel, float height, global::UnityEngine.GUIStyle style, params global::UnityEngine.GUILayoutOption[] options)
	{
		return global::UnityEngine.GUILayoutUtility.GetRect(0f, 100f, height, height, style, options);
	}

	// Token: 0x060000F3 RID: 243 RVA: 0x000040F0 File Offset: 0x000022F0
	private static bool VerifyArgs(global::AuthorShared.GenerateOptions generateOptions, global::UnityEngine.GUIContent[] options, global::System.Array array)
	{
		return options != null && array != null && options.Length == array.Length && options.Length != 0;
	}

	// Token: 0x060000F4 RID: 244 RVA: 0x00004124 File Offset: 0x00002324
	private static bool PopupImmediate<T>(global::AuthorShared.Content content, global::AuthorShared.GenerateOptions generateOptions, T args, global::UnityEngine.GUIStyle style, global::UnityEngine.GUILayoutOption[] options, out object value)
	{
		value = null;
		return false;
	}

	// Token: 0x060000F5 RID: 245 RVA: 0x0000412C File Offset: 0x0000232C
	private static bool AuthorPopupGenerate(object arg, ref int selected, out global::UnityEngine.GUIContent[] options, out global::System.Array array)
	{
		options = null;
		array = null;
		global::AuthorShared.AuthorOptionGenerate authorOptionGenerate = (global::AuthorShared.AuthorOptionGenerate)arg;
		global::System.Collections.Generic.List<global::AuthorPeice> list = new global::System.Collections.Generic.List<global::AuthorPeice>(authorOptionGenerate.creation.EnumeratePeices(authorOptionGenerate.selectedOnly));
		int num = list.Count;
		if (num == 0)
		{
			return false;
		}
		if (authorOptionGenerate.type != null)
		{
			for (int i = 0; i < num; i++)
			{
				global::AuthorPeice authorPeice;
				if (!(authorPeice = list[i]) || !authorOptionGenerate.type.IsAssignableFrom(authorPeice.GetType()))
				{
					list.RemoveAt(i--);
					num--;
				}
			}
		}
		else
		{
			for (int j = 0; j < num; j++)
			{
				if (!list[j])
				{
					list.RemoveAt(j--);
					num--;
				}
			}
		}
		if (num == 0)
		{
			return false;
		}
		if (!authorOptionGenerate.allowSelf && authorOptionGenerate.self)
		{
			if (authorOptionGenerate.peice)
			{
				for (int k = 0; k < num; k++)
				{
					global::AuthorPeice authorPeice;
					if ((authorPeice = list[k]) == authorOptionGenerate.self)
					{
						list.RemoveAt(k--);
						num--;
					}
					else if (authorPeice == authorOptionGenerate.peice)
					{
						selected = k++;
						while (k < num)
						{
							if (list[k] == authorOptionGenerate.self)
							{
								list.RemoveAt(k--);
								num--;
							}
							k++;
						}
						break;
					}
				}
			}
			else
			{
				for (int l = 0; l < num; l++)
				{
					if (list[l] == authorOptionGenerate.self)
					{
						list.RemoveAt(l--);
						num--;
					}
				}
			}
		}
		else if (authorOptionGenerate.peice)
		{
			for (int m = 0; m < num; m++)
			{
				if (list[m] == authorOptionGenerate.peice)
				{
					selected = m;
					break;
				}
			}
		}
		if (num == 0)
		{
			return false;
		}
		global::AuthorPeice[] array2 = list.ToArray();
		options = new global::UnityEngine.GUIContent[array2.Length];
		for (int n = 0; n < array2.Length; n++)
		{
			options[n] = new global::UnityEngine.GUIContent(string.Format("{0:00}. {1} ({2})", n, array2[n].peiceID, array2[n].GetType().Name), array2[n].ToString());
		}
		array = array2;
		return true;
	}

	// Token: 0x060000F6 RID: 246 RVA: 0x000043F8 File Offset: 0x000025F8
	private static bool PeiceFieldBase<T>(global::AuthorShared.Content content, global::AuthorShared self, ref T peice, global::System.Type type, bool allowSelf, global::UnityEngine.GUIStyle style, params global::UnityEngine.GUILayoutOption[] options) where T : global::AuthorPeice
	{
		return false;
	}

	// Token: 0x060000F7 RID: 247 RVA: 0x000043FC File Offset: 0x000025FC
	public static bool PeiceField<T>(global::AuthorShared.Content content, global::AuthorCreation self, ref T peice, global::System.Type type, global::UnityEngine.GUIStyle style, params global::UnityEngine.GUILayoutOption[] options) where T : global::AuthorPeice
	{
		return global::AuthorShared.PeiceFieldBase<T>(content, self, ref peice, type, true, style, options);
	}

	// Token: 0x060000F8 RID: 248 RVA: 0x0000440C File Offset: 0x0000260C
	public static bool PeiceField<T>(global::AuthorShared.Content content, global::AuthorPeice self, ref T peice, global::System.Type type, bool allowSelf, global::UnityEngine.GUIStyle style, params global::UnityEngine.GUILayoutOption[] options) where T : global::AuthorPeice
	{
		return global::AuthorShared.PeiceFieldBase<T>(content, self, ref peice, type, allowSelf, style, options);
	}

	// Token: 0x060000F9 RID: 249 RVA: 0x00004420 File Offset: 0x00002620
	public static bool PeiceField<T>(global::AuthorShared.Content content, global::AuthorPeice self, ref T peice, global::System.Type type, global::UnityEngine.GUIStyle style, params global::UnityEngine.GUILayoutOption[] options) where T : global::AuthorPeice
	{
		return global::AuthorShared.PeiceFieldBase<T>(content, self, ref peice, type, false, style, options);
	}

	// Token: 0x060000FA RID: 250 RVA: 0x00004430 File Offset: 0x00002630
	public static global::UnityEngine.GameObject FindPrefabRoot(global::UnityEngine.GameObject prefab)
	{
		return prefab.transform.root.gameObject;
	}

	// Token: 0x060000FB RID: 251 RVA: 0x00004444 File Offset: 0x00002644
	public static T InstantiatePrefab<T>(T prefab) where T : global::UnityEngine.Component
	{
		global::UnityEngine.Object @object = global::UnityEngine.Object.Instantiate(prefab);
		return (T)((object)@object);
	}

	// Token: 0x060000FC RID: 252 RVA: 0x00004464 File Offset: 0x00002664
	public static global::UnityEngine.GameObject InstantiatePrefab(global::UnityEngine.GameObject prefab)
	{
		global::UnityEngine.Object @object = global::UnityEngine.Object.Instantiate(prefab);
		return (global::UnityEngine.GameObject)@object;
	}

	// Token: 0x060000FD RID: 253 RVA: 0x00004480 File Offset: 0x00002680
	public static void SetActiveSelection(global::UnityEngine.Object o)
	{
	}

	// Token: 0x060000FE RID: 254 RVA: 0x00004484 File Offset: 0x00002684
	public static bool InAnimationMode()
	{
		return false;
	}

	// Token: 0x060000FF RID: 255 RVA: 0x00004488 File Offset: 0x00002688
	public static void StartAnimationMode(params global::UnityEngine.Object[] objects)
	{
	}

	// Token: 0x06000100 RID: 256 RVA: 0x0000448C File Offset: 0x0000268C
	public static void StopAnimationMode()
	{
	}

	// Token: 0x06000101 RID: 257 RVA: 0x00004490 File Offset: 0x00002690
	public static string CalculatePath(global::UnityEngine.Transform targetTransform, global::UnityEngine.Transform root)
	{
		return targetTransform.name;
	}

	// Token: 0x06000102 RID: 258 RVA: 0x00004498 File Offset: 0x00002698
	public static global::UnityEngine.Transform GetRootBone(global::UnityEngine.GameObject go)
	{
		global::UnityEngine.SkinnedMeshRenderer skinnedMeshRenderer;
		return global::AuthorShared.GetRootBone(go, out skinnedMeshRenderer);
	}

	// Token: 0x06000103 RID: 259 RVA: 0x000044B0 File Offset: 0x000026B0
	public static global::UnityEngine.Transform GetRootBone(global::UnityEngine.GameObject go, out global::UnityEngine.SkinnedMeshRenderer renderer)
	{
		if (go.renderer is global::UnityEngine.SkinnedMeshRenderer)
		{
			renderer = (go.renderer as global::UnityEngine.SkinnedMeshRenderer);
		}
		else
		{
			renderer = null;
			foreach (global::UnityEngine.Transform transform in go.transform.ListDecendantsByDepth())
			{
				if (transform.renderer is global::UnityEngine.SkinnedMeshRenderer)
				{
					renderer = (transform.renderer as global::UnityEngine.SkinnedMeshRenderer);
					break;
				}
			}
			if (renderer == null)
			{
				return go.transform;
			}
		}
		return global::AuthorShared.GetRootBone(renderer);
	}

	// Token: 0x06000104 RID: 260 RVA: 0x00004578 File Offset: 0x00002778
	public static global::UnityEngine.Transform GetRootBone(global::UnityEngine.Component co, out global::UnityEngine.SkinnedMeshRenderer renderer)
	{
		if (co is global::UnityEngine.SkinnedMeshRenderer)
		{
			renderer = (co as global::UnityEngine.SkinnedMeshRenderer);
			return global::AuthorShared.GetRootBone(renderer);
		}
		return global::AuthorShared.GetRootBone(co.gameObject, out renderer);
	}

	// Token: 0x06000105 RID: 261 RVA: 0x000045A4 File Offset: 0x000027A4
	public static global::UnityEngine.Transform GetRootBone(global::UnityEngine.Component co)
	{
		if (co is global::UnityEngine.SkinnedMeshRenderer)
		{
			return global::AuthorShared.GetRootBone(co as global::UnityEngine.SkinnedMeshRenderer);
		}
		return global::AuthorShared.GetRootBone(co.gameObject);
	}

	// Token: 0x06000106 RID: 262 RVA: 0x000045D4 File Offset: 0x000027D4
	public static global::UnityEngine.Transform GetRootBone(global::UnityEngine.SkinnedMeshRenderer renderer)
	{
		if (!renderer)
		{
			throw new global::System.ArgumentNullException("renderer");
		}
		return renderer.transform;
	}

	// Token: 0x06000107 RID: 263 RVA: 0x000045F4 File Offset: 0x000027F4
	public static bool Button(global::AuthorShared.Content content, global::UnityEngine.GUIStyle style, params global::UnityEngine.GUILayoutOption[] options)
	{
		int type = content.type;
		if (type == 1)
		{
			return global::UnityEngine.GUILayout.Button(content.text, style, options);
		}
		if (type != 2)
		{
			return global::UnityEngine.GUILayout.Button(global::UnityEngine.GUIContent.none, style, options);
		}
		return global::UnityEngine.GUILayout.Button(content.content, style, options);
	}

	// Token: 0x06000108 RID: 264 RVA: 0x00004648 File Offset: 0x00002848
	public static bool Button(global::UnityEngine.Texture image, global::UnityEngine.GUIStyle style, params global::UnityEngine.GUILayoutOption[] options)
	{
		return global::UnityEngine.GUILayout.Button(image, style, options);
	}

	// Token: 0x06000109 RID: 265 RVA: 0x00004654 File Offset: 0x00002854
	public static bool Button(global::AuthorShared.Content content, params global::UnityEngine.GUILayoutOption[] options)
	{
		int type = content.type;
		if (type == 1)
		{
			return global::UnityEngine.GUILayout.Button(content.text, options);
		}
		if (type != 2)
		{
			return global::UnityEngine.GUILayout.Button(global::UnityEngine.GUIContent.none, options);
		}
		return global::UnityEngine.GUILayout.Button(content.content, options);
	}

	// Token: 0x0600010A RID: 266 RVA: 0x000046A4 File Offset: 0x000028A4
	public static bool Button(global::UnityEngine.Texture image, params global::UnityEngine.GUILayoutOption[] options)
	{
		return global::UnityEngine.GUILayout.Button(image, options);
	}

	// Token: 0x0600010B RID: 267 RVA: 0x000046B0 File Offset: 0x000028B0
	public static bool Toggle(global::AuthorShared.Content content, bool state, global::UnityEngine.GUIStyle style, params global::UnityEngine.GUILayoutOption[] options)
	{
		int type = content.type;
		if (type == 1)
		{
			return global::UnityEngine.GUILayout.Toggle(state, content.text, style, options);
		}
		if (type != 2)
		{
			return global::UnityEngine.GUILayout.Toggle(state, global::UnityEngine.GUIContent.none, style, options);
		}
		return global::UnityEngine.GUILayout.Toggle(state, content.content, style, options);
	}

	// Token: 0x0600010C RID: 268 RVA: 0x00004708 File Offset: 0x00002908
	public static bool Toggle(global::UnityEngine.Texture image, bool state, global::UnityEngine.GUIStyle style, params global::UnityEngine.GUILayoutOption[] options)
	{
		return global::UnityEngine.GUILayout.Toggle(state, image, style, options);
	}

	// Token: 0x0600010D RID: 269 RVA: 0x00004714 File Offset: 0x00002914
	public static bool Toggle(global::AuthorShared.Content content, bool state, params global::UnityEngine.GUILayoutOption[] options)
	{
		int type = content.type;
		if (type == 1)
		{
			return global::UnityEngine.GUILayout.Toggle(state, content.text, options);
		}
		if (type != 2)
		{
			return global::UnityEngine.GUILayout.Toggle(state, global::UnityEngine.GUIContent.none, options);
		}
		return global::UnityEngine.GUILayout.Toggle(state, content.content, options);
	}

	// Token: 0x0600010E RID: 270 RVA: 0x00004768 File Offset: 0x00002968
	public static bool Toggle(global::UnityEngine.Texture image, bool state, params global::UnityEngine.GUILayoutOption[] options)
	{
		return global::UnityEngine.GUILayout.Toggle(state, image, options);
	}

	// Token: 0x0600010F RID: 271 RVA: 0x00004774 File Offset: 0x00002974
	public static bool Toggle(global::AuthorShared.Content content, ref bool state, global::UnityEngine.GUIStyle style, params global::UnityEngine.GUILayoutOption[] options)
	{
		return global::AuthorShared.Change(ref state, global::AuthorShared.Toggle(content, state, style, options));
	}

	// Token: 0x06000110 RID: 272 RVA: 0x00004788 File Offset: 0x00002988
	public static bool Toggle(global::AuthorShared.Content content, ref bool state, params global::UnityEngine.GUILayoutOption[] options)
	{
		return global::AuthorShared.Change(ref state, global::AuthorShared.Toggle(content, state, options));
	}

	// Token: 0x06000111 RID: 273 RVA: 0x0000479C File Offset: 0x0000299C
	public static bool ArrayField<T>(global::AuthorShared.Content content, ref T[] array, global::AuthorShared.ArrayFieldFunctor<T> functor)
	{
		global::AuthorShared.BeginHorizontal(new global::UnityEngine.GUILayoutOption[0]);
		int num = (array != null) ? array.Length : 0;
		global::AuthorShared.PrefixLabel(content);
		global::AuthorShared.BeginVertical(new global::UnityEngine.GUILayoutOption[0]);
		global::AuthorShared.BeginHorizontal(new global::UnityEngine.GUILayoutOption[0]);
		global::AuthorShared.Label("Size", new global::UnityEngine.GUILayoutOption[]
		{
			global::UnityEngine.GUILayout.ExpandWidth(false)
		});
		int num2 = global::UnityEngine.Mathf.Max(0, global::AuthorShared.IntField(default(global::AuthorShared.Content), num, new global::UnityEngine.GUILayoutOption[0]));
		global::AuthorShared.EndHorizontal();
		bool flag = num != num2;
		if (num > 0)
		{
			for (int i = 0; i < num; i++)
			{
				flag |= functor(ref array[i]);
			}
		}
		global::AuthorShared.EndVertical();
		global::AuthorShared.EndHorizontal();
		if (flag)
		{
			global::System.Array.Resize<T>(ref array, num2);
			return true;
		}
		return false;
	}

	// Token: 0x06000112 RID: 274 RVA: 0x00004874 File Offset: 0x00002A74
	public static bool MatchPrefab(global::UnityEngine.Object a, global::UnityEngine.Object b)
	{
		return (a == b || !a || !b) && false;
	}

	// Token: 0x04000049 RID: 73
	private static readonly global::UnityEngine.GUIContent AuthorPeiceContent = new global::UnityEngine.GUIContent();

	// Token: 0x0400004A RID: 74
	private static global::UnityEngine.Rect lastRect_popup;

	// Token: 0x0400004B RID: 75
	private static readonly global::AuthorShared.GenerateOptions authorPopupGenerate = new global::AuthorShared.GenerateOptions(global::AuthorShared.AuthorPopupGenerate);

	// Token: 0x02000015 RID: 21
	public struct Content
	{
		// Token: 0x06000113 RID: 275 RVA: 0x0000489C File Offset: 0x00002A9C
		private Content(global::UnityEngine.GUIContent content)
		{
			this.content = content;
			this.text = (content ?? global::UnityEngine.GUIContent.none).text;
			this.type = 2;
		}

		// Token: 0x06000114 RID: 276 RVA: 0x000048D0 File Offset: 0x00002AD0
		private Content(string text)
		{
			this.content = null;
			this.text = text;
			this.type = ((text != null) ? 1 : 0);
		}

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x06000115 RID: 277 RVA: 0x000048F4 File Offset: 0x00002AF4
		public global::UnityEngine.Texture image
		{
			get
			{
				return (this.type != 2) ? global::UnityEngine.GUIContent.none.image : this.content.image;
			}
		}

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x06000116 RID: 278 RVA: 0x00004928 File Offset: 0x00002B28
		public string tooltip
		{
			get
			{
				return (this.type != 2) ? global::UnityEngine.GUIContent.none.tooltip : this.content.tooltip;
			}
		}

		// Token: 0x06000117 RID: 279 RVA: 0x0000495C File Offset: 0x00002B5C
		public static implicit operator global::AuthorShared.Content(global::UnityEngine.GUIContent content)
		{
			return new global::AuthorShared.Content(content);
		}

		// Token: 0x06000118 RID: 280 RVA: 0x00004964 File Offset: 0x00002B64
		public static implicit operator global::AuthorShared.Content(string content)
		{
			return new global::AuthorShared.Content(content);
		}

		// Token: 0x06000119 RID: 281 RVA: 0x0000496C File Offset: 0x00002B6C
		public static implicit operator global::AuthorShared.Content(bool show)
		{
			if (show)
			{
				return new global::AuthorShared.Content(global::UnityEngine.GUIContent.none);
			}
			return default(global::AuthorShared.Content);
		}

		// Token: 0x0600011A RID: 282 RVA: 0x00004994 File Offset: 0x00002B94
		public static bool operator true(global::AuthorShared.Content content)
		{
			return content.type != 0;
		}

		// Token: 0x0600011B RID: 283 RVA: 0x000049A4 File Offset: 0x00002BA4
		public static bool operator false(global::AuthorShared.Content content)
		{
			return content.type == 0;
		}

		// Token: 0x0600011C RID: 284 RVA: 0x000049B0 File Offset: 0x00002BB0
		public static implicit operator global::UnityEngine.GUIContent(global::AuthorShared.Content content)
		{
			return global::AuthorShared.Content.g.GetOrTemp(content);
		}

		// Token: 0x0600011D RID: 285 RVA: 0x000049B8 File Offset: 0x00002BB8
		public static explicit operator string(global::AuthorShared.Content content)
		{
			return content.text;
		}

		// Token: 0x0400004C RID: 76
		public readonly int type;

		// Token: 0x0400004D RID: 77
		public readonly string text;

		// Token: 0x0400004E RID: 78
		public readonly global::UnityEngine.GUIContent content;

		// Token: 0x02000016 RID: 22
		private static class g
		{
			// Token: 0x0600011E RID: 286 RVA: 0x000049C4 File Offset: 0x00002BC4
			// Note: this type is marked as 'beforefieldinit'.
			static g()
			{
			}

			// Token: 0x0600011F RID: 287 RVA: 0x00004A74 File Offset: 0x00002C74
			public static global::UnityEngine.GUIContent GetOrTemp(global::AuthorShared.Content content)
			{
				if (content.type == 2)
				{
					return content.content;
				}
				if (content.type == 1)
				{
					global::UnityEngine.GUIContent guicontent = global::AuthorShared.Content.g.bufContents[global::AuthorShared.Content.g.bufPos];
					if (++global::AuthorShared.Content.g.bufPos == global::AuthorShared.Content.g.bufContents.Length)
					{
						global::AuthorShared.Content.g.bufPos = 0;
					}
					guicontent.text = content.text;
					guicontent.tooltip = global::AuthorShared.Content.g.noneCopy.tooltip;
					guicontent.image = global::AuthorShared.Content.g.noneCopy.image;
					return guicontent;
				}
				return global::AuthorShared.Content.g.noneCopy;
			}

			// Token: 0x0400004F RID: 79
			public static readonly global::UnityEngine.GUIContent noneCopy = new global::UnityEngine.GUIContent();

			// Token: 0x04000050 RID: 80
			public static readonly global::UnityEngine.GUIContent[] bufContents = new global::UnityEngine.GUIContent[]
			{
				new global::UnityEngine.GUIContent(),
				new global::UnityEngine.GUIContent(),
				new global::UnityEngine.GUIContent(),
				new global::UnityEngine.GUIContent(),
				new global::UnityEngine.GUIContent(),
				new global::UnityEngine.GUIContent(),
				new global::UnityEngine.GUIContent(),
				new global::UnityEngine.GUIContent(),
				new global::UnityEngine.GUIContent(),
				new global::UnityEngine.GUIContent(),
				new global::UnityEngine.GUIContent(),
				new global::UnityEngine.GUIContent(),
				new global::UnityEngine.GUIContent(),
				new global::UnityEngine.GUIContent(),
				new global::UnityEngine.GUIContent(),
				new global::UnityEngine.GUIContent()
			};

			// Token: 0x04000051 RID: 81
			private static int bufPos = 0;
		}
	}

	// Token: 0x02000017 RID: 23
	public enum ObjectKind
	{
		// Token: 0x04000053 RID: 83
		LevelInstance,
		// Token: 0x04000054 RID: 84
		Prefab,
		// Token: 0x04000055 RID: 85
		PrefabInstance = 3,
		// Token: 0x04000056 RID: 86
		Model = 2,
		// Token: 0x04000057 RID: 87
		ModelInstance = 4,
		// Token: 0x04000058 RID: 88
		MissingPrefabInstance,
		// Token: 0x04000059 RID: 89
		DisconnectedPrefabInstance,
		// Token: 0x0400005A RID: 90
		ScriptableObject,
		// Token: 0x0400005B RID: 91
		DisconnectedModelInstance,
		// Token: 0x0400005C RID: 92
		OtherAsset,
		// Token: 0x0400005D RID: 93
		OtherInstance,
		// Token: 0x0400005E RID: 94
		ScriptableObjectInstance,
		// Token: 0x0400005F RID: 95
		Null = -2
	}

	// Token: 0x02000018 RID: 24
	public static class Styles
	{
		// Token: 0x06000120 RID: 288 RVA: 0x00004B04 File Offset: 0x00002D04
		// Note: this type is marked as 'beforefieldinit'.
		static Styles()
		{
		}

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x06000121 RID: 289 RVA: 0x00004C18 File Offset: 0x00002E18
		public static global::UnityEngine.GUIStyle miniBoldLabel
		{
			get
			{
				return global::AuthorShared.Styles.label;
			}
		}

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x06000122 RID: 290 RVA: 0x00004C20 File Offset: 0x00002E20
		public static global::UnityEngine.GUIStyle boldLabel
		{
			get
			{
				return global::AuthorShared.Styles.label;
			}
		}

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x06000123 RID: 291 RVA: 0x00004C28 File Offset: 0x00002E28
		public static global::UnityEngine.GUIStyle largeLabel
		{
			get
			{
				return global::AuthorShared.Styles.label;
			}
		}

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x06000124 RID: 292 RVA: 0x00004C30 File Offset: 0x00002E30
		public static global::UnityEngine.GUIStyle largeWhiteLabel
		{
			get
			{
				return global::AuthorShared.Styles.label;
			}
		}

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x06000125 RID: 293 RVA: 0x00004C38 File Offset: 0x00002E38
		public static global::UnityEngine.GUIStyle miniButton
		{
			get
			{
				return global::AuthorShared.Styles.button;
			}
		}

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x06000126 RID: 294 RVA: 0x00004C40 File Offset: 0x00002E40
		public static global::UnityEngine.GUIStyle miniButtonLeft
		{
			get
			{
				return global::AuthorShared.Styles.button;
			}
		}

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x06000127 RID: 295 RVA: 0x00004C48 File Offset: 0x00002E48
		public static global::UnityEngine.GUIStyle miniButtonMid
		{
			get
			{
				return global::AuthorShared.Styles.button;
			}
		}

		// Token: 0x1700002D RID: 45
		// (get) Token: 0x06000128 RID: 296 RVA: 0x00004C50 File Offset: 0x00002E50
		public static global::UnityEngine.GUIStyle miniButtonRight
		{
			get
			{
				return global::AuthorShared.Styles.button;
			}
		}

		// Token: 0x1700002E RID: 46
		// (get) Token: 0x06000129 RID: 297 RVA: 0x00004C58 File Offset: 0x00002E58
		public static global::UnityEngine.GUIStyle miniLabel
		{
			get
			{
				return global::AuthorShared.Styles.label;
			}
		}

		// Token: 0x0600012A RID: 298 RVA: 0x00004C60 File Offset: 0x00002E60
		private static void RightAlignText(global::UnityEngine.GUIStyle original, ref global::UnityEngine.GUIStyle mod)
		{
			switch (original.alignment)
			{
			case 0:
			case 1:
				mod.alignment = 2;
				break;
			case 3:
			case 4:
				mod.alignment = 5;
				break;
			case 6:
			case 7:
				mod.alignment = 8;
				break;
			}
		}

		// Token: 0x0600012B RID: 299 RVA: 0x00004CC8 File Offset: 0x00002EC8
		private static void CenterAlignText(global::UnityEngine.GUIStyle original, ref global::UnityEngine.GUIStyle mod)
		{
			switch (original.alignment)
			{
			case 0:
			case 2:
				mod.alignment = 1;
				break;
			case 3:
			case 5:
				mod.alignment = 4;
				break;
			case 6:
			case 8:
				mod.alignment = 7;
				break;
			}
		}

		// Token: 0x0600012C RID: 300 RVA: 0x00004D34 File Offset: 0x00002F34
		private static void LeftAlignText(global::UnityEngine.GUIStyle original, ref global::UnityEngine.GUIStyle mod)
		{
			switch (original.alignment)
			{
			case 1:
			case 2:
				mod.alignment = 0;
				break;
			case 4:
			case 5:
				mod.alignment = 3;
				break;
			case 7:
			case 8:
				mod.alignment = 6;
				break;
			}
		}

		// Token: 0x0600012D RID: 301 RVA: 0x00004D9C File Offset: 0x00002F9C
		private static void IconAbove(global::UnityEngine.GUIStyle original, ref global::UnityEngine.GUIStyle mod)
		{
			mod.imagePosition = 1;
		}

		// Token: 0x0600012E RID: 302 RVA: 0x00004DA8 File Offset: 0x00002FA8
		private static void CreateGradientOutline(global::UnityEngine.GUIStyle original, ref global::UnityEngine.GUIStyle mod)
		{
			mod.border = new global::UnityEngine.RectOffset(1, 1, 1, 1);
			mod.normal = new global::UnityEngine.GUIStyleState();
			mod.normal.background = (global::UnityEngine.Texture2D)global::UnityEngine.Resources.LoadAssetAtPath("Assets/AuthorSuite/Editor Resources/Icons/GradientOutline.png", typeof(global::UnityEngine.Texture2D));
		}

		// Token: 0x0600012F RID: 303 RVA: 0x00004DF8 File Offset: 0x00002FF8
		private static void CreateGradientInline(global::UnityEngine.GUIStyle original, ref global::UnityEngine.GUIStyle mod)
		{
			mod.border = new global::UnityEngine.RectOffset(1, 1, 1, 1);
			mod.normal = new global::UnityEngine.GUIStyleState();
			mod.normal.background = (global::UnityEngine.Texture2D)global::UnityEngine.Resources.LoadAssetAtPath("Assets/AuthorSuite/Editor Resources/Icons/GradientInline.png", typeof(global::UnityEngine.Texture2D));
		}

		// Token: 0x06000130 RID: 304 RVA: 0x00004E48 File Offset: 0x00003048
		private static void CreateGradientOutlineFill(global::UnityEngine.GUIStyle original, ref global::UnityEngine.GUIStyle mod)
		{
			mod.border = new global::UnityEngine.RectOffset(1, 1, 1, 1);
			mod.normal = new global::UnityEngine.GUIStyleState();
			mod.normal.background = (global::UnityEngine.Texture2D)global::UnityEngine.Resources.LoadAssetAtPath("Assets/AuthorSuite/Editor Resources/Icons/GradientOutlineFill.png", typeof(global::UnityEngine.Texture2D));
		}

		// Token: 0x06000131 RID: 305 RVA: 0x00004E98 File Offset: 0x00003098
		private static void CreateGradientInlineFill(global::UnityEngine.GUIStyle original, ref global::UnityEngine.GUIStyle mod)
		{
			mod.border = new global::UnityEngine.RectOffset(1, 1, 1, 1);
			mod.normal = new global::UnityEngine.GUIStyleState();
			mod.normal.background = (global::UnityEngine.Texture2D)global::UnityEngine.Resources.LoadAssetAtPath("Assets/AuthorSuite/Editor Resources/Icons/GradientInlineFill.png", typeof(global::UnityEngine.Texture2D));
		}

		// Token: 0x06000132 RID: 306 RVA: 0x00004EE8 File Offset: 0x000030E8
		private static void CreateSubSectionTitleFill(global::UnityEngine.GUIStyle original, ref global::UnityEngine.GUIStyle mod)
		{
			global::AuthorShared.Styles.CreateGradientOutlineFill(original, ref mod);
			mod.alignment = 2;
			mod.font = global::AuthorShared.Styles.boldLabel.font;
			mod.normal.textColor = new global::UnityEngine.Color(0.03f, 0.03f, 0.03f, 1f);
			mod.stretchWidth = true;
		}

		// Token: 0x06000133 RID: 307 RVA: 0x00004F44 File Offset: 0x00003144
		private static void CreateInfoLabel(global::UnityEngine.GUIStyle original, ref global::UnityEngine.GUIStyle mod)
		{
			mod.alignment = 6;
			mod.normal.textColor = new global::UnityEngine.Color(1f, 1f, 1f, 0.17f);
		}

		// Token: 0x1700002F RID: 47
		// (get) Token: 0x06000134 RID: 308 RVA: 0x00004F80 File Offset: 0x00003180
		public static global::UnityEngine.GUIStyle peiceButtonLeft
		{
			get
			{
				return global::AuthorShared.Styles._peiceButtonLeft.GetStyle(global::AuthorShared.Styles.miniButtonLeft);
			}
		}

		// Token: 0x17000030 RID: 48
		// (get) Token: 0x06000135 RID: 309 RVA: 0x00004F94 File Offset: 0x00003194
		public static global::UnityEngine.GUIStyle peiceButtonMid
		{
			get
			{
				return global::AuthorShared.Styles._peiceButtonMid.GetStyle(global::AuthorShared.Styles.miniButtonMid);
			}
		}

		// Token: 0x17000031 RID: 49
		// (get) Token: 0x06000136 RID: 310 RVA: 0x00004FA8 File Offset: 0x000031A8
		public static global::UnityEngine.GUIStyle peiceButtonRight
		{
			get
			{
				return global::AuthorShared.Styles._peiceButtonRight.GetStyle(global::AuthorShared.Styles.miniButtonRight);
			}
		}

		// Token: 0x17000032 RID: 50
		// (get) Token: 0x06000137 RID: 311 RVA: 0x00004FBC File Offset: 0x000031BC
		public static global::UnityEngine.GUIStyle palletButton
		{
			get
			{
				return global::AuthorShared.Styles._palletButton.GetStyle(global::AuthorShared.Styles.miniButton);
			}
		}

		// Token: 0x17000033 RID: 51
		// (get) Token: 0x06000138 RID: 312 RVA: 0x00004FD0 File Offset: 0x000031D0
		public static global::UnityEngine.GUIStyle gradientOutline
		{
			get
			{
				return global::AuthorShared.Styles._gradientOutline.GetStyle(global::AuthorShared.Styles.box);
			}
		}

		// Token: 0x17000034 RID: 52
		// (get) Token: 0x06000139 RID: 313 RVA: 0x00004FE4 File Offset: 0x000031E4
		public static global::UnityEngine.GUIStyle gradientInline
		{
			get
			{
				return global::AuthorShared.Styles._gradientInline.GetStyle(global::AuthorShared.Styles.box);
			}
		}

		// Token: 0x17000035 RID: 53
		// (get) Token: 0x0600013A RID: 314 RVA: 0x00004FF8 File Offset: 0x000031F8
		public static global::UnityEngine.GUIStyle gradientOutlineFill
		{
			get
			{
				return global::AuthorShared.Styles._gradientOutlineFill.GetStyle(global::AuthorShared.Styles.box);
			}
		}

		// Token: 0x17000036 RID: 54
		// (get) Token: 0x0600013B RID: 315 RVA: 0x0000500C File Offset: 0x0000320C
		public static global::UnityEngine.GUIStyle gradientInlineFill
		{
			get
			{
				return global::AuthorShared.Styles._gradientInlineFill.GetStyle(global::AuthorShared.Styles.box);
			}
		}

		// Token: 0x17000037 RID: 55
		// (get) Token: 0x0600013C RID: 316 RVA: 0x00005020 File Offset: 0x00003220
		public static global::UnityEngine.GUIStyle button
		{
			get
			{
				return global::UnityEngine.GUI.skin.button;
			}
		}

		// Token: 0x17000038 RID: 56
		// (get) Token: 0x0600013D RID: 317 RVA: 0x0000502C File Offset: 0x0000322C
		public static global::UnityEngine.GUIStyle label
		{
			get
			{
				return global::UnityEngine.GUI.skin.label;
			}
		}

		// Token: 0x17000039 RID: 57
		// (get) Token: 0x0600013E RID: 318 RVA: 0x00005038 File Offset: 0x00003238
		public static global::UnityEngine.GUIStyle box
		{
			get
			{
				return global::UnityEngine.GUI.skin.box;
			}
		}

		// Token: 0x1700003A RID: 58
		// (get) Token: 0x0600013F RID: 319 RVA: 0x00005044 File Offset: 0x00003244
		public static global::UnityEngine.GUIStyle subSection
		{
			get
			{
				return global::AuthorShared.Styles.gradientOutline;
			}
		}

		// Token: 0x1700003B RID: 59
		// (get) Token: 0x06000140 RID: 320 RVA: 0x0000504C File Offset: 0x0000324C
		public static global::UnityEngine.GUIStyle subSectionTitle
		{
			get
			{
				return global::AuthorShared.Styles._subSectionTitle.GetStyle(global::AuthorShared.Styles.box);
			}
		}

		// Token: 0x1700003C RID: 60
		// (get) Token: 0x06000141 RID: 321 RVA: 0x00005060 File Offset: 0x00003260
		public static global::UnityEngine.GUIStyle infoLabel
		{
			get
			{
				return global::AuthorShared.Styles._infoLabel.GetStyle(global::AuthorShared.Styles.miniLabel);
			}
		}

		// Token: 0x04000060 RID: 96
		private static readonly global::AuthorShared.Styles.StyleModFunctor rightAlignText = new global::AuthorShared.Styles.StyleModFunctor(global::AuthorShared.Styles.RightAlignText);

		// Token: 0x04000061 RID: 97
		private static readonly global::AuthorShared.Styles.StyleModFunctor leftAlignText = new global::AuthorShared.Styles.StyleModFunctor(global::AuthorShared.Styles.LeftAlignText);

		// Token: 0x04000062 RID: 98
		private static readonly global::AuthorShared.Styles.StyleModFunctor centerAlignText = new global::AuthorShared.Styles.StyleModFunctor(global::AuthorShared.Styles.CenterAlignText);

		// Token: 0x04000063 RID: 99
		private static readonly global::AuthorShared.Styles.StyleModFunctor iconAbove = new global::AuthorShared.Styles.StyleModFunctor(global::AuthorShared.Styles.IconAbove);

		// Token: 0x04000064 RID: 100
		private static global::AuthorShared.Styles.StyleMod _peiceButtonLeft = new global::AuthorShared.Styles.StyleMod(global::AuthorShared.Styles.leftAlignText);

		// Token: 0x04000065 RID: 101
		private static global::AuthorShared.Styles.StyleMod _peiceButtonMid = new global::AuthorShared.Styles.StyleMod(global::AuthorShared.Styles.centerAlignText);

		// Token: 0x04000066 RID: 102
		private static global::AuthorShared.Styles.StyleMod _peiceButtonRight = new global::AuthorShared.Styles.StyleMod(global::AuthorShared.Styles.rightAlignText);

		// Token: 0x04000067 RID: 103
		private static global::AuthorShared.Styles.StyleMod _palletButton = new global::AuthorShared.Styles.StyleMod(global::AuthorShared.Styles.iconAbove);

		// Token: 0x04000068 RID: 104
		private static global::AuthorShared.Styles.StyleMod _gradientOutline = new global::AuthorShared.Styles.StyleMod(new global::AuthorShared.Styles.StyleModFunctor(global::AuthorShared.Styles.CreateGradientOutline));

		// Token: 0x04000069 RID: 105
		private static global::AuthorShared.Styles.StyleMod _gradientInline = new global::AuthorShared.Styles.StyleMod(new global::AuthorShared.Styles.StyleModFunctor(global::AuthorShared.Styles.CreateGradientInline));

		// Token: 0x0400006A RID: 106
		private static global::AuthorShared.Styles.StyleMod _gradientOutlineFill = new global::AuthorShared.Styles.StyleMod(new global::AuthorShared.Styles.StyleModFunctor(global::AuthorShared.Styles.CreateGradientOutlineFill));

		// Token: 0x0400006B RID: 107
		private static global::AuthorShared.Styles.StyleMod _gradientInlineFill = new global::AuthorShared.Styles.StyleMod(new global::AuthorShared.Styles.StyleModFunctor(global::AuthorShared.Styles.CreateGradientInlineFill));

		// Token: 0x0400006C RID: 108
		private static global::AuthorShared.Styles.StyleMod _subSectionTitle = new global::AuthorShared.Styles.StyleMod(new global::AuthorShared.Styles.StyleModFunctor(global::AuthorShared.Styles.CreateSubSectionTitleFill));

		// Token: 0x0400006D RID: 109
		private static global::AuthorShared.Styles.StyleMod _infoLabel = new global::AuthorShared.Styles.StyleMod(new global::AuthorShared.Styles.StyleModFunctor(global::AuthorShared.Styles.CreateInfoLabel));

		// Token: 0x02000019 RID: 25
		private struct StyleMod
		{
			// Token: 0x06000142 RID: 322 RVA: 0x00005074 File Offset: 0x00003274
			public StyleMod(global::AuthorShared.Styles.StyleModFunctor functor)
			{
				this.functor = functor;
				this.original = (this.modified = null);
			}

			// Token: 0x06000143 RID: 323 RVA: 0x00005098 File Offset: 0x00003298
			public global::UnityEngine.GUIStyle GetStyle(global::UnityEngine.GUIStyle original)
			{
				if (original == null)
				{
					return null;
				}
				if (this.original != original)
				{
					this.original = original;
					this.modified = new global::UnityEngine.GUIStyle(original);
					try
					{
						this.functor(original, ref this.modified);
						this.modified = (this.modified ?? this.original);
					}
					catch (global::System.Exception ex)
					{
						global::UnityEngine.Debug.LogError(ex);
					}
				}
				return this.modified;
			}

			// Token: 0x0400006E RID: 110
			public readonly global::AuthorShared.Styles.StyleModFunctor functor;

			// Token: 0x0400006F RID: 111
			private global::UnityEngine.GUIStyle original;

			// Token: 0x04000070 RID: 112
			private global::UnityEngine.GUIStyle modified;
		}

		// Token: 0x0200001A RID: 26
		// (Invoke) Token: 0x06000145 RID: 325
		private delegate void StyleModFunctor(global::UnityEngine.GUIStyle original, ref global::UnityEngine.GUIStyle mod);
	}

	// Token: 0x0200001B RID: 27
	protected static class Icon
	{
		// Token: 0x1700003D RID: 61
		// (get) Token: 0x06000148 RID: 328 RVA: 0x0000512C File Offset: 0x0000332C
		public static global::UnityEngine.Texture texSolo
		{
			get
			{
				return null;
			}
		}

		// Token: 0x1700003E RID: 62
		// (get) Token: 0x06000149 RID: 329 RVA: 0x00005130 File Offset: 0x00003330
		public static global::UnityEngine.Texture texDelete
		{
			get
			{
				return null;
			}
		}

		// Token: 0x1700003F RID: 63
		// (get) Token: 0x0600014A RID: 330 RVA: 0x00005134 File Offset: 0x00003334
		public static global::UnityEngine.GUIContent solo
		{
			get
			{
				global::UnityEngine.GUIContent result;
				if ((result = global::AuthorShared.Icon._solo) == null)
				{
					result = (global::AuthorShared.Icon._solo = new global::UnityEngine.GUIContent(global::AuthorShared.Icon.texSolo, "Solo Select"));
				}
				return result;
			}
		}

		// Token: 0x17000040 RID: 64
		// (get) Token: 0x0600014B RID: 331 RVA: 0x00005158 File Offset: 0x00003358
		public static global::UnityEngine.GUIContent delete
		{
			get
			{
				global::UnityEngine.GUIContent result;
				if ((result = global::AuthorShared.Icon._delete) == null)
				{
					result = (global::AuthorShared.Icon._delete = new global::UnityEngine.GUIContent(global::AuthorShared.Icon.texDelete, "Delete"));
				}
				return result;
			}
		}

		// Token: 0x04000071 RID: 113
		private static global::UnityEngine.GUIContent _solo;

		// Token: 0x04000072 RID: 114
		private static global::UnityEngine.GUIContent _delete;
	}

	// Token: 0x0200001C RID: 28
	public enum ObjectFieldFlags
	{
		// Token: 0x04000074 RID: 116
		AllowScene = 1,
		// Token: 0x04000075 RID: 117
		ForbidNull,
		// Token: 0x04000076 RID: 118
		Prefab = 4,
		// Token: 0x04000077 RID: 119
		Model = 8,
		// Token: 0x04000078 RID: 120
		Instance = 0x10,
		// Token: 0x04000079 RID: 121
		NotPrefab = 0x20,
		// Token: 0x0400007A RID: 122
		NotModel = 0x40,
		// Token: 0x0400007B RID: 123
		NotInstance = 0x80,
		// Token: 0x0400007C RID: 124
		Asset = 0x100,
		// Token: 0x0400007D RID: 125
		Root = 0x200
	}

	// Token: 0x0200001D RID: 29
	private static class Hash
	{
		// Token: 0x0600014C RID: 332 RVA: 0x0000517C File Offset: 0x0000337C
		static Hash()
		{
		}

		// Token: 0x0400007E RID: 126
		public static readonly int s_PopupHash = "EditorPopup".GetHashCode();
	}

	// Token: 0x0200001E RID: 30
	private struct AuthorOptionGenerate
	{
		// Token: 0x0400007F RID: 127
		public global::AuthorCreation creation;

		// Token: 0x04000080 RID: 128
		public global::AuthorShared self;

		// Token: 0x04000081 RID: 129
		public global::AuthorPeice peice;

		// Token: 0x04000082 RID: 130
		public global::System.Type type;

		// Token: 0x04000083 RID: 131
		public bool allowSelf;

		// Token: 0x04000084 RID: 132
		public bool selectedOnly;
	}

	// Token: 0x0200001F RID: 31
	public struct PropMod
	{
		// Token: 0x0600014D RID: 333 RVA: 0x00005190 File Offset: 0x00003390
		public static global::AuthorShared.PropMod New()
		{
			return default(global::AuthorShared.PropMod);
		}

		// Token: 0x0600014E RID: 334 RVA: 0x000051A8 File Offset: 0x000033A8
		public static global::AuthorShared.PropMod[] Get(global::UnityEngine.Object o)
		{
			return new global::AuthorShared.PropMod[0];
		}

		// Token: 0x17000041 RID: 65
		// (get) Token: 0x0600014F RID: 335 RVA: 0x000051B0 File Offset: 0x000033B0
		public string propertyPath
		{
			get
			{
				return string.Empty;
			}
		}

		// Token: 0x17000042 RID: 66
		// (get) Token: 0x06000150 RID: 336 RVA: 0x000051B8 File Offset: 0x000033B8
		public string value
		{
			get
			{
				return string.Empty;
			}
		}

		// Token: 0x17000043 RID: 67
		// (get) Token: 0x06000151 RID: 337 RVA: 0x000051C0 File Offset: 0x000033C0
		public global::UnityEngine.Object objectReference
		{
			get
			{
				return null;
			}
		}

		// Token: 0x17000044 RID: 68
		// (get) Token: 0x06000152 RID: 338 RVA: 0x000051C4 File Offset: 0x000033C4
		public global::UnityEngine.Object target
		{
			get
			{
				return null;
			}
		}

		// Token: 0x06000153 RID: 339 RVA: 0x000051C8 File Offset: 0x000033C8
		public static void Set(global::UnityEngine.Object o, global::AuthorShared.PropMod[] mod)
		{
		}
	}

	// Token: 0x02000020 RID: 32
	public static class Scene
	{
		// Token: 0x17000045 RID: 69
		// (get) Token: 0x06000154 RID: 340 RVA: 0x000051CC File Offset: 0x000033CC
		// (set) Token: 0x06000155 RID: 341 RVA: 0x000051D4 File Offset: 0x000033D4
		public static global::UnityEngine.Matrix4x4 matrix
		{
			get
			{
				return global::UnityEngine.Matrix4x4.identity;
			}
			set
			{
			}
		}

		// Token: 0x17000046 RID: 70
		// (get) Token: 0x06000156 RID: 342 RVA: 0x000051D8 File Offset: 0x000033D8
		// (set) Token: 0x06000157 RID: 343 RVA: 0x000051E0 File Offset: 0x000033E0
		public static global::UnityEngine.Color color
		{
			get
			{
				return global::UnityEngine.Color.white;
			}
			set
			{
			}
		}

		// Token: 0x17000047 RID: 71
		// (get) Token: 0x06000158 RID: 344 RVA: 0x000051E4 File Offset: 0x000033E4
		// (set) Token: 0x06000159 RID: 345 RVA: 0x000051E8 File Offset: 0x000033E8
		public static bool lighting
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		// Token: 0x0600015A RID: 346 RVA: 0x000051EC File Offset: 0x000033EC
		public static void GetUpAndRight(ref global::UnityEngine.Vector3 forward, out global::UnityEngine.Vector3 right, out global::UnityEngine.Vector3 up)
		{
			forward.Normalize();
			float num = global::UnityEngine.Vector3.Dot(forward, global::UnityEngine.Vector3.up);
			if (num * num > 0.80999994f)
			{
				if (forward.x * forward.x <= forward.z * forward.z)
				{
					up = global::UnityEngine.Vector3.Cross(forward, global::UnityEngine.Vector3.right);
				}
				else
				{
					up = global::UnityEngine.Vector3.Cross(forward, global::UnityEngine.Vector3.forward);
				}
				up.Normalize();
				right = global::UnityEngine.Vector3.Cross(forward, up);
				right.Normalize();
			}
			else
			{
				right = global::UnityEngine.Vector3.Cross(forward, global::UnityEngine.Vector3.up);
				right.Normalize();
				up = global::UnityEngine.Vector3.Cross(forward, right);
				up.Normalize();
			}
			if (global::UnityEngine.Vector3.Dot(global::UnityEngine.Vector3.Cross(up, forward), right) < 0f)
			{
				right = -right;
			}
		}

		// Token: 0x0600015B RID: 347 RVA: 0x00005308 File Offset: 0x00003508
		private static void DrawSphereNow(global::UnityEngine.Vector3 center, float radius)
		{
		}

		// Token: 0x0600015C RID: 348 RVA: 0x0000530C File Offset: 0x0000350C
		private static void DrawCapsuleNow(global::UnityEngine.Vector3 center, float radius, float height, int axis)
		{
		}

		// Token: 0x0600015D RID: 349 RVA: 0x00005310 File Offset: 0x00003510
		private static void DrawBoxNow(global::UnityEngine.Vector3 center, global::UnityEngine.Vector3 size)
		{
		}

		// Token: 0x0600015E RID: 350 RVA: 0x00005314 File Offset: 0x00003514
		private static void DrawBoneNow(global::UnityEngine.Vector3 origin, global::UnityEngine.Quaternion forward, float length, float backLength, global::UnityEngine.Vector3 size)
		{
		}

		// Token: 0x0600015F RID: 351 RVA: 0x00005318 File Offset: 0x00003518
		public static void DrawSphere(global::UnityEngine.Vector3 center, float radius)
		{
		}

		// Token: 0x06000160 RID: 352 RVA: 0x0000531C File Offset: 0x0000351C
		public static void DrawCapsule(global::UnityEngine.Vector3 center, float radius, float height, int axis)
		{
		}

		// Token: 0x06000161 RID: 353 RVA: 0x00005320 File Offset: 0x00003520
		public static void DrawBox(global::UnityEngine.Vector3 center, global::UnityEngine.Vector3 size)
		{
		}

		// Token: 0x06000162 RID: 354 RVA: 0x00005324 File Offset: 0x00003524
		public static void DrawBone(global::UnityEngine.Vector3 origin, global::UnityEngine.Quaternion rot, float length, float backLength, global::UnityEngine.Vector3 size)
		{
		}

		// Token: 0x06000163 RID: 355 RVA: 0x00005328 File Offset: 0x00003528
		public static bool SphereDrag(ref global::UnityEngine.Vector3 center, ref float radius)
		{
			return false;
		}

		// Token: 0x06000164 RID: 356 RVA: 0x0000532C File Offset: 0x0000352C
		public static bool PointDrag(ref global::UnityEngine.Vector3 anchor)
		{
			return false;
		}

		// Token: 0x06000165 RID: 357 RVA: 0x00005330 File Offset: 0x00003530
		public static bool PointDrag(ref global::UnityEngine.Vector3 anchor, ref global::UnityEngine.Vector3 axis)
		{
			return false;
		}

		// Token: 0x06000166 RID: 358 RVA: 0x00005334 File Offset: 0x00003534
		public static bool PivotDrag(ref global::UnityEngine.Vector3 anchor, ref global::UnityEngine.Vector3 axis)
		{
			return false;
		}

		// Token: 0x06000167 RID: 359 RVA: 0x00005338 File Offset: 0x00003538
		public static float? GetAxialAngleDifference(global::UnityEngine.Quaternion a, global::UnityEngine.Quaternion b)
		{
			float num;
			global::UnityEngine.Vector3 vector;
			a.ToAngleAxis(ref num, ref vector);
			float num2;
			global::UnityEngine.Vector3 vector2;
			b.ToAngleAxis(ref num2, ref vector2);
			float num3 = global::UnityEngine.Vector3.Dot(vector, vector2);
			if (global::UnityEngine.Mathf.Approximately(num3, 1f))
			{
				return new float?(global::UnityEngine.Mathf.DeltaAngle(num, num2));
			}
			if (global::UnityEngine.Mathf.Approximately(num3, -1f))
			{
				return new float?(global::UnityEngine.Mathf.DeltaAngle(num, -num2));
			}
			return null;
		}

		// Token: 0x06000168 RID: 360 RVA: 0x000053AC File Offset: 0x000035AC
		public static bool LimitDrag(global::UnityEngine.Vector3 anchor, global::UnityEngine.Vector3 axis, ref float min, ref float max)
		{
			float num = 0f;
			return global::AuthorShared.Scene.LimitDrag(anchor, axis, ref num, ref min, ref max) && num == 0f;
		}

		// Token: 0x06000169 RID: 361 RVA: 0x000053DC File Offset: 0x000035DC
		public static bool LimitDrag(global::UnityEngine.Vector3 anchor, global::UnityEngine.Vector3 axis, ref float offset, ref float min, ref float max)
		{
			return false;
		}

		// Token: 0x0600016A RID: 362 RVA: 0x000053E0 File Offset: 0x000035E0
		public static bool LimitDragBothWays(global::UnityEngine.Vector3 anchor, global::UnityEngine.Vector3 axis, ref float angle)
		{
			float num = 0f;
			return global::AuthorShared.Scene.LimitDragBothWays(anchor, axis, ref num, ref angle) && num == 0f;
		}

		// Token: 0x0600016B RID: 363 RVA: 0x00005410 File Offset: 0x00003610
		public static bool LimitDragBothWays(global::UnityEngine.Vector3 anchor, global::UnityEngine.Vector3 axis, ref float offset, ref float angle)
		{
			return false;
		}

		// Token: 0x0600016C RID: 364 RVA: 0x00005414 File Offset: 0x00003614
		public static bool LimitDrag(global::UnityEngine.Vector3 anchor, global::UnityEngine.Vector3 axis, ref global::UnityEngine.JointLimits limit)
		{
			float min = limit.min;
			float max = limit.max;
			if (global::AuthorShared.Scene.LimitDrag(anchor, axis, ref min, ref max))
			{
				limit.min = min;
				limit.max = max;
				limit.min = min;
				return true;
			}
			return false;
		}

		// Token: 0x0600016D RID: 365 RVA: 0x00005458 File Offset: 0x00003658
		public static bool LimitDrag(global::UnityEngine.Vector3 anchor, global::UnityEngine.Vector3 axis, ref float offset, ref global::UnityEngine.JointLimits limit)
		{
			float min = limit.min;
			float max = limit.max;
			if (global::AuthorShared.Scene.LimitDrag(anchor, axis, ref offset, ref min, ref max))
			{
				limit.min = min;
				limit.max = max;
				return true;
			}
			return false;
		}

		// Token: 0x0600016E RID: 366 RVA: 0x00005498 File Offset: 0x00003698
		public static bool LimitDrag(global::UnityEngine.Vector3 anchor, global::UnityEngine.Vector3 axis, ref global::UnityEngine.SoftJointLimit low, ref global::UnityEngine.SoftJointLimit high)
		{
			float num = low.limit;
			float num2 = high.limit;
			if (global::AuthorShared.Scene.LimitDrag(anchor, axis, ref num, ref num2))
			{
				if (num != low.limit)
				{
					num = global::UnityEngine.Mathf.Clamp(num, -180f, 180f);
					if (num != low.limit)
					{
						low.limit = num;
						return true;
					}
					return false;
				}
				else
				{
					if (num2 == high.limit)
					{
						return true;
					}
					num2 = global::UnityEngine.Mathf.Clamp(num2, -180f, 180f);
					if (num2 != high.limit)
					{
						high.limit = num2;
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x0600016F RID: 367 RVA: 0x00005534 File Offset: 0x00003734
		public static bool LimitDrag(global::UnityEngine.Vector3 anchor, global::UnityEngine.Vector3 axis, ref global::UnityEngine.SoftJointLimit bothWays)
		{
			float limit = bothWays.limit;
			if (global::AuthorShared.Scene.LimitDragBothWays(anchor, axis, ref limit))
			{
				bothWays.limit = limit;
				return true;
			}
			return false;
		}

		// Token: 0x06000170 RID: 368 RVA: 0x00005560 File Offset: 0x00003760
		public static bool LimitDrag(global::UnityEngine.Vector3 anchor, global::UnityEngine.Vector3 axis, ref float offset, ref global::UnityEngine.SoftJointLimit low, ref global::UnityEngine.SoftJointLimit high)
		{
			float num = low.limit;
			float num2 = high.limit;
			if (global::AuthorShared.Scene.LimitDrag(anchor, axis, ref offset, ref num, ref num2))
			{
				if (num != low.limit)
				{
					num = global::UnityEngine.Mathf.Clamp(num, -180f, 180f);
					if (num != low.limit)
					{
						low.limit = num;
						return true;
					}
					return false;
				}
				else
				{
					if (num2 == high.limit)
					{
						return true;
					}
					num2 = global::UnityEngine.Mathf.Clamp(num2, -180f, 180f);
					if (num2 != high.limit)
					{
						high.limit = num2;
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x06000171 RID: 369 RVA: 0x00005600 File Offset: 0x00003800
		public static bool LimitDrag(global::UnityEngine.Vector3 anchor, global::UnityEngine.Vector3 axis, ref float offset, ref global::UnityEngine.SoftJointLimit bothWays)
		{
			float limit = bothWays.limit;
			if (global::AuthorShared.Scene.LimitDragBothWays(anchor, axis, ref offset, ref limit))
			{
				bothWays.limit = limit;
				return true;
			}
			return false;
		}

		// Token: 0x06000172 RID: 370 RVA: 0x00005630 File Offset: 0x00003830
		private static float CapRadius(float radius, float height, int axis, int heightAxis)
		{
			if (heightAxis == axis)
			{
				return radius + height / 2f;
			}
			return radius;
		}

		// Token: 0x06000173 RID: 371 RVA: 0x00005644 File Offset: 0x00003844
		private static global::UnityEngine.Vector3 Direction(int i)
		{
			switch (i % 3)
			{
			default:
				return (i / 3 % 2 * (i / 3 % 2) != 1) ? global::UnityEngine.Vector3.right : global::UnityEngine.Vector3.left;
			case 1:
				return (i / 3 % 2 * (i / 3 % 2) != 1) ? global::UnityEngine.Vector3.up : global::UnityEngine.Vector3.down;
			case 2:
				return (i / 3 % 2 * (i / 3 % 2) != 1) ? global::UnityEngine.Vector3.forward : global::UnityEngine.Vector3.back;
			}
		}

		// Token: 0x06000174 RID: 372 RVA: 0x000056D0 File Offset: 0x000038D0
		public static bool CapsuleDrag(ref global::UnityEngine.Vector3 center, ref float radius, ref float height, ref int heightAxis)
		{
			return false;
		}

		// Token: 0x06000175 RID: 373 RVA: 0x000056D4 File Offset: 0x000038D4
		public static bool BoxDrag(ref global::UnityEngine.Vector3 center, ref global::UnityEngine.Vector3 size)
		{
			return false;
		}

		// Token: 0x04000085 RID: 133
		private const int SHAPE_MESH = 0;

		// Token: 0x04000086 RID: 134
		private const int SHAPE_DISH = 1;

		// Token: 0x04000087 RID: 135
		private const int SHAPE_BONE = 2;

		// Token: 0x04000088 RID: 136
		private const int SHAPE_BOX = 3;

		// Token: 0x04000089 RID: 137
		private const int SHAPE_CAPSULE_X = 4;

		// Token: 0x0400008A RID: 138
		private const int SHAPE_CAPSULE_Y = 5;

		// Token: 0x0400008B RID: 139
		private const int SHAPE_CAPSULE_Z = 6;

		// Token: 0x0400008C RID: 140
		private const int SHAPE_SPHERE = 7;

		// Token: 0x0400008D RID: 141
		private const int kShapeCount = 8;

		// Token: 0x0400008E RID: 142
		private const string _ToolColor = "_Tc";

		// Token: 0x0400008F RID: 143
		private const string _Radius = "_Rv";

		// Token: 0x04000090 RID: 144
		private const string _Height = "_Hv";

		// Token: 0x04000091 RID: 145
		private const string _Sides = "_S3";

		// Token: 0x04000092 RID: 146
		private const string _LightScale = "_Lv";

		// Token: 0x04000093 RID: 147
		private const string _BoneParameters = "_B4";

		// Token: 0x02000021 RID: 33
		private static class Keyword
		{
			// Token: 0x06000176 RID: 374 RVA: 0x000056D8 File Offset: 0x000038D8
			static Keyword()
			{
				for (int i = 0; i < 8; i++)
				{
					int num = 0;
					for (int j = 0; j < 3; j++)
					{
						if ((i & 1 << j) == 1 << j)
						{
							num++;
						}
					}
					global::AuthorShared.Scene.Keyword.SHAPE[i] = new string[num];
					int num2 = 0;
					for (int k = 0; k < 3; k++)
					{
						if ((i & 1 << k) == 1 << k)
						{
							global::AuthorShared.Scene.Keyword.SHAPE[i][num2++] = global::AuthorShared.Scene.Keyword.BIT_STRINGS[k];
						}
					}
				}
			}

			// Token: 0x04000094 RID: 148
			private const int BIT_STRINGS_LENGTH = 3;

			// Token: 0x04000095 RID: 149
			private static readonly string[] BIT_STRINGS = new string[]
			{
				"SBA",
				"SBB",
				"SBC"
			};

			// Token: 0x04000096 RID: 150
			public static readonly string[][] SHAPE = new string[8][];
		}
	}

	// Token: 0x02000022 RID: 34
	public enum PeiceAction
	{
		// Token: 0x04000098 RID: 152
		None,
		// Token: 0x04000099 RID: 153
		AddToSelection,
		// Token: 0x0400009A RID: 154
		RemoveFromSelection,
		// Token: 0x0400009B RID: 155
		SelectSolo,
		// Token: 0x0400009C RID: 156
		Delete,
		// Token: 0x0400009D RID: 157
		Dirty,
		// Token: 0x0400009E RID: 158
		Ping
	}

	// Token: 0x02000023 RID: 35
	public struct PeiceCommand
	{
		// Token: 0x0400009F RID: 159
		public global::AuthorPeice peice;

		// Token: 0x040000A0 RID: 160
		public global::AuthorShared.PeiceAction action;
	}

	// Token: 0x02000024 RID: 36
	protected class AttributeKeyValueList
	{
		// Token: 0x06000177 RID: 375 RVA: 0x000057A0 File Offset: 0x000039A0
		public AttributeKeyValueList(params object[] keysThenValues) : this(keysThenValues)
		{
		}

		// Token: 0x06000178 RID: 376 RVA: 0x000057AC File Offset: 0x000039AC
		public AttributeKeyValueList(global::System.Collections.IEnumerable keysThenValues)
		{
			this.dict = new global::System.Collections.Generic.Dictionary<global::AuthTarg, global::System.Collections.ArrayList>();
			global::AuthTarg? authTarg = null;
			global::System.Collections.IEnumerator enumerator = null;
			try
			{
				enumerator = keysThenValues.GetEnumerator();
				if (enumerator != null)
				{
					while (enumerator.MoveNext())
					{
						object obj = enumerator.Current;
						if (obj is global::AuthTarg)
						{
							authTarg = new global::AuthTarg?((global::AuthTarg)((int)obj));
						}
						else if (authTarg == null || object.ReferenceEquals(obj, null))
						{
							continue;
						}
						global::System.Collections.ArrayList arrayList;
						if (!this.dict.TryGetValue(authTarg.Value, out arrayList))
						{
							arrayList = (this.dict[authTarg.Value] = new global::System.Collections.ArrayList());
						}
						arrayList.Add(obj);
					}
				}
			}
			finally
			{
				if (enumerator is global::System.IDisposable)
				{
					((global::System.IDisposable)enumerator).Dispose();
				}
			}
		}

		// Token: 0x06000179 RID: 377 RVA: 0x000058AC File Offset: 0x00003AAC
		private static void RunInstance(global::UnityEngine.MonoBehaviour instance, global::AuthorShared.AttributeKeyValueList.AuthField attribute, global::System.Collections.ArrayList args)
		{
			object value = attribute.field.GetValue(instance);
			if ((!(value is global::UnityEngine.Object)) ? (value != null) : ((global::UnityEngine.Object)value))
			{
				return;
			}
			global::System.Type fieldType = attribute.field.FieldType;
			bool flag = typeof(global::UnityEngine.Component).IsAssignableFrom(fieldType);
			bool flag2 = !flag && typeof(global::UnityEngine.GameObject).IsAssignableFrom(fieldType);
			if (flag == flag2)
			{
				return;
			}
			if (global::AuthorShared.AttributeKeyValueList.Search(instance, attribute, args, flag, ref value))
			{
				attribute.field.SetValue(instance, value);
			}
		}

		// Token: 0x0600017A RID: 378 RVA: 0x0000594C File Offset: 0x00003B4C
		private static bool Search(global::UnityEngine.MonoBehaviour instance, global::AuthorShared.AttributeKeyValueList.AuthField attribute, global::System.Collections.ArrayList args, bool isComponent, ref object value)
		{
			global::AuthOptions authOptions = attribute.options & (global::AuthOptions.SearchDown | global::AuthOptions.SearchUp);
			bool flag = authOptions != (global::AuthOptions)0;
			bool flag2 = !flag || (attribute.options & global::AuthOptions.SearchInclusive) == global::AuthOptions.SearchInclusive;
			if (flag2 && global::AuthorShared.AttributeKeyValueList.SearchGameObject(instance.gameObject, attribute, args, isComponent, ref value))
			{
				return true;
			}
			if (flag)
			{
				if ((authOptions & global::AuthOptions.SearchDown) == global::AuthOptions.SearchDown)
				{
					if ((attribute.options & (global::AuthOptions.SearchUp | global::AuthOptions.SearchReverse)) == (global::AuthOptions.SearchUp | global::AuthOptions.SearchReverse))
					{
						if (global::AuthorShared.AttributeKeyValueList.SearchGameObjectUp(instance.gameObject, attribute, args, isComponent, ref value))
						{
							return true;
						}
						authOptions &= ~global::AuthOptions.SearchUp;
					}
					if (global::AuthorShared.AttributeKeyValueList.SearchGameObjectDown(instance.gameObject, attribute, args, isComponent, ref value))
					{
						return true;
					}
				}
				if ((authOptions & global::AuthOptions.SearchUp) == global::AuthOptions.SearchUp && global::AuthorShared.AttributeKeyValueList.SearchGameObjectUp(instance.gameObject, attribute, args, isComponent, ref value))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600017B RID: 379 RVA: 0x00005A10 File Offset: 0x00003C10
		private static bool SearchGameObject(global::UnityEngine.GameObject self, global::AuthorShared.AttributeKeyValueList.AuthField attribute, global::System.Collections.ArrayList options, bool isComponent, ref object value)
		{
			foreach (object obj in options)
			{
				if (obj is global::UnityEngine.Object)
				{
					global::UnityEngine.Object @object = (global::UnityEngine.Object)obj;
					if (@object)
					{
						if ((attribute.options & (global::AuthOptions)4) == (global::AuthOptions)0 || !(@object.name != attribute.nameMask))
						{
							if (isComponent)
							{
								global::UnityEngine.Component component;
								if (@object is global::UnityEngine.GameObject)
								{
									global::UnityEngine.GameObject gameObject = (global::UnityEngine.GameObject)@object;
									component = gameObject.GetComponent(attribute.field.FieldType);
								}
								else if (attribute.field.FieldType.IsAssignableFrom(@object.GetType()))
								{
									component = (global::UnityEngine.Component)@object;
								}
								else
								{
									if (!(@object is global::UnityEngine.Component))
									{
										continue;
									}
									component = ((global::UnityEngine.Component)@object).GetComponent(attribute.field.FieldType);
								}
								if (component)
								{
									value = component;
									return true;
								}
							}
							else if (@object is global::UnityEngine.GameObject)
							{
								value = (global::UnityEngine.GameObject)@object;
								return true;
							}
						}
					}
				}
			}
			return false;
		}

		// Token: 0x0600017C RID: 380 RVA: 0x00005B80 File Offset: 0x00003D80
		private static global::System.Collections.Generic.IEnumerable<global::UnityEngine.Component> GetComponentDown(global::UnityEngine.GameObject go, global::System.Type type, global::UnityEngine.Transform childSkip)
		{
			if (go && typeof(global::UnityEngine.Component).IsAssignableFrom(type))
			{
				foreach (object child in go.transform)
				{
					if (child as global::UnityEngine.Transform && (global::UnityEngine.Transform)child != childSkip)
					{
						foreach (global::UnityEngine.Component component in ((global::UnityEngine.Transform)child).gameObject.GetComponentsInChildren(type, true))
						{
							yield return component;
						}
					}
				}
			}
			yield break;
		}

		// Token: 0x0600017D RID: 381 RVA: 0x00005BC8 File Offset: 0x00003DC8
		private static global::System.Collections.Generic.IEnumerable<global::UnityEngine.Component> GetComponentDown(global::UnityEngine.GameObject go, global::System.Type type)
		{
			if (go && typeof(global::UnityEngine.Component).IsAssignableFrom(type))
			{
				foreach (object child in go.transform)
				{
					if (child as global::UnityEngine.Transform)
					{
						foreach (global::UnityEngine.Component component in ((global::UnityEngine.Transform)child).gameObject.GetComponentsInChildren(type, true))
						{
							yield return component;
						}
					}
				}
			}
			yield break;
		}

		// Token: 0x0600017E RID: 382 RVA: 0x00005C00 File Offset: 0x00003E00
		private static global::System.Collections.Generic.IEnumerable<global::UnityEngine.Component> GetComponentUp(global::UnityEngine.GameObject go, global::System.Type type, bool andThenDown)
		{
			if (go && typeof(global::UnityEngine.Component).IsAssignableFrom(type))
			{
				int upCount = 0;
				global::UnityEngine.Transform parent = go.transform.parent;
				if (parent)
				{
					do
					{
						upCount++;
						foreach (global::UnityEngine.Component component in parent.GetComponents(type))
						{
							yield return component;
						}
						parent = parent.parent;
					}
					while (parent);
					if (!andThenDown)
					{
						yield break;
					}
					while (upCount > 0)
					{
						parent = go.transform.parent;
						global::UnityEngine.Transform skip = go.transform;
						upCount--;
						for (int i = 0; i < upCount; i++)
						{
							parent = parent.parent;
							skip = skip.parent;
						}
						foreach (global::UnityEngine.Component child in global::AuthorShared.AttributeKeyValueList.GetComponentDown(parent.gameObject, type, skip))
						{
							yield return child;
						}
					}
				}
			}
			yield break;
		}

		// Token: 0x0600017F RID: 383 RVA: 0x00005C48 File Offset: 0x00003E48
		private static bool SearchGameObjectDown(global::UnityEngine.GameObject self, global::AuthorShared.AttributeKeyValueList.AuthField attribute, global::System.Collections.ArrayList options, bool isComponent, ref object value)
		{
			global::System.Type type = (!isComponent) ? typeof(global::UnityEngine.Transform) : attribute.field.FieldType;
			foreach (object obj in options)
			{
				if (obj is global::UnityEngine.Object)
				{
					global::UnityEngine.Object @object = (global::UnityEngine.Object)obj;
					if (@object)
					{
						global::UnityEngine.GameObject go;
						if (@object is global::UnityEngine.GameObject)
						{
							go = (global::UnityEngine.GameObject)@object;
						}
						else
						{
							if (!(@object is global::UnityEngine.Component))
							{
								continue;
							}
							go = ((global::UnityEngine.Component)@object).gameObject;
						}
						foreach (global::UnityEngine.Component component in global::AuthorShared.AttributeKeyValueList.GetComponentDown(go, type))
						{
							if ((attribute.options & (global::AuthOptions)4) == (global::AuthOptions)0 || !(component.name != attribute.nameMask))
							{
								if (isComponent)
								{
									value = component;
									return true;
								}
								global::UnityEngine.GameObject gameObject = component.gameObject;
								if (gameObject)
								{
									value = gameObject;
									return true;
								}
							}
						}
					}
				}
			}
			return false;
		}

		// Token: 0x06000180 RID: 384 RVA: 0x00005DE0 File Offset: 0x00003FE0
		private static bool SearchGameObjectUp(global::UnityEngine.GameObject self, global::AuthorShared.AttributeKeyValueList.AuthField attribute, global::System.Collections.ArrayList options, bool isComponent, ref object value)
		{
			global::System.Type type = (!isComponent) ? typeof(global::UnityEngine.Transform) : attribute.field.FieldType;
			foreach (object obj in options)
			{
				if (obj is global::UnityEngine.Object)
				{
					global::UnityEngine.Object @object = (global::UnityEngine.Object)obj;
					if (@object)
					{
						global::UnityEngine.GameObject go;
						if (@object is global::UnityEngine.GameObject)
						{
							go = (global::UnityEngine.GameObject)@object;
						}
						else
						{
							if (!(@object is global::UnityEngine.Component))
							{
								continue;
							}
							go = ((global::UnityEngine.Component)@object).gameObject;
						}
						foreach (global::UnityEngine.Component component in global::AuthorShared.AttributeKeyValueList.GetComponentUp(go, type, false))
						{
							if ((attribute.options & (global::AuthOptions)4) == (global::AuthOptions)0 || !(component.name != attribute.nameMask))
							{
								if (isComponent)
								{
									value = component;
									return true;
								}
								global::UnityEngine.GameObject gameObject = component.gameObject;
								if (gameObject)
								{
									value = gameObject;
									return true;
								}
							}
						}
					}
				}
			}
			return false;
		}

		// Token: 0x06000181 RID: 385 RVA: 0x00005F7C File Offset: 0x0000417C
		public void Run(global::UnityEngine.MonoBehaviour script)
		{
			if (this.dict.Count > 0)
			{
				global::AuthorShared.AttributeKeyValueList.TypeRunner.Exec(script, this);
			}
		}

		// Token: 0x06000182 RID: 386 RVA: 0x00005F98 File Offset: 0x00004198
		public void Run(global::UnityEngine.GameObject go)
		{
			if (this.dict.Count > 0 && go)
			{
				foreach (global::UnityEngine.MonoBehaviour monoBehaviour in go.GetComponentsInChildren<global::UnityEngine.MonoBehaviour>(true))
				{
					global::AuthorShared.AttributeKeyValueList.TypeRunner.Exec(monoBehaviour, this);
				}
			}
		}

		// Token: 0x040000A1 RID: 161
		private global::System.Collections.Generic.Dictionary<global::AuthTarg, global::System.Collections.ArrayList> dict;

		// Token: 0x02000025 RID: 37
		private class AuthField
		{
			// Token: 0x06000183 RID: 387 RVA: 0x00005FE8 File Offset: 0x000041E8
			public AuthField()
			{
			}

			// Token: 0x040000A2 RID: 162
			public global::System.Reflection.FieldInfo field;

			// Token: 0x040000A3 RID: 163
			public global::AuthOptions options;

			// Token: 0x040000A4 RID: 164
			public string nameMask;
		}

		// Token: 0x02000026 RID: 38
		private class TypeRunnerPlatform
		{
			// Token: 0x06000184 RID: 388 RVA: 0x00005FF0 File Offset: 0x000041F0
			public TypeRunnerPlatform()
			{
			}

			// Token: 0x06000185 RID: 389 RVA: 0x00005FF8 File Offset: 0x000041F8
			public void Exec(object instance, global::AuthorShared.AttributeKeyValueList kv)
			{
				if (this.hasBase)
				{
					this.@base.Exec(instance, kv);
				}
				if (this.hasDelegate)
				{
					this.exec(instance, kv);
				}
			}

			// Token: 0x040000A5 RID: 165
			public global::AuthorShared.AttributeKeyValueList.TypeRunnerExec exec;

			// Token: 0x040000A6 RID: 166
			public global::AuthorShared.AttributeKeyValueList.TypeRunnerPlatform @base;

			// Token: 0x040000A7 RID: 167
			public bool tested;

			// Token: 0x040000A8 RID: 168
			public bool hasDelegate;

			// Token: 0x040000A9 RID: 169
			public bool hasBase;
		}

		// Token: 0x02000027 RID: 39
		private static class TypeRunner
		{
			// Token: 0x06000186 RID: 390 RVA: 0x00006038 File Offset: 0x00004238
			// Note: this type is marked as 'beforefieldinit'.
			static TypeRunner()
			{
			}

			// Token: 0x06000187 RID: 391 RVA: 0x00006044 File Offset: 0x00004244
			private static void GeneratePlatform(global::System.Type type, out global::AuthorShared.AttributeKeyValueList.TypeRunnerPlatform platform)
			{
				if (type.BaseType == typeof(global::UnityEngine.MonoBehaviour))
				{
					platform = null;
				}
				else if (!global::AuthorShared.AttributeKeyValueList.TypeRunner.platforms.TryGetValue(type.BaseType, out platform))
				{
					global::AuthorShared.AttributeKeyValueList.TypeRunner.GeneratePlatform(type.BaseType, out platform);
				}
				global::AuthorShared.AttributeKeyValueList.TypeRunnerExec typeRunnerExec = (global::AuthorShared.AttributeKeyValueList.TypeRunnerExec)typeof(global::AuthorShared.AttributeKeyValueList.TypeRunner<>).MakeGenericType(new global::System.Type[]
				{
					type
				}).GetField("exec", global::System.Reflection.BindingFlags.Static | global::System.Reflection.BindingFlags.Public | global::System.Reflection.BindingFlags.NonPublic).GetValue(null);
				if (typeRunnerExec != null)
				{
					if (platform != null && platform.exec != null)
					{
						typeRunnerExec = (global::AuthorShared.AttributeKeyValueList.TypeRunnerExec)global::System.Delegate.Combine(typeRunnerExec, platform.exec);
					}
				}
				else if (platform != null)
				{
					typeRunnerExec = platform.exec;
				}
				global::System.Collections.Generic.Dictionary<global::System.Type, global::AuthorShared.AttributeKeyValueList.TypeRunnerPlatform> dictionary = global::AuthorShared.AttributeKeyValueList.TypeRunner.platforms;
				global::AuthorShared.AttributeKeyValueList.TypeRunnerPlatform value;
				platform = (value = new global::AuthorShared.AttributeKeyValueList.TypeRunnerPlatform
				{
					@base = platform,
					exec = typeRunnerExec,
					hasBase = (platform != null),
					hasDelegate = (typeRunnerExec != null),
					tested = true
				});
				dictionary[type] = value;
			}

			// Token: 0x06000188 RID: 392 RVA: 0x0000614C File Offset: 0x0000434C
			public static void Exec(global::UnityEngine.MonoBehaviour monoBehaviour, global::AuthorShared.AttributeKeyValueList kv)
			{
				if (monoBehaviour)
				{
					global::System.Type type = monoBehaviour.GetType();
					if (type != typeof(global::UnityEngine.MonoBehaviour))
					{
						global::AuthorShared.AttributeKeyValueList.TypeRunnerPlatform typeRunnerPlatform;
						if (!global::AuthorShared.AttributeKeyValueList.TypeRunner.platforms.TryGetValue(type, out typeRunnerPlatform))
						{
							global::AuthorShared.AttributeKeyValueList.TypeRunner.GeneratePlatform(type, out typeRunnerPlatform);
						}
						typeRunnerPlatform.Exec(monoBehaviour, kv);
					}
				}
			}

			// Token: 0x06000189 RID: 393 RVA: 0x000061A0 File Offset: 0x000043A0
			public static bool TestAttribute<T>(global::System.Reflection.FieldInfo field, out T[] attribs) where T : global::System.Attribute
			{
				if (global::System.Attribute.IsDefined(field, typeof(T)))
				{
					global::System.Attribute[] customAttributes = global::System.Attribute.GetCustomAttributes(field, typeof(T), false);
					if (customAttributes.Length > 0)
					{
						attribs = new T[customAttributes.Length];
						for (int i = 0; i < customAttributes.Length; i++)
						{
							attribs[i] = (T)((object)customAttributes[i]);
						}
						return true;
					}
				}
				attribs = null;
				return false;
			}

			// Token: 0x040000AA RID: 170
			private static readonly global::System.Collections.Generic.Dictionary<global::System.Type, global::AuthorShared.AttributeKeyValueList.TypeRunnerPlatform> platforms = new global::System.Collections.Generic.Dictionary<global::System.Type, global::AuthorShared.AttributeKeyValueList.TypeRunnerPlatform>();
		}

		// Token: 0x02000028 RID: 40
		private static class TypeRunner<T> where T : global::UnityEngine.MonoBehaviour
		{
			// Token: 0x0600018A RID: 394 RVA: 0x00006214 File Offset: 0x00004414
			static TypeRunner()
			{
				global::System.Reflection.FieldInfo[] array = typeof(T).GetFields(global::System.Reflection.BindingFlags.DeclaredOnly | global::System.Reflection.BindingFlags.Instance | global::System.Reflection.BindingFlags.Public | global::System.Reflection.BindingFlags.NonPublic);
				int num = array.Length;
				for (int i = 0; i < num; i++)
				{
					global::PostAuthAttribute[] array2;
					if (global::AuthorShared.AttributeKeyValueList.TypeRunner.TestAttribute<global::PostAuthAttribute>(array[i], out array2))
					{
						global::System.Collections.Generic.List<global::System.Collections.Generic.KeyValuePair<global::AuthTarg, global::AuthorShared.AttributeKeyValueList.AuthField>> list = new global::System.Collections.Generic.List<global::System.Collections.Generic.KeyValuePair<global::AuthTarg, global::AuthorShared.AttributeKeyValueList.AuthField>>();
						bool flag;
						do
						{
							flag = false;
							int num2 = 0;
							int num3 = array2.Length;
							do
							{
								list.Add(new global::System.Collections.Generic.KeyValuePair<global::AuthTarg, global::AuthorShared.AttributeKeyValueList.AuthField>(array2[num2].target, new global::AuthorShared.AttributeKeyValueList.AuthField
								{
									field = array[i],
									options = array2[num2].options,
									nameMask = array2[num2].nameMask
								}));
							}
							while (++num2 < num3);
							while (++i < num)
							{
								if (flag = global::AuthorShared.AttributeKeyValueList.TypeRunner.TestAttribute<global::PostAuthAttribute>(array[i], out array2))
								{
									break;
								}
							}
						}
						while (flag);
						global::AuthorShared.AttributeKeyValueList.TypeRunner<T>.fields = list.ToArray();
						global::AuthorShared.AttributeKeyValueList.TypeRunner<T>.fieldCount = global::AuthorShared.AttributeKeyValueList.TypeRunner<T>.fields.Length;
						global::AuthorShared.AttributeKeyValueList.TypeRunner<T>.exec = new global::AuthorShared.AttributeKeyValueList.TypeRunnerExec(global::AuthorShared.AttributeKeyValueList.TypeRunner<T>.Exec);
						return;
					}
				}
				global::AuthorShared.AttributeKeyValueList.TypeRunner<T>.exec = null;
				global::AuthorShared.AttributeKeyValueList.TypeRunner<T>.fieldCount = 0;
				global::AuthorShared.AttributeKeyValueList.TypeRunner<T>.fields = null;
			}

			// Token: 0x0600018B RID: 395 RVA: 0x0000632C File Offset: 0x0000452C
			private static void Exec(object instance, global::AuthorShared.AttributeKeyValueList list)
			{
				global::UnityEngine.MonoBehaviour instance2 = (global::UnityEngine.MonoBehaviour)instance;
				for (int i = 0; i < global::AuthorShared.AttributeKeyValueList.TypeRunner<T>.fieldCount; i++)
				{
					global::System.Collections.ArrayList args;
					if (list.dict.TryGetValue(global::AuthorShared.AttributeKeyValueList.TypeRunner<T>.fields[i].Key, out args))
					{
						global::AuthorShared.AttributeKeyValueList.RunInstance(instance2, global::AuthorShared.AttributeKeyValueList.TypeRunner<T>.fields[i].Value, args);
					}
				}
			}

			// Token: 0x040000AB RID: 171
			private static readonly global::System.Collections.Generic.KeyValuePair<global::AuthTarg, global::AuthorShared.AttributeKeyValueList.AuthField>[] fields;

			// Token: 0x040000AC RID: 172
			private static readonly int fieldCount;

			// Token: 0x040000AD RID: 173
			private static readonly global::AuthorShared.AttributeKeyValueList.TypeRunnerExec exec;
		}

		// Token: 0x02000029 RID: 41
		// (Invoke) Token: 0x0600018D RID: 397
		private delegate void TypeRunnerExec(object instance, global::AuthorShared.AttributeKeyValueList kv);

		// Token: 0x0200002A RID: 42
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private sealed class <GetComponentDown>c__Iterator0 : global::System.Collections.Generic.IEnumerable<global::UnityEngine.Component>, global::System.Collections.Generic.IEnumerator<global::UnityEngine.Component>, global::System.IDisposable, global::System.Collections.IEnumerator, global::System.Collections.IEnumerable
		{
			// Token: 0x06000190 RID: 400 RVA: 0x00006390 File Offset: 0x00004590
			public <GetComponentDown>c__Iterator0()
			{
			}

			// Token: 0x17000048 RID: 72
			// (get) Token: 0x06000191 RID: 401 RVA: 0x00006398 File Offset: 0x00004598
			global::UnityEngine.Component global::System.Collections.Generic.IEnumerator<global::UnityEngine.Component>.Current
			{
				[global::System.Diagnostics.DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x17000049 RID: 73
			// (get) Token: 0x06000192 RID: 402 RVA: 0x000063A0 File Offset: 0x000045A0
			object global::System.Collections.IEnumerator.Current
			{
				[global::System.Diagnostics.DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x06000193 RID: 403 RVA: 0x000063A8 File Offset: 0x000045A8
			[global::System.Diagnostics.DebuggerHidden]
			global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
			{
				return this.System.Collections.Generic.IEnumerable<UnityEngine.Component>.GetEnumerator();
			}

			// Token: 0x06000194 RID: 404 RVA: 0x000063B0 File Offset: 0x000045B0
			[global::System.Diagnostics.DebuggerHidden]
			global::System.Collections.Generic.IEnumerator<global::UnityEngine.Component> global::System.Collections.Generic.IEnumerable<global::UnityEngine.Component>.GetEnumerator()
			{
				if (global::System.Threading.Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
				{
					return this;
				}
				global::AuthorShared.AttributeKeyValueList.<GetComponentDown>c__Iterator0 <GetComponentDown>c__Iterator = new global::AuthorShared.AttributeKeyValueList.<GetComponentDown>c__Iterator0();
				<GetComponentDown>c__Iterator.go = go;
				<GetComponentDown>c__Iterator.type = type;
				<GetComponentDown>c__Iterator.childSkip = childSkip;
				return <GetComponentDown>c__Iterator;
			}

			// Token: 0x06000195 RID: 405 RVA: 0x000063FC File Offset: 0x000045FC
			public bool MoveNext()
			{
				uint num = (uint)this.$PC;
				this.$PC = -1;
				bool flag = false;
				switch (num)
				{
				case 0U:
					if (!go || !typeof(global::UnityEngine.Component).IsAssignableFrom(type))
					{
						goto IL_164;
					}
					enumerator = go.transform.GetEnumerator();
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
					case 1U:
						i++;
						goto IL_121;
					}
					IL_134:
					while (enumerator.MoveNext())
					{
						child = enumerator.Current;
						if (child as global::UnityEngine.Transform && (global::UnityEngine.Transform)child != childSkip)
						{
							componentsInChildren = ((global::UnityEngine.Transform)child).gameObject.GetComponentsInChildren(type, true);
							i = 0;
							goto IL_121;
						}
					}
					goto IL_164;
					IL_121:
					if (i >= componentsInChildren.Length)
					{
						goto IL_134;
					}
					component = componentsInChildren[i];
					this.$current = component;
					this.$PC = 1;
					flag = true;
					return true;
				}
				finally
				{
					if (!flag)
					{
						global::System.IDisposable disposable = enumerator as global::System.IDisposable;
						if (disposable != null)
						{
							disposable.Dispose();
						}
					}
				}
				IL_164:
				this.$PC = -1;
				return false;
			}

			// Token: 0x06000196 RID: 406 RVA: 0x00006598 File Offset: 0x00004798
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
						global::System.IDisposable disposable = enumerator as global::System.IDisposable;
						if (disposable != null)
						{
							disposable.Dispose();
						}
					}
					break;
				}
			}

			// Token: 0x06000197 RID: 407 RVA: 0x00006600 File Offset: 0x00004800
			[global::System.Diagnostics.DebuggerHidden]
			public void Reset()
			{
				throw new global::System.NotSupportedException();
			}

			// Token: 0x040000AE RID: 174
			internal global::UnityEngine.GameObject go;

			// Token: 0x040000AF RID: 175
			internal global::System.Type type;

			// Token: 0x040000B0 RID: 176
			internal global::System.Collections.IEnumerator <$s_3>__0;

			// Token: 0x040000B1 RID: 177
			internal object <child>__1;

			// Token: 0x040000B2 RID: 178
			internal global::UnityEngine.Transform childSkip;

			// Token: 0x040000B3 RID: 179
			internal global::UnityEngine.Component[] <$s_4>__2;

			// Token: 0x040000B4 RID: 180
			internal int <$s_5>__3;

			// Token: 0x040000B5 RID: 181
			internal global::UnityEngine.Component <component>__4;

			// Token: 0x040000B6 RID: 182
			internal int $PC;

			// Token: 0x040000B7 RID: 183
			internal global::UnityEngine.Component $current;

			// Token: 0x040000B8 RID: 184
			internal global::UnityEngine.GameObject <$>go;

			// Token: 0x040000B9 RID: 185
			internal global::System.Type <$>type;

			// Token: 0x040000BA RID: 186
			internal global::UnityEngine.Transform <$>childSkip;
		}

		// Token: 0x0200002B RID: 43
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private sealed class <GetComponentDown>c__Iterator1 : global::System.Collections.Generic.IEnumerable<global::UnityEngine.Component>, global::System.Collections.Generic.IEnumerator<global::UnityEngine.Component>, global::System.IDisposable, global::System.Collections.IEnumerator, global::System.Collections.IEnumerable
		{
			// Token: 0x06000198 RID: 408 RVA: 0x00006608 File Offset: 0x00004808
			public <GetComponentDown>c__Iterator1()
			{
			}

			// Token: 0x1700004A RID: 74
			// (get) Token: 0x06000199 RID: 409 RVA: 0x00006610 File Offset: 0x00004810
			global::UnityEngine.Component global::System.Collections.Generic.IEnumerator<global::UnityEngine.Component>.Current
			{
				[global::System.Diagnostics.DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x1700004B RID: 75
			// (get) Token: 0x0600019A RID: 410 RVA: 0x00006618 File Offset: 0x00004818
			object global::System.Collections.IEnumerator.Current
			{
				[global::System.Diagnostics.DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x0600019B RID: 411 RVA: 0x00006620 File Offset: 0x00004820
			[global::System.Diagnostics.DebuggerHidden]
			global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
			{
				return this.System.Collections.Generic.IEnumerable<UnityEngine.Component>.GetEnumerator();
			}

			// Token: 0x0600019C RID: 412 RVA: 0x00006628 File Offset: 0x00004828
			[global::System.Diagnostics.DebuggerHidden]
			global::System.Collections.Generic.IEnumerator<global::UnityEngine.Component> global::System.Collections.Generic.IEnumerable<global::UnityEngine.Component>.GetEnumerator()
			{
				if (global::System.Threading.Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
				{
					return this;
				}
				global::AuthorShared.AttributeKeyValueList.<GetComponentDown>c__Iterator1 <GetComponentDown>c__Iterator = new global::AuthorShared.AttributeKeyValueList.<GetComponentDown>c__Iterator1();
				<GetComponentDown>c__Iterator.go = go;
				<GetComponentDown>c__Iterator.type = type;
				return <GetComponentDown>c__Iterator;
			}

			// Token: 0x0600019D RID: 413 RVA: 0x00006668 File Offset: 0x00004868
			public bool MoveNext()
			{
				uint num = (uint)this.$PC;
				this.$PC = -1;
				bool flag = false;
				switch (num)
				{
				case 0U:
					if (!go || !typeof(global::UnityEngine.Component).IsAssignableFrom(type))
					{
						goto IL_149;
					}
					enumerator = go.transform.GetEnumerator();
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
					case 1U:
						i++;
						goto IL_106;
					}
					IL_119:
					while (enumerator.MoveNext())
					{
						child = enumerator.Current;
						if (child as global::UnityEngine.Transform)
						{
							componentsInChildren = ((global::UnityEngine.Transform)child).gameObject.GetComponentsInChildren(type, true);
							i = 0;
							goto IL_106;
						}
					}
					goto IL_149;
					IL_106:
					if (i >= componentsInChildren.Length)
					{
						goto IL_119;
					}
					component = componentsInChildren[i];
					this.$current = component;
					this.$PC = 1;
					flag = true;
					return true;
				}
				finally
				{
					if (!flag)
					{
						global::System.IDisposable disposable = enumerator as global::System.IDisposable;
						if (disposable != null)
						{
							disposable.Dispose();
						}
					}
				}
				IL_149:
				this.$PC = -1;
				return false;
			}

			// Token: 0x0600019E RID: 414 RVA: 0x000067E8 File Offset: 0x000049E8
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
						global::System.IDisposable disposable = enumerator as global::System.IDisposable;
						if (disposable != null)
						{
							disposable.Dispose();
						}
					}
					break;
				}
			}

			// Token: 0x0600019F RID: 415 RVA: 0x00006850 File Offset: 0x00004A50
			[global::System.Diagnostics.DebuggerHidden]
			public void Reset()
			{
				throw new global::System.NotSupportedException();
			}

			// Token: 0x040000BB RID: 187
			internal global::UnityEngine.GameObject go;

			// Token: 0x040000BC RID: 188
			internal global::System.Type type;

			// Token: 0x040000BD RID: 189
			internal global::System.Collections.IEnumerator <$s_6>__0;

			// Token: 0x040000BE RID: 190
			internal object <child>__1;

			// Token: 0x040000BF RID: 191
			internal global::UnityEngine.Component[] <$s_7>__2;

			// Token: 0x040000C0 RID: 192
			internal int <$s_8>__3;

			// Token: 0x040000C1 RID: 193
			internal global::UnityEngine.Component <component>__4;

			// Token: 0x040000C2 RID: 194
			internal int $PC;

			// Token: 0x040000C3 RID: 195
			internal global::UnityEngine.Component $current;

			// Token: 0x040000C4 RID: 196
			internal global::UnityEngine.GameObject <$>go;

			// Token: 0x040000C5 RID: 197
			internal global::System.Type <$>type;
		}

		// Token: 0x0200002C RID: 44
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private sealed class <GetComponentUp>c__Iterator2 : global::System.Collections.Generic.IEnumerable<global::UnityEngine.Component>, global::System.Collections.Generic.IEnumerator<global::UnityEngine.Component>, global::System.IDisposable, global::System.Collections.IEnumerator, global::System.Collections.IEnumerable
		{
			// Token: 0x060001A0 RID: 416 RVA: 0x00006858 File Offset: 0x00004A58
			public <GetComponentUp>c__Iterator2()
			{
			}

			// Token: 0x1700004C RID: 76
			// (get) Token: 0x060001A1 RID: 417 RVA: 0x00006860 File Offset: 0x00004A60
			global::UnityEngine.Component global::System.Collections.Generic.IEnumerator<global::UnityEngine.Component>.Current
			{
				[global::System.Diagnostics.DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x1700004D RID: 77
			// (get) Token: 0x060001A2 RID: 418 RVA: 0x00006868 File Offset: 0x00004A68
			object global::System.Collections.IEnumerator.Current
			{
				[global::System.Diagnostics.DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x060001A3 RID: 419 RVA: 0x00006870 File Offset: 0x00004A70
			[global::System.Diagnostics.DebuggerHidden]
			global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
			{
				return this.System.Collections.Generic.IEnumerable<UnityEngine.Component>.GetEnumerator();
			}

			// Token: 0x060001A4 RID: 420 RVA: 0x00006878 File Offset: 0x00004A78
			[global::System.Diagnostics.DebuggerHidden]
			global::System.Collections.Generic.IEnumerator<global::UnityEngine.Component> global::System.Collections.Generic.IEnumerable<global::UnityEngine.Component>.GetEnumerator()
			{
				if (global::System.Threading.Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
				{
					return this;
				}
				global::AuthorShared.AttributeKeyValueList.<GetComponentUp>c__Iterator2 <GetComponentUp>c__Iterator = new global::AuthorShared.AttributeKeyValueList.<GetComponentUp>c__Iterator2();
				<GetComponentUp>c__Iterator.go = go;
				<GetComponentUp>c__Iterator.type = type;
				<GetComponentUp>c__Iterator.andThenDown = andThenDown;
				return <GetComponentUp>c__Iterator;
			}

			// Token: 0x060001A5 RID: 421 RVA: 0x000068C4 File Offset: 0x00004AC4
			public bool MoveNext()
			{
				uint num = (uint)this.$PC;
				this.$PC = -1;
				bool flag = false;
				switch (num)
				{
				case 0U:
					if (!go || !typeof(global::UnityEngine.Component).IsAssignableFrom(type))
					{
						goto IL_253;
					}
					upCount = 0;
					parent = go.transform.parent;
					if (!parent)
					{
						goto IL_253;
					}
					break;
				case 1U:
					j++;
					goto IL_E8;
				case 2U:
					Block_8:
					try
					{
						switch (num)
						{
						}
						if (enumerator.MoveNext())
						{
							child = enumerator.Current;
							this.$current = child;
							this.$PC = 2;
							flag = true;
							return true;
						}
					}
					finally
					{
						if (!flag)
						{
							if (enumerator != null)
							{
								enumerator.Dispose();
							}
						}
					}
					goto IL_247;
				default:
					return false;
				}
				IL_7E:
				upCount++;
				components = parent.GetComponents(type);
				j = 0;
				IL_E8:
				if (j < components.Length)
				{
					component = components[j];
					this.$current = component;
					this.$PC = 1;
					return true;
				}
				parent = parent.parent;
				if (parent)
				{
					goto IL_7E;
				}
				if (!andThenDown)
				{
					return false;
				}
				IL_247:
				if (upCount > 0)
				{
					parent = go.transform.parent;
					skip = go.transform;
					upCount--;
					for (i = 0; i < upCount; i++)
					{
						parent = parent.parent;
						skip = skip.parent;
					}
					enumerator = global::AuthorShared.AttributeKeyValueList.GetComponentDown(parent.gameObject, type, skip).GetEnumerator();
					num = 0xFFFFFFFDU;
					goto Block_8;
				}
				IL_253:
				this.$PC = -1;
				return false;
			}

			// Token: 0x060001A6 RID: 422 RVA: 0x00006B4C File Offset: 0x00004D4C
			[global::System.Diagnostics.DebuggerHidden]
			public void Dispose()
			{
				uint num = (uint)this.$PC;
				this.$PC = -1;
				switch (num)
				{
				case 2U:
					try
					{
					}
					finally
					{
						if (enumerator != null)
						{
							enumerator.Dispose();
						}
					}
					break;
				}
			}

			// Token: 0x060001A7 RID: 423 RVA: 0x00006BB4 File Offset: 0x00004DB4
			[global::System.Diagnostics.DebuggerHidden]
			public void Reset()
			{
				throw new global::System.NotSupportedException();
			}

			// Token: 0x040000C6 RID: 198
			internal global::UnityEngine.GameObject go;

			// Token: 0x040000C7 RID: 199
			internal global::System.Type type;

			// Token: 0x040000C8 RID: 200
			internal int <upCount>__0;

			// Token: 0x040000C9 RID: 201
			internal global::UnityEngine.Transform <parent>__1;

			// Token: 0x040000CA RID: 202
			internal global::UnityEngine.Component[] <$s_9>__2;

			// Token: 0x040000CB RID: 203
			internal int <$s_10>__3;

			// Token: 0x040000CC RID: 204
			internal global::UnityEngine.Component <component>__4;

			// Token: 0x040000CD RID: 205
			internal bool andThenDown;

			// Token: 0x040000CE RID: 206
			internal global::UnityEngine.Transform <skip>__5;

			// Token: 0x040000CF RID: 207
			internal int <i>__6;

			// Token: 0x040000D0 RID: 208
			internal global::System.Collections.Generic.IEnumerator<global::UnityEngine.Component> <$s_11>__7;

			// Token: 0x040000D1 RID: 209
			internal global::UnityEngine.Component <child>__8;

			// Token: 0x040000D2 RID: 210
			internal int $PC;

			// Token: 0x040000D3 RID: 211
			internal global::UnityEngine.Component $current;

			// Token: 0x040000D4 RID: 212
			internal global::UnityEngine.GameObject <$>go;

			// Token: 0x040000D5 RID: 213
			internal global::System.Type <$>type;

			// Token: 0x040000D6 RID: 214
			internal bool <$>andThenDown;
		}
	}

	// Token: 0x0200002D RID: 45
	// (Invoke) Token: 0x060001A9 RID: 425
	public delegate void CustomMenuProc(object userData, string[] options, int selected);

	// Token: 0x0200002E RID: 46
	// (Invoke) Token: 0x060001AD RID: 429
	private delegate bool GenerateOptions(object args, ref int selected, out global::UnityEngine.GUIContent[] options, out global::System.Array values);

	// Token: 0x0200002F RID: 47
	// (Invoke) Token: 0x060001B1 RID: 433
	public delegate bool ArrayFieldFunctor<T>(ref T value);
}
