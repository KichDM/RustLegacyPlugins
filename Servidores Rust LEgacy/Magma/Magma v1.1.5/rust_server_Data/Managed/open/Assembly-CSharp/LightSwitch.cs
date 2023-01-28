using System;
using System.IO;
using Facepunch;
using uLink;
using UnityEngine;

// Token: 0x0200078D RID: 1933
[global::NGCAutoAddScript]
public class LightSwitch : global::Facepunch.NetBehaviour, global::IActivatable, global::IActivatableToggle, global::IContextRequestable, global::IContextRequestableQuick, global::IContextRequestableText, global::IContextRequestablePointText, global::IComponentInterface<global::IActivatable, global::Facepunch.MonoBehaviour, global::Activatable>, global::IComponentInterface<global::IActivatable, global::Facepunch.MonoBehaviour>, global::IComponentInterface<global::IActivatable>, global::IComponentInterface<global::IContextRequestable, global::Facepunch.MonoBehaviour, global::Contextual>, global::IComponentInterface<global::IContextRequestable, global::Facepunch.MonoBehaviour>, global::IComponentInterface<global::IContextRequestable>
{
	// Token: 0x06004030 RID: 16432 RVA: 0x000E56A0 File Offset: 0x000E38A0
	public LightSwitch()
	{
	}

	// Token: 0x17000BFE RID: 3070
	// (get) Token: 0x06004031 RID: 16433 RVA: 0x000E56C0 File Offset: 0x000E38C0
	protected int randSeed
	{
		get
		{
			return this._randSeed;
		}
	}

	// Token: 0x17000BFF RID: 3071
	// (get) Token: 0x06004032 RID: 16434 RVA: 0x000E56C8 File Offset: 0x000E38C8
	// (set) Token: 0x06004033 RID: 16435 RVA: 0x000E56D0 File Offset: 0x000E38D0
	private protected bool startsOn
	{
		protected get
		{
			return this._startsOn;
		}
		private set
		{
			this._startsOn = value;
		}
	}

	// Token: 0x06004034 RID: 16436 RVA: 0x000E56DC File Offset: 0x000E38DC
	private static void DefaultArray(string test, ref global::LightStyle[] array)
	{
		if (array == null)
		{
			global::LightStyle lightStyle = test;
			if (lightStyle)
			{
				array = new global::LightStyle[]
				{
					lightStyle
				};
			}
			else
			{
				array = new global::LightStyle[0];
			}
		}
		else if (array.Length == 0)
		{
			global::LightStyle lightStyle2 = test;
			if (lightStyle2)
			{
				array = new global::LightStyle[]
				{
					lightStyle2
				};
			}
		}
	}

	// Token: 0x06004035 RID: 16437 RVA: 0x000E5748 File Offset: 0x000E3948
	private void Reset()
	{
		this._randSeed = global::UnityEngine.Random.Range(0, int.MaxValue);
		if (this.stylists == null)
		{
			this.stylists = new global::LightStylist[0];
		}
		global::LightSwitch.DefaultArray("on", ref this.randOn);
		global::LightSwitch.DefaultArray("off", ref this.randOff);
	}

	// Token: 0x06004036 RID: 16438 RVA: 0x000E57A0 File Offset: 0x000E39A0
	private static bool MakeCTX(ref global::LightStylist[] stylists, ref global::LightSwitch.StylistCTX[] ctx)
	{
		int num;
		if (stylists == null)
		{
			num = 0;
		}
		else
		{
			num = stylists.Length;
		}
		global::System.Array.Resize<global::LightSwitch.StylistCTX>(ref ctx, num);
		return num > 0;
	}

	// Token: 0x06004037 RID: 16439 RVA: 0x000E57CC File Offset: 0x000E39CC
	private void Awake()
	{
		this.rand = new global::SeededRandom(this.randSeed);
		global::LightSwitch.MakeCTX(ref this.stylists, ref this.stylistCTX);
		if (this.stylists != null)
		{
			for (int i = 0; i < this.stylists.Length; i++)
			{
				if (this.stylists[i])
				{
					this.stylists[i] = this.stylists[i].ensuredAwake;
				}
			}
		}
		global::GameEvent.PlayerConnected += this.PlayerConnected;
		this.registeredConnectCallback = true;
		this.on = !this.startsOn;
		this.ServerToggle(global::NetCull.timeInMillis);
	}

