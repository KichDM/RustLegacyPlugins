using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Facepunch.Collections;
using Facepunch.MeshBatch;
using Magma;
using Rust;
using RustProto;
using RustProto.Helpers;
using uLink;
using UnityEngine;

// Token: 0x020007AA RID: 1962
[global::UnityEngine.RequireComponent(typeof(global::uLink.NetworkView))]
public class StructureMaster : global::IDMain, global::IServerSaveable, global::IServerSaveNotify
{
	// Token: 0x0600415B RID: 16731 RVA: 0x000EAD80 File Offset: 0x000E8F80
	protected StructureMaster(global::IDFlags idFlags) : base(idFlags)
	{
	}

	// Token: 0x0600415C RID: 16732 RVA: 0x000EAD90 File Offset: 0x000E8F90
	public StructureMaster() : this(0)
	{
	}

	// Token: 0x0600415D RID: 16733 RVA: 0x000EAD9C File Offset: 0x000E8F9C
	// Note: this type is marked as 'beforefieldinit'.
	static StructureMaster()
	{
	}

	// Token: 0x0600415E RID: 16734 RVA: 0x000EADF4 File Offset: 0x000E8FF4
	void global::IServerSaveNotify.PostLoad()
	{
		if (global::StructureMaster.prebindingExists)
		{
			global::StructureMaster.BindPreBindings();
		}
	}

	// Token: 0x17000C0A RID: 3082
	// (get) Token: 0x0600415F RID: 16735 RVA: 0x000EAE08 File Offset: 0x000E9008
	public static global::System.Collections.Generic.List<global::StructureMaster> AllStructuresWithBounds
	{
		get
		{
			return global::StructureMaster.g_Structures;
		}
	}

	// Token: 0x17000C0B RID: 3083
	// (get) Token: 0x06004160 RID: 16736 RVA: 0x000EAE10 File Offset: 0x000E9010
	public static global::System.Collections.Generic.List<global::StructureMaster> AllStructures
	{
		get
		{
			return global::StructureMaster.g_Structures;
		}
	}

	// Token: 0x06004161 RID: 16737 RVA: 0x000EAE18 File Offset: 0x000E9018
	public static global::StructureMaster[] RayTestStructures(global::UnityEngine.Ray ray)
	{
		return global::StructureMaster.RayTestStructures(ray, 10f);
	}

	// Token: 0x06004162 RID: 16738 RVA: 0x000EAE28 File Offset: 0x000E9028
	public static global::StructureMaster[] RayTestStructures(global::UnityEngine.Ray ray, float maxDistance)
	{
		global::System.Collections.Generic.List<global::System.Collections.Generic.KeyValuePair<global::StructureMaster, float>> list = new global::System.Collections.Generic.List<global::System.Collections.Generic.KeyValuePair<global::StructureMaster, float>>();
		foreach (global::StructureMaster structureMaster in global::StructureMaster.AllStructuresWithBounds)
		{
			float num = 0f;
			global::UnityEngine.Bounds bounds2;
			bool bounds = structureMaster.GetBounds(out bounds2);
			if (bounds && bounds2.IntersectRay(ray, ref num) && num <= maxDistance)
			{
				list.Add(new global::System.Collections.Generic.KeyValuePair<global::StructureMaster, float>(structureMaster, num));
			}
		}
		if (list.Count == 0)
		{
			return global::StructureMaster.Empty.array;
		}
		list.Sort((global::System.Collections.Generic.KeyValuePair<global::StructureMaster, float> x, global::System.Collections.Generic.KeyValuePair<global::StructureMaster, float> y) => x.Value.CompareTo(y.Value));
		global::StructureMaster[] array = new global::StructureMaster[list.Count];
		int num2 = 0;
		foreach (global::System.Collections.Generic.KeyValuePair<global::StructureMaster, float> keyValuePair in list)
		{
			array[num2++] = keyValuePair.Key;
		}
		return array;
	}

	// Token: 0x17000C0C RID: 3084
	// (get) Token: 0x06004163 RID: 16739 RVA: 0x000EAF6C File Offset: 0x000E916C
	public global::UnityEngine.Bounds containedBounds
	{
		get
		{
			if (this._boundsDirty)
			{
				this.RecalculateBounds();
			}
			return this._containedBounds;
		}
	}

	// Token: 0x06004164 RID: 16740 RVA: 0x000EAF88 File Offset: 0x000E9188
	public void MarkBoundsDirty()
	{
		this._boundsDirty = true;
	}

	// Token: 0x06004165 RID: 16741 RVA: 0x000EAF94 File Offset: 0x000E9194
	public void SetMaterialType(global::StructureMaster.StructureMaterialType type)
	{
		if (this._materialType == global::StructureMaster.StructureMaterialType.UNSET)
		{
			this._materialType = type;
		}
	}

	// Token: 0x06004166 RID: 16742 RVA: 0x000EAFA8 File Offset: 0x000E91A8
	public global::StructureMaster.StructureMaterialType GetMaterialType()
	{
		return this._materialType;
	}

	// Token: 0x06004167 RID: 16743 RVA: 0x000EAFB0 File Offset: 0x000E91B0
	public float GetDecayDelayForType(global::StructureMaster.StructureMaterialType type)
	{
		switch (type)
		{
		default:
			return 0f;
		case global::StructureMaster.StructureMaterialType.Wood:
			return 172800f;
		case global::StructureMaster.StructureMaterialType.Metal:
			return 345600f;
		case global::StructureMaster.StructureMaterialType.Brick:
			return 259200f;
		case global::StructureMaster.StructureMaterialType.Concrete:
			return 432000f;
		}
	}

	// Token: 0x06004168 RID: 16744 RVA: 0x000EAFFC File Offset: 0x000E91FC
	public float GetDecayTimeMaxHealthForType(global::StructureMaster.StructureMaterialType type)
	{
		switch (type)
		{
		default:
			return 60f;
		case global::StructureMaster.StructureMaterialType.Wood:
			return 21600f;
		case global::StructureMaster.StructureMaterialType.Metal:
			return 43200f;
		case global::StructureMaster.StructureMaterialType.Brick:
			return 86400f;
		case global::StructureMaster.StructureMaterialType.Concrete:
			return 259200f;
		}
	}

	// Token: 0x06004169 RID: 16745 RVA: 0x000EB048 File Offset: 0x000E9248
	public float GetDecayTimeMaxHealth()
	{
		return this.GetDecayTimeMaxHealthForType(this._materialType);
	}

	// Token: 0x0600416A RID: 16746 RVA: 0x000EB058 File Offset: 0x000E9258
	public float GetDecayDelay()
	{
		return this.GetDecayDelayForType(this._materialType);
	}

	// Token: 0x0600416B RID: 16747 RVA: 0x000EB068 File Offset: 0x000E9268
	public void Awake()
	{
		this._structureComponents = new global::System.Collections.Generic.HashSet<global::StructureComponent>();
		this._structureComponentsByPosition = new global::System.Collections.Generic.Dictionary<global::StructureComponentKey, global::StructureMaster.CompPosNode>();
		global::StructureMaster.g_Structures.Add(this);
		global::StructureMaster.Schedule.Register(this);
		this.Touched();
		global::StructureMaster.Callbacks.EnsureInstalled();
	}

	// Token: 0x0600416C RID: 16748 RVA: 0x000EB0A0 File Offset: 0x000E92A0
	public void OnDestroy()
	{
		try
		{
			global::StructureMaster.g_Structures.Remove(this);
		}
		finally
		{
			try
			{
				global::StructureMaster.Schedule.Unregister(this);
			}
			finally
			{
				base.OnDestroy();
			}
		}
	}

