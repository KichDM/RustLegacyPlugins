using System;
using Facepunch;

// Token: 0x0200058F RID: 1423
public interface IContextRequestableVisibility : global::IContextRequestable, global::IComponentInterface<global::IContextRequestable, global::Facepunch.MonoBehaviour, global::Contextual>, global::IComponentInterface<global::IContextRequestable, global::Facepunch.MonoBehaviour>, global::IComponentInterface<global::IContextRequestable>
{
	// Token: 0x06002F75 RID: 12149
	void OnContextVisibilityChanged(global::ContextSprite sprite, bool nowVisible);
}
