using System;
using Facepunch.Build;
using Facepunch.Hash;
using uLink;
using UnityEngine;

// Token: 0x020006C0 RID: 1728
[global::Facepunch.Build.UniqueBundleScriptableObject]
public class Datablock : global::UnityEngine.ScriptableObject, global::System.IComparable<global::Datablock>
{
	// Token: 0x06003AFD RID: 15101 RVA: 0x000D1B7C File Offset: 0x000CFD7C
	public Datablock()
	{
	}

	// Token: 0x17000B14 RID: 2836
	// (get) Token: 0x06003AFE RID: 15102 RVA: 0x000D1B84 File Offset: 0x000CFD84
	public int uniqueID
	{
		get
		{
			return this._uniqueID;
		}
	}

	// Token: 0x06003AFF RID: 15103 RVA: 0x000D1B8C File Offset: 0x000CFD8C
	public override int GetHashCode()
	{
		return this._uniqueID;
	}

	// Token: 0x06003B00 RID: 15104 RVA: 0x000D1B94 File Offset: 0x000CFD94
	public int CompareTo(global::Datablock other)
	{
		if (object.ReferenceEquals(other, this))
		{
			return 0;
		}
		if (!other)
		{
			return -1;
		}
		int num = this._uniqueID.CompareTo(other._uniqueID);
		if (num == 0)
		{
			return base.name.CompareTo(other.name);
		}
		return num;
	}

	// Token: 0x06003B01 RID: 15105 RVA: 0x000D1BE8 File Offset: 0x000CFDE8
	protected virtual void SecureWriteMemberValues(global::uLink.BitStream stream)
	{
		stream.WriteInt32(this._uniqueID);
	}

	// Token: 0x06003B02 RID: 15106 RVA: 0x000D1BF8 File Offset: 0x000CFDF8
	public uint SecureHash()
	{
		return this.SecureHash(0U);
	}

	// Token: 0x06003B03 RID: 15107 RVA: 0x000D1C04 File Offset: 0x000CFE04
	public uint SecureHash(uint seed)
	{
		global::uLink.BitStream stream = new global::uLink.BitStream(true);
		try
		{
			this.SecureWriteMemberValues(stream);
		}
		catch (global::System.Exception ex)
		{
			global::UnityEngine.Debug.LogException(ex);
		}
		return global::Facepunch.Hash.MurmurHash2.UINT(stream.GetDataByteArray(), seed);
	}

	// Token: 0x04001E37 RID: 7735
	[global::UnityEngine.HideInInspector]
	[global::UnityEngine.SerializeField]
	private int _uniqueID;

	// Token: 0x020006C1 RID: 1729
	public struct Ident : global::System.IEquatable<global::Datablock.Ident>, global::System.IEquatable<global::Datablock>
	{
		// Token: 0x06003B04 RID: 15108 RVA: 0x000D1C58 File Offset: 0x000CFE58
		private Ident(object refValue, int uniqueID, byte type_f)
		{
			this.refValue = refValue;
			this.uid = uniqueID;
			this.type_f = type_f;
		}

		// Token: 0x06003B05 RID: 15109 RVA: 0x000D1C70 File Offset: 0x000CFE70
		private Ident(object referenceValue, bool isNull, byte type)
		{
			if (isNull)
			{
				this = default(global::Datablock.Ident);
			}
			else
			{
				this.refValue = referenceValue;
				this.uid = 0;
				this.type_f = type;
			}
		}

		// Token: 0x06003B06 RID: 15110 RVA: 0x000D1CAC File Offset: 0x000CFEAC
		private Ident(object referenceValue, byte type)
		{
			this = new global::Datablock.Ident(referenceValue, !object.ReferenceEquals(referenceValue, null), type);
		}

		// Token: 0x06003B07 RID: 15111 RVA: 0x000D1CC0 File Offset: 0x000CFEC0
		private Ident(global::Datablock db)
		{
			this = new global::Datablock.Ident(db, db, 0x81);
		}

		// Token: 0x06003B08 RID: 15112 RVA: 0x000D1CD4 File Offset: 0x000CFED4
		private Ident(global::InventoryItem item)
		{
			this = new global::Datablock.Ident(item, 0x82);
		}

