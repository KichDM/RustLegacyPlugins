using System;

// Token: 0x02000422 RID: 1058
public interface IPrefabCustomInstantiate
{
	// Token: 0x060024D0 RID: 9424
	global::IDMain CustomInstantiatePrefab(ref global::CustomInstantiationArgs args);

	// Token: 0x060024D1 RID: 9425
	bool InitializePrefabInstance(global::NetInstance net);
}
