using System;
using UnityEngine;

// Token: 0x0200027F RID: 639
public struct BBox
{
	// Token: 0x17000679 RID: 1657
	public global::UnityEngine.Vector3 this[int corner]
	{
		get
		{
			switch (corner)
			{
			case 0:
				return this.a;
			case 1:
				return this.b;
			case 2:
				return this.c;
			case 3:
				return this.d;
			case 4:
				return this.e;
			case 5:
				return this.f;
			case 6:
				return this.g;
			case 7:
				return this.h;
			default:
				throw new global::System.ArgumentOutOfRangeException("corner");
			}
		}
		set
		{
			switch (corner)
			{
			case 0:
				this.a = value;
				break;
			case 1:
				this.b = value;
				break;
			case 2:
				this.c = value;
				break;
			case 3:
				this.d = value;
				break;
			case 4:
				this.e = value;
				break;
			case 5:
				this.f = value;
				break;
			case 6:
				this.g = value;
				break;
			case 7:
				this.h = value;
				break;
			default:
				throw new global::System.ArgumentOutOfRangeException("corner");
			}
		}
	}

	// Token: 0x1700067A RID: 1658
	public float this[int corner, int axis]
	{
		get
		{
			switch (corner)
			{
			case 0:
				return this.a[axis];
			case 1:
				return this.b[axis];
			case 2:
				return this.c[axis];
			case 3:
				return this.d[axis];
			case 4:
				return this.e[axis];
			case 5:
				return this.f[axis];
			case 6:
				return this.g[axis];
			case 7:
				return this.h[axis];
			default:
				throw new global::System.ArgumentOutOfRangeException("corner");
			}
		}
		set
		{
			switch (corner)
			{
			case 0:
				this.a[axis] = value;
				break;
			case 1:
				this.b[axis] = value;
				break;
			case 2:
				this.c[axis] = value;
				break;
			case 3:
				this.d[axis] = value;
				break;
			case 4:
				this.e[axis] = value;
				break;
			case 5:
				this.f[axis] = value;
				break;
			case 6:
				this.g[axis] = value;
				break;
			case 7:
				this.h[axis] = value;
				break;
			default:
				throw new global::System.ArgumentOutOfRangeException("corner");
			}
		}
	}

	// Token: 0x04000BD3 RID: 3027
	public global::UnityEngine.Vector3 a;

	// Token: 0x04000BD4 RID: 3028
	public global::UnityEngine.Vector3 b;

	// Token: 0x04000BD5 RID: 3029
	public global::UnityEngine.Vector3 c;

	// Token: 0x04000BD6 RID: 3030
	public global::UnityEngine.Vector3 d;

	// Token: 0x04000BD7 RID: 3031
	public global::UnityEngine.Vector3 e;

	// Token: 0x04000BD8 RID: 3032
	public global::UnityEngine.Vector3 f;

	// Token: 0x04000BD9 RID: 3033
	public global::UnityEngine.Vector3 g;

	// Token: 0x04000BDA RID: 3034
	public global::UnityEngine.Vector3 h;
}
