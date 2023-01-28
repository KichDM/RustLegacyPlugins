using System;
using Facepunch.Precision;
using UnityEngine;

// Token: 0x02000473 RID: 1139
public static class TransitionFunctions
{
	// Token: 0x06002737 RID: 10039 RVA: 0x000965C0 File Offset: 0x000947C0
	public static global::UnityEngine.Color Linear(float t, global::UnityEngine.Color a, global::UnityEngine.Color b)
	{
		return global::TransitionFunctions.Sum(global::TransitionFunctions.Mul(a, 1f - t), global::TransitionFunctions.Mul(b, t));
	}

	// Token: 0x06002738 RID: 10040 RVA: 0x000965DC File Offset: 0x000947DC
	public static global::UnityEngine.Color Round(float t, global::UnityEngine.Color a, global::UnityEngine.Color b)
	{
		return (t >= 0.5f) ? b : a;
	}

	// Token: 0x06002739 RID: 10041 RVA: 0x000965F0 File Offset: 0x000947F0
	public static global::UnityEngine.Color Ceil(float t, global::UnityEngine.Color a, global::UnityEngine.Color b)
	{
		return (t <= 0f) ? a : b;
	}

	// Token: 0x0600273A RID: 10042 RVA: 0x00096604 File Offset: 0x00094804
	public static global::UnityEngine.Color Floor(float t, global::UnityEngine.Color a, global::UnityEngine.Color b)
	{
		return (t >= 1f) ? b : a;
	}

	// Token: 0x0600273B RID: 10043 RVA: 0x00096618 File Offset: 0x00094818
	public static global::UnityEngine.Color Spline(float t, global::UnityEngine.Color a, global::UnityEngine.Color b)
	{
		return (t > 0f) ? ((t < 1f) ? global::TransitionFunctions.Linear(global::TransitionFunctions.SimpleSpline(t), a, b) : b) : a;
	}

	// Token: 0x0600273C RID: 10044 RVA: 0x0009664C File Offset: 0x0009484C
	public static global::UnityEngine.Color Evaluate(this global::TransitionFunction f, float t, global::UnityEngine.Color a, global::UnityEngine.Color b)
	{
		switch (f)
		{
		case global::TransitionFunction.Linear:
			return global::TransitionFunctions.Linear(t, a, b);
		case global::TransitionFunction.Round:
			return global::TransitionFunctions.Round(t, a, b);
		case global::TransitionFunction.Floor:
			return global::TransitionFunctions.Floor(t, a, b);
		case global::TransitionFunction.Ceil:
			return global::TransitionFunctions.Ceil(t, a, b);
		case global::TransitionFunction.Spline:
			return global::TransitionFunctions.Spline(t, a, b);
		default:
			throw new global::System.ArgumentOutOfRangeException("v", "Attempted use of unrecognized TransitionFunction enum value");
		}
	}

	// Token: 0x0600273D RID: 10045 RVA: 0x000966B8 File Offset: 0x000948B8
	public static global::UnityEngine.Color Evaluate(this global::TransitionFunction<global::UnityEngine.Color> v, float t)
	{
		return v.f.Evaluate(t, v.a, v.b);
	}

	// Token: 0x0600273E RID: 10046 RVA: 0x000966D8 File Offset: 0x000948D8
	public static global::UnityEngine.Color Mul(global::UnityEngine.Color a, float b)
	{
		global::UnityEngine.Color result;
		result.r = a.r * b;
		result.g = a.g * b;
		result.b = a.b * b;
		result.a = a.a * b;
		return result;
	}

	// Token: 0x0600273F RID: 10047 RVA: 0x00096728 File Offset: 0x00094928
	public static global::UnityEngine.Color Sum(global::UnityEngine.Color a, global::UnityEngine.Color b)
	{
		global::UnityEngine.Color result;
		result.r = a.r + b.r;
		result.g = a.g + b.g;
		result.b = a.b + b.b;
		result.a = a.a * b.a;
		return result;
	}

	// Token: 0x06002740 RID: 10048 RVA: 0x00096790 File Offset: 0x00094990
	public static global::UnityEngine.Matrix4x4 Linear(float t, global::UnityEngine.Matrix4x4 a, global::UnityEngine.Matrix4x4 b)
	{
		return global::TransitionFunctions.Sum(global::TransitionFunctions.Mul(a, 1f - t), global::TransitionFunctions.Mul(b, t));
	}

	// Token: 0x06002741 RID: 10049 RVA: 0x000967AC File Offset: 0x000949AC
	public static global::UnityEngine.Matrix4x4 Round(float t, global::UnityEngine.Matrix4x4 a, global::UnityEngine.Matrix4x4 b)
	{
		return (t >= 0.5f) ? b : a;
	}

	// Token: 0x06002742 RID: 10050 RVA: 0x000967C0 File Offset: 0x000949C0
	public static global::UnityEngine.Matrix4x4 Ceil(float t, global::UnityEngine.Matrix4x4 a, global::UnityEngine.Matrix4x4 b)
	{
		return (t <= 0f) ? a : b;
	}

	// Token: 0x06002743 RID: 10051 RVA: 0x000967D4 File Offset: 0x000949D4
	public static global::UnityEngine.Matrix4x4 Floor(float t, global::UnityEngine.Matrix4x4 a, global::UnityEngine.Matrix4x4 b)
	{
		return (t >= 1f) ? b : a;
	}

	// Token: 0x06002744 RID: 10052 RVA: 0x000967E8 File Offset: 0x000949E8
	public static global::UnityEngine.Matrix4x4 Spline(float t, global::UnityEngine.Matrix4x4 a, global::UnityEngine.Matrix4x4 b)
	{
		return (t > 0f) ? ((t < 1f) ? global::TransitionFunctions.Linear(global::TransitionFunctions.SimpleSpline(t), a, b) : b) : a;
	}

	// Token: 0x06002745 RID: 10053 RVA: 0x0009681C File Offset: 0x00094A1C
	public static global::UnityEngine.Matrix4x4 Evaluate(this global::TransitionFunction f, float t, global::UnityEngine.Matrix4x4 a, global::UnityEngine.Matrix4x4 b)
	{
		switch (f)
		{
		case global::TransitionFunction.Linear:
			return global::TransitionFunctions.Linear(t, a, b);
		case global::TransitionFunction.Round:
			return global::TransitionFunctions.Round(t, a, b);
		case global::TransitionFunction.Floor:
			return global::TransitionFunctions.Floor(t, a, b);
		case global::TransitionFunction.Ceil:
			return global::TransitionFunctions.Ceil(t, a, b);
		case global::TransitionFunction.Spline:
			return global::TransitionFunctions.Spline(t, a, b);
		default:
			throw new global::System.ArgumentOutOfRangeException("v", "Attempted use of unrecognized TransitionFunction enum value");
		}
	}

	// Token: 0x06002746 RID: 10054 RVA: 0x00096888 File Offset: 0x00094A88
	public static global::UnityEngine.Matrix4x4 Evaluate(this global::TransitionFunction<global::UnityEngine.Matrix4x4> v, float t)
	{
		return v.f.Evaluate(t, v.a, v.b);
	}

	// Token: 0x06002747 RID: 10055 RVA: 0x000968A8 File Offset: 0x00094AA8
	public static global::UnityEngine.Matrix4x4 Mul(global::UnityEngine.Matrix4x4 a, float b)
	{
		global::UnityEngine.Matrix4x4 result;
		result.m00 = a.m00 * b;
		result.m10 = a.m10 * b;
		result.m20 = a.m20 * b;
		result.m30 = a.m30 * b;
		result.m01 = a.m01 * b;
		result.m11 = a.m11 * b;
		result.m21 = a.m21 * b;
		result.m31 = a.m31 * b;
		result.m02 = a.m02 * b;
		result.m12 = a.m12 * b;
		result.m22 = a.m22 * b;
		result.m32 = a.m32 * b;
		result.m03 = a.m03 * b;
		result.m13 = a.m13 * b;
		result.m23 = a.m23 * b;
		result.m33 = a.m33 * b;
		return result;
	}

	// Token: 0x06002748 RID: 10056 RVA: 0x000969B8 File Offset: 0x00094BB8
	public static global::UnityEngine.Matrix4x4 Sum(global::UnityEngine.Matrix4x4 a, global::UnityEngine.Matrix4x4 b)
	{
		global::UnityEngine.Matrix4x4 result;
		result.m00 = a.m00 + b.m00;
		result.m10 = a.m10 + b.m10;
		result.m20 = a.m20 + b.m20;
		result.m30 = a.m30 + b.m30;
		result.m01 = a.m01 + b.m01;
		result.m11 = a.m11 + b.m11;
		result.m21 = a.m21 + b.m21;
		result.m31 = a.m31 + b.m31;
		result.m02 = a.m02 + b.m02;
		result.m12 = a.m12 + b.m12;
		result.m22 = a.m22 + b.m22;
		result.m32 = a.m32 + b.m32;
		result.m03 = a.m03 + b.m03;
		result.m13 = a.m13 + b.m13;
		result.m23 = a.m23 + b.m23;
		result.m33 = a.m33 + b.m33;
		return result;
	}

	// Token: 0x06002749 RID: 10057 RVA: 0x00096B28 File Offset: 0x00094D28
	public static global::UnityEngine.Matrix4x4 Inverse(global::UnityEngine.Matrix4x4 v)
	{
		return global::UnityEngine.Matrix4x4.Inverse(v);
	}

	// Token: 0x0600274A RID: 10058 RVA: 0x00096B30 File Offset: 0x00094D30
	public static global::UnityEngine.Matrix4x4 Transpose(global::UnityEngine.Matrix4x4 v)
	{
		return global::UnityEngine.Matrix4x4.Transpose(v);
	}

	// Token: 0x0600274B RID: 10059 RVA: 0x00096B38 File Offset: 0x00094D38
	private static global::UnityEngine.Vector3 GET_0X(global::UnityEngine.Matrix4x4 a)
	{
		return global::TransitionFunctions.Vect(a.m00, a.m01, a.m02);
	}

	// Token: 0x0600274C RID: 10060 RVA: 0x00096B54 File Offset: 0x00094D54
	private static global::UnityEngine.Vector3 GET_X0(global::UnityEngine.Matrix4x4 a)
	{
		return global::TransitionFunctions.Vect(a.m00, a.m10, a.m20);
	}

	// Token: 0x0600274D RID: 10061 RVA: 0x00096B70 File Offset: 0x00094D70
	private static void SET_0X(ref global::UnityEngine.Matrix4x4 m, global::UnityEngine.Vector3 v)
	{
		m.m00 = v.x;
		m.m01 = v.y;
		m.m02 = v.z;
	}

	// Token: 0x0600274E RID: 10062 RVA: 0x00096B9C File Offset: 0x00094D9C
	private static void SET_X0(ref global::UnityEngine.Matrix4x4 m, global::UnityEngine.Vector3 v)
	{
		m.m00 = v.x;
		m.m10 = v.y;
		m.m20 = v.z;
	}

	// Token: 0x0600274F RID: 10063 RVA: 0x00096BC8 File Offset: 0x00094DC8
	private static global::UnityEngine.Vector3 GET_1X(global::UnityEngine.Matrix4x4 a)
	{
		return global::TransitionFunctions.Vect(a.m10, a.m11, a.m12);
	}

	// Token: 0x06002750 RID: 10064 RVA: 0x00096BE4 File Offset: 0x00094DE4
	private static global::UnityEngine.Vector3 GET_X1(global::UnityEngine.Matrix4x4 a)
	{
		return global::TransitionFunctions.Vect(a.m01, a.m11, a.m21);
	}

	// Token: 0x06002751 RID: 10065 RVA: 0x00096C00 File Offset: 0x00094E00
	private static void SET_1X(ref global::UnityEngine.Matrix4x4 m, global::UnityEngine.Vector3 v)
	{
		m.m10 = v.x;
		m.m11 = v.y;
		m.m12 = v.z;
	}

