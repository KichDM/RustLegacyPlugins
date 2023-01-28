using System;
using System.Runtime.InteropServices;
using Facepunch;
using uLink;
using UnityEngine;

// Token: 0x02000417 RID: 1047
[global::System.Runtime.InteropServices.StructLayout(global::System.Runtime.InteropServices.LayoutKind.Explicit, Size = 4)]
public struct NetEntityID : global::System.IEquatable<global::uLink.NetworkViewID>, global::System.IEquatable<global::NetEntityID>, global::System.IComparable<global::uLink.NetworkViewID>, global::System.IComparable<global::NetEntityID>
{
	// Token: 0x0600242D RID: 9261 RVA: 0x0008A3C0 File Offset: 0x000885C0
	public NetEntityID(global::NGCView view)
	{
		this = default(global::NetEntityID);
		if (view)
		{
			this.v = view.id;
		}
	}

	// Token: 0x0600242E RID: 9262 RVA: 0x0008A3F4 File Offset: 0x000885F4
	public NetEntityID(global::uLink.NetworkView view)
	{
		this = default(global::NetEntityID);
		if (view)
		{
			this._viewID = view.viewID;
		}
	}

	// Token: 0x0600242F RID: 9263 RVA: 0x0008A428 File Offset: 0x00088628
	public NetEntityID(global::uLink.NetworkViewID viewID)
	{
		this = default(global::NetEntityID);
		this._viewID = viewID;
	}

	// Token: 0x06002430 RID: 9264 RVA: 0x0008A44C File Offset: 0x0008864C
	static NetEntityID()
	{
		global::uLink.BitStreamCodec.AddAndMakeArray<global::NetEntityID>(global::NetEntityID.deserializer, global::NetEntityID.serializer);
	}

	// Token: 0x17000824 RID: 2084
	// (get) Token: 0x06002431 RID: 9265 RVA: 0x0008A480 File Offset: 0x00088680
	public bool isNet
	{
		get
		{
			return this.p1 == 0 && this._viewID != global::uLink.NetworkViewID.unassigned;
		}
	}

	// Token: 0x17000825 RID: 2085
	// (get) Token: 0x06002432 RID: 9266 RVA: 0x0008A4A0 File Offset: 0x000886A0
	public bool isNGC
	{
		get
		{
			return this.p1 != 0;
		}
	}

	// Token: 0x17000826 RID: 2086
	// (get) Token: 0x06002433 RID: 9267 RVA: 0x0008A4B0 File Offset: 0x000886B0
	public bool isUnassigned
	{
		get
		{
			return this.v == 0;
		}
	}

	// Token: 0x17000827 RID: 2087
	// (get) Token: 0x06002434 RID: 9268 RVA: 0x0008A4BC File Offset: 0x000886BC
	public bool isMine
	{
		get
		{
			return this.p1 != 0 || this._viewID.isMine;
		}
	}

	// Token: 0x17000828 RID: 2088
	// (get) Token: 0x06002435 RID: 9269 RVA: 0x0008A4D8 File Offset: 0x000886D8
	public bool isAllocated
	{
		get
		{
			return this.p1 != 0 || this._viewID.isAllocated;
		}
	}

	// Token: 0x17000829 RID: 2089
	// (get) Token: 0x06002436 RID: 9270 RVA: 0x0008A4F4 File Offset: 0x000886F4
	public bool isManual
	{
		get
		{
			return this.p1 == 0 && this._viewID.isManual;
		}
	}

	// Token: 0x1700082A RID: 2090
	// (get) Token: 0x06002437 RID: 9271 RVA: 0x0008A510 File Offset: 0x00088710
	public int id
	{
		get
		{
			return this.v;
		}
	}

	// Token: 0x1700082B RID: 2091
	// (get) Token: 0x06002438 RID: 9272 RVA: 0x0008A518 File Offset: 0x00088718
	public global::uLink.NetworkPlayer owner
	{
		get
		{
			if (this.p1 == 0)
			{
				return this._viewID.owner;
			}
			return global::uLink.NetworkPlayer.server;
		}
	}

