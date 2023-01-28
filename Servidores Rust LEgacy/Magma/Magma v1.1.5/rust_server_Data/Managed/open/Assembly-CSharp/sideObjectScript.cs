using System;
using UnityEngine;

// Token: 0x020008A0 RID: 2208
public class sideObjectScript : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06004C60 RID: 19552 RVA: 0x00120C68 File Offset: 0x0011EE68
	public sideObjectScript()
	{
	}

	// Token: 0x0400292E RID: 10542
	public global::RoadObjectScript OODCCOODCC;

	// Token: 0x0400292F RID: 10543
	public int soIndex;

	// Token: 0x04002930 RID: 10544
	public string soName;

	// Token: 0x04002931 RID: 10545
	public int soAlign;

	// Token: 0x04002932 RID: 10546
	public float soUVx = 0.1f;

	// Token: 0x04002933 RID: 10547
	public float soUVy = 1f;

	// Token: 0x04002934 RID: 10548
	public float m_distance = 10f;

	// Token: 0x04002935 RID: 10549
	public int objectType;

	// Token: 0x04002936 RID: 10550
	public int position;

	// Token: 0x04002937 RID: 10551
	public global::UnityEngine.Material mat;

	// Token: 0x04002938 RID: 10552
	public bool weld = true;

	// Token: 0x04002939 RID: 10553
	public bool combine = true;

	// Token: 0x0400293A RID: 10554
	public bool OQCCQQDDOC = true;

	// Token: 0x0400293B RID: 10555
	public string m_go = string.Empty;

	// Token: 0x0400293C RID: 10556
	public string ODDDOCCOQO = string.Empty;

	// Token: 0x0400293D RID: 10557
	public string ODOQDQQCCQ = string.Empty;

	// Token: 0x0400293E RID: 10558
	public global::UnityEngine.GameObject goStart;

	// Token: 0x0400293F RID: 10559
	public global::UnityEngine.GameObject goEnd;

	// Token: 0x04002940 RID: 10560
	public global::UnityEngine.GameObject goInstantiated;

	// Token: 0x04002941 RID: 10561
	public int selectedRotation;

	// Token: 0x04002942 RID: 10562
	public static string[] rotationOptions;

	// Token: 0x04002943 RID: 10563
	public static string[] uvStrings;

	// Token: 0x04002944 RID: 10564
	public int uvInt;

	// Token: 0x04002945 RID: 10565
	public bool randomObjects;

	// Token: 0x04002946 RID: 10566
	public int childOrder;

	// Token: 0x04002947 RID: 10567
	public string[] childOrderStrings;

	// Token: 0x04002948 RID: 10568
	public float density = 1f;

	// Token: 0x04002949 RID: 10569
	public float sidewaysOffset;

	// Token: 0x0400294A RID: 10570
	public int terrainTree;

	// Token: 0x0400294B RID: 10571
	public string[] rotationStrings;

	// Token: 0x0400294C RID: 10572
	public int selectedYRotation;

	// Token: 0x0400294D RID: 10573
	public int childCount;

	// Token: 0x0400294E RID: 10574
	public float xPosition;

	// Token: 0x0400294F RID: 10575
	public float yPosition;

	// Token: 0x04002950 RID: 10576
	public float uvYRound;

	// Token: 0x04002951 RID: 10577
	public bool m_collider;
}
