using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Facepunch;
using Facepunch.Procedural;
using Magma;
using uLink;
using UnityEngine;

// Token: 0x02000551 RID: 1361
public class BasicWildLifeAI : global::Facepunch.NetBehaviour, global::IInterpTimedEventReceiver
{
	// Token: 0x06002E62 RID: 11874 RVA: 0x000B07DC File Offset: 0x000AE9DC
	public BasicWildLifeAI()
	{
	}

	// Token: 0x06002E63 RID: 11875 RVA: 0x000B0838 File Offset: 0x000AEA38
	void global::IInterpTimedEventReceiver.OnInterpTimedEvent()
	{
		if (!this.OnInterpTimedEvent())
		{
			global::InterpTimedEvent.MarkUnhandled();
		}
	}

	// Token: 0x170009EB RID: 2539
	// (get) Token: 0x06002E64 RID: 11876 RVA: 0x000B0858 File Offset: 0x000AEA58
	public global::UnityEngine.Transform transform
	{
		get
		{
			return this._myTransform;
		}
	}

	// Token: 0x170009EC RID: 2540
	// (get) Token: 0x06002E65 RID: 11877 RVA: 0x000B0860 File Offset: 0x000AEA60
	public bool thinking
	{
		get
		{
			return this.ZZmZaZnZaZgZeZrZZZZmZaZnZaZgZeZdZZ && global::WildlifeManager.ZZZmZaZnZaZgZeZrZAZvZaZiZlZaZbZlZeZ;
		}
	}

	// Token: 0x06002E66 RID: 11878 RVA: 0x000B0878 File Offset: 0x000AEA78
	protected internal bool ManagedUpdate(ulong millis, global::WildlifeManager.LocalData localData)
	{
		if (!this.ShouldUpdate())
		{
			return false;
		}
		if (this.SimAIState(millis))
		{
			this._wildMove.DoMove(this, millis);
		}
		this.DoNetwork(localData);
		return true;
	}

	// Token: 0x06002E67 RID: 11879 RVA: 0x000B08B4 File Offset: 0x000AEAB4
	protected bool ShouldUpdate()
	{
		return this._takeDamage.alive;
	}

	// Token: 0x06002E68 RID: 11880 RVA: 0x000B08C4 File Offset: 0x000AEAC4
	protected virtual bool SimAIState(ulong millis)
	{
		switch (this._state)
		{
		case 1:
			this.StateSim_Idle(millis);
			return true;
		case 2:
			this.StateSim_Flee(millis);
			return true;
		case 5:
			this.StateSim_Roam(millis);
			return true;
		}
		return false;
	}

	// Token: 0x06002E69 RID: 11881 RVA: 0x000B0918 File Offset: 0x000AEB18
	protected virtual bool ExitCurrentState()
	{
		bool flag;
		switch (this._state)
		{
		case 1:
			this.ExitState_Idle();
			flag = true;
			goto IL_58;
		case 2:
			this.ExitState_Flee();
			flag = true;
			goto IL_58;
		case 5:
			this.ExitState_Roam();
			flag = true;
			goto IL_58;
		}
		flag = false;
		IL_58:
		if (flag)
		{
			this._lastState = this._state;
		}
		return flag;
	}

	// Token: 0x06002E6A RID: 11882 RVA: 0x000B0990 File Offset: 0x000AEB90
	protected void EnterState_Idle()
	{
		this.idleClock.ResetRandomDurationSeconds(8.0, 10.0);
		this._wildMove.SetLookDirection(global::Angle2.Direction(0f, global::UnityEngine.Random.Range(0f, 360f)));
		this._state = 1;
		if (!this.idleSoundRefireClock.once)
		{
			this.idleSoundRefireClock.ResetRandomDurationSeconds(2.0, 4.0);
		}
	}

	// Token: 0x06002E6B RID: 11883 RVA: 0x000B0A14 File Offset: 0x000AEC14
	protected void ExitState_Idle()
	{
	}

	// Token: 0x06002E6C RID: 11884 RVA: 0x000B0A18 File Offset: 0x000AEC18
	protected void StateSim_Idle(ulong millis)
	{
		if (this.idleClock.IntegrateTime_Reached(millis))
		{
			this.ExitCurrentState();
			this.EnterState_Roam();
			return;
		}
		if (this.idleSoundRefireClock.IntegrateTime_Reached(millis))
		{
			this.idleSoundRefireClock.ResetDurationMillis(0xFA0UL);
			this.NetworkSound(global::BasicWildLifeAI.AISound.Idle);
		}
	}

