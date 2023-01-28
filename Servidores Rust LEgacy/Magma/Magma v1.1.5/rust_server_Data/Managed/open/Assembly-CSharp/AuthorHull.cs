using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using Facepunch.Actor;
using UnityEngine;

// Token: 0x02000037 RID: 55
[global::AuthorSuiteCreation(Title = "Author Hull", Description = "Create a new character. Allows you to define hitboxes and fine tune ragdoll and joints.", Scripter = "Pat", OutputType = typeof(global::Character), Ready = true)]
public class AuthorHull : global::AuthorCreation
{
	// Token: 0x060001F5 RID: 501 RVA: 0x00009348 File Offset: 0x00007548
	public AuthorHull() : this(typeof(global::Character))
	{
	}

	// Token: 0x060001F6 RID: 502 RVA: 0x0000935C File Offset: 0x0000755C
	protected AuthorHull(global::System.Type type) : base(type)
	{
	}

	// Token: 0x060001F7 RID: 503 RVA: 0x000093E4 File Offset: 0x000075E4
	// Note: this type is marked as 'beforefieldinit'.
	static AuthorHull()
	{
	}

	// Token: 0x060001F8 RID: 504 RVA: 0x000093F8 File Offset: 0x000075F8
	public global::HitBox CreateHitBox(global::UnityEngine.GameObject target)
	{
		global::HitBox hitBox = global::AuthorShared.AddComponent<global::HitBox>(target, this.hitBoxType);
		global::AuthorShared.SetSerializedProperty(hitBox, "_hitBoxSystem", this.creatingSystem);
		hitBox.idMain = hitBox.hitBoxSystem.idMain;
		return hitBox;
	}

	// Token: 0x060001F9 RID: 505 RVA: 0x00009438 File Offset: 0x00007638
	public global::HitBoxSystem CreateHitBoxSystem(global::UnityEngine.GameObject target)
	{
		return global::AuthorShared.AddComponent<global::HitBoxSystem>(target, this.hitBoxSystemType);
	}

	// Token: 0x060001FA RID: 506 RVA: 0x00009448 File Offset: 0x00007648
	private global::UnityEngine.Transform GetHitColliderParent(global::UnityEngine.GameObject root)
	{
		global::UnityEngine.SkinnedMeshRenderer skinnedMeshRenderer;
		global::UnityEngine.Transform rootBone = global::AuthorShared.GetRootBone(root, out skinnedMeshRenderer);
		return (!skinnedMeshRenderer || !skinnedMeshRenderer.transform.parent) ? rootBone : skinnedMeshRenderer.transform.parent;
	}

	// Token: 0x060001FB RID: 507 RVA: 0x00009490 File Offset: 0x00007690
	public override global::System.Collections.Generic.IEnumerable<global::AuthorPeice> DoSceneView()
	{
		if (this.drawBones && this.modelPrefabInstance != null)
		{
			global::UnityEngine.Transform rootBone = global::AuthorShared.GetRootBone(this.modelPrefabInstance);
			if (rootBone)
			{
				global::UnityEngine.Color color = global::AuthorShared.Scene.color;
				global::UnityEngine.Color color2 = color * new global::UnityEngine.Color(0.9f, 0.8f, 0.3f, 0.1f);
				global::System.Collections.Generic.List<global::UnityEngine.Transform> list = rootBone.ListDecendantsByDepth();
				global::AuthorShared.Scene.color = color2;
				foreach (global::UnityEngine.Transform transform in list)
				{
					global::UnityEngine.Vector3 position = transform.parent.position;
					global::UnityEngine.Vector3 position2 = transform.position;
					global::UnityEngine.Vector3 vector = position2 - position;
					float magnitude = vector.magnitude;
					if (magnitude != 0f)
					{
						global::UnityEngine.Vector3 up = transform.up;
						global::UnityEngine.Quaternion rot = global::UnityEngine.Quaternion.LookRotation(vector, up);
						global::AuthorShared.Scene.DrawBone(position, rot, magnitude, global::UnityEngine.Mathf.Min(magnitude / 2f, 0.025f), global::UnityEngine.Vector3.one * global::UnityEngine.Mathf.Min(magnitude, 0.05f));
					}
				}
				global::AuthorShared.Scene.color = color;
			}
		}
		return base.DoSceneView();
	}

	// Token: 0x060001FC RID: 508 RVA: 0x000095E4 File Offset: 0x000077E4
	private void ApplyMaterials(global::UnityEngine.GameObject instance)
	{
		global::UnityEngine.SkinnedMeshRenderer skinnedMeshRenderer = (!(instance == null)) ? instance.GetComponentInChildren<global::UnityEngine.SkinnedMeshRenderer>() : null;
		if (skinnedMeshRenderer)
		{
			skinnedMeshRenderer.sharedMaterials = this.materials;
		}
	}

	// Token: 0x060001FD RID: 509 RVA: 0x00009624 File Offset: 0x00007824
	private void DestroyRepresentations(ref global::UnityEngine.GameObject stored, string suffix)
	{
		if (stored)
		{
			global::UnityEngine.Object.DestroyImmediate(stored);
		}
		foreach (global::UnityEngine.Object @object in global::UnityEngine.Object.FindObjectsOfType(typeof(global::UnityEngine.GameObject)))
		{
			if (@object && ((global::UnityEngine.GameObject)@object).transform.parent == null && @object.name.EndsWith(suffix))
			{
				global::UnityEngine.Object.DestroyImmediate(@object);
			}
		}
	}

