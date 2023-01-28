using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

// Token: 0x020006C6 RID: 1734
public class inv : global::ConsoleSystem
{
	// Token: 0x06003B59 RID: 15193 RVA: 0x000D2A88 File Offset: 0x000D0C88
	public inv()
	{
	}

	// Token: 0x06003B5A RID: 15194 RVA: 0x000D2A90 File Offset: 0x000D0C90
	private static global::System.Collections.Generic.IEnumerable<global::Inventory> OneInventory(global::Inventory inventory)
	{
		yield return inventory;
		yield break;
	}

	// Token: 0x06003B5B RID: 15195 RVA: 0x000D2ABC File Offset: 0x000D0CBC
	private static global::System.Collections.Generic.IEnumerable<global::PlayerClient> OnePlayerClient(global::PlayerClient playerClient)
	{
		yield return playerClient;
		yield break;
	}

	// Token: 0x06003B5C RID: 15196 RVA: 0x000D2AE8 File Offset: 0x000D0CE8
	private static global::System.Collections.Generic.IEnumerable<global::Inventory> Inventories(global::PlayerClient client)
	{
		return global::inv.Inventories(global::inv.OnePlayerClient(client));
	}

	// Token: 0x06003B5D RID: 15197 RVA: 0x000D2AF8 File Offset: 0x000D0CF8
	private static global::System.Collections.Generic.IEnumerable<global::Inventory> Inventories(global::System.Collections.Generic.IEnumerable<global::PlayerClient> clients)
	{
		foreach (global::PlayerClient pc in clients)
		{
			if (pc)
			{
				global::Controllable controllable = pc.rootControllable;
				if (controllable)
				{
					global::Character character = controllable.idMain;
					if (character)
					{
						yield return character.GetLocal<global::Inventory>();
					}
				}
			}
		}
		yield break;
	}

	// Token: 0x06003B5E RID: 15198 RVA: 0x000D2B24 File Offset: 0x000D0D24
	private static string RunGiveCommand(ref global::ConsoleSystem.Arg arg, int shift, global::System.Collections.Generic.IEnumerable<global::Inventory> onInventories)
	{
		if (!arg.HasArgs(1))
		{
			return null;
		}
		string text = arg.Args[shift];
		global::ItemDataBlock byName = global::DatablockDictionary.GetByName(text);
		if (byName == null)
		{
			return string.Format("No item named :{0}: to give!", text);
		}
		int @int = arg.GetInt(shift + 1, 1);
		global::Inventory.Uses.Quantity uses;
		global::Inventory.Uses.Quantity.TryParse(arg.GetString(shift + 2, "Random"), out uses);
		int int2 = arg.GetInt(shift + 3, -1);
		int num = 0;
		int num2 = 0;
		if (!byName.IsSplittable())
		{
			int maxEligableSlots = (int)byName.GetMaxEligableSlots();
			foreach (global::Inventory inventory in onInventories)
			{
				bool flag = false;
				if (inventory)
				{
					for (int i = 0; i < @int; i++)
					{
						if (!inventory.noVacantSlots)
						{
							global::IInventoryItem inventoryItem = inventory.AddItem(byName, global::Inventory.Slot.Preference.Define(global::Inventory.Slot.Kind.Default, false, global::Inventory.Slot.KindFlags.Belt), uses);
							if (object.ReferenceEquals(inventoryItem, null))
							{
								break;
							}
							flag = true;
							num++;
							if (int2 != -1 && maxEligableSlots > 0)
							{
								global::IHeldItem heldItem = inventoryItem as global::IHeldItem;
								if (!object.ReferenceEquals(heldItem, null))
								{
									heldItem.SetTotalModSlotCount(global::UnityEngine.Mathf.Min(int2, maxEligableSlots));
								}
							}
						}
					}
					if (flag)
					{
						num2++;
					}
				}
			}
		}
		else
		{
			foreach (global::Inventory inventory2 in onInventories)
			{
				if (inventory2)
				{
					int num3 = inventory2.AddItemAmount(byName, @int);
					int num4 = @int - num3;
					num += num4;
					if (num4 > 0)
					{
						num2++;
					}
				}
			}
		}
		if (num2 == 0)
		{
			return string.Format("There were no inventories able to handle the arguments \"{0}\"", arg.ArgsStr);
		}
		if (num2 != 1)
		{
			return string.Format("Gave {0} {1}(s) between {2} inventories", num, byName.name, num2);
		}
		if (num > 1)
		{
			return string.Format("Gave {0} {1}(s) to 1 inventory", num, byName.name);
		}
		return string.Format("Gave 1 {0} to 1 inventory", byName.name);
	}

