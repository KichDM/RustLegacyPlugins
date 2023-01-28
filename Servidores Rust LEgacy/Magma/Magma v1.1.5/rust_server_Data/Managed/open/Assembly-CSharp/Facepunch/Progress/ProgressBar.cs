using System;
using System.Collections.Generic;
using UnityEngine;

namespace Facepunch.Progress
{
	// Token: 0x020001FA RID: 506
	public sealed class ProgressBar
	{
		// Token: 0x06000DC8 RID: 3528 RVA: 0x00035B4C File Offset: 0x00033D4C
		public ProgressBar()
		{
		}

		// Token: 0x06000DC9 RID: 3529 RVA: 0x00035B60 File Offset: 0x00033D60
		public void Add(global::Facepunch.Progress.IProgress IProgress)
		{
			if (object.ReferenceEquals(IProgress, null))
			{
				return;
			}
			this.List.Add(IProgress);
			this.count++;
			this.denom += 1f;
		}

		// Token: 0x06000DCA RID: 3530 RVA: 0x00035B9C File Offset: 0x00033D9C
		public void AddMultiple<T>(global::System.Collections.Generic.IEnumerable<T> collection) where T : global::Facepunch.Progress.IProgress
		{
			foreach (T t in collection)
			{
				this.Add(t);
			}
		}

		// Token: 0x06000DCB RID: 3531 RVA: 0x00035C00 File Offset: 0x00033E00
		public void Clear()
		{
			this.bonus = (this.denom = 0f);
			this.List.Clear();
			this.count = 0;
		}

		// Token: 0x06000DCC RID: 3532 RVA: 0x00035C34 File Offset: 0x00033E34
		public void Clean()
		{
			float num;
			this.Update(out num);
		}

		// Token: 0x06000DCD RID: 3533 RVA: 0x00035C4C File Offset: 0x00033E4C
		public bool Update(out float progress)
		{
			if (this.count == 0)
			{
				progress = 0f;
				return false;
			}
			float num = 0f;
			int i = 0;
			int num2 = this.count;
			int num3 = num2 - 1;
			while (i < num2)
			{
				float num4;
				if (this.List[num3].Poll(out num4) && num4 < 1f)
				{
					num += num4;
				}
				else
				{
					if (--this.count <= 0)
					{
						this.Clear();
						progress = 1f;
						return true;
					}
					this.bonus += 1f;
					this.List.RemoveAt(num3);
				}
				i++;
				num3--;
			}
			if ((progress = (num + this.bonus) / this.denom) > 1f)
			{
				progress = 1f;
			}
			return true;
		}

		// Token: 0x06000DCE RID: 3534 RVA: 0x00035D38 File Offset: 0x00033F38
		public void Add(global::UnityEngine.AsyncOperation Progress)
		{
			if (!object.ReferenceEquals(Progress, null))
			{
				this.Add(new global::Facepunch.Progress.ProgressBar.AsyncOperationProgress(Progress));
			}
		}

		// Token: 0x040008B0 RID: 2224
		private readonly global::System.Collections.Generic.List<global::Facepunch.Progress.IProgress> List = new global::System.Collections.Generic.List<global::Facepunch.Progress.IProgress>();

		// Token: 0x040008B1 RID: 2225
		private float bonus;

		// Token: 0x040008B2 RID: 2226
		private float denom;

		// Token: 0x040008B3 RID: 2227
		private int count;

		// Token: 0x020001FB RID: 507
		private struct AsyncOperationProgress : global::Facepunch.Progress.IProgress
		{
			// Token: 0x06000DCF RID: 3535 RVA: 0x00035D58 File Offset: 0x00033F58
			public AsyncOperationProgress(global::UnityEngine.AsyncOperation aop)
			{
				this.aop = aop;
			}

			// Token: 0x17000357 RID: 855
			// (get) Token: 0x06000DD0 RID: 3536 RVA: 0x00035D64 File Offset: 0x00033F64
			public float progress
			{
				get
				{
					return (this.aop != null && !this.aop.isDone) ? (this.aop.progress * 0.999f) : 1f;
				}
			}

			// Token: 0x040008B4 RID: 2228
			public readonly global::UnityEngine.AsyncOperation aop;
		}
	}
}
