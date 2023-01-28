using System;
using System.Collections.Generic;
using System.IO;
using Facepunch;
using uLink;
using UnityEngine;

namespace Magma
{
	// Token: 0x02000015 RID: 21
	public class World
	{
		// Token: 0x060000B8 RID: 184 RVA: 0x000038A0 File Offset: 0x00001AA0
		public static global::Magma.World GetWorld()
		{
			if (global::Magma.World.world == null)
			{
				global::Magma.World.world = new global::Magma.World();
			}
			return global::Magma.World.world;
		}

		// Token: 0x17000038 RID: 56
		// (get) Token: 0x060000B9 RID: 185 RVA: 0x000038B8 File Offset: 0x00001AB8
		// (set) Token: 0x060000BA RID: 186 RVA: 0x000038C4 File Offset: 0x00001AC4
		public float Time
		{
			get
			{
				return global::EnvironmentControlCenter.Singleton.GetTime();
			}
			set
			{
				global::EnvironmentControlCenter.Singleton.SetTime(value);
			}
		}

		// Token: 0x17000039 RID: 57
		// (get) Token: 0x060000BB RID: 187 RVA: 0x000038D4 File Offset: 0x00001AD4
		public global::System.Collections.Generic.List<global::Magma.Entity> Entities
		{
			get
			{
				global::System.Collections.Generic.List<global::Magma.Entity> list = new global::System.Collections.Generic.List<global::Magma.Entity>();
				foreach (global::StructureComponent obj in global::Resources.FindObjectsOfTypeAll(typeof(global::StructureComponent)))
				{
					list.Add(new global::Magma.Entity(obj));
				}
				foreach (global::DeployableObject obj2 in global::Resources.FindObjectsOfTypeAll(typeof(global::DeployableObject)))
				{
					list.Add(new global::Magma.Entity(obj2));
				}
				return list;
			}
		}

		// Token: 0x1700003A RID: 58
		// (get) Token: 0x060000BC RID: 188 RVA: 0x0000395B File Offset: 0x00001B5B
		// (set) Token: 0x060000BD RID: 189 RVA: 0x00003962 File Offset: 0x00001B62
		public float DayLength
		{
			get
			{
				return global::env.daylength;
			}
			set
			{
				global::env.daylength = value;
			}
		}

		// Token: 0x1700003B RID: 59
		// (get) Token: 0x060000BE RID: 190 RVA: 0x0000396A File Offset: 0x00001B6A
		// (set) Token: 0x060000BF RID: 191 RVA: 0x00003971 File Offset: 0x00001B71
		public float NightLength
		{
			get
			{
				return global::env.nightlength;
			}
			set
			{
				global::env.nightlength = value;
			}
		}

		// Token: 0x060000C0 RID: 192 RVA: 0x00003979 File Offset: 0x00001B79
		public World()
		{
		}

		// Token: 0x060000C1 RID: 193 RVA: 0x00003981 File Offset: 0x00001B81
		public void Airdrop()
		{
			this.Airdrop(1);
		}

		// Token: 0x060000C2 RID: 194 RVA: 0x0000398C File Offset: 0x00001B8C
		public void Airdrop(int rep)
		{
			for (int i = 0; i < rep; i++)
			{
				global::SupplyDropZone.CallAirDrop();
			}
		}

		// Token: 0x060000C3 RID: 195 RVA: 0x000039AA File Offset: 0x00001BAA
		public void AirdropAt(float x, float y, float z)
		{
			this.AirdropAt(x, y, z, 1);
		}

		// Token: 0x060000C4 RID: 196 RVA: 0x000039B8 File Offset: 0x00001BB8
		public void AirdropAt(float x, float y, float z, int rep)
		{
			for (int i = 0; i < rep; i++)
			{
				global::SupplyDropZone.CallAirDropAt(new global::UnityEngine.Vector3(x, y, z));
			}
		}

		// Token: 0x060000C5 RID: 197 RVA: 0x000039DF File Offset: 0x00001BDF
		public void AirdropAtPlayer(global::Magma.Player p)
		{
			this.AirdropAtPlayer(p, 1);
		}

		// Token: 0x060000C6 RID: 198 RVA: 0x000039EC File Offset: 0x00001BEC
		public void AirdropAtPlayer(global::Magma.Player p, int rep)
		{
			for (int i = 0; i < rep; i++)
			{
				global::SupplyDropZone.CallAirDropAt(p.Location);
			}
		}

