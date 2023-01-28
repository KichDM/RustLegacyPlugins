using System;
using System.Collections.Specialized;
using System.Runtime.InteropServices;
using UnityEngine;

// Token: 0x0200049B RID: 1179
public static class Vis
{
	// Token: 0x060028E7 RID: 10471 RVA: 0x0009B6AC File Offset: 0x000998AC
	public static global::Vis.Op Negate(global::Vis.Op op)
	{
		return global::Vis.Op.Any - (op - global::Vis.Op.Any);
	}

	// Token: 0x060028E8 RID: 10472 RVA: 0x0009B6B4 File Offset: 0x000998B4
	public static global::Vis.Op<TFlags> Negate<TFlags>(global::Vis.Op<TFlags> op) where TFlags : struct, global::System.IConvertible, global::System.IFormattable, global::System.IComparable
	{
		op.op = global::Vis.Negate(op.op);
		return op;
	}

	// Token: 0x060028E9 RID: 10473 RVA: 0x0009B6CC File Offset: 0x000998CC
	internal static bool Evaluate(global::Vis.Op op, int f, int m)
	{
		switch (op)
		{
		case global::Vis.Op.Always:
			return true;
		case global::Vis.Op.Equals:
			return m == f;
		case global::Vis.Op.All:
			return (m & f) == f;
		case global::Vis.Op.Any:
			return (m & f) != 0;
		case global::Vis.Op.None:
			return (m & f) == 0;
		case global::Vis.Op.NotEquals:
			return m != f;
		default:
			return false;
		}
	}

	// Token: 0x060028EA RID: 10474 RVA: 0x0009B72C File Offset: 0x0009992C
	private static int SetTrue(global::Vis.Op op, int f, ref global::System.Collections.Specialized.BitVector32 bits, global::System.Collections.Specialized.BitVector32.Section sect)
	{
		int num = bits[sect];
		int result;
		if (num != (result = global::Vis.SetTrue(op, f, num)))
		{
			bits[sect] = num;
		}
		return result;
	}

	// Token: 0x060028EB RID: 10475 RVA: 0x0009B75C File Offset: 0x0009995C
	private static int SetTrue(global::Vis.Op op, int f, int m)
	{
		switch (op)
		{
		default:
			return m;
		case global::Vis.Op.Equals:
			return f;
		case global::Vis.Op.All:
			return m | f;
		case global::Vis.Op.Any:
			if ((m & f) == 0)
			{
				return m | f;
			}
			return m;
		case global::Vis.Op.None:
			return m & ~f;
		case global::Vis.Op.NotEquals:
			return ~f;
		}
	}

	// Token: 0x060028EC RID: 10476 RVA: 0x0009B7B0 File Offset: 0x000999B0
	public static bool IsZeroWay(this global::Vis.Comparison comparison)
	{
		return (comparison & global::Vis.Comparison.Contact) == global::Vis.Comparison.Oblivious;
	}

	// Token: 0x060028ED RID: 10477 RVA: 0x0009B7BC File Offset: 0x000999BC
	public static bool IsOneWay(this global::Vis.Comparison comparison)
	{
		return (comparison & global::Vis.Comparison.IsSelf) != global::Vis.Comparison.IsSelf;
	}

	// Token: 0x060028EE RID: 10478 RVA: 0x0009B7CC File Offset: 0x000999CC
	public static bool DoesSeeTarget(this global::Vis.Comparison comparison)
	{
		return (comparison & (global::Vis.Comparison)4) == (global::Vis.Comparison)4;
	}

	// Token: 0x060028EF RID: 10479 RVA: 0x0009B7D4 File Offset: 0x000999D4
	public static bool IsSeenByTarget(this global::Vis.Comparison comparison)
	{
		return (comparison & (global::Vis.Comparison)8) == (global::Vis.Comparison)8;
	}

	// Token: 0x060028F0 RID: 10480 RVA: 0x0009B7DC File Offset: 0x000999DC
	public static bool IsTwoWay(this global::Vis.Comparison comparison)
	{
		return (comparison & global::Vis.Comparison.Contact) != global::Vis.Comparison.IsSelf;
	}

	// Token: 0x060028F1 RID: 10481 RVA: 0x0009B7EC File Offset: 0x000999EC
	public static int CountSeen(this global::Vis.Comparison comparison)
	{
		int result = 0;
		int num = (int)comparison;
		if ((num & 1) == 1)
		{
			if ((num & 4) == 4)
			{
				num++;
			}
			if ((num & 8) == 8)
			{
				num++;
			}
		}
		return result;
	}

	// Token: 0x060028F2 RID: 10482 RVA: 0x0009B824 File Offset: 0x00099A24
	public static int GetStealth(this global::Vis.Comparison comparison)
	{
		int num = (int)(comparison & global::Vis.Comparison.IsSelf);
		if (num == 4)
		{
			return 1;
		}
		if (num != 8)
		{
			return 0;
		}
		return -1;
	}

	// Token: 0x060028F3 RID: 10483 RVA: 0x0009B850 File Offset: 0x00099A50
	public static global::VisNode.Search.Radial.Enumerator GetNodesInRadius(global::UnityEngine.Vector3 point, float radius)
	{
		return new global::VisNode.Search.Radial.Enumerator(new global::VisNode.Search.PointRadiusData(point, radius));
	}

	// Token: 0x060028F4 RID: 10484 RVA: 0x0009B860 File Offset: 0x00099A60
	public static void RadialMessage(global::UnityEngine.Vector3 point, float radius, string message, object arg)
	{
		global::VisNode.Search.Radial.Enumerator nodesInRadius = global::Vis.GetNodesInRadius(point, radius);
		while (nodesInRadius.MoveNext())
		{
			nodesInRadius.Current.SendMessage(message, arg, 1);
		}
	}

	// Token: 0x060028F5 RID: 10485 RVA: 0x0009B898 File Offset: 0x00099A98
	public static void RadialMessage(global::UnityEngine.Vector3 point, float radius, string message)
	{
		global::VisNode.Search.Radial.Enumerator nodesInRadius = global::Vis.GetNodesInRadius(point, radius);
		while (nodesInRadius.MoveNext())
		{
			nodesInRadius.Current.SendMessage(message, 1);
		}
	}

	// Token: 0x060028F6 RID: 10486 RVA: 0x0009B8CC File Offset: 0x00099ACC
	public static global::VisNode.Search.Point.Visual.Enumerator GetNodesWhoCanSee(global::UnityEngine.Vector3 point)
	{
		return new global::VisNode.Search.Point.Visual.Enumerator(new global::VisNode.Search.PointVisibilityData(point));
	}

	// Token: 0x060028F7 RID: 10487 RVA: 0x0009B8DC File Offset: 0x00099ADC
	public static void VisibleMessage(global::UnityEngine.Vector3 point, string message, object arg)
	{
		global::VisNode.Search.Point.Visual.Enumerator nodesWhoCanSee = global::Vis.GetNodesWhoCanSee(point);
		while (nodesWhoCanSee.MoveNext())
		{
			nodesWhoCanSee.Current.SendMessage(message, arg, 1);
		}
	}

	// Token: 0x060028F8 RID: 10488 RVA: 0x0009B910 File Offset: 0x00099B10
	public static void VisibleMessage(global::UnityEngine.Vector3 point, string message)
	{
		global::VisNode.Search.Point.Visual.Enumerator nodesWhoCanSee = global::Vis.GetNodesWhoCanSee(point);
		while (nodesWhoCanSee.MoveNext())
		{
			nodesWhoCanSee.Current.SendMessage(message, 1);
		}
	}

	// Token: 0x04001439 RID: 5177
	public const global::Vis.Trait kTraitBegin = global::Vis.Trait.Alive;

	// Token: 0x0400143A RID: 5178
	public const global::Vis.Trait kTraitEnd = (global::Vis.Trait)0x20;

	// Token: 0x0400143B RID: 5179
	public const global::Vis.Trait kLifeFirst = global::Vis.Trait.Alive;

	// Token: 0x0400143C RID: 5180
	public const global::Vis.Trait kLifeLast = global::Vis.Trait.Dead;

	// Token: 0x0400143D RID: 5181
	public const global::Vis.Trait kStatusFirst = global::Vis.Trait.Casual;

	// Token: 0x0400143E RID: 5182
	public const global::Vis.Trait kStatusLast = global::Vis.Trait.Attacking;

	// Token: 0x0400143F RID: 5183
	public const global::Vis.Trait kRoleFirst = global::Vis.Trait.Citizen;

	// Token: 0x04001440 RID: 5184
	public const global::Vis.Trait kRoleLast = global::Vis.Trait.Animal;

	// Token: 0x04001441 RID: 5185
	public const global::Vis.Trait kLifeBegin = global::Vis.Trait.Alive;

	// Token: 0x04001442 RID: 5186
	public const global::Vis.Trait kLifeEnd = (global::Vis.Trait)3;

	// Token: 0x04001443 RID: 5187
	public const global::Vis.Trait kStatusBegin = global::Vis.Trait.Casual;

	// Token: 0x04001444 RID: 5188
	public const global::Vis.Trait kStatusEnd = (global::Vis.Trait)0xF;

	// Token: 0x04001445 RID: 5189
	public const global::Vis.Trait kRoleBegin = global::Vis.Trait.Citizen;

	// Token: 0x04001446 RID: 5190
	public const global::Vis.Trait kRoleEnd = (global::Vis.Trait)0x20;

	// Token: 0x04001447 RID: 5191
	public const int kLifeCount = 3;

	// Token: 0x04001448 RID: 5192
	public const int kStatusCount = 7;

	// Token: 0x04001449 RID: 5193
	public const int kRoleCount = 8;

	// Token: 0x0400144A RID: 5194
	private const uint one = 1U;

	// Token: 0x0400144B RID: 5195
	public const int kLifeMask = 7;

	// Token: 0x0400144C RID: 5196
	public const int kStatusMask = 0x7F00;

	// Token: 0x0400144D RID: 5197
	public const int kRoleMask = -0x1000000;

	// Token: 0x0400144E RID: 5198
	private const int OpZero = 3;

	// Token: 0x0400144F RID: 5199
	private const int mask24b = 0xFFFFFF;

	// Token: 0x04001450 RID: 5200
	private const int mask31b = 0x7FFFFFFF;

	// Token: 0x04001451 RID: 5201
	private const int mask24o7b = 0x1000000;

	// Token: 0x04001452 RID: 5202
	private const int mask31o1b = -0x80000000;

	// Token: 0x04001453 RID: 5203
	private const byte mask7b = 0x7F;

	// Token: 0x04001454 RID: 5204
	private const byte mask7o1b = 0x80;

	// Token: 0x04001455 RID: 5205
	public const global::Vis.Life kLifeNone = (global::Vis.Life)0;

	// Token: 0x04001456 RID: 5206
	public const global::Vis.Life kLifeAll = global::Vis.Life.Alive | global::Vis.Life.Unconcious | global::Vis.Life.Dead;

	// Token: 0x04001457 RID: 5207
	public const global::Vis.Status kStatusNone = (global::Vis.Status)0;

	// Token: 0x04001458 RID: 5208
	public const global::Vis.Status kStatusAll = global::Vis.Status.Casual | global::Vis.Status.Hurt | global::Vis.Status.Curious | global::Vis.Status.Alert | global::Vis.Status.Search | global::Vis.Status.Armed | global::Vis.Status.Attacking;

	// Token: 0x04001459 RID: 5209
	public const global::Vis.Role kRoleNone = (global::Vis.Role)0;

	// Token: 0x0400145A RID: 5210
	public const global::Vis.Role kRoleAll = (global::Vis.Role)(-1);

	// Token: 0x0400145B RID: 5211
	public const int kFlagRelative = 1;

	// Token: 0x0400145C RID: 5212
	public const int kFlagTarget = 4;

	// Token: 0x0400145D RID: 5213
	public const int kFlagSelf = 8;

	// Token: 0x0400145E RID: 5214
	public const int kComparisonStealthy = 5;

	// Token: 0x0400145F RID: 5215
	public const int kComparisonPrey = 9;