	// Token: 0x06002439 RID: 9273 RVA: 0x0008A538 File Offset: 0x00088738
	public override bool Equals(object obj)
	{
		return (!(obj is global::NetEntityID)) ? (this.isNet && obj is global::uLink.NetworkViewID && this.Equals((global::uLink.NetworkViewID)obj)) : this.Equals((global::NetEntityID)obj);
	}

	// Token: 0x0600243A RID: 9274 RVA: 0x0008A588 File Offset: 0x00088788
	public bool Equals(global::NetEntityID obj)
	{
		return this.v == obj.v;
	}

	// Token: 0x0600243B RID: 9275 RVA: 0x0008A59C File Offset: 0x0008879C
	public bool Equals(global::uLink.NetworkViewID obj)
	{
		return this.p1 == 0 && this._viewID == obj;
	}

	// Token: 0x0600243C RID: 9276 RVA: 0x0008A5B8 File Offset: 0x000887B8
	public override string ToString()
	{
		if (this.v == 0)
		{
			return "Unassigned";
		}
		if (this.p1 == 0)
		{
			return this._viewID.ToString();
		}
		return string.Format("NGC ViewID {0} ({1}:{2})", this.v, this.p1, (int)(this.p2 + 1));
	}

	// Token: 0x1700082C RID: 2092
	// (get) Token: 0x0600243D RID: 9277 RVA: 0x0008A61C File Offset: 0x0008881C
	public static global::NetEntityID unassigned
	{
		get
		{
			return default(global::NetEntityID);
		}
	}

	// Token: 0x1700082D RID: 2093
	// (get) Token: 0x0600243E RID: 9278 RVA: 0x0008A634 File Offset: 0x00088834
	public global::IDMain main
	{
		get
		{
			if (this.p1 == 0)
			{
				if (this.p2 == 0)
				{
					return null;
				}
				global::Facepunch.NetworkView networkView = global::Facepunch.NetworkView.Find(this._viewID);
				if (!networkView)
				{
					return null;
				}
				global::IDBase idbase = global::IDBase.Get(networkView);
				if (idbase)
				{
					return idbase.idMain;
				}
				return null;
			}
			else
			{
				global::NGCView ngcview = global::NGC.Find(this.v);
				if (ngcview)
				{
					return global::IDBase.GetMain(ngcview.gameObject);
				}
				return null;
			}
		}
	}

	// Token: 0x1700082E RID: 2094
	// (get) Token: 0x0600243F RID: 9279 RVA: 0x0008A6B4 File Offset: 0x000888B4
	public global::IDBase idBase
	{
		get
		{
			if (this.p1 == 0)
			{
				if (this.p2 == 0)
				{
					return null;
				}
				global::Facepunch.NetworkView networkView = global::Facepunch.NetworkView.Find(this._viewID);
				if (networkView)
				{
					return global::IDBase.Get(networkView);
				}
				return null;
			}
			else
			{
				global::NGCView ngcview = global::NGC.Find(this.v);
				if (ngcview)
				{
					return global::IDBase.Get(ngcview.gameObject);
				}
				return null;
			}
		}
	}

	// Token: 0x1700082F RID: 2095
	// (get) Token: 0x06002440 RID: 9280 RVA: 0x0008A720 File Offset: 0x00088920
	public global::Facepunch.NetworkView networkView
	{
		get
		{
			if (this.p1 == 0)
			{
				return global::Facepunch.NetworkView.Find(this._viewID);
			}
			return null;
		}
	}

	// Token: 0x17000830 RID: 2096
	// (get) Token: 0x06002441 RID: 9281 RVA: 0x0008A73C File Offset: 0x0008893C
	public global::NGCView ngcView
	{
		get
		{
			if (this.p1 == 0)
			{
				return null;
			}
			return global::NGC.Find(this.v);
		}
	}

	// Token: 0x17000831 RID: 2097
	// (get) Token: 0x06002442 RID: 9282 RVA: 0x0008A758 File Offset: 0x00088958
	public global::UnityEngine.GameObject gameObject
	{
		get
		{
			global::UnityEngine.MonoBehaviour view = this.view;
			return (!view) ? null : view.gameObject;
		}
	}

