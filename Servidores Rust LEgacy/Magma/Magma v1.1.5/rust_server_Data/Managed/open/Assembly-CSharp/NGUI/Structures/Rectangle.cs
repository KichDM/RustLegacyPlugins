using System;
using UnityEngine;

namespace NGUI.Structures
{
	// Token: 0x02000960 RID: 2400
	public struct Rectangle
	{
		// Token: 0x17000F45 RID: 3909
		// (get) Token: 0x060051D1 RID: 20945 RVA: 0x00144A00 File Offset: 0x00142C00
		// (set) Token: 0x060051D2 RID: 20946 RVA: 0x00144A34 File Offset: 0x00142C34
		public global::UnityEngine.Vector2 b
		{
			get
			{
				global::UnityEngine.Vector2 result;
				result.x = this.d.x;
				result.y = this.a.y;
				return result;
			}
			set
			{
				this.d.x = value.x;
				this.a.y = value.y;
			}
		}

		// Token: 0x17000F46 RID: 3910
		// (get) Token: 0x060051D3 RID: 20947 RVA: 0x00144A68 File Offset: 0x00142C68
		// (set) Token: 0x060051D4 RID: 20948 RVA: 0x00144A9C File Offset: 0x00142C9C
		public global::UnityEngine.Vector2 c
		{
			get
			{
				global::UnityEngine.Vector2 result;
				result.x = this.a.x;
				result.y = this.d.y;
				return result;
			}
			set
			{
				this.a.x = value.x;
				this.d.y = value.y;
			}
		}

		// Token: 0x17000F47 RID: 3911
		// (get) Token: 0x060051D5 RID: 20949 RVA: 0x00144AD0 File Offset: 0x00142CD0
		public global::UnityEngine.Vector2 dim
		{
			get
			{
				global::UnityEngine.Vector2 result;
				result.x = this.d.x - this.a.x;
				result.y = this.d.y - this.a.y;
				return result;
			}
		}

		// Token: 0x17000F48 RID: 3912
		// (get) Token: 0x060051D6 RID: 20950 RVA: 0x00144B1C File Offset: 0x00142D1C
		public global::UnityEngine.Vector2 center
		{
			get
			{
				global::UnityEngine.Vector2 result;
				result.x = this.a.x + (this.d.x - this.a.x) * 0.5f;
				result.y = this.a.y + (this.d.y - this.a.y) * 0.5f;
				return result;
			}
		}

		// Token: 0x17000F49 RID: 3913
		// (get) Token: 0x060051D7 RID: 20951 RVA: 0x00144B8C File Offset: 0x00142D8C
		public float height
		{
			get
			{
				return this.d.y - this.a.y;
			}
		}

		// Token: 0x17000F4A RID: 3914
		// (get) Token: 0x060051D8 RID: 20952 RVA: 0x00144BA8 File Offset: 0x00142DA8
		public float width
		{
			get
			{
				return this.d.x - this.a.x;
			}
		}

		// Token: 0x17000F4B RID: 3915
		public global::UnityEngine.Vector2 this[int i]
		{
			get
			{
				global::UnityEngine.Vector2 result;
				result.x = (((i & 1) != 1) ? this.a.x : this.d.x);
				result.y = (((i & 2) != 2) ? this.a.y : this.d.y);
				return result;
			}
			set
			{
				if ((i & 1) == 1)
				{
					this.d.x = value.x;
				}
				else
				{
					this.a.x = value.x;
				}
				if ((i & 2) == 2)
				{
					this.d.y = value.y;
				}
				else
				{
					this.a.y = value.y;
				}
			}
		}

		// Token: 0x04002E48 RID: 11848
		public const int size = 0x10;

		// Token: 0x04002E49 RID: 11849
		public const int halfSize = 8;

		// Token: 0x04002E4A RID: 11850
		public global::UnityEngine.Vector2 a;

		// Token: 0x04002E4B RID: 11851
		public global::UnityEngine.Vector2 d;
	}
}
