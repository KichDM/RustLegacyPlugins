using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Google.ProtocolBuffers;
using Google.ProtocolBuffers.Descriptors;
using Google.ProtocolBuffers.FieldAccess;
using RustProto.Proto;

namespace RustProto
{
	// Token: 0x0200027A RID: 634
	[global::System.Diagnostics.DebuggerNonUserCode]
	public static class Worldsave
	{
		// Token: 0x0600166B RID: 5739 RVA: 0x0004A900 File Offset: 0x00048B00
		static Worldsave()
		{
			byte[] array = global::System.Convert.FromBase64String("ChRydXN0L3dvcmxkc2F2ZS5wcm90bxIJUnVzdFByb3RvGg9ydXN0L2l0ZW0ucHJvdG8aEXJ1c3QvY29tbW9uLnByb3RvGhFydXN0L3ZpdGFscy5wcm90byIpCgpvYmplY3REb29yEg0KBVN0YXRlGAEgASgFEgwKBE9wZW4YAiABKAgiNgoQb2JqZWN0RGVwbG95YWJsZRIRCglDcmVhdG9ySUQYASABKAQSDwoHT3duZXJJRBgCIAEoBCJYChJvYmplY3RTdHJ1Y3RNYXN0ZXISCgoCSUQYASABKAUSEgoKRGVjYXlEZWxheRgCIAEoAhIRCglDcmVhdG9ySUQYAyABKAQSDwoHT3duZXJJRBgEIAEoBCJLChVvYmplY3RTdHJ1Y3RDb21wb25lbnQSCgoCSUQYASABKAUSEAoITWFzdGVySUQYAiABKAUSFAoMTWFzdGVyVmlld0lEGAMgASgFIiIKEG9iamVjdEZpcmVCYXJyZWwSDgoGT25GaXJlGAEgASgIImQKEW9iamVjdE5ldEluc3RhbmNlEhQKDHNlcnZlclByZWZhYhgBIAEoBRITCgtvd25lclByZWZhYhgCIAEoBRITCgtwcm94eVByZWZhYhgDIAEoBRIPCgdncm91cElEGAQgASgFIi0KEW9iamVjdE5HQ0luc3RhbmNlEgoKAklEGAEgASgFEgwKBGRhdGEYAiABKAwinAEKDG9iamVjdENvb3JkcxIeCgNwb3MYASABKAsyES5SdXN0UHJvdG8uVmVjdG9yEiEKBm9sZFBvcxgCIAEoCzIRLlJ1c3RQcm90by5WZWN0b3ISIgoDcm90GAMgASgLMhUuUnVzdFByb3RvLlF1YXRlcm5pb24SJQoGb2xkUm90GAQgASgLMhUuUnVzdFByb3RvLlF1YXRlcm5pb24iLwoVb2JqZWN0SUNhcnJpYWJsZVRyYW5zEhYKDnRyYW5zQ2FycmllcklEGAEgASgFIiIKEG9iamVjdFRha2VEYW1hZ2USDgoGaGVhbHRoGAEgASgCIpgBChRvYmplY3RTbGVlcGluZ0F2YXRhchIRCglmb290QXJtb3IYASABKAUSEAoIbGVnQXJtb3IYAiABKAUSEgoKdG9yc29Bcm1vchgDIAEoBRIRCgloZWFkQXJtb3IYBCABKAUSEQoJdGltZXN0YW1wGAUgASgFEiEKBnZpdGFscxgGIAEoCzIRLlJ1c3RQcm90by5WaXRhbHMiQQoOb2JqZWN0TG9ja2FibGUSEAoIcGFzc3dvcmQYASABKAkSDgoGbG9ja2VkGAIgASgIEg0KBXVzZXJzGAMgAygEIqcFCgtTYXZlZE9iamVjdBIKCgJpZBgBIAEoBRIjCgRkb29yGAIgASgLMhUuUnVzdFByb3RvLm9iamVjdERvb3ISIgoJaW52ZW50b3J5GAMgAygLMg8uUnVzdFByb3RvLkl0ZW0SLwoKZGVwbG95YWJsZRgEIAEoCzIbLlJ1c3RQcm90by5vYmplY3REZXBsb3lhYmxlEjMKDHN0cnVjdE1hc3RlchgFIAEoCzIdLlJ1c3RQcm90by5vYmplY3RTdHJ1Y3RNYXN0ZXISOQoPc3RydWN0Q29tcG9uZW50GAYgASgLMiAuUnVzdFByb3RvLm9iamVjdFN0cnVjdENvbXBvbmVudBIvCgpmaXJlQmFycmVsGAcgASgLMhsuUnVzdFByb3RvLm9iamVjdEZpcmVCYXJyZWwSMQoLbmV0SW5zdGFuY2UYCCABKAsyHC5SdXN0UHJvdG8ub2JqZWN0TmV0SW5zdGFuY2USJwoGY29vcmRzGAkgASgLMhcuUnVzdFByb3RvLm9iamVjdENvb3JkcxIxCgtuZ2NJbnN0YW5jZRgKIAEoCzIcLlJ1c3RQcm90by5vYmplY3ROR0NJbnN0YW5jZRI4Cg5jYXJyaWFibGVUcmFucxgLIAEoCzIgLlJ1c3RQcm90by5vYmplY3RJQ2FycmlhYmxlVHJhbnMSLwoKdGFrZURhbWFnZRgMIAEoCzIbLlJ1c3RQcm90by5vYmplY3RUYWtlRGFtYWdlEhEKCXNvcnRPcmRlchgNIAEoBRI3Cg5zbGVlcGluZ0F2YXRhchgOIAEoCzIfLlJ1c3RQcm90by5vYmplY3RTbGVlcGluZ0F2YXRhchIrCghsb2NrYWJsZRgPIAEoCzIZLlJ1c3RQcm90by5vYmplY3RMb2NrYWJsZSJoCglXb3JsZFNhdmUSKwoLc2NlbmVPYmplY3QYASADKAsyFi5SdXN0UHJvdG8uU2F2ZWRPYmplY3QSLgoOaW5zdGFuY2VPYmplY3QYAiADKAsyFi5SdXN0UHJvdG8uU2F2ZWRPYmplY3RCAkgB");
			global::Google.ProtocolBuffers.Descriptors.FileDescriptor.InternalDescriptorAssigner internalDescriptorAssigner = delegate(global::Google.ProtocolBuffers.Descriptors.FileDescriptor root)
			{
				global::RustProto.Worldsave.descriptor = root;
				global::RustProto.Worldsave.internal__static_RustProto_objectDoor__Descriptor = global::RustProto.Worldsave.Descriptor.MessageTypes[0];
				global::RustProto.Worldsave.internal__static_RustProto_objectDoor__FieldAccessorTable = new global::Google.ProtocolBuffers.FieldAccess.FieldAccessorTable<global::RustProto.objectDoor, global::RustProto.objectDoor.Builder>(global::RustProto.Worldsave.internal__static_RustProto_objectDoor__Descriptor, new string[]
				{
					"State",
					"Open"
				});
				global::RustProto.Worldsave.internal__static_RustProto_objectDeployable__Descriptor = global::RustProto.Worldsave.Descriptor.MessageTypes[1];
				global::RustProto.Worldsave.internal__static_RustProto_objectDeployable__FieldAccessorTable = new global::Google.ProtocolBuffers.FieldAccess.FieldAccessorTable<global::RustProto.objectDeployable, global::RustProto.objectDeployable.Builder>(global::RustProto.Worldsave.internal__static_RustProto_objectDeployable__Descriptor, new string[]
				{
					"CreatorID",
					"OwnerID"
				});
				global::RustProto.Worldsave.internal__static_RustProto_objectStructMaster__Descriptor = global::RustProto.Worldsave.Descriptor.MessageTypes[2];
				global::RustProto.Worldsave.internal__static_RustProto_objectStructMaster__FieldAccessorTable = new global::Google.ProtocolBuffers.FieldAccess.FieldAccessorTable<global::RustProto.objectStructMaster, global::RustProto.objectStructMaster.Builder>(global::RustProto.Worldsave.internal__static_RustProto_objectStructMaster__Descriptor, new string[]
				{
					"ID",
					"DecayDelay",
					"CreatorID",
					"OwnerID"
				});
				global::RustProto.Worldsave.internal__static_RustProto_objectStructComponent__Descriptor = global::RustProto.Worldsave.Descriptor.MessageTypes[3];
				global::RustProto.Worldsave.internal__static_RustProto_objectStructComponent__FieldAccessorTable = new global::Google.ProtocolBuffers.FieldAccess.FieldAccessorTable<global::RustProto.objectStructComponent, global::RustProto.objectStructComponent.Builder>(global::RustProto.Worldsave.internal__static_RustProto_objectStructComponent__Descriptor, new string[]
				{
					"ID",
					"MasterID",
					"MasterViewID"
				});
				global::RustProto.Worldsave.internal__static_RustProto_objectFireBarrel__Descriptor = global::RustProto.Worldsave.Descriptor.MessageTypes[4];
				global::RustProto.Worldsave.internal__static_RustProto_objectFireBarrel__FieldAccessorTable = new global::Google.ProtocolBuffers.FieldAccess.FieldAccessorTable<global::RustProto.objectFireBarrel, global::RustProto.objectFireBarrel.Builder>(global::RustProto.Worldsave.internal__static_RustProto_objectFireBarrel__Descriptor, new string[]
				{
					"OnFire"
				});
				global::RustProto.Worldsave.internal__static_RustProto_objectNetInstance__Descriptor = global::RustProto.Worldsave.Descriptor.MessageTypes[5];
				global::RustProto.Worldsave.internal__static_RustProto_objectNetInstance__FieldAccessorTable = new global::Google.ProtocolBuffers.FieldAccess.FieldAccessorTable<global::RustProto.objectNetInstance, global::RustProto.objectNetInstance.Builder>(global::RustProto.Worldsave.internal__static_RustProto_objectNetInstance__Descriptor, new string[]
				{
					"ServerPrefab",
					"OwnerPrefab",
					"ProxyPrefab",
					"GroupID"
				});
				global::RustProto.Worldsave.internal__static_RustProto_objectNGCInstance__Descriptor = global::RustProto.Worldsave.Descriptor.MessageTypes[6];
				global::RustProto.Worldsave.internal__static_RustProto_objectNGCInstance__FieldAccessorTable = new global::Google.ProtocolBuffers.FieldAccess.FieldAccessorTable<global::RustProto.objectNGCInstance, global::RustProto.objectNGCInstance.Builder>(global::RustProto.Worldsave.internal__static_RustProto_objectNGCInstance__Descriptor, new string[]
				{
					"ID",
					"Data"
				});
				global::RustProto.Worldsave.internal__static_RustProto_objectCoords__Descriptor = global::RustProto.Worldsave.Descriptor.MessageTypes[7];
				global::RustProto.Worldsave.internal__static_RustProto_objectCoords__FieldAccessorTable = new global::Google.ProtocolBuffers.FieldAccess.FieldAccessorTable<global::RustProto.objectCoords, global::RustProto.objectCoords.Builder>(global::RustProto.Worldsave.internal__static_RustProto_objectCoords__Descriptor, new string[]
				{
					"Pos",
					"OldPos",
					"Rot",
					"OldRot"
				});
				global::RustProto.Worldsave.internal__static_RustProto_objectICarriableTrans__Descriptor = global::RustProto.Worldsave.Descriptor.MessageTypes[8];
				global::RustProto.Worldsave.internal__static_RustProto_objectICarriableTrans__FieldAccessorTable = new global::Google.ProtocolBuffers.FieldAccess.FieldAccessorTable<global::RustProto.objectICarriableTrans, global::RustProto.objectICarriableTrans.Builder>(global::RustProto.Worldsave.internal__static_RustProto_objectICarriableTrans__Descriptor, new string[]
				{
					"TransCarrierID"
				});
				global::RustProto.Worldsave.internal__static_RustProto_objectTakeDamage__Descriptor = global::RustProto.Worldsave.Descriptor.MessageTypes[9];
				global::RustProto.Worldsave.internal__static_RustProto_objectTakeDamage__FieldAccessorTable = new global::Google.ProtocolBuffers.FieldAccess.FieldAccessorTable<global::RustProto.objectTakeDamage, global::RustProto.objectTakeDamage.Builder>(global::RustProto.Worldsave.internal__static_RustProto_objectTakeDamage__Descriptor, new string[]
				{
					"Health"
				});
				global::RustProto.Worldsave.internal__static_RustProto_objectSleepingAvatar__Descriptor = global::RustProto.Worldsave.Descriptor.MessageTypes[0xA];
				global::RustProto.Worldsave.internal__static_RustProto_objectSleepingAvatar__FieldAccessorTable = new global::Google.ProtocolBuffers.FieldAccess.FieldAccessorTable<global::RustProto.objectSleepingAvatar, global::RustProto.objectSleepingAvatar.Builder>(global::RustProto.Worldsave.internal__static_RustProto_objectSleepingAvatar__Descriptor, new string[]
				{
					"FootArmor",
					"LegArmor",
					"TorsoArmor",
					"HeadArmor",
					"Timestamp",
					"Vitals"
				});
				global::RustProto.Worldsave.internal__static_RustProto_objectLockable__Descriptor = global::RustProto.Worldsave.Descriptor.MessageTypes[0xB];
				global::RustProto.Worldsave.internal__static_RustProto_objectLockable__FieldAccessorTable = new global::Google.ProtocolBuffers.FieldAccess.FieldAccessorTable<global::RustProto.objectLockable, global::RustProto.objectLockable.Builder>(global::RustProto.Worldsave.internal__static_RustProto_objectLockable__Descriptor, new string[]
				{
					"Password",
					"Locked",
					"Users"
				});
				global::RustProto.Worldsave.internal__static_RustProto_SavedObject__Descriptor = global::RustProto.Worldsave.Descriptor.MessageTypes[0xC];
				global::RustProto.Worldsave.internal__static_RustProto_SavedObject__FieldAccessorTable = new global::Google.ProtocolBuffers.FieldAccess.FieldAccessorTable<global::RustProto.SavedObject, global::RustProto.SavedObject.Builder>(global::RustProto.Worldsave.internal__static_RustProto_SavedObject__Descriptor, new string[]
				{
					"Id",
					"Door",
					"Inventory",
					"Deployable",
					"StructMaster",
					"StructComponent",
					"FireBarrel",
					"NetInstance",
					"Coords",
					"NgcInstance",
					"CarriableTrans",
					"TakeDamage",
					"SortOrder",
					"SleepingAvatar",
					"Lockable"
				});
				global::RustProto.Worldsave.internal__static_RustProto_WorldSave__Descriptor = global::RustProto.Worldsave.Descriptor.MessageTypes[0xD];
				global::RustProto.Worldsave.internal__static_RustProto_WorldSave__FieldAccessorTable = new global::Google.ProtocolBuffers.FieldAccess.FieldAccessorTable<global::RustProto.WorldSave, global::RustProto.WorldSave.Builder>(global::RustProto.Worldsave.internal__static_RustProto_WorldSave__Descriptor, new string[]
				{
					"SceneObject",
					"InstanceObject"
				});
				return null;
			};
			global::Google.ProtocolBuffers.Descriptors.FileDescriptor.InternalBuildGeneratedFileFrom(array, new global::Google.ProtocolBuffers.Descriptors.FileDescriptor[]
			{
				global::RustProto.Proto.Item.Descriptor,
				global::RustProto.Common.Descriptor,
				global::RustProto.Proto.Vitals.Descriptor
			}, internalDescriptorAssigner);
		}

