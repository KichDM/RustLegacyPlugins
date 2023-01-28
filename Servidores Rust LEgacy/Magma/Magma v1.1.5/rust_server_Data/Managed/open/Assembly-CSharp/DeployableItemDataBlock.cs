using System;
using Facepunch.MeshBatch;
using Magma;
using Rust;
using RustProto;
using uLink;
using UnityEngine;

// Token: 0x0200068C RID: 1676
public class DeployableItemDataBlock : global::HeldItemDataBlock
{
	// Token: 0x060036B0 RID: 14000 RVA: 0x000CC528 File Offset: 0x000CA728
	public DeployableItemDataBlock()
	{
	}

	// Token: 0x060036B1 RID: 14001 RVA: 0x000CC550 File Offset: 0x000CA750
	protected override global::IInventoryItem ConstructItem()
	{
		return new global::DeployableItemDataBlock.ITEM_TYPE(this);
	}

	// Token: 0x17000AF8 RID: 2808
	// (get) Token: 0x060036B2 RID: 14002 RVA: 0x000CC558 File Offset: 0x000CA758
	public global::DeployableObject ObjectToPlace
	{
		get
		{
			if (!this._loadedDeployableObject && global::UnityEngine.Application.isPlaying)
			{
				global::NetCull.LoadPrefabScript<global::DeployableObject>(this.DeployableObjectPrefabName, out this._deployableObject);
				this._loadedDeployableObject = true;
			}
			return this._deployableObject;
		}
	}

	// Token: 0x060036B3 RID: 14003 RVA: 0x000CC59C File Offset: 0x000CA79C
	public bool CheckPlacement(global::UnityEngine.Ray ray, out global::UnityEngine.Vector3 pos, out global::UnityEngine.Quaternion rot, out global::TransCarrier carrier)
	{
		global::DeployableItemDataBlock.DeployPlaceResults deployPlaceResults;
		this.CheckPlacementResults(ray, out pos, out rot, out carrier, out deployPlaceResults);
		return deployPlaceResults.Valid();
	}

	// Token: 0x060036B4 RID: 14004 RVA: 0x000CC5C0 File Offset: 0x000CA7C0
	private static bool NonVariantSphereCast(global::UnityEngine.Ray r, global::UnityEngine.Vector3 p)
	{
		global::UnityEngine.Vector3 origin = r.origin;
		global::UnityEngine.Vector3 direction = r.direction;
		float num = direction.x * p.x + direction.y * p.y + direction.z * p.z - (direction.x * origin.x + direction.y * origin.y + direction.z * origin.z);
		global::UnityEngine.Vector3 vector;
		vector.x = p.x - (direction.x * num + origin.x);
		vector.y = p.y - (direction.y * num + origin.y);
		vector.z = p.z - (direction.z * num + origin.z);
		return vector.x * vector.x + vector.y * vector.y + vector.z * vector.z < 0.001f;
	}

