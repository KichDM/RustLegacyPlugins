using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

// Token: 0x0200006A RID: 106
public static class GameConstant
{
	// Token: 0x060002E6 RID: 742 RVA: 0x0000E90C File Offset: 0x0000CB0C
	public static global::GameConstant.Tag GetTag(this global::UnityEngine.GameObject gameObject)
	{
		return (global::GameConstant.Tag)gameObject;
	}

	// Token: 0x060002E7 RID: 743 RVA: 0x0000E914 File Offset: 0x0000CB14
	public static global::GameConstant.Tag GetTag(this global::UnityEngine.Component component)
	{
		return (global::GameConstant.Tag)component;
	}

	// Token: 0x0200006B RID: 107
	public static class Layer
	{
		// Token: 0x0400020F RID: 527
		public const int kMask_BloodSplatter = 0x80401;

		// Token: 0x04000210 RID: 528
		public const int kMask_BulletImpactWorld = 0x1C1411;

		// Token: 0x04000211 RID: 529
		public const int kMask_BulletImpactCharacter = 0x18020000;

		// Token: 0x04000212 RID: 530
		public const int kMask_BulletImpact = 0x183E1411;

		// Token: 0x04000213 RID: 531
		public const int kMask_BlocksSprite = 0x80401;

		// Token: 0x04000214 RID: 532
		public const int kMask_InfoLabel = -0x4010005;

		// Token: 0x04000215 RID: 533
		public const int kMask_Use = -0xC030005;

		// Token: 0x04000216 RID: 534
		public const int kMask_SpawnLand = 0x80401;

		// Token: 0x04000217 RID: 535
		public const int kMask_ClientExplosion = 0x8000000;

		// Token: 0x04000218 RID: 536
		public const int kMask_ServerExplosion = 0x10360401;

		// Token: 0x04000219 RID: 537
		public const int kMask_Deployable = -0x1C270005;

		// Token: 0x0400021A RID: 538
		public const int kMask_WildlifeMove = -0x1C270005;

		// Token: 0x0400021B RID: 539
		public const int kMask_PlayerMovement = 0x20180403;

		// Token: 0x0400021C RID: 540
		public const int kMask_PlayerPusher = 0x140000;

		// Token: 0x0400021D RID: 541
		public const int kMask_Melee = 0x183E1411;

		// Token: 0x0200006C RID: 108
		public static class Default
		{
			// Token: 0x0400021E RID: 542
			public const string name = "Default";

			// Token: 0x0400021F RID: 543
			public const int index = 0;

			// Token: 0x04000220 RID: 544
			public const int mask = 1;
		}

		// Token: 0x0200006D RID: 109
		public static class TransparentFX
		{
			// Token: 0x04000221 RID: 545
			public const string name = "TransparentFX";

			// Token: 0x04000222 RID: 546
			public const int index = 1;

			// Token: 0x04000223 RID: 547
			public const int mask = 2;
		}

		// Token: 0x0200006E RID: 110
		public static class IgnoreRaycast
		{
			// Token: 0x04000224 RID: 548
			public const string name = "Ignore Raycast";

			// Token: 0x04000225 RID: 549
			public const int index = 2;

			// Token: 0x04000226 RID: 550
			public const int mask = 4;
		}

		// Token: 0x0200006F RID: 111
		public static class Water
		{
			// Token: 0x04000227 RID: 551
			public const string name = "Water";

			// Token: 0x04000228 RID: 552
			public const int index = 4;

			// Token: 0x04000229 RID: 553
			public const int mask = 0x10;
		}

		// Token: 0x02000070 RID: 112
		public static class NGUILayer
		{
			// Token: 0x0400022A RID: 554
			public const string name = "NGUILayer";

			// Token: 0x0400022B RID: 555
			public const int index = 8;

			// Token: 0x0400022C RID: 556
			public const int mask = 0x100;
		}

		// Token: 0x02000071 RID: 113
		public static class NGUILayer2D
		{
			// Token: 0x0400022D RID: 557
			public const string name = "NGUILayer2D";

