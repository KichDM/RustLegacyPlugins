using System;
using UnityEngine;

// Token: 0x02000438 RID: 1080
public static class ServerRuntime
{
	// Token: 0x060025B1 RID: 9649 RVA: 0x000901A4 File Offset: 0x0008E3A4
	public static void PushLoadingPhase()
	{
		global::ServerRuntime.LoadingPhaseCount = ((global::ServerRuntime.LoadingPhaseCount >= 1) ? (global::ServerRuntime.LoadingPhaseCount + 1) : 1);
		global::UnityEngine.Application.targetFrameRate = 0;
	}

	// Token: 0x060025B2 RID: 9650 RVA: 0x000901CC File Offset: 0x0008E3CC
	public static void PopLoadingPhase()
	{
		if (--global::ServerRuntime.LoadingPhaseCount == 0)
		{
			if (global::ServerRuntime.SetTargetFrameRate != null)
			{
				global::UnityEngine.Application.targetFrameRate = global::ServerRuntime.SetTargetFrameRate.Value;
			}
		}
		else if (global::ServerRuntime.LoadingPhaseCount < 0)
		{
			global::ServerRuntime.LoadingPhaseCount = 0;
		}
	}

	// Token: 0x17000865 RID: 2149
	// (get) Token: 0x060025B3 RID: 9651 RVA: 0x00090220 File Offset: 0x0008E420
	// (set) Token: 0x060025B4 RID: 9652 RVA: 0x00090250 File Offset: 0x0008E450
	public static int TargetFrameRate
	{
		get
		{
			int? setTargetFrameRate = global::ServerRuntime.SetTargetFrameRate;
			return (setTargetFrameRate == null) ? global::UnityEngine.Application.targetFrameRate : setTargetFrameRate.Value;
		}
		set
		{
			global::ServerRuntime.SetTargetFrameRate = new int?(value);
			if (global::ServerRuntime.LoadingPhaseCount > 0)
			{
				global::UnityEngine.Application.targetFrameRate = value;
			}
		}
	}

	// Token: 0x04001336 RID: 4918
	private static int? SetTargetFrameRate;

	// Token: 0x04001337 RID: 4919
	private static int LoadingPhaseCount;
}
