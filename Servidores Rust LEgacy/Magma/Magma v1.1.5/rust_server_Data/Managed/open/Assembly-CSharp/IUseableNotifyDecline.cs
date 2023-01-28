using System;
using Facepunch;

// Token: 0x02000234 RID: 564
public interface IUseableNotifyDecline : global::IUseable, global::IComponentInterface<global::IUseable, global::Facepunch.MonoBehaviour, global::Useable>, global::IComponentInterface<global::IUseable, global::Facepunch.MonoBehaviour>, global::IComponentInterface<global::IUseable>
{
	// Token: 0x06000F15 RID: 3861
	void OnUseDeclined(global::Character user, global::UseResponse response, global::UseEnterRequest request);
}
