using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Magma
{
	// Token: 0x02000003 RID: 3
	public class Zone3D
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000008 RID: 8 RVA: 0x000020B7 File Offset: 0x000002B7
		// (set) Token: 0x06000009 RID: 9 RVA: 0x000020BF File Offset: 0x000002BF
		public global::System.Collections.Generic.List<global::UnityEngine.Vector2> Points
		{
			get
			{
				return this._points;
			}
			set
			{
				this._points = value;
			}
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x0600000A RID: 10 RVA: 0x000020C8 File Offset: 0x000002C8
		public global::System.Collections.Generic.List<global::Magma.Entity> Entities
		{
			get
			{
				global::System.Collections.Generic.List<global::Magma.Entity> list = new global::System.Collections.Generic.List<global::Magma.Entity>();
				foreach (global::Magma.Entity entity in global::Magma.World.GetWorld().Entities)
				{
					if (this.Contains(entity))
					{
						list.Add(entity);
					}
				}
				return list;
			}
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x0600000B RID: 11 RVA: 0x00002130 File Offset: 0x00000330
		// (set) Token: 0x0600000C RID: 12 RVA: 0x00002138 File Offset: 0x00000338
		public bool PVP
		{
			get
			{
				return this._pvp;
			}
			set
			{
				this._pvp = value;
			}
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x0600000D RID: 13 RVA: 0x00002141 File Offset: 0x00000341
		// (set) Token: 0x0600000E RID: 14 RVA: 0x00002149 File Offset: 0x00000349
		public bool Protected
		{
			get
			{
				return this._protected;
			}
			set
			{
				this._protected = value;
			}
		}

		// Token: 0x0600000F RID: 15 RVA: 0x00002152 File Offset: 0x00000352
		public Zone3D(string name)
		{
			this.PVP = true;
			this.Protected = false;
			this.tmpPoints = new global::System.Collections.Generic.List<global::Magma.Entity>();
			this.Points = new global::System.Collections.Generic.List<global::UnityEngine.Vector2>();
			global::Magma.DataStore.GetInstance().Add("3DZonesList", name, this);
		}

		// Token: 0x06000010 RID: 16 RVA: 0x00002190 File Offset: 0x00000390
		public void ShowMarkers()
		{
			this.HideMarkers();
			foreach (global::UnityEngine.Vector2 vector in this.Points)
			{
				global::UnityEngine.Vector3 location;
				location..ctor(vector.x, global::Magma.World.GetWorld().GetGround(vector.x, vector.y), vector.y);
				global::Magma.Entity item = global::Magma.World.GetWorld().Spawn(";struct_metal_pillar", location) as global::Magma.Entity;
				this.tmpPoints.Add(item);
			}
		}

		// Token: 0x06000011 RID: 17 RVA: 0x00002234 File Offset: 0x00000434
		public void HideMarkers()
		{
			foreach (global::Magma.Entity entity in this.tmpPoints)
			{
				global::Magma.Util.GetUtil().DestroyObject((entity.Object as global::StructureComponent).gameObject);
			}
			this.tmpPoints.Clear();
		}

		// Token: 0x06000012 RID: 18 RVA: 0x000022A8 File Offset: 0x000004A8
		public void Mark(global::UnityEngine.Vector2 v)
		{
			this.Points.Add(v);
		}

		// Token: 0x06000013 RID: 19 RVA: 0x000022B6 File Offset: 0x000004B6
		public void Mark(float x, float y)
		{
			this.Points.Add(new global::UnityEngine.Vector2(x, y));
		}

		// Token: 0x06000014 RID: 20 RVA: 0x000022CC File Offset: 0x000004CC
		public bool Contains(global::UnityEngine.Vector3 v)
		{
			global::UnityEngine.Vector2 vector;
			vector..ctor(v.x, v.z);
			int index = this.Points.Count - 1;
			bool flag = false;
			int i = 0;
			while (i < this.Points.Count)
			{
				if (((this.Points[i].y <= vector.y && vector.y < this.Points[index].y) || (this.Points[index].y <= vector.y && vector.y < this.Points[i].y)) && vector.x < (this.Points[index].x - this.Points[i].x) * (vector.y - this.Points[i].y) / (this.Points[index].y - this.Points[i].y) + this.Points[i].x)
				{
					flag = !flag;
				}
				index = i++;
			}
			return flag;
		}

		// Token: 0x06000015 RID: 21 RVA: 0x0000240C File Offset: 0x0000060C
		public bool Contains(global::Magma.Entity en)
		{
			return this.Contains(new global::UnityEngine.Vector3(en.X, en.Y, en.Z));
		}

		// Token: 0x06000016 RID: 22 RVA: 0x0000242B File Offset: 0x0000062B
		public bool Contains(global::Magma.Player p)
		{
			return this.Contains(p.Location);
		}

		// Token: 0x06000017 RID: 23 RVA: 0x00002439 File Offset: 0x00000639
		public static global::Magma.Zone3D Get(string name)
		{
			return global::Magma.DataStore.GetInstance().Get("3DZonesList", name) as global::Magma.Zone3D;
		}

		// Token: 0x06000018 RID: 24 RVA: 0x00002450 File Offset: 0x00000650
		public static global::Magma.Zone3D GlobalContains(global::Magma.Player p)
		{
			global::System.Collections.Hashtable table = global::Magma.DataStore.GetInstance().GetTable("3DZonesList");
			if (table != null)
			{
				foreach (object obj in table.Values)
				{
					global::Magma.Zone3D zone3D = obj as global::Magma.Zone3D;
					if (zone3D.Contains(p))
					{
						return zone3D;
					}
				}
			}
			return null;
		}

		// Token: 0x06000019 RID: 25 RVA: 0x000024D0 File Offset: 0x000006D0
		public static global::Magma.Zone3D GlobalContains(global::Magma.Entity e)
		{
			global::System.Collections.Hashtable table = global::Magma.DataStore.GetInstance().GetTable("3DZonesList");
			if (table != null)
			{
				foreach (object obj in table.Values)
				{
					global::Magma.Zone3D zone3D = obj as global::Magma.Zone3D;
					if (zone3D.Contains(e))
					{
						return zone3D;
					}
				}
			}
			return null;
		}

		// Token: 0x04000003 RID: 3
		private global::System.Collections.Generic.List<global::Magma.Entity> tmpPoints;

		// Token: 0x04000004 RID: 4
		private global::System.Collections.Generic.List<global::UnityEngine.Vector2> _points;

		// Token: 0x04000005 RID: 5
		private bool _pvp;

		// Token: 0x04000006 RID: 6
		private bool _protected;
	}
}
