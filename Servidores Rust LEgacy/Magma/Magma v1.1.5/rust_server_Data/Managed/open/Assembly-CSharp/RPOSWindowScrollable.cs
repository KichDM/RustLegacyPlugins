using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x02000545 RID: 1349
public class RPOSWindowScrollable : global::RPOSWindow
{
	// Token: 0x06002E0A RID: 11786 RVA: 0x000AEFD4 File Offset: 0x000AD1D4
	public RPOSWindowScrollable()
	{
	}

	// Token: 0x06002E0B RID: 11787 RVA: 0x000AEFEC File Offset: 0x000AD1EC
	protected override void OnWindowShow()
	{
		base.OnWindowShow();
		if (this.autoResetScrolling)
		{
			this.ResetScrolling();
		}
	}

	// Token: 0x06002E0C RID: 11788 RVA: 0x000AF008 File Offset: 0x000AD208
	protected void ResetScrolling()
	{
		this.ResetScrolling(false);
	}

	// Token: 0x06002E0D RID: 11789 RVA: 0x000AF014 File Offset: 0x000AD214
	protected virtual void ResetScrolling(bool retainCurrentValue)
	{
		global::UIScrollBar uiscrollBar = null;
		global::UIScrollBar uiscrollBar2 = null;
		if (this.myDraggablePanel)
		{
			if (!retainCurrentValue)
			{
				uiscrollBar = ((!this.vertical) ? null : this.myDraggablePanel.verticalScrollBar);
				uiscrollBar2 = ((!this.horizontal) ? null : this.myDraggablePanel.horizontalScrollBar);
			}
			if (!this.didManualStart)
			{
				this.myDraggablePanel.ManualStart();
				this.didManualStart = true;
			}
			this.myDraggablePanel.calculateBoundsEveryChange = false;
			this.NextFrameRecalculateBounds();
		}
		else if (!retainCurrentValue)
		{
			uiscrollBar = ((!this.vertical || this.horizontal) ? null : base.GetComponentInChildren<global::UIScrollBar>());
			uiscrollBar2 = ((!this.horizontal || this.vertical) ? null : base.GetComponentInChildren<global::UIScrollBar>());
		}
		if (!retainCurrentValue)
		{
			if (this.vertical && uiscrollBar)
			{
				uiscrollBar.scrollValue = this.initialScrollValue.y;
				uiscrollBar.ForceUpdate();
			}
			if (this.horizontal && uiscrollBar2)
			{
				uiscrollBar2.scrollValue = this.initialScrollValue.x;
				uiscrollBar2.ForceUpdate();
			}
		}
	}

	// Token: 0x06002E0E RID: 11790 RVA: 0x000AF158 File Offset: 0x000AD358
	protected void NextFrameRecalculateBounds()
	{
		this.cancelCalculationNextFrame = false;
		if (!this.queuedCalculationNextFrame)
		{
			base.StartCoroutine(this.Routine_NextFrameRecalculateBounds());
		}
	}

	// Token: 0x06002E0F RID: 11791 RVA: 0x000AF17C File Offset: 0x000AD37C
	private global::System.Collections.IEnumerator Routine_NextFrameRecalculateBounds()
	{
		yield return null;
		this.queuedCalculationNextFrame = false;
		if (!this.cancelCalculationNextFrame && this.myDraggablePanel)
		{
			this.myDraggablePanel.CalculateBoundsIfNeeded();
		}
		yield break;
	}

	// Token: 0x040017C5 RID: 6085
	public global::UIDraggablePanel myDraggablePanel;

	// Token: 0x040017C6 RID: 6086
	public bool horizontal;

	// Token: 0x040017C7 RID: 6087
	public bool vertical = true;

	// Token: 0x040017C8 RID: 6088
	protected bool autoResetScrolling = true;

	// Token: 0x040017C9 RID: 6089
	private bool didManualStart;

	// Token: 0x040017CA RID: 6090
	private bool queuedCalculationNextFrame;

	// Token: 0x040017CB RID: 6091
	private bool cancelCalculationNextFrame;

	// Token: 0x040017CC RID: 6092
	protected global::UnityEngine.Vector2 initialScrollValue;

	// Token: 0x02000546 RID: 1350
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private sealed class <Routine_NextFrameRecalculateBounds>c__Iterator40 : global::System.IDisposable, global::System.Collections.IEnumerator, global::System.Collections.Generic.IEnumerator<object>
	{
		// Token: 0x06002E10 RID: 11792 RVA: 0x000AF198 File Offset: 0x000AD398
		public <Routine_NextFrameRecalculateBounds>c__Iterator40()
		{
		}

		// Token: 0x170009DB RID: 2523
		// (get) Token: 0x06002E11 RID: 11793 RVA: 0x000AF1A0 File Offset: 0x000AD3A0
		object global::System.Collections.Generic.IEnumerator<object>.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170009DC RID: 2524
		// (get) Token: 0x06002E12 RID: 11794 RVA: 0x000AF1A8 File Offset: 0x000AD3A8
		object global::System.Collections.IEnumerator.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06002E13 RID: 11795 RVA: 0x000AF1B0 File Offset: 0x000AD3B0
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			switch (num)
			{
			case 0U:
				this.$current = null;
				this.$PC = 1;
				return true;
			case 1U:
				this.queuedCalculationNextFrame = false;
				if (!this.cancelCalculationNextFrame && this.myDraggablePanel)
				{
					this.myDraggablePanel.CalculateBoundsIfNeeded();
				}
				this.$PC = -1;
				break;
			}
			return false;
		}

		// Token: 0x06002E14 RID: 11796 RVA: 0x000AF240 File Offset: 0x000AD440
		[global::System.Diagnostics.DebuggerHidden]
		public void Dispose()
		{
			this.$PC = -1;
		}

		// Token: 0x06002E15 RID: 11797 RVA: 0x000AF24C File Offset: 0x000AD44C
		[global::System.Diagnostics.DebuggerHidden]
		public void Reset()
		{
			throw new global::System.NotSupportedException();
		}

		// Token: 0x040017CD RID: 6093
		internal int $PC;

		// Token: 0x040017CE RID: 6094
		internal object $current;

		// Token: 0x040017CF RID: 6095
		internal global::RPOSWindowScrollable <>f__this;
	}
}
