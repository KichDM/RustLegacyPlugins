using System;
using System.Collections;
using System.Collections.Generic;
using EasyRoads3D;
using UnityEngine;

// Token: 0x0200089E RID: 2206
public class RoadObjectScript : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06004C41 RID: 19521 RVA: 0x0011E854 File Offset: 0x0011CA54
	public RoadObjectScript()
	{
	}

	// Token: 0x06004C42 RID: 19522 RVA: 0x0011E9E0 File Offset: 0x0011CBE0
	// Note: this type is marked as 'beforefieldinit'.
	static RoadObjectScript()
	{
	}

	// Token: 0x06004C43 RID: 19523 RVA: 0x0011E9FC File Offset: 0x0011CBFC
	public void OCOQDDODDQ(global::System.Collections.ArrayList arr, string[] DOODQOQO, string[] OODDQOQO)
	{
		this.ODOCOQCCOC(base.transform, arr, DOODQOQO, OODDQOQO);
	}

	// Token: 0x06004C44 RID: 19524 RVA: 0x0011EA10 File Offset: 0x0011CC10
	public void OCCOCQQQDO(global::MarkerScript markerScript)
	{
		this.OCQOCOCQQO = markerScript.transform;
		global::System.Collections.Generic.List<global::UnityEngine.GameObject> list = new global::System.Collections.Generic.List<global::UnityEngine.GameObject>();
		for (int i = 0; i < this.OCQOCOCQQOs.Length; i++)
		{
			if (this.OCQOCOCQQOs[i] != markerScript.gameObject)
			{
				list.Add(this.OCQOCOCQQOs[i]);
			}
		}
		list.Add(markerScript.gameObject);
		this.OCQOCOCQQOs = list.ToArray();
		this.OCQOCOCQQO = markerScript.transform;
		this.OOQQCODOCD.OODCDQDOCO(this.OCQOCOCQQO, this.OCQOCOCQQOs, markerScript.OCCCCODCOD, markerScript.OQCQOQQDCQ, this.OODDDCQCOC, ref markerScript.OCQOCOCQQOs, ref markerScript.trperc, this.OCQOCOCQQOs);
		this.ODOCDOOOQQ = -1;
	}

	// Token: 0x06004C45 RID: 19525 RVA: 0x0011EAD4 File Offset: 0x0011CCD4
	public void OCOQDCQOCD(global::MarkerScript markerScript)
	{
		if (markerScript.OQCQOQQDCQ != markerScript.ODOOQQOO || markerScript.OQCQOQQDCQ != markerScript.ODOOQQOO)
		{
			this.OOQQCODOCD.OODCDQDOCO(this.OCQOCOCQQO, this.OCQOCOCQQOs, markerScript.OCCCCODCOD, markerScript.OQCQOQQDCQ, this.OODDDCQCOC, ref markerScript.OCQOCOCQQOs, ref markerScript.trperc, this.OCQOCOCQQOs);
			markerScript.ODQDOQOO = markerScript.OCCCCODCOD;
			markerScript.ODOOQQOO = markerScript.OQCQOQQDCQ;
		}
		if (this.OODCCOODCC.autoUpdate)
		{
			this.OCOOCODDOC(this.OODCCOODCC.geoResolution, false, false);
		}
	}

	// Token: 0x06004C46 RID: 19526 RVA: 0x0011EB7C File Offset: 0x0011CD7C
	public void ResetMaterials(global::MarkerScript markerScript)
	{
		if (this.OOQQCODOCD != null)
		{
			this.OOQQCODOCD.OODCDQDOCO(this.OCQOCOCQQO, this.OCQOCOCQQOs, markerScript.OCCCCODCOD, markerScript.OQCQOQQDCQ, this.OODDDCQCOC, ref markerScript.OCQOCOCQQOs, ref markerScript.trperc, this.OCQOCOCQQOs);
		}
	}

	// Token: 0x06004C47 RID: 19527 RVA: 0x0011EBD0 File Offset: 0x0011CDD0
	public void OOOOQCDODD(global::MarkerScript markerScript)
	{
		if (markerScript.OQCQOQQDCQ != markerScript.ODOOQQOO)
		{
			this.OOQQCODOCD.OODCDQDOCO(this.OCQOCOCQQO, this.OCQOCOCQQOs, markerScript.OCCCCODCOD, markerScript.OQCQOQQDCQ, this.OODDDCQCOC, ref markerScript.OCQOCOCQQOs, ref markerScript.trperc, this.OCQOCOCQQOs);
			markerScript.ODOOQQOO = markerScript.OQCQOQQDCQ;
		}
		this.OCOOCODDOC(this.OODCCOODCC.geoResolution, false, false);
	}

	// Token: 0x06004C48 RID: 19528 RVA: 0x0011EC48 File Offset: 0x0011CE48
	private void OQDODCODOQ(string ctrl, global::MarkerScript markerScript)
	{
		int num = 0;
		foreach (global::UnityEngine.Transform transform in markerScript.OCQOCOCQQOs)
		{
			global::MarkerScript component = transform.GetComponent<global::MarkerScript>();
			if (ctrl == "rs")
			{
				component.LeftSurrounding(markerScript.rs - markerScript.ODOQQOOO, markerScript.trperc[num]);
			}
			else if (ctrl == "ls")
			{
				component.RightSurrounding(markerScript.ls - markerScript.DODOQQOO, markerScript.trperc[num]);
			}
			else if (ctrl == "ri")
			{
				component.LeftIndent(markerScript.ri - markerScript.OOQOQQOO, markerScript.trperc[num]);
			}
			else if (ctrl == "li")
			{
				component.RightIndent(markerScript.li - markerScript.ODODQQOO, markerScript.trperc[num]);
			}
			else if (ctrl == "rt")
			{
				component.LeftTilting(markerScript.rt - markerScript.ODDQODOO, markerScript.trperc[num]);
			}
			else if (ctrl == "lt")
			{
				component.RightTilting(markerScript.lt - markerScript.ODDOQOQQ, markerScript.trperc[num]);
			}
			else if (ctrl == "floorDepth")
			{
				component.FloorDepth(markerScript.floorDepth - markerScript.oldFloorDepth, markerScript.trperc[num]);
			}
			num++;
		}
	}

	// Token: 0x06004C49 RID: 19529 RVA: 0x0011EDD4 File Offset: 0x0011CFD4
	public void OQOCODCDOO()
	{
		if (this.markers > 1)
		{
			this.OCOOCODDOC(this.OODCCOODCC.geoResolution, false, false);
		}
	}

	// Token: 0x06004C4A RID: 19530 RVA: 0x0011EDF8 File Offset: 0x0011CFF8
	public void ODOCOQCCOC(global::UnityEngine.Transform tr, global::System.Collections.ArrayList arr, string[] DOODQOQO, string[] OODDQOQO)
	{
		global::RoadObjectScript.version = "2.4.6";
		global::RoadObjectScript.OODCDOQDCC = (global::UnityEngine.GUISkin)global::UnityEngine.Resources.Load("ER3DSkin", typeof(global::UnityEngine.GUISkin));
		global::RoadObjectScript.OQOOODODQD = (global::UnityEngine.Texture2D)global::UnityEngine.Resources.Load("ER3DLogo", typeof(global::UnityEngine.Texture2D));
		if (global::RoadObjectScript.objectStrings == null)
		{
			global::RoadObjectScript.objectStrings = new string[3];
			global::RoadObjectScript.objectStrings[0] = "Road Object";
			global::RoadObjectScript.objectStrings[1] = "River Object";
			global::RoadObjectScript.objectStrings[2] = "Procedural Mesh Object";
		}
		this.obj = tr;
		this.OOQQCODOCD = new global::EasyRoads3D.OQCDQQDQCC();
		this.OODCCOODCC = this.obj.GetComponent<global::RoadObjectScript>();
		foreach (object obj in this.obj)
		{
			global::UnityEngine.Transform transform = (global::UnityEngine.Transform)obj;
			if (transform.name == "Markers")
			{
				this.OODDDCQCOC = transform;
			}
		}
		global::EasyRoads3D.OQCDQQDQCC.terrainList.Clear();
		global::UnityEngine.Terrain[] array = (global::UnityEngine.Terrain[])global::UnityEngine.Object.FindObjectsOfType(typeof(global::UnityEngine.Terrain));
		foreach (global::UnityEngine.Terrain terrain in array)
		{
			global::EasyRoads3D.Terrains terrains = new global::EasyRoads3D.Terrains();
			terrains.terrain = terrain;
			if (!terrain.gameObject.GetComponent<global::EasyRoads3DTerrainID>())
			{
				global::EasyRoads3DTerrainID easyRoads3DTerrainID = (global::EasyRoads3DTerrainID)terrain.gameObject.AddComponent("EasyRoads3DTerrainID");
				string text = global::UnityEngine.Random.Range(0x5F5E100, 0x3B9AC9FF).ToString();
				easyRoads3DTerrainID.terrainid = text;
				terrains.id = text;
			}
			else
			{
				terrains.id = terrain.gameObject.GetComponent<global::EasyRoads3DTerrainID>().terrainid;
			}
			this.OOQQCODOCD.OCDQQCDOQO(terrains);
		}
		global::EasyRoads3D.ODCDDDDQQD.OCDQQCDOQO();
		if (this.roadMaterialEdit == null)
		{
			this.roadMaterialEdit = (global::UnityEngine.Material)global::UnityEngine.Resources.Load("materials/roadMaterialEdit", typeof(global::UnityEngine.Material));
		}
		if (this.objectType == 0 && global::UnityEngine.GameObject.Find(base.gameObject.name + "/road") == null)
		{
			global::UnityEngine.GameObject gameObject = new global::UnityEngine.GameObject("road");
			gameObject.transform.parent = base.transform;
		}
		this.OOQQCODOCD.OODQOQCDCQ(this.obj, global::RoadObjectScript.OCQCDDDOCC, this.OODCCOODCC.roadWidth, this.surfaceOpacity, ref this.OOCCDCOQCQ, ref this.indent, this.applyAnimation, this.waveSize, this.waveHeight);
		this.OOQQCODOCD.ODDQCCDCDC = this.ODDQCCDCDC;
		this.OOQQCODOCD.OOCQDOOCQD = this.OOCQDOOCQD;
		this.OOQQCODOCD.OdQODQOD = this.OdQODQOD + 1;
		this.OOQQCODOCD.OOQQQDOD = this.OOQQQDOD;
		this.OOQQCODOCD.OOQQQDODOffset = this.OOQQQDODOffset;
		this.OOQQCODOCD.OOQQQDODLength = this.OOQQQDODLength;
		this.OOQQCODOCD.objectType = this.objectType;
		this.OOQQCODOCD.snapY = this.snapY;
		this.OOQQCODOCD.terrainRendered = this.ODODCOCCDQ;
		this.OOQQCODOCD.handleVegetation = this.handleVegetation;
		this.OOQQCODOCD.raise = this.raise;
		this.OOQQCODOCD.roadResolution = this.roadResolution;
		this.OOQQCODOCD.multipleTerrains = this.multipleTerrains;
		this.OOQQCODOCD.editRestore = this.editRestore;
		this.OOQQCODOCD.roadMaterialEdit = this.roadMaterialEdit;
		if (global::RoadObjectScript.backupLocation == 0)
		{
			global::EasyRoads3D.OOCDQCOODC.backupFolder = "/EasyRoads3D";
		}
		else
		{
			global::EasyRoads3D.OOCDQCOODC.backupFolder = "/Assets/EasyRoads3D/backups";
		}
		this.ODODQOQO = this.OOQQCODOCD.OCDODCOCOC();
		this.ODODQOQOInt = this.OOQQCODOCD.OCCQOQCQDO();
		if (this.ODODCOCCDQ)
		{
			this.doRestore = true;
		}
		this.OOQODQOCOC();
		if (arr != null || global::RoadObjectScript.ODODQOOQ == null)
		{
			this.OOOOOOODCD(arr, DOODQOQO, OODDQOQO);
		}
		if (this.doRestore)
		{
			return;
		}
	}

	// Token: 0x06004C4B RID: 19531 RVA: 0x0011F240 File Offset: 0x0011D440
	public void UpdateBackupFolder()
	{
	}

	// Token: 0x06004C4C RID: 19532 RVA: 0x0011F244 File Offset: 0x0011D444
	public void OCCOOQDCQO()
	{
		if ((!this.ODODDDOO || this.objectType == 2) && this.OQCCDQCDDD != null)
		{
			for (int i = 0; i < this.OQCCDQCDDD.Length; i++)
			{
				this.OQCCDQCDDD[i] = false;
				this.ODODODCODD[i] = false;
			}
		}
	}

	// Token: 0x06004C4D RID: 19533 RVA: 0x0011F2A0 File Offset: 0x0011D4A0
	public void OODDQODDCC(global::UnityEngine.Vector3 pos)
	{
		if (!this.displayRoad)
		{
			this.displayRoad = true;
			this.OOQQCODOCD.OODDDCQCCQ(this.displayRoad, this.OODDDCQCOC);
		}
		pos.y += this.OODCCOODCC.raiseMarkers;
		if (this.forceY && this.ODOQDQOO != null)
		{
			float num = global::UnityEngine.Vector3.Distance(pos, this.ODOQDQOO.transform.position);
			pos.y = this.ODOQDQOO.transform.position.y + this.yChange * (num / 100f);
		}
		else if (this.forceY && this.markers == 0)
		{
			this.lastY = pos.y;
		}
		global::UnityEngine.GameObject gameObject;
		if (this.ODOQDQOO != null)
		{
			gameObject = (global::UnityEngine.GameObject)global::UnityEngine.Object.Instantiate(this.ODOQDQOO);
		}
		else
		{
			gameObject = (global::UnityEngine.GameObject)global::UnityEngine.Object.Instantiate(global::UnityEngine.Resources.Load("marker", typeof(global::UnityEngine.GameObject)));
		}
		global::UnityEngine.Transform transform = gameObject.transform;
		transform.position = pos;
		transform.parent = this.OODDDCQCOC;
		this.markers++;
		string name;
		if (this.markers < 0xA)
		{
			name = "Marker000" + this.markers.ToString();
		}
		else if (this.markers < 0x64)
		{
			name = "Marker00" + this.markers.ToString();
		}
		else
		{
			name = "Marker0" + this.markers.ToString();
		}
		transform.gameObject.name = name;
		global::MarkerScript component = transform.GetComponent<global::MarkerScript>();
		component.OOCCDCOQCQ = false;
		component.objectScript = this.obj.GetComponent<global::RoadObjectScript>();
		if (this.ODOQDQOO == null)
		{
			component.waterLevel = this.OODCCOODCC.waterLevel;
			component.floorDepth = this.OODCCOODCC.floorDepth;
			component.ri = this.OODCCOODCC.indent;
			component.li = this.OODCCOODCC.indent;
			component.rs = this.OODCCOODCC.surrounding;
			component.ls = this.OODCCOODCC.surrounding;
			component.tension = 0.5f;
			if (this.objectType == 1)
			{
				pos.y -= this.waterLevel;
				transform.position = pos;
			}
		}
		if (this.objectType == 2 && component.surface != null)
		{
			component.surface.gameObject.SetActive(false);
		}
		this.ODOQDQOO = transform.gameObject;
		if (this.markers > 1)
		{
			this.OCOOCODDOC(this.OODCCOODCC.geoResolution, false, false);
			if (this.materialType == 0)
			{
				this.OOQQCODOCD.OOQOOCDQOD(this.materialType);
			}
		}
	}

	// Token: 0x06004C4E RID: 19534 RVA: 0x0011F5A8 File Offset: 0x0011D7A8
	public void OCOOCODDOC(float geo, bool renderMode, bool camMode)
	{
		this.OOQQCODOCD.OOODOQDODQ.Clear();
		int num = 0;
		foreach (object obj in this.obj)
		{
			global::UnityEngine.Transform transform = (global::UnityEngine.Transform)obj;
			if (transform.name == "Markers")
			{
				foreach (object obj2 in transform)
				{
					global::UnityEngine.Transform transform2 = (global::UnityEngine.Transform)obj2;
					global::MarkerScript component = transform2.GetComponent<global::MarkerScript>();
					component.objectScript = this.obj.GetComponent<global::RoadObjectScript>();
					if (!component.OOCCDCOQCQ)
					{
						component.OOCCDCOQCQ = this.OOQQCODOCD.OOOCQDOCDC(transform2);
					}
					global::EasyRoads3D.OQDQOQDOQO oqdqoqdoqo = new global::EasyRoads3D.OQDQOQDOQO();
					oqdqoqdoqo.position = transform2.position;
					oqdqoqdoqo.num = this.OOQQCODOCD.OOODOQDODQ.Count;
					oqdqoqdoqo.object1 = transform2;
					oqdqoqdoqo.object2 = component.surface;
					oqdqoqdoqo.tension = component.tension;
					oqdqoqdoqo.ri = component.ri;
					if (oqdqoqdoqo.ri < 1f)
					{
						oqdqoqdoqo.ri = 1f;
					}
					oqdqoqdoqo.li = component.li;
					if (oqdqoqdoqo.li < 1f)
					{
						oqdqoqdoqo.li = 1f;
					}
					oqdqoqdoqo.rt = component.rt;
					oqdqoqdoqo.lt = component.lt;
					oqdqoqdoqo.rs = component.rs;
					if (oqdqoqdoqo.rs < 1f)
					{
						oqdqoqdoqo.rs = 1f;
					}
					oqdqoqdoqo.OQDOOODDQD = component.rs;
					oqdqoqdoqo.ls = component.ls;
					if (oqdqoqdoqo.ls < 1f)
					{
						oqdqoqdoqo.ls = 1f;
					}
					oqdqoqdoqo.OOOCDQODDO = component.ls;
					oqdqoqdoqo.renderFlag = component.bridgeObject;
					oqdqoqdoqo.OCCOQCQDOD = component.distHeights;
					oqdqoqdoqo.newSegment = component.newSegment;
					oqdqoqdoqo.floorDepth = component.floorDepth;
					oqdqoqdoqo.waterLevel = this.waterLevel;
					oqdqoqdoqo.lockWaterLevel = component.lockWaterLevel;
					oqdqoqdoqo.sharpCorner = component.sharpCorner;
					oqdqoqdoqo.OQCDCODODQ = this.OOQQCODOCD;
					component.markerNum = num;
					component.distance = "-1";
					component.OODDQCQQDD = "-1";
					this.OOQQCODOCD.OOODOQDODQ.Add(oqdqoqdoqo);
					num++;
				}
			}
		}
		this.distance = "-1";
		this.OOQQCODOCD.ODQQQCQCOO = this.OODCCOODCC.roadWidth;
		this.OOQQCODOCD.ODOCODQOOC(geo, this.obj, this.OODCCOODCC.OOQDOOQQ, renderMode, camMode, this.objectType);
		if (this.OOQQCODOCD.leftVecs.Count > 0)
		{
			this.leftVecs = this.OOQQCODOCD.leftVecs.ToArray();
			this.rightVecs = this.OOQQCODOCD.rightVecs.ToArray();
		}
	}

	// Token: 0x06004C4F RID: 19535 RVA: 0x0011F914 File Offset: 0x0011DB14
	public void StartCam()
	{
		this.OCOOCODDOC(0.5f, false, true);
	}

	// Token: 0x06004C50 RID: 19536 RVA: 0x0011F924 File Offset: 0x0011DB24
	public void OOQODQOCOC()
	{
		int num = 0;
		foreach (object obj in this.obj)
		{
			global::UnityEngine.Transform transform = (global::UnityEngine.Transform)obj;
			if (transform.name == "Markers")
			{
				num = 1;
				foreach (object obj2 in transform)
				{
					global::UnityEngine.Transform transform2 = (global::UnityEngine.Transform)obj2;
					string name;
					if (num < 0xA)
					{
						name = "Marker000" + num.ToString();
					}
					else if (num < 0x64)
					{
						name = "Marker00" + num.ToString();
					}
					else
					{
						name = "Marker0" + num.ToString();
					}
					transform2.name = name;
					this.ODOQDQOO = transform2.gameObject;
					num++;
				}
			}
		}
		this.markers = num - 1;
		this.OCOOCODDOC(this.OODCCOODCC.geoResolution, false, false);
	}

	// Token: 0x06004C51 RID: 19537 RVA: 0x0011FA88 File Offset: 0x0011DC88
	public void ODDOOODDCQ()
	{
		global::RoadObjectScript[] array = (global::RoadObjectScript[])global::UnityEngine.Object.FindObjectsOfType(typeof(global::RoadObjectScript));
		global::System.Collections.ArrayList arrayList = new global::System.Collections.ArrayList();
		foreach (global::RoadObjectScript roadObjectScript in array)
		{
			if (roadObjectScript.transform != base.transform)
			{
				arrayList.Add(roadObjectScript.transform);
			}
		}
		if (this.ODODQOQO == null)
		{
			this.ODODQOQO = this.OOQQCODOCD.OCDODCOCOC();
			this.ODODQOQOInt = this.OOQQCODOCD.OCCQOQCQDO();
		}
		this.OCOOCODDOC(0.5f, true, false);
		this.OOQQCODOCD.OCOOOOCOQO(global::UnityEngine.Vector3.zero, this.OODCCOODCC.raise, this.obj, this.OODCCOODCC.OOQDOOQQ, arrayList, this.handleVegetation);
		this.OCQDCQDDCO();
	}

	// Token: 0x06004C52 RID: 19538 RVA: 0x0011FB68 File Offset: 0x0011DD68
	public global::System.Collections.ArrayList RebuildObjs()
	{
		global::RoadObjectScript[] array = (global::RoadObjectScript[])global::UnityEngine.Object.FindObjectsOfType(typeof(global::RoadObjectScript));
		global::System.Collections.ArrayList arrayList = new global::System.Collections.ArrayList();
		foreach (global::RoadObjectScript roadObjectScript in array)
		{
			if (roadObjectScript.transform != base.transform)
			{
				arrayList.Add(roadObjectScript.transform);
			}
		}
		return arrayList;
	}

	// Token: 0x06004C53 RID: 19539 RVA: 0x0011FBD4 File Offset: 0x0011DDD4
	public void ODQDOOOCOC()
	{
		this.OCOOCODDOC(this.OODCCOODCC.geoResolution, false, false);
		if (this.OOQQCODOCD != null)
		{
			this.OOQQCODOCD.ODQDOOOCOC();
		}
		this.ODODDDOO = false;
	}

	// Token: 0x06004C54 RID: 19540 RVA: 0x0011FC14 File Offset: 0x0011DE14
	public void OCQDCQDDCO()
	{
		this.OOQQCODOCD.OCQDCQDDCO(this.OODCCOODCC.applySplatmap, this.OODCCOODCC.splatmapSmoothLevel, this.OODCCOODCC.renderRoad, this.OODCCOODCC.tuw, this.OODCCOODCC.roadResolution, this.OODCCOODCC.raise, this.OODCCOODCC.opacity, this.OODCCOODCC.expand, this.OODCCOODCC.offsetX, this.OODCCOODCC.offsetY, this.OODCCOODCC.beveledRoad, this.OODCCOODCC.splatmapLayer, this.OODCCOODCC.OdQODQOD, this.OOQQQDOD, this.OOQQQDODOffset, this.OOQQQDODLength);
	}

	// Token: 0x06004C55 RID: 19541 RVA: 0x0011FCD0 File Offset: 0x0011DED0
	public void OQQDQCQQOC()
	{
		this.OOQQCODOCD.OQQDQCQQOC(this.OODCCOODCC.renderRoad, this.OODCCOODCC.tuw, this.OODCCOODCC.roadResolution, this.OODCCOODCC.raise, this.OODCCOODCC.beveledRoad, this.OODCCOODCC.OdQODQOD, this.OOQQQDOD, this.OOQQQDODOffset, this.OOQQQDODLength);
	}

	// Token: 0x06004C56 RID: 19542 RVA: 0x0011FD40 File Offset: 0x0011DF40
	public void ODQDCQQDDO(global::UnityEngine.Vector3 pos, bool doInsert)
	{
		if (!this.displayRoad)
		{
			this.displayRoad = true;
			this.OOQQCODOCD.OODDDCQCCQ(this.displayRoad, this.OODDDCQCOC);
		}
		int num = -1;
		int num2 = -1;
		float num3 = 10000f;
		float num4 = 10000f;
		global::UnityEngine.Vector3 vector = pos;
		global::EasyRoads3D.OQDQOQDOQO oqdqoqdoqo = (global::EasyRoads3D.OQDQOQDOQO)this.OOQQCODOCD.OOODOQDODQ[0];
		global::EasyRoads3D.OQDQOQDOQO oqdqoqdoqo2 = (global::EasyRoads3D.OQDQOQDOQO)this.OOQQCODOCD.OOODOQDODQ[1];
		this.OOQQCODOCD.ODDDDCCDCO(pos, ref num, ref num2, ref num3, ref num4, ref oqdqoqdoqo, ref oqdqoqdoqo2, ref vector);
		pos = vector;
		if (doInsert && num >= 0 && num2 >= 0)
		{
			if (this.OODCCOODCC.OOQDOOQQ && num2 == this.OOQQCODOCD.OOODOQDODQ.Count - 1)
			{
				this.OODDQODDCC(pos);
			}
			else
			{
				global::EasyRoads3D.OQDQOQDOQO oqdqoqdoqo3 = (global::EasyRoads3D.OQDQOQDOQO)this.OOQQCODOCD.OOODOQDODQ[num2];
				string name = oqdqoqdoqo3.object1.name;
				int num5 = num2 + 2;
				for (int i = num2; i < this.OOQQCODOCD.OOODOQDODQ.Count - 1; i++)
				{
					oqdqoqdoqo3 = (global::EasyRoads3D.OQDQOQDOQO)this.OOQQCODOCD.OOODOQDODQ[i];
					string name2;
					if (num5 < 0xA)
					{
						name2 = "Marker000" + num5.ToString();
					}
					else if (num5 < 0x64)
					{
						name2 = "Marker00" + num5.ToString();
					}
					else
					{
						name2 = "Marker0" + num5.ToString();
					}
					oqdqoqdoqo3.object1.name = name2;
					num5++;
				}
				oqdqoqdoqo3 = (global::EasyRoads3D.OQDQOQDOQO)this.OOQQCODOCD.OOODOQDODQ[num];
				global::UnityEngine.Transform transform = (global::UnityEngine.Transform)global::UnityEngine.Object.Instantiate(oqdqoqdoqo3.object1.transform, pos, oqdqoqdoqo3.object1.rotation);
				transform.gameObject.name = name;
				transform.parent = this.OODDDCQCOC;
				global::MarkerScript component = transform.GetComponent<global::MarkerScript>();
				component.OOCCDCOQCQ = false;
				float num6 = num3 + num4;
				float num7 = num3 / num6;
				float num8 = oqdqoqdoqo.ri - oqdqoqdoqo2.ri;
				component.ri = oqdqoqdoqo.ri - num8 * num7;
				num8 = oqdqoqdoqo.li - oqdqoqdoqo2.li;
				component.li = oqdqoqdoqo.li - num8 * num7;
				num8 = oqdqoqdoqo.rt - oqdqoqdoqo2.rt;
				component.rt = oqdqoqdoqo.rt - num8 * num7;
				num8 = oqdqoqdoqo.lt - oqdqoqdoqo2.lt;
				component.lt = oqdqoqdoqo.lt - num8 * num7;
				num8 = oqdqoqdoqo.rs - oqdqoqdoqo2.rs;
				component.rs = oqdqoqdoqo.rs - num8 * num7;
				num8 = oqdqoqdoqo.ls - oqdqoqdoqo2.ls;
				component.ls = oqdqoqdoqo.ls - num8 * num7;
				this.OCOOCODDOC(this.OODCCOODCC.geoResolution, false, false);
				if (this.materialType == 0)
				{
					this.OOQQCODOCD.OOQOOCDQOD(this.materialType);
				}
				if (this.objectType == 2)
				{
					component.surface.gameObject.SetActive(false);
				}
			}
		}
		this.OOQODQOCOC();
	}

	// Token: 0x06004C57 RID: 19543 RVA: 0x0012009C File Offset: 0x0011E29C
	public void ODCQOCDQOC()
	{
		global::UnityEngine.Object.DestroyImmediate(this.OODCCOODCC.OCQOCOCQQO.gameObject);
		this.OCQOCOCQQO = null;
		this.OOQODQOCOC();
	}

	// Token: 0x06004C58 RID: 19544 RVA: 0x001200CC File Offset: 0x0011E2CC
	public void OQCQQDODDC()
	{
		if (this.OOQQCODOCD == null)
		{
			this.ODOCOQCCOC(base.transform, null, null, null);
		}
		global::EasyRoads3D.OQCDQQDQCC.ODOQCCODQC = true;
		if (!this.ODODCOCCDQ)
		{
			this.geoResolution = 0.5f;
			this.ODODCOCCDQ = true;
			this.doTerrain = false;
			this.OOQODQOCOC();
			if (this.objectType < 2)
			{
				this.ODDOOODDCQ();
			}
			this.OOQQCODOCD.terrainRendered = true;
			this.OCQDCQDDCO();
		}
		if (this.displayRoad && this.objectType < 2)
		{
			global::UnityEngine.Material material = (global::UnityEngine.Material)global::UnityEngine.Resources.Load("roadMaterial", typeof(global::UnityEngine.Material));
			if (this.OOQQCODOCD.road.renderer != null)
			{
				this.OOQQCODOCD.road.renderer.material = material;
			}
			foreach (object obj in this.OOQQCODOCD.road.transform)
			{
				global::UnityEngine.Transform transform = (global::UnityEngine.Transform)obj;
				if (transform.gameObject.renderer != null)
				{
					transform.gameObject.renderer.material = material;
				}
			}
			this.OOQQCODOCD.road.transform.parent = null;
			this.OOQQCODOCD.road.layer = 0;
			this.OOQQCODOCD.road.name = base.gameObject.name;
		}
		else if (this.OOQQCODOCD.road != null)
		{
			global::UnityEngine.Object.DestroyImmediate(this.OOQQCODOCD.road);
		}
	}

	// Token: 0x06004C59 RID: 19545 RVA: 0x001202A4 File Offset: 0x0011E4A4
	public void OQQOOCCQCO()
	{
		this.OOQQCODOCD.OOQDODCQOQ(0xC);
	}

	// Token: 0x06004C5A RID: 19546 RVA: 0x001202B4 File Offset: 0x0011E4B4
	public global::System.Collections.ArrayList ODCOQCODCC()
	{
		global::System.Collections.ArrayList arrayList = new global::System.Collections.ArrayList();
		foreach (object obj in this.obj)
		{
			global::UnityEngine.Transform transform = (global::UnityEngine.Transform)obj;
			if (transform.name == "Markers")
			{
				foreach (object obj2 in transform)
				{
					global::UnityEngine.Transform transform2 = (global::UnityEngine.Transform)obj2;
					global::MarkerScript component = transform2.GetComponent<global::MarkerScript>();
					arrayList.Add(component.ODDGDOOO);
					arrayList.Add(component.ODDQOODO);
					if (transform2.name == "Marker0003")
					{
					}
					arrayList.Add(component.ODDQOOO);
				}
			}
		}
		return arrayList;
	}

	// Token: 0x06004C5B RID: 19547 RVA: 0x001203DC File Offset: 0x0011E5DC
	public void OQCOCQDQDD()
	{
		global::System.Collections.ArrayList arrayList = new global::System.Collections.ArrayList();
		global::System.Collections.ArrayList arrayList2 = new global::System.Collections.ArrayList();
		global::System.Collections.ArrayList arrayList3 = new global::System.Collections.ArrayList();
		for (int i = 0; i < global::RoadObjectScript.ODODOQQO.Length; i++)
		{
			if (this.ODODQQOD[i])
			{
				arrayList.Add(global::RoadObjectScript.ODODQOOQ[i]);
				arrayList3.Add(global::RoadObjectScript.ODODOQQO[i]);
				arrayList2.Add(i);
			}
		}
		this.ODODDQOO = (string[])arrayList.ToArray(typeof(string));
		this.OOQQQOQO = (int[])arrayList2.ToArray(typeof(int));
	}

	// Token: 0x06004C5C RID: 19548 RVA: 0x00120480 File Offset: 0x0011E680
	public void OOOOOOODCD(global::System.Collections.ArrayList arr, string[] DOODQOQO, string[] OODDQOQO)
	{
		bool flag = false;
		global::RoadObjectScript.ODODOQQO = DOODQOQO;
		global::RoadObjectScript.ODODQOOQ = OODDQOQO;
		global::System.Collections.ArrayList arrayList = new global::System.Collections.ArrayList();
		if (this.obj == null)
		{
			this.ODOCOQCCOC(base.transform, null, null, null);
		}
		foreach (object obj in this.obj)
		{
			global::UnityEngine.Transform transform = (global::UnityEngine.Transform)obj;
			if (transform.name == "Markers")
			{
				foreach (object obj2 in transform)
				{
					global::UnityEngine.Transform transform2 = (global::UnityEngine.Transform)obj2;
					global::MarkerScript component = transform2.GetComponent<global::MarkerScript>();
					component.OQODQQDO.Clear();
					component.ODOQQQDO.Clear();
					component.OQQODQQOO.Clear();
					component.ODDOQQOO.Clear();
					arrayList.Add(component);
				}
			}
		}
		this.mSc = (global::MarkerScript[])arrayList.ToArray(typeof(global::MarkerScript));
		global::System.Collections.ArrayList arrayList2 = new global::System.Collections.ArrayList();
		int num = 0;
		int num2 = 0;
		if (this.ODQQQQQO != null)
		{
			if (arr.Count == 0)
			{
				return;
			}
			for (int i = 0; i < global::RoadObjectScript.ODODOQQO.Length; i++)
			{
				global::EasyRoads3D.ODODDQQO ododdqqo = (global::EasyRoads3D.ODODDQQO)arr[i];
				for (int j = 0; j < this.ODQQQQQO.Length; j++)
				{
					if (global::RoadObjectScript.ODODOQQO[i] == this.ODQQQQQO[j])
					{
						num++;
						if (this.ODODQQOD.Length > j)
						{
							arrayList2.Add(this.ODODQQOD[j]);
						}
						else
						{
							arrayList2.Add(false);
						}
						foreach (global::MarkerScript markerScript in this.mSc)
						{
							int num3 = -1;
							for (int l = 0; l < markerScript.ODDOOQDO.Length; l++)
							{
								if (ododdqqo.id == markerScript.ODDOOQDO[l])
								{
									num3 = l;
									break;
								}
							}
							if (num3 >= 0)
							{
								markerScript.OQODQQDO.Add(markerScript.ODDOOQDO[num3]);
								markerScript.ODOQQQDO.Add(markerScript.ODDGDOOO[num3]);
								markerScript.OQQODQQOO.Add(markerScript.ODDQOOO[num3]);
								if (ododdqqo.sidewaysDistanceUpdate == 0 || (ododdqqo.sidewaysDistanceUpdate == 2 && markerScript.ODDQOODO[num3] != ododdqqo.oldSidwaysDistance))
								{
									markerScript.ODDOQQOO.Add(markerScript.ODDQOODO[num3]);
								}
								else
								{
									markerScript.ODDOQQOO.Add(ododdqqo.splinePosition);
								}
							}
							else
							{
								markerScript.OQODQQDO.Add(ododdqqo.id);
								markerScript.ODOQQQDO.Add(ododdqqo.markerActive);
								markerScript.OQQODQQOO.Add(true);
								markerScript.ODDOQQOO.Add(ododdqqo.splinePosition);
							}
						}
					}
				}
				if (ododdqqo.sidewaysDistanceUpdate != 0)
				{
				}
				flag = false;
			}
		}
		for (int m = 0; m < global::RoadObjectScript.ODODOQQO.Length; m++)
		{
			global::EasyRoads3D.ODODDQQO ododdqqo2 = (global::EasyRoads3D.ODODDQQO)arr[m];
			bool flag2 = false;
			for (int n = 0; n < this.ODQQQQQO.Length; n++)
			{
				if (global::RoadObjectScript.ODODOQQO[m] == this.ODQQQQQO[n])
				{
					flag2 = true;
				}
			}
			if (!flag2)
			{
				num2++;
				arrayList2.Add(false);
				foreach (global::MarkerScript markerScript2 in this.mSc)
				{
					markerScript2.OQODQQDO.Add(ododdqqo2.id);
					markerScript2.ODOQQQDO.Add(ododdqqo2.markerActive);
					markerScript2.OQQODQQOO.Add(true);
					markerScript2.ODDOQQOO.Add(ododdqqo2.splinePosition);
				}
			}
		}
		this.ODODQQOD = (bool[])arrayList2.ToArray(typeof(bool));
		this.ODQQQQQO = new string[global::RoadObjectScript.ODODOQQO.Length];
		global::RoadObjectScript.ODODOQQO.CopyTo(this.ODQQQQQO, 0);
		global::System.Collections.ArrayList arrayList3 = new global::System.Collections.ArrayList();
		for (int num5 = 0; num5 < this.ODODQQOD.Length; num5++)
		{
			if (this.ODODQQOD[num5])
			{
				arrayList3.Add(num5);
			}
		}
		this.OOQQQOQO = (int[])arrayList3.ToArray(typeof(int));
		foreach (global::MarkerScript markerScript3 in this.mSc)
		{
			markerScript3.ODDOOQDO = (string[])markerScript3.OQODQQDO.ToArray(typeof(string));
			markerScript3.ODDGDOOO = (bool[])markerScript3.ODOQQQDO.ToArray(typeof(bool));
			markerScript3.ODDQOOO = (bool[])markerScript3.OQQODQQOO.ToArray(typeof(bool));
			markerScript3.ODDQOODO = (float[])markerScript3.ODDOQQOO.ToArray(typeof(float));
		}
		if (flag)
		{
		}
	}

	// Token: 0x06004C5D RID: 19549 RVA: 0x00120AA4 File Offset: 0x0011ECA4
	public bool CheckWaterHeights()
	{
		bool result = true;
		float y = global::UnityEngine.Terrain.activeTerrain.transform.position.y;
		foreach (object obj in this.obj)
		{
			global::UnityEngine.Transform transform = (global::UnityEngine.Transform)obj;
			if (transform.name == "Markers")
			{
				foreach (object obj2 in transform)
				{
					global::UnityEngine.Transform transform2 = (global::UnityEngine.Transform)obj2;
					if (transform2.position.y - y <= 0.1f)
					{
						result = false;
					}
				}
			}
		}
		return result;
	}

	// Token: 0x040028B5 RID: 10421
	public static string version = string.Empty;

	// Token: 0x040028B6 RID: 10422
	public int objectType;

	// Token: 0x040028B7 RID: 10423
	public bool displayRoad = true;

	// Token: 0x040028B8 RID: 10424
	public float roadWidth = 5f;

	// Token: 0x040028B9 RID: 10425
	public float indent = 3f;

	// Token: 0x040028BA RID: 10426
	public float surrounding = 5f;

	// Token: 0x040028BB RID: 10427
	public float raise = 1f;

	// Token: 0x040028BC RID: 10428
	public float raiseMarkers = 0.5f;

	// Token: 0x040028BD RID: 10429
	public bool OOQDOOQQ;

	// Token: 0x040028BE RID: 10430
	public bool renderRoad = true;

	// Token: 0x040028BF RID: 10431
	public bool beveledRoad;

	// Token: 0x040028C0 RID: 10432
	public bool applySplatmap;

	// Token: 0x040028C1 RID: 10433
	public int splatmapLayer = 4;

	// Token: 0x040028C2 RID: 10434
	public bool autoUpdate = true;

	// Token: 0x040028C3 RID: 10435
	public float geoResolution = 5f;

	// Token: 0x040028C4 RID: 10436
	public int roadResolution = 1;

	// Token: 0x040028C5 RID: 10437
	public float tuw = 15f;

	// Token: 0x040028C6 RID: 10438
	public int splatmapSmoothLevel;

	// Token: 0x040028C7 RID: 10439
	public float opacity = 1f;

	// Token: 0x040028C8 RID: 10440
	public int expand;

	// Token: 0x040028C9 RID: 10441
	public int offsetX;

	// Token: 0x040028CA RID: 10442
	public int offsetY;

	// Token: 0x040028CB RID: 10443
	private global::UnityEngine.Material surfaceMaterial;

	// Token: 0x040028CC RID: 10444
	public float surfaceOpacity = 1f;

	// Token: 0x040028CD RID: 10445
	public float smoothDistance = 1f;

	// Token: 0x040028CE RID: 10446
	public float smoothSurDistance = 3f;

	// Token: 0x040028CF RID: 10447
	private bool handleInsertFlag;

	// Token: 0x040028D0 RID: 10448
	public bool handleVegetation = true;

	// Token: 0x040028D1 RID: 10449
	public float OOCQDOOCQD = 2f;

	// Token: 0x040028D2 RID: 10450
	public float ODDQCCDCDC = 1f;

	// Token: 0x040028D3 RID: 10451
	public int materialType;

	// Token: 0x040028D4 RID: 10452
	private string[] materialStrings;

	// Token: 0x040028D5 RID: 10453
	private global::MarkerScript[] mSc;

	// Token: 0x040028D6 RID: 10454
	private bool ODQDOQOCCD;

	// Token: 0x040028D7 RID: 10455
	private bool[] OQCCDQCDDD;

	// Token: 0x040028D8 RID: 10456
	private bool[] ODODODCODD;

	// Token: 0x040028D9 RID: 10457
	public string[] OODQCQODQQ;

	// Token: 0x040028DA RID: 10458
	public string[] ODODQOQO;

	// Token: 0x040028DB RID: 10459
	public int[] ODODQOQOInt;

	// Token: 0x040028DC RID: 10460
	public int OQDCQDCDDD = -1;

	// Token: 0x040028DD RID: 10461
	public int ODOCDOOOQQ = -1;

	// Token: 0x040028DE RID: 10462
	public static global::UnityEngine.GUISkin OODCDOQDCC;

	// Token: 0x040028DF RID: 10463
	public static global::UnityEngine.GUISkin OODQQDDCDD;

	// Token: 0x040028E0 RID: 10464
	public bool OQOCDODDQC;

	// Token: 0x040028E1 RID: 10465
	private global::UnityEngine.Vector3 cPos;

	// Token: 0x040028E2 RID: 10466
	private global::UnityEngine.Vector3 ePos;

	// Token: 0x040028E3 RID: 10467
	public bool OOCCDCOQCQ;

	// Token: 0x040028E4 RID: 10468
	public static global::UnityEngine.Texture2D OQOOODODQD;

	// Token: 0x040028E5 RID: 10469
	public int markers = 1;

	// Token: 0x040028E6 RID: 10470
	public global::EasyRoads3D.OQCDQQDQCC OOQQCODOCD;

	// Token: 0x040028E7 RID: 10471
	private global::UnityEngine.GameObject ODOQDQOO;

	// Token: 0x040028E8 RID: 10472
	public bool ODODCOCCDQ;

	// Token: 0x040028E9 RID: 10473
	public bool doTerrain;

	// Token: 0x040028EA RID: 10474
	private global::UnityEngine.Transform OCQOCOCQQO;

	// Token: 0x040028EB RID: 10475
	public global::UnityEngine.GameObject[] OCQOCOCQQOs;

	// Token: 0x040028EC RID: 10476
	private static string OCQCDDDOCC;

	// Token: 0x040028ED RID: 10477
	public global::UnityEngine.Transform obj;

	// Token: 0x040028EE RID: 10478
	private string OOQCQCDDOQ;

	// Token: 0x040028EF RID: 10479
	public static string erInit = string.Empty;

	// Token: 0x040028F0 RID: 10480
	public static global::UnityEngine.Transform OCQQQOQOQC;

	// Token: 0x040028F1 RID: 10481
	private global::RoadObjectScript OODCCOODCC;

	// Token: 0x040028F2 RID: 10482
	public bool flyby;

	// Token: 0x040028F3 RID: 10483
	private global::UnityEngine.Vector3 pos;

	// Token: 0x040028F4 RID: 10484
	private float fl;

	// Token: 0x040028F5 RID: 10485
	private float oldfl;

	// Token: 0x040028F6 RID: 10486
	private bool ODDCQQQQOO;

	// Token: 0x040028F7 RID: 10487
	private bool ODOQCDDCOO;

	// Token: 0x040028F8 RID: 10488
	private bool ODQQOQCQCO;

	// Token: 0x040028F9 RID: 10489
	public global::UnityEngine.Transform OODDDCQCOC;

	// Token: 0x040028FA RID: 10490
	public int OdQODQOD = 1;

	// Token: 0x040028FB RID: 10491
	public float OOQQQDOD;

	// Token: 0x040028FC RID: 10492
	public float OOQQQDODOffset;

	// Token: 0x040028FD RID: 10493
	public float OOQQQDODLength;

	// Token: 0x040028FE RID: 10494
	public bool ODODDDOO;

	// Token: 0x040028FF RID: 10495
	public static string[] ODOQDOQO;

	// Token: 0x04002900 RID: 10496
	public static string[] ODODOQQO;

	// Token: 0x04002901 RID: 10497
	public static string[] ODODQOOQ;

	// Token: 0x04002902 RID: 10498
	public int ODQDOOQO;

	// Token: 0x04002903 RID: 10499
	public string[] ODQQQQQO;

	// Token: 0x04002904 RID: 10500
	public string[] ODODDQOO;

	// Token: 0x04002905 RID: 10501
	public bool[] ODODQQOD;

	// Token: 0x04002906 RID: 10502
	public int[] OOQQQOQO;

	// Token: 0x04002907 RID: 10503
	public int ODOQOOQO;

	// Token: 0x04002908 RID: 10504
	public bool forceY;

	// Token: 0x04002909 RID: 10505
	public float yChange;

	// Token: 0x0400290A RID: 10506
	public float floorDepth = 2f;

	// Token: 0x0400290B RID: 10507
	public float waterLevel = 1.5f;

	// Token: 0x0400290C RID: 10508
	public bool lockWaterLevel = true;

	// Token: 0x0400290D RID: 10509
	public float lastY;

	// Token: 0x0400290E RID: 10510
	public string distance = "0";

	// Token: 0x0400290F RID: 10511
	public string markerDisplayStr = "Hide Markers";

	// Token: 0x04002910 RID: 10512
	public static string[] objectStrings;

	// Token: 0x04002911 RID: 10513
	public string objectText = "Road";

	// Token: 0x04002912 RID: 10514
	public bool applyAnimation;

	// Token: 0x04002913 RID: 10515
	public float waveSize = 1.5f;

	// Token: 0x04002914 RID: 10516
	public float waveHeight = 0.15f;

	// Token: 0x04002915 RID: 10517
	public bool snapY = true;

	// Token: 0x04002916 RID: 10518
	private global::UnityEngine.TextAnchor origAnchor;

	// Token: 0x04002917 RID: 10519
	public bool autoODODDQQO;

	// Token: 0x04002918 RID: 10520
	public global::UnityEngine.Texture2D roadTexture;

	// Token: 0x04002919 RID: 10521
	public global::UnityEngine.Texture2D roadMaterial;

	// Token: 0x0400291A RID: 10522
	public string[] ODQOOCCQQO;

	// Token: 0x0400291B RID: 10523
	public string[] OOOOCOCCDC;

	// Token: 0x0400291C RID: 10524
	public int selectedWaterMaterial;

	// Token: 0x0400291D RID: 10525
	public int selectedWaterScript;

	// Token: 0x0400291E RID: 10526
	private bool doRestore;

	// Token: 0x0400291F RID: 10527
	public bool doFlyOver;

	// Token: 0x04002920 RID: 10528
	public static global::UnityEngine.GameObject tracer;

	// Token: 0x04002921 RID: 10529
	public global::UnityEngine.Camera goCam;

	// Token: 0x04002922 RID: 10530
	public float speed = 1f;

	// Token: 0x04002923 RID: 10531
	public float offset;

	// Token: 0x04002924 RID: 10532
	public bool camInit;

	// Token: 0x04002925 RID: 10533
	public global::UnityEngine.GameObject customMesh;

	// Token: 0x04002926 RID: 10534
	public static bool disableFreeAlerts = true;

	// Token: 0x04002927 RID: 10535
	public bool multipleTerrains;

	// Token: 0x04002928 RID: 10536
	public bool editRestore = true;

	// Token: 0x04002929 RID: 10537
	public global::UnityEngine.Material roadMaterialEdit;

	// Token: 0x0400292A RID: 10538
	public static int backupLocation;

	// Token: 0x0400292B RID: 10539
	public string[] backupStrings = new string[]
	{
		"Outside Assets folder path",
		"Inside Assets folder path"
	};

	// Token: 0x0400292C RID: 10540
	public global::UnityEngine.Vector3[] leftVecs = new global::UnityEngine.Vector3[0];

	// Token: 0x0400292D RID: 10541
	public global::UnityEngine.Vector3[] rightVecs = new global::UnityEngine.Vector3[0];
}
