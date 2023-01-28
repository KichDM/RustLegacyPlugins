using System;
using uLink;

// Token: 0x020005EF RID: 1519
public struct BufferHealthRPC
{
	// Token: 0x06003112 RID: 12562 RVA: 0x000BB2B8 File Offset: 0x000B94B8
	private void Initialize(global::IDBase self)
	{
		global::TakeDamage local;
		global::NetEntityID netEntityID;
		if (!self || !(local = self.GetLocal<global::TakeDamage>()) || (int)global::NetEntityID.Of(self, out netEntityID) == 0)
		{
			this.takeDamage = null;
			this.entityID = global::NetEntityID.unassigned;
			this.valid = false;
		}
		else
		{
			this.takeDamage = local;
			this.entityID = netEntityID;
			this.valid = true;
			this.health = null;
		}
	}

	// Token: 0x06003113 RID: 12563 RVA: 0x000BB334 File Offset: 0x000B9534
	public bool CheckBegin(global::IDBase self, out global::BufferHealthRPC.Status status, float resolution = 0f, global::BufferHealthRPC.Flags flags = (global::BufferHealthRPC.Flags)0)
	{
		if (!this.initialized)
		{
			this.initialized = true;
			this.Initialize(self);
		}
		if (!this.valid || !this.takeDamage || !self)
		{
			this.valid = false;
			float? num = this.health;
			status.Health = ((num == null) ? 0f : num.Value);
			status.Error = true;
			status.NetEntityID = global::NetEntityID.unassigned;
			if (this.buffered)
			{
				status.Result = global::BufferHealthRPC.Result.RemoveBuffer;
			}
			else
			{
				status.Result = global::BufferHealthRPC.Result.NoChange;
			}
			return false;
		}
		float num2 = this.takeDamage.health;
		float maxHealth = this.takeDamage.maxHealth;
		float? num3 = this.health;
		float num4 = (num3 == null) ? maxHealth : num3.Value;
		if ((int)((sbyte)((int)flags & 8)) != 8 && num2 == num4)
		{
			status.Health = num4;
			status.NetEntityID = this.entityID;
			status.Error = false;
			status.Result = global::BufferHealthRPC.Result.NoChange;
			return false;
		}
		bool flag = num2 == maxHealth;
		bool flag2 = num2 == 0f;
		if ((int)((sbyte)((int)flags & 8)) != 8 && resolution != 0f && (!flag2 || (int)((sbyte)((int)flags & 1)) != 0) && (!flag || (int)((sbyte)((int)flags & 2)) != 0))
		{
			bool flag3;
			if (resolution < 0f)
			{
				float num5 = (num2 - num4) / maxHealth;
				float num6 = -resolution;
				flag3 = (num5 < num6 && num5 > -num6);
			}
			else
			{
				float num7 = num2 - num4;
				flag3 = (num7 < resolution && num7 > -resolution);
			}
			if (flag3)
			{
				status.Health = num4;
				status.NetEntityID = this.entityID;
				status.Result = global::BufferHealthRPC.Result.NoChange;
				status.Error = false;
				return false;
			}
		}
		status.Health = num2;
		status.NetEntityID = this.entityID;
		status.Error = false;
		if (this.buffered)
		{
			if (flag || (int)((sbyte)((int)flags & 4)) == 4)
			{
				status.Result = global::BufferHealthRPC.Result.RemoveBufferSend;
			}
			else
			{
				status.Result = global::BufferHealthRPC.Result.SendReplacedBuffered;
			}
		}
		else if (flag || (int)((sbyte)((int)flags & 4)) == 4)
		{
			status.Result = global::BufferHealthRPC.Result.Send;
		}
		else
		{
			status.Result = global::BufferHealthRPC.Result.SendBuffered;
		}
		return true;
	}

	// Token: 0x06003114 RID: 12564 RVA: 0x000BB58C File Offset: 0x000B978C
	public void CheckEnd(global::IDBase self, ref global::BufferHealthRPC.Status status)
	{
		if (!this.initialized)
		{
			this.initialized = true;
			this.Initialize(self);
		}
		if ((int)((sbyte)((int)status.Result & 2)) == 2)
		{
			this.health = new float?(status.Health);
		}
		this.buffered = ((int)((sbyte)((int)status.Result & 4)) == 4);
	}

