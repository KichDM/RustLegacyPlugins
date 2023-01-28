using System;
using UnityEngine;

// Token: 0x02000806 RID: 2054
[global::System.Serializable]
[global::UnityEngine.AddComponentMenu("Daikon Forge/User Interface/GUI Camera")]
[global::UnityEngine.ExecuteInEditMode]
[global::UnityEngine.RequireComponent(typeof(global::UnityEngine.Camera))]
public class dfGUICamera : global::UnityEngine.MonoBehaviour
{
	// Token: 0x060044E2 RID: 17634 RVA: 0x000FB6D8 File Offset: 0x000F98D8
	public dfGUICamera()
	{
	}

	// Token: 0x060044E3 RID: 17635 RVA: 0x000FB6E0 File Offset: 0x000F98E0
	public void Awake()
	{
	}

	// Token: 0x060044E4 RID: 17636 RVA: 0x000FB6E4 File Offset: 0x000F98E4
	public void OnEnable()
	{
	}

	// Token: 0x060044E5 RID: 17637 RVA: 0x000FB6E8 File Offset: 0x000F98E8
	public void Start()
	{
		base.camera.transparencySortMode = 2;
		base.camera.useOcclusionCulling = false;
		base.camera.eventMask &= ~base.camera.cullingMask;
	}
}
