using System;
using Facepunch;

// Token: 0x02000566 RID: 1382
public interface IActivatableInfo : global::IActivatable, global::IComponentInterface<global::IActivatable, global::Facepunch.MonoBehaviour, global::Activatable>, global::IComponentInterface<global::IActivatable, global::Facepunch.MonoBehaviour>, global::IComponentInterface<global::IActivatable>
{
	// Token: 0x06002EE8 RID: 12008
	void ActInfo(out global::ActivatableInfo info);
}
