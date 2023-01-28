using System;
using UnityEngine;

// Token: 0x02000129 RID: 297
public class CharacterAnimationTrait : global::CharacterTrait
{
	// Token: 0x06000751 RID: 1873 RVA: 0x00020310 File Offset: 0x0001E510
	public CharacterAnimationTrait()
	{
	}

	// Token: 0x17000169 RID: 361
	// (get) Token: 0x06000752 RID: 1874 RVA: 0x00020324 File Offset: 0x0001E524
	public global::MovementAnimationSetup movementAnimationSetup
	{
		get
		{
			return this._movementAnimationSetup;
		}
	}

	// Token: 0x1700016A RID: 362
	// (get) Token: 0x06000753 RID: 1875 RVA: 0x0002032C File Offset: 0x0001E52C
	public string defaultGroupName
	{
		get
		{
			return this._defaultGroupName;
		}
	}

	// Token: 0x040005D7 RID: 1495
	[global::UnityEngine.SerializeField]
	private global::MovementAnimationSetup _movementAnimationSetup;

	// Token: 0x040005D8 RID: 1496
	[global::UnityEngine.SerializeField]
	private string _defaultGroupName = "noitem";
}
