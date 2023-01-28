using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using UnityEngine;

// Token: 0x020001BF RID: 447
[global::UnityEngine.ExecuteInEditMode]
public class ManagedLeakDetector : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06000D17 RID: 3351 RVA: 0x000329F4 File Offset: 0x00030BF4
	public ManagedLeakDetector()
	{
	}

	// Token: 0x06000D18 RID: 3352 RVA: 0x000329FC File Offset: 0x00030BFC
	private static bool CheckRelation(global::System.Type a, global::System.Type b)
	{
		return a.IsAssignableFrom(b) || b.IsAssignableFrom(a);
	}

	// Token: 0x06000D19 RID: 3353 RVA: 0x00032A14 File Offset: 0x00030C14
	public static string Poll()
	{
		return global::ManagedLeakDetector.Poll(typeof(global::UnityEngine.Object));
	}

	// Token: 0x06000D1A RID: 3354 RVA: 0x00032A28 File Offset: 0x00030C28
	public static string Poll(global::System.Type searchType)
	{
		return global::ManagedLeakDetector.Poll(searchType, typeof(global::UnityEngine.Object));
	}

	// Token: 0x06000D1B RID: 3355 RVA: 0x00032A3C File Offset: 0x00030C3C
	public static string Poll(global::System.Type searchType, global::System.Type minType)
	{
		return new global::ManagedLeakDetector.ReadResult(searchType, minType).ToString();
	}

	// Token: 0x06000D1C RID: 3356 RVA: 0x00032A4C File Offset: 0x00030C4C
	private void OnGUI()
	{
		if (global::UnityEngine.Event.current.type == 7)
		{
			if (!global::UnityEngine.Camera.main)
			{
				global::UnityEngine.GUI.Box(new global::UnityEngine.Rect(-5f, -5f, (float)(global::UnityEngine.Screen.width + 0xA), (float)(global::UnityEngine.Screen.height + 0xA)), global::UnityEngine.GUIContent.none);
			}
			global::ManagedLeakDetector.ReadResult readResult = new global::ManagedLeakDetector.ReadResult();
			readResult.Read();
			global::ManagedLeakDetector.Counter[] counters = readResult.counters;
			float num = (float)(global::UnityEngine.Screen.width - 0xA);
			this.scroll = global::UnityEngine.GUI.BeginScrollView(new global::UnityEngine.Rect(5f, 5f, num, (float)(global::UnityEngine.Screen.height - 0xA)), this.scroll, new global::UnityEngine.Rect(0f, 0f, num, (float)(counters.Length * 0x14)));
			int num2 = 0;
			foreach (global::ManagedLeakDetector.Counter counter in counters)
			{
				global::UnityEngine.GUI.Label(new global::UnityEngine.Rect(0f, (float)num2, num, 20f), string.Format("{0:000} [{1:0000}] {2}", counter.actualInstanceCount, counter.derivedInstanceCount, counter.type));
				num2 += 0x14;
			}
		}
	}

	// Token: 0x04000859 RID: 2137
	private global::UnityEngine.Vector2 scroll;

	// Token: 0x020001C0 RID: 448
	private class Counter
	{
		// Token: 0x06000D1D RID: 3357 RVA: 0x00032B6C File Offset: 0x00030D6C
		public Counter()
		{
		}

		// Token: 0x0400085A RID: 2138
		public int actualInstanceCount;

		// Token: 0x0400085B RID: 2139
		public int derivedInstanceCount;

		// Token: 0x0400085C RID: 2140
		public int enabledCount;

		// Token: 0x0400085D RID: 2141
		public global::System.Type type;
	}

	// Token: 0x020001C1 RID: 449
	private class ReadResult
	{
		// Token: 0x06000D1E RID: 3358 RVA: 0x00032B74 File Offset: 0x00030D74
		public ReadResult(global::System.Type searchType, global::System.Type minType)
		{
			this.minType = (minType ?? typeof(global::UnityEngine.Object));
			this.searchType = (searchType ?? typeof(global::UnityEngine.Object));
			this.sumComponent.name = "Components";
			this.sumBehaviour.name = "Behaviours";
			this.sumRenderer.name = "Renderers";
			this.sumCollider.name = "Colliders";
			this.sumCloth.name = "Cloths";
			this.sumGameObject.name = "Game Objects";
			this.sumScriptableObject.name = "Scriptable Objects";
			this.sumMaterial.name = "Materials";
			this.sumTexture.name = "Textures";
			this.sumAnimation.name = "Animations";
			this.sumMesh.name = "Meshes";
			this.sumAudioClip.name = "Audio Clips";
			this.sumAnimationClip.name = "Animation Clips";
			this.sumParticleEmitter.name = "Particle Emitters (Legacy)";
			this.sumParticleSystem.name = "Particle Systems";
			this.sumComponent.check = global::ManagedLeakDetector.CheckRelation(searchType, typeof(global::UnityEngine.Component));
			this.sumBehaviour.check = (this.sumComponent.check && global::ManagedLeakDetector.CheckRelation(typeof(global::UnityEngine.Behaviour), searchType));
			this.sumRenderer.check = (this.sumComponent.check && global::ManagedLeakDetector.CheckRelation(typeof(global::UnityEngine.Renderer), searchType));
			this.sumCollider.check = (this.sumComponent.check && global::ManagedLeakDetector.CheckRelation(typeof(global::UnityEngine.Collider), searchType));
			this.sumCloth.check = (this.sumComponent.check && global::ManagedLeakDetector.CheckRelation(typeof(global::UnityEngine.Cloth), searchType));
			this.sumParticleSystem.check = (this.sumComponent.check && global::ManagedLeakDetector.CheckRelation(typeof(global::UnityEngine.ParticleSystem), searchType));
			this.sumAnimation.check = (this.sumBehaviour.check && global::ManagedLeakDetector.CheckRelation(typeof(global::UnityEngine.Animation), searchType));
			this.sumParticleEmitter.check = (this.sumComponent.check && global::ManagedLeakDetector.CheckRelation(typeof(global::UnityEngine.ParticleEmitter), searchType));
			this.sumGameObject.check = global::ManagedLeakDetector.CheckRelation(typeof(global::UnityEngine.GameObject), searchType);
			this.sumScriptableObject.check = global::ManagedLeakDetector.CheckRelation(typeof(global::UnityEngine.ScriptableObject), searchType);
			this.sumMaterial.check = global::ManagedLeakDetector.CheckRelation(typeof(global::UnityEngine.Material), searchType);
			this.sumTexture.check = global::ManagedLeakDetector.CheckRelation(typeof(global::UnityEngine.Texture), searchType);
			this.sumMesh.check = global::ManagedLeakDetector.CheckRelation(typeof(global::UnityEngine.Mesh), searchType);
			this.sumAudioClip.check = global::ManagedLeakDetector.CheckRelation(typeof(global::UnityEngine.AudioClip), searchType);
			this.sumAnimationClip.check = global::ManagedLeakDetector.CheckRelation(typeof(global::UnityEngine.AnimationClip), searchType);
		}

		// Token: 0x06000D1F RID: 3359 RVA: 0x00032EC4 File Offset: 0x000310C4
		public ReadResult(global::System.Type searchType) : this(searchType, typeof(global::UnityEngine.Object))
		{
		}

		// Token: 0x06000D20 RID: 3360 RVA: 0x00032ED8 File Offset: 0x000310D8
		public ReadResult() : this(typeof(global::UnityEngine.Object))
		{
		}

		// Token: 0x06000D21 RID: 3361 RVA: 0x00032EEC File Offset: 0x000310EC
		public void Read()
		{
			this.Read(false);
		}

		// Token: 0x06000D22 RID: 3362 RVA: 0x00032EF8 File Offset: 0x000310F8
		public void Read(bool forceUpdate)
		{
			if (this.complete && !forceUpdate)
			{
				return;
			}
			global::System.Collections.Generic.Dictionary<global::System.Type, global::ManagedLeakDetector.Counter> dictionary = new global::System.Collections.Generic.Dictionary<global::System.Type, global::ManagedLeakDetector.Counter>();
			global::ManagedLeakDetector.Counter counter = new global::ManagedLeakDetector.Counter();
			counter.type = this.minType;
			dictionary.Add(this.minType, counter);
			this.sumComponent.Reset();
			this.sumBehaviour.Reset();
			this.sumRenderer.Reset();
			this.sumCollider.Reset();
			this.sumCloth.Reset();
			this.sumGameObject.Reset();
			this.sumScriptableObject.Reset();
			this.sumMaterial.Reset();
			this.sumTexture.Reset();
			this.sumAnimation.Reset();
			this.sumMesh.Reset();
			this.sumAudioClip.Reset();
			this.sumAnimationClip.Reset();
			this.sumParticleSystem.Reset();
			this.sumParticleEmitter.Reset();
			this.sumComponent.check = global::ManagedLeakDetector.CheckRelation(this.searchType, typeof(global::UnityEngine.Component));
			this.sumBehaviour.check = (this.sumComponent.check && global::ManagedLeakDetector.CheckRelation(typeof(global::UnityEngine.Behaviour), this.searchType));
			this.sumRenderer.check = (this.sumComponent.check && global::ManagedLeakDetector.CheckRelation(typeof(global::UnityEngine.Renderer), this.searchType));
			this.sumCollider.check = (this.sumComponent.check && global::ManagedLeakDetector.CheckRelation(typeof(global::UnityEngine.Collider), this.searchType));
			this.sumCloth.check = (this.sumComponent.check && global::ManagedLeakDetector.CheckRelation(typeof(global::UnityEngine.Cloth), this.searchType));
			this.sumParticleSystem.check = (this.sumComponent.check && global::ManagedLeakDetector.CheckRelation(typeof(global::UnityEngine.ParticleSystem), this.searchType));
			this.sumAnimation.check = (this.sumBehaviour.check && global::ManagedLeakDetector.CheckRelation(typeof(global::UnityEngine.Animation), this.searchType));
			this.sumParticleEmitter.check = (this.sumComponent.check && global::ManagedLeakDetector.CheckRelation(typeof(global::UnityEngine.ParticleEmitter), this.searchType));
			this.sumGameObject.check = global::ManagedLeakDetector.CheckRelation(typeof(global::UnityEngine.GameObject), this.searchType);
			this.sumScriptableObject.check = global::ManagedLeakDetector.CheckRelation(typeof(global::UnityEngine.ScriptableObject), this.searchType);
			this.sumMaterial.check = global::ManagedLeakDetector.CheckRelation(typeof(global::UnityEngine.Material), this.searchType);
			this.sumTexture.check = global::ManagedLeakDetector.CheckRelation(typeof(global::UnityEngine.Texture), this.searchType);
			this.sumMesh.check = global::ManagedLeakDetector.CheckRelation(typeof(global::UnityEngine.Mesh), this.searchType);
			this.sumAudioClip.check = global::ManagedLeakDetector.CheckRelation(typeof(global::UnityEngine.AudioClip), this.searchType);
			this.sumAnimationClip.check = global::ManagedLeakDetector.CheckRelation(typeof(global::UnityEngine.AnimationClip), this.searchType);
			foreach (global::UnityEngine.Object @object in global::UnityEngine.Object.FindObjectsOfType(this.searchType))
			{
				global::System.Type type = @object.GetType();
				global::ManagedLeakDetector.Counter counter2;
				if (dictionary.TryGetValue(type, out counter2))
				{
					counter2.actualInstanceCount++;
				}
				else
				{
					dictionary.Add(type, counter2 = new global::ManagedLeakDetector.Counter
					{
						type = type,
						actualInstanceCount = 1
					});
				}
				if (this.sumComponent.check && typeof(global::UnityEngine.Component).IsAssignableFrom(type))
				{
					this.sumComponent.total = this.sumComponent.total + 1;
					if (this.sumBehaviour.check && typeof(global::UnityEngine.Behaviour).IsAssignableFrom(type))
					{
						if (((global::UnityEngine.Behaviour)@object).enabled)
						{
							this.sumComponent.enabled = this.sumComponent.enabled + 1;
							counter2.enabledCount++;
							this.sumBehaviour.enabled = this.sumBehaviour.enabled + 1;
							this.sumBehaviour.total = this.sumBehaviour.total + 1;
							if (this.sumAnimation.check && typeof(global::UnityEngine.Animation).IsAssignableFrom(type))
							{
								this.sumAnimation.enabled = this.sumAnimation.enabled + 1;
								this.sumAnimation.total = this.sumAnimation.total + 1;
							}
						}
						else if (this.sumAnimation.check && typeof(global::UnityEngine.Animation).IsAssignableFrom(type))
						{
							this.sumAnimation.total = this.sumAnimation.total + 1;
						}
					}
					else if (this.sumRenderer.check && typeof(global::UnityEngine.Renderer).IsAssignableFrom(type))
					{
						this.sumRenderer.total = this.sumRenderer.total + 1;
						if (((global::UnityEngine.Renderer)@object).enabled)
						{
							this.sumComponent.enabled = this.sumComponent.enabled + 1;
							this.sumRenderer.enabled = this.sumRenderer.enabled + 1;
							counter2.enabledCount++;
						}
					}
					else if (this.sumCollider.check && typeof(global::UnityEngine.Collider).IsAssignableFrom(type))
					{
						this.sumCollider.total = this.sumCollider.total + 1;
						if (((global::UnityEngine.Collider)@object).enabled)
						{
							this.sumComponent.enabled = this.sumComponent.enabled + 1;
							this.sumCollider.enabled = this.sumCollider.enabled + 1;
							counter2.enabledCount++;
						}
					}
					else if (this.sumParticleSystem.check && typeof(global::UnityEngine.ParticleSystem).IsAssignableFrom(type))
					{
						this.sumParticleSystem.total = this.sumParticleSystem.total + 1;
						if (((global::UnityEngine.ParticleSystem)@object).IsAlive())
						{
							counter2.enabledCount++;
							this.sumParticleSystem.enabled = this.sumParticleSystem.enabled + 1;
							this.sumComponent.enabled = this.sumComponent.enabled + 1;
						}
					}
					else if (this.sumCloth.check && typeof(global::UnityEngine.Cloth).IsAssignableFrom(type))
					{
						this.sumCloth.total = this.sumCloth.total + 1;
						if (((global::UnityEngine.Cloth)@object).enabled)
						{
							counter2.enabledCount++;
							this.sumComponent.enabled = this.sumComponent.enabled + 1;
							this.sumCloth.enabled = this.sumCloth.enabled + 1;
						}
					}
					else if (this.sumParticleEmitter.check && typeof(global::UnityEngine.ParticleEmitter).IsAssignableFrom(type))
					{
						this.sumParticleEmitter.total = this.sumParticleEmitter.total + 1;
						if (((global::UnityEngine.ParticleEmitter)@object).enabled)
						{
							counter2.enabledCount++;
							this.sumParticleEmitter.enabled = this.sumParticleEmitter.enabled + 1;
							this.sumComponent.enabled = this.sumComponent.enabled + 1;
						}
					}
				}
				else if (this.sumGameObject.check && typeof(global::UnityEngine.GameObject).IsAssignableFrom(type))
				{
					this.sumGameObject.total = this.sumGameObject.total + 1;
					if (((global::UnityEngine.GameObject)@object).activeInHierarchy)
					{
						this.sumGameObject.enabled = this.sumGameObject.enabled + 1;
						counter2.enabledCount++;
					}
				}
				else if (this.sumMaterial.check && typeof(global::UnityEngine.Material).IsAssignableFrom(type))
				{
					this.sumMaterial.total = this.sumMaterial.total + 1;
				}
				else if (this.sumTexture.check && typeof(global::UnityEngine.Texture).IsAssignableFrom(type))
				{
					this.sumTexture.total = this.sumTexture.total + 1;
				}
				else if (this.sumAudioClip.check && typeof(global::UnityEngine.AudioClip).IsAssignableFrom(type))
				{
					this.sumAudioClip.total = this.sumAudioClip.total + 1;
				}
				else if (this.sumAnimationClip.check && typeof(global::UnityEngine.AnimationClip).IsAssignableFrom(type))
				{
					this.sumAnimationClip.total = this.sumAnimationClip.total + 1;
				}
				else if (this.sumMesh.check && typeof(global::UnityEngine.Mesh).IsAssignableFrom(type))
				{
					this.sumMesh.total = this.sumMesh.total + 1;
				}
				else if (this.sumScriptableObject.check && typeof(global::UnityEngine.ScriptableObject).IsAssignableFrom(type))
				{
					this.sumScriptableObject.total = this.sumScriptableObject.total + 1;
				}
				if (type != this.minType)
				{
					for (type = type.BaseType; type != typeof(global::UnityEngine.Object); type = type.BaseType)
					{
						if (dictionary.TryGetValue(type, out counter2))
						{
							counter2.derivedInstanceCount++;
						}
						else
						{
							dictionary.Add(type, new global::ManagedLeakDetector.Counter
							{
								type = type,
								derivedInstanceCount = 1
							});
						}
					}
					counter.derivedInstanceCount++;
				}
			}
			global::System.Collections.Generic.List<global::ManagedLeakDetector.Counter> list = new global::System.Collections.Generic.List<global::ManagedLeakDetector.Counter>(dictionary.Values);
			list.Sort(delegate(global::ManagedLeakDetector.Counter firstPair, global::ManagedLeakDetector.Counter nextPair)
			{
				int num = nextPair.actualInstanceCount.CompareTo(firstPair.actualInstanceCount);
				if (num == 0)
				{
					return nextPair.derivedInstanceCount.CompareTo(firstPair.derivedInstanceCount);
				}
				return num;
			});
			this.counters = list.ToArray();
			this.complete = true;
		}

		// Token: 0x06000D23 RID: 3363 RVA: 0x00033940 File Offset: 0x00031B40
		private static void Print(global::System.Text.StringBuilder sb, ref global::ManagedLeakDetector.SumEnable en)
		{
			if (en.check)
			{
				if (en.enabled != 0)
				{
					sb.AppendFormat("{0} {1} ({2})\r\n", en.name, en.total, en.enabled);
				}
				else if (en.total != 0)
				{
					sb.AppendFormat("{0} {1}\r\n", en.name, en.total);
				}
			}
		}

		// Token: 0x06000D24 RID: 3364 RVA: 0x000339B8 File Offset: 0x00031BB8
		public override string ToString()
		{
			this.Read();
			global::System.Text.StringBuilder stringBuilder = new global::System.Text.StringBuilder();
			stringBuilder.AppendLine("Instances, Deriving Instances, Type, (# Enabled [if not shown 0] )");
			foreach (global::ManagedLeakDetector.Counter counter in this.counters)
			{
				if (counter.enabledCount != 0)
				{
					stringBuilder.AppendFormat("{0,8} [{1,8}] {2} ({3} enabled)\r\n", new object[]
					{
						counter.actualInstanceCount,
						counter.derivedInstanceCount,
						counter.type,
						counter.enabledCount
					});
				}
				else
				{
					stringBuilder.AppendFormat("{0,8} [{1,8}] {2}\r\n", counter.actualInstanceCount, counter.derivedInstanceCount, counter.type);
				}
			}
			stringBuilder.AppendLine("basic counters: if not there, there is none.");
			global::ManagedLeakDetector.ReadResult.Print(stringBuilder, ref this.sumComponent);
			global::ManagedLeakDetector.ReadResult.Print(stringBuilder, ref this.sumBehaviour);
			global::ManagedLeakDetector.ReadResult.Print(stringBuilder, ref this.sumRenderer);
			global::ManagedLeakDetector.ReadResult.Print(stringBuilder, ref this.sumCollider);
			global::ManagedLeakDetector.ReadResult.Print(stringBuilder, ref this.sumCloth);
			global::ManagedLeakDetector.ReadResult.Print(stringBuilder, ref this.sumGameObject);
			global::ManagedLeakDetector.ReadResult.Print(stringBuilder, ref this.sumScriptableObject);
			global::ManagedLeakDetector.ReadResult.Print(stringBuilder, ref this.sumMaterial);
			global::ManagedLeakDetector.ReadResult.Print(stringBuilder, ref this.sumTexture);
			global::ManagedLeakDetector.ReadResult.Print(stringBuilder, ref this.sumAnimation);
			global::ManagedLeakDetector.ReadResult.Print(stringBuilder, ref this.sumMesh);
			global::ManagedLeakDetector.ReadResult.Print(stringBuilder, ref this.sumAudioClip);
			global::ManagedLeakDetector.ReadResult.Print(stringBuilder, ref this.sumAnimationClip);
			global::ManagedLeakDetector.ReadResult.Print(stringBuilder, ref this.sumParticleSystem);
			global::ManagedLeakDetector.ReadResult.Print(stringBuilder, ref this.sumParticleEmitter);
			stringBuilder.AppendFormat("Count done for search {0} (min:{1})", this.searchType, this.minType);
			return stringBuilder.ToString();
		}

		// Token: 0x06000D25 RID: 3365 RVA: 0x00033B58 File Offset: 0x00031D58
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static int <Read>m__3(global::ManagedLeakDetector.Counter firstPair, global::ManagedLeakDetector.Counter nextPair)
		{
			int num = nextPair.actualInstanceCount.CompareTo(firstPair.actualInstanceCount);
			if (num == 0)
			{
				return nextPair.derivedInstanceCount.CompareTo(firstPair.derivedInstanceCount);
			}
			return num;
		}

		// Token: 0x0400085E RID: 2142
		public global::ManagedLeakDetector.SumEnable sumComponent;

		// Token: 0x0400085F RID: 2143
		public global::ManagedLeakDetector.SumEnable sumBehaviour;

		// Token: 0x04000860 RID: 2144
		public global::ManagedLeakDetector.SumEnable sumRenderer;

		// Token: 0x04000861 RID: 2145
		public global::ManagedLeakDetector.SumEnable sumCollider;

		// Token: 0x04000862 RID: 2146
		public global::ManagedLeakDetector.SumEnable sumCloth;

		// Token: 0x04000863 RID: 2147
		public global::ManagedLeakDetector.SumEnable sumGameObject;

		// Token: 0x04000864 RID: 2148
		public global::ManagedLeakDetector.SumEnable sumScriptableObject;

		// Token: 0x04000865 RID: 2149
		public global::ManagedLeakDetector.SumEnable sumMaterial;

		// Token: 0x04000866 RID: 2150
		public global::ManagedLeakDetector.SumEnable sumTexture;

		// Token: 0x04000867 RID: 2151
		public global::ManagedLeakDetector.SumEnable sumAnimation;

		// Token: 0x04000868 RID: 2152
		public global::ManagedLeakDetector.SumEnable sumMesh;

		// Token: 0x04000869 RID: 2153
		public global::ManagedLeakDetector.SumEnable sumAudioClip;

		// Token: 0x0400086A RID: 2154
		public global::ManagedLeakDetector.SumEnable sumAnimationClip;

		// Token: 0x0400086B RID: 2155
		public global::ManagedLeakDetector.SumEnable sumParticleEmitter;

		// Token: 0x0400086C RID: 2156
		public global::ManagedLeakDetector.SumEnable sumParticleSystem;

		// Token: 0x0400086D RID: 2157
		public bool complete;

		// Token: 0x0400086E RID: 2158
		public global::ManagedLeakDetector.Counter[] counters;

		// Token: 0x0400086F RID: 2159
		public readonly global::System.Type searchType;

		// Token: 0x04000870 RID: 2160
		public readonly global::System.Type minType;

		// Token: 0x04000871 RID: 2161
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private static global::System.Comparison<global::ManagedLeakDetector.Counter> <>f__am$cache13;
	}

	// Token: 0x020001C2 RID: 450
	private struct SumEnable
	{
		// Token: 0x1700034C RID: 844
		// (get) Token: 0x06000D26 RID: 3366 RVA: 0x00033B90 File Offset: 0x00031D90
		public int disabled
		{
			get
			{
				return this.total - this.enabled;
			}
		}

		// Token: 0x06000D27 RID: 3367 RVA: 0x00033BA0 File Offset: 0x00031DA0
		public void Reset()
		{
			this.total = 0;
			this.enabled = 0;
		}

		// Token: 0x04000872 RID: 2162
		public bool check;

		// Token: 0x04000873 RID: 2163
		public int total;

		// Token: 0x04000874 RID: 2164
		public int enabled;

		// Token: 0x04000875 RID: 2165
		public string name;

		// Token: 0x04000876 RID: 2166
		public global::System.Type type;
	}
}
