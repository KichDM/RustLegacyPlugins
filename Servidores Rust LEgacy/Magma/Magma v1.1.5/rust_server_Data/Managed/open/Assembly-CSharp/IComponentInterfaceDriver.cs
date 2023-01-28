using System;
using UnityEngine;

// Token: 0x020001F6 RID: 502
public interface IComponentInterfaceDriver<InterfaceType, MonoBehaviourType, InterfaceDriverType> where InterfaceType : global::IComponentInterface<InterfaceType, MonoBehaviourType, InterfaceDriverType> where MonoBehaviourType : global::UnityEngine.MonoBehaviour where InterfaceDriverType : global::UnityEngine.MonoBehaviour, global::IComponentInterfaceDriver<InterfaceType, MonoBehaviourType, InterfaceDriverType>
{
	// Token: 0x17000352 RID: 850
	// (get) Token: 0x06000DC1 RID: 3521
	MonoBehaviourType implementor { get; }

	// Token: 0x17000353 RID: 851
	// (get) Token: 0x06000DC2 RID: 3522
	InterfaceType @interface { get; }

	// Token: 0x17000354 RID: 852
	// (get) Token: 0x06000DC3 RID: 3523
	bool exists { get; }

	// Token: 0x17000355 RID: 853
	// (get) Token: 0x06000DC4 RID: 3524
	InterfaceDriverType driver { get; }
}
