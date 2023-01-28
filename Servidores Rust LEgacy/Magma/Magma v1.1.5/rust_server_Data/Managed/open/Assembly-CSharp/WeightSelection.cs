using System;
using UnityEngine;

// Token: 0x02000617 RID: 1559
public class WeightSelection
{
	// Token: 0x060031A0 RID: 12704 RVA: 0x000BE980 File Offset: 0x000BCB80
	public WeightSelection()
	{
	}

	// Token: 0x060031A1 RID: 12705 RVA: 0x000BE988 File Offset: 0x000BCB88
	public static object RandomPick(global::WeightSelection.WeightedEntry[] array)
	{
		return global::WeightSelection.RandomPickEntry(array).obj;
	}

	// Token: 0x060031A2 RID: 12706 RVA: 0x000BE998 File Offset: 0x000BCB98
	public static global::WeightSelection.WeightedEntry RandomPickEntry(global::WeightSelection.WeightedEntry[] array)
	{
		float num = 0f;
		foreach (global::WeightSelection.WeightedEntry weightedEntry in array)
		{
			num += weightedEntry.weight;
		}
		if (num == 0f)
		{
			return null;
		}
		float num2 = global::UnityEngine.Random.Range(0f, num);
		foreach (global::WeightSelection.WeightedEntry weightedEntry2 in array)
		{
			if ((num2 -= weightedEntry2.weight) <= 0f)
			{
				return weightedEntry2;
			}
		}
		return array[array.Length - 1];
	}

	// Token: 0x060031A3 RID: 12707 RVA: 0x000BEA2C File Offset: 0x000BCC2C
	public static T RandomPick<T>(global::WeightSelection.WeightedEntry<T>[] array)
	{
		return global::WeightSelection.RandomPickEntry<T>(array).obj;
	}

	// Token: 0x060031A4 RID: 12708 RVA: 0x000BEA3C File Offset: 0x000BCC3C
	public static global::WeightSelection.WeightedEntry<T> RandomPickEntry<T>(global::WeightSelection.WeightedEntry<T>[] array)
	{
		float num = 0f;
		foreach (global::WeightSelection.WeightedEntry<T> weightedEntry in array)
		{
			num += weightedEntry.weight;
		}
		if (num == 0f)
		{
			return null;
		}
		float num2 = global::UnityEngine.Random.Range(0f, num);
		foreach (global::WeightSelection.WeightedEntry<T> weightedEntry2 in array)
		{
			if ((num2 -= weightedEntry2.weight) <= 0f)
			{
				return weightedEntry2;
			}
		}
		return array[array.Length - 1];
	}

	// Token: 0x02000618 RID: 1560
	[global::System.Serializable]
	public class WeightedEntry
	{
		// Token: 0x060031A5 RID: 12709 RVA: 0x000BEAD0 File Offset: 0x000BCCD0
		public WeightedEntry()
		{
		}

		// Token: 0x04001BC5 RID: 7109
		public float weight;

		// Token: 0x04001BC6 RID: 7110
		public global::UnityEngine.Object obj;
	}

	// Token: 0x02000619 RID: 1561
	[global::System.Serializable]
	public class WeightedEntry<T>
	{
		// Token: 0x060031A6 RID: 12710 RVA: 0x000BEAD8 File Offset: 0x000BCCD8
		public WeightedEntry()
		{
		}

		// Token: 0x04001BC7 RID: 7111
		public float weight;

		// Token: 0x04001BC8 RID: 7112
		public T obj;
	}
}
