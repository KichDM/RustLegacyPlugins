// Reference: Facepunch.MeshBatch
// Reference: Google.ProtocolBuffers
// Reference: Google.ProtocolBuffers
using System.Collections.Generic;
using System;
using System.Reflection;
using System.Data;
using UnityEngine;
using Oxide.Core;
using Oxide.Core.Plugins;
using Oxide.Core.Libraries.Covalence;
using RustProto;
using RustExtended;

namespace Oxide.Plugins
{
    [Info("VKStatus", "Unkown", "2.0.1", ResourceId = 941)]
    class FVKStatus : RustLegacyPlugin
    {
    	public static int num = 0;

    	static Plugins.Timer timerCheckControllable; 

        void Init()
        {
            Puts("Plugin Loaded!");
            UpdateOnline();
        }

        void UpdateOnline()
        {
        	if (timerCheckControllable != null) 
            {
                timerCheckControllable.Destroy(); 
            }
        	timerCheckControllable = timer.Repeat(180f, 0, () => 
            { 
                num = 0;
                foreach (uLink.NetworkPlayer networkPlayer in NetCull.connections) 
                { 
                    NetUser netUser = networkPlayer.GetLocalData() as NetUser; 
                    if (netUser != null) 
                    { 
                        ++num;
                    } 
                }
                GetRequest();
            });
        }

        void GetRequest()
        {
            webrequest.EnqueueGet("https://api.vk.com/method/status.set?text=Онлайн "+num+" из 200 игроков                 IP: net.connect s3.elegacy.ru:27043&group_id=145812534&access_token=e41167450182b1a1e889bb44ffee0d17102a504a65380bc0ba39a9650a35ee93c1766f3a6b1f26a8b39d2&v=5.73", (code, response) => GetCallback(code, response), this);
        }

        void GetCallback(int code, string response)
        {
            if (response == null || code != 200)
            {
                return;
            }
        } 
    }
} 