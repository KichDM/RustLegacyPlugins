using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x0200044B RID: 1099
public abstract class Socket
{
	// Token: 0x0600260F RID: 9743 RVA: 0x00092358 File Offset: 0x00090558
	protected Socket(bool is_vm)
	{
		this.is_vm = is_vm;
	}

	// Token: 0x17000873 RID: 2163
	// (get) Token: 0x06002610 RID: 9744 RVA: 0x00092368 File Offset: 0x00090568
	public global::UnityEngine.Transform attachParent
	{
		get
		{
			if (this.is_vm)
			{
				return ((global::Socket.CameraSpace)this).attachParent;
			}
			return this.parent;
		}
	}

	// Token: 0x17000874 RID: 2164
	// (get) Token: 0x06002611 RID: 9745 RVA: 0x00092388 File Offset: 0x00090588
	public global::UnityEngine.Vector3 position
	{
		get
		{
			if (this.is_vm)
			{
				return ((global::Socket.CameraSpace)this).position;
			}
			return ((global::Socket.LocalSpace)this).position;
		}
	}

	// Token: 0x17000875 RID: 2165
	// (get) Token: 0x06002612 RID: 9746 RVA: 0x000923B8 File Offset: 0x000905B8
	public global::UnityEngine.Quaternion rotation
	{
		get
		{
			if (this.is_vm)
			{
				return ((global::Socket.CameraSpace)this).rotation;
			}
			return ((global::Socket.LocalSpace)this).rotation;
		}
	}

	// Token: 0x17000876 RID: 2166
	// (get) Token: 0x06002613 RID: 9747 RVA: 0x000923E8 File Offset: 0x000905E8
	public global::UnityEngine.Vector3 localPosition
	{
		get
		{
			return this.offset;
		}
	}

	// Token: 0x17000877 RID: 2167
	// (get) Token: 0x06002614 RID: 9748 RVA: 0x000923F0 File Offset: 0x000905F0
	public global::UnityEngine.Quaternion localRotation
	{
		get
		{
			return this.rotate;
		}
	}

	// Token: 0x06002615 RID: 9749 RVA: 0x000923F8 File Offset: 0x000905F8
	public bool AddChild(global::UnityEngine.Transform transform, bool snap)
	{
		if (this.is_vm)
		{
			return ((global::Socket.CameraSpace)this).AddChild(transform, snap);
		}
		return ((global::Socket.LocalSpace)this).AddChild(transform, snap);
	}

	// Token: 0x06002616 RID: 9750 RVA: 0x0009242C File Offset: 0x0009062C
	public bool AddChildWithCoords(global::UnityEngine.Transform transform, global::UnityEngine.Vector3 offsetFromThisSocket)
	{
		if (this.is_vm)
		{
			return ((global::Socket.CameraSpace)this).AddChildWithCoords(transform, offsetFromThisSocket);
		}
		return ((global::Socket.LocalSpace)this).AddChildWithCoords(transform, offsetFromThisSocket);
	}

	// Token: 0x06002617 RID: 9751 RVA: 0x00092460 File Offset: 0x00090660
	public bool AddChildWithCoords(global::UnityEngine.Transform transform, global::UnityEngine.Vector3 offsetFromThisSocket, global::UnityEngine.Vector3 eulerOffsetFromThisSocket)
	{
		if (this.is_vm)
		{
			return ((global::Socket.CameraSpace)this).AddChildWithCoords(transform, offsetFromThisSocket, eulerOffsetFromThisSocket);
		}
		return ((global::Socket.LocalSpace)this).AddChildWithCoords(transform, offsetFromThisSocket, eulerOffsetFromThisSocket);
	}

	// Token: 0x06002618 RID: 9752 RVA: 0x00092498 File Offset: 0x00090698
	public bool AddChildWithCoords(global::UnityEngine.Transform transform, global::UnityEngine.Vector3 offsetFromThisSocket, global::UnityEngine.Quaternion rotationalOffsetFromThisSocket)
	{
		if (this.is_vm)
		{
			return ((global::Socket.CameraSpace)this).AddChildWithCoords(transform, offsetFromThisSocket, rotationalOffsetFromThisSocket);
		}
		return ((global::Socket.LocalSpace)this).AddChildWithCoords(transform, offsetFromThisSocket, rotationalOffsetFromThisSocket);
	}

	// Token: 0x17000878 RID: 2168
	// (get) Token: 0x06002619 RID: 9753 RVA: 0x000924D0 File Offset: 0x000906D0
	public global::UnityEngine.Quaternion rotate
	{
		get
		{
			if (!this.got_last || this.rotate_last != this.eulerRotate)
			{
				this.rotate_last = this.eulerRotate;
				this.quat_last = global::UnityEngine.Quaternion.Euler(this.eulerRotate);
				this.got_last = true;
			}
			return this.quat_last;
		}
	}

	// Token: 0x0600261A RID: 9754 RVA: 0x00092528 File Offset: 0x00090728
	public void Rotate(global::UnityEngine.Quaternion rotation)
	{
		if (this.is_vm)
		{
			((global::Socket.CameraSpace)this).Rotate(rotation);
		}
		else
		{
			((global::Socket.LocalSpace)this).Rotate(rotation);
		}
	}

	// Token: 0x0600261B RID: 9755 RVA: 0x00092560 File Offset: 0x00090760
	public void UnRotate(global::UnityEngine.Quaternion rotation)
	{
		if (this.is_vm)
		{
			((global::Socket.CameraSpace)this).UnRotate(rotation);
		}
		else
		{
			((global::Socket.LocalSpace)this).UnRotate(rotation);
		}
	}

	// Token: 0x0600261C RID: 9756 RVA: 0x00092598 File Offset: 0x00090798
	public void DrawGizmos(string icon)
	{
		global::UnityEngine.Matrix4x4 matrix = global::UnityEngine.Gizmos.matrix;
		if (this.parent)
		{
			global::UnityEngine.Gizmos.matrix = this.parent.localToWorldMatrix;
		}
		global::UnityEngine.Gizmos.matrix *= global::UnityEngine.Matrix4x4.TRS(this.offset, this.rotate, global::UnityEngine.Vector3.one);
		global::UnityEngine.Color color = global::UnityEngine.Gizmos.color;
		global::UnityEngine.Gizmos.color = color * global::UnityEngine.Color.red;
		global::UnityEngine.Gizmos.DrawLine(global::UnityEngine.Vector3.zero, global::UnityEngine.Vector3.right * 0.1f);
		if (icon != null)
		{
			global::UnityEngine.Gizmos.DrawIcon(global::UnityEngine.Vector3.left, icon);
		}
		global::UnityEngine.Gizmos.color = color * global::UnityEngine.Color.green;
		global::UnityEngine.Gizmos.DrawLine(global::UnityEngine.Vector3.zero, global::UnityEngine.Vector3.up * 0.1f);
		if (icon != null)
		{
			global::UnityEngine.Gizmos.DrawIcon(global::UnityEngine.Vector3.down, icon);
		}
		global::UnityEngine.Gizmos.color = color * global::UnityEngine.Color.blue;
		global::UnityEngine.Gizmos.DrawLine(global::UnityEngine.Vector3.zero, global::UnityEngine.Vector3.forward * 0.1f);
		global::UnityEngine.Gizmos.matrix = matrix;
		global::UnityEngine.Gizmos.color = color;
	}

	// Token: 0x0600261D RID: 9757 RVA: 0x000926A0 File Offset: 0x000908A0
	private void AddInstanceChild(global::UnityEngine.Transform tr, bool snap)
	{
		if (!this.AddChild(tr, snap))
		{
			global::UnityEngine.Debug.LogWarning("Could not add child!", tr);
		}
	}

	// Token: 0x0600261E RID: 9758 RVA: 0x000926BC File Offset: 0x000908BC
	public global::UnityEngine.Transform InstantiateAsChild(global::UnityEngine.Transform prefab, bool snap)
	{
		global::UnityEngine.Transform transform = (global::UnityEngine.Transform)global::UnityEngine.Object.Instantiate(prefab, this.position, this.rotation);
		this.AddInstanceChild(transform, snap);
		return transform;
	}

	// Token: 0x0600261F RID: 9759 RVA: 0x000926EC File Offset: 0x000908EC
	public global::UnityEngine.GameObject InstantiateAsChild(global::UnityEngine.GameObject prefab, bool snap)
	{
		global::UnityEngine.GameObject gameObject = (global::UnityEngine.GameObject)global::UnityEngine.Object.Instantiate(prefab, this.position, this.rotation);
		this.AddInstanceChild(gameObject.transform, snap);
		return gameObject;
	}

	// Token: 0x06002620 RID: 9760 RVA: 0x00092720 File Offset: 0x00090920
	public TComponent InstantiateAsChild<TComponent>(TComponent prefab, bool snap) where TComponent : global::UnityEngine.Component
	{
		TComponent result = (TComponent)((object)global::UnityEngine.Object.Instantiate(prefab, this.position, this.rotation));
		this.AddInstanceChild(result.transform, snap);
		return result;
	}

