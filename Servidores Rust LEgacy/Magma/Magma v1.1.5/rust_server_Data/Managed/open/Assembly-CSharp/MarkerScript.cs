using System;
using System.Collections;
using EasyRoads3D;
using UnityEngine;

// Token: 0x0200089D RID: 2205
[global::UnityEngine.ExecuteInEditMode]
public class MarkerScript : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06004C35 RID: 19509 RVA: 0x0011E354 File Offset: 0x0011C554
	public MarkerScript()
	{
	}

	// Token: 0x06004C36 RID: 19510 RVA: 0x0011E408 File Offset: 0x0011C608
	private void Start()
	{
		foreach (object obj in base.transform)
		{
			global::UnityEngine.Transform transform = (global::UnityEngine.Transform)obj;
			this.surface = transform;
		}
	}

	// Token: 0x06004C37 RID: 19511 RVA: 0x0011E478 File Offset: 0x0011C678
	private void OnDrawGizmos()
	{
		if (this.objectScript != null)
		{
			if (!this.objectScript.ODODCOCCDQ)
			{
				global::UnityEngine.Vector3 vector = base.transform.position - this.oldPos;
				if (this.OCCCCODCOD && this.oldPos != global::UnityEngine.Vector3.zero && vector != global::UnityEngine.Vector3.zero)
				{
					int num = 0;
					foreach (global::UnityEngine.Transform transform in this.OCQOCOCQQOs)
					{
						transform.position += vector * this.trperc[num];
						num++;
					}
				}
				if (this.oldPos != global::UnityEngine.Vector3.zero && vector != global::UnityEngine.Vector3.zero)
				{
					this.changed = true;
					if (this.objectScript.ODODCOCCDQ)
					{
						this.objectScript.OOQQCODOCD.specialRoadMaterial = true;
					}
				}
				this.oldPos = base.transform.position;
			}
			else if (this.objectScript.ODODDDOO)
			{
				base.transform.position = this.oldPos;
			}
		}
	}

	// Token: 0x06004C38 RID: 19512 RVA: 0x0011E5BC File Offset: 0x0011C7BC
	private void SetObjectScript()
	{
		this.objectScript = base.transform.parent.parent.GetComponent<global::RoadObjectScript>();
		if (this.objectScript.OOQQCODOCD == null)
		{
			global::System.Collections.ArrayList arrayList = global::EasyRoads3D.ODODDCCOQO.OCDCQOOODO(false);
			this.objectScript.OCOQDDODDQ(arrayList, global::EasyRoads3D.ODODDCCOQO.OOQOOQODQQ(arrayList), global::EasyRoads3D.ODODDCCOQO.OQQDOODOOQ(arrayList));
		}
	}

	// Token: 0x06004C39 RID: 19513 RVA: 0x0011E614 File Offset: 0x0011C814
	public void LeftIndent(float change, float perc)
	{
		this.ri += change * perc;
		if (this.ri < this.objectScript.indent)
		{
			this.ri = this.objectScript.indent;
		}
		this.OOQOQQOO = this.ri;
	}

	// Token: 0x06004C3A RID: 19514 RVA: 0x0011E664 File Offset: 0x0011C864
	public void RightIndent(float change, float perc)
	{
		this.li += change * perc;
		if (this.li < this.objectScript.indent)
		{
			this.li = this.objectScript.indent;
		}
		this.ODODQQOO = this.li;
	}

	// Token: 0x06004C3B RID: 19515 RVA: 0x0011E6B4 File Offset: 0x0011C8B4
	public void LeftSurrounding(float change, float perc)
	{
		this.rs += change * perc;
		if (this.rs < this.objectScript.indent)
		{
			this.rs = this.objectScript.indent;
		}
		this.ODOQQOOO = this.rs;
	}

	// Token: 0x06004C3C RID: 19516 RVA: 0x0011E704 File Offset: 0x0011C904
	public void RightSurrounding(float change, float perc)
	{
		this.ls += change * perc;
		if (this.ls < this.objectScript.indent)
		{
			this.ls = this.objectScript.indent;
		}
		this.DODOQQOO = this.ls;
	}

	// Token: 0x06004C3D RID: 19517 RVA: 0x0011E754 File Offset: 0x0011C954
	public void LeftTilting(float change, float perc)
	{
		this.rt += change * perc;
		if (this.rt < 0f)
		{
			this.rt = 0f;
		}
		this.ODDQODOO = this.rt;
	}

	// Token: 0x06004C3E RID: 19518 RVA: 0x0011E790 File Offset: 0x0011C990
	public void RightTilting(float change, float perc)
	{
		this.lt += change * perc;
		if (this.lt < 0f)
		{
			this.lt = 0f;
		}
		this.ODDOQOQQ = this.lt;
	}

	// Token: 0x06004C3F RID: 19519 RVA: 0x0011E7CC File Offset: 0x0011C9CC
	public void FloorDepth(float change, float perc)
	{
		this.floorDepth += change * perc;
		if (this.floorDepth > 0f)
		{
			this.floorDepth = 0f;
		}
		this.oldFloorDepth = this.floorDepth;
	}

	// Token: 0x06004C40 RID: 19520 RVA: 0x0011E808 File Offset: 0x0011CA08
	public bool InSelected()
	{
		for (int i = 0; i < this.objectScript.OCQOCOCQQOs.Length; i++)
		{
			if (this.objectScript.OCQOCOCQQOs[i] == base.gameObject)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x0400287D RID: 10365
	public float tension = 0.5f;

	// Token: 0x0400287E RID: 10366
	public float ri;

	// Token: 0x0400287F RID: 10367
	public float OOQOQQOO;

	// Token: 0x04002880 RID: 10368
	public float li;

	// Token: 0x04002881 RID: 10369
	public float ODODQQOO;

	// Token: 0x04002882 RID: 10370
	public float rs;

	// Token: 0x04002883 RID: 10371
	public float ODOQQOOO;

	// Token: 0x04002884 RID: 10372
	public float ls;

	// Token: 0x04002885 RID: 10373
	public float DODOQQOO;

	// Token: 0x04002886 RID: 10374
	public float rt;

	// Token: 0x04002887 RID: 10375
	public float ODDQODOO;

	// Token: 0x04002888 RID: 10376
	public float lt;

	// Token: 0x04002889 RID: 10377
	public float ODDOQOQQ;

	// Token: 0x0400288A RID: 10378
	public bool OCCCCODCOD;

	// Token: 0x0400288B RID: 10379
	public bool ODQDOQOO;

	// Token: 0x0400288C RID: 10380
	public float OQCQOQQDCQ;

	// Token: 0x0400288D RID: 10381
	public float ODOOQQOO;

	// Token: 0x0400288E RID: 10382
	public global::UnityEngine.Transform[] OCQOCOCQQOs;

	// Token: 0x0400288F RID: 10383
	public float[] trperc;

	// Token: 0x04002890 RID: 10384
	public global::UnityEngine.Vector3 oldPos = global::UnityEngine.Vector3.zero;

	// Token: 0x04002891 RID: 10385
	public bool autoUpdate;

	// Token: 0x04002892 RID: 10386
	public bool changed;

	// Token: 0x04002893 RID: 10387
	public global::UnityEngine.Transform surface;

	// Token: 0x04002894 RID: 10388
	public bool OOCCDCOQCQ;

	// Token: 0x04002895 RID: 10389
	private global::UnityEngine.Vector3 position;

	// Token: 0x04002896 RID: 10390
	private bool updated;

	// Token: 0x04002897 RID: 10391
	private int frameCount;

	// Token: 0x04002898 RID: 10392
	private float currentstamp;

	// Token: 0x04002899 RID: 10393
	private float newstamp;

	// Token: 0x0400289A RID: 10394
	private bool mousedown;

	// Token: 0x0400289B RID: 10395
	private global::UnityEngine.Vector3 lookAtPoint;

	// Token: 0x0400289C RID: 10396
	public bool bridgeObject;

	// Token: 0x0400289D RID: 10397
	public bool distHeights;

	// Token: 0x0400289E RID: 10398
	public global::RoadObjectScript objectScript;

	// Token: 0x0400289F RID: 10399
	public global::System.Collections.ArrayList OQODQQDO = new global::System.Collections.ArrayList();

	// Token: 0x040028A0 RID: 10400
	public global::System.Collections.ArrayList ODOQQQDO = new global::System.Collections.ArrayList();

	// Token: 0x040028A1 RID: 10401
	public global::System.Collections.ArrayList OQQODQQOO = new global::System.Collections.ArrayList();

	// Token: 0x040028A2 RID: 10402
	public global::System.Collections.ArrayList ODDOQQOO = new global::System.Collections.ArrayList();

	// Token: 0x040028A3 RID: 10403
	public global::System.Collections.ArrayList ODDDDQOO = new global::System.Collections.ArrayList();

	// Token: 0x040028A4 RID: 10404
	public global::System.Collections.ArrayList DQQOQQOO = new global::System.Collections.ArrayList();

	// Token: 0x040028A5 RID: 10405
	public string[] ODDOOQDO;

	// Token: 0x040028A6 RID: 10406
	public bool[] ODDGDOOO;

	// Token: 0x040028A7 RID: 10407
	public bool[] ODDQOOO;

	// Token: 0x040028A8 RID: 10408
	public float[] ODDQOODO;

	// Token: 0x040028A9 RID: 10409
	public float[] ODOQODOO;

	// Token: 0x040028AA RID: 10410
	public float[] ODDOQDO;

	// Token: 0x040028AB RID: 10411
	public int markerNum;

	// Token: 0x040028AC RID: 10412
	public string distance = "0";

	// Token: 0x040028AD RID: 10413
	public string OQOQODQCQC = "0";

	// Token: 0x040028AE RID: 10414
	public string OODDQCQQDD = "0";

	// Token: 0x040028AF RID: 10415
	public bool newSegment;

	// Token: 0x040028B0 RID: 10416
	public float floorDepth = 2f;

	// Token: 0x040028B1 RID: 10417
	public float oldFloorDepth = 2f;

	// Token: 0x040028B2 RID: 10418
	public float waterLevel = 0.5f;

	// Token: 0x040028B3 RID: 10419
	public bool lockWaterLevel = true;

	// Token: 0x040028B4 RID: 10420
	public bool sharpCorner;
}