	// Token: 0x06002752 RID: 10066 RVA: 0x00096C2C File Offset: 0x00094E2C
	private static void SET_X1(ref global::UnityEngine.Matrix4x4 m, global::UnityEngine.Vector3 v)
	{
		m.m01 = v.x;
		m.m11 = v.y;
		m.m21 = v.z;
	}

	// Token: 0x06002753 RID: 10067 RVA: 0x00096C58 File Offset: 0x00094E58
	private static global::UnityEngine.Vector3 GET_2X(global::UnityEngine.Matrix4x4 a)
	{
		return global::TransitionFunctions.Vect(a.m20, a.m21, a.m22);
	}

	// Token: 0x06002754 RID: 10068 RVA: 0x00096C74 File Offset: 0x00094E74
	private static global::UnityEngine.Vector3 GET_X2(global::UnityEngine.Matrix4x4 a)
	{
		return global::TransitionFunctions.Vect(a.m02, a.m12, a.m22);
	}

	// Token: 0x06002755 RID: 10069 RVA: 0x00096C90 File Offset: 0x00094E90
	private static void SET_2X(ref global::UnityEngine.Matrix4x4 m, global::UnityEngine.Vector3 v)
	{
		m.m20 = v.x;
		m.m21 = v.y;
		m.m22 = v.z;
	}

	// Token: 0x06002756 RID: 10070 RVA: 0x00096CBC File Offset: 0x00094EBC
	private static void SET_X2(ref global::UnityEngine.Matrix4x4 m, global::UnityEngine.Vector3 v)
	{
		m.m02 = v.x;
		m.m12 = v.y;
		m.m22 = v.z;
	}

	// Token: 0x06002757 RID: 10071 RVA: 0x00096CE8 File Offset: 0x00094EE8
	private static global::UnityEngine.Vector3 GET_3X(global::UnityEngine.Matrix4x4 a)
	{
		return global::TransitionFunctions.Vect(a.m30, a.m31, a.m32);
	}

	// Token: 0x06002758 RID: 10072 RVA: 0x00096D04 File Offset: 0x00094F04
	private static global::UnityEngine.Vector3 GET_X3(global::UnityEngine.Matrix4x4 a)
	{
		return global::TransitionFunctions.Vect(a.m03, a.m13, a.m23);
	}

	// Token: 0x06002759 RID: 10073 RVA: 0x00096D20 File Offset: 0x00094F20
	private static void SET_3X(ref global::UnityEngine.Matrix4x4 m, global::UnityEngine.Vector3 v)
	{
		m.m30 = v.x;
		m.m31 = v.y;
		m.m32 = v.z;
	}

	// Token: 0x0600275A RID: 10074 RVA: 0x00096D4C File Offset: 0x00094F4C
	private static void SET_X3(ref global::UnityEngine.Matrix4x4 m, global::UnityEngine.Vector3 v)
	{
		m.m03 = v.x;
		m.m13 = v.y;
		m.m23 = v.z;
	}

	// Token: 0x0600275B RID: 10075 RVA: 0x00096D78 File Offset: 0x00094F78
	private static global::UnityEngine.Vector3 DIR_X(global::UnityEngine.Matrix4x4 a)
	{
		return global::TransitionFunctions.GET_X0(a);
	}

	// Token: 0x0600275C RID: 10076 RVA: 0x00096D80 File Offset: 0x00094F80
	private static void DIR_X(ref global::UnityEngine.Matrix4x4 a, global::UnityEngine.Vector3 v)
	{
		global::TransitionFunctions.SET_X0(ref a, v);
	}

	// Token: 0x0600275D RID: 10077 RVA: 0x00096D8C File Offset: 0x00094F8C
	private static global::UnityEngine.Vector3 DIR_Y(global::UnityEngine.Matrix4x4 a)
	{
		return global::TransitionFunctions.GET_X1(a);
	}

	// Token: 0x0600275E RID: 10078 RVA: 0x00096D94 File Offset: 0x00094F94
	private static void DIR_Y(ref global::UnityEngine.Matrix4x4 a, global::UnityEngine.Vector3 v)
	{
		global::TransitionFunctions.SET_X1(ref a, v);
	}

	// Token: 0x0600275F RID: 10079 RVA: 0x00096DA0 File Offset: 0x00094FA0
	private static global::UnityEngine.Vector3 DIR_Z(global::UnityEngine.Matrix4x4 a)
	{
		return global::TransitionFunctions.GET_X2(a);
	}

	// Token: 0x06002760 RID: 10080 RVA: 0x00096DA8 File Offset: 0x00094FA8
	private static void DIR_Z(ref global::UnityEngine.Matrix4x4 a, global::UnityEngine.Vector3 v)
	{
		global::TransitionFunctions.SET_X2(ref a, v);
	}

	// Token: 0x06002761 RID: 10081 RVA: 0x00096DB4 File Offset: 0x00094FB4
	private static global::UnityEngine.Vector3 TRANS(global::UnityEngine.Matrix4x4 a)
	{
		return global::TransitionFunctions.GET_X3(a);
	}

	// Token: 0x06002762 RID: 10082 RVA: 0x00096DBC File Offset: 0x00094FBC
	private static void TRANS(ref global::UnityEngine.Matrix4x4 a, global::UnityEngine.Vector3 v)
	{
		global::TransitionFunctions.SET_X3(ref a, v);
	}

	// Token: 0x06002763 RID: 10083 RVA: 0x00096DC8 File Offset: 0x00094FC8
	private static global::UnityEngine.Vector3 SCALE(global::UnityEngine.Matrix4x4 a)
	{
		return global::TransitionFunctions.GET_3X(a);
	}

	// Token: 0x06002764 RID: 10084 RVA: 0x00096DD0 File Offset: 0x00094FD0
	private static void SCALE(ref global::UnityEngine.Matrix4x4 a, global::UnityEngine.Vector3 v)
	{
		global::TransitionFunctions.SET_3X(ref a, v);
	}

	// Token: 0x06002765 RID: 10085 RVA: 0x00096DDC File Offset: 0x00094FDC
	private static global::UnityEngine.Vector3 SLERP(float t, global::UnityEngine.Vector3 a, global::UnityEngine.Vector3 b)
	{
		return global::TransitionFunctions.Slerp(t, a, b);
	}

	// Token: 0x06002766 RID: 10086 RVA: 0x00096DE8 File Offset: 0x00094FE8
	private static global::UnityEngine.Vector3 LLERP(float t, global::UnityEngine.Vector3 a, global::UnityEngine.Vector3 b)
	{
		return global::TransitionFunctions.Linear(t, a, b);
	}

	// Token: 0x06002767 RID: 10087 RVA: 0x00096DF4 File Offset: 0x00094FF4
	public static global::UnityEngine.Matrix4x4 Slerp(float t, global::UnityEngine.Matrix4x4 a, global::UnityEngine.Matrix4x4 b)
	{
		global::UnityEngine.Matrix4x4 identity = global::UnityEngine.Matrix4x4.identity;
		global::UnityEngine.Vector3 vector = global::TransitionFunctions.Slerp(t, global::TransitionFunctions.DIR_X(a), global::TransitionFunctions.DIR_X(b));
		global::UnityEngine.Vector3 vector2 = global::TransitionFunctions.Slerp(t, global::TransitionFunctions.DIR_Y(a), global::TransitionFunctions.DIR_Y(b));
		global::UnityEngine.Vector3 vector3 = global::TransitionFunctions.Slerp(t, global::TransitionFunctions.DIR_Z(a), global::TransitionFunctions.DIR_Z(b));
		global::UnityEngine.Quaternion rotation = global::TransitionFunctions.LookRotation(vector3, vector2);
		vector2 = global::TransitionFunctions.Rotate(rotation, global::TransitionFunctions.Y3(global::TransitionFunctions.Length(vector2)));
		if (global::TransitionFunctions.CrossDot(vector3, vector2, vector) > 0f)
		{
			vector = global::TransitionFunctions.Rotate(rotation, global::TransitionFunctions.X3(-global::TransitionFunctions.Length(vector)));
		}
		else
		{
			vector = global::TransitionFunctions.Rotate(rotation, global::TransitionFunctions.X3(global::TransitionFunctions.Length(vector)));
		}
		global::TransitionFunctions.DIR_X(ref identity, vector);
		global::TransitionFunctions.DIR_Y(ref identity, vector2);
		global::TransitionFunctions.DIR_Z(ref identity, vector3);
		global::TransitionFunctions.SCALE(ref identity, global::TransitionFunctions.Linear(t, global::TransitionFunctions.SCALE(a), global::TransitionFunctions.SCALE(b)));
		global::TransitionFunctions.TRANS(ref identity, global::TransitionFunctions.Linear(t, global::TransitionFunctions.TRANS(a), global::TransitionFunctions.TRANS(b)));
		identity.m33 = global::TransitionFunctions.Linear(t, a.m33, b.m33);
		return identity;
	}

	// Token: 0x06002768 RID: 10088 RVA: 0x00096F00 File Offset: 0x00095100
	public static global::UnityEngine.Matrix4x4 SlerpWorldToCamera(float t, global::UnityEngine.Matrix4x4 a, global::UnityEngine.Matrix4x4 b)
	{
		return global::TransitionFunctions.Slerp(t, a.inverse, b.inverse).inverse;
	}

	// Token: 0x06002769 RID: 10089 RVA: 0x00096F2C File Offset: 0x0009512C
	public static global::Facepunch.Precision.Matrix4x4G Linear(double t, global::Facepunch.Precision.Matrix4x4G a, global::Facepunch.Precision.Matrix4x4G b)
	{
		return global::TransitionFunctions.Sum(global::TransitionFunctions.Mul(a, 1.0 - t), global::TransitionFunctions.Mul(b, t));
	}

	// Token: 0x0600276A RID: 10090 RVA: 0x00096F4C File Offset: 0x0009514C
	public static global::Facepunch.Precision.Matrix4x4G Round(double t, global::Facepunch.Precision.Matrix4x4G a, global::Facepunch.Precision.Matrix4x4G b)
	{
		return (t >= 0.5) ? b : a;
	}

	// Token: 0x0600276B RID: 10091 RVA: 0x00096F64 File Offset: 0x00095164
	public static global::Facepunch.Precision.Matrix4x4G Ceil(double t, global::Facepunch.Precision.Matrix4x4G a, global::Facepunch.Precision.Matrix4x4G b)
	{
		return (t <= 0.0) ? a : b;
	}

	// Token: 0x0600276C RID: 10092 RVA: 0x00096F7C File Offset: 0x0009517C
	public static global::Facepunch.Precision.Matrix4x4G Floor(double t, global::Facepunch.Precision.Matrix4x4G a, global::Facepunch.Precision.Matrix4x4G b)
	{
		return (t >= 1.0) ? b : a;
	}

	// Token: 0x0600276D RID: 10093 RVA: 0x00096F94 File Offset: 0x00095194
	public static global::Facepunch.Precision.Matrix4x4G Spline(double t, global::Facepunch.Precision.Matrix4x4G a, global::Facepunch.Precision.Matrix4x4G b)
	{
		return (t > 0.0) ? ((t < 1.0) ? global::TransitionFunctions.Linear(global::TransitionFunctions.SimpleSpline(t), a, b) : b) : a;
	}

	// Token: 0x0600276E RID: 10094 RVA: 0x00096FD0 File Offset: 0x000951D0
	public static global::Facepunch.Precision.Matrix4x4G Evaluate(this global::TransitionFunction f, double t, global::Facepunch.Precision.Matrix4x4G a, global::Facepunch.Precision.Matrix4x4G b)
	{
		switch (f)
		{
		case global::TransitionFunction.Linear:
			return global::TransitionFunctions.Linear(t, a, b);
		case global::TransitionFunction.Round:
			return global::TransitionFunctions.Round(t, a, b);
		case global::TransitionFunction.Floor:
			return global::TransitionFunctions.Floor(t, a, b);
		case global::TransitionFunction.Ceil:
			return global::TransitionFunctions.Ceil(t, a, b);
		case global::TransitionFunction.Spline:
			return global::TransitionFunctions.Spline(t, a, b);
		default:
			throw new global::System.ArgumentOutOfRangeException("v", "Attempted use of unrecognized TransitionFunction enum value");
		}
	}

