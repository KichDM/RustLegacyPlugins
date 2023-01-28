using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using Facepunch.Clocks.Counters;
using Facepunch.Progress;
using UnityEngine;

// Token: 0x02000203 RID: 515
[global::UnityEngine.AddComponentMenu("")]
public abstract class ThrottledTask : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06000E40 RID: 3648 RVA: 0x00036B38 File Offset: 0x00034D38
	protected ThrottledTask()
	{
	}

	// Token: 0x06000E41 RID: 3649 RVA: 0x00036B40 File Offset: 0x00034D40
	// Note: this type is marked as 'beforefieldinit'.
	static ThrottledTask()
	{
	}

	// Token: 0x1700036F RID: 879
	// (get) Token: 0x06000E42 RID: 3650 RVA: 0x00036B4C File Offset: 0x00034D4C
	public static bool Operational
	{
		get
		{
			return global::ThrottledTask.numWorking > 0;
		}
	}

	// Token: 0x17000370 RID: 880
	// (get) Token: 0x06000E43 RID: 3651 RVA: 0x00036B58 File Offset: 0x00034D58
	public static global::ThrottledTask[] AllWorkingTasks
	{
		get
		{
			global::ThrottledTask[] array = new global::ThrottledTask[global::ThrottledTask.numWorking];
			int num = 0;
			foreach (global::ThrottledTask throttledTask in global::ThrottledTask.AllTasks)
			{
				if (throttledTask.working)
				{
					array[num++] = throttledTask;
					if (num == global::ThrottledTask.numWorking)
					{
						break;
					}
				}
			}
			return array;
		}
	}

	// Token: 0x17000371 RID: 881
	// (get) Token: 0x06000E44 RID: 3652 RVA: 0x00036BE8 File Offset: 0x00034DE8
	public static global::System.Collections.Generic.IEnumerable<global::Facepunch.Progress.IProgress> AllWorkingTasksProgress
	{
		get
		{
			foreach (global::ThrottledTask task in global::ThrottledTask.AllTasks)
			{
				if (task.working && task is global::Facepunch.Progress.IProgress)
				{
					yield return task as global::Facepunch.Progress.IProgress;
				}
			}
			yield break;
		}
	}

	// Token: 0x17000372 RID: 882
	// (get) Token: 0x06000E45 RID: 3653 RVA: 0x00036C04 File Offset: 0x00034E04
	protected global::ThrottledTask.Timer Begin
	{
		get
		{
			return global::ThrottledTask.Timer.Start;
		}
	}

	// Token: 0x17000373 RID: 883
	// (get) Token: 0x06000E46 RID: 3654 RVA: 0x00036C0C File Offset: 0x00034E0C
	// (set) Token: 0x06000E47 RID: 3655 RVA: 0x00036C14 File Offset: 0x00034E14
	public bool Working
	{
		get
		{
			return this.working;
		}
		protected set
		{
			this.SetWorking(value);
		}
	}

	// Token: 0x06000E48 RID: 3656 RVA: 0x00036C20 File Offset: 0x00034E20
	private void SetWorking(bool on)
	{
		if (on != this.working)
		{
			this.working = on;
			if (on)
			{
				global::ThrottledTask.numWorking++;
			}
			else
			{
				global::ThrottledTask.numWorking--;
			}
		}
	}

	// Token: 0x06000E49 RID: 3657 RVA: 0x00036C64 File Offset: 0x00034E64
	protected void Awake()
	{
		if (!this.added)
		{
			this.added = true;
			global::ThrottledTask.AllTasks.Add(this);
		}
	}

	// Token: 0x06000E4A RID: 3658 RVA: 0x00036C84 File Offset: 0x00034E84
	protected void OnDestroy()
	{
		if (this.added)
		{
			global::ThrottledTask.AllTasks.Remove(this);
		}
		else
		{
			this.added = true;
		}
		this.SetWorking(false);
	}

	// Token: 0x040008CA RID: 2250
	private const int kTargetMSPerFrame = 0x190;

	// Token: 0x040008CB RID: 2251
	[global::System.NonSerialized]
	private bool working;

	// Token: 0x040008CC RID: 2252
	[global::System.NonSerialized]
	private bool added;

	// Token: 0x040008CD RID: 2253
	private static int numWorking;

	// Token: 0x040008CE RID: 2254
	private static global::System.Collections.Generic.List<global::ThrottledTask> AllTasks = new global::System.Collections.Generic.List<global::ThrottledTask>();

	// Token: 0x02000204 RID: 516
	protected struct Timer
	{
		// Token: 0x06000E4B RID: 3659 RVA: 0x00036CBC File Offset: 0x00034EBC
		private Timer(global::Facepunch.Clocks.Counters.SystemTimestamp clock)
		{
			this.clock = clock;
		}

		// Token: 0x17000374 RID: 884
		// (get) Token: 0x06000E4C RID: 3660 RVA: 0x00036CC8 File Offset: 0x00034EC8
		internal static global::ThrottledTask.Timer Start
		{
			get
			{
				return new global::ThrottledTask.Timer(global::Facepunch.Clocks.Counters.SystemTimestamp.Restart);
			}
		}

		// Token: 0x17000375 RID: 885
		// (get) Token: 0x06000E4D RID: 3661 RVA: 0x00036CD4 File Offset: 0x00034ED4
		public bool Continue
		{
			get
			{
				return global::ThrottledTask.numWorking == 0 || this.clock.Elapsed.TotalMilliseconds < 400.0 / (double)global::ThrottledTask.numWorking;
			}
		}

		// Token: 0x040008CF RID: 2255
		private readonly global::Facepunch.Clocks.Counters.SystemTimestamp clock;
	}

	// Token: 0x02000205 RID: 517
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private sealed class <>c__IteratorD : global::System.IDisposable, global::System.Collections.IEnumerator, global::System.Collections.IEnumerable, global::System.Collections.Generic.IEnumerable<global::Facepunch.Progress.IProgress>, global::System.Collections.Generic.IEnumerator<global::Facepunch.Progress.IProgress>
	{
		// Token: 0x06000E4E RID: 3662 RVA: 0x00036D18 File Offset: 0x00034F18
		public <>c__IteratorD()
		{
		}

		// Token: 0x17000376 RID: 886
		// (get) Token: 0x06000E4F RID: 3663 RVA: 0x00036D20 File Offset: 0x00034F20
		global::Facepunch.Progress.IProgress global::System.Collections.Generic.IEnumerator<global::Facepunch.Progress.IProgress>.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17000377 RID: 887
		// (get) Token: 0x06000E50 RID: 3664 RVA: 0x00036D28 File Offset: 0x00034F28
		object global::System.Collections.IEnumerator.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06000E51 RID: 3665 RVA: 0x00036D30 File Offset: 0x00034F30
		[global::System.Diagnostics.DebuggerHidden]
		global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<Facepunch.Progress.IProgress>.GetEnumerator();
		}

		// Token: 0x06000E52 RID: 3666 RVA: 0x00036D38 File Offset: 0x00034F38
		[global::System.Diagnostics.DebuggerHidden]
		global::System.Collections.Generic.IEnumerator<global::Facepunch.Progress.IProgress> global::System.Collections.Generic.IEnumerable<global::Facepunch.Progress.IProgress>.GetEnumerator()
		{
			if (global::System.Threading.Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			return new global::ThrottledTask.<>c__IteratorD();
		}

		// Token: 0x06000E53 RID: 3667 RVA: 0x00036D54 File Offset: 0x00034F54
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0U:
				enumerator = global::ThrottledTask.AllTasks.GetEnumerator();
				num = 0xFFFFFFFDU;
				break;
			case 1U:
				break;
			default:
				return false;
			}
			try
			{
				switch (num)
				{
				}
				while (enumerator.MoveNext())
				{
					task = enumerator.Current;
					if (task.working && task is global::Facepunch.Progress.IProgress)
					{
						this.$current = (task as global::Facepunch.Progress.IProgress);
						this.$PC = 1;
						flag = true;
						return true;
					}
				}
			}
			finally
			{
				if (!flag)
				{
					((global::System.IDisposable)enumerator).Dispose();
				}
			}
			this.$PC = -1;
			return false;
		}

		// Token: 0x06000E54 RID: 3668 RVA: 0x00036E4C File Offset: 0x0003504C
		[global::System.Diagnostics.DebuggerHidden]
		public void Dispose()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			switch (num)
			{
			case 1U:
				try
				{
				}
				finally
				{
					((global::System.IDisposable)enumerator).Dispose();
				}
				break;
			}
		}

		// Token: 0x06000E55 RID: 3669 RVA: 0x00036EAC File Offset: 0x000350AC
		[global::System.Diagnostics.DebuggerHidden]
		public void Reset()
		{
			throw new global::System.NotSupportedException();
		}

		// Token: 0x040008D0 RID: 2256
		internal global::System.Collections.Generic.List<global::ThrottledTask>.Enumerator <$s_106>__0;

		// Token: 0x040008D1 RID: 2257
		internal global::ThrottledTask <task>__1;

		// Token: 0x040008D2 RID: 2258
		internal int $PC;

		// Token: 0x040008D3 RID: 2259
		internal global::Facepunch.Progress.IProgress $current;
	}
}
