using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x02000805 RID: 2053
public abstract class dfFontRendererBase : global::System.IDisposable
{
	// Token: 0x060044A9 RID: 17577 RVA: 0x000FB434 File Offset: 0x000F9634
	protected dfFontRendererBase()
	{
	}

	// Token: 0x17000CB6 RID: 3254
	// (get) Token: 0x060044AA RID: 17578 RVA: 0x000FB43C File Offset: 0x000F963C
	// (set) Token: 0x060044AB RID: 17579 RVA: 0x000FB444 File Offset: 0x000F9644
	public global::dfFontBase Font
	{
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		get
		{
			return this.<Font>k__BackingField;
		}
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		protected set
		{
			this.<Font>k__BackingField = value;
		}
	}

	// Token: 0x17000CB7 RID: 3255
	// (get) Token: 0x060044AC RID: 17580 RVA: 0x000FB450 File Offset: 0x000F9650
	// (set) Token: 0x060044AD RID: 17581 RVA: 0x000FB458 File Offset: 0x000F9658
	public global::UnityEngine.Vector2 MaxSize
	{
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		get
		{
			return this.<MaxSize>k__BackingField;
		}
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		set
		{
			this.<MaxSize>k__BackingField = value;
		}
	}

	// Token: 0x17000CB8 RID: 3256
	// (get) Token: 0x060044AE RID: 17582 RVA: 0x000FB464 File Offset: 0x000F9664
	// (set) Token: 0x060044AF RID: 17583 RVA: 0x000FB46C File Offset: 0x000F966C
	public float PixelRatio
	{
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		get
		{
			return this.<PixelRatio>k__BackingField;
		}
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		set
		{
			this.<PixelRatio>k__BackingField = value;
		}
	}

	// Token: 0x17000CB9 RID: 3257
	// (get) Token: 0x060044B0 RID: 17584 RVA: 0x000FB478 File Offset: 0x000F9678
	// (set) Token: 0x060044B1 RID: 17585 RVA: 0x000FB480 File Offset: 0x000F9680
	public float TextScale
	{
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		get
		{
			return this.<TextScale>k__BackingField;
		}
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		set
		{
			this.<TextScale>k__BackingField = value;
		}
	}

	// Token: 0x17000CBA RID: 3258
	// (get) Token: 0x060044B2 RID: 17586 RVA: 0x000FB48C File Offset: 0x000F968C
	// (set) Token: 0x060044B3 RID: 17587 RVA: 0x000FB494 File Offset: 0x000F9694
	public int CharacterSpacing
	{
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		get
		{
			return this.<CharacterSpacing>k__BackingField;
		}
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		set
		{
			this.<CharacterSpacing>k__BackingField = value;
		}
	}

	// Token: 0x17000CBB RID: 3259
	// (get) Token: 0x060044B4 RID: 17588 RVA: 0x000FB4A0 File Offset: 0x000F96A0
	// (set) Token: 0x060044B5 RID: 17589 RVA: 0x000FB4A8 File Offset: 0x000F96A8
	public global::UnityEngine.Vector3 VectorOffset
	{
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		get
		{
			return this.<VectorOffset>k__BackingField;
		}
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		set
		{
			this.<VectorOffset>k__BackingField = value;
		}
	}

	// Token: 0x17000CBC RID: 3260
	// (get) Token: 0x060044B6 RID: 17590 RVA: 0x000FB4B4 File Offset: 0x000F96B4
	// (set) Token: 0x060044B7 RID: 17591 RVA: 0x000FB4BC File Offset: 0x000F96BC
	public bool ProcessMarkup
	{
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		get
		{
			return this.<ProcessMarkup>k__BackingField;
		}
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		set
		{
			this.<ProcessMarkup>k__BackingField = value;
		}
	}

	// Token: 0x17000CBD RID: 3261
	// (get) Token: 0x060044B8 RID: 17592 RVA: 0x000FB4C8 File Offset: 0x000F96C8
	// (set) Token: 0x060044B9 RID: 17593 RVA: 0x000FB4D0 File Offset: 0x000F96D0
	public bool WordWrap
	{
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		get
		{
			return this.<WordWrap>k__BackingField;
		}
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		set
		{
			this.<WordWrap>k__BackingField = value;
		}
	}