	// Token: 0x06002621 RID: 9761 RVA: 0x00092760 File Offset: 0x00090960
	public TObject Instantiate<TObject>(TObject prefab) where TObject : global::UnityEngine.Object
	{
		return (TObject)((object)global::UnityEngine.Object.Instantiate(prefab, this.position, this.rotation));
	}

	// Token: 0x06002622 RID: 9762 RVA: 0x00092780 File Offset: 0x00090980
	public void Snap()
	{
		if (this.is_vm)
		{
			((global::Socket.CameraSpace)this).Snap();
		}
	}

	// Token: 0x04001369 RID: 4969
	public global::UnityEngine.Transform parent;

	// Token: 0x0400136A RID: 4970
	public global::UnityEngine.Vector3 offset;

	// Token: 0x0400136B RID: 4971
	public global::UnityEngine.Vector3 eulerRotate;

	// Token: 0x0400136C RID: 4972
	private readonly bool is_vm;

	// Token: 0x0400136D RID: 4973
	private global::UnityEngine.Vector3 rotate_last;

	// Token: 0x0400136E RID: 4974
	private global::UnityEngine.Quaternion quat_last;

	// Token: 0x0400136F RID: 4975
	private bool got_last;

	// Token: 0x0200044C RID: 1100
	public struct CameraConversion : global::System.IEquatable<global::Socket.CameraConversion>
	{
		// Token: 0x06002623 RID: 9763 RVA: 0x00092798 File Offset: 0x00090998
		public CameraConversion(global::UnityEngine.Transform World, global::UnityEngine.Transform Camera)
		{
			this.Eye = World;
			this.Shelf = Camera;
			this.Provided = (World != Camera && World && Camera);
		}

		// Token: 0x17000879 RID: 2169
		// (get) Token: 0x06002624 RID: 9764 RVA: 0x000927DC File Offset: 0x000909DC
		public bool Valid
		{
			get
			{
				return this.Provided && this.Eye && this.Shelf;
			}
		}

		// Token: 0x06002625 RID: 9765 RVA: 0x00092808 File Offset: 0x00090A08
		public bool Equals(global::Socket.CameraConversion other)
		{
			return (!this.Provided) ? (!other.Provided) : (other.Provided && this.Eye == other.Eye && this.Shelf == other.Shelf);
		}

		// Token: 0x06002626 RID: 9766 RVA: 0x00092868 File Offset: 0x00090A68
		public override bool Equals(object obj)
		{
			return obj is global::Socket.CameraConversion && this.Equals((global::Socket.CameraConversion)obj);
		}

		// Token: 0x06002627 RID: 9767 RVA: 0x00092884 File Offset: 0x00090A84
		public override string ToString()
		{
			return (!this.Valid) ? ((!this.Provided) ? "[CameraConversion:NotProvided]" : "[CameraConversion:Invalid]") : "[CameraConversion:Valid]";
		}

		// Token: 0x06002628 RID: 9768 RVA: 0x000928B8 File Offset: 0x00090AB8
		public override int GetHashCode()
		{
			return (!this.Provided) ? 0 : (this.Eye.GetHashCode() ^ this.Shelf.GetHashCode());
		}

		// Token: 0x1700087A RID: 2170
		// (get) Token: 0x06002629 RID: 9769 RVA: 0x000928F0 File Offset: 0x00090AF0
		public static global::Socket.CameraConversion None
		{
			get
			{
				return default(global::Socket.CameraConversion);
			}
		}

		// Token: 0x0600262A RID: 9770 RVA: 0x00092908 File Offset: 0x00090B08
		public static implicit operator bool(global::Socket.CameraConversion cc)
		{
			return cc.Valid;
		}

		// Token: 0x0600262B RID: 9771 RVA: 0x00092914 File Offset: 0x00090B14
		public static bool operator true(global::Socket.CameraConversion cc)
		{
			return cc.Valid;
		}

		// Token: 0x0600262C RID: 9772 RVA: 0x00092920 File Offset: 0x00090B20
		public static bool operator false(global::Socket.CameraConversion cc)
		{
			return !cc.Valid;
		}

		// Token: 0x04001370 RID: 4976
		public readonly global::UnityEngine.Transform Eye;

		// Token: 0x04001371 RID: 4977
		public readonly global::UnityEngine.Transform Shelf;

		// Token: 0x04001372 RID: 4978
		public readonly bool Provided;
	}

	// Token: 0x0200044D RID: 1101
	[global::System.Serializable]
	public sealed class CameraSpace : global::Socket
	{
		// Token: 0x0600262D RID: 9773 RVA: 0x0009292C File Offset: 0x00090B2C
		public CameraSpace() : base(true)
		{
		}

		// Token: 0x0600262E RID: 9774 RVA: 0x00092938 File Offset: 0x00090B38
		public static void UpdateProxy(global::UnityEngine.Transform key, global::UnityEngine.Transform value, global::UnityEngine.Transform shelf, global::UnityEngine.Transform eye)
		{
			value.position = eye.TransformPoint(shelf.InverseTransformPoint(key.position));
			global::UnityEngine.Vector3 vector = eye.TransformDirection(shelf.InverseTransformDirection(key.forward));
			global::UnityEngine.Vector3 vector2 = eye.TransformDirection(shelf.InverseTransformDirection(key.up));
			value.rotation = global::UnityEngine.Quaternion.LookRotation(vector, vector2);
		}

		// Token: 0x1700087B RID: 2171
		// (get) Token: 0x0600262F RID: 9775 RVA: 0x00092990 File Offset: 0x00090B90
		public new global::UnityEngine.Vector3 position
		{
			get
			{
				global::UnityEngine.Vector3 vector;
				if (this.root)
				{
					if (this.parent && this.parent != this.root)
					{
						vector = this.root.InverseTransformPoint(this.parent.TransformPoint(this.offset));
					}
					else
					{
						vector = this.offset;
					}
				}
				else if (this.parent)
				{
					vector = this.parent.TransformPoint(this.offset);
				}
				else
				{
					vector = this.offset;
				}
				return (!this.eye) ? vector : this.eye.TransformPoint(vector);
			}
		}

		// Token: 0x1700087C RID: 2172
		// (get) Token: 0x06002630 RID: 9776 RVA: 0x00092A54 File Offset: 0x00090C54
		public new global::UnityEngine.Quaternion rotation
		{
			get
			{
				global::UnityEngine.Quaternion quaternion;
				if (this.root)
				{
					if (this.parent && this.parent != this.root)
					{
						quaternion = global::UnityEngine.Quaternion.Inverse(this.root.rotation) * (base.rotate * this.parent.rotation);
					}
					else
					{
						quaternion = base.rotate;
					}
				}
				else if (this.parent)
				{
					quaternion = base.rotate * this.parent.rotation;
				}
				else
				{
					quaternion = base.rotate;
				}
				if (this.eye)
				{
					return this.eye.rotation * quaternion;
				}
				return quaternion;
			}
		}

		// Token: 0x1700087D RID: 2173
		// (get) Token: 0x06002631 RID: 9777 RVA: 0x00092B2C File Offset: 0x00090D2C
		public new global::UnityEngine.Transform attachParent
		{
			get
			{
				if (this.proxy)
				{
					return this.proxyTransform;
				}
				return this.eye;
			}
		}

		// Token: 0x1700087E RID: 2174
		// (get) Token: 0x06002632 RID: 9778 RVA: 0x00092B48 File Offset: 0x00090D48
		public global::UnityEngine.Vector3 preEyePosition
		{
			get
			{
				return (!this.parent) ? this.offset : this.parent.TransformPoint(this.offset);
			}
		}

		// Token: 0x1700087F RID: 2175
		// (get) Token: 0x06002633 RID: 9779 RVA: 0x00092B84 File Offset: 0x00090D84
		public global::UnityEngine.Quaternion preEyeRotation
		{
			get
			{
				return (!this.parent) ? base.rotate : (this.parent.rotation * base.rotate);
			}
		}

		// Token: 0x06002634 RID: 9780 RVA: 0x00092BC4 File Offset: 0x00090DC4
		public new void Rotate(global::UnityEngine.Quaternion rotation)
		{
			float num;
			global::UnityEngine.Vector3 vector;
			rotation.ToAngleAxis(ref num, ref vector);
			vector = this.parent.TransformDirection(vector);
			this.parent.RotateAround(this.preEyePosition, vector, num);
		}

		// Token: 0x06002635 RID: 9781 RVA: 0x00092BFC File Offset: 0x00090DFC
		public new void UnRotate(global::UnityEngine.Quaternion rotation)
		{
			float num;
			global::UnityEngine.Vector3 vector;
			rotation.ToAngleAxis(ref num, ref vector);
			vector = this.parent.TransformDirection(vector);
			this.parent.RotateAround(this.preEyePosition, -vector, num);
		}

