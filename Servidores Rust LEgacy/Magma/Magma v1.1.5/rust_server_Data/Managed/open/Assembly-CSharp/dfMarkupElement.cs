using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02000865 RID: 2149
public abstract class dfMarkupElement
{
	// Token: 0x06004A89 RID: 19081 RVA: 0x001184FC File Offset: 0x001166FC
	public dfMarkupElement()
	{
		this.ChildNodes = new global::System.Collections.Generic.List<global::dfMarkupElement>();
	}

	// Token: 0x17000DF4 RID: 3572
	// (get) Token: 0x06004A8A RID: 19082 RVA: 0x00118510 File Offset: 0x00116710
	// (set) Token: 0x06004A8B RID: 19083 RVA: 0x00118518 File Offset: 0x00116718
	public global::dfMarkupElement Parent
	{
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		get
		{
			return this.<Parent>k__BackingField;
		}
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		protected set
		{
			this.<Parent>k__BackingField = value;
		}
	}

	// Token: 0x17000DF5 RID: 3573
	// (get) Token: 0x06004A8C RID: 19084 RVA: 0x00118524 File Offset: 0x00116724
	// (set) Token: 0x06004A8D RID: 19085 RVA: 0x0011852C File Offset: 0x0011672C
	private protected global::System.Collections.Generic.List<global::dfMarkupElement> ChildNodes
	{
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		protected get
		{
			return this.<ChildNodes>k__BackingField;
		}
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private set
		{
			this.<ChildNodes>k__BackingField = value;
		}
	}

	// Token: 0x06004A8E RID: 19086 RVA: 0x00118538 File Offset: 0x00116738
	public void AddChildNode(global::dfMarkupElement node)
	{
		node.Parent = this;
		this.ChildNodes.Add(node);
	}

	// Token: 0x06004A8F RID: 19087 RVA: 0x00118550 File Offset: 0x00116750
	public void PerformLayout(global::dfMarkupBox container, global::dfMarkupStyle style)
	{
		this._PerformLayoutImpl(container, style);
	}

	// Token: 0x06004A90 RID: 19088 RVA: 0x0011855C File Offset: 0x0011675C
	internal virtual void Release()
	{
		this.Parent = null;
		this.ChildNodes.Clear();
	}

	// Token: 0x06004A91 RID: 19089
	protected abstract void _PerformLayoutImpl(global::dfMarkupBox container, global::dfMarkupStyle style);

	// Token: 0x040027B2 RID: 10162
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private global::dfMarkupElement <Parent>k__BackingField;

	// Token: 0x040027B3 RID: 10163
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private global::System.Collections.Generic.List<global::dfMarkupElement> <ChildNodes>k__BackingField;
}