	// Token: 0x04001460 RID: 5216
	public const int kComparisonIsSelf = 0xC;

	// Token: 0x04001461 RID: 5217
	public const int kComparisonOblivious = 1;

	// Token: 0x04001462 RID: 5218
	public const int kComparisonContact = 0xD;

	// Token: 0x0200049C RID: 1180
	public enum Trait
	{
		// Token: 0x04001464 RID: 5220
		Alive,
		// Token: 0x04001465 RID: 5221
		Unconcious,
		// Token: 0x04001466 RID: 5222
		Dead,
		// Token: 0x04001467 RID: 5223
		Casual = 8,
		// Token: 0x04001468 RID: 5224
		Hurt,
		// Token: 0x04001469 RID: 5225
		Curious,
		// Token: 0x0400146A RID: 5226
		Alert,
		// Token: 0x0400146B RID: 5227
		Search,
		// Token: 0x0400146C RID: 5228
		Armed,
		// Token: 0x0400146D RID: 5229
		Attacking,
		// Token: 0x0400146E RID: 5230
		Citizen = 0x18,
		// Token: 0x0400146F RID: 5231
		Criminal,
		// Token: 0x04001470 RID: 5232
		Authority,
		// Token: 0x04001471 RID: 5233
		Target,
		// Token: 0x04001472 RID: 5234
		Entourage,
		// Token: 0x04001473 RID: 5235
		Player,
		// Token: 0x04001474 RID: 5236
		Vehicle,
		// Token: 0x04001475 RID: 5237
		Animal
	}

	// Token: 0x0200049D RID: 1181
	public enum Op
	{
		// Token: 0x04001477 RID: 5239
		Always,
		// Token: 0x04001478 RID: 5240
		Equals,
		// Token: 0x04001479 RID: 5241
		All,
		// Token: 0x0400147A RID: 5242
		Any,
		// Token: 0x0400147B RID: 5243
		None,
		// Token: 0x0400147C RID: 5244
		NotEquals,
		// Token: 0x0400147D RID: 5245
		Never
	}

	// Token: 0x0200049E RID: 1182
	private static class EnumUtil<TEnum> where TEnum : struct, global::System.IConvertible, global::System.IFormattable, global::System.IComparable
	{
		// Token: 0x060028F9 RID: 10489 RVA: 0x0009B944 File Offset: 0x00099B44
		public static int ToInt(TEnum val)
		{
			return global::System.Convert.ToInt32(val);
		}
	}

	// Token: 0x0200049F RID: 1183
	[global::System.Runtime.InteropServices.StructLayout(global::System.Runtime.InteropServices.LayoutKind.Explicit, Size = 4)]
	private struct OpBase
	{
		// Token: 0x060028FA RID: 10490 RVA: 0x0009B954 File Offset: 0x00099B54
		public OpBase(byte _op, int _val)
		{
			this._val = _val;
			this._op = _op;
		}

		// Token: 0x0400147E RID: 5246
		[global::System.Runtime.InteropServices.FieldOffset(0)]
		public int _val;

		// Token: 0x0400147F RID: 5247
		[global::System.Runtime.InteropServices.FieldOffset(3)]
		public byte _op;
	}

	// Token: 0x020004A0 RID: 1184
	public struct Op<TFlags> : global::System.IEquatable<global::Vis.Op>, global::System.IEquatable<global::Vis.Op<TFlags>> where TFlags : struct, global::System.IConvertible, global::System.IFormattable, global::System.IComparable
	{
		// Token: 0x060028FB RID: 10491 RVA: 0x0009B964 File Offset: 0x00099B64
		internal Op(byte op, int val)
		{
			this._ = new global::Vis.OpBase(op, val);
		}

		// Token: 0x060028FC RID: 10492 RVA: 0x0009B974 File Offset: 0x00099B74
		public Op(global::Vis.Op op, TFlags flags)
		{
			this = new global::Vis.Op<TFlags>((byte)op, global::System.Convert.ToInt32(flags));
		}

		// Token: 0x060028FD RID: 10493 RVA: 0x0009B98C File Offset: 0x00099B8C
		internal Op(int op, int flags)
		{
			this = new global::Vis.Op<TFlags>((byte)op, flags);
		}

		// Token: 0x060028FE RID: 10494 RVA: 0x0009B998 File Offset: 0x00099B98
		private static int ToInt(TFlags f)
		{
			return global::Vis.EnumUtil<TFlags>.ToInt(f);
		}

		// Token: 0x170008FD RID: 2301
		// (get) Token: 0x060028FF RID: 10495 RVA: 0x0009B9A0 File Offset: 0x00099BA0
		// (set) Token: 0x06002900 RID: 10496 RVA: 0x0009B9B0 File Offset: 0x00099BB0
		private int _val
		{
			get
			{
				return this._._val;
			}
			set
			{
				this._._val = value;
			}
		}

		// Token: 0x170008FE RID: 2302
		// (get) Token: 0x06002901 RID: 10497 RVA: 0x0009B9C0 File Offset: 0x00099BC0
		// (set) Token: 0x06002902 RID: 10498 RVA: 0x0009B9D0 File Offset: 0x00099BD0
		private byte _op
		{
			get
			{
				return this._._op;
			}
			set
			{
				this._._op = value;
			}
		}

		// Token: 0x170008FF RID: 2303
		// (get) Token: 0x06002903 RID: 10499 RVA: 0x0009B9E0 File Offset: 0x00099BE0
		// (set) Token: 0x06002904 RID: 10500 RVA: 0x0009BA10 File Offset: 0x00099C10
		public TFlags value
		{
			get
			{
				return (TFlags)((object)global::System.Enum.ToObject(typeof(TFlags), this._val & 0xFFFFFF));
			}
			set
			{
				this._val = ((this._val & 0x1000000) | (global::Vis.Op<TFlags>.ToInt(value) & 0xFFFFFF));
			}
		}

		// Token: 0x17000900 RID: 2304
		// (get) Token: 0x06002905 RID: 10501 RVA: 0x0009BA34 File Offset: 0x00099C34
		// (set) Token: 0x06002906 RID: 10502 RVA: 0x0009BA44 File Offset: 0x00099C44
		public int intvalue
		{
			get
			{
				return this._val & 0x1000000;
			}
			set
			{
				this._val = ((this._val & 0x1000000) | (value & 0xFFFFFF));
			}
		}

		// Token: 0x17000901 RID: 2305
		// (get) Token: 0x06002907 RID: 10503 RVA: 0x0009BA60 File Offset: 0x00099C60
		// (set) Token: 0x06002908 RID: 10504 RVA: 0x0009BA6C File Offset: 0x00099C6C
		public global::Vis.Op op
		{
			get
			{
				return (global::Vis.Op)(this._op & 0x7F);
			}
			set
			{
				this._op = ((this._op & 0x80) | ((byte)value & 0x7F));
			}
		}

		// Token: 0x17000902 RID: 2306
		// (get) Token: 0x06002909 RID: 10505 RVA: 0x0009BA88 File Offset: 0x00099C88
		// (set) Token: 0x0600290A RID: 10506 RVA: 0x0009BA90 File Offset: 0x00099C90
		public int data
		{
			get
			{
				return this._val;
			}
			set
			{
				this._val = value;
			}
		}

		// Token: 0x0600290B RID: 10507 RVA: 0x0009BA9C File Offset: 0x00099C9C
		public override int GetHashCode()
		{
			return this._val & int.MaxValue;
		}

		// Token: 0x0600290C RID: 10508 RVA: 0x0009BAAC File Offset: 0x00099CAC
		public override string ToString()
		{
			return this.op + ':' + this.value;
		}

		// Token: 0x0600290D RID: 10509 RVA: 0x0009BADC File Offset: 0x00099CDC
		public override bool Equals(object obj)
		{
			if (obj is global::Vis.Op<TFlags>)
			{
				return this.Equals((global::Vis.Op<TFlags>)obj);
			}
			if (obj is global::Vis.Op)
			{
				return this.Equals((global::Vis.Op)((int)obj));
			}
			return obj.Equals(this);
		}

		// Token: 0x0600290E RID: 10510 RVA: 0x0009BB2C File Offset: 0x00099D2C
		public bool Equals(global::Vis.Op<TFlags> other)
		{
			return other._val == this;
		}

		// Token: 0x0600290F RID: 10511 RVA: 0x0009BB40 File Offset: 0x00099D40
		public bool Equals(global::Vis.Op other)
		{
			return other == this.op;
		}

		// Token: 0x06002910 RID: 10512 RVA: 0x0009BB4C File Offset: 0x00099D4C
		public global::Vis.Op<TFlags>.Res Eval(int flags)
		{
			return new global::Vis.Op<TFlags>.Res(this, (TFlags)((object)global::System.Enum.ToObject(typeof(TFlags), flags)), flags);
		}

		// Token: 0x06002911 RID: 10513 RVA: 0x0009BB70 File Offset: 0x00099D70
		public global::Vis.Op<TFlags>.Res Eval(TFlags flags)
		{
			return new global::Vis.Op<TFlags>.Res(this, flags, global::Vis.Op<TFlags>.ToInt(flags));
		}

		// Token: 0x06002912 RID: 10514 RVA: 0x0009BB84 File Offset: 0x00099D84
		public static bool operator ==(global::Vis.Op<TFlags> op, TFlags flags)
		{
			return global::Vis.Evaluate(op.op, op._val & 0xFFFFFF, global::Vis.Op<TFlags>.ToInt(flags));
		}

		// Token: 0x06002913 RID: 10515 RVA: 0x0009BBB0 File Offset: 0x00099DB0
		public static bool operator ==(TFlags flags, global::Vis.Op<TFlags> op)
		{
			return global::Vis.Evaluate(op.op, op._val & 0xFFFFFF, global::Vis.Op<TFlags>.ToInt(flags));
		}

		// Token: 0x06002914 RID: 10516 RVA: 0x0009BBDC File Offset: 0x00099DDC
		public static bool operator !=(global::Vis.Op<TFlags> op, TFlags flags)
		{
			return !global::Vis.Evaluate(op.op, op._val & 0xFFFFFF, global::Vis.Op<TFlags>.ToInt(flags));
		}

		// Token: 0x06002915 RID: 10517 RVA: 0x0009BC0C File Offset: 0x00099E0C
		public static bool operator !=(TFlags flags, global::Vis.Op<TFlags> op)
		{
			return !global::Vis.Evaluate(op.op, op._val & 0xFFFFFF, global::Vis.Op<TFlags>.ToInt(flags));
		}

		// Token: 0x06002916 RID: 10518 RVA: 0x0009BC3C File Offset: 0x00099E3C
		public static global::Vis.Op<TFlags>.Res operator +(global::Vis.Op<TFlags> op, TFlags flags)
		{
			return op.Eval(flags);
		}

		// Token: 0x06002917 RID: 10519 RVA: 0x0009BC48 File Offset: 0x00099E48
		public static global::Vis.Op<TFlags>.Res operator +(global::Vis.Op<TFlags> op, int flags)
		{
			return op.Eval(flags);
		}

		// Token: 0x06002918 RID: 10520 RVA: 0x0009BC54 File Offset: 0x00099E54
		public static global::Vis.Op<TFlags>.Res operator -(global::Vis.Op<TFlags> op, TFlags flags)
		{
			return op.Eval(flags);
		}

		// Token: 0x06002919 RID: 10521 RVA: 0x0009BC60 File Offset: 0x00099E60
		public static global::Vis.Op<TFlags>.Res operator -(global::Vis.Op<TFlags> op, int flags)
		{
			return op.Eval(flags);
		}

		// Token: 0x0600291A RID: 10522 RVA: 0x0009BC6C File Offset: 0x00099E6C
		public static global::Vis.Op<TFlags>operator -(global::Vis.Op<TFlags> op)
		{
			op.op = global::Vis.Negate(op.op);
			return op;
		}

		// Token: 0x0600291B RID: 10523 RVA: 0x0009BC84 File Offset: 0x00099E84
		public static bool operator ==(global::Vis.Op<TFlags> L, global::Vis.Op R)
		{
			return (int)L._op == (int)((sbyte)R);
		}