	// Token: 0x17000832 RID: 2098
	// (get) Token: 0x06002443 RID: 9283 RVA: 0x0008A784 File Offset: 0x00088984
	public global::UnityEngine.MonoBehaviour view
	{
		get
		{
			if (this.p1 != 0)
			{
				return global::NGC.Find(this.v);
			}
			if (this.p2 == 0)
			{
				return null;
			}
			return global::Facepunch.NetworkView.Find(this._viewID);
		}
	}

	// Token: 0x06002444 RID: 9284 RVA: 0x0008A7B8 File Offset: 0x000889B8
	public override int GetHashCode()
	{
		return (this.p1 != 0) ? (this.v ^ -0x10000) : this.p2.GetHashCode();
	}

	// Token: 0x06002445 RID: 9285 RVA: 0x0008A7E4 File Offset: 0x000889E4
	public int CompareTo(global::NetEntityID other)
	{
		return this.v.CompareTo(other.v);
	}

	// Token: 0x06002446 RID: 9286 RVA: 0x0008A7F8 File Offset: 0x000889F8
	public int CompareTo(global::uLink.NetworkViewID other)
	{
		return this.v.CompareTo(other.id);
	}

	// Token: 0x06002447 RID: 9287 RVA: 0x0008A80C File Offset: 0x00088A0C
	private static void Serializer(global::uLink.BitStream bs, object value, params object[] codecOptions)
	{
		global::NetEntityID netEntityID = (global::NetEntityID)value;
		bs.Write<ushort>(netEntityID.p1, codecOptions);
		if (netEntityID.p1 == 0)
		{
			bs.Write<global::uLink.NetworkViewID>(netEntityID._viewID, codecOptions);
		}
		else
		{
			bs.Write<ushort>(netEntityID.p2, new object[0]);
		}
	}

	// Token: 0x06002448 RID: 9288 RVA: 0x0008A860 File Offset: 0x00088A60
	private static object Deserializer(global::uLink.BitStream bs, params object[] codecOptions)
	{
		global::NetEntityID netEntityID = default(global::NetEntityID);
		netEntityID.p1 = bs.Read<ushort>(codecOptions);
		if (netEntityID.p1 == 0)
		{
			netEntityID._viewID = bs.Read<global::uLink.NetworkViewID>(codecOptions);
		}
		else
		{
			netEntityID.p2 = bs.Read<ushort>(codecOptions);
		}
		return netEntityID;
	}

	// Token: 0x06002449 RID: 9289 RVA: 0x0008A8B8 File Offset: 0x00088AB8
	public static global::NetEntityID.Kind Of(global::UnityEngine.Component component, out global::NetEntityID entID, out global::UnityEngine.MonoBehaviour view)
	{
		if (component is global::UnityEngine.MonoBehaviour)
		{
			return global::NetEntityID.Of((global::UnityEngine.MonoBehaviour)component, out entID, out view);
		}
		if (component)
		{
			return global::NetEntityID.Of(component.gameObject, out entID, out view);
		}
		entID = global::NetEntityID.unassigned;
		view = null;
		return global::NetEntityID.Kind.Missing;
	}

	// Token: 0x0600244A RID: 9290 RVA: 0x0008A908 File Offset: 0x00088B08
	public static global::NetEntityID.Kind Of(global::UnityEngine.Component component, out global::NetEntityID entID)
	{
		global::UnityEngine.MonoBehaviour monoBehaviour;
		return global::NetEntityID.Of(component, out entID, out monoBehaviour);
	}

	// Token: 0x0600244B RID: 9291 RVA: 0x0008A920 File Offset: 0x00088B20
	public static global::NetEntityID.Kind Of(global::UnityEngine.Component component, out global::UnityEngine.MonoBehaviour view)
	{
		global::NetEntityID netEntityID;
		return global::NetEntityID.Of(component, out netEntityID, out view);
	}

	// Token: 0x0600244C RID: 9292 RVA: 0x0008A938 File Offset: 0x00088B38
	public static global::NetEntityID.Kind Of(global::UnityEngine.Component component)
	{
		global::NetEntityID netEntityID;
		global::UnityEngine.MonoBehaviour monoBehaviour;
		return global::NetEntityID.Of(component, out netEntityID, out monoBehaviour);
	}