		// Token: 0x060000C7 RID: 199 RVA: 0x00003A10 File Offset: 0x00001C10
		public object Spawn(string prefab, float x, float y, float z)
		{
			return this.Spawn(prefab, x, y, z, 1);
		}

		// Token: 0x060000C8 RID: 200 RVA: 0x00003A1E File Offset: 0x00001C1E
		public object Spawn(string prefab, float x, float y, float z, int rep)
		{
			return this.Spawn(prefab, new global::UnityEngine.Vector3(x, y, z), global::UnityEngine.Quaternion.identity, rep);
		}

		// Token: 0x060000C9 RID: 201 RVA: 0x00003A37 File Offset: 0x00001C37
		public object Spawn(string prefab, float x, float y, float z, global::UnityEngine.Quaternion rot)
		{
			return this.Spawn(prefab, x, y, z, rot, 1);
		}

		// Token: 0x060000CA RID: 202 RVA: 0x00003A47 File Offset: 0x00001C47
		public object Spawn(string prefab, float x, float y, float z, global::UnityEngine.Quaternion rot, int rep)
		{
			return this.Spawn(prefab, new global::UnityEngine.Vector3(x, y, z), rot, rep);
		}

		// Token: 0x060000CB RID: 203 RVA: 0x00003A5D File Offset: 0x00001C5D
		public object Spawn(string prefab, global::UnityEngine.Vector3 location)
		{
			return this.Spawn(prefab, location, 1);
		}

		// Token: 0x060000CC RID: 204 RVA: 0x00003A68 File Offset: 0x00001C68
		public object Spawn(string prefab, global::UnityEngine.Vector3 location, int rep)
		{
			return this.Spawn(prefab, location, global::UnityEngine.Quaternion.identity, rep);
		}

		// Token: 0x060000CD RID: 205 RVA: 0x00003A78 File Offset: 0x00001C78
		public object SpawnAtPlayer(string prefab, global::Magma.Player p)
		{
			return this.Spawn(prefab, p.Location, p.PlayerClient.transform.rotation, 1);
		}

		// Token: 0x060000CE RID: 206 RVA: 0x00003A98 File Offset: 0x00001C98
		public object SpawnAtPlayer(string prefab, global::Magma.Player p, int rep)
		{
			return this.Spawn(prefab, p.Location, p.PlayerClient.transform.rotation, rep);
		}

		// Token: 0x060000CF RID: 207 RVA: 0x00003AB8 File Offset: 0x00001CB8
		private object Spawn(string prefab, global::UnityEngine.Vector3 location, global::UnityEngine.Quaternion rotation, int rep)
		{
			object result = null;
			for (int i = 0; i < rep; i++)
			{
				if (prefab == ":player_soldier")
				{
					result = global::NetCull.InstantiateDynamic(global::uLink.NetworkPlayer.server, prefab, location, rotation);
				}
				else if (prefab.Contains("C130"))
				{
					result = global::NetCull.InstantiateClassic(prefab, location, rotation, 0);
				}
				else
				{
					global::UnityEngine.GameObject gameObject = global::NetCull.InstantiateStatic(prefab, location, rotation);
					result = gameObject;
					global::StructureComponent component = gameObject.GetComponent<global::StructureComponent>();
					if (component != null)
					{
						result = new global::Magma.Entity(component);
					}
					else
					{
						global::DeployableObject component2 = gameObject.GetComponent<global::DeployableObject>();
						if (component2 != null)
						{
							component2.ownerID = 0UL;
							component2.creatorID = 0UL;
							component2.CacheCreator();
							component2.CreatorSet();
							result = new global::Magma.Entity(component2);
						}
					}
				}
			}
			return result;
		}

		// Token: 0x060000D0 RID: 208 RVA: 0x00003B6F File Offset: 0x00001D6F
		public global::Magma.Zone3D CreateZone(string name)
		{
			return new global::Magma.Zone3D(name);
		}

		// Token: 0x060000D1 RID: 209 RVA: 0x00003B77 File Offset: 0x00001D77
		public global::StructureMaster CreateSM(global::Magma.Player p)
		{
			return this.CreateSM(p, p.X, p.Y, p.Z, p.PlayerClient.transform.rotation);
		}