		// Token: 0x0600291C RID: 10524 RVA: 0x0009BC94 File Offset: 0x00099E94
		public static bool operator ==(global::Vis.Op L, global::Vis.Op<TFlags> R)
		{
			return (int)R._op == (int)((sbyte)L);
		}

		// Token: 0x0600291D RID: 10525 RVA: 0x0009BCA4 File Offset: 0x00099EA4
		public static bool operator !=(global::Vis.Op<TFlags> L, global::Vis.Op R)
		{
			return (int)L._op != (int)((sbyte)R);
		}

		// Token: 0x0600291E RID: 10526 RVA: 0x0009BCB8 File Offset: 0x00099EB8
		public static bool operator !=(global::Vis.Op L, global::Vis.Op<TFlags> R)
		{
			return (int)R._op != (int)((sbyte)L);
		}

		// Token: 0x0600291F RID: 10527 RVA: 0x0009BCCC File Offset: 0x00099ECC
		public static bool operator ==(global::Vis.Op<TFlags> L, int R)
		{
			return L._val == R;
		}

		// Token: 0x06002920 RID: 10528 RVA: 0x0009BCD8 File Offset: 0x00099ED8
		public static bool operator ==(int R, global::Vis.Op<TFlags> L)
		{
			return L._val == R;
		}

		// Token: 0x06002921 RID: 10529 RVA: 0x0009BCE4 File Offset: 0x00099EE4
		public static bool operator !=(global::Vis.Op<TFlags> L, int R)
		{
			return L._val != R;
		}

		// Token: 0x06002922 RID: 10530 RVA: 0x0009BCF4 File Offset: 0x00099EF4
		public static bool operator !=(int R, global::Vis.Op<TFlags> L)
		{
			return L._val != R;
		}

		// Token: 0x06002923 RID: 10531 RVA: 0x0009BD04 File Offset: 0x00099F04
		public static bool operator ==(global::Vis.Op<TFlags> L, global::Vis.Op<TFlags> R)
		{
			return L._val == R._val;
		}

		// Token: 0x06002924 RID: 10532 RVA: 0x0009BD18 File Offset: 0x00099F18
		public static bool operator !=(global::Vis.Op<TFlags> L, global::Vis.Op<TFlags> R)
		{
			return L._val != R._val;
		}

		// Token: 0x06002925 RID: 10533 RVA: 0x0009BD30 File Offset: 0x00099F30
		public static implicit operator global::Vis.Op<TFlags>(int data)
		{
			return new global::Vis.Op<TFlags>
			{
				_val = data
			};
		}

		// Token: 0x06002926 RID: 10534 RVA: 0x0009BD50 File Offset: 0x00099F50
		public static implicit operator int(global::Vis.Op<TFlags> op)
		{
			return op._val;
		}

		// Token: 0x06002927 RID: 10535 RVA: 0x0009BD5C File Offset: 0x00099F5C
		public static implicit operator global::Vis.Op(global::Vis.Op<TFlags> op)
		{
			return op.op;
		}

		// Token: 0x04001480 RID: 5248
		private global::Vis.OpBase _;

		// Token: 0x020004A1 RID: 1185
		public struct Res
		{
			// Token: 0x06002928 RID: 10536 RVA: 0x0009BD68 File Offset: 0x00099F68
			internal Res(global::Vis.Op<TFlags> op, TFlags flags, int flagsint)
			{
				this._op = op;
				this.query = flags;
				if (global::Vis.Evaluate(op.op, op.intvalue, flagsint))
				{
					this._op._val = (this._op._val | int.MinValue);
				}
				else
				{
					this._op._val = (this._op._val & int.MaxValue);
				}
			}

			// Token: 0x17000903 RID: 2307
			// (get) Token: 0x06002929 RID: 10537 RVA: 0x0009BDD0 File Offset: 0x00099FD0
			public global::Vis.Op<TFlags> operation
			{
				get
				{
					return this._op;
				}
			}

			// Token: 0x17000904 RID: 2308
			// (get) Token: 0x0600292A RID: 10538 RVA: 0x0009BDD8 File Offset: 0x00099FD8
			public bool passed
			{
				get
				{
					return (this._op._val & int.MinValue) == int.MinValue;
				}
			}

			// Token: 0x17000905 RID: 2309
			// (get) Token: 0x0600292B RID: 10539 RVA: 0x0009BE00 File Offset: 0x0009A000
			public bool failed
			{
				get
				{
					return (this._op._val & int.MinValue) != int.MinValue;
				}
			}

			// Token: 0x17000906 RID: 2310
			// (get) Token: 0x0600292C RID: 10540 RVA: 0x0009BE2C File Offset: 0x0009A02C
			public TFlags value
			{
				get
				{
					return this._op.value;
				}
			}

			// Token: 0x17000907 RID: 2311
			// (get) Token: 0x0600292D RID: 10541 RVA: 0x0009BE48 File Offset: 0x0009A048
			public int intvalue
			{
				get
				{
					return this._op.intvalue;
				}
			}

			// Token: 0x17000908 RID: 2312
			// (get) Token: 0x0600292E RID: 10542 RVA: 0x0009BE64 File Offset: 0x0009A064
			public int data
			{
				get
				{
					return this._op._val;
				}
			}

			// Token: 0x0600292F RID: 10543 RVA: 0x0009BE80 File Offset: 0x0009A080
			public override int GetHashCode()
			{
				return (int.MinValue | this._op._val) ^ global::Vis.Op<TFlags>.ToInt(this.query);
			}

			// Token: 0x06002930 RID: 10544 RVA: 0x0009BEB0 File Offset: 0x0009A0B0
			public override string ToString()
			{
				return string.Format("{0}({1}) == {2}", this.operation, this.query, this.passed);
			}

			// Token: 0x06002931 RID: 10545 RVA: 0x0009BEE8 File Offset: 0x0009A0E8
			public static implicit operator bool(global::Vis.Op<TFlags>.Res r)
			{
				return r.passed;
			}

			// Token: 0x06002932 RID: 10546 RVA: 0x0009BEF4 File Offset: 0x0009A0F4
			public static bool operator !(global::Vis.Op<TFlags>.Res r)
			{
				return r.failed;
			}

			// Token: 0x04001481 RID: 5249
			public readonly TFlags query;

			// Token: 0x04001482 RID: 5250
			private readonly global::Vis.Op<TFlags> _op;
		}
	}

	// Token: 0x020004A2 RID: 1186
	[global::System.Flags]
	public enum Life
	{
		// Token: 0x04001484 RID: 5252
		Alive = 1,
		// Token: 0x04001485 RID: 5253
		Unconcious = 2,
		// Token: 0x04001486 RID: 5254
		Dead = 4
	}

	// Token: 0x020004A3 RID: 1187
	[global::System.Flags]
	public enum Status
	{
		// Token: 0x04001488 RID: 5256
		Casual = 1,
		// Token: 0x04001489 RID: 5257
		Hurt = 2,
		// Token: 0x0400148A RID: 5258
		Curious = 4,
		// Token: 0x0400148B RID: 5259
		Alert = 8,
		// Token: 0x0400148C RID: 5260
		Search = 0x10,
		// Token: 0x0400148D RID: 5261
		Armed = 0x20,
		// Token: 0x0400148E RID: 5262
		Attacking = 0x40
	}

	// Token: 0x020004A4 RID: 1188
	[global::System.Flags]
	public enum Role
	{
		// Token: 0x04001490 RID: 5264
		Citizen = 1,
		// Token: 0x04001491 RID: 5265
		Criminal = 2,
		// Token: 0x04001492 RID: 5266
		Authority = 4,
		// Token: 0x04001493 RID: 5267
		Target = 8,
		// Token: 0x04001494 RID: 5268
		Entourage = 0x10,
		// Token: 0x04001495 RID: 5269
		Player = 0x20,
		// Token: 0x04001496 RID: 5270
		Vehicle = 0x40,
		// Token: 0x04001497 RID: 5271
		Animal = 0x80
	}

	// Token: 0x020004A5 RID: 1189
	[global::System.Runtime.InteropServices.StructLayout(global::System.Runtime.InteropServices.LayoutKind.Explicit, Size = 4)]
	public struct Mask
	{
		// Token: 0x06002933 RID: 10547 RVA: 0x0009BF00 File Offset: 0x0009A100
		static Mask()
		{
			int num = 0;
			global::Vis.Mask.sect(0, ref num);
			global::System.Collections.Specialized.BitVector32.Section? section = new global::System.Collections.Specialized.BitVector32.Section?(global::Vis.Mask.sect(3, ref num));
			global::Vis.Mask.sect(5, ref num);
			global::System.Collections.Specialized.BitVector32.Section? section2 = new global::System.Collections.Specialized.BitVector32.Section?(global::Vis.Mask.sect(7, ref num));
			global::Vis.Mask.sect(9, ref num);
			global::System.Collections.Specialized.BitVector32.Section? section3 = new global::System.Collections.Specialized.BitVector32.Section?(global::Vis.Mask.sect(8, ref num));
			global::Vis.Mask.s_life = section.GetValueOrDefault();
			global::Vis.Mask.s_stat = section2.GetValueOrDefault();
			global::Vis.Mask.s_role = section3.GetValueOrDefault();
		}

		// Token: 0x06002934 RID: 10548 RVA: 0x0009BF88 File Offset: 0x0009A188
		private static global::System.Collections.Specialized.BitVector32.Section sect_(int count, ref int i)
		{
			if (count == 0)
			{
				return default(global::System.Collections.Specialized.BitVector32.Section);
			}
			if (i == 0)
			{
				global::System.Collections.Specialized.BitVector32.Section result = global::System.Collections.Specialized.BitVector32.CreateSection((short)((1 << count) - 1));
				i += count;
				return result;
			}
			int j = i;
			global::System.Collections.Specialized.BitVector32.Section previous;
			if (j >= 8)
			{
				previous = global::System.Collections.Specialized.BitVector32.CreateSection(0xFF);
				for (j -= 8; j >= 8; j -= 8)
				{
					previous = global::System.Collections.Specialized.BitVector32.CreateSection(0xFF, previous);
				}
				if (j > 0)
				{
					previous = global::System.Collections.Specialized.BitVector32.CreateSection((short)((1 << j) - 1), previous);
				}
			}
			else
			{
				previous = global::System.Collections.Specialized.BitVector32.CreateSection((short)((1 << j) - 1));
			}
			global::System.Collections.Specialized.BitVector32.Section result2 = global::System.Collections.Specialized.BitVector32.CreateSection((short)((1 << count) - 1), previous);
			i += count;
			return result2;
		}

		// Token: 0x06002935 RID: 10549 RVA: 0x0009C03C File Offset: 0x0009A23C
		private static global::System.Collections.Specialized.BitVector32.Section sect(int count, ref int i)
		{
			return global::Vis.Mask.sect_(count, ref i);
		}

		// Token: 0x17000909 RID: 2313
		// (get) Token: 0x06002936 RID: 10550 RVA: 0x0009C048 File Offset: 0x0009A248
		// (set) Token: 0x06002937 RID: 10551 RVA: 0x0009C05C File Offset: 0x0009A25C
		public global::Vis.Life life
		{
			get
			{
				return (global::Vis.Life)this.bits[global::Vis.Mask.s_life];
			}
			set
			{
				this.bits[global::Vis.Mask.s_life] = (int)(value & (global::Vis.Life)global::Vis.Mask.s_life.Mask);
			}
		}

		// Token: 0x1700090A RID: 2314
		public bool this[global::Vis.Life mask]
		{
			get
			{
				return (this.life & mask) != (global::Vis.Life)0;
			}
			set
			{
				if (value)
				{
					this.life |= mask;
				}
				else
				{
					this.life &= ~mask;
				}
			}
		}

