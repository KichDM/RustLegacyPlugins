using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x020007FD RID: 2045
public class dfTouchEventArgs : global::dfMouseEventArgs
{
	// Token: 0x06004455 RID: 17493 RVA: 0x000F9720 File Offset: 0x000F7920
	public dfTouchEventArgs(global::dfControl Source, global::UnityEngine.Touch touch, global::UnityEngine.Ray ray) : base(Source, global::dfMouseButtons.Left, touch.tapCount, ray, touch.position, 0f)
	{
		this.Touch = touch;
		this.Touches = new global::System.Collections.Generic.List<global::UnityEngine.Touch>
		{
			touch
		};
		if (touch.deltaTime > 1E-45f)
		{
			base.MoveDelta = touch.deltaPosition * (global::UnityEngine.Time.deltaTime / touch.deltaTime);
		}
	}

	// Token: 0x06004456 RID: 17494 RVA: 0x000F9794 File Offset: 0x000F7994
	public dfTouchEventArgs(global::dfControl source, global::System.Collections.Generic.List<global::UnityEngine.Touch> touches, global::UnityEngine.Ray ray) : this(source, touches.First<global::UnityEngine.Touch>(), ray)
	{
		this.Touches = touches;
	}

	// Token: 0x06004457 RID: 17495 RVA: 0x000F97AC File Offset: 0x000F79AC
	public dfTouchEventArgs(global::dfControl Source) : base(Source)
	{
		base.Position = global::UnityEngine.Vector2.zero;
	}

	// Token: 0x17000C9C RID: 3228
	// (get) Token: 0x06004458 RID: 17496 RVA: 0x000F97C0 File Offset: 0x000F79C0
	// (set) Token: 0x06004459 RID: 17497 RVA: 0x000F97C8 File Offset: 0x000F79C8
	public global::UnityEngine.Touch Touch
	{
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		get
		{
			return this.<Touch>k__BackingField;
		}
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private set
		{
			this.<Touch>k__BackingField = value;
		}
	}

	// Token: 0x17000C9D RID: 3229
	// (get) Token: 0x0600445A RID: 17498 RVA: 0x000F97D4 File Offset: 0x000F79D4
	// (set) Token: 0x0600445B RID: 17499 RVA: 0x000F97DC File Offset: 0x000F79DC
	public global::System.Collections.Generic.List<global::UnityEngine.Touch> Touches
	{
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		get
		{
			return this.<Touches>k__BackingField;
		}
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private set
		{
			this.<Touches>k__BackingField = value;
		}
	}

	// Token: 0x17000C9E RID: 3230
	// (get) Token: 0x0600445C RID: 17500 RVA: 0x000F97E8 File Offset: 0x000F79E8
	public bool IsMultiTouch
	{
		get
		{
			return this.Touches.Count > 1;
		}
	}

	// Token: 0x04002472 RID: 9330
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private global::UnityEngine.Touch <Touch>k__BackingField;

	// Token: 0x04002473 RID: 9331
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private global::System.Collections.Generic.List<global::UnityEngine.Touch> <Touches>k__BackingField;
}
