using System.Collections.Generic;
#pragma warning disable 0618

namespace Oxide.Plugins{
        [Info("Voting", "KasT", "1.0.0")]
    class Voting : RustLegacyPlugin
	{

		
		static public bool flag_vote = true;
		static public bool flag_once;
		
		
	  static bool VotingSystem = true;
	  static bool VotingEnq = false;
	  
	  static bool MensagemGlobal = true;
	  
	  static string chatPrefix = "VECTOR";
	
	  static float TimeToEnd = 60f;
	
      const string permiAdmin = "voting.use";
  
	  static int MinVotes = 5;
	  
	  static int VoteYes = 0;
	  static int VoteNo = 0;
	  
	  static List <string> PlayersQueVotaram = new List<string>();
	  
        void OnServerInitialized()
		{
			flag_vote = true;
			CheckCfg<string>("Settings: Chat Prefix: ", ref chatPrefix);
			CheckCfg<bool>("Settings: System Status: ", ref VotingSystem);
			CheckCfg<bool>("Settings: Announcer Voting Global: ", ref MensagemGlobal);
			CheckCfg<int>("Settings: Min Votes: ", ref MinVotes);
			CheckCfg<float>("Settings: Time To End Voting: ", ref TimeToEnd);
			CheckCfg<bool>("Settings: Flag vote: ", ref flag_vote);
			permission.RegisterPermission(permiAdmin, this);
			Lang();
			SaveConfig();
        }
		
		void OnItemAdded(Inventory inventory, int slot, IInventoryItem item)
		{
		}

		protected override void LoadDefaultConfig(){} 
		private void CheckCfg<T>(string Key, ref T var){
			if(Config[Key] is T)
			var = (T)Config[Key];  
			else
			Config[Key] = var;
		}
	