		// Token: 0x1700090B RID: 2315
		// (get) Token: 0x0600293A RID: 10554 RVA: 0x0009C0C4 File Offset: 0x0009A2C4
		// (set) Token: 0x0600293B RID: 10555 RVA: 0x0009C0D8 File Offset: 0x0009A2D8
		public global::Vis.Status stat
		{
			get
			{
				return (global::Vis.Status)this.bits[global::Vis.Mask.s_stat];
			}
			set
			{
				this.bits[global::Vis.Mask.s_stat] = (int)(value & (global::Vis.Status)global::Vis.Mask.s_stat.Mask);
			}
		}

		// Token: 0x1700090C RID: 2316
		public bool this[global::Vis.Status mask]
		{
			get
			{
				return (this.stat & mask) != (global::Vis.Status)0;
			}
			set
			{
				if (value)
				{
					this.stat |= mask;
				}
				else
				{
					this.stat &= ~mask;
				}
			}
		}

		// Token: 0x1700090D RID: 2317
		// (get) Token: 0x0600293E RID: 10558 RVA: 0x0009C140 File Offset: 0x0009A340
		// (set) Token: 0x0600293F RID: 10559 RVA: 0x0009C154 File Offset: 0x0009A354
		public global::Vis.Role role
		{
			get
			{
				return (global::Vis.Role)this.bits[global::Vis.Mask.s_role];
			}
			set
			{
				this.bits[global::Vis.Mask.s_role] = (int)(value & (global::Vis.Role)global::Vis.Mask.s_role.Mask);
			}
		}

		// Token: 0x1700090E RID: 2318
		public bool this[global::Vis.Role mask]
		{
			get
			{
				return (this.role & mask) != (global::Vis.Role)0;
			}
			set
			{
				if (value)
				{
					this.role |= mask;
				}
				else
				{
					this.role &= ~mask;
				}
			}
		}

		// Token: 0x1700090F RID: 2319
		public bool this[global::Vis.Op op, global::Vis.Life val]
		{
			get
			{
				return this.Eval(op, val);
			}
			set
			{
				this.Apply(op, val);
			}
		}

		// Token: 0x17000910 RID: 2320
		public bool this[global::Vis.Op op, global::Vis.Status val]
		{
			get
			{
				return this.Eval(op, val);
			}
			set
			{
				this.Apply(op, val);
			}
		}

		// Token: 0x17000911 RID: 2321
		public bool this[global::Vis.Op op, global::Vis.Role val]
		{
			get
			{
				return this.Eval(op, val);
			}
			set
			{
				this.Apply(op, val);
			}
		}

		// Token: 0x17000912 RID: 2322
		public global::Vis.Op<global::Vis.Life>.Res this[global::Vis.Op<global::Vis.Life> op]
		{
			get
			{
				return op.Eval(this.bits[global::Vis.Mask.s_life]);
			}
		}

		// Token: 0x17000913 RID: 2323
		public global::Vis.Op<global::Vis.Status>.Res this[global::Vis.Op<global::Vis.Status> op]
		{
			get
			{
				return op.Eval(this.bits[global::Vis.Mask.s_stat]);
			}
		}

		// Token: 0x17000914 RID: 2324
		public global::Vis.Op<global::Vis.Role>.Res this[global::Vis.Op<global::Vis.Role> op]
		{
			get
			{
				return op.Eval(this.bits[global::Vis.Mask.s_role]);
			}
		}

		// Token: 0x0600294B RID: 10571 RVA: 0x0009C258 File Offset: 0x0009A458
		public bool All(global::Vis.Life f)
		{
			return (this.life & f) == f;
		}

		// Token: 0x0600294C RID: 10572 RVA: 0x0009C268 File Offset: 0x0009A468
		public bool All(global::Vis.Role f)
		{
			return (this.role & f) == f;
		}

		// Token: 0x0600294D RID: 10573 RVA: 0x0009C278 File Offset: 0x0009A478
		public bool All(global::Vis.Status f)
		{
			return (this.stat & f) == f;
		}

		// Token: 0x0600294E RID: 10574 RVA: 0x0009C288 File Offset: 0x0009A488
		public bool Any(global::Vis.Life f)
		{
			return (this.life & f) > (global::Vis.Life)0;
		}

		// Token: 0x0600294F RID: 10575 RVA: 0x0009C298 File Offset: 0x0009A498
		public bool Any(global::Vis.Role f)
		{
			return (this.role & f) > (global::Vis.Role)0;
		}

		// Token: 0x06002950 RID: 10576 RVA: 0x0009C2A8 File Offset: 0x0009A4A8
		public bool Any(global::Vis.Status f)
		{
			return (this.stat & f) > (global::Vis.Status)0;
		}

		// Token: 0x06002951 RID: 10577 RVA: 0x0009C2B8 File Offset: 0x0009A4B8
		public bool AllMore(global::Vis.Life f)
		{
			global::Vis.Life life = this.life;
			return life > f && (life & f) == f;
		}

		// Token: 0x06002952 RID: 10578 RVA: 0x0009C2DC File Offset: 0x0009A4DC
		public bool AllMore(global::Vis.Role f)
		{
			global::Vis.Role role = this.role;
			return role > f && (role & f) == f;
		}

		// Token: 0x06002953 RID: 10579 RVA: 0x0009C300 File Offset: 0x0009A500
		public bool AllMore(global::Vis.Status f)
		{
			global::Vis.Status stat = this.stat;
			return stat > f && (stat & f) == f;
		}

		// Token: 0x06002954 RID: 10580 RVA: 0x0009C324 File Offset: 0x0009A524
		public bool AnyLess(global::Vis.Life f)
		{
			global::Vis.Life life = this.life;
			return (life & f) < f;
		}

		// Token: 0x06002955 RID: 10581 RVA: 0x0009C340 File Offset: 0x0009A540
		public bool AnyLess(global::Vis.Role f)
		{
			global::Vis.Role role = this.role;
			return (role & f) < f;
		}

		// Token: 0x06002956 RID: 10582 RVA: 0x0009C35C File Offset: 0x0009A55C
		public bool AnyLess(global::Vis.Status f)
		{
			global::Vis.Status stat = this.stat;
			return (stat & f) < f;
		}

		// Token: 0x06002957 RID: 10583 RVA: 0x0009C378 File Offset: 0x0009A578
		public bool Equals(global::Vis.Life f)
		{
			return this.life == f;
		}

		// Token: 0x06002958 RID: 10584 RVA: 0x0009C384 File Offset: 0x0009A584
		public bool Equals(global::Vis.Role f)
		{
			return this.role == f;
		}

		// Token: 0x06002959 RID: 10585 RVA: 0x0009C390 File Offset: 0x0009A590
		public bool Equals(global::Vis.Status f)
		{
			return this.stat == f;
		}

		// Token: 0x0600295A RID: 10586 RVA: 0x0009C39C File Offset: 0x0009A59C
		public void Append(global::Vis.Life f)
		{
			this.life |= f;
		}

		// Token: 0x0600295B RID: 10587 RVA: 0x0009C3AC File Offset: 0x0009A5AC
		public void Append(global::Vis.Role f)
		{
			this.role |= f;
		}

		// Token: 0x0600295C RID: 10588 RVA: 0x0009C3BC File Offset: 0x0009A5BC
		public void Append(global::Vis.Status f)
		{
			this.stat |= f;
		}

		// Token: 0x0600295D RID: 10589 RVA: 0x0009C3CC File Offset: 0x0009A5CC
		public global::Vis.Life Not(global::Vis.Life f)
		{
			return (this.life ^ f) & f;
		}

		// Token: 0x0600295E RID: 10590 RVA: 0x0009C3D8 File Offset: 0x0009A5D8
		public global::Vis.Role Not(global::Vis.Role f)
		{
			return (this.role ^ f) & f;
		}

		// Token: 0x0600295F RID: 10591 RVA: 0x0009C3E4 File Offset: 0x0009A5E4
		public global::Vis.Status Not(global::Vis.Status f)
		{
			return (this.stat ^ f) & f;
		}

		// Token: 0x06002960 RID: 10592 RVA: 0x0009C3F0 File Offset: 0x0009A5F0
		public global::Vis.Life AppendNot(global::Vis.Life f)
		{
			global::Vis.Life life = (this.life ^ f) & f;
			this.life |= life;
			return life;
		}

		// Token: 0x06002961 RID: 10593 RVA: 0x0009C418 File Offset: 0x0009A618
		public global::Vis.Role AppendNot(global::Vis.Role f)
		{
			global::Vis.Role role = (this.role ^ f) & f;
			this.role |= role;
			return role;
		}

		// Token: 0x06002962 RID: 10594 RVA: 0x0009C440 File Offset: 0x0009A640
		public global::Vis.Status AppendNot(global::Vis.Status f)
		{
			global::Vis.Status status = (this.stat ^ f) & f;
			this.stat |= status;
			return status;
		}

		// Token: 0x06002963 RID: 10595 RVA: 0x0009C468 File Offset: 0x0009A668
		public bool Eval(global::Vis.Op op, global::Vis.Life f)
		{
			return global::Vis.Evaluate(op, (int)f, this.bits[global::Vis.Mask.s_life]);
		}

		// Token: 0x06002964 RID: 10596 RVA: 0x0009C484 File Offset: 0x0009A684
		public bool Eval(global::Vis.Op<global::Vis.Life> op)
		{
			return op == this.life;
		}

		// Token: 0x06002965 RID: 10597 RVA: 0x0009C494 File Offset: 0x0009A694
		public global::Vis.Life Apply(global::Vis.Op op, global::Vis.Life f)
		{
			return (global::Vis.Life)global::Vis.SetTrue(op, (int)f, ref this.bits, global::Vis.Mask.s_life);
		}

		// Token: 0x06002966 RID: 10598 RVA: 0x0009C4A8 File Offset: 0x0009A6A8
		public global::Vis.Life Apply(global::Vis.Op<global::Vis.Life> op)
		{
			return (global::Vis.Life)global::Vis.SetTrue(op, op.intvalue, ref this.bits, global::Vis.Mask.s_life);
		}

		// Token: 0x06002967 RID: 10599 RVA: 0x0009C4C8 File Offset: 0x0009A6C8
		public bool Eval(global::Vis.Op op, global::Vis.Status f)
		{
			return global::Vis.Evaluate(op, (int)f, this.bits[global::Vis.Mask.s_stat]);
		}

		// Token: 0x06002968 RID: 10600 RVA: 0x0009C4E4 File Offset: 0x0009A6E4
		public bool Eval(global::Vis.Op<global::Vis.Status> op)
		{
			return op == this.stat;
		}

		// Token: 0x06002969 RID: 10601 RVA: 0x0009C4F4 File Offset: 0x0009A6F4
		public global::Vis.Status Apply(global::Vis.Op op, global::Vis.Status f)
		{
			return (global::Vis.Status)global::Vis.SetTrue(op, (int)f, ref this.bits, global::Vis.Mask.s_stat);
		}

		// Token: 0x0600296A RID: 10602 RVA: 0x0009C508 File Offset: 0x0009A708
		public global::Vis.Status Apply(global::Vis.Op<global::Vis.Status> op)
		{
			return (global::Vis.Status)global::Vis.SetTrue(op, op.intvalue, ref this.bits, global::Vis.Mask.s_stat);
		}

		// Token: 0x0600296B RID: 10603 RVA: 0x0009C528 File Offset: 0x0009A728
		public bool Eval(global::Vis.Op op, global::Vis.Role f)
		{
			return global::Vis.Evaluate(op, (int)f, this.bits[global::Vis.Mask.s_role]);
		}

		// Token: 0x0600296C RID: 10604 RVA: 0x0009C544 File Offset: 0x0009A744
		public bool Eval(global::Vis.Op<global::Vis.Role> op)
		{
			return op == this.role;
		}

		// Token: 0x0600296D RID: 10605 RVA: 0x0009C554 File Offset: 0x0009A754
		public global::Vis.Role Apply(global::Vis.Op op, global::Vis.Role f)
		{
			return (global::Vis.Role)global::Vis.SetTrue(op, (int)f, ref this.bits, global::Vis.Mask.s_role);
		}

