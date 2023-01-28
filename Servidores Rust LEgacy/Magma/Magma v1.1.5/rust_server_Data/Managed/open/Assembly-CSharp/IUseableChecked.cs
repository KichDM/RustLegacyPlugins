using System;
using Facepunch;

// Token: 0x02000233 RID: 563
public interface IUseableChecked : global::IUseable, global::IComponentInterface<global::IUseable, global::Facepunch.MonoBehaviour, global::Useable>, global::IComponentInterface<global::IUseable, global::Facepunch.MonoBehaviour>, global::IComponentInterface<global::IUseable>
{
	// Token: 0x06000F14 RID: 3860
	global::UseCheck CanUse(global::Character user, global::UseEnterRequest request);
}
