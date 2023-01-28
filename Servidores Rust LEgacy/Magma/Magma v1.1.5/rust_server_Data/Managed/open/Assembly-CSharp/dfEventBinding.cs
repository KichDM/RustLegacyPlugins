using System;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x0200084D RID: 2125
[global::System.Serializable]
[global::UnityEngine.AddComponentMenu("Daikon Forge/Data Binding/Event Binding")]
public class dfEventBinding : global::UnityEngine.MonoBehaviour, global::IDataBindingComponent
{
	// Token: 0x0600497C RID: 18812 RVA: 0x00112AE8 File Offset: 0x00110CE8
	public dfEventBinding()
	{
	}

	// Token: 0x0600497D RID: 18813 RVA: 0x00112AF0 File Offset: 0x00110CF0
	public void OnEnable()
	{
		if (this.DataSource != null && !this.isBound && this.DataSource.IsValid && this.DataTarget.IsValid)
		{
			this.Bind();
		}
	}

	// Token: 0x0600497E RID: 18814 RVA: 0x00112B3C File Offset: 0x00110D3C
	public void Start()
	{
		if (this.DataSource != null && !this.isBound && this.DataSource.IsValid && this.DataTarget.IsValid)
		{
			this.Bind();
		}
	}

	// Token: 0x0600497F RID: 18815 RVA: 0x00112B88 File Offset: 0x00110D88
	public void OnDisable()
	{
		this.Unbind();
	}

	// Token: 0x06004980 RID: 18816 RVA: 0x00112B90 File Offset: 0x00110D90
	public void Bind()
	{
		if (this.isBound || this.DataSource == null)
		{
			return;
		}
		if (!this.DataSource.IsValid || !this.DataTarget.IsValid)
		{
			global::UnityEngine.Debug.LogError(string.Format("Invalid event binding configuration - Source:{0}, Target:{1}", this.DataSource, this.DataTarget));
			return;
		}
		this.sourceComponent = this.DataSource.Component;
		this.targetComponent = this.DataTarget.Component;
		global::System.Reflection.MethodInfo method = this.DataTarget.GetMethod();
		if (method == null)
		{
			global::UnityEngine.Debug.LogError("Event handler not found: " + this.targetComponent.GetType().Name + "." + this.DataTarget.MemberName);
			return;
		}
		this.eventField = this.getField(this.sourceComponent, this.DataSource.MemberName);
		if (this.eventField == null)
		{
			global::UnityEngine.Debug.LogError("Event definition not found: " + this.sourceComponent.GetType().Name + "." + this.DataSource.MemberName);
			return;
		}
		try
		{
			global::System.Reflection.MethodInfo method2 = this.eventField.FieldType.GetMethod("Invoke");
			global::System.Reflection.ParameterInfo[] parameters = method2.GetParameters();
			global::System.Reflection.ParameterInfo[] parameters2 = method.GetParameters();
			if (parameters.Length == parameters2.Length)
			{
				this.eventDelegate = global::System.Delegate.CreateDelegate(this.eventField.FieldType, this.targetComponent, method, true);
			}
			else
			{
				if (parameters.Length <= 0 || parameters2.Length != 0)
				{
					base.enabled = false;
					throw new global::System.InvalidCastException("Event signature mismatch: " + method);
				}
				this.eventDelegate = this.createEventProxyDelegate(this.targetComponent, this.eventField.FieldType, parameters, method);
			}
		}
		catch (global::System.Exception ex)
		{
			base.enabled = false;
			global::UnityEngine.Debug.LogError("Event binding failed - Failed to create event handler: " + ex.ToString());
			return;
		}
		global::System.Delegate value = global::System.Delegate.Combine(this.eventDelegate, (global::System.Delegate)this.eventField.GetValue(this.sourceComponent));
		this.eventField.SetValue(this.sourceComponent, value);
		this.isBound = true;
	}

	// Token: 0x06004981 RID: 18817 RVA: 0x00112DD4 File Offset: 0x00110FD4
	public void Unbind()
	{
		if (!this.isBound)
		{
			return;
		}
		this.isBound = false;
		global::System.Delegate source = (global::System.Delegate)this.eventField.GetValue(this.sourceComponent);
		global::System.Delegate value = global::System.Delegate.Remove(source, this.eventDelegate);
		this.eventField.SetValue(this.sourceComponent, value);
		this.eventField = null;
		this.eventDelegate = null;
		this.handlerProxy = null;
		this.sourceComponent = null;
		this.targetComponent = null;
	}

	// Token: 0x06004982 RID: 18818 RVA: 0x00112E50 File Offset: 0x00111050
	public override string ToString()
	{
		string text = (this.DataSource == null || !(this.DataSource.Component != null)) ? "[null]" : this.DataSource.Component.GetType().Name;
		string text2 = (this.DataSource == null || string.IsNullOrEmpty(this.DataSource.MemberName)) ? "[null]" : this.DataSource.MemberName;
		string text3 = (this.DataTarget == null || !(this.DataTarget.Component != null)) ? "[null]" : this.DataTarget.Component.GetType().Name;
		string text4 = (this.DataTarget == null || string.IsNullOrEmpty(this.DataTarget.MemberName)) ? "[null]" : this.DataTarget.MemberName;
		return string.Format("Bind {0}.{1} -> {2}.{3}", new object[]
		{
			text,
			text2,
			text3,
			text4
		});
	}