	// Token: 0x06002E6D RID: 11885 RVA: 0x000B0A70 File Offset: 0x000AEC70
	protected void EnterState_Flee(global::UnityEngine.Vector3 fleeFrom, ulong fleeDuration)
	{
		this.NetworkSound(global::BasicWildLifeAI.AISound.Afraid);
		global::Vis.Mask traitMask = this._vis.traitMask;
		traitMask[global::Vis.Status.Alert] = true;
		this._vis.traitMask = traitMask;
		global::UnityEngine.Vector3 worldDir = this._myTransform.position - fleeFrom;
		worldDir.Normalize();
		worldDir.y = 0f;
		this.fleeClock.ResetDurationMillis(fleeDuration);
		this._wildMove.SetMoveDirection(worldDir, global::UnityEngine.Random.Range(this.runSpeed * 0.9f, this.runSpeed * 1.1f));
		this._state = 2;
	}

	// Token: 0x06002E6E RID: 11886 RVA: 0x000B0B08 File Offset: 0x000AED08
	protected void EnterState_Flee(global::UnityEngine.Vector3 fleeFrom)
	{
		this.EnterState_Flee(fleeFrom, 0x1388UL);
	}

	// Token: 0x06002E6F RID: 11887 RVA: 0x000B0B18 File Offset: 0x000AED18
	protected void ExitState_Flee()
	{
		global::Vis.Mask traitMask = this._vis.traitMask;
		traitMask[global::Vis.Status.Alert] = false;
		this._vis.traitMask = traitMask;
	}

	// Token: 0x06002E70 RID: 11888 RVA: 0x000B0B48 File Offset: 0x000AED48
	protected void StateSim_Flee(ulong millis)
	{
		if (this.fleeClock.IntegrateTime_Reached(millis))
		{
			this.ExitCurrentState();
			this.EnterState_Idle();
		}
	}

	// Token: 0x06002E71 RID: 11889 RVA: 0x000B0B68 File Offset: 0x000AED68
	protected void EnterState_Roam()
	{
		bool flag = false;
		global::UnityEngine.Vector3 worldDir = this.transform.forward;
		if (this._mySpawner)
		{
			global::GenericSpawner component = this._mySpawner.GetComponent<global::GenericSpawner>();
			if (component)
			{
				global::UnityEngine.Vector3 vector;
				vector..ctor(this.transform.position.x, 0f, this.transform.position.z);
				global::UnityEngine.Vector3 vector2;
				vector2..ctor(this._mySpawner.transform.position.x, 0f, this._mySpawner.transform.position.z);
				if (global::UnityEngine.Vector3.Distance(vector, vector2) > component.radius * 0.5f)
				{
					flag = true;
					worldDir = vector2 - vector;
					worldDir.Normalize();
				}
			}
		}
		if (!flag)
		{
			worldDir = global::Angle2.Direction(0f, global::UnityEngine.Random.Range(0f, 360f));
		}
		this._wildMove.SetMoveDirection(worldDir, this.walkSpeed);
		this._state = 5;
		this.roamClock.ResetRandomDurationSeconds(3.0, 5.0);
	}

	// Token: 0x06002E72 RID: 11890 RVA: 0x000B0CA0 File Offset: 0x000AEEA0
	protected void ExitState_Roam()
	{
		this._wildMove.Stop();
	}

	// Token: 0x06002E73 RID: 11891 RVA: 0x000B0CB0 File Offset: 0x000AEEB0
	protected void StateSim_Roam(ulong millis)
	{
		if (this.roamClock.IntegrateTime_Reached(millis))
		{
			this.ExitCurrentState();
			this.EnterState_Idle();
		}
	}

	// Token: 0x06002E74 RID: 11892 RVA: 0x000B0CD0 File Offset: 0x000AEED0
	protected void EnterState_Dead()
	{
		this._state = 7;
		this._vis.mute = true;
		this._vis.deaf = true;
		this._vis.blind = true;
		this.NetworkSound(global::BasicWildLifeAI.AISound.Death);
	}

