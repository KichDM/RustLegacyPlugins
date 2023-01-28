using System;
using Magma;
using RustPP.Social;

namespace RustPP.Commands
{
	// Token: 0x02000033 RID: 51
	internal class AddFriendCommand : global::RustPP.Commands.ChatCommand
	{
		// Token: 0x06000209 RID: 521 RVA: 0x000086CC File Offset: 0x000068CC
		public override void Execute(ref global::ConsoleSystem.Arg Arguments, ref string[] ChatArguments)
		{
			if (ChatArguments != null)
			{
				string text = "";
				for (int i = 0; i < ChatArguments.Length; i++)
				{
					text = text + ChatArguments[i] + " ";
				}
				text = text.Trim();
				if (text != null)
				{
					global::PlayerClient playerClient = null;
					try
					{
						playerClient = global::PlayerClient.FindAllWithName(text, global::System.StringComparison.CurrentCultureIgnoreCase).ToArray<global::PlayerClient>()[0];
					}
					catch (global::System.Exception)
					{
						playerClient = null;
					}
					global::RustPP.Commands.FriendsCommand friendsCommand = (global::RustPP.Commands.FriendsCommand)global::RustPP.Commands.ChatCommand.GetCommand("friends");
					global::RustPP.Social.FriendList friendList = (global::RustPP.Social.FriendList)friendsCommand.GetFriendsLists()[Arguments.argUser.userID];
					if (playerClient == null)
					{
						global::Magma.Util.sayUser(Arguments.argUser.networkPlayer, "No player found with the name: " + text);
						return;
					}
					if (Arguments.argUser.userID == playerClient.userID)
					{
						global::Magma.Util.sayUser(Arguments.argUser.networkPlayer, "You can't add yourself as a friend !");
						return;
					}
					if (friendList != null)
					{
						if (friendList.isFriendWith(playerClient.userID))
						{
							global::Magma.Util.sayUser(Arguments.argUser.networkPlayer, "You are already friend with " + playerClient.netUser.displayName + ".");
							return;
						}
					}
					else
					{
						friendList = new global::RustPP.Social.FriendList();
					}
					friendList.AddFriend(playerClient.netUser.displayName, playerClient.userID);
					friendsCommand.GetFriendsLists()[Arguments.argUser.userID] = friendList;
					global::Magma.Util.sayUser(Arguments.argUser.networkPlayer, "You have added " + playerClient.netUser.displayName + " to your friend list.");
					return;
				}
			}
			else
			{
				global::Magma.Util.sayUser(Arguments.argUser.networkPlayer, "Friends Management Usage:   /addfriend  \"playerName\"");
			}
		}

		// Token: 0x0600020A RID: 522 RVA: 0x0000887C File Offset: 0x00006A7C
		public AddFriendCommand()
		{
		}
	}
}