		// Token: 0x0600296E RID: 10606 RVA: 0x0009C568 File Offset: 0x0009A768
		public global::Vis.Role Apply(global::Vis.Op<global::Vis.Role> op)
		{
			return (global::Vis.Role)global::Vis.SetTrue(op, op.intvalue, ref this.bits, global::Vis.Mask.s_role);
		}

		// Token: 0x0600296F RID: 10607 RVA: 0x0009C588 File Offset: 0x0009A788
		public void Remove(global::Vis.Life f)
		{
			this.life &= ~f;
		}

		// Token: 0x06002970 RID: 10608 RVA: 0x0009C59C File Offset: 0x0009A79C
		public void Remove(global::Vis.Role f)
		{
			this.role &= ~f;
		}

		// Token: 0x06002971 RID: 10609 RVA: 0x0009C5B0 File Offset: 0x0009A7B0
		public void Remove(global::Vis.Status f)
		{
			this.stat &= ~f;
		}

		// Token: 0x17000915 RID: 2325
		public bool this[global::Vis.Trait trait]
		{
			get
			{
				return this.bits[1 << (int)trait];
			}
		}

		// Token: 0x17000916 RID: 2326
		public bool this[int mask]
		{
			get
			{
				return this.bits[mask];
			}
		}

		// Token: 0x04001498 RID: 5272
		public const int kAlive = 1;

		// Token: 0x04001499 RID: 5273
		public const int kUnconcious = 2;

		// Token: 0x0400149A RID: 5274
		public const int kDead = 4;

		// Token: 0x0400149B RID: 5275
		public const int kCasual = 0x100;

		// Token: 0x0400149C RID: 5276
		public const int kHurt = 0x200;

		// Token: 0x0400149D RID: 5277
		public const int kCurious = 0x400;

		// Token: 0x0400149E RID: 5278
		public const int kAlert = 0x800;

		// Token: 0x0400149F RID: 5279
		public const int kSearch = 0x1000;

		// Token: 0x040014A0 RID: 5280
		public const int kArmed = 0x2000;

		// Token: 0x040014A1 RID: 5281
		public const int kAttacking = 0x4000;

		// Token: 0x040014A2 RID: 5282
		public const int kCriminal = 0x2000000;

		// Token: 0x040014A3 RID: 5283
		public const int kAuthority = 0x4000000;

		// Token: 0x040014A4 RID: 5284
		private static global::System.Collections.Specialized.BitVector32.Section s_life;

		// Token: 0x040014A5 RID: 5285
		private static global::System.Collections.Specialized.BitVector32.Section s_stat;

		// Token: 0x040014A6 RID: 5286
		private static global::System.Collections.Specialized.BitVector32.Section s_role;

		// Token: 0x040014A7 RID: 5287
		[global::System.Runtime.InteropServices.FieldOffset(0)]
		public global::System.Collections.Specialized.BitVector32 bits;

		// Token: 0x040014A8 RID: 5288
		[global::System.Runtime.InteropServices.FieldOffset(0)]
		public int data;

		// Token: 0x040014A9 RID: 5289
		[global::System.Runtime.InteropServices.FieldOffset(0)]
		public uint udata;

		// Token: 0x040014AA RID: 5290
		public static readonly global::Vis.Mask zero = default(global::Vis.Mask);
	}

	// Token: 0x020004A6 RID: 1190
	[global::System.Flags]
	public enum Flag
	{
		// Token: 0x040014AC RID: 5292
		Zero = 0,
		// Token: 0x040014AD RID: 5293
		Relative = 1,
		// Token: 0x040014AE RID: 5294
		Target = 4,
		// Token: 0x040014AF RID: 5295
		Self = 8
	}

	// Token: 0x020004A7 RID: 1191
	public enum Comparison
	{
		// Token: 0x040014B1 RID: 5297
		Stealthy = 5,
		// Token: 0x040014B2 RID: 5298
		Prey = 9,
		// Token: 0x040014B3 RID: 5299
		IsSelf = 0xC,
		// Token: 0x040014B4 RID: 5300
		Oblivious = 1,
		// Token: 0x040014B5 RID: 5301
		Contact = 0xD
	}

	// Token: 0x020004A8 RID: 1192
	public enum Region
	{
		// Token: 0x040014B7 RID: 5303
		Life,
		// Token: 0x040014B8 RID: 5304
		Status,
		// Token: 0x040014B9 RID: 5305
		Role
	}

	// Token: 0x020004A9 RID: 1193
	public struct Rule
	{
		// Token: 0x17000917 RID: 2327
		public global::Vis.Mask this[global::Vis.Rule.Step step]
		{
			get
			{
				switch (step)
				{
				case global::Vis.Rule.Step.Accept:
					return this.accept;
				case global::Vis.Rule.Step.Conditional:
					return this.conditional;
				case global::Vis.Rule.Step.Reject:
					return this.reject;
				default:
					throw new global::System.ArgumentOutOfRangeException("step");
				}
			}
			set
			{
				switch (step)
				{
				case global::Vis.Rule.Step.Accept:
					this.accept = value;
					break;
				case global::Vis.Rule.Step.Conditional:
					this.conditional = value;
					break;
				case global::Vis.Rule.Step.Reject:
					this.reject = value;
					break;
				default:
					throw new global::System.ArgumentOutOfRangeException("step");
				}
			}
		}

		// Token: 0x17000918 RID: 2328
		// (get) Token: 0x06002976 RID: 10614 RVA: 0x0009C688 File Offset: 0x0009A888
		// (set) Token: 0x06002977 RID: 10615 RVA: 0x0009C6BC File Offset: 0x0009A8BC
		public global::Vis.Op<global::Vis.Life> rejectLife
		{
			get
			{
				return new global::Vis.Op<global::Vis.Life>((byte)this.setup.life.reject, (int)this.reject.life);
			}
			set
			{
				global::Vis.Rule.RegionSetup life = this.setup.life;
				life.reject = value.op;
				this.setup.life = life;
				this.reject.life = value.value;
			}
		}

		// Token: 0x17000919 RID: 2329
		// (get) Token: 0x06002978 RID: 10616 RVA: 0x0009C704 File Offset: 0x0009A904
		// (set) Token: 0x06002979 RID: 10617 RVA: 0x0009C738 File Offset: 0x0009A938
		public global::Vis.Op<global::Vis.Status> rejectStatus
		{
			get
			{
				return new global::Vis.Op<global::Vis.Status>((byte)this.setup.stat.reject, (int)this.reject.stat);
			}
			set
			{
				global::Vis.Rule.RegionSetup life = this.setup.life;
				life.reject = value.op;
				this.setup.life = life;
				this.reject.stat = value.value;
			}
		}

		// Token: 0x1700091A RID: 2330
		// (get) Token: 0x0600297A RID: 10618 RVA: 0x0009C780 File Offset: 0x0009A980
		// (set) Token: 0x0600297B RID: 10619 RVA: 0x0009C7B4 File Offset: 0x0009A9B4
		public global::Vis.Op<global::Vis.Role> rejectRole
		{
			get
			{
				return new global::Vis.Op<global::Vis.Role>((byte)this.setup.role.reject, (int)this.reject.role);
			}
			set
			{
				global::Vis.Rule.RegionSetup life = this.setup.life;
				life.reject = value.op;
				this.setup.life = life;
				this.reject.role = value.value;
			}
		}

		// Token: 0x1700091B RID: 2331
		// (get) Token: 0x0600297C RID: 10620 RVA: 0x0009C7FC File Offset: 0x0009A9FC
		// (set) Token: 0x0600297D RID: 10621 RVA: 0x0009C830 File Offset: 0x0009AA30
		public global::Vis.Op<global::Vis.Life> acceptLife
		{
			get
			{
				return new global::Vis.Op<global::Vis.Life>((byte)this.setup.life.accept, (int)this.accept.life);
			}
			set
			{
				global::Vis.Rule.RegionSetup life = this.setup.life;
				life.accept = value.op;
				this.setup.life = life;
				this.accept.life = value.value;
			}
		}

		// Token: 0x1700091C RID: 2332
		// (get) Token: 0x0600297E RID: 10622 RVA: 0x0009C878 File Offset: 0x0009AA78
		// (set) Token: 0x0600297F RID: 10623 RVA: 0x0009C8AC File Offset: 0x0009AAAC
		public global::Vis.Op<global::Vis.Status> acceptStatus
		{
			get
			{
				return new global::Vis.Op<global::Vis.Status>((byte)this.setup.stat.accept, (int)this.accept.stat);
			}
			set
			{
				global::Vis.Rule.RegionSetup stat = this.setup.stat;
				stat.accept = value.op;
				this.setup.stat = stat;
				this.accept.stat = value.value;
			}
		}

		// Token: 0x1700091D RID: 2333
		// (get) Token: 0x06002980 RID: 10624 RVA: 0x0009C8F4 File Offset: 0x0009AAF4
		// (set) Token: 0x06002981 RID: 10625 RVA: 0x0009C928 File Offset: 0x0009AB28
		public global::Vis.Op<global::Vis.Role> acceptRole
		{
			get
			{
				return new global::Vis.Op<global::Vis.Role>((byte)this.setup.role.accept, (int)this.accept.role);
			}
			set
			{
				global::Vis.Rule.RegionSetup role = this.setup.role;
				role.accept = value.op;
				this.setup.role = role;
				this.accept.role = value.value;
			}
		}

		// Token: 0x1700091E RID: 2334
		// (get) Token: 0x06002982 RID: 10626 RVA: 0x0009C970 File Offset: 0x0009AB70
		// (set) Token: 0x06002983 RID: 10627 RVA: 0x0009C9A4 File Offset: 0x0009ABA4
		public global::Vis.Op<global::Vis.Life> conditionalLife
		{
			get
			{
				return new global::Vis.Op<global::Vis.Life>((byte)this.setup.life.conditional, (int)this.conditional.life);
			}
			set
			{
				global::Vis.Rule.RegionSetup life = this.setup.life;
				life.conditional = value.op;
				this.setup.life = life;
				this.conditional.life = value.value;
			}
		}

		// Token: 0x1700091F RID: 2335
		// (get) Token: 0x06002984 RID: 10628 RVA: 0x0009C9EC File Offset: 0x0009ABEC
		// (set) Token: 0x06002985 RID: 10629 RVA: 0x0009CA20 File Offset: 0x0009AC20
		public global::Vis.Op<global::Vis.Status> conditionalStatus
		{
			get
			{
				return new global::Vis.Op<global::Vis.Status>((byte)this.setup.stat.conditional, (int)this.conditional.stat);
			}
			set
			{
				global::Vis.Rule.RegionSetup stat = this.setup.stat;
				stat.conditional = value.op;
				this.setup.stat = stat;
				this.conditional.stat = value.value;
			}
		}

		// Token: 0x17000920 RID: 2336
		// (get) Token: 0x06002986 RID: 10630 RVA: 0x0009CA68 File Offset: 0x0009AC68
		// (set) Token: 0x06002987 RID: 10631 RVA: 0x0009CA9C File Offset: 0x0009AC9C
		public global::Vis.Op<global::Vis.Role> conditionalRole
		{
			get
			{
				return new global::Vis.Op<global::Vis.Role>((byte)this.setup.role.conditional, (int)this.conditional.role);
			}
			set
			{
				global::Vis.Rule.RegionSetup role = this.setup.role;
				role.conditional = value.op;
				this.setup.role = role;
				this.conditional.role = value.value;
			}
		}

		// Token: 0x06002988 RID: 10632 RVA: 0x0009CAE4 File Offset: 0x0009ACE4
		private global::Vis.Rule.Failure Accept(global::Vis.Mask mask)
		{
			if (!this.setup.checkAccept)
			{
				return global::Vis.Rule.Failure.None;
			}
			global::Vis.Rule.Failure failure = global::Vis.Rule.Failure.None;
			if (!mask.Eval(this.acceptLife))
			{
				failure |= (global::Vis.Rule.Failure.Conditional | global::Vis.Rule.Failure.Life);
			}
			if (!mask.Eval(this.acceptRole))
			{
				failure |= (global::Vis.Rule.Failure.Conditional | global::Vis.Rule.Failure.Role);
			}
			if (!mask.Eval(this.acceptStatus))
			{
				failure |= (global::Vis.Rule.Failure.Conditional | global::Vis.Rule.Failure.Status);
			}
			return failure;
		}

