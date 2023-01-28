using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Magma;
using RustProto;
using RustProto.Helpers;
using uLink;
using UnityEngine;

// Token: 0x020007A4 RID: 1956
[global::NGCAutoAddScript]
[global::UnityEngine.RequireComponent(typeof(global::TakeDamage))]
public class StructureComponent : global::IDMain, global::IServerSaveable
{
	// Token: 0x0600412A RID: 16682 RVA: 0x000EA0CC File Offset: 0x000E82CC
	public StructureComponent() : base(0)
	{
	}

	// Token: 0x0600412B RID: 16683 RVA: 0x000EA0EC File Offset: 0x000E82EC
	// Note: this type is marked as 'beforefieldinit'.
	static StructureComponent()
	{
	}

	// Token: 0x0600412C RID: 16684 RVA: 0x000EA0F0 File Offset: 0x000E82F0
	public global::StructureMaster.StructureMaterialType GetMaterialType()
	{
		return this._materialType;
	}

	// Token: 0x0600412D RID: 16685 RVA: 0x000EA0F8 File Offset: 0x000E82F8
	public void Touched()
	{
		this._master.Touched();
	}

	// Token: 0x0600412E RID: 16686 RVA: 0x000EA108 File Offset: 0x000E8308
	public void OnHurt(global::DamageEvent damage)
	{
		global::Magma.Hooks.EntityHurt(this, ref damage);
	}

	// Token: 0x0600412F RID: 16687 RVA: 0x000EA114 File Offset: 0x000E8314
	public void OnRepair()
	{
		this.UpdateClientHealth();
	}

	// Token: 0x06004130 RID: 16688 RVA: 0x000EA11C File Offset: 0x000E831C
	public bool IsType(global::StructureComponent.StructureComponentType checkType)
	{
		return this.type == checkType;
	}

	// Token: 0x06004131 RID: 16689 RVA: 0x000EA128 File Offset: 0x000E8328
	public bool IsPillar()
	{
		return this.type == global::StructureComponent.StructureComponentType.Pillar;
	}

	// Token: 0x06004132 RID: 16690 RVA: 0x000EA134 File Offset: 0x000E8334
	public bool IsWallType()
	{
		return this.type == global::StructureComponent.StructureComponentType.Wall || this.type == global::StructureComponent.StructureComponentType.Doorway || this.type == global::StructureComponent.StructureComponentType.WindowWall;
	}

	// Token: 0x06004133 RID: 16691 RVA: 0x000EA168 File Offset: 0x000E8368
	public void UpdateClientHealth()
	{
		this.healthBuffer.CheckAuto(this, "ClientHealthUpdate", false, false, 0.01f, (global::BufferHealthRPC.Flags)0);
	}

	// Token: 0x06004134 RID: 16692 RVA: 0x000EA184 File Offset: 0x000E8384
	[global::UnityEngine.RPC]
	public void ClientHealthUpdate(float newHealth)
	{
	}

	// Token: 0x06004135 RID: 16693 RVA: 0x000EA188 File Offset: 0x000E8388
	public void OnKilled(global::DamageEvent e)
	{
		base.StartCoroutine("DelayedKill");
	}

	// Token: 0x06004136 RID: 16694 RVA: 0x000EA198 File Offset: 0x000E8398
	[global::UnityEngine.RPC]
	public void ClientKilled()
	{
	}

	// Token: 0x06004137 RID: 16695 RVA: 0x000EA19C File Offset: 0x000E839C
	private global::System.Collections.IEnumerator DelayedKill()
	{
		yield return null;
		try
		{
			global::NetCull.RPC(this, "ClientKilled", 1);
		}
		finally
		{
			global::NetCull.Destroy(base.gameObject);
		}
		yield break;
	}

	// Token: 0x06004138 RID: 16696 RVA: 0x000EA1B8 File Offset: 0x000E83B8
	internal void OnWillBeDestroyedOnServer()
	{
		if (this._master)
		{
			this._master.RemoveComponent(this);
		}
	}