	// Token: 0x060001FE RID: 510 RVA: 0x000096AC File Offset: 0x000078AC
	protected override bool OnGUICreationSettings()
	{
		bool flag = base.OnGUICreationSettings();
		bool flag2 = this.modelPrefab;
		global::UnityEngine.GameObject gameObject = (global::UnityEngine.GameObject)global::AuthorShared.ObjectField("Model Prefab", this.modelPrefab, typeof(global::UnityEngine.GameObject), true, new global::UnityEngine.GUILayoutOption[0]);
		if (gameObject != this.modelPrefab)
		{
			if (!gameObject)
			{
				gameObject = this.modelPrefab;
			}
			else if (global::AuthorShared.GetObjectKind(gameObject) != global::AuthorShared.ObjectKind.Model)
			{
				gameObject = this.modelPrefab;
			}
			else
			{
				gameObject = global::AuthorShared.FindPrefabRoot(gameObject);
			}
		}
		if (gameObject != this.modelPrefab)
		{
			this.modelPrefab = gameObject;
			this.ChangedModelPrefab();
			this.ChangedEditingOptions();
			flag |= true;
		}
		bool enabled = global::UnityEngine.GUI.enabled;
		if (!flag2)
		{
			global::UnityEngine.GUI.enabled = false;
		}
		bool flag3 = this.modelPrefabForHitBox;
		global::UnityEngine.GameObject gameObject2 = (global::UnityEngine.GameObject)global::AuthorShared.ObjectField("Override Model Prefab [HitBox]", (!flag3) ? this.modelPrefab : this.modelPrefabForHitBox, typeof(global::UnityEngine.GameObject), true, new global::UnityEngine.GUILayoutOption[0]);
		global::UnityEngine.GUI.enabled = enabled;
		if (!gameObject2 || gameObject2 == this.modelPrefab)
		{
			if (flag2)
			{
				global::UnityEngine.GUILayout.Label(global::AuthorHull.guis.notOverridingContent, global::AuthorShared.Styles.miniLabel, new global::UnityEngine.GUILayoutOption[0]);
			}
			gameObject2 = null;
		}
		else
		{
			global::UnityEngine.GUILayout.Label(global::AuthorHull.guis.overridingContent, global::AuthorShared.Styles.miniLabel, new global::UnityEngine.GUILayoutOption[0]);
			bool flag4 = global::AuthorShared.Toggle("Use Meshes from Override in Ragdoll output", this.useMeshesFromHitBoxOnRagdoll, new global::UnityEngine.GUILayoutOption[0]);
			if (flag4 != this.useMeshesFromHitBoxOnRagdoll)
			{
				this.useMeshesFromHitBoxOnRagdoll = flag4;
				flag = true;
			}
		}
		if (gameObject2 != this.modelPrefabForHitBox)
		{
			if (!gameObject2)
			{
				gameObject2 = this.modelPrefabForHitBox;
			}
			else if (global::AuthorShared.GetObjectKind(gameObject2) != global::AuthorShared.ObjectKind.Model)
			{
				gameObject2 = this.modelPrefabForHitBox;
			}
			else
			{
				gameObject2 = global::AuthorShared.FindPrefabRoot(gameObject2);
			}
		}
		if (gameObject2 != this.modelPrefabForHitBox)
		{
			this.modelPrefabForHitBox = gameObject2;
			flag |= true;
		}
		global::Facepunch.Actor.ActorRig actorRig = (global::Facepunch.Actor.ActorRig)global::AuthorShared.ObjectField("Actor Rig", this.actorRig, typeof(global::Facepunch.Actor.ActorRig), global::AuthorShared.ObjectFieldFlags.Asset, new global::UnityEngine.GUILayoutOption[0]);
		if (actorRig != this.actorRig && !actorRig)
		{
			actorRig = this.actorRig;
		}
		if (actorRig != this.actorRig)
		{
			this.actorRig = actorRig;
			flag |= true;
		}
		global::Character character = (global::Character)global::AuthorShared.ObjectField("Prototype Prefab", this.prototype, typeof(global::IDMain), global::AuthorShared.ObjectFieldFlags.Prefab, new global::UnityEngine.GUILayoutOption[0]);
		if (character != this.prototype && character && global::AuthorShared.GetObjectKind(character.gameObject) != global::AuthorShared.ObjectKind.Prefab)
		{
			character = this.prototype;
		}
		if (character != this.prototype)
		{
			this.prototype = character;
			flag |= true;
		}
		global::Ragdoll ragdoll = (global::Ragdoll)global::AuthorShared.ObjectField("Prototype Ragdoll", this.ragdollPrototype, typeof(global::IDMain), global::AuthorShared.ObjectFieldFlags.Prefab, new global::UnityEngine.GUILayoutOption[0]);
		if (ragdoll != this.ragdollPrototype && ragdoll && global::AuthorShared.GetObjectKind(ragdoll.gameObject) != global::AuthorShared.ObjectKind.Prefab)
		{
			ragdoll = this.ragdollPrototype;
		}
		if (ragdoll != this.ragdollPrototype)
		{
			this.ragdollPrototype = ragdoll;
			flag |= true;
		}
		if (this.modelPrefabInstance)
		{
			bool activeSelf = this.modelPrefabInstance.activeSelf;
			global::AuthorShared.BeginHorizontal(new global::UnityEngine.GUILayoutOption[0]);
			if (global::AuthorShared.Toggle("Show Model Prefab", ref activeSelf, global::AuthorShared.Styles.miniButton, new global::UnityEngine.GUILayoutOption[0]))
			{
				this.modelPrefabInstance.SetActive(activeSelf);
			}
			flag |= global::AuthorShared.Toggle("Render Bones", ref this.drawBones, global::AuthorShared.Styles.miniButton, new global::UnityEngine.GUILayoutOption[0]);
			global::AuthorShared.EndHorizontal();
		}
		global::AuthorShared.BeginSubSection("Rendering", new global::UnityEngine.GUILayoutOption[0]);
		if (global::AuthorShared.ArrayField<global::UnityEngine.Material>("Materials", ref this.materials, delegate(ref global::UnityEngine.Material material)
		{
			return global::AuthorShared.ObjectField<global::UnityEngine.Material>(default(global::AuthorShared.Content), ref material, typeof(global::UnityEngine.Material), (global::AuthorShared.ObjectFieldFlags)0, new global::UnityEngine.GUILayoutOption[0]);
		}))
		{
			flag = true;
			this.ApplyMaterials(this.modelPrefabInstance);
		}
		global::AuthorShared.EndSubSection();
		global::AuthorShared.BeginSubSection("Types", "AddComponent strings", new global::UnityEngine.GUILayoutOption[0]);
		string a = global::AuthorShared.StringField("HitBox Type", this.hitBoxType, new global::UnityEngine.GUILayoutOption[0]);
		string a2 = global::AuthorShared.StringField("HitBoxSystem Type", this.hitBoxSystemType, new global::UnityEngine.GUILayoutOption[0]);
		global::AuthorShared.EndSubSection();
		global::AuthorShared.BeginSubSection("Hit Capsule", "Should be large enough to fit all boxes at any time", new global::UnityEngine.GUILayoutOption[0]);
		global::UnityEngine.Vector3 vector = global::AuthorShared.Vector3Field("Center", this.hitCapsuleCenter, new global::UnityEngine.GUILayoutOption[0]);
		float num = global::AuthorShared.FloatField("Radius", this.hitCapsuleRadius, new global::UnityEngine.GUILayoutOption[0]);
		float num2 = global::AuthorShared.FloatField("Height", this.hitCapsuleHeight, new global::UnityEngine.GUILayoutOption[0]);
		int num3 = global::AuthorShared.IntField("Axis", this.hitCapsuleDirection, new global::UnityEngine.GUILayoutOption[0]);
		float num4 = global::AuthorShared.FloatField("Eye Height", this.eyeHeight, new global::UnityEngine.GUILayoutOption[0]);
		global::AuthorShared.EndSubSection();
		global::AuthorShared.BeginSubSection("Rigidbody", new global::UnityEngine.GUILayoutOption[0]);
		flag |= global::AuthorShared.IntField("Ignore n. parent col.", ref this.ignoreCollisionUpSteps, new global::UnityEngine.GUILayoutOption[0]);
		flag |= global::AuthorShared.IntField("Ignore n. child col.", ref this.ignoreCollisionDownSteps, new global::UnityEngine.GUILayoutOption[0]);
		global::AuthorShared.EndSubSection();
		global::AuthorShared.BeginSubSection("Body Parts", new global::UnityEngine.GUILayoutOption[0]);
		string a3 = global::AuthorShared.StringField("Default Hit Box Layer", this.defaultBodyPartLayer ?? string.Empty, new global::UnityEngine.GUILayoutOption[0]);
		if (string.IsNullOrEmpty(this.defaultBodyPartLayer))
		{
			global::AuthorShared.Label("[the layer in the models will be used]", new global::UnityEngine.GUILayoutOption[0]);
		}
		if (a3 != (this.defaultBodyPartLayer ?? string.Empty))
		{
			this.defaultBodyPartLayer = a3;
			flag = true;
		}
		bool flag5 = this.bodyParts.Count == 0 || global::AuthorShared.Toggle("Show Unassigned Parts", this.showAllBones, new global::UnityEngine.GUILayoutOption[0]);
		for (global::BodyPart bodyPart = 0; bodyPart < 0x78; bodyPart++)
		{
			global::UnityEngine.Transform transform;
			if ((this.bodyParts.TryGetValue(bodyPart, ref transform) || this.showAllBones) && global::AuthorShared.ObjectField<global::UnityEngine.Transform>(bodyPart.ToString(), ref transform, (global::AuthorShared.ObjectFieldFlags)0x11, new global::UnityEngine.GUILayoutOption[0]))
			{
				if (transform)
				{
					global::BodyPart? bodyPart2 = this.bodyParts.BodyPartOf(transform);
					if (bodyPart2 != null)
					{
						bool? flag6 = global::AuthorShared.Ask(string.Concat(new object[]
						{
							"That transform was assigned do something else.\r\nChange it from ",
							bodyPart2.Value,
							" to ",
							bodyPart,
							"?"
						}));
						bool? flag7 = (flag6 == null) ? null : new bool?(!flag6.Value);
						if (flag7 != null && flag7.Value)
						{
							goto IL_7C3;
						}
						this.bodyParts.Remove(bodyPart2.Value);
					}
					this.bodyParts[bodyPart] = transform;
				}
				else
				{
					this.bodyParts.Remove(bodyPart);
				}
				flag = true;
			}
			IL_7C3:;
		}
		this.showAllBones = flag5;
		global::AuthorShared.BeginSubSection("Destroy Children", new global::UnityEngine.GUILayoutOption[0]);
		global::AuthorShared.BeginSubSection(global::AuthorHull.guis.destroyDrop, "Remove these from generation", global::AuthorShared.Styles.miniLabel, new global::UnityEngine.GUILayoutOption[0]);
		global::UnityEngine.Transform transform2 = (global::UnityEngine.Transform)global::AuthorShared.ObjectField(null, typeof(global::UnityEngine.Transform), (global::AuthorShared.ObjectFieldFlags)0x19, new global::UnityEngine.GUILayoutOption[0]);
		global::AuthorShared.EndSubSection();
		if (transform2 && (!this.modelPrefabInstance || !transform2.IsChildOf(this.modelPrefabInstance.transform)))
		{
			global::UnityEngine.Debug.Log("Thats not a valid selection", transform2);
			transform2 = null;
		}
		bool flag8 = false;
		if (this.removeThese != null && this.removeThese.Length > 0)
		{
			global::AuthorShared.BeginSubSection("These will be removed with generation", new global::UnityEngine.GUILayoutOption[0]);
			for (int i = 0; i < this.removeThese.Length; i++)
			{
				global::AuthorShared.BeginHorizontal(global::AuthorShared.Styles.gradientOutline, new global::UnityEngine.GUILayoutOption[0]);
				if (global::AuthorShared.Button(global::AuthorShared.ObjectContent<global::UnityEngine.Transform>(this.removeThese[i], typeof(global::UnityEngine.Transform)), global::AuthorShared.Styles.peiceButtonLeft, new global::UnityEngine.GUILayoutOption[0]) && this.removeThese[i])
				{
					global::AuthorShared.PingObject(this.removeThese[i]);
				}
				if (global::AuthorShared.Button(global::AuthorShared.Icon.delete, global::AuthorShared.Styles.peiceButtonRight, new global::UnityEngine.GUILayoutOption[0]))
				{
					this.removeThese[i] = null;
					flag8 = true;
				}
				global::AuthorShared.EndHorizontal();
			}
			global::AuthorShared.EndSubSection();
		}
		global::AuthorShared.EndSubSection();
		global::AuthorShared.EndSubSection();
		global::AuthorShared.BeginSubSection("Output", "this is where stuff will be saved", new global::UnityEngine.GUILayoutOption[0]);
		global::UnityEngine.Object @object = global::AuthorShared.ObjectField("OUTPUT HITBOX", this.hitBoxOutputPrefab, typeof(global::UnityEngine.GameObject), (global::AuthorShared.ObjectFieldFlags)0xC4, new global::UnityEngine.GUILayoutOption[0]);
		global::UnityEngine.Object object2 = global::AuthorShared.ObjectField("OUTPUT RAGDOLL", this.ragdollOutputPrefab, typeof(global::UnityEngine.GameObject), (global::AuthorShared.ObjectFieldFlags)0xC4, new global::UnityEngine.GUILayoutOption[0]);
		global::AuthorShared.EndSubSection();
		global::AuthorShared.BeginSubSection("Authoring Helpers", "These do not output to the mesh, just are here to help you author", new global::UnityEngine.GUILayoutOption[0]);
		global::UnityEngine.Vector3 vector2 = global::AuthorShared.Vector3Field("Angles Offset", this.editingAngles, new global::UnityEngine.GUILayoutOption[0]);
		bool flag9 = global::AuthorShared.Toggle("Origin To Root", this.editingCenterToRoot, new global::UnityEngine.GUILayoutOption[0]);
		global::AuthorShared.EndSubSection();
		global::AuthorShared.BeginHorizontal(global::AuthorShared.Styles.box, new global::UnityEngine.GUILayoutOption[0]);
		bool enabled2 = global::UnityEngine.GUI.enabled;
		if (!gameObject)
		{
			global::UnityEngine.GUI.enabled = false;
		}
		if (global::AuthorShared.Button("Generate", global::AuthorShared.Styles.miniButtonLeft, new global::UnityEngine.GUILayoutOption[0]))
		{
			this.GeneratePrefabInstances();
			this.savedGenerated = false;
			global::AuthorShared.SetDirty(this);
			flag = true;
		}
		global::UnityEngine.GUI.enabled = (!this.savedGenerated && this.generatedRigid && this.generatedHitBox && this.hitBoxOutputPrefab && this.ragdollOutputPrefab && this.ragdollOutputPrefab != this.hitBoxOutputPrefab);
		if (global::AuthorShared.Button("Update Prefabs", global::AuthorShared.Styles.miniButtonRight, new global::UnityEngine.GUILayoutOption[0]) && global::AuthorShared.Ask("This will overwrite any changes made to the output prefab that may have been done externally\r\nStill go ahead?") == true)
		{
			this.UpdatePrefabs();
			this.savedGenerated = true;
			flag = true;
		}
		global::UnityEngine.GUI.enabled = enabled2;
		global::AuthorShared.EndHorizontal();
		if (global::AuthorShared.Button("Save To JSON", new global::UnityEngine.GUILayoutOption[0]))
		{
			base.SaveSettings();
		}
		if (this.prototype && global::AuthorShared.Button("Write JSON Serialized Properties from Prototype", new global::UnityEngine.GUILayoutOption[0]))
		{
			this.PreviewPrototype();
		}
		if (a != this.hitBoxType || a2 != this.hitBoxSystemType)
		{
			this.hitBoxType = a;
			this.hitBoxSystemType = a2;
			flag = true;
		}
		else if (vector != this.hitCapsuleCenter || num != this.hitCapsuleRadius || num2 != this.hitCapsuleHeight || num3 != this.hitCapsuleDirection || num4 != this.eyeHeight)
		{
			this.hitCapsuleCenter = vector;
			this.hitCapsuleRadius = num;
			this.hitCapsuleHeight = num2;
			this.hitCapsuleDirection = num3;
			this.eyeHeight = num4;
			flag = true;
		}
		else if (vector2 != this.editingAngles || this.editingCenterToRoot != flag9)
		{
			this.editingAngles = vector2;
			this.editingCenterToRoot = flag9;
			flag = true;
			this.ChangedEditingOptions();
		}
		else if (@object != this.hitBoxOutputPrefab)
		{
			if (this.EnsureItsAPrefab(ref @object) && @object != this.hitBoxOutputPrefab)
			{
				this.hitBoxOutputPrefab = (global::UnityEngine.GameObject)@object;
				flag = true;
			}
		}
		else if (object2 != this.ragdollOutputPrefab)
		{
			if (this.EnsureItsAPrefab(ref object2) && object2 != this.ragdollOutputPrefab)
			{
				this.ragdollOutputPrefab = (global::UnityEngine.GameObject)object2;
				flag = true;
			}
		}
		else if (transform2)
		{
			global::System.Array.Resize<global::UnityEngine.Transform>(ref this.removeThese, (this.removeThese != null) ? (this.removeThese.Length + 1) : 1);
			this.removeThese[this.removeThese.Length - 1] = transform2;
			flag8 = true;
		}
		if (flag8)
		{
			int newSize = 0;
			for (int j = 0; j < this.removeThese.Length; j++)
			{
				if (this.removeThese[j])
				{
					this.removeThese[newSize++] = this.removeThese[j];
				}
			}
			global::System.Array.Resize<global::UnityEngine.Transform>(ref this.removeThese, newSize);
			flag = true;
		}
		return flag;
	}

