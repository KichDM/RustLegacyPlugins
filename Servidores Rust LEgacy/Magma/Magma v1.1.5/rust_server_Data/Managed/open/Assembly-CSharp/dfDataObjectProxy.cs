using System;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x0200084A RID: 2122
[global::System.Serializable]
[global::UnityEngine.AddComponentMenu("Daikon Forge/Data Binding/Proxy Data Object")]
public class dfDataObjectProxy : global::UnityEngine.MonoBehaviour, global::IDataBindingComponent
{
	// Token: 0x06004967 RID: 18791 RVA: 0x001128AC File Offset: 0x00110AAC
	public dfDataObjectProxy()
	{
	}

	// Token: 0x1400005A RID: 90
	// (add) Token: 0x06004968 RID: 18792 RVA: 0x001128B4 File Offset: 0x00110AB4
	// (remove) Token: 0x06004969 RID: 18793 RVA: 0x001128D0 File Offset: 0x00110AD0
	public event global::dfDataObjectProxy.DataObjectChangedHandler DataChanged
	{
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		add
		{
			this.DataChanged = (global::dfDataObjectProxy.DataObjectChangedHandler)global::System.Delegate.Combine(this.DataChanged, value);
		}
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		remove
		{
			this.DataChanged = (global::dfDataObjectProxy.DataObjectChangedHandler)global::System.Delegate.Remove(this.DataChanged, value);
		}
	}

	// Token: 0x0600496A RID: 18794 RVA: 0x001128EC File Offset: 0x00110AEC
	public void Start()
	{
		if (this.DataType == null)
		{
			global::UnityEngine.Debug.LogError("Unable to retrieve System.Type reference for type: " + this.TypeName);
		}
	}

	// Token: 0x17000DCC RID: 3532
	// (get) Token: 0x0600496B RID: 18795 RVA: 0x0011291C File Offset: 0x00110B1C
	// (set) Token: 0x0600496C RID: 18796 RVA: 0x00112924 File Offset: 0x00110B24
	public string TypeName
	{
		get
		{
			return this.typeName;
		}
		set
		{
			if (this.typeName != value)
			{
				this.typeName = value;
				this.Data = null;
			}
		}
	}

	// Token: 0x17000DCD RID: 3533
	// (get) Token: 0x0600496D RID: 18797 RVA: 0x00112948 File Offset: 0x00110B48
	public global::System.Type DataType
	{
		get
		{
			return this.getTypeFromName(this.typeName);
		}
	}

	// Token: 0x17000DCE RID: 3534
	// (get) Token: 0x0600496E RID: 18798 RVA: 0x00112958 File Offset: 0x00110B58
	// (set) Token: 0x0600496F RID: 18799 RVA: 0x00112960 File Offset: 0x00110B60
	public object Data
	{
		get
		{
			return this.data;
		}
		set
		{
			if (!object.ReferenceEquals(value, this.data))
			{
				this.data = value;
				if (value != null)
				{
					this.typeName = value.GetType().Name;
				}
				if (this.DataChanged != null)
				{
					this.DataChanged(value);
				}
			}
		}
	}

	// Token: 0x06004970 RID: 18800 RVA: 0x001129B4 File Offset: 0x00110BB4
	public global::System.Type GetPropertyType(string PropertyName)
	{
		global::System.Type dataType = this.DataType;
		if (dataType == null)
		{
			return null;
		}
		global::System.Reflection.MemberInfo memberInfo = dataType.GetMember(PropertyName, global::System.Reflection.BindingFlags.Instance | global::System.Reflection.BindingFlags.Public).FirstOrDefault<global::System.Reflection.MemberInfo>();
		if (memberInfo is global::System.Reflection.FieldInfo)
		{
			return ((global::System.Reflection.FieldInfo)memberInfo).FieldType;
		}
		if (memberInfo is global::System.Reflection.PropertyInfo)
		{
			return ((global::System.Reflection.PropertyInfo)memberInfo).PropertyType;
		}
		return null;
	}

	// Token: 0x06004971 RID: 18801 RVA: 0x00112A10 File Offset: 0x00110C10
	public global::dfObservableProperty GetProperty(string PropertyName)
	{
		if (this.data == null)
		{
			return null;
		}
		return new global::dfObservableProperty(this.data, PropertyName);
	}

	// Token: 0x06004972 RID: 18802 RVA: 0x00112A2C File Offset: 0x00110C2C
	private global::System.Type getTypeFromName(string typeName)
	{
		global::System.Type[] types = base.GetType().Assembly.GetTypes();
		return (from t in types
		where t.Name == typeName
		select t).FirstOrDefault<global::System.Type>();
	}

	// Token: 0x06004973 RID: 18803 RVA: 0x00112A70 File Offset: 0x00110C70
	private static global::System.Type getTypeFromQualifiedName(string typeName)
	{
		global::System.Type type = global::System.Type.GetType(typeName);
		if (type != null)
		{
			return type;
		}
		if (typeName.IndexOf('.') == -1)
		{
			return null;
		}
		string assemblyString = typeName.Substring(0, typeName.IndexOf('.'));
		global::System.Reflection.Assembly assembly = global::System.Reflection.Assembly.Load(assemblyString);
		if (assembly == null)
		{
			return null;
		}
		return assembly.GetType(typeName);
	}

	// Token: 0x06004974 RID: 18804 RVA: 0x00112AC4 File Offset: 0x00110CC4
	public void Bind()
	{
	}

	// Token: 0x06004975 RID: 18805 RVA: 0x00112AC8 File Offset: 0x00110CC8
	public void Unbind()
	{
	}

	// Token: 0x0400271E RID: 10014
	[global::UnityEngine.SerializeField]
	protected string typeName;

	// Token: 0x0400271F RID: 10015
	private object data;

	// Token: 0x04002720 RID: 10016
	private global::dfDataObjectProxy.DataObjectChangedHandler DataChanged;

	// Token: 0x0200084B RID: 2123
	// (Invoke) Token: 0x06004977 RID: 18807
	[global::dfEventCategory("Data Changed")]
	public delegate void DataObjectChangedHandler(object data);

	// Token: 0x0200084C RID: 2124
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private sealed class <getTypeFromName>c__AnonStorey6D
	{
		// Token: 0x0600497A RID: 18810 RVA: 0x00112ACC File Offset: 0x00110CCC
		public <getTypeFromName>c__AnonStorey6D()
		{
		}

		// Token: 0x0600497B RID: 18811 RVA: 0x00112AD4 File Offset: 0x00110CD4
		internal bool <>m__2B(global::System.Type t)
		{
			return t.Name == this.typeName;
		}

		// Token: 0x04002721 RID: 10017
		internal string typeName;
	}
}