	// Token: 0x060036B5 RID: 14005 RVA: 0x000CC6D4 File Offset: 0x000CA8D4
	public void CheckPlacementResults(global::UnityEngine.Ray ray, out global::UnityEngine.Vector3 pos, out global::UnityEngine.Quaternion rot, out global::TransCarrier carrier, out global::DeployableItemDataBlock.DeployPlaceResults results)
	{
		float num = this.placeRange;
		bool flag = false;
		bool flag2 = false;
		bool flag3 = false;
		global::DeployableObject deployableObject = null;
		bool flag4 = false;
		bool flag5 = false;
		bool flag6 = this.minCastRadius >= float.Epsilon;
		global::UnityEngine.RaycastHit raycastHit;
		bool flag8;
		global::Facepunch.MeshBatch.MeshBatchInstance meshBatchInstance;
		bool flag7 = (!flag6) ? global::Facepunch.MeshBatch.MeshBatchPhysics.Raycast(ray, ref raycastHit, num, -0x1C270005, ref flag8, ref meshBatchInstance) : global::Facepunch.MeshBatch.MeshBatchPhysics.SphereCast(ray, this.minCastRadius, ref raycastHit, num, -0x1C270005, ref flag8, ref meshBatchInstance);
		global::UnityEngine.Vector3 point = ray.GetPoint(num);
		if (!flag7)
		{
			global::UnityEngine.Vector3 vector = point;
			vector.y += 0.5f;
			flag4 = global::Facepunch.MeshBatch.MeshBatchPhysics.Raycast(vector, global::UnityEngine.Vector3.down, ref raycastHit, 5f, -0x1C270005, ref flag8, ref meshBatchInstance);
		}
		global::UnityEngine.Vector3 vector2;
		global::UnityEngine.Vector3 vector3;
		if (flag7 || flag4)
		{
			global::IDMain idmain = (!flag8) ? global::IDBase.GetMain(raycastHit.collider) : meshBatchInstance.idMain;
			flag3 = (idmain is global::StructureComponent || idmain is global::StructureMaster);
			vector2 = raycastHit.point;
			vector3 = raycastHit.normal;
			flag = (!flag3 && (deployableObject = (idmain as global::DeployableObject)));
			if (this.carrierSphereCastMode != global::DeployableItemDataBlock.CarrierSphereCastMode.Allowed && flag7 && flag6 && !global::DeployableItemDataBlock.NonVariantSphereCast(ray, vector2))
			{
				float num2;
				global::UnityEngine.Ray ray2;
				if (this.carrierSphereCastMode == global::DeployableItemDataBlock.CarrierSphereCastMode.AdjustedRay)
				{
					global::UnityEngine.Vector3 origin = ray.origin;
					global::UnityEngine.Vector3 point2 = raycastHit.point;
					global::UnityEngine.Vector3 vector4 = point2 - origin;
					num2 = vector4.magnitude + this.minCastRadius * 2f;
					ray2..ctor(origin, vector4);
					global::UnityEngine.Debug.DrawLine(ray.origin, ray.GetPoint(num2), global::UnityEngine.Color.cyan);
				}
				else
				{
					num2 = num + this.minCastRadius;
					ray2 = ray;
				}
				global::UnityEngine.RaycastHit raycastHit2;
				bool flag10;
				global::Facepunch.MeshBatch.MeshBatchInstance meshBatchInstance2;
				bool flag9;
				if (!(flag9 = global::Facepunch.MeshBatch.MeshBatchPhysics.Raycast(ray2, ref raycastHit2, num2, -0x1C270005, ref flag10, ref meshBatchInstance2)))
				{
					global::UnityEngine.Vector3 vector5 = vector2;
					vector5.y += 0.5f;
					flag9 = global::Facepunch.MeshBatch.MeshBatchPhysics.Raycast(vector5, global::UnityEngine.Vector3.down, ref raycastHit2, 5f, -0x1C270005, ref flag10, ref meshBatchInstance2);
				}
				if (flag9)
				{
					global::IDMain idmain2 = (!flag10) ? global::IDBase.GetMain(raycastHit2.collider) : meshBatchInstance2.idMain;
					carrier = ((!idmain2) ? raycastHit2.collider.GetComponent<global::TransCarrier>() : idmain2.GetLocal<global::TransCarrier>());
				}
				else
				{
					carrier = null;
				}
			}
			else
			{
				carrier = ((!idmain) ? raycastHit.collider.gameObject : idmain.gameObject).GetComponent<global::TransCarrier>();
			}
			flag2 = (raycastHit.collider is global::UnityEngine.TerrainCollider || raycastHit.collider.gameObject.layer == 0xA);
			flag5 = true;
		}
		else
		{
			vector2 = point;
			vector3 = global::UnityEngine.Vector3.up;
			carrier = null;
		}
		bool flag11 = false;
		global::Hardpoint hardpoint = null;
		if (this.hardpointType != global::Hardpoint.hardpoint_type.None)
		{
			hardpoint = global::Hardpoint.GetHardpointFromRay(ray, this.hardpointType);
			if (hardpoint)
			{
				flag11 = true;
				vector2 = hardpoint.transform.position;
				vector3 = hardpoint.transform.up;
				carrier = hardpoint.GetMaster().GetTransCarrier();
				flag5 = true;
			}
		}
		bool flag12 = false;
		if (this.spacingRadius > 0f)
		{
			global::UnityEngine.Collider[] array = global::UnityEngine.Physics.OverlapSphere(vector2, this.spacingRadius);
			foreach (global::UnityEngine.Collider collider in array)
			{
				global::UnityEngine.GameObject gameObject = collider.gameObject;
				global::IDBase component = collider.gameObject.GetComponent<global::IDBase>();
				if (component != null)
				{
					gameObject = component.idMain.gameObject;
				}
				if (gameObject.CompareTag(this.ObjectToPlace.gameObject.tag) && global::UnityEngine.Vector3.Distance(vector2, gameObject.transform.position) < this.spacingRadius)
				{
					flag12 = true;
					break;
				}
			}
		}
		bool flag13 = false;
		if (flag && !this.forcePlaceable && deployableObject.cantPlaceOn)
		{
			flag13 = true;
		}
		pos = vector2;
		if (this.orientationMode == global::DeployableOrientationMode.Default)
		{
			if (this.uprightOnly)
			{
				this.orientationMode = global::DeployableOrientationMode.Upright;
			}
			else
			{
				this.orientationMode = global::DeployableOrientationMode.NormalUp;
			}
		}
		global::UnityEngine.Quaternion quaternion;
		switch (this.orientationMode)
		{
		case global::DeployableOrientationMode.NormalUp:
			quaternion = global::TransformHelpers.LookRotationForcedUp(ray.direction, vector3);
			break;
		case global::DeployableOrientationMode.Upright:
			quaternion = global::TransformHelpers.LookRotationForcedUp(ray.direction, global::UnityEngine.Vector3.up);
			break;
		case global::DeployableOrientationMode.NormalForward:
		{
			global::UnityEngine.Vector3 forward = global::UnityEngine.Vector3.Cross(ray.direction, global::UnityEngine.Vector3.up);
			quaternion = global::TransformHelpers.LookRotationForcedUp(forward, vector3);
			break;
		}
		case global::DeployableOrientationMode.HardpointPosRot:
			if (flag11)
			{
				quaternion = hardpoint.transform.rotation;
			}
			else
			{
				quaternion = global::TransformHelpers.LookRotationForcedUp(ray.direction, global::UnityEngine.Vector3.up);
			}
			break;
		default:
			throw new global::System.NotImplementedException();
		}
		rot = quaternion * this.ObjectToPlace.transform.localRotation;
		bool flag14 = false;
		if (this.checkPlacementZones)
		{
			flag14 = global::NoPlacementZone.ValidPos(pos);
		}
		float num3 = global::UnityEngine.Vector3.Angle(vector3, global::UnityEngine.Vector3.up);
		results.falseFromDeployable = ((!this.CanStackOnDeployables && flag) || flag13);
		results.falseFromTerrian = (this.TerrainOnly && !flag2);
		results.falseFromClose = (this.spacingRadius > 0f && flag12);
		results.falseFromHardpoint = (this.requireHardpoint && !flag11);
		results.falseFromAngle = (!this.requireHardpoint && num3 >= this.ObjectToPlace.maxSlope);
		results.falseFromPlacementZone = (this.checkPlacementZones && !flag14);
		results.falseFromHittingNothing = !flag5;
		results.falseFromStructure = (this.StructureOnly && !flag3);
		results.falseFromFitRequirements = (this.fitRequirements != null && !this.fitRequirements.Test(pos, (!this.fitTestForcedUp) ? rot : global::TransformHelpers.LookRotationForcedUp(rot, global::UnityEngine.Vector3.up), this.ObjectToPlace.transform.localScale));
	}