	// Token: 0x0600276F RID: 10095 RVA: 0x0009703C File Offset: 0x0009523C
	public static global::Facepunch.Precision.Matrix4x4G Evaluate(this global::TransitionFunction<global::Facepunch.Precision.Matrix4x4G> v, double t)
	{
		return v.f.Evaluate(t, v.a, v.b);
	}

	// Token: 0x06002770 RID: 10096 RVA: 0x0009705C File Offset: 0x0009525C
	public static global::Facepunch.Precision.Matrix4x4G Mul(global::Facepunch.Precision.Matrix4x4G a, double b)
	{
		global::Facepunch.Precision.Matrix4x4G result;
		result.m00 = a.m00 * b;
		result.m10 = a.m10 * b;
		result.m20 = a.m20 * b;
		result.m30 = a.m30 * b;
		result.m01 = a.m01 * b;
		result.m11 = a.m11 * b;
		result.m21 = a.m21 * b;
		result.m31 = a.m31 * b;
		result.m02 = a.m02 * b;
		result.m12 = a.m12 * b;
		result.m22 = a.m22 * b;
		result.m32 = a.m32 * b;
		result.m03 = a.m03 * b;
		result.m13 = a.m13 * b;
		result.m23 = a.m23 * b;
		result.m33 = a.m33 * b;
		return result;
	}

	// Token: 0x06002771 RID: 10097 RVA: 0x0009716C File Offset: 0x0009536C
	public static global::Facepunch.Precision.Matrix4x4G Sum(global::Facepunch.Precision.Matrix4x4G a, global::Facepunch.Precision.Matrix4x4G b)
	{
		global::Facepunch.Precision.Matrix4x4G result;
		result.m00 = a.m00 + b.m00;
		result.m10 = a.m10 + b.m10;
		result.m20 = a.m20 + b.m20;
		result.m30 = a.m30 + b.m30;
		result.m01 = a.m01 + b.m01;
		result.m11 = a.m11 + b.m11;
		result.m21 = a.m21 + b.m21;
		result.m31 = a.m31 + b.m31;
		result.m02 = a.m02 + b.m02;
		result.m12 = a.m12 + b.m12;
		result.m22 = a.m22 + b.m22;
		result.m32 = a.m32 + b.m32;
		result.m03 = a.m03 + b.m03;
		result.m13 = a.m13 + b.m13;
		result.m23 = a.m23 + b.m23;
		result.m33 = a.m33 + b.m33;
		return result;
	}

	// Token: 0x06002772 RID: 10098 RVA: 0x000972DC File Offset: 0x000954DC
	public static global::Facepunch.Precision.Matrix4x4G Inverse(global::Facepunch.Precision.Matrix4x4G v)
	{
		global::Facepunch.Precision.Matrix4x4G result;
		global::Facepunch.Precision.Matrix4x4G.Inverse(ref v, ref result);
		return result;
	}

	// Token: 0x06002773 RID: 10099 RVA: 0x000972F4 File Offset: 0x000954F4
	public static global::Facepunch.Precision.Matrix4x4G Transpose(global::Facepunch.Precision.Matrix4x4G v)
	{
		global::Facepunch.Precision.Matrix4x4G result;
		global::Facepunch.Precision.Matrix4x4G.Transpose(ref v, ref result);
		return result;
	}

	// Token: 0x06002774 RID: 10100 RVA: 0x0009730C File Offset: 0x0009550C
	private static global::Facepunch.Precision.Vector3G VECT3F(double x, double y, double z)
	{
		global::Facepunch.Precision.Vector3G result;
		result.x = x;
		result.y = y;
		result.z = z;
		return result;
	}

	// Token: 0x06002775 RID: 10101 RVA: 0x00097334 File Offset: 0x00095534
	private static global::Facepunch.Precision.Vector3G GET_0X(global::Facepunch.Precision.Matrix4x4G a)
	{
		return global::TransitionFunctions.VECT3F(a.m00, a.m01, a.m02);
	}

	// Token: 0x06002776 RID: 10102 RVA: 0x00097350 File Offset: 0x00095550
	private static global::Facepunch.Precision.Vector3G GET_X0(global::Facepunch.Precision.Matrix4x4G a)
	{
		return global::TransitionFunctions.VECT3F(a.m00, a.m10, a.m20);
	}

	// Token: 0x06002777 RID: 10103 RVA: 0x0009736C File Offset: 0x0009556C
	private static void SET_0X(ref global::Facepunch.Precision.Matrix4x4G m, global::Facepunch.Precision.Vector3G v)
	{
		m.m00 = v.x;
		m.m01 = v.y;
		m.m02 = v.z;
	}

	// Token: 0x06002778 RID: 10104 RVA: 0x00097398 File Offset: 0x00095598
	private static void SET_X0(ref global::Facepunch.Precision.Matrix4x4G m, global::Facepunch.Precision.Vector3G v)
	{
		m.m00 = v.x;
		m.m10 = v.y;
		m.m20 = v.z;
	}

	// Token: 0x06002779 RID: 10105 RVA: 0x000973C4 File Offset: 0x000955C4
	private static global::Facepunch.Precision.Vector3G GET_1X(global::Facepunch.Precision.Matrix4x4G a)
	{
		return global::TransitionFunctions.VECT3F(a.m10, a.m11, a.m12);
	}

	// Token: 0x0600277A RID: 10106 RVA: 0x000973E0 File Offset: 0x000955E0
	private static global::Facepunch.Precision.Vector3G GET_X1(global::Facepunch.Precision.Matrix4x4G a)
	{
		return global::TransitionFunctions.VECT3F(a.m01, a.m11, a.m21);
	}

	// Token: 0x0600277B RID: 10107 RVA: 0x000973FC File Offset: 0x000955FC
	private static void SET_1X(ref global::Facepunch.Precision.Matrix4x4G m, global::Facepunch.Precision.Vector3G v)
	{
		m.m10 = v.x;
		m.m11 = v.y;
		m.m12 = v.z;
	}

	// Token: 0x0600277C RID: 10108 RVA: 0x00097428 File Offset: 0x00095628
	private static void SET_X1(ref global::Facepunch.Precision.Matrix4x4G m, global::Facepunch.Precision.Vector3G v)
	{
		m.m01 = v.x;
		m.m11 = v.y;
		m.m21 = v.z;
	}

	// Token: 0x0600277D RID: 10109 RVA: 0x00097454 File Offset: 0x00095654
	private static global::Facepunch.Precision.Vector3G GET_2X(global::Facepunch.Precision.Matrix4x4G a)
	{
		return global::TransitionFunctions.VECT3F(a.m20, a.m21, a.m22);
	}

	// Token: 0x0600277E RID: 10110 RVA: 0x00097470 File Offset: 0x00095670
	private static global::Facepunch.Precision.Vector3G GET_X2(global::Facepunch.Precision.Matrix4x4G a)
	{
		return global::TransitionFunctions.VECT3F(a.m02, a.m12, a.m22);
	}

	// Token: 0x0600277F RID: 10111 RVA: 0x0009748C File Offset: 0x0009568C
	private static void SET_2X(ref global::Facepunch.Precision.Matrix4x4G m, global::Facepunch.Precision.Vector3G v)
	{
		m.m20 = v.x;
		m.m21 = v.y;
		m.m22 = v.z;
	}

	// Token: 0x06002780 RID: 10112 RVA: 0x000974B8 File Offset: 0x000956B8
	private static void SET_X2(ref global::Facepunch.Precision.Matrix4x4G m, global::Facepunch.Precision.Vector3G v)
	{
		m.m02 = v.x;
		m.m12 = v.y;
		m.m22 = v.z;
	}

	// Token: 0x06002781 RID: 10113 RVA: 0x000974E4 File Offset: 0x000956E4
	private static global::Facepunch.Precision.Vector3G GET_3X(global::Facepunch.Precision.Matrix4x4G a)
	{
		return global::TransitionFunctions.VECT3F(a.m30, a.m31, a.m32);
	}

	// Token: 0x06002782 RID: 10114 RVA: 0x00097500 File Offset: 0x00095700
	private static global::Facepunch.Precision.Vector3G GET_X3(global::Facepunch.Precision.Matrix4x4G a)
	{
		return global::TransitionFunctions.VECT3F(a.m03, a.m13, a.m23);
	}

	// Token: 0x06002783 RID: 10115 RVA: 0x0009751C File Offset: 0x0009571C
	private static void SET_3X(ref global::Facepunch.Precision.Matrix4x4G m, global::Facepunch.Precision.Vector3G v)
	{
		m.m30 = v.x;
		m.m31 = v.y;
		m.m32 = v.z;
	}

	// Token: 0x06002784 RID: 10116 RVA: 0x00097548 File Offset: 0x00095748
	private static void SET_X3(ref global::Facepunch.Precision.Matrix4x4G m, global::Facepunch.Precision.Vector3G v)
	{
		m.m03 = v.x;
		m.m13 = v.y;
		m.m23 = v.z;
	}

	// Token: 0x06002785 RID: 10117 RVA: 0x00097574 File Offset: 0x00095774
	private static global::Facepunch.Precision.Vector3G DIR_X(global::Facepunch.Precision.Matrix4x4G a)
	{
		return global::TransitionFunctions.GET_X0(a);
	}

	// Token: 0x06002786 RID: 10118 RVA: 0x0009757C File Offset: 0x0009577C
	private static void DIR_X(ref global::Facepunch.Precision.Matrix4x4G a, global::Facepunch.Precision.Vector3G v)
	{
		global::TransitionFunctions.SET_X0(ref a, v);
	}

	// Token: 0x06002787 RID: 10119 RVA: 0x00097588 File Offset: 0x00095788
	private static global::Facepunch.Precision.Vector3G DIR_Y(global::Facepunch.Precision.Matrix4x4G a)
	{
		return global::TransitionFunctions.GET_X1(a);
	}

	// Token: 0x06002788 RID: 10120 RVA: 0x00097590 File Offset: 0x00095790
	private static void DIR_Y(ref global::Facepunch.Precision.Matrix4x4G a, global::Facepunch.Precision.Vector3G v)
	{
		global::TransitionFunctions.SET_X1(ref a, v);
	}

	// Token: 0x06002789 RID: 10121 RVA: 0x0009759C File Offset: 0x0009579C
	private static global::Facepunch.Precision.Vector3G DIR_Z(global::Facepunch.Precision.Matrix4x4G a)
	{
		return global::TransitionFunctions.GET_X2(a);
	}

	// Token: 0x0600278A RID: 10122 RVA: 0x000975A4 File Offset: 0x000957A4
	private static void DIR_Z(ref global::Facepunch.Precision.Matrix4x4G a, global::Facepunch.Precision.Vector3G v)
	{
		global::TransitionFunctions.SET_X2(ref a, v);
	}

	// Token: 0x0600278B RID: 10123 RVA: 0x000975B0 File Offset: 0x000957B0
	private static global::Facepunch.Precision.Vector3G TRANS(global::Facepunch.Precision.Matrix4x4G a)
	{
		return global::TransitionFunctions.GET_X3(a);
	}

	// Token: 0x0600278C RID: 10124 RVA: 0x000975B8 File Offset: 0x000957B8
	private static void TRANS(ref global::Facepunch.Precision.Matrix4x4G a, global::Facepunch.Precision.Vector3G v)
	{
		global::TransitionFunctions.SET_X3(ref a, v);
	}

	// Token: 0x0600278D RID: 10125 RVA: 0x000975C4 File Offset: 0x000957C4
	private static global::Facepunch.Precision.Vector3G SCALE(global::Facepunch.Precision.Matrix4x4G a)
	{
		return global::TransitionFunctions.GET_3X(a);
	}

