using System;
using Magma;
using RustPP.Social;

namespace RustPP.Commands
{
	// Token: 0x02000053 RID: 83
	public class UnfriendCommand : global::RustPP.Commands.ChatCommand
	{
		// Token: 0x06000259 RID: 601 RVA: 0x0000B750 File Offset: 0x00009950
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
					if (friendList == null)
					{
						global::Magma.Util.sayUser(Arguments.argUser.networkPlayer, "You currently have no friends.");
						return;
					}
					string str;
					if (playerClient == null)
					{
						if (!friendList.isFriendWith(text))
						{
							global::Magma.Util.sayUser(Arguments.argUser.networkPlayer, "You are not friends with " + text);
							return;
						}
						friendList.RemoveFriend(text);
						str = friendList.GetRealName(text);
					}
					else
					{
						if (!friendList.isFriendWith(playerClient.userID))
						{
							global::Magma.Util.sayUser(Arguments.argUser.networkPlayer, "You are not friends with " + text);
							return;
						}
						friendList.RemoveFriend(playerClient.userID);
						str = playerClient.netUser.displayName;
					}
					global::Magma.Util.sayUser(Arguments.argUser.networkPlayer, "You have removed " + str + " from your friends list.");
					if (friendList.HasFriends())
					{
						friendsCommand.GetFriendsLists()[Arguments.argUser.userID] = friendList;
						return;
					}
					friendsCommand.GetFriendsLists().Remove(Arguments.argUser.userID);
					return;
				}
			}
			else
			{
				global::Magma.Util.sayUser(Arguments.argUser.networkPlayer, "Friends Management Usage:   /unfriend \"playerName\"");
			}
		}

		// Token: 0x0600025A RID: 602 RVA: 0x0000B918 File Offset: 0x00009B18
		public UnfriendCommand()
		{
		}
	}
}