	// Token: 0x060001FF RID: 511 RVA: 0x0000A490 File Offset: 0x00008690
	internal void FigureOutDefaultBodyPart(ref global::UnityEngine.Transform bone, ref global::BodyPart bodyPart, ref global::UnityEngine.Transform mirrored, ref global::BodyPart mirroredBodyPart)
	{
		global::BodyPart bodyPart2 = bodyPart;
		for (global::BodyPart bodyPart3 = 0; bodyPart3 < 0x78; bodyPart3++)
		{
			global::UnityEngine.Transform transform;
			if (this.bodyParts.TryGetValue(bodyPart3, ref transform) && transform == bone)
			{
				bodyPart2 = bodyPart3;
			}
		}
		if (bodyPart2 != bodyPart)
		{
			bodyPart = bodyPart2;
			if (!mirrored && global::BodyParts.IsSided(bodyPart))
			{
				bodyPart2 = global::BodyParts.SwapSide(bodyPart2);
				if (this.bodyParts.TryGetValue(bodyPart2, ref mirrored))
				{
					mirroredBodyPart = bodyPart2;
				}
			}
		}
	}

	// Token: 0x06000200 RID: 512 RVA: 0x0000A518 File Offset: 0x00008718
	private void ChangedEditingOptions()
	{
		if (this.modelPrefabInstance)
		{
			this.modelPrefabInstance.transform.localEulerAngles = this.editingAngles;
			this.modelPrefabInstance.transform.localPosition = global::UnityEngine.Vector3.zero;
			if (this.editingCenterToRoot)
			{
				global::UnityEngine.Transform rootBone = global::AuthorShared.GetRootBone(this.modelPrefabInstance.GetComponentInChildren<global::UnityEngine.SkinnedMeshRenderer>());
				if (rootBone)
				{
					this.modelPrefabInstance.transform.position = -rootBone.position;
				}
			}
		}
	}

	// Token: 0x06000201 RID: 513 RVA: 0x0000A5A4 File Offset: 0x000087A4
	private static global::System.Collections.Generic.KeyValuePair<global::UnityEngine.Collider, global::UnityEngine.Collider> MakeKV(global::UnityEngine.Collider a, global::UnityEngine.Collider b)
	{
		if (string.Compare(a.name, b.name) < 0)
		{
			return new global::System.Collections.Generic.KeyValuePair<global::UnityEngine.Collider, global::UnityEngine.Collider>(b, a);
		}
		return new global::System.Collections.Generic.KeyValuePair<global::UnityEngine.Collider, global::UnityEngine.Collider>(a, b);
	}

	// Token: 0x06000202 RID: 514 RVA: 0x0000A5D8 File Offset: 0x000087D8
	private static global::System.Collections.Generic.IEnumerable<global::UnityEngine.Collider> GetCollidersOnRigidbody(global::UnityEngine.Rigidbody rb)
	{
		foreach (global::UnityEngine.Collider collider in rb.GetComponentsInChildren<global::UnityEngine.Collider>())
		{
			if (collider.attachedRigidbody == rb)
			{
				yield return collider;
			}
		}
		yield break;
	}

