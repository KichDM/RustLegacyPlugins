using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020005D9 RID: 1497
public class GameGizmo : global::UnityEngine.ScriptableObject
{
	// Token: 0x060030BF RID: 12479 RVA: 0x000B9BAC File Offset: 0x000B7DAC
	public GameGizmo()
	{
	}

	// Token: 0x17000A32 RID: 2610
	// (get) Token: 0x060030C0 RID: 12480 RVA: 0x000B9BEC File Offset: 0x000B7DEC
	public float minAlpha
	{
		get
		{
			return this._minAlpha;
		}
	}

	// Token: 0x17000A33 RID: 2611
	// (get) Token: 0x060030C1 RID: 12481 RVA: 0x000B9BF4 File Offset: 0x000B7DF4
	public float maxAlpha
	{
		get
		{
			return this._maxAlpha;
		}
	}

	// Token: 0x17000A34 RID: 2612
	// (get) Token: 0x060030C2 RID: 12482 RVA: 0x000B9BFC File Offset: 0x000B7DFC
	public global::UnityEngine.Color goodColor
	{
		get
		{
			return this._good;
		}
	}

	// Token: 0x17000A35 RID: 2613
	// (get) Token: 0x060030C3 RID: 12483 RVA: 0x000B9C04 File Offset: 0x000B7E04
	public global::UnityEngine.Color badColor
	{
		get
		{
			return this._bad;
		}
	}

	// Token: 0x060030C4 RID: 12484 RVA: 0x000B9C0C File Offset: 0x000B7E0C
	protected virtual global::GameGizmo.Instance ConstructInstance()
	{
		return new global::GameGizmo.Instance(this);
	}

	// Token: 0x060030C5 RID: 12485 RVA: 0x000B9C14 File Offset: 0x000B7E14
	private bool CreateInstance(out global::GameGizmo.Instance instance, global::System.Type type)
	{
		try
		{
			instance = this.ConstructInstance();
			if (object.ReferenceEquals(instance, null))
			{
				return false;
			}
			if (this._instances == null)
			{
				this._instances = new global::System.Collections.Generic.HashSet<global::GameGizmo.Instance>();
			}
			this._instances.Add(instance);
			if (!type.IsAssignableFrom(instance.GetType()))
			{
				this.DestroyInstance(instance);
				throw new global::System.InvalidCastException();
			}
		}
		catch (global::System.Exception ex)
		{
			global::UnityEngine.Debug.LogException(ex, this);
			instance = null;
			return false;
		}
		return true;
	}

	// Token: 0x060030C6 RID: 12486 RVA: 0x000B9CC0 File Offset: 0x000B7EC0
	public bool Create<TInstance>(out TInstance instance) where TInstance : global::GameGizmo.Instance
	{
		global::GameGizmo.Instance instance2;
		if (this.CreateInstance(out instance2, typeof(TInstance)))
		{
			instance = (TInstance)((object)instance2);
			return true;
		}
		instance = (TInstance)((object)null);
		return false;
	}

	// Token: 0x060030C7 RID: 12487 RVA: 0x000B9D00 File Offset: 0x000B7F00
	protected virtual void DeconstructInstance(global::GameGizmo.Instance instance)
	{
	}

	// Token: 0x060030C8 RID: 12488 RVA: 0x000B9D04 File Offset: 0x000B7F04
	private bool DestroyInstance(global::GameGizmo.Instance instance)
	{
		if (!object.ReferenceEquals(instance, null) && this._instances != null && this._instances.Remove(instance))
		{
			try
			{
				instance.ClearResources();
				this.DeconstructInstance(instance);
			}
			catch (global::System.Exception ex)
			{
				global::UnityEngine.Debug.LogException(ex, this);
			}
			return true;
		}
		return false;
	}

	// Token: 0x060030C9 RID: 12489 RVA: 0x000B9D78 File Offset: 0x000B7F78
	public bool Destroy<TInstance>(ref TInstance instance) where TInstance : global::GameGizmo.Instance
	{
		if (this.DestroyInstance(instance))
		{
			instance = (TInstance)((object)null);
			return true;
		}
		return false;
	}

	// Token: 0x04001A72 RID: 6770
	[global::UnityEngine.SerializeField]
	private global::UnityEngine.Mesh _mesh;

	// Token: 0x04001A73 RID: 6771
	[global::UnityEngine.SerializeField]
	private global::UnityEngine.Material[] _materials;

	// Token: 0x04001A74 RID: 6772
	[global::UnityEngine.SerializeField]
	private bool _castShadows;

	// Token: 0x04001A75 RID: 6773
	[global::UnityEngine.SerializeField]
	private bool _receiveShadows;

	// Token: 0x04001A76 RID: 6774
	[global::UnityEngine.SerializeField]
	private int _layer;