			// Token: 0x0400022E RID: 558
			public const int index = 9;

			// Token: 0x0400022F RID: 559
			public const int mask = 0x200;
		}

		// Token: 0x02000072 RID: 114
		public static class Static
		{
			// Token: 0x04000230 RID: 560
			public const string name = "Static";

			// Token: 0x04000231 RID: 561
			public const int index = 0xA;

			// Token: 0x04000232 RID: 562
			public const int mask = 0x400;
		}

		// Token: 0x02000073 RID: 115
		public static class Sprite
		{
			// Token: 0x04000233 RID: 563
			public const string name = "Sprite";

			// Token: 0x04000234 RID: 564
			public const int index = 0xB;

			// Token: 0x04000235 RID: 565
			public const int mask = 0x800;
		}

		// Token: 0x02000074 RID: 116
		public static class CullStatic
		{
			// Token: 0x04000236 RID: 566
			public const string name = "CullStatic";

			// Token: 0x04000237 RID: 567
			public const int index = 0xC;

			// Token: 0x04000238 RID: 568
			public const int mask = 0x1000;
		}

		// Token: 0x02000075 RID: 117
		public static class ViewModel
		{
			// Token: 0x04000239 RID: 569
			public const string name = "View Model";

			// Token: 0x0400023A RID: 570
			public const int index = 0xD;

			// Token: 0x0400023B RID: 571
			public const int mask = 0x2000;
		}

		// Token: 0x02000076 RID: 118
		public static class CharacterCollision
		{
			// Token: 0x0400023C RID: 572
			public const string name = "Character Collision";

			// Token: 0x0400023D RID: 573
			public const int index = 0x10;

			// Token: 0x0400023E RID: 574
			public const int mask = 0x10000;
		}

		// Token: 0x02000077 RID: 119
		public static class Hitbox
		{
			// Token: 0x0400023F RID: 575
			public const string name = "Hitbox";

			// Token: 0x04000240 RID: 576
			public const int index = 0x11;

			// Token: 0x04000241 RID: 577
			public const int mask = 0x20000;
		}

		// Token: 0x02000078 RID: 120
		public static class Debris
		{
			// Token: 0x04000242 RID: 578
			public const string name = "Debris";

			// Token: 0x04000243 RID: 579
			public const int index = 0x12;

			// Token: 0x04000244 RID: 580
			public const int mask = 0x40000;
		}

		// Token: 0x02000079 RID: 121
		public static class Terrain
		{
			// Token: 0x04000245 RID: 581
			public const string name = "Terrain";

			// Token: 0x04000246 RID: 582
			public const int index = 0x13;

			// Token: 0x04000247 RID: 583
			public const int mask = 0x80000;
		}

		// Token: 0x0200007A RID: 122
		public static class Mechanical
		{
			// Token: 0x04000248 RID: 584
			public const string name = "Mechanical";

			// Token: 0x04000249 RID: 585
			public const int index = 0x14;

			// Token: 0x0400024A RID: 586
			public const int mask = 0x100000;
		}

		// Token: 0x0200007B RID: 123
		public static class HitOnly
		{
			// Token: 0x0400024B RID: 587
			public const string name = "HitOnly";

			// Token: 0x0400024C RID: 588
			public const int index = 0x15;

			// Token: 0x0400024D RID: 589
			public const int mask = 0x200000;
		}

		// Token: 0x0200007C RID: 124
		public static class MeshBatched
		{
			// Token: 0x0400024E RID: 590
			public const string name = "MeshBatched";

			// Token: 0x0400024F RID: 591
			public const int index = 0x16;

			// Token: 0x04000250 RID: 592
			public const int mask = 0x400000;
		}

		// Token: 0x0200007D RID: 125
		public static class Skybox
		{
			// Token: 0x04000251 RID: 593
			public const string name = "Skybox";

			// Token: 0x04000252 RID: 594
			public const int index = 0x17;