	// Token: 0x060036B6 RID: 14006 RVA: 0x000CCD48 File Offset: 0x000CAF48
	public override void DoAction1(global::uLink.BitStream stream, global::ItemRepresentation rep, ref global::uLink.NetworkMessageInfo info)
	{
		global::NetCull.VerifyRPC(ref info, false);
		global::IDeployableItem deployableItem;
		if (!rep.Item<global::IDeployableItem>(out deployableItem) || deployableItem.uses <= 0)
		{
			return;
		}
		global::UnityEngine.Vector3 vector = stream.ReadVector3();
		global::UnityEngine.Vector3 vector2 = stream.ReadVector3();
		global::UnityEngine.Ray ray;
		ray..ctor(vector, vector2);
		global::UnityEngine.Vector3 position;
		global::UnityEngine.Quaternion rotation;
		global::TransCarrier carrier;
		if (!this.CheckPlacement(ray, out position, out rotation, out carrier))
		{
			global::Rust.Notice.Popup(info.sender, "", "You can't place that here", 4f);
			return;
		}
		global::DeployableObject component = global::NetCull.InstantiateStatic(this.DeployableObjectPrefabName, position, rotation).GetComponent<global::DeployableObject>();
		if (component)
		{
			try
			{
				component.SetupCreator(deployableItem.controllable);
				this.SetupDeployableObject(stream, rep, ref info, component, carrier);
				global::Magma.Hooks.EntityDeployed(component);
			}
			finally
			{
				int num = 1;
				if (deployableItem.Consume(ref num))
				{
					deployableItem.inventory.RemoveItem(deployableItem.slot);
				}
			}
		}
	}

