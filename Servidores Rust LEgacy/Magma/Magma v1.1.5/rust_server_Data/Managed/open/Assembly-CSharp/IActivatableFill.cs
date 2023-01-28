using System;
using Facepunch;

// Token: 0x02000567 RID: 1383
public interface IActivatableFill : global::IActivatable, global::IComponentInterface<global::IActivatable, global::Facepunch.MonoBehaviour, global::Activatable>, global::IComponentInterface<global::IActivatable, global::Facepunch.MonoBehaviour>, global::IComponentInterface<global::IActivatable>
{
	// Token: 0x06002EE9 RID: 12009
	void ActivatableChanged(global::Activatable activatable, bool nonNull);
}
