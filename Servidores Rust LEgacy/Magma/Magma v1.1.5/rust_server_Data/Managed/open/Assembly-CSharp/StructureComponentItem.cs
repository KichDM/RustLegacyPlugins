using System;
using uLink;
using UnityEngine;

// Token: 0x0200070A RID: 1802
public abstract class StructureComponentItem<T> : global::HeldItem<T> where T : global::StructureComponentDataBlock
{
	// Token: 0x06003D1B RID: 15643 RVA: 0x000D70F4 File Offset: 0x000D52F4
	protected StructureComponentItem(T db) : base(db)
	{
	}

	// Token: 0x06003D1C RID: 15644 RVA: 0x000D7108 File Offset: 0x000D5308
	protected void RenderPlacementHelpers()
	{
		T datablock = this.datablock;
		global::StructureComponent structureToPlacePrefab = datablock.structureToPlacePrefab;
		this._master = null;
		this._placePos = global::UnityEngine.Vector3.zero;
		this._placeRot = global::UnityEngine.Quaternion.identity;
		this.validLocation = false;
		float axis = global::UnityEngine.Input.GetAxis("Mouse ScrollWheel");
		if (axis > 0f)
		{
			this.desiredRotation *= global::UnityEngine.Quaternion.AngleAxis(90f, global::UnityEngine.Vector3.up);
		}
		else if (axis < 0f)
		{
			this.desiredRotation *= global::UnityEngine.Quaternion.AngleAxis(-90f, global::UnityEngine.Vector3.up);
		}
		global::Character character = base.character;
		if (character == null)
		{
			return;
		}
		global::UnityEngine.Ray eyesRay = character.eyesRay;
		float num = (structureToPlacePrefab.type != global::StructureComponent.StructureComponentType.Ceiling) ? 8f : 4f;
		global::UnityEngine.Vector3 vector = global::UnityEngine.Vector3.zero;
		global::UnityEngine.Vector3 vector2 = global::UnityEngine.Vector3.up;
		global::UnityEngine.Vector3 zero = global::UnityEngine.Vector3.zero;
		global::UnityEngine.RaycastHit raycastHit;
		bool flag;
		if (global::UnityEngine.Physics.Raycast(eyesRay, ref raycastHit, num))
		{
			vector = raycastHit.point;
			vector2 = raycastHit.normal;
			flag = true;
		}
		else
		{
			flag = false;
			vector = eyesRay.origin + eyesRay.direction * num;
		}
		switch (structureToPlacePrefab.type)
		{
		case global::StructureComponent.StructureComponentType.Ceiling:
		case global::StructureComponent.StructureComponentType.Foundation:
		case global::StructureComponent.StructureComponentType.Ramp:
			vector.y -= 3.5f;
			break;
		}
		bool flag2 = false;
		bool flag3 = false;
		global::UnityEngine.Vector3 placePos = vector;
		global::UnityEngine.Quaternion placeRot = global::TransformHelpers.LookRotationForcedUp(character.eyesAngles.forward, global::UnityEngine.Vector3.up) * this.desiredRotation;
		foreach (global::StructureMaster structureMaster in global::StructureMaster.RayTestStructures(eyesRay))
		{
			if (structureMaster)
			{
				int num2;
				int num3;
				int num4;
				structureMaster.GetStructureSize(out num2, out num3, out num4);
				this._placePos = global::StructureMaster.SnapToGrid(structureMaster.transform, vector, true);
				this._placeRot = global::TransformHelpers.LookRotationForcedUp(structureMaster.transform.forward, structureMaster.transform.transform.up) * this.desiredRotation;
				if (!flag3)
				{
					placePos = this._placePos;
					placeRot = this._placeRot;
					flag3 = true;
				}
				if (structureToPlacePrefab.CheckLocation(structureMaster, this._placePos, this._placeRot))
				{
					this._master = structureMaster;
					flag2 = true;
					break;
				}
			}
		}
		if (!flag2)
		{
			if (structureToPlacePrefab.type == global::StructureComponent.StructureComponentType.Foundation)
			{
				if (flag && raycastHit.collider is global::UnityEngine.TerrainCollider)
				{
					bool flag4 = false;
					foreach (global::StructureMaster structureMaster2 in global::StructureMaster.AllStructuresWithBounds)
					{
						if (structureMaster2.containedBounds.Intersects(new global::UnityEngine.Bounds(vector, new global::UnityEngine.Vector3(5f, 5f, 4f))))
						{
							flag4 = true;
							break;
						}
					}
					if (!flag4)
					{
						this._placePos = vector;
						this._placeRot = global::TransformHelpers.LookRotationForcedUp(character.eyesAngles.forward, global::UnityEngine.Vector3.up) * this.desiredRotation;
						this.validLocation = true;
					}
				}
				else
				{
					this._placePos = placePos;
					this._placeRot = placeRot;
					this.validLocation = false;
				}
			}
			else
			{
				this._placePos = placePos;
				this._placeRot = placeRot;
				this.validLocation = false;
			}
		}
		else
		{
			this.validLocation = true;
		}
		T datablock2 = this.datablock;
		if (!datablock2.CheckBlockers(this._placePos))
		{
			this.validLocation = false;
		}
		global::UnityEngine.Color color = global::UnityEngine.Color.red;
		if (this.validLocation)
		{
			color = global::UnityEngine.Color.green;
		}
		color.a = 0.5f + global::UnityEngine.Mathf.Abs(global::UnityEngine.Mathf.Sin(global::UnityEngine.Time.time * 8f)) * 0.25f;
		if (this._materialProps != null)
		{
			this._materialProps.Clear();
			this._materialProps.AddColor("_EmissionColor", color);
			this._materialProps.AddVector("_MainTex_ST", new global::UnityEngine.Vector4(1f, 1f, 0f, global::UnityEngine.Mathf.Repeat(global::UnityEngine.Time.time, 30f)));
		}
		if (!this.validLocation)
		{
			this._placePos = vector;
		}
	}