	// Token: 0x0600416D RID: 16749 RVA: 0x000EB108 File Offset: 0x000E9308
	public bool GetBounds(out global::UnityEngine.Bounds bounds)
	{
		bounds = this.containedBounds;
		return this._structureComponents.Count > 0;
	}

	// Token: 0x0600416E RID: 16750 RVA: 0x000EB124 File Offset: 0x000E9324
	public void AddWeightLink(global::StructureComponent me, global::StructureComponent weight)
	{
		if (this._weightOnMe.ContainsKey(me))
		{
			this._weightOnMe[me].Add(weight);
		}
		else
		{
			this._weightOnMe.Add(me, new global::System.Collections.Generic.HashSet<global::StructureComponent>());
			this._weightOnMe[me].Add(weight);
		}
		if (this._hasWeightOn.ContainsKey(weight))
		{
			this._hasWeightOn[weight].Add(me);
		}
		else
		{
			this._hasWeightOn.Add(weight, new global::System.Collections.Generic.HashSet<global::StructureComponent>());
			this._hasWeightOn[weight].Add(me);
		}
	}

	// Token: 0x0600416F RID: 16751 RVA: 0x000EB1CC File Offset: 0x000E93CC
	public global::UnityEngine.Vector3 LocalIndexRound(global::UnityEngine.Vector3 toRound)
	{
		return toRound;
	}

	// Token: 0x06004170 RID: 16752 RVA: 0x000EB1D0 File Offset: 0x000E93D0
	public void RemoveLinkForComp(global::StructureComponent comp)
	{
		if (this._weightOnMe.ContainsKey(comp))
		{
			foreach (global::StructureComponent key in this._weightOnMe[comp])
			{
				if (this._hasWeightOn[key].Contains(comp))
				{
					this._hasWeightOn[key].Remove(comp);
					if (this._hasWeightOn[key].Count == 0)
					{
						this._hasWeightOn.Remove(key);
					}
				}
			}
			this._weightOnMe.Remove(comp);
		}
		if (this._hasWeightOn.ContainsKey(comp))
		{
			foreach (global::StructureComponent key2 in this._hasWeightOn[comp])
			{
				if (this._weightOnMe[key2].Contains(comp))
				{
					this._weightOnMe[key2].Remove(comp);
					if (this._weightOnMe[key2].Count == 0)
					{
						this._weightOnMe.Remove(key2);
					}
				}
			}
			this._hasWeightOn.Remove(comp);
		}
	}

	// Token: 0x06004171 RID: 16753 RVA: 0x000EB360 File Offset: 0x000E9560
	public void GenerateLinkForComp(global::StructureComponent comp)
	{
		if (this._hasWeightOn == null)
		{
			this._hasWeightOn = new global::System.Collections.Generic.Dictionary<global::StructureComponent, global::System.Collections.Generic.HashSet<global::StructureComponent>>();
		}
		if (this._weightOnMe == null)
		{
			this._weightOnMe = new global::System.Collections.Generic.Dictionary<global::StructureComponent, global::System.Collections.Generic.HashSet<global::StructureComponent>>();
		}
		global::UnityEngine.Vector3 vector = this.LocalIndexRound(base.transform.InverseTransformPoint(comp.transform.position));
		if (comp.type == global::StructureComponent.StructureComponentType.Wall || comp.type == global::StructureComponent.StructureComponentType.Doorway || comp.type == global::StructureComponent.StructureComponentType.WindowWall)
		{
			global::UnityEngine.Vector3 worldPos = comp.transform.position + comp.transform.rotation * -global::UnityEngine.Vector3.right * 2.5f;
			global::StructureComponent componentFromPositionWorld = this.GetComponentFromPositionWorld(worldPos);
			global::UnityEngine.Vector3 worldPos2 = comp.transform.position + comp.transform.rotation * global::UnityEngine.Vector3.right * 2.5f;
			global::StructureComponent componentFromPositionWorld2 = this.GetComponentFromPositionWorld(worldPos2);
			if (componentFromPositionWorld && componentFromPositionWorld.type == global::StructureComponent.StructureComponentType.Pillar)
			{
				this.AddWeightLink(componentFromPositionWorld, comp);
			}
			if (componentFromPositionWorld2 && componentFromPositionWorld2.type == global::StructureComponent.StructureComponentType.Pillar)
			{
				this.AddWeightLink(componentFromPositionWorld2, comp);
			}
		}
		else if (comp.type == global::StructureComponent.StructureComponentType.Pillar)
		{
			global::StructureComponent structureComponent = this.CompByLocal(vector - new global::UnityEngine.Vector3(0f, global::StructureMaster.gridSpacingY, 0f), global::StructureComponent.StructureComponentType.Pillar);
			if (structureComponent)
			{
				this.AddWeightLink(structureComponent, comp);
			}
			float num = -global::StructureMaster.gridSpacingY;
			global::UnityEngine.Vector3[] array = new global::UnityEngine.Vector3[]
			{
				new global::UnityEngine.Vector3(-2.5f, num, -2.5f),
				new global::UnityEngine.Vector3(2.5f, num, 2.5f),
				new global::UnityEngine.Vector3(-2.5f, num, 2.5f),
				new global::UnityEngine.Vector3(2.5f, num, -2.5f),
				new global::UnityEngine.Vector3(2.5f, num, 0f),
				new global::UnityEngine.Vector3(-2.5f, num, 0f),
				new global::UnityEngine.Vector3(0f, num, 2.5f),
				new global::UnityEngine.Vector3(0f, num, -2.5f),
				new global::UnityEngine.Vector3(0f, num, 0f)
			};
			foreach (global::UnityEngine.Vector3 vector2 in array)
			{
				global::StructureComponent structureComponent2 = this.CompByLocal(vector + vector2, global::StructureComponent.StructureComponentType.Foundation);
				global::StructureComponent structureComponent3 = this.CompByLocal(vector + vector2, global::StructureComponent.StructureComponentType.Ceiling);
				if (structureComponent2)
				{
					this.AddWeightLink(structureComponent2, comp);
				}
				if (structureComponent3)
				{
					this.AddWeightLink(structureComponent3, comp);
				}
			}
		}
		else if (comp.type == global::StructureComponent.StructureComponentType.Ceiling)
		{
			global::UnityEngine.Vector3[] array3 = new global::UnityEngine.Vector3[]
			{
				new global::UnityEngine.Vector3(-2.5f, 0f, -2.5f),
				new global::UnityEngine.Vector3(2.5f, 0f, 2.5f),
				new global::UnityEngine.Vector3(-2.5f, 0f, 2.5f),
				new global::UnityEngine.Vector3(2.5f, 0f, -2.5f)
			};
			foreach (global::UnityEngine.Vector3 vector3 in array3)
			{
				global::StructureComponent structureComponent4 = this.CompByLocal(vector + vector3, global::StructureComponent.StructureComponentType.Pillar);
				if (structureComponent4 != null)
				{
					this.AddWeightLink(structureComponent4, comp);
				}
			}
		}
		else if (comp.type == global::StructureComponent.StructureComponentType.Ramp)
		{
			global::StructureComponent structureComponent5 = this.CompByLocal(vector - new global::UnityEngine.Vector3(0f, global::StructureMaster.gridSpacingY, 0f));
			if (structureComponent5)
			{
				this.AddWeightLink(structureComponent5, comp);
			}
		}
		else if (comp.type == global::StructureComponent.StructureComponentType.Foundation)
		{
			global::StructureComponent structureComponent6 = this.CompByLocal(vector - new global::UnityEngine.Vector3(0f, global::StructureMaster.gridSpacingY, 0f), global::StructureComponent.StructureComponentType.Foundation);
			if (structureComponent6)
			{
				if (structureComponent6 != comp)
				{
					this.AddWeightLink(structureComponent6, comp);
				}
				else
				{
					global::UnityEngine.Debug.Log("MAJOR FUCKUP");
				}
			}
		}
		else if (comp.type == global::StructureComponent.StructureComponentType.Stairs)
		{
			global::UnityEngine.Vector3[] array5 = new global::UnityEngine.Vector3[]
			{
				new global::UnityEngine.Vector3(-2.5f, 0f, -2.5f),
				new global::UnityEngine.Vector3(2.5f, 0f, 2.5f),
				new global::UnityEngine.Vector3(-2.5f, 0f, 2.5f),
				new global::UnityEngine.Vector3(2.5f, 0f, -2.5f)
			};
			foreach (global::UnityEngine.Vector3 vector4 in array5)
			{
				global::StructureComponent structureComponent7 = this.CompByLocal(vector + vector4, global::StructureComponent.StructureComponentType.Pillar);
				if (structureComponent7 != null && structureComponent7.type == global::StructureComponent.StructureComponentType.Pillar)
				{
					this.AddWeightLink(structureComponent7, comp);
				}
			}
		}
	}

