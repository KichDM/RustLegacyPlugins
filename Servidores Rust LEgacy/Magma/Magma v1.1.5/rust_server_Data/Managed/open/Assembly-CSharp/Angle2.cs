using System;
using System.Runtime.InteropServices;
using UnityEngine;

// Token: 0x0200027E RID: 638
[global::System.Runtime.InteropServices.StructLayout(global::System.Runtime.InteropServices.LayoutKind.Explicit, Size = 8)]
public struct Angle2
{
	// Token: 0x060016DC RID: 5852 RVA: 0x00054680 File Offset: 0x00052880
	public Angle2(float pitch, float yaw)
	{
		this = default(global::Angle2);
		global::Angle2 angle = this;
		angle.pitch = pitch;
		angle.yaw = yaw;
		this = angle;
	}

	// Token: 0x060016DD RID: 5853 RVA: 0x000546B4 File Offset: 0x000528B4
	public Angle2(global::Angle2 angle)
	{
		this = angle;
	}

	// Token: 0x060016DE RID: 5854 RVA: 0x000546C0 File Offset: 0x000528C0
	public Angle2(global::UnityEngine.Vector2 pitchYaw)
	{
		this = default(global::Angle2);
		global::Angle2 angle = this;
		angle.m = pitchYaw;
		this = angle;
	}

	// Token: 0x060016DF RID: 5855 RVA: 0x000546EC File Offset: 0x000528EC
	static Angle2()
	{
		for (long num = 0L; num < 0x2000L; num += 1L)
		{
			global::Angle2.eights360[(int)(checked((global::System.IntPtr)num))] = (float)((double)num / 65536.0 * 360.0);
		}
		global::uLinkAngle2Extensions.Register();
	}

	// Token: 0x17000667 RID: 1639
	public float this[int index]
	{
		get
		{
			return this.m[index];
		}
		set
		{
			this.m[index] = value;
		}
	}

	// Token: 0x17000668 RID: 1640
	// (get) Token: 0x060016E2 RID: 5858 RVA: 0x00054774 File Offset: 0x00052974
	// (set) Token: 0x060016E3 RID: 5859 RVA: 0x00054790 File Offset: 0x00052990
	public global::UnityEngine.Quaternion quat
	{
		get
		{
			return global::UnityEngine.Quaternion.Euler(-this.pitch, this.yaw, 0f);
		}
		set
		{
			this.eulerAngles = value.eulerAngles;
		}
	}

	// Token: 0x17000669 RID: 1641
	// (get) Token: 0x060016E4 RID: 5860 RVA: 0x000547A0 File Offset: 0x000529A0
	// (set) Token: 0x060016E5 RID: 5861 RVA: 0x000547B4 File Offset: 0x000529B4
	public global::UnityEngine.Vector3 eulerAngles
	{
		get
		{
			return new global::UnityEngine.Vector3(-this.pitch, this.yaw);
		}
		set
		{
			this.pitch = -value.x;
			this.yaw = value.y;
		}
	}

	// Token: 0x1700066A RID: 1642
	// (get) Token: 0x060016E6 RID: 5862 RVA: 0x000547D4 File Offset: 0x000529D4
	// (set) Token: 0x060016E7 RID: 5863 RVA: 0x000547E8 File Offset: 0x000529E8
	public global::UnityEngine.Vector3 yawEulerAngles
	{
		get
		{
			return new global::UnityEngine.Vector3(0f, this.yaw);
		}
		set
		{
			this.yaw = value.y;
		}
	}

	// Token: 0x1700066B RID: 1643
	// (get) Token: 0x060016E8 RID: 5864 RVA: 0x000547F8 File Offset: 0x000529F8
	// (set) Token: 0x060016E9 RID: 5865 RVA: 0x0005480C File Offset: 0x00052A0C
	public global::UnityEngine.Vector3 pitchEulerAngles
	{
		get
		{
			return new global::UnityEngine.Vector3(-this.pitch, 0f);
		}
		set
		{
			this.pitch = -value.x;
		}
	}

