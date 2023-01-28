using System;
using UnityEngine;

// Token: 0x02000856 RID: 2134
[global::System.Serializable]
[global::UnityEngine.AddComponentMenu("Daikon Forge/Data Binding/Proxy Property Binding")]
public class dfProxyPropertyBinding : global::UnityEngine.MonoBehaviour, global::IDataBindingComponent
{
	// Token: 0x060049C9 RID: 18889 RVA: 0x00113BAC File Offset: 0x00111DAC
	public dfProxyPropertyBinding()
	{
	}

	// Token: 0x060049CA RID: 18890 RVA: 0x00113BB4 File Offset: 0x00111DB4
	public void Awake()
	{
	}

	// Token: 0x060049CB RID: 18891 RVA: 0x00113BB8 File Offset: 0x00111DB8
	public void OnEnable()
	{
		if (!this.isBound && this.IsDataSourceValid() && this.DataTarget.IsValid)
		{
			this.Bind();
		}
	}

	// Token: 0x060049CC RID: 18892 RVA: 0x00113BF4 File Offset: 0x00111DF4
	public void Start()
	{
		if (!this.isBound && this.IsDataSourceValid() && this.DataTarget.IsValid)
		{
			this.Bind();
		}
	}

	// Token: 0x060049CD RID: 18893 RVA: 0x00113C30 File Offset: 0x00111E30
	public void OnDisable()
	{
		this.Unbind();
	}

	// Token: 0x060049CE RID: 18894 RVA: 0x00113C38 File Offset: 0x00111E38
	public void Update()
	{
		if (this.sourceProperty == null || this.targetProperty == null)
		{
			return;
		}
		if (this.sourceProperty.HasChanged)
		{
			this.targetProperty.Value = this.sourceProperty.Value;
			this.sourceProperty.ClearChangedFlag();
		}
		else if (this.TwoWay && this.targetProperty.HasChanged)
		{
			this.sourceProperty.Value = this.targetProperty.Value;
			this.targetProperty.ClearChangedFlag();
		}
	}

	// Token: 0x060049CF RID: 18895 RVA: 0x00113CD0 File Offset: 0x00111ED0
	public void Bind()
	{
		if (this.isBound)
		{
			return;
		}
		if (!this.IsDataSourceValid())
		{
			global::UnityEngine.Debug.LogError(string.Format("Invalid data binding configuration - Source:{0}, Target:{1}", this.DataSource, this.DataTarget));
			return;
		}
		if (!this.DataTarget.IsValid)
		{
			global::UnityEngine.Debug.LogError(string.Format("Invalid data binding configuration - Source:{0}, Target:{1}", this.DataSource, this.DataTarget));
			return;
		}
		global::dfDataObjectProxy dfDataObjectProxy = this.DataSource.Component as global::dfDataObjectProxy;
		this.sourceProperty = dfDataObjectProxy.GetProperty(this.DataSource.MemberName);
		this.targetProperty = this.DataTarget.GetProperty();
		this.isBound = (this.sourceProperty != null && this.targetProperty != null);
		if (this.isBound)
		{
			this.targetProperty.Value = this.sourceProperty.Value;
		}
		this.attachEvent();
	}

	// Token: 0x060049D0 RID: 18896 RVA: 0x00113DBC File Offset: 0x00111FBC
	public void Unbind()
	{
		if (!this.isBound)
		{
			return;
		}
		this.detachEvent();
		this.sourceProperty = null;
		this.targetProperty = null;
		this.isBound = false;
	}

	// Token: 0x060049D1 RID: 18897 RVA: 0x00113DE8 File Offset: 0x00111FE8
	private bool IsDataSourceValid()
	{
		return this.DataSource != null || this.DataSource.Component != null || !string.IsNullOrEmpty(this.DataSource.MemberName) || (this.DataSource.Component as global::dfDataObjectProxy).Data != null;
	}

	// Token: 0x060049D2 RID: 18898 RVA: 0x00113E4C File Offset: 0x0011204C
	private void attachEvent()
	{
		if (this.eventsAttached)
		{
			return;
		}
		this.eventsAttached = true;
		global::dfDataObjectProxy dfDataObjectProxy = this.DataSource.Component as global::dfDataObjectProxy;
		if (dfDataObjectProxy != null)
		{
			dfDataObjectProxy.DataChanged += this.handle_DataChanged;
		}
	}

	// Token: 0x060049D3 RID: 18899 RVA: 0x00113E9C File Offset: 0x0011209C
	private void detachEvent()
	{
		if (!this.eventsAttached)
		{
			return;
		}
		this.eventsAttached = false;
		global::dfDataObjectProxy dfDataObjectProxy = this.DataSource.Component as global::dfDataObjectProxy;
		if (dfDataObjectProxy != null)
		{
			dfDataObjectProxy.DataChanged -= this.handle_DataChanged;
		}
	}

	// Token: 0x060049D4 RID: 18900 RVA: 0x00113EEC File Offset: 0x001120EC
	private void handle_DataChanged(object data)
	{
		this.Unbind();
		if (this.IsDataSourceValid())
		{
			this.Bind();
		}
	}

	// Token: 0x060049D5 RID: 18901 RVA: 0x00113F08 File Offset: 0x00112108
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

	// Token: 0x0400273F RID: 10047
	public global::dfComponentMemberInfo DataSource;

	// Token: 0x04002740 RID: 10048
	public global::dfComponentMemberInfo DataTarget;

	// Token: 0x04002741 RID: 10049
	public bool TwoWay;

	// Token: 0x04002742 RID: 10050
	private global::dfObservableProperty sourceProperty;

	// Token: 0x04002743 RID: 10051
	private global::dfObservableProperty targetProperty;

	// Token: 0x04002744 RID: 10052
	private bool isBound;

	// Token: 0x04002745 RID: 10053
	private bool eventsAttached;
}
