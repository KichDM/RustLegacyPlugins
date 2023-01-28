using System;
using System.Collections.Generic;

// Token: 0x02000139 RID: 313
public class CharacterPrefab : global::NetMainPrefab
{
	// Token: 0x060007C1 RID: 1985 RVA: 0x000213DC File Offset: 0x0001F5DC
	public CharacterPrefab() : this(typeof(global::Character), false, null, false)
	{
	}

	// Token: 0x060007C2 RID: 1986 RVA: 0x000213F4 File Offset: 0x0001F5F4
	protected CharacterPrefab(global::System.Type characterType) : this(characterType, true, null, false)
	{
	}

	// Token: 0x060007C3 RID: 1987 RVA: 0x00021400 File Offset: 0x0001F600
	protected CharacterPrefab(global::System.Type characterType, params global::System.Type[] requiredIDLocalComponents) : this(characterType, true, requiredIDLocalComponents, requiredIDLocalComponents != null && requiredIDLocalComponents.Length > 0)
	{
	}

	// Token: 0x060007C4 RID: 1988 RVA: 0x0002141C File Offset: 0x0001F61C
	private CharacterPrefab(global::System.Type characterType, bool typeCheck, global::System.Type[] requiredIDLocalComponents, bool anyRequiredIDLocalComponents) : base(characterType)
	{
		if (typeCheck && !typeof(global::Character).IsAssignableFrom(characterType))
		{
			throw new global::System.ArgumentOutOfRangeException("type", "type must be assignable to Character");
		}
	}

	// Token: 0x060007C5 RID: 1989 RVA: 0x0002145C File Offset: 0x0001F65C
	protected static global::System.Type[] TypeArrayAppend(global::System.Type[] mustInclude, global::System.Type[] given)
	{
		if (mustInclude == null || mustInclude.Length == 0)
		{
			return given;
		}
		if (given == null || given.Length == 0)
		{
			return mustInclude;
		}
		global::System.Collections.Generic.List<global::System.Type> list = new global::System.Collections.Generic.List<global::System.Type>(given);
		for (int i = 0; i < mustInclude.Length; i++)
		{
			bool flag = false;
			for (int j = 0; j < given.Length; j++)
			{
				if (mustInclude[i].IsAssignableFrom(given[j]))
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				list.Add(mustInclude[i]);
			}
		}
		return list.ToArray();
	}
}
