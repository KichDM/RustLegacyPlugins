using System;
using Facepunch;

// Token: 0x0200058B RID: 1419
public interface IContextRequestable : global::IComponentInterface<global::IContextRequestable, global::Facepunch.MonoBehaviour, global::Contextual>, global::IComponentInterface<global::IContextRequestable, global::Facepunch.MonoBehaviour>, global::IComponentInterface<global::IContextRequestable>
{
	// Token: 0x06002F70 RID: 12144
	global::ContextExecution ContextQuery(global::Controllable controllable, ulong timestamp);
}