	// Token: 0x0600278E RID: 10126 RVA: 0x000975CC File Offset: 0x000957CC
	private static void SCALE(ref global::Facepunch.Precision.Matrix4x4G a, global::Facepunch.Precision.Vector3G v)
	{
		global::TransitionFunctions.SET_3X(ref a, v);
	}

	// Token: 0x0600278F RID: 10127 RVA: 0x000975D8 File Offset: 0x000957D8
	private static global::Facepunch.Precision.Vector3G SLERP(double t, global::Facepunch.Precision.Vector3G a, global::Facepunch.Precision.Vector3G b)
	{
		return global::TransitionFunctions.Slerp(t, a, b);
	}

	// Token: 0x06002790 RID: 10128 RVA: 0x000975E4 File Offset: 0x000957E4
	private static global::Facepunch.Precision.Vector3G LLERP(double t, global::Facepunch.Precision.Vector3G a, global::Facepunch.Precision.Vector3G b)
	{
		return global::TransitionFunctions.Linear(t, a, b);
	}

	// Token: 0x06002791 RID: 10129 RVA: 0x000975F0 File Offset: 0x000957F0
	public static global::Facepunch.Precision.Matrix4x4G Slerp(double t, global::Facepunch.Precision.Matrix4x4G a, global::Facepunch.Precision.Matrix4x4G b)
	{
		global::Facepunch.Precision.Matrix4x4G identity = global::Facepunch.Precision.Matrix4x4G.identity;
		global::Facepunch.Precision.Vector3G vector3G = global::TransitionFunctions.Slerp(t, global::TransitionFunctions.DIR_X(a), global::TransitionFunctions.DIR_X(b));
		global::Facepunch.Precision.Vector3G vector3G2 = global::TransitionFunctions.Slerp(t, global::TransitionFunctions.DIR_Y(a), global::TransitionFunctions.DIR_Y(b));
		global::Facepunch.Precision.Vector3G vector3G3 = global::TransitionFunctions.Slerp(t, global::TransitionFunctions.DIR_Z(a), global::TransitionFunctions.DIR_Z(b));
		global::Facepunch.Precision.QuaternionG rotation = global::TransitionFunctions.LookRotation(vector3G3, vector3G2);
		vector3G2 = global::TransitionFunctions.Rotate(rotation, global::TransitionFunctions.Y3(global::TransitionFunctions.Length(vector3G2)));
		if (global::TransitionFunctions.CrossDot(vector3G3, vector3G2, vector3G) > 0.0)
		{
			vector3G = global::TransitionFunctions.Rotate(rotation, global::TransitionFunctions.X3(-global::TransitionFunctions.Length(vector3G)));
		}
		else
		{
			vector3G = global::TransitionFunctions.Rotate(rotation, global::TransitionFunctions.X3(global::TransitionFunctions.Length(vector3G)));
		}
		global::TransitionFunctions.DIR_X(ref identity, vector3G);
		global::TransitionFunctions.DIR_Y(ref identity, vector3G2);
		global::TransitionFunctions.DIR_Z(ref identity, vector3G3);
		global::TransitionFunctions.SCALE(ref identity, global::TransitionFunctions.Linear(t, global::TransitionFunctions.SCALE(a), global::TransitionFunctions.SCALE(b)));
		global::TransitionFunctions.TRANS(ref identity, global::TransitionFunctions.Linear(t, global::TransitionFunctions.TRANS(a), global::TransitionFunctions.TRANS(b)));
		identity.m33 = global::TransitionFunctions.Linear(t, a.m33, b.m33);
		return identity;
	}

	// Token: 0x06002792 RID: 10130 RVA: 0x00097700 File Offset: 0x00095900
	public static global::Facepunch.Precision.Matrix4x4G SlerpWorldToCamera(double t, global::Facepunch.Precision.Matrix4x4G a, global::Facepunch.Precision.Matrix4x4G b)
	{
		return global::TransitionFunctions.Inverse(global::TransitionFunctions.Slerp(t, global::TransitionFunctions.Inverse(a), global::TransitionFunctions.Inverse(b)));
	}

	// Token: 0x06002793 RID: 10131 RVA: 0x0009771C File Offset: 0x0009591C
	public static global::UnityEngine.Quaternion Round(float t, global::UnityEngine.Quaternion a, global::UnityEngine.Quaternion b)
	{
		return (t >= 0.5f) ? b : a;
	}

	// Token: 0x06002794 RID: 10132 RVA: 0x00097730 File Offset: 0x00095930
	public static global::UnityEngine.Quaternion Ceil(float t, global::UnityEngine.Quaternion a, global::UnityEngine.Quaternion b)
	{
		return (t <= 0f) ? a : b;
	}

	// Token: 0x06002795 RID: 10133 RVA: 0x00097744 File Offset: 0x00095944
	public static global::UnityEngine.Quaternion Floor(float t, global::UnityEngine.Quaternion a, global::UnityEngine.Quaternion b)
	{
		return (t >= 1f) ? b : a;
	}

	// Token: 0x06002796 RID: 10134 RVA: 0x00097758 File Offset: 0x00095958
	public static global::UnityEngine.Quaternion Spline(float t, global::UnityEngine.Quaternion a, global::UnityEngine.Quaternion b)
	{
		return (t > 0f) ? ((t < 1f) ? global::TransitionFunctions.Linear(global::TransitionFunctions.SimpleSpline(t), a, b) : b) : a;
	}

	// Token: 0x06002797 RID: 10135 RVA: 0x0009778C File Offset: 0x0009598C
	public static global::UnityEngine.Quaternion Evaluate(this global::TransitionFunction f, float t, global::UnityEngine.Quaternion a, global::UnityEngine.Quaternion b)
	{
		switch (f)
		{
		case global::TransitionFunction.Linear:
			return global::TransitionFunctions.Linear(t, a, b);
		case global::TransitionFunction.Round:
			return global::TransitionFunctions.Round(t, a, b);
		case global::TransitionFunction.Floor:
			return global::TransitionFunctions.Floor(t, a, b);
		case global::TransitionFunction.Ceil:
			return global::TransitionFunctions.Ceil(t, a, b);
		case global::TransitionFunction.Spline:
			return global::TransitionFunctions.Spline(t, a, b);
		default:
			throw new global::System.ArgumentOutOfRangeException("v", "Attempted use of unrecognized TransitionFunction enum value");
		}
	}

	// Token: 0x06002798 RID: 10136 RVA: 0x000977F8 File Offset: 0x000959F8
	public static global::UnityEngine.Quaternion Evaluate(this global::TransitionFunction<global::UnityEngine.Quaternion> v, float t)
	{
		return v.f.Evaluate(t, v.a, v.b);
	}

	// Token: 0x06002799 RID: 10137 RVA: 0x00097818 File Offset: 0x00095A18
	public static global::UnityEngine.Quaternion Mul(global::UnityEngine.Quaternion a, float b)
	{
		global::UnityEngine.Quaternion result;
		result.x = a.x * b;
		result.y = a.y * b;
		result.z = a.z * b;
		result.w = a.w * b;
		return result;
	}

	// Token: 0x0600279A RID: 10138 RVA: 0x00097868 File Offset: 0x00095A68
	public static global::UnityEngine.Quaternion Sum(global::UnityEngine.Quaternion a, global::UnityEngine.Quaternion b)
	{
		global::UnityEngine.Quaternion result;
		result.x = a.x + b.x;
		result.y = a.y + b.y;
		result.z = a.z + b.z;
		result.w = a.w * b.w;
		return result;
	}

	// Token: 0x0600279B RID: 10139 RVA: 0x000978D0 File Offset: 0x00095AD0
	public static global::UnityEngine.Quaternion Linear(float t, global::UnityEngine.Quaternion a, global::UnityEngine.Quaternion b)
	{
		return global::TransitionFunctions.Slerp(t, a, b);
	}

	// Token: 0x0600279C RID: 10140 RVA: 0x000978DC File Offset: 0x00095ADC
	public static global::UnityEngine.Quaternion Slerp(float t, global::UnityEngine.Quaternion a, global::UnityEngine.Quaternion b)
	{
		global::UnityEngine.Quaternion result;
		if (t == 0f)
		{
			result = a;
		}
		else if (t == 1f)
		{
			result = b;
		}
		else
		{
			float num = a.x * b.x + a.y * b.y + a.z * b.z + a.w * b.w;
			if (num == 1f)
			{
				result = a;
			}
			else if (num < 0f)
			{
				num = global::TransitionFunctions.Acos(-num);
				float num2 = global::TransitionFunctions.Sin(num);
				if (num2 == 0f)
				{
					float num3 = 1f - t;
					result.x = a.x * num3 + b.x * t;
					result.y = a.y * num3 + b.y * t;
					result.z = a.z * num3 + b.z * t;
					result.w = a.w * num3 + b.w * t;
				}
				else
				{
					float num4 = global::TransitionFunctions.Sin(num * t);
					float num3 = global::TransitionFunctions.Sin(num * (1f - t));
					result.x = (a.x * num3 - b.x * num4) / num2;
					result.y = (a.y * num3 - b.y * num4) / num2;
					result.z = (a.z * num3 - b.z * num4) / num2;
					result.w = (a.w * num3 - b.w * num4) / num2;
				}
			}
			else
			{
				num = global::TransitionFunctions.Acos(num);
				float num2 = global::TransitionFunctions.Sin(num);
				if (num2 == 0f)
				{
					float num3 = 1f - t;
					result.x = a.x * num3 + b.x * t;
					result.y = a.y * num3 + b.y * t;
					result.z = a.z * num3 + b.z * t;
					result.w = a.w * num3 + b.w * t;
				}
				else
				{
					float num4 = global::TransitionFunctions.Sin(num * t);
					float num3 = global::TransitionFunctions.Sin(num * (1f - t));
					result.x = (a.x * num3 + b.x * num4) / num2;
					result.y = (a.y * num3 + b.y * num4) / num2;
					result.z = (a.z * num3 + b.z * num4) / num2;
					result.w = (a.w * num3 + b.w * num4) / num2;
				}
			}
		}
		return result;
	}

	// Token: 0x0600279D RID: 10141 RVA: 0x00097BC0 File Offset: 0x00095DC0
	public static global::UnityEngine.Quaternion LookRotation(global::UnityEngine.Vector3 forward, global::UnityEngine.Vector3 up)
	{
		return global::UnityEngine.Quaternion.LookRotation(forward, up);
	}

	// Token: 0x0600279E RID: 10142 RVA: 0x00097BCC File Offset: 0x00095DCC
	public static global::UnityEngine.Vector3 Rotate(global::UnityEngine.Quaternion rotation, global::UnityEngine.Vector3 vector)
	{
		return rotation * vector;
	}

	// Token: 0x0600279F RID: 10143 RVA: 0x00097BD8 File Offset: 0x00095DD8
	public static global::Facepunch.Precision.QuaternionG Round(double t, global::Facepunch.Precision.QuaternionG a, global::Facepunch.Precision.QuaternionG b)
	{
		return (t >= 0.5) ? b : a;
	}

	// Token: 0x060027A0 RID: 10144 RVA: 0x00097BF0 File Offset: 0x00095DF0
	public static global::Facepunch.Precision.QuaternionG Ceil(double t, global::Facepunch.Precision.QuaternionG a, global::Facepunch.Precision.QuaternionG b)
	{
		return (t <= 0.0) ? a : b;
	}

	// Token: 0x060027A1 RID: 10145 RVA: 0x00097C08 File Offset: 0x00095E08
	public static global::Facepunch.Precision.QuaternionG Floor(double t, global::Facepunch.Precision.QuaternionG a, global::Facepunch.Precision.QuaternionG b)
	{
		return (t >= 1.0) ? b : a;
	}