	// Token: 0x06003B5F RID: 15199 RVA: 0x000D2DAC File Offset: 0x000D0FAC
	[global::ConsoleSystem.Admin]
	[global::ConsoleSystem.Help("give item(s) to calling alive admin with inventory", "<case sensitive name of item> [number of stacks or uses=1] [number of ammo=random] [number of mod slots=random]")]
	public static void give(ref global::ConsoleSystem.Arg arg)
	{
		arg.ReplyWith(global::inv.RunGiveCommand(ref arg, 0, global::inv.Inventories(arg.playerClient())) ?? "<case sensitive name of item> [number of stacks or uses=1] [number of ammo=random] [number of mod slots=random]");
	}

	// Token: 0x06003B60 RID: 15200 RVA: 0x000D2DE0 File Offset: 0x000D0FE0
	[global::ConsoleSystem.Admin]
	[global::ConsoleSystem.Help("give armor(s) to calling alive admin with inventory", "<case sensitive name of item> [number of stacks or uses=1] [number of ammo=random] [number of mod slots=random]")]
	public static void givearmor(ref global::ConsoleSystem.Arg arg)
	{
		global::ConsoleSystem.Arg arg2;
		global::ConsoleSystem.Arg arg3;
		global::ConsoleSystem.Arg arg4;
		global::ConsoleSystem.Arg arg5;
		if (global::inv.SplitArgsForArmor(ref arg, 0, out arg2, out arg3, out arg4, out arg5))
		{
			global::inv.giveplayer(ref arg2);
			global::inv.giveplayer(ref arg3);
			global::inv.giveplayer(ref arg4);
			global::inv.giveplayer(ref arg5);
			global::inv.JoinArgsForResult(ref arg, ref arg2, ref arg3, ref arg4, ref arg5);
		}
	}

	// Token: 0x06003B61 RID: 15201 RVA: 0x000D2E2C File Offset: 0x000D102C
	[global::ConsoleSystem.Admin]
	[global::ConsoleSystem.Help("give item(s) to every alive player with a inventory", "<case sensitive name of item> [number of stacks or uses=1] [number of ammo=random] [number of mod slots=random]")]
	public static void giveall(ref global::ConsoleSystem.Arg arg)
	{
		global::ServerManagement serverManagement = global::ServerManagement.Get();
		if (!serverManagement)
		{
			arg.ReplyWith("no server management");
			return;
		}
		arg.ReplyWith(global::inv.RunGiveCommand(ref arg, 0, global::inv.Inventories(global::PlayerClient.All)) ?? "<case sensitive name of item> [number of stacks or uses=1] [number of ammo=random] [number of mod slots=random]");
	}

	// Token: 0x06003B62 RID: 15202 RVA: 0x000D2E7C File Offset: 0x000D107C
	[global::ConsoleSystem.Admin]
	[global::ConsoleSystem.Help("give item(s) to every alive player with inventory and matching name", "<player name> <case sensitive name of item> [number of stacks or uses=1] [number of ammo=random] [number of mod slots=random]")]
	public static void giveplayer(ref global::ConsoleSystem.Arg arg)
	{
		global::ServerManagement serverManagement = global::ServerManagement.Get();
		if (!serverManagement)
		{
			arg.ReplyWith("no server management");
			return;
		}
		arg.ReplyWith(global::inv.RunGiveCommand(ref arg, 1, global::inv.Inventories(global::PlayerClient.FindAllWithString(arg.GetString(0, string.Empty)))) ?? "<player name> <case sensitive name of item> [number of stacks or uses=1] [number of ammo=random] [number of mod slots=random]");
	}

