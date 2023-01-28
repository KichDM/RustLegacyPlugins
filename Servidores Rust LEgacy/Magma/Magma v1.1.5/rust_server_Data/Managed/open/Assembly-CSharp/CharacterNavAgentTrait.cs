using System;
using UnityEngine;

// Token: 0x02000137 RID: 311
public class CharacterNavAgentTrait : global::CharacterTrait
{
	// Token: 0x060007AC RID: 1964 RVA: 0x0002120C File Offset: 0x0001F40C
	public CharacterNavAgentTrait()
	{
	}

	// Token: 0x1700019A RID: 410
	// (get) Token: 0x060007AD RID: 1965 RVA: 0x0002128C File Offset: 0x0001F48C
	public float radius
	{
		get
		{
			return this._radius;
		}
	}

	// Token: 0x1700019B RID: 411
	// (get) Token: 0x060007AE RID: 1966 RVA: 0x00021294 File Offset: 0x0001F494
	public float speed
	{
		get
		{
			return this._speed;
		}
	}

	// Token: 0x1700019C RID: 412
	// (get) Token: 0x060007AF RID: 1967 RVA: 0x0002129C File Offset: 0x0001F49C
	public float acceleration
	{
		get
		{
			return this._acceleration;
		}
	}

	// Token: 0x1700019D RID: 413
	// (get) Token: 0x060007B0 RID: 1968 RVA: 0x000212A4 File Offset: 0x0001F4A4
	public float angularSpeed
	{
		get
		{
			return this._angularSpeed;
		}
	}

	// Token: 0x1700019E RID: 414
	// (get) Token: 0x060007B1 RID: 1969 RVA: 0x000212AC File Offset: 0x0001F4AC
	public float stoppingDistance
	{
		get
		{
			return this._stoppingDistance;
		}
	}

	// Token: 0x1700019F RID: 415
	// (get) Token: 0x060007B2 RID: 1970 RVA: 0x000212B4 File Offset: 0x0001F4B4
	public bool autoTraverseOffMeshLink
	{
		get
		{
			return this._autoTraverseOffMeshLink;
		}
	}

	// Token: 0x170001A0 RID: 416
	// (get) Token: 0x060007B3 RID: 1971 RVA: 0x000212BC File Offset: 0x0001F4BC
	public bool autoBraking
	{
		get
		{
			return this._autoBraking;
		}
	}

	// Token: 0x170001A1 RID: 417
	// (get) Token: 0x060007B4 RID: 1972 RVA: 0x000212C4 File Offset: 0x0001F4C4
	public bool autoRepath
	{
		get
		{
			return this._autoRepath;
		}
	}

	// Token: 0x170001A2 RID: 418
	// (get) Token: 0x060007B5 RID: 1973 RVA: 0x000212CC File Offset: 0x0001F4CC
	public float height
	{
		get
		{
			return this._height;
		}
	}

	// Token: 0x170001A3 RID: 419
	// (get) Token: 0x060007B6 RID: 1974 RVA: 0x000212D4 File Offset: 0x0001F4D4
	public float baseOffset
	{
		get
		{
			return this._baseOffset;
		}
	}

	// Token: 0x170001A4 RID: 420
	// (get) Token: 0x060007B7 RID: 1975 RVA: 0x000212DC File Offset: 0x0001F4DC
	public global::UnityEngine.ObstacleAvoidanceType obstacleAvoidanceType
	{
		get
		{
			return this._obstacleAvoidanceType;
		}
	}

	// Token: 0x170001A5 RID: 421
	// (get) Token: 0x060007B8 RID: 1976 RVA: 0x000212E4 File Offset: 0x0001F4E4
	public int avoidancePriority
	{
		get
		{
			return this._avoidancePriority;
		}
	}

	// Token: 0x170001A6 RID: 422
	// (get) Token: 0x060007B9 RID: 1977 RVA: 0x000212EC File Offset: 0x0001F4EC
	public int walkableMaks
	{
		get
		{
			return this._walkableMask;
		}
	}

	// Token: 0x060007BA RID: 1978 RVA: 0x000212F4 File Offset: 0x0001F4F4
	public void CopyTo(global::UnityEngine.NavMeshAgent agent)
	{
		agent.radius = this._radius;
		agent.speed = this._speed;
		agent.acceleration = this._acceleration;
		agent.angularSpeed = this._angularSpeed;
		agent.stoppingDistance = this._stoppingDistance;
		agent.autoTraverseOffMeshLink = this._autoTraverseOffMeshLink;
		agent.autoBraking = this._autoBraking;
		agent.autoRepath = this._autoRepath;
		agent.height = this._height;
		agent.baseOffset = this._baseOffset;
		agent.obstacleAvoidanceType = this._obstacleAvoidanceType;
		agent.avoidancePriority = this._avoidancePriority;
		agent.walkableMask = this._walkableMask;
	}

	// Token: 0x0400060B RID: 1547
	[global::UnityEngine.SerializeField]
	private float _radius = 0.5f;

	// Token: 0x0400060C RID: 1548
	[global::UnityEngine.SerializeField]
	private float _speed = 3f;

	// Token: 0x0400060D RID: 1549
	[global::UnityEngine.SerializeField]
	private float _acceleration = 8f;

	// Token: 0x0400060E RID: 1550
	[global::UnityEngine.SerializeField]
	private float _angularSpeed = 120f;

	// Token: 0x0400060F RID: 1551
	[global::UnityEngine.SerializeField]
	private float _stoppingDistance = 2f;

	// Token: 0x04000610 RID: 1552
	[global::UnityEngine.SerializeField]
	private bool _autoTraverseOffMeshLink = true;

	// Token: 0x04000611 RID: 1553
	[global::UnityEngine.SerializeField]
	private bool _autoBraking = true;

	// Token: 0x04000612 RID: 1554
	[global::UnityEngine.SerializeField]
	private bool _autoRepath = true;

	// Token: 0x04000613 RID: 1555
	[global::UnityEngine.SerializeField]
	private float _height = 2f;

	// Token: 0x04000614 RID: 1556
	[global::UnityEngine.SerializeField]
	private float _baseOffset;

	// Token: 0x04000615 RID: 1557
	[global::UnityEngine.SerializeField]
	private global::UnityEngine.ObstacleAvoidanceType _obstacleAvoidanceType = 1;

	// Token: 0x04000616 RID: 1558
	[global::UnityEngine.SerializeField]
	private int _avoidancePriority = 0x32;

	// Token: 0x04000617 RID: 1559
	[global::UnityEngine.SerializeField]
	private int _walkableMask = -1;
}