	// Token: 0x06000203 RID: 515 RVA: 0x0000A604 File Offset: 0x00008804
	private global::UnityEngine.GameObject InstantiatePrefabWithRemovedBones(global::UnityEngine.GameObject prefab)
	{
		global::UnityEngine.GameObject gameObject = global::AuthorShared.InstantiatePrefab(prefab);
		if (this.modelPrefabInstance)
		{
			if (this.removeThese != null)
			{
				for (int i = 0; i < this.removeThese.Length; i++)
				{
					if (this.removeThese[i])
					{
						global::UnityEngine.Transform transform = gameObject.transform.FindChild(global::AuthorShared.CalculatePath(this.removeThese[i], this.modelPrefabInstance.transform));
						if (transform)
						{
							global::UnityEngine.Object.DestroyImmediate(transform);
						}
					}
				}
			}
			if (!this.allowBonesOutsideOfModelPrefab && prefab != this.modelPrefab)
			{
				foreach (global::UnityEngine.Transform transform2 in gameObject.GetComponentsInChildren<global::UnityEngine.Transform>(true))
				{
					if (transform2)
					{
						string text = global::AuthorShared.CalculatePath(transform2, gameObject.transform);
						if (!string.IsNullOrEmpty(text))
						{
							if (!this.modelPrefabInstance.transform.Find(text))
							{
								global::UnityEngine.Debug.LogWarning("Deleted bone because it was not in the model prefab instance:" + text, gameObject);
								global::UnityEngine.Object.DestroyImmediate(transform2.gameObject);
							}
						}
					}
				}
			}
		}
		return gameObject;
	}

	// Token: 0x06000204 RID: 516 RVA: 0x0000A740 File Offset: 0x00008940
	private global::UnityEngine.GameObject MakeColliderPrefab()
	{
		global::UnityEngine.GameObject gameObject = this.InstantiatePrefabWithRemovedBones(this.modelPrefab);
		if (this.removeThese != null)
		{
			global::UnityEngine.GameObject gameObject2 = gameObject;
			gameObject2.name += "::RAGDOLL_OUTPUT::";
		}
		foreach (global::UnityEngine.Animation animation in gameObject.GetComponentsInChildren<global::UnityEngine.Animation>())
		{
			if (animation)
			{
				global::UnityEngine.Object.DestroyImmediate(animation, true);
			}
		}
		if (this.useMeshesFromHitBoxOnRagdoll && this.modelPrefabForHitBox && this.modelPrefabForHitBox != this.modelPrefab)
		{
			foreach (global::UnityEngine.Renderer renderer in gameObject.GetComponentsInChildren<global::UnityEngine.Renderer>())
			{
				if (renderer)
				{
					if (renderer is global::UnityEngine.MeshRenderer)
					{
						global::UnityEngine.MeshFilter component = renderer.GetComponent<global::UnityEngine.MeshFilter>();
						string text = global::AuthorShared.CalculatePath(renderer.transform, gameObject.transform);
						component.sharedMesh = this.modelPrefabForHitBox.transform.FindChild(text).GetComponent<global::UnityEngine.MeshFilter>().sharedMesh;
						global::AuthorShared.SetDirty(component);
					}
					else if (renderer is global::UnityEngine.SkinnedMeshRenderer)
					{
						((global::UnityEngine.SkinnedMeshRenderer)renderer).sharedMesh = this.modelPrefabForHitBox.transform.FindChild(global::AuthorShared.CalculatePath(renderer.transform, gameObject.transform)).GetComponent<global::UnityEngine.SkinnedMeshRenderer>().sharedMesh;
						global::AuthorShared.SetDirty(renderer);
					}
				}
			}
		}
		this.ApplyMaterials(gameObject);
		int? layerIndex;
		if (string.IsNullOrEmpty(this.defaultBodyPartLayer))
		{
			layerIndex = null;
		}
		else
		{
			layerIndex = new int?(global::UnityEngine.LayerMask.NameToLayer(this.defaultBodyPartLayer));
		}
		foreach (global::AuthorPeice authorPeice in base.EnumeratePeices())
		{
			if (authorPeice && authorPeice is global::AuthorChHit)
			{
				((global::AuthorChHit)authorPeice).CreateColliderOn(gameObject.transform, this.modelPrefabInstance.transform, true, layerIndex);
			}
		}
		global::UnityEngine.Transform rootBone = global::AuthorShared.GetRootBone(gameObject);
		global::System.Collections.Generic.Dictionary<global::UnityEngine.Rigidbody, global::System.Collections.Generic.List<global::UnityEngine.Collider>> dictionary = new global::System.Collections.Generic.Dictionary<global::UnityEngine.Rigidbody, global::System.Collections.Generic.List<global::UnityEngine.Collider>>();
		foreach (global::UnityEngine.Collider collider in rootBone.GetComponentsInChildren<global::UnityEngine.Collider>())
		{
			global::UnityEngine.Rigidbody attachedRigidbody = collider.attachedRigidbody;
			if (attachedRigidbody)
			{
				global::System.Collections.Generic.List<global::UnityEngine.Collider> list;
				if (!dictionary.TryGetValue(attachedRigidbody, out list))
				{
					list = new global::System.Collections.Generic.List<global::UnityEngine.Collider>();
					dictionary[attachedRigidbody] = list;
				}
				list.Add(collider);
			}
		}
		global::System.Collections.Generic.HashSet<global::System.Collections.Generic.KeyValuePair<global::UnityEngine.Collider, global::UnityEngine.Collider>> hashSet = new global::System.Collections.Generic.HashSet<global::System.Collections.Generic.KeyValuePair<global::UnityEngine.Collider, global::UnityEngine.Collider>>();
		foreach (global::System.Collections.Generic.KeyValuePair<global::UnityEngine.Rigidbody, global::System.Collections.Generic.List<global::UnityEngine.Collider>> keyValuePair in dictionary)
		{
			global::UnityEngine.Transform transform = keyValuePair.Key.transform;
			global::UnityEngine.Transform parent = transform.parent;
			int num = 0;
			while (num++ < this.ignoreCollisionUpSteps && parent && parent.IsChildOf(rootBone))
			{
				global::UnityEngine.Rigidbody rigidbody;
				do
				{
					rigidbody = parent.rigidbody;
				}
				while (!rigidbody && (parent = parent.parent) && parent.IsChildOf(rootBone));
				if (rigidbody)
				{
					foreach (global::UnityEngine.Collider a in keyValuePair.Value)
					{
						foreach (global::UnityEngine.Collider b in dictionary[rigidbody])
						{
							hashSet.Add(global::AuthorHull.MakeKV(a, b));
						}
					}
				}
			}
			if (this.ignoreCollisionDownSteps > 0)
			{
				foreach (global::UnityEngine.Transform transform2 in transform.ListDecendantsByDepth())
				{
					global::UnityEngine.Rigidbody rigidbody2 = transform2.rigidbody;
					if (rigidbody2)
					{
						parent = transform2.parent;
						num = 0;
						while (parent != transform)
						{
							if (parent.rigidbody && ++num > this.ignoreCollisionDownSteps)
							{
								break;
							}
							parent = parent.parent;
						}
						if (num < this.ignoreCollisionDownSteps)
						{
							foreach (global::UnityEngine.Collider a2 in keyValuePair.Value)
							{
								foreach (global::UnityEngine.Collider b2 in dictionary[transform2.rigidbody])
								{
									hashSet.Add(global::AuthorHull.MakeKV(a2, b2));
								}
							}
						}
					}
				}
			}
		}
		int count = hashSet.Count;
		if (count > 0)
		{
			global::UnityEngine.Collider[] array = new global::UnityEngine.Collider[count];
			global::UnityEngine.Collider[] array2 = new global::UnityEngine.Collider[count];
			int num2 = 0;
			foreach (global::System.Collections.Generic.KeyValuePair<global::UnityEngine.Collider, global::UnityEngine.Collider> keyValuePair2 in hashSet)
			{
				array[num2] = keyValuePair2.Key;
				array2[num2] = keyValuePair2.Value;
				num2++;
			}
			global::IgnoreColliders ignoreColliders = gameObject.AddComponent<global::IgnoreColliders>();
			ignoreColliders.a = array;
			ignoreColliders.b = array2;
		}
		this.CreateEyes(gameObject);
		if (this.ragdollPrototype)
		{
			this.ApplyPrototype(gameObject, this.ragdollPrototype);
		}
		this.ApplyRig(gameObject);
		return gameObject;
	}

	// Token: 0x06000205 RID: 517 RVA: 0x0000ADF8 File Offset: 0x00008FF8
	private static global::AuthorShared.AttributeKeyValueList GenKVL(global::UnityEngine.GameObject hitBox, global::UnityEngine.GameObject rigid)
	{
		return new global::AuthorShared.AttributeKeyValueList(new object[]
		{
			global::AuthTarg.HitBox,
			hitBox,
			global::AuthTarg.Ragdoll,
			rigid
		});
	}