	// Token: 0x06004983 RID: 18819 RVA: 0x00112F6C File Offset: 0x0011116C
	[global::dfEventProxy]
	private void MouseEventProxy(global::dfControl control, global::dfMouseEventArgs mouseEvent)
	{
		this.callProxyEventHandler();
	}

	// Token: 0x06004984 RID: 18820 RVA: 0x00112F74 File Offset: 0x00111174
	[global::dfEventProxy]
	private void KeyEventProxy(global::dfControl control, global::dfKeyEventArgs keyEvent)
	{
		this.callProxyEventHandler();
	}

	// Token: 0x06004985 RID: 18821 RVA: 0x00112F7C File Offset: 0x0011117C
	[global::dfEventProxy]
	private void DragEventProxy(global::dfControl control, global::dfDragEventArgs dragEvent)
	{
		this.callProxyEventHandler();
	}

	// Token: 0x06004986 RID: 18822 RVA: 0x00112F84 File Offset: 0x00111184
	[global::dfEventProxy]
	private void ChildControlEventProxy(global::dfControl container, global::dfControl child)
	{
		this.callProxyEventHandler();
	}

	// Token: 0x06004987 RID: 18823 RVA: 0x00112F8C File Offset: 0x0011118C
	[global::dfEventProxy]
	private void FocusEventProxy(global::dfControl control, global::dfFocusEventArgs args)
	{
		this.callProxyEventHandler();
	}

	// Token: 0x06004988 RID: 18824 RVA: 0x00112F94 File Offset: 0x00111194
	[global::dfEventProxy]
	private void PropertyChangedProxy(global::dfControl control, int value)
	{
		this.callProxyEventHandler();
	}

	// Token: 0x06004989 RID: 18825 RVA: 0x00112F9C File Offset: 0x0011119C
	[global::dfEventProxy]
	private void PropertyChangedProxy(global::dfControl control, float value)
	{
		this.callProxyEventHandler();
	}

	// Token: 0x0600498A RID: 18826 RVA: 0x00112FA4 File Offset: 0x001111A4
	[global::dfEventProxy]
	private void PropertyChangedProxy(global::dfControl control, bool value)
	{
		this.callProxyEventHandler();
	}

	// Token: 0x0600498B RID: 18827 RVA: 0x00112FAC File Offset: 0x001111AC
	[global::dfEventProxy]
	private void PropertyChangedProxy(global::dfControl control, string value)
	{
		this.callProxyEventHandler();
	}

	// Token: 0x0600498C RID: 18828 RVA: 0x00112FB4 File Offset: 0x001111B4
	[global::dfEventProxy]
	private void PropertyChangedProxy(global::dfControl control, global::UnityEngine.Vector2 value)
	{
		this.callProxyEventHandler();
	}

	// Token: 0x0600498D RID: 18829 RVA: 0x00112FBC File Offset: 0x001111BC
	[global::dfEventProxy]
	private void PropertyChangedProxy(global::dfControl control, global::UnityEngine.Vector3 value)
	{
		this.callProxyEventHandler();
	}

	// Token: 0x0600498E RID: 18830 RVA: 0x00112FC4 File Offset: 0x001111C4
	[global::dfEventProxy]
	private void PropertyChangedProxy(global::dfControl control, global::UnityEngine.Vector4 value)
	{
		this.callProxyEventHandler();
	}

	// Token: 0x0600498F RID: 18831 RVA: 0x00112FCC File Offset: 0x001111CC
	[global::dfEventProxy]
	private void PropertyChangedProxy(global::dfControl control, global::UnityEngine.Quaternion value)
	{
		this.callProxyEventHandler();
	}

	// Token: 0x06004990 RID: 18832 RVA: 0x00112FD4 File Offset: 0x001111D4
	[global::dfEventProxy]
	private void PropertyChangedProxy(global::dfControl control, global::dfButton.ButtonState value)
	{
		this.callProxyEventHandler();
	}

	// Token: 0x06004991 RID: 18833 RVA: 0x00112FDC File Offset: 0x001111DC
	[global::dfEventProxy]
	private void PropertyChangedProxy(global::dfControl control, global::dfPivotPoint value)
	{
		this.callProxyEventHandler();
	}

	// Token: 0x06004992 RID: 18834 RVA: 0x00112FE4 File Offset: 0x001111E4
	[global::dfEventProxy]
	private void PropertyChangedProxy(global::dfControl control, global::UnityEngine.Texture2D value)
	{
		this.callProxyEventHandler();
	}