	// Token: 0x0600244D RID: 9293 RVA: 0x0008A950 File Offset: 0x00088B50
	public static global::NetEntityID.Kind Of(global::UnityEngine.MonoBehaviour script, out global::NetEntityID entID, out global::UnityEngine.MonoBehaviour view)
	{
		if (!script)
		{
			entID = global::NetEntityID.unassigned;
			view = null;
			return global::NetEntityID.Kind.Missing;
		}
		if (script is global::uLink.NetworkView)
		{
			view = script;
			entID = ((global::uLink.NetworkView)script).viewID;
			return global::NetEntityID.Kind.Net;
		}
		if (script is global::NGCView)
		{
			view = script;
			entID = new global::NetEntityID((global::NGCView)script);
			return global::NetEntityID.Kind.NGC;
		}
		return global::NetEntityID.Of(script.gameObject, out entID, out view);
	}

	// Token: 0x0600244E RID: 9294 RVA: 0x0008A9C8 File Offset: 0x00088BC8
	public static global::NetEntityID.Kind Of(global::UnityEngine.MonoBehaviour script, out global::NetEntityID entID)
	{
		global::UnityEngine.MonoBehaviour monoBehaviour;
		return global::NetEntityID.Of(script, out entID, out monoBehaviour);
	}

	// Token: 0x0600244F RID: 9295 RVA: 0x0008A9E0 File Offset: 0x00088BE0
	public static global::NetEntityID.Kind Of(global::UnityEngine.MonoBehaviour script, out global::UnityEngine.MonoBehaviour view)
	{
		global::NetEntityID netEntityID;
		return global::NetEntityID.Of(script, out netEntityID, out view);
	}

	// Token: 0x06002450 RID: 9296 RVA: 0x0008A9F8 File Offset: 0x00088BF8
	public static global::NetEntityID.Kind Of(global::UnityEngine.MonoBehaviour script)
	{
		global::NetEntityID netEntityID;
		global::UnityEngine.MonoBehaviour monoBehaviour;
		return global::NetEntityID.Of(script, out netEntityID, out monoBehaviour);
	}

	// Token: 0x06002451 RID: 9297 RVA: 0x0008AA10 File Offset: 0x00088C10
	public static global::NetEntityID.Kind Of(global::UnityEngine.GameObject entity)
	{
		global::NetEntityID netEntityID;
		global::UnityEngine.MonoBehaviour monoBehaviour;
		return global::NetEntityID.Of(entity, out netEntityID, out monoBehaviour);
	}

	// Token: 0x06002452 RID: 9298 RVA: 0x0008AA28 File Offset: 0x00088C28
	public static global::NetEntityID.Kind Of(global::UnityEngine.GameObject entity, out global::UnityEngine.MonoBehaviour view)
	{
		global::NetEntityID netEntityID;
		return global::NetEntityID.Of(entity, out netEntityID, out view);
	}

	// Token: 0x06002453 RID: 9299 RVA: 0x0008AA40 File Offset: 0x00088C40
	public static global::NetEntityID.Kind Of(global::UnityEngine.GameObject entity, out global::NetEntityID entID)
	{
		global::UnityEngine.MonoBehaviour monoBehaviour;
		return global::NetEntityID.Of(entity, out entID, out monoBehaviour);
	}

	// Token: 0x06002454 RID: 9300 RVA: 0x0008AA58 File Offset: 0x00088C58
	public static global::NetEntityID.Kind Of(global::UnityEngine.GameObject entity, out global::NetEntityID entID, out global::UnityEngine.MonoBehaviour view)
	{
		if (!entity)
		{
			entID = global::NetEntityID.unassigned;
			view = null;
			return global::NetEntityID.Kind.Missing;
		}
		global::uLink.NetworkView component = entity.GetComponent<global::uLink.NetworkView>();
		if (component)
		{
			entID = new global::NetEntityID(component.viewID);
			view = component;
			return global::NetEntityID.Kind.Net;
		}
		global::NGCView component2 = entity.GetComponent<global::NGCView>();
		if (component2)
		{
			entID = new global::NetEntityID(component2);
			view = component2;
			return global::NetEntityID.Kind.NGC;
		}
		entID = global::NetEntityID.unassigned;
		view = null;
		return global::NetEntityID.Kind.Missing;
	}