		// Token: 0x0600166C RID: 5740 RVA: 0x0004A95C File Offset: 0x00048B5C
		public static void RegisterAllExtensions(global::Google.ProtocolBuffers.ExtensionRegistry registry)
		{
		}

		// Token: 0x1700063D RID: 1597
		// (get) Token: 0x0600166D RID: 5741 RVA: 0x0004A960 File Offset: 0x00048B60
		public static global::Google.ProtocolBuffers.Descriptors.FileDescriptor Descriptor
		{
			get
			{
				return global::RustProto.Worldsave.descriptor;
			}
		}

		// Token: 0x0600166E RID: 5742 RVA: 0x0004A968 File Offset: 0x00048B68
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static global::Google.ProtocolBuffers.ExtensionRegistry <Worldsave>m__D(global::Google.ProtocolBuffers.Descriptors.FileDescriptor root)
		{
			global::RustProto.Worldsave.descriptor = root;
			global::RustProto.Worldsave.internal__static_RustProto_objectDoor__Descriptor = global::RustProto.Worldsave.Descriptor.MessageTypes[0];
			global::RustProto.Worldsave.internal__static_RustProto_objectDoor__FieldAccessorTable = new global::Google.ProtocolBuffers.FieldAccess.FieldAccessorTable<global::RustProto.objectDoor, global::RustProto.objectDoor.Builder>(global::RustProto.Worldsave.internal__static_RustProto_objectDoor__Descriptor, new string[]
			{
				"State",
				"Open"
			});
			global::RustProto.Worldsave.internal__static_RustProto_objectDeployable__Descriptor = global::RustProto.Worldsave.Descriptor.MessageTypes[1];
			global::RustProto.Worldsave.internal__static_RustProto_objectDeployable__FieldAccessorTable = new global::Google.ProtocolBuffers.FieldAccess.FieldAccessorTable<global::RustProto.objectDeployable, global::RustProto.objectDeployable.Builder>(global::RustProto.Worldsave.internal__static_RustProto_objectDeployable__Descriptor, new string[]
			{
				"CreatorID",
				"OwnerID"
			});
			global::RustProto.Worldsave.internal__static_RustProto_objectStructMaster__Descriptor = global::RustProto.Worldsave.Descriptor.MessageTypes[2];
			global::RustProto.Worldsave.internal__static_RustProto_objectStructMaster__FieldAccessorTable = new global::Google.ProtocolBuffers.FieldAccess.FieldAccessorTable<global::RustProto.objectStructMaster, global::RustProto.objectStructMaster.Builder>(global::RustProto.Worldsave.internal__static_RustProto_objectStructMaster__Descriptor, new string[]
			{
				"ID",
				"DecayDelay",
				"CreatorID",
				"OwnerID"
			});
			global::RustProto.Worldsave.internal__static_RustProto_objectStructComponent__Descriptor = global::RustProto.Worldsave.Descriptor.MessageTypes[3];
			global::RustProto.Worldsave.internal__static_RustProto_objectStructComponent__FieldAccessorTable = new global::Google.ProtocolBuffers.FieldAccess.FieldAccessorTable<global::RustProto.objectStructComponent, global::RustProto.objectStructComponent.Builder>(global::RustProto.Worldsave.internal__static_RustProto_objectStructComponent__Descriptor, new string[]
			{
				"ID",
				"MasterID",
				"MasterViewID"
			});
			global::RustProto.Worldsave.internal__static_RustProto_objectFireBarrel__Descriptor = global::RustProto.Worldsave.Descriptor.MessageTypes[4];
			global::RustProto.Worldsave.internal__static_RustProto_objectFireBarrel__FieldAccessorTable = new global::Google.ProtocolBuffers.FieldAccess.FieldAccessorTable<global::RustProto.objectFireBarrel, global::RustProto.objectFireBarrel.Builder>(global::RustProto.Worldsave.internal__static_RustProto_objectFireBarrel__Descriptor, new string[]
			{
				"OnFire"
			});
			global::RustProto.Worldsave.internal__static_RustProto_objectNetInstance__Descriptor = global::RustProto.Worldsave.Descriptor.MessageTypes[5];
			global::RustProto.Worldsave.internal__static_RustProto_objectNetInstance__FieldAccessorTable = new global::Google.ProtocolBuffers.FieldAccess.FieldAccessorTable<global::RustProto.objectNetInstance, global::RustProto.objectNetInstance.Builder>(global::RustProto.Worldsave.internal__static_RustProto_objectNetInstance__Descriptor, new string[]
			{
				"ServerPrefab",
				"OwnerPrefab",
				"ProxyPrefab",
				"GroupID"
			});
			global::RustProto.Worldsave.internal__static_RustProto_objectNGCInstance__Descriptor = global::RustProto.Worldsave.Descriptor.MessageTypes[6];
			global::RustProto.Worldsave.internal__static_RustProto_objectNGCInstance__FieldAccessorTable = new global::Google.ProtocolBuffers.FieldAccess.FieldAccessorTable<global::RustProto.objectNGCInstance, global::RustProto.objectNGCInstance.Builder>(global::RustProto.Worldsave.internal__static_RustProto_objectNGCInstance__Descriptor, new string[]
			{
				"ID",
				"Data"
			});
			global::RustProto.Worldsave.internal__static_RustProto_objectCoords__Descriptor = global::RustProto.Worldsave.Descriptor.MessageTypes[7];
			global::RustProto.Worldsave.internal__static_RustProto_objectCoords__FieldAccessorTable = new global::Google.ProtocolBuffers.FieldAccess.FieldAccessorTable<global::RustProto.objectCoords, global::RustProto.objectCoords.Builder>(global::RustProto.Worldsave.internal__static_RustProto_objectCoords__Descriptor, new string[]
			{
				"Pos",
				"OldPos",
				"Rot",
				"OldRot"
			});
			global::RustProto.Worldsave.internal__static_RustProto_objectICarriableTrans__Descriptor = global::RustProto.Worldsave.Descriptor.MessageTypes[8];
			global::RustProto.Worldsave.internal__static_RustProto_objectICarriableTrans__FieldAccessorTable = new global::Google.ProtocolBuffers.FieldAccess.FieldAccessorTable<global::RustProto.objectICarriableTrans, global::RustProto.objectICarriableTrans.Builder>(global::RustProto.Worldsave.internal__static_RustProto_objectICarriableTrans__Descriptor, new string[]
			{
				"TransCarrierID"
			});
			global::RustProto.Worldsave.internal__static_RustProto_objectTakeDamage__Descriptor = global::RustProto.Worldsave.Descriptor.MessageTypes[9];
			global::RustProto.Worldsave.internal__static_RustProto_objectTakeDamage__FieldAccessorTable = new global::Google.ProtocolBuffers.FieldAccess.FieldAccessorTable<global::RustProto.objectTakeDamage, global::RustProto.objectTakeDamage.Builder>(global::RustProto.Worldsave.internal__static_RustProto_objectTakeDamage__Descriptor, new string[]
			{
				"Health"
			});
			global::RustProto.Worldsave.internal__static_RustProto_objectSleepingAvatar__Descriptor = global::RustProto.Worldsave.Descriptor.MessageTypes[0xA];
			global::RustProto.Worldsave.internal__static_RustProto_objectSleepingAvatar__FieldAccessorTable = new global::Google.ProtocolBuffers.FieldAccess.FieldAccessorTable<global::RustProto.objectSleepingAvatar, global::RustProto.objectSleepingAvatar.Builder>(global::RustProto.Worldsave.internal__static_RustProto_objectSleepingAvatar__Descriptor, new string[]
			{
				"FootArmor",
				"LegArmor",
				"TorsoArmor",
				"HeadArmor",
				"Timestamp",
				"Vitals"
			});
			global::RustProto.Worldsave.internal__static_RustProto_objectLockable__Descriptor = global::RustProto.Worldsave.Descriptor.MessageTypes[0xB];
			global::RustProto.Worldsave.internal__static_RustProto_objectLockable__FieldAccessorTable = new global::Google.ProtocolBuffers.FieldAccess.FieldAccessorTable<global::RustProto.objectLockable, global::RustProto.objectLockable.Builder>(global::RustProto.Worldsave.internal__static_RustProto_objectLockable__Descriptor, new string[]
			{
				"Password",
				"Locked",
				"Users"
			});
			global::RustProto.Worldsave.internal__static_RustProto_SavedObject__Descriptor = global::RustProto.Worldsave.Descriptor.MessageTypes[0xC];
			global::RustProto.Worldsave.internal__static_RustProto_SavedObject__FieldAccessorTable = new global::Google.ProtocolBuffers.FieldAccess.FieldAccessorTable<global::RustProto.SavedObject, global::RustProto.SavedObject.Builder>(global::RustProto.Worldsave.internal__static_RustProto_SavedObject__Descriptor, new string[]
			{
				"Id",
				"Door",
				"Inventory",
				"Deployable",
				"StructMaster",
				"StructComponent",
				"FireBarrel",
				"NetInstance",
				"Coords",
				"NgcInstance",
				"CarriableTrans",
				"TakeDamage",
				"SortOrder",
				"SleepingAvatar",
				"Lockable"
			});
			global::RustProto.Worldsave.internal__static_RustProto_WorldSave__Descriptor = global::RustProto.Worldsave.Descriptor.MessageTypes[0xD];
			global::RustProto.Worldsave.internal__static_RustProto_WorldSave__FieldAccessorTable = new global::Google.ProtocolBuffers.FieldAccess.FieldAccessorTable<global::RustProto.WorldSave, global::RustProto.WorldSave.Builder>(global::RustProto.Worldsave.internal__static_RustProto_WorldSave__Descriptor, new string[]
			{
				"SceneObject",
				"InstanceObject"
			});
			return null;
		}

