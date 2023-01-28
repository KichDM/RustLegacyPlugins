using System;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x02000890 RID: 2192
[global::System.Serializable]
[global::UnityEngine.AddComponentMenu("Daikon Forge/Tweens/Tween Event Binding")]
public class dfTweenEventBinding : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06004BE6 RID: 19430 RVA: 0x0011D4C8 File Offset: 0x0011B6C8
	public dfTweenEventBinding()
	{
	}

	// Token: 0x06004BE7 RID: 19431 RVA: 0x0011D4D0 File Offset: 0x0011B6D0
	private void OnEnable()
	{
		if (this.isValid())
		{
			this.Bind();
		}
	}

	// Token: 0x06004BE8 RID: 19432 RVA: 0x0011D4E4 File Offset: 0x0011B6E4
	private void Start()
	{
		if (this.isValid())
		{
			this.Bind();
		}
	}

	// Token: 0x06004BE9 RID: 19433 RVA: 0x0011D4F8 File Offset: 0x0011B6F8
	private void OnDisable()
	{
		this.Unbind();
	}

	// Token: 0x06004BEA RID: 19434 RVA: 0x0011D500 File Offset: 0x0011B700
	public void Bind()
	{
		if (this.isBound && !this.isValid())
		{
			return;
		}
		this.isBound = true;
		if (!string.IsNullOrEmpty(this.StartEvent))
		{
			this.bindEvent(this.StartEvent, "Play", out this.startEventField, out this.startEventHandler);
		}
		if (!string.IsNullOrEmpty(this.StopEvent))
		{
			this.bindEvent(this.StopEvent, "Stop", out this.stopEventField, out this.stopEventHandler);
		}
		if (!string.IsNullOrEmpty(this.ResetEvent))
		{
			this.bindEvent(this.ResetEvent, "Reset", out this.resetEventField, out this.resetEventHandler);
		}
	}

	// Token: 0x06004BEB RID: 19435 RVA: 0x0011D5B4 File Offset: 0x0011B7B4
	public void Unbind()
	{
		if (!this.isBound)
		{
			return;
		}
		this.isBound = false;
		if (this.startEventField != null)
		{
			this.unbindEvent(this.startEventField, this.startEventHandler);
			this.startEventField = null;
			this.startEventHandler = null;
		}
		if (this.stopEventField != null)
		{
			this.unbindEvent(this.stopEventField, this.stopEventHandler);
			this.stopEventField = null;
			this.stopEventHandler = null;
		}
		if (this.resetEventField != null)
		{
			this.unbindEvent(this.resetEventField, this.resetEventHandler);
			this.resetEventField = null;
			this.resetEventHandler = null;
		}
	}

	// Token: 0x06004BEC RID: 19436 RVA: 0x0011D658 File Offset: 0x0011B858
	private bool isValid()
	{
		if (this.Tween == null || !(this.Tween is global::dfTweenComponentBase))
		{
			return false;
		}
		if (this.EventSource == null)
		{
			return false;
		}
		bool flag = string.IsNullOrEmpty(this.StartEvent) && string.IsNullOrEmpty(this.StopEvent) && string.IsNullOrEmpty(this.ResetEvent);
		if (flag)
		{
			return false;
		}
		global::System.Type type = this.EventSource.GetType();
		return (string.IsNullOrEmpty(this.StartEvent) || this.getField(type, this.StartEvent) != null) && (string.IsNullOrEmpty(this.StopEvent) || this.getField(type, this.StopEvent) != null) && (string.IsNullOrEmpty(this.ResetEvent) || this.getField(type, this.ResetEvent) != null);
	}

	// Token: 0x06004BED RID: 19437 RVA: 0x0011D74C File Offset: 0x0011B94C
	private void unbindEvent(global::System.Reflection.FieldInfo eventField, global::System.Delegate eventDelegate)
	{
		global::System.Delegate source = (global::System.Delegate)eventField.GetValue(this.EventSource);
		global::System.Delegate value = global::System.Delegate.Remove(source, eventDelegate);
		eventField.SetValue(this.EventSource, value);
	}

	// Token: 0x06004BEE RID: 19438 RVA: 0x0011D780 File Offset: 0x0011B980
	private void bindEvent(string eventName, string handlerName, out global::System.Reflection.FieldInfo eventField, out global::System.Delegate eventHandler)
	{
		eventField = null;
		eventHandler = null;
		global::System.Reflection.MethodInfo method = this.Tween.GetType().GetMethod(handlerName, global::System.Reflection.BindingFlags.Instance | global::System.Reflection.BindingFlags.Public | global::System.Reflection.BindingFlags.NonPublic);
		if (method == null)
		{
			throw new global::System.MissingMemberException("Method not found: " + handlerName);
		}
		eventField = this.getField(this.EventSource.GetType(), eventName);
		if (eventField == null)
		{
			throw new global::System.MissingMemberException("Event not found: " + eventName);
		}
		try
		{
			global::System.Reflection.MethodInfo method2 = eventField.FieldType.GetMethod("Invoke");
			global::System.Reflection.ParameterInfo[] parameters = method2.GetParameters();
			global::System.Reflection.ParameterInfo[] parameters2 = method.GetParameters();
			if (parameters.Length == parameters2.Length)
			{
				eventHandler = global::System.Delegate.CreateDelegate(eventField.FieldType, this.Tween, method, true);
			}
			else
			{
				if (parameters.Length <= 0 || parameters2.Length != 0)
				{
					throw new global::System.InvalidCastException("Event signature mismatch: " + eventHandler);
				}
				eventHandler = this.createDynamicWrapper(this.Tween, eventField.FieldType, parameters, method);
			}
		}
		catch (global::System.Exception ex)
		{
			global::UnityEngine.Debug.LogError("Event binding failed - Failed to create event handler: " + ex.ToString());
			return;
		}
		global::System.Delegate value = global::System.Delegate.Combine(eventHandler, (global::System.Delegate)eventField.GetValue(this.EventSource));
		eventField.SetValue(this.EventSource, value);
	}

	// Token: 0x06004BEF RID: 19439 RVA: 0x0011D8E4 File Offset: 0x0011BAE4
	private global::System.Reflection.FieldInfo getField(global::System.Type type, string fieldName)
	{
		return (from f in type.GetAllFields()
		where f.Name == fieldName
		select f).FirstOrDefault<global::System.Reflection.FieldInfo>();
	}

	// Token: 0x06004BF0 RID: 19440 RVA: 0x0011D91C File Offset: 0x0011BB1C
	private global::System.Delegate createDynamicWrapper(object target, global::System.Type delegateType, global::System.Reflection.ParameterInfo[] eventParams, global::System.Reflection.MethodInfo eventHandler)
	{
		global::System.Type[] parameterTypes = new global::System.Type[]
		{
			target.GetType()
		}.Concat(from p in eventParams
		select p.ParameterType).ToArray<global::System.Type>();
		global::System.Reflection.Emit.DynamicMethod dynamicMethod = new global::System.Reflection.Emit.DynamicMethod("DynamicEventWrapper_" + eventHandler.Name, typeof(void), parameterTypes);
		global::System.Reflection.Emit.ILGenerator ilgenerator = dynamicMethod.GetILGenerator();
		ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Ldarg_0);
		ilgenerator.EmitCall(global::System.Reflection.Emit.OpCodes.Callvirt, eventHandler, global::System.Type.EmptyTypes);
		ilgenerator.Emit(global::System.Reflection.Emit.OpCodes.Ret);
		return dynamicMethod.CreateDelegate(delegateType, target);
	}

	// Token: 0x06004BF1 RID: 19441 RVA: 0x0011D9C0 File Offset: 0x0011BBC0
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private static global::System.Type <createDynamicWrapper>m__32(global::System.Reflection.ParameterInfo p)
	{
		return p.ParameterType;
	}

	// Token: 0x0400285A RID: 10330
	public global::UnityEngine.Component Tween;

	// Token: 0x0400285B RID: 10331
	public global::UnityEngine.Component EventSource;

	// Token: 0x0400285C RID: 10332
	public string StartEvent;

	// Token: 0x0400285D RID: 10333
	public string StopEvent;

	// Token: 0x0400285E RID: 10334
	public string ResetEvent;

	// Token: 0x0400285F RID: 10335
	private bool isBound;

	// Token: 0x04002860 RID: 10336
	private global::System.Reflection.FieldInfo startEventField;

	// Token: 0x04002861 RID: 10337
	private global::System.Reflection.FieldInfo stopEventField;

	// Token: 0x04002862 RID: 10338
	private global::System.Reflection.FieldInfo resetEventField;

	// Token: 0x04002863 RID: 10339
	private global::System.Delegate startEventHandler;

	// Token: 0x04002864 RID: 10340
	private global::System.Delegate stopEventHandler;

	// Token: 0x04002865 RID: 10341
	private global::System.Delegate resetEventHandler;

	// Token: 0x04002866 RID: 10342
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private static global::System.Func<global::System.Reflection.ParameterInfo, global::System.Type> <>f__am$cacheC;

	// Token: 0x02000891 RID: 2193
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private sealed class <getField>c__AnonStorey71
	{
		// Token: 0x06004BF2 RID: 19442 RVA: 0x0011D9C8 File Offset: 0x0011BBC8
		public <getField>c__AnonStorey71()
		{
		}

		// Token: 0x06004BF3 RID: 19443 RVA: 0x0011D9D0 File Offset: 0x0011BBD0
		internal bool <>m__31(global::System.Reflection.FieldInfo f)
		{
			return f.Name == this.fieldName;
		}

		// Token: 0x04002867 RID: 10343
		internal string fieldName;
	}
}