	// Token: 0x060036B7 RID: 14007 RVA: 0x000CCE3C File Offset: 0x000CB03C
	protected virtual void SetupDeployableObject(global::uLink.BitStream stream, global::ItemRepresentation rep, ref global::uLink.NetworkMessageInfo info, global::DeployableObject created, global::TransCarrier carrier)
	{
		if (carrier)
		{
			carrier.AddObject(created);
		}
		else if (!this.neverGrabCarrier)
		{
			created.GrabCarrier();
		}
	}

	// Token: 0x04001D92 RID: 7570
	public global::GameGizmo aimGizmo;

	// Token: 0x04001D93 RID: 7571
	[global::System.NonSerialized]
	private global::DeployableObject _deployableObject;

	// Token: 0x04001D94 RID: 7572
	[global::System.NonSerialized]
	private bool _loadedDeployableObject;

	// Token: 0x04001D95 RID: 7573
	public string DeployableObjectPrefabName;

	// Token: 0x04001D96 RID: 7574
	public global::UnityEngine.Material overrideMat;

	// Token: 0x04001D97 RID: 7575
	public bool uprightOnly;

	// Token: 0x04001D98 RID: 7576
	public global::DeployableOrientationMode orientationMode;

	// Token: 0x04001D99 RID: 7577
	public bool CanStackOnDeployables = true;

	// Token: 0x04001D9A RID: 7578
	public float minCastRadius = 0.25f;

	// Token: 0x04001D9B RID: 7579
	public bool StructureOnly;

	// Token: 0x04001D9C RID: 7580
	public bool TerrainOnly;

	// Token: 0x04001D9D RID: 7581
	public float spacingRadius;

	// Token: 0x04001D9E RID: 7582
	public float placeRange = 8f;

	// Token: 0x04001D9F RID: 7583
	public bool requireHardpoint;

	// Token: 0x04001DA0 RID: 7584
	public global::Hardpoint.hardpoint_type hardpointType;

	// Token: 0x04001DA1 RID: 7585
	public bool checkPlacementZones;

	// Token: 0x04001DA2 RID: 7586
	public bool forcePlaceable;

	// Token: 0x04001DA3 RID: 7587
	public bool neverGrabCarrier;

	// Token: 0x04001DA4 RID: 7588
	public global::DeployableItemDataBlock.CarrierSphereCastMode carrierSphereCastMode;

	// Token: 0x04001DA5 RID: 7589
	public global::FitRequirements fitRequirements;

	// Token: 0x04001DA6 RID: 7590
	public bool fitTestForcedUp;

