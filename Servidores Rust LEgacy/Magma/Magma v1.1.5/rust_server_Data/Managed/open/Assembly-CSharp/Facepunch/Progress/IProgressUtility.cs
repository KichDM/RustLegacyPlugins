using System;
using UnityEngine;

namespace Facepunch.Progress
{
	// Token: 0x020001F9 RID: 505
	public static class IProgressUtility
	{
		// Token: 0x06000DC7 RID: 3527 RVA: 0x00035AD0 File Offset: 0x00033CD0
		public static bool Poll(this global::Facepunch.Progress.IProgress IProgress, out float progress)
		{
			bool flag;
			if (IProgress is global::UnityEngine.Object)
			{
				flag = !(global::UnityEngine.Object)IProgress;
			}
			else
			{
				flag = object.ReferenceEquals(IProgress, null);
			}
			if (flag)
			{
				progress = 0f;
				return false;
			}
			float progress2 = IProgress.progress;
			if (progress2 >= 1f)
			{
				progress = 1f;
			}
			else if (progress2 <= 0f)
			{
				progress = 0f;
			}
			else
			{
				progress = progress2;
			}
			return true;
		}
	}
}
