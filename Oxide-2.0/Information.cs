using System.Collections.Generic;

namespace Oxide.Plugins{
        [Info("Information", "DiGGeT", "1.0.0")]
    class Information : RustLegacyPlugin
	{
		
		void OnPlayerSpawn(PlayerClient player)
		{
			NetUser str = player.netUser;
			timer.Once(20f, ()=>
			{ rust.SendChatMessage(str, "Пропиши [color green]/donat [color white] что бы узнать цены на [color green]донат"); });
			rust.SendChatMessage(str, "Пропиши [color red]/top [color white] что бы увидеть ТОП 5 игроков [color red]сервера");

		}
	}
}