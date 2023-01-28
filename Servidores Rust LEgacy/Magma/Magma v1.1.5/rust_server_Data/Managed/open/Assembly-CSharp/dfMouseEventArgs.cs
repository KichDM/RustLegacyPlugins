using System;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x020007FC RID: 2044
public class dfMouseEventArgs : global::dfControlEventArgs
{
	// Token: 0x06004447 RID: 17479 RVA: 0x000F9634 File Offset: 0x000F7834
	public dfMouseEventArgs(global::dfControl Source, global::dfMouseButtons button, int clicks, global::UnityEngine.Ray ray, global::UnityEngine.Vector2 location, float wheel) : base(Source)
	{
		this.Buttons = button;
		this.Clicks = clicks;
		this.Position = location;
		this.WheelDelta = wheel;
		this.Ray = ray;
	}

	// Token: 0x06004448 RID: 17480 RVA: 0x000F9670 File Offset: 0x000F7870
	public dfMouseEventArgs(global::dfControl Source) : base(Source)
	{
		this.Buttons = global::dfMouseButtons.None;
		this.Clicks = 0;
		this.Position = global::UnityEngine.Vector2.zero;
		this.WheelDelta = 0f;
	}

	// Token: 0x17000C96 RID: 3222
	// (get) Token: 0x06004449 RID: 17481 RVA: 0x000F96A8 File Offset: 0x000F78A8
	// (set) Token: 0x0600444A RID: 17482 RVA: 0x000F96B0 File Offset: 0x000F78B0
	public global::dfMouseButtons Buttons
	{
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		get
		{
			return this.<Buttons>k__BackingField;
		}
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private set
		{
			this.<Buttons>k__BackingField = value;
		}
	}

	// Token: 0x17000C97 RID: 3223
	// (get) Token: 0x0600444B RID: 17483 RVA: 0x000F96BC File Offset: 0x000F78BC
	// (set) Token: 0x0600444C RID: 17484 RVA: 0x000F96C4 File Offset: 0x000F78C4
	public int Clicks
	{
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		get
		{
			return this.<Clicks>k__BackingField;
		}
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private set
		{
			this.<Clicks>k__BackingField = value;
		}
	}

	// Token: 0x17000C98 RID: 3224
	// (get) Token: 0x0600444D RID: 17485 RVA: 0x000F96D0 File Offset: 0x000F78D0
	// (set) Token: 0x0600444E RID: 17486 RVA: 0x000F96D8 File Offset: 0x000F78D8
	public float WheelDelta
	{
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		get
		{
			return this.<WheelDelta>k__BackingField;
		}
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private set
		{
			this.<WheelDelta>k__BackingField = value;
		}
	}

	// Token: 0x17000C99 RID: 3225
	// (get) Token: 0x0600444F RID: 17487 RVA: 0x000F96E4 File Offset: 0x000F78E4
	// (set) Token: 0x06004450 RID: 17488 RVA: 0x000F96EC File Offset: 0x000F78EC
	public global::UnityEngine.Vector2 MoveDelta
	{
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		get
		{
			return this.<MoveDelta>k__BackingField;
		}
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		set
		{
			this.<MoveDelta>k__BackingField = value;
		}
	}

	// Token: 0x17000C9A RID: 3226
	// (get) Token: 0x06004451 RID: 17489 RVA: 0x000F96F8 File Offset: 0x000F78F8
	// (set) Token: 0x06004452 RID: 17490 RVA: 0x000F9700 File Offset: 0x000F7900
	public global::UnityEngine.Vector2 Position
	{
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		get
		{
			return this.<Position>k__BackingField;
		}
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		set
		{
			this.<Position>k__BackingField = value;
		}
	}

	// Token: 0x17000C9B RID: 3227
	// (get) Token: 0x06004453 RID: 17491 RVA: 0x000F970C File Offset: 0x000F790C
	// (set) Token: 0x06004454 RID: 17492 RVA: 0x000F9714 File Offset: 0x000F7914
	public global::UnityEngine.Ray Ray
	{
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		get
		{
			return this.<Ray>k__BackingField;
		}
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		set
		{
			this.<Ray>k__BackingField = value;
		}
	}

	// Token: 0x0400246C RID: 9324
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private global::dfMouseButtons <Buttons>k__BackingField;

	// Token: 0x0400246D RID: 9325
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private int <Clicks>k__BackingField;

	// Token: 0x0400246E RID: 9326
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private float <WheelDelta>k__BackingField;

	// Token: 0x0400246F RID: 9327
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private global::UnityEngine.Vector2 <MoveDelta>k__BackingField;

	// Token: 0x04002470 RID: 9328
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private global::UnityEngine.Vector2 <Position>k__BackingField;

	// Token: 0x04002471 RID: 9329
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private global::UnityEngine.Ray <Ray>k__BackingField;
}
