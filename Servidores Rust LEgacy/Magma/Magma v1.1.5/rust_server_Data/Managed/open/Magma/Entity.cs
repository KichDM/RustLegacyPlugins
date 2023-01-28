using System;
using System.Collections.Generic;
using UnityEngine;

namespace Magma
{
	// Token: 0x0200000B RID: 11
	public class Entity
	{
		// Token: 0x1700001C RID: 28
		// (get) Token: 0x0600005A RID: 90 RVA: 0x00002C67 File Offset: 0x00000E67
		// (set) Token: 0x0600005B RID: 91 RVA: 0x00002C6F File Offset: 0x00000E6F
		public object Object
		{
			get
			{
				return this._obj;
			}
			set
			{
				this._obj = value;
			}
		}

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x0600005C RID: 92 RVA: 0x00002C78 File Offset: 0x00000E78
		public string Name
		{
			get
			{
				if (this.IsDeployableObject())
				{
					return this.GetObject<global::DeployableObject>().gameObject.name.Replace("(Clone)", "");
				}
				if (this.IsStructure())
				{
					return this.GetObject<global::StructureComponent>().name.Replace("(Clone)", "");
				}
				return "";
			}
		}

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x0600005D RID: 93 RVA: 0x00002CD5 File Offset: 0x00000ED5
		public int InstanceID
		{
			get
			{
				if (this.IsDeployableObject())
				{
					return this.GetObject<global::DeployableObject>().GetInstanceID();
				}
				if (this.IsStructure())
				{
					return this.GetObject<global::StructureComponent>().GetInstanceID();
				}
				return 0;
			}
		}

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x0600005E RID: 94 RVA: 0x00002D00 File Offset: 0x00000F00
		// (set) Token: 0x0600005F RID: 95 RVA: 0x00002D39 File Offset: 0x00000F39
		public float Health
		{
			get
			{
				if (this.IsDeployableObject())
				{
					return this.GetObject<global::DeployableObject>().GetComponent<global::TakeDamage>().health;
				}
				if (this.IsStructure())
				{
					return this.GetObject<global::StructureComponent>().GetComponent<global::TakeDamage>().health;
				}
				return 0f;
			}
			set
			{
				if (this.IsDeployableObject())
				{
					this.GetObject<global::DeployableObject>().GetComponent<global::TakeDamage>().health = value;
					return;
				}
				if (this.IsStructure())
				{
					this.GetObject<global::StructureComponent>().GetComponent<global::TakeDamage>().health = value;
				}
			}
		}

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x06000060 RID: 96 RVA: 0x00002D70 File Offset: 0x00000F70
		public global::Magma.Player Creator
		{
			get
			{
				return global::Magma.Player.FindByGameID(this.CreatorID.ToString());
			}
		}

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x06000061 RID: 97 RVA: 0x00002D90 File Offset: 0x00000F90
		public ulong CreatorID
		{
			get
			{
				if (this.IsDeployableObject())
				{
					return this.GetObject<global::DeployableObject>().creatorID;
				}
				if (this.IsStructure())
				{
					return this.GetObject<global::StructureComponent>()._master.creatorID;
				}
				return 0UL;
			}
		}

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x06000062 RID: 98 RVA: 0x00002DC4 File Offset: 0x00000FC4
		public global::Magma.Player Owner
		{
			get
			{
				return global::Magma.Player.FindByGameID(this.OwnerID.ToString());
			}
		}

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x06000063 RID: 99 RVA: 0x00002DE4 File Offset: 0x00000FE4
		public ulong OwnerID
		{
			get
			{
				if (this.IsDeployableObject())
				{
					return this.GetObject<global::DeployableObject>().ownerID;
				}
				if (this.IsStructure())
				{
					return this.GetObject<global::StructureComponent>()._master.ownerID;
				}
				return 0UL;
			}
		}

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x06000064 RID: 100 RVA: 0x00002E18 File Offset: 0x00001018
		// (set) Token: 0x06000065 RID: 101 RVA: 0x00002E70 File Offset: 0x00001070
		public float X
		{
			get
			{
				if (this.IsDeployableObject())
				{
					return this.GetObject<global::DeployableObject>().gameObject.transform.position.x;
				}
				if (this.IsStructure())
				{
					return this.GetObject<global::StructureComponent>().gameObject.transform.position.x;
				}
				return 0f;
			}
			set
			{
				if (this.IsDeployableObject())
				{
					this.GetObject<global::DeployableObject>().gameObject.transform.position = new global::UnityEngine.Vector3(value, this.Y, this.Z);
					return;
				}
				if (this.IsStructure())
				{
					this.GetObject<global::StructureComponent>().gameObject.transform.position = new global::UnityEngine.Vector3(value, this.Y, this.Z);
				}
			}
		}

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x06000066 RID: 102 RVA: 0x00002EDC File Offset: 0x000010DC
		// (set) Token: 0x06000067 RID: 103 RVA: 0x00002F34 File Offset: 0x00001134
		public float Y
		{
			get
			{
				if (this.IsDeployableObject())
				{
					return this.GetObject<global::DeployableObject>().gameObject.transform.position.y;
				}
				if (this.IsStructure())
				{
					return this.GetObject<global::StructureComponent>().gameObject.transform.position.y;
				}
				return 0f;
			}
			set
			{
				if (this.IsDeployableObject())
				{
					this.GetObject<global::DeployableObject>().gameObject.transform.position = new global::UnityEngine.Vector3(this.X, value, this.Z);
					return;
				}
				if (this.IsStructure())
				{
					this.GetObject<global::StructureComponent>().gameObject.transform.position = new global::UnityEngine.Vector3(this.X, value, this.Z);
				}
			}
		}

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x06000068 RID: 104 RVA: 0x00002FA0 File Offset: 0x000011A0
		// (set) Token: 0x06000069 RID: 105 RVA: 0x00002FF8 File Offset: 0x000011F8
		public float Z
		{
			get
			{
				if (this.IsDeployableObject())
				{
					return this.GetObject<global::DeployableObject>().gameObject.transform.position.z;
				}
				if (this.IsStructure())
				{
					return this.GetObject<global::StructureComponent>().gameObject.transform.position.z;
				}
				return 0f;
			}
			set
			{
				if (this.IsDeployableObject())
				{
					this.GetObject<global::DeployableObject>().gameObject.transform.position = new global::UnityEngine.Vector3(this.X, this.Y, value);
					return;
				}
				if (this.IsStructure())
				{
					this.GetObject<global::StructureComponent>().gameObject.transform.position = new global::UnityEngine.Vector3(this.X, this.Y, value);
				}
			}
		}

