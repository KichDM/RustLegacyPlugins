using System.Collections.Generic;
using System;
using System.Reflection;
using System.Data;
using UnityEngine;
using Oxide.Core;
using Oxide.Core.Plugins;
using RustProto;
using System.Linq;
using System.Collections.Generic;
using RustProto;
using Oxide.Core.Libraries;
using RustExtended;
// Reference: Oxide.Ext.RustLegacy
// Reference: Facepunch.ID
// Reference: Facepunch.MeshBatch
// Reference: Google.ProtocolBuffers

namespace Oxide.Plugins
{
    [Info("RNDAntiFloodchat", "lutSEfer", "1.0.0")]
    class RNDAntiFloodchat : RustLegacyPlugin
    {
		public string messageconnector = "[color#00FA9A]Вы Флудерастите, ждите ";
		int TimerAcceptortime=3;
		string ChatName= RustExtended.Core.ServerName ;
		const string quote = "\"";
		static Dictionary<string, DataFloodchat> DataflDt = new Dictionary<string, DataFloodchat>();
		DataFloodchat dataflood;
		class DataFloodchat
			{
				public string userid {get; set;}
				public DateTime lastchattime{get; set;}
			}
		private DataFloodchat GetPlayerData(string ID)
			{
				if(!DataflDt.TryGetValue(ID, out dataflood)){
					dataflood = new DataFloodchat();
					DataflDt.Add(ID, dataflood);
				}
				return dataflood;
			}		
		private void OnPlayerConnected(NetUser netuser)
		{
			dataflood = GetPlayerData(netuser.userID.ToString());
			if(dataflood.userid == null)
			{
				dataflood.lastchattime = DateTime.Now;
			}
		}
		object OnPlayerChat(NetUser netuser, string message)
        {
			dataflood = GetPlayerData(netuser.userID.ToString());
			///////////////////////
			DateTime Lastchattime = dataflood.lastchattime;
			DateTime CurTime = DateTime.Now;
			TimeSpan ts = CurTime - Lastchattime;
			int raznica = ts.Seconds;
			if (raznica <=TimerAcceptortime)
			{
				string currentmessage = messageconnector + " ";
				currentmessage=currentmessage+TimerAcceptortime;
				ConsoleNetworker.SendClientCommand(netuser.networkPlayer, "chat.add " +quote+ ChatName + quote+ Facepunch.Utility.String.QuoteSafe(currentmessage+" секунд ")+quote);
				return true;
			}
			else
			{
				dataflood.lastchattime = DateTime.Now;
				return null;
			}
        }
	}
}