		// Token: 0x06002989 RID: 10633 RVA: 0x0009CB4C File Offset: 0x0009AD4C
		private global::Vis.Rule.Failure Conditional(global::Vis.Mask mask)
		{
			if (!this.setup.checkConditional)
			{
				return global::Vis.Rule.Failure.None;
			}
			global::Vis.Rule.Failure failure = global::Vis.Rule.Failure.None;
			if (!mask.Eval(this.conditionalLife))
			{
				failure |= (global::Vis.Rule.Failure.Conditional | global::Vis.Rule.Failure.Life);
			}
			if (!mask.Eval(this.conditionalRole))
			{
				failure |= (global::Vis.Rule.Failure.Conditional | global::Vis.Rule.Failure.Role);
			}
			if (!mask.Eval(this.conditionalStatus))
			{
				failure |= (global::Vis.Rule.Failure.Conditional | global::Vis.Rule.Failure.Status);
			}
			return failure;
		}

		// Token: 0x0600298A RID: 10634 RVA: 0x0009CBB4 File Offset: 0x0009ADB4
		private global::Vis.Rule.Failure Reject(global::Vis.Mask mask)
		{
			if (!this.setup.checkReject)
			{
				return global::Vis.Rule.Failure.None;
			}
			global::Vis.Rule.Failure failure = global::Vis.Rule.Failure.None;
			if (mask.Eval(this.rejectLife))
			{
				failure |= (global::Vis.Rule.Failure.Reject | global::Vis.Rule.Failure.Life);
			}
			if (mask.Eval(this.rejectRole))
			{
				failure |= (global::Vis.Rule.Failure.Reject | global::Vis.Rule.Failure.Role);
			}
			if (mask.Eval(this.rejectStatus))
			{
				failure |= (global::Vis.Rule.Failure.Reject | global::Vis.Rule.Failure.Status);
			}
			return failure;
		}

		// Token: 0x0600298B RID: 10635 RVA: 0x0009CC1C File Offset: 0x0009AE1C
		private global::Vis.Rule.Failure Check(global::Vis.Mask a, global::Vis.Mask c, global::Vis.Mask r)
		{
			global::Vis.Rule.Failure failure = this.Accept(a);
			if (failure != global::Vis.Rule.Failure.None)
			{
				return failure;
			}
			failure = this.Conditional(c);
			if (failure != global::Vis.Rule.Failure.None)
			{
				return failure;
			}
			return this.Reject(r);
		}

		// Token: 0x0600298C RID: 10636 RVA: 0x0009CC54 File Offset: 0x0009AE54
		public global::Vis.Rule.Failure Pass(global::Vis.Mask self, global::Vis.Mask other)
		{
			switch (this.setup.option)
			{
			default:
				return this.Check(other, self, other);
			case global::Vis.Rule.Setup.Option.Inverse:
				return this.Check(self, other, self);
			case global::Vis.Rule.Setup.Option.NoConditional:
				return this.Check(other, other, other);
			case global::Vis.Rule.Setup.Option.AllConditional:
				return this.Check(self, self, self);
			}
		}

		// Token: 0x0600298D RID: 10637 RVA: 0x0009CCB0 File Offset: 0x0009AEB0
		public static global::Vis.Rule Decode(int[] data, int index)
		{
			global::Vis.Rule result = default(global::Vis.Rule);
			result.setup.data = data[index++];
			result.accept.data = data[index++];
			result.conditional.data = data[index++];
			result.reject.data = data[index];
			return result;
		}

		// Token: 0x0600298E RID: 10638 RVA: 0x0009CD14 File Offset: 0x0009AF14
		public static void Encode(ref global::Vis.Rule rule, int[] data, int index)
		{
			data[index++] = rule.setup.data;
			data[index++] = rule.accept.data;
			data[index++] = rule.conditional.data;
			data[index++] = rule.reject.data;
		}

		// Token: 0x040014BA RID: 5306
		public global::Vis.Rule.Setup setup;

		// Token: 0x040014BB RID: 5307
		public global::Vis.Mask reject;

		// Token: 0x040014BC RID: 5308
		public global::Vis.Mask accept;

		// Token: 0x040014BD RID: 5309
		public global::Vis.Mask conditional;

		// Token: 0x020004AA RID: 1194
		public enum Clearance
		{
			// Token: 0x040014BF RID: 5311
			Outside,
			// Token: 0x040014C0 RID: 5312
			Enter,
			// Token: 0x040014C1 RID: 5313
			Stay,
			// Token: 0x040014C2 RID: 5314
			Exit
		}

		// Token: 0x020004AB RID: 1195
		public enum Step
		{
			// Token: 0x040014C4 RID: 5316
			Accept,
			// Token: 0x040014C5 RID: 5317
			Conditional,
			// Token: 0x040014C6 RID: 5318
			Reject
		}

		// Token: 0x020004AC RID: 1196
		public struct RegionSetup
		{
			// Token: 0x0600298F RID: 10639 RVA: 0x0009CD70 File Offset: 0x0009AF70
			internal RegionSetup(int value, global::Vis.Region reg)
			{
				this._ = new global::System.Collections.Specialized.BitVector32(value | (int)((int)reg << (int)(global::Vis.Rule.RegionSetup.s_region.Offset & 0x1F)));
			}

			// Token: 0x06002990 RID: 10640 RVA: 0x0009CD9C File Offset: 0x0009AF9C
			static RegionSetup()
			{
				global::System.Collections.Specialized.BitVector32.Section previous = global::Vis.Rule.RegionSetup.s_apt = global::System.Collections.Specialized.BitVector32.CreateSection(7);
				previous = (global::Vis.Rule.RegionSetup.s_cnd = global::System.Collections.Specialized.BitVector32.CreateSection(7, previous));
				previous = (global::Vis.Rule.RegionSetup.s_rej = global::System.Collections.Specialized.BitVector32.CreateSection(7, previous));
				global::Vis.Rule.RegionSetup.s_whole = global::System.Collections.Specialized.BitVector32.CreateSection(0x1FF);
				previous = global::System.Collections.Specialized.BitVector32.CreateSection(7, previous);
				global::Vis.Rule.RegionSetup.s_region = global::System.Collections.Specialized.BitVector32.CreateSection(3, previous);
			}

			// Token: 0x17000921 RID: 2337
			// (get) Token: 0x06002991 RID: 10641 RVA: 0x0009CDF8 File Offset: 0x0009AFF8
			// (set) Token: 0x06002992 RID: 10642 RVA: 0x0009CE0C File Offset: 0x0009B00C
			public global::Vis.Op accept
			{
				get
				{
					return (global::Vis.Op)this._[global::Vis.Rule.RegionSetup.s_apt];
				}
				set
				{
					this._[global::Vis.Rule.RegionSetup.s_apt] = (int)value;
				}
			}

			// Token: 0x17000922 RID: 2338
			// (get) Token: 0x06002993 RID: 10643 RVA: 0x0009CE20 File Offset: 0x0009B020
			// (set) Token: 0x06002994 RID: 10644 RVA: 0x0009CE34 File Offset: 0x0009B034
			public global::Vis.Op conditional
			{
				get
				{
					return (global::Vis.Op)this._[global::Vis.Rule.RegionSetup.s_cnd];
				}
				set
				{
					this._[global::Vis.Rule.RegionSetup.s_cnd] = (int)value;
				}
			}

			// Token: 0x17000923 RID: 2339
			// (get) Token: 0x06002995 RID: 10645 RVA: 0x0009CE48 File Offset: 0x0009B048
			// (set) Token: 0x06002996 RID: 10646 RVA: 0x0009CE5C File Offset: 0x0009B05C
			public global::Vis.Op reject
			{
				get
				{
					return (global::Vis.Op)this._[global::Vis.Rule.RegionSetup.s_rej];
				}
				set
				{
					this._[global::Vis.Rule.RegionSetup.s_rej] = (int)value;
				}
			}

			// Token: 0x17000924 RID: 2340
			// (get) Token: 0x06002997 RID: 10647 RVA: 0x0009CE70 File Offset: 0x0009B070
			// (set) Token: 0x06002998 RID: 10648 RVA: 0x0009CE84 File Offset: 0x0009B084
			public global::Vis.Region region
			{
				get
				{
					return (global::Vis.Region)this._[global::Vis.Rule.RegionSetup.s_region];
				}
				set
				{
					this._[global::Vis.Rule.RegionSetup.s_region] = (int)value;
				}
			}

			// Token: 0x17000925 RID: 2341
			public global::Vis.Op this[global::Vis.Rule.Step step]
			{
				get
				{
					switch (step)
					{
					case global::Vis.Rule.Step.Accept:
						return this.accept;
					case global::Vis.Rule.Step.Conditional:
						return this.conditional;
					case global::Vis.Rule.Step.Reject:
						return this.reject;
					default:
						throw new global::System.ArgumentOutOfRangeException("step");
					}
				}
				set
				{
					switch (step)
					{
					case global::Vis.Rule.Step.Accept:
						this.accept = value;
						break;
					case global::Vis.Rule.Step.Conditional:
						this.conditional = value;
						break;
					case global::Vis.Rule.Step.Reject:
						this.reject = value;
						break;
					default:
						throw new global::System.ArgumentOutOfRangeException("step");
					}
				}
			}

			// Token: 0x17000926 RID: 2342
			// (get) Token: 0x0600299B RID: 10651 RVA: 0x0009CF38 File Offset: 0x0009B138
			internal int dat
			{
				get
				{
					return this._[global::Vis.Rule.RegionSetup.s_whole];
				}
			}

			// Token: 0x040014C7 RID: 5319
			private static readonly global::System.Collections.Specialized.BitVector32.Section s_apt;

			// Token: 0x040014C8 RID: 5320
			private static readonly global::System.Collections.Specialized.BitVector32.Section s_cnd;

			// Token: 0x040014C9 RID: 5321
			private static readonly global::System.Collections.Specialized.BitVector32.Section s_rej;

			// Token: 0x040014CA RID: 5322
			private static readonly global::System.Collections.Specialized.BitVector32.Section s_whole;

			// Token: 0x040014CB RID: 5323
			private static readonly global::System.Collections.Specialized.BitVector32.Section s_region;

			// Token: 0x040014CC RID: 5324
			private global::System.Collections.Specialized.BitVector32 _;
		}

		// Token: 0x020004AD RID: 1197
		public struct StepSetup
		{
			// Token: 0x0600299C RID: 10652 RVA: 0x0009CF4C File Offset: 0x0009B14C
			internal StepSetup(int life, int stat, int role, int step, int enable)
			{
				this = default(global::Vis.Rule.StepSetup);
				this._[global::Vis.Rule.StepSetup.s_life] = life;
				this._[global::Vis.Rule.StepSetup.s_stat] = stat;
				this._[global::Vis.Rule.StepSetup.s_role] = role;
				this._[global::Vis.Rule.StepSetup.s_step] = step;
				this._[global::Vis.Rule.StepSetup.s_enable] = enable;
			}

			// Token: 0x0600299D RID: 10653 RVA: 0x0009CFC0 File Offset: 0x0009B1C0
			static StepSetup()
			{
				global::System.Collections.Specialized.BitVector32.Section previous = global::Vis.Rule.StepSetup.s_life = global::System.Collections.Specialized.BitVector32.CreateSection(7);
				previous = (global::Vis.Rule.StepSetup.s_step = global::System.Collections.Specialized.BitVector32.CreateSection(0xFF, previous));
				previous = (global::Vis.Rule.StepSetup.s_enable = global::System.Collections.Specialized.BitVector32.CreateSection(1, previous));
				previous = (global::Vis.Rule.StepSetup.s_stat = global::System.Collections.Specialized.BitVector32.CreateSection(7, previous));
				previous = global::System.Collections.Specialized.BitVector32.CreateSection(0x1FF, previous);
				global::Vis.Rule.StepSetup.s_role = global::System.Collections.Specialized.BitVector32.CreateSection(7, previous);
			}

