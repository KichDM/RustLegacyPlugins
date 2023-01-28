using System;
using UnityEngine;

namespace Magma.Events
{
	// Token: 0x0200000C RID: 12
	public class SpawnEvent
	{
		// Token: 0x17000027 RID: 39
		// (get) Token: 0x06000074 RID: 116 RVA: 0x00003244 File Offset: 0x00001444
		public bool CampUsed
		{
			get
			{
				return this._atCamp;
			}
		}

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x06000075 RID: 117 RVA: 0x0000324C File Offset: 0x0000144C
		// (set) Token: 0x06000076 RID: 118 RVA: 0x00003254 File Offset: 0x00001454
		public float X
		{
			get
			{
				return this._x;
			}
			set
			{
				this._x = value;
			}
		}

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x06000077 RID: 119 RVA: 0x0000325D File Offset: 0x0000145D
		// (set) Token: 0x06000078 RID: 120 RVA: 0x00003265 File Offset: 0x00001465
		public float Y
		{
			get
			{
				return this._y;
			}
			set
			{
				this._y = value;
			}
		}

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x06000079 RID: 121 RVA: 0x0000326E File Offset: 0x0000146E
		// (set) Token: 0x0600007A RID: 122 RVA: 0x00003276 File Offset: 0x00001476
		public float Z
		{
			get
			{
				return this._z;
			}
			set
			{
				this._z = value;
			}
		}

		// Token: 0x0600007B RID: 123 RVA: 0x0000327F File Offset: 0x0000147F
		public SpawnEvent(global::UnityEngine.Vector3 pos, bool camp)
		{
			this._atCamp = camp;
			this._x = pos.x;
			this._y = pos.y;
			this._z = pos.z;
		}

		// Token: 0x0400001E RID: 30
		private bool _atCamp;

		// Token: 0x0400001F RID: 31
		private float _x;

		// Token: 0x04000020 RID: 32
		private float _y;

		// Token: 0x04000021 RID: 33
		private float _z;
	}
}