		// Token: 0x06003B09 RID: 15113 RVA: 0x000D1CE4 File Offset: 0x000CFEE4
		private Ident(string name)
		{
			this = new global::Datablock.Ident(name, string.IsNullOrEmpty(name), 0x83);
		}

		// Token: 0x06003B0A RID: 15114 RVA: 0x000D1CF8 File Offset: 0x000CFEF8
		private Ident(int uniqueID)
		{
			this.refValue = null;
			this.type_f = 0x84;
			this.uid = uniqueID;
		}

		// Token: 0x06003B0B RID: 15115 RVA: 0x000D1D14 File Offset: 0x000CFF14
		private void Confirm()
		{
			global::Datablock datablock;
			switch (this.type_f & 0x7F)
			{
			case 1:
				datablock = (global::Datablock)this.refValue;
				break;
			case 2:
				datablock = ((global::InventoryItem)this.refValue).datablock;
				break;
			case 3:
				datablock = global::DatablockDictionary.GetByName((string)this.refValue);
				break;
			case 4:
				datablock = global::DatablockDictionary.GetByUniqueID(this.uid);
				break;
			default:
				this = default(global::Datablock.Ident);
				return;
			}
			if (datablock)
			{
				this = new global::Datablock.Ident(datablock, datablock.uniqueID, 1);
			}
			else
			{
				this = default(global::Datablock.Ident);
			}
		}

		// Token: 0x06003B0C RID: 15116 RVA: 0x000D1DD4 File Offset: 0x000CFFD4
		public override int GetHashCode()
		{
			return this.uid;
		}

		// Token: 0x17000B15 RID: 2837
		// (get) Token: 0x06003B0D RID: 15117 RVA: 0x000D1DDC File Offset: 0x000CFFDC
		public global::Datablock datablock
		{
			get
			{
				if ((this.type_f & 0x80) == 0x80)
				{
					this.Confirm();
				}
				return (global::Datablock)this.refValue;
			}
		}

		// Token: 0x17000B16 RID: 2838
		// (get) Token: 0x06003B0E RID: 15118 RVA: 0x000D1E08 File Offset: 0x000D0008
		public int uniqueID
		{
			get
			{
				if ((this.type_f & 0x80) == 0x80)
				{
					this.Confirm();
				}
				return this.uid;
			}
		}

		// Token: 0x17000B17 RID: 2839
		// (get) Token: 0x06003B0F RID: 15119 RVA: 0x000D1E38 File Offset: 0x000D0038
		public int? uniqueIDIfExists
		{
			get
			{
				if ((this.type_f & 0x80) == 0x80)
				{
					this.Confirm();
				}
				if (this.type_f != 0)
				{
					return new int?(this.uid);
				}
				return null;
			}
		}

		// Token: 0x17000B18 RID: 2840
		// (get) Token: 0x06003B10 RID: 15120 RVA: 0x000D1E84 File Offset: 0x000D0084
		public bool exists
		{
			get
			{
				if ((this.type_f & 0x80) == 0x80)
				{
					this.Confirm();
				}
				return this.type_f != 0 && (global::Datablock)this.refValue;
			}
		}

		// Token: 0x17000B19 RID: 2841
		// (get) Token: 0x06003B11 RID: 15121 RVA: 0x000D1ECC File Offset: 0x000D00CC
		public string name
		{
			get
			{
				if ((this.type_f & 0x80) == 0x80)
				{
					this.Confirm();
				}
				if (this.type_f != 1)
				{
					return string.Empty;
				}
				global::Datablock datablock = (global::Datablock)this.refValue;
				if (datablock)
				{
					return datablock.name;
				}
				return string.Empty;
			}
		}

		// Token: 0x06003B12 RID: 15122 RVA: 0x000D1F2C File Offset: 0x000D012C
		public bool Equals(global::Datablock.Ident other)
		{
			if ((this.type_f & 0x80) == 0x80)
			{
				this.Confirm();
			}
			if ((other.type_f & 0x80) == 0x80)
			{
				other.Confirm();
			}
			return object.Equals(this.refValue, other.refValue);
		}

		// Token: 0x06003B13 RID: 15123 RVA: 0x000D1F88 File Offset: 0x000D0188
		public bool Equals(global::Datablock datablock)
		{
			if ((this.type_f & 0x80) == 0x80)
			{
				this.Confirm();
			}
			return object.Equals(this.refValue, datablock);
		}

