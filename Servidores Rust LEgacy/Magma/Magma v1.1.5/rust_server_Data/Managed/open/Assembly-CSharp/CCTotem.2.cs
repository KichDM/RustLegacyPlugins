using System;

// Token: 0x02000318 RID: 792
public abstract class CCTotem<TTotemObject> : global::CCTotem where TTotemObject : global::CCTotem.TotemicObject
{
	// Token: 0x06001ABB RID: 6843 RVA: 0x000695E4 File Offset: 0x000677E4
	internal CCTotem()
	{
	}

	// Token: 0x17000767 RID: 1895
	// (get) Token: 0x06001ABC RID: 6844 RVA: 0x000695EC File Offset: 0x000677EC
	internal sealed override global::CCTotem.TotemicObject _Object
	{
		get
		{
			return this.totemicObject;
		}
	}

	// Token: 0x04000F95 RID: 3989
	protected internal new TTotemObject totemicObject;
}