	// Token: 0x06004172 RID: 16754 RVA: 0x000EB900 File Offset: 0x000E9B00
	public void GenerateLinks()
	{
		this._hasWeightOn = new global::System.Collections.Generic.Dictionary<global::StructureComponent, global::System.Collections.Generic.HashSet<global::StructureComponent>>();
		this._weightOnMe = new global::System.Collections.Generic.Dictionary<global::StructureComponent, global::System.Collections.Generic.HashSet<global::StructureComponent>>();
		foreach (global::StructureComponent comp in this._structureComponents)
		{
			this.GenerateLinkForComp(comp);
		}
	}

	// Token: 0x06004173 RID: 16755 RVA: 0x000EB97C File Offset: 0x000E9B7C
	public bool CheckIsWall(global::StructureComponent wallTest)
	{
		return wallTest != null && wallTest.IsWallType();
	}

	// Token: 0x06004174 RID: 16756 RVA: 0x000EB994 File Offset: 0x000E9B94
	public bool ComponentCarryingWeight(global::StructureComponent comp)
	{
		return this._weightOnMe != null && this._weightOnMe.ContainsKey(comp) && this._weightOnMe[comp].Count > 0;
	}

	// Token: 0x17000C0D RID: 3085
	// (get) Token: 0x06004175 RID: 16757 RVA: 0x000EB9D8 File Offset: 0x000E9BD8
	// (set) Token: 0x06004176 RID: 16758 RVA: 0x000EB9E0 File Offset: 0x000E9BE0
	private static float decayRate
	{
		get
		{
			return global::StructureMaster._decayRate;
		}
		set
		{
			global::StructureMaster._decayRate = value;
		}
	}

	// Token: 0x06004177 RID: 16759 RVA: 0x000EB9E8 File Offset: 0x000E9BE8
	public void Touched()
	{
		this._decayDelayRemaining = this.GetDecayDelay();
		global::StructureMaster.Schedule.Reschedule(this);
	}

	// Token: 0x06004178 RID: 16760 RVA: 0x000EB9FC File Offset: 0x000E9BFC
	protected global::StructureMaster.DecayStatus DoDecay()
	{
		float num = global::UnityEngine.Time.time - this._lastDecayTime;
		this._lastDecayTime = global::UnityEngine.Time.time;
		if (global::StructureMaster.decayRate <= 0f)
		{
			return global::StructureMaster.DecayStatus.Delaying;
		}
		this._decayDelayRemaining -= num;
		num = -this._decayDelayRemaining;
		if (this._decayDelayRemaining < 0f)
		{
			this._decayDelayRemaining = 0f;
		}
		if (num <= 0f)
		{
			return global::StructureMaster.DecayStatus.Delaying;
		}
		this._pentUpDecayTime += num;
		float decayTimeMaxHealth = this.GetDecayTimeMaxHealth();
		float num2 = this._pentUpDecayTime / decayTimeMaxHealth;
		if (num2 < global::structure.minpercentdmg)
		{
			return global::StructureMaster.DecayStatus.PentUpDecay;
		}
		this._pentUpDecayTime = 0f;
		foreach (global::StructureComponent structureComponent in this._structureComponents)
		{
			global::TakeDamage component = structureComponent.GetComponent<global::TakeDamage>();
			if (component)
			{
				float num3 = component.maxHealth * num2 * global::UnityEngine.Random.Range(0.75f, 1.25f) * global::StructureMaster.decayRate;
				num3 = global::Magma.Hooks.EntityDecay(structureComponent, num3);
				if (structureComponent.type == global::StructureComponent.StructureComponentType.Wall || structureComponent.type == global::StructureComponent.StructureComponentType.Doorway || structureComponent.type == global::StructureComponent.StructureComponentType.WindowWall)
				{
					global::UnityEngine.Ray ray;
					ray..ctor(structureComponent.transform.position + new global::UnityEngine.Vector3(0f, 2.5f, 0f), structureComponent.transform.forward);
					global::UnityEngine.Ray ray2;
					ray2..ctor(structureComponent.transform.position + new global::UnityEngine.Vector3(0f, 2.5f, 0f), -structureComponent.transform.forward);
					bool flag = false;
					global::UnityEngine.RaycastHit raycastHit;
					bool flag2;
					global::Facepunch.MeshBatch.MeshBatchInstance meshBatchInstance;
					if (global::Facepunch.MeshBatch.MeshBatchPhysics.Raycast(ray, ref raycastHit, 25f, ref flag2, ref meshBatchInstance))
					{
						global::IDMain idmain = (!flag2) ? global::IDBase.GetMain(raycastHit.collider.gameObject) : meshBatchInstance.idMain;
						global::UnityEngine.RaycastHit raycastHit2;
						if (idmain && (idmain is global::StructureComponent || idmain.CompareTag("Door")) && global::Facepunch.MeshBatch.MeshBatchPhysics.Raycast(ray2, ref raycastHit2, 25f, ref flag2, ref meshBatchInstance))
						{
							idmain = ((!flag2) ? global::IDBase.GetMain(raycastHit2.collider.gameObject) : meshBatchInstance.idMain);
							if (idmain && (idmain is global::StructureComponent || idmain.CompareTag("Door")))
							{
								flag = true;
							}
						}
					}
					if (flag)
					{
						num3 *= 0.2f;
					}
					global::TakeDamage.HurtSelf(structureComponent, num3, null);
				}
				else if (structureComponent.type == global::StructureComponent.StructureComponentType.Pillar)
				{
					if (!this.ComponentCarryingWeight(structureComponent))
					{
						global::TakeDamage.HurtSelf(structureComponent, num3, null);
					}
				}
				else if (structureComponent.type == global::StructureComponent.StructureComponentType.Ceiling)
				{
					if (!this.ComponentCarryingWeight(structureComponent))
					{
						global::TakeDamage.HurtSelf(structureComponent, num3, null);
					}
				}
				else if (structureComponent.type == global::StructureComponent.StructureComponentType.Foundation)
				{
					if (!this.ComponentCarryingWeight(structureComponent))
					{
						global::TakeDamage.HurtSelf(structureComponent, num3, null);
					}
				}
				else
				{
					global::TakeDamage.HurtSelf(structureComponent, num3, null);
				}
			}
		}
		return global::StructureMaster.DecayStatus.Decaying;
	}