	// Token: 0x06000206 RID: 518 RVA: 0x0000AE20 File Offset: 0x00009020
	private void GeneratePrefabInstances()
	{
		this.DestroyRepresentations(ref this.generatedRigid, "::RAGDOLL_OUTPUT::");
		this.generatedRigid = this.MakeColliderPrefab();
		this.DestroyRepresentations(ref this.generatedHitBox, "::HITBOX_OUTPUT::");
		this.generatedHitBox = this.MakeHitBoxPrefab();
		if (this.generatedHitBox && this.generatedRigid)
		{
			global::AuthorShared.AttributeKeyValueList attributeKeyValueList = global::AuthorHull.GenKVL(this.generatedHitBox, this.generatedRigid);
			attributeKeyValueList.Run(this.generatedHitBox);
			attributeKeyValueList.Run(this.generatedRigid);
			global::System.Collections.Generic.List<global::System.Collections.Generic.KeyValuePair<global::System.Reflection.MethodInfo, global::UnityEngine.MonoBehaviour>> list = this.CaptureFinalizeMethods(this.generatedHitBox, "OnAuthoredAsHitBoxPrefab");
			global::System.Collections.Generic.List<global::System.Collections.Generic.KeyValuePair<global::System.Reflection.MethodInfo, global::UnityEngine.MonoBehaviour>> list2 = this.CaptureFinalizeMethods(this.generatedRigid, "OnAuthoredAsRagdollPrefab");
			object[] parameters = new object[]
			{
				this.generatedRigid
			};
			foreach (global::System.Collections.Generic.KeyValuePair<global::System.Reflection.MethodInfo, global::UnityEngine.MonoBehaviour> keyValuePair in list)
			{
				if (keyValuePair.Value)
				{
					try
					{
						keyValuePair.Key.Invoke(keyValuePair.Value, parameters);
					}
					catch (global::System.Exception ex)
					{
						global::UnityEngine.Debug.LogException(ex, keyValuePair.Value);
					}
				}
			}
			object[] parameters2 = new object[]
			{
				this.generatedHitBox
			};
			foreach (global::System.Collections.Generic.KeyValuePair<global::System.Reflection.MethodInfo, global::UnityEngine.MonoBehaviour> keyValuePair2 in list2)
			{
				if (keyValuePair2.Value)
				{
					try
					{
						keyValuePair2.Key.Invoke(keyValuePair2.Value, parameters2);
					}
					catch (global::System.Exception ex2)
					{
						global::UnityEngine.Debug.LogException(ex2, keyValuePair2.Value);
					}
				}
			}
		}
		global::AuthorShared.SetDirty(this.generatedRigid);
		global::AuthorShared.SetDirty(this.generatedHitBox);
	}

	// Token: 0x06000207 RID: 519 RVA: 0x0000B05C File Offset: 0x0000925C
	private global::UnityEngine.GameObject CreateEyes(global::UnityEngine.GameObject output)
	{
		return new global::UnityEngine.GameObject("Eyes")
		{
			transform = 
			{
				parent = output.transform,
				localPosition = new global::UnityEngine.Vector3(0f, this.eyeHeight, 0f)
			}
		};
	}

	// Token: 0x06000208 RID: 520 RVA: 0x0000B0A8 File Offset: 0x000092A8
	private global::UnityEngine.GameObject MakeHitBoxPrefab()
	{
		global::UnityEngine.GameObject result;
		try
		{
			global::UnityEngine.GameObject gameObject = this.InstantiatePrefabWithRemovedBones((!this.modelPrefabForHitBox) ? this.modelPrefab : this.modelPrefabForHitBox);
			global::UnityEngine.GameObject gameObject2 = gameObject;
			gameObject2.name += "::HITBOX_OUTPUT::";
			this.ApplyMaterials(gameObject);
			global::UnityEngine.SkinnedMeshRenderer skinnedMeshRenderer;
			global::AuthorShared.GetRootBone(gameObject, out skinnedMeshRenderer);
			global::UnityEngine.GameObject gameObject3 = new global::UnityEngine.GameObject("HB Hit", new global::System.Type[]
			{
				typeof(global::UnityEngine.CapsuleCollider),
				typeof(global::UnityEngine.Rigidbody)
			})
			{
				layer = global::UnityEngine.LayerMask.NameToLayer(this.hitBoxLayerName)
			};
			gameObject3.transform.parent = ((!skinnedMeshRenderer.transform.parent) ? gameObject.transform : skinnedMeshRenderer.transform.parent);
			global::UnityEngine.CapsuleCollider capsuleCollider = gameObject3.collider as global::UnityEngine.CapsuleCollider;
			capsuleCollider.center = this.hitCapsuleCenter;
			capsuleCollider.height = this.hitCapsuleHeight;
			capsuleCollider.radius = this.hitCapsuleRadius;
			capsuleCollider.direction = this.hitCapsuleDirection;
			capsuleCollider.isTrigger = false;
			capsuleCollider.rigidbody.isKinematic = true;
			gameObject3.layer = global::UnityEngine.LayerMask.NameToLayer("Hitbox");
			global::HitBoxSystem hitBoxSystem = this.creatingSystem = this.CreateHitBoxSystem(gameObject3);
			if (hitBoxSystem.bodyParts == null)
			{
				hitBoxSystem.bodyParts = new global::IDRemoteBodyPartCollection();
			}
			global::System.Collections.Generic.List<global::HitShape> list = new global::System.Collections.Generic.List<global::HitShape>();
			int? layerIndex;
			if (string.IsNullOrEmpty(this.defaultBodyPartLayer))
			{
				layerIndex = null;
			}
			else
			{
				layerIndex = new int?(global::UnityEngine.LayerMask.NameToLayer(this.defaultBodyPartLayer));
			}
			foreach (global::AuthorPeice authorPeice in base.EnumeratePeices())
			{
				if (authorPeice && authorPeice is global::AuthorChHit)
				{
					((global::AuthorChHit)authorPeice).CreateHitBoxOn(list, gameObject.transform, this.modelPrefabInstance.transform, layerIndex);
				}
			}
			int i = 0;
			int num = list.Count;
			while (i < num)
			{
				if (list[i] == null)
				{
					list.RemoveAt(i--);
					num--;
				}
				i++;
			}
			list.Sort(global::HitShape.prioritySorter);
			hitBoxSystem.shapes = list.ToArray();
			foreach (global::HitBox hitBox in gameObject.GetComponentsInChildren<global::HitBox>())
			{
				try
				{
					global::IDRemoteBodyPart idremoteBodyPart;
					bool flag = hitBoxSystem.bodyParts.TryGetValue(hitBox.bodyPart, ref idremoteBodyPart);
					hitBoxSystem.bodyParts[hitBox.bodyPart] = hitBox;
					foreach (global::UnityEngine.Collider collider in hitBox.GetComponents<global::UnityEngine.Collider>())
					{
						global::UnityEngine.Object.DestroyImmediate(collider);
					}
					if (flag)
					{
						global::UnityEngine.Debug.LogWarning(string.Concat(new object[]
						{
							"Overwrite ",
							hitBox.bodyPart,
							". Was ",
							idremoteBodyPart,
							", now ",
							hitBox
						}), hitBox);
					}
				}
				catch (global::System.Exception arg)
				{
					global::UnityEngine.Debug.LogError(string.Format("{0}:{2}:{1}", hitBox, arg, hitBox.bodyPart));
					throw;
				}
			}
			global::AuthorShared.SetDirty(hitBoxSystem);
			this.CreateEyes(gameObject);
			global::IDMain idmain = this.ApplyPrototype(gameObject, this.prototype);
			this.ApplyRig(gameObject);
			global::AuthorShared.SetDirty(gameObject);
			result = gameObject;
		}
		finally
		{
			this.creatingSystem = null;
		}
		return result;
	}

