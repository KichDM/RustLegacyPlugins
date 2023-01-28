using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000851 RID: 2129
[global::System.Serializable]
[global::UnityEngine.AddComponentMenu("Daikon Forge/Data Binding/Expression Binding")]
public class dfExpressionPropertyBinding : global::UnityEngine.MonoBehaviour, global::IDataBindingComponent
{
	// Token: 0x0600499E RID: 18846 RVA: 0x001131B0 File Offset: 0x001113B0
	public dfExpressionPropertyBinding()
	{
	}

	// Token: 0x17000DCF RID: 3535
	// (get) Token: 0x0600499F RID: 18847 RVA: 0x001131B8 File Offset: 0x001113B8
	// (set) Token: 0x060049A0 RID: 18848 RVA: 0x001131C0 File Offset: 0x001113C0
	public string Expression
	{
		get
		{
			return this.expression;
		}
		set
		{
			if (!string.Equals(value, this.expression))
			{
				this.Unbind();
				this.expression = value;
			}
		}
	}

	// Token: 0x060049A1 RID: 18849 RVA: 0x001131E0 File Offset: 0x001113E0
	public void OnDisable()
	{
		this.Unbind();
	}

	// Token: 0x060049A2 RID: 18850 RVA: 0x001131E8 File Offset: 0x001113E8
	public void Update()
	{
		if (this.isBound)
		{
			this.evaluate();
		}
		else
		{
			bool flag = this.DataSource != null && !string.IsNullOrEmpty(this.expression) && this.DataTarget.IsValid;
			if (flag)
			{
				this.Bind();
			}
		}
	}

	// Token: 0x060049A3 RID: 18851 RVA: 0x00113248 File Offset: 0x00111448
	public void Unbind()
	{
		if (!this.isBound)
		{
			return;
		}
		this.compiledExpression = null;
		this.targetProperty = null;
		this.isBound = false;
	}

	// Token: 0x060049A4 RID: 18852 RVA: 0x0011326C File Offset: 0x0011146C
	public void Bind()
	{
		if (this.isBound)
		{
			return;
		}
		if (this.DataSource is global::dfDataObjectProxy && ((global::dfDataObjectProxy)this.DataSource).Data == null)
		{
			return;
		}
		global::dfScriptEngineSettings dfScriptEngineSettings = new global::dfScriptEngineSettings
		{
			Constants = new global::System.Collections.Generic.Dictionary<string, object>
			{
				{
					"Application",
					typeof(global::UnityEngine.Application)
				},
				{
					"Color",
					typeof(global::UnityEngine.Color)
				},
				{
					"Color32",
					typeof(global::UnityEngine.Color32)
				},
				{
					"Random",
					typeof(global::UnityEngine.Random)
				},
				{
					"Time",
					typeof(global::UnityEngine.Time)
				},
				{
					"ScriptableObject",
					typeof(global::UnityEngine.ScriptableObject)
				},
				{
					"Vector2",
					typeof(global::UnityEngine.Vector2)
				},
				{
					"Vector3",
					typeof(global::UnityEngine.Vector3)
				},
				{
					"Vector4",
					typeof(global::UnityEngine.Vector4)
				},
				{
					"Quaternion",
					typeof(global::UnityEngine.Quaternion)
				},
				{
					"Matrix",
					typeof(global::UnityEngine.Matrix4x4)
				},
				{
					"Mathf",
					typeof(global::UnityEngine.Mathf)
				}
			}
		};
		if (this.DataSource is global::dfDataObjectProxy)
		{
			global::dfDataObjectProxy dfDataObjectProxy = this.DataSource as global::dfDataObjectProxy;
			dfScriptEngineSettings.AddVariable(new global::dfScriptVariable("source", null, dfDataObjectProxy.DataType));
		}
		else
		{
			dfScriptEngineSettings.AddVariable(new global::dfScriptVariable("source", this.DataSource));
		}
		this.compiledExpression = global::dfScriptEngine.CompileExpression(this.expression, dfScriptEngineSettings);
		this.targetProperty = this.DataTarget.GetProperty();
		this.isBound = (this.compiledExpression != null && this.targetProperty != null);
	}

	// Token: 0x060049A5 RID: 18853 RVA: 0x00113450 File Offset: 0x00111650
	private void evaluate()
	{
		try
		{
			object obj = this.DataSource;
			if (obj is global::dfDataObjectProxy)
			{
				obj = ((global::dfDataObjectProxy)obj).Data;
			}
			object value = this.compiledExpression.DynamicInvoke(new object[]
			{
				obj
			});
			this.targetProperty.Value = value;
		}
		catch (global::System.Exception ex)
		{
			global::UnityEngine.Debug.LogError(ex);
		}
	}

	// Token: 0x060049A6 RID: 18854 RVA: 0x001134CC File Offset: 0x001116CC
	public override string ToString()
	{
		string arg = (this.DataTarget == null || !(this.DataTarget.Component != null)) ? "[null]" : this.DataTarget.Component.GetType().Name;
		string arg2 = (this.DataTarget == null || string.IsNullOrEmpty(this.DataTarget.MemberName)) ? "[null]" : this.DataTarget.MemberName;
		return string.Format("Bind [expression] -> {0}.{1}", arg, arg2);
	}

	// Token: 0x0400272D RID: 10029
	public global::UnityEngine.Component DataSource;

	// Token: 0x0400272E RID: 10030
	public global::dfComponentMemberInfo DataTarget;

	// Token: 0x0400272F RID: 10031
	[global::UnityEngine.SerializeField]
	protected string expression;

	// Token: 0x04002730 RID: 10032
	private global::System.Delegate compiledExpression;

	// Token: 0x04002731 RID: 10033
	private global::dfObservableProperty targetProperty;

	// Token: 0x04002732 RID: 10034
	private bool isBound;
}
