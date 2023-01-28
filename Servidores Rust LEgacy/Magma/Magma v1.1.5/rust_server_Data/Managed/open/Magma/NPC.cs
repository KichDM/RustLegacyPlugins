using System;

namespace Magma
{
	// Token: 0x0200000E RID: 14
	public class NPC
	{
		// Token: 0x1700002B RID: 43
		// (get) Token: 0x0600007E RID: 126 RVA: 0x00003374 File Offset: 0x00001574
		// (set) Token: 0x0600007F RID: 127 RVA: 0x00003390 File Offset: 0x00001590
		public string Name
		{
			get
			{
				return this._char.name.Replace("(Clone)", "");
			}
			set
			{
				this._char.name = value;
			}
		}

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x06000080 RID: 128 RVA: 0x0000339E File Offset: 0x0000159E
		// (set) Token: 0x06000081 RID: 129 RVA: 0x000033AB File Offset: 0x000015AB
		public float Health
		{
			get
			{
				return this._char.health;
			}
			set
			{
				this._char.takeDamage.health = value;
			}
		}

		// Token: 0x1700002D RID: 45
		// (get) Token: 0x06000082 RID: 130 RVA: 0x000033BE File Offset: 0x000015BE
		// (set) Token: 0x06000083 RID: 131 RVA: 0x000033C6 File Offset: 0x000015C6
		public global::Character Character
		{
			get
			{
				return this._char;
			}
			set
			{
				this._char = value;
			}
		}

		// Token: 0x06000084 RID: 132 RVA: 0x000033CF File Offset: 0x000015CF
		public NPC(global::Character c)
		{
			this._char = c;
		}

		// Token: 0x06000085 RID: 133 RVA: 0x000033E0 File Offset: 0x000015E0
		public void Kill()
		{
			this.Character.Signal_ServerCharacterDeath();
			this.Character.SendMessage("OnKilled", default(global::DamageEvent), 1);
		}

		// Token: 0x04000022 RID: 34
		private global::Character _char;
	}
}
