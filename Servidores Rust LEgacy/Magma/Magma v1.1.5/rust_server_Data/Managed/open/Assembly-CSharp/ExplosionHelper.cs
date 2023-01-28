using System;
using System.Collections;
using System.Collections.Generic;
using Facepunch.MeshBatch;
using Facepunch.MeshBatch.Extensions;
using UnityEngine;

// Token: 0x020005F6 RID: 1526
public static class ExplosionHelper
{
	// Token: 0x06003121 RID: 12577 RVA: 0x000BBA08 File Offset: 0x000B9C08
	public static global::ExplosionHelper.Surface[] OverlapExplosion(global::UnityEngine.Vector3 point, float explosionRadius, int findLayerMask = -1, int occludingLayerMask = -1, global::IDMain ignore = null)
	{
		global::ExplosionHelper.Point point2 = new global::ExplosionHelper.Point(point, explosionRadius, findLayerMask, occludingLayerMask, ignore);
		return point2.ToArray();
	}

	// Token: 0x06003122 RID: 12578 RVA: 0x000BBA2C File Offset: 0x000B9C2C
	public static global::ExplosionHelper.Surface[] OverlapExplosionSorted(global::UnityEngine.Vector3 point, float explosionRadius, int findLayerMask = -1, int occludingLayerMask = -1, global::IDMain ignore = null)
	{
		global::ExplosionHelper.Surface[] array = global::ExplosionHelper.OverlapExplosion(point, explosionRadius, findLayerMask, occludingLayerMask, ignore);
		if (array.Length > 1)
		{
			global::System.Array.Sort<global::ExplosionHelper.Surface>(array);
		}
		return array;
	}

	// Token: 0x06003123 RID: 12579 RVA: 0x000BBA58 File Offset: 0x000B9C58
	public static global::ExplosionHelper.Surface[] OverlapExplosionUnique(global::UnityEngine.Vector3 point, float explosionRadius, int findLayerMask = -1, int occludingLayerMask = -1, global::IDMain ignore = null)
	{
		global::ExplosionHelper.Surface[] array = global::ExplosionHelper.OverlapExplosion(point, explosionRadius, findLayerMask, occludingLayerMask, ignore);
		int num = array.Length;
		if (num > 1)
		{
			global::System.Array.Sort<global::ExplosionHelper.Surface>(array);
			if (global::ExplosionHelper.Unique.Filter(array, ref num))
			{
				global::System.Array.Resize<global::ExplosionHelper.Surface>(ref array, num);
			}
		}
		return array;
	}

	// Token: 0x04001B47 RID: 6983
	private const float kMaxZero = 1E-05f;

	// Token: 0x020005F7 RID: 1527
	public struct Surface : global::System.IEquatable<global::ExplosionHelper.Surface>, global::System.IComparable<global::ExplosionHelper.Surface>
	{
		// Token: 0x06003124 RID: 12580 RVA: 0x000BBA98 File Offset: 0x000B9C98
		public override bool Equals(object obj)
		{
			return obj is global::ExplosionHelper.Surface && this.Equals((global::ExplosionHelper.Surface)obj);
		}

		// Token: 0x06003125 RID: 12581 RVA: 0x000BBAB4 File Offset: 0x000B9CB4
		public bool Equals(global::ExplosionHelper.Surface surface)
		{
			return this.blocked == surface.blocked && this.bounds == surface.bounds && this.idBase == surface.idBase && this.idMain == surface.idMain && this.work.Equals(ref surface.work);
		}

		// Token: 0x06003126 RID: 12582 RVA: 0x000BBB30 File Offset: 0x000B9D30
		public bool Equals(ref global::ExplosionHelper.Surface surface)
		{
			return this.blocked == surface.blocked && this.bounds == surface.bounds && this.idBase == surface.idBase && this.idMain == surface.idMain && this.work.Equals(ref surface.work);
		}

		// Token: 0x06003127 RID: 12583 RVA: 0x000BBBA4 File Offset: 0x000B9DA4
		public override string ToString()
		{
			return "Surface";
		}

		// Token: 0x06003128 RID: 12584 RVA: 0x000BBBAC File Offset: 0x000B9DAC
		public override int GetHashCode()
		{
			return this.bounds.GetHashCode() ^ ((!this.idBase) ? 0 : this.idBase.GetHashCode());
		}