	// Token: 0x06002455 RID: 9301 RVA: 0x0008AAD0 File Offset: 0x00088CD0
	public TComponent GetComponent<TComponent>() where TComponent : global::UnityEngine.Component
	{
		global::UnityEngine.MonoBehaviour view = this.view;
		return (!view) ? ((TComponent)((object)null)) : view.GetComponent<TComponent>();
	}

	// Token: 0x06002456 RID: 9302 RVA: 0x0008AB00 File Offset: 0x00088D00
	public bool GetComponent<TComponent>(out TComponent component) where TComponent : global::UnityEngine.Component
	{
		global::UnityEngine.MonoBehaviour view = this.view;
		if (!view)
		{
			component = (TComponent)((object)null);
			return false;
		}
		if (view is TComponent)
		{
			component = (TComponent)((object)view);
			return true;
		}
		return component = view.GetComponent<TComponent>();
	}

	// Token: 0x17000833 RID: 2099
	// (get) Token: 0x06002457 RID: 9303 RVA: 0x0008AB60 File Offset: 0x00088D60
	public global::UnityEngine.Collider collider
	{
		get
		{
			global::UnityEngine.MonoBehaviour view = this.view;
			return (!view) ? null : view.collider;
		}
	}

	// Token: 0x17000834 RID: 2100
	// (get) Token: 0x06002458 RID: 9304 RVA: 0x0008AB8C File Offset: 0x00088D8C
	public global::UnityEngine.Renderer renderer
	{
		get
		{
			global::UnityEngine.MonoBehaviour view = this.view;
			return (!view) ? null : view.renderer;
		}
	}

	// Token: 0x17000835 RID: 2101
	// (get) Token: 0x06002459 RID: 9305 RVA: 0x0008ABB8 File Offset: 0x00088DB8
	public global::UnityEngine.Transform transform
	{
		get
		{
			global::UnityEngine.MonoBehaviour view = this.view;
			return (!view) ? null : view.transform;
		}
	}

	// Token: 0x17000836 RID: 2102
	// (get) Token: 0x0600245A RID: 9306 RVA: 0x0008ABE4 File Offset: 0x00088DE4
	public global::UnityEngine.Rigidbody rigidbody
	{
		get
		{
			global::UnityEngine.MonoBehaviour view = this.view;
			return (!view) ? null : view.rigidbody;
		}
	}

	// Token: 0x0600245B RID: 9307 RVA: 0x0008AC10 File Offset: 0x00088E10
	public static global::NetEntityID Get(global::UnityEngine.GameObject entity)
	{
		return global::NetEntityID.Get(entity, false);
	}

	// Token: 0x0600245C RID: 9308 RVA: 0x0008AC1C File Offset: 0x00088E1C
	public static global::NetEntityID Get(global::UnityEngine.GameObject entity, bool throwIfNotFound)
	{
		global::NetEntityID result;
		if ((int)global::NetEntityID.Of(entity, out result) != 0)
		{
			return result;
		}
		if (throwIfNotFound)
		{
			throw new global::System.InvalidOperationException("no recognizable net entity id");
		}
		return global::NetEntityID.unassigned;
	}

	// Token: 0x0600245D RID: 9309 RVA: 0x0008AC50 File Offset: 0x00088E50
	public static global::NetEntityID Get(global::UnityEngine.Component entityComponent)
	{
		return global::NetEntityID.Get(entityComponent, false);
	}

	// Token: 0x0600245E RID: 9310 RVA: 0x0008AC5C File Offset: 0x00088E5C
	public static global::NetEntityID Get(global::UnityEngine.Component entityComponent, bool throwIfNotFound)
	{
		global::NetEntityID result;
		if ((int)global::NetEntityID.Of(entityComponent, out result) != 0)
		{
			return result;
		}
		if (throwIfNotFound)
		{
			throw new global::System.InvalidOperationException("no recognizable net entity id");
		}
		return global::NetEntityID.unassigned;
	}