	// Token: 0x06004139 RID: 16697 RVA: 0x000EA1D8 File Offset: 0x000E83D8
	internal void ClearMaster()
	{
		this._master = null;
	}

	// Token: 0x0600413A RID: 16698 RVA: 0x000EA1E4 File Offset: 0x000E83E4
	protected internal virtual void OnOwnedByMasterStructure(global::StructureMaster master)
	{
		this._master = master;
		global::NGCView component = base.GetComponent<global::NGCView>();
		if (component && !global::ServerSaveManager.IsLoading)
		{
			this._master.Touched();
		}
	}

	// Token: 0x0600413B RID: 16699 RVA: 0x000EA220 File Offset: 0x000E8420
	[global::System.Obsolete("Do not call manually", true)]
	[global::UnityEngine.RPC]
	protected void SMSet(global::uLink.NetworkViewID masterViewID)
	{
	}

	// Token: 0x0600413C RID: 16700 RVA: 0x000EA224 File Offset: 0x000E8424
	public virtual bool CheckLocation(global::StructureMaster master, global::UnityEngine.Vector3 placePos, global::UnityEngine.Quaternion placeRot)
	{
		bool flag = false;
		bool flag2 = false;
		global::UnityEngine.Vector3 vector = master.transform.InverseTransformPoint(placePos);
		if (master.GetMaterialType() != global::StructureMaster.StructureMaterialType.UNSET && master.GetMaterialType() != this.GetMaterialType())
		{
			if (global::StructureComponent.logFailures)
			{
				global::UnityEngine.Debug.Log("Not proper material type, master is :" + master.GetMaterialType());
			}
			return false;
		}
		global::StructureComponent componentFromPositionWorld = master.GetComponentFromPositionWorld(placePos);
		if (componentFromPositionWorld != null)
		{
			if (global::StructureComponent.logFailures)
			{
				global::UnityEngine.Debug.Log("Occupied space", componentFromPositionWorld);
			}
			flag = true;
		}
		global::StructureComponent structureComponent = master.CompByLocal(vector - new global::UnityEngine.Vector3(0f, global::StructureMaster.gridSpacingY, 0f));
		if (this.type != global::StructureComponent.StructureComponentType.Foundation)
		{
			bool foundationForPoint = master.GetFoundationForPoint(placePos);
			if (foundationForPoint)
			{
				flag2 = true;
			}
		}
		if (this.type == global::StructureComponent.StructureComponentType.Wall || this.type == global::StructureComponent.StructureComponentType.Doorway || this.type == global::StructureComponent.StructureComponentType.WindowWall)
		{
			if (flag)
			{
				return false;
			}
			global::UnityEngine.Vector3 vector2 = placePos + placeRot * -global::UnityEngine.Vector3.right * 2.5f;
			global::StructureComponent componentFromPositionWorld2 = master.GetComponentFromPositionWorld(vector2);
			global::UnityEngine.Vector3 vector3 = placePos + placeRot * global::UnityEngine.Vector3.right * 2.5f;
			global::StructureComponent componentFromPositionWorld3 = master.GetComponentFromPositionWorld(vector3);
			if (global::StructureComponent.logFailures)
			{
				global::UnityEngine.Debug.DrawLine(vector2, vector3, global::UnityEngine.Color.cyan);
			}
			if (componentFromPositionWorld2 && componentFromPositionWorld3)
			{
				bool flag3;
				if (componentFromPositionWorld2.type != global::StructureComponent.StructureComponentType.Pillar)
				{
					if (global::StructureComponent.logFailures)
					{
						global::UnityEngine.Debug.Log("Left was not acceptable", componentFromPositionWorld2);
					}
					flag3 = false;
				}
				else
				{
					flag3 = true;
				}
				bool flag4;
				if (componentFromPositionWorld3.type != global::StructureComponent.StructureComponentType.Pillar)
				{
					if (global::StructureComponent.logFailures)
					{
						global::UnityEngine.Debug.Log("Right was not acceptable", componentFromPositionWorld3);
					}
					flag4 = false;
				}
				else
				{
					flag4 = true;
				}
				return flag3 && flag4;
			}
			if (global::StructureComponent.logFailures)
			{
				if (!componentFromPositionWorld2)
				{
					global::UnityEngine.Debug.Log("Did not find left");
				}
				if (!componentFromPositionWorld3)
				{
					global::UnityEngine.Debug.Log("Did not find right");
				}
			}
			return false;
		}
		else
		{
			if (this.type == global::StructureComponent.StructureComponentType.Foundation)
			{
				foreach (global::StructureMaster structureMaster in global::StructureMaster.AllStructuresWithBounds)
				{
					if (!(structureMaster == master))
					{
						if (structureMaster.containedBounds.Intersects(new global::UnityEngine.Bounds(placePos, new global::UnityEngine.Vector3(5f, 5f, 4f))))
						{
							if (global::StructureComponent.logFailures)
							{
								global::UnityEngine.Debug.Log("Too close to something");
							}
							return false;
						}
					}
				}
				bool flag5 = master.IsValidFoundationSpot(placePos);
				if (global::StructureComponent.logFailures)
				{
					global::UnityEngine.Debug.Log(string.Concat(new object[]
					{
						"returning here : mastervalid:",
						flag5,
						"compinplace",
						componentFromPositionWorld
					}));
				}
				return flag5 && !componentFromPositionWorld;
			}
			if (this.type == global::StructureComponent.StructureComponentType.Ramp)
			{
				return componentFromPositionWorld == null && (master.IsValidFoundationSpot(placePos) || (structureComponent && (structureComponent.type == global::StructureComponent.StructureComponentType.Ceiling || structureComponent.type == global::StructureComponent.StructureComponentType.Foundation)));
			}
			if (this.type == global::StructureComponent.StructureComponentType.Pillar)
			{
				return ((structureComponent && structureComponent.type == global::StructureComponent.StructureComponentType.Pillar) || flag2) && !flag;
			}
			if (this.type != global::StructureComponent.StructureComponentType.Stairs && this.type != global::StructureComponent.StructureComponentType.Ceiling)
			{
				return false;
			}
			if (flag)
			{
				return false;
			}
			global::UnityEngine.Vector3[] array = new global::UnityEngine.Vector3[]
			{
				new global::UnityEngine.Vector3(-2.5f, 0f, -2.5f),
				new global::UnityEngine.Vector3(2.5f, 0f, 2.5f),
				new global::UnityEngine.Vector3(-2.5f, 0f, 2.5f),
				new global::UnityEngine.Vector3(2.5f, 0f, -2.5f)
			};
			foreach (global::UnityEngine.Vector3 vector4 in array)
			{
				global::StructureComponent structureComponent2 = master.CompByLocal(vector + vector4);
				if (structureComponent2 == null || structureComponent2.type != global::StructureComponent.StructureComponentType.Pillar)
				{
					return false;
				}
			}
			return true;
		}
	}