		// Token: 0x06003129 RID: 12585 RVA: 0x000BBBE8 File Offset: 0x000B9DE8
		public int CompareTo(global::ExplosionHelper.Surface other)
		{
			int num = this.blocked.CompareTo(other.blocked);
			if (num == 0)
			{
				num = this.work.distanceToCenter.CompareTo(other.work.distanceToCenter);
				if (num == 0)
				{
					num = this.work.boundsSquareDistance.CompareTo(other.work.squareDistanceToCenter);
					if (num == 0)
					{
						num = this.work.rayDistance.CompareTo(other.work.rayDistance);
					}
				}
			}
			return num;
		}

		// Token: 0x04001B48 RID: 6984
		public global::IDBase idBase;

		// Token: 0x04001B49 RID: 6985
		public global::IDMain idMain;

		// Token: 0x04001B4A RID: 6986
		public global::UnityEngine.Bounds bounds;

		// Token: 0x04001B4B RID: 6987
		public global::ExplosionHelper.Work work;

		// Token: 0x04001B4C RID: 6988
		public bool blocked;
	}

	// Token: 0x020005F8 RID: 1528
	public struct Work
	{
		// Token: 0x0600312A RID: 12586 RVA: 0x000BBC74 File Offset: 0x000B9E74
		public bool Equals(ref global::ExplosionHelper.Work w)
		{
			return this.squareDistanceToCenter == w.squareDistanceToCenter && this.boundsSquareDistance == w.boundsSquareDistance && this.boundsExtentSquareMagnitude == w.boundsExtentSquareMagnitude && this.distanceToCenter == w.distanceToCenter && ((!this.rayTest) ? (!w.rayTest) : (w.rayTest && this.squareRayDistance == w.squareRayDistance && this.rayDistance == w.rayDistance && this.rayDir == w.rayDir)) && this.center == w.center && this.boundsExtent == w.boundsExtent;
		}

		// Token: 0x04001B4D RID: 6989
		public global::UnityEngine.Vector3 center;

		// Token: 0x04001B4E RID: 6990
		public global::UnityEngine.Vector3 rayDir;

		// Token: 0x04001B4F RID: 6991
		public global::UnityEngine.Vector3 boundsExtent;

		// Token: 0x04001B50 RID: 6992
		public float boundsExtentSquareMagnitude;

		// Token: 0x04001B51 RID: 6993
		public float boundsSquareDistance;

		// Token: 0x04001B52 RID: 6994
		public float distanceToCenter;

		// Token: 0x04001B53 RID: 6995
		public float squareDistanceToCenter;

		// Token: 0x04001B54 RID: 6996
		public float rayDistance;

		// Token: 0x04001B55 RID: 6997
		public float squareRayDistance;

		// Token: 0x04001B56 RID: 6998
		public bool rayTest;
	}

	// Token: 0x020005F9 RID: 1529
	public struct Point : global::System.Collections.IEnumerable, global::System.Collections.Generic.IEnumerable<global::ExplosionHelper.Surface>
	{
		// Token: 0x0600312B RID: 12587 RVA: 0x000BBD50 File Offset: 0x000B9F50
		public Point(global::UnityEngine.Vector3 point, float blastRadius, int overlapLayerMask, int raycastLayerMask, global::IDMain skip)
		{
			this.point = point;
			this.blastRadius = blastRadius;
			this.overlapLayerMask = overlapLayerMask;
			this.raycastLayerMask = raycastLayerMask;
			this.skip = skip;
		}

