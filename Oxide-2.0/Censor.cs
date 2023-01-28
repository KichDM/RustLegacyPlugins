using System.Collections.Generic;

namespace Oxide.Plugins{
        [Info("Censor", "DiGGeT83", "1.0.0")]
    class Censor : RustLegacyPlugin
	{
		//При спавне игрока, вызывается автоматически команда censor.nudity false !!ВАЖНО!! Ошибок не вызывает!!
		void OnPlayerSpawn(PlayerClient player)
		{
			NetUser str = player.netUser;
			{
			rust.RunClientCommand(str, "censor.nudity false");
			}
		}
	}
}