	// Token: 0x0600413D RID: 16701 RVA: 0x000EA6D4 File Offset: 0x000E88D4
	public void WriteObjectSave(ref global::RustProto.SavedObject.Builder saveobj)
	{
		int id = this._master.FindComponentID(this);
		using (global::RustProto.Helpers.Recycler<global::RustProto.objectStructComponent, global::RustProto.objectStructComponent.Builder> recycler = global::RustProto.objectStructComponent.Recycler())
		{
			global::RustProto.objectStructComponent.Builder builder = recycler.OpenBuilder();
			builder.SetMasterID(this._master.GetMasterID());
			builder.SetID(id);
			builder.SetMasterViewID(global::NetEntityID.Get(this._master).id);
			saveobj.SetStructComponent(builder);
		}
	}

	// Token: 0x0600413E RID: 16702 RVA: 0x000EA768 File Offset: 0x000E8968
	public void ReadObjectSave(ref global::RustProto.SavedObject saveobj)
	{
		if (!saveobj.HasStructComponent)
		{
			return;
		}
		global::RustProto.objectStructComponent structComponent = saveobj.StructComponent;
		if (structComponent.HasMasterViewID)
		{
			global::StructureComponent.Loading.BindToMasterByPreviousNetEntityID(this, structComponent.MasterViewID, structComponent.MasterID, structComponent.ID);
		}
		else
		{
			global::StructureMaster.BindChild(structComponent.MasterID, structComponent.ID, this);
		}
	}