	// Token: 0x1700066C RID: 1644
	// (get) Token: 0x060016EA RID: 5866 RVA: 0x0005481C File Offset: 0x00052A1C
	// (set) Token: 0x060016EB RID: 5867 RVA: 0x00054830 File Offset: 0x00052A30
	public global::UnityEngine.Vector3 forward
	{
		get
		{
			return this.quat * global::UnityEngine.Vector3.forward;
		}
		set
		{
			this.quat = global::UnityEngine.Quaternion.LookRotation(value);
		}
	}

	// Token: 0x1700066D RID: 1645
	// (get) Token: 0x060016EC RID: 5868 RVA: 0x00054840 File Offset: 0x00052A40
	public global::UnityEngine.Vector3 right
	{
		get
		{
			return this.quat * global::UnityEngine.Vector3.right;
		}
	}

	// Token: 0x1700066E RID: 1646
	// (get) Token: 0x060016ED RID: 5869 RVA: 0x00054854 File Offset: 0x00052A54
	public global::UnityEngine.Vector3 up
	{
		get
		{
			return this.quat * global::UnityEngine.Vector3.up;
		}
	}

	// Token: 0x1700066F RID: 1647
	// (get) Token: 0x060016EE RID: 5870 RVA: 0x00054868 File Offset: 0x00052A68
	// (set) Token: 0x060016EF RID: 5871 RVA: 0x0005487C File Offset: 0x00052A7C
	public global::UnityEngine.Vector3 back
	{
		get
		{
			return this.quat * global::UnityEngine.Vector3.back;
		}
		set
		{
			this.forward = -value;
		}
	}

	// Token: 0x17000670 RID: 1648
	// (get) Token: 0x060016F0 RID: 5872 RVA: 0x0005488C File Offset: 0x00052A8C
	public global::UnityEngine.Vector3 left
	{
		get
		{
			return this.quat * global::UnityEngine.Vector3.left;
		}
	}

	// Token: 0x17000671 RID: 1649
	// (get) Token: 0x060016F1 RID: 5873 RVA: 0x000548A0 File Offset: 0x00052AA0
	public global::UnityEngine.Vector3 down
	{
		get
		{
			return this.quat * global::UnityEngine.Vector3.down;
		}
	}

	// Token: 0x060016F2 RID: 5874 RVA: 0x000548B4 File Offset: 0x00052AB4
	public override int GetHashCode()
	{
		return this.normalized.m.GetHashCode();
	}

	// Token: 0x060016F3 RID: 5875 RVA: 0x000548D4 File Offset: 0x00052AD4
	public override bool Equals(object obj)
	{
		if (obj == null)
		{
			return false;
		}
		if (obj is global::Angle2)
		{
			return this == (global::Angle2)obj;
		}
		if (obj is global::UnityEngine.Vector2)
		{
			return this == (global::UnityEngine.Vector2)obj;
		}
		if (obj is global::UnityEngine.Quaternion)
		{
			return this == (global::UnityEngine.Quaternion)obj;
		}
		if (obj is global::UnityEngine.Vector3)
		{
			return this == (global::UnityEngine.Vector3)obj;
		}
		return obj.Equals(this);
	}

	// Token: 0x060016F4 RID: 5876 RVA: 0x00054970 File Offset: 0x00052B70
	public override string ToString()
	{
		return this.m.ToString();
	}

	// Token: 0x17000672 RID: 1650
	// (get) Token: 0x060016F5 RID: 5877 RVA: 0x00054980 File Offset: 0x00052B80
	public global::Angle2 normalized
	{
		get
		{
			return global::Angle2.Normalize(this);
		}
	}

	// Token: 0x17000673 RID: 1651
	// (get) Token: 0x060016F6 RID: 5878 RVA: 0x00054990 File Offset: 0x00052B90
	public float angleMagnitude
	{
		get
		{
			return this.m.magnitude;
		}
	}

	// Token: 0x17000674 RID: 1652
	// (get) Token: 0x060016F7 RID: 5879 RVA: 0x000549A0 File Offset: 0x00052BA0
	public float sqrAngleMagnitude
	{
		get
		{
			return this.m.sqrMagnitude;
		}
	}

	// Token: 0x17000675 RID: 1653
	// (get) Token: 0x060016F8 RID: 5880 RVA: 0x000549B0 File Offset: 0x00052BB0
	public float normalizedAngleMagnitude
	{
		get
		{
			return global::Angle2.Normalize(this).m.magnitude;
		}
	}