	// Token: 0x06003115 RID: 12565 RVA: 0x000BB5E8 File Offset: 0x000B97E8
	public void CheckAuto(global::IDBase self, string RPCName, bool ExcludeOwner = false, bool IncludeServer = false, float resolution = 0f, global::BufferHealthRPC.Flags flags = (global::BufferHealthRPC.Flags)0)
	{
		global::BufferHealthRPC.Status status;
		if (this.CheckBegin(self, out status, resolution, flags))
		{
			status.Run(RPCName, ExcludeOwner, IncludeServer);
			this.CheckEnd(self, ref status);
		}
	}

	// Token: 0x04001B30 RID: 6960
	[global::System.NonSerialized]
	private bool initialized;

	// Token: 0x04001B31 RID: 6961
	[global::System.NonSerialized]
	private bool valid;

	// Token: 0x04001B32 RID: 6962
	[global::System.NonSerialized]
	private bool buffered;

	// Token: 0x04001B33 RID: 6963
	[global::System.NonSerialized]
	private float? health;

	// Token: 0x04001B34 RID: 6964
	[global::System.NonSerialized]
	private global::NetEntityID entityID;

	// Token: 0x04001B35 RID: 6965
	[global::System.NonSerialized]
	private global::TakeDamage takeDamage;

	// Token: 0x020005F0 RID: 1520
	public enum Result : sbyte
	{
		// Token: 0x04001B37 RID: 6967
		NoChange,
		// Token: 0x04001B38 RID: 6968
		RemoveBuffer,
		// Token: 0x04001B39 RID: 6969
		Send,
		// Token: 0x04001B3A RID: 6970
		AddBuffer = 4,
		// Token: 0x04001B3B RID: 6971
		RemoveBufferSend = 3,
		// Token: 0x04001B3C RID: 6972
		SendBuffered = 6,
		// Token: 0x04001B3D RID: 6973
		SendReplacedBuffered
	}

	// Token: 0x020005F1 RID: 1521
	[global::System.Flags]
	public enum Flags : sbyte
	{
		// Token: 0x04001B3F RID: 6975
		DoNotForceZeroHealthUpdate = 1,
		// Token: 0x04001B40 RID: 6976
		DoNotForceFullHealthUpdate = 2,
		// Token: 0x04001B41 RID: 6977
		DoNotBuffer = 4,
		// Token: 0x04001B42 RID: 6978
		ForceSend = 8
	}

	// Token: 0x020005F2 RID: 1522
	public struct Status
	{
		// Token: 0x17000A46 RID: 2630
		// (get) Token: 0x06003116 RID: 12566 RVA: 0x000BB61C File Offset: 0x000B981C
		public bool RemoveRPC
		{
			get
			{
				return (int)((sbyte)((int)this.Result & 1)) == 1;
			}
		}

		// Token: 0x17000A47 RID: 2631
		// (get) Token: 0x06003117 RID: 12567 RVA: 0x000BB62C File Offset: 0x000B982C
		public bool SendRPC
		{
			get
			{
				return (int)((sbyte)((int)this.Result & 6)) != 0;
			}
		}

		// Token: 0x06003118 RID: 12568 RVA: 0x000BB640 File Offset: 0x000B9840
		public global::uLink.RPCMode ToRPCMode(bool ExcludeOwner = false, bool IncludeServer = false)
		{
			if ((int)this.Result == 4)
			{
				return 4;
			}
			return ((int)((sbyte)((int)this.Result & 4)) != 4) ? ((!ExcludeOwner) ? ((!IncludeServer) ? 1 : 2) : ((!IncludeServer) ? 9 : 0xA)) : ((!ExcludeOwner) ? ((!IncludeServer) ? 5 : 6) : ((!IncludeServer) ? 0xD : 0xE));
		}

		// Token: 0x06003119 RID: 12569 RVA: 0x000BB6C0 File Offset: 0x000B98C0
		internal void Run(string RPCName, bool ExcludeOwner = false, bool IncludeServer = false)
		{
			if (this.RemoveRPC)
			{
				global::NetCull.RemoveRPCsByName(this.NetEntityID, RPCName);
			}
			if (this.SendRPC)
			{
				global::NetCull.RPC<float>(this.NetEntityID, RPCName, this.ToRPCMode(ExcludeOwner, IncludeServer), this.Health);
			}
		}

		// Token: 0x04001B43 RID: 6979
		[global::System.NonSerialized]
		public bool Error;

		// Token: 0x04001B44 RID: 6980
		[global::System.NonSerialized]
		public global::BufferHealthRPC.Result Result;

		// Token: 0x04001B45 RID: 6981
		[global::System.NonSerialized]
		public float Health;

		// Token: 0x04001B46 RID: 6982
		[global::System.NonSerialized]
		public global::NetEntityID NetEntityID;
	}
}