	// Token: 0x06003B63 RID: 15203 RVA: 0x000D2ED8 File Offset: 0x000D10D8
	[global::ConsoleSystem.Admin]
	[global::ConsoleSystem.Help("give armor(s) to every alive player with inventory and matching name", "<player name> <case sensitive name of item> [number of stacks or uses=1] [number of ammo=random] [number of mod slots=random]")]
	public static void giveplayerarmor(ref global::ConsoleSystem.Arg arg)
	{
		global::ConsoleSystem.Arg arg2;
		global::ConsoleSystem.Arg arg3;
		global::ConsoleSystem.Arg arg4;
		global::ConsoleSystem.Arg arg5;
		if (global::inv.SplitArgsForArmor(ref arg, 0, out arg2, out arg3, out arg4, out arg5))
		{
			global::inv.giveplayer(ref arg2);
			global::inv.giveplayer(ref arg3);
			global::inv.giveplayer(ref arg4);
			global::inv.giveplayer(ref arg5);
			global::inv.JoinArgsForResult(ref arg, ref arg2, ref arg3, ref arg4, ref arg5);
		}
	}

	// Token: 0x06003B64 RID: 15204 RVA: 0x000D2F24 File Offset: 0x000D1124
	private static bool SplitArgsForArmor(ref global::ConsoleSystem.Arg arg, int itemArg, out global::ConsoleSystem.Arg feet, out global::ConsoleSystem.Arg legs, out global::ConsoleSystem.Arg torso, out global::ConsoleSystem.Arg helmet)
	{
		global::ConsoleSystem.Arg arg2;
		helmet = (arg2 = arg);
		torso = (arg2 = arg2);
		legs = (arg2 = arg2);
		feet = arg2;
		if (!arg.HasArgs(itemArg + 1))
		{
			return false;
		}
		feet.Args = (string[])arg.Args.Clone();
		legs.Args = (string[])arg.Args.Clone();
		torso.Args = (string[])arg.Args.Clone();
		helmet.Args = (string[])arg.Args.Clone();
		feet.Args[itemArg] = arg.Args[itemArg] + " Boots";
		legs.Args[itemArg] = arg.Args[itemArg] + " Pants";
		torso.Args[itemArg] = arg.Args[itemArg] + " Vest";
		helmet.Args[itemArg] = arg.Args[itemArg] + " Helmet";
		return true;
	}

	// Token: 0x06003B65 RID: 15205 RVA: 0x000D302C File Offset: 0x000D122C
	private static void JoinArgsForResult(ref global::ConsoleSystem.Arg arg, ref global::ConsoleSystem.Arg feet, ref global::ConsoleSystem.Arg legs, ref global::ConsoleSystem.Arg torso, ref global::ConsoleSystem.Arg helmet)
	{
		arg.ReplyWith(string.Format("{0}\n{1}\n{2}\n{3}", new object[]
		{
			feet.Reply,
			legs.Reply,
			torso.Reply,
			helmet.Reply
		}));
	}