	// Token: 0x17000676 RID: 1654
	// (get) Token: 0x060016F9 RID: 5881 RVA: 0x000549D8 File Offset: 0x00052BD8
	public float normalizedSqrAngleMagnitude
	{
		get
		{
			return global::Angle2.Normalize(this).m.sqrMagnitude;
		}
	}

	// Token: 0x060016FA RID: 5882 RVA: 0x00054A00 File Offset: 0x00052C00
	private static global::UnityEngine.Vector2 NormMags(global::Angle2 a, global::Angle2 b)
	{
		global::UnityEngine.Vector2 result;
		result..ctor(global::Angle2.DistAngle(a.x, b.x), global::Angle2.DistAngle(a.y, b.y));
		result.Normalize();
		return result;
	}

	// Token: 0x060016FB RID: 5883 RVA: 0x00054A44 File Offset: 0x00052C44
	public static global::Angle2 SmoothDamp(global::Angle2 current, global::Angle2 target, ref global::UnityEngine.Vector2 velocity, float damping, float maxAngleMove, float deltaTime)
	{
		if (current.x == target.x)
		{
			velocity.x = 0f;
			current.y = global::UnityEngine.Mathf.SmoothDampAngle(current.y, target.y, ref velocity.y, damping, maxAngleMove, deltaTime);
		}
		else if (current.y == target.y)
		{
			velocity.y = 0f;
			current.x = global::UnityEngine.Mathf.SmoothDampAngle(current.x, target.x, ref velocity.x, damping, maxAngleMove, deltaTime);
		}
		else
		{
			global::UnityEngine.Vector2 vector = global::Angle2.NormMags(current, target) * maxAngleMove;
			current.x = global::UnityEngine.Mathf.SmoothDampAngle(current.x, target.x, ref velocity.x, damping, vector.x, deltaTime);
			current.y = global::UnityEngine.Mathf.SmoothDampAngle(current.y, target.y, ref velocity.y, damping, vector.y, deltaTime);
		}
		return current;
	}

	// Token: 0x060016FC RID: 5884 RVA: 0x00054B48 File Offset: 0x00052D48
	public static global::Angle2 SmoothDamp(global::Angle2 current, global::Angle2 target, ref global::UnityEngine.Vector2 velocity, global::UnityEngine.Vector2 damping, global::UnityEngine.Vector2 maxAngleMove, float deltaTime)
	{
		current.x = global::UnityEngine.Mathf.SmoothDampAngle(current.x, target.x, ref velocity.x, damping.x, maxAngleMove.x, deltaTime);
		current.y = global::UnityEngine.Mathf.SmoothDampAngle(current.y, target.y, ref velocity.y, damping.y, maxAngleMove.y, deltaTime);
		return current;
	}

	// Token: 0x060016FD RID: 5885 RVA: 0x00054BB8 File Offset: 0x00052DB8
	public static global::Angle2 SmoothDamp(global::Angle2 current, global::Angle2 target, ref global::UnityEngine.Vector2 velocity, float damping, global::UnityEngine.Vector2 maxAngleMove, float deltaTime)
	{
		current.x = global::UnityEngine.Mathf.SmoothDampAngle(current.x, target.x, ref velocity.x, damping, maxAngleMove.x, deltaTime);
		current.y = global::UnityEngine.Mathf.SmoothDampAngle(current.y, target.y, ref velocity.y, damping, maxAngleMove.y, deltaTime);
		return current;
	}

	// Token: 0x060016FE RID: 5886 RVA: 0x00054C1C File Offset: 0x00052E1C
	public static global::Angle2 SmoothDamp(global::Angle2 current, global::Angle2 target, ref global::UnityEngine.Vector2 velocity, float damping, global::UnityEngine.Vector2 maxAngleMove)
	{
		return global::Angle2.SmoothDamp(current, target, ref velocity, damping, maxAngleMove, global::UnityEngine.Time.deltaTime);
	}