		// Token: 0x06002636 RID: 9782 RVA: 0x00092C3C File Offset: 0x00090E3C
		public new bool AddChild(global::UnityEngine.Transform transform, bool snap)
		{
			if (this.proxy && this.proxyTransform)
			{
				if (snap)
				{
					transform.parent = this.proxyTransform;
					transform.localPosition = this.offset;
					transform.localEulerAngles = this.eulerRotate;
				}
				else
				{
					global::UnityEngine.Vector3 vector = transform.position;
					global::UnityEngine.Vector3 vector2 = transform.forward;
					global::UnityEngine.Vector3 vector3 = transform.up;
					if (this.eye)
					{
						vector = this.eye.InverseTransformPoint(vector);
						vector3 = this.eye.InverseTransformDirection(vector3);
						vector2 = this.eye.InverseTransformDirection(vector2);
					}
					if (this.root)
					{
						vector = this.root.TransformPoint(vector);
						vector3 = this.root.TransformDirection(vector3);
						vector2 = this.root.TransformDirection(vector2);
					}
					if (this.parent)
					{
						vector = this.parent.InverseTransformPoint(vector);
						vector3 = this.parent.InverseTransformDirection(vector3);
						vector2 = this.parent.InverseTransformDirection(vector2);
					}
					transform.parent = this.proxyTransform;
					transform.localPosition = vector;
					transform.localRotation = global::UnityEngine.Quaternion.LookRotation(vector2, vector3);
				}
				return true;
			}
			return false;
		}

		// Token: 0x06002637 RID: 9783 RVA: 0x00092D70 File Offset: 0x00090F70
		public new bool AddChildWithCoords(global::UnityEngine.Transform transform, global::UnityEngine.Vector3 offsetFromThisSocket)
		{
			if (this.AddChild(transform, false))
			{
				transform.localPosition = this.offset + base.rotate * offsetFromThisSocket;
				return true;
			}
			return false;
		}

		// Token: 0x06002638 RID: 9784 RVA: 0x00092DAC File Offset: 0x00090FAC
		public new bool AddChildWithCoords(global::UnityEngine.Transform transform, global::UnityEngine.Vector3 offsetFromThisSocket, global::UnityEngine.Vector3 eulerOffsetFromThisSocket)
		{
			if (this.AddChild(transform, false))
			{
				global::UnityEngine.Quaternion rotate = base.rotate;
				transform.localPosition = this.offset + rotate * offsetFromThisSocket;
				transform.localRotation = rotate * global::UnityEngine.Quaternion.Euler(eulerOffsetFromThisSocket);
				return true;
			}
			return false;
		}

		// Token: 0x06002639 RID: 9785 RVA: 0x00092DFC File Offset: 0x00090FFC
		public new bool AddChildWithCoords(global::UnityEngine.Transform transform, global::UnityEngine.Vector3 offsetFromThisSocket, global::UnityEngine.Quaternion rotationOffsetFromThisSocket)
		{
			if (this.AddChild(transform, false))
			{
				global::UnityEngine.Quaternion rotate = base.rotate;
				transform.localPosition = this.offset + rotate * offsetFromThisSocket;
				transform.localRotation = rotate * rotationOffsetFromThisSocket;
				return true;
			}
			return false;
		}

		// Token: 0x0600263A RID: 9786 RVA: 0x00092E48 File Offset: 0x00091048
		public new void Snap()
		{
			if (this.proxy && this.proxyTransform && this.root && this.eye)
			{
				global::Socket.CameraSpace.UpdateProxy(this.parent, this.proxyTransform, this.root, this.eye);
			}
		}

		// Token: 0x04001373 RID: 4979
		[global::System.NonSerialized]
		public global::UnityEngine.Transform eye;

		// Token: 0x04001374 RID: 4980
		[global::System.NonSerialized]
		public global::UnityEngine.Transform root;

		// Token: 0x04001375 RID: 4981
		public bool proxy;

		// Token: 0x04001376 RID: 4982
		[global::System.NonSerialized]
		internal global::UnityEngine.Transform proxyTransform;
	}

	// Token: 0x0200044E RID: 1102
	[global::System.Serializable]
	public sealed class ConfigBodyPart
	{
		// Token: 0x0600263B RID: 9787 RVA: 0x00092EB0 File Offset: 0x000910B0
		public ConfigBodyPart()
		{
		}

		// Token: 0x0600263C RID: 9788 RVA: 0x00092EB8 File Offset: 0x000910B8
		public static global::Socket.ConfigBodyPart Create(global::BodyPart parent, global::UnityEngine.Vector3 offset, global::UnityEngine.Vector3 eulerRotate)
		{
			return new global::Socket.ConfigBodyPart
			{
				parent = parent,
				offset = offset,
				eulerRotate = eulerRotate
			};
		}

		// Token: 0x0600263D RID: 9789 RVA: 0x00092EE4 File Offset: 0x000910E4
		private bool Find(global::HitBoxSystem system, out global::UnityEngine.Transform parent)
		{
			if (!system)
			{
				parent = null;
				return false;
			}
			global::IDRemoteBodyPart idremoteBodyPart;
			if (!system.bodyParts.TryGetValue(this.parent, ref idremoteBodyPart))
			{
				parent = null;
				return false;
			}
			parent = idremoteBodyPart.transform;
			return true;
		}

		// Token: 0x0600263E RID: 9790 RVA: 0x00092F28 File Offset: 0x00091128
		public bool Extract(ref global::Socket.LocalSpace space, global::HitBoxSystem system)
		{
			global::UnityEngine.Transform transform;
			if (this.Find(system, out transform))
			{
				if (space == null)
				{
					space = new global::Socket.LocalSpace
					{
						parent = transform,
						eulerRotate = this.eulerRotate,
						offset = this.offset
					};
				}
				else if (space.parent != transform)
				{
					space.parent = transform;
					space.eulerRotate = this.eulerRotate;
					space.offset = this.offset;
				}
				return true;
			}
			return false;
		}

		// Token: 0x0600263F RID: 9791 RVA: 0x00092FB0 File Offset: 0x000911B0
		public bool Extract(ref global::Socket.CameraSpace space, global::HitBoxSystem system)
		{
			global::UnityEngine.Transform transform;
			if (this.Find(system, out transform))
			{
				if (space == null)
				{
					space = new global::Socket.CameraSpace
					{
						parent = transform,
						eulerRotate = this.eulerRotate,
						offset = this.offset
					};
				}
				else if (space.parent != transform)
				{
					space.parent = transform;
					space.eulerRotate = this.eulerRotate;
					space.offset = this.offset;
				}
				return true;
			}
			return false;
		}

		// Token: 0x04001377 RID: 4983
		public global::BodyPart parent;

		// Token: 0x04001378 RID: 4984
		public global::UnityEngine.Vector3 offset;

		// Token: 0x04001379 RID: 4985
		public global::UnityEngine.Vector3 eulerRotate;
	}

	// Token: 0x0200044F RID: 1103
	[global::System.Serializable]
	public sealed class LocalSpace : global::Socket
	{
		// Token: 0x06002640 RID: 9792 RVA: 0x00093038 File Offset: 0x00091238
		public LocalSpace() : base(false)
		{
		}

		// Token: 0x17000880 RID: 2176
		// (get) Token: 0x06002641 RID: 9793 RVA: 0x00093044 File Offset: 0x00091244
		public new global::UnityEngine.Vector3 position
		{
			get
			{
				return (!this.parent) ? this.offset : this.parent.TransformPoint(this.offset);
			}
		}

		// Token: 0x17000881 RID: 2177
		// (get) Token: 0x06002642 RID: 9794 RVA: 0x00093080 File Offset: 0x00091280
		public new global::UnityEngine.Quaternion rotation
		{
			get
			{
				return (!this.parent) ? base.rotate : (this.parent.rotation * base.rotate);
			}
		}

		// Token: 0x06002643 RID: 9795 RVA: 0x000930C0 File Offset: 0x000912C0
		public new void Rotate(global::UnityEngine.Quaternion rotation)
		{
			float num;
			global::UnityEngine.Vector3 vector;
			rotation.ToAngleAxis(ref num, ref vector);
			vector = this.parent.TransformDirection(vector);
			this.parent.RotateAround(this.position, vector, num);
		}

		// Token: 0x06002644 RID: 9796 RVA: 0x000930F8 File Offset: 0x000912F8
		public new void UnRotate(global::UnityEngine.Quaternion rotation)
		{
			float num;
			global::UnityEngine.Vector3 vector;
			rotation.ToAngleAxis(ref num, ref vector);
			vector = this.parent.TransformDirection(vector);
			this.parent.RotateAround(this.position, -vector, num);
		}