	// Token: 0x06002E75 RID: 11893 RVA: 0x000B0D10 File Offset: 0x000AEF10
	protected internal virtual void HitSomething()
	{
		if (this._state == 7)
		{
			return;
		}
		if (this._state == 2 || (this._state == 5 && this._lastBounceTime + 0.5f < global::UnityEngine.Time.time))
		{
			this._lastBounceTime = global::UnityEngine.Time.time;
			global::Angle2 angle = global::Angle2.LookDirection(-this._myTransform.forward);
			angle.pitch = 0f;
			angle.yaw += global::UnityEngine.Random.Range(-30f, 30f);
			this._wildMove.SetLookDirection(angle.forward);
		}
	}

	// Token: 0x06002E76 RID: 11894 RVA: 0x000B0DB4 File Offset: 0x000AEFB4
	public virtual void HearFootstep(global::UnityEngine.Vector3 origin)
	{
		if (this._state == 2 || this._state == 7 || !this.afraidOfFootsteps)
		{
			return;
		}
		this.ExitCurrentState();
		this.EnterState_Flee(origin);
	}

	// Token: 0x06002E77 RID: 11895 RVA: 0x000B0DF4 File Offset: 0x000AEFF4
	public virtual void HearDanger(global::UnityEngine.Vector3 origin)
	{
		if (this._state == 2 || this._state == 7 || !this.afraidOfDanger)
		{
			return;
		}
		this.ExitCurrentState();
		this.EnterState_Flee(origin);
	}

	// Token: 0x06002E78 RID: 11896 RVA: 0x000B0E34 File Offset: 0x000AF034
	protected virtual void OnHurt(global::DamageEvent damage)
	{
		global::Magma.Hooks.NPCHurt(ref damage);
		if (this._state == 2 || this._state == 7)
		{
			return;
		}
		if (damage.attacker.character != null)
		{
			this.ExitCurrentState();
			this.EnterState_Flee(this.transform.position + new global::UnityEngine.Vector3(global::UnityEngine.Random.Range(-1f, 1f), 0f, global::UnityEngine.Random.Range(-1f, 1f)));
		}
	}

	// Token: 0x06002E79 RID: 11897 RVA: 0x000B0EC0 File Offset: 0x000AF0C0
	protected void OnKilled(global::DamageEvent damage)
	{
		global::Magma.Hooks.NPCKilled(ref damage);
		this.ExitCurrentState();
		this.EnterState_Dead();
		global::Facepunch.NetworkView networkView = base.networkView;
		global::NetCull.RemoveRPCsByName(networkView, "GetNetworkUpdate");
		networkView.RPC("ClientDeath", 1, new object[]
		{
			this._myTransform.position,
			damage.attacker.networkViewID
		});
		base.Invoke("DelayedDestroy", 90f);
		global::WildlifeManager.RemoveWildlifeInstance(this);
	}

	// Token: 0x06002E7A RID: 11898 RVA: 0x000B0F44 File Offset: 0x000AF144
	private void SetSpawner(global::UnityEngine.GameObject spawner)
	{
		this._mySpawner = spawner;
	}

	// Token: 0x06002E7B RID: 11899 RVA: 0x000B0F50 File Offset: 0x000AF150
	protected void ResourcesDepletedMsg()
	{
		base.CancelInvoke("DelayedDestroy");
		global::NetCull.Destroy(base.gameObject);
	}

	// Token: 0x06002E7C RID: 11900 RVA: 0x000B0F68 File Offset: 0x000AF168
	protected void DelayedDestroy()
	{
		global::NetCull.Destroy(base.gameObject);
	}

	// Token: 0x06002E7D RID: 11901 RVA: 0x000B0F78 File Offset: 0x000AF178
	public void DoNetwork(global::WildlifeManager.LocalData localData)
	{
		global::UnityEngine.Vector3 position = this._myTransform.position;
		global::UnityEngine.Quaternion rotation = this._myTransform.rotation;
		if (localData.CoordinatesChanged(ref position, ref rotation))
		{
			global::Angle2 angle = (global::Angle2)rotation;
			global::Facepunch.NetworkView networkView = base.networkView;
			global::NetCull.RemoveRPCsByName(networkView, "GetNetworkUpdate");
			networkView.RPC("GetNetworkUpdate", 5, new object[]
			{
				position,
				angle
			});
			if (global::WaterLine.Height != 0f && position.y <= global::WaterLine.Height && this._takeDamage.alive)
			{
				global::IDMain idMain = base.GetComponent<global::Character>().idMain;
				global::TakeDamage.Hurt(idMain, idMain, this._takeDamage.health * 2f, null);
			}
		}
	}