	// Token: 0x0600245F RID: 9311 RVA: 0x0008AC90 File Offset: 0x00088E90
	public static global::NetEntityID Get(global::UnityEngine.MonoBehaviour entityScript)
	{
		return global::NetEntityID.Get(entityScript, false);
	}

	// Token: 0x06002460 RID: 9312 RVA: 0x0008AC9C File Offset: 0x00088E9C
	public static global::NetEntityID Get(global::UnityEngine.MonoBehaviour entityScript, bool throwIfNotFound)
	{
		global::NetEntityID result;
		if ((int)global::NetEntityID.Of(entityScript, out result) != 0)
		{
			return result;
		}
		if (throwIfNotFound)
		{
			throw new global::System.InvalidOperationException("no recognizable net entity id");
		}
		return global::NetEntityID.unassigned;
	}

	// Token: 0x06002461 RID: 9313 RVA: 0x0008ACD0 File Offset: 0x00088ED0
	public static global::NetEntityID Get(global::uLink.NetworkViewID id)
	{
		return new global::NetEntityID(id);
	}

	// Token: 0x06002462 RID: 9314 RVA: 0x0008ACD8 File Offset: 0x00088ED8
	public static bool operator ==(global::NetEntityID lhs, global::NetEntityID rhs)
	{
		return lhs.v == rhs.v;
	}

	// Token: 0x06002463 RID: 9315 RVA: 0x0008ACEC File Offset: 0x00088EEC
	public static bool operator !=(global::NetEntityID lhs, global::NetEntityID rhs)
	{
		return lhs.v != rhs.v;
	}

	// Token: 0x06002464 RID: 9316 RVA: 0x0008AD04 File Offset: 0x00088F04
	public static bool operator ==(global::NetEntityID lhs, global::uLink.NetworkViewID rhs)
	{
		return lhs.p1 == 0 && (int)lhs.p2 == rhs.id;
	}

	// Token: 0x06002465 RID: 9317 RVA: 0x0008AD28 File Offset: 0x00088F28
	public static bool operator !=(global::NetEntityID lhs, global::uLink.NetworkViewID rhs)
	{
		return lhs.p1 != 0 || (int)lhs.p2 != rhs.id;
	}

	// Token: 0x06002466 RID: 9318 RVA: 0x0008AD58 File Offset: 0x00088F58
	public static bool operator ==(global::uLink.NetworkViewID lhs, global::NetEntityID rhs)
	{
		return rhs.p1 == 0 && (int)rhs.p2 == lhs.id;
	}

	// Token: 0x06002467 RID: 9319 RVA: 0x0008AD7C File Offset: 0x00088F7C
	public static bool operator !=(global::uLink.NetworkViewID lhs, global::NetEntityID rhs)
	{
		return rhs.p1 != 0 || (int)rhs.p2 != lhs.id;
	}

	// Token: 0x06002468 RID: 9320 RVA: 0x0008ADAC File Offset: 0x00088FAC
	public static bool operator >=(global::NetEntityID lhs, global::NetEntityID rhs)
	{
		return lhs.v >= rhs.v;
	}

	// Token: 0x06002469 RID: 9321 RVA: 0x0008ADC4 File Offset: 0x00088FC4
	public static bool operator >=(global::NetEntityID lhs, global::uLink.NetworkViewID rhs)
	{
		return lhs.v >= rhs.id;
	}

	// Token: 0x0600246A RID: 9322 RVA: 0x0008ADDC File Offset: 0x00088FDC
	public static bool operator >=(global::uLink.NetworkViewID lhs, global::NetEntityID rhs)
	{
		return lhs.id >= rhs.v;
	}

	// Token: 0x0600246B RID: 9323 RVA: 0x0008ADF4 File Offset: 0x00088FF4
	public static bool operator <=(global::NetEntityID lhs, global::NetEntityID rhs)
	{
		return lhs.v <= rhs.v;
	}

	// Token: 0x0600246C RID: 9324 RVA: 0x0008AE0C File Offset: 0x0008900C
	public static bool operator <=(global::NetEntityID lhs, global::uLink.NetworkViewID rhs)
	{
		return lhs.v <= rhs.id;
	}

