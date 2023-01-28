using System;
using Facepunch;

// Token: 0x02000230 RID: 560
public interface IUseableUpdated : global::IUseable, global::IComponentInterface<global::IUseable, global::Facepunch.MonoBehaviour, global::Useable>, global::IComponentInterface<global::IUseable, global::Facepunch.MonoBehaviour>, global::IComponentInterface<global::IUseable>
{
	// Token: 0x17000388 RID: 904
	// (get) Token: 0x06000F11 RID: 3857
	global::UseUpdateFlags UseUpdateFlags { get; }

	// Token: 0x06000F12 RID: 3858
	void OnUseUpdate(global::Useable use);
}