			// Token: 0x04000253 RID: 595
			public const int mask = 0x800000;
		}

		// Token: 0x0200007E RID: 126
		public static class Zone
		{
			// Token: 0x04000254 RID: 596
			public const string name = "Zone";

			// Token: 0x04000255 RID: 597
			public const int index = 0x1A;

			// Token: 0x04000256 RID: 598
			public const int mask = 0x4000000;
		}

		// Token: 0x0200007F RID: 127
		public static class Ragdoll
		{
			// Token: 0x04000257 RID: 599
			public const string name = "Ragdoll";

			// Token: 0x04000258 RID: 600
			public const int index = 0x1B;

			// Token: 0x04000259 RID: 601
			public const int mask = 0x8000000;
		}

		// Token: 0x02000080 RID: 128
		public static class Vehicle
		{
			// Token: 0x0400025A RID: 602
			public const string name = "Vehicle";

			// Token: 0x0400025B RID: 603
			public const int index = 0x1C;

			// Token: 0x0400025C RID: 604
			public const int mask = 0x10000000;
		}

		// Token: 0x02000081 RID: 129
		public static class PlayerClip
		{
			// Token: 0x0400025D RID: 605
			public const string name = "PlayerClip";

			// Token: 0x0400025E RID: 606
			public const int index = 0x1D;

			// Token: 0x0400025F RID: 607
			public const int mask = 0x20000000;
		}

		// Token: 0x02000082 RID: 130
		public static class GameUI
		{
			// Token: 0x04000260 RID: 608
			public const string name = "GameUI";

			// Token: 0x04000261 RID: 609
			public const int index = 0x1F;

			// Token: 0x04000262 RID: 610
			public const int mask = -0x80000000;
		}
	}

	// Token: 0x02000083 RID: 131
	private struct TagInfo
	{
		// Token: 0x060002E8 RID: 744 RVA: 0x0000E91C File Offset: 0x0000CB1C
		public TagInfo(string tag, int tagNumber, bool builtin)
		{
			this.tag = tag;
			this.tagNumber = tagNumber;
			this.builtin = builtin;
			this.valid = true;
		}

		// Token: 0x04000263 RID: 611
		public readonly string tag;

		// Token: 0x04000264 RID: 612
		public readonly int tagNumber;

		// Token: 0x04000265 RID: 613
		public readonly bool builtin;

		// Token: 0x04000266 RID: 614
		public readonly bool valid;
	}

	// Token: 0x02000084 RID: 132
	public struct Tag
	{
		// Token: 0x060002E9 RID: 745 RVA: 0x0000E93C File Offset: 0x0000CB3C
		private Tag(int tagNumber)
		{
			this.tagNumber = tagNumber;
		}

		// Token: 0x060002EA RID: 746 RVA: 0x0000E948 File Offset: 0x0000CB48
		static Tag()
		{
			foreach (global::System.Type type in typeof(global::GameConstant.Tag).GetNestedTypes())
			{
				global::System.Reflection.FieldInfo field = type.GetField("tag", global::System.Reflection.BindingFlags.Static | global::System.Reflection.BindingFlags.Public);
				global::System.Reflection.FieldInfo field2 = type.GetField("tagNumber", global::System.Reflection.BindingFlags.Static | global::System.Reflection.BindingFlags.Public);
				global::System.Reflection.FieldInfo field3 = type.GetField("builtin", global::System.Reflection.BindingFlags.Static | global::System.Reflection.BindingFlags.Public);
				if (field != null && field2 != null && field3 != null)
				{
					try
					{
						int num = (int)field2.GetValue(null);
						string tag = (string)field.GetValue(null);
						bool builtin = (bool)field3.GetValue(null);
						global::GameConstant.Tag.Info[num] = new global::GameConstant.TagInfo(tag, num, builtin);
					}
					catch (global::System.Exception ex)
					{
						global::UnityEngine.Debug.LogError(ex);
					}
				}
			}
			for (int j = 0; j < 0x17; j++)
			{
				int num2;
				if (!global::GameConstant.Tag.Info[j].valid)
				{
					global::UnityEngine.Debug.LogWarning(string.Format("Theres no tag specified for index {0}", j));
				}
				else if (global::GameConstant.Tag.Dictionary.TryGetValue(global::GameConstant.Tag.Info[j].tag, out num2))
				{
					global::UnityEngine.Debug.LogWarning(string.Format("Duplicate tag at index {0} will be overriden by predicessor at index {1}", j, num2));
				}
				else
				{
					global::GameConstant.Tag.Dictionary.Add(global::GameConstant.Tag.Info[j].tag, j);
				}
			}
		}