	// Token: 0x0200068D RID: 1677
	private sealed class ITEM_TYPE : global::DeployableItem<global::DeployableItemDataBlock>, global::IDeployableItem, global::IHeldItem, global::IInventoryItem
	{
		// Token: 0x060036B8 RID: 14008 RVA: 0x000CCE78 File Offset: 0x000CB078
		public ITEM_TYPE(global::DeployableItemDataBlock BLOCK) : base(BLOCK)
		{
		}

		// Token: 0x17000AF9 RID: 2809
		// (get) Token: 0x060036B9 RID: 14009 RVA: 0x000CCE84 File Offset: 0x000CB084
		global::ItemDataBlock global::IInventoryItem.datablock
		{
			get
			{
				return this.datablock;
			}
		}

		// Token: 0x060036BA RID: 14010 RVA: 0x000CCE8C File Offset: 0x000CB08C
		void SetTotalModSlotCount(int count)
		{
			base.SetTotalModSlotCount(count);
		}

		// Token: 0x060036BB RID: 14011 RVA: 0x000CCE98 File Offset: 0x000CB098
		void SetUsedModSlotCount(int count)
		{
			base.SetUsedModSlotCount(count);
		}

		// Token: 0x060036BC RID: 14012 RVA: 0x000CCEA4 File Offset: 0x000CB0A4
		void AddMod(global::ItemModDataBlock mod)
		{
			base.AddMod(mod);
		}

		// Token: 0x060036BD RID: 14013 RVA: 0x000CCEB0 File Offset: 0x000CB0B0
		int FindMod(global::ItemModDataBlock mod)
		{
			return base.FindMod(mod);
		}

		// Token: 0x060036BE RID: 14014 RVA: 0x000CCEBC File Offset: 0x000CB0BC
		void OnActivate()
		{
			base.OnActivate();
		}

		// Token: 0x060036BF RID: 14015 RVA: 0x000CCEC4 File Offset: 0x000CB0C4
		void OnDeactivate()
		{
			base.OnDeactivate();
		}

		// Token: 0x060036C0 RID: 14016 RVA: 0x000CCECC File Offset: 0x000CB0CC
		global::ViewModel get_viewModelInstance()
		{
			return base.viewModelInstance;
		}

		// Token: 0x060036C1 RID: 14017 RVA: 0x000CCED4 File Offset: 0x000CB0D4
		global::ItemRepresentation get_itemRepresentation()
		{
			return base.itemRepresentation;
		}

		// Token: 0x060036C2 RID: 14018 RVA: 0x000CCEDC File Offset: 0x000CB0DC
		void set_itemRepresentation(global::ItemRepresentation value)
		{
			base.itemRepresentation = value;
		}

		// Token: 0x060036C3 RID: 14019 RVA: 0x000CCEE8 File Offset: 0x000CB0E8
		bool get_canActivate()
		{
			return base.canActivate;
		}

		// Token: 0x060036C4 RID: 14020 RVA: 0x000CCEF0 File Offset: 0x000CB0F0
		bool get_canDeactivate()
		{
			return base.canDeactivate;
		}

		// Token: 0x060036C5 RID: 14021 RVA: 0x000CCEF8 File Offset: 0x000CB0F8
		global::ItemModFlags get_modFlags()
		{
			return base.modFlags;
		}

		// Token: 0x060036C6 RID: 14022 RVA: 0x000CCF00 File Offset: 0x000CB100
		global::ItemModDataBlock[] get_itemMods()
		{
			return base.itemMods;
		}

		// Token: 0x060036C7 RID: 14023 RVA: 0x000CCF08 File Offset: 0x000CB108
		int get_totalModSlots()
		{
			return base.totalModSlots;
		}

		// Token: 0x060036C8 RID: 14024 RVA: 0x000CCF10 File Offset: 0x000CB110
		int get_usedModSlots()
		{
			return base.usedModSlots;
		}

		// Token: 0x060036C9 RID: 14025 RVA: 0x000CCF18 File Offset: 0x000CB118
		int get_freeModSlots()
		{
			return base.freeModSlots;
		}