	// Token: 0x04001A77 RID: 6775
	[global::UnityEngine.SerializeField]
	private global::UnityEngine.Color _good = global::UnityEngine.Color.green;

	// Token: 0x04001A78 RID: 6776
	[global::UnityEngine.SerializeField]
	private global::UnityEngine.Color _bad = global::UnityEngine.Color.red;

	// Token: 0x04001A79 RID: 6777
	[global::UnityEngine.SerializeField]
	private float _minAlpha = 0.9f;

	// Token: 0x04001A7A RID: 6778
	[global::UnityEngine.SerializeField]
	private float _maxAlpha = 1f;

	// Token: 0x04001A7B RID: 6779
	[global::UnityEngine.SerializeField]
	private global::UnityEngine.Vector3 alternateArrowDirection;

	// Token: 0x04001A7C RID: 6780
	private global::System.Collections.Generic.HashSet<global::GameGizmo.Instance> _instances;

	// Token: 0x020005DA RID: 1498
	public class Instance
	{
		// Token: 0x060030CA RID: 12490 RVA: 0x000B9DA0 File Offset: 0x000B7FA0
		protected internal Instance(global::GameGizmo gizmo)
		{
			this.localPosition = global::UnityEngine.Vector3.zero;
			this.localRotation = global::UnityEngine.Quaternion.identity;
			this.localScale = global::UnityEngine.Vector3.one;
			this.gameGizmo = gizmo;
			this.propertyBlock = new global::UnityEngine.MaterialPropertyBlock();
		}

		// Token: 0x17000A36 RID: 2614
		// (get) Token: 0x060030CB RID: 12491 RVA: 0x000B9DF4 File Offset: 0x000B7FF4
		protected int layer
		{
			get
			{
				return this.gameGizmo._layer;
			}
		}

		// Token: 0x17000A37 RID: 2615
		// (get) Token: 0x060030CC RID: 12492 RVA: 0x000B9E04 File Offset: 0x000B8004
		protected bool castShadows
		{
			get
			{
				return this.gameGizmo._castShadows;
			}
		}

		// Token: 0x17000A38 RID: 2616
		// (get) Token: 0x060030CD RID: 12493 RVA: 0x000B9E14 File Offset: 0x000B8014
		protected bool receiveShadows
		{
			get
			{
				return this.gameGizmo._receiveShadows;
			}
		}

		// Token: 0x060030CE RID: 12494 RVA: 0x000B9E24 File Offset: 0x000B8024
		public void AddResourceToDelete(global::UnityEngine.Object resource)
		{
			if (resource)
			{
				global::System.Collections.Generic.List<global::UnityEngine.Object> list;
				if ((list = this.resources) == null)
				{
					list = (this.resources = new global::System.Collections.Generic.List<global::UnityEngine.Object>());
				}
				list.Add(resource);
			}
		}

		// Token: 0x060030CF RID: 12495 RVA: 0x000B9E60 File Offset: 0x000B8060
		internal void ClearResources()
		{
			global::System.Collections.Generic.List<global::UnityEngine.Object> list = this.resources;
			if (list != null)
			{
				this.resources = null;
				foreach (global::UnityEngine.Object @object in list)
				{
					global::UnityEngine.Object.Destroy(@object);
				}
			}
		}

		// Token: 0x17000A39 RID: 2617
		// (get) Token: 0x060030D0 RID: 12496 RVA: 0x000B9ED4 File Offset: 0x000B80D4
		// (set) Token: 0x060030D1 RID: 12497 RVA: 0x000B9F10 File Offset: 0x000B8110
		public global::UnityEngine.Vector3 position
		{
			get
			{
				return (!this._parent) ? this.localPosition : this._parent.TransformPoint(this.localPosition);
			}
			set
			{
				if (this._parent)
				{
					this.localPosition = this._parent.InverseTransformPoint(value);
				}
				else
				{
					this.localPosition = value;
				}
			}
		}

		// Token: 0x17000A3A RID: 2618
		// (get) Token: 0x060030D2 RID: 12498 RVA: 0x000B9F4C File Offset: 0x000B814C
		// (set) Token: 0x060030D3 RID: 12499 RVA: 0x000B9F80 File Offset: 0x000B8180
		public global::UnityEngine.Quaternion rotation
		{
			get
			{
				return (!this._parent) ? this.localRotation : (this.localRotation * this._parent.rotation);
			}
			set
			{
				if (this._parent)
				{
					this.localRotation = global::UnityEngine.Quaternion.Inverse(this._parent.rotation) * value;
				}
				else
				{
					this.localRotation = value;
				}
			}
		}