		// Token: 0x17000075 RID: 117
		// (get) Token: 0x060002EB RID: 747 RVA: 0x0000EAF8 File Offset: 0x0000CCF8
		public string tag
		{
			get
			{
				return global::GameConstant.Tag.Info[this.tagNumber].tag;
			}
		}

		// Token: 0x17000076 RID: 118
		// (get) Token: 0x060002EC RID: 748 RVA: 0x0000EB10 File Offset: 0x0000CD10
		public bool builtin
		{
			get
			{
				return global::GameConstant.Tag.Info[this.tagNumber].builtin;
			}
		}

		// Token: 0x060002ED RID: 749 RVA: 0x0000EB28 File Offset: 0x0000CD28
		public bool Contains(global::UnityEngine.GameObject gameObject)
		{
			return gameObject && gameObject.CompareTag(global::GameConstant.Tag.Info[this.tagNumber].tag);
		}

		// Token: 0x060002EE RID: 750 RVA: 0x0000EB54 File Offset: 0x0000CD54
		public bool Contains(global::UnityEngine.Component component)
		{
			return component && component.CompareTag(global::GameConstant.Tag.Info[this.tagNumber].tag);
		}

		// Token: 0x060002EF RID: 751 RVA: 0x0000EB80 File Offset: 0x0000CD80
		public static int Index(global::UnityEngine.GameObject gameObject)
		{
			for (int i = 0; i < 0x17; i++)
			{
				if (gameObject.CompareTag(global::GameConstant.Tag.Info[i].tag))
				{
					return i;
				}
			}
			throw new global::System.InvalidProgramException(string.Format("There is a tag missing in this class for \"{0}\"", gameObject.tag));
		}

		// Token: 0x060002F0 RID: 752 RVA: 0x0000EBD4 File Offset: 0x0000CDD4
		public static int Index(global::UnityEngine.Component component)
		{
			global::UnityEngine.GameObject gameObject = component.gameObject;
			for (int i = 0; i < 0x17; i++)
			{
				if (gameObject.CompareTag(global::GameConstant.Tag.Info[i].tag))
				{
					return i;
				}
			}
			throw new global::System.InvalidProgramException(string.Format("There is a tag missing in this class for \"{0}\"", gameObject.tag));
		}

		// Token: 0x060002F1 RID: 753 RVA: 0x0000EC30 File Offset: 0x0000CE30
		public static int Index(string tag)
		{
			int result;
			if (global::GameConstant.Tag.Dictionary.TryGetValue(tag, out result))
			{
				return result;
			}
			throw new global::System.InvalidProgramException(string.Format("There is a tag missing in this class for \"{0}\"", tag));
		}

		// Token: 0x060002F2 RID: 754 RVA: 0x0000EC64 File Offset: 0x0000CE64
		public static explicit operator global::GameConstant.Tag(global::UnityEngine.GameObject gameObject)
		{
			return new global::GameConstant.Tag(global::GameConstant.Tag.Index(gameObject));
		}

		// Token: 0x060002F3 RID: 755 RVA: 0x0000EC74 File Offset: 0x0000CE74
		public static explicit operator global::GameConstant.Tag(global::UnityEngine.Component component)
		{
			return new global::GameConstant.Tag(global::GameConstant.Tag.Index(component));
		}

