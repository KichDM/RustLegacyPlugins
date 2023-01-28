using System;
using Facepunch;
using uLink;

// Token: 0x02000181 RID: 385
public struct DamageBeing
{
	// Token: 0x17000308 RID: 776
	// (get) Token: 0x06000B39 RID: 2873 RVA: 0x0002B994 File Offset: 0x00029B94
	public global::IDMain idMain
	{
		get
		{
			return (!this.id) ? null : this.id.idMain;
		}
	}

	// Token: 0x17000309 RID: 777
	// (get) Token: 0x06000B3A RID: 2874 RVA: 0x0002B9B8 File Offset: 0x00029BB8
	public global::Character character
	{
		get
		{
			return this.idOwnerMain as global::Character;
		}
	}

	// Token: 0x1700030A RID: 778
	// (get) Token: 0x06000B3B RID: 2875 RVA: 0x0002B9C8 File Offset: 0x00029BC8
	public global::IDMain idOwnerMain
	{
		get
		{
			global::IDMain idmain = (!this.id) ? null : this.id.idMain;
			if (idmain)
			{
				if (idmain is global::RigidObj)
				{
					global::Facepunch.NetworkView ownerView = ((global::RigidObj)idmain).ownerView;
					if (ownerView)
					{
						idmain = ownerView.GetComponent<global::IDMain>();
					}
					else
					{
						idmain = null;
					}
				}
				else if (idmain is global::IDeployedObjectMain)
				{
					global::DeployedObjectInfo deployedObjectInfo = ((global::IDeployedObjectMain)idmain).DeployedObjectInfo;
					if (deployedObjectInfo.valid)
					{
						return deployedObjectInfo.playerCharacter;
					}
				}
			}
			return idmain;
		}
	}

	// Token: 0x1700030B RID: 779
	// (get) Token: 0x06000B3C RID: 2876 RVA: 0x0002BA64 File Offset: 0x00029C64
	public global::Controllable controllable
	{
		get
		{
			if (!this.id)
			{
				return null;
			}
			global::IDMain idOwnerMain = this.idOwnerMain;
			if (!idOwnerMain)
			{
				return null;
			}
			if (idOwnerMain is global::Character)
			{
				return ((global::Character)idOwnerMain).controllable;
			}
			if (idOwnerMain is global::IDeployedObjectMain)
			{
				global::DeployedObjectInfo deployedObjectInfo = ((global::IDeployedObjectMain)idOwnerMain).DeployedObjectInfo;
				if (deployedObjectInfo.valid)
				{
					return deployedObjectInfo.playerControllable;
				}
			}
			return null;
		}
	}

	// Token: 0x1700030C RID: 780
	// (get) Token: 0x06000B3D RID: 2877 RVA: 0x0002BADC File Offset: 0x00029CDC
	public global::PlayerClient client
	{
		get
		{
			if (!this.id)
			{
				return null;
			}
			global::IDMain idOwnerMain = this.idOwnerMain;
			if (!idOwnerMain)
			{
				return null;
			}
			if (idOwnerMain is global::Character)
			{
				return ((global::Character)idOwnerMain).playerClient;
			}
			if (idOwnerMain is global::IDeployedObjectMain)
			{
				global::DeployedObjectInfo deployedObjectInfo = ((global::IDeployedObjectMain)idOwnerMain).DeployedObjectInfo;
				if (deployedObjectInfo.valid)
				{
					return deployedObjectInfo.playerClient;
				}
			}
			global::Controllable component = idOwnerMain.GetComponent<global::Controllable>();
			if (component)
			{
				global::PlayerClient playerClient = component.playerClient;
				if (!playerClient)
				{
					global::Facepunch.NetworkView networkView = component.networkView;
					if (networkView)
					{
						global::PlayerClient.Find(networkView.owner, out playerClient);
					}
				}
				return playerClient;
			}
			return null;
		}
	}

	// Token: 0x1700030D RID: 781
	// (get) Token: 0x06000B3E RID: 2878 RVA: 0x0002BB9C File Offset: 0x00029D9C
	public global::Facepunch.NetworkView networkView
	{
		get
		{
			if (!this.id)
			{
				return null;
			}
			global::IDMain idMain = this.id.idMain;
			if (idMain)
			{
				return idMain.networkView;
			}
			return this.id.networkView;
		}
	}

	// Token: 0x1700030E RID: 782
	// (get) Token: 0x06000B3F RID: 2879 RVA: 0x0002BBE4 File Offset: 0x00029DE4
	public global::Facepunch.NetworkView ownerView
	{
		get
		{
			global::IDMain idmain = (!this.id) ? null : this.id.idMain;
			if (idmain is global::RigidObj)
			{
				return ((global::RigidObj)idmain).ownerView;
			}
			return this.networkView;
		}
	}

