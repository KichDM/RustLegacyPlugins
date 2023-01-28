using System;
using Facepunch;

// Token: 0x02000564 RID: 1380
public interface IActivatableToggle : global::IActivatable, global::IComponentInterface<global::IActivatable, global::Facepunch.MonoBehaviour, global::Activatable>, global::IComponentInterface<global::IActivatable, global::Facepunch.MonoBehaviour>, global::IComponentInterface<global::IActivatable>
{
	// Token: 0x06002EE6 RID: 12006
	global::ActivationResult ActTrigger(global::Character instigator, global::ActivationToggleState toggleTarget, ulong timestamp);

	// Token: 0x06002EE7 RID: 12007
	global::ActivationToggleState ActGetToggleState();
}
