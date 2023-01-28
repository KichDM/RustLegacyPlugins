using System;
using UnityEngine;

namespace Facepunch.Procedural
{
	// Token: 0x0200060C RID: 1548
	public struct Origin
	{
		// Token: 0x06003167 RID: 12647 RVA: 0x000BD44C File Offset: 0x000BB64C
		public void Target(ref global::UnityEngine.Vector3 target, float moveSpeed)
		{
			if (!this.value.clock.once)
			{
				this.delta.x = (this.delta.y = (this.delta.z = 0f));
				this.value.SetImmediate(ref target);
			}
			else
			{
				this.delta.x = target.x - this.value.current.x;
				this.delta.y = target.y - this.value.current.y;
				this.delta.z = target.z - this.value.current.z;
				float num = this.delta.x * this.delta.x + this.delta.y * this.delta.y + this.delta.z * this.delta.z;
				float num2 = moveSpeed * float.Epsilon;
				float num3 = num2 * num2;
				if (num <= num3 || moveSpeed == 0f)
				{
					this.delta.x = (this.delta.y = (this.delta.z = 0f));
					this.value.SetImmediate(ref target);
				}
				else
				{
					float num4 = global::UnityEngine.Mathf.Sqrt(num);
					this.value.begin = this.value.current;
					this.value.end = target;
					if (moveSpeed < 0f)
					{
						moveSpeed = -moveSpeed;
					}
					this.value.clock.remain = (this.value.clock.duration = (ulong)global::System.Math.Ceiling((double)num4 * 1000.0 / (double)moveSpeed));
					if (this.value.clock.remain <= 1UL)
					{
						this.delta.x = (this.delta.y = (this.delta.z = 0f));
						this.value.SetImmediate(ref target);
					}
				}
			}
		}

		// Token: 0x06003168 RID: 12648 RVA: 0x000BD688 File Offset: 0x000BB888
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
				double percent = this.value.clock.percent;
				this.value.current.x = (float)((double)this.value.begin.x + (double)this.delta.x * percent);
				this.value.current.y = (float)((double)this.value.begin.y + (double)this.delta.y * percent);
				this.value.current.z = (float)((double)this.value.begin.z + (double)this.delta.z * percent);
			}
			return integration;
		}

		// Token: 0x04001B92 RID: 7058
		[global::System.NonSerialized]
		public global::Facepunch.Procedural.Integrated<global::UnityEngine.Vector3> value;

		// Token: 0x04001B93 RID: 7059
		[global::System.NonSerialized]
		public global::UnityEngine.Vector3 delta;
	}
}