		// Token: 0x17000A3B RID: 2619
		// (get) Token: 0x060030D4 RID: 12500 RVA: 0x000B9FC8 File Offset: 0x000B81C8
		// (set) Token: 0x060030D5 RID: 12501 RVA: 0x000B9FD0 File Offset: 0x000B81D0
		public global::UnityEngine.Transform parent
		{
			get
			{
				return this._parent;
			}
			set
			{
				if (value != this._parent)
				{
					if (value)
					{
						this.localPosition = value.InverseTransformPoint(this.position);
						this.localRotation = global::UnityEngine.Quaternion.Inverse(value.rotation) * this.rotation;
						this._parent = value;
					}
					else
					{
						this._parent = null;
					}
				}
			}
		}

		// Token: 0x060030D6 RID: 12502 RVA: 0x000BA03C File Offset: 0x000B823C
		protected global::UnityEngine.Matrix4x4 DefaultMatrix()
		{
			global::UnityEngine.Matrix4x4 matrix4x = global::UnityEngine.Matrix4x4.TRS(this.localPosition, this.localRotation, this.localScale);
			if (this._parent)
			{
				matrix4x = this._parent.localToWorldMatrix * matrix4x;
			}
			return matrix4x;
		}

		// Token: 0x060030D7 RID: 12503 RVA: 0x000BA084 File Offset: 0x000B8284
		public void Render()
		{
			this.Render(false, null);
		}

		// Token: 0x060030D8 RID: 12504 RVA: 0x000BA090 File Offset: 0x000B8290
		public void Render(global::UnityEngine.Camera camera)
		{
			this.Render(camera, camera);
		}

		// Token: 0x060030D9 RID: 12505 RVA: 0x000BA0A0 File Offset: 0x000B82A0
		protected virtual void Render(bool useCamera, global::UnityEngine.Camera camera)
		{
			if (this.hideMesh)
			{
				return;
			}
			global::UnityEngine.Mesh mesh = this.gameGizmo._mesh;
			if (!mesh)
			{
				return;
			}
			global::UnityEngine.Material[] materials = this.gameGizmo._materials;
			int num;
			if (materials == null || (num = materials.Length) == 0)
			{
				return;
			}
			global::UnityEngine.Matrix4x4? matrix4x = this.ultimateMatrix;
			global::UnityEngine.Matrix4x4 matrix4x2;
			if (matrix4x != null)
			{
				matrix4x2 = matrix4x.Value;
			}
			else
			{
				global::UnityEngine.Matrix4x4? matrix4x3 = this.overrideMatrix;
				matrix4x2 = ((matrix4x3 == null) ? this.DefaultMatrix() : matrix4x3.Value);
			}
			global::UnityEngine.Matrix4x4 matrix4x4 = matrix4x2;
			if (this.gameGizmo.alternateArrowDirection != global::UnityEngine.Vector3.zero)
			{
				matrix4x4 *= global::UnityEngine.Matrix4x4.TRS(global::UnityEngine.Vector3.zero, global::UnityEngine.Quaternion.Euler(this.gameGizmo.alternateArrowDirection), global::UnityEngine.Vector3.one);
			}
			for (int i = 0; i < mesh.subMeshCount; i++)
			{
				global::UnityEngine.Graphics.DrawMesh(mesh, matrix4x4, materials[i % num], this.gameGizmo._layer, camera, i, this.propertyBlock, this.gameGizmo._castShadows, this.gameGizmo._receiveShadows);
			}
		}

		// Token: 0x04001A7D RID: 6781
		[global::System.NonSerialized]
		public readonly global::GameGizmo gameGizmo;

		// Token: 0x04001A7E RID: 6782
		[global::System.NonSerialized]
		public readonly global::UnityEngine.MaterialPropertyBlock propertyBlock;

		// Token: 0x04001A7F RID: 6783
		[global::System.NonSerialized]
		public global::UnityEngine.Vector3 localPosition;

		// Token: 0x04001A80 RID: 6784
		[global::System.NonSerialized]
		public global::UnityEngine.Quaternion localRotation;

		// Token: 0x04001A81 RID: 6785
		[global::System.NonSerialized]
		public global::UnityEngine.Vector3 localScale;

		// Token: 0x04001A82 RID: 6786
		[global::System.NonSerialized]
		public global::UnityEngine.Matrix4x4? overrideMatrix;

		// Token: 0x04001A83 RID: 6787
		[global::System.NonSerialized]
		public global::UnityEngine.MeshRenderer carrierRenderer;

		// Token: 0x04001A84 RID: 6788
		protected global::UnityEngine.Matrix4x4? ultimateMatrix;

		// Token: 0x04001A85 RID: 6789
		protected bool hideMesh;

		// Token: 0x04001A86 RID: 6790
		private global::System.Collections.Generic.List<global::UnityEngine.Object> resources = new global::System.Collections.Generic.List<global::UnityEngine.Object>();

		// Token: 0x04001A87 RID: 6791
		private global::UnityEngine.Transform _parent;
	}
}
