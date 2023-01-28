using System;
using UnityEngine;

namespace Facepunch.Procedural
{
	// Token: 0x0200060B RID: 1547
	public struct Direction
	{
		// Token: 0x06003165 RID: 12645 RVA: 0x000BD2B4 File Offset: 0x000BB4B4
		public void Target(ref global::UnityEngine.Vector3 target, float degreeSpeed)
		{
			if (!this.value.clock.once)
			{
				this.value.SetImmediate(ref target);
			}
			else
			{
				float num = global::UnityEngine.Mathf.Abs(global::UnityEngine.Vector3.Angle(this.value.current, target));
				if (num < degreeSpeed * 1E-45f || degreeSpeed == 0f)
				{
					this.value.SetImmediate(ref target);
				}
				else
				{
					this.value.begin = this.value.current;
					this.value.end = target;
					if (degreeSpeed < 0f)
					{
						degreeSpeed = -degreeSpeed;
					}
					this.value.clock.duration = (this.value.clock.remain = (ulong)global::System.Math.Ceiling((double)num * 1000.0 / (double)degreeSpeed));
					if (this.value.clock.remain <= 1UL)
					{
						this.value.SetImmediate(ref target);
					}
				}
			}
		}

		// Token: 0x06003166 RID: 12646 RVA: 0x000BD3C0 File Offset: 0x000BB5C0
		public global::Facepunch.Procedural.Integration Advance(ulong millis)
		{
			global::Facepunch.Procedural.Integration integration = this.value.clock.IntegrateTime(millis);
			global::Facepunch.Procedural.Integration integration2 = integration;
			if (integration2 != global::Facepunch.Procedural.Integration.Moved)
			{
				if (integration2 == global::Facepunch.Procedural.Integration.MovedDestination)
				{
					this.value.current = this.value.end;
				}
			}
			else
			{
				this.value.current = global::UnityEngine.Vector3.Slerp(this.value.begin, this.value.end, this.value.clock.percentf);
			}
			return integration;
		}

		// Token: 0x04001B91 RID: 7057
		[global::System.NonSerialized]
		public global::Facepunch.Procedural.Integrated<global::UnityEngine.Vector3> value;
	}
}
