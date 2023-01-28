using System;
using UnityEngine;

// Token: 0x020005EC RID: 1516
public class HelloScript : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06003108 RID: 12552 RVA: 0x000BAFA8 File Offset: 0x000B91A8
	public HelloScript()
	{
	}

	// Token: 0x06003109 RID: 12553 RVA: 0x000BAFB0 File Offset: 0x000B91B0
	private void Start()
	{
		global::UnityEngine.Debug.Log("HELLO!:" + this.helloString + "from object: " + base.gameObject.name);
	}

	// Token: 0x04001B2A RID: 6954
	public string helloString;
}
