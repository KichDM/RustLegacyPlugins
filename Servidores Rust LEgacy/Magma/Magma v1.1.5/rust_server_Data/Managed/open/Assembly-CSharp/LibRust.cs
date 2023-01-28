using System;
using System.Runtime.InteropServices;
using Magma;
using UnityEngine;

// Token: 0x02000236 RID: 566
public class LibRust : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06000F24 RID: 3876 RVA: 0x0003A514 File Offset: 0x00038714
	public LibRust()
	{
	}

	// Token: 0x06000F25 RID: 3877 RVA: 0x0003A51C File Offset: 0x0003871C
	public void Awake()
	{
		if (!global::UnityEngine.Application.isPlaying)
		{
			return;
		}
		global::UnityEngine.Object.DontDestroyOnLoad(this);
		global::ConsoleSystem.RegisterLogCallback(new global::UnityEngine.Application.LogCallback(global::LibRust.CaptureLog), true);
		string[] commandLineArgs = global::System.Environment.GetCommandLineArgs();
		global::LibRust.Initialize(commandLineArgs, commandLineArgs.Length);
	}

	// Token: 0x06000F26 RID: 3878 RVA: 0x0003A55C File Offset: 0x0003875C
	public void OnDestroy()
	{
		if (!global::UnityEngine.Application.isPlaying)
		{
			return;
		}
		global::UnityEngine.Debug.Log("OnDestroy");
		global::Magma.Hooks.ServerShutdown();
		global::LibRust.Shutdown();
	}

	// Token: 0x06000F27 RID: 3879 RVA: 0x0003A580 File Offset: 0x00038780
	public void Update()
	{
		if (!global::UnityEngine.Application.isPlaying)
		{
			return;
		}
		global::LibRust.Cycle();
		global::System.IntPtr intPtr = global::LibRust.Console_Input();
		if (intPtr != global::System.IntPtr.Zero)
		{
			string strCommand = global::System.Runtime.InteropServices.Marshal.PtrToStringAnsi(intPtr);
			global::ConsoleSystem.Run(strCommand, true);
		}
		if (global::LibRust.Console_Closing())
		{
			global::ConsoleSystem.Run("quit", false);
			global::UnityEngine.Object.Destroy(this);
		}
	}

	// Token: 0x06000F28 RID: 3880 RVA: 0x0003A5E0 File Offset: 0x000387E0
	private static void CaptureLog(string log, string stacktrace, global::UnityEngine.LogType type)
	{
		if (!global::UnityEngine.Application.isPlaying)
		{
			return;
		}
		if (type != 3 && log.StartsWith("HDR RenderTexture format is not supported on this platform."))
		{
			return;
		}
		global::LibRust.ConsoleLog(log, stacktrace, type);
	}

	// Token: 0x06000F29 RID: 3881
	[global::System.Runtime.InteropServices.DllImport("librust")]
	public static extern int Initialize(string[] args, int numargs);

	// Token: 0x06000F2A RID: 3882
	[global::System.Runtime.InteropServices.DllImport("librust")]
	public static extern void Shutdown();

	// Token: 0x06000F2B RID: 3883
	[global::System.Runtime.InteropServices.DllImport("librust")]
	public static extern void Cycle();

	// Token: 0x06000F2C RID: 3884
	[global::System.Runtime.InteropServices.DllImport("librust")]
	public static extern bool Console_Closing();

	// Token: 0x06000F2D RID: 3885
	[global::System.Runtime.InteropServices.DllImport("librust")]
	public static extern global::System.IntPtr Console_Input();

	// Token: 0x06000F2E RID: 3886
	[global::System.Runtime.InteropServices.DllImport("librust")]
	public static extern void ConsoleLog(string log, string trace, int type);
}
