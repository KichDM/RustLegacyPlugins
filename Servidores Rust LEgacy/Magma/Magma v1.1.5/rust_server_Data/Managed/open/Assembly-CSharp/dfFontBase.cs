using System;
using UnityEngine;

// Token: 0x02000804 RID: 2052
[global::System.Serializable]
public abstract class dfFontBase : global::UnityEngine.MonoBehaviour
{
	// Token: 0x0600449F RID: 17567 RVA: 0x000FB42C File Offset: 0x000F962C
	protected dfFontBase()
	{
	}

	// Token: 0x17000CB1 RID: 3249
	// (get) Token: 0x060044A0 RID: 17568
	// (set) Token: 0x060044A1 RID: 17569
	public abstract global::UnityEngine.Material Material { get; set; }

	// Token: 0x17000CB2 RID: 3250
	// (get) Token: 0x060044A2 RID: 17570
	public abstract global::UnityEngine.Texture Texture { get; }

	// Token: 0x17000CB3 RID: 3251
	// (get) Token: 0x060044A3 RID: 17571
	public abstract bool IsValid { get; }

	// Token: 0x17000CB4 RID: 3252
	// (get) Token: 0x060044A4 RID: 17572
	// (set) Token: 0x060044A5 RID: 17573
	public abstract int FontSize { get; set; }

	// Token: 0x17000CB5 RID: 3253
	// (get) Token: 0x060044A6 RID: 17574
	// (set) Token: 0x060044A7 RID: 17575
	public abstract int LineHeight { get; set; }

	// Token: 0x060044A8 RID: 17576
	public abstract global::dfFontRendererBase ObtainRenderer();
}