	// Token: 0x06004179 RID: 16761 RVA: 0x000EBD64 File Offset: 0x000E9F64
	public static global::UnityEngine.Vector3 SnapToGrid(global::UnityEngine.Transform gridCenter, global::UnityEngine.Vector3 desiredPosition, bool useHeight)
	{
		global::UnityEngine.Vector3 vector = gridCenter.InverseTransformPoint(desiredPosition);
		vector.x = global::UnityEngine.Mathf.Round(vector.x / global::StructureMaster.gridSpacingXZ) * global::StructureMaster.gridSpacingXZ;
		vector.z = global::UnityEngine.Mathf.Round(vector.z / global::StructureMaster.gridSpacingXZ) * global::StructureMaster.gridSpacingXZ;
		if (useHeight)
		{
			vector.y = global::UnityEngine.Mathf.Round(vector.y / global::StructureMaster.gridSpacingY) * global::StructureMaster.gridSpacingY;
		}
		vector = gridCenter.TransformPoint(vector);
		return vector;
	}

	// Token: 0x0600417A RID: 16762 RVA: 0x000EBDE8 File Offset: 0x000E9FE8
	public bool AddCompPositionEntry(global::StructureComponent comp)
	{
		global::UnityEngine.Vector3 v = this.LocalIndexRound(base.transform.InverseTransformPoint(comp.transform.position));
		global::StructureComponentKey key = new global::StructureComponentKey(v);
		global::StructureMaster.CompPosNode compPosNode;
		if (this._structureComponentsByPosition.TryGetValue(key, out compPosNode))
		{
			compPosNode.Add(comp);
		}
		else
		{
			compPosNode = new global::StructureMaster.CompPosNode();
			compPosNode.Add(comp);
			this._structureComponentsByPosition.Add(key, compPosNode);
		}
		return true;
	}

	// Token: 0x0600417B RID: 16763 RVA: 0x000EBE54 File Offset: 0x000EA054
	public bool RemoveCompPositionEntry(global::StructureComponent comp)
	{
		global::UnityEngine.Vector3 v = this.LocalIndexRound(base.transform.InverseTransformPoint(comp.transform.position));
		global::StructureComponentKey key = new global::StructureComponentKey(v);
		global::StructureMaster.CompPosNode compPosNode;
		if (this._structureComponentsByPosition.TryGetValue(key, out compPosNode))
		{
			compPosNode.Remove(comp);
			if (compPosNode.GetAny())
			{
				this._structureComponentsByPosition.Remove(key);
			}
			return true;
		}
		return false;
	}

	// Token: 0x0600417C RID: 16764 RVA: 0x000EBEC0 File Offset: 0x000EA0C0
	public global::StructureComponent CompByLocal(global::UnityEngine.Vector3 localPos)
	{
		global::StructureComponentKey key = new global::StructureComponentKey(localPos);
		global::StructureMaster.CompPosNode compPosNode;
		if (this._structureComponentsByPosition.TryGetValue(key, out compPosNode))
		{
			return compPosNode.GetAny();
		}
		return null;
	}

	// Token: 0x0600417D RID: 16765 RVA: 0x000EBEF0 File Offset: 0x000EA0F0
	public global::StructureComponent CompByLocal(global::UnityEngine.Vector3 localPos, global::StructureComponent.StructureComponentType type)
	{
		global::StructureComponentKey key = new global::StructureComponentKey(localPos);
		global::StructureMaster.CompPosNode compPosNode;
		if (this._structureComponentsByPosition.TryGetValue(key, out compPosNode))
		{
			return compPosNode.GetType(type);
		}
		return null;
	}

	// Token: 0x0600417E RID: 16766 RVA: 0x000EBF24 File Offset: 0x000EA124
	public void TryGenerateLOD()
	{
	}

	// Token: 0x0600417F RID: 16767 RVA: 0x000EBF28 File Offset: 0x000EA128
	public void GenerateLOD()
	{
		base.GetComponent<global::CombineChildren>().DoCombine();
	}

	// Token: 0x06004180 RID: 16768 RVA: 0x000EBF38 File Offset: 0x000EA138
	internal void AppendStructureComponent(global::StructureComponent comp)
	{
		this.AppendStructureComponent(comp, false);
	}

	// Token: 0x06004181 RID: 16769 RVA: 0x000EBF44 File Offset: 0x000EA144
	protected void AppendStructureComponent(global::StructureComponent comp, bool nobind)
	{
		if (comp.type == global::StructureComponent.StructureComponentType.Foundation && this._materialType == global::StructureMaster.StructureMaterialType.UNSET)
		{
			this.SetMaterialType(comp.GetMaterialType());
		}
		this._structureComponents.Add(comp);
		this.AddCompPositionEntry(comp);
		this.GenerateLinkForComp(comp);
		this.RecalculateStructureLinks();
		this.MarkBoundsDirty();
		if (!nobind)
		{
			try
			{
				comp.OnOwnedByMasterStructure(this);
			}
			catch (global::System.Exception ex)
			{
				global::UnityEngine.Debug.LogError(ex);
			}
		}
		if (this.meshBatchTargetPhysical)
		{
			foreach (global::Facepunch.MeshBatch.MeshBatchInstance meshBatchInstance in comp.GetComponentsInChildren<global::Facepunch.MeshBatch.MeshBatchInstance>(true))
			{
				meshBatchInstance.allowedPhysically = true;
				meshBatchInstance.physicalTarget = this.meshBatchTargetPhysical;
			}
		}
	}

	// Token: 0x06004182 RID: 16770 RVA: 0x000EC01C File Offset: 0x000EA21C
	[global::System.Obsolete("NOT OBSOLETE BUT.. This should only be called from datablocks or otherwise immediately after the component is instantiated - and only once", false)]
	public void AddStructureComponent(global::StructureComponent comp)
	{
		this.AppendStructureComponent(comp, true);
		global::NetCull.RPC<global::uLink.NetworkViewID>(comp, "StructureComponent:SMSet", 5, base.networkViewID);
		try
		{
			comp.OnOwnedByMasterStructure(this);
		}
		catch (global::System.Exception ex)
		{
			global::UnityEngine.Debug.LogError(ex);
		}
	}

	// Token: 0x06004183 RID: 16771 RVA: 0x000EC078 File Offset: 0x000EA278
	private global::System.Collections.IEnumerator CheckNextFrameAnyComponents()
	{
		yield return null;
		if (this._structureComponents.Count == 0)
		{
			global::NetCull.Destroy(base.gameObject);
		}
		yield break;
	}

	// Token: 0x06004184 RID: 16772 RVA: 0x000EC094 File Offset: 0x000EA294
	public bool RemoveComponent(global::StructureComponent comp)
	{
		this.RemoveCompPositionEntry(comp);
		this.RemoveLinkForComp(comp);
		if (this._structureComponents.Remove(comp))
		{
			comp.ClearMaster();
			if (this._structureComponents.Count == 0)
			{
				base.StartCoroutine("CheckNextFrameAnyComponents");
			}
		}
		this.RecalculateStructureLinks();
		this.MarkBoundsDirty();
		return true;
	}