		// Token: 0x0600312C RID: 12588 RVA: 0x000BBD78 File Offset: 0x000B9F78
		global::System.Collections.Generic.IEnumerator<global::ExplosionHelper.Surface> global::System.Collections.Generic.IEnumerable<global::ExplosionHelper.Surface>.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		// Token: 0x0600312D RID: 12589 RVA: 0x000BBD88 File Offset: 0x000B9F88
		global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		// Token: 0x0600312E RID: 12590 RVA: 0x000BBD98 File Offset: 0x000B9F98
		private bool BoundsWork(ref global::UnityEngine.Bounds bounds, ref global::ExplosionHelper.Work w)
		{
			w.boundsSquareDistance = bounds.SqrDistance(this.point);
			if (w.boundsSquareDistance > this.blastRadius * this.blastRadius)
			{
				return false;
			}
			if (w.boundsSquareDistance <= 1E-05f)
			{
				w.boundsSquareDistance = 0f;
			}
			w.center = bounds.center;
			w.rayDir.x = w.center.x - this.point.x;
			w.rayDir.y = w.center.y - this.point.y;
			w.rayDir.z = w.center.z - this.point.z;
			w.squareDistanceToCenter = w.rayDir.x * w.rayDir.x + w.rayDir.y * w.rayDir.y + w.rayDir.z * w.rayDir.z;
			if (w.squareDistanceToCenter > this.blastRadius * this.blastRadius)
			{
				return false;
			}
			if (w.squareDistanceToCenter <= 9.9999994E-11f)
			{
				w.distanceToCenter = (w.squareDistanceToCenter = 0f);
				w.rayDistance = (w.squareRayDistance = 0f);
				w.rayTest = false;
				w.boundsExtent = bounds.size;
				w.boundsExtent.x = w.boundsExtent.x * 0.5f;
				w.boundsExtent.y = w.boundsExtent.y * 0.5f;
				w.boundsExtent.z = w.boundsExtent.z * 0.5f;
				w.boundsExtentSquareMagnitude = w.boundsExtent.x * w.boundsExtent.x + w.boundsExtent.y * w.boundsExtent.y + w.boundsExtent.z * w.boundsExtent.z;
				return true;
			}
			w.distanceToCenter = global::UnityEngine.Mathf.Sqrt(w.squareDistanceToCenter);
			w.boundsExtent = bounds.size;
			w.boundsExtent.x = w.boundsExtent.x * 0.5f;
			w.boundsExtent.y = w.boundsExtent.y * 0.5f;
			w.boundsExtent.z = w.boundsExtent.z * 0.5f;
			w.boundsExtentSquareMagnitude = w.boundsExtent.x * w.boundsExtent.x + w.boundsExtent.y * w.boundsExtent.y + w.boundsExtent.z * w.boundsExtent.z;
			w.squareRayDistance = w.boundsSquareDistance + w.boundsExtentSquareMagnitude;
			if (w.squareRayDistance > w.squareDistanceToCenter)
			{
				w.squareRayDistance = w.squareDistanceToCenter;
				w.rayDistance = w.distanceToCenter;
			}
			else
			{
				if (w.squareRayDistance <= 9.9999994E-11f)
				{
					w.rayDistance = (w.squareRayDistance = 0f);
					w.rayTest = false;
					return true;
				}
				w.rayDistance = global::UnityEngine.Mathf.Sqrt(w.squareRayDistance);
			}
			w.rayTest = true;
			return true;
		}

		// Token: 0x0600312F RID: 12591 RVA: 0x000BC0E4 File Offset: 0x000BA2E4
		private bool SurfaceForMeshBatchInstance(global::Facepunch.MeshBatch.MeshBatchInstance instance, ref global::ExplosionHelper.Surface surface)
		{
			surface.idBase = instance;
			surface.idMain = surface.idBase.idMain;
			if (!surface.idMain || surface.idMain == this.skip)
			{
				surface = default(global::ExplosionHelper.Surface);
				return false;
			}
			surface.bounds = instance.physicalBounds;
			if (this.BoundsWork(ref surface.bounds, ref surface.work))
			{
				if (surface.work.rayTest)
				{
					bool flag;
					global::Facepunch.MeshBatch.MeshBatchInstance meshBatchInstance;
					if (this.raycastLayerMask != 0 && global::Facepunch.MeshBatch.MeshBatchPhysics.Raycast(this.point, surface.work.rayDir, surface.work.rayDistance, this.raycastLayerMask, ref flag, ref meshBatchInstance))
					{
						if (flag && meshBatchInstance == instance)
						{
							surface.blocked = false;
						}
						else
						{
							surface.blocked = true;
						}
					}
					else
					{
						surface.blocked = false;
					}
				}
				else
				{
					surface.blocked = false;
				}
				return true;
			}
			surface = default(global::ExplosionHelper.Surface);
			return false;
		}

		// Token: 0x06003130 RID: 12592 RVA: 0x000BC200 File Offset: 0x000BA400
		private bool SurfaceForCollider(global::UnityEngine.Collider collider, ref global::ExplosionHelper.Surface surface)
		{
			if (!collider.enabled)
			{
				surface = default(global::ExplosionHelper.Surface);
				return false;
			}
			surface.idBase = global::IDBase.Get(collider);
			if (!surface.idBase)
			{
				surface = default(global::ExplosionHelper.Surface);
				return false;
			}
			surface.idMain = surface.idBase.idMain;
			if (!surface.idMain || surface.idMain == this.skip)
			{
				surface = default(global::ExplosionHelper.Surface);
				return false;
			}
			surface.bounds = collider.bounds;
			if (this.BoundsWork(ref surface.bounds, ref surface.work))
			{
				if (this.raycastLayerMask != 0)
				{
					global::UnityEngine.RaycastHit raycastHit;
					surface.blocked = (surface.work.rayTest && collider.Raycast(new global::UnityEngine.Ray(this.point, surface.work.rayDir), ref raycastHit, surface.work.rayDistance) && global::UnityEngine.Physics.Raycast(this.point, surface.work.rayDir, ref raycastHit, raycastHit.distance, this.raycastLayerMask) && raycastHit.collider != collider);
				}
				return true;
			}
			return false;
		}