	// Token: 0x06000209 RID: 521 RVA: 0x0000B4A0 File Offset: 0x000096A0
	private global::IDMain ApplyPrototype(global::UnityEngine.GameObject output, global::IDMain prototype)
	{
		global::IDMain result = null;
		if (prototype)
		{
			global::UnityEngine.Component[] components = prototype.GetComponents<global::UnityEngine.Component>();
			global::UnityEngine.Component[] array = new global::UnityEngine.Component[components.Length];
			global::UnityEngine.Component[] array2 = new global::UnityEngine.Component[components.Length];
			int num = components.Length;
			int num2 = -1;
			int num3 = 0x1F4;
			int num4;
			do
			{
				num4 = 0;
				for (int i = 0; i < num; i++)
				{
					global::UnityEngine.Component component = components[i];
					if (!component)
					{
						components[i] = null;
					}
					else if (component is global::UnityEngine.Transform)
					{
						components[i] = null;
						array[i] = component;
						array2[num2 = i] = output.transform;
					}
					else
					{
						global::UnityEngine.Component component2 = output.AddComponent(component.GetType());
						if (component2)
						{
							array2[i] = component2;
							components[i] = null;
							array[i] = component;
							if (component2 is global::IDMain)
							{
								result = (global::IDMain)component2;
							}
						}
						else
						{
							num4++;
						}
					}
				}
			}
			while (num4 != 0 || num3-- <= 0);
			if (num3 < 0)
			{
				global::UnityEngine.Debug.LogError("Couldnt remake all components");
			}
			for (int j = 0; j < 2; j++)
			{
				for (int k = 0; k < num; k++)
				{
					if (k != num2)
					{
						global::UnityEngine.Component component3 = array[k];
						global::UnityEngine.Component component4 = array2[k];
						if (component3)
						{
							if (component4)
							{
								this.TransferComponentSettings(prototype.gameObject, output, array, array2, component3, component4);
								global::AuthorShared.SetDirty(component4);
							}
							else
							{
								global::UnityEngine.Debug.LogWarning("no dest for source " + component3, component3);
							}
						}
						else if (component4)
						{
							global::UnityEngine.Debug.LogWarning("no source for dest " + component4, component4);
						}
						else
						{
							global::UnityEngine.Debug.LogWarning("no source or dest", output);
						}
					}
				}
			}
			output.layer = prototype.gameObject.layer;
			output.tag = prototype.gameObject.tag;
		}
		return result;
	}

	// Token: 0x0600020A RID: 522 RVA: 0x0000B69C File Offset: 0x0000989C
	private bool ApplyRig(global::UnityEngine.GameObject output)
	{
		bool result = false;
		if (this.actorRig)
		{
			global::Facepunch.Actor.BoneStructure.EditorOnly_AddOrUpdateBoneStructure(output, this.actorRig);
			result = true;
		}
		else
		{
			global::Facepunch.Actor.BoneStructure component = output.GetComponent<global::Facepunch.Actor.BoneStructure>();
			if (component)
			{
				global::UnityEngine.Object.DestroyImmediate(component, true);
			}
		}
		return result;
	}

	// Token: 0x0600020B RID: 523 RVA: 0x0000B6E8 File Offset: 0x000098E8
	private global::System.Collections.Generic.List<global::System.Collections.Generic.KeyValuePair<global::System.Reflection.MethodInfo, global::UnityEngine.MonoBehaviour>> CaptureFinalizeMethods(global::UnityEngine.GameObject output, string methodName)
	{
		global::System.Collections.Generic.List<global::System.Collections.Generic.KeyValuePair<global::System.Reflection.MethodInfo, global::UnityEngine.MonoBehaviour>> list = new global::System.Collections.Generic.List<global::System.Collections.Generic.KeyValuePair<global::System.Reflection.MethodInfo, global::UnityEngine.MonoBehaviour>>();
		foreach (global::UnityEngine.MonoBehaviour monoBehaviour in output.GetComponentsInChildren<global::UnityEngine.MonoBehaviour>(true))
		{
			if (monoBehaviour)
			{
				foreach (global::System.Reflection.MethodInfo methodInfo in monoBehaviour.GetType().GetMethods(global::System.Reflection.BindingFlags.Instance | global::System.Reflection.BindingFlags.Public | global::System.Reflection.BindingFlags.NonPublic))
				{
					if (methodInfo.Name == methodName)
					{
						list.Add(new global::System.Collections.Generic.KeyValuePair<global::System.Reflection.MethodInfo, global::UnityEngine.MonoBehaviour>(methodInfo, monoBehaviour));
					}
				}
			}
		}
		return list;
	}

	// Token: 0x0600020C RID: 524 RVA: 0x0000B778 File Offset: 0x00009978
	private static bool ActorRigSearch(global::System.Reflection.MemberInfo m, object filterCriteria)
	{
		return ((global::System.Reflection.FieldInfo)m).FieldType == typeof(global::Facepunch.Actor.ActorRig);
	}

	// Token: 0x0600020D RID: 525 RVA: 0x0000B794 File Offset: 0x00009994
	private void TransferComponentSettings(global::UnityEngine.GameObject srcGO, global::UnityEngine.GameObject dstGO, global::UnityEngine.Component[] srcComponents, global::UnityEngine.Component[] dstComponents, global::UnityEngine.Component src, global::UnityEngine.Component dst)
	{
		if (!(src is global::UnityEngine.MonoBehaviour) && src is global::UnityEngine.SkinnedMeshRenderer)
		{
			global::UnityEngine.Debug.LogWarning("Cannot copy skinned mesh renderers");
			return;
		}
	}

	// Token: 0x0600020E RID: 526 RVA: 0x0000B7BC File Offset: 0x000099BC
	private void TransferComponentSettings(global::UnityEngine.NavMeshAgent src, global::UnityEngine.NavMeshAgent dst)
	{
		dst.radius = src.radius;
		dst.speed = src.speed;
		dst.acceleration = src.acceleration;
		dst.angularSpeed = src.angularSpeed;
		dst.stoppingDistance = src.stoppingDistance;
		dst.autoTraverseOffMeshLink = src.autoTraverseOffMeshLink;
		dst.autoRepath = src.autoRepath;
		dst.height = src.height;
		dst.baseOffset = src.baseOffset;
		dst.obstacleAvoidanceType = src.obstacleAvoidanceType;
		dst.walkableMask = src.walkableMask;
		dst.enabled = src.enabled;
	}

	// Token: 0x0600020F RID: 527 RVA: 0x0000B85C File Offset: 0x00009A5C
	private void ChangedModelPrefab()
	{
		if (this.modelPrefabInstance)
		{
			global::UnityEngine.Object.DestroyImmediate(this.modelPrefabInstance);
		}
		this.modelPrefabInstance = global::AuthorShared.InstantiatePrefab(this.modelPrefab);
		this.modelPrefabInstance.transform.localPosition = global::UnityEngine.Vector3.zero;
		this.modelPrefabInstance.transform.localRotation = global::UnityEngine.Quaternion.identity;
		this.modelPrefabInstance.transform.localScale = global::UnityEngine.Vector3.one;
	}

	// Token: 0x06000210 RID: 528 RVA: 0x0000B8D4 File Offset: 0x00009AD4
	protected override global::System.Collections.Generic.IEnumerable<global::AuthorPalletObject> EnumeratePalletObjects()
	{
		global::AuthorPalletObject[] pallet = global::AuthorHull.HitBoxItems.pallet;
		if (!global::AuthorHull.once)
		{
			pallet[0].guiContent.image = global::AuthorShared.ObjectContent(null, typeof(global::UnityEngine.BoxCollider)).image;
			pallet[1].guiContent.image = global::AuthorShared.ObjectContent(null, typeof(global::UnityEngine.SphereCollider)).image;
			pallet[2].guiContent.image = global::AuthorShared.ObjectContent(null, typeof(global::UnityEngine.CapsuleCollider)).image;
			global::AuthorHull.once = true;
		}
		return pallet;
	}

	// Token: 0x06000211 RID: 529 RVA: 0x0000B968 File Offset: 0x00009B68
	private void OnDrawGizmosSelected()
	{
		if (this.modelPrefabInstance)
		{
			global::UnityEngine.Gizmos.matrix = this.modelPrefabInstance.transform.localToWorldMatrix;
			global::UnityEngine.Transform hitColliderParent = this.GetHitColliderParent(this.modelPrefabInstance);
			if (hitColliderParent)
			{
				global::UnityEngine.Gizmos.matrix = hitColliderParent.localToWorldMatrix;
				global::Gizmos2.DrawWireCapsule(this.hitCapsuleCenter, this.hitCapsuleRadius, this.hitCapsuleHeight, this.hitCapsuleDirection);
			}
		}
	}

	// Token: 0x06000212 RID: 530 RVA: 0x0000B9DC File Offset: 0x00009BDC
	private static void WriteJSONGUID(global::JSONStream stream, global::UnityEngine.Object obj)
	{
		string text = global::AuthorShared.GetAssetPath(obj);
		string text2 = null;
		if (text == string.Empty)
		{
			text = null;
		}
		else
		{
			text2 = global::AuthorShared.PathToGUID(text);
			if (string.IsNullOrEmpty(text2))
			{
				text2 = null;
			}
		}
		string text3;
		if (obj)
		{
			text3 = obj.GetType().AssemblyQualifiedName;
		}
		else
		{
			text3 = null;
		}
		stream.WriteObjectStart();
		stream.WriteText("path", text);
		stream.WriteText("guid", text2);
		stream.WriteText("type", text3);
		stream.WriteObjectEnd();
	}

	// Token: 0x06000213 RID: 531 RVA: 0x0000BA6C File Offset: 0x00009C6C
	private static void WriteJSONGUID(global::JSONStream stream, string property, global::UnityEngine.Object obj)
	{
		stream.WriteProperty(property);
		global::AuthorHull.WriteJSONGUID(stream, obj);
	}