	// Token: 0x060016FF RID: 5887 RVA: 0x00054C30 File Offset: 0x00052E30
	public static global::Angle2 SmoothDamp(global::Angle2 current, global::Angle2 target, ref global::UnityEngine.Vector2 velocity, global::UnityEngine.Vector2 damping, global::UnityEngine.Vector2 maxAngleMove)
	{
		return global::Angle2.SmoothDamp(current, target, ref velocity, damping, maxAngleMove, global::UnityEngine.Time.deltaTime);
	}

	// Token: 0x06001700 RID: 5888 RVA: 0x00054C44 File Offset: 0x00052E44
	public static global::Angle2 SmoothDamp(global::Angle2 current, global::Angle2 target, ref global::UnityEngine.Vector2 velocity, float damping, float maxAngleMove)
	{
		return global::Angle2.SmoothDamp(current, target, ref velocity, damping, maxAngleMove, global::UnityEngine.Time.deltaTime);
	}

	// Token: 0x06001701 RID: 5889 RVA: 0x00054C58 File Offset: 0x00052E58
	public static global::Angle2 SmoothDamp(global::Angle2 current, global::Angle2 target, ref global::UnityEngine.Vector2 velocity, float damping)
	{
		return global::Angle2.SmoothDamp(current, target, ref velocity, damping, float.PositiveInfinity, global::UnityEngine.Time.deltaTime);
	}

	// Token: 0x06001702 RID: 5890 RVA: 0x00054C70 File Offset: 0x00052E70
	public static global::Angle2 SmoothDamp(global::Angle2 current, global::Angle2 target, ref global::UnityEngine.Vector2 velocity, global::UnityEngine.Vector2 damping)
	{
		return global::Angle2.SmoothDamp(current, target, ref velocity, damping, new global::UnityEngine.Vector2(float.PositiveInfinity, float.PositiveInfinity), global::UnityEngine.Time.deltaTime);
	}

	// Token: 0x06001703 RID: 5891 RVA: 0x00054C90 File Offset: 0x00052E90
	public static global::Angle2 MoveTowards(global::Angle2 current, global::Angle2 target, float maxAngleMove)
	{
		if (current.x == target.x)
		{
			current.y = global::UnityEngine.Mathf.MoveTowardsAngle(current.y, target.y, maxAngleMove);
		}
		else if (current.y == target.y)
		{
			current.x = global::UnityEngine.Mathf.MoveTowardsAngle(current.x, target.x, maxAngleMove);
		}
		else
		{
			global::UnityEngine.Vector2 vector = global::Angle2.NormMags(current, target) * maxAngleMove;
			current.x = global::UnityEngine.Mathf.MoveTowardsAngle(current.x, target.x, vector.x);
			current.y = global::UnityEngine.Mathf.MoveTowardsAngle(current.y, target.y, vector.y);
		}
		return current;
	}

	// Token: 0x06001704 RID: 5892 RVA: 0x00054D54 File Offset: 0x00052F54
	public static global::Angle2 MoveTowards(global::Angle2 current, global::Angle2 target, global::UnityEngine.Vector2 maxAngleMove)
	{
		current.x = global::UnityEngine.Mathf.MoveTowardsAngle(current.x, target.y, maxAngleMove.x);
		current.y = global::UnityEngine.Mathf.MoveTowardsAngle(current.x, target.y, maxAngleMove.y);
		return current;
	}

	// Token: 0x06001705 RID: 5893 RVA: 0x00054DA4 File Offset: 0x00052FA4
	public static global::Angle2 Lerp(global::Angle2 a, global::Angle2 b, float t)
	{
		return new global::Angle2(global::UnityEngine.Mathf.LerpAngle(a.x, b.x, t), global::UnityEngine.Mathf.LerpAngle(a.y, b.y, t));
	}

	// Token: 0x06001706 RID: 5894 RVA: 0x00054DD4 File Offset: 0x00052FD4
	public static global::Angle2 Lerp(global::Angle2 a, global::Angle2 b, global::UnityEngine.Vector2 t)
	{
		return new global::Angle2(global::UnityEngine.Mathf.LerpAngle(a.x, b.x, t.x), global::UnityEngine.Mathf.LerpAngle(a.y, b.y, t.y));
	}