		// Token: 0x06002645 RID: 9797 RVA: 0x00093138 File Offset: 0x00091338
		public new bool AddChild(global::UnityEngine.Transform transform, bool snap)
		{
			if (transform)
			{
				transform.parent = this.parent;
				if (snap)
				{
					transform.localPosition = this.offset;
					transform.localEulerAngles = this.eulerRotate;
				}
				return true;
			}
			return false;
		}

		// Token: 0x06002646 RID: 9798 RVA: 0x00093180 File Offset: 0x00091380
		public new bool AddChildWithCoords(global::UnityEngine.Transform transform, global::UnityEngine.Vector3 offsetFromThisSocket)
		{
			if (this.AddChild(transform, false))
			{
				transform.localPosition = this.offset + base.rotate * offsetFromThisSocket;
				return true;
			}
			return false;
		}

		// Token: 0x06002647 RID: 9799 RVA: 0x000931BC File Offset: 0x000913BC
		public new bool AddChildWithCoords(global::UnityEngine.Transform transform, global::UnityEngine.Vector3 offsetFromThisSocket, global::UnityEngine.Vector3 eulerOffsetFromThisSocket)
		{
			if (this.AddChild(transform, false))
			{
				global::UnityEngine.Quaternion rotate = base.rotate;
				transform.localPosition = this.offset + rotate * offsetFromThisSocket;
				transform.localRotation = rotate * global::UnityEngine.Quaternion.Euler(eulerOffsetFromThisSocket);
				return true;
			}
			return false;
		}

		// Token: 0x06002648 RID: 9800 RVA: 0x0009320C File Offset: 0x0009140C
		public new bool AddChildWithCoords(global::UnityEngine.Transform transform, global::UnityEngine.Vector3 offsetFromThisSocket, global::UnityEngine.Quaternion rotationOffsetFromThisSocket)
		{
			if (this.AddChild(transform, false))
			{
				global::UnityEngine.Quaternion rotate = base.rotate;
				transform.localPosition = this.offset + rotate * offsetFromThisSocket;
				transform.localRotation = rotate * rotationOffsetFromThisSocket;
				return true;
			}
			return false;
		}

		// Token: 0x06002649 RID: 9801 RVA: 0x00093258 File Offset: 0x00091458
		public new void Snap()
		{
		}
	}

	// Token: 0x02000450 RID: 1104
	public interface Source
	{
		// Token: 0x0600264A RID: 9802
		bool GetSocket(string name, out global::Socket socket);

		// Token: 0x0600264B RID: 9803
		bool ReplaceSocket(string name, global::Socket newValue);

		// Token: 0x17000882 RID: 2178
		// (get) Token: 0x0600264C RID: 9804
		global::System.Collections.Generic.IEnumerable<string> SocketNames { get; }

		// Token: 0x17000883 RID: 2179
		// (get) Token: 0x0600264D RID: 9805
		int SocketsVersion { get; }

		// Token: 0x0600264E RID: 9806
		global::Socket.CameraConversion CameraSpaceSetup();

		// Token: 0x0600264F RID: 9807
		global::System.Type ProxyScriptType(string name);
	}

	// Token: 0x02000451 RID: 1105
	public interface Mapped
	{
		// Token: 0x17000884 RID: 2180
		// (get) Token: 0x06002650 RID: 9808
		global::Socket.Map socketMap { get; }
	}

	// Token: 0x02000452 RID: 1106
	public interface Provider : global::Socket.Source, global::Socket.Mapped
	{
	}

	// Token: 0x02000453 RID: 1107
	public abstract class Proxy : global::UnityEngine.MonoBehaviour, global::Socket.Mapped
	{
		// Token: 0x06002651 RID: 9809 RVA: 0x0009325C File Offset: 0x0009145C
		public Proxy()
		{
			this.link = global::Socket.ProxyLink.Pop();
			this.link.proxy = this;
		}

		// Token: 0x17000885 RID: 2181
		// (get) Token: 0x06002652 RID: 9810 RVA: 0x0009327C File Offset: 0x0009147C
		public global::UnityEngine.Transform transform
		{
			get
			{
				return this._transform;
			}
		}

		// Token: 0x06002653 RID: 9811 RVA: 0x00093284 File Offset: 0x00091484
		public bool GetSocketMap(out global::Socket.Map map)
		{
			return this.link.map.Try(out map);
		}

		// Token: 0x17000886 RID: 2182
		// (get) Token: 0x06002654 RID: 9812 RVA: 0x00093298 File Offset: 0x00091498
		public global::Socket.Map socketMap
		{
			get
			{
				return this.link.map.Map;
			}
		}

		// Token: 0x17000887 RID: 2183
		// (get) Token: 0x06002655 RID: 9813 RVA: 0x000932AC File Offset: 0x000914AC
		public int socketIndex
		{
			get
			{
				return (!this.link.linked || !this.link.map.Exists) ? -1 : this.link.index;
			}
		}

		// Token: 0x17000888 RID: 2184
		// (get) Token: 0x06002656 RID: 9814 RVA: 0x000932F0 File Offset: 0x000914F0
		public global::Socket.CameraSpace socket
		{
			get
			{
				global::Socket.CameraSpace cameraSpace;
				return (!this.link.linked || !this.link.map.Socket<global::Socket.CameraSpace>(this.link.index, out cameraSpace)) ? null : cameraSpace;
			}
		}

		// Token: 0x17000889 RID: 2185
		// (get) Token: 0x06002657 RID: 9815 RVA: 0x00093338 File Offset: 0x00091538
		public string socketName
		{
			get
			{
				string text;
				return (!this.link.linked || !this.link.map.Name(this.link.index, out text)) ? null : text;
			}
		}

		// Token: 0x1700088A RID: 2186
		// (get) Token: 0x06002658 RID: 9816 RVA: 0x00093380 File Offset: 0x00091580
		public bool socketExists
		{
			get
			{
				return this.link.linked && this.link.map.Exists;
			}
		}

		// Token: 0x06002659 RID: 9817 RVA: 0x000933A8 File Offset: 0x000915A8
		protected virtual void InitializeProxy()
		{
		}

		// Token: 0x0600265A RID: 9818 RVA: 0x000933AC File Offset: 0x000915AC
		protected virtual void UninitializeProxy()
		{
		}

		// Token: 0x0600265B RID: 9819 RVA: 0x000933B0 File Offset: 0x000915B0
		protected void Awake()
		{
			this._transform = base.transform;
			this.link.scriptAlive = true;
			try
			{
				this.InitializeProxy();
			}
			catch (global::System.Exception ex)
			{
				global::UnityEngine.Debug.LogException(ex, this);
			}
		}

		// Token: 0x0600265C RID: 9820 RVA: 0x0009340C File Offset: 0x0009160C
		protected void OnDestroy()
		{
			if (this.link.scriptAlive)
			{
				this.link.scriptAlive = false;
				try
				{
					this.UninitializeProxy();
				}
				finally
				{
					global::Socket.Map map;
					if (this.GetSocketMap(out map))
					{
						map.OnProxyDestroyed(this.link);
					}
					this.link.proxy = null;
				}
			}
		}

		// Token: 0x0400137A RID: 4986
		[global::System.NonSerialized]
		private readonly global::Socket.ProxyLink link;

		// Token: 0x0400137B RID: 4987
		[global::System.NonSerialized]
		private global::UnityEngine.Transform _transform;
	}

	// Token: 0x02000454 RID: 1108
	internal sealed class ProxyLink
	{
		// Token: 0x0600265D RID: 9821 RVA: 0x00093484 File Offset: 0x00091684
		public ProxyLink()
		{
		}

		// Token: 0x0600265E RID: 9822 RVA: 0x00093494 File Offset: 0x00091694
		public static global::Socket.ProxyLink Pop()
		{
			return global::Socket.ProxyLink.Usage.Stack.Pop();
		}

		// Token: 0x0600265F RID: 9823 RVA: 0x000934A0 File Offset: 0x000916A0
		public static void Push(global::Socket.ProxyLink top)
		{
			global::Socket.ProxyLink.Usage.Stack.Push(top);
		}

		// Token: 0x06002660 RID: 9824 RVA: 0x000934B0 File Offset: 0x000916B0
		public static void EnsurePopped(global::Socket.ProxyLink top)
		{
			if (global::Socket.ProxyLink.Usage.Stack.Count > 0 && global::Socket.ProxyLink.Usage.Stack.Peek() == top)
			{
				global::Socket.ProxyLink.Usage.Stack.Pop();
			}
		}

		// Token: 0x0400137C RID: 4988
		[global::System.NonSerialized]
		public global::Socket.Map.Reference map;

		// Token: 0x0400137D RID: 4989
		[global::System.NonSerialized]
		public global::Socket.Proxy proxy;

		// Token: 0x0400137E RID: 4990
		[global::System.NonSerialized]
		public global::UnityEngine.GameObject gameObject;

		// Token: 0x0400137F RID: 4991
		[global::System.NonSerialized]
		public bool scriptAlive;