		// Token: 0x06003131 RID: 12593 RVA: 0x000BC350 File Offset: 0x000BA550
		public global::ExplosionHelper.Point.Enumerator GetEnumerator()
		{
			return new global::ExplosionHelper.Point.Enumerator(ref this, false);
		}

		// Token: 0x06003132 RID: 12594 RVA: 0x000BC35C File Offset: 0x000BA55C
		public global::ExplosionHelper.Surface[] ToArray()
		{
			global::ExplosionHelper.Point.Enumerator enumerator = new global::ExplosionHelper.Point.Enumerator(ref this, true);
			return global::ExplosionHelper.Point.EnumeratorToArray.Build(ref enumerator);
		}

		// Token: 0x04001B57 RID: 6999
		public readonly global::UnityEngine.Vector3 point;

		// Token: 0x04001B58 RID: 7000
		public readonly float blastRadius;

		// Token: 0x04001B59 RID: 7001
		public readonly int overlapLayerMask;

		// Token: 0x04001B5A RID: 7002
		public readonly int raycastLayerMask;

		// Token: 0x04001B5B RID: 7003
		public readonly global::IDMain skip;

		// Token: 0x020005FA RID: 1530
		public struct Enumerator : global::System.IDisposable, global::System.Collections.IEnumerator, global::System.Collections.Generic.IEnumerator<global::ExplosionHelper.Surface>
		{
			// Token: 0x06003133 RID: 12595 RVA: 0x000BC37C File Offset: 0x000BA57C
			internal Enumerator(ref global::ExplosionHelper.Point point, bool immediate)
			{
				this._immediate = immediate;
				this.IN = point;
				this.colliderIndex = -1;
				this.inInstanceEnumerator = false;
				this.overlapEnumerator = null;
				this.output = null;
				this.overlap = null;
				this.current = default(global::ExplosionHelper.Surface);
			}

			// Token: 0x17000A48 RID: 2632
			// (get) Token: 0x06003134 RID: 12596 RVA: 0x000BC3D0 File Offset: 0x000BA5D0
			object global::System.Collections.IEnumerator.Current
			{
				get
				{
					return this.current;
				}
			}

			// Token: 0x17000A49 RID: 2633
			// (get) Token: 0x06003135 RID: 12597 RVA: 0x000BC3E0 File Offset: 0x000BA5E0
			public global::ExplosionHelper.Surface Current
			{
				get
				{
					return this.current;
				}
			}

			// Token: 0x06003136 RID: 12598 RVA: 0x000BC3E8 File Offset: 0x000BA5E8
			public bool MoveNext()
			{
				for (;;)
				{
					IL_00:
					while (this.inInstanceEnumerator)
					{
						if ((this._immediate || this.output) && this.overlapEnumerator.MoveNext())
						{
							global::Facepunch.MeshBatch.MeshBatchInstance instance = this.overlapEnumerator.Current;
							if (this.IN.SurfaceForMeshBatchInstance(instance, ref this.current))
							{
								return true;
							}
						}
						else
						{
							this.overlapEnumerator.Dispose();
							this.overlapEnumerator = null;
							this.inInstanceEnumerator = false;
							this.output = null;
						}
					}
					if (this.colliderIndex++ == -1)
					{
						this.overlap = global::UnityEngine.Physics.OverlapSphere(this.IN.point, this.IN.blastRadius, this.IN.overlapLayerMask);
					}
					while (this.colliderIndex < this.overlap.Length)
					{
						if (this._immediate || this.overlap[this.colliderIndex])
						{
							if (global::Facepunch.MeshBatch.Extensions.MeshBatchExtenders.GetMeshBatchPhysicalOutput<global::Facepunch.MeshBatch.MeshBatchPhysicalOutput>(this.overlap[this.colliderIndex], ref this.output))
							{
								this.inInstanceEnumerator = true;
								this.overlapEnumerator = this.output.EnumerateOverlapSphereInstances(this.IN.point, this.IN.blastRadius).GetEnumerator();
								goto IL_00;
							}
							if (this.IN.SurfaceForCollider(this.overlap[this.colliderIndex], ref this.current))
							{
								return true;
							}
						}
						this.colliderIndex++;
					}
					goto Block_8;
				}
				return true;
				Block_8:
				this.colliderIndex = this.overlap.Length;
				this.current = default(global::ExplosionHelper.Surface);
				return false;
			}