	// Token: 0x06004038 RID: 16440 RVA: 0x000E587C File Offset: 0x000E3A7C
	private void TurnOn()
	{
		if (this.randOn == null || this.randOn.Length == 0)
		{
			global::UnityEngine.Debug.LogError("Theres no light styles in randOn", this);
		}
		else
		{
			int length = this.randOn.Length;
			for (int i = 0; i < this.stylistCTX.Length; i++)
			{
				this.stylistCTX[i].lastOnStyle = (sbyte)this.rand.RandomIndex(length);
				if (this.stylists[i])
				{
					this.stylists[i].CrossFade(this.randOn[(int)this.stylistCTX[i].lastOnStyle], global::UnityEngine.Random.Range(this.minOnFadeDuration, this.maxOnFadeDuration));
				}
			}
		}
	}

	// Token: 0x06004039 RID: 16441 RVA: 0x000E593C File Offset: 0x000E3B3C
	private void TurnOff()
	{
		if (this.randOff == null || this.randOff.Length == 0)
		{
			global::UnityEngine.Debug.LogError("Theres no light styles in randOn", this);
		}
		else
		{
			int length = this.randOff.Length;
			for (int i = 0; i < this.stylistCTX.Length; i++)
			{
				this.stylistCTX[i].lastOffStyle = (sbyte)this.rand.RandomIndex(length);
				if (this.stylists[i])
				{
					this.stylists[i].CrossFade(this.randOff[(int)this.stylistCTX[i].lastOffStyle], global::UnityEngine.Random.Range(this.minOffFadeDuration, this.maxOffFadeDuration));
				}
			}
		}
	}

	// Token: 0x0600403A RID: 16442 RVA: 0x000E59FC File Offset: 0x000E3BFC
	[global::UnityEngine.RPC]
	protected void ReadState(bool on, global::uLink.NetworkMessageInfo info)
	{
		this.lastChangeTime = info.timestampInMillis;
		this.on = on;
		if (on)
		{
			this.TurnOn();
		}
		else
		{
			this.TurnOff();
		}
	}

	// Token: 0x0600403B RID: 16443 RVA: 0x000E5A38 File Offset: 0x000E3C38
	private void ServerToggle(ulong timestamp)
	{
		this.on = !this.on;
		this.lastChangeTime = timestamp / 1000.0;
		if (this.on)
		{
			this.TurnOn();
		}
		else
		{
			this.TurnOff();
		}
		global::NetCull.RPC<bool>(this, "ReadState", 1, this.on);
	}

	// Token: 0x0600403C RID: 16444 RVA: 0x000E5A98 File Offset: 0x000E3C98
	public string ContextText(global::Controllable localControllable)
	{
		if (this.on)
		{
			return this.textTurnOff;
		}
		return this.textTurnOn;
	}

	// Token: 0x0600403D RID: 16445 RVA: 0x000E5AB4 File Offset: 0x000E3CB4
	public global::ContextExecution ContextQuery(global::Controllable controllable, ulong timestamp)
	{
		return global::ContextExecution.Quick;
	}

	// Token: 0x0600403E RID: 16446 RVA: 0x000E5AB8 File Offset: 0x000E3CB8
	public global::ContextResponse ContextRespondQuick(global::Controllable controllable, ulong timestamp)
	{
		this.ServerToggle(timestamp);
		return global::ContextResponse.DoneBreak;
	}

	// Token: 0x0600403F RID: 16447 RVA: 0x000E5AC4 File Offset: 0x000E3CC4
	public bool ContextTextPoint(out global::UnityEngine.Vector3 worldPoint)
	{
		worldPoint = default(global::UnityEngine.Vector3);
		return false;
	}

	// Token: 0x06004040 RID: 16448 RVA: 0x000E5AE4 File Offset: 0x000E3CE4
	private void OnDestroy()
	{
		if (this.registeredConnectCallback)
		{
			global::GameEvent.PlayerConnected -= this.PlayerConnected;
			this.registeredConnectCallback = false;
		}
	}

	// Token: 0x06004041 RID: 16449 RVA: 0x000E5B0C File Offset: 0x000E3D0C
	private void Write(global::System.IO.BinaryWriter writer)
	{
		writer.Write((!this.on) ? (-this.lastChangeTime) : this.lastChangeTime);
		writer.Write(this.rand.Seed);
		writer.Write(this.rand.PositionData);
		writer.Write((byte)this.stylistCTX.Length);
		for (int i = 0; i < this.stylistCTX.Length; i++)
		{
			this.stylistCTX[i].Write(writer);
		}
	}

