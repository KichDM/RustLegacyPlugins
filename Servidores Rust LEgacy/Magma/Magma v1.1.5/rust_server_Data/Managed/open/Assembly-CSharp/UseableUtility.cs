using System;
using UnityEngine;

// Token: 0x02000235 RID: 565
public static class UseableUtility
{
	// Token: 0x06000F16 RID: 3862 RVA: 0x0003A394 File Offset: 0x00038594
	// Note: this type is marked as 'beforefieldinit'.
	static UseableUtility()
	{
	}

	// Token: 0x06000F17 RID: 3863 RVA: 0x0003A398 File Offset: 0x00038598
	public static void LogError<T>(T a, global::UnityEngine.Object b)
	{
		if (global::UseableUtility.log_enabled)
		{
			global::UnityEngine.Debug.LogError(a, b);
		}
	}

	// Token: 0x06000F18 RID: 3864 RVA: 0x0003A3B0 File Offset: 0x000385B0
	public static void LogWarning<T>(T a, global::UnityEngine.Object b)
	{
		if (global::UseableUtility.log_enabled)
		{
			global::UnityEngine.Debug.LogWarning(a, b);
		}
	}

	// Token: 0x06000F19 RID: 3865 RVA: 0x0003A3C8 File Offset: 0x000385C8
	public static void Log<T>(T a, global::UnityEngine.Object b)
	{
		if (global::UseableUtility.log_enabled)
		{
			global::UnityEngine.Debug.Log(a, b);
		}
	}

	// Token: 0x06000F1A RID: 3866 RVA: 0x0003A3E0 File Offset: 0x000385E0
	public static void LogError<T>(T a)
	{
		if (global::UseableUtility.log_enabled)
		{
			global::UnityEngine.Debug.LogError(a);
		}
	}

	// Token: 0x06000F1B RID: 3867 RVA: 0x0003A3F8 File Offset: 0x000385F8
	public static void LogWarning<T>(T a)
	{
		if (global::UseableUtility.log_enabled)
		{
			global::UnityEngine.Debug.LogWarning(a);
		}
	}

	// Token: 0x06000F1C RID: 3868 RVA: 0x0003A410 File Offset: 0x00038610
	public static void Log<T>(T a)
	{
		if (global::UseableUtility.log_enabled)
		{
			global::UnityEngine.Debug.Log(a);
		}
	}

	// Token: 0x06000F1D RID: 3869 RVA: 0x0003A428 File Offset: 0x00038628
	public static bool Succeeded(this global::UseResponse response)
	{
		bool flag = (int)response >= 0;
		if (!flag)
		{
			global::UseableUtility.LogWarning<string>("Did not succeed " + response);
		}
		return flag;
	}

	// Token: 0x06000F1E RID: 3870 RVA: 0x0003A45C File Offset: 0x0003865C
	public static bool ThrewException<E>(this global::UseResponse response, out E e, bool doNotClear) where E : global::System.Exception
	{
		if ((int)response < -0x10 || (int)response > -0xA)
		{
			e = (E)((object)null);
			return false;
		}
		return global::Useable.GetLastException<E>(out e, doNotClear);
	}

	// Token: 0x06000F1F RID: 3871 RVA: 0x0003A488 File Offset: 0x00038688
	public static bool ThrewException(this global::UseResponse response, out global::System.Exception e, bool doNotClear)
	{
		if ((int)response < -0x10 || (int)response > -0xA)
		{
			e = null;
			return false;
		}
		return global::Useable.GetLastException(out e, doNotClear);
	}

	// Token: 0x06000F20 RID: 3872 RVA: 0x0003A4A8 File Offset: 0x000386A8
	public static bool ThrewException(this global::UseResponse response, out global::System.Exception e)
	{
		return response.ThrewException(out e, false);
	}

	// Token: 0x06000F21 RID: 3873 RVA: 0x0003A4B4 File Offset: 0x000386B4
	public static bool Checked(this global::UseResponse response)
	{
		return (int)response < -0x10 || (int)response > 0;
	}

	// Token: 0x06000F22 RID: 3874 RVA: 0x0003A4C8 File Offset: 0x000386C8
	public static void OnDestroy(global::IUseable self, global::Useable useable)
	{
		if (useable && useable.occupied)
		{
			useable.Eject();
		}
	}

	// Token: 0x06000F23 RID: 3875 RVA: 0x0003A4E8 File Offset: 0x000386E8
	public static void OnDestroy(global::IUseable self)
	{
		global::UnityEngine.MonoBehaviour monoBehaviour = self as global::UnityEngine.MonoBehaviour;
		if (monoBehaviour)
		{
			global::UseableUtility.OnDestroy(self, monoBehaviour.GetComponent<global::Useable>());
		}
	}

	// Token: 0x040009AA RID: 2474
	public const global::UseResponse kMinSuccess = global::UseResponse.Pass_Unchecked;

	// Token: 0x040009AB RID: 2475
	public const global::UseResponse kMinException = global::UseResponse.Fail_CheckException;

	// Token: 0x040009AC RID: 2476
	public const global::UseResponse kMaxException = global::UseResponse.Fail_Vacancy;

	// Token: 0x040009AD RID: 2477
	public const global::UseResponse kMinSucessChecked = global::UseResponse.Pass_Checked;

	// Token: 0x040009AE RID: 2478
	public const global::UseResponse kMaxFailedChecked = (global::UseResponse)-0x11;

	// Token: 0x040009AF RID: 2479
	private static bool log_enabled;
}