	// Token: 0x060027A2 RID: 10146 RVA: 0x00097C20 File Offset: 0x00095E20
	public static global::Facepunch.Precision.QuaternionG Spline(double t, global::Facepunch.Precision.QuaternionG a, global::Facepunch.Precision.QuaternionG b)
	{
		return (t > 0.0) ? ((t < 1.0) ? global::TransitionFunctions.Linear(global::TransitionFunctions.SimpleSpline(t), a, b) : b) : a;
	}

	// Token: 0x060027A3 RID: 10147 RVA: 0x00097C5C File Offset: 0x00095E5C
	public static global::Facepunch.Precision.QuaternionG Evaluate(this global::TransitionFunction f, double t, global::Facepunch.Precision.QuaternionG a, global::Facepunch.Precision.QuaternionG b)
	{
		switch (f)
		{
		case global::TransitionFunction.Linear:
			return global::TransitionFunctions.Linear(t, a, b);
		case global::TransitionFunction.Round:
			return global::TransitionFunctions.Round(t, a, b);
		case global::TransitionFunction.Floor:
			return global::TransitionFunctions.Floor(t, a, b);
		case global::TransitionFunction.Ceil:
			return global::TransitionFunctions.Ceil(t, a, b);
		case global::TransitionFunction.Spline:
			return global::TransitionFunctions.Spline(t, a, b);
		default:
			throw new global::System.ArgumentOutOfRangeException("v", "Attempted use of unrecognized TransitionFunction enum value");
		}
	}

	// Token: 0x060027A4 RID: 10148 RVA: 0x00097CC8 File Offset: 0x00095EC8
	public static global::Facepunch.Precision.QuaternionG Evaluate(this global::TransitionFunction<global::Facepunch.Precision.QuaternionG> v, double t)
	{
		return v.f.Evaluate(t, v.a, v.b);
	}

	// Token: 0x060027A5 RID: 10149 RVA: 0x00097CE8 File Offset: 0x00095EE8
	public static global::Facepunch.Precision.QuaternionG Mul(global::Facepunch.Precision.QuaternionG a, double b)
	{
		global::Facepunch.Precision.QuaternionG result;
		result.x = a.x * b;
		result.y = a.y * b;
		result.z = a.z * b;
		result.w = a.w * b;
		return result;
	}

	// Token: 0x060027A6 RID: 10150 RVA: 0x00097D38 File Offset: 0x00095F38
	public static global::Facepunch.Precision.QuaternionG Sum(global::Facepunch.Precision.QuaternionG a, global::Facepunch.Precision.QuaternionG b)
	{
		global::Facepunch.Precision.QuaternionG result;
		result.x = a.x + b.x;
		result.y = a.y + b.y;
		result.z = a.z + b.z;
		result.w = a.w * b.w;
		return result;
	}

	// Token: 0x060027A7 RID: 10151 RVA: 0x00097DA0 File Offset: 0x00095FA0
	public static global::Facepunch.Precision.QuaternionG Linear(double t, global::Facepunch.Precision.QuaternionG a, global::Facepunch.Precision.QuaternionG b)
	{
		return global::TransitionFunctions.Slerp(t, a, b);
	}

	// Token: 0x060027A8 RID: 10152 RVA: 0x00097DAC File Offset: 0x00095FAC
	public static global::Facepunch.Precision.QuaternionG Slerp(double t, global::Facepunch.Precision.QuaternionG a, global::Facepunch.Precision.QuaternionG b)
	{
		global::Facepunch.Precision.QuaternionG result;
		if (t == 0.0)
		{
			result = a;
		}
		else if (t == 1.0)
		{
			result = b;
		}
		else
		{
			double num = a.x * b.x + a.y * b.y + a.z * b.z + a.w * b.w;
			if (num == 1.0)
			{
				result = a;
			}
			else if (num < 0.0)
			{
				num = global::TransitionFunctions.Acos(-num);
				double num2 = global::TransitionFunctions.Sin(num);
				if (num2 == 0.0)
				{
					double num3 = 1.0 - t;
					result.x = a.x * num3 + b.x * t;
					result.y = a.y * num3 + b.y * t;
					result.z = a.z * num3 + b.z * t;
					result.w = a.w * num3 + b.w * t;
				}
				else
				{
					double num4 = global::TransitionFunctions.Sin(num * t);
					double num3 = global::TransitionFunctions.Sin(num * (1.0 - t));
					result.x = (a.x * num3 - b.x * num4) / num2;
					result.y = (a.y * num3 - b.y * num4) / num2;
					result.z = (a.z * num3 - b.z * num4) / num2;
					result.w = (a.w * num3 - b.w * num4) / num2;
				}
			}
			else
			{
				num = global::TransitionFunctions.Acos(num);
				double num2 = global::TransitionFunctions.Sin(num);
				if (num2 == 0.0)
				{
					double num3 = 1.0 - t;
					result.x = a.x * num3 + b.x * t;
					result.y = a.y * num3 + b.y * t;
					result.z = a.z * num3 + b.z * t;
					result.w = a.w * num3 + b.w * t;
				}
				else
				{
					double num4 = global::TransitionFunctions.Sin(num * t);
					double num3 = global::TransitionFunctions.Sin(num * (1.0 - t));
					result.x = (a.x * num3 + b.x * num4) / num2;
					result.y = (a.y * num3 + b.y * num4) / num2;
					result.z = (a.z * num3 + b.z * num4) / num2;
					result.w = (a.w * num3 + b.w * num4) / num2;
				}
			}
		}
		return result;
	}

	// Token: 0x060027A9 RID: 10153 RVA: 0x000980B8 File Offset: 0x000962B8
	public static global::Facepunch.Precision.QuaternionG LookRotation(global::Facepunch.Precision.Vector3G forward, global::Facepunch.Precision.Vector3G up)
	{
		global::Facepunch.Precision.QuaternionG result;
		global::Facepunch.Precision.QuaternionG.LookRotation(ref forward, ref up, ref result);
		return result;
	}

	// Token: 0x060027AA RID: 10154 RVA: 0x000980D4 File Offset: 0x000962D4
	public static global::Facepunch.Precision.Vector3G Rotate(global::Facepunch.Precision.QuaternionG rotation, global::Facepunch.Precision.Vector3G vector)
	{
		global::Facepunch.Precision.Vector3G result;
		global::Facepunch.Precision.QuaternionG.Mult(ref rotation, ref vector, ref result);
		return result;
	}

	// Token: 0x060027AB RID: 10155 RVA: 0x000980F0 File Offset: 0x000962F0
	public static global::UnityEngine.Vector2 Linear(float t, global::UnityEngine.Vector2 a, global::UnityEngine.Vector2 b)
	{
		return global::TransitionFunctions.Sum(global::TransitionFunctions.Mul(a, 1f - t), global::TransitionFunctions.Mul(b, t));
	}

	// Token: 0x060027AC RID: 10156 RVA: 0x0009810C File Offset: 0x0009630C
	public static global::UnityEngine.Vector2 Round(float t, global::UnityEngine.Vector2 a, global::UnityEngine.Vector2 b)
	{
		return (t >= 0.5f) ? b : a;
	}

	// Token: 0x060027AD RID: 10157 RVA: 0x00098120 File Offset: 0x00096320
	public static global::UnityEngine.Vector2 Ceil(float t, global::UnityEngine.Vector2 a, global::UnityEngine.Vector2 b)
	{
		return (t <= 0f) ? a : b;
	}

	// Token: 0x060027AE RID: 10158 RVA: 0x00098134 File Offset: 0x00096334
	public static global::UnityEngine.Vector2 Floor(float t, global::UnityEngine.Vector2 a, global::UnityEngine.Vector2 b)
	{
		return (t >= 1f) ? b : a;
	}

	// Token: 0x060027AF RID: 10159 RVA: 0x00098148 File Offset: 0x00096348
	public static global::UnityEngine.Vector2 Spline(float t, global::UnityEngine.Vector2 a, global::UnityEngine.Vector2 b)
	{
		return (t > 0f) ? ((t < 1f) ? global::TransitionFunctions.Linear(global::TransitionFunctions.SimpleSpline(t), a, b) : b) : a;
	}

	// Token: 0x060027B0 RID: 10160 RVA: 0x0009817C File Offset: 0x0009637C
	public static global::UnityEngine.Vector2 Evaluate(this global::TransitionFunction f, float t, global::UnityEngine.Vector2 a, global::UnityEngine.Vector2 b)
	{
		switch (f)
		{
		case global::TransitionFunction.Linear:
			return global::TransitionFunctions.Linear(t, a, b);
		case global::TransitionFunction.Round:
			return global::TransitionFunctions.Round(t, a, b);
		case global::TransitionFunction.Floor:
			return global::TransitionFunctions.Floor(t, a, b);
		case global::TransitionFunction.Ceil:
			return global::TransitionFunctions.Ceil(t, a, b);
		case global::TransitionFunction.Spline:
			return global::TransitionFunctions.Spline(t, a, b);
		default:
			throw new global::System.ArgumentOutOfRangeException("v", "Attempted use of unrecognized TransitionFunction enum value");
		}
	}

	// Token: 0x060027B1 RID: 10161 RVA: 0x000981E8 File Offset: 0x000963E8
	public static global::UnityEngine.Vector2 Evaluate(this global::TransitionFunction<global::UnityEngine.Vector2> v, float t)
	{
		return v.f.Evaluate(t, v.a, v.b);
	}

	// Token: 0x060027B2 RID: 10162 RVA: 0x00098208 File Offset: 0x00096408
	public static global::UnityEngine.Vector2 Mul(global::UnityEngine.Vector2 a, float b)
	{
		global::UnityEngine.Vector2 result;
		result.x = a.x * b;
		result.y = a.y * b;
		return result;
	}

	// Token: 0x060027B3 RID: 10163 RVA: 0x00098238 File Offset: 0x00096438
	public static global::UnityEngine.Vector2 Sum(global::UnityEngine.Vector2 a, global::UnityEngine.Vector2 b)
	{
		global::UnityEngine.Vector2 result;
		result.x = a.x + b.x;
		result.y = a.y + b.y;
		return result;
	}

	// Token: 0x060027B4 RID: 10164 RVA: 0x00098274 File Offset: 0x00096474
	public static global::UnityEngine.Vector2 Slerp(float t, global::UnityEngine.Vector2 a, global::UnityEngine.Vector2 b)
	{
		float num = global::TransitionFunctions.DegreesToRadians(global::UnityEngine.Vector2.Angle(a, b));
		float num2;
		if (num == 0f || (num2 = global::TransitionFunctions.Sin(num)) == 0f)
		{
			return global::TransitionFunctions.Linear(t, a, b);
		}
		float b2 = global::TransitionFunctions.Sin((1f - t) * num) / num2;
		float b3 = global::TransitionFunctions.Sin(t * num) / num2;
		return global::TransitionFunctions.Sum(global::TransitionFunctions.Mul(a, b2), global::TransitionFunctions.Mul(b, b3));
	}

	// Token: 0x060027B5 RID: 10165 RVA: 0x000982E8 File Offset: 0x000964E8
	public static global::UnityEngine.Vector3 Linear(float t, global::UnityEngine.Vector3 a, global::UnityEngine.Vector3 b)
	{
		return global::TransitionFunctions.Sum(global::TransitionFunctions.Mul(a, 1f - t), global::TransitionFunctions.Mul(b, t));
	}

	// Token: 0x060027B6 RID: 10166 RVA: 0x00098304 File Offset: 0x00096504
	public static global::UnityEngine.Vector3 Round(float t, global::UnityEngine.Vector3 a, global::UnityEngine.Vector3 b)
	{
		return (t >= 0.5f) ? b : a;
	}

	// Token: 0x060027B7 RID: 10167 RVA: 0x00098318 File Offset: 0x00096518
	public static global::UnityEngine.Vector3 Ceil(float t, global::UnityEngine.Vector3 a, global::UnityEngine.Vector3 b)
	{
		return (t <= 0f) ? a : b;
	}