	// Token: 0x06002E7E RID: 11902 RVA: 0x000B1048 File Offset: 0x000AF248
	protected void NetworkSound(global::BasicWildLifeAI.AISound toPlay)
	{
		base.networkView.RPC<byte>("Snd", 1, (byte)toPlay);
	}

	// Token: 0x06002E7F RID: 11903 RVA: 0x000B105C File Offset: 0x000AF25C
	protected void Awake()
	{
		this._myTransform = base.transform;
		this._takeDamage = base.GetComponent<global::TakeDamage>();
		this._wildMove = base.GetComponent<global::BaseAIMovement>();
		this._vis = base.GetComponent<global::VisNode>();
		this._vis.head = base.GetComponent<global::Character>().eyesTransformReadOnly;
		global::UnityEngine.Object.Destroy(base.GetComponent<global::TransformInterpolator>());
		this._wildMove.InitializeMovement(this);
	}

	// Token: 0x06002E80 RID: 11904 RVA: 0x000B10C8 File Offset: 0x000AF2C8
	protected void uLink_OnNetworkInstantiate(global::uLink.NetworkMessageInfo info)
	{
		global::ServerHelper.SetupForServer(base.gameObject);
		this._vis.enabled = true;
		global::WildlifeManager.AddWildlifeInstance(this);
	}

	// Token: 0x06002E81 RID: 11905 RVA: 0x000B10E8 File Offset: 0x000AF2E8
	protected void OnDestroy()
	{
		if (this.thinking)
		{
			global::WildlifeManager.RemoveWildlifeInstance(this);
		}
		global::InterpTimedEvent.Remove(this);
		if (this._mySpawner)
		{
			this._mySpawner.SendMessage("WasKilled", base.gameObject);
		}
	}

	// Token: 0x06002E82 RID: 11906 RVA: 0x000B1134 File Offset: 0x000AF334
	[global::UnityEngine.RPC]
	protected void GetNetworkUpdate(global::UnityEngine.Vector3 pos, global::Angle2 rot, global::uLink.NetworkMessageInfo info)
	{
	}

	// Token: 0x06002E83 RID: 11907 RVA: 0x000B1138 File Offset: 0x000AF338
	[global::UnityEngine.RPC]
	protected void Snd(byte type, global::uLink.NetworkMessageInfo info)
	{
		try
		{
			global::InterpTimedEvent.Queue(this, "SOUND", ref info, new object[]
			{
				(int)type
			});
		}
		catch (global::System.Exception ex)
		{
			global::UnityEngine.Debug.LogException(ex);
			global::UnityEngine.Debug.LogWarning("Running emergency dump because of previous exception in Snd", this);
			global::InterpTimedEvent.EMERGENCY_DUMP(true);
		}
	}

	// Token: 0x06002E84 RID: 11908 RVA: 0x000B11A0 File Offset: 0x000AF3A0
	[global::UnityEngine.RPC]
	protected void ClientHealthChange(float newHealth)
	{
	}

	// Token: 0x06002E85 RID: 11909 RVA: 0x000B11A4 File Offset: 0x000AF3A4
	[global::UnityEngine.RPC]
	protected void ClientDeath(global::UnityEngine.Vector3 deadPos, global::uLink.NetworkViewID attackerID, global::uLink.NetworkMessageInfo info)
	{
	}