			// Token: 0x17000927 RID: 2343
			// (get) Token: 0x0600299E RID: 10654 RVA: 0x0009D024 File Offset: 0x0009B224
			// (set) Token: 0x0600299F RID: 10655 RVA: 0x0009D038 File Offset: 0x0009B238
			public global::Vis.Op life
			{
				get
				{
					return (global::Vis.Op)this._[global::Vis.Rule.StepSetup.s_life];
				}
				set
				{
					this._[global::Vis.Rule.StepSetup.s_life] = (int)value;
				}
			}

			// Token: 0x17000928 RID: 2344
			// (get) Token: 0x060029A0 RID: 10656 RVA: 0x0009D04C File Offset: 0x0009B24C
			// (set) Token: 0x060029A1 RID: 10657 RVA: 0x0009D060 File Offset: 0x0009B260
			public global::Vis.Op stat
			{
				get
				{
					return (global::Vis.Op)this._[global::Vis.Rule.StepSetup.s_stat];
				}
				set
				{
					this._[global::Vis.Rule.StepSetup.s_stat] = (int)value;
				}
			}

			// Token: 0x17000929 RID: 2345
			// (get) Token: 0x060029A2 RID: 10658 RVA: 0x0009D074 File Offset: 0x0009B274
			// (set) Token: 0x060029A3 RID: 10659 RVA: 0x0009D088 File Offset: 0x0009B288
			public global::Vis.Op role
			{
				get
				{
					return (global::Vis.Op)this._[global::Vis.Rule.StepSetup.s_role];
				}
				set
				{
					this._[global::Vis.Rule.StepSetup.s_role] = (int)value;
				}
			}

			// Token: 0x1700092A RID: 2346
			// (get) Token: 0x060029A4 RID: 10660 RVA: 0x0009D09C File Offset: 0x0009B29C
			// (set) Token: 0x060029A5 RID: 10661 RVA: 0x0009D0B0 File Offset: 0x0009B2B0
			public global::Vis.Rule.Step step
			{
				get
				{
					return (global::Vis.Rule.Step)this._[global::Vis.Rule.StepSetup.s_step];
				}
				set
				{
					this._[global::Vis.Rule.StepSetup.s_step] = (int)value;
				}
			}

			// Token: 0x1700092B RID: 2347
			// (get) Token: 0x060029A6 RID: 10662 RVA: 0x0009D0C4 File Offset: 0x0009B2C4
			// (set) Token: 0x060029A7 RID: 10663 RVA: 0x0009D0DC File Offset: 0x0009B2DC
			public bool enabled
			{
				get
				{
					return this._[global::Vis.Rule.StepSetup.s_enable] != 0;
				}
				set
				{
					this._[global::Vis.Rule.StepSetup.s_enable] = ((!value) ? 0 : 1);
				}
			}

			// Token: 0x1700092C RID: 2348
			public global::Vis.Op this[global::Vis.Region region]
			{
				get
				{
					switch (region)
					{
					case global::Vis.Region.Life:
						return this.life;
					case global::Vis.Region.Status:
						return this.stat;
					case global::Vis.Region.Role:
						return this.role;
					default:
						throw new global::System.ArgumentOutOfRangeException("region");
					}
				}
				set
				{
					switch (region)
					{
					case global::Vis.Region.Life:
						this.life = value;
						break;
					case global::Vis.Region.Status:
						this.stat = value;
						break;
					case global::Vis.Region.Role:
						this.role = value;
						break;
					default:
						throw new global::System.ArgumentOutOfRangeException("region");
					}
				}
			}

			// Token: 0x040014CD RID: 5325
			private static readonly global::System.Collections.Specialized.BitVector32.Section s_life;

			// Token: 0x040014CE RID: 5326
			private static readonly global::System.Collections.Specialized.BitVector32.Section s_stat;

			// Token: 0x040014CF RID: 5327
			private static readonly global::System.Collections.Specialized.BitVector32.Section s_role;

			// Token: 0x040014D0 RID: 5328
			private static readonly global::System.Collections.Specialized.BitVector32.Section s_step;

			// Token: 0x040014D1 RID: 5329
			private static readonly global::System.Collections.Specialized.BitVector32.Section s_enable;

			// Token: 0x040014D2 RID: 5330
			private global::System.Collections.Specialized.BitVector32 _;
		}

		// Token: 0x020004AE RID: 1198
		public struct StepCheck
		{
			// Token: 0x060029AA RID: 10666 RVA: 0x0009D19C File Offset: 0x0009B39C
			internal StepCheck(int i)
			{
				this.bits = (byte)i;
			}

			// Token: 0x1700092D RID: 2349
			// (get) Token: 0x060029AB RID: 10667 RVA: 0x0009D1A8 File Offset: 0x0009B3A8
			// (set) Token: 0x060029AC RID: 10668 RVA: 0x0009D1B8 File Offset: 0x0009B3B8
			public bool accept
			{
				get
				{
					return (this.bits & 1) == 1;
				}
				set
				{
					this.bits = ((!value) ? (this.bits & 6) : (this.bits | 1));
				}
			}

			// Token: 0x1700092E RID: 2350
			// (get) Token: 0x060029AD RID: 10669 RVA: 0x0009D1E8 File Offset: 0x0009B3E8
			// (set) Token: 0x060029AE RID: 10670 RVA: 0x0009D1F8 File Offset: 0x0009B3F8
			public bool conditional
			{
				get
				{
					return (this.bits & 2) == 2;
				}
				set
				{
					this.bits = ((!value) ? (this.bits & 5) : (this.bits | 2));
				}
			}

			// Token: 0x1700092F RID: 2351
			// (get) Token: 0x060029AF RID: 10671 RVA: 0x0009D228 File Offset: 0x0009B428
			// (set) Token: 0x060029B0 RID: 10672 RVA: 0x0009D238 File Offset: 0x0009B438
			public bool reject
			{
				get
				{
					return (this.bits & 4) == 4;
				}
				set
				{
					this.bits = ((!value) ? (this.bits & 3) : (this.bits | 4));
				}
			}

			// Token: 0x17000930 RID: 2352
			// (get) Token: 0x060029B1 RID: 10673 RVA: 0x0009D268 File Offset: 0x0009B468
			internal int value
			{
				get
				{
					return (int)this.bits;
				}
			}

			// Token: 0x17000931 RID: 2353
			public bool this[global::Vis.Rule.Step step]
			{
				get
				{
					switch (step)
					{
					case global::Vis.Rule.Step.Accept:
						return this.accept;
					case global::Vis.Rule.Step.Conditional:
						return this.conditional;
					case global::Vis.Rule.Step.Reject:
						return this.reject;
					default:
						throw new global::System.ArgumentOutOfRangeException("step");
					}
				}
				set
				{
					switch (step)
					{
					case global::Vis.Rule.Step.Accept:
						this.accept = value;
						break;
					case global::Vis.Rule.Step.Conditional:
						this.conditional = value;
						break;
					case global::Vis.Rule.Step.Reject:
						this.reject = value;
						break;
					default:
						throw new global::System.ArgumentOutOfRangeException("step");
					}
				}
			}

			// Token: 0x040014D3 RID: 5331
			private byte bits;
		}

		// Token: 0x020004AF RID: 1199
		public struct Setup
		{
			// Token: 0x060029B4 RID: 10676 RVA: 0x0009D310 File Offset: 0x0009B510
			static Setup()
			{
				global::System.Collections.Specialized.BitVector32.Section previous = global::Vis.Rule.Setup.s_life = global::System.Collections.Specialized.BitVector32.CreateSection(0x1FF);
				previous = (global::Vis.Rule.Setup.s_stat = global::System.Collections.Specialized.BitVector32.CreateSection(0x1FF, previous));
				previous = (global::Vis.Rule.Setup.s_role = global::System.Collections.Specialized.BitVector32.CreateSection(0x1FF, previous));
				previous = (global::Vis.Rule.Setup.s_options = global::System.Collections.Specialized.BitVector32.CreateSection(3, previous));
				global::Vis.Rule.Setup.s_check = global::System.Collections.Specialized.BitVector32.CreateSection(7, previous);
				global::Vis.Rule.Setup.s_life_ = new global::System.Collections.Specialized.BitVector32.Section[3];
				global::Vis.Rule.Setup.s_stat_ = new global::System.Collections.Specialized.BitVector32.Section[3];
				global::Vis.Rule.Setup.s_role_ = new global::System.Collections.Specialized.BitVector32.Section[3];
				global::Vis.Rule.Setup.s_check_ = new global::System.Collections.Specialized.BitVector32.Section[3];
				int i = 0;
				global::Vis.Rule.Setup.s_life_[i] = global::System.Collections.Specialized.BitVector32.CreateSection(7);
				global::Vis.Rule.Setup.s_stat_[i] = global::System.Collections.Specialized.BitVector32.CreateSection(7, global::Vis.Rule.Setup.s_life);
				global::Vis.Rule.Setup.s_role_[i] = global::System.Collections.Specialized.BitVector32.CreateSection(7, global::Vis.Rule.Setup.s_stat);
				global::Vis.Rule.Setup.s_check_[i] = global::System.Collections.Specialized.BitVector32.CreateSection(1, global::Vis.Rule.Setup.s_options);
				for (i++; i < 3; i++)
				{
					global::Vis.Rule.Setup.s_life_[i] = global::System.Collections.Specialized.BitVector32.CreateSection(7, global::Vis.Rule.Setup.s_life_[i - 1]);
					global::Vis.Rule.Setup.s_stat_[i] = global::System.Collections.Specialized.BitVector32.CreateSection(7, global::Vis.Rule.Setup.s_stat_[i - 1]);
					global::Vis.Rule.Setup.s_role_[i] = global::System.Collections.Specialized.BitVector32.CreateSection(7, global::Vis.Rule.Setup.s_role_[i - 1]);
					global::Vis.Rule.Setup.s_check_[i] = global::System.Collections.Specialized.BitVector32.CreateSection(1, global::Vis.Rule.Setup.s_check_[i - 1]);
				}
			}

			// Token: 0x17000932 RID: 2354
			// (get) Token: 0x060029B5 RID: 10677 RVA: 0x0009D4B8 File Offset: 0x0009B6B8
			// (set) Token: 0x060029B6 RID: 10678 RVA: 0x0009D4D0 File Offset: 0x0009B6D0
			public global::Vis.Rule.RegionSetup life
			{
				get
				{
					return new global::Vis.Rule.RegionSetup(this._[global::Vis.Rule.Setup.s_life], global::Vis.Region.Life);
				}
				set
				{
					this._[global::Vis.Rule.Setup.s_life] = value.dat;
				}
			}

			// Token: 0x17000933 RID: 2355
			// (get) Token: 0x060029B7 RID: 10679 RVA: 0x0009D4EC File Offset: 0x0009B6EC
			// (set) Token: 0x060029B8 RID: 10680 RVA: 0x0009D504 File Offset: 0x0009B704
			public global::Vis.Rule.RegionSetup stat
			{
				get
				{
					return new global::Vis.Rule.RegionSetup(this._[global::Vis.Rule.Setup.s_stat], global::Vis.Region.Status);
				}
				set
				{
					this._[global::Vis.Rule.Setup.s_stat] = value.dat;
				}
			}

			// Token: 0x17000934 RID: 2356
			// (get) Token: 0x060029B9 RID: 10681 RVA: 0x0009D520 File Offset: 0x0009B720
			// (set) Token: 0x060029BA RID: 10682 RVA: 0x0009D538 File Offset: 0x0009B738
			public global::Vis.Rule.RegionSetup role
			{
				get
				{
					return new global::Vis.Rule.RegionSetup(this._[global::Vis.Rule.Setup.s_role], global::Vis.Region.Role);
				}
				set
				{
					this._[global::Vis.Rule.Setup.s_role] = value.dat;
				}
			}

