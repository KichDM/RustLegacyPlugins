using System;
using UnityEngine;

// Token: 0x020001F4 RID: 500
public interface IComponentInterface<InterfaceType, MonoBehaviourType> : global::IComponentInterface<InterfaceType> where InterfaceType : global::IComponentInterface<InterfaceType, MonoBehaviourType> where MonoBehaviourType : global::UnityEngine.MonoBehaviour
{
}
