using System;
using UnityEngine;

// Token: 0x020000D5 RID: 213
public class RunConsoleCommand : global::UnityEngine.MonoBehaviour
{
	// Token: 0x0600041D RID: 1053 RVA: 0x00013838 File Offset: 0x00011A38
	public RunConsoleCommand()
	{
	}

	// Token: 0x0600041E RID: 1054 RVA: 0x0001384C File Offset: 0x00011A4C
	public void RunCommandImmediately()
	{
		global::ConsoleSystem.Run(this.consoleCommand, false);
	}

	// Token: 0x040003E3 RID: 995
	public string consoleCommand = "echo Missing Console Command!";

	// Token: 0x040003E4 RID: 996
	public bool asIfTypedIntoConsole;
}