	// Token: 0x060027B8 RID: 10168 RVA: 0x0009832C File Offset: 0x0009652C
	public static global::UnityEngine.Vector3 Floor(float t, global::UnityEngine.Vector3 a, global::UnityEngine.Vector3 b)
	{
		return (t >= 1f) ? b : a;
	}

	// Token: 0x060027B9 RID: 10169 RVA: 0x00098340 File Offset: 0x00096540
	public static global::UnityEngine.Vector3 Spline(float t, global::UnityEngine.Vector3 a, global::UnityEngine.Vector3 b)
	{
		return (t > 0f) ? ((t < 1f) ? global::TransitionFunctions.Linear(global::TransitionFunctions.SimpleSpline(t), a, b) : b) : a;
	}

	// Token: 0x060027BA RID: 10170 RVA: 0x00098374 File Offset: 0x00096574
	public static global::UnityEngine.Vector3 Evaluate(this global::TransitionFunction f, float t, global::UnityEngine.Vector3 a, global::UnityEngine.Vector3 b)
	{
		switch (f)
		{
		case global::TransitionFunction.Linear:
			return global::TransitionFunctions.Linear(t, a, b);
		case global::TransitionFunction.Round:
			return global::TransitionFunctions.Round(t, a, b);
		case global::TransitionFunction.Floor:
			return global::TransitionFunctions.Floor(t, a, b);
		case global::TransitionFunction.Ceil:
			return global::TransitionFunctions.Ceil(t, a, b);
		case global::TransitionFunction.Spline:
			return global::TransitionFunctions.Spline(t, a, b);
		default:
			throw new global::System.ArgumentOutOfRangeException("v", "Attempted use of unrecognized TransitionFunction enum value");
		}
	}

	// Token: 0x060027BB RID: 10171 RVA: 0x000983E0 File Offset: 0x000965E0
	public static global::UnityEngine.Vector3 Evaluate(this global::TransitionFunction<global::UnityEngine.Vector3> v, float t)
	{
		return v.f.Evaluate(t, v.a, v.b);
	}

	// Token: 0x060027BC RID: 10172 RVA: 0x00098400 File Offset: 0x00096600
	public static global::UnityEngine.Vector3 Mul(global::UnityEngine.Vector3 a, float b)
	{
		global::UnityEngine.Vector3 result;
		result.x = a.x * b;
		result.y = a.y * b;
		result.z = a.z * b;
		return result;
	}

	// Token: 0x060027BD RID: 10173 RVA: 0x00098440 File Offset: 0x00096640
	public static global::UnityEngine.Vector3 Sum(global::UnityEngine.Vector3 a, global::UnityEngine.Vector3 b)
	{
		global::UnityEngine.Vector3 result;
		result.x = a.x + b.x;
		result.y = a.y + b.y;
		result.z = a.z + b.z;
		return result;
	}

	// Token: 0x060027BE RID: 10174 RVA: 0x00098490 File Offset: 0x00096690
	public static global::UnityEngine.Vector3 Slerp(float t, global::UnityEngine.Vector3 a, global::UnityEngine.Vector3 b)
	{
		float num = global::TransitionFunctions.AngleRadians(a, b);
		float num2;
		if (num == 0f || (num2 = global::TransitionFunctions.Sin(num)) == 0f)
		{
			return global::TransitionFunctions.Linear(t, a, b);
		}
		float b2 = global::TransitionFunctions.Sin((1f - t) * num) / num2;
		float b3 = global::TransitionFunctions.Sin(t * num) / num2;
		return global::TransitionFunctions.Sum(global::TransitionFunctions.Mul(a, b2), global::TransitionFunctions.Mul(b, b3));
	}

	// Token: 0x060027BF RID: 10175 RVA: 0x000984FC File Offset: 0x000966FC
	public static global::UnityEngine.Vector3 Normalize(global::UnityEngine.Vector3 v)
	{
		float num = v.x * v.x + v.y * v.y + v.z * v.z;
		if (num == 0f || num == 1f)
		{
			return v;
		}
		num = global::TransitionFunctions.Sqrt(num);
		global::UnityEngine.Vector3 result;
		result.x = v.x / num;
		result.y = v.y / num;
		result.z = v.z / num;
		return result;
	}

	// Token: 0x060027C0 RID: 10176 RVA: 0x0009858C File Offset: 0x0009678C
	public static float AngleRadians(global::UnityEngine.Vector3 a, global::UnityEngine.Vector3 b)
	{
		float num = global::TransitionFunctions.DotNormal(a, b);
		if (num >= 1f)
		{
			return 0f;
		}
		if (num <= -1f)
		{
			return 3.1415927f;
		}
		if (num == 0f)
		{
			return 1.5707964f;
		}
		return global::TransitionFunctions.Acos(num);
	}

	// Token: 0x060027C1 RID: 10177 RVA: 0x000985DC File Offset: 0x000967DC
	public static float AngleDegrees(global::UnityEngine.Vector3 a, global::UnityEngine.Vector3 b)
	{
		float num = global::TransitionFunctions.DotNormal(a, b);
		if (num >= 1f)
		{
			return 0f;
		}
		if (num <= -1f)
		{
			return 180f;
		}
		if (num == 0f)
		{
			return 90f;
		}
		return global::TransitionFunctions.RadiansToDegrees(global::TransitionFunctions.Acos(num));
	}

	// Token: 0x060027C2 RID: 10178 RVA: 0x00098630 File Offset: 0x00096830
	public static global::UnityEngine.Vector3 Vect(float x, float y, float z)
	{
		global::UnityEngine.Vector3 result;
		result.x = x;
		result.y = y;
		result.z = z;
		return result;
	}

	// Token: 0x060027C3 RID: 10179 RVA: 0x00098658 File Offset: 0x00096858
	public static float Length(global::UnityEngine.Vector3 a)
	{
		return global::TransitionFunctions.Sqrt(a.x * a.x + a.y * a.y + a.z * a.z);
	}

	// Token: 0x060027C4 RID: 10180 RVA: 0x0009869C File Offset: 0x0009689C
	public static global::UnityEngine.Vector3 Cross(global::UnityEngine.Vector3 a, global::UnityEngine.Vector3 b)
	{
		global::UnityEngine.Vector3 result;
		result.x = a.y * b.z - a.z * b.y;
		result.y = a.z * b.x - a.x * b.z;
		result.z = a.x * b.y - a.y * b.x;
		return result;
	}

	// Token: 0x060027C5 RID: 10181 RVA: 0x0009871C File Offset: 0x0009691C
	public static float CrossDot(global::UnityEngine.Vector3 a, global::UnityEngine.Vector3 b, global::UnityEngine.Vector3 dotB)
	{
		return (a.y * b.z - a.z * b.y) * dotB.x + (a.z * b.x - a.x * b.z) * dotB.y + (a.x * b.y - a.y * b.x) * dotB.z;
	}

	// Token: 0x060027C6 RID: 10182 RVA: 0x000987A0 File Offset: 0x000969A0
	public static float Dot(global::UnityEngine.Vector3 a, global::UnityEngine.Vector3 b)
	{
		return a.x * b.x + a.y * b.y + a.z * b.z;
	}

	// Token: 0x060027C7 RID: 10183 RVA: 0x000987D4 File Offset: 0x000969D4
	public static float DotNormal(global::UnityEngine.Vector3 a, global::UnityEngine.Vector3 b)
	{
		return global::TransitionFunctions.Dot(global::TransitionFunctions.Normalize(a), global::TransitionFunctions.Normalize(b));
	}

	// Token: 0x060027C8 RID: 10184 RVA: 0x000987E8 File Offset: 0x000969E8
	public static global::UnityEngine.Vector3 X3(float x)
	{
		global::UnityEngine.Vector3 result;
		result.y = (result.z = 0f);
		result.x = x;
		return result;
	}

	// Token: 0x060027C9 RID: 10185 RVA: 0x00098814 File Offset: 0x00096A14
	public static global::UnityEngine.Vector3 Y3(float y)
	{
		global::UnityEngine.Vector3 result;
		result.x = (result.z = 0f);
		result.y = y;
		return result;
	}

	// Token: 0x060027CA RID: 10186 RVA: 0x00098840 File Offset: 0x00096A40
	public static global::UnityEngine.Vector3 Z3(float z)
	{
		global::UnityEngine.Vector3 result;
		result.x = (result.y = 0f);
		result.z = z;
		return result;
	}

	// Token: 0x060027CB RID: 10187 RVA: 0x0009886C File Offset: 0x00096A6C
	public static global::UnityEngine.Vector3 Scale3(float xyz)
	{
		global::UnityEngine.Vector3 result;
		result.z = xyz;
		result.y = xyz;
		result.x = xyz;
		return result;
	}

	// Token: 0x060027CC RID: 10188 RVA: 0x00098898 File Offset: 0x00096A98
	public static global::Facepunch.Precision.Vector3G Linear(double t, global::Facepunch.Precision.Vector3G a, global::Facepunch.Precision.Vector3G b)
	{
		return global::TransitionFunctions.Sum(global::TransitionFunctions.Mul(a, 1.0 - t), global::TransitionFunctions.Mul(b, t));
	}

	// Token: 0x060027CD RID: 10189 RVA: 0x000988B8 File Offset: 0x00096AB8
	public static global::Facepunch.Precision.Vector3G Round(double t, global::Facepunch.Precision.Vector3G a, global::Facepunch.Precision.Vector3G b)
	{
		return (t >= 0.5) ? b : a;
	}

	// Token: 0x060027CE RID: 10190 RVA: 0x000988D0 File Offset: 0x00096AD0
	public static global::Facepunch.Precision.Vector3G Ceil(double t, global::Facepunch.Precision.Vector3G a, global::Facepunch.Precision.Vector3G b)
	{
		return (t <= 0.0) ? a : b;
	}

	// Token: 0x060027CF RID: 10191 RVA: 0x000988E8 File Offset: 0x00096AE8
	public static global::Facepunch.Precision.Vector3G Floor(double t, global::Facepunch.Precision.Vector3G a, global::Facepunch.Precision.Vector3G b)
	{
		return (t >= 1.0) ? b : a;
	}

	// Token: 0x060027D0 RID: 10192 RVA: 0x00098900 File Offset: 0x00096B00
	public static global::Facepunch.Precision.Vector3G Spline(double t, global::Facepunch.Precision.Vector3G a, global::Facepunch.Precision.Vector3G b)
	{
		return (t > 0.0) ? ((t < 1.0) ? global::TransitionFunctions.Linear(global::TransitionFunctions.SimpleSpline(t), a, b) : b) : a;
	}

	// Token: 0x060027D1 RID: 10193 RVA: 0x0009893C File Offset: 0x00096B3C
	public static global::Facepunch.Precision.Vector3G Evaluate(this global::TransitionFunction f, double t, global::Facepunch.Precision.Vector3G a, global::Facepunch.Precision.Vector3G b)
	{
		switch (f)
		{
		case global::TransitionFunction.Linear:
			return global::TransitionFunctions.Linear(t, a, b);
		case global::TransitionFunction.Round:
			return global::TransitionFunctions.Round(t, a, b);
		case global::TransitionFunction.Floor:
			return global::TransitionFunctions.Floor(t, a, b);
		case global::TransitionFunction.Ceil:
			return global::TransitionFunctions.Ceil(t, a, b);
		case global::TransitionFunction.Spline:
			return global::TransitionFunctions.Spline(t, a, b);
		default:
			throw new global::System.ArgumentOutOfRangeException("v", "Attempted use of unrecognized TransitionFunction enum value");
		}
	}

	// Token: 0x060027D2 RID: 10194 RVA: 0x000989A8 File Offset: 0x00096BA8
	public static global::Facepunch.Precision.Vector3G Evaluate(this global::TransitionFunction<global::Facepunch.Precision.Vector3G> v, double t)
	{
		return v.f.Evaluate(t, v.a, v.b);
	}