        void Lang(){
			
			// english
			lang.RegisterMessages(new Dictionary<string, string>
			{
				{"NoPermission", "У вас нет прав!"},
				{"SystemOFF", "Cистема отключена!"},
				{"VotingMSG", "Голосование уже идет!"},
				{"VotingMSG1", "Вы не задали сообщение для vote!"},
				{"VotingMSG2", "Опрос не активен или уже завершен!"},
				{"VotingMSG3", "Вы уже проголосовали, ждите!"},
				{"VotingMSG4", "Используй /vote yes или /vote no - чтобы проголосовать!"},
				{"VotingMSG5", "[color orange]{0} [color clear] голосует [color aqua] ЗА [color clear]!"},
				{"VotingMSG6", "[color orange]{0} [color clear] голосует [color red] ПРОТИВ [color clear]!"},
				{"VotingMSG7", "[color red]Недостаточно голосов, нужно [color red]{0}"},
				{"VotingMSG8", "There was a tie in the vote!"},
				
				{"VotingHelp", "[color aqua]☀  Голосование за День ☀ [color clear]"},
				{"VotingHelp1", "-> Чтобы проголосовать [color aqua] ЗА [color clear], используй /vote yes"},
				{"VotingHelp2", "-> Чтобы проголосовать [color red] ПРОТИВ [color clear], используй /vote no"},
				{"VotingHelp3", "-> Времени до окончания опроса: [color aqua]60 секунд. -> [/day]"},
				
				{"VotingWinYes", "[color aqua]☑[color clear] Да будет свет! Собрано {0} голосов. [color aqua]☑"},
				{"VotingWinNo", "[color red]☒[color clear] Отказано.[color clear] {0}  против! [color red]☒"}

			}, this);

			// brazilian
			lang.RegisterMessages(new Dictionary<string, string>
			{
				{"NoPermission", "У вас нет прав!"},
				{"SystemOFF", "Cистема отключена!"},
				{"VotingMSG", "Голосование уже идет!"},
				{"VotingMSG1", "Вы не задали сообщение для vote!"},
				{"VotingMSG2", "Опрос не активен или уже завершен!"},
				{"VotingMSG3", "Вы уже проголосовали, ждите!"},
				{"VotingMSG4", "Используй /vote yes или /vote no - чтобы проголосовать!"},
				{"VotingMSG5", "[color orange]{0} [color clear] голосует [color aqua] ЗА [color clear]!"},
				{"VotingMSG6", "[color orange]{0} [color clear] голосует [color red] ПРОТИВ [color clear]!"},
				{"VotingMSG7", "[color red]☒ Недостаточно голосов, нужно [color red]{0} [color red]☒"},
				{"VotingMSG8", "There was a tie in the vote!"},
				
				{"VotingHelp", "[color aqua]☀  Голосование за День ☀ [color clear]"},
				{"VotingHelp1", "-> Чтобы проголосовать [color aqua] ЗА [color clear], используй /vote yes"},
				{"VotingHelp2", "-> Чтобы проголосовать [color red] ПРОТИВ [color clear], используй /vote no"},
				{"VotingHelp3", "-> Времени до окончания опроса: [color aqua]60 секунд. -> [/day]"},
				
				{"VotingWinYes", "[color aqua]☑[color clear] Да будет свет! Собрано {0} голосов. [color aqua]☑"},
				{"VotingWinNo", "[color red]☒[color clear] Отказано.[color clear] {0}  против! [color red]☒"}

			}, this, "pt-br");

			lang.RegisterMessages(new Dictionary<string, string>
			{
				{"NoPermission", "У вас нет прав!"},
				{"SystemOFF", "Cистема отключена!"},
				{"VotingMSG", "Голосование уже идет!"},
				{"VotingMSG1", "Вы не задали сообщение для vote!"},
				{"VotingMSG2", "Опрос не активен или уже завершен!"},
				{"VotingMSG3", "Вы уже проголосовали, ждите!"},
				{"VotingMSG4", "Используй /vote yes или /vote no - чтобы проголосовать!"},
				{"VotingMSG5", "[color orange]{0} [color clear] голосует [color aqua] ЗА [color clear]!"},
				{"VotingMSG6", "[color orange]{0} [color clear] голосует [color red] ПРОТИВ [color clear]!"},
				{"VotingMSG7", "[color red]☒ Недостаточно голосов, нужно [color red]{0} [color red]☒"},
				{"VotingMSG8", "There was a tie in the vote!"},
				
				{"VotingHelp", "[color aqua]☀  Голосование за День ☀ [color clear]"},
				{"VotingHelp1", "-> Чтобы проголосовать [color aqua] ЗА [color clear], используй /vote yes"},
				{"VotingHelp2", "-> Чтобы проголосовать [color red] ПРОТИВ [color clear], используй /vote no"},
				{"VotingHelp3", "-> Времени до окончания опроса: [color aqua]60 секунд. -> [/day]"},
				
				{"VotingWinYes", "[color aqua]☑[color clear] Да будет свет! Собрано {0} голосов. [color aqua]☑"},
				{"VotingWinNo", "[color red]☒[color clear] Отказано.[color clear] {0}  против! [color red]☒"}

			}, this, "spanish");
			return;
        }
		
		
		[ChatCommand("flag_vote")]
		void ChangeFlag(NetUser netuser, string command, string[] args)
		{
			if(AcessAdmin(netuser))
			{
				if(flag_vote == true)
				{
					flag_vote = false;
					rust.SendChatMessage(netuser, chatPrefix, "[color red]flagvote is FALSE");
				}
				else
				{
					flag_vote = true;
					rust.SendChatMessage(netuser, chatPrefix, "[color red]flagvote is TRUE");
				}
			}				
		}
		
		
	  [ChatCommand("day")]
	  void CommandOpen(NetUser netuser, string command, string[] args)
	  {
		string cmd;
		 if(args.Length != 0){
		cmd = args[0].ToLower();
		rust.RunServerCommand(cmd);
		}
		if(flag_vote == true)
		{
			flag_vote = false;
		  string ID = netuser.userID.ToString();
		  if (!VotingSystem) { rust.SendChatMessage(netuser, chatPrefix, lang.GetMessage("SystemOFF", this, ID)); return; }
		  string message = "";
		  AnuncioMSG(message);
		  Finalizar();
		}
		else
			rust.SendChatMessage(netuser, chatPrefix, "[color red]Отказано! Запускать голосование можно раз в 10 минут.");
		timer.Once(600, () =>{flag_vote = true;});
	  }