	// Token: 0x06004185 RID: 16773 RVA: 0x000EC0F0 File Offset: 0x000EA2F0
	public void RecalculateBounds()
	{
		this._containedBounds = new global::UnityEngine.Bounds(base.transform.position, global::UnityEngine.Vector3.zero);
		foreach (global::StructureComponent structureComponent in this._structureComponents)
		{
			this._containedBounds.Encapsulate(structureComponent.collider.bounds);
		}
		this.RecalculateStructureSize();
		this._containedBounds.Expand(5f);
		this._boundsDirty = false;
	}

	// Token: 0x06004186 RID: 16774 RVA: 0x000EC1A0 File Offset: 0x000EA3A0
	public void RecalculateStructureSize()
	{
		global::UnityEngine.Bounds localBounds;
		localBounds..ctor(global::UnityEngine.Vector3.zero, global::UnityEngine.Vector3.zero);
		foreach (global::StructureComponent structureComponent in this._structureComponents)
		{
			if (structureComponent.type == global::StructureComponent.StructureComponentType.Foundation)
			{
				global::UnityEngine.Vector3 vector = base.transform.InverseTransformPoint(structureComponent.transform.position);
				localBounds.Encapsulate(vector);
			}
			else if (structureComponent.type == global::StructureComponent.StructureComponentType.Pillar)
			{
			}
		}
		localBounds.Expand(global::StructureMaster.gridSpacingXZ * 2f);
		this._localBounds = localBounds;
	}

	// Token: 0x06004187 RID: 16775 RVA: 0x000EC264 File Offset: 0x000EA464
	public void GetStructureSize(out int maxWidth, out int maxLength, out int maxHeight)
	{
		global::UnityEngine.Bounds containedBounds = this.containedBounds;
		float num = this._localBounds.size.x / (global::StructureMaster.gridSpacingXZ * 2f);
		float num2 = this._localBounds.size.z / (global::StructureMaster.gridSpacingXZ * 2f);
		float num3 = this._localBounds.size.y / global::StructureMaster.gridSpacingY;
		maxWidth = global::UnityEngine.Mathf.RoundToInt(num);
		maxLength = global::UnityEngine.Mathf.RoundToInt(num2);
		maxHeight = global::UnityEngine.Mathf.RoundToInt(num3);
	}

	// Token: 0x06004188 RID: 16776 RVA: 0x000EC2F0 File Offset: 0x000EA4F0
	public void RecalculateStructureLinks()
	{
	}

	// Token: 0x06004189 RID: 16777 RVA: 0x000EC2F4 File Offset: 0x000EA4F4
	public void OnDrawGizmos()
	{
		global::UnityEngine.Gizmos.color = global::UnityEngine.Color.white;
		global::UnityEngine.Gizmos.DrawWireCube(this.containedBounds.center, this.containedBounds.size);
	}

	// Token: 0x0600418A RID: 16778 RVA: 0x000EC32C File Offset: 0x000EA52C
	public void OnDrawGizmosSelected()
	{
		global::UnityEngine.Gizmos.color = global::UnityEngine.Color.yellow;
		global::UnityEngine.Gizmos.DrawWireCube(this.containedBounds.center, this.containedBounds.size);
		if (this._hasWeightOn == null)
		{
			return;
		}
		foreach (global::System.Collections.Generic.KeyValuePair<global::StructureComponent, global::System.Collections.Generic.HashSet<global::StructureComponent>> keyValuePair in this._hasWeightOn)
		{
			if (keyValuePair.Key)
			{
				global::UnityEngine.Gizmos.color = global::UnityEngine.Color.gray;
				global::UnityEngine.Gizmos.DrawWireSphere(keyValuePair.Key.transform.position + new global::UnityEngine.Vector3(0f, 0.25f, 0f), 0.25f);
				global::UnityEngine.Gizmos.color = global::UnityEngine.Color.green;
				foreach (global::StructureComponent structureComponent in keyValuePair.Value)
				{
					if (structureComponent)
					{
						global::UnityEngine.Gizmos.DrawLine(keyValuePair.Key.transform.position, structureComponent.transform.position);
					}
				}
			}
		}
	}

	// Token: 0x0600418B RID: 16779 RVA: 0x000EC4A0 File Offset: 0x000EA6A0
	public global::StructureComponent GetComponentFromPositionWorld(global::UnityEngine.Vector3 worldPos)
	{
		global::UnityEngine.Vector3 localPos = this.LocalIndexRound(base.transform.InverseTransformPoint(worldPos));
		return this.CompByLocal(localPos);
	}

	// Token: 0x0600418C RID: 16780 RVA: 0x000EC4C8 File Offset: 0x000EA6C8
	public global::StructureComponent GetComponentFromPositionLocal(global::UnityEngine.Vector3 localPos)
	{
		foreach (global::StructureComponent structureComponent in this._structureComponents)
		{
			if (global::UnityEngine.Vector3.Distance(localPos, base.transform.InverseTransformPoint(structureComponent.transform.position)) < 0.01f)
			{
				return structureComponent;
			}
		}
		return null;
	}

	// Token: 0x0600418D RID: 16781 RVA: 0x000EC558 File Offset: 0x000EA758
	public bool Approx(float a, float b)
	{
		return (double)global::UnityEngine.Mathf.Abs(a - b) < 0.001;
	}