	// Token: 0x06001707 RID: 5895 RVA: 0x00054E10 File Offset: 0x00053010
	public static global::Angle2 Delta(global::Angle2 a, global::Angle2 b)
	{
		return new global::Angle2(global::UnityEngine.Mathf.DeltaAngle(a.x, b.x), global::UnityEngine.Mathf.DeltaAngle(b.x, b.y));
	}

	// Token: 0x06001708 RID: 5896 RVA: 0x00054E40 File Offset: 0x00053040
	public static float SquareAngleDistance(global::Angle2 a, global::Angle2 b)
	{
		float num = global::UnityEngine.Mathf.DeltaAngle(a.x, b.x);
		float num2 = global::UnityEngine.Mathf.DeltaAngle(a.y, b.y);
		return num * num + num2 * num2;
	}

	// Token: 0x06001709 RID: 5897 RVA: 0x00054E7C File Offset: 0x0005307C
	public static float AngleDistance(global::Angle2 a, global::Angle2 b)
	{
		return global::UnityEngine.Mathf.Sqrt(global::Angle2.SquareAngleDistance(a, b));
	}

	// Token: 0x0600170A RID: 5898 RVA: 0x00054E8C File Offset: 0x0005308C
	private static float DistAngle(float a, float b)
	{
		return global::UnityEngine.Mathf.Abs(global::UnityEngine.Mathf.DeltaAngle(a, b));
	}

	// Token: 0x0600170B RID: 5899 RVA: 0x00054E9C File Offset: 0x0005309C
	private static float NormAngle(float a)
	{
		a = global::UnityEngine.Mathf.DeltaAngle(0f, a);
		return (a <= 180f) ? a : (a - 360f);
	}

	// Token: 0x0600170C RID: 5900 RVA: 0x00054EC4 File Offset: 0x000530C4
	public static global::Angle2 Normalize(global::Angle2 a)
	{
		return new global::Angle2
		{
			x = global::Angle2.NormAngle(a.x),
			y = global::Angle2.NormAngle(a.y)
		};
	}

	// Token: 0x0600170D RID: 5901 RVA: 0x00054F00 File Offset: 0x00053100
	public static global::Angle2 NormalizeAdd(global::Angle2 a, global::Angle2 b)
	{
		return new global::Angle2
		{
			x = global::Angle2.NormAngle(a.x + b.x),
			y = global::Angle2.NormAngle(a.y + b.y)
		};
	}

	// Token: 0x0600170E RID: 5902 RVA: 0x00054F4C File Offset: 0x0005314C
	public static global::Angle2 NormalizeSubtract(global::Angle2 a, global::Angle2 b)
	{
		return new global::Angle2
		{
			x = global::Angle2.NormAngle(a.x - b.x),
			y = global::Angle2.NormAngle(a.y - b.y)
		};
	}

	// Token: 0x0600170F RID: 5903 RVA: 0x00054F98 File Offset: 0x00053198
	public static global::Angle2 LookDirection(global::UnityEngine.Vector3 v)
	{
		return (global::Angle2)v;
	}

	// Token: 0x06001710 RID: 5904 RVA: 0x00054FA0 File Offset: 0x000531A0
	public static global::UnityEngine.Vector3 Direction(float pitch, float yaw)
	{
		return global::UnityEngine.Quaternion.Euler(-pitch, yaw, 0f) * global::UnityEngine.Vector3.forward;
	}

	// Token: 0x06001711 RID: 5905 RVA: 0x00054FBC File Offset: 0x000531BC
	public static int Encode360(float x)
	{
		x = global::UnityEngine.Mathf.DeltaAngle(0f, x);
		if (x < 0f)
		{
			x += 360f;
		}
		switch (global::UnityEngine.Mathf.FloorToInt(x) / 0x2D)
		{
		case 0:
			return global::UnityEngine.Mathf.RoundToInt((float)((double)x * 182.04444444444445));
		case 1:
			return global::UnityEngine.Mathf.RoundToInt((float)((double)(x - 45f) * 182.04444444444445)) + 0x2000;
		case 2:
			return global::UnityEngine.Mathf.RoundToInt((float)((double)(x - 90f) * 182.04444444444445)) + 0x4000;
		case 3:
			return global::UnityEngine.Mathf.RoundToInt((float)((double)(x - 135f) * 182.04444444444445)) + 0x6000;
		case 4:
			return global::UnityEngine.Mathf.RoundToInt((float)((double)(x - 180f) * 182.04444444444445)) + 0x8000;
		case 5:
			return global::UnityEngine.Mathf.RoundToInt((float)((double)(x - 225f) * 182.04444444444445)) + 0xA000;
		case 6:
			return global::UnityEngine.Mathf.RoundToInt((float)((double)(x - 270f) * 182.04444444444445)) + 0xC000;
		case 7:
			return global::UnityEngine.Mathf.RoundToInt((float)((double)(x - 315f) * 182.04444444444445)) + 0xE000;
		case 8:
			return 0;
		default:
			return -1;
		}
	}