	// Token: 0x06004993 RID: 18835 RVA: 0x00112FEC File Offset: 0x001111EC
	[global::dfEventProxy]
	private void PropertyChangedProxy(global::dfControl control, global::UnityEngine.Material value)
	{
		this.callProxyEventHandler();
	}

	// Token: 0x06004994 RID: 18836 RVA: 0x00112FF4 File Offset: 0x001111F4
	private void callProxyEventHandler()
	{
		if (this.handlerProxy != null)
		{
			this.handlerProxy.Invoke(this.targetComponent, null);
		}
	}

	// Token: 0x06004995 RID: 18837 RVA: 0x00113014 File Offset: 0x00111214
	private global::System.Reflection.FieldInfo getField(global::UnityEngine.Component sourceComponent, string fieldName)
	{
		return (from f in sourceComponent.GetType().GetAllFields()
		where f.Name == fieldName
		select f).FirstOrDefault<global::System.Reflection.FieldInfo>();
	}

	// Token: 0x06004996 RID: 18838 RVA: 0x00113050 File Offset: 0x00111250
	private global::System.Delegate createEventProxyDelegate(object target, global::System.Type delegateType, global::System.Reflection.ParameterInfo[] eventParams, global::System.Reflection.MethodInfo eventHandler)
	{
		global::System.Reflection.MethodInfo methodInfo = (from m in typeof(global::dfEventBinding).GetMethods(global::System.Reflection.BindingFlags.Instance | global::System.Reflection.BindingFlags.NonPublic)
		where m.IsDefined(typeof(global::dfEventProxyAttribute), true) && this.signatureIsCompatible(eventParams, m.GetParameters())
		select m).FirstOrDefault<global::System.Reflection.MethodInfo>();
		if (methodInfo == null)
		{
			return null;
		}
		this.handlerProxy = eventHandler;
		return global::System.Delegate.CreateDelegate(delegateType, this, methodInfo, true);
	}

	// Token: 0x06004997 RID: 18839 RVA: 0x001130B4 File Offset: 0x001112B4
	private bool signatureIsCompatible(global::System.Reflection.ParameterInfo[] lhs, global::System.Reflection.ParameterInfo[] rhs)
	{
		if (lhs == null || rhs == null)
		{
			return false;
		}
		if (lhs.Length != rhs.Length)
		{
			return false;
		}
		for (int i = 0; i < lhs.Length; i++)
		{
			if (!this.areTypesCompatible(lhs[i], rhs[i]))
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x06004998 RID: 18840 RVA: 0x00113104 File Offset: 0x00111304
	private bool areTypesCompatible(global::System.Reflection.ParameterInfo lhs, global::System.Reflection.ParameterInfo rhs)
	{
		return lhs.ParameterType.Equals(rhs.ParameterType) || lhs.ParameterType.IsAssignableFrom(rhs.ParameterType);
	}

	// Token: 0x04002722 RID: 10018
	public global::dfComponentMemberInfo DataSource;

	// Token: 0x04002723 RID: 10019
	public global::dfComponentMemberInfo DataTarget;

	// Token: 0x04002724 RID: 10020
	private bool isBound;

	// Token: 0x04002725 RID: 10021
	private global::UnityEngine.Component sourceComponent;

	// Token: 0x04002726 RID: 10022
	private global::UnityEngine.Component targetComponent;

	// Token: 0x04002727 RID: 10023
	private global::System.Reflection.FieldInfo eventField;

	// Token: 0x04002728 RID: 10024
	private global::System.Delegate eventDelegate;

	// Token: 0x04002729 RID: 10025
	private global::System.Reflection.MethodInfo handlerProxy;

	// Token: 0x0200084E RID: 2126
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private sealed class <getField>c__AnonStorey6E
	{
		// Token: 0x06004999 RID: 18841 RVA: 0x00113144 File Offset: 0x00111344
		public <getField>c__AnonStorey6E()
		{
		}

		// Token: 0x0600499A RID: 18842 RVA: 0x0011314C File Offset: 0x0011134C
		internal bool <>m__2C(global::System.Reflection.FieldInfo f)
		{
			return f.Name == this.fieldName;
		}

		// Token: 0x0400272A RID: 10026
		internal string fieldName;
	}

	// Token: 0x0200084F RID: 2127
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private sealed class <createEventProxyDelegate>c__AnonStorey6F
	{
		// Token: 0x0600499B RID: 18843 RVA: 0x00113160 File Offset: 0x00111360
		public <createEventProxyDelegate>c__AnonStorey6F()
		{
		}

		// Token: 0x0600499C RID: 18844 RVA: 0x00113168 File Offset: 0x00111368
		internal bool <>m__2D(global::System.Reflection.MethodInfo m)
		{
			return m.IsDefined(typeof(global::dfEventProxyAttribute), true) && this.<>f__this.signatureIsCompatible(this.eventParams, m.GetParameters());
		}

		// Token: 0x0400272B RID: 10027
		internal global::System.Reflection.ParameterInfo[] eventParams;

		// Token: 0x0400272C RID: 10028
		internal global::dfEventBinding <>f__this;
	}
}
