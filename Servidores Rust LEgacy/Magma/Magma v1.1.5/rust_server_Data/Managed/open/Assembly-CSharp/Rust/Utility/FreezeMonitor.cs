using System;
using System.Runtime.InteropServices;

namespace Rust.Utility
{
	// Token: 0x0200009D RID: 157
	public static class FreezeMonitor
	{
		// Token: 0x0600030A RID: 778 RVA: 0x0000EDE4 File Offset: 0x0000CFE4
		public static void On()
		{
			global::Rust.Utility.FreezeMonitor.FreezeMonitor_On();
		}

		// Token: 0x0600030B RID: 779 RVA: 0x0000EDEC File Offset: 0x0000CFEC
		public static void Off()
		{
			global::Rust.Utility.FreezeMonitor.FreezeMonitor_Off();
		}

		// Token: 0x0600030C RID: 780
		[global::System.Runtime.InteropServices.DllImport("librust")]
		private static extern void FreezeMonitor_Off();

		// Token: 0x0600030D RID: 781
		[global::System.Runtime.InteropServices.DllImport("librust")]
		private static extern void FreezeMonitor_On();
	}
}