	// Token: 0x1700030F RID: 783
	// (get) Token: 0x06000B40 RID: 2880 RVA: 0x0002BC30 File Offset: 0x00029E30
	public global::uLink.NetworkViewID networkViewID
	{
		get
		{
			global::Facepunch.NetworkView networkView = this.networkView;
			if (networkView)
			{
				return networkView.viewID;
			}
			return global::uLink.NetworkViewID.unassigned;
		}
	}

	// Token: 0x17000310 RID: 784
	// (get) Token: 0x06000B41 RID: 2881 RVA: 0x0002BC5C File Offset: 0x00029E5C
	public global::uLink.NetworkViewID ownerViewID
	{
		get
		{
			global::Facepunch.NetworkView ownerView = this.ownerView;
			if (ownerView)
			{
				return ownerView.viewID;
			}
			return global::uLink.NetworkViewID.unassigned;
		}
	}

	// Token: 0x17000311 RID: 785
	// (get) Token: 0x06000B42 RID: 2882 RVA: 0x0002BC88 File Offset: 0x00029E88
	public global::BodyPart bodyPart
	{
		get
		{
			if (this.id is global::IDRemoteBodyPart && this.id)
			{
				return ((global::IDRemoteBodyPart)this.id).bodyPart;
			}
			return 0;
		}
	}

	// Token: 0x06000B43 RID: 2883 RVA: 0x0002BCC8 File Offset: 0x00029EC8
	public bool Equals(global::DamageBeing other)
	{
		return this.id == other.id;
	}

	// Token: 0x06000B44 RID: 2884 RVA: 0x0002BCDC File Offset: 0x00029EDC
	public override bool Equals(object obj)
	{
		return object.Equals(this.id, obj);
	}

	// Token: 0x06000B45 RID: 2885 RVA: 0x0002BCEC File Offset: 0x00029EEC
	public override int GetHashCode()
	{
		return (!this.id) ? 0 : this.id.GetHashCode();
	}

	// Token: 0x06000B46 RID: 2886 RVA: 0x0002BD10 File Offset: 0x00029F10
	public override string ToString()
	{
		if (this.id)
		{
			return string.Format("{{id=({0}),idMain=({1})}}", this.id, this.id.idMain);
		}
		return "{{null}}";
	}

	// Token: 0x06000B47 RID: 2887 RVA: 0x0002BD44 File Offset: 0x00029F44
	public bool IsDifferentPlayer(global::PlayerClient exclude)
	{
		if (!this.id)
		{
			return false;
		}
		global::IDMain idmain = this.idOwnerMain;
		if (!idmain)
		{
			idmain = this.id.idMain;
			if (!idmain)
			{
				return false;
			}
		}
		if (idmain is global::Character)
		{
			global::PlayerClient playerClient = ((global::Character)idmain).playerClient;
			return playerClient && playerClient != exclude;
		}
		if (idmain is global::IDeployedObjectMain)
		{
			global::DeployedObjectInfo deployedObjectInfo = ((global::IDeployedObjectMain)idmain).DeployedObjectInfo;
			if (deployedObjectInfo.valid)
			{
				global::PlayerClient playerClient2 = deployedObjectInfo.playerClient;
				return playerClient2 && playerClient2 != exclude;
			}
		}
		global::Controllable component = idmain.GetComponent<global::Controllable>();
		if (component)
		{
			global::PlayerClient playerClient3 = component.playerClient;
			return playerClient3 && playerClient3 != exclude;
		}
		return false;
	}

	// Token: 0x17000312 RID: 786
	// (get) Token: 0x06000B48 RID: 2888 RVA: 0x0002BE34 File Offset: 0x0002A034
	public ulong userID
	{
		get
		{
			global::PlayerClient client = this.client;
			if (client)
			{
				return client.userID;
			}
			return 0UL;
		}
	}

	// Token: 0x06000B49 RID: 2889 RVA: 0x0002BE5C File Offset: 0x0002A05C
	public static implicit operator global::IDBase(global::DamageBeing being)
	{
		return being.id;
	}

	// Token: 0x06000B4A RID: 2890 RVA: 0x0002BE68 File Offset: 0x0002A068
	public static bool operator true(global::DamageBeing being)
	{
		return being.id;
	}

	// Token: 0x06000B4B RID: 2891 RVA: 0x0002BE7C File Offset: 0x0002A07C
	public static bool operator false(global::DamageBeing being)
	{
		return !being.id;
	}

	// Token: 0x040007A9 RID: 1961
	public global::IDBase id;
}