	// Token: 0x0600246D RID: 9325 RVA: 0x0008AE24 File Offset: 0x00089024
	public static bool operator <=(global::uLink.NetworkViewID lhs, global::NetEntityID rhs)
	{
		return lhs.id <= rhs.v;
	}

	// Token: 0x0600246E RID: 9326 RVA: 0x0008AE3C File Offset: 0x0008903C
	public static bool operator >(global::NetEntityID lhs, global::NetEntityID rhs)
	{
		return lhs.v > rhs.v;
	}

	// Token: 0x0600246F RID: 9327 RVA: 0x0008AE50 File Offset: 0x00089050
	public static bool operator >(global::NetEntityID lhs, global::uLink.NetworkViewID rhs)
	{
		return lhs.v > rhs.id;
	}

	// Token: 0x06002470 RID: 9328 RVA: 0x0008AE64 File Offset: 0x00089064
	public static bool operator >(global::uLink.NetworkViewID lhs, global::NetEntityID rhs)
	{
		return lhs.id > rhs.v;
	}

	// Token: 0x06002471 RID: 9329 RVA: 0x0008AE78 File Offset: 0x00089078
	public static bool operator <(global::NetEntityID lhs, global::NetEntityID rhs)
	{
		return lhs.v < rhs.v;
	}

	// Token: 0x06002472 RID: 9330 RVA: 0x0008AE8C File Offset: 0x0008908C
	public static bool operator <(global::NetEntityID lhs, global::uLink.NetworkViewID rhs)
	{
		return lhs.v < rhs.id;
	}

	// Token: 0x06002473 RID: 9331 RVA: 0x0008AEA0 File Offset: 0x000890A0
	public static bool operator <(global::uLink.NetworkViewID lhs, global::NetEntityID rhs)
	{
		return lhs.id < rhs.v;
	}

	// Token: 0x06002474 RID: 9332 RVA: 0x0008AEB4 File Offset: 0x000890B4
	public static implicit operator global::NetEntityID(global::uLink.NetworkViewID viewID)
	{
		return new global::NetEntityID
		{
			_viewID = viewID
		};
	}

	// Token: 0x06002475 RID: 9333 RVA: 0x0008AED4 File Offset: 0x000890D4
	public static explicit operator global::uLink.NetworkViewID(global::NetEntityID viewID)
	{
		if (viewID.p1 != 0)
		{
			throw new global::System.InvalidCastException("The NetEntityID did not represet a NetworkViewID");
		}
		return viewID._viewID;
	}

	// Token: 0x06002476 RID: 9334 RVA: 0x0008AEF4 File Offset: 0x000890F4
	public static bool operator true(global::NetEntityID id)
	{
		return id.v != 0;
	}

	// Token: 0x06002477 RID: 9335 RVA: 0x0008AF04 File Offset: 0x00089104
	public static bool operator false(global::NetEntityID id)
	{
		return id.v == 0;
	}

	// Token: 0x0400121E RID: 4638
	[global::System.Runtime.InteropServices.FieldOffset(0)]
	private global::uLink.NetworkViewID _viewID;

	// Token: 0x0400121F RID: 4639
	[global::System.Runtime.InteropServices.FieldOffset(0)]
	private ushort p2;

	// Token: 0x04001220 RID: 4640
	[global::System.Runtime.InteropServices.FieldOffset(2)]
	private ushort p1;

	// Token: 0x04001221 RID: 4641
	[global::System.Runtime.InteropServices.FieldOffset(0)]
	private int v;

	// Token: 0x04001222 RID: 4642
	private static readonly global::uLink.BitStreamCodec.Serializer serializer = new global::uLink.BitStreamCodec.Serializer(global::NetEntityID.Serializer);

	// Token: 0x04001223 RID: 4643
	private static readonly global::uLink.BitStreamCodec.Deserializer deserializer = new global::uLink.BitStreamCodec.Deserializer(global::NetEntityID.Deserializer);

	// Token: 0x02000418 RID: 1048
	public enum Kind : sbyte
	{
		// Token: 0x04001225 RID: 4645
		NGC = -1,
		// Token: 0x04001226 RID: 4646
		Missing,
		// Token: 0x04001227 RID: 4647
		Net
	}
}