		// Token: 0x060036CA RID: 14026 RVA: 0x000CCF20 File Offset: 0x000CB120
		bool IsDamaged()
		{
			return base.IsDamaged();
		}

		// Token: 0x060036CB RID: 14027 RVA: 0x000CCF28 File Offset: 0x000CB128
		bool IsBroken()
		{
			return base.IsBroken();
		}

		// Token: 0x060036CC RID: 14028 RVA: 0x000CCF30 File Offset: 0x000CB130
		float GetConditionPercent()
		{
			return base.GetConditionPercent();
		}

		// Token: 0x060036CD RID: 14029 RVA: 0x000CCF38 File Offset: 0x000CB138
		int AddUses(int count)
		{
			return base.AddUses(count);
		}

		// Token: 0x060036CE RID: 14030 RVA: 0x000CCF44 File Offset: 0x000CB144
		void SetUses(int count)
		{
			base.SetUses(count);
		}

		// Token: 0x060036CF RID: 14031 RVA: 0x000CCF50 File Offset: 0x000CB150
		void SetCondition(float condition)
		{
			base.SetCondition(condition);
		}

		// Token: 0x060036D0 RID: 14032 RVA: 0x000CCF5C File Offset: 0x000CB15C
		void SetMaxCondition(float condition)
		{
			base.SetMaxCondition(condition);
		}

		// Token: 0x060036D1 RID: 14033 RVA: 0x000CCF68 File Offset: 0x000CB168
		bool Consume(ref int count)
		{
			return base.Consume(ref count);
		}

		// Token: 0x060036D2 RID: 14034 RVA: 0x000CCF74 File Offset: 0x000CB174
		bool TryConditionLoss(float probability, float percentLoss)
		{
			return base.TryConditionLoss(probability, percentLoss);
		}

		// Token: 0x060036D3 RID: 14035 RVA: 0x000CCF80 File Offset: 0x000CB180
		void Serialize(global::uLink.BitStream stream)
		{
			base.Serialize(stream);
		}

		// Token: 0x060036D4 RID: 14036 RVA: 0x000CCF8C File Offset: 0x000CB18C
		void Deserialize(global::uLink.BitStream stream)
		{
			base.Deserialize(stream);
		}

		// Token: 0x060036D5 RID: 14037 RVA: 0x000CCF98 File Offset: 0x000CB198
		bool MarkDirty()
		{
			return base.MarkDirty();
		}

		// Token: 0x060036D6 RID: 14038 RVA: 0x000CCFA0 File Offset: 0x000CB1A0
		bool Save(ref global::RustProto.Item.Builder proto)
		{
			return base.Save(ref proto);
		}

		// Token: 0x060036D7 RID: 14039 RVA: 0x000CCFAC File Offset: 0x000CB1AC
		bool Load(ref global::RustProto.Item item)
		{
			return base.Load(ref item);
		}

		// Token: 0x060036D8 RID: 14040 RVA: 0x000CCFB8 File Offset: 0x000CB1B8
		int get_slot()
		{
			return base.slot;
		}

		// Token: 0x060036D9 RID: 14041 RVA: 0x000CCFC0 File Offset: 0x000CB1C0
		float get_condition()
		{
			return base.condition;
		}

		// Token: 0x060036DA RID: 14042 RVA: 0x000CCFC8 File Offset: 0x000CB1C8
		float get_maxcondition()
		{
			return base.maxcondition;
		}

		// Token: 0x060036DB RID: 14043 RVA: 0x000CCFD0 File Offset: 0x000CB1D0
		int get_uses()
		{
			return base.uses;
		}

		// Token: 0x060036DC RID: 14044 RVA: 0x000CCFD8 File Offset: 0x000CB1D8
		global::Inventory get_inventory()
		{
			return base.inventory;
		}

		// Token: 0x060036DD RID: 14045 RVA: 0x000CCFE0 File Offset: 0x000CB1E0
		bool get_dirty()
		{
			return base.dirty;
		}

		// Token: 0x060036DE RID: 14046 RVA: 0x000CCFE8 File Offset: 0x000CB1E8
		float get_lastUseTime()
		{
			return base.lastUseTime;
		}