		// Token: 0x060000D2 RID: 210 RVA: 0x00003BA2 File Offset: 0x00001DA2
		public global::StructureMaster CreateSM(global::Magma.Player p, float x, float y, float z)
		{
			return this.CreateSM(p, x, y, z, global::UnityEngine.Quaternion.identity);
		}

		// Token: 0x060000D3 RID: 211 RVA: 0x00003BB4 File Offset: 0x00001DB4
		public global::StructureMaster CreateSM(global::Magma.Player p, float x, float y, float z, global::UnityEngine.Quaternion rot)
		{
			global::StructureMaster structureMaster = global::NetCull.InstantiateClassic<global::StructureMaster>(global::Facepunch.Bundling.Load<global::StructureMaster>("content/structures/StructureMasterPrefab"), new global::UnityEngine.Vector3(x, y, z), rot, 0);
			structureMaster.SetupCreator(p.PlayerClient.controllable);
			return structureMaster;
		}

		// Token: 0x060000D4 RID: 212 RVA: 0x00003BF0 File Offset: 0x00001DF0
		public float GetGround(float x, float z)
		{
			global::UnityEngine.Vector3 vector;
			vector..ctor(x, 2000f, z);
			global::UnityEngine.Vector3 vector2;
			vector2..ctor(0f, -1f, 0f);
			global::UnityEngine.RaycastHit[] array = global::UnityEngine.Physics.RaycastAll(vector, vector2);
			return array[0].point.y;
		}

		// Token: 0x060000D5 RID: 213 RVA: 0x00003C3C File Offset: 0x00001E3C
		public void Lists()
		{
			foreach (global::LootSpawnList lootSpawnList in global::DatablockDictionary._lootSpawnLists.Values)
			{
				global::System.IO.File.AppendAllText(global::Magma.Util.GetAbsoluteFilePath("Lists.txt"), "Name : " + lootSpawnList.name + "\n");
				global::System.IO.File.AppendAllText(global::Magma.Util.GetAbsoluteFilePath("Lists.txt"), "Min Spawn : " + lootSpawnList.minPackagesToSpawn + "\n");
				global::System.IO.File.AppendAllText(global::Magma.Util.GetAbsoluteFilePath("Lists.txt"), "Max Spawn : " + lootSpawnList.maxPackagesToSpawn + "\n");
				global::System.IO.File.AppendAllText(global::Magma.Util.GetAbsoluteFilePath("Lists.txt"), "NoDuplicate : " + lootSpawnList.noDuplicates + "\n");
				global::System.IO.File.AppendAllText(global::Magma.Util.GetAbsoluteFilePath("Lists.txt"), "OneOfEach : " + lootSpawnList.spawnOneOfEach + "\n");
				global::System.IO.File.AppendAllText(global::Magma.Util.GetAbsoluteFilePath("Lists.txt"), "Entries :\n");
				foreach (global::LootSpawnList.LootWeightedEntry lootWeightedEntry in lootSpawnList.LootPackages)
				{
					global::System.IO.File.AppendAllText(global::Magma.Util.GetAbsoluteFilePath("Lists.txt"), "Amount Min : " + lootWeightedEntry.amountMin + "\n");
					global::System.IO.File.AppendAllText(global::Magma.Util.GetAbsoluteFilePath("Lists.txt"), "Amount Max : " + lootWeightedEntry.amountMax + "\n");
					global::System.IO.File.AppendAllText(global::Magma.Util.GetAbsoluteFilePath("Lists.txt"), "Weight : " + lootWeightedEntry.weight + "\n");
					global::System.IO.File.AppendAllText(global::Magma.Util.GetAbsoluteFilePath("Lists.txt"), "Object : " + lootWeightedEntry.obj.ToString() + "\n\n");
				}
			}
		}