	// Token: 0x06003B66 RID: 15206 RVA: 0x000D307C File Offset: 0x000D127C
	[global::ConsoleSystem.Admin]
	[global::ConsoleSystem.Help("gives you the ammo for the current active item if any", "[number of ammo to give]")]
	public static void ammo(ref global::ConsoleSystem.Arg arg)
	{
		foreach (global::Inventory inventory in global::inv.Inventories(arg.PlayerClients))
		{
			if (inventory)
			{
				global::IHeldItem heldItem = inventory._activeItem as global::IHeldItem;
				if (object.ReferenceEquals(heldItem, null))
				{
					arg.ReplyWith(string.Format("Theres no active item for {0}", inventory.name));
					return;
				}
				global::ItemDataBlock itemDataBlock;
				if (((global::HeldItemDataBlock)heldItem.datablock).PollForAmmoDatablock(out itemDataBlock))
				{
					int @int = arg.GetInt(0, itemDataBlock._maxUses);
					int num = inventory.AddItemAmount(itemDataBlock, @int);
					arg.ReplyWith(string.Format("Gave {0} {1}", @int - num, itemDataBlock.name));
					return;
				}
				arg.ReplyWith(string.Format("{0} does not take any ammo?", heldItem));
				return;
			}
		}
		arg.ReplyWith(string.Format("Theres no inventory for {0}", arg.playerClient()));
	}

	// Token: 0x04001E56 RID: 7766
	private const string give_usage = "<case sensitive name of item> [number of stacks or uses=1] [number of ammo=random] [number of mod slots=random]";

	// Token: 0x04001E57 RID: 7767
	private const string giveplayer_usage = "<player name> <case sensitive name of item> [number of stacks or uses=1] [number of ammo=random] [number of mod slots=random]";

	// Token: 0x04001E58 RID: 7768
	[global::ConsoleSystem.Admin]
	public static int loglevel;

	// Token: 0x04001E59 RID: 7769
	[global::ConsoleSystem.Admin]
	public static bool clientupdates;

	// Token: 0x020006C7 RID: 1735
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private sealed class <OneInventory>c__Iterator48 : global::System.IDisposable, global::System.Collections.IEnumerator, global::System.Collections.IEnumerable, global::System.Collections.Generic.IEnumerable<global::Inventory>, global::System.Collections.Generic.IEnumerator<global::Inventory>
	{
		// Token: 0x06003B67 RID: 15207 RVA: 0x000D31A4 File Offset: 0x000D13A4
		public <OneInventory>c__Iterator48()
		{
		}

		// Token: 0x17000B22 RID: 2850
		// (get) Token: 0x06003B68 RID: 15208 RVA: 0x000D31AC File Offset: 0x000D13AC
		global::Inventory global::System.Collections.Generic.IEnumerator<global::Inventory>.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17000B23 RID: 2851
		// (get) Token: 0x06003B69 RID: 15209 RVA: 0x000D31B4 File Offset: 0x000D13B4
		object global::System.Collections.IEnumerator.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06003B6A RID: 15210 RVA: 0x000D31BC File Offset: 0x000D13BC
		[global::System.Diagnostics.DebuggerHidden]
		global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<Inventory>.GetEnumerator();
		}

		// Token: 0x06003B6B RID: 15211 RVA: 0x000D31C4 File Offset: 0x000D13C4
		[global::System.Diagnostics.DebuggerHidden]
		global::System.Collections.Generic.IEnumerator<global::Inventory> global::System.Collections.Generic.IEnumerable<global::Inventory>.GetEnumerator()
		{
			if (global::System.Threading.Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			global::inv.<OneInventory>c__Iterator48 <OneInventory>c__Iterator = new global::inv.<OneInventory>c__Iterator48();
			<OneInventory>c__Iterator.inventory = inventory;
			return <OneInventory>c__Iterator;
		}

		// Token: 0x06003B6C RID: 15212 RVA: 0x000D31F8 File Offset: 0x000D13F8
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			switch (num)
			{
			case 0U:
				this.$current = inventory;
				this.$PC = 1;
				return true;
			case 1U:
				this.$PC = -1;
				break;
			}
			return false;
		}

		// Token: 0x06003B6D RID: 15213 RVA: 0x000D324C File Offset: 0x000D144C
		[global::System.Diagnostics.DebuggerHidden]
		public void Dispose()
		{
			this.$PC = -1;
		}