		// Token: 0x04001380 RID: 4992
		[global::System.NonSerialized]
		public bool linked;

		// Token: 0x04001381 RID: 4993
		[global::System.NonSerialized]
		public int index = -1;

		// Token: 0x02000455 RID: 1109
		private static class Usage
		{
			// Token: 0x06002661 RID: 9825 RVA: 0x000934E0 File Offset: 0x000916E0
			// Note: this type is marked as 'beforefieldinit'.
			static Usage()
			{
			}

			// Token: 0x04001382 RID: 4994
			public static readonly global::System.Collections.Generic.Stack<global::Socket.ProxyLink> Stack = new global::System.Collections.Generic.Stack<global::Socket.ProxyLink>();
		}
	}

	// Token: 0x02000456 RID: 1110
	public struct Slot
	{
		// Token: 0x06002662 RID: 9826 RVA: 0x000934EC File Offset: 0x000916EC
		internal Slot(global::Socket.Map.Reference map, int index)
		{
			this.m = map;
			this.index = index;
		}

		// Token: 0x1700088B RID: 2187
		// (get) Token: 0x06002663 RID: 9827 RVA: 0x000934FC File Offset: 0x000916FC
		// (set) Token: 0x06002664 RID: 9828 RVA: 0x00093510 File Offset: 0x00091710
		public global::Socket socket
		{
			get
			{
				return this.m.Socket(this.index);
			}
			set
			{
				if (!this.ReplaceSocket(value))
				{
					throw new global::System.InvalidOperationException("could not replace socket");
				}
			}
		}

		// Token: 0x1700088C RID: 2188
		// (get) Token: 0x06002665 RID: 9829 RVA: 0x0009352C File Offset: 0x0009172C
		public global::UnityEngine.Transform proxy
		{
			get
			{
				global::Socket.ProxyLink proxyLink;
				return (!this.m.Proxy(this.index, out proxyLink) || !proxyLink.proxy) ? null : proxyLink.proxy.transform;
			}
		}

		// Token: 0x1700088D RID: 2189
		// (get) Token: 0x06002666 RID: 9830 RVA: 0x00093574 File Offset: 0x00091774
		public string name
		{
			get
			{
				return this.m.Name(this.index);
			}
		}

		// Token: 0x06002667 RID: 9831 RVA: 0x00093588 File Offset: 0x00091788
		public bool BelongsTo(global::Socket.Map map)
		{
			return this.m.Is(map);
		}

		// Token: 0x06002668 RID: 9832 RVA: 0x00093598 File Offset: 0x00091798
		public bool ReplaceSocket(global::Socket newSocketValue)
		{
			global::Socket.Map map;
			return this.m.Try(out map) && map.ReplaceSocket(this.index, newSocketValue);
		}

		// Token: 0x04001383 RID: 4995
		private global::Socket.Map.Reference m;

		// Token: 0x04001384 RID: 4996
		public readonly int index;
	}

	// Token: 0x02000457 RID: 1111
	public sealed class Map : global::Socket.Mapped
	{
		// Token: 0x06002669 RID: 9833 RVA: 0x000935C8 File Offset: 0x000917C8
		private Map(global::Socket.Source source, global::UnityEngine.Object script)
		{
			this.source = source;
			this.script = script;
		}

		// Token: 0x1700088E RID: 2190
		// (get) Token: 0x0600266A RID: 9834 RVA: 0x000935E0 File Offset: 0x000917E0
		global::Socket.Map global::Socket.Mapped.socketMap
		{
			get
			{
				return this.EnsureMap();
			}
		}

		// Token: 0x1700088F RID: 2191
		// (get) Token: 0x0600266B RID: 9835 RVA: 0x000935E8 File Offset: 0x000917E8
		public int socketCount
		{
			get
			{
				return (!this.EnsureState()) ? 0 : this.array.Length;
			}
		}

		// Token: 0x17000890 RID: 2192
		public global::Socket.Slot this[int index]
		{
			get
			{
				if (index < 0 || !this.EnsureState() || index >= this.array.Length)
				{
					throw new global::System.IndexOutOfRangeException();
				}
				return new global::Socket.Slot(this, index);
			}
		}

		// Token: 0x17000891 RID: 2193
		public global::Socket.Slot this[string name]
		{
			get
			{
				if (!this.EnsureState())
				{
					throw new global::System.Collections.Generic.KeyNotFoundException(name);
				}
				return new global::Socket.Slot(this, this.dict[name]);
			}
		}

		// Token: 0x17000892 RID: 2194
		// (get) Token: 0x0600266E RID: 9838 RVA: 0x00093670 File Offset: 0x00091870
		public global::Socket.CameraConversion cameraConversion
		{
			get
			{
				global::Socket.CameraConversion result;
				this.GetCameraSpace(out result);
				return result;
			}
		}

		// Token: 0x0600266F RID: 9839 RVA: 0x00093688 File Offset: 0x00091888
		public bool ReplaceSocket(string name, global::Socket value)
		{
			int index;
			return this.EnsureState() && this.dict.TryGetValue(name, out index) && this.ValidSlotReplace(index, value);
		}

		// Token: 0x06002670 RID: 9840 RVA: 0x000936C0 File Offset: 0x000918C0
		public bool ReplaceSocket(int index, global::Socket value)
		{
			return index >= 0 && (this.EnsureState() && index < this.array.Length) && this.ValidSlotReplace(index, value);
		}

		// Token: 0x06002671 RID: 9841 RVA: 0x000936F0 File Offset: 0x000918F0
		public bool ReplaceSocket(global::Socket.Slot slot, global::Socket value)
		{
			return slot.index >= 0 && (slot.BelongsTo(this) && slot.index < this.array.Length) && this.ValidSlotReplace(slot.index, value);
		}

		// Token: 0x06002672 RID: 9842 RVA: 0x00093740 File Offset: 0x00091940
		public void SnapProxies()
		{
			if (this.EnsureState())
			{
				global::Socket.CameraConversion cameraConversion;
				bool flag = this.GetCameraSpace(out cameraConversion);
				for (int i = 0; i < this.array.Length; i++)
				{
					if (this.array[i].madeLink && this.array[i].link.scriptAlive && this.array[i].link.linked)
					{
						try
						{
							global::Socket.CameraSpace cameraSpace = (global::Socket.CameraSpace)this.array[i].socket;
							cameraSpace.proxyTransform = this.array[i].link.proxy.transform;
							cameraSpace.eye = cameraConversion.Eye;
							cameraSpace.root = cameraConversion.Shelf;
							if (flag)
							{
								cameraSpace.Snap();
							}
						}
						catch (global::System.Exception ex)
						{
							global::UnityEngine.Debug.LogException(ex, this.array[i].link.proxy);
						}
					}
				}
			}
		}

		// Token: 0x06002673 RID: 9843 RVA: 0x0009386C File Offset: 0x00091A6C
		private static bool Of(ref global::Socket.Map member, out global::Socket.Map value)
		{
			if (object.ReferenceEquals(member, null))
			{
				value = null;
				return false;
			}
			global::Socket.Map map = member.EnsureMap();
			member = map;
			value = map;
			return !object.ReferenceEquals(map, null);
		}

		// Token: 0x06002674 RID: 9844 RVA: 0x000938A4 File Offset: 0x00091AA4
		internal static global::Socket.Map Of(ref global::Socket.Map member)
		{
			global::Socket.Map result;
			global::Socket.Map.Of(ref member, out result);
			return result;
		}

		// Token: 0x06002675 RID: 9845 RVA: 0x000938BC File Offset: 0x00091ABC
		private static global::Socket.Map Get<TSource>(TSource source, ref global::Socket.Map member) where TSource : global::UnityEngine.Object, global::Socket.Source
		{
			if (object.ReferenceEquals(source, null))
			{
				throw new global::System.ArgumentNullException("source");
			}
			if (!source)
			{
				return global::Socket.Map.NullMap;
			}
			global::Socket.Map map = member;
			if (object.ReferenceEquals(map, null))
			{
				map = new global::Socket.Map(source, source);
			}
			global::Socket.Map result;
			member = (result = map.EnsureMap());
			return result;
		}

		// Token: 0x06002676 RID: 9846 RVA: 0x00093928 File Offset: 0x00091B28
		private void CleanTransforms()
		{
			this.checkTransforms = true;
			this.cameraSpace = global::Socket.CameraConversion.None;
		}

		// Token: 0x06002677 RID: 9847 RVA: 0x0009393C File Offset: 0x00091B3C
		private global::Socket.Map EnsureMap()
		{
			return (!this.EnsureState()) ? global::Socket.Map.NullMap : this;
		}

		// Token: 0x06002678 RID: 9848 RVA: 0x00093954 File Offset: 0x00091B54
		private bool EnsureState()
		{
			if (!this.script || this.deleted)
			{
				return false;
			}
			if (this.securing)
			{
				return true;
			}
			try
			{
				this.securing = true;
				this.SecureState();
			}
			finally
			{
				this.securing = false;
			}
			return true;
		}

