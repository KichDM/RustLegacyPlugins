//Reference: RustExtended
using System.Linq;
using Oxide.Core;
using RustExtended;

namespace Oxide.Plugins
{
    [Info("AutoPremios", "KichDM", "1.0.0")]
    public class AutoSup : RustLegacyPlugin
    {
        private const float Timeout = 7200f;

        void Loaded()
        {
            timer.Once(Timeout, GiveReward);
        }

        void GiveReward()
        {
            var selectPlayer = PlayerClient.All.ElementAt(Random.Range(0, PlayerClient.All.Count));
            if (selectPlayer == null) goto Run;
            Helper.GiveItem(selectPlayer, "Supply Signal", 1);
            rust.BroadcastChat("PREMIO",$"El Jugador [color red]{selectPlayer.userName} [color green]GANO 1 Supply Signal en un Sorteo");
            Run:
            timer.Once(Timeout, GiveReward);
        }
    }
}