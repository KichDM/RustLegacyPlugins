using System;
using Facepunch;

// Token: 0x0200022E RID: 558
public interface IUseable : global::IComponentInterface<global::IUseable, global::Facepunch.MonoBehaviour, global::Useable>, global::IComponentInterface<global::IUseable, global::Facepunch.MonoBehaviour>, global::IComponentInterface<global::IUseable>
{
	// Token: 0x06000F0F RID: 3855
	void OnUseEnter(global::Useable use);

	// Token: 0x06000F10 RID: 3856
	void OnUseExit(global::Useable use, global::UseExitReason reason);
}