	// Token: 0x06001712 RID: 5906 RVA: 0x00055114 File Offset: 0x00053314
	public static float Decode360(int x)
	{
		int num = x / 0x2000;
		float num2 = (float)num * 45f + global::Angle2.eights360[x - num * 0x2000];
		return (num2 >= 180f) ? (num2 - 360f) : num2;
	}

	// Token: 0x17000677 RID: 1655
	// (get) Token: 0x06001713 RID: 5907 RVA: 0x0005515C File Offset: 0x0005335C
	// (set) Token: 0x06001714 RID: 5908 RVA: 0x00055178 File Offset: 0x00053378
	public int encoded
	{
		get
		{
			return global::Angle2.Encode360(this.y) << 0x10 | global::Angle2.Encode360(this.x);
		}
		set
		{
			this.x = global::Angle2.Decode360(value & 0xFFFF);
			this.y = global::Angle2.Decode360(value >> 0x10 & 0xFFFF);
		}
	}

	// Token: 0x17000678 RID: 1656
	// (get) Token: 0x06001715 RID: 5909 RVA: 0x000551A4 File Offset: 0x000533A4
	public global::Angle2 decoded
	{
		get
		{
			global::Angle2 result = this;
			result.encoded = this.encoded;
			return result;
		}
	}

	// Token: 0x06001716 RID: 5910 RVA: 0x000551C8 File Offset: 0x000533C8
	public static global::Angle2 operator -(global::Angle2 L, global::Angle2 R)
	{
		L.m -= R.m;
		return L;
	}

	// Token: 0x06001717 RID: 5911 RVA: 0x000551E4 File Offset: 0x000533E4
	public static global::Angle2 operator +(global::Angle2 L, global::Angle2 R)
	{
		L.m += R.m;
		return L;
	}

	// Token: 0x06001718 RID: 5912 RVA: 0x00055200 File Offset: 0x00053400
	public static global::Angle2 operator *(global::Angle2 L, global::Angle2 R)
	{
		L.m += global::Angle2.Delta(L, R).m;
		return L;
	}

	// Token: 0x06001719 RID: 5913 RVA: 0x00055230 File Offset: 0x00053430
	public static global::Angle2 operator /(global::Angle2 L, global::Angle2 R)
	{
		L.m -= global::Angle2.Delta(L, R).m;
		return L;
	}

	// Token: 0x0600171A RID: 5914 RVA: 0x00055260 File Offset: 0x00053460
	public static global::Angle2 operator +(global::Angle2 L, global::UnityEngine.Vector2 R)
	{
		L.m += R;
		return L;
	}

	// Token: 0x0600171B RID: 5915 RVA: 0x00055278 File Offset: 0x00053478
	public static global::Angle2 operator -(global::Angle2 L, global::UnityEngine.Vector2 R)
	{
		L.m -= R;
		return L;
	}

	// Token: 0x0600171C RID: 5916 RVA: 0x00055290 File Offset: 0x00053490
	public static global::Angle2 operator *(global::Angle2 L, global::UnityEngine.Vector2 R)
	{
		L.m = global::UnityEngine.Vector2.Scale(L.m, R);
		return L;
	}

	// Token: 0x0600171D RID: 5917 RVA: 0x000552A8 File Offset: 0x000534A8
	public static global::Angle2 operator /(global::Angle2 L, global::UnityEngine.Vector2 R)
	{
		L.x /= R.x;
		L.y /= R.y;
		return L;
	}