		// Token: 0x04000267 RID: 615
		private const int kBuiltinTagCount = 7;

		// Token: 0x04000268 RID: 616
		public const int kTagCount = 0x17;

		// Token: 0x04000269 RID: 617
		public const int kCustomTagCount = 0x10;

		// Token: 0x0400026A RID: 618
		public readonly int tagNumber;

		// Token: 0x0400026B RID: 619
		private static readonly global::GameConstant.TagInfo[] Info = new global::GameConstant.TagInfo[0x17];

		// Token: 0x0400026C RID: 620
		private static readonly global::System.Collections.Generic.Dictionary<string, int> Dictionary = new global::System.Collections.Generic.Dictionary<string, int>(0x17);

		// Token: 0x02000085 RID: 133
		public static class Untagged
		{
			// Token: 0x060002F4 RID: 756 RVA: 0x0000EC84 File Offset: 0x0000CE84
			// Note: this type is marked as 'beforefieldinit'.
			static Untagged()
			{
			}

			// Token: 0x0400026D RID: 621
			public const string tag = "Untagged";

			// Token: 0x0400026E RID: 622
			public const int tagNumber = 0;

			// Token: 0x0400026F RID: 623
			public const bool builtin = true;

			// Token: 0x04000270 RID: 624
			public static readonly global::GameConstant.Tag value = new global::GameConstant.Tag(0);
		}

		// Token: 0x02000086 RID: 134
		public static class Respawn
		{
			// Token: 0x060002F5 RID: 757 RVA: 0x0000EC94 File Offset: 0x0000CE94
			// Note: this type is marked as 'beforefieldinit'.
			static Respawn()
			{
			}

			// Token: 0x04000271 RID: 625
			public const string tag = "Respawn";

			// Token: 0x04000272 RID: 626
			public const int tagNumber = 1;

			// Token: 0x04000273 RID: 627
			public const bool builtin = true;

			// Token: 0x04000274 RID: 628
			public static readonly global::GameConstant.Tag value = new global::GameConstant.Tag(1);
		}

		// Token: 0x02000087 RID: 135
		public static class Finish
		{
			// Token: 0x060002F6 RID: 758 RVA: 0x0000ECA4 File Offset: 0x0000CEA4
			// Note: this type is marked as 'beforefieldinit'.
			static Finish()
			{
			}

			// Token: 0x04000275 RID: 629
			public const string tag = "Finish";

			// Token: 0x04000276 RID: 630
			public const int tagNumber = 2;

			// Token: 0x04000277 RID: 631
			public const bool builtin = true;

			// Token: 0x04000278 RID: 632
			public static readonly global::GameConstant.Tag value = new global::GameConstant.Tag(2);
		}

		// Token: 0x02000088 RID: 136
		public static class EditorOnly
		{
			// Token: 0x060002F7 RID: 759 RVA: 0x0000ECB4 File Offset: 0x0000CEB4
			// Note: this type is marked as 'beforefieldinit'.
			static EditorOnly()
			{
			}

			// Token: 0x04000279 RID: 633
			public const string tag = "EditorOnly";

			// Token: 0x0400027A RID: 634
			public const int tagNumber = 3;

			// Token: 0x0400027B RID: 635
			public const bool builtin = true;

			// Token: 0x0400027C RID: 636
			public static readonly global::GameConstant.Tag value = new global::GameConstant.Tag(3);
		}

		// Token: 0x02000089 RID: 137
		public static class MainCamera
		{
			// Token: 0x060002F8 RID: 760 RVA: 0x0000ECC4 File Offset: 0x0000CEC4
			// Note: this type is marked as 'beforefieldinit'.
			static MainCamera()
			{
			}

			// Token: 0x0400027D RID: 637
			public const string tag = "MainCamera";

			// Token: 0x0400027E RID: 638
			public const int tagNumber = 4;

			// Token: 0x0400027F RID: 639
			public const bool builtin = true;

			// Token: 0x04000280 RID: 640
			public static readonly global::GameConstant.Tag value = new global::GameConstant.Tag(4);
		}

