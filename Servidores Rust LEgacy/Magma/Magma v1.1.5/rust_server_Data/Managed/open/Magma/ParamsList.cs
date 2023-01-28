using System;
using System.Collections.Generic;

// Token: 0x0200000F RID: 15
public class ParamsList
{
	// Token: 0x06000086 RID: 134 RVA: 0x00003417 File Offset: 0x00001617
	public ParamsList()
	{
		this.objs = new global::System.Collections.Generic.List<object>();
	}

	// Token: 0x06000087 RID: 135 RVA: 0x0000342A File Offset: 0x0000162A
	public void Add(object o)
	{
		this.objs.Add(o);
	}

	// Token: 0x06000088 RID: 136 RVA: 0x00003438 File Offset: 0x00001638
	public void Remove(object o)
	{
		this.objs.Remove(o);
	}

	// Token: 0x06000089 RID: 137 RVA: 0x00003447 File Offset: 0x00001647
	public object Get(int index)
	{
		return this.objs[index];
	}

	// Token: 0x1700002E RID: 46
	// (get) Token: 0x0600008A RID: 138 RVA: 0x00003455 File Offset: 0x00001655
	public int Length
	{
		get
		{
			return this.objs.Count;
		}
	}

	// Token: 0x0600008B RID: 139 RVA: 0x00003462 File Offset: 0x00001662
	public object[] ToArray()
	{
		return this.objs.ToArray();
	}

	// Token: 0x04000023 RID: 35
	private global::System.Collections.Generic.List<object> objs;
}
