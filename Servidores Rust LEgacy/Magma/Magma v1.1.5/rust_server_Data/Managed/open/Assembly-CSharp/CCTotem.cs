using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using UnityEngine;

// Token: 0x02000302 RID: 770
public abstract class CCTotem : global::UnityEngine.MonoBehaviour
{
	// Token: 0x06001A45 RID: 6725 RVA: 0x00067694 File Offset: 0x00065894
	internal CCTotem()
	{
	}

	// Token: 0x06001A46 RID: 6726 RVA: 0x0006769C File Offset: 0x0006589C
	private static string VS(global::UnityEngine.Vector3 v)
	{
		return string.Format("[{0},{1},{2}]", v.x, v.y, v.z);
	}

	// Token: 0x17000747 RID: 1863
	// (get) Token: 0x06001A47 RID: 6727 RVA: 0x000676D8 File Offset: 0x000658D8
	protected internal global::CCTotem.TotemicObject totemicObject
	{
		get
		{
			return this._Object;
		}
	}

	// Token: 0x17000748 RID: 1864
	// (get) Token: 0x06001A48 RID: 6728
	internal abstract global::CCTotem.TotemicObject _Object { get; }

	// Token: 0x06001A49 RID: 6729 RVA: 0x000676E0 File Offset: 0x000658E0
	private static void DestroyCCDesc(global::CCTotemPole ScriptOwner, ref global::CCDesc CCDesc)
	{
		if (ScriptOwner)
		{
			ScriptOwner.DestroyCCDesc(ref CCDesc);
		}
		else
		{
			global::CCDesc ccdesc = CCDesc;
			CCDesc = null;
			if (ccdesc)
			{
				global::UnityEngine.Object.Destroy(ccdesc.gameObject);
			}
		}
	}

	// Token: 0x04000F26 RID: 3878
	protected internal const int kMaxTotemicFiguresPerTotemPole = 8;

	// Token: 0x04000F27 RID: 3879
	protected internal const global::UnityEngine.CollisionFlags kCF_Sides = 1;

	// Token: 0x04000F28 RID: 3880
	protected internal const global::UnityEngine.CollisionFlags kCF_Above = 2;

	// Token: 0x04000F29 RID: 3881
	protected internal const global::UnityEngine.CollisionFlags kCF_Below = 4;

	// Token: 0x04000F2A RID: 3882
	protected internal const global::UnityEngine.CollisionFlags kCF_None = 0;

	// Token: 0x02000303 RID: 771
	protected internal struct Configuration
	{
		// Token: 0x06001A4A RID: 6730 RVA: 0x00067720 File Offset: 0x00065920
		public Configuration(ref global::CCTotem.Initialization totem)
		{
			if (!totem.figurePrefab)
			{
				throw new global::System.ArgumentException("figurePrefab was missing", "totem");
			}
			this.totem = totem;
			this.totemMinHeight = totem.minHeight;
			this.totemMaxHeight = totem.maxHeight;
			this.totemBottomBufferUnits = totem.bottomBufferUnits;
			if (this.totemMinHeight >= this.totemMaxHeight)
			{
				throw new global::System.ArgumentException("maxHeight is less than or equal to minHeight", "totem");
			}
			if (global::UnityEngine.Mathf.Approximately(this.totemBottomBufferUnits, 0f))
			{
				this.totemBottomBufferUnits = 0f;
			}
			else if (this.totemBottomBufferUnits < 0f)
			{
				throw new global::System.ArgumentException("bottomBufferPercent must not be less than zero", "totem");
			}
			global::CCDesc figurePrefab = totem.figurePrefab;
			this.figureSkinWidth = figurePrefab.skinWidth;
			this.figure2SkinWidth = this.figureSkinWidth + this.figureSkinWidth;
			this.figureRadius = figurePrefab.radius;
			this.figureSkinnedRadius = this.figureRadius + this.figureSkinWidth;
			this.figureDiameter = this.figureRadius + this.figureRadius;
			this.figureSkinnedDiameter = this.figureSkinnedRadius + this.figureSkinnedRadius;
			this.figureHeight = figurePrefab.height;
			if (this.figureHeight <= this.figureDiameter)
			{
				throw new global::System.ArgumentException("The CCDesc(CharacterController) Prefab is a sphere, not a capsule. Thus cannot be expanded on the totem pole", "totem");
			}
			this.figureSkinnedHeight = this.figureHeight + this.figure2SkinWidth;
			if (this.figureSkinnedHeight > this.totemMinHeight && !global::UnityEngine.Mathf.Approximately(this.totemMinHeight, this.figureSkinnedHeight))
			{
				throw new global::System.ArgumentException("minHeight is too small. It must be at least the size of the CCDesc(CharacterController) prefab's [height+(skinWidth*2)]", "totem");
			}
			this.figureSlideHeight = this.figureSkinnedHeight - this.figureSkinnedDiameter;
			if (this.figureSlideHeight <= 0f)
			{
				throw new global::System.ArgumentException("The CCDesc(CharacterController) Prefab has limited height availability. Thus cannot be expanded on the totem pole", "totem");
			}
			this.figureFixedHeight = this.figureSkinnedHeight - this.figureSlideHeight;
			this.poleTopBufferAmount = this.figureSkinnedRadius;
			this.poleBottomBufferUnitSize = this.figureSlideHeight * 0.5f;
			this.poleBottomBufferAmount = this.poleBottomBufferUnitSize * this.totemBottomBufferUnits;
			if (this.poleBottomBufferAmount > this.figureSlideHeight)
			{
				if (!global::UnityEngine.Mathf.Approximately(this.poleBottomBufferAmount, this.figureSlideHeight))
				{
					throw new global::System.ArgumentException("The bottomBuffer was too large and landed outside of sliding height area of the capsule", "totem");
				}
				this.poleBottomBufferAmount = this.figureSlideHeight;
				this.totemBottomBufferUnits = this.figureSlideHeight / this.poleBottomBufferUnitSize;
			}
			this.poleBottomBufferHeight = this.figureSkinnedRadius + this.poleBottomBufferAmount;
			this.poleMostContractedHeightPossible = this.figureSkinnedHeight + this.poleBottomBufferAmount;
			if (this.poleMostContractedHeightPossible > this.totemMinHeight)
			{
				if (!global::UnityEngine.Mathf.Approximately(this.poleMostContractedHeightPossible, this.totemMinHeight))
				{
					throw new global::System.ArgumentException("bottomBufferPercent value is too high with the current setup, results in contracted height greater than totem.minHeight.", "totem");
				}
				this.totemMinHeight = this.poleMostContractedHeightPossible;
			}
			this.poleContractedHeight = global::UnityEngine.Mathf.Max(this.poleMostContractedHeightPossible, this.totemMinHeight);
			this.poleContractedHeightFromMostContractedHeightPossible = this.poleContractedHeight - this.poleMostContractedHeightPossible;
			this.poleExpandedHeight = global::UnityEngine.Mathf.Max(this.poleContractedHeight, this.totemMaxHeight);
			this.poleExpandedHeightFromMostContractedHeightPossible = this.poleExpandedHeight - this.poleMostContractedHeightPossible;
			if (global::UnityEngine.Mathf.Approximately(this.poleContractedHeightFromMostContractedHeightPossible, this.poleExpandedHeightFromMostContractedHeightPossible))
			{
				throw new global::System.ArgumentException("minHeight and maxHeight were too close to eachother to provide reliable contraction/expansion calculations.", "totem");
			}
			if (this.poleContractedHeightFromMostContractedHeightPossible < 0f || this.poleExpandedHeightFromMostContractedHeightPossible < this.poleContractedHeightFromMostContractedHeightPossible)
			{
				throw new global::System.ArgumentException("Calculation error with current configuration.", "totem");
			}
			this.poleFixedLength = this.poleBottomBufferHeight + this.poleTopBufferAmount;
			this.poleExpansionLength = this.poleExpandedHeight - this.poleFixedLength;
			this.numSlidingTotemicFigures = global::UnityEngine.Mathf.CeilToInt(this.poleExpansionLength / this.figureSlideHeight);
			if (this.numSlidingTotemicFigures < 1)
			{
				throw new global::System.ArgumentException("The current configuration of the CCTotem resulted in no need for more than one CCDesc(CharacterController), thus rejecting usage..", "totem");
			}
			this.poleMostExpandedHeightPossible = this.poleFixedLength + (float)this.numSlidingTotemicFigures * this.figureSlideHeight;
			this.numRequiredTotemicFigures = 1 + this.numSlidingTotemicFigures;
			if (this.numRequiredTotemicFigures > 8)
			{
				throw new global::System.ArgumentOutOfRangeException("totem", this.numRequiredTotemicFigures, "The current configuration of the CCTotem resulted in more than the max number of TotemicFigure's allowed :" + 8);
			}
			global::UnityEngine.Vector3 center = figurePrefab.center;
			this.figureOriginOffsetCenter = new global::UnityEngine.Vector3(0f - center.x, 0f - center.y, 0f - center.z);
			this.figureOriginOffsetBottom = new global::UnityEngine.Vector3(this.figureOriginOffsetCenter.x, 0f - (center.y - this.figureSkinnedHeight / 2f), this.figureOriginOffsetCenter.z);
			this.figureOriginOffsetTop = new global::UnityEngine.Vector3(this.figureOriginOffsetCenter.x, 0f - (center.y + this.figureSkinnedHeight / 2f), this.figureOriginOffsetCenter.z);
		}

