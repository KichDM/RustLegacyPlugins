using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Google.ProtocolBuffers;
using Google.ProtocolBuffers.Descriptors;
using Google.ProtocolBuffers.FieldAccess;

namespace RustProto.Proto
{
	// Token: 0x02000279 RID: 633
	[global::System.Diagnostics.DebuggerNonUserCode]
	public static class Vitals
	{
		// Token: 0x06001667 RID: 5735 RVA: 0x0004A820 File Offset: 0x00048A20
		static Vitals()
		{
			byte[] array = global::System.Convert.FromBase64String("ChFydXN0L3ZpdGFscy5wcm90bxIJUnVzdFByb3RvIu8BCgZWaXRhbHMSEwoGaGVhbHRoGAEgASgCOgMxMDASFQoJaHlkcmF0aW9uGAIgASgCOgIzMBIWCghjYWxvcmllcxgDIAEoAjoEMTAwMBIUCglyYWRpYXRpb24YBCABKAI6ATASGQoOcmFkaWF0aW9uX2FudGkYBSABKAI6ATASFgoLYmxlZWRfc3BlZWQYBiABKAI6ATASFAoJYmxlZWRfbWF4GAcgASgCOgEwEhUKCmhlYWxfc3BlZWQYCCABKAI6ATASEwoIaGVhbF9tYXgYCSABKAI6ATASFgoLdGVtcGVyYXR1cmUYCiABKAI6ATBCAkgB");
			global::Google.ProtocolBuffers.Descriptors.FileDescriptor.InternalDescriptorAssigner internalDescriptorAssigner = delegate(global::Google.ProtocolBuffers.Descriptors.FileDescriptor root)
			{
				global::RustProto.Proto.Vitals.descriptor = root;
				global::RustProto.Proto.Vitals.internal__static_RustProto_Vitals__Descriptor = global::RustProto.Proto.Vitals.Descriptor.MessageTypes[0];
				global::RustProto.Proto.Vitals.internal__static_RustProto_Vitals__FieldAccessorTable = new global::Google.ProtocolBuffers.FieldAccess.FieldAccessorTable<global::RustProto.Vitals, global::RustProto.Vitals.Builder>(global::RustProto.Proto.Vitals.internal__static_RustProto_Vitals__Descriptor, new string[]
				{
					"Health",
					"Hydration",
					"Calories",
					"Radiation",
					"RadiationAnti",
					"BleedSpeed",
					"BleedMax",
					"HealSpeed",
					"HealMax",
					"Temperature"
				});
				return null;
			};
			global::Google.ProtocolBuffers.Descriptors.FileDescriptor.InternalBuildGeneratedFileFrom(array, new global::Google.ProtocolBuffers.Descriptors.FileDescriptor[0], internalDescriptorAssigner);
		}

		// Token: 0x06001668 RID: 5736 RVA: 0x0004A864 File Offset: 0x00048A64
		public static void RegisterAllExtensions(global::Google.ProtocolBuffers.ExtensionRegistry registry)
		{
		}

		// Token: 0x1700063C RID: 1596
		// (get) Token: 0x06001669 RID: 5737 RVA: 0x0004A868 File Offset: 0x00048A68
		public static global::Google.ProtocolBuffers.Descriptors.FileDescriptor Descriptor
		{
			get
			{
				return global::RustProto.Proto.Vitals.descriptor;
			}
		}

		// Token: 0x0600166A RID: 5738 RVA: 0x0004A870 File Offset: 0x00048A70
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static global::Google.ProtocolBuffers.ExtensionRegistry <Vitals>m__C(global::Google.ProtocolBuffers.Descriptors.FileDescriptor root)
		{
			global::RustProto.Proto.Vitals.descriptor = root;
			global::RustProto.Proto.Vitals.internal__static_RustProto_Vitals__Descriptor = global::RustProto.Proto.Vitals.Descriptor.MessageTypes[0];
			global::RustProto.Proto.Vitals.internal__static_RustProto_Vitals__FieldAccessorTable = new global::Google.ProtocolBuffers.FieldAccess.FieldAccessorTable<global::RustProto.Vitals, global::RustProto.Vitals.Builder>(global::RustProto.Proto.Vitals.internal__static_RustProto_Vitals__Descriptor, new string[]
			{
				"Health",
				"Hydration",
				"Calories",
				"Radiation",
				"RadiationAnti",
				"BleedSpeed",
				"BleedMax",
				"HealSpeed",
				"HealMax",
				"Temperature"
			});
			return null;
		}

		// Token: 0x04000B97 RID: 2967
		internal static global::Google.ProtocolBuffers.Descriptors.MessageDescriptor internal__static_RustProto_Vitals__Descriptor;

		// Token: 0x04000B98 RID: 2968
		internal static global::Google.ProtocolBuffers.FieldAccess.FieldAccessorTable<global::RustProto.Vitals, global::RustProto.Vitals.Builder> internal__static_RustProto_Vitals__FieldAccessorTable;

		// Token: 0x04000B99 RID: 2969
		private static global::Google.ProtocolBuffers.Descriptors.FileDescriptor descriptor;

		// Token: 0x04000B9A RID: 2970
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static global::Google.ProtocolBuffers.Descriptors.FileDescriptor.InternalDescriptorAssigner <>f__am$cache3;
	}
}
