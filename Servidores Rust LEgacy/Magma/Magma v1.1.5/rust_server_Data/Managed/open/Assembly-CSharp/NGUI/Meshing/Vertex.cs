using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace NGUI.Meshing
{
	// Token: 0x020008FB RID: 2299
	[global::System.Runtime.InteropServices.StructLayout(global::System.Runtime.InteropServices.LayoutKind.Explicit, Size = 0x24)]
	public struct Vertex
	{
		// Token: 0x17000E8A RID: 3722
		// (get) Token: 0x06004ECC RID: 20172 RVA: 0x0012F500 File Offset: 0x0012D700
		// (set) Token: 0x06004ECD RID: 20173 RVA: 0x0012F538 File Offset: 0x0012D738
		public global::UnityEngine.Vector3 position
		{
			get
			{
				global::UnityEngine.Vector3 result;
				result.x = this.x;
				result.y = this.y;
				result.z = this.z;
				return result;
			}
			set
			{
				this.x = value.x;
				this.y = value.y;
				this.z = value.z;
			}
		}

		// Token: 0x17000E8B RID: 3723
		// (get) Token: 0x06004ECE RID: 20174 RVA: 0x0012F570 File Offset: 0x0012D770
		// (set) Token: 0x06004ECF RID: 20175 RVA: 0x0012F59C File Offset: 0x0012D79C
		public global::UnityEngine.Vector2 texcoord
		{
			get
			{
				global::UnityEngine.Vector2 result;
				result.x = this.u;
				result.y = this.v;
				return result;
			}
			set
			{
				this.u = value.x;
				this.v = value.y;
			}
		}

		// Token: 0x17000E8C RID: 3724
		// (get) Token: 0x06004ED0 RID: 20176 RVA: 0x0012F5BC File Offset: 0x0012D7BC
		// (set) Token: 0x06004ED1 RID: 20177 RVA: 0x0012F604 File Offset: 0x0012D804
		public global::UnityEngine.Color color
		{
			get
			{
				global::UnityEngine.Color result;
				result.r = this.r;
				result.g = this.g;
				result.b = this.b;
				result.a = this.a;
				return result;
			}
			set
			{
				this.r = value.r;
				this.g = value.g;
				this.b = value.b;
				this.a = value.a;
			}
		}

		// Token: 0x04002B6A RID: 11114
		[global::System.Runtime.InteropServices.FieldOffset(0)]
		public float x;

		// Token: 0x04002B6B RID: 11115
		[global::System.Runtime.InteropServices.FieldOffset(4)]
		public float y;

		// Token: 0x04002B6C RID: 11116
		[global::System.Runtime.InteropServices.FieldOffset(8)]
		public float z;

		// Token: 0x04002B6D RID: 11117
		[global::System.Runtime.InteropServices.FieldOffset(0xC)]
		public float u;

		// Token: 0x04002B6E RID: 11118
		[global::System.Runtime.InteropServices.FieldOffset(0x10)]
		public float v;

		// Token: 0x04002B6F RID: 11119
		[global::System.Runtime.InteropServices.FieldOffset(0x14)]
		public float r;

		// Token: 0x04002B70 RID: 11120
		[global::System.Runtime.InteropServices.FieldOffset(0x18)]
		public float g;

		// Token: 0x04002B71 RID: 11121
		[global::System.Runtime.InteropServices.FieldOffset(0x1C)]
		public float b;

		// Token: 0x04002B72 RID: 11122
		[global::System.Runtime.InteropServices.FieldOffset(0x20)]
		public float a;
	}
}
