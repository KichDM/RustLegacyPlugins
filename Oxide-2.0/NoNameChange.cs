using System;
using System.Collections.Generic;
using Oxide.Core;

namespace Oxide.Plugins
{
  [Info("No Name Change", "thenetimp", "0.0.2")]
  [Description("Kicks people who change their game name from wipe to wipe")]
  class NoNameChange : RustPlugin
  {
    object CanClientLogin(Network.Connection conn)
    {
      var steamId = conn.userid.ToString();
      var username = conn.username;

      // Foreach stored player check if the steamId
      // exists for a different username
      foreach (var player in storedData.Players)
      {
        if(player.SteamId == steamId)
        {
          if(player.Username != username)
          {
            Puts("Fail login");
            return "Username changes are not allowed. You must log in with username: " + player.Username;
          }
        }
      }

      // Create the user info record.
      var info = new PlayerInfo(steamId, username);

      // If the info record isn't in the data file add it.
      if (!storedData.Players.Contains(info))
      {
        Puts("Saving user to datafile");
        storedData.Players.Add(info);
        Interface.Oxide.DataFileSystem.WriteObject("NoNameChange", storedData);
      }

      return true;
    }

    StoredData storedData;

    void Loaded()
    {
        storedData = Interface.Oxide.DataFileSystem.ReadObject<StoredData>("NoNameChange");
    }

    class StoredData
    {
      public HashSet<PlayerInfo> Players = new HashSet<PlayerInfo>();

      public StoredData()
      {
      }
    }

    class PlayerInfo
    {
      public string SteamId;
      public string Username;

      public PlayerInfo()
      {
      }

      public PlayerInfo(string steamId, string username)
      {
          SteamId = steamId;
          Username = username;
      }
    }
  }
}