		// Token: 0x06003B14 RID: 15124 RVA: 0x000D1FC0 File Offset: 0x000D01C0
		public override bool Equals(object obj)
		{
			if (obj is global::Datablock.Ident)
			{
				return this.Equals((global::Datablock.Ident)obj);
			}
			return obj is global::Datablock && this.Equals((global::Datablock)obj);
		}

		// Token: 0x06003B15 RID: 15125 RVA: 0x000D1FF4 File Offset: 0x000D01F4
		public override string ToString()
		{
			if ((this.type_f & 0x80) == 0x80)
			{
				this.Confirm();
			}
			global::Datablock datablock;
			return (this.type_f != 0 && (datablock = (global::Datablock)this.refValue)) ? datablock.name : "null";
		}

		// Token: 0x06003B16 RID: 15126 RVA: 0x000D2050 File Offset: 0x000D0250
		public bool GetDatablock(out global::Datablock datablock)
		{
			if ((this.type_f & 0x80) == 0x80)
			{
				this.Confirm();
			}
			if (this.type_f == 0)
			{
				datablock = null;
				return false;
			}
			datablock = (global::Datablock)this.refValue;
			return datablock;
		}

		// Token: 0x06003B17 RID: 15127 RVA: 0x000D20A0 File Offset: 0x000D02A0
		public bool GetDatablock<TDatablock>(out TDatablock datablock) where TDatablock : global::Datablock
		{
			if ((this.type_f & 0x80) == 0x80)
			{
				this.Confirm();
			}
			if (this.type_f == 0)
			{
				datablock = (TDatablock)((object)null);
				return false;
			}
			datablock = (((global::Datablock)this.refValue) as TDatablock);
			return datablock;
		}

		// Token: 0x06003B18 RID: 15128 RVA: 0x000D2110 File Offset: 0x000D0310
		public global::Datablock GetDatablock()
		{
			if ((this.type_f & 0x80) == 0x80)
			{
				this.Confirm();
			}
			if (this.type_f == 0)
			{
				return null;
			}
			return (global::Datablock)this.refValue;
		}

		// Token: 0x06003B19 RID: 15129 RVA: 0x000D2154 File Offset: 0x000D0354
		public global::Datablock GetDatablock<TDatablock>() where TDatablock : global::Datablock
		{
			if ((this.type_f & 0x80) == 0x80)
			{
				this.Confirm();
			}
			if (this.type_f == 0)
			{
				throw new global::UnityEngine.MissingReferenceException("this identifier is not valid");
			}
			return (TDatablock)((object)this.refValue);
		}

		// Token: 0x06003B1A RID: 15130 RVA: 0x000D21A4 File Offset: 0x000D03A4
		public static implicit operator global::Datablock.Ident(string dbName)
		{
			return new global::Datablock.Ident(dbName);
		}

		// Token: 0x06003B1B RID: 15131 RVA: 0x000D21AC File Offset: 0x000D03AC
		public static implicit operator global::Datablock.Ident(int dbHash)
		{
			return new global::Datablock.Ident(dbHash);
		}

		// Token: 0x06003B1C RID: 15132 RVA: 0x000D21B4 File Offset: 0x000D03B4
		public static implicit operator global::Datablock.Ident(uint dbHash)
		{
			return new global::Datablock.Ident((int)dbHash);
		}

		// Token: 0x06003B1D RID: 15133 RVA: 0x000D21BC File Offset: 0x000D03BC
		[global::System.Obsolete("Make sure your wanting to get a dbhash from a ushort here.")]
		public static implicit operator global::Datablock.Ident(ushort dbHash)
		{
			return new global::Datablock.Ident((int)dbHash);
		}

		// Token: 0x06003B1E RID: 15134 RVA: 0x000D21C4 File Offset: 0x000D03C4
		[global::System.Obsolete("Make sure your wanting to get a dbhash from a short here.")]
		public static implicit operator global::Datablock.Ident(short dbHash)
		{
			return new global::Datablock.Ident((int)dbHash);
		}

		// Token: 0x06003B1F RID: 15135 RVA: 0x000D21CC File Offset: 0x000D03CC
		[global::System.Obsolete("Make sure your wanting to get a dbhash from a byte here.")]
		public static implicit operator global::Datablock.Ident(byte dbHash)
		{
			return new global::Datablock.Ident((int)dbHash);
		}