		// Token: 0x04000B9B RID: 2971
		internal static global::Google.ProtocolBuffers.Descriptors.MessageDescriptor internal__static_RustProto_objectDoor__Descriptor;

		// Token: 0x04000B9C RID: 2972
		internal static global::Google.ProtocolBuffers.FieldAccess.FieldAccessorTable<global::RustProto.objectDoor, global::RustProto.objectDoor.Builder> internal__static_RustProto_objectDoor__FieldAccessorTable;

		// Token: 0x04000B9D RID: 2973
		internal static global::Google.ProtocolBuffers.Descriptors.MessageDescriptor internal__static_RustProto_objectDeployable__Descriptor;

		// Token: 0x04000B9E RID: 2974
		internal static global::Google.ProtocolBuffers.FieldAccess.FieldAccessorTable<global::RustProto.objectDeployable, global::RustProto.objectDeployable.Builder> internal__static_RustProto_objectDeployable__FieldAccessorTable;

		// Token: 0x04000B9F RID: 2975
		internal static global::Google.ProtocolBuffers.Descriptors.MessageDescriptor internal__static_RustProto_objectStructMaster__Descriptor;

		// Token: 0x04000BA0 RID: 2976
		internal static global::Google.ProtocolBuffers.FieldAccess.FieldAccessorTable<global::RustProto.objectStructMaster, global::RustProto.objectStructMaster.Builder> internal__static_RustProto_objectStructMaster__FieldAccessorTable;

