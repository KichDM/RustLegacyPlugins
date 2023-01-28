using System;
using Facepunch.Actor;
using UnityEngine;

// Token: 0x02000202 RID: 514
public class RagdollHelper : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06000E39 RID: 3641 RVA: 0x0003678C File Offset: 0x0003498C
	public RagdollHelper()
	{
	}

	// Token: 0x06000E3A RID: 3642 RVA: 0x00036794 File Offset: 0x00034994
	private void Start()
	{
	}

	// Token: 0x06000E3B RID: 3643 RVA: 0x00036798 File Offset: 0x00034998
	private void Update()
	{
	}

	// Token: 0x06000E3C RID: 3644 RVA: 0x0003679C File Offset: 0x0003499C
	private static void _RecursiveLinkTransformsByName(global::UnityEngine.Transform ragdoll, global::UnityEngine.Transform body)
	{
		for (int i = 0; i < ragdoll.childCount; i++)
		{
			global::UnityEngine.Transform childAtIndex = global::FindChildHelper.GetChildAtIndex(ragdoll, i);
			global::UnityEngine.Transform transform = global::FindChildHelper.FindChildByName(childAtIndex.name, body);
			if (transform)
			{
				childAtIndex.position = transform.position;
				childAtIndex.rotation = transform.rotation;
			}
			global::RagdollHelper._RecursiveLinkTransformsByName(childAtIndex, body);
		}
	}

	// Token: 0x06000E3D RID: 3645 RVA: 0x00036800 File Offset: 0x00034A00
	private static void _RecursiveLinkTransformsByName(global::UnityEngine.Transform ragdoll, global::UnityEngine.Transform body, global::UnityEngine.Transform bodyMatchTransform, ref global::UnityEngine.Transform ragdollMatchTransform, ref bool foundMatch)
	{
		ragdollMatchTransform = null;
		for (int i = 0; i < ragdoll.childCount; i++)
		{
			global::UnityEngine.Transform childAtIndex = global::FindChildHelper.GetChildAtIndex(ragdoll, i);
			global::UnityEngine.Transform transform = global::FindChildHelper.FindChildByName(childAtIndex.name, body);
			if (transform)
			{
				childAtIndex.position = transform.position;
				childAtIndex.rotation = transform.rotation;
				if (!foundMatch && transform == bodyMatchTransform)
				{
					foundMatch = true;
					ragdollMatchTransform = childAtIndex;
				}
				if (foundMatch)
				{
					global::RagdollHelper._RecursiveLinkTransformsByName(childAtIndex, transform);
				}
				else
				{
					global::RagdollHelper._RecursiveLinkTransformsByName(childAtIndex, transform, bodyMatchTransform, ref ragdollMatchTransform, ref foundMatch);
				}
			}
		}
	}

	// Token: 0x06000E3E RID: 3646 RVA: 0x0003689C File Offset: 0x00034A9C
	public static void RecursiveLinkTransformsByName(global::UnityEngine.Transform ragdoll, global::UnityEngine.Transform body)
	{
		global::Facepunch.Actor.BoneStructure component = body.GetComponent<global::Facepunch.Actor.BoneStructure>();
		if (component)
		{
			global::Facepunch.Actor.BoneStructure component2 = ragdoll.GetComponent<global::Facepunch.Actor.BoneStructure>();
			if (component2)
			{
				using (global::Facepunch.Actor.BoneStructure.ParentDownOrdered.Enumerator enumerator = component.parentDown.GetEnumerator())
				{
					using (global::Facepunch.Actor.BoneStructure.ParentDownOrdered.Enumerator enumerator2 = component2.parentDown.GetEnumerator())
					{
						while (enumerator.MoveNext() && enumerator2.MoveNext())
						{
							global::UnityEngine.Transform transform = enumerator.Current;
							global::UnityEngine.Transform transform2 = enumerator2.Current;
							transform2.position = transform.position;
							transform2.rotation = transform.rotation;
						}
					}
				}
				return;
			}
		}
		global::RagdollHelper._RecursiveLinkTransformsByName(ragdoll, body);
	}

	// Token: 0x06000E3F RID: 3647 RVA: 0x00036998 File Offset: 0x00034B98
	public static bool RecursiveLinkTransformsByName(global::UnityEngine.Transform ragdoll, global::UnityEngine.Transform body, global::UnityEngine.Transform bodyMatchTransform, out global::UnityEngine.Transform ragdollMatchTransform)
	{
		if (!bodyMatchTransform)
		{
			ragdollMatchTransform = null;
			global::RagdollHelper.RecursiveLinkTransformsByName(ragdoll, body);
			return false;
		}
		if (body == bodyMatchTransform)
		{
			ragdollMatchTransform = ragdoll;
			global::RagdollHelper.RecursiveLinkTransformsByName(ragdoll, body);
			return true;
		}
		global::Facepunch.Actor.BoneStructure component = body.GetComponent<global::Facepunch.Actor.BoneStructure>();
		if (component)
		{
			global::Facepunch.Actor.BoneStructure component2 = ragdoll.GetComponent<global::Facepunch.Actor.BoneStructure>();
			if (component2)
			{
				using (global::Facepunch.Actor.BoneStructure.ParentDownOrdered.Enumerator enumerator = component.parentDown.GetEnumerator())
				{
					using (global::Facepunch.Actor.BoneStructure.ParentDownOrdered.Enumerator enumerator2 = component2.parentDown.GetEnumerator())
					{
						while (enumerator.MoveNext() && enumerator2.MoveNext())
						{
							global::UnityEngine.Transform transform = enumerator.Current;
							global::UnityEngine.Transform transform2 = enumerator2.Current;
							transform2.position = transform.position;
							transform2.rotation = transform.rotation;
							if (transform == bodyMatchTransform)
							{
								ragdollMatchTransform = transform2;
								while (enumerator.MoveNext() && enumerator2.MoveNext())
								{
									transform = enumerator.Current;
									transform2 = enumerator2.Current;
									transform2.position = transform.position;
									transform2.rotation = transform.rotation;
								}
								return true;
							}
						}
					}
				}
				ragdollMatchTransform = null;
				return false;
			}
		}
		bool result = false;
		ragdollMatchTransform = null;
		global::RagdollHelper._RecursiveLinkTransformsByName(ragdoll, body, bodyMatchTransform, ref ragdollMatchTransform, ref result);
		return result;
	}
}