		// Token: 0x06003B20 RID: 15136 RVA: 0x000D21D4 File Offset: 0x000D03D4
		[global::System.Obsolete("Make sure your wanting to get a dbhash from a sbyte here.")]
		public static implicit operator global::Datablock.Ident(sbyte dbHash)
		{
			return new global::Datablock.Ident((int)dbHash);
		}

		// Token: 0x06003B21 RID: 15137 RVA: 0x000D21E0 File Offset: 0x000D03E0
		public static explicit operator global::Datablock.Ident(ulong dbHash)
		{
			uint uniqueID = (uint)dbHash;
			return new global::Datablock.Ident((int)uniqueID);
		}

		// Token: 0x06003B22 RID: 15138 RVA: 0x000D21F8 File Offset: 0x000D03F8
		public static explicit operator global::Datablock.Ident(long dbHash)
		{
			int uniqueID = (int)dbHash;
			return new global::Datablock.Ident(uniqueID);
		}

		// Token: 0x06003B23 RID: 15139 RVA: 0x000D2210 File Offset: 0x000D0410
		public static explicit operator global::Datablock.Ident(global::InventoryItem item)
		{
			return new global::Datablock.Ident(item);
		}

		// Token: 0x06003B24 RID: 15140 RVA: 0x000D2218 File Offset: 0x000D0418
		public static explicit operator global::Datablock.Ident(global::Datablock db)
		{
			if (db)
			{
				return new global::Datablock.Ident(db, db.uniqueID, 1);
			}
			return default(global::Datablock.Ident);
		}

		// Token: 0x06003B25 RID: 15141 RVA: 0x000D2248 File Offset: 0x000D0448
		public static global::Datablock.Ident operator +(global::Datablock.Ident ident)
		{
			if ((ident.type_f & 0x80) == 0x80)
			{
				ident.Confirm();
			}
			return ident;
		}

		// Token: 0x06003B26 RID: 15142 RVA: 0x000D226C File Offset: 0x000D046C
		public static bool operator ==(global::Datablock.Ident ident, global::Datablock.Ident other)
		{
			return ident.Equals(other);
		}

		// Token: 0x06003B27 RID: 15143 RVA: 0x000D2278 File Offset: 0x000D0478
		public static bool operator !=(global::Datablock.Ident ident, global::Datablock.Ident other)
		{
			return !ident.Equals(other);
		}

		// Token: 0x06003B28 RID: 15144 RVA: 0x000D2288 File Offset: 0x000D0488
		public static bool operator ==(global::Datablock.Ident ident, global::Datablock other)
		{
			return ident.Equals(other);
		}

		// Token: 0x06003B29 RID: 15145 RVA: 0x000D2294 File Offset: 0x000D0494
		public static bool operator !=(global::Datablock.Ident ident, global::Datablock other)
		{
			return !ident.Equals(other);
		}

		// Token: 0x06003B2A RID: 15146 RVA: 0x000D22A4 File Offset: 0x000D04A4
		public static bool operator ==(global::Datablock.Ident ident, string other)
		{
			if (string.IsNullOrEmpty(other))
			{
				return !ident.exists;
			}
			return ident.name == other;
		}

		// Token: 0x06003B2B RID: 15147 RVA: 0x000D22D4 File Offset: 0x000D04D4
		public static bool operator !=(global::Datablock.Ident ident, string other)
		{
			if (string.IsNullOrEmpty(other))
			{
				return ident.exists;
			}
			return ident.name != other;
		}

		// Token: 0x06003B2C RID: 15148 RVA: 0x000D2304 File Offset: 0x000D0504
		public static bool operator ==(global::Datablock.Ident ident, int hash)
		{
			return ident.uniqueIDIfExists == hash;
		}

		// Token: 0x06003B2D RID: 15149 RVA: 0x000D2330 File Offset: 0x000D0530
		public static bool operator !=(global::Datablock.Ident ident, int hash)
		{
			return ident.uniqueIDIfExists != hash;
		}

		// Token: 0x06003B2E RID: 15150 RVA: 0x000D235C File Offset: 0x000D055C
		public static bool operator ==(global::Datablock.Ident ident, uint hash)
		{
			return ident.uniqueID == (int)hash;
		}

