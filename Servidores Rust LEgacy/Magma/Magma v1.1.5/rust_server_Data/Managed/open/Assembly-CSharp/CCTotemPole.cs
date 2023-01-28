using System;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x0200031A RID: 794
public sealed class CCTotemPole : global::CCTotem<global::CCTotem.TotemPole, global::CCTotemPole>
{
	// Token: 0x06001AC1 RID: 6849 RVA: 0x00069778 File Offset: 0x00067978
	public CCTotemPole()
	{
	}

	// Token: 0x1400000D RID: 13
	// (add) Token: 0x06001AC2 RID: 6850 RVA: 0x000697B8 File Offset: 0x000679B8
	// (remove) Token: 0x06001AC3 RID: 6851 RVA: 0x000697D4 File Offset: 0x000679D4
	public event global::CCTotem.PositionBinder OnBindPosition
	{
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		add
		{
			this.OnBindPosition = (global::CCTotem.PositionBinder)global::System.Delegate.Combine(this.OnBindPosition, value);
		}
		[global::System.Runtime.CompilerServices.MethodImpl(global::System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
		remove
		{
			this.OnBindPosition = (global::CCTotem.PositionBinder)global::System.Delegate.Remove(this.OnBindPosition, value);
		}
	}

	// Token: 0x1400000E RID: 14
	// (add) Token: 0x06001AC4 RID: 6852 RVA: 0x000697F0 File Offset: 0x000679F0
	// (remove) Token: 0x06001AC5 RID: 6853 RVA: 0x0006983C File Offset: 0x00067A3C
	public event global::CCTotem.ConfigurationBinder OnConfigurationBinding
	{
		add
		{
			if (!object.ReferenceEquals(this.ConfigurationBinder, value))
			{
				if (!object.ReferenceEquals(this.ConfigurationBinder, null))
				{
					this.ExecuteAllBindings(false);
					this.ConfigurationBinder = null;
				}
				this.ConfigurationBinder = value;
				this.ExecuteAllBindings(true);
			}
		}
		remove
		{
			if (object.ReferenceEquals(this.ConfigurationBinder, value))
			{
				this.ExecuteAllBindings(false);
				if (object.ReferenceEquals(this.ConfigurationBinder, value))
				{
					this.ConfigurationBinder = null;
				}
			}
		}
	}

	// Token: 0x17000768 RID: 1896
	// (get) Token: 0x06001AC6 RID: 6854 RVA: 0x0006987C File Offset: 0x00067A7C
	public bool Exists
	{
		get
		{
			return !object.ReferenceEquals(this.totemicObject, null);
		}
	}

	// Token: 0x17000769 RID: 1897
	// (get) Token: 0x06001AC7 RID: 6855 RVA: 0x00069890 File Offset: 0x00067A90
	public float MinimumHeight
	{
		get
		{
			return this.minimumHeight;
		}
	}

	// Token: 0x1700076A RID: 1898
	// (get) Token: 0x06001AC8 RID: 6856 RVA: 0x00069898 File Offset: 0x00067A98
	public float MaximumHeight
	{
		get
		{
			return this.maximumHeight;
		}
	}

	// Token: 0x1700076B RID: 1899
	// (get) Token: 0x06001AC9 RID: 6857 RVA: 0x000698A0 File Offset: 0x00067AA0
	public float Height
	{
		get
		{
			return (!this.Exists) ? (this.minimumHeight + this.initialHeightFraction * (this.maximumHeight - this.minimumHeight)) : this.totemicObject.Expansion.Value;
		}
	}

	// Token: 0x1700076C RID: 1900
	// (get) Token: 0x06001ACA RID: 6858 RVA: 0x000698E0 File Offset: 0x00067AE0
	private global::CCTotem.Initialization Members
	{
		get
		{
			return new global::CCTotem.Initialization(this, this.prefab, this.minimumHeight, this.maximumHeight, this.minimumHeight + (this.maximumHeight - this.minimumHeight) * this.initialHeightFraction, this.bottomBufferUnits);
		}
	}

	// Token: 0x1700076D RID: 1901
	// (get) Token: 0x06001ACB RID: 6859 RVA: 0x0006991C File Offset: 0x00067B1C
	public bool isGrounded
	{
		get
		{
			return this.Exists && this.totemicObject.isGrounded;
		}
	}

	// Token: 0x1700076E RID: 1902
	// (get) Token: 0x06001ACC RID: 6860 RVA: 0x00069938 File Offset: 0x00067B38
	public global::UnityEngine.Vector3 velocity
	{
		get
		{
			return (!this.Exists) ? global::UnityEngine.Vector3.zero : this.totemicObject.velocity;
		}
	}

	// Token: 0x1700076F RID: 1903
	// (get) Token: 0x06001ACD RID: 6861 RVA: 0x00069968 File Offset: 0x00067B68
	public global::UnityEngine.CollisionFlags collisionFlags
	{
		get
		{
			return (!this.Exists) ? 0 : this.totemicObject.collisionFlags;
		}
	}

	// Token: 0x17000770 RID: 1904
	// (get) Token: 0x06001ACE RID: 6862 RVA: 0x00069988 File Offset: 0x00067B88
	public float stepOffset
	{
		get
		{
			return (!this.Exists) ? this.prefab.stepOffset : this.totemicObject.stepOffset;
		}
	}

	// Token: 0x17000771 RID: 1905
	// (get) Token: 0x06001ACF RID: 6863 RVA: 0x000699BC File Offset: 0x00067BBC
	public float slopeLimit
	{
		get
		{
			return (!this.Exists) ? this.prefab.slopeLimit : this.totemicObject.slopeLimit;
		}
	}

	// Token: 0x17000772 RID: 1906
	// (get) Token: 0x06001AD0 RID: 6864 RVA: 0x000699F0 File Offset: 0x00067BF0
	public global::UnityEngine.Vector3 center
	{
		get
		{
			return (!this.Exists) ? this.prefab.center : this.totemicObject.center;
		}
	}

	// Token: 0x17000773 RID: 1907
	// (get) Token: 0x06001AD1 RID: 6865 RVA: 0x00069A24 File Offset: 0x00067C24
	[global::System.Obsolete("this is the height of the character controller. prefer this.Height")]
	public float height
	{
		get
		{
			return (!this.Exists) ? this.prefab.height : this.totemicObject.height;
		}
	}

	// Token: 0x17000774 RID: 1908
	// (get) Token: 0x06001AD2 RID: 6866 RVA: 0x00069A58 File Offset: 0x00067C58
	public float radius
	{
		get
		{
			return (!this.Exists) ? this.prefab.radius : this.totemicObject.radius;
		}
	}

	// Token: 0x06001AD3 RID: 6867 RVA: 0x00069A8C File Offset: 0x00067C8C
	public bool UpdateConfiguration()
	{
		this.LastException = null;
		global::CCTotem.Initialization members = this.Members;
		bool result;
		try
		{
			this.LastGoodConfiguration = new global::CCTotem.Configuration(ref members);
			this.HasLastGoodConfiguration = true;
			result = true;
		}
		catch (global::System.ArgumentException lastException)
		{
			this.LastException = lastException;
			result = false;
		}
		return result;
	}

	// Token: 0x06001AD4 RID: 6868 RVA: 0x00069AF8 File Offset: 0x00067CF8
	private void Awake()
	{
		if (!this.UpdateConfiguration())
		{
			global::UnityEngine.Debug.LogException(this.LastException, this);
			return;
		}
		this.CreatePhysics();
	}

	// Token: 0x06001AD5 RID: 6869 RVA: 0x00069B18 File Offset: 0x00067D18
	private void CreatePhysics()
	{
		if (!this.HasLastGoodConfiguration && !this.UpdateConfiguration())
		{
			global::UnityEngine.Debug.LogException(this.LastException, this);
			return;
		}
		base.AssignTotemicObject(new global::CCTotem.TotemPole(ref this.LastGoodConfiguration));
		this.totemicObject.Create();
	}

	// Token: 0x06001AD6 RID: 6870 RVA: 0x00069B64 File Offset: 0x00067D64
	internal void DestroyCCDesc(ref global::CCDesc CCDesc)
	{
		if (CCDesc)
		{
			global::CCDesc ccdesc = CCDesc;
			CCDesc = null;
			this.ExecuteBinding(ccdesc, false);
			global::UnityEngine.Object.Destroy(ccdesc.gameObject);
		}
	}

	// Token: 0x06001AD7 RID: 6871 RVA: 0x00069B98 File Offset: 0x00067D98
	internal void ExecuteBinding(global::CCDesc CCDesc, bool Bind)
	{
		if (CCDesc && !object.ReferenceEquals(this.ConfigurationBinder, null))
		{
			try
			{
				this.ConfigurationBinder(Bind, CCDesc, this.Tag);
			}
			catch (global::System.Exception ex)
			{
				global::UnityEngine.Debug.LogException(ex, this);
			}
		}
	}

	// Token: 0x06001AD8 RID: 6872 RVA: 0x00069C04 File Offset: 0x00067E04
	internal void ExecuteAllBindings(bool Bind)
	{
		if (this.Exists)
		{
			this.ExecuteBinding(this.totemicObject.CCDesc, Bind);
			for (int i = 0; i < this.totemicObject.Configuration.numRequiredTotemicFigures; i++)
			{
				this.ExecuteBinding(this.totemicObject.TotemicFigures[i].CCDesc, Bind);
			}
		}
	}

	// Token: 0x06001AD9 RID: 6873 RVA: 0x00069C6C File Offset: 0x00067E6C
	public global::CCTotem.MoveInfo Move(global::UnityEngine.Vector3 motion)
	{
		return this.Move(motion, this.Height);
	}

	// Token: 0x06001ADA RID: 6874 RVA: 0x00069C7C File Offset: 0x00067E7C
	public global::CCTotem.MoveInfo Move(global::UnityEngine.Vector3 motion, float height)
	{
		global::CCTotem.TotemPole totemicObject = this.totemicObject;
		if (object.ReferenceEquals(totemicObject, null))
		{
			throw new global::System.InvalidOperationException("Exists == false");
		}
		global::CCTotem.MoveInfo result = totemicObject.Move(motion, height);
		this.BindPositions(result.PositionPlacement);
		return result;
	}

	// Token: 0x06001ADB RID: 6875 RVA: 0x00069CC0 File Offset: 0x00067EC0
	public bool SmudgeTo(global::UnityEngine.Vector3 worldSkinnedBottom)
	{
		if (!this.Exists)
		{
			return false;
		}
		global::UnityEngine.Vector3 position = base.transform.position;
		if (position == worldSkinnedBottom)
		{
			return true;
		}
		global::UnityEngine.Vector3 vector = worldSkinnedBottom - position;
		global::CCDesc ccdesc = this.totemicObject.CCDesc;
		if (!ccdesc)
		{
			return false;
		}
		global::UnityEngine.Vector3 vector2;
		vector2.x = (vector2.z = 0f);
		vector2.y = ccdesc.effectiveHeight * 0.5f - ccdesc.radius;
		global::UnityEngine.Vector3 center = ccdesc.center;
		global::UnityEngine.Vector3 vector3 = ccdesc.OffsetToWorld(center - vector2);
		global::UnityEngine.Vector3 vector4 = ccdesc.OffsetToWorld(center + vector2);
		float magnitude = (ccdesc.OffsetToWorld(center + new global::UnityEngine.Vector3(ccdesc.skinnedRadius, 0f, 0f)) - ccdesc.worldCenter).magnitude;
		float magnitude2 = vector.magnitude;
		float num = 1f / magnitude2;
		global::UnityEngine.Vector3 vector5;
		vector5.x = vector.x * num;
		vector5.y = vector.y * num;
		vector5.z = vector.z * num;
		int num2 = 0;
		int layer = base.gameObject.layer;
		for (int i = 0; i < 0x20; i++)
		{
			if (!global::UnityEngine.Physics.GetIgnoreLayerCollision(layer, i))
			{
				num2 |= 1 << i;
			}
		}
		if (global::UnityEngine.Physics.CapsuleCast(vector3, vector4, magnitude, vector5, magnitude2, num2))
		{
			return false;
		}
		this.totemicObject.CCDesc.transform.position += vector;
		for (int j = 0; j < this.totemicObject.Configuration.numRequiredTotemicFigures; j++)
		{
			this.totemicObject.TotemicFigures[j].CCDesc.transform.position += vector;
		}
		this.BindPositions(new global::CCTotem.PositionPlacement(this.totemicObject.CCDesc.worldSkinnedBottom, this.totemicObject.CCDesc.worldSkinnedTop, this.totemicObject.CCDesc.transform.position, this.totemicObject.Configuration.poleExpandedHeight));
		return true;
	}

	// Token: 0x06001ADC RID: 6876 RVA: 0x00069F14 File Offset: 0x00068114
	public void Teleport(global::UnityEngine.Vector3 origin)
	{
		if (this.Exists)
		{
			base.ClearTotemicObject();
		}
		base.transform.position = origin;
		this.CreatePhysics();
	}

	// Token: 0x06001ADD RID: 6877 RVA: 0x00069F44 File Offset: 0x00068144
	private void BindPositions(global::CCTotem.PositionPlacement PositionPlacement)
	{
		if (this.OnBindPosition != null)
		{
			try
			{
				this.OnBindPosition(ref PositionPlacement, this.Tag);
			}
			catch (global::System.Exception ex)
			{
				global::UnityEngine.Debug.LogException(ex, this);
			}
		}
	}

	// Token: 0x06001ADE RID: 6878 RVA: 0x00069FA0 File Offset: 0x000681A0
	private new void OnDestroy()
	{
		try
		{
			base.OnDestroy();
		}
		finally
		{
			this.OnBindPosition = null;
			this.ConfigurationBinder = null;
			this.Tag = null;
		}
	}

	// Token: 0x04000F97 RID: 3991
	[global::UnityEngine.SerializeField]
	private global::CCDesc prefab;

	// Token: 0x04000F98 RID: 3992
	[global::UnityEngine.SerializeField]
	private float minimumHeight = 0.6f;

	// Token: 0x04000F99 RID: 3993
	[global::UnityEngine.SerializeField]
	private float maximumHeight = 2.08f;

	// Token: 0x04000F9A RID: 3994
	[global::UnityEngine.SerializeField]
	private float initialHeightFraction = 1f;

	// Token: 0x04000F9B RID: 3995
	[global::UnityEngine.SerializeField]
	private float bottomBufferUnits = 0.1f;

	// Token: 0x04000F9C RID: 3996
	[global::System.NonSerialized]
	private bool HasLastGoodConfiguration;

	// Token: 0x04000F9D RID: 3997
	[global::System.NonSerialized]
	private global::CCTotem.Configuration LastGoodConfiguration;

	// Token: 0x04000F9E RID: 3998
	[global::System.NonSerialized]
	private new global::CCTotem.ConfigurationBinder ConfigurationBinder;

	// Token: 0x04000F9F RID: 3999
	[global::System.NonSerialized]
	public global::System.ArgumentException LastException;

	// Token: 0x04000FA0 RID: 4000
	[global::System.NonSerialized]
	public object Tag;

	// Token: 0x04000FA1 RID: 4001
	private global::CCTotem.PositionBinder OnBindPosition;
}