        [ChatCommand("vote")]
        void Command(NetUser netuser, string command, string[] args) {
            string ID = netuser.userID.ToString();
            if (!VotingSystem) { rust.SendChatMessage(netuser, chatPrefix, lang.GetMessage("SystemOFF!", this, ID)); return; }
            if (!VotingEnq) { rust.SendChatMessage(netuser, chatPrefix, lang.GetMessage("VotingMSG2", this, ID)); return; }
            if (PlayersQueVotaram.Contains(ID)) { rust.SendChatMessage(netuser, chatPrefix, lang.GetMessage("VotingMSG3", this, ID)); return; }
            if (args.Length == 0) { rust.SendChatMessage(netuser, chatPrefix, lang.GetMessage("VotingMSG4", this, ID)); return; }
            switch (args[0].ToLower()) {
                case "yes":
                    VoteYes++;
                    PlayersQueVotaram.Add(ID);
                    if (MensagemGlobal) { rust.BroadcastChat(chatPrefix, string.Format(lang.GetMessage("VotingMSG5", this), netuser.displayName)); return; }
                    break;
                case "no":
                    VoteNo++;
                    PlayersQueVotaram.Add(ID);
                    if (MensagemGlobal) { rust.BroadcastChat(chatPrefix, string.Format(lang.GetMessage("VotingMSG6", this), netuser.displayName)); return; }
                    break;
                default: {
                        HelpCommand(netuser);
                        break;
                    }
            } }
	 
	  void HelpCommand(NetUser netuser){
		string ID = netuser.userID.ToString();
	 }

	  void AnuncioMSG(string mensagem){
      rust.BroadcastChat(chatPrefix, lang.GetMessage("VotingHelp", this));
	  rust.BroadcastChat(chatPrefix, lang.GetMessage("VotingHelp1", this));
	  rust.BroadcastChat(chatPrefix, lang.GetMessage("VotingHelp2", this));
	  rust.BroadcastChat(chatPrefix, lang.GetMessage("VotingHelp3", this));	  
      rust.BroadcastChat(chatPrefix, lang.GetMessage("VotingHelp", this));
	  VotingEnq = true;
	  }

	  void Finalizar()
	  {
            timer.Once(TimeToEnd, () =>
            {
                int Votos = VoteYes + VoteNo;
                if (Votos < MinVotes)
                {
                    VoteYes = 0;
                    VoteNo = 0;
                    PlayersQueVotaram.Clear();
                    rust.BroadcastChat(chatPrefix, string.Format(lang.GetMessage("VotingMSG7", this), MinVotes));
					VotingEnq = false;
                    return;
                }
                int VotosComp = VoteYes.CompareTo(VoteNo);
                if (VotosComp == 0) {
                rust.BroadcastChat(chatPrefix, lang.GetMessage("VotingMSG8", this));
				VoteYes = 0;
                VoteNo = 0;
                PlayersQueVotaram.Clear();
				VotingEnq = false; }
                else if (VotosComp == 1) {
                rust.BroadcastChat(chatPrefix, string.Format(lang.GetMessage("VotingWinYes", this), VoteYes));
				timer.Once(5, () =>{rust.RunServerCommand("env.time 10");});     //  ---------------- перез
				VoteYes = 0;
                VoteNo = 0;
                PlayersQueVotaram.Clear();
				VotingEnq = false; }
                else if (VotosComp == -1) {
                rust.BroadcastChat(chatPrefix, string.Format(lang.GetMessage("VotingWinNo", this), VoteNo));
                VoteYes = 0;
                VoteNo = 0;
                PlayersQueVotaram.Clear();
				VotingEnq = false; }
            });
	  }
	  
	 	bool AcessAdmin(NetUser netuser){
		if(netuser.CanAdmin())return true; 
		if(permission.UserHasPermission(netuser.userID.ToString(), permiAdmin))return true;
		return false;
		}

    }
}