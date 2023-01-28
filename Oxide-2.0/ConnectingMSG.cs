using UnityEngine;
using Oxide.Core;
using Oxide.Core.Plugins;
using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Oxide.Core.Libraries;
using Newtonsoft.Json;

namespace Oxide.Plugins
{
	[Info("ConnectingMSG", "mcnovinho08", "0.1.0")]
	[Description("Differentiated connection messages for your server!")]
	
	class ConnectingMSG : RustLegacyPlugin
	{		

		static JsonSerializerSettings jsonsettings;
		
		static string chatPrefix = "Connecting";
		
		static bool MensagemConnect = true;
		static bool MensagemDisconnect = true;
		
		
		void OnServerInitialized()
		{
			CheckCfg<string>("Settings: ChatPrefix", ref chatPrefix);
			CheckCfg<bool>("Settings: Message Connect", ref MensagemConnect);
			CheckCfg<bool>("Settings: Connecting : {Player} Se conecto a [color #0080FF]♛[color #FF4000]『Ｎｏｖａ[color #088A08]Ｌａｎｄ』[color #0080FF]♛ Pais: {1} Ciudad: {2}|{3}", ref Mensagem1);
			CheckCfg<bool>("Settings: Connecting : {Player} Se conecto a [color #0080FF]♛[color #FF4000]『Ｎｏｖａ[color #088A08]Ｌａｎｄ』[color #0080FF]♛ Pais: {1} Ciudad: {2} Estado: {3}", ref Mensagem2);
			CheckCfg<bool>("Settings: Connecting : {Player} Se conecto a [color #0080FF]♛[color #FF4000]『Ｎｏｖａ[color #088A08]Ｌａｎｄ』[color #0080FF]♛ Pais: {1} Ciudad: {2}", ref Mensagem3);
			CheckCfg<bool>("Settings: Connecting : {Player} Se conecto a [color #0080FF]♛[color #FF4000]『Ｎｏｖａ[color #088A08]Ｌａｎｄ』[color #0080FF]♛ Ciudad: {1}", ref Mensagem4);
			CheckCfg<bool>("Settings: Connecting : {Player} Se conecto a [color #0080FF]♛[color #FF4000]『Ｎｏｖａ[color #088A08]Ｌａｎｄ』[color #0080FF]♛ Estado: {1}", ref Mensagem5);
			CheckCfg<bool>("Settings: Message Disconnect", ref MensagemDisconnect);
			LoadDefaultMessages();
			SaveConfig();//
			
		}
		protected override void LoadDefaultConfig(){} 
		private void CheckCfg<T>(string Key, ref T var){
			if(Config[Key] is T)
			var = (T)Config[Key];  
			else
			Config[Key] = var;
		}
		

		string GetMessage(string key, string Id = null) => lang.GetMessage(key, this, Id);
		void LoadDefaultMessages()
		{
			var message = new Dictionary<string, string>
			{//
				{"PlayerConnect1", "[color orange]{0} [color green]Entro a Se conecto a [color #0080FF]♛[color #FF4000]『Ｎｏｖａ[color #088A08]Ｌａｎｄ』[color #0080FF]♛ [color red]Pais: [color aqua]{1} [color red]Ciudad: [color aqua]{2}|{3}"},
				{"PlayerConnect2", "[color blue]✓[color orange] {0} [color green]Se conecto a [color #0080FF]♛[color #FF4000]『Ｎｏｖａ[color #088A08]Ｌａｎｄ』[color #0080FF]♛ [color clear]Pais: [color aqua]{1} [color clear]Ciudad: [color aqua]{2} [color clear]Estado: [color aqua]{3}"},
				{"PlayerConnect3", "{0} Se conecto a [color #0080FF]♛[color #FF4000]『Ｎｏｖａ[color #088A08]Ｌａｎｄ』[color #0080FF]♛ Pais: {1} City: {2} !"},
				{"PlayerConnect4", "{0} Se conecto a [color #0080FF]♛[color #FF4000]『Ｎｏｖａ[color #088A08]Ｌａｎｄ』[color #0080FF]♛ Ciudad: {1} !"},
				{"PlayerConnect5", "{0} Se conecto a [color #0080FF]♛[color #FF4000]『Ｎｏｖａ[color #088A08]Ｌａｎｄ』[color #0080FF]♛ Estado: {1} !"},
				{"PlayerDisconnect", "[color red]✖ [color orange] {0} [color yellow]Se fue de [color #0080FF]♛[color #FF4000]『Ｎｏｖａ[color #088A08]Ｌａｎｄ』[color #0080FF]♛"}
				
			};
			lang.RegisterMessages(message, this);
		}
		
		static bool Mensagem1 = true;
		static bool Mensagem2 = false;
		static bool Mensagem3 = false;
		static bool Mensagem4 = false;
		static bool Mensagem5 = false;
		
		void OnPlayerConnected(NetUser netuser)
		{
			string Name = netuser.displayName;
			string Ip = netuser.networkPlayer.externalIP;
			string ID = netuser.userID.ToString();
			if(Ip != "127.0.0.1"){
				var url = string.Format("http://ip-api.com/json/" + Ip);
				Interface.GetMod().GetLibrary<WebRequests>("WebRequests").EnqueueGet(url, (code, response) =>{ 
					var jsonresponse = JsonConvert.DeserializeObject<Dictionary<string, object>>(response, jsonsettings);
					var country = (jsonresponse["country"].ToString());
					var countryCode = (jsonresponse["countryCode"].ToString());
					var region = (jsonresponse["region"].ToString());
					var regionName = (jsonresponse["regionName"].ToString());
                    var city = (jsonresponse["city"].ToString());
					if (!Mensagem1) { rust.BroadcastChat(chatPrefix, string.Format(GetMessage("PlayerConnect1"), Name, country, city, region)); }
					else if (!Mensagem2) { rust.BroadcastChat(chatPrefix, string.Format(GetMessage("PlayerConnect2"), Name, country, city, regionName)); }
				    else if (!Mensagem3) { rust.BroadcastChat(chatPrefix, string.Format(GetMessage("PlayerConnect3"), Name, country, city)); }
				    else if (!Mensagem4) { rust.BroadcastChat(chatPrefix, string.Format(GetMessage("PlayerConnect4"), Name, city)); }
				    else if (!Mensagem5) { rust.BroadcastChat(chatPrefix, string.Format(GetMessage("PlayerConnect5"), Name, regionName)); }
					Puts(string.Format(netuser.displayName + " ( "+ netuser.userID.ToString() +"  ) Entro al servidor"));
				}, this);
			}
			
		}

		
        void OnPlayerDisconnected(uLink.NetworkPlayer networkPlayer)
		{
            NetUser netUser = networkPlayer.GetLocalData<NetUser>();
			rust.BroadcastChat(chatPrefix, string.Format(GetMessage("[color red]✖ [color orange] {0} [color yellow]Se fue de [color #0080FF]♛[color #FF4000]『Ｎｏｖａ[color #088A08]Ｌａｎｄ』[color #0080FF]♛"), netUser.displayName));
		Puts(string.Format(netUser.displayName + " ( "+  netUser.userID.ToString() + "[color red]✖ [color orange] {0} [color yellow]Se fue de [color #0080FF]♛[color #FF4000]『Ｎｏｖａ[color #088A08]Ｌａｎｄ』[color #0080FF]♛"));
		}

	}
}