	// Token: 0x06000214 RID: 532 RVA: 0x0000BA7C File Offset: 0x00009C7C
	protected override void SaveSettings(global::JSONStream stream)
	{
		stream.WriteObjectStart();
		stream.WriteObjectStart("types");
		stream.WriteText("hitboxsystem", this.hitBoxSystemType);
		stream.WriteText("hitbox", this.hitBoxType);
		stream.WriteObjectEnd();
		stream.WriteObjectStart("assets");
		global::AuthorHull.WriteJSONGUID(stream, "model", this.modelPrefabInstance);
		stream.WriteArrayStart("materials");
		if (this.materials != null)
		{
			for (int i = 0; i < this.materials.Length; i++)
			{
				global::AuthorHull.WriteJSONGUID(stream, this.materials[i]);
			}
		}
		stream.WriteArrayEnd();
		stream.WriteObjectStart("bodyparts");
		foreach (global::BodyPartPair<global::UnityEngine.Transform> bodyPartPair in this.bodyParts)
		{
			stream.WriteText(bodyPartPair.key.ToString(), global::AuthorShared.CalculatePath(bodyPartPair.value, this.modelPrefabInstance.transform));
		}
		stream.WriteObjectEnd();
		stream.WriteArrayStart("peices");
		foreach (global::AuthorPeice authorPeice in base.EnumeratePeices())
		{
			stream.WriteObjectStart();
			stream.WriteText("type", authorPeice.GetType().AssemblyQualifiedName);
			stream.WriteText("id", authorPeice.peiceID);
			stream.WriteObjectStart("instance");
			authorPeice.SaveJsonProperties(stream);
			stream.WriteObjectEnd();
			stream.WriteObjectEnd();
		}
		stream.WriteArrayEnd();
		stream.WriteObjectEnd();
	}

	// Token: 0x06000215 RID: 533 RVA: 0x0000BC64 File Offset: 0x00009E64
	protected override void LoadSettings(global::JSONStream stream)
	{
		stream.ReadSkip();
	}

	// Token: 0x06000216 RID: 534 RVA: 0x0000BC70 File Offset: 0x00009E70
	public override string RootBonePath(global::AuthorPeice callingPeice, global::UnityEngine.Transform bone)
	{
		return global::AuthorShared.CalculatePath(bone, this.modelPrefabInstance.transform);
	}

	// Token: 0x06000217 RID: 535 RVA: 0x0000BC84 File Offset: 0x00009E84
	[global::System.Diagnostics.Conditional("EXPECT_CRASH")]
	private static void PreCrashLog(string text)
	{
		global::UnityEngine.Debug.Log(text);
	}

	// Token: 0x06000218 RID: 536 RVA: 0x0000BC8C File Offset: 0x00009E8C
	[global::System.Diagnostics.Conditional("LOG_GENERATE")]
	private static void GenerateLog(object text)
	{
		global::UnityEngine.Debug.Log(text);
	}

	// Token: 0x06000219 RID: 537 RVA: 0x0000BC94 File Offset: 0x00009E94
	[global::System.Diagnostics.Conditional("LOG_GENERATE")]
	private static void GenerateLog(object text, global::UnityEngine.Object obj)
	{
		global::UnityEngine.Debug.Log(text, obj);
	}

	// Token: 0x0600021A RID: 538 RVA: 0x0000BCA0 File Offset: 0x00009EA0
	protected void PreviewPrototype()
	{
		global::AuthorCreationProject authorCreationProject;
		using (global::System.IO.Stream stream = base.GetStream(true, "protoprev", out authorCreationProject))
		{
			if (stream != null)
			{
				using (global::JSONStream jsonstream = global::JSONStream.CreateWriter(stream))
				{
					if (jsonstream == null)
					{
					}
				}
			}
		}
	}

	// Token: 0x0600021B RID: 539 RVA: 0x0000BD2C File Offset: 0x00009F2C
	private void UpdatePrefabs()
	{
	}

	// Token: 0x0600021C RID: 540 RVA: 0x0000BD30 File Offset: 0x00009F30
	private bool EnsureItsAPrefab(ref global::UnityEngine.Object obj)
	{
		return !obj;
	}

	// Token: 0x0600021D RID: 541 RVA: 0x0000BD3C File Offset: 0x00009F3C
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private static bool <OnGUICreationSettings>m__1(ref global::UnityEngine.Material material)
	{
		return global::AuthorShared.ObjectField<global::UnityEngine.Material>(default(global::AuthorShared.Content), ref material, typeof(global::UnityEngine.Material), (global::AuthorShared.ObjectFieldFlags)0, new global::UnityEngine.GUILayoutOption[0]);
	}

	// Token: 0x04000137 RID: 311
	private const string suffix_rigid = "::RAGDOLL_OUTPUT::";

	// Token: 0x04000138 RID: 312
	private const string suffix_hitbox = "::HITBOX_OUTPUT::";

	// Token: 0x04000139 RID: 313
	[global::UnityEngine.SerializeField]
	private global::UnityEngine.GameObject modelPrefab;

	// Token: 0x0400013A RID: 314
	[global::UnityEngine.SerializeField]
	private global::UnityEngine.GameObject modelPrefabForHitBox;

	// Token: 0x0400013B RID: 315
	[global::UnityEngine.SerializeField]
	private global::UnityEngine.GameObject modelPrefabInstance;

	// Token: 0x0400013C RID: 316
	[global::UnityEngine.SerializeField]
	private global::UnityEngine.GameObject hitBoxOutputPrefab;

	// Token: 0x0400013D RID: 317
	[global::UnityEngine.SerializeField]
	private global::UnityEngine.GameObject ragdollOutputPrefab;

	// Token: 0x0400013E RID: 318
	[global::UnityEngine.SerializeField]
	private global::UnityEngine.Vector3 hitCapsuleCenter;

	// Token: 0x0400013F RID: 319
	[global::UnityEngine.SerializeField]
	private float hitCapsuleRadius = 1f;

	// Token: 0x04000140 RID: 320
	[global::UnityEngine.SerializeField]
	private float hitCapsuleHeight = 2.5f;

	// Token: 0x04000141 RID: 321
	[global::UnityEngine.SerializeField]
	private int hitCapsuleDirection;

	// Token: 0x04000142 RID: 322
	[global::UnityEngine.SerializeField]
	private bool drawBones;

	// Token: 0x04000143 RID: 323
	[global::UnityEngine.SerializeField]
	private bool allowBonesOutsideOfModelPrefab;

	// Token: 0x04000144 RID: 324
	[global::UnityEngine.SerializeField]
	private int ignoreCollisionDownSteps = 2;

	// Token: 0x04000145 RID: 325
	[global::UnityEngine.SerializeField]
	private int ignoreCollisionUpSteps = 1;

	// Token: 0x04000146 RID: 326
	[global::UnityEngine.SerializeField]
	private string hitBoxType = "HitBox";

	// Token: 0x04000147 RID: 327
	[global::UnityEngine.SerializeField]
	private string hitBoxSystemType = "HitBoxSystem";

	// Token: 0x04000148 RID: 328
	[global::UnityEngine.SerializeField]
	private string defaultBodyPartLayer = string.Empty;

	// Token: 0x04000149 RID: 329
	[global::UnityEngine.SerializeField]
	private global::Facepunch.Actor.ActorRig actorRig;

	// Token: 0x0400014A RID: 330
	[global::UnityEngine.SerializeField]
	private global::Character prototype;

	// Token: 0x0400014B RID: 331
	[global::UnityEngine.SerializeField]
	private global::Ragdoll ragdollPrototype;

	// Token: 0x0400014C RID: 332
	[global::UnityEngine.SerializeField]
	private global::UnityEngine.Transform hitCapsuleTransform;

	// Token: 0x0400014D RID: 333
	[global::UnityEngine.SerializeField]
	private global::UnityEngine.Transform[] removeThese;

	// Token: 0x0400014E RID: 334
	[global::UnityEngine.SerializeField]
	private float eyeHeight = 1f;

	// Token: 0x0400014F RID: 335
	[global::UnityEngine.SerializeField]
	private global::UnityEngine.GameObject generatedRigid;

	// Token: 0x04000150 RID: 336
	[global::UnityEngine.SerializeField]
	private global::UnityEngine.GameObject generatedHitBox;

	// Token: 0x04000151 RID: 337
	[global::UnityEngine.SerializeField]
	private bool savedGenerated;

	// Token: 0x04000152 RID: 338
	[global::UnityEngine.SerializeField]
	private global::UnityEngine.Material[] materials;

	// Token: 0x04000153 RID: 339
	[global::UnityEngine.SerializeField]
	private global::UnityEngine.Vector3 editingAngles = global::UnityEngine.Vector3.zero;

	// Token: 0x04000154 RID: 340
	[global::UnityEngine.SerializeField]
	private bool editingCenterToRoot;

