using System;
using System.Diagnostics;
using UnityEngine;

// Token: 0x020007C4 RID: 1988
[global::UnityEngine.ExecuteInEditMode]
public class TestTransformFind : global::UnityEngine.MonoBehaviour
{
	// Token: 0x060041F2 RID: 16882 RVA: 0x000EF410 File Offset: 0x000ED610
	public TestTransformFind()
	{
	}

	// Token: 0x060041F3 RID: 16883 RVA: 0x000EF418 File Offset: 0x000ED618
	private void Update()
	{
		if (string.IsNullOrEmpty(this.find))
		{
			this.foundFind = null;
			this.foundIter = null;
		}
		else
		{
			if (this.findSW == null)
			{
				this.findSW = new global::System.Diagnostics.Stopwatch();
			}
			this.findSW.Reset();
			this.findSW.Start();
			this.foundFind = base.transform.Find(this.find);
			this.findSW.Stop();
			this.findTime = (float)this.findSW.Elapsed.TotalMilliseconds;
			if (this.iterSW == null)
			{
				this.iterSW = new global::System.Diagnostics.Stopwatch();
			}
			this.iterSW.Reset();
			this.iterSW.Start();
			this.foundIter = global::FindChildHelper.FindChildByName(this.find, this);
			this.iterSW.Stop();
			this.iterTime = (float)this.iterSW.Elapsed.TotalMilliseconds;
		}
	}

	// Token: 0x040022B4 RID: 8884
	public string find;

	// Token: 0x040022B5 RID: 8885
	public global::UnityEngine.Transform foundFind;

	// Token: 0x040022B6 RID: 8886
	public global::UnityEngine.Transform foundIter;

	// Token: 0x040022B7 RID: 8887
	public float findTime;

	// Token: 0x040022B8 RID: 8888
	public float iterTime;

	// Token: 0x040022B9 RID: 8889
	private global::System.Diagnostics.Stopwatch findSW;

	// Token: 0x040022BA RID: 8890
	private global::System.Diagnostics.Stopwatch iterSW;
}