		// Token: 0x17000893 RID: 2195
		// (get) Token: 0x06002679 RID: 9849 RVA: 0x000939C4 File Offset: 0x00091BC4
		private static global::Socket.Map NullMap
		{
			get
			{
				return null;
			}
		}

		// Token: 0x0600267A RID: 9850 RVA: 0x000939C8 File Offset: 0x00091BC8
		private global::Socket.Map.Result SecureState()
		{
			global::Socket.Map.Result result = this.PollState();
			switch (result)
			{
			case global::Socket.Map.Result.Initialized:
				this.initialized = true;
				this.CleanTransforms();
				break;
			case global::Socket.Map.Result.Version:
				this.CleanTransforms();
				break;
			case global::Socket.Map.Result.Forced:
				break;
			default:
				return result;
			}
			this.OnState(result);
			return result;
		}

		// Token: 0x0600267B RID: 9851 RVA: 0x00093A24 File Offset: 0x00091C24
		private global::Socket.Map.Result PollState()
		{
			if (!this.initialized)
			{
				this.Initialize();
				return global::Socket.Map.Result.Initialized;
			}
			int socketsVersion = this.source.SocketsVersion;
			global::Socket.Map.Result result;
			if (this.version != socketsVersion)
			{
				this.version = socketsVersion;
				result = global::Socket.Map.Result.Version;
			}
			else
			{
				if (!this.forceUpdate)
				{
					return global::Socket.Map.Result.Nothing;
				}
				result = global::Socket.Map.Result.Forced;
			}
			this.forceUpdate = false;
			this.Update(result);
			return result;
		}

		// Token: 0x0600267C RID: 9852 RVA: 0x00093A90 File Offset: 0x00091C90
		private void Initialize()
		{
			global::System.Collections.Generic.IEnumerable<string> socketNames = this.source.SocketNames;
			global::System.Collections.Generic.ICollection<string> collection;
			if (object.ReferenceEquals(socketNames, null))
			{
				collection = new string[0];
			}
			else
			{
				collection = (socketNames as global::System.Collections.Generic.ICollection<string>);
				if (collection == null)
				{
					collection = new global::System.Collections.Generic.HashSet<string>(socketNames, global::System.StringComparer.InvariantCultureIgnoreCase);
				}
			}
			int count = collection.Count;
			this.array = new global::Socket.Map.Element[count];
			this.dict = new global::System.Collections.Generic.Dictionary<string, int>(count, global::System.StringComparer.InvariantCultureIgnoreCase);
			int num = 0;
			foreach (string text in collection)
			{
				if (this.source.GetSocket(text, out this.array[num].socket))
				{
					try
					{
						this.dict.Add(this.array[num].name = text, num);
					}
					catch (global::System.ArgumentException ex)
					{
						global::UnityEngine.Debug.LogException(ex, this.script);
						global::UnityEngine.Debug.Log(text);
						continue;
					}
					num++;
				}
			}
			global::System.Array.Resize<global::Socket.Map.Element>(ref this.array, num);
			this.version = this.source.SocketsVersion;
		}

		// Token: 0x0600267D RID: 9853 RVA: 0x00093BF8 File Offset: 0x00091DF8
		private void ElementUpdate(int srcIndex, ref global::Socket.Map.Element src, int dstIndex, ref global::Socket.Map.Element dst, global::Socket newSocket)
		{
			if (srcIndex != dstIndex)
			{
				dst.name = src.name;
				dst.link = src.link;
				dst.socket = src.socket;
				dst.madeLink = src.madeLink;
				if (dst.madeLink)
				{
					dst.link.index = dstIndex;
				}
				this.dict[dst.name] = dstIndex;
			}
			this.SocketUpdate(ref dst.socket, newSocket);
		}

		// Token: 0x0600267E RID: 9854 RVA: 0x00093C7C File Offset: 0x00091E7C
		private void SocketUpdate(ref global::Socket socket, global::Socket newSocket)
		{
			global::Socket socket2 = socket;
			if (!object.ReferenceEquals(socket2, newSocket))
			{
				socket = newSocket;
				if (socket2 is global::Socket.CameraSpace && newSocket is global::Socket.CameraSpace)
				{
					global::Socket.CameraSpace cameraSpace = (global::Socket.CameraSpace)socket2;
					global::Socket.CameraSpace cameraSpace2 = (global::Socket.CameraSpace)newSocket;
					cameraSpace2.root = cameraSpace.root;
					cameraSpace2.eye = cameraSpace.eye;
					cameraSpace2.proxyTransform = cameraSpace.proxyTransform;
				}
			}
		}

		// Token: 0x0600267F RID: 9855 RVA: 0x00093CE4 File Offset: 0x00091EE4
		private void ElementRemove(ref global::Socket.Map.Element element, ref global::Socket.Map.RemoveList<global::Socket.ProxyLink> removeList)
		{
			if (element.madeLink)
			{
				if (element.link.scriptAlive)
				{
					removeList.Add(element.link);
				}
				element.link = null;
				element.madeLink = false;
			}
			this.dict.Remove(element.name);
		}

		// Token: 0x06002680 RID: 9856 RVA: 0x00093D38 File Offset: 0x00091F38
		private void Update(global::Socket.Map.Result Because)
		{
			if (Because == global::Socket.Map.Result.Version)
			{
				this.CleanTransforms();
			}
			int newSize = 0;
			global::Socket.Map.RemoveList<global::Socket.ProxyLink> removeList = default(global::Socket.Map.RemoveList<global::Socket.ProxyLink>);
			for (int i = 0; i < this.array.Length; i++)
			{
				global::Socket newSocket;
				if (this.source.GetSocket(this.array[i].name, out newSocket))
				{
					int num = newSize++;
					this.ElementUpdate(i, ref this.array[i], num, ref this.array[num], newSocket);
				}
				else
				{
					this.ElementRemove(ref this.array[i], ref removeList);
				}
			}
			global::System.Array.Resize<global::Socket.Map.Element>(ref this.array, newSize);
		}

		// Token: 0x06002681 RID: 9857 RVA: 0x00093DEC File Offset: 0x00091FEC
		private void OnState(global::Socket.Map.Result State)
		{
			bool flag = false;
			global::Socket.CameraConversion cameraConversion = default(global::Socket.CameraConversion);
			for (int i = 0; i < this.array.Length; i++)
			{
				global::Socket.Map.ProxyCheck proxyCheck;
				this.CheckProxyIndex(i, out proxyCheck);
				if (proxyCheck.isCameraSpace)
				{
					if (!flag)
					{
						bool flag2 = this.GetCameraSpace(out cameraConversion);
						flag = true;
					}
					proxyCheck.cameraSpace.eye = cameraConversion.Eye;
					proxyCheck.cameraSpace.root = cameraConversion.Shelf;
					proxyCheck.cameraSpace.proxyTransform = proxyCheck.proxyTransform;
				}
			}
		}

		// Token: 0x06002682 RID: 9858 RVA: 0x00093E88 File Offset: 0x00092088
		private bool ValidSlotReplace(int index, global::Socket value)
		{
			global::Socket socket = this.array[index].socket;
			if (object.ReferenceEquals(value, socket))
			{
				return true;
			}
			if ((!object.ReferenceEquals(value, null) && value.GetType() != socket.GetType()) || !this.source.ReplaceSocket(this.array[index].name, value))
			{
				return false;
			}
			this.forceUpdate = true;
			return this.EnsureState();
		}

		// Token: 0x06002683 RID: 9859 RVA: 0x00093F04 File Offset: 0x00092104
		private bool GetCameraSpace(out global::Socket.CameraConversion cameraSpace)
		{
			if (!this.EnsureState())
			{
				this.checkTransforms = false;
				this.cameraSpace = global::Socket.CameraConversion.None;
			}
			else if (this.checkTransforms)
			{
				this.checkTransforms = false;
				this.cameraSpace = this.source.CameraSpaceSetup();
			}
			cameraSpace = this.cameraSpace;
			return cameraSpace.Valid;
		}

		// Token: 0x06002684 RID: 9860 RVA: 0x00093F68 File Offset: 0x00092168
		private void DestroyProxyLink(global::Socket.ProxyLink link)
		{
			if (link.linked)
			{
				link.linked = false;
				if (link.scriptAlive && link.proxy)
				{
					global::UnityEngine.Object.Destroy(link.proxy);
				}
				link.proxy = null;
				if (link.gameObject)
				{
					global::UnityEngine.Object.Destroy(link.gameObject);
				}
				link.gameObject = null;
				link.proxy = null;
			}
		}

		// Token: 0x06002685 RID: 9861 RVA: 0x00093FE0 File Offset: 0x000921E0
		internal void OnProxyDestroyed(object link)
		{
			this.DestroyProxyLink((global::Socket.ProxyLink)link);
		}