		// Token: 0x06003B6E RID: 15214 RVA: 0x000D3258 File Offset: 0x000D1458
		[global::System.Diagnostics.DebuggerHidden]
		public void Reset()
		{
			throw new global::System.NotSupportedException();
		}

		// Token: 0x04001E5A RID: 7770
		internal global::Inventory inventory;

		// Token: 0x04001E5B RID: 7771
		internal int $PC;

		// Token: 0x04001E5C RID: 7772
		internal global::Inventory $current;

		// Token: 0x04001E5D RID: 7773
		internal global::Inventory <$>inventory;
	}

	// Token: 0x020006C8 RID: 1736
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private sealed class <OnePlayerClient>c__Iterator49 : global::System.IDisposable, global::System.Collections.IEnumerator, global::System.Collections.IEnumerable, global::System.Collections.Generic.IEnumerable<global::PlayerClient>, global::System.Collections.Generic.IEnumerator<global::PlayerClient>
	{
		// Token: 0x06003B6F RID: 15215 RVA: 0x000D3260 File Offset: 0x000D1460
		public <OnePlayerClient>c__Iterator49()
		{
		}

		// Token: 0x17000B24 RID: 2852
		// (get) Token: 0x06003B70 RID: 15216 RVA: 0x000D3268 File Offset: 0x000D1468
		global::PlayerClient global::System.Collections.Generic.IEnumerator<global::PlayerClient>.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17000B25 RID: 2853
		// (get) Token: 0x06003B71 RID: 15217 RVA: 0x000D3270 File Offset: 0x000D1470
		object global::System.Collections.IEnumerator.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06003B72 RID: 15218 RVA: 0x000D3278 File Offset: 0x000D1478
		[global::System.Diagnostics.DebuggerHidden]
		global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<PlayerClient>.GetEnumerator();
		}

		// Token: 0x06003B73 RID: 15219 RVA: 0x000D3280 File Offset: 0x000D1480
		[global::System.Diagnostics.DebuggerHidden]
		global::System.Collections.Generic.IEnumerator<global::PlayerClient> global::System.Collections.Generic.IEnumerable<global::PlayerClient>.GetEnumerator()
		{
			if (global::System.Threading.Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			global::inv.<OnePlayerClient>c__Iterator49 <OnePlayerClient>c__Iterator = new global::inv.<OnePlayerClient>c__Iterator49();
			<OnePlayerClient>c__Iterator.playerClient = playerClient;
			return <OnePlayerClient>c__Iterator;
		}

		// Token: 0x06003B74 RID: 15220 RVA: 0x000D32B4 File Offset: 0x000D14B4
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			switch (num)
			{
			case 0U:
				this.$current = playerClient;
				this.$PC = 1;
				return true;
			case 1U:
				this.$PC = -1;
				break;
			}
			return false;
		}

		// Token: 0x06003B75 RID: 15221 RVA: 0x000D3308 File Offset: 0x000D1508
		[global::System.Diagnostics.DebuggerHidden]
		public void Dispose()
		{
			this.$PC = -1;
		}

		// Token: 0x06003B76 RID: 15222 RVA: 0x000D3314 File Offset: 0x000D1514
		[global::System.Diagnostics.DebuggerHidden]
		public void Reset()
		{
			throw new global::System.NotSupportedException();
		}

		// Token: 0x04001E5E RID: 7774
		internal global::PlayerClient playerClient;

		// Token: 0x04001E5F RID: 7775
		internal int $PC;

		// Token: 0x04001E60 RID: 7776
		internal global::PlayerClient $current;

		// Token: 0x04001E61 RID: 7777
		internal global::PlayerClient <$>playerClient;
	}

	// Token: 0x020006C9 RID: 1737
	[global::System.Runtime.CompilerServices.CompilerGenerated]
	private sealed class <Inventories>c__Iterator4A : global::System.IDisposable, global::System.Collections.IEnumerator, global::System.Collections.IEnumerable, global::System.Collections.Generic.IEnumerable<global::Inventory>, global::System.Collections.Generic.IEnumerator<global::Inventory>
	{
		// Token: 0x06003B77 RID: 15223 RVA: 0x000D331C File Offset: 0x000D151C
		public <Inventories>c__Iterator4A()
		{
		}

		// Token: 0x17000B26 RID: 2854
		// (get) Token: 0x06003B78 RID: 15224 RVA: 0x000D3324 File Offset: 0x000D1524
		global::Inventory global::System.Collections.Generic.IEnumerator<global::Inventory>.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17000B27 RID: 2855
		// (get) Token: 0x06003B79 RID: 15225 RVA: 0x000D332C File Offset: 0x000D152C
		object global::System.Collections.IEnumerator.Current
		{
			[global::System.Diagnostics.DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06003B7A RID: 15226 RVA: 0x000D3334 File Offset: 0x000D1534
		[global::System.Diagnostics.DebuggerHidden]
		global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<Inventory>.GetEnumerator();
		}

		// Token: 0x06003B7B RID: 15227 RVA: 0x000D333C File Offset: 0x000D153C
		[global::System.Diagnostics.DebuggerHidden]
		global::System.Collections.Generic.IEnumerator<global::Inventory> global::System.Collections.Generic.IEnumerable<global::Inventory>.GetEnumerator()
		{
			if (global::System.Threading.Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			global::inv.<Inventories>c__Iterator4A <Inventories>c__Iterator4A = new global::inv.<Inventories>c__Iterator4A();
			<Inventories>c__Iterator4A.clients = clients;
			return <Inventories>c__Iterator4A;
		}

		// Token: 0x06003B7C RID: 15228 RVA: 0x000D3370 File Offset: 0x000D1570
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0U:
				enumerator = clients.GetEnumerator();
				num = 0xFFFFFFFDU;
				break;
			case 1U:
				break;
			default:
				return false;
			}
			try
			{
				switch (num)
				{
				}
				while (enumerator.MoveNext())
				{
					pc = enumerator.Current;
					if (pc)
					{
						controllable = pc.rootControllable;
						if (controllable)
						{
							character = controllable.idMain;
							if (character)
							{
								this.$current = character.GetLocal<global::Inventory>();
								this.$PC = 1;
								flag = true;
								return true;
							}
						}
					}
				}
			}
			finally
			{
				if (!flag)
				{
					if (enumerator != null)
					{
						enumerator.Dispose();
					}
				}
			}
			this.$PC = -1;
			return false;
		}

		// Token: 0x06003B7D RID: 15229 RVA: 0x000D34A0 File Offset: 0x000D16A0
		[global::System.Diagnostics.DebuggerHidden]
		public void Dispose()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			switch (num)
			{
			case 1U:
				try
				{
				}
				finally
				{
					if (enumerator != null)
					{
						enumerator.Dispose();
					}
				}
				break;
			}
		}

		// Token: 0x06003B7E RID: 15230 RVA: 0x000D3504 File Offset: 0x000D1704
		[global::System.Diagnostics.DebuggerHidden]
		public void Reset()
		{
			throw new global::System.NotSupportedException();
		}

		// Token: 0x04001E62 RID: 7778
		internal global::System.Collections.Generic.IEnumerable<global::PlayerClient> clients;

		// Token: 0x04001E63 RID: 7779
		internal global::System.Collections.Generic.IEnumerator<global::PlayerClient> <$s_518>__0;

		// Token: 0x04001E64 RID: 7780
		internal global::PlayerClient <pc>__1;

		// Token: 0x04001E65 RID: 7781
		internal global::Controllable <controllable>__2;

		// Token: 0x04001E66 RID: 7782
		internal global::Character <character>__3;

		// Token: 0x04001E67 RID: 7783
		internal int $PC;

		// Token: 0x04001E68 RID: 7784
		internal global::Inventory $current;

		// Token: 0x04001E69 RID: 7785
		internal global::System.Collections.Generic.IEnumerable<global::PlayerClient> <$>clients;
	}
}