		// Token: 0x060036DF RID: 14047 RVA: 0x000CCFF0 File Offset: 0x000CB1F0
		void set_lastUseTime(float value)
		{
			base.lastUseTime = value;
		}

		// Token: 0x060036E0 RID: 14048 RVA: 0x000CCFFC File Offset: 0x000CB1FC
		bool get_isInLocalInventory()
		{
			return base.isInLocalInventory;
		}

		// Token: 0x060036E1 RID: 14049 RVA: 0x000CD004 File Offset: 0x000CB204
		global::IDMain get_idMain()
		{
			return base.idMain;
		}

		// Token: 0x060036E2 RID: 14050 RVA: 0x000CD00C File Offset: 0x000CB20C
		global::Character get_character()
		{
			return base.character;
		}

		// Token: 0x060036E3 RID: 14051 RVA: 0x000CD014 File Offset: 0x000CB214
		global::Controller get_controller()
		{
			return base.controller;
		}

		// Token: 0x060036E4 RID: 14052 RVA: 0x000CD01C File Offset: 0x000CB21C
		global::Controllable get_controllable()
		{
			return base.controllable;
		}

		// Token: 0x060036E5 RID: 14053 RVA: 0x000CD024 File Offset: 0x000CB224
		bool get_active()
		{
			return base.active;
		}

		// Token: 0x060036E6 RID: 14054 RVA: 0x000CD02C File Offset: 0x000CB22C
		bool get_doNotSave()
		{
			return base.doNotSave;
		}
	}

	// Token: 0x0200068E RID: 1678
	public enum CarrierSphereCastMode
	{
		// Token: 0x04001DA8 RID: 7592
		Allowed,
		// Token: 0x04001DA9 RID: 7593
		AdjustedRay,
		// Token: 0x04001DAA RID: 7594
		InputRay
	}

	// Token: 0x0200068F RID: 1679
	public struct DeployPlaceResults
	{
		// Token: 0x060036E7 RID: 14055 RVA: 0x000CD034 File Offset: 0x000CB234
		public bool Valid()
		{
			return !this.falseFromAngle && !this.falseFromDeployable && !this.falseFromTerrian && !this.falseFromClose && !this.falseFromHardpoint && !this.falseFromPlacementZone && !this.falseFromFitRequirements && !this.falseFromHittingNothing && !this.falseFromStructure;
		}

		// Token: 0x060036E8 RID: 14056 RVA: 0x000CD0A8 File Offset: 0x000CB2A8
		public void PrintResults()
		{
			if (this.Valid())
			{
				global::UnityEngine.Debug.Log("VALID!");
			}
			else
			{
				string str = string.Format("Results ang:{0} dep:{1} ter:{2} close:{3} hardpoint:{4} npz:{5} fit:{6} nothin:{7} struct:{8}", new object[]
				{
					this.falseFromAngle,
					this.falseFromDeployable,
					this.falseFromTerrian,
					this.falseFromClose,
					this.falseFromHardpoint,
					this.falseFromPlacementZone,
					this.falseFromFitRequirements,
					this.falseFromHittingNothing,
					this.falseFromStructure
				});
				global::UnityEngine.Debug.Log("FAIL! - " + str);
			}
		}

		// Token: 0x04001DAB RID: 7595
		public bool falseFromDeployable;

		// Token: 0x04001DAC RID: 7596
		public bool falseFromTerrian;

		// Token: 0x04001DAD RID: 7597
		public bool falseFromClose;

		// Token: 0x04001DAE RID: 7598
		public bool falseFromHardpoint;

		// Token: 0x04001DAF RID: 7599
		public bool falseFromAngle;

		// Token: 0x04001DB0 RID: 7600
		public bool falseFromPlacementZone;

		// Token: 0x04001DB1 RID: 7601
		public bool falseFromFitRequirements;

		// Token: 0x04001DB2 RID: 7602
		public bool falseFromHittingNothing;

		// Token: 0x04001DB3 RID: 7603
		public bool falseFromStructure;
	}
}