		// Token: 0x060000D6 RID: 214 RVA: 0x00003E44 File Offset: 0x00002044
		public void Blocks()
		{
			foreach (global::ItemDataBlock itemDataBlock in global::DatablockDictionary.All)
			{
				global::System.IO.File.AppendAllText(global::Magma.Util.GetAbsoluteFilePath("BlocksData.txt"), "Name : " + itemDataBlock.name + "\n");
				global::System.IO.File.AppendAllText(global::Magma.Util.GetAbsoluteFilePath("BlocksData.txt"), "ID : " + itemDataBlock.uniqueID + "\n");
				global::System.IO.File.AppendAllText(global::Magma.Util.GetAbsoluteFilePath("BlocksData.txt"), "Flags : " + itemDataBlock._itemFlags.ToString() + "\n");
				global::System.IO.File.AppendAllText(global::Magma.Util.GetAbsoluteFilePath("BlocksData.txt"), "Max Condition : " + itemDataBlock._maxCondition + "\n");
				global::System.IO.File.AppendAllText(global::Magma.Util.GetAbsoluteFilePath("BlocksData.txt"), "Loose Condition : " + itemDataBlock.doesLoseCondition + "\n");
				global::System.IO.File.AppendAllText(global::Magma.Util.GetAbsoluteFilePath("BlocksData.txt"), "Max Uses : " + itemDataBlock._maxUses + "\n");
				global::System.IO.File.AppendAllText(global::Magma.Util.GetAbsoluteFilePath("BlocksData.txt"), "Mins Uses (Display) : " + itemDataBlock._minUsesForDisplay + "\n");
				global::System.IO.File.AppendAllText(global::Magma.Util.GetAbsoluteFilePath("BlocksData.txt"), "Spawn Uses Max : " + itemDataBlock._spawnUsesMax + "\n");
				global::System.IO.File.AppendAllText(global::Magma.Util.GetAbsoluteFilePath("BlocksData.txt"), "Spawn Uses Min : " + itemDataBlock._spawnUsesMin + "\n");
				global::System.IO.File.AppendAllText(global::Magma.Util.GetAbsoluteFilePath("BlocksData.txt"), "Splittable : " + itemDataBlock._splittable + "\n");
				global::System.IO.File.AppendAllText(global::Magma.Util.GetAbsoluteFilePath("BlocksData.txt"), "Category : " + itemDataBlock.category.ToString() + "\n");
				global::System.IO.File.AppendAllText(global::Magma.Util.GetAbsoluteFilePath("BlocksData.txt"), "Combinations :\n");
				foreach (global::ItemDataBlock.CombineRecipe combineRecipe in itemDataBlock.Combinations)
				{
					global::System.IO.File.AppendAllText(global::Magma.Util.GetAbsoluteFilePath("BlocksData.txt"), "\t" + combineRecipe.ToString() + "\n");
				}
				global::System.IO.File.AppendAllText(global::Magma.Util.GetAbsoluteFilePath("BlocksData.txt"), "Icon : " + itemDataBlock.icon + "\n");
				global::System.IO.File.AppendAllText(global::Magma.Util.GetAbsoluteFilePath("BlocksData.txt"), "IsRecycleable : " + itemDataBlock.isRecycleable + "\n");
				global::System.IO.File.AppendAllText(global::Magma.Util.GetAbsoluteFilePath("BlocksData.txt"), "IsRepairable : " + itemDataBlock.isRepairable + "\n");
				global::System.IO.File.AppendAllText(global::Magma.Util.GetAbsoluteFilePath("BlocksData.txt"), "IsResearchable : " + itemDataBlock.isResearchable + "\n");
				global::System.IO.File.AppendAllText(global::Magma.Util.GetAbsoluteFilePath("BlocksData.txt"), "Description : " + itemDataBlock.itemDescriptionOverride + "\n");
				if (itemDataBlock is global::BulletWeaponDataBlock)
				{
					global::BulletWeaponDataBlock bulletWeaponDataBlock = (global::BulletWeaponDataBlock)itemDataBlock;
					global::System.IO.File.AppendAllText(global::Magma.Util.GetAbsoluteFilePath("BlocksData.txt"), "Min Damage : " + bulletWeaponDataBlock.damageMin + "\n");
					global::System.IO.File.AppendAllText(global::Magma.Util.GetAbsoluteFilePath("BlocksData.txt"), "Max Damage : " + bulletWeaponDataBlock.damageMax + "\n");
					global::System.IO.File.AppendAllText(global::Magma.Util.GetAbsoluteFilePath("BlocksData.txt"), "Ammo : " + bulletWeaponDataBlock.ammoType.ToString() + "\n");
					global::System.IO.File.AppendAllText(global::Magma.Util.GetAbsoluteFilePath("BlocksData.txt"), "Recoil Duration : " + bulletWeaponDataBlock.recoilDuration + "\n");
					global::System.IO.File.AppendAllText(global::Magma.Util.GetAbsoluteFilePath("BlocksData.txt"), "RecoilPitch Min : " + bulletWeaponDataBlock.recoilPitchMin + "\n");
					global::System.IO.File.AppendAllText(global::Magma.Util.GetAbsoluteFilePath("BlocksData.txt"), "RecoilPitch Max : " + bulletWeaponDataBlock.recoilPitchMax + "\n");
					global::System.IO.File.AppendAllText(global::Magma.Util.GetAbsoluteFilePath("BlocksData.txt"), "RecoilYawn Min : " + bulletWeaponDataBlock.recoilYawMin + "\n");
					global::System.IO.File.AppendAllText(global::Magma.Util.GetAbsoluteFilePath("BlocksData.txt"), "RecoilYawn Max : " + bulletWeaponDataBlock.recoilYawMax + "\n");
					global::System.IO.File.AppendAllText(global::Magma.Util.GetAbsoluteFilePath("BlocksData.txt"), "Bullet Range : " + bulletWeaponDataBlock.bulletRange + "\n");
					global::System.IO.File.AppendAllText(global::Magma.Util.GetAbsoluteFilePath("BlocksData.txt"), "Sway : " + bulletWeaponDataBlock.aimSway + "\n");
					global::System.IO.File.AppendAllText(global::Magma.Util.GetAbsoluteFilePath("BlocksData.txt"), "SwaySpeed : " + bulletWeaponDataBlock.aimSwaySpeed + "\n");
					global::System.IO.File.AppendAllText(global::Magma.Util.GetAbsoluteFilePath("BlocksData.txt"), "Aim Sensitivity : " + bulletWeaponDataBlock.aimSensitivtyPercent + "\n");
					global::System.IO.File.AppendAllText(global::Magma.Util.GetAbsoluteFilePath("BlocksData.txt"), "FireRate : " + bulletWeaponDataBlock.fireRate + "\n");
					global::System.IO.File.AppendAllText(global::Magma.Util.GetAbsoluteFilePath("BlocksData.txt"), "FireRate Secondary : " + bulletWeaponDataBlock.fireRateSecondary + "\n");
					global::System.IO.File.AppendAllText(global::Magma.Util.GetAbsoluteFilePath("BlocksData.txt"), "Max Clip Ammo : " + bulletWeaponDataBlock.maxClipAmmo + "\n");
					global::System.IO.File.AppendAllText(global::Magma.Util.GetAbsoluteFilePath("BlocksData.txt"), "Reload Duration : " + bulletWeaponDataBlock.reloadDuration + "\n");
					global::System.IO.File.AppendAllText(global::Magma.Util.GetAbsoluteFilePath("BlocksData.txt"), "Attachment Point : " + bulletWeaponDataBlock.attachmentPoint + "\n");
				}
				global::System.IO.File.AppendAllText(global::Magma.Util.GetAbsoluteFilePath("BlocksData.txt"), "------------------------------------------------------------\n\n");
			}
		}