		// Token: 0x06002686 RID: 9862 RVA: 0x00093FF0 File Offset: 0x000921F0
		private global::Socket.ProxyLink MakeProxy(global::Socket.CameraSpace socket, int index)
		{
			global::System.Type type = this.source.ProxyScriptType(this.array[index].name);
			if (object.ReferenceEquals(type, null))
			{
				return null;
			}
			if (!typeof(global::Socket.Proxy).IsAssignableFrom(type))
			{
				throw new global::System.InvalidProgramException("SocketSource returned a type that did not extend SocketMap.Proxy");
			}
			global::Socket.ProxyLink proxyLink = new global::Socket.ProxyLink();
			proxyLink.map = this;
			proxyLink.index = index;
			global::Socket.ProxyLink.Push(proxyLink);
			global::UnityEngine.Vector3 position = global::UnityEngine.Vector3.zero;
			global::UnityEngine.Quaternion rotation = global::UnityEngine.Quaternion.identity;
			global::Socket.CameraConversion cameraConversion;
			if (this.GetCameraSpace(out cameraConversion))
			{
				socket.root = cameraConversion.Shelf;
				socket.eye = cameraConversion.Eye;
			}
			else
			{
				socket.eye = null;
				socket.root = null;
			}
			try
			{
				position = socket.position;
				rotation = socket.rotation;
			}
			catch (global::System.Exception ex)
			{
				global::UnityEngine.Debug.LogException(ex, this.script);
			}
			try
			{
				proxyLink.gameObject = new global::UnityEngine.GameObject(this.array[index].name, new global::System.Type[]
				{
					type
				})
				{
					transform = 
					{
						position = position,
						rotation = rotation
					}
				};
			}
			catch
			{
				proxyLink.linked = false;
				if (proxyLink.gameObject)
				{
					global::UnityEngine.Object.Destroy(proxyLink.gameObject);
				}
				throw;
			}
			finally
			{
				global::Socket.ProxyLink.EnsurePopped(proxyLink);
			}
			proxyLink.linked = true;
			socket.proxyTransform = proxyLink.proxy.transform;
			return proxyLink;
		}

		// Token: 0x06002687 RID: 9863 RVA: 0x000941B4 File Offset: 0x000923B4
		private void CheckProxyIndex(int index, out global::Socket.Map.ProxyCheck o)
		{
			if (o.isProxy = ((o.isCameraSpace = !object.ReferenceEquals(o.cameraSpace = (this.array[index].socket as global::Socket.CameraSpace), null)) && o.cameraSpace.proxy))
			{
				if (!this.array[index].madeLink)
				{
					o.proxyLink = (this.array[index].link = this.MakeProxy(o.cameraSpace, index));
					this.array[index].madeLink = true;
				}
				else
				{
					o.proxyLink = this.array[index].link;
				}
				o.parentOrProxy = o.proxyLink.proxy.transform;
			}
			else
			{
				o.proxyLink = null;
				o.parentOrProxy = this.array[index].socket.parent;
			}
			o.index = index;
		}

		// Token: 0x06002688 RID: 9864 RVA: 0x000942C4 File Offset: 0x000924C4
		private void Delete()
		{
			if (!this.initialized || this.deleted)
			{
				return;
			}
			this.deleted = true;
			for (int i = this.array.Length - 1; i >= 0; i--)
			{
				if (this.array[i].madeLink)
				{
					this.DestroyProxyLink(this.array[i].link);
				}
			}
		}

		// Token: 0x04001385 RID: 4997
		[global::System.NonSerialized]
		private readonly global::UnityEngine.Object script;

		// Token: 0x04001386 RID: 4998
		[global::System.NonSerialized]
		private readonly global::Socket.Source source;

		// Token: 0x04001387 RID: 4999
		[global::System.NonSerialized]
		private global::System.Collections.Generic.Dictionary<string, int> dict;

		// Token: 0x04001388 RID: 5000
		[global::System.NonSerialized]
		private bool initialized;

		// Token: 0x04001389 RID: 5001
		[global::System.NonSerialized]
		private bool checkTransforms;

		// Token: 0x0400138A RID: 5002
		[global::System.NonSerialized]
		private bool securing;

		// Token: 0x0400138B RID: 5003
		[global::System.NonSerialized]
		private bool forceUpdate;

		// Token: 0x0400138C RID: 5004
		[global::System.NonSerialized]
		private bool deleted;

		// Token: 0x0400138D RID: 5005
		[global::System.NonSerialized]
		private global::Socket.Map.Element[] array;

		// Token: 0x0400138E RID: 5006
		[global::System.NonSerialized]
		private int version;

		// Token: 0x0400138F RID: 5007
		[global::System.NonSerialized]
		private global::Socket.CameraConversion cameraSpace;

		// Token: 0x02000458 RID: 1112
		public struct Member
		{
			// Token: 0x06002689 RID: 9865 RVA: 0x00094338 File Offset: 0x00092538
			public global::Socket.Map Get<T>(T outerInstance) where T : global::UnityEngine.Object, global::Socket.Source
			{
				if (this.deleted)
				{
					return null;
				}
				return global::Socket.Map.Get<T>(outerInstance, ref this.reference);
			}

			// Token: 0x0600268A RID: 9866 RVA: 0x00094354 File Offset: 0x00092554
			public bool Get<T>(T outerInstance, out global::Socket.Map map) where T : global::UnityEngine.Object, global::Socket.Source
			{
				map = this.Get<T>(outerInstance);
				return !object.ReferenceEquals(map, null);
			}

			// Token: 0x0600268B RID: 9867 RVA: 0x0009436C File Offset: 0x0009256C
			public bool DeleteBy<T>(T outerInstance) where T : global::UnityEngine.Object, global::Socket.Source
			{
				if (!this.deleted)
				{
					if (object.ReferenceEquals(this.reference, null))
					{
						this.deleted = true;
					}
					else
					{
						if (!object.ReferenceEquals(outerInstance, this.reference.source))
						{
							throw new global::System.ArgumentException("instance did not match that of which created the map", "outerInstance");
						}
						this.deleted = true;
						try
						{
							this.reference.Delete();
						}
						catch (global::System.Exception ex)
						{
							global::UnityEngine.Debug.LogException(ex, outerInstance);
						}
						finally
						{
							this.reference = null;
						}
					}
					return true;
				}
				return false;
			}

			// Token: 0x04001390 RID: 5008
			private global::Socket.Map reference;

			// Token: 0x04001391 RID: 5009
			private bool deleted;
		}

		// Token: 0x02000459 RID: 1113
		private struct Element
		{
			// Token: 0x04001392 RID: 5010
			public global::Socket socket;

			// Token: 0x04001393 RID: 5011
			public string name;

			// Token: 0x04001394 RID: 5012
			public global::Socket.ProxyLink link;

			// Token: 0x04001395 RID: 5013
			public bool madeLink;
		}

		// Token: 0x0200045A RID: 1114
		private enum Result
		{
			// Token: 0x04001397 RID: 5015
			Nothing,
			// Token: 0x04001398 RID: 5016
			Initialized,
			// Token: 0x04001399 RID: 5017
			Version,
			// Token: 0x0400139A RID: 5018
			Forced
		}

		// Token: 0x0200045B RID: 1115
		private struct RemoveList<T>
		{
			// Token: 0x0600268C RID: 9868 RVA: 0x00094434 File Offset: 0x00092634
			public void Add(T item)
			{
				if (!this.exists)
				{
					this.list = new global::System.Collections.Generic.List<T>();
				}
				this.list.Add(item);
			}

			// Token: 0x0400139B RID: 5019
			public bool exists;

			// Token: 0x0400139C RID: 5020
			public global::System.Collections.Generic.List<T> list;
		}

		// Token: 0x0200045C RID: 1116
		private struct ProxyCheck
		{
			// Token: 0x17000894 RID: 2196
			// (get) Token: 0x0600268D RID: 9869 RVA: 0x00094464 File Offset: 0x00092664
			public global::UnityEngine.Transform proxyTransform
			{
				get
				{
					return (!this.isProxy) ? null : this.parentOrProxy;
				}
			}

			// Token: 0x17000895 RID: 2197
			// (get) Token: 0x0600268E RID: 9870 RVA: 0x00094480 File Offset: 0x00092680
			public global::UnityEngine.Transform parent
			{
				get
				{
					return (!this.isProxy) ? this.parentOrProxy : this.cameraSpace.parent;
				}
			}

			// Token: 0x0400139D RID: 5021
			public global::UnityEngine.Transform parentOrProxy;

			// Token: 0x0400139E RID: 5022
			public global::Socket.CameraSpace cameraSpace;

			// Token: 0x0400139F RID: 5023
			public global::Socket.ProxyLink proxyLink;

			// Token: 0x040013A0 RID: 5024
			public int index;

			// Token: 0x040013A1 RID: 5025
			public bool isCameraSpace;

			// Token: 0x040013A2 RID: 5026
			public bool isProxy;
		}