	// Token: 0x06004042 RID: 16450 RVA: 0x000E5B98 File Offset: 0x000E3D98
	private void Read(global::System.IO.BinaryReader reader)
	{
		this.lastChangeTime = reader.ReadDouble();
		this.on = (this.lastChangeTime > 0.0);
		if (!this.on)
		{
			this.lastChangeTime = -this.lastChangeTime;
		}
		int num = reader.ReadInt32();
		uint positionData = reader.ReadUInt32();
		byte b = reader.ReadByte();
		global::System.Array.Resize<global::LightSwitch.StylistCTX>(ref this.stylistCTX, (int)b);
		global::System.Array.Resize<global::LightStylist>(ref this.stylists, (int)b);
		for (int i = 0; i < (int)b; i++)
		{
			this.stylistCTX[i].Read(reader);
		}
		if (num != this.rand.Seed)
		{
			this._randSeed = num;
			this.rand = new global::SeededRandom(num);
		}
		this.rand.PositionData = positionData;
		this.JumpUpdate();
	}

	// Token: 0x06004043 RID: 16451 RVA: 0x000E5C68 File Offset: 0x000E3E68
	private void JumpUpdate()
	{
		double time = global::NetCull.time - this.lastChangeTime;
		if (this.on)
		{
			int i = 0;
			int num = (this.randOn != null) ? this.randOn.Length : 0;
			while (i < this.stylistCTX.Length)
			{
				if (this.stylists[i] && (int)this.stylistCTX[i].lastOnStyle >= 0 && (int)this.stylistCTX[i].lastOnStyle < num && this.randOn[(int)this.stylistCTX[i].lastOnStyle])
				{
					this.stylists[i].Play(this.randOn[(int)this.stylistCTX[i].lastOnStyle], time);
				}
				else
				{
					global::UnityEngine.Debug.Log("Did not set on " + i, this);
				}
				i++;
			}
		}
		else
		{
			int j = 0;
			int num2 = (this.randOff != null) ? this.randOff.Length : 0;
			while (j < this.stylistCTX.Length)
			{
				if (this.stylists[j] && (int)this.stylistCTX[j].lastOffStyle >= 0 && (int)this.stylistCTX[j].lastOffStyle < num2 && this.randOff[(int)this.stylistCTX[j].lastOffStyle])
				{
					this.stylists[j].Play(this.randOff[(int)this.stylistCTX[j].lastOffStyle], time);
				}
				else
				{
					global::UnityEngine.Debug.Log("Did not set off " + j, this);
				}
				j++;
			}
		}
	}

	// Token: 0x17000C00 RID: 3072
	// (get) Token: 0x06004044 RID: 16452 RVA: 0x000E5E48 File Offset: 0x000E4048
	private int StreamSize
	{
		get
		{
			return 0x11 + this.stylistCTX.Length * 2;
		}
	}

	// Token: 0x06004045 RID: 16453 RVA: 0x000E5E58 File Offset: 0x000E4058
	[global::UnityEngine.RPC]
	private void ConnectSetup(byte[] data)
	{
		using (global::System.IO.MemoryStream memoryStream = new global::System.IO.MemoryStream(data))
		{
			using (global::System.IO.BinaryReader binaryReader = new global::System.IO.BinaryReader(memoryStream))
			{
				this.Read(binaryReader);
			}
		}
	}

	// Token: 0x06004046 RID: 16454 RVA: 0x000E5ED4 File Offset: 0x000E40D4
	public void PlayerConnected(global::PlayerClient player)
	{
		byte[] array = new byte[this.StreamSize];
		using (global::System.IO.MemoryStream memoryStream = new global::System.IO.MemoryStream(array))
		{
			using (global::System.IO.BinaryWriter binaryWriter = new global::System.IO.BinaryWriter(memoryStream))
			{
				this.Write(binaryWriter);
			}
		}
		global::NetCull.RPC<byte[]>(this, "ConnectSetup", player.netPlayer, array);
	}