		// Token: 0x0200008A RID: 138
		public static class Player
		{
			// Token: 0x060002F9 RID: 761 RVA: 0x0000ECD4 File Offset: 0x0000CED4
			// Note: this type is marked as 'beforefieldinit'.
			static Player()
			{
			}

			// Token: 0x04000281 RID: 641
			public const string tag = "Player";

			// Token: 0x04000282 RID: 642
			public const int tagNumber = 5;

			// Token: 0x04000283 RID: 643
			public const bool builtin = true;

			// Token: 0x04000284 RID: 644
			public static readonly global::GameConstant.Tag value = new global::GameConstant.Tag(5);
		}

		// Token: 0x0200008B RID: 139
		public static class GameController
		{
			// Token: 0x060002FA RID: 762 RVA: 0x0000ECE4 File Offset: 0x0000CEE4
			// Note: this type is marked as 'beforefieldinit'.
			static GameController()
			{
			}

			// Token: 0x04000285 RID: 645
			public const string tag = "GameController";

			// Token: 0x04000286 RID: 646
			public const int tagNumber = 6;

			// Token: 0x04000287 RID: 647
			public const bool builtin = true;

			// Token: 0x04000288 RID: 648
			public static readonly global::GameConstant.Tag value = new global::GameConstant.Tag(6);
		}

		// Token: 0x0200008C RID: 140
		public static class SkyboxCamera
		{
			// Token: 0x060002FB RID: 763 RVA: 0x0000ECF4 File Offset: 0x0000CEF4
			// Note: this type is marked as 'beforefieldinit'.
			static SkyboxCamera()
			{
			}

			// Token: 0x04000289 RID: 649
			public const string tag = "Skybox Camera";

			// Token: 0x0400028A RID: 650
			public const int tagNumber = 7;

			// Token: 0x0400028B RID: 651
			public const bool builtin = false;

			// Token: 0x0400028C RID: 652
			public static readonly global::GameConstant.Tag value = new global::GameConstant.Tag(7);
		}

		// Token: 0x0200008D RID: 141
		public static class MainTerrain
		{
			// Token: 0x060002FC RID: 764 RVA: 0x0000ED04 File Offset: 0x0000CF04
			// Note: this type is marked as 'beforefieldinit'.
			static MainTerrain()
			{
			}

			// Token: 0x0400028D RID: 653
			public const string tag = "Main Terrain";

			// Token: 0x0400028E RID: 654
			public const int tagNumber = 8;

			// Token: 0x0400028F RID: 655
			public const bool builtin = false;

			// Token: 0x04000290 RID: 656
			public static readonly global::GameConstant.Tag value = new global::GameConstant.Tag(8);
		}

		// Token: 0x0200008E RID: 142
		public static class TreeCollider
		{
			// Token: 0x060002FD RID: 765 RVA: 0x0000ED14 File Offset: 0x0000CF14
			// Note: this type is marked as 'beforefieldinit'.
			static TreeCollider()
			{
			}

			// Token: 0x04000291 RID: 657
			public const string tag = "Tree Collider";

			// Token: 0x04000292 RID: 658
			public const int tagNumber = 9;

			// Token: 0x04000293 RID: 659
			public const bool builtin = false;

			// Token: 0x04000294 RID: 660
			public static readonly global::GameConstant.Tag value = new global::GameConstant.Tag(9);
		}

		// Token: 0x0200008F RID: 143
		public static class Meat
		{
			// Token: 0x060002FE RID: 766 RVA: 0x0000ED24 File Offset: 0x0000CF24
			// Note: this type is marked as 'beforefieldinit'.
			static Meat()
			{
			}

			// Token: 0x04000295 RID: 661
			public const string tag = "Meat";

			// Token: 0x04000296 RID: 662
			public const int tagNumber = 0xA;

			// Token: 0x04000297 RID: 663
			public const bool builtin = false;

