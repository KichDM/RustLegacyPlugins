using System;
using System.Linq;
using System.Reflection;
using UnityEngine;

// Token: 0x02000848 RID: 2120
[global::System.Serializable]
public class dfComponentMemberInfo
{
	// Token: 0x0600494E RID: 18766 RVA: 0x00112470 File Offset: 0x00110670
	public dfComponentMemberInfo()
	{
	}

	// Token: 0x17000DC5 RID: 3525
	// (get) Token: 0x0600494F RID: 18767 RVA: 0x00112478 File Offset: 0x00110678
	public bool IsValid
	{
		get
		{
			return this.Component != null && !string.IsNullOrEmpty(this.MemberName) && this.Component.GetType().GetMember(this.MemberName).FirstOrDefault<global::System.Reflection.MemberInfo>() != null;
		}
	}

	// Token: 0x06004950 RID: 18768 RVA: 0x001124D8 File Offset: 0x001106D8
	public global::System.Type GetMemberType()
	{
		global::System.Type type = this.Component.GetType();
		global::System.Reflection.MemberInfo memberInfo = type.GetMember(this.MemberName).FirstOrDefault<global::System.Reflection.MemberInfo>();
		if (memberInfo == null)
		{
			throw new global::System.MissingMemberException("Member not found: " + type.Name + "." + this.MemberName);
		}
		if (memberInfo is global::System.Reflection.FieldInfo)
		{
			return ((global::System.Reflection.FieldInfo)memberInfo).FieldType;
		}
		if (memberInfo is global::System.Reflection.PropertyInfo)
		{
			return ((global::System.Reflection.PropertyInfo)memberInfo).PropertyType;
		}
		if (memberInfo is global::System.Reflection.MethodInfo)
		{
			return ((global::System.Reflection.MethodInfo)memberInfo).ReturnType;
		}
		if (memberInfo is global::System.Reflection.EventInfo)
		{
			return ((global::System.Reflection.EventInfo)memberInfo).EventHandlerType;
		}
		throw new global::System.InvalidCastException("Invalid member type: " + memberInfo.MemberType);
	}

	// Token: 0x06004951 RID: 18769 RVA: 0x001125A0 File Offset: 0x001107A0
	public global::System.Reflection.MethodInfo GetMethod()
	{
		return this.Component.GetType().GetMember(this.MemberName, global::System.Reflection.BindingFlags.Instance | global::System.Reflection.BindingFlags.Public | global::System.Reflection.BindingFlags.NonPublic).FirstOrDefault<global::System.Reflection.MemberInfo>() as global::System.Reflection.MethodInfo;
	}

	// Token: 0x06004952 RID: 18770 RVA: 0x001125D4 File Offset: 0x001107D4
	public global::dfObservableProperty GetProperty()
	{
		global::System.Type type = this.Component.GetType();
		global::System.Reflection.MemberInfo memberInfo = this.Component.GetType().GetMember(this.MemberName).FirstOrDefault<global::System.Reflection.MemberInfo>();
		if (memberInfo == null)
		{
			throw new global::System.MissingMemberException("Member not found: " + type.Name + "." + this.MemberName);
		}
		if (!(memberInfo is global::System.Reflection.FieldInfo) && !(memberInfo is global::System.Reflection.PropertyInfo))
		{
			throw new global::System.InvalidCastException("Member " + this.MemberName + " is not an observable field or property");
		}
		return new global::dfObservableProperty(this.Component, memberInfo);
	}

	// Token: 0x06004953 RID: 18771 RVA: 0x00112670 File Offset: 0x00110870
	public override string ToString()
	{
		string arg = (!(this.Component != null)) ? "[Missing ComponentType]" : this.Component.GetType().Name;
		string arg2 = string.IsNullOrEmpty(this.MemberName) ? "[Missing MemberName]" : this.MemberName;
		return string.Format("{0}.{1}", arg, arg2);
	}

	// Token: 0x04002715 RID: 10005
	public global::UnityEngine.Component Component;

	// Token: 0x04002716 RID: 10006
	public string MemberName;
}