		// Token: 0x06003B2F RID: 15151 RVA: 0x000D2368 File Offset: 0x000D0568
		public static bool operator !=(global::Datablock.Ident ident, uint hash)
		{
			return ident.uniqueID != (int)hash;
		}

		// Token: 0x06003B30 RID: 15152 RVA: 0x000D2378 File Offset: 0x000D0578
		public static bool operator ==(global::Datablock.Ident ident, ushort hash)
		{
			return ident.uniqueIDIfExists == (int)hash;
		}

		// Token: 0x06003B31 RID: 15153 RVA: 0x000D23A4 File Offset: 0x000D05A4
		public static bool operator !=(global::Datablock.Ident ident, ushort hash)
		{
			return ident.uniqueIDIfExists != (int)hash;
		}

		// Token: 0x06003B32 RID: 15154 RVA: 0x000D23D0 File Offset: 0x000D05D0
		public static bool operator ==(global::Datablock.Ident ident, short hash)
		{
			return ident.uniqueID == (int)hash;
		}

		// Token: 0x06003B33 RID: 15155 RVA: 0x000D23DC File Offset: 0x000D05DC
		public static bool operator !=(global::Datablock.Ident ident, short hash)
		{
			return ident.uniqueID != (int)hash;
		}

		// Token: 0x06003B34 RID: 15156 RVA: 0x000D23EC File Offset: 0x000D05EC
		public static bool operator ==(global::Datablock.Ident ident, byte hash)
		{
			return ident.uniqueIDIfExists == (int)hash;
		}

		// Token: 0x06003B35 RID: 15157 RVA: 0x000D2418 File Offset: 0x000D0618
		public static bool operator !=(global::Datablock.Ident ident, byte hash)
		{
			return ident.uniqueIDIfExists != (int)hash;
		}

		// Token: 0x06003B36 RID: 15158 RVA: 0x000D2444 File Offset: 0x000D0644
		public static bool operator ==(global::Datablock.Ident ident, sbyte hash)
		{
			return ident.uniqueID == (int)hash;
		}

		// Token: 0x06003B37 RID: 15159 RVA: 0x000D2454 File Offset: 0x000D0654
		public static bool operator !=(global::Datablock.Ident ident, sbyte hash)
		{
			return ident.uniqueID != (int)hash;
		}

		// Token: 0x06003B38 RID: 15160 RVA: 0x000D2464 File Offset: 0x000D0664
		public static bool operator true(global::Datablock.Ident ident)
		{
			return ident.exists;
		}

		// Token: 0x06003B39 RID: 15161 RVA: 0x000D2470 File Offset: 0x000D0670
		public static bool operator false(global::Datablock.Ident ident)
		{
			return !ident.exists;
		}

		// Token: 0x04001E38 RID: 7736
		private const byte TYPE_NULL = 0;

		// Token: 0x04001E39 RID: 7737
		private const byte TYPE_DATABLOCK = 1;

		// Token: 0x04001E3A RID: 7738
		private const byte TYPE_INVENTORY_ITEM = 2;

		// Token: 0x04001E3B RID: 7739
		private const byte TYPE_STRING = 3;

		// Token: 0x04001E3C RID: 7740
		private const byte TYPE_HASH = 4;

		// Token: 0x04001E3D RID: 7741
		private const int FLAG_UNCONFIRMED = 0x80;

		// Token: 0x04001E3E RID: 7742
		private const int MASK_TYPE = 0x7F;

		// Token: 0x04001E3F RID: 7743
		private const byte TYPE_STRING_UNCONFIRMED = 0x83;

		// Token: 0x04001E40 RID: 7744
		private const byte TYPE_HASH_UNCONFIRMED = 0x84;

		// Token: 0x04001E41 RID: 7745
		private const byte TYPE_INVENTORY_ITEM_UNCONFIRMED = 0x82;

		// Token: 0x04001E42 RID: 7746
		private const byte TYPE_DATABLOCK_UNCONFIRMED = 0x81;

		// Token: 0x04001E43 RID: 7747
		private readonly object refValue;

		// Token: 0x04001E44 RID: 7748
		private readonly int uid;

		// Token: 0x04001E45 RID: 7749
		private readonly byte type_f;
	}
}