	// Token: 0x17000CBE RID: 3262
	// (get) Token: 0x060044BA RID: 17594 RVA: 0x000FB4DC File Offset: 0x000F96DC
	// (set) Token: 0x060044BB RID: 17595 RVA: 0x000FB4E4 File Offset: 0x000F96E4
	public bool MultiLine
	{
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		get
		{
			return this.<MultiLine>k__BackingField;
		}
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		set
		{
			this.<MultiLine>k__BackingField = value;
		}
	}

	// Token: 0x17000CBF RID: 3263
	// (get) Token: 0x060044BC RID: 17596 RVA: 0x000FB4F0 File Offset: 0x000F96F0
	// (set) Token: 0x060044BD RID: 17597 RVA: 0x000FB4F8 File Offset: 0x000F96F8
	public bool OverrideMarkupColors
	{
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		get
		{
			return this.<OverrideMarkupColors>k__BackingField;
		}
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		set
		{
			this.<OverrideMarkupColors>k__BackingField = value;
		}
	}

	// Token: 0x17000CC0 RID: 3264
	// (get) Token: 0x060044BE RID: 17598 RVA: 0x000FB504 File Offset: 0x000F9704
	// (set) Token: 0x060044BF RID: 17599 RVA: 0x000FB50C File Offset: 0x000F970C
	public bool ColorizeSymbols
	{
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		get
		{
			return this.<ColorizeSymbols>k__BackingField;
		}
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		set
		{
			this.<ColorizeSymbols>k__BackingField = value;
		}
	}

	// Token: 0x17000CC1 RID: 3265
	// (get) Token: 0x060044C0 RID: 17600 RVA: 0x000FB518 File Offset: 0x000F9718
	// (set) Token: 0x060044C1 RID: 17601 RVA: 0x000FB520 File Offset: 0x000F9720
	public global::UnityEngine.TextAlignment TextAlign
	{
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		get
		{
			return this.<TextAlign>k__BackingField;
		}
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		set
		{
			this.<TextAlign>k__BackingField = value;
		}
	}

	// Token: 0x17000CC2 RID: 3266
	// (get) Token: 0x060044C2 RID: 17602 RVA: 0x000FB52C File Offset: 0x000F972C
	// (set) Token: 0x060044C3 RID: 17603 RVA: 0x000FB534 File Offset: 0x000F9734
	public global::UnityEngine.Color32 DefaultColor
	{
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		get
		{
			return this.<DefaultColor>k__BackingField;
		}
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		set
		{
			this.<DefaultColor>k__BackingField = value;
		}
	}

	// Token: 0x17000CC3 RID: 3267
	// (get) Token: 0x060044C4 RID: 17604 RVA: 0x000FB540 File Offset: 0x000F9740
	// (set) Token: 0x060044C5 RID: 17605 RVA: 0x000FB548 File Offset: 0x000F9748
	public global::UnityEngine.Color32? BottomColor
	{
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		get
		{
			return this.<BottomColor>k__BackingField;
		}
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		set
		{
			this.<BottomColor>k__BackingField = value;
		}
	}

	// Token: 0x17000CC4 RID: 3268
	// (get) Token: 0x060044C6 RID: 17606 RVA: 0x000FB554 File Offset: 0x000F9754
	// (set) Token: 0x060044C7 RID: 17607 RVA: 0x000FB55C File Offset: 0x000F975C
	public float Opacity
	{
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		get
		{
			return this.<Opacity>k__BackingField;
		}
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		set
		{
			this.<Opacity>k__BackingField = value;
		}
	}

	// Token: 0x17000CC5 RID: 3269
	// (get) Token: 0x060044C8 RID: 17608 RVA: 0x000FB568 File Offset: 0x000F9768
	// (set) Token: 0x060044C9 RID: 17609 RVA: 0x000FB570 File Offset: 0x000F9770
	public bool Outline
	{
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		get
		{
			return this.<Outline>k__BackingField;
		}
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		set
		{
			this.<Outline>k__BackingField = value;
		}
	}