		// Token: 0x0200045D RID: 1117
		internal struct Reference
		{
			// Token: 0x0600268F RID: 9871 RVA: 0x000944A4 File Offset: 0x000926A4
			private Reference(global::Socket.Map reference)
			{
				this.reference = reference;
			}

			// Token: 0x06002690 RID: 9872 RVA: 0x000944B0 File Offset: 0x000926B0
			public bool Try(out global::Socket.Map map)
			{
				return global::Socket.Map.Of(ref this.reference, out map);
			}

			// Token: 0x06002691 RID: 9873 RVA: 0x000944C0 File Offset: 0x000926C0
			private bool ByIndex(int index, out global::Socket.Map map)
			{
				if (index < 0)
				{
					map = null;
				}
				else if (this.Try(out map) && index < map.array.Length)
				{
					return true;
				}
				return false;
			}

			// Token: 0x06002692 RID: 9874 RVA: 0x000944F0 File Offset: 0x000926F0
			private bool ByKey(string name, out global::Socket.Map map, out int index)
			{
				if (object.ReferenceEquals(name, null))
				{
					map = null;
				}
				else if (this.Try(out map))
				{
					return map.dict.TryGetValue(name, out index);
				}
				index = -1;
				return false;
			}

			// Token: 0x06002693 RID: 9875 RVA: 0x00094528 File Offset: 0x00092728
			private static bool Socket(bool valid, int index, global::Socket.Map map, out global::Socket socket)
			{
				if (valid)
				{
					socket = map.array[index].socket;
					return true;
				}
				socket = null;
				return false;
			}

			// Token: 0x06002694 RID: 9876 RVA: 0x0009454C File Offset: 0x0009274C
			private static bool Name(bool valid, int index, global::Socket.Map map, out string name)
			{
				if (valid)
				{
					name = map.array[index].name;
					return true;
				}
				name = null;
				return false;
			}

			// Token: 0x06002695 RID: 9877 RVA: 0x00094570 File Offset: 0x00092770
			private static bool Proxy(bool valid, int index, global::Socket.Map map, out global::Socket.ProxyLink proxyLink)
			{
				if (valid)
				{
					proxyLink = map.array[index].link;
					return map.array[index].madeLink;
				}
				proxyLink = null;
				return false;
			}

			// Token: 0x06002696 RID: 9878 RVA: 0x000945A4 File Offset: 0x000927A4
			public bool Socket(int index, out global::Socket socket)
			{
				global::Socket.Map map;
				return global::Socket.Map.Reference.Socket(this.ByIndex(index, out map), index, map, out socket);
			}

			// Token: 0x06002697 RID: 9879 RVA: 0x000945C4 File Offset: 0x000927C4
			public global::Socket Socket(int index)
			{
				global::Socket.Map map = this.Map;
				return map.array[index].socket;
			}

			// Token: 0x06002698 RID: 9880 RVA: 0x000945EC File Offset: 0x000927EC
			public bool Name(int index, out string name)
			{
				global::Socket.Map map;
				return global::Socket.Map.Reference.Name(this.ByIndex(index, out map), index, map, out name);
			}

			// Token: 0x06002699 RID: 9881 RVA: 0x0009460C File Offset: 0x0009280C
			public string Name(int index)
			{
				global::Socket.Map map = this.Map;
				return map.array[index].name;
			}

			// Token: 0x0600269A RID: 9882 RVA: 0x00094634 File Offset: 0x00092834
			public bool Proxy(int index, out global::Socket.ProxyLink link)
			{
				global::Socket.Map map;
				return global::Socket.Map.Reference.Proxy(this.ByIndex(index, out map), index, map, out link);
			}

			// Token: 0x0600269B RID: 9883 RVA: 0x00094654 File Offset: 0x00092854
			internal global::Socket.ProxyLink Proxy(int index)
			{
				global::Socket.Map map = this.Map;
				return map.array[index].link;
			}

			// Token: 0x0600269C RID: 9884 RVA: 0x0009467C File Offset: 0x0009287C
			public bool Socket(string key, out global::Socket socket)
			{
				global::Socket.Map map;
				int index;
				return global::Socket.Map.Reference.Socket(this.ByKey(key, out map, out index), index, map, out socket);
			}

			// Token: 0x0600269D RID: 9885 RVA: 0x0009469C File Offset: 0x0009289C
			public global::Socket Socket(string key)
			{
				global::Socket.Map map = this.Map;
				return map.array[map.dict[key]].socket;
			}

			// Token: 0x0600269E RID: 9886 RVA: 0x000946CC File Offset: 0x000928CC
			public bool Name(string key, out string name)
			{
				global::Socket.Map map;
				int index;
				return global::Socket.Map.Reference.Name(this.ByKey(key, out map, out index), index, map, out name);
			}

			// Token: 0x0600269F RID: 9887 RVA: 0x000946EC File Offset: 0x000928EC
			public string Name(string key)
			{
				global::Socket.Map map = this.Map;
				return map.array[map.dict[key]].name;
			}

			// Token: 0x060026A0 RID: 9888 RVA: 0x0009471C File Offset: 0x0009291C
			internal bool Proxy(string key, out global::Socket.ProxyLink link)
			{
				global::Socket.Map map;
				int index;
				return global::Socket.Map.Reference.Proxy(this.ByKey(key, out map, out index), index, map, out link);
			}

			// Token: 0x060026A1 RID: 9889 RVA: 0x0009473C File Offset: 0x0009293C
			internal global::Socket.ProxyLink Proxy(string key)
			{
				global::Socket.Map map = this.Map;
				return map.array[map.dict[key]].link;
			}

			// Token: 0x17000896 RID: 2198
			// (get) Token: 0x060026A2 RID: 9890 RVA: 0x0009476C File Offset: 0x0009296C
			public global::Socket.Map Map
			{
				get
				{
					return global::Socket.Map.Of(ref this.reference);
				}
			}

			// Token: 0x17000897 RID: 2199
			// (get) Token: 0x060026A3 RID: 9891 RVA: 0x0009477C File Offset: 0x0009297C
			public bool Exists
			{
				get
				{
					global::Socket.Map map;
					return global::Socket.Map.Of(ref this.reference, out map);
				}
			}

			// Token: 0x060026A4 RID: 9892 RVA: 0x00094798 File Offset: 0x00092998
			public bool RefEquals(global::Socket.Map map)
			{
				return object.ReferenceEquals(this.reference, map);
			}

			// Token: 0x060026A5 RID: 9893 RVA: 0x000947A8 File Offset: 0x000929A8
			public bool Is(global::Socket.Map map)
			{
				return object.ReferenceEquals(this.Map, map);
			}

			// Token: 0x060026A6 RID: 9894 RVA: 0x000947B8 File Offset: 0x000929B8
			public bool Socket<TSocket>(int index, out TSocket socket) where TSocket : global::Socket, new()
			{
				global::Socket socket2;
				bool flag = this.Socket(index, out socket2);
				socket = ((!flag) ? ((TSocket)((object)null)) : (socket2 as TSocket));
				return flag && socket2 != null;
			}

			// Token: 0x060026A7 RID: 9895 RVA: 0x00094804 File Offset: 0x00092A04
			public bool Socket<TSocket>(string name, out TSocket socket) where TSocket : global::Socket, new()
			{
				global::Socket socket2;
				bool flag = this.Socket(name, out socket2);
				socket = ((!flag) ? ((TSocket)((object)null)) : (socket2 as TSocket));
				return flag && socket2 != null;
			}

			// Token: 0x060026A8 RID: 9896 RVA: 0x00094850 File Offset: 0x00092A50
			public TSocket Socket<TSocket>(int index) where TSocket : global::Socket, new()
			{
				return (TSocket)((object)this.Socket(index));
			}

			// Token: 0x060026A9 RID: 9897 RVA: 0x00094860 File Offset: 0x00092A60
			public TSocket Socket<TSocket>(string name) where TSocket : global::Socket, new()
			{
				return (TSocket)((object)this.Socket(name));
			}

			// Token: 0x060026AA RID: 9898 RVA: 0x00094870 File Offset: 0x00092A70
			public bool SocketIndex(string name, out int index)
			{
				global::Socket.Map map;
				if (this.Try(out map))
				{
					return map.dict.TryGetValue(name, out index);
				}
				index = -1;
				return false;
			}

			// Token: 0x060026AB RID: 9899 RVA: 0x0009489C File Offset: 0x00092A9C
			public int SocketIndex(string name)
			{
				return this.Map.dict[name];
			}

			// Token: 0x060026AC RID: 9900 RVA: 0x000948B0 File Offset: 0x00092AB0
			public static implicit operator global::Socket.Map.Reference(global::Socket.Map reference)
			{
				return new global::Socket.Map.Reference(reference);
			}

			// Token: 0x040013A3 RID: 5027
			private global::Socket.Map reference;
		}
	}
}