		// Token: 0x06001A4B RID: 6731 RVA: 0x00067C0C File Offset: 0x00065E0C
		public override string ToString()
		{
			return global::CCTotem.ToStringHelper<global::CCTotem.Configuration>.GetString(this);
		}

		// Token: 0x04000F2B RID: 3883
		public readonly global::CCTotem.Initialization totem;

		// Token: 0x04000F2C RID: 3884
		public readonly float totemMinHeight;

		// Token: 0x04000F2D RID: 3885
		public readonly float totemMaxHeight;

		// Token: 0x04000F2E RID: 3886
		public readonly float totemBottomBufferUnits;

		// Token: 0x04000F2F RID: 3887
		public readonly float figureSkinWidth;

		// Token: 0x04000F30 RID: 3888
		public readonly float figure2SkinWidth;

		// Token: 0x04000F31 RID: 3889
		public readonly float figureRadius;

		// Token: 0x04000F32 RID: 3890
		public readonly float figureSkinnedRadius;

		// Token: 0x04000F33 RID: 3891
		public readonly float figureDiameter;

		// Token: 0x04000F34 RID: 3892
		public readonly float figureSkinnedDiameter;

		// Token: 0x04000F35 RID: 3893
		public readonly float figureHeight;

		// Token: 0x04000F36 RID: 3894
		public readonly float figureSkinnedHeight;

		// Token: 0x04000F37 RID: 3895
		public readonly float figureSlideHeight;

		// Token: 0x04000F38 RID: 3896
		public readonly float figureFixedHeight;

		// Token: 0x04000F39 RID: 3897
		public readonly float poleTopBufferAmount;

		// Token: 0x04000F3A RID: 3898
		public readonly float poleBottomBufferAmount;

		// Token: 0x04000F3B RID: 3899
		public readonly float poleBottomBufferHeight;

		// Token: 0x04000F3C RID: 3900
		public readonly float poleBottomBufferUnitSize;

		// Token: 0x04000F3D RID: 3901
		public readonly float poleMostContractedHeightPossible;

		// Token: 0x04000F3E RID: 3902
		public readonly float poleMostExpandedHeightPossible;

		// Token: 0x04000F3F RID: 3903
		public readonly float poleContractedHeight;

		// Token: 0x04000F40 RID: 3904
		public readonly float poleContractedHeightFromMostContractedHeightPossible;

		// Token: 0x04000F41 RID: 3905
		public readonly float poleExpandedHeight;

		// Token: 0x04000F42 RID: 3906
		public readonly float poleExpandedHeightFromMostContractedHeightPossible;

		// Token: 0x04000F43 RID: 3907
		public readonly float poleFixedLength;

		// Token: 0x04000F44 RID: 3908
		public readonly float poleExpansionLength;

		// Token: 0x04000F45 RID: 3909
		public readonly int numRequiredTotemicFigures;

		// Token: 0x04000F46 RID: 3910
		public readonly int numSlidingTotemicFigures;

		// Token: 0x04000F47 RID: 3911
		public readonly global::UnityEngine.Vector3 figureOriginOffsetBottom;

		// Token: 0x04000F48 RID: 3912
		public readonly global::UnityEngine.Vector3 figureOriginOffsetTop;

		// Token: 0x04000F49 RID: 3913
		public readonly global::UnityEngine.Vector3 figureOriginOffsetCenter;
	}

	// Token: 0x02000304 RID: 772
	protected internal struct Contraction
	{
		// Token: 0x06001A4C RID: 6732 RVA: 0x00067C20 File Offset: 0x00065E20
		private Contraction(float Contracted, float Expanded, float Range, float InverseRange)
		{
			this.Contracted = Contracted;
			this.Expanded = Expanded;
			this.Range = Range;
			this.InverseRange = InverseRange;
		}

		// Token: 0x06001A4D RID: 6733 RVA: 0x00067C40 File Offset: 0x00065E40
		public global::CCTotem.Expansion ExpansionForValue(float Value)
		{
			global::CCTotem.Expansion result;
			if (Value <= this.Contracted)
			{
				result = new global::CCTotem.Expansion(this.Contracted, 0f, 0f);
			}
			else if (Value >= this.Expanded)
			{
				result = new global::CCTotem.Expansion(this.Expanded, 1f, this.Range);
			}
			else
			{
				float num = Value - this.Contracted;
				float fractionExpanded = num / this.Range;
				result = new global::CCTotem.Expansion(Value, fractionExpanded, num);
			}
			return result;
		}

		// Token: 0x06001A4E RID: 6734 RVA: 0x00067CBC File Offset: 0x00065EBC
		public global::CCTotem.Expansion ExpansionForFraction(float FractionExpanded)
		{
			global::CCTotem.Expansion result;
			if (FractionExpanded <= 0f)
			{
				result = new global::CCTotem.Expansion(this.Contracted, 0f, 0f);
			}
			else if (FractionExpanded >= 1f)
			{
				result = new global::CCTotem.Expansion(this.Expanded, 1f, this.Range);
			}
			else
			{
				float num = FractionExpanded * this.Range;
				float value = this.Contracted + num;
				result = new global::CCTotem.Expansion(value, FractionExpanded, num);
			}
			return result;
		}

		// Token: 0x06001A4F RID: 6735 RVA: 0x00067D38 File Offset: 0x00065F38
		public global::CCTotem.Expansion ExpansionForAmount(float Amount)
		{
			global::CCTotem.Expansion result;
			if (Amount <= 0f)
			{
				result = new global::CCTotem.Expansion(this.Contracted, 0f, 0f);
			}
			else if (Amount >= this.Range)
			{
				result = new global::CCTotem.Expansion(this.Expanded, 1f, this.Range);
			}
			else
			{
				float fractionExpanded = Amount / this.Range;
				float value = this.Contracted + Amount;
				result = new global::CCTotem.Expansion(value, fractionExpanded, Amount);
			}
			return result;
		}

		// Token: 0x06001A50 RID: 6736 RVA: 0x00067DB4 File Offset: 0x00065FB4
		public override string ToString()
		{
			return string.Format("{{Contracted={0},Expanded={1},Range={2},InverseRange={3}}}", new object[]
			{
				this.Contracted,
				this.Expanded,
				this.Range,
				this.InverseRange
			});
		}

		// Token: 0x06001A51 RID: 6737 RVA: 0x00067E0C File Offset: 0x0006600C
		public static global::CCTotem.Contraction Define(float Contracted, float Expanded)
		{
			if (global::UnityEngine.Mathf.Approximately(Contracted, Expanded))
			{
				throw new global::System.ArgumentOutOfRangeException("Contracted", "approximately equal to Expanded");
			}
			float num = Expanded - Contracted;
			return new global::CCTotem.Contraction(Contracted, Expanded, num, (float)(1.0 / (double)num));
		}

		// Token: 0x04000F4A RID: 3914
		public readonly float Contracted;

		// Token: 0x04000F4B RID: 3915
		public readonly float Expanded;

		// Token: 0x04000F4C RID: 3916
		public readonly float Range;

		// Token: 0x04000F4D RID: 3917
		public readonly float InverseRange;
	}

	// Token: 0x02000305 RID: 773
	protected internal struct Direction
	{
		// Token: 0x06001A52 RID: 6738 RVA: 0x00067E50 File Offset: 0x00066050
		public Direction(global::CCTotem.TotemicFigure TotemicFigure)
		{
			if (object.ReferenceEquals(TotemicFigure, null))
			{
				throw new global::System.ArgumentNullException("TotemicFigure");
			}
			this.TotemicFigure = TotemicFigure;
			this.Exists = true;
		}

		// Token: 0x17000749 RID: 1865
		// (get) Token: 0x06001A53 RID: 6739 RVA: 0x00067E78 File Offset: 0x00066078
		public static global::CCTotem.Direction None
		{
			get
			{
				return default(global::CCTotem.Direction);
			}
		}

		// Token: 0x06001A54 RID: 6740 RVA: 0x00067E90 File Offset: 0x00066090
		public override string ToString()
		{
			return (!this.Exists) ? "{Does Not Exist}" : string.Format("{{TotemicFigure={0}}}", this.TotemicFigure);
		}

		// Token: 0x04000F4E RID: 3918
		public readonly bool Exists;

		// Token: 0x04000F4F RID: 3919
		public readonly global::CCTotem.TotemicFigure TotemicFigure;
	}

	// Token: 0x02000306 RID: 774
	protected internal struct Ends<T>
	{
		// Token: 0x06001A55 RID: 6741 RVA: 0x00067EB8 File Offset: 0x000660B8
		public Ends(T Bottom, T Top)
		{
			this.Bottom = Bottom;
			this.Top = Top;
		}