	// Token: 0x0600418E RID: 16782 RVA: 0x000EC574 File Offset: 0x000EA774
	public bool IsValidFoundationSpot(global::UnityEngine.Vector3 searchPos)
	{
		if (this._structureComponents.Count == 0)
		{
			return true;
		}
		foreach (global::StructureComponent structureComponent in this._structureComponents)
		{
			if (structureComponent.type == global::StructureComponent.StructureComponentType.Foundation)
			{
				global::UnityEngine.Vector3 vector = structureComponent.transform.InverseTransformPoint(searchPos);
				bool flag = ((this.Approx(global::UnityEngine.Mathf.Abs(vector.x), 5f) && this.Approx(vector.z, 0f)) || (this.Approx(global::UnityEngine.Mathf.Abs(vector.z), 5f) && this.Approx(vector.x, 0f))) && this.Approx(vector.y, 0f);
				bool flag2 = false;
				global::UnityEngine.Vector3 vector2;
				global::UnityEngine.Vector3 vector3;
				if (global::TransformHelpers.GetGroundInfoTerrainOnly(searchPos + new global::UnityEngine.Vector3(0f, 3.5f, 0f), 3.5f, out vector2, out vector3))
				{
					flag2 = true;
				}
				if (flag && !flag2)
				{
					flag = false;
				}
				bool flag3 = false;
				if (flag || flag3)
				{
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x0600418F RID: 16783 RVA: 0x000EC6E0 File Offset: 0x000EA8E0
	public bool GetFoundationForPoint(global::UnityEngine.Vector3 searchPos)
	{
		foreach (global::StructureComponent structureComponent in this._structureComponents)
		{
			if (structureComponent.type == global::StructureComponent.StructureComponentType.Foundation)
			{
				global::UnityEngine.Vector3 vector = structureComponent.transform.InverseTransformPoint(searchPos);
				if (global::UnityEngine.Mathf.Abs(vector.x) <= 2.51f && global::UnityEngine.Mathf.Abs(vector.z) <= 2.51f && this.Approx(vector.y, 4f))
				{
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x06004190 RID: 16784 RVA: 0x000EC7AC File Offset: 0x000EA9AC
	public void SetupCreator(global::Controllable controllable)
	{
		global::uLink.NetworkPlayer owner = controllable.networkView.owner;
		global::NetUser netUser = global::NetUser.Find(owner);
		if (netUser != null)
		{
			this.creatorID = netUser.user.Userid;
			this.ownerID = netUser.user.Userid;
			this.CacheCreator();
		}
	}

	// Token: 0x06004191 RID: 16785 RVA: 0x000EC7FC File Offset: 0x000EA9FC
	public void CacheCreator()
	{
		global::NetEntityID entID = global::NetEntityID.Get(this);
		if (this.ownerBuffered)
		{
			global::NetCull.RemoveRPCsByName(entID, "GetOwnerInfo");
		}
		this.ownerBuffered = true;
		global::NetCull.RPC<ulong, ulong>(entID, "GetOwnerInfo", 0xE, this.creatorID, this.ownerID);
	}

	// Token: 0x06004192 RID: 16786 RVA: 0x000EC848 File Offset: 0x000EAA48
	[global::UnityEngine.RPC]
	public void GetOwnerInfo(ulong creator, ulong owner)
	{
	}

	// Token: 0x06004193 RID: 16787 RVA: 0x000EC84C File Offset: 0x000EAA4C
	public int GetMasterID()
	{
		return global::StructureMaster.g_Structures.IndexOf(this);
	}

	// Token: 0x06004194 RID: 16788 RVA: 0x000EC85C File Offset: 0x000EAA5C
	public void WriteObjectSave(ref global::RustProto.SavedObject.Builder saveobj)
	{
		using (global::RustProto.Helpers.Recycler<global::RustProto.objectStructMaster, global::RustProto.objectStructMaster.Builder> recycler = global::RustProto.objectStructMaster.Recycler())
		{
			global::RustProto.objectStructMaster.Builder builder = recycler.OpenBuilder();
			builder.SetID(this.GetMasterID());
			builder.SetDecayDelay(this._decayDelayRemaining);
			builder.SetCreatorID(this.creatorID);
			builder.SetOwnerID(this.ownerID);
			saveobj.SetStructMaster(builder);
		}
	}

	// Token: 0x06004195 RID: 16789 RVA: 0x000EC8E4 File Offset: 0x000EAAE4
	public void ReadObjectSave(ref global::RustProto.SavedObject saveobj)
	{
		if (!saveobj.HasStructMaster)
		{
			return;
		}
		global::RustProto.objectStructMaster structMaster = saveobj.StructMaster;
		global::StructureMaster.GetPrebinding(saveobj.StructMaster.ID).master = this;
		if (structMaster.HasDecayDelay)
		{
			this._decayDelayRemaining = structMaster.DecayDelay;
		}
		if (structMaster.HasOwnerID)
		{
			this.ownerID = structMaster.OwnerID;
		}
		if (structMaster.HasCreatorID)
		{
			this.creatorID = structMaster.CreatorID;
		}
	}

	// Token: 0x06004196 RID: 16790 RVA: 0x000EC964 File Offset: 0x000EAB64
	private static void ClearLoadData()
	{
		global::StructureMaster.sv_load_prebinding.Clear();
		global::StructureMaster.prebindingExists = false;
	}

	// Token: 0x06004197 RID: 16791 RVA: 0x000EC978 File Offset: 0x000EAB78
	private static global::StructureMaster.PreBinding GetPrebinding(int masterID)
	{
		global::StructureMaster.PreBinding result;
		if (!global::StructureMaster.sv_load_prebinding.TryGetValue(masterID, out result))
		{
			result = (global::StructureMaster.sv_load_prebinding[masterID] = new global::StructureMaster.PreBinding());
		}
		global::StructureMaster.prebindingExists = true;
		return result;
	}

	// Token: 0x06004198 RID: 16792 RVA: 0x000EC9B0 File Offset: 0x000EABB0
	public static void BindChild(int masterID, int childID, global::StructureComponent child)
	{
		global::StructureMaster.PreBinding prebinding = global::StructureMaster.GetPrebinding(masterID);
		prebinding.components[childID] = child;
	}

	// Token: 0x06004199 RID: 16793 RVA: 0x000EC9D4 File Offset: 0x000EABD4
	private static void BindPreBindings()
	{
		try
		{
			int[] array = null;
			global::StructureComponent[] array2 = null;
			int num = 0;
			foreach (global::StructureMaster.PreBinding preBinding in global::StructureMaster.sv_load_prebinding.Values)
			{
				if (preBinding.master)
				{
					int count = preBinding.components.Count;
					if (count > num)
					{
						num = count;
						array = new int[count];
						array2 = new global::StructureComponent[count];
					}
					else if (count <= 0)
					{
						continue;
					}
					int num2 = 0;
					foreach (global::System.Collections.Generic.KeyValuePair<int, global::StructureComponent> keyValuePair in preBinding.components)
					{
						array[num2] = keyValuePair.Key;
						array2[num2] = keyValuePair.Value;
						num2++;
					}
					global::System.Array.Sort<int, global::StructureComponent>(array, array2, 0, count);
					for (int i = 0; i < count; i++)
					{
						try
						{
							preBinding.master.AddStructureComponent(array2[i]);
						}
						catch (global::System.Exception ex)
						{
							global::UnityEngine.Debug.LogError(ex, preBinding.master);
						}
					}
				}
			}
		}
		finally
		{
			global::StructureMaster.prebindingExists = false;
			global::StructureMaster.sv_load_prebinding.Clear();
		}
		global::StructureMaster.linkCalcStartTime = global::UnityEngine.Time.realtimeSinceStartup;
		foreach (global::StructureMaster structureMaster in global::StructureMaster.g_Structures)
		{
		}
	}

	// Token: 0x0600419A RID: 16794 RVA: 0x000ECBE8 File Offset: 0x000EADE8
	public int FindComponentID(global::StructureComponent component)
	{
		int num = 0;
		foreach (global::StructureComponent structureComponent in this._structureComponents)
		{
			if (!(structureComponent != component))
			{
				return num;
			}
			num++;
		}
		return -1;
	}

	// Token: 0x0600419B RID: 16795 RVA: 0x000ECC68 File Offset: 0x000EAE68
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private static int <RayTestStructures>m__15(global::System.Collections.Generic.KeyValuePair<global::StructureMaster, float> x, global::System.Collections.Generic.KeyValuePair<global::StructureMaster, float> y)
	{
		return x.Value.CompareTo(y.Value);
	}

	// Token: 0x0400221C RID: 8732
	public static global::UnityEngine.Vector3 foundationSize = new global::UnityEngine.Vector3(5f, 0.5f, 5f);

	// Token: 0x0400221D RID: 8733
	public static float gridSpacingXZ = 2.5f;

	// Token: 0x0400221E RID: 8734
	public static float gridSpacingY = 4f;

	// Token: 0x0400221F RID: 8735
	[global::System.NonSerialized]
	private bool ownerBuffered;

	// Token: 0x04002220 RID: 8736
	[global::UnityEngine.SerializeField]
	private global::Facepunch.MeshBatch.MeshBatchGraphicalTarget meshBatchTargetGraphical;

	// Token: 0x04002221 RID: 8737
	[global::UnityEngine.SerializeField]
	private global::Facepunch.MeshBatch.MeshBatchPhysicalTarget meshBatchTargetPhysical;

	// Token: 0x04002222 RID: 8738
	private static global::System.Collections.Generic.List<global::StructureMaster> g_Structures = new global::System.Collections.Generic.List<global::StructureMaster>();

	// Token: 0x04002223 RID: 8739
	protected global::System.Collections.Generic.HashSet<global::StructureComponent> _structureComponents;

	// Token: 0x04002224 RID: 8740
	protected global::System.Collections.Generic.List<global::UnityEngine.Vector3> _foundationPoints;

	// Token: 0x04002225 RID: 8741
	private bool _boundsDirty = true;

	// Token: 0x04002226 RID: 8742
	private global::UnityEngine.Bounds _containedBounds;

	// Token: 0x04002227 RID: 8743
	private global::UnityEngine.Vector3 _buildingSize;

	// Token: 0x04002228 RID: 8744
	private global::UnityEngine.Bounds _localBounds;

	// Token: 0x04002229 RID: 8745
	protected int nextID;

	// Token: 0x0400222A RID: 8746
	protected float _lastDecayTime;

	// Token: 0x0400222B RID: 8747
	private float _decayDelayRemaining;

	// Token: 0x0400222C RID: 8748
	private float _pentUpDecayTime;

	// Token: 0x0400222D RID: 8749
	public ulong creatorID;

	// Token: 0x0400222E RID: 8750
	public ulong ownerID;

	// Token: 0x0400222F RID: 8751
	protected global::StructureMaster.StructureMaterialType _materialType;

	// Token: 0x04002230 RID: 8752
	[global::System.NonSerialized]
	private global::Facepunch.Collections.StaticQueue<global::StructureMaster.Schedule, global::StructureMaster>.Entry regkey;

	// Token: 0x04002231 RID: 8753
	protected global::System.Collections.Generic.Dictionary<global::StructureComponent, global::System.Collections.Generic.HashSet<global::StructureComponent>> _hasWeightOn;

	// Token: 0x04002232 RID: 8754
	protected global::System.Collections.Generic.Dictionary<global::StructureComponent, global::System.Collections.Generic.HashSet<global::StructureComponent>> _weightOnMe;

	// Token: 0x04002233 RID: 8755
	protected global::System.Collections.Generic.Dictionary<global::StructureComponentKey, global::StructureMaster.CompPosNode> _structureComponentsByPosition;

	// Token: 0x04002234 RID: 8756
	private static float _decayRate = 1f;

	// Token: 0x04002235 RID: 8757
	public static float linkCalcStartTime;

	// Token: 0x04002236 RID: 8758
	private static readonly global::System.Collections.Generic.Dictionary<int, global::StructureMaster.PreBinding> sv_load_prebinding = new global::System.Collections.Generic.Dictionary<int, global::StructureMaster.PreBinding>();

	// Token: 0x04002237 RID: 8759
	private static bool prebindingExists;

	// Token: 0x04002238 RID: 8760
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private static global::System.Comparison<global::System.Collections.Generic.KeyValuePair<global::StructureMaster, float>> <>f__am$cache1C;

	// Token: 0x020007AB RID: 1963
	private static class Empty
	{
		// Token: 0x0600419C RID: 16796 RVA: 0x000ECC8C File Offset: 0x000EAE8C
		// Note: this type is marked as 'beforefieldinit'.
		static Empty()
		{
		}

		// Token: 0x04002239 RID: 8761
		public static readonly global::StructureMaster[] array = new global::StructureMaster[0];
	}

	// Token: 0x020007AC RID: 1964
	[global::System.Serializable]
	public enum StructureMaterialType
	{
		// Token: 0x0400223B RID: 8763
		UNSET,
		// Token: 0x0400223C RID: 8764
		Wood,
		// Token: 0x0400223D RID: 8765
		Metal,
		// Token: 0x0400223E RID: 8766
		Brick,
		// Token: 0x0400223F RID: 8767
		Concrete
	}

	// Token: 0x020007AD RID: 1965
	private static class Callbacks
	{
		// Token: 0x0600419D RID: 16797 RVA: 0x000ECC9C File Offset: 0x000EAE9C
		static Callbacks()
		{
			global::NetCull.Callbacks.beforeEveryUpdate += global::StructureMaster.Callbacks.RunDecayThink;
		}

		// Token: 0x0600419E RID: 16798 RVA: 0x000ECCB0 File Offset: 0x000EAEB0
		private static void RunDecayThink()
		{
			try
			{
				global::StructureMaster.Schedule.Process(global::structure.maxframeattempt);
			}
			catch (global::System.Exception ex)
			{
				global::UnityEngine.Debug.LogException(ex);
			}
		}

		// Token: 0x0600419F RID: 16799 RVA: 0x000ECCF4 File Offset: 0x000EAEF4
		public static void EnsureInstalled()
		{
		}
	}

	// Token: 0x020007AE RID: 1966
	private sealed class Schedule : global::Facepunch.Collections.StaticQueue<global::StructureMaster.Schedule, global::StructureMaster>
	{
		// Token: 0x060041A0 RID: 16800 RVA: 0x000ECCF8 File Offset: 0x000EAEF8
		public Schedule()
		{
		}

		// Token: 0x060041A1 RID: 16801 RVA: 0x000ECD00 File Offset: 0x000EAF00
		public static bool Register(global::StructureMaster master)
		{
			return global::Facepunch.Collections.StaticQueue<global::StructureMaster.Schedule, global::StructureMaster>.enqueue(master, ref master.regkey);
		}

		// Token: 0x060041A2 RID: 16802 RVA: 0x000ECD18 File Offset: 0x000EAF18
		public static bool Unregister(global::StructureMaster master)
		{
			return global::Facepunch.Collections.StaticQueue<global::StructureMaster.Schedule, global::StructureMaster>.dequeue(master, ref master.regkey);
		}

		// Token: 0x060041A3 RID: 16803 RVA: 0x000ECD28 File Offset: 0x000EAF28
		public static void Reschedule(global::StructureMaster master)
		{
			global::Facepunch.Collections.StaticQueue<global::StructureMaster.Schedule, global::StructureMaster>.requeue(master, ref master.regkey);
		}

		// Token: 0x060041A4 RID: 16804 RVA: 0x000ECD38 File Offset: 0x000EAF38
		public static void Process(int maxCount = 1)
		{
			if (global::Rust.Globals.isLoading)
			{
				return;
			}
			try
			{
				global::Facepunch.Collections.StaticQueue<global::StructureMaster.Schedule, global::StructureMaster>.iterator iterator = new global::Facepunch.Collections.StaticQueue<global::StructureMaster.Schedule, global::StructureMaster>.iterator(maxCount);
				int num = 0;
				global::StructureMaster structureMaster;
				bool flag = iterator.Start(out structureMaster);
				while (flag)
				{
					flag = ((!structureMaster || !iterator.Validate(ref structureMaster.regkey)) ? iterator.MissingNext(out structureMaster) : global::StructureMaster.Schedule.ThinkInstance(ref iterator, ref structureMaster, ref structureMaster.regkey, ref num));
				}
			}
			finally
			{
			}
		}

		// Token: 0x060041A5 RID: 16805 RVA: 0x000ECDD4 File Offset: 0x000EAFD4
		private static bool ThinkInstance(ref global::Facepunch.Collections.StaticQueue<global::StructureMaster.Schedule, global::StructureMaster>.iterator iter, ref global::StructureMaster master, ref global::Facepunch.Collections.StaticQueue<global::StructureMaster.Schedule, global::StructureMaster>.Entry key, ref int numDecaying)
		{
			global::StructureMaster.DecayStatus decayStatus;
			try
			{
				decayStatus = master.DoDecay();
			}
			catch (global::System.Exception ex)
			{
				decayStatus = global::StructureMaster.DecayStatus.Delaying;
				global::UnityEngine.Debug.LogException(ex, master);
			}
			global::Facepunch.Collections.StaticQueue<global::StructureMaster.Schedule, global::StructureMaster>.act cmd;
			switch (decayStatus)
			{
			case global::StructureMaster.DecayStatus.Decaying:
				cmd = global::Facepunch.Collections.StaticQueue<global::StructureMaster.Schedule, global::StructureMaster>.act.back;
				numDecaying++;
				goto IL_5C;
			case global::StructureMaster.DecayStatus.PentUpDecay:
				cmd = global::Facepunch.Collections.StaticQueue<global::StructureMaster.Schedule, global::StructureMaster>.act.none;
				goto IL_5C;
			case global::StructureMaster.DecayStatus.Gone:
				cmd = global::Facepunch.Collections.StaticQueue<global::StructureMaster.Schedule, global::StructureMaster>.act.delist;
				goto IL_5C;
			}
			cmd = global::Facepunch.Collections.StaticQueue<global::StructureMaster.Schedule, global::StructureMaster>.act.back;
			IL_5C:
			return iter.Next(ref key, cmd, out master) && numDecaying < global::structure.framelimit;
		}
	}

	// Token: 0x020007AF RID: 1967
	protected enum DecayStatus
	{
		// Token: 0x04002241 RID: 8769
		Decaying,
		// Token: 0x04002242 RID: 8770
		Delaying,
		// Token: 0x04002243 RID: 8771
		PentUpDecay,
		// Token: 0x04002244 RID: 8772
		Gone
	}

	// Token: 0x020007B0 RID: 1968
	public class CompPosNode
	{
		// Token: 0x060041A6 RID: 16806 RVA: 0x000ECE74 File Offset: 0x000EB074
		public CompPosNode()
		{
		}

		// Token: 0x060041A7 RID: 16807 RVA: 0x000ECE7C File Offset: 0x000EB07C
		public global::StructureComponent GetType(global::StructureComponent.StructureComponentType type)
		{
			switch (type)
			{
			case global::StructureComponent.StructureComponentType.Pillar:
				return this._pillar;
			case global::StructureComponent.StructureComponentType.Wall:
			case global::StructureComponent.StructureComponentType.Doorway:
			case global::StructureComponent.StructureComponentType.WindowWall:
				return this._wall;
			case global::StructureComponent.StructureComponentType.Ceiling:
				return this._ceiling;
			case global::StructureComponent.StructureComponentType.Stairs:
				return this._stairs;
			case global::StructureComponent.StructureComponentType.Foundation:
				return this._foundation;
			default:
				return null;
			}
		}

		// Token: 0x060041A8 RID: 16808 RVA: 0x000ECED8 File Offset: 0x000EB0D8
		public void Add(global::StructureComponent toAdd)
		{
			switch (toAdd.type)
			{
			case global::StructureComponent.StructureComponentType.Pillar:
				this._pillar = toAdd;
				break;
			case global::StructureComponent.StructureComponentType.Wall:
			case global::StructureComponent.StructureComponentType.Doorway:
			case global::StructureComponent.StructureComponentType.WindowWall:
				this._wall = toAdd;
				break;
			case global::StructureComponent.StructureComponentType.Ceiling:
				this._ceiling = toAdd;
				break;
			case global::StructureComponent.StructureComponentType.Stairs:
				this._stairs = toAdd;
				break;
			case global::StructureComponent.StructureComponentType.Foundation:
				this._foundation = toAdd;
				break;
			}
		}

		// Token: 0x060041A9 RID: 16809 RVA: 0x000ECF58 File Offset: 0x000EB158
		public global::StructureComponent GetAny()
		{
			if (this._ceiling != null)
			{
				return this._ceiling;
			}
			if (this._stairs != null)
			{
				return this._stairs;
			}
			if (this._pillar != null)
			{
				return this._pillar;
			}
			if (this._foundation != null)
			{
				return this._foundation;
			}
			if (this._wall != null)
			{
				return this._wall;
			}
			return null;
		}

		// Token: 0x060041AA RID: 16810 RVA: 0x000ECFE0 File Offset: 0x000EB1E0
		public void Remove(global::StructureComponent toRemove)
		{
			if (this._wall == toRemove)
			{
				this._wall = null;
			}
			else if (this._foundation == toRemove)
			{
				this._foundation = null;
			}
			else if (this._pillar == toRemove)
			{
				this._pillar = null;
			}
			else if (this._stairs == toRemove)
			{
				this._stairs = null;
			}
			else if (this._ceiling == toRemove)
			{
				this._ceiling = null;
			}
		}

		// Token: 0x04002245 RID: 8773
		public global::StructureComponent _wall;

		// Token: 0x04002246 RID: 8774
		public global::StructureComponent _foundation;

		// Token: 0x04002247 RID: 8775
		public global::StructureComponent _pillar;

		// Token: 0x04002248 RID: 8776
		public global::StructureComponent _stairs;

		// Token: 0x04002249 RID: 8777
		public global::StructureComponent _ceiling;
	}

	// Token: 0x020007B1 RID: 1969
	private sealed class PreBinding
	{
		// Token: 0x060041AB RID: 16811 RVA: 0x000ED07C File Offset: 0x000EB27C
		public PreBinding()
		{
		}

		// Token: 0x0400224A RID: 8778
		public global::StructureMaster master;

		// Token: 0x0400224B RID: 8779
		public global::System.Collections.Generic.Dictionary<int, global::StructureComponent> components = new global::System.Collections.Generic.Dictionary<int, global::StructureComponent>();
	}

	// Token: 0x020007B2 RID: 1970
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private sealed class <CheckNextFrameAnyComponents>c__Iterator52 : global::System.IDisposable, global::System.Collections.IEnumerator, global::System.Collections.Generic.IEnumerator<object>
	{
		// Token: 0x060041AC RID: 16812 RVA: 0x000ED090 File Offset: 0x000EB290
		public <CheckNextFrameAnyComponents>c__Iterator52()
		{
		}

		// Token: 0x17000C0E RID: 3086
		// (get) Token: 0x060041AD RID: 16813 RVA: 0x000ED098 File Offset: 0x000EB298
		object global::System.Collections.Generic.IEnumerator<object>.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17000C0F RID: 3087
		// (get) Token: 0x060041AE RID: 16814 RVA: 0x000ED0A0 File Offset: 0x000EB2A0
		object global::System.Collections.IEnumerator.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x060041AF RID: 16815 RVA: 0x000ED0A8 File Offset: 0x000EB2A8
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			switch (num)
			{
			case 0U:
				this.$current = null;
				this.$PC = 1;
				return true;
			case 1U:
				if (this._structureComponents.Count == 0)
				{
					global::NetCull.Destroy(base.gameObject);
				}
				this.$PC = -1;
				break;
			}
			return false;
		}

		// Token: 0x060041B0 RID: 16816 RVA: 0x000ED11C File Offset: 0x000EB31C
		[global::System.Diagnostics.DebuggerHidden]
		public void Dispose()
		{
			this.$PC = -1;
		}

		// Token: 0x060041B1 RID: 16817 RVA: 0x000ED128 File Offset: 0x000EB328
		[global::System.Diagnostics.DebuggerHidden]
		public void Reset()
		{
			throw new global::System.NotSupportedException();
		}

		// Token: 0x0400224C RID: 8780
		internal int $PC;

		// Token: 0x0400224D RID: 8781
		internal object $current;

		// Token: 0x0400224E RID: 8782
		internal global::StructureMaster <>f__this;
	}
}