	// Token: 0x060027D3 RID: 10195 RVA: 0x000989C8 File Offset: 0x00096BC8
	public static global::Facepunch.Precision.Vector3G Mul(global::Facepunch.Precision.Vector3G a, double b)
	{
		global::Facepunch.Precision.Vector3G result;
		result.x = a.x * b;
		result.y = a.y * b;
		result.z = a.z * b;
		return result;
	}

	// Token: 0x060027D4 RID: 10196 RVA: 0x00098A08 File Offset: 0x00096C08
	public static global::Facepunch.Precision.Vector3G Sum(global::Facepunch.Precision.Vector3G a, global::Facepunch.Precision.Vector3G b)
	{
		global::Facepunch.Precision.Vector3G result;
		result.x = a.x + b.x;
		result.y = a.y + b.y;
		result.z = a.z + b.z;
		return result;
	}

	// Token: 0x060027D5 RID: 10197 RVA: 0x00098A58 File Offset: 0x00096C58
	public static global::Facepunch.Precision.Vector3G Slerp(double t, global::Facepunch.Precision.Vector3G a, global::Facepunch.Precision.Vector3G b)
	{
		double num = global::TransitionFunctions.AngleRadians(a, b);
		double num2;
		if (num == 0.0 || (num2 = global::TransitionFunctions.Sin(num)) == 0.0)
		{
			return global::TransitionFunctions.Linear(t, a, b);
		}
		double b2 = global::TransitionFunctions.Sin((1.0 - t) * num) / num2;
		double b3 = global::TransitionFunctions.Sin(t * num) / num2;
		return global::TransitionFunctions.Sum(global::TransitionFunctions.Mul(a, b2), global::TransitionFunctions.Mul(b, b3));
	}

	// Token: 0x060027D6 RID: 10198 RVA: 0x00098AD0 File Offset: 0x00096CD0
	public static global::Facepunch.Precision.Vector3G Normalize(global::Facepunch.Precision.Vector3G v)
	{
		double num = v.x * v.x + v.y * v.y + v.z * v.z;
		if (num == 0.0 || num == 1.0)
		{
			return v;
		}
		num = global::TransitionFunctions.Sqrt(num);
		global::Facepunch.Precision.Vector3G result;
		result.x = v.x / num;
		result.y = v.y / num;
		result.z = v.z / num;
		return result;
	}

	// Token: 0x060027D7 RID: 10199 RVA: 0x00098B68 File Offset: 0x00096D68
	public static double AngleRadians(global::Facepunch.Precision.Vector3G a, global::Facepunch.Precision.Vector3G b)
	{
		double num = global::TransitionFunctions.DotNormal(a, b);
		if (num >= 1.0)
		{
			return 0.0;
		}
		if (num <= -1.0)
		{
			return 3.141592653589793;
		}
		if (num == 0.0)
		{
			return 1.5707963267948966;
		}
		return global::TransitionFunctions.Acos(num);
	}

	// Token: 0x060027D8 RID: 10200 RVA: 0x00098BD0 File Offset: 0x00096DD0
	public static double AngleDegrees(global::Facepunch.Precision.Vector3G a, global::Facepunch.Precision.Vector3G b)
	{
		double num = global::TransitionFunctions.DotNormal(a, b);
		if (num >= 1.0)
		{
			return 0.0;
		}
		if (num <= -1.0)
		{
			return 180.0;
		}
		if (num == 0.0)
		{
			return 90.0;
		}
		return global::TransitionFunctions.RadiansToDegrees(global::TransitionFunctions.Acos(num));
	}

	// Token: 0x060027D9 RID: 10201 RVA: 0x00098C3C File Offset: 0x00096E3C
	public static global::Facepunch.Precision.Vector3G Vect(double x, double y, double z)
	{
		global::Facepunch.Precision.Vector3G result;
		result.x = x;
		result.y = y;
		result.z = z;
		return result;
	}

	// Token: 0x060027DA RID: 10202 RVA: 0x00098C64 File Offset: 0x00096E64
	public static double Length(global::Facepunch.Precision.Vector3G a)
	{
		return global::TransitionFunctions.Sqrt(a.x * a.x + a.y * a.y + a.z * a.z);
	}

	// Token: 0x060027DB RID: 10203 RVA: 0x00098CA8 File Offset: 0x00096EA8
	public static global::Facepunch.Precision.Vector3G Cross(global::Facepunch.Precision.Vector3G a, global::Facepunch.Precision.Vector3G b)
	{
		global::Facepunch.Precision.Vector3G result;
		result.x = a.y * b.z - a.z * b.y;
		result.y = a.z * b.x - a.x * b.z;
		result.z = a.x * b.y - a.y * b.x;
		return result;
	}

	// Token: 0x060027DC RID: 10204 RVA: 0x00098D28 File Offset: 0x00096F28
	public static double CrossDot(global::Facepunch.Precision.Vector3G a, global::Facepunch.Precision.Vector3G b, global::Facepunch.Precision.Vector3G dotB)
	{
		return (a.y * b.z - a.z * b.y) * dotB.x + (a.z * b.x - a.x * b.z) * dotB.y + (a.x * b.y - a.y * b.x) * dotB.z;
	}

	// Token: 0x060027DD RID: 10205 RVA: 0x00098DAC File Offset: 0x00096FAC
	public static double Dot(global::Facepunch.Precision.Vector3G a, global::Facepunch.Precision.Vector3G b)
	{
		return a.x * b.x + a.y * b.y + a.z * b.z;
	}

	// Token: 0x060027DE RID: 10206 RVA: 0x00098DE0 File Offset: 0x00096FE0
	public static double DotNormal(global::Facepunch.Precision.Vector3G a, global::Facepunch.Precision.Vector3G b)
	{
		return global::TransitionFunctions.Dot(global::TransitionFunctions.Normalize(a), global::TransitionFunctions.Normalize(b));
	}

	// Token: 0x060027DF RID: 10207 RVA: 0x00098DF4 File Offset: 0x00096FF4
	public static global::Facepunch.Precision.Vector3G X3(double x)
	{
		global::Facepunch.Precision.Vector3G result;
		result.y = (result.z = 0.0);
		result.x = x;
		return result;
	}

	// Token: 0x060027E0 RID: 10208 RVA: 0x00098E24 File Offset: 0x00097024
	public static global::Facepunch.Precision.Vector3G Y3(double y)
	{
		global::Facepunch.Precision.Vector3G result;
		result.x = (result.z = 0.0);
		result.y = y;
		return result;
	}

	// Token: 0x060027E1 RID: 10209 RVA: 0x00098E54 File Offset: 0x00097054
	public static global::Facepunch.Precision.Vector3G Z3(double z)
	{
		global::Facepunch.Precision.Vector3G result;
		result.x = (result.y = 0.0);
		result.z = z;
		return result;
	}

	// Token: 0x060027E2 RID: 10210 RVA: 0x00098E84 File Offset: 0x00097084
	public static global::Facepunch.Precision.Vector3G Scale3(double xyz)
	{
		global::Facepunch.Precision.Vector3G result;
		result.z = xyz;
		result.y = xyz;
		result.x = xyz;
		return result;
	}

	// Token: 0x060027E3 RID: 10211 RVA: 0x00098EB0 File Offset: 0x000970B0
	public static global::UnityEngine.Vector4 Linear(float t, global::UnityEngine.Vector4 a, global::UnityEngine.Vector4 b)
	{
		return global::TransitionFunctions.Sum(global::TransitionFunctions.Mul(a, 1f - t), global::TransitionFunctions.Mul(b, t));
	}

	// Token: 0x060027E4 RID: 10212 RVA: 0x00098ECC File Offset: 0x000970CC
	public static global::UnityEngine.Vector4 Round(float t, global::UnityEngine.Vector4 a, global::UnityEngine.Vector4 b)
	{
		return (t >= 0.5f) ? b : a;
	}

	// Token: 0x060027E5 RID: 10213 RVA: 0x00098EE0 File Offset: 0x000970E0
	public static global::UnityEngine.Vector4 Ceil(float t, global::UnityEngine.Vector4 a, global::UnityEngine.Vector4 b)
	{
		return (t <= 0f) ? a : b;
	}

	// Token: 0x060027E6 RID: 10214 RVA: 0x00098EF4 File Offset: 0x000970F4
	public static global::UnityEngine.Vector4 Floor(float t, global::UnityEngine.Vector4 a, global::UnityEngine.Vector4 b)
	{
		return (t >= 1f) ? b : a;
	}

	// Token: 0x060027E7 RID: 10215 RVA: 0x00098F08 File Offset: 0x00097108
	public static global::UnityEngine.Vector4 Spline(float t, global::UnityEngine.Vector4 a, global::UnityEngine.Vector4 b)
	{
		return (t > 0f) ? ((t < 1f) ? global::TransitionFunctions.Linear(global::TransitionFunctions.SimpleSpline(t), a, b) : b) : a;
	}

	// Token: 0x060027E8 RID: 10216 RVA: 0x00098F3C File Offset: 0x0009713C
	public static global::UnityEngine.Vector4 Evaluate(this global::TransitionFunction f, float t, global::UnityEngine.Vector4 a, global::UnityEngine.Vector4 b)
	{
		switch (f)
		{
		case global::TransitionFunction.Linear:
			return global::TransitionFunctions.Linear(t, a, b);
		case global::TransitionFunction.Round:
			return global::TransitionFunctions.Round(t, a, b);
		case global::TransitionFunction.Floor:
			return global::TransitionFunctions.Floor(t, a, b);
		case global::TransitionFunction.Ceil:
			return global::TransitionFunctions.Ceil(t, a, b);
		case global::TransitionFunction.Spline:
			return global::TransitionFunctions.Spline(t, a, b);
		default:
			throw new global::System.ArgumentOutOfRangeException("v", "Attempted use of unrecognized TransitionFunction enum value");
		}
	}

	// Token: 0x060027E9 RID: 10217 RVA: 0x00098FA8 File Offset: 0x000971A8
	public static global::UnityEngine.Vector4 Evaluate(this global::TransitionFunction<global::UnityEngine.Vector4> v, float t)
	{
		return v.f.Evaluate(t, v.a, v.b);
	}

	// Token: 0x060027EA RID: 10218 RVA: 0x00098FC8 File Offset: 0x000971C8
	public static global::UnityEngine.Vector4 Mul(global::UnityEngine.Vector4 a, float b)
	{
		global::UnityEngine.Vector4 result;
		result.x = a.x * b;
		result.y = a.y * b;
		result.z = a.z * b;
		result.w = a.w * b;
		return result;
	}

	// Token: 0x060027EB RID: 10219 RVA: 0x00099018 File Offset: 0x00097218
	public static global::UnityEngine.Vector4 Sum(global::UnityEngine.Vector4 a, global::UnityEngine.Vector4 b)
	{
		global::UnityEngine.Vector4 result;
		result.x = a.x + b.x;
		result.y = a.y + b.y;
		result.z = a.z + b.z;
		result.w = a.w * b.w;
		return result;
	}

	// Token: 0x060027EC RID: 10220 RVA: 0x00099080 File Offset: 0x00097280
	public static double Min(double a, double b)
	{
		return (b >= a) ? a : b;
	}

	// Token: 0x060027ED RID: 10221 RVA: 0x00099090 File Offset: 0x00097290
	public static double Max(double a, double b)
	{
		return (b <= a) ? a : b;
	}

	// Token: 0x060027EE RID: 10222 RVA: 0x000990A0 File Offset: 0x000972A0
	public static double Distance(double a, double b)
	{
		return (b <= a) ? (a - b) : (b - a);
	}

	// Token: 0x060027EF RID: 10223 RVA: 0x000990B4 File Offset: 0x000972B4
	public static double Evaluate(this global::TransitionFunction f, double t)
	{
		return f.Evaluate(t, 0.0, 1.0);
	}

	// Token: 0x060027F0 RID: 10224 RVA: 0x000990D0 File Offset: 0x000972D0
	public static double Mul(double a, double b)
	{
		return a * b;
	}

