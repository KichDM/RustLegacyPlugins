using System;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x020001FD RID: 509
[global::System.AttributeUsage(global::System.AttributeTargets.Class)]
public class InterfaceDriverComponentAttribute : global::System.Attribute
{
	// Token: 0x06000DD1 RID: 3537 RVA: 0x00035DA8 File Offset: 0x00033FA8
	public InterfaceDriverComponentAttribute(global::System.Type interfaceType, string serializedFieldName, string runtimeFieldName)
	{
		this.Interface = interfaceType;
		this.SerializedFieldName = serializedFieldName;
		this.RuntimeFieldName = runtimeFieldName;
	}

	// Token: 0x17000358 RID: 856
	// (get) Token: 0x06000DD2 RID: 3538 RVA: 0x00035DE8 File Offset: 0x00033FE8
	// (set) Token: 0x06000DD3 RID: 3539 RVA: 0x00035DF0 File Offset: 0x00033FF0
	public bool AlwaysSaveDisabled
	{
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		get
		{
			return this.<AlwaysSaveDisabled>k__BackingField;
		}
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		set
		{
			this.<AlwaysSaveDisabled>k__BackingField = value;
		}
	}

	// Token: 0x17000359 RID: 857
	// (get) Token: 0x06000DD4 RID: 3540 RVA: 0x00035DFC File Offset: 0x00033FFC
	// (set) Token: 0x06000DD5 RID: 3541 RVA: 0x00035E04 File Offset: 0x00034004
	public string AdditionalProperties
	{
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		get
		{
			return this.<AdditionalProperties>k__BackingField;
		}
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		set
		{
			this.<AdditionalProperties>k__BackingField = value;
		}
	}

	// Token: 0x1700035A RID: 858
	// (get) Token: 0x06000DD6 RID: 3542 RVA: 0x00035E10 File Offset: 0x00034010
	// (set) Token: 0x06000DD7 RID: 3543 RVA: 0x00035E18 File Offset: 0x00034018
	public global::System.Type UnityType
	{
		get
		{
			return this._minimumType;
		}
		set
		{
			this._minimumType = (value ?? typeof(global::UnityEngine.MonoBehaviour));
		}
	}

	// Token: 0x1700035B RID: 859
	// (get) Token: 0x06000DD8 RID: 3544 RVA: 0x00035E34 File Offset: 0x00034034
	// (set) Token: 0x06000DD9 RID: 3545 RVA: 0x00035E3C File Offset: 0x0003403C
	public global::InterfaceSearchRoute SearchRoute
	{
		get
		{
			return this.searchRoute;
		}
		set
		{
			if (value == (global::InterfaceSearchRoute)0)
			{
				value = global::InterfaceSearchRoute.GameObject;
			}
			this.searchRoute = value;
		}
	}

	// Token: 0x040008BB RID: 2235
	public readonly string SerializedFieldName;

	// Token: 0x040008BC RID: 2236
	public readonly string RuntimeFieldName;

	// Token: 0x040008BD RID: 2237
	public readonly global::System.Type Interface;

	// Token: 0x040008BE RID: 2238
	private global::System.Type _minimumType = typeof(global::UnityEngine.MonoBehaviour);

	// Token: 0x040008BF RID: 2239
	private global::InterfaceSearchRoute searchRoute = global::InterfaceSearchRoute.GameObject;

	// Token: 0x040008C0 RID: 2240
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private bool <AlwaysSaveDisabled>k__BackingField;

	// Token: 0x040008C1 RID: 2241
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private string <AdditionalProperties>k__BackingField;
}
