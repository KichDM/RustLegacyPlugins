       // @@@ ---  Creator SPooCK --- @@@   //
      //   @@@ --- Wiper --- @@@     	   //
     //   @@@ --- Version 1.2.3 --- @@@   //
    //  								 //
   // 		░░░░░███████ ]▄▄▄▄▄▄▄▄  	//
  //		▂▄▅█████████▅▄▃▂      	   //
 //		Il███████████████████].	  	  //
// 		 ◥⊙▲⊙▲⊙▲⊙▲⊙▲⊙▲⊙▲⊙▲⊙▲⊙◤..  	 //

function On_Command(e,t,r){if(e.Admin&&"wipeall"==t){var a=Plugin.GetIni("Wiper");for(var i in World.Entities){var o=(i.Name,i.CreatorID.ToString()),n=i.OwnerID.ToString(),l=a.GetSetting("Protected ID",o),c=a.GetSetting("Protected ID",n);void 0==l&&void 0==c&&(Server.BroadcastFrom("DECAY SYSTEM","[color#00FFFF][ADMIN][/color] [color#00FF00]forced a SERVER WIPE ![/color] [color#FF0000]MAY CAUSE LAG STAND BY ![/color]"),Util.DestroyObject(i.Object.gameObject))}}if(e.Admin&&"wwipe"==t){var d=r[0].ToString(),m=0,S=null;for(var D in World.Entities)if("furn"==d&&"Furnace"==D.Name){var S="Furnace's";Util.DestroyObject(D.Object.gameObject),m++}else if("camp"==d&&"Campfire"==D.Name){var S="Camp Fire's";Util.DestroyObject(D.Object.gameObject),m++}else if("spike"==d&&"WooodSpikeWall"==D.Name){var S="Spike Wall's";Util.DestroyObject(D.Object.gameObject),m++}else if("spikel"==d&&"LargeWoodSpikeWall"==D.Name){var S="Large Spike Wall's";Util.DestroyObject(D.Object.gameObject),m++}else if("barr"==d&&"Barricade_Fence_Deployable"==D.Name){var S="Wood Barricade's";Util.DestroyObject(D.Object.gameObject),m++}else if("wbench"==d&&"Workbench"==D.Name){var S="Work Benche's";Util.DestroyObject(D.Object.gameObject),m++}else if("rbench"==d&&"RepairBench"==D.Name){var S="Repair Benche's";Util.DestroyObject(D.Object.gameObject),m++}else if("shelt"==d&&"Wood_Shelter"==D.Name){var S="Shelter's";Util.DestroyObject(D.Object.gameObject),m++}if(null!=S){e.Notice("Removed ► "+m+"▐ "+S+"▐");var S=null}else null==S&&e.Notice("Command not recognised: "+d)}if(e.Admin&&"wipe"==t){var T=r[0].ToString();if(r[0].match(/[0-9]/g)){var m=0;for(var W in World.Entities)if(0!=W.Health){var o=W.CreatorID.ToString(),n=W.OwnerID.ToString();(o==T||n==T)&&(m++,Util.DestroyObject(W.Object.gameObject))}e.Notice("Found ► "+m+"▐ objects for ►"+T+"▐")}else e.Notice("Use only numbers for correct IDs !")}if(e.Admin&&"wtreset"==t){var s=System.Environment.TickCount,a=Plugin.GetIni("Wiper"),p=36e5*a.GetSetting("Decay","Timer"),g=6e4*a.GetSetting("Decay","AnnTimer");Plugin.KillTimer("WiperT"),Plugin.KillTimer("WiperAN"),DataStore.Flush("WiperT"),DataStore.Flush("WiperAN"),System.Threading.Thread.Sleep(1e3),Plugin.CreateTimer("WiperT",p).Start(),Plugin.CreateTimer("WiperAN",g).Start(),DataStore.Add("WiperT","Time",p),DataStore.Add("WiperT","TimeLeft",s),DataStore.Add("WiperT","TimeO","On"),DataStore.Add("WiperT","TimeDEF",p),DataStore.Add("WiperAN","Time",g),DataStore.Add("WiperAN","TimeLeft",s),DataStore.Add("WiperAN","TimeO","On"),DataStore.Add("WiperAN","TimeDEFa",g),e.Notice("All timers has been reset !")}if(e.Admin&&"wtimer"==t){if(Plugin.GetTimer("WiperT")){var h=parseInt(DataStore.Get("WiperT","Time")),u=parseInt(DataStore.Get("WiperT","TimeLeft")),s=System.Environment.TickCount,A=h-(s-u),y=Math.round(A),F=parseInt(y/36e5),O=parseInt(y/6e4),b=parseInt(y/1e3),f=O-60*F,N=b-60*O;e.MessageFrom("Wiper","Decay timer is running: [color#FF0000]"+F+" hour(s) "+f+" min. "+N+" sec.")}else e.MessageFrom("Wiper","There is no Decay timer !");if(Plugin.GetTimer("WiperAN")){var C=parseInt(DataStore.Get("WiperAN","Time")),v=parseInt(DataStore.Get("WiperAN","TimeLeft")),G=System.Environment.TickCount,j=C-(G-v),M=Math.round(j),I=parseInt(M/6e4),P=parseInt(M/1e3),H=P-60*I;e.MessageFrom("Wiper","Announce timer is running: [color#FF0000]"+I+" min. "+H+" sec.")}else e.MessageFrom("Wiper","There is no Announce timer !")}if(e.Admin&&"wforce"==t&&(Server.BroadcastFrom("DECAY SYSTEM","[color#00FFFF][ADMIN][/color] [color#00FF00]forced a DECAY ![/color] [color#FF0000]MAY CAUSE LAG STAND BY ![/color]"),Plugin.KillTimer("WiperT"),DataStore.Flush("WiperT"),decay(hit)),"wcheck"==t){{var a=Plugin.GetIni("Wiper"),E=a.GetSetting("Decay","CheckMess"),k=a.GetSetting("Decay","TURN");a.GetSetting("Decay","B500"),a.GetSetting("Decay","B750"),a.GetSetting("Decay","B1000"),a.GetSetting("Decay","B1500"),a.GetSetting("Decay","B1800"),a.GetSetting("Decay","B2000"),a.GetSetting("Decay","B2500"),a.GetSetting("Decay","B5000")}if("true"==k){var B=DataStore.Get("WiperTC",e.SteamID);if("1"!=B)if(Plugin.GetTimer("CheckCD"))e.Notice("Checkin is processing. Try again after 30 sec.");else{Server.BroadcastFrom("DECAY SYSTEM",e.Name+" "+E),DataStore.Add("WiperTC",e.SteamID,"1"),e.Notice("You have checked your activity. Buildings HP restored !"),Plugin.CreateTimer("CheckCD",3e4).Start();var U=e.SteamID.ToString();for(var w in World.Entities)if(0!=w.Health){var L=w.Name,Y=w.CreatorID.ToString();Y==U&&(("Campfire"==L||"Furnace"==L||"WoodBox"==L||"WoodDoor"==L)&&w.Health<500&&(w.Health=500),"WooodSpikeWall"==L&&w.Health<750&&(w.Health=750),("MetalDoor"==L||"MetalStairs"==L||"MetalCeiling"==L||"MetalRamp"==L||"WoodBoxLarge"==L||"Barricade_Fence_Deployable"==L||"Workbench"==L||"RepairBench"==L||"Wood_Shelter"==L||"WoodStairs"==L||"WoodRamp"==L||"WoodCeiling"==L||"WoodWindowFrame"==L||"WoodDoorFrame"==L||"WoodWall"==L)&&w.Health<1e3&&(w.Health=1e3),"LargeWoodSpikeWall"==L&&w.Health<1500&&(w.Health=1500),"WoodGate"==L&&w.Health<1800&&(w.Health=1800),("MetalBarsWindow"==L||"MetalWindowFrame"==L||"MetalDoorFrame"==L||"MetalWall"==L||"WooodGateway"==L)&&w.Health<2e3&&(w.Health=2e3),"WoodFoundation"==L&&w.Health<2500&&(w.Health=2500),("WoodPillar"==L||"MetalFoundation"==L||"MetalPillar"==L)&&w.Health<5e3&&(w.Health=5e3))}}else e.Notice("You are allready checked !")}else e.Notice("Decay is off. You don't need to check your buildings !")}}function On_PluginInit(){if(!Plugin.IniExists("Wiper")){var e=Plugin.CreateIni("Wiper");e.AddSetting("Decay","TURN","true"),e.AddSetting("Decay","EntMess","[color#00FF00]If you were away more than 3 days please use[/color] [color#FF0000]/wcheck[/color] [color#00FF00]or your buildings may be destroyed ![/color]"),e.AddSetting("Decay","AnnTimer",15),e.AddSetting("Decay","AnnMess","[color#00FF00]Don't forget to[/color] [color#FF0000]/wcheck[/color] [color#00FF00]yourself at least once per 3 days ![/color]"),e.AddSetting("Decay","CheckMess","[color#00FF00]just checked for activity. Don't forget to[/color] [color#FF0000]/wcheck[/color] [color#00FF00]at least once per 3 days.[/color]"),e.AddSetting("Decay","Timer",3),e.AddSetting("Decay","Days",4),e.Save()}var t=System.Environment.TickCount,r=Plugin.GetIni("Wiper"),a=(r.GetSetting("Decay","TURN"),36e5*r.GetSetting("Decay","Timer")),i=parseInt(DataStore.Get("WiperT","Time")),o=parseInt(DataStore.Get("WiperT","TimeLeft")),n=DataStore.Get("WiperT","TimeO"),l=DataStore.Get("WiperT","TimeDEF"),c=i-(t-o),d=6e4*r.GetSetting("Decay","AnnTimer"),m=parseInt(DataStore.Get("WiperAN","Time")),S=parseInt(DataStore.Get("WiperAN","TimeLeft")),D=DataStore.Get("WiperAN","TimeDEFa"),T=DataStore.Get("WiperAN","TimeO"),W=m-(t-S);"On"==n&&a==l?(Plugin.KillTimer("WiperT"),System.Threading.Thread.Sleep(1e3),Plugin.CreateTimer("WiperT",Math.round(c)).Start(),DataStore.Add("WiperT","Time",Math.round(c)),DataStore.Add("WiperT","TimeLeft",t)):(Plugin.KillTimer("WiperT"),DataStore.Flush("WiperT"),System.Threading.Thread.Sleep(1e3),Plugin.CreateTimer("WiperT",a).Start(),DataStore.Add("WiperT","Time",a),DataStore.Add("WiperT","TimeLeft",t),DataStore.Add("WiperT","TimeO","On"),DataStore.Add("WiperT","TimeDEF",a),Server.BroadcastFrom("DECAY SYSTEM","Decay Timer reset !")),"On"==T&&d==D?(Plugin.KillTimer("WiperAN"),System.Threading.Thread.Sleep(1e3),Plugin.CreateTimer("WiperAN",Math.round(W)).Start(),DataStore.Add("WiperAN","Time",Math.round(W)),DataStore.Add("WiperAN","TimeLeft",t)):(Plugin.KillTimer("WiperAN"),DataStore.Flush("WiperAN"),System.Threading.Thread.Sleep(1e3),Plugin.CreateTimer("WiperAN",d).Start(),DataStore.Add("WiperAN","Time",d),DataStore.Add("WiperAN","TimeLeft",t),DataStore.Add("WiperAN","TimeO","On"),DataStore.Add("WiperAN","TimeDEFa",d),Server.BroadcastFrom("Wiper","Announce Timer reset !"))}function CheckCDCallback(){Plugin.KillTimer("CheckCD")}function WiperANCallback(){Plugin.KillTimer("WiperAN"),DataStore.Flush("WiperAN"),announce(hit)}function WiperTCallback(){Plugin.KillTimer("WiperT"),DataStore.Flush("WiperT"),decay(hit)}function announce(){var e=Plugin.GetIni("Wiper"),t=e.GetSetting("Decay","AnnMess"),r=6e4*e.GetSetting("Decay","AnnTimer"),a=System.Environment.TickCount;Plugin.CreateTimer("WiperAN",r).Start(),DataStore.Add("WiperAN","Time",r),DataStore.Add("WiperAN","TimeLeft",a),DataStore.Add("WiperAN","TimeO","On"),DataStore.Add("WiperAN","TimeDEFa",r),Server.BroadcastFrom("DECAY SYSTEM",t)}function decay(){var e=Plugin.GetIni("Wiper"),t=24*e.GetSetting("Decay","Days"),r=e.GetSetting("Decay","Timer"),a=36e5*e.GetSetting("Decay","Timer"),i=System.Environment.TickCount,o=500/t*r,n=750/t*r,l=1e3/t*r,c=1800/t*r,d=2e3/t*r,m=2500/t*r,S=5e3/t*r;Plugin.CreateTimer("CheckCD",3e4).Start(),Plugin.CreateTimer("WiperT",a).Start(),DataStore.Add("WiperT","Time",a),DataStore.Add("WiperT","TimeLeft",i),DataStore.Add("WiperT","TimeO","On"),DataStore.Add("WiperT","TimeDEF",a),System.Threading.Thread.Sleep(3e3);for(var D in World.Entities){var T=D.Name,W=D.CreatorID.ToString(),s=D.OwnerID.ToString(),p=e.GetSetting("Protected ID",W),g=e.GetSetting("Protected ID",s);(void 0==p&&void 0==g||void 0==W||void 0==s)&&(("MetalDoor"==T||"MetalStairs"==T||"MetalCeiling"==T||"MetalRamp"==T||"Campfire"==T||"Furnace"==T||"WoodBox"==T||"WoodDoor"==T)&&(D.Health<6?Util.DestroyObject(D.Object.gameObject):D.Health=D.Health-o),"WoodSpikeWall"==T&&(D.Health<10?Util.DestroyObject(D.Object.gameObject):D.Health=D.Health-n),("MetalBarsWindow"==T||"MetalWindowFrame"==T||"MetalDoorFrame"==T||"MetalWall"==T||"MetalWall"==T||"WoodBoxLarge"==T||"Barricade_Fence_Deployable"==T||"Workbench"==T||"RepairBench"==T||"Wood_Shelter"==T||"WoodStairs"==T||"WoodRamp"==T||"WoodCeiling"==T||"WoodWindowFrame"==T||"WoodDoorFrame"==T||"WoodWall"==T)&&(D.Health<13?Util.DestroyObject(D.Object.gameObject):D.Health=D.Health-l),"LargeWoodSpikeWall"==T&&(D.Health<20?Util.DestroyObject(D.Object.gameObject):D.Health=D.Health-b1500),"WoodGate"==T&&(D.Health<25?Util.DestroyObject(D.Object.gameObject):D.Health=D.Health-c),"WoodGateway"==T&&(D.Health<27?Util.DestroyObject(D.Object.gameObject):D.Health=D.Health-d),("WoodFoundation"==T||"MetalFoundation"==T||"MetalPillar"==T)&&(D.Health<34?Util.DestroyObject(D.Object.gameObject):D.Health=D.Health-m),"WoodPillar"==T&&(D.Health<69?Util.DestroyObject(D.Object.gameObject):D.Health=D.Health-S))}}function On_PlayerConnected(e){var t=Plugin.GetIni("Wiper"),r=t.GetSetting("Decay","TURN"),a=t.GetSetting("Decay","EntMess");"true"==r&&e.MessageFrom("DECAY SYSTEM",a)}function On_PlayerDisconnected(e){var t=Plugin.GetIni("Wiper"),r=t.GetSetting("Decay","TURN");"true"==r&&DataStore.Remove("WiperTC",e.SteamID),Wiper(e)&&Data.AddTableValue("Wiper",e.SteamID,!Wiper(e)),WiperS(e)&&Data.AddTableValue("WiperS",e.SteamID,!WiperS(e))}