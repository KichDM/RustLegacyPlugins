using System;
using Facepunch;

// Token: 0x02000562 RID: 1378
public interface IActivatable : global::IComponentInterface<global::IActivatable, global::Facepunch.MonoBehaviour, global::Activatable>, global::IComponentInterface<global::IActivatable, global::Facepunch.MonoBehaviour>, global::IComponentInterface<global::IActivatable>
{
	// Token: 0x06002EE5 RID: 12005
	global::ActivationResult ActTrigger(global::Character instigator, ulong timestamp);
}