	// Token: 0x17000CC6 RID: 3270
	// (get) Token: 0x060044CA RID: 17610 RVA: 0x000FB57C File Offset: 0x000F977C
	// (set) Token: 0x060044CB RID: 17611 RVA: 0x000FB584 File Offset: 0x000F9784
	public int OutlineSize
	{
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		get
		{
			return this.<OutlineSize>k__BackingField;
		}
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		set
		{
			this.<OutlineSize>k__BackingField = value;
		}
	}

	// Token: 0x17000CC7 RID: 3271
	// (get) Token: 0x060044CC RID: 17612 RVA: 0x000FB590 File Offset: 0x000F9790
	// (set) Token: 0x060044CD RID: 17613 RVA: 0x000FB598 File Offset: 0x000F9798
	public global::UnityEngine.Color32 OutlineColor
	{
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		get
		{
			return this.<OutlineColor>k__BackingField;
		}
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		set
		{
			this.<OutlineColor>k__BackingField = value;
		}
	}

	// Token: 0x17000CC8 RID: 3272
	// (get) Token: 0x060044CE RID: 17614 RVA: 0x000FB5A4 File Offset: 0x000F97A4
	// (set) Token: 0x060044CF RID: 17615 RVA: 0x000FB5AC File Offset: 0x000F97AC
	public bool Shadow
	{
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		get
		{
			return this.<Shadow>k__BackingField;
		}
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		set
		{
			this.<Shadow>k__BackingField = value;
		}
	}

	// Token: 0x17000CC9 RID: 3273
	// (get) Token: 0x060044D0 RID: 17616 RVA: 0x000FB5B8 File Offset: 0x000F97B8
	// (set) Token: 0x060044D1 RID: 17617 RVA: 0x000FB5C0 File Offset: 0x000F97C0
	public global::UnityEngine.Color32 ShadowColor
	{
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		get
		{
			return this.<ShadowColor>k__BackingField;
		}
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		set
		{
			this.<ShadowColor>k__BackingField = value;
		}
	}

	// Token: 0x17000CCA RID: 3274
	// (get) Token: 0x060044D2 RID: 17618 RVA: 0x000FB5CC File Offset: 0x000F97CC
	// (set) Token: 0x060044D3 RID: 17619 RVA: 0x000FB5D4 File Offset: 0x000F97D4
	public global::UnityEngine.Vector2 ShadowOffset
	{
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		get
		{
			return this.<ShadowOffset>k__BackingField;
		}
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		set
		{
			this.<ShadowOffset>k__BackingField = value;
		}
	}

	// Token: 0x17000CCB RID: 3275
	// (get) Token: 0x060044D4 RID: 17620 RVA: 0x000FB5E0 File Offset: 0x000F97E0
	// (set) Token: 0x060044D5 RID: 17621 RVA: 0x000FB5E8 File Offset: 0x000F97E8
	public int TabSize
	{
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		get
		{
			return this.<TabSize>k__BackingField;
		}
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		set
		{
			this.<TabSize>k__BackingField = value;
		}
	}

	// Token: 0x17000CCC RID: 3276
	// (get) Token: 0x060044D6 RID: 17622 RVA: 0x000FB5F4 File Offset: 0x000F97F4
	// (set) Token: 0x060044D7 RID: 17623 RVA: 0x000FB5FC File Offset: 0x000F97FC
	public global::System.Collections.Generic.List<int> TabStops
	{
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		get
		{
			return this.<TabStops>k__BackingField;
		}
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		set
		{
			this.<TabStops>k__BackingField = value;
		}
	}

	// Token: 0x17000CCD RID: 3277
	// (get) Token: 0x060044D8 RID: 17624 RVA: 0x000FB608 File Offset: 0x000F9808
	// (set) Token: 0x060044D9 RID: 17625 RVA: 0x000FB610 File Offset: 0x000F9810
	public global::UnityEngine.Vector2 RenderedSize
	{
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		get
		{
			return this.<RenderedSize>k__BackingField;
		}
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		internal set
		{
			this.<RenderedSize>k__BackingField = value;
		}
	}

	// Token: 0x17000CCE RID: 3278
	// (get) Token: 0x060044DA RID: 17626 RVA: 0x000FB61C File Offset: 0x000F981C
	// (set) Token: 0x060044DB RID: 17627 RVA: 0x000FB624 File Offset: 0x000F9824
	public int LinesRendered
	{
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		get
		{
			return this.<LinesRendered>k__BackingField;
		}
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		internal set
		{
			this.<LinesRendered>k__BackingField = value;
		}
	}