	// Token: 0x04000155 RID: 341
	[global::UnityEngine.SerializeField]
	private global::BodyPartTransformMap bodyParts = new global::BodyPartTransformMap();

	// Token: 0x04000156 RID: 342
	[global::UnityEngine.SerializeField]
	private string saveJSONGUID;

	// Token: 0x04000157 RID: 343
	[global::UnityEngine.SerializeField]
	private string previewPrototypeGUID;

	// Token: 0x04000158 RID: 344
	[global::UnityEngine.SerializeField]
	private bool removeAnimationFromRagdoll;

	// Token: 0x04000159 RID: 345
	[global::UnityEngine.SerializeField]
	private string hitBoxLayerName = "Hitbox";

	// Token: 0x0400015A RID: 346
	[global::UnityEngine.SerializeField]
	private bool useMeshesFromHitBoxOnRagdoll;

	// Token: 0x0400015B RID: 347
	private static bool once;

	// Token: 0x0400015C RID: 348
	private global::HitBoxSystem creatingSystem;

	// Token: 0x0400015D RID: 349
	private bool showAllBones;

	// Token: 0x0400015E RID: 350
	private static readonly global::System.Reflection.MemberFilter actorRigSearch = new global::System.Reflection.MemberFilter(global::AuthorHull.ActorRigSearch);

	// Token: 0x0400015F RID: 351
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private static global::AuthorShared.ArrayFieldFunctor<global::UnityEngine.Material> <>f__am$cache26;

	// Token: 0x02000038 RID: 56
	private static class guis
	{
		// Token: 0x0600021E RID: 542 RVA: 0x0000BD6C File Offset: 0x00009F6C
		// Note: this type is marked as 'beforefieldinit'.
		static guis()
		{
		}

		// Token: 0x04000160 RID: 352
		public static readonly global::UnityEngine.GUIContent overridingContent = new global::UnityEngine.GUIContent("[overriding the hitbox output prefab]", "The HitBox prefab output will use the overriding mesh prefab provided, You must make sure that the heirarchy matches between the two");

		// Token: 0x04000161 RID: 353
		public static readonly global::UnityEngine.GUIContent notOverridingContent = new global::UnityEngine.GUIContent("[both outputs will use the same base]", "The HitBox prefab output will use the same mesh prefab as the one for the rigidbody");

		// Token: 0x04000162 RID: 354
		public static readonly global::UnityEngine.GUIContent destroyDrop = new global::UnityEngine.GUIContent("Destroy bone", "Drag a transform off the model instance that contains no ::'s");
	}

	// Token: 0x02000039 RID: 57
	private static class HitBoxItems
	{
		// Token: 0x0600021F RID: 543 RVA: 0x0000BDB8 File Offset: 0x00009FB8
		// Note: this type is marked as 'beforefieldinit'.
		static HitBoxItems()
		{
		}

		// Token: 0x06000220 RID: 544 RVA: 0x0000BE84 File Offset: 0x0000A084
		private static bool ValidateByID(global::AuthorCreation creation, global::AuthorPalletObject palletObject)
		{
			return true;
		}

		// Token: 0x06000221 RID: 545 RVA: 0x0000BE88 File Offset: 0x0000A088
		private static global::AuthorPeice CreateByID<TPeice>(global::AuthorCreation creation, global::AuthorPalletObject palletObject) where TPeice : global::AuthorPeice
		{
			global::UnityEngine.GameObject gameObject = new global::UnityEngine.GameObject(palletObject.guiContent.text, new global::System.Type[]
			{
				typeof(TPeice)
			});
			TPeice component = gameObject.GetComponent<TPeice>();
			component.peiceID = palletObject.guiContent.text;
			return component;
		}

		// Token: 0x04000163 RID: 355
		public static readonly global::AuthorPalletObject.Validator validateByID = new global::AuthorPalletObject.Validator(global::AuthorHull.HitBoxItems.ValidateByID);

		// Token: 0x04000164 RID: 356
		public static readonly global::AuthorPalletObject.Creator createSocketByID = new global::AuthorPalletObject.Creator(global::AuthorHull.HitBoxItems.CreateByID<global::AuthorChHit>);

		// Token: 0x04000165 RID: 357
		public static readonly global::AuthorPalletObject[] pallet = new global::AuthorPalletObject[]
		{
			new global::AuthorPalletObject
			{
				guiContent = new global::UnityEngine.GUIContent("Box"),
				validator = global::AuthorHull.HitBoxItems.validateByID,
				creator = global::AuthorHull.HitBoxItems.createSocketByID
			},
			new global::AuthorPalletObject
			{
				guiContent = new global::UnityEngine.GUIContent("Sphere"),
				validator = global::AuthorHull.HitBoxItems.validateByID,
				creator = global::AuthorHull.HitBoxItems.createSocketByID
			},
			new global::AuthorPalletObject
			{
				guiContent = new global::UnityEngine.GUIContent("Capsule"),
				validator = global::AuthorHull.HitBoxItems.validateByID,
				creator = global::AuthorHull.HitBoxItems.createSocketByID
			}
		};
	}

	// Token: 0x0200003A RID: 58
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private sealed class <GetCollidersOnRigidbody>c__Iterator6 : global::System.IDisposable, global::System.Collections.IEnumerator, global::System.Collections.IEnumerable, global::System.Collections.Generic.IEnumerable<global::UnityEngine.Collider>, global::System.Collections.Generic.IEnumerator<global::UnityEngine.Collider>
	{
		// Token: 0x06000222 RID: 546 RVA: 0x0000BEE0 File Offset: 0x0000A0E0
		public <GetCollidersOnRigidbody>c__Iterator6()
		{
		}

		// Token: 0x17000058 RID: 88
		// (get) Token: 0x06000223 RID: 547 RVA: 0x0000BEE8 File Offset: 0x0000A0E8
		global::UnityEngine.Collider global::System.Collections.Generic.IEnumerator<global::UnityEngine.Collider>.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17000059 RID: 89
		// (get) Token: 0x06000224 RID: 548 RVA: 0x0000BEF0 File Offset: 0x0000A0F0
		object global::System.Collections.IEnumerator.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06000225 RID: 549 RVA: 0x0000BEF8 File Offset: 0x0000A0F8
		[global::System.Diagnostics.DebuggerHidden]
		global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<UnityEngine.Collider>.GetEnumerator();
		}

		// Token: 0x06000226 RID: 550 RVA: 0x0000BF00 File Offset: 0x0000A100
		[global::System.Diagnostics.DebuggerHidden]
		global::System.Collections.Generic.IEnumerator<global::UnityEngine.Collider> global::System.Collections.Generic.IEnumerable<global::UnityEngine.Collider>.GetEnumerator()
		{
			if (global::System.Threading.Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			global::AuthorHull.<GetCollidersOnRigidbody>c__Iterator6 <GetCollidersOnRigidbody>c__Iterator = new global::AuthorHull.<GetCollidersOnRigidbody>c__Iterator6();
			<GetCollidersOnRigidbody>c__Iterator.rb = rb;
			return <GetCollidersOnRigidbody>c__Iterator;
		}

		// Token: 0x06000227 RID: 551 RVA: 0x0000BF34 File Offset: 0x0000A134
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			switch (num)
			{
			case 0U:
				componentsInChildren = rb.GetComponentsInChildren<global::UnityEngine.Collider>();
				i = 0;
				break;
			case 1U:
				IL_84:
				i++;
				break;
			default:
				return false;
			}
			if (i >= componentsInChildren.Length)
			{
				this.$PC = -1;
			}
			else
			{
				collider = componentsInChildren[i];
				if (collider.attachedRigidbody == rb)
				{
					this.$current = collider;
					this.$PC = 1;
					return true;
				}
				goto IL_84;
			}
			return false;
		}

		// Token: 0x06000228 RID: 552 RVA: 0x0000BFF4 File Offset: 0x0000A1F4
		[global::System.Diagnostics.DebuggerHidden]
		public void Dispose()
		{
			this.$PC = -1;
		}

		// Token: 0x06000229 RID: 553 RVA: 0x0000C000 File Offset: 0x0000A200
		[global::System.Diagnostics.DebuggerHidden]
		public void Reset()
		{
			throw new global::System.NotSupportedException();
		}

		// Token: 0x04000166 RID: 358
		internal global::UnityEngine.Rigidbody rb;

		// Token: 0x04000167 RID: 359
		internal global::UnityEngine.Collider[] <$s_33>__0;

		// Token: 0x04000168 RID: 360
		internal int <$s_34>__1;

		// Token: 0x04000169 RID: 361
		internal global::UnityEngine.Collider <collider>__2;

		// Token: 0x0400016A RID: 362
		internal int $PC;

		// Token: 0x0400016B RID: 363
		internal global::UnityEngine.Collider $current;

		// Token: 0x0400016C RID: 364
		internal global::UnityEngine.Rigidbody <$>rb;
	}
}