	// Token: 0x060027F1 RID: 10225 RVA: 0x000990D8 File Offset: 0x000972D8
	public static double Sum(double a, double b)
	{
		return a + b;
	}

	// Token: 0x060027F2 RID: 10226 RVA: 0x000990E0 File Offset: 0x000972E0
	public static double Linear(double t, double a, double b)
	{
		return global::TransitionFunctions.Sum(global::TransitionFunctions.Mul(a, 1.0 - t), global::TransitionFunctions.Mul(b, t));
	}

	// Token: 0x060027F3 RID: 10227 RVA: 0x00099100 File Offset: 0x00097300
	public static double Round(double t, double a, double b)
	{
		return (t >= 0.5) ? b : a;
	}

	// Token: 0x060027F4 RID: 10228 RVA: 0x00099118 File Offset: 0x00097318
	public static double Ceil(double t, double a, double b)
	{
		return (t <= 0.0) ? a : b;
	}

	// Token: 0x060027F5 RID: 10229 RVA: 0x00099130 File Offset: 0x00097330
	public static double Floor(double t, double a, double b)
	{
		return (t >= 1.0) ? b : a;
	}

	// Token: 0x060027F6 RID: 10230 RVA: 0x00099148 File Offset: 0x00097348
	public static double Spline(double t, double a, double b)
	{
		return (t > 0.0) ? ((t < 1.0) ? global::TransitionFunctions.Linear(global::TransitionFunctions.SimpleSpline(t), a, b) : b) : a;
	}

	// Token: 0x060027F7 RID: 10231 RVA: 0x00099184 File Offset: 0x00097384
	public static double Evaluate(this global::TransitionFunction f, double t, double a, double b)
	{
		switch (f)
		{
		case global::TransitionFunction.Linear:
			return global::TransitionFunctions.Linear(t, a, b);
		case global::TransitionFunction.Round:
			return global::TransitionFunctions.Round(t, a, b);
		case global::TransitionFunction.Floor:
			return global::TransitionFunctions.Floor(t, a, b);
		case global::TransitionFunction.Ceil:
			return global::TransitionFunctions.Ceil(t, a, b);
		case global::TransitionFunction.Spline:
			return global::TransitionFunctions.Spline(t, a, b);
		default:
			throw new global::System.ArgumentOutOfRangeException("v", "Attempted use of unrecognized TransitionFunction enum value");
		}
	}

	// Token: 0x060027F8 RID: 10232 RVA: 0x000991F0 File Offset: 0x000973F0
	public static double Evaluate(this global::TransitionFunction<double> v, double t)
	{
		return v.f.Evaluate(t, v.a, v.b);
	}

	// Token: 0x060027F9 RID: 10233 RVA: 0x00099210 File Offset: 0x00097410
	public static double Sin(double v)
	{
		return global::System.Math.Sin(v);
	}

	// Token: 0x060027FA RID: 10234 RVA: 0x00099218 File Offset: 0x00097418
	public static double Cos(double v)
	{
		return global::System.Math.Cos(v);
	}

	// Token: 0x060027FB RID: 10235 RVA: 0x00099220 File Offset: 0x00097420
	public static double Atan2(double y, double x)
	{
		return global::System.Math.Atan2(y, x);
	}

	// Token: 0x060027FC RID: 10236 RVA: 0x0009922C File Offset: 0x0009742C
	public static double Acos(double v)
	{
		return global::System.Math.Acos(v);
	}

	// Token: 0x060027FD RID: 10237 RVA: 0x00099234 File Offset: 0x00097434
	public static double Sqrt(double v)
	{
		return global::System.Math.Sqrt(v);
	}

	// Token: 0x060027FE RID: 10238 RVA: 0x0009923C File Offset: 0x0009743C
	public static double DegreesToRadians(double rads)
	{
		return 0.017453292519943295 * rads;
	}

	// Token: 0x060027FF RID: 10239 RVA: 0x0009924C File Offset: 0x0009744C
	public static double RadiansToDegrees(double degs)
	{
		return 57.29577951308232 * degs;
	}

	// Token: 0x06002800 RID: 10240 RVA: 0x0009925C File Offset: 0x0009745C
	private static double SimpleSpline(double v01)
	{
		return 3.0 * (v01 * v01) - 2.0 * (v01 * v01) * v01;
	}

	// Token: 0x06002801 RID: 10241 RVA: 0x0009927C File Offset: 0x0009747C
	public static double Linear(float t, double a, double b)
	{
		return global::TransitionFunctions.Sum(global::TransitionFunctions.Mul(a, (double)(1f - t)), global::TransitionFunctions.Mul(b, (double)t));
	}

	// Token: 0x06002802 RID: 10242 RVA: 0x0009929C File Offset: 0x0009749C
	public static double Round(float t, double a, double b)
	{
		return (t >= 0.5f) ? b : a;
	}

	// Token: 0x06002803 RID: 10243 RVA: 0x000992B0 File Offset: 0x000974B0
	public static double Ceil(float t, double a, double b)
	{
		return (t <= 0f) ? a : b;
	}

	// Token: 0x06002804 RID: 10244 RVA: 0x000992C4 File Offset: 0x000974C4
	public static double Floor(float t, double a, double b)
	{
		return (t >= 1f) ? b : a;
	}

	// Token: 0x06002805 RID: 10245 RVA: 0x000992D8 File Offset: 0x000974D8
	public static double Spline(float t, double a, double b)
	{
		return (t > 0f) ? ((t < 1f) ? global::TransitionFunctions.Linear(global::TransitionFunctions.SimpleSpline(t), a, b) : b) : a;
	}

	// Token: 0x06002806 RID: 10246 RVA: 0x0009930C File Offset: 0x0009750C
	public static double Evaluate(this global::TransitionFunction f, float t, double a, double b)
	{
		switch (f)
		{
		case global::TransitionFunction.Linear:
			return global::TransitionFunctions.Linear(t, a, b);
		case global::TransitionFunction.Round:
			return global::TransitionFunctions.Round(t, a, b);
		case global::TransitionFunction.Floor:
			return global::TransitionFunctions.Floor(t, a, b);
		case global::TransitionFunction.Ceil:
			return global::TransitionFunctions.Ceil(t, a, b);
		case global::TransitionFunction.Spline:
			return global::TransitionFunctions.Spline(t, a, b);
		default:
			throw new global::System.ArgumentOutOfRangeException("v", "Attempted use of unrecognized TransitionFunction enum value");
		}
	}

	// Token: 0x06002807 RID: 10247 RVA: 0x00099378 File Offset: 0x00097578
	public static double Evaluate(this global::TransitionFunction<double> v, float t)
	{
		return v.f.Evaluate(t, v.a, v.b);
	}

	// Token: 0x06002808 RID: 10248 RVA: 0x00099398 File Offset: 0x00097598
	public static float Min(float a, float b)
	{
		return (b >= a) ? a : b;
	}

	// Token: 0x06002809 RID: 10249 RVA: 0x000993A8 File Offset: 0x000975A8
	public static float Max(float a, float b)
	{
		return (b <= a) ? a : b;
	}

	// Token: 0x0600280A RID: 10250 RVA: 0x000993B8 File Offset: 0x000975B8
	public static float Distance(float a, float b)
	{
		return (b <= a) ? (a - b) : (b - a);
	}

	// Token: 0x0600280B RID: 10251 RVA: 0x000993CC File Offset: 0x000975CC
	public static float Evaluate(this global::TransitionFunction f, float t)
	{
		return f.Evaluate(t, 0f, 1f);
	}

	// Token: 0x0600280C RID: 10252 RVA: 0x000993E0 File Offset: 0x000975E0
	public static float Mul(float a, float b)
	{
		return a * b;
	}

	// Token: 0x0600280D RID: 10253 RVA: 0x000993E8 File Offset: 0x000975E8
	public static float Sum(float a, float b)
	{
		return a + b;
	}

	// Token: 0x0600280E RID: 10254 RVA: 0x000993F0 File Offset: 0x000975F0
	public static float Linear(float t, float a, float b)
	{
		return global::TransitionFunctions.Sum(global::TransitionFunctions.Mul(a, 1f - t), global::TransitionFunctions.Mul(b, t));
	}

	// Token: 0x0600280F RID: 10255 RVA: 0x0009940C File Offset: 0x0009760C
	public static float Round(float t, float a, float b)
	{
		return (t >= 0.5f) ? b : a;
	}

	// Token: 0x06002810 RID: 10256 RVA: 0x00099420 File Offset: 0x00097620
	public static float Ceil(float t, float a, float b)
	{
		return (t <= 0f) ? a : b;
	}

	// Token: 0x06002811 RID: 10257 RVA: 0x00099434 File Offset: 0x00097634
	public static float Floor(float t, float a, float b)
	{
		return (t >= 1f) ? b : a;
	}

	// Token: 0x06002812 RID: 10258 RVA: 0x00099448 File Offset: 0x00097648
	public static float Spline(float t, float a, float b)
	{
		return (t > 0f) ? ((t < 1f) ? global::TransitionFunctions.Linear(global::TransitionFunctions.SimpleSpline(t), a, b) : b) : a;
	}

	// Token: 0x06002813 RID: 10259 RVA: 0x0009947C File Offset: 0x0009767C
	public static float Evaluate(this global::TransitionFunction f, float t, float a, float b)
	{
		switch (f)
		{
		case global::TransitionFunction.Linear:
			return global::TransitionFunctions.Linear(t, a, b);
		case global::TransitionFunction.Round:
			return global::TransitionFunctions.Round(t, a, b);
		case global::TransitionFunction.Floor:
			return global::TransitionFunctions.Floor(t, a, b);
		case global::TransitionFunction.Ceil:
			return global::TransitionFunctions.Ceil(t, a, b);
		case global::TransitionFunction.Spline:
			return global::TransitionFunctions.Spline(t, a, b);
		default:
			throw new global::System.ArgumentOutOfRangeException("v", "Attempted use of unrecognized TransitionFunction enum value");
		}
	}

	// Token: 0x06002814 RID: 10260 RVA: 0x000994E8 File Offset: 0x000976E8
	public static float Evaluate(this global::TransitionFunction<float> v, float t)
	{
		return v.f.Evaluate(t, v.a, v.b);
	}

	// Token: 0x06002815 RID: 10261 RVA: 0x00099508 File Offset: 0x00097708
	public static float Sin(float v)
	{
		return global::UnityEngine.Mathf.Sin(v);
	}

	// Token: 0x06002816 RID: 10262 RVA: 0x00099510 File Offset: 0x00097710
	public static float Cos(float v)
	{
		return global::UnityEngine.Mathf.Cos(v);
	}

	// Token: 0x06002817 RID: 10263 RVA: 0x00099518 File Offset: 0x00097718
	public static float Atan2(float y, float x)
	{
		return global::UnityEngine.Mathf.Atan2(y, x);
	}

	// Token: 0x06002818 RID: 10264 RVA: 0x00099524 File Offset: 0x00097724
	public static float Acos(float v)
	{
		return global::UnityEngine.Mathf.Acos(v);
	}

	// Token: 0x06002819 RID: 10265 RVA: 0x0009952C File Offset: 0x0009772C
	public static float Sqrt(float v)
	{
		return global::UnityEngine.Mathf.Sqrt(v);
	}

	// Token: 0x0600281A RID: 10266 RVA: 0x00099534 File Offset: 0x00097734
	public static float DegreesToRadians(float rads)
	{
		return 0.017453292f * rads;
	}

	// Token: 0x0600281B RID: 10267 RVA: 0x00099540 File Offset: 0x00097740
	public static float RadiansToDegrees(float degs)
	{
		return 57.29578f * degs;
	}

	// Token: 0x0600281C RID: 10268 RVA: 0x0009954C File Offset: 0x0009774C
	private static float SimpleSpline(float v01)
	{
		return 3f * (v01 * v01) - 2f * (v01 * v01) * v01;
	}
}
