using System;
using System.Collections.Generic;
using Facepunch;

// Token: 0x0200058C RID: 1420
public interface IContextRequestableMenu : global::IContextRequestable, global::IComponentInterface<global::IContextRequestable, global::Facepunch.MonoBehaviour, global::Contextual>, global::IComponentInterface<global::IContextRequestable, global::Facepunch.MonoBehaviour>, global::IComponentInterface<global::IContextRequestable>
{
	// Token: 0x06002F71 RID: 12145
	global::System.Collections.Generic.IEnumerable<global::ContextActionPrototype> ContextQueryMenu(global::Controllable controllable, ulong timestamp);

	// Token: 0x06002F72 RID: 12146
	global::ContextResponse ContextRespondMenu(global::Controllable controllable, global::ContextActionPrototype action, ulong timestamp);
}