			// Token: 0x04000298 RID: 664
			public static readonly global::GameConstant.Tag value = new global::GameConstant.Tag(0xA);
		}

		// Token: 0x02000090 RID: 144
		public static class Shelter
		{
			// Token: 0x060002FF RID: 767 RVA: 0x0000ED34 File Offset: 0x0000CF34
			// Note: this type is marked as 'beforefieldinit'.
			static Shelter()
			{
			}

			// Token: 0x04000299 RID: 665
			public const string tag = "Shelter";

			// Token: 0x0400029A RID: 666
			public const int tagNumber = 0xB;

			// Token: 0x0400029B RID: 667
			public const bool builtin = false;

			// Token: 0x0400029C RID: 668
			public static readonly global::GameConstant.Tag value = new global::GameConstant.Tag(0xB);
		}

		// Token: 0x02000091 RID: 145
		public static class Door
		{
			// Token: 0x06000300 RID: 768 RVA: 0x0000ED44 File Offset: 0x0000CF44
			// Note: this type is marked as 'beforefieldinit'.
			static Door()
			{
			}

			// Token: 0x0400029D RID: 669
			public const string tag = "Door";

			// Token: 0x0400029E RID: 670
			public const int tagNumber = 0xC;

			// Token: 0x0400029F RID: 671
			public const bool builtin = false;

			// Token: 0x040002A0 RID: 672
			public static readonly global::GameConstant.Tag value = new global::GameConstant.Tag(0xC);
		}

		// Token: 0x02000092 RID: 146
		public static class Barricade
		{
			// Token: 0x06000301 RID: 769 RVA: 0x0000ED54 File Offset: 0x0000CF54
			// Note: this type is marked as 'beforefieldinit'.
			static Barricade()
			{
			}

			// Token: 0x040002A1 RID: 673
			public const string tag = "Barricade";

			// Token: 0x040002A2 RID: 674
			public const int tagNumber = 0xD;

			// Token: 0x040002A3 RID: 675
			public const bool builtin = false;

			// Token: 0x040002A4 RID: 676
			public static readonly global::GameConstant.Tag value = new global::GameConstant.Tag(0xD);
		}

		// Token: 0x02000093 RID: 147
		public static class StorageBox
		{
			// Token: 0x06000302 RID: 770 RVA: 0x0000ED64 File Offset: 0x0000CF64
			// Note: this type is marked as 'beforefieldinit'.
			static StorageBox()
			{
			}

			// Token: 0x040002A5 RID: 677
			public const string tag = "StorageBox";

			// Token: 0x040002A6 RID: 678
			public const int tagNumber = 0xE;

			// Token: 0x040002A7 RID: 679
			public const bool builtin = false;

			// Token: 0x040002A8 RID: 680
			public static readonly global::GameConstant.Tag value = new global::GameConstant.Tag(0xE);
		}

		// Token: 0x02000094 RID: 148
		public static class MeshBatched
		{
			// Token: 0x06000303 RID: 771 RVA: 0x0000ED74 File Offset: 0x0000CF74
			// Note: this type is marked as 'beforefieldinit'.
			static MeshBatched()
			{
			}

			// Token: 0x040002A9 RID: 681
			public const string tag = "mBC";

			// Token: 0x040002AA RID: 682
			public const int tagNumber = 0xF;

			// Token: 0x040002AB RID: 683
			public const bool builtin = false;

			// Token: 0x040002AC RID: 684
			public static readonly global::GameConstant.Tag value = new global::GameConstant.Tag(0xF);
		}

		// Token: 0x02000095 RID: 149
		public static class RPOSCamera
		{
			// Token: 0x040002AD RID: 685
			public const string tag = "RPOS Camera";

			// Token: 0x040002AE RID: 686
			public const int tagNumber = 0x10;

			// Token: 0x040002AF RID: 687
			public const bool builtin = false;
		}

		// Token: 0x02000096 RID: 150
		public static class FPGrass
		{
			// Token: 0x06000304 RID: 772 RVA: 0x0000ED84 File Offset: 0x0000CF84
			// Note: this type is marked as 'beforefieldinit'.
			static FPGrass()
			{
			}

