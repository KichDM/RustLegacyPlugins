using System;
using UnityEngine;

namespace NGUIHack
{
	// Token: 0x0200096F RID: 2415
	public class Event : global::System.IDisposable
	{
		// Token: 0x0600523A RID: 21050 RVA: 0x00151C7C File Offset: 0x0014FE7C
		internal Event(global::UnityEngine.Event @event)
		{
			this.@event = @event;
			this.originalType = @event.type;
			this.originalRawType = @event.rawType;
			this.overrideType = 0xC;
			this.screenPosition = global::UnityEngine.Input.mousePosition;
		}

		// Token: 0x0600523B RID: 21051 RVA: 0x00151CC8 File Offset: 0x0014FEC8
		internal Event(global::UnityEngine.Event @event, global::UnityEngine.EventType overrideType) : this(@event)
		{
			this.overrideType = overrideType;
		}

		// Token: 0x17000F67 RID: 3943
		// (get) Token: 0x0600523C RID: 21052 RVA: 0x00151CD8 File Offset: 0x0014FED8
		public global::UnityEngine.EventType type
		{
			get
			{
				return (this.overrideType != 0xC) ? this.overrideType : this.@event.type;
			}
		}

		// Token: 0x17000F68 RID: 3944
		// (get) Token: 0x0600523D RID: 21053 RVA: 0x00151D00 File Offset: 0x0014FF00
		public global::UnityEngine.EventType rawType
		{
			get
			{
				return (this.overrideType != 0xC) ? this.overrideType : this.@event.rawType;
			}
		}

		// Token: 0x17000F69 RID: 3945
		// (get) Token: 0x0600523E RID: 21054 RVA: 0x00151D28 File Offset: 0x0014FF28
		public int button
		{
			get
			{
				return this.@event.button;
			}
		}

		// Token: 0x17000F6A RID: 3946
		// (get) Token: 0x0600523F RID: 21055 RVA: 0x00151D38 File Offset: 0x0014FF38
		public global::UnityEngine.Vector2 mousePosition
		{
			get
			{
				return this.screenPosition;
			}
		}

		// Token: 0x17000F6B RID: 3947
		// (get) Token: 0x06005240 RID: 21056 RVA: 0x00151D40 File Offset: 0x0014FF40
		public global::UnityEngine.KeyCode keyCode
		{
			get
			{
				return this.@event.keyCode;
			}
		}

		// Token: 0x17000F6C RID: 3948
		// (get) Token: 0x06005241 RID: 21057 RVA: 0x00151D50 File Offset: 0x0014FF50
		public char character
		{
			get
			{
				return this.@event.character;
			}
		}

		// Token: 0x17000F6D RID: 3949
		// (get) Token: 0x06005242 RID: 21058 RVA: 0x00151D60 File Offset: 0x0014FF60
		public global::UnityEngine.EventModifiers modifiers
		{
			get
			{
				return this.@event.modifiers;
			}
		}

		// Token: 0x17000F6E RID: 3950
		// (get) Token: 0x06005243 RID: 21059 RVA: 0x00151D70 File Offset: 0x0014FF70
		public bool shift
		{
			get
			{
				return this.@event.shift;
			}
		}

		// Token: 0x17000F6F RID: 3951
		// (get) Token: 0x06005244 RID: 21060 RVA: 0x00151D80 File Offset: 0x0014FF80
		public bool alt
		{
			get
			{
				return this.@event.alt;
			}
		}

		// Token: 0x17000F70 RID: 3952
		// (get) Token: 0x06005245 RID: 21061 RVA: 0x00151D90 File Offset: 0x0014FF90
		public bool control
		{
			get
			{
				return this.@event.control;
			}
		}

		// Token: 0x17000F71 RID: 3953
		// (get) Token: 0x06005246 RID: 21062 RVA: 0x00151DA0 File Offset: 0x0014FFA0
		public bool capsLock
		{
			get
			{
				return this.@event.capsLock;
			}
		}

		// Token: 0x17000F72 RID: 3954
		// (get) Token: 0x06005247 RID: 21063 RVA: 0x00151DB0 File Offset: 0x0014FFB0
		public global::UnityEngine.Vector2 delta
		{
			get
			{
				return this.@event.delta;
			}
		}

		// Token: 0x06005248 RID: 21064 RVA: 0x00151DC0 File Offset: 0x0014FFC0
		public void Dispose()
		{
			if (this.overrideType != 0xC && this.@event.type == this.overrideType)
			{
				this.@event.type = this.originalType;
			}
		}

		// Token: 0x06005249 RID: 21065 RVA: 0x00151E04 File Offset: 0x00150004
		public void Use()
		{
			if (this.overrideType == 0xC)
			{
				this.@event.Use();
			}
		}

		// Token: 0x17000F73 RID: 3955
		// (get) Token: 0x0600524A RID: 21066 RVA: 0x00151E20 File Offset: 0x00150020
		internal global::UnityEngine.Event real
		{
			get
			{
				return this.@event;
			}
		}

		// Token: 0x17000F74 RID: 3956
		// (get) Token: 0x0600524B RID: 21067 RVA: 0x00151E28 File Offset: 0x00150028
		public global::UnityEngine.EventType unityOriginalRawType
		{
			get
			{
				return this.originalRawType;
			}
		}

		// Token: 0x04002E97 RID: 11927
		public static int pressed;

		// Token: 0x04002E98 RID: 11928
		public static int unpressed;

		// Token: 0x04002E99 RID: 11929
		public static int held;

		// Token: 0x04002E9A RID: 11930
		private readonly global::UnityEngine.Event @event;

		// Token: 0x04002E9B RID: 11931
		private readonly global::UnityEngine.EventType originalType;

		// Token: 0x04002E9C RID: 11932
		private readonly global::UnityEngine.EventType originalRawType;

		// Token: 0x04002E9D RID: 11933
		private readonly global::UnityEngine.EventType overrideType;

		// Token: 0x04002E9E RID: 11934
		private readonly global::UnityEngine.Vector2 screenPosition;
	}
}
