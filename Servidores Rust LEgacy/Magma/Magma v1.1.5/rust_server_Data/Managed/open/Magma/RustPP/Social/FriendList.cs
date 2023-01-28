using System;
using System.Collections;
using Magma;

namespace RustPP.Social
{
	// Token: 0x0200005E RID: 94
	[global::System.Serializable]
	public class FriendList : global::System.Collections.ArrayList
	{
		// Token: 0x060002A1 RID: 673 RVA: 0x0000D4CC File Offset: 0x0000B6CC
		public bool isFriendWith(string name)
		{
			bool result = false;
			foreach (object obj in this)
			{
				global::RustPP.Social.FriendList.Friend friend = (global::RustPP.Social.FriendList.Friend)obj;
				if (friend.GetDisplayName().ToLower() == name.ToLower())
				{
					result = true;
				}
			}
			return result;
		}

		// Token: 0x060002A2 RID: 674 RVA: 0x0000D538 File Offset: 0x0000B738
		public bool isFriendWith(ulong userID)
		{
			bool result = false;
			foreach (object obj in this)
			{
				global::RustPP.Social.FriendList.Friend friend = (global::RustPP.Social.FriendList.Friend)obj;
				if (friend.GetUserID() == userID)
				{
					result = true;
				}
			}
			return result;
		}

		// Token: 0x060002A3 RID: 675 RVA: 0x0000D594 File Offset: 0x0000B794
		public void AddFriend(string fName, ulong fUID)
		{
			this.Add(new global::RustPP.Social.FriendList.Friend(fName, fUID));
		}

		// Token: 0x060002A4 RID: 676 RVA: 0x0000D5A4 File Offset: 0x0000B7A4
		public void RemoveFriend(string fName)
		{
			foreach (object obj in this)
			{
				global::RustPP.Social.FriendList.Friend friend = (global::RustPP.Social.FriendList.Friend)obj;
				if (fName.ToLower() == friend.GetDisplayName().ToLower())
				{
					this.Remove(friend);
					break;
				}
			}
		}

		// Token: 0x060002A5 RID: 677 RVA: 0x0000D614 File Offset: 0x0000B814
		public void RemoveFriend(ulong fUID)
		{
			foreach (object obj in this)
			{
				global::RustPP.Social.FriendList.Friend friend = (global::RustPP.Social.FriendList.Friend)obj;
				if (fUID == friend.GetUserID())
				{
					this.Remove(friend);
					break;
				}
			}
		}

		// Token: 0x060002A6 RID: 678 RVA: 0x0000D674 File Offset: 0x0000B874
		public bool HasFriends()
		{
			return this.Count != 0;
		}

		// Token: 0x060002A7 RID: 679 RVA: 0x0000D684 File Offset: 0x0000B884
		public string GetRealName(string name)
		{
			foreach (object obj in this)
			{
				global::RustPP.Social.FriendList.Friend friend = (global::RustPP.Social.FriendList.Friend)obj;
				if (name.ToLower() == friend.GetDisplayName().ToLower())
				{
					return friend.GetDisplayName();
				}
			}
			return name;
		}

		// Token: 0x060002A8 RID: 680 RVA: 0x0000D6F8 File Offset: 0x0000B8F8
		public void OutputList(ref global::ConsoleSystem.Arg arg)
		{
			global::System.Collections.ArrayList arrayList = new global::System.Collections.ArrayList();
			global::System.Collections.ArrayList arrayList2 = new global::System.Collections.ArrayList();
			foreach (object obj in this)
			{
				global::RustPP.Social.FriendList.Friend friend = (global::RustPP.Social.FriendList.Friend)obj;
				global::PlayerClient playerClient;
				try
				{
					playerClient = global::PlayerClient.FindAllWithString(friend.GetUserID().ToString()).ToArray<global::PlayerClient>()[0];
				}
				catch (global::System.Exception)
				{
					arrayList2.Add(friend.GetDisplayName());
					continue;
				}
				arrayList.Add(playerClient.netUser.displayName + " (Online)");
				friend.SetDisplayName(playerClient.netUser.displayName);
			}
			if (arrayList.Count > 0)
			{
				global::Magma.Util.sayUser(arg.argUser.networkPlayer, string.Concat(new object[]
				{
					"You currently have ",
					arrayList.Count,
					" friend",
					(arrayList.Count > 1) ? "s" : "",
					" online."
				}));
			}
			else
			{
				global::Magma.Util.sayUser(arg.argUser.networkPlayer, "None of your friend is playing right now.");
			}
			foreach (object obj2 in arrayList2)
			{
				string value = (string)obj2;
				arrayList.Add(value);
			}
			int num = 0;
			int num2 = 0;
			string text = "";
			foreach (object obj3 in arrayList)
			{
				string str = (string)obj3;
				num2++;
				if (num2 >= 0x3C)
				{
					num = 0;
					break;
				}
				text = text + str + ",  ";
				if (num == 6)
				{
					num = 0;
					global::Magma.Util.sayUser(arg.argUser.networkPlayer, text.Substring(0, text.Length - 3));
					text = "";
				}
				else
				{
					num++;
				}
			}
			if (num != 0)
			{
				global::Magma.Util.sayUser(arg.argUser.networkPlayer, text.Substring(0, text.Length - 3));
			}
		}

		// Token: 0x060002A9 RID: 681 RVA: 0x0000D964 File Offset: 0x0000BB64
		public FriendList()
		{
		}

		// Token: 0x0200005F RID: 95
		[global::System.Serializable]
		private class Friend
		{
			// Token: 0x060002AA RID: 682 RVA: 0x0000D96C File Offset: 0x0000BB6C
			public Friend(string dName, ulong uID)
			{
				this._displayName = dName;
				this._userID = uID;
			}

			// Token: 0x060002AB RID: 683 RVA: 0x0000D982 File Offset: 0x0000BB82
			public void SetDisplayName(string name)
			{
				this._displayName = name;
			}

			// Token: 0x060002AC RID: 684 RVA: 0x0000D98B File Offset: 0x0000BB8B
			public string GetDisplayName()
			{
				return this._displayName;
			}

			// Token: 0x060002AD RID: 685 RVA: 0x0000D993 File Offset: 0x0000BB93
			public ulong GetUserID()
			{
				return this._userID;
			}

			// Token: 0x04000093 RID: 147
			private ulong _userID;

			// Token: 0x04000094 RID: 148
			private string _displayName;
		}
	}
}