		// Token: 0x04000BA1 RID: 2977
		internal static global::Google.ProtocolBuffers.Descriptors.MessageDescriptor internal__static_RustProto_objectStructComponent__Descriptor;

		// Token: 0x04000BA2 RID: 2978
		internal static global::Google.ProtocolBuffers.FieldAccess.FieldAccessorTable<global::RustProto.objectStructComponent, global::RustProto.objectStructComponent.Builder> internal__static_RustProto_objectStructComponent__FieldAccessorTable;

		// Token: 0x04000BA3 RID: 2979
		internal static global::Google.ProtocolBuffers.Descriptors.MessageDescriptor internal__static_RustProto_objectFireBarrel__Descriptor;

		// Token: 0x04000BA4 RID: 2980
		internal static global::Google.ProtocolBuffers.FieldAccess.FieldAccessorTable<global::RustProto.objectFireBarrel, global::RustProto.objectFireBarrel.Builder> internal__static_RustProto_objectFireBarrel__FieldAccessorTable;

		// Token: 0x04000BA5 RID: 2981
		internal static global::Google.ProtocolBuffers.Descriptors.MessageDescriptor internal__static_RustProto_objectNetInstance__Descriptor;

		// Token: 0x04000BA6 RID: 2982
		internal static global::Google.ProtocolBuffers.FieldAccess.FieldAccessorTable<global::RustProto.objectNetInstance, global::RustProto.objectNetInstance.Builder> internal__static_RustProto_objectNetInstance__FieldAccessorTable;

