using System;
using Facepunch;

// Token: 0x0200058E RID: 1422
public interface IContextRequestableMenuQuickRouter : global::IContextRequestable, global::IContextRequestableMenu, global::IContextRequestableQuick, global::IComponentInterface<global::IContextRequestable, global::Facepunch.MonoBehaviour, global::Contextual>, global::IComponentInterface<global::IContextRequestable, global::Facepunch.MonoBehaviour>, global::IComponentInterface<global::IContextRequestable>
{
	// Token: 0x06002F74 RID: 12148
	bool ContextQuickWhenNoMenuActions(global::Controllable controllable, ulong timestamp, bool fromError);
}
