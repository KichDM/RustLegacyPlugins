using System;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x0200083D RID: 2109
public static class ReflectionExtensions
{
	// Token: 0x06004857 RID: 18519 RVA: 0x0010D37C File Offset: 0x0010B57C
	public static global::System.Reflection.FieldInfo[] GetAllFields(this global::System.Type type)
	{
		if (type == null)
		{
			return new global::System.Reflection.FieldInfo[0];
		}
		global::System.Reflection.BindingFlags bindingAttr = global::System.Reflection.BindingFlags.DeclaredOnly | global::System.Reflection.BindingFlags.Instance | global::System.Reflection.BindingFlags.Public | global::System.Reflection.BindingFlags.NonPublic;
		return (from f in type.GetFields(bindingAttr).Concat(type.BaseType.GetAllFields())
		where !f.IsDefined(typeof(global::UnityEngine.HideInInspector), true)
		select f).ToArray<global::System.Reflection.FieldInfo>();
	}

	// Token: 0x06004858 RID: 18520 RVA: 0x0010D3D8 File Offset: 0x0010B5D8
	public static object GetProperty(this object target, string property)
	{
		if (target == null)
		{
			throw new global::System.NullReferenceException("Target is null");
		}
		global::System.Reflection.MemberInfo[] member = target.GetType().GetMember(property, global::System.Reflection.BindingFlags.Instance | global::System.Reflection.BindingFlags.Public | global::System.Reflection.BindingFlags.NonPublic);
		if (member == null || member.Length == 0)
		{
			throw new global::System.IndexOutOfRangeException("Property not found: " + property);
		}
		global::System.Reflection.MemberInfo memberInfo = member[0];
		if (memberInfo is global::System.Reflection.FieldInfo)
		{
			return ((global::System.Reflection.FieldInfo)memberInfo).GetValue(target);
		}
		if (memberInfo is global::System.Reflection.PropertyInfo)
		{
			return ((global::System.Reflection.PropertyInfo)memberInfo).GetValue(target, null);
		}
		throw new global::System.InvalidOperationException("Member type not supported: " + memberInfo.MemberType);
	}

	// Token: 0x06004859 RID: 18521 RVA: 0x0010D474 File Offset: 0x0010B674
	public static void SetProperty(this object target, string property, object value)
	{
		if (target == null)
		{
			throw new global::System.NullReferenceException("Target is null");
		}
		global::System.Reflection.MemberInfo[] member = target.GetType().GetMember(property, global::System.Reflection.BindingFlags.Instance | global::System.Reflection.BindingFlags.Public | global::System.Reflection.BindingFlags.NonPublic);
		if (member == null || member.Length == 0)
		{
			throw new global::System.IndexOutOfRangeException("Property not found: " + property);
		}
		global::System.Reflection.MemberInfo memberInfo = member[0];
		if (memberInfo is global::System.Reflection.FieldInfo)
		{
			((global::System.Reflection.FieldInfo)memberInfo).SetValue(target, value);
			return;
		}
		if (memberInfo is global::System.Reflection.PropertyInfo)
		{
			((global::System.Reflection.PropertyInfo)memberInfo).SetValue(target, value, null);
			return;
		}
		throw new global::System.InvalidOperationException("Member type not supported: " + memberInfo.MemberType);
	}

	// Token: 0x0600485A RID: 18522 RVA: 0x0010D514 File Offset: 0x0010B714
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private static bool <GetAllFields>m__28(global::System.Reflection.FieldInfo f)
	{
		return !f.IsDefined(typeof(global::UnityEngine.HideInInspector), true);
	}

	// Token: 0x040026C2 RID: 9922
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private static global::System.Func<global::System.Reflection.FieldInfo, bool> <>f__am$cache0;
}