	// Token: 0x040021F7 RID: 8695
	public global::UnityEngine.GameObject deathEffect;

	// Token: 0x040021F8 RID: 8696
	public global::StructureMaster _master;

	// Token: 0x040021F9 RID: 8697
	protected float oldHealth;

	// Token: 0x040021FA RID: 8698
	[global::System.NonSerialized]
	private bool addedDestroyCallback;

	// Token: 0x040021FB RID: 8699
	public float Width = 5f;

	// Token: 0x040021FC RID: 8700
	public float Height = 1f;

	// Token: 0x040021FD RID: 8701
	public global::StructureMaster.StructureMaterialType _materialType;

	// Token: 0x040021FE RID: 8702
	public global::StructureComponent.StructureComponentType type;

	// Token: 0x040021FF RID: 8703
	[global::System.NonSerialized]
	private global::BufferHealthRPC healthBuffer;

	// Token: 0x04002200 RID: 8704
	private static bool logFailures;

	// Token: 0x020007A5 RID: 1957
	[global::System.Serializable]
	public enum StructureComponentType
	{
		// Token: 0x04002202 RID: 8706
		Pillar,
		// Token: 0x04002203 RID: 8707
		Wall,
		// Token: 0x04002204 RID: 8708
		Doorway,
		// Token: 0x04002205 RID: 8709
		Ceiling,
		// Token: 0x04002206 RID: 8710
		Stairs,
		// Token: 0x04002207 RID: 8711
		Foundation,
		// Token: 0x04002208 RID: 8712
		WindowWall,
		// Token: 0x04002209 RID: 8713
		Ramp,
		// Token: 0x0400220A RID: 8714
		Last
	}

	// Token: 0x020007A6 RID: 1958
	private static class Loading
	{
		// Token: 0x0600413F RID: 16703 RVA: 0x000EA7C4 File Offset: 0x000E89C4
		// Note: this type is marked as 'beforefieldinit'.
		static Loading()
		{
		}

		// Token: 0x06004140 RID: 16704 RVA: 0x000EA7D8 File Offset: 0x000E89D8
		private static void BindToMasterCallback(int oldID, global::NetEntityID newID, object userData)
		{
			global::StructureComponent.Loading.CallbackData callbackData = (global::StructureComponent.Loading.CallbackData)userData;
			if (callbackData.structureComponent)
			{
				if (!newID.isUnassigned)
				{
					global::StructureMaster component = newID.GetComponent<global::StructureMaster>();
					if (component)
					{
						component.AddStructureComponent(callbackData.structureComponent);
						return;
					}
				}
				global::StructureMaster.BindChild(callbackData.fallbackMasterID, callbackData.fallbackComponentID, callbackData.structureComponent);
			}
			else
			{
				global::UnityEngine.Debug.LogWarning("The strucutre component was deleted.");
			}
		}

		// Token: 0x06004141 RID: 16705 RVA: 0x000EA858 File Offset: 0x000E8A58
		public static void BindToMasterByPreviousNetEntityID(global::StructureComponent structureComponent, int masterOldNetEntityID, int fallbackStructureMasterID, int fallbackStructureComponentID)
		{
			global::StructureComponent.Loading.CallbackData userData = new global::StructureComponent.Loading.CallbackData
			{
				structureComponent = structureComponent,
				fallbackMasterID = fallbackStructureMasterID,
				fallbackComponentID = fallbackStructureComponentID
			};
			global::ServerSaveManager.LoadBinding.RegisterCallbackOnLoaded(masterOldNetEntityID, global::StructureComponent.Loading.bindToMasterCallback, userData);
		}

