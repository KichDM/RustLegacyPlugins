using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Google.ProtocolBuffers;
using Google.ProtocolBuffers.Descriptors;
using Google.ProtocolBuffers.FieldAccess;

namespace RustProto
{
	// Token: 0x0200026C RID: 620
	[global::System.Diagnostics.DebuggerNonUserCode]
	public static class Common
	{
		// Token: 0x060015AA RID: 5546 RVA: 0x00048EF0 File Offset: 0x000470F0
		static Common()
		{
			byte[] array = global::System.Convert.FromBase64String("ChFydXN0L2NvbW1vbi5wcm90bxIJUnVzdFByb3RvIjIKBlZlY3RvchIMCgF4GAEgASgCOgEwEgwKAXkYAiABKAI6ATASDAoBehgDIAEoAjoBMCJECgpRdWF0ZXJuaW9uEgwKAXgYASABKAI6ATASDAoBeRgCIAEoAjoBMBIMCgF6GAMgASgCOgEwEgwKAXcYBCABKAI6ATBCAkgB");
			global::Google.ProtocolBuffers.Descriptors.FileDescriptor.InternalDescriptorAssigner internalDescriptorAssigner = delegate(global::Google.ProtocolBuffers.Descriptors.FileDescriptor root)
			{
				global::RustProto.Common.descriptor = root;
				global::RustProto.Common.internal__static_RustProto_Vector__Descriptor = global::RustProto.Common.Descriptor.MessageTypes[0];
				global::RustProto.Common.internal__static_RustProto_Vector__FieldAccessorTable = new global::Google.ProtocolBuffers.FieldAccess.FieldAccessorTable<global::RustProto.Vector, global::RustProto.Vector.Builder>(global::RustProto.Common.internal__static_RustProto_Vector__Descriptor, new string[]
				{
					"X",
					"Y",
					"Z"
				});
				global::RustProto.Common.internal__static_RustProto_Quaternion__Descriptor = global::RustProto.Common.Descriptor.MessageTypes[1];
				global::RustProto.Common.internal__static_RustProto_Quaternion__FieldAccessorTable = new global::Google.ProtocolBuffers.FieldAccess.FieldAccessorTable<global::RustProto.Quaternion, global::RustProto.Quaternion.Builder>(global::RustProto.Common.internal__static_RustProto_Quaternion__Descriptor, new string[]
				{
					"X",
					"Y",
					"Z",
					"W"
				});
				return null;
			};
			global::Google.ProtocolBuffers.Descriptors.FileDescriptor.InternalBuildGeneratedFileFrom(array, new global::Google.ProtocolBuffers.Descriptors.FileDescriptor[0], internalDescriptorAssigner);
		}

		// Token: 0x060015AB RID: 5547 RVA: 0x00048F34 File Offset: 0x00047134
		public static void RegisterAllExtensions(global::Google.ProtocolBuffers.ExtensionRegistry registry)
		{
		}

		// Token: 0x170005F7 RID: 1527
		// (get) Token: 0x060015AC RID: 5548 RVA: 0x00048F38 File Offset: 0x00047138
		public static global::Google.ProtocolBuffers.Descriptors.FileDescriptor Descriptor
		{
			get
			{
				return global::RustProto.Common.descriptor;
			}
		}

		// Token: 0x060015AD RID: 5549 RVA: 0x00048F40 File Offset: 0x00047140
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static global::Google.ProtocolBuffers.ExtensionRegistry <Common>m__7(global::Google.ProtocolBuffers.Descriptors.FileDescriptor root)
		{
			global::RustProto.Common.descriptor = root;
			global::RustProto.Common.internal__static_RustProto_Vector__Descriptor = global::RustProto.Common.Descriptor.MessageTypes[0];
			global::RustProto.Common.internal__static_RustProto_Vector__FieldAccessorTable = new global::Google.ProtocolBuffers.FieldAccess.FieldAccessorTable<global::RustProto.Vector, global::RustProto.Vector.Builder>(global::RustProto.Common.internal__static_RustProto_Vector__Descriptor, new string[]
			{
				"X",
				"Y",
				"Z"
			});
			global::RustProto.Common.internal__static_RustProto_Quaternion__Descriptor = global::RustProto.Common.Descriptor.MessageTypes[1];
			global::RustProto.Common.internal__static_RustProto_Quaternion__FieldAccessorTable = new global::Google.ProtocolBuffers.FieldAccess.FieldAccessorTable<global::RustProto.Quaternion, global::RustProto.Quaternion.Builder>(global::RustProto.Common.internal__static_RustProto_Quaternion__Descriptor, new string[]
			{
				"X",
				"Y",
				"Z",
				"W"
			});
			return null;
		}

		// Token: 0x04000B54 RID: 2900
		internal static global::Google.ProtocolBuffers.Descriptors.MessageDescriptor internal__static_RustProto_Vector__Descriptor;

		// Token: 0x04000B55 RID: 2901
		internal static global::Google.ProtocolBuffers.FieldAccess.FieldAccessorTable<global::RustProto.Vector, global::RustProto.Vector.Builder> internal__static_RustProto_Vector__FieldAccessorTable;

		// Token: 0x04000B56 RID: 2902
		internal static global::Google.ProtocolBuffers.Descriptors.MessageDescriptor internal__static_RustProto_Quaternion__Descriptor;

		// Token: 0x04000B57 RID: 2903
		internal static global::Google.ProtocolBuffers.FieldAccess.FieldAccessorTable<global::RustProto.Quaternion, global::RustProto.Quaternion.Builder> internal__static_RustProto_Quaternion__FieldAccessorTable;

		// Token: 0x04000B58 RID: 2904
		private static global::Google.ProtocolBuffers.Descriptors.FileDescriptor descriptor;

		// Token: 0x04000B59 RID: 2905
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static global::Google.ProtocolBuffers.Descriptors.FileDescriptor.InternalDescriptorAssigner <>f__am$cache5;
	}
}
