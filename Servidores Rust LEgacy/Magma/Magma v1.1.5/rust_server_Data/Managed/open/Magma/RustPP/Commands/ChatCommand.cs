using System;
using System.Collections.Generic;
using Magma;
using RustPP.Permissions;

namespace RustPP.Commands
{
	// Token: 0x0200002F RID: 47
	public abstract class ChatCommand
	{
		// Token: 0x17000059 RID: 89
		// (get) Token: 0x060001F7 RID: 503 RVA: 0x00007EFE File Offset: 0x000060FE
		// (set) Token: 0x060001F8 RID: 504 RVA: 0x00007F06 File Offset: 0x00006106
		public string Command
		{
			get
			{
				return this._cmd;
			}
			set
			{
				this._cmd = value;
			}
		}

		// Token: 0x1700005A RID: 90
		// (get) Token: 0x060001F9 RID: 505 RVA: 0x00007F0F File Offset: 0x0000610F
		public bool Enabled
		{
			get
			{
				return global::RustPP.Core.config.isCommandOn(this.Command.Remove(0, 1));
			}
		}

		// Token: 0x1700005B RID: 91
		// (get) Token: 0x060001FA RID: 506 RVA: 0x00007F28 File Offset: 0x00006128
		public bool AdminRestricted
		{
			get
			{
				return this._adminRestricted;
			}
		}

		// Token: 0x1700005C RID: 92
		// (get) Token: 0x060001FB RID: 507 RVA: 0x00007F30 File Offset: 0x00006130
		// (set) Token: 0x060001FC RID: 508 RVA: 0x00007F38 File Offset: 0x00006138
		public string AdminFlags
		{
			get
			{
				return this._adminFlags;
			}
			set
			{
				this._adminRestricted = true;
				this._adminFlags = value;
			}
		}

		// Token: 0x060001FD RID: 509 RVA: 0x00007F48 File Offset: 0x00006148
		public ChatCommand()
		{
		}

		// Token: 0x060001FE RID: 510 RVA: 0x00007F50 File Offset: 0x00006150
		public static void AddCommand(string cmdString, global::RustPP.Commands.ChatCommand command)
		{
			command.Command = cmdString;
			global::RustPP.Commands.ChatCommand.classInstances.Add(command);
		}

		// Token: 0x060001FF RID: 511 RVA: 0x00007F64 File Offset: 0x00006164
		public static global::RustPP.Commands.ChatCommand GetCommand(string cmdString)
		{
			foreach (global::RustPP.Commands.ChatCommand chatCommand in global::RustPP.Commands.ChatCommand.classInstances)
			{
				if (chatCommand.Command.Remove(0, 1) == cmdString)
				{
					return chatCommand;
				}
			}
			return null;
		}

		// Token: 0x06000200 RID: 512 RVA: 0x00007FCC File Offset: 0x000061CC
		public static void CallCommand(string cmd, ref global::ConsoleSystem.Arg arg, ref string[] chatArgs)
		{
			foreach (global::RustPP.Commands.ChatCommand chatCommand in global::RustPP.Commands.ChatCommand.classInstances)
			{
				if (chatCommand.Command == cmd)
				{
					if (!chatCommand.Enabled)
					{
						global::Magma.Util.sayUser(arg.argUser.networkPlayer, "This feature has been disabled on this server.");
						break;
					}
					if (!chatCommand.AdminRestricted)
					{
						chatCommand.Execute(ref arg, ref chatArgs);
						break;
					}
					if (chatCommand.AdminFlags == "RCON")
					{
						if (arg.argUser.admin)
						{
							chatCommand.Execute(ref arg, ref chatArgs);
							break;
						}
						global::Magma.Util.sayUser(arg.argUser.networkPlayer, "You need RCON access to be able to use this command.");
						break;
					}
					else
					{
						if (!global::RustPP.Permissions.Administrator.IsAdmin(arg.argUser.userID))
						{
							global::Magma.Util.sayUser(arg.argUser.networkPlayer, "You don't have access to use this command");
							break;
						}
						if (global::RustPP.Permissions.Administrator.GetAdmin(arg.argUser.userID).HasPermission(chatCommand.AdminFlags))
						{
							chatCommand.Execute(ref arg, ref chatArgs);
							break;
						}
						global::Magma.Util.sayUser(arg.argUser.networkPlayer, "Only administrators with the " + chatCommand.AdminFlags.ToString() + " permission can use that command.");
						break;
					}
				}
			}
		}

		// Token: 0x06000201 RID: 513
		public abstract void Execute(ref global::ConsoleSystem.Arg Arguments, ref string[] ChatArguments);

		// Token: 0x06000202 RID: 514 RVA: 0x00008140 File Offset: 0x00006340
		// Note: this type is marked as 'beforefieldinit'.
		static ChatCommand()
		{
		}

		// Token: 0x04000076 RID: 118
		private static global::System.Collections.Generic.List<global::RustPP.Commands.ChatCommand> classInstances = new global::System.Collections.Generic.List<global::RustPP.Commands.ChatCommand>();

		// Token: 0x04000077 RID: 119
		private string _cmd;

		// Token: 0x04000078 RID: 120
		private bool _adminRestricted;

		// Token: 0x04000079 RID: 121
		private string _adminFlags;
	}
}
