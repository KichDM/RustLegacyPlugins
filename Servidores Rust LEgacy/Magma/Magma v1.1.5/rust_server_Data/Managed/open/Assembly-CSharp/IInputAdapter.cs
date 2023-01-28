using System;
using UnityEngine;

// Token: 0x02000819 RID: 2073
public interface IInputAdapter
{
	// Token: 0x060045AB RID: 17835
	bool GetKeyDown(global::UnityEngine.KeyCode key);

	// Token: 0x060045AC RID: 17836
	bool GetKeyUp(global::UnityEngine.KeyCode key);

	// Token: 0x060045AD RID: 17837
	float GetAxis(string axisName);

	// Token: 0x060045AE RID: 17838
	global::UnityEngine.Vector2 GetMousePosition();

	// Token: 0x060045AF RID: 17839
	bool GetMouseButton(int button);

	// Token: 0x060045B0 RID: 17840
	bool GetMouseButtonDown(int button);

	// Token: 0x060045B1 RID: 17841
	bool GetMouseButtonUp(int button);
}