	// Token: 0x06002E86 RID: 11910 RVA: 0x000B11A8 File Offset: 0x000AF3A8
	protected virtual bool OnInterpTimedEvent()
	{
		string tag = global::InterpTimedEvent.Tag;
		if (tag != null)
		{
			if (global::BasicWildLifeAI.<>f__switch$map8 == null)
			{
				global::BasicWildLifeAI.<>f__switch$map8 = new global::System.Collections.Generic.Dictionary<string, int>(2)
				{
					{
						"DEATH",
						0
					},
					{
						"SOUND",
						1
					}
				};
			}
			int num;
			if (global::BasicWildLifeAI.<>f__switch$map8.TryGetValue(tag, out num))
			{
				if (num == 0)
				{
					return true;
				}
				if (num == 1)
				{
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x040017F3 RID: 6131
	protected const int kWildState_Default = 0;

	// Token: 0x040017F4 RID: 6132
	protected const int kWildState_Idle = 1;

	// Token: 0x040017F5 RID: 6133
	protected const int kWildState_Flee = 2;

	// Token: 0x040017F6 RID: 6134
	protected const int kWildState_SearchMate = 3;

	// Token: 0x040017F7 RID: 6135
	protected const int kWildState_Sex = 4;

	// Token: 0x040017F8 RID: 6136
	protected const int kWildState_Roam = 5;

	// Token: 0x040017F9 RID: 6137
	protected const int kWildState_Attack = 6;

	// Token: 0x040017FA RID: 6138
	protected const int kWildState_Dead = 7;

	// Token: 0x040017FB RID: 6139
	protected const int kWildState_LAST = 7;

	// Token: 0x040017FC RID: 6140
	private const string RPCName_GetNetworkUpdate = "GetNetworkUpdate";

	// Token: 0x040017FD RID: 6141
	private const string RPCName_Snd = "Snd";

	// Token: 0x040017FE RID: 6142
	private const string RPCName_ClientHealthChange = "ClientHealthChange";

	// Token: 0x040017FF RID: 6143
	private const string RPCName_ClientDeath = "ClientDeath";

	// Token: 0x04001800 RID: 6144
	public bool afraidOfFootsteps = true;

	// Token: 0x04001801 RID: 6145
	public bool afraidOfDanger = true;

	// Token: 0x04001802 RID: 6146
	[global::UnityEngine.SerializeField]
	protected global::AudioClipArray idleSounds;

	// Token: 0x04001803 RID: 6147
	[global::UnityEngine.SerializeField]
	protected global::AudioClipArray fleeStartSounds;

	// Token: 0x04001804 RID: 6148
	[global::UnityEngine.SerializeField]
	protected global::AudioClipArray deathSounds;

	// Token: 0x04001805 RID: 6149
	[global::UnityEngine.SerializeField]
	protected float walkSpeed = 1f;

	// Token: 0x04001806 RID: 6150
	[global::UnityEngine.SerializeField]
	protected float runSpeed = 3f;

	// Token: 0x04001807 RID: 6151
	[global::UnityEngine.SerializeField]
	protected float walkAnimScalar = 1f;

	// Token: 0x04001808 RID: 6152
	[global::UnityEngine.SerializeField]
	protected float runAnimScalar = 1f;

	// Token: 0x04001809 RID: 6153
	protected global::UnityEngine.Transform _myTransform;

	// Token: 0x0400180A RID: 6154
	protected global::TakeDamage _takeDamage;

	// Token: 0x0400180B RID: 6155
	protected global::BaseAIMovement _wildMove;

	// Token: 0x0400180C RID: 6156
	protected global::VisNode _vis;

	// Token: 0x0400180D RID: 6157
	protected global::UnityEngine.GameObject _mySpawner;

	// Token: 0x0400180E RID: 6158
	protected int _lastState = 1;

	// Token: 0x0400180F RID: 6159
	protected int _state = 1;

	// Token: 0x04001810 RID: 6160
	protected global::Facepunch.Procedural.MillisClock idleClock;

	// Token: 0x04001811 RID: 6161
	protected global::Facepunch.Procedural.MillisClock roamClock;

	// Token: 0x04001812 RID: 6162
	protected global::Facepunch.Procedural.MillisClock fleeClock;

	// Token: 0x04001813 RID: 6163
	protected global::Facepunch.Procedural.MillisClock idleSoundRefireClock;

	// Token: 0x04001814 RID: 6164
	protected float _lastBounceTime;

	// Token: 0x04001815 RID: 6165
	[global::System.NonSerialized]
	[global::System.Obsolete("DO NOT USE", false)]
	internal bool ZZmZaZnZaZgZeZrZZZZmZaZnZaZgZeZdZZ;

	// Token: 0x04001816 RID: 6166
	[global::System.NonSerialized]
	[global::System.Obsolete("DO NOT USE", false)]
	internal global::WildlifeManager.LocalData ZZlZoZcZaZlZZ;

	// Token: 0x04001817 RID: 6167
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private static global::System.Collections.Generic.Dictionary<string, int> <>f__switch$map8;

	// Token: 0x02000552 RID: 1362
	public enum AISound : byte
	{
		// Token: 0x04001819 RID: 6169
		Idle,
		// Token: 0x0400181A RID: 6170
		Warn,
		// Token: 0x0400181B RID: 6171
		Attack,
		// Token: 0x0400181C RID: 6172
		Afraid,
		// Token: 0x0400181D RID: 6173
		Death,
		// Token: 0x0400181E RID: 6174
		Chase,
		// Token: 0x0400181F RID: 6175
		ChaseClose
	}
}
