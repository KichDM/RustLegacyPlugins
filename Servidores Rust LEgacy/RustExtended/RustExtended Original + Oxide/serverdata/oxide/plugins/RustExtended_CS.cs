using System;
using System.Collections.Generic;
using Oxide.Core;
using Oxide.Core.Libraries;
using RustExtended;

namespace Oxide.Plugins
{
    [Info("RustExtended (C#) Example", "Breaker", 1.0)]
    class RustExtendedCS : RustLegacyPlugin
    {
        void Init()
        {
			UnityEngine.Debug.Log("[Demo Plugin] RustExtended Hardware ID: " + RustExtended.Loader.HardwareID );
			UnityEngine.Debug.Log("[Demo Plugin] RustExtended Database Type: " + RustExtended.Core.DatabaseType);		
			UnityEngine.Debug.Log("[Demo Plugin] RustExtended Information: ");
			UnityEngine.Debug.Log("[Demo Plugin]   - " + RustExtended.Core.Commands.Count + " Total Command(s)");
			UnityEngine.Debug.Log("[Demo Plugin]   - " + RustExtended.Core.Ranks.Count + " Total Rank(s)");
			UnityEngine.Debug.Log("[Demo Plugin]   - " + RustExtended.Core.Kits.Count + " Total Kit(s)");
        }
    }
}