using System;

// Token: 0x020001EA RID: 490
[global::System.AttributeUsage(global::System.AttributeTargets.Delegate)]
public class EventListerInvokeAttribute : global::System.Attribute
{
	// Token: 0x06000DA3 RID: 3491 RVA: 0x00035298 File Offset: 0x00033498
	public EventListerInvokeAttribute(global::System.Type invokeClass, string invokeMember, global::System.Type invokeCall)
	{
		this.InvokeClass = invokeClass;
		this.InvokeMember = invokeMember;
		this.InvokeCall = invokeCall;
	}

	// Token: 0x040008A1 RID: 2209
	internal readonly global::System.Type InvokeClass;

	// Token: 0x040008A2 RID: 2210
	internal readonly string InvokeMember;

	// Token: 0x040008A3 RID: 2211
	internal readonly global::System.Type InvokeCall;
}