		// Token: 0x04000BA7 RID: 2983
		internal static global::Google.ProtocolBuffers.Descriptors.MessageDescriptor internal__static_RustProto_objectNGCInstance__Descriptor;

		// Token: 0x04000BA8 RID: 2984
		internal static global::Google.ProtocolBuffers.FieldAccess.FieldAccessorTable<global::RustProto.objectNGCInstance, global::RustProto.objectNGCInstance.Builder> internal__static_RustProto_objectNGCInstance__FieldAccessorTable;

		// Token: 0x04000BA9 RID: 2985
		internal static global::Google.ProtocolBuffers.Descriptors.MessageDescriptor internal__static_RustProto_objectCoords__Descriptor;

		// Token: 0x04000BAA RID: 2986
		internal static global::Google.ProtocolBuffers.FieldAccess.FieldAccessorTable<global::RustProto.objectCoords, global::RustProto.objectCoords.Builder> internal__static_RustProto_objectCoords__FieldAccessorTable;

		// Token: 0x04000BAB RID: 2987
		internal static global::Google.ProtocolBuffers.Descriptors.MessageDescriptor internal__static_RustProto_objectICarriableTrans__Descriptor;

		// Token: 0x04000BAC RID: 2988
		internal static global::Google.ProtocolBuffers.FieldAccess.FieldAccessorTable<global::RustProto.objectICarriableTrans, global::RustProto.objectICarriableTrans.Builder> internal__static_RustProto_objectICarriableTrans__FieldAccessorTable;

