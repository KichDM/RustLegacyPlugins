using System;
using UnityEngine;

// Token: 0x020001F5 RID: 501
public interface IComponentInterface<InterfaceType, MonoBehaviourType, InterfaceDriverType> : global::IComponentInterface<InterfaceType, MonoBehaviourType>, global::IComponentInterface<InterfaceType> where InterfaceType : global::IComponentInterface<InterfaceType, MonoBehaviourType, InterfaceDriverType> where MonoBehaviourType : global::UnityEngine.MonoBehaviour where InterfaceDriverType : global::UnityEngine.MonoBehaviour, global::IComponentInterfaceDriver<InterfaceType, MonoBehaviourType, InterfaceDriverType>
{
}
