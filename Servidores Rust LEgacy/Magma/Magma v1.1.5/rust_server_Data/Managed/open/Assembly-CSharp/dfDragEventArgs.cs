using System;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x020007FA RID: 2042
public class dfDragEventArgs : global::dfControlEventArgs
{
	// Token: 0x0600442F RID: 17455 RVA: 0x000F949C File Offset: 0x000F769C
	internal dfDragEventArgs(global::dfControl source) : base(source)
	{
		this.State = global::dfDragDropState.None;
	}

	// Token: 0x06004430 RID: 17456 RVA: 0x000F94AC File Offset: 0x000F76AC
	internal dfDragEventArgs(global::dfControl source, global::dfDragDropState state, object data, global::UnityEngine.Ray ray, global::UnityEngine.Vector2 position) : base(source)
	{
		this.Data = data;
		this.State = state;
		this.Position = position;
		this.Ray = ray;
	}

	// Token: 0x17000C8C RID: 3212
	// (get) Token: 0x06004431 RID: 17457 RVA: 0x000F94E0 File Offset: 0x000F76E0
	// (set) Token: 0x06004432 RID: 17458 RVA: 0x000F94E8 File Offset: 0x000F76E8
	public global::dfDragDropState State
	{
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		get
		{
			return this.<State>k__BackingField;
		}
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		set
		{
			this.<State>k__BackingField = value;
		}
	}

	// Token: 0x17000C8D RID: 3213
	// (get) Token: 0x06004433 RID: 17459 RVA: 0x000F94F4 File Offset: 0x000F76F4
	// (set) Token: 0x06004434 RID: 17460 RVA: 0x000F94FC File Offset: 0x000F76FC
	public object Data
	{
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		get
		{
			return this.<Data>k__BackingField;
		}
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		set
		{
			this.<Data>k__BackingField = value;
		}
	}

	// Token: 0x17000C8E RID: 3214
	// (get) Token: 0x06004435 RID: 17461 RVA: 0x000F9508 File Offset: 0x000F7708
	// (set) Token: 0x06004436 RID: 17462 RVA: 0x000F9510 File Offset: 0x000F7710
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

	// Token: 0x17000C8F RID: 3215
	// (get) Token: 0x06004437 RID: 17463 RVA: 0x000F951C File Offset: 0x000F771C
	// (set) Token: 0x06004438 RID: 17464 RVA: 0x000F9524 File Offset: 0x000F7724
	public global::dfControl Target
	{
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		get
		{
			return this.<Target>k__BackingField;
		}
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		set
		{
			this.<Target>k__BackingField = value;
		}
	}

	// Token: 0x17000C90 RID: 3216
	// (get) Token: 0x06004439 RID: 17465 RVA: 0x000F9530 File Offset: 0x000F7730
	// (set) Token: 0x0600443A RID: 17466 RVA: 0x000F9538 File Offset: 0x000F7738
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

	// Token: 0x04002462 RID: 9314
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private global::dfDragDropState <State>k__BackingField;

	// Token: 0x04002463 RID: 9315
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private object <Data>k__BackingField;

	// Token: 0x04002464 RID: 9316
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private global::UnityEngine.Vector2 <Position>k__BackingField;

	// Token: 0x04002465 RID: 9317
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private global::dfControl <Target>k__BackingField;

	// Token: 0x04002466 RID: 9318
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private global::UnityEngine.Ray <Ray>k__BackingField;
}