		// Token: 0x04000BAD RID: 2989
		internal static global::Google.ProtocolBuffers.Descriptors.MessageDescriptor internal__static_RustProto_objectTakeDamage__Descriptor;

		// Token: 0x04000BAE RID: 2990
		internal static global::Google.ProtocolBuffers.FieldAccess.FieldAccessorTable<global::RustProto.objectTakeDamage, global::RustProto.objectTakeDamage.Builder> internal__static_RustProto_objectTakeDamage__FieldAccessorTable;

		// Token: 0x04000BAF RID: 2991
		internal static global::Google.ProtocolBuffers.Descriptors.MessageDescriptor internal__static_RustProto_objectSleepingAvatar__Descriptor;

		// Token: 0x04000BB0 RID: 2992
		internal static global::Google.ProtocolBuffers.FieldAccess.FieldAccessorTable<global::RustProto.objectSleepingAvatar, global::RustProto.objectSleepingAvatar.Builder> internal__static_RustProto_objectSleepingAvatar__FieldAccessorTable;

		// Token: 0x04000BB1 RID: 2993
		internal static global::Google.ProtocolBuffers.Descriptors.MessageDescriptor internal__static_RustProto_objectLockable__Descriptor;

		// Token: 0x04000BB2 RID: 2994
		internal static global::Google.ProtocolBuffers.FieldAccess.FieldAccessorTable<global::RustProto.objectLockable, global::RustProto.objectLockable.Builder> internal__static_RustProto_objectLockable__FieldAccessorTable;

