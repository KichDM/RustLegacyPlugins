using System;
using Facepunch;

// Token: 0x0200058D RID: 1421
public interface IContextRequestableQuick : global::IContextRequestable, global::IComponentInterface<global::IContextRequestable, global::Facepunch.MonoBehaviour, global::Contextual>, global::IComponentInterface<global::IContextRequestable, global::Facepunch.MonoBehaviour>, global::IComponentInterface<global::IContextRequestable>
{
	// Token: 0x06002F73 RID: 12147
	global::ContextResponse ContextRespondQuick(global::Controllable controllable, ulong timestamp);
}