		// Token: 0x0400220B RID: 8715
		private static readonly global::SaveLoadBindingCallback bindToMasterCallback = new global::SaveLoadBindingCallback(global::StructureComponent.Loading.BindToMasterCallback);

		// Token: 0x020007A7 RID: 1959
		private class CallbackData
		{
			// Token: 0x06004142 RID: 16706 RVA: 0x000EA894 File Offset: 0x000E8A94
			public CallbackData()
			{
			}

			// Token: 0x06004143 RID: 16707 RVA: 0x000EA89C File Offset: 0x000E8A9C
			public override bool Equals(object obj)
			{
				return obj is global::StructureComponent.Loading.CallbackData && ((global::StructureComponent.Loading.CallbackData)obj).structureComponent == this.structureComponent && ((global::StructureComponent.Loading.CallbackData)obj).fallbackMasterID == this.fallbackMasterID && ((global::StructureComponent.Loading.CallbackData)obj).fallbackComponentID == this.fallbackComponentID;
			}

			// Token: 0x06004144 RID: 16708 RVA: 0x000EA8FC File Offset: 0x000E8AFC
			public override int GetHashCode()
			{
				return ((!this.structureComponent) ? 0 : this.structureComponent.GetInstanceID()) ^ (this.fallbackMasterID << 0x10 ^ this.fallbackMasterID >> 0x10 ^ this.fallbackComponentID);
			}

			// Token: 0x0400220C RID: 8716
			public global::StructureComponent structureComponent;

			// Token: 0x0400220D RID: 8717
			public int fallbackMasterID;

			// Token: 0x0400220E RID: 8718
			public int fallbackComponentID;
		}
	}

	// Token: 0x020007A8 RID: 1960
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private sealed class <DelayedKill>c__Iterator51 : global::System.IDisposable, global::System.Collections.IEnumerator, global::System.Collections.Generic.IEnumerator<object>
	{
		// Token: 0x06004145 RID: 16709 RVA: 0x000EA948 File Offset: 0x000E8B48
		public <DelayedKill>c__Iterator51()
		{
		}

		// Token: 0x17000C04 RID: 3076
		// (get) Token: 0x06004146 RID: 16710 RVA: 0x000EA950 File Offset: 0x000E8B50
		object global::System.Collections.Generic.IEnumerator<object>.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17000C05 RID: 3077
		// (get) Token: 0x06004147 RID: 16711 RVA: 0x000EA958 File Offset: 0x000E8B58
		object global::System.Collections.IEnumerator.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06004148 RID: 16712 RVA: 0x000EA960 File Offset: 0x000E8B60
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
				try
				{
					global::NetCull.RPC(this, "ClientKilled", 1);
				}
				finally
				{
					global::NetCull.Destroy(base.gameObject);
				}
				this.$PC = -1;
				break;
			}
			return false;
		}

		// Token: 0x06004149 RID: 16713 RVA: 0x000EA9F4 File Offset: 0x000E8BF4
		[global::System.Diagnostics.DebuggerHidden]
		public void Dispose()
		{
			this.$PC = -1;
		}

		// Token: 0x0600414A RID: 16714 RVA: 0x000EAA00 File Offset: 0x000E8C00
		[global::System.Diagnostics.DebuggerHidden]
		public void Reset()
		{
			throw new global::System.NotSupportedException();
		}

		// Token: 0x0400220F RID: 8719
		internal int $PC;

		// Token: 0x04002210 RID: 8720
		internal object $current;

		// Token: 0x04002211 RID: 8721
		internal global::StructureComponent <>f__this;
	}
}