	// Token: 0x0600171E RID: 5918 RVA: 0x000552D8 File Offset: 0x000534D8
	public static global::UnityEngine.Vector2 operator +(global::UnityEngine.Vector2 L, global::Angle2 R)
	{
		L += R.m;
		return L;
	}

	// Token: 0x0600171F RID: 5919 RVA: 0x000552EC File Offset: 0x000534EC
	public static global::UnityEngine.Vector2 operator -(global::UnityEngine.Vector2 L, global::Angle2 R)
	{
		L -= R.m;
		return L;
	}

	// Token: 0x06001720 RID: 5920 RVA: 0x00055300 File Offset: 0x00053500
	public static global::Angle2 operator *(global::Angle2 L, float R)
	{
		L.m *= R;
		return L;
	}

	// Token: 0x06001721 RID: 5921 RVA: 0x00055318 File Offset: 0x00053518
	public static global::Angle2 operator *(float L, global::Angle2 R)
	{
		R.m *= L;
		return R;
	}

	// Token: 0x06001722 RID: 5922 RVA: 0x00055330 File Offset: 0x00053530
	public static global::Angle2 operator /(global::Angle2 L, float R)
	{
		L.m /= R;
		return L;
	}

	// Token: 0x06001723 RID: 5923 RVA: 0x00055348 File Offset: 0x00053548
	public static global::Angle2 operator /(float L, global::Angle2 R)
	{
		R.m /= L;
		return R;
	}

	// Token: 0x06001724 RID: 5924 RVA: 0x00055360 File Offset: 0x00053560
	public static global::UnityEngine.Vector3 operator *(global::Angle2 L, global::UnityEngine.Vector3 R)
	{
		return L.quat * R;
	}

	// Token: 0x06001725 RID: 5925 RVA: 0x00055370 File Offset: 0x00053570
	public static global::Angle2 operator *(global::Angle2 L, global::UnityEngine.Quaternion R)
	{
		L.quat *= R;
		return L;
	}

	// Token: 0x06001726 RID: 5926 RVA: 0x00055388 File Offset: 0x00053588
	public static global::UnityEngine.Quaternion operator *(global::UnityEngine.Quaternion L, global::Angle2 R)
	{
		return L * R.quat;
	}

	// Token: 0x06001727 RID: 5927 RVA: 0x00055398 File Offset: 0x00053598
	public static global::Angle2 operator -(global::Angle2 negate)
	{
		negate.m = -negate.m;
		return negate;
	}

	// Token: 0x06001728 RID: 5928 RVA: 0x000553B0 File Offset: 0x000535B0
	public static bool operator ==(global::Angle2 L, global::Angle2 R)
	{
		return global::Angle2.Normalize(L - R).sqrAngleMagnitude == 0f;
	}

	// Token: 0x06001729 RID: 5929 RVA: 0x000553D8 File Offset: 0x000535D8
	public static bool operator !=(global::Angle2 L, global::Angle2 R)
	{
		return global::Angle2.Normalize(L - R).sqrAngleMagnitude != 0f;
	}

	// Token: 0x0600172A RID: 5930 RVA: 0x00055404 File Offset: 0x00053604
	public static bool operator ==(global::UnityEngine.Vector2 L, global::Angle2 R)
	{
		return L == R.m;
	}

	// Token: 0x0600172B RID: 5931 RVA: 0x00055414 File Offset: 0x00053614
	public static bool operator !=(global::UnityEngine.Vector2 L, global::Angle2 R)
	{
		return L != R.m;
	}

	// Token: 0x0600172C RID: 5932 RVA: 0x00055424 File Offset: 0x00053624
	public static bool operator ==(global::Angle2 L, global::UnityEngine.Vector2 R)
	{
		return L.m == R;
	}

	// Token: 0x0600172D RID: 5933 RVA: 0x00055434 File Offset: 0x00053634
	public static bool operator !=(global::Angle2 L, global::UnityEngine.Vector2 R)
	{
		return L.m != R;
	}

	// Token: 0x0600172E RID: 5934 RVA: 0x00055444 File Offset: 0x00053644
	public static bool operator ==(global::UnityEngine.Vector3 L, global::Angle2 R)
	{
		return L == R.forward;
	}