		// Token: 0x0600006A RID: 106 RVA: 0x00003064 File Offset: 0x00001264
		public Entity(object Obj)
		{
			this.Object = Obj;
		}

		// Token: 0x0600006B RID: 107 RVA: 0x00003073 File Offset: 0x00001273
		public global::TakeDamage GetTakeDamage()
		{
			if (this.IsDeployableObject())
			{
				return this.GetObject<global::DeployableObject>().GetComponent<global::TakeDamage>();
			}
			if (this.IsStructure())
			{
				return this.GetObject<global::StructureComponent>().GetComponent<global::TakeDamage>();
			}
			return null;
		}

		// Token: 0x0600006C RID: 108 RVA: 0x0000309E File Offset: 0x0000129E
		public bool IsDeployableObject()
		{
			return this.Object is global::DeployableObject;
		}

		// Token: 0x0600006D RID: 109 RVA: 0x000030AE File Offset: 0x000012AE
		public bool IsStructure()
		{
			return this.Object is global::StructureComponent;
		}

		// Token: 0x0600006E RID: 110 RVA: 0x000030C0 File Offset: 0x000012C0
		public global::System.Collections.Generic.List<global::Magma.Entity> GetLinkedStructs()
		{
			global::System.Collections.Generic.List<global::Magma.Entity> list = new global::System.Collections.Generic.List<global::Magma.Entity>();
			foreach (global::StructureComponent structureComponent in (this.Object as global::StructureComponent)._master._structureComponents)
			{
				if (structureComponent != this.Object)
				{
					list.Add(new global::Magma.Entity(structureComponent));
				}
			}
			return list;
		}

		// Token: 0x0600006F RID: 111 RVA: 0x00003138 File Offset: 0x00001338
		public void Destroy()
		{
			try
			{
				if (this.IsDeployableObject())
				{
					this.GetObject<global::DeployableObject>().OnKilled();
				}
				else if (this.IsStructure())
				{
					global::StructureComponent @object = this.GetObject<global::StructureComponent>();
					@object._master.RemoveComponent(@object);
					@object._master = null;
					this.GetObject<global::StructureComponent>().StartCoroutine("DelayedKill");
				}
			}
			catch (global::System.Exception)
			{
				if (this.IsDeployableObject())
				{
					global::NetCull.Destroy(this.GetObject<global::DeployableObject>().networkViewID);
				}
				else if (this.IsStructure())
				{
					global::NetCull.Destroy(this.GetObject<global::StructureComponent>().networkViewID);
				}
			}
		}

		// Token: 0x06000070 RID: 112 RVA: 0x000031D8 File Offset: 0x000013D8
		public void UpdateHealth()
		{
			if (this.IsDeployableObject())
			{
				this.GetObject<global::DeployableObject>().UpdateClientHealth();
				return;
			}
			if (this.IsStructure())
			{
				this.GetObject<global::StructureComponent>().UpdateClientHealth();
			}
		}

		// Token: 0x06000071 RID: 113 RVA: 0x00003201 File Offset: 0x00001401
		public void ChangeOwner(global::Magma.Player p)
		{
			if (this.IsDeployableObject())
			{
				this.GetObject<global::DeployableObject>().SetupCreator(p.PlayerClient.controllable);
			}
		}

		// Token: 0x06000072 RID: 114 RVA: 0x00003221 File Offset: 0x00001421
		public void SetDecayEnabled(bool c)
		{
			if (this.IsDeployableObject())
			{
				this.GetObject<global::DeployableObject>().SetDecayEnabled(c);
			}
		}

		// Token: 0x06000073 RID: 115 RVA: 0x00003237 File Offset: 0x00001437
		private T GetObject<T>()
		{
			return (T)((object)this.Object);
		}

		// Token: 0x0400001D RID: 29
		private object _obj;
	}
}