			// Token: 0x06003137 RID: 12599 RVA: 0x000BC5B8 File Offset: 0x000BA7B8
			public void Dispose()
			{
				this.colliderIndex = -1;
				if (this.inInstanceEnumerator)
				{
					this.inInstanceEnumerator = false;
					this.overlapEnumerator.Dispose();
				}
				this.overlapEnumerator = null;
				this.output = null;
				this.overlap = null;
				this.current = default(global::ExplosionHelper.Surface);
			}

			// Token: 0x06003138 RID: 12600 RVA: 0x000BC610 File Offset: 0x000BA810
			public void Reset()
			{
				this.Dispose();
			}

			// Token: 0x04001B5C RID: 7004
			private readonly global::ExplosionHelper.Point IN;

			// Token: 0x04001B5D RID: 7005
			private int colliderIndex;

			// Token: 0x04001B5E RID: 7006
			private bool inInstanceEnumerator;

			// Token: 0x04001B5F RID: 7007
			private global::Facepunch.MeshBatch.MeshBatchPhysicalOutput output;

			// Token: 0x04001B60 RID: 7008
			private global::System.Collections.Generic.IEnumerator<global::Facepunch.MeshBatch.MeshBatchInstance> overlapEnumerator;

			// Token: 0x04001B61 RID: 7009
			private global::UnityEngine.Collider[] overlap;

			// Token: 0x04001B62 RID: 7010
			public global::ExplosionHelper.Surface current;

			// Token: 0x04001B63 RID: 7011
			private readonly bool _immediate;
		}

		// Token: 0x020005FB RID: 1531
		private struct EnumeratorToArray
		{
			// Token: 0x06003139 RID: 12601 RVA: 0x000BC618 File Offset: 0x000BA818
			private void RecurseInStackHeapToArray()
			{
				if (this.enumerator.MoveNext())
				{
					global::ExplosionHelper.Surface current = this.enumerator.current;
					this.length++;
					this.RecurseInStackHeapToArray();
					this.array[--this.length] = current;
				}
				else
				{
					this.array = new global::ExplosionHelper.Surface[this.length];
				}
			}

			// Token: 0x0600313A RID: 12602 RVA: 0x000BC690 File Offset: 0x000BA890
			public static global::ExplosionHelper.Surface[] Build(ref global::ExplosionHelper.Point.Enumerator point_enumerator)
			{
				global::ExplosionHelper.Point.EnumeratorToArray enumeratorToArray;
				enumeratorToArray.enumerator = point_enumerator;
				enumeratorToArray.length = 0;
				enumeratorToArray.array = null;
				enumeratorToArray.RecurseInStackHeapToArray();
				return enumeratorToArray.array;
			}

			// Token: 0x04001B64 RID: 7012
			private global::ExplosionHelper.Point.Enumerator enumerator;

			// Token: 0x04001B65 RID: 7013
			private global::ExplosionHelper.Surface[] array;

			// Token: 0x04001B66 RID: 7014
			private int length;
		}
	}

	// Token: 0x020005FC RID: 1532
	private static class Unique
	{
		// Token: 0x0600313B RID: 12603 RVA: 0x000BC6C8 File Offset: 0x000BA8C8
		// Note: this type is marked as 'beforefieldinit'.
		static Unique()
		{
		}

		// Token: 0x0600313C RID: 12604 RVA: 0x000BC6D4 File Offset: 0x000BA8D4
		public static bool Filter(global::ExplosionHelper.Surface[] array, ref int length)
		{
			int num = array.Length;
			try
			{
				for (int i = 0; i < num; i++)
				{
					global::IDMain idMain = array[i].idMain;
					if (idMain && !global::ExplosionHelper.Unique.Set.Add(idMain))
					{
						int num2 = i;
						while (++i < num)
						{
							idMain = array[i].idMain;
							if (!array[i].idMain || global::ExplosionHelper.Unique.Set.Add(idMain))
							{
								array[num2++] = array[i];
							}
						}
						length = num2;
						return true;
					}
				}
			}
			finally
			{
				global::ExplosionHelper.Unique.Set.Clear();
			}
			return false;
		}

		// Token: 0x04001B67 RID: 7015
		private static readonly global::System.Collections.Generic.HashSet<global::IDMain> Set = new global::System.Collections.Generic.HashSet<global::IDMain>();
	}
}
