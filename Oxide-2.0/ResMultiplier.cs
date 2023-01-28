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

namespace Oxide.Plugins
{
    [Info("ResMultiplier", "Freezak", "1.0.0")]
    class ResMultiplier : RustLegacyPlugin
    {
		void Init()
        {
        }
		
		bool day = false;
		
		Timer TimerResm;
		
		float dayx = 4.0f;      //Днём
		float nightx = 2.0f;    //Ночью
		
		string ChatName= RustExtended.Core.ServerName ;
		
        void OnServerInitialized()
        {
            TimerResm = timer.Repeat(2, 0, () => Resmchecker());
        }		
		
		void Resmchecker()
        {
			float time = EnvironmentControlCenter.Singleton.GetTime();
			var hour = Math.Floor(time);
			if (hour > RustExtended.Core.CycleInstantCraftOff && hour < RustExtended.Core.CycleInstantCraftOn)
			{
				RustExtended.Core.ResourcesAmountMultiplierWood = dayx;
				RustExtended.Core.ResourcesAmountMultiplierRock = dayx;
				RustExtended.Core.ResourcesAmountMultiplierFlay = dayx;
				RustExtended.Core.ResourcesGatherMultiplierWood = dayx;
				RustExtended.Core.ResourcesGatherMultiplierRock = dayx;
				RustExtended.Core.ResourcesGatherMultiplierFlay = dayx;
				if(day)
				{
					RustExtended.Broadcast.MessageAll("[COLOR clear]Наступила ночь, рейты увеличены до x4");
					day = false;
				}
			}
			else
			{
				RustExtended.Core.ResourcesAmountMultiplierWood = nightx;
				RustExtended.Core.ResourcesAmountMultiplierRock = nightx;
				RustExtended.Core.ResourcesAmountMultiplierFlay = nightx;
				RustExtended.Core.ResourcesGatherMultiplierWood = nightx;
				RustExtended.Core.ResourcesGatherMultiplierRock = nightx;
				RustExtended.Core.ResourcesGatherMultiplierFlay = nightx;
				if(!day)
				{
					RustExtended.Broadcast.MessageAll("[COLOR clear]Наступил день, рейты уменьшены до x2");
					day = true;
				}
			}
        }
	}
}