	// Token: 0x060044DC RID: 17628
	public abstract void Release();

	// Token: 0x060044DD RID: 17629
	public abstract float[] GetCharacterWidths(string text);

	// Token: 0x060044DE RID: 17630
	public abstract global::UnityEngine.Vector2 MeasureString(string text);

	// Token: 0x060044DF RID: 17631
	public abstract void Render(string text, global::dfRenderData destination);

	// Token: 0x060044E0 RID: 17632 RVA: 0x000FB630 File Offset: 0x000F9830
	protected virtual void Reset()
	{
		this.Font = null;
		this.PixelRatio = 0f;
		this.TextScale = 1f;
		this.CharacterSpacing = 0;
		this.VectorOffset = global::UnityEngine.Vector3.zero;
		this.ProcessMarkup = false;
		this.WordWrap = false;
		this.MultiLine = false;
		this.OverrideMarkupColors = false;
		this.ColorizeSymbols = false;
		this.TextAlign = 0;
		this.DefaultColor = global::UnityEngine.Color.white;
		this.BottomColor = null;
		this.Opacity = 1f;
		this.Outline = false;
		this.Shadow = false;
	}

	// Token: 0x060044E1 RID: 17633 RVA: 0x000FB6D0 File Offset: 0x000F98D0
	public void Dispose()
	{
		this.Release();
	}

	// Token: 0x0400249F RID: 9375
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private global::dfFontBase <Font>k__BackingField;

	// Token: 0x040024A0 RID: 9376
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private global::UnityEngine.Vector2 <MaxSize>k__BackingField;

	// Token: 0x040024A1 RID: 9377
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private float <PixelRatio>k__BackingField;

	// Token: 0x040024A2 RID: 9378
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private float <TextScale>k__BackingField;

	// Token: 0x040024A3 RID: 9379
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private int <CharacterSpacing>k__BackingField;

	// Token: 0x040024A4 RID: 9380
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private global::UnityEngine.Vector3 <VectorOffset>k__BackingField;

	// Token: 0x040024A5 RID: 9381
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private bool <ProcessMarkup>k__BackingField;

	// Token: 0x040024A6 RID: 9382
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private bool <WordWrap>k__BackingField;

	// Token: 0x040024A7 RID: 9383
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private bool <MultiLine>k__BackingField;

	// Token: 0x040024A8 RID: 9384
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private bool <OverrideMarkupColors>k__BackingField;

	// Token: 0x040024A9 RID: 9385
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private bool <ColorizeSymbols>k__BackingField;

	// Token: 0x040024AA RID: 9386
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private global::UnityEngine.TextAlignment <TextAlign>k__BackingField;

	// Token: 0x040024AB RID: 9387
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private global::UnityEngine.Color32 <DefaultColor>k__BackingField;

	// Token: 0x040024AC RID: 9388
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private global::UnityEngine.Color32? <BottomColor>k__BackingField;

	// Token: 0x040024AD RID: 9389
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private float <Opacity>k__BackingField;

	// Token: 0x040024AE RID: 9390
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private bool <Outline>k__BackingField;

	// Token: 0x040024AF RID: 9391
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private int <OutlineSize>k__BackingField;

	// Token: 0x040024B0 RID: 9392
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private global::UnityEngine.Color32 <OutlineColor>k__BackingField;

	// Token: 0x040024B1 RID: 9393
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private bool <Shadow>k__BackingField;

	// Token: 0x040024B2 RID: 9394
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private global::UnityEngine.Color32 <ShadowColor>k__BackingField;

	// Token: 0x040024B3 RID: 9395
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private global::UnityEngine.Vector2 <ShadowOffset>k__BackingField;

	// Token: 0x040024B4 RID: 9396
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private int <TabSize>k__BackingField;

	// Token: 0x040024B5 RID: 9397
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private global::System.Collections.Generic.List<int> <TabStops>k__BackingField;

	// Token: 0x040024B6 RID: 9398
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private global::UnityEngine.Vector2 <RenderedSize>k__BackingField;

	// Token: 0x040024B7 RID: 9399
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private int <LinesRendered>k__BackingField;
}