	// Token: 0x06004047 RID: 16455 RVA: 0x000E5F70 File Offset: 0x000E4170
	public global::ActivationResult ActTrigger(global::Character instigator, global::ActivationToggleState toggleTarget, ulong timestamp)
	{
		if (toggleTarget != global::ActivationToggleState.On)
		{
			if (toggleTarget != global::ActivationToggleState.Off)
			{
				return global::ActivationResult.Fail_BadToggle;
			}
			if (!this.on)
			{
				return global::ActivationResult.Fail_Redundant;
			}
			this.ServerToggle(timestamp);
			return (!this.on) ? global::ActivationResult.Success : global::ActivationResult.Fail_Busy;
		}
		else
		{
			if (this.on)
			{
				return global::ActivationResult.Fail_Redundant;
			}
			this.ServerToggle(timestamp);
			return (!this.on) ? global::ActivationResult.Fail_Busy : global::ActivationResult.Success;
		}
	}

	// Token: 0x06004048 RID: 16456 RVA: 0x000E5FE4 File Offset: 0x000E41E4
	public global::ActivationToggleState ActGetToggleState()
	{
		return (!this.on) ? global::ActivationToggleState.Off : global::ActivationToggleState.On;
	}

	// Token: 0x06004049 RID: 16457 RVA: 0x000E5FF8 File Offset: 0x000E41F8
	public global::ActivationResult ActTrigger(global::Character instigator, ulong timestamp)
	{
		return this.ActTrigger(instigator, (!this.on) ? global::ActivationToggleState.On : global::ActivationToggleState.Off, timestamp);
	}

	// Token: 0x0400216E RID: 8558
	[global::UnityEngine.SerializeField]
	protected global::LightStylist[] stylists;

	// Token: 0x0400216F RID: 8559
	private global::LightSwitch.StylistCTX[] stylistCTX;

	// Token: 0x04002170 RID: 8560
	private double lastChangeTime;

	// Token: 0x04002171 RID: 8561
	[global::UnityEngine.SerializeField]
	protected global::LightStyle[] randOn;

	// Token: 0x04002172 RID: 8562
	[global::UnityEngine.SerializeField]
	protected global::LightStyle[] randOff;

	// Token: 0x04002173 RID: 8563
	[global::UnityEngine.SerializeField]
	private int _randSeed;

	// Token: 0x04002174 RID: 8564
	[global::UnityEngine.SerializeField]
	protected float minOnFadeDuration;

	// Token: 0x04002175 RID: 8565
	[global::UnityEngine.SerializeField]
	protected float maxOnFadeDuration;

	// Token: 0x04002176 RID: 8566
	[global::UnityEngine.SerializeField]
	protected float minOffFadeDuration;

	// Token: 0x04002177 RID: 8567
	[global::UnityEngine.SerializeField]
	protected float maxOffFadeDuration;

	// Token: 0x04002178 RID: 8568
	[global::UnityEngine.SerializeField]
	private bool _startsOn;

	// Token: 0x04002179 RID: 8569
	private sbyte lastPickedOn;

	// Token: 0x0400217A RID: 8570
	private sbyte lastPickedOff;

	// Token: 0x0400217B RID: 8571
	private global::SeededRandom rand;

	// Token: 0x0400217C RID: 8572
	private bool on;

	// Token: 0x0400217D RID: 8573
	[global::UnityEngine.SerializeField]
	protected string textTurnOn = "Flick Up";

	// Token: 0x0400217E RID: 8574
	[global::UnityEngine.SerializeField]
	protected string textTurnOff = "Flick Down";

	// Token: 0x0400217F RID: 8575
	private bool registeredConnectCallback;

	// Token: 0x0200078E RID: 1934
	private struct StylistCTX
	{
		// Token: 0x0600404A RID: 16458 RVA: 0x000E6014 File Offset: 0x000E4214
		public void Write(global::System.IO.BinaryWriter writer)
		{
			writer.Write(this.lastOnStyle);
			writer.Write(this.lastOffStyle);
		}

		// Token: 0x0600404B RID: 16459 RVA: 0x000E6030 File Offset: 0x000E4230
		public void Read(global::System.IO.BinaryReader reader)
		{
			this.lastOnStyle = reader.ReadSByte();
			this.lastOffStyle = reader.ReadSByte();
		}

		// Token: 0x04002180 RID: 8576
		public const int SIZE = 2;

		// Token: 0x04002181 RID: 8577
		public sbyte lastOnStyle;

		// Token: 0x04002182 RID: 8578
		public sbyte lastOffStyle;
	}
}
