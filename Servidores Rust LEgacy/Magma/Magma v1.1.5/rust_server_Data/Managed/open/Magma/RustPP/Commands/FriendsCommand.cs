using System;
using System.Collections;
using Magma;
using RustPP.Social;

namespace RustPP.Commands
{
	// Token: 0x02000036 RID: 54
	public class FriendsCommand : global::RustPP.Commands.ChatCommand
	{
		// Token: 0x06000210 RID: 528 RVA: 0x00008E0C File Offset: 0x0000700C
		public void SetFriendsLists(global::System.Collections.Hashtable fl)
		{
			global::RustPP.Commands.FriendsCommand.friendsLists = fl;
		}

		// Token: 0x06000211 RID: 529 RVA: 0x00008E14 File Offset: 0x00007014
		public global::System.Collections.Hashtable GetFriendsLists()
		{
			return global::RustPP.Commands.FriendsCommand.friendsLists;
		}

		// Token: 0x06000212 RID: 530 RVA: 0x00008E1C File Offset: 0x0000701C
		public override void Execute(ref global::ConsoleSystem.Arg Arguments, ref string[] ChatArguments)
		{
			if (!global::RustPP.Commands.FriendsCommand.friendsLists.ContainsKey(Arguments.argUser.userID))
			{
				global::Magma.Util.sayUser(Arguments.argUser.networkPlayer, "You currently have no friend.");
				return;
			}
			global::RustPP.Social.FriendList friendList = (global::RustPP.Social.FriendList)global::RustPP.Commands.FriendsCommand.friendsLists[Arguments.argUser.userID];
			friendList.OutputList(ref Arguments);
		}

		// Token: 0x06000213 RID: 531 RVA: 0x00008E91 File Offset: 0x00007091
		public FriendsCommand()
		{
		}

		// Token: 0x06000214 RID: 532 RVA: 0x00008E85 File Offset: 0x00007085
		// Note: this type is marked as 'beforefieldinit'.
		static FriendsCommand()
		{
		}

		// Token: 0x0400007A RID: 122
		public static global::System.Collections.Hashtable friendsLists = new global::System.Collections.Hashtable();
	}
}