		// Token: 0x060000D7 RID: 215 RVA: 0x00004434 File Offset: 0x00002634
		public void Prefabs()
		{
			foreach (global::ItemDataBlock itemDataBlock in global::DatablockDictionary.All)
			{
				if (itemDataBlock is global::DeployableItemDataBlock)
				{
					global::DeployableItemDataBlock deployableItemDataBlock = itemDataBlock as global::DeployableItemDataBlock;
					global::System.IO.File.AppendAllText(global::Magma.Util.GetAbsoluteFilePath("Prefabs.txt"), string.Concat(new string[]
					{
						"[\"",
						deployableItemDataBlock.ObjectToPlace.name,
						"\", \"",
						deployableItemDataBlock.DeployableObjectPrefabName,
						"\"],\n"
					}));
				}
				else if (itemDataBlock is global::StructureComponentDataBlock)
				{
					global::StructureComponentDataBlock structureComponentDataBlock = itemDataBlock as global::StructureComponentDataBlock;
					global::System.IO.File.AppendAllText(global::Magma.Util.GetAbsoluteFilePath("Prefabs.txt"), string.Concat(new string[]
					{
						"[\"",
						structureComponentDataBlock.structureToPlacePrefab.name,
						"\", \"",
						structureComponentDataBlock.structureToPlaceName,
						"\"],\n"
					}));
				}
			}
		}

		// Token: 0x0400002C RID: 44
		private static global::Magma.World world;
	}
}