		// Token: 0x04000BB3 RID: 2995
		internal static global::Google.ProtocolBuffers.Descriptors.MessageDescriptor internal__static_RustProto_SavedObject__Descriptor;

		// Token: 0x04000BB4 RID: 2996
		internal static global::Google.ProtocolBuffers.FieldAccess.FieldAccessorTable<global::RustProto.SavedObject, global::RustProto.SavedObject.Builder> internal__static_RustProto_SavedObject__FieldAccessorTable;

		// Token: 0x04000BB5 RID: 2997
		internal static global::Google.ProtocolBuffers.Descriptors.MessageDescriptor internal__static_RustProto_WorldSave__Descriptor;

		// Token: 0x04000BB6 RID: 2998
		internal static global::Google.ProtocolBuffers.FieldAccess.FieldAccessorTable<global::RustProto.WorldSave, global::RustProto.WorldSave.Builder> internal__static_RustProto_WorldSave__FieldAccessorTable;

		// Token: 0x04000BB7 RID: 2999
		private static global::Google.ProtocolBuffers.Descriptors.FileDescriptor descriptor;

		// Token: 0x04000BB8 RID: 3000
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static global::Google.ProtocolBuffers.Descriptors.FileDescriptor.InternalDescriptorAssigner <>f__am$cache1D;
	}
}