	// Token: 0x06003D1D RID: 15645 RVA: 0x000D75A8 File Offset: 0x000D57A8
	private void InformException(global::System.Exception e, string title, ref bool informedOnce, global::UnityEngine.Object obj = null)
	{
		throw e;
	}

	// Token: 0x06003D1E RID: 15646 RVA: 0x000D75AC File Offset: 0x000D57AC
	public override void PreCameraRender()
	{
		try
		{
			this.RenderPlacementHelpers();
		}
		catch (global::System.Exception e)
		{
			this.InformException(e, "in PreCameraRender()", ref global::StructureComponentItem<T>.informedPreRender, null);
		}
	}

	// Token: 0x06003D1F RID: 15647 RVA: 0x000D75F8 File Offset: 0x000D57F8
	public virtual void DoPlace()
	{
		this._nextPlaceTime = global::UnityEngine.Time.time + 0.5f;
		global::Character character = base.character;
		if (character == null)
		{
			global::UnityEngine.Debug.Log("NO char for placement");
			return;
		}
		global::UnityEngine.Ray eyesRay = character.eyesRay;
		base.itemRepresentation.Action(1, 0, new object[]
		{
			eyesRay.origin,
			eyesRay.direction,
			this._placePos,
			this._placeRot,
			(!(this._master != null)) ? global::uLink.NetworkViewID.unassigned : this._master.networkView.viewID
		});
	}

	// Token: 0x06003D20 RID: 15648 RVA: 0x000D76BC File Offset: 0x000D58BC
	public bool IsValidLocation()
	{
		return false;
	}

	// Token: 0x06003D21 RID: 15649 RVA: 0x000D76C0 File Offset: 0x000D58C0
	public virtual bool CanPlace()
	{
		return this.validLocation && this._nextPlaceTime <= global::UnityEngine.Time.time;
	}

	// Token: 0x04001EE3 RID: 7907
	protected bool validLocation;

	// Token: 0x04001EE4 RID: 7908
	protected float _nextPlaceTime;

	// Token: 0x04001EE5 RID: 7909
	protected global::StructureMaster _master;

	// Token: 0x04001EE6 RID: 7910
	protected global::UnityEngine.Vector3 _placePos;

	// Token: 0x04001EE7 RID: 7911
	protected global::UnityEngine.Quaternion _placeRot;

	// Token: 0x04001EE8 RID: 7912
	protected global::PrefabRenderer _prefabRenderer;

	// Token: 0x04001EE9 RID: 7913
	protected global::UnityEngine.MaterialPropertyBlock _materialProps;

	// Token: 0x04001EEA RID: 7914
	protected bool lastFrameAttack2;

	// Token: 0x04001EEB RID: 7915
	public global::UnityEngine.Quaternion desiredRotation = global::UnityEngine.Quaternion.identity;

	// Token: 0x04001EEC RID: 7916
	private static bool informedPreRender;

	// Token: 0x04001EED RID: 7917
	private static bool informedPreFrame;
}