		// Token: 0x06001A56 RID: 6742 RVA: 0x00067EC8 File Offset: 0x000660C8
		public override string ToString()
		{
			return string.Format("{{Bottom={0},Top={1}}}", this.Bottom, this.Top);
		}

		// Token: 0x04000F50 RID: 3920
		public T Bottom;

		// Token: 0x04000F51 RID: 3921
		public T Top;
	}

	// Token: 0x02000307 RID: 775
	protected internal struct Expansion
	{
		// Token: 0x06001A57 RID: 6743 RVA: 0x00067EF8 File Offset: 0x000660F8
		internal Expansion(float Value, float FractionExpanded, float Amount)
		{
			this.Value = Value;
			this.FractionExpanded = FractionExpanded;
			this.Amount = Amount;
		}

		// Token: 0x06001A58 RID: 6744 RVA: 0x00067F10 File Offset: 0x00066110
		public override string ToString()
		{
			return string.Format("{{Value={0},FractionExpanded={1},Amount={2}}}", this.Value, this.FractionExpanded, this.Amount);
		}

		// Token: 0x04000F52 RID: 3922
		public readonly float Value;

		// Token: 0x04000F53 RID: 3923
		public readonly float FractionExpanded;

		// Token: 0x04000F54 RID: 3924
		public readonly float Amount;
	}

	// Token: 0x02000308 RID: 776
	protected internal struct Initialization
	{
		// Token: 0x06001A59 RID: 6745 RVA: 0x00067F40 File Offset: 0x00066140
		public Initialization(global::CCTotemPole totemPole, global::CCDesc figurePrefab, float minHeight, float maxHeight, float initialHeight, float bottomBufferUnits)
		{
			this.totemPole = totemPole;
			this.figurePrefab = figurePrefab;
			this.minHeight = minHeight;
			this.maxHeight = maxHeight;
			this.initialHeight = initialHeight;
			this.bottomBufferUnits = bottomBufferUnits;
			this.nonDefault = true;
		}

		// Token: 0x06001A5A RID: 6746 RVA: 0x00067F84 File Offset: 0x00066184
		public override string ToString()
		{
			return global::CCTotem.ToStringHelper<global::CCTotem.Initialization>.GetString(this);
		}

		// Token: 0x04000F55 RID: 3925
		public readonly global::CCTotemPole totemPole;

		// Token: 0x04000F56 RID: 3926
		public readonly global::CCDesc figurePrefab;

		// Token: 0x04000F57 RID: 3927
		public readonly float minHeight;

		// Token: 0x04000F58 RID: 3928
		public readonly float maxHeight;

		// Token: 0x04000F59 RID: 3929
		public readonly float initialHeight;

		// Token: 0x04000F5A RID: 3930
		public readonly float bottomBufferUnits;

		// Token: 0x04000F5B RID: 3931
		public readonly bool nonDefault;
	}

	// Token: 0x02000309 RID: 777
	public struct PositionPlacement
	{
		// Token: 0x06001A5B RID: 6747 RVA: 0x00067F98 File Offset: 0x00066198
		public PositionPlacement(global::UnityEngine.Vector3 Bottom, global::UnityEngine.Vector3 Top, global::UnityEngine.Vector3 ColliderPosition, float OriginalHeight)
		{
			this.bottom = Bottom;
			this.top = Top;
			this.colliderCenter = ColliderPosition;
			this.height = Top.y - Bottom.y;
			this.originalHeight = OriginalHeight;
			this.originalTop.x = Bottom.x;
			this.originalTop.y = Bottom.y + OriginalHeight;
			this.originalTop.z = Bottom.z;
		}

		// Token: 0x04000F5C RID: 3932
		public global::UnityEngine.Vector3 bottom;

		// Token: 0x04000F5D RID: 3933
		public global::UnityEngine.Vector3 top;

		// Token: 0x04000F5E RID: 3934
		public global::UnityEngine.Vector3 colliderCenter;

		// Token: 0x04000F5F RID: 3935
		public float height;

		// Token: 0x04000F60 RID: 3936
		public float originalHeight;

		// Token: 0x04000F61 RID: 3937
		public global::UnityEngine.Vector3 originalTop;
	}

	// Token: 0x0200030A RID: 778
	protected internal struct Route
	{
		// Token: 0x06001A5C RID: 6748 RVA: 0x00068010 File Offset: 0x00066210
		public Route(global::CCTotem.Direction Up, global::CCTotem.Direction At, global::CCTotem.Direction Down)
		{
			this.Up = Up;
			this.At = At;
			this.Down = Down;
		}

		// Token: 0x06001A5D RID: 6749 RVA: 0x00068028 File Offset: 0x00066228
		public unsafe bool GetUp(out global::CCTotem.Route route)
		{
			if (this.Up.Exists)
			{
				route = *this.Up.TotemicFigure;
				return true;
			}
			route = new global::CCTotem.Route(global::CCTotem.Direction.None, global::CCTotem.Direction.None, this.At);
			return false;
		}

		// Token: 0x06001A5E RID: 6750 RVA: 0x0006807C File Offset: 0x0006627C
		public unsafe bool GetDown(out global::CCTotem.Route route)
		{
			if (this.Down.Exists)
			{
				route = *this.Down.TotemicFigure;
				return true;
			}
			route = new global::CCTotem.Route(this.At, global::CCTotem.Direction.None, global::CCTotem.Direction.None);
			return false;
		}

		// Token: 0x1700074A RID: 1866
		// (get) Token: 0x06001A5F RID: 6751 RVA: 0x000680D0 File Offset: 0x000662D0
		public global::System.Collections.Generic.IEnumerable<global::CCTotem.TotemicFigure> EnumerateUpInclusive
		{
			get
			{
				global::CCTotem.Route it = ref this;
				while (it.At.Exists)
				{
					yield return it.At.TotemicFigure;
					it.GetUp(out it);
				}
				yield break;
			}
		}

		// Token: 0x1700074B RID: 1867
		// (get) Token: 0x06001A60 RID: 6752 RVA: 0x000680F8 File Offset: 0x000662F8
		public global::System.Collections.Generic.IEnumerable<global::CCTotem.TotemicFigure> EnumerateUp
		{
			get
			{
				global::CCTotem.Route it;
				if (this.GetUp(out it))
				{
					while (it.At.Exists)
					{
						yield return it.At.TotemicFigure;
						it.GetUp(out it);
					}
				}
				yield break;
			}
		}

		// Token: 0x1700074C RID: 1868
		// (get) Token: 0x06001A61 RID: 6753 RVA: 0x00068120 File Offset: 0x00066320
		public global::System.Collections.Generic.IEnumerable<global::CCTotem.TotemicFigure> EnumerateDownInclusive
		{
			get
			{
				global::CCTotem.Route it = ref this;
				while (it.At.Exists)
				{
					yield return it.At.TotemicFigure;
					it.GetDown(out it);
				}
				yield break;
			}
		}

		// Token: 0x1700074D RID: 1869
		// (get) Token: 0x06001A62 RID: 6754 RVA: 0x00068148 File Offset: 0x00066348
		public global::System.Collections.Generic.IEnumerable<global::CCTotem.TotemicFigure> EnumerateDown
		{
			get
			{
				global::CCTotem.Route it;
				if (this.GetUp(out it))
				{
					while (it.At.Exists)
					{
						yield return it.At.TotemicFigure;
						it.GetDown(out it);
					}
				}
				yield break;
			}
		}

		// Token: 0x06001A63 RID: 6755 RVA: 0x00068170 File Offset: 0x00066370
		public override string ToString()
		{
			return string.Format("{{Up={0},At={1},Down={2}}}", this.Up, this.At, this.Down);
		}

		// Token: 0x04000F62 RID: 3938
		public readonly global::CCTotem.Direction Up;

		// Token: 0x04000F63 RID: 3939
		public readonly global::CCTotem.Direction At;

		// Token: 0x04000F64 RID: 3940
		public readonly global::CCTotem.Direction Down;

