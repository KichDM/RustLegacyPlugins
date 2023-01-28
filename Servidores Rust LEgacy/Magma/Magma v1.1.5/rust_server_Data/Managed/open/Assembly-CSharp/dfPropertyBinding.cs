using System;
using UnityEngine;

// Token: 0x02000855 RID: 2133
[global::System.Serializable]
[global::UnityEngine.AddComponentMenu("Daikon Forge/Data Binding/Property Binding")]
public class dfPropertyBinding : global::UnityEngine.MonoBehaviour, global::IDataBindingComponent
{
	// Token: 0x060049C1 RID: 18881 RVA: 0x001138A4 File Offset: 0x00111AA4
	public dfPropertyBinding()
	{
	}

	// Token: 0x060049C2 RID: 18882 RVA: 0x001138AC File Offset: 0x00111AAC
	public void OnEnable()
	{
		if (!this.isBound && this.DataSource.IsValid && this.DataTarget.IsValid)
		{
			this.Bind();
		}
	}

	// Token: 0x060049C3 RID: 18883 RVA: 0x001138E0 File Offset: 0x00111AE0
	public void Start()
	{
		if (!this.isBound && this.DataSource.IsValid && this.DataTarget.IsValid)
		{
			this.Bind();
		}
	}

	// Token: 0x060049C4 RID: 18884 RVA: 0x00113914 File Offset: 0x00111B14
	public void OnDisable()
	{
		this.Unbind();
	}

	// Token: 0x060049C5 RID: 18885 RVA: 0x0011391C File Offset: 0x00111B1C
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

	// Token: 0x060049C6 RID: 18886 RVA: 0x001139B4 File Offset: 0x00111BB4
	public void Bind()
	{
		if (this.isBound)
		{
			return;
		}
		if (!this.DataSource.IsValid || !this.DataTarget.IsValid)
		{
			global::UnityEngine.Debug.LogError(string.Format("Invalid data binding configuration - Source:{0}, Target:{1}", this.DataSource, this.DataTarget));
			return;
		}
		this.sourceProperty = this.DataSource.GetProperty();
		this.targetProperty = this.DataTarget.GetProperty();
		this.isBound = (this.sourceProperty != null && this.targetProperty != null);
		if (this.isBound)
		{
			this.targetProperty.Value = this.sourceProperty.Value;
		}
	}

	// Token: 0x060049C7 RID: 18887 RVA: 0x00113A6C File Offset: 0x00111C6C
	public void Unbind()
	{
		if (!this.isBound)
		{
			return;
		}
		this.sourceProperty = null;
		this.targetProperty = null;
		this.isBound = false;
	}

	// Token: 0x060049C8 RID: 18888 RVA: 0x00113A90 File Offset: 0x00111C90
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

	// Token: 0x04002739 RID: 10041
	public global::dfComponentMemberInfo DataSource;

	// Token: 0x0400273A RID: 10042
	public global::dfComponentMemberInfo DataTarget;

	// Token: 0x0400273B RID: 10043
	public bool TwoWay;

	// Token: 0x0400273C RID: 10044
	private global::dfObservableProperty sourceProperty;

	// Token: 0x0400273D RID: 10045
	private global::dfObservableProperty targetProperty;

	// Token: 0x0400273E RID: 10046
	private bool isBound;
}