			// Token: 0x060029BB RID: 10683 RVA: 0x0009D554 File Offset: 0x0009B754
			private global::Vis.Rule.StepSetup Get(int i)
			{
				return new global::Vis.Rule.StepSetup(this._[global::Vis.Rule.Setup.s_life_[i]], this._[global::Vis.Rule.Setup.s_stat_[i]], this._[global::Vis.Rule.Setup.s_role_[i]], i, this._[global::Vis.Rule.Setup.s_check_[i]]);
			}

			// Token: 0x060029BC RID: 10684 RVA: 0x0009D5D4 File Offset: 0x0009B7D4
			private void Set(int i, global::Vis.Rule.StepSetup step)
			{
				this._[global::Vis.Rule.Setup.s_life_[i]] = (int)(step.life & (global::Vis.Op)global::Vis.Rule.Setup.s_life_[i].Mask);
				this._[global::Vis.Rule.Setup.s_stat_[i]] = (int)(step.stat & (global::Vis.Op)global::Vis.Rule.Setup.s_stat_[i].Mask);
				this._[global::Vis.Rule.Setup.s_role_[i]] = (int)(step.role & (global::Vis.Op)global::Vis.Rule.Setup.s_role_[i].Mask);
				this._[global::Vis.Rule.Setup.s_check_[i]] = ((!step.enabled) ? 0 : 1);
			}

			// Token: 0x17000935 RID: 2357
			// (get) Token: 0x060029BD RID: 10685 RVA: 0x0009D6A8 File Offset: 0x0009B8A8
			// (set) Token: 0x060029BE RID: 10686 RVA: 0x0009D6B4 File Offset: 0x0009B8B4
			public global::Vis.Rule.StepSetup accept
			{
				get
				{
					return this.Get(0);
				}
				set
				{
					this.Set(0, value);
				}
			}

			// Token: 0x17000936 RID: 2358
			// (get) Token: 0x060029BF RID: 10687 RVA: 0x0009D6C0 File Offset: 0x0009B8C0
			// (set) Token: 0x060029C0 RID: 10688 RVA: 0x0009D6CC File Offset: 0x0009B8CC
			public global::Vis.Rule.StepSetup conditional
			{
				get
				{
					return this.Get(1);
				}
				set
				{
					this.Set(1, value);
				}
			}

			// Token: 0x17000937 RID: 2359
			// (get) Token: 0x060029C1 RID: 10689 RVA: 0x0009D6D8 File Offset: 0x0009B8D8
			// (set) Token: 0x060029C2 RID: 10690 RVA: 0x0009D6E4 File Offset: 0x0009B8E4
			public global::Vis.Rule.StepSetup reject
			{
				get
				{
					return this.Get(2);
				}
				set
				{
					this.Set(2, value);
				}
			}

			// Token: 0x17000938 RID: 2360
			public global::Vis.Rule.RegionSetup this[global::Vis.Region region]
			{
				get
				{
					switch (region)
					{
					case global::Vis.Region.Life:
						return this.life;
					case global::Vis.Region.Status:
						return this.stat;
					case global::Vis.Region.Role:
						return this.role;
					default:
						throw new global::System.ArgumentOutOfRangeException("region");
					}
				}
				set
				{
					switch (region)
					{
					case global::Vis.Region.Life:
						this.life = value;
						break;
					case global::Vis.Region.Status:
						this.stat = value;
						break;
					case global::Vis.Region.Role:
						this.role = value;
						break;
					default:
						throw new global::System.ArgumentOutOfRangeException("region");
					}
				}
			}

			// Token: 0x17000939 RID: 2361
			public global::Vis.Rule.StepSetup this[global::Vis.Rule.Step step]
			{
				get
				{
					switch (step)
					{
					case global::Vis.Rule.Step.Accept:
						return this.accept;
					case global::Vis.Rule.Step.Conditional:
						return this.conditional;
					case global::Vis.Rule.Step.Reject:
						return this.reject;
					default:
						throw new global::System.ArgumentOutOfRangeException("step");
					}
				}
				set
				{
					switch (step)
					{
					case global::Vis.Rule.Step.Accept:
						this.accept = value;
						break;
					case global::Vis.Rule.Step.Conditional:
						this.conditional = value;
						break;
					case global::Vis.Rule.Step.Reject:
						this.reject = value;
						break;
					default:
						throw new global::System.ArgumentOutOfRangeException("step");
					}
				}
			}

			// Token: 0x1700093A RID: 2362
			// (get) Token: 0x060029C7 RID: 10695 RVA: 0x0009D830 File Offset: 0x0009BA30
			// (set) Token: 0x060029C8 RID: 10696 RVA: 0x0009D844 File Offset: 0x0009BA44
			public global::Vis.Rule.Setup.Option option
			{
				get
				{
					return (global::Vis.Rule.Setup.Option)this._[global::Vis.Rule.Setup.s_options];
				}
				set
				{
					this._[global::Vis.Rule.Setup.s_options] = (int)value;
				}
			}

			// Token: 0x1700093B RID: 2363
			// (get) Token: 0x060029C9 RID: 10697 RVA: 0x0009D858 File Offset: 0x0009BA58
			// (set) Token: 0x060029CA RID: 10698 RVA: 0x0009D870 File Offset: 0x0009BA70
			public global::Vis.Rule.StepCheck check
			{
				get
				{
					return new global::Vis.Rule.StepCheck(this._[global::Vis.Rule.Setup.s_check]);
				}
				set
				{
					this._[global::Vis.Rule.Setup.s_check] = value.value;
				}
			}

			// Token: 0x1700093C RID: 2364
			// (get) Token: 0x060029CB RID: 10699 RVA: 0x0009D88C File Offset: 0x0009BA8C
			// (set) Token: 0x060029CC RID: 10700 RVA: 0x0009D8B0 File Offset: 0x0009BAB0
			public bool checkAccept
			{
				get
				{
					return this._[global::Vis.Rule.Setup.s_check_[0]] != 0;
				}
				set
				{
					this._[global::Vis.Rule.Setup.s_check_[0]] = ((!value) ? 0 : 1);
				}
			}

			// Token: 0x1700093D RID: 2365
			// (get) Token: 0x060029CD RID: 10701 RVA: 0x0009D8E8 File Offset: 0x0009BAE8
			// (set) Token: 0x060029CE RID: 10702 RVA: 0x0009D90C File Offset: 0x0009BB0C
			public bool checkConditional
			{
				get
				{
					return this._[global::Vis.Rule.Setup.s_check_[1]] != 0;
				}
				set
				{
					this._[global::Vis.Rule.Setup.s_check_[1]] = ((!value) ? 0 : 1);
				}
			}

			// Token: 0x1700093E RID: 2366
			// (get) Token: 0x060029CF RID: 10703 RVA: 0x0009D944 File Offset: 0x0009BB44
			// (set) Token: 0x060029D0 RID: 10704 RVA: 0x0009D968 File Offset: 0x0009BB68
			public bool checkReject
			{
				get
				{
					return this._[global::Vis.Rule.Setup.s_check_[2]] != 0;
				}
				set
				{
					this._[global::Vis.Rule.Setup.s_check_[2]] = ((!value) ? 0 : 1);
				}
			}

			// Token: 0x060029D1 RID: 10705 RVA: 0x0009D9A0 File Offset: 0x0009BBA0
			public void SetSetup(global::Vis.Rule.RegionSetup operations)
			{
				this[operations.region] = operations;
			}

			// Token: 0x060029D2 RID: 10706 RVA: 0x0009D9B0 File Offset: 0x0009BBB0
			public void SetSetup(global::Vis.Rule.StepSetup operations)
			{
				this[operations.step] = operations;
			}

			// Token: 0x1700093F RID: 2367
			// (get) Token: 0x060029D3 RID: 10707 RVA: 0x0009D9C0 File Offset: 0x0009BBC0
			// (set) Token: 0x060029D4 RID: 10708 RVA: 0x0009D9D0 File Offset: 0x0009BBD0
			internal int data
			{
				get
				{
					return this._.Data;
				}
				set
				{
					this._ = new global::System.Collections.Specialized.BitVector32(value);
				}
			}

			// Token: 0x040014D4 RID: 5332
			private static readonly global::System.Collections.Specialized.BitVector32.Section s_life;

			// Token: 0x040014D5 RID: 5333
			private static readonly global::System.Collections.Specialized.BitVector32.Section[] s_life_;

			// Token: 0x040014D6 RID: 5334
			private static readonly global::System.Collections.Specialized.BitVector32.Section s_stat;

			// Token: 0x040014D7 RID: 5335
			private static readonly global::System.Collections.Specialized.BitVector32.Section[] s_stat_;

			// Token: 0x040014D8 RID: 5336
			private static readonly global::System.Collections.Specialized.BitVector32.Section s_role;

			// Token: 0x040014D9 RID: 5337
			private static readonly global::System.Collections.Specialized.BitVector32.Section[] s_role_;

			// Token: 0x040014DA RID: 5338
			private static readonly global::System.Collections.Specialized.BitVector32.Section s_options;

			// Token: 0x040014DB RID: 5339
			private static readonly global::System.Collections.Specialized.BitVector32.Section s_check;

			// Token: 0x040014DC RID: 5340
			private static readonly global::System.Collections.Specialized.BitVector32.Section[] s_check_;

			// Token: 0x040014DD RID: 5341
			private global::System.Collections.Specialized.BitVector32 _;

			// Token: 0x020004B0 RID: 1200
			public enum Option
			{
				// Token: 0x040014DF RID: 5343
				Default,
				// Token: 0x040014E0 RID: 5344
				Inverse,
				// Token: 0x040014E1 RID: 5345
				NoConditional,
				// Token: 0x040014E2 RID: 5346
				AllConditional
			}
		}

		// Token: 0x020004B1 RID: 1201
		[global::System.Flags]
		public enum Failure
		{
			// Token: 0x040014E4 RID: 5348
			None = 0,
			// Token: 0x040014E5 RID: 5349
			Accept = 1,
			// Token: 0x040014E6 RID: 5350
			Conditional = 2,
			// Token: 0x040014E7 RID: 5351
			Reject = 4,
			// Token: 0x040014E8 RID: 5352
			Life = 8,
			// Token: 0x040014E9 RID: 5353
			Role = 0x10,
			// Token: 0x040014EA RID: 5354
			Status = 0x20
		}
	}

	// Token: 0x020004B2 RID: 1202
	public struct Stamp
	{
		// Token: 0x060029D5 RID: 10709 RVA: 0x0009D9E0 File Offset: 0x0009BBE0
		public Stamp(global::UnityEngine.Transform transform)
		{
			this.position = transform.position;
			this.rotation = transform.rotation;
			global::UnityEngine.Vector3 forward = transform.forward;
			this.plane.x = forward.x;
			this.plane.y = forward.y;
			this.plane.z = forward.z;
			this.plane.w = this.position.x * this.plane.x + this.position.y * this.plane.y + this.position.z * this.plane.z;
		}

		// Token: 0x17000940 RID: 2368
		// (get) Token: 0x060029D6 RID: 10710 RVA: 0x0009DA94 File Offset: 0x0009BC94
		public global::UnityEngine.Vector3 forward
		{
			get
			{
				return new global::UnityEngine.Vector3(this.plane.x, this.plane.y, this.plane.z);
			}
		}

		// Token: 0x060029D7 RID: 10711 RVA: 0x0009DAC8 File Offset: 0x0009BCC8
		public void Collect(global::UnityEngine.Transform transform)
		{
			this.position = transform.position;
			this.rotation = transform.rotation;
			global::UnityEngine.Vector3 forward = transform.forward;
			this.plane.x = forward.x;
			this.plane.y = forward.y;
			this.plane.z = forward.z;
			this.plane.w = this.position.x * this.forward.x + this.position.y * this.forward.y + this.position.z * this.forward.z;
		}

		// Token: 0x040014EB RID: 5355
		public global::UnityEngine.Vector3 position;

		// Token: 0x040014EC RID: 5356
		public global::UnityEngine.Vector4 plane;

		// Token: 0x040014ED RID: 5357
		public global::UnityEngine.Quaternion rotation;
	}
}