		// Token: 0x0200030B RID: 779
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private sealed class <>c__Iterator2E : global::System.IDisposable, global::System.Collections.IEnumerator, global::System.Collections.IEnumerable, global::System.Collections.Generic.IEnumerable<global::CCTotem.TotemicFigure>, global::System.Collections.Generic.IEnumerator<global::CCTotem.TotemicFigure>
		{
			// Token: 0x06001A64 RID: 6756 RVA: 0x000681A0 File Offset: 0x000663A0
			public <>c__Iterator2E()
			{
			}

			// Token: 0x1700074E RID: 1870
			// (get) Token: 0x06001A65 RID: 6757 RVA: 0x000681A8 File Offset: 0x000663A8
			global::CCTotem.TotemicFigure global::System.Collections.Generic.IEnumerator<global::CCTotem.TotemicFigure>.Current
			{
				[global::System.Diagnostics.DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x1700074F RID: 1871
			// (get) Token: 0x06001A66 RID: 6758 RVA: 0x000681B0 File Offset: 0x000663B0
			object global::System.Collections.IEnumerator.Current
			{
				[global::System.Diagnostics.DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x06001A67 RID: 6759 RVA: 0x000681B8 File Offset: 0x000663B8
			[global::System.Diagnostics.DebuggerHidden]
			global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
			{
				return this.System.Collections.Generic.IEnumerable<CCTotem.TotemicFigure>.GetEnumerator();
			}

			// Token: 0x06001A68 RID: 6760 RVA: 0x000681C0 File Offset: 0x000663C0
			[global::System.Diagnostics.DebuggerHidden]
			global::System.Collections.Generic.IEnumerator<global::CCTotem.TotemicFigure> global::System.Collections.Generic.IEnumerable<global::CCTotem.TotemicFigure>.GetEnumerator()
			{
				if (global::System.Threading.Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
				{
					return this;
				}
				global::CCTotem.Route.<>c__Iterator2E <>c__Iterator2E = new global::CCTotem.Route.<>c__Iterator2E();
				<>c__Iterator2E.<>f__this = ref this;
				return <>c__Iterator2E;
			}

			// Token: 0x06001A69 RID: 6761 RVA: 0x000681F4 File Offset: 0x000663F4
			public bool MoveNext()
			{
				uint num = (uint)this.$PC;
				this.$PC = -1;
				switch (num)
				{
				case 0U:
					it = ref this;
					break;
				case 1U:
					it.GetUp(out it);
					break;
				default:
					return false;
				}
				if (it.At.Exists)
				{
					this.$current = it.At.TotemicFigure;
					this.$PC = 1;
					return true;
				}
				this.$PC = -1;
				return false;
			}

			// Token: 0x06001A6A RID: 6762 RVA: 0x00068290 File Offset: 0x00066490
			[global::System.Diagnostics.DebuggerHidden]
			public void Dispose()
			{
				this.$PC = -1;
			}

			// Token: 0x06001A6B RID: 6763 RVA: 0x0006829C File Offset: 0x0006649C
			[global::System.Diagnostics.DebuggerHidden]
			public void Reset()
			{
				throw new global::System.NotSupportedException();
			}

			// Token: 0x04000F65 RID: 3941
			internal global::CCTotem.Route <it>__0;

			// Token: 0x04000F66 RID: 3942
			internal int $PC;

			// Token: 0x04000F67 RID: 3943
			internal global::CCTotem.TotemicFigure $current;

			// Token: 0x04000F68 RID: 3944
			internal global::CCTotem.Route <>f__this;
		}

		// Token: 0x0200030C RID: 780
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private sealed class <>c__Iterator2F : global::System.IDisposable, global::System.Collections.IEnumerator, global::System.Collections.IEnumerable, global::System.Collections.Generic.IEnumerable<global::CCTotem.TotemicFigure>, global::System.Collections.Generic.IEnumerator<global::CCTotem.TotemicFigure>
		{
			// Token: 0x06001A6C RID: 6764 RVA: 0x000682A4 File Offset: 0x000664A4
			public <>c__Iterator2F()
			{
			}

			// Token: 0x17000750 RID: 1872
			// (get) Token: 0x06001A6D RID: 6765 RVA: 0x000682AC File Offset: 0x000664AC
			global::CCTotem.TotemicFigure global::System.Collections.Generic.IEnumerator<global::CCTotem.TotemicFigure>.Current
			{
				[global::System.Diagnostics.DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x17000751 RID: 1873
			// (get) Token: 0x06001A6E RID: 6766 RVA: 0x000682B4 File Offset: 0x000664B4
			object global::System.Collections.IEnumerator.Current
			{
				[global::System.Diagnostics.DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x06001A6F RID: 6767 RVA: 0x000682BC File Offset: 0x000664BC
			[global::System.Diagnostics.DebuggerHidden]
			global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
			{
				return this.System.Collections.Generic.IEnumerable<CCTotem.TotemicFigure>.GetEnumerator();
			}

			// Token: 0x06001A70 RID: 6768 RVA: 0x000682C4 File Offset: 0x000664C4
			[global::System.Diagnostics.DebuggerHidden]
			global::System.Collections.Generic.IEnumerator<global::CCTotem.TotemicFigure> global::System.Collections.Generic.IEnumerable<global::CCTotem.TotemicFigure>.GetEnumerator()
			{
				if (global::System.Threading.Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
				{
					return this;
				}
				global::CCTotem.Route.<>c__Iterator2F <>c__Iterator2F = new global::CCTotem.Route.<>c__Iterator2F();
				<>c__Iterator2F.<>f__this = ref this;
				return <>c__Iterator2F;
			}

			// Token: 0x06001A71 RID: 6769 RVA: 0x000682F8 File Offset: 0x000664F8
			public bool MoveNext()
			{
				uint num = (uint)this.$PC;
				this.$PC = -1;
				switch (num)
				{
				case 0U:
					if (!base.GetUp(out it))
					{
						goto IL_8B;
					}
					break;
				case 1U:
					it.GetUp(out it);
					break;
				default:
					return false;
				}
				if (it.At.Exists)
				{
					this.$current = it.At.TotemicFigure;
					this.$PC = 1;
					return true;
				}
				IL_8B:
				this.$PC = -1;
				return false;
			}

			// Token: 0x06001A72 RID: 6770 RVA: 0x0006839C File Offset: 0x0006659C
			[global::System.Diagnostics.DebuggerHidden]
			public void Dispose()
			{
				this.$PC = -1;
			}

			// Token: 0x06001A73 RID: 6771 RVA: 0x000683A8 File Offset: 0x000665A8
			[global::System.Diagnostics.DebuggerHidden]
			public void Reset()
			{
				throw new global::System.NotSupportedException();
			}

			// Token: 0x04000F69 RID: 3945
			internal global::CCTotem.Route <it>__0;

			// Token: 0x04000F6A RID: 3946
			internal int $PC;

			// Token: 0x04000F6B RID: 3947
			internal global::CCTotem.TotemicFigure $current;

			// Token: 0x04000F6C RID: 3948
			internal global::CCTotem.Route <>f__this;
		}

		// Token: 0x0200030D RID: 781
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private sealed class <>c__Iterator30 : global::System.IDisposable, global::System.Collections.IEnumerator, global::System.Collections.IEnumerable, global::System.Collections.Generic.IEnumerable<global::CCTotem.TotemicFigure>, global::System.Collections.Generic.IEnumerator<global::CCTotem.TotemicFigure>
		{
			// Token: 0x06001A74 RID: 6772 RVA: 0x000683B0 File Offset: 0x000665B0
			public <>c__Iterator30()
			{
			}

			// Token: 0x17000752 RID: 1874
			// (get) Token: 0x06001A75 RID: 6773 RVA: 0x000683B8 File Offset: 0x000665B8
			global::CCTotem.TotemicFigure global::System.Collections.Generic.IEnumerator<global::CCTotem.TotemicFigure>.Current
			{
				[global::System.Diagnostics.DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x17000753 RID: 1875
			// (get) Token: 0x06001A76 RID: 6774 RVA: 0x000683C0 File Offset: 0x000665C0
			object global::System.Collections.IEnumerator.Current
			{
				[global::System.Diagnostics.DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x06001A77 RID: 6775 RVA: 0x000683C8 File Offset: 0x000665C8
			[global::System.Diagnostics.DebuggerHidden]
			global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
			{
				return this.System.Collections.Generic.IEnumerable<CCTotem.TotemicFigure>.GetEnumerator();
			}

			// Token: 0x06001A78 RID: 6776 RVA: 0x000683D0 File Offset: 0x000665D0
			[global::System.Diagnostics.DebuggerHidden]
			global::System.Collections.Generic.IEnumerator<global::CCTotem.TotemicFigure> global::System.Collections.Generic.IEnumerable<global::CCTotem.TotemicFigure>.GetEnumerator()
			{
				if (global::System.Threading.Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
				{
					return this;
				}
				global::CCTotem.Route.<>c__Iterator30 <>c__Iterator = new global::CCTotem.Route.<>c__Iterator30();
				<>c__Iterator.<>f__this = ref this;
				return <>c__Iterator;
			}

			// Token: 0x06001A79 RID: 6777 RVA: 0x00068404 File Offset: 0x00066604
			public bool MoveNext()
			{
				uint num = (uint)this.$PC;
				this.$PC = -1;
				switch (num)
				{
				case 0U:
					it = ref this;
					break;
				case 1U:
					it.GetDown(out it);
					break;
				default:
					return false;
				}
				if (it.At.Exists)
				{
					this.$current = it.At.TotemicFigure;
					this.$PC = 1;
					return true;
				}
				this.$PC = -1;
				return false;
			}

			// Token: 0x06001A7A RID: 6778 RVA: 0x000684A0 File Offset: 0x000666A0
			[global::System.Diagnostics.DebuggerHidden]
			public void Dispose()
			{
				this.$PC = -1;
			}

			// Token: 0x06001A7B RID: 6779 RVA: 0x000684AC File Offset: 0x000666AC
			[global::System.Diagnostics.DebuggerHidden]
			public void Reset()
			{
				throw new global::System.NotSupportedException();
			}

			// Token: 0x04000F6D RID: 3949
			internal global::CCTotem.Route <it>__0;

			// Token: 0x04000F6E RID: 3950
			internal int $PC;

			// Token: 0x04000F6F RID: 3951
			internal global::CCTotem.TotemicFigure $current;

			// Token: 0x04000F70 RID: 3952
			internal global::CCTotem.Route <>f__this;
		}

		// Token: 0x0200030E RID: 782
		[global::System.Runtime.CompilerServices.CompilerGenerated]
		private sealed class <>c__Iterator31 : global::System.IDisposable, global::System.Collections.IEnumerator, global::System.Collections.IEnumerable, global::System.Collections.Generic.IEnumerable<global::CCTotem.TotemicFigure>, global::System.Collections.Generic.IEnumerator<global::CCTotem.TotemicFigure>
		{
			// Token: 0x06001A7C RID: 6780 RVA: 0x000684B4 File Offset: 0x000666B4
			public <>c__Iterator31()
			{
			}

			// Token: 0x17000754 RID: 1876
			// (get) Token: 0x06001A7D RID: 6781 RVA: 0x000684BC File Offset: 0x000666BC
			global::CCTotem.TotemicFigure global::System.Collections.Generic.IEnumerator<global::CCTotem.TotemicFigure>.Current
			{
				[global::System.Diagnostics.DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x17000755 RID: 1877
			// (get) Token: 0x06001A7E RID: 6782 RVA: 0x000684C4 File Offset: 0x000666C4
			object global::System.Collections.IEnumerator.Current
			{
				[global::System.Diagnostics.DebuggerHidden]
				get
				{
					return this.$current;
				}
			}

			// Token: 0x06001A7F RID: 6783 RVA: 0x000684CC File Offset: 0x000666CC
			[global::System.Diagnostics.DebuggerHidden]
			global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
			{
				return this.System.Collections.Generic.IEnumerable<CCTotem.TotemicFigure>.GetEnumerator();
			}

			// Token: 0x06001A80 RID: 6784 RVA: 0x000684D4 File Offset: 0x000666D4
			[global::System.Diagnostics.DebuggerHidden]
			global::System.Collections.Generic.IEnumerator<global::CCTotem.TotemicFigure> global::System.Collections.Generic.IEnumerable<global::CCTotem.TotemicFigure>.GetEnumerator()
			{
				if (global::System.Threading.Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
				{
					return this;
				}
				global::CCTotem.Route.<>c__Iterator31 <>c__Iterator = new global::CCTotem.Route.<>c__Iterator31();
				<>c__Iterator.<>f__this = ref this;
				return <>c__Iterator;
			}

			// Token: 0x06001A81 RID: 6785 RVA: 0x00068508 File Offset: 0x00066708
			public bool MoveNext()
			{
				uint num = (uint)this.$PC;
				this.$PC = -1;
				switch (num)
				{
				case 0U:
					if (!base.GetUp(out it))
					{
						goto IL_8B;
					}
					break;
				case 1U:
					it.GetDown(out it);
					break;
				default:
					return false;
				}
				if (it.At.Exists)
				{
					this.$current = it.At.TotemicFigure;
					this.$PC = 1;
					return true;
				}
				IL_8B:
				this.$PC = -1;
				return false;
			}

			// Token: 0x06001A82 RID: 6786 RVA: 0x000685AC File Offset: 0x000667AC
			[global::System.Diagnostics.DebuggerHidden]
			public void Dispose()
			{
				this.$PC = -1;
			}

			// Token: 0x06001A83 RID: 6787 RVA: 0x000685B8 File Offset: 0x000667B8
			[global::System.Diagnostics.DebuggerHidden]
			public void Reset()
			{
				throw new global::System.NotSupportedException();
			}

			// Token: 0x04000F71 RID: 3953
			internal global::CCTotem.Route <it>__0;

			// Token: 0x04000F72 RID: 3954
			internal int $PC;

			// Token: 0x04000F73 RID: 3955
			internal global::CCTotem.TotemicFigure $current;

			// Token: 0x04000F74 RID: 3956
			internal global::CCTotem.Route <>f__this;
		}
	}

	// Token: 0x0200030F RID: 783
	public abstract class TotemicObject
	{
		// Token: 0x06001A84 RID: 6788 RVA: 0x000685C0 File Offset: 0x000667C0
		internal TotemicObject()
		{
		}

		// Token: 0x17000756 RID: 1878
		// (get) Token: 0x06001A85 RID: 6789 RVA: 0x000685C8 File Offset: 0x000667C8
		protected internal global::CCTotem Script
		{
			get
			{
				return this._Script;
			}
		}

		// Token: 0x17000757 RID: 1879
		// (get) Token: 0x06001A86 RID: 6790
		internal abstract global::CCTotem _Script { get; }
	}

	// Token: 0x02000310 RID: 784
	public abstract class TotemicObject<CCTotemScript> : global::CCTotem.TotemicObject where CCTotemScript : global::CCTotem, new()
	{
		// Token: 0x06001A87 RID: 6791 RVA: 0x000685D0 File Offset: 0x000667D0
		internal TotemicObject()
		{
		}

		// Token: 0x17000758 RID: 1880
		// (get) Token: 0x06001A88 RID: 6792 RVA: 0x000685D8 File Offset: 0x000667D8
		internal sealed override global::CCTotem _Script
		{
			get
			{
				return this.Script;
			}
		}

		// Token: 0x04000F75 RID: 3957
		protected internal new CCTotemScript Script;
	}

	// Token: 0x02000311 RID: 785
	public abstract class TotemicObject<CCTotemScript, TTotemicObject> : global::CCTotem.TotemicObject<CCTotemScript> where CCTotemScript : global::CCTotem<TTotemicObject, CCTotemScript>, new() where TTotemicObject : global::CCTotem.TotemicObject<CCTotemScript, TTotemicObject>, new()
	{
		// Token: 0x06001A89 RID: 6793 RVA: 0x000685E8 File Offset: 0x000667E8
		internal TotemicObject()
		{
		}

		// Token: 0x06001A8A RID: 6794
		internal abstract void OnScriptDestroy(CCTotemScript Script);

		// Token: 0x06001A8B RID: 6795
		internal abstract void AssignedToScript(CCTotemScript Script);
	}

	// Token: 0x02000312 RID: 786
	private static class ToStringHelper<T> where T : struct
	{
		// Token: 0x06001A8C RID: 6796 RVA: 0x000685F0 File Offset: 0x000667F0
		static ToStringHelper()
		{
			global::System.Text.StringBuilder stringBuilder = new global::System.Text.StringBuilder();
			using (global::System.IO.StringWriter stringWriter = new global::System.IO.StringWriter(stringBuilder))
			{
				stringWriter.Write("{{");
				bool flag = true;
				for (int i = 0; i < global::CCTotem.ToStringHelper<T>.allFields.Length; i++)
				{
					if (flag)
					{
						flag = false;
					}
					else
					{
						stringWriter.Write(", ");
					}
					stringWriter.Write("{0}={{{1}}}", global::CCTotem.ToStringHelper<T>.allFields[i].Name, i);
				}
				stringWriter.Write("}}");
			}
			global::CCTotem.ToStringHelper<T>.formatterString = stringBuilder.ToString();
		}

		// Token: 0x06001A8D RID: 6797 RVA: 0x000686D0 File Offset: 0x000668D0
		public static string GetString(object boxed)
		{
			string result;
			try
			{
				for (int i = 0; i < global::CCTotem.ToStringHelper<T>.allFields.Length; i++)
				{
					global::CCTotem.ToStringHelper<T>.valueHolders[i] = global::CCTotem.ToStringHelper<T>.allFields[i].GetValue(boxed);
				}
				result = string.Format(global::CCTotem.ToStringHelper<T>.formatterString, global::CCTotem.ToStringHelper<T>.valueHolders);
			}
			finally
			{
				for (int j = 0; j < global::CCTotem.ToStringHelper<T>.allFields.Length; j++)
				{
					global::CCTotem.ToStringHelper<T>.valueHolders[j] = null;
				}
			}
			return result;
		}

		// Token: 0x04000F76 RID: 3958
		private static readonly global::System.Reflection.FieldInfo[] allFields = typeof(T).GetFields();

		// Token: 0x04000F77 RID: 3959
		private static readonly object[] valueHolders = new object[global::CCTotem.ToStringHelper<T>.allFields.Length];

		// Token: 0x04000F78 RID: 3960
		private static readonly string formatterString;
	}

	// Token: 0x02000313 RID: 787
	public struct MoveInfo
	{
		// Token: 0x06001A8E RID: 6798 RVA: 0x00068764 File Offset: 0x00066964
		public MoveInfo(global::UnityEngine.CollisionFlags CollisionFlags, global::UnityEngine.CollisionFlags WorkingCollisionFlags, float WantedHeight, global::UnityEngine.Vector3 BottomMovement, global::UnityEngine.Vector3 TopMovement, global::CCTotem.PositionPlacement PositionPlacement)
		{
			this.CollisionFlags = CollisionFlags;
			this.WorkingCollisionFlags = WorkingCollisionFlags;
			this.WantedHeight = WantedHeight;
			this.BottomMovement = BottomMovement;
			this.TopMovement = TopMovement;
			this.PositionPlacement = PositionPlacement;
		}

		// Token: 0x04000F79 RID: 3961
		public readonly global::UnityEngine.CollisionFlags CollisionFlags;

		// Token: 0x04000F7A RID: 3962
		public readonly global::UnityEngine.CollisionFlags WorkingCollisionFlags;

		// Token: 0x04000F7B RID: 3963
		public readonly float WantedHeight;

		// Token: 0x04000F7C RID: 3964
		public readonly global::UnityEngine.Vector3 BottomMovement;

		// Token: 0x04000F7D RID: 3965
		public readonly global::UnityEngine.Vector3 TopMovement;

		// Token: 0x04000F7E RID: 3966
		public readonly global::CCTotem.PositionPlacement PositionPlacement;
	}

	// Token: 0x02000314 RID: 788
	public sealed class TotemPole : global::CCTotem.TotemicObject<global::CCTotemPole, global::CCTotem.TotemPole>
	{
		// Token: 0x06001A8F RID: 6799 RVA: 0x00068794 File Offset: 0x00066994
		[global::System.Obsolete("Infrastructure", true)]
		public TotemPole()
		{
			throw new global::System.NotSupportedException();
		}

		// Token: 0x06001A90 RID: 6800 RVA: 0x000687A4 File Offset: 0x000669A4
		internal TotemPole(ref global::CCTotem.Configuration TotemConfiguration)
		{
			this.Configuration = TotemConfiguration;
			this.TotemicFigures = new global::CCTotem.TotemicFigure[8];
			this.TotemicFigureEnds = global::CCTotem.TotemicFigure.CreateAllTotemicFigures(this);
			this.Contraction = global::CCTotem.Contraction.Define(this.Configuration.poleContractedHeight, this.Configuration.poleExpandedHeight);
		}

		// Token: 0x06001A91 RID: 6801 RVA: 0x000687FC File Offset: 0x000669FC
		internal override void AssignedToScript(global::CCTotemPole Script)
		{
			this.Script = Script;
		}

		// Token: 0x06001A92 RID: 6802 RVA: 0x00068808 File Offset: 0x00066A08
		internal override void OnScriptDestroy(global::CCTotemPole Script)
		{
			if (object.ReferenceEquals(this.Script, Script))
			{
				this.DeleteAllFiguresAndClearScript();
			}
		}

		// Token: 0x06001A93 RID: 6803 RVA: 0x00068824 File Offset: 0x00066A24
		private void DeleteAllFiguresAndClearScript()
		{
			global::CCTotemPole script = this.Script;
			this.Script = null;
			for (int i = this.Configuration.numRequiredTotemicFigures - 1; i >= 0; i--)
			{
				global::CCTotem.TotemicFigure totemicFigure = this.TotemicFigures[i];
				if (!object.ReferenceEquals(totemicFigure, null))
				{
					if (totemicFigure.TotemPole == this)
					{
						this.TotemicFigures[i].Delete(script);
					}
					else
					{
						this.TotemicFigures[i] = null;
					}
				}
			}
			global::CCTotem.DestroyCCDesc(script, ref this.CCDesc);
			if (script && object.ReferenceEquals(script.totemicObject, this))
			{
				script.totemicObject = null;
			}
		}

		// Token: 0x06001A94 RID: 6804 RVA: 0x000688CC File Offset: 0x00066ACC
		private global::CCDesc InstantiateCCDesc(global::UnityEngine.Vector3 worldBottom, string name)
		{
			global::CCDesc ccdesc = (global::CCDesc)global::UnityEngine.Object.Instantiate(this.Configuration.totem.figurePrefab, worldBottom, global::UnityEngine.Quaternion.identity);
			if (!string.IsNullOrEmpty(name))
			{
				ccdesc.name = name;
			}
			ccdesc.gameObject.hideFlags = 8;
			ccdesc.detectCollisions = false;
			return ccdesc;
		}

		// Token: 0x06001A95 RID: 6805 RVA: 0x00068928 File Offset: 0x00066B28
		private global::CCTotemicFigure InstantiateTotemicFigure(global::UnityEngine.Vector3 worldBottom, global::CCTotem.TotemicFigure target)
		{
			worldBottom.y += target.TotemContractionBottom.ExpansionForFraction(this.Expansion.FractionExpanded).Value;
			target.CCDesc = this.InstantiateCCDesc(worldBottom, string.Format("__TotemicFigure{0}", target.BottomUpIndex));
			global::CCTotemicFigure cctotemicFigure = target.CCDesc.gameObject.AddComponent<global::CCTotemicFigure>();
			cctotemicFigure.AssignTotemicObject(target);
			if (this.Script)
			{
				this.Script.ExecuteBinding(target.CCDesc, true);
			}
			return cctotemicFigure;
		}

		// Token: 0x06001A96 RID: 6806 RVA: 0x000689C4 File Offset: 0x00066BC4
		public void Create()
		{
			float initialHeight = this.Configuration.totem.initialHeight;
			this.Expansion = this.Contraction.ExpansionForValue(initialHeight);
			global::UnityEngine.Vector3 worldBottom = this.Script.transform.position + this.Configuration.figureOriginOffsetBottom;
			this.CCDesc = this.InstantiateCCDesc(worldBottom, "__TotemPole");
			if (this.Script)
			{
				this.Script.ExecuteBinding(this.CCDesc, true);
			}
			for (int i = 0; i < this.Configuration.numRequiredTotemicFigures; i++)
			{
				this.InstantiateTotemicFigure(worldBottom, this.TotemicFigures[i]);
			}
			this.Point.Bottom = this.TotemicFigures[0].BottomOrigin;
			this.Point.Top = this.TotemicFigureEnds.Top.TopOrigin;
			this.CCDesc.ModifyHeight(this.Point.Top.y - this.Point.Bottom.y, false);
		}

		// Token: 0x17000759 RID: 1881
		// (get) Token: 0x06001A97 RID: 6807 RVA: 0x00068AF0 File Offset: 0x00066CF0
		private global::CCDesc CCDescOrPrefab
		{
			get
			{
				return (!this.CCDesc) ? this.Configuration.totem.figurePrefab : this.CCDesc;
			}
		}

		// Token: 0x1700075A RID: 1882
		// (get) Token: 0x06001A98 RID: 6808 RVA: 0x00068B30 File Offset: 0x00066D30
		public bool isGrounded
		{
			get
			{
				return this.grounded;
			}
		}

		// Token: 0x1700075B RID: 1883
		// (get) Token: 0x06001A99 RID: 6809 RVA: 0x00068B38 File Offset: 0x00066D38
		public global::UnityEngine.Vector3 velocity
		{
			get
			{
				return (!this.CCDesc) ? global::UnityEngine.Vector3.zero : this.CCDesc.velocity;
			}
		}

		// Token: 0x1700075C RID: 1884
		// (get) Token: 0x06001A9A RID: 6810 RVA: 0x00068B60 File Offset: 0x00066D60
		public global::UnityEngine.CollisionFlags collisionFlags
		{
			get
			{
				return (!this.CCDesc) ? 0 : this.CCDesc.collisionFlags;
			}
		}

		// Token: 0x1700075D RID: 1885
		// (get) Token: 0x06001A9B RID: 6811 RVA: 0x00068B84 File Offset: 0x00066D84
		public float stepOffset
		{
			get
			{
				return this.CCDescOrPrefab.stepOffset;
			}
		}

		// Token: 0x1700075E RID: 1886
		// (get) Token: 0x06001A9C RID: 6812 RVA: 0x00068B94 File Offset: 0x00066D94
		public float slopeLimit
		{
			get
			{
				return this.CCDescOrPrefab.slopeLimit;
			}
		}

		// Token: 0x1700075F RID: 1887
		// (get) Token: 0x06001A9D RID: 6813 RVA: 0x00068BA4 File Offset: 0x00066DA4
		public float height
		{
			get
			{
				return this.CCDescOrPrefab.height;
			}
		}

		// Token: 0x17000760 RID: 1888
		// (get) Token: 0x06001A9E RID: 6814 RVA: 0x00068BB4 File Offset: 0x00066DB4
		public float radius
		{
			get
			{
				return this.CCDescOrPrefab.radius;
			}
		}

		// Token: 0x17000761 RID: 1889
		// (get) Token: 0x06001A9F RID: 6815 RVA: 0x00068BC4 File Offset: 0x00066DC4
		public global::UnityEngine.Vector3 center
		{
			get
			{
				return this.CCDescOrPrefab.center;
			}
		}

		// Token: 0x06001AA0 RID: 6816 RVA: 0x00068BD4 File Offset: 0x00066DD4
		public global::CCTotem.MoveInfo Move(global::UnityEngine.Vector3 motion, float height)
		{
			global::CCTotem.Expansion expansion = this.Contraction.ExpansionForValue(height);
			height = expansion.Value;
			global::UnityEngine.CollisionFlags collisionFlags = this.TotemicFigureEnds.Bottom.MoveSweep(motion) & this.TotemicFigureEnds.Bottom.CollisionFlagsMask;
			this.grounded = this.TotemicFigureEnds.Bottom.CCDesc.isGrounded;
			int num = 0;
			for (int i = this.Configuration.numRequiredTotemicFigures - 1; i >= 1; i--)
			{
				global::UnityEngine.Vector3 sweepMovement = this.TotemicFigures[num].SweepMovement;
				collisionFlags |= (this.TotemicFigures[i].MoveSweep(sweepMovement) & this.TotemicFigures[i].CollisionFlagsMask);
				num = i;
			}
			if (this.TotemicFigures[num].SweepMovement != this.TotemicFigures[0].SweepMovement)
			{
				global::UnityEngine.Vector3 sweepMovement2 = this.TotemicFigures[num].SweepMovement;
				for (int j = 0; j < this.Configuration.numRequiredTotemicFigures; j++)
				{
					global::UnityEngine.Vector3 motion2 = sweepMovement2 - this.TotemicFigures[j].SweepMovement;
					collisionFlags |= (this.TotemicFigures[j].MoveSweep(motion2) & this.TotemicFigures[j].CollisionFlagsMask);
				}
			}
			this.Point.Bottom = this.TotemicFigures[0].BottomOrigin;
			this.Point.Top = this.TotemicFigureEnds.Top.TopOrigin;
			this.Expansion = this.Contraction.ExpansionForValue(this.Point.Top.y - this.Point.Bottom.y);
			if (this.Expansion.Value != expansion.Value)
			{
				global::UnityEngine.Vector3 targetTop = this.Point.Bottom + new global::UnityEngine.Vector3(0f, expansion.Value, 0f);
				collisionFlags |= (this.TotemicFigureEnds.Top.MoveWorldTopTo(targetTop) & this.TotemicFigureEnds.Top.CollisionFlagsMask);
				global::UnityEngine.Vector3 topOrigin = this.TotemicFigureEnds.Top.TopOrigin;
				expansion = this.Contraction.ExpansionForValue(topOrigin.y - this.Point.Bottom.y);
				for (int k = this.Configuration.numRequiredTotemicFigures - 2; k > 0; k--)
				{
					global::CCTotem.TotemicFigure totemicFigure = this.TotemicFigures[k];
					global::UnityEngine.Vector3 bottom = this.Point.Bottom;
					bottom.y += totemicFigure.TotemContractionBottom.ExpansionForFraction(expansion.FractionExpanded).Value;
					collisionFlags |= (totemicFigure.MoveWorldBottomTo(bottom) & totemicFigure.CollisionFlagsMask);
				}
				this.Point.Top = this.TotemicFigureEnds.Top.TopOrigin;
				this.Expansion = expansion;
			}
			float effectiveSkinnedHeight = this.CCDesc.effectiveSkinnedHeight;
			global::UnityEngine.Vector3 worldSkinnedBottom = this.CCDesc.worldSkinnedBottom;
			global::UnityEngine.Vector3 worldSkinnedTop = this.CCDesc.worldSkinnedTop;
			global::UnityEngine.Vector3 vector = this.TotemicFigures[0].BottomOrigin - worldSkinnedBottom;
			global::CCDesc.HeightModification heightModification = this.CCDesc.ModifyHeight(this.Expansion.Value, false);
			global::UnityEngine.CollisionFlags collisionFlags2 = this.CCDesc.Move(vector);
			global::UnityEngine.Vector3 worldSkinnedBottom2 = this.CCDesc.worldSkinnedBottom;
			global::UnityEngine.Vector3 vector2 = worldSkinnedBottom2 - worldSkinnedBottom;
			if (vector != vector2)
			{
				global::UnityEngine.Vector3 motion3 = vector2 - vector;
				for (int l = 0; l < this.Configuration.numRequiredTotemicFigures; l++)
				{
					collisionFlags |= (this.TotemicFigures[l].MoveSweep(motion3) & this.TotemicFigures[l].CollisionFlagsMask);
				}
				this.Point.Bottom = this.TotemicFigures[0].BottomOrigin;
				this.Point.Top = this.TotemicFigureEnds.Top.TopOrigin;
				this.Expansion = this.Contraction.ExpansionForValue(this.Point.Top.y - this.Point.Bottom.y);
				global::CCDesc.HeightModification heightModification2 = this.CCDesc.ModifyHeight(this.Expansion.Value, false);
				worldSkinnedBottom2 = this.CCDesc.worldSkinnedBottom;
				vector2 = worldSkinnedBottom2 - worldSkinnedBottom;
			}
			global::UnityEngine.Vector3 worldSkinnedTop2 = this.CCDesc.worldSkinnedTop;
			global::UnityEngine.Vector3 topMovement = worldSkinnedTop2 - worldSkinnedTop;
			global::CCTotem.PositionPlacement positionPlacement = new global::CCTotem.PositionPlacement(worldSkinnedBottom2, worldSkinnedTop2, this.CCDesc.transform.position, this.Configuration.poleExpandedHeight);
			return new global::CCTotem.MoveInfo(collisionFlags2, collisionFlags, height, vector2, topMovement, positionPlacement);
		}

		// Token: 0x04000F7F RID: 3967
		private const int kCrouch_NotModified = 0;

		// Token: 0x04000F80 RID: 3968
		private const int kCrouch_MovingDown = -1;

		// Token: 0x04000F81 RID: 3969
		private const int kCrouch_MovingUp = 1;

		// Token: 0x04000F82 RID: 3970
		internal readonly global::CCTotem.Configuration Configuration;

		// Token: 0x04000F83 RID: 3971
		internal readonly global::CCTotem.TotemicFigure[] TotemicFigures;

		// Token: 0x04000F84 RID: 3972
		internal readonly global::CCTotem.Ends<global::CCTotem.TotemicFigure> TotemicFigureEnds;

		// Token: 0x04000F85 RID: 3973
		internal readonly global::CCTotem.Contraction Contraction;

		// Token: 0x04000F86 RID: 3974
		internal global::CCTotem.Ends<global::UnityEngine.Vector3> Point;

		// Token: 0x04000F87 RID: 3975
		internal global::CCTotem.Expansion Expansion;

		// Token: 0x04000F88 RID: 3976
		internal global::CCDesc CCDesc;

		// Token: 0x04000F89 RID: 3977
		private bool grounded;
	}

	// Token: 0x02000315 RID: 789
	public sealed class TotemicFigure : global::CCTotem.TotemicObject<global::CCTotemicFigure, global::CCTotem.TotemicFigure>
	{
		// Token: 0x06001AA1 RID: 6817 RVA: 0x000690B4 File Offset: 0x000672B4
		[global::System.Obsolete("Infrastructure", true)]
		public TotemicFigure()
		{
			throw new global::System.NotSupportedException();
		}

		// Token: 0x06001AA2 RID: 6818 RVA: 0x000690C4 File Offset: 0x000672C4
		private TotemicFigure(global::CCTotem.TotemPole TotemPole, int BottomUpIndex)
		{
			this.TotemPole = TotemPole;
			this.BottomUpIndex = BottomUpIndex;
			this.TopDownIndex = this.TotemPole.Configuration.numRequiredTotemicFigures - (this.BottomUpIndex + 1);
			this.CollisionFlagsMask = 1;
			if (this.BottomUpIndex == 0)
			{
				this.CollisionFlagsMask |= 4;
			}
			if (this.TopDownIndex == 0)
			{
				this.CollisionFlagsMask |= 2;
			}
			this.TotemPole.TotemicFigures[this.BottomUpIndex] = this;
		}

		// Token: 0x06001AA3 RID: 6819 RVA: 0x00069150 File Offset: 0x00067350
		private TotemicFigure(global::CCTotem.Direction Down) : this(Down.TotemicFigure.TotemPole, Down.TotemicFigure.BottomUpIndex + 1)
		{
			float num = (float)this.BottomUpIndex / (float)this.TotemPole.Configuration.numSlidingTotemicFigures;
			float num2 = (this.TotemPole.Configuration.numSlidingTotemicFigures != 1) ? ((float)(this.BottomUpIndex - 1) / (float)(this.TotemPole.Configuration.numSlidingTotemicFigures - 1)) : num;
			float num3 = global::UnityEngine.Mathf.Lerp(this.TotemPole.Configuration.poleBottomBufferAmount, this.TotemPole.Configuration.poleContractedHeight - this.TotemPole.Configuration.figureSkinnedHeight, num2);
			float num4 = global::UnityEngine.Mathf.Lerp(this.TotemPole.Configuration.poleBottomBufferAmount, this.TotemPole.Configuration.poleExpandedHeight - this.TotemPole.Configuration.figureSkinnedHeight, num);
			this.TotemContractionBottom = global::CCTotem.Contraction.Define(num3, num4);
			this.TotemContractionTop = global::CCTotem.Contraction.Define(num3 + this.TotemPole.Configuration.figureSkinnedHeight, num4 + this.TotemPole.Configuration.figureSkinnedHeight);
			global::CCTotem.Direction direction = new global::CCTotem.Direction(this);
			global::CCTotem.Direction none;
			if (this.BottomUpIndex < this.TotemPole.Configuration.numRequiredTotemicFigures - 1)
			{
				none = new global::CCTotem.Direction(new global::CCTotem.TotemicFigure(direction));
			}
			else
			{
				none = global::CCTotem.Direction.None;
			}
			this.TotemicRoute = new global::CCTotem.Route(Down, direction, none);
		}

		// Token: 0x06001AA4 RID: 6820 RVA: 0x000692CC File Offset: 0x000674CC
		private TotemicFigure(global::CCTotem.TotemPole TotemPole) : this(TotemPole, 0)
		{
			global::CCTotem.Direction direction = new global::CCTotem.Direction(this);
			this.TotemicRoute = new global::CCTotem.Route(global::CCTotem.Direction.None, direction, new global::CCTotem.Direction(new global::CCTotem.TotemicFigure(direction)));
		}

		// Token: 0x06001AA5 RID: 6821 RVA: 0x00069308 File Offset: 0x00067508
		internal static global::CCTotem.Ends<global::CCTotem.TotemicFigure> CreateAllTotemicFigures(global::CCTotem.TotemPole TotemPole)
		{
			if (!object.ReferenceEquals(TotemPole.TotemicFigures[0], null))
			{
				throw new global::System.ArgumentException("The totem pole already has totemic figures", "TotemPole");
			}
			global::CCTotem.TotemicFigure bottom = new global::CCTotem.TotemicFigure(TotemPole);
			global::CCTotem.TotemicFigure top = TotemPole.TotemicFigures[TotemPole.Configuration.numRequiredTotemicFigures - 1];
			return new global::CCTotem.Ends<global::CCTotem.TotemicFigure>(bottom, top);
		}

		// Token: 0x06001AA6 RID: 6822 RVA: 0x00069360 File Offset: 0x00067560
		internal override void OnScriptDestroy(global::CCTotemicFigure Script)
		{
			if (object.ReferenceEquals(this.Script, Script))
			{
				this.Script = null;
				if (object.ReferenceEquals(Script.totemicObject, this))
				{
					Script.totemicObject = null;
				}
			}
		}

		// Token: 0x06001AA7 RID: 6823 RVA: 0x000693A0 File Offset: 0x000675A0
		internal override void AssignedToScript(global::CCTotemicFigure Script)
		{
			this.Script = Script;
		}

		// Token: 0x06001AA8 RID: 6824 RVA: 0x000693AC File Offset: 0x000675AC
		internal void Delete(global::CCTotemPole OwnerScript)
		{
			global::CCTotemicFigure script = this.Script;
			this.Script = null;
			if (script && object.ReferenceEquals(script.totemicObject, this))
			{
				script.totemicObject = null;
			}
			global::CCTotem.DestroyCCDesc(OwnerScript, ref this.CCDesc);
			if (script)
			{
				global::UnityEngine.Object.Destroy(script.gameObject);
			}
			if (object.ReferenceEquals(this.TotemPole.TotemicFigures[this.BottomUpIndex], this))
			{
				this.TotemPole.TotemicFigures[this.BottomUpIndex] = null;
			}
		}

		// Token: 0x06001AA9 RID: 6825 RVA: 0x0006943C File Offset: 0x0006763C
		public override string ToString()
		{
			return string.Format("{{Index={0},ContractionBottom={1},ContractionTop={2},Script={3}}}", new object[]
			{
				this.BottomUpIndex,
				this.TotemContractionBottom,
				this.TotemContractionTop,
				this.Script
			});
		}

		// Token: 0x17000762 RID: 1890
		// (get) Token: 0x06001AAA RID: 6826 RVA: 0x0006948C File Offset: 0x0006768C
		public global::UnityEngine.Vector3 BottomOrigin
		{
			get
			{
				return this.CCDesc.worldSkinnedBottom;
			}
		}

		// Token: 0x17000763 RID: 1891
		// (get) Token: 0x06001AAB RID: 6827 RVA: 0x0006949C File Offset: 0x0006769C
		public global::UnityEngine.Vector3 CenterOrigin
		{
			get
			{
				return this.CCDesc.worldCenter;
			}
		}

		// Token: 0x17000764 RID: 1892
		// (get) Token: 0x06001AAC RID: 6828 RVA: 0x000694AC File Offset: 0x000676AC
		public global::UnityEngine.Vector3 TopOrigin
		{
			get
			{
				return this.CCDesc.worldSkinnedTop;
			}
		}

		// Token: 0x17000765 RID: 1893
		// (get) Token: 0x06001AAD RID: 6829 RVA: 0x000694BC File Offset: 0x000676BC
		public global::UnityEngine.Vector3 SlideBottomOrigin
		{
			get
			{
				return this.CCDesc.OffsetToWorld(this.CCDesc.center - new global::UnityEngine.Vector3(0f, this.CCDesc.effectiveSkinnedHeight * 0.5f - this.CCDesc.skinnedRadius, 0f));
			}
		}

		// Token: 0x17000766 RID: 1894
		// (get) Token: 0x06001AAE RID: 6830 RVA: 0x00069510 File Offset: 0x00067710
		public global::UnityEngine.Vector3 SlideTopOrigin
		{
			get
			{
				return this.CCDesc.OffsetToWorld(this.CCDesc.center + new global::UnityEngine.Vector3(0f, this.CCDesc.effectiveSkinnedHeight * 0.5f - this.CCDesc.skinnedRadius, 0f));
			}
		}

		// Token: 0x06001AAF RID: 6831 RVA: 0x00069564 File Offset: 0x00067764
		public global::UnityEngine.CollisionFlags MoveWorldBottomTo(global::UnityEngine.Vector3 targetBottom)
		{
			return this.MoveWorld(targetBottom - this.BottomOrigin);
		}

		// Token: 0x06001AB0 RID: 6832 RVA: 0x00069578 File Offset: 0x00067778
		public global::UnityEngine.CollisionFlags MoveWorldTopTo(global::UnityEngine.Vector3 targetTop)
		{
			return this.MoveWorld(targetTop - this.TopOrigin);
		}

		// Token: 0x06001AB1 RID: 6833 RVA: 0x0006958C File Offset: 0x0006778C
		public global::UnityEngine.CollisionFlags MoveWorld(global::UnityEngine.Vector3 motion)
		{
			return this.CCDesc.Move(motion);
		}

		// Token: 0x06001AB2 RID: 6834 RVA: 0x0006959C File Offset: 0x0006779C
		public global::UnityEngine.CollisionFlags MoveSweep(global::UnityEngine.Vector3 motion)
		{
			this.PreSweepBottom = this.BottomOrigin;
			global::UnityEngine.CollisionFlags result = this.MoveWorld(motion);
			this.PostSweepBottom = this.BottomOrigin;
			this.SweepMovement = this.PostSweepBottom - this.PreSweepBottom;
			return result;
		}

		// Token: 0x04000F8A RID: 3978
		public global::CCDesc CCDesc;

		// Token: 0x04000F8B RID: 3979
		internal readonly global::CCTotem.TotemPole TotemPole;

		// Token: 0x04000F8C RID: 3980
		internal readonly int BottomUpIndex;

		// Token: 0x04000F8D RID: 3981
		internal readonly int TopDownIndex;

		// Token: 0x04000F8E RID: 3982
		internal readonly global::UnityEngine.CollisionFlags CollisionFlagsMask;

		// Token: 0x04000F8F RID: 3983
		internal readonly global::CCTotem.Route TotemicRoute;

		// Token: 0x04000F90 RID: 3984
		internal readonly global::CCTotem.Contraction TotemContractionTop;

		// Token: 0x04000F91 RID: 3985
		internal readonly global::CCTotem.Contraction TotemContractionBottom;

		// Token: 0x04000F92 RID: 3986
		public global::UnityEngine.Vector3 PreSweepBottom;

		// Token: 0x04000F93 RID: 3987
		public global::UnityEngine.Vector3 PostSweepBottom;

		// Token: 0x04000F94 RID: 3988
		public global::UnityEngine.Vector3 SweepMovement;
	}

	// Token: 0x02000316 RID: 790
	// (Invoke) Token: 0x06001AB4 RID: 6836
	public delegate void PositionBinder(ref global::CCTotem.PositionPlacement binding, object Tag);

	// Token: 0x02000317 RID: 791
	// (Invoke) Token: 0x06001AB8 RID: 6840
	public delegate void ConfigurationBinder(bool Bind, global::CCDesc CCDesc, object Tag);
}
