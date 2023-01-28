using System;
using System.Runtime.InteropServices;

// Token: 0x020004FD RID: 1277
public static class RCon
{
	// Token: 0x06002BFA RID: 11258 RVA: 0x000A5AD8 File Offset: 0x000A3CD8
	public static void Setup()
	{
		global::RCon.funcAuth = new global::RCon.rconFuncAuth(global::RCon.DoAuth);
		global::RCon.funcAuthGC = global::System.Runtime.InteropServices.GCHandle.Alloc(global::RCon.funcAuth);
		global::RCon.funcCommand = new global::RCon.rconFuncCommand(global::RCon.RunCommand);
		global::RCon.funcCommandGC = global::System.Runtime.InteropServices.GCHandle.Alloc(global::RCon.funcCommand);
		global::RCon.RCON_SetupCallbacks(global::RCon.funcAuth, global::RCon.funcCommand);
	}

	// Token: 0x06002BFB RID: 11259 RVA: 0x000A5B34 File Offset: 0x000A3D34
	public static bool DoAuth(string strPassword)
	{
		return !(global::rcon.password == string.Empty) && global::rcon.password == strPassword;
	}

	// Token: 0x06002BFC RID: 11260 RVA: 0x000A5B60 File Offset: 0x000A3D60
	public static void RunCommand(int iID, string strCommand)
	{
		global::ConsoleSystem.Run(strCommand, true);
	}

	// Token: 0x06002BFD RID: 11261
	[global::System.Runtime.InteropServices.DllImport("librust")]
	public static extern void RCON_SetupCallbacks(global::RCon.rconFuncAuth auth, global::RCon.rconFuncCommand command);

	// Token: 0x04001656 RID: 5718
	private static global::RCon.rconFuncAuth funcAuth;

	// Token: 0x04001657 RID: 5719
	private static global::System.Runtime.InteropServices.GCHandle funcAuthGC;

	// Token: 0x04001658 RID: 5720
	private static global::RCon.rconFuncCommand funcCommand;

	// Token: 0x04001659 RID: 5721
	private static global::System.Runtime.InteropServices.GCHandle funcCommandGC;

	// Token: 0x020004FE RID: 1278
	// (Invoke) Token: 0x06002BFF RID: 11263
	public delegate bool rconFuncAuth(string strPassword);

	// Token: 0x020004FF RID: 1279
	// (Invoke) Token: 0x06002C03 RID: 11267
	public delegate void rconFuncCommand(int iID, string strCommand);
}