	// Token: 0x0600172F RID: 5935 RVA: 0x00055454 File Offset: 0x00053654
	public static bool operator !=(global::UnityEngine.Vector3 L, global::Angle2 R)
	{
		return L != R.forward;
	}

	// Token: 0x06001730 RID: 5936 RVA: 0x00055464 File Offset: 0x00053664
	public static bool operator ==(global::Angle2 L, global::UnityEngine.Vector3 R)
	{
		return L.forward == R;
	}

	// Token: 0x06001731 RID: 5937 RVA: 0x00055474 File Offset: 0x00053674
	public static bool operator !=(global::Angle2 L, global::UnityEngine.Vector3 R)
	{
		return L.forward != R;
	}

	// Token: 0x06001732 RID: 5938 RVA: 0x00055484 File Offset: 0x00053684
	public static bool operator ==(global::UnityEngine.Quaternion L, global::Angle2 R)
	{
		return L == R.quat;
	}

	// Token: 0x06001733 RID: 5939 RVA: 0x00055494 File Offset: 0x00053694
	public static bool operator !=(global::UnityEngine.Quaternion L, global::Angle2 R)
	{
		return L != R.quat;
	}

	// Token: 0x06001734 RID: 5940 RVA: 0x000554A4 File Offset: 0x000536A4
	public static bool operator ==(global::Angle2 L, global::UnityEngine.Quaternion R)
	{
		return L.quat == R;
	}

	// Token: 0x06001735 RID: 5941 RVA: 0x000554B4 File Offset: 0x000536B4
	public static bool operator !=(global::Angle2 L, global::UnityEngine.Quaternion R)
	{
		return L.quat != R;
	}

	// Token: 0x06001736 RID: 5942 RVA: 0x000554C4 File Offset: 0x000536C4
	public static implicit operator global::Angle2(global::UnityEngine.Vector2 yawPitch)
	{
		return new global::Angle2
		{
			m = yawPitch
		};
	}

	// Token: 0x06001737 RID: 5943 RVA: 0x000554E4 File Offset: 0x000536E4
	public static implicit operator global::UnityEngine.Vector2(global::Angle2 a)
	{
		return a.m;
	}

	// Token: 0x06001738 RID: 5944 RVA: 0x000554F0 File Offset: 0x000536F0
	public static explicit operator global::Angle2(global::UnityEngine.Vector3 forward)
	{
		return new global::Angle2
		{
			forward = forward
		};
	}

	// Token: 0x06001739 RID: 5945 RVA: 0x00055510 File Offset: 0x00053710
	public static explicit operator global::UnityEngine.Vector3(global::Angle2 a)
	{
		return a.forward;
	}

	// Token: 0x0600173A RID: 5946 RVA: 0x0005551C File Offset: 0x0005371C
	public static explicit operator global::Angle2(global::UnityEngine.Quaternion quat)
	{
		return new global::Angle2
		{
			quat = quat
		};
	}

	// Token: 0x0600173B RID: 5947 RVA: 0x0005553C File Offset: 0x0005373C
	public static explicit operator global::UnityEngine.Quaternion(global::Angle2 a)
	{
		return a.quat;
	}

	// Token: 0x04000BCA RID: 3018
	private const float kEigth = 45f;

	// Token: 0x04000BCB RID: 3019
	private const double kF2I = 182.04444444444445;

	// Token: 0x04000BCC RID: 3020
	[global::System.Runtime.InteropServices.FieldOffset(0)]
	public float pitch;

	// Token: 0x04000BCD RID: 3021
	[global::System.Runtime.InteropServices.FieldOffset(4)]
	public float yaw;

	// Token: 0x04000BCE RID: 3022
	[global::System.Runtime.InteropServices.FieldOffset(0)]
	public float x;

	// Token: 0x04000BCF RID: 3023
	[global::System.Runtime.InteropServices.FieldOffset(4)]
	public float y;

	// Token: 0x04000BD0 RID: 3024
	[global::System.Runtime.InteropServices.FieldOffset(0)]
	public global::UnityEngine.Vector2 m;

	// Token: 0x04000BD1 RID: 3025
	public static readonly global::Angle2 zero = default(global::Angle2);

	// Token: 0x04000BD2 RID: 3026
	private static readonly float[] eights360 = new float[0x2000];
}