			// Token: 0x040002B0 RID: 688
			public const string tag = "FPGrass";

			// Token: 0x040002B1 RID: 689
			public const int tagNumber = 0x11;

			// Token: 0x040002B2 RID: 690
			public const bool builtin = false;

			// Token: 0x040002B3 RID: 691
			public static readonly global::GameConstant.Tag value = new global::GameConstant.Tag(0x11);
		}

		// Token: 0x02000097 RID: 151
		public static class ServerOnly
		{
			// Token: 0x06000305 RID: 773 RVA: 0x0000ED94 File Offset: 0x0000CF94
			// Note: this type is marked as 'beforefieldinit'.
			static ServerOnly()
			{
			}

			// Token: 0x040002B4 RID: 692
			public const string tag = "Server Only";

			// Token: 0x040002B5 RID: 693
			public const int tagNumber = 0x12;

			// Token: 0x040002B6 RID: 694
			public const bool builtin = false;

			// Token: 0x040002B7 RID: 695
			public static readonly global::GameConstant.Tag value = new global::GameConstant.Tag(0x12);
		}

		// Token: 0x02000098 RID: 152
		public static class ClientOnly
		{
			// Token: 0x06000306 RID: 774 RVA: 0x0000EDA4 File Offset: 0x0000CFA4
			// Note: this type is marked as 'beforefieldinit'.
			static ClientOnly()
			{
			}

			// Token: 0x040002B8 RID: 696
			public const string tag = "RPOS Camera";

			// Token: 0x040002B9 RID: 697
			public const int tagNumber = 0x13;

			// Token: 0x040002BA RID: 698
			public const bool builtin = false;

			// Token: 0x040002BB RID: 699
			public static readonly global::GameConstant.Tag value = new global::GameConstant.Tag(0x13);
		}

		// Token: 0x02000099 RID: 153
		public static class Folder
		{
			// Token: 0x06000307 RID: 775 RVA: 0x0000EDB4 File Offset: 0x0000CFB4
			// Note: this type is marked as 'beforefieldinit'.
			static Folder()
			{
			}

			// Token: 0x040002BC RID: 700
			public const string tag = "Folder";

			// Token: 0x040002BD RID: 701
			public const int tagNumber = 0x14;

			// Token: 0x040002BE RID: 702
			public const bool builtin = false;

			// Token: 0x040002BF RID: 703
			public static readonly global::GameConstant.Tag value = new global::GameConstant.Tag(0x14);
		}

		// Token: 0x0200009A RID: 154
		public static class ServerFolder
		{
			// Token: 0x06000308 RID: 776 RVA: 0x0000EDC4 File Offset: 0x0000CFC4
			// Note: this type is marked as 'beforefieldinit'.
			static ServerFolder()
			{
			}

			// Token: 0x040002C0 RID: 704
			public const string tag = "Server Folder";

			// Token: 0x040002C1 RID: 705
			public const int tagNumber = 0x15;

			// Token: 0x040002C2 RID: 706
			public const bool builtin = false;

			// Token: 0x040002C3 RID: 707
			public static readonly global::GameConstant.Tag value = new global::GameConstant.Tag(0x15);
		}

		// Token: 0x0200009B RID: 155
		public static class ClientFolder
		{
			// Token: 0x06000309 RID: 777 RVA: 0x0000EDD4 File Offset: 0x0000CFD4
			// Note: this type is marked as 'beforefieldinit'.
			static ClientFolder()
			{
			}

			// Token: 0x040002C4 RID: 708
			public const string tag = "Client Folder";

			// Token: 0x040002C5 RID: 709
			public const int tagNumber = 0x16;

			// Token: 0x040002C6 RID: 710
			public const bool builtin = false;

			// Token: 0x040002C7 RID: 711
			public static readonly global::GameConstant.Tag value = new global::GameConstant.Tag(0x16);
		}
	}
}
