using System;
using System.Collections.Generic;


//▒█▀▀█ ▒█░░▒█ 　 ▒█▀▀█ ▀█▀ ▒█▄░▒█ ▒█░▄▀ 
//▒█▀▀▄ ▒█▄▄▄█ 　 ▒█▄▄█ ▒█░ ▒█▒█▒█ ▒█▀▄░ 
//▒█▄▄█ ░░▒█░░ 　 ▒█░░░ ▄█▄ ▒█░░▀█ ▒█░▒█


namespace Oxide.Plugins
{
    [Info("CustomChatCommands", "PINK", "0.1.0")]
    class CustomChatCommands : RustLegacyPlugin
    {

        string chatPrefix = "✯NovaLand✯";



        protected override void LoadDefaultConfig() { }
        private void CheckCfg<T>(string Key, ref T var)
        {

                if (Config[Key] is T)
                    var = (T)Config[Key];
                else
                    Config[Key] = var;
 
        }


        [ChatCommand("comandos")]
        void cmdComandos(NetUser netuser, string command, string[] args)
        {
            
                if (args.Length != 1)
                {
                    rust.SendChatMessage(netuser, chatPrefix, "━━━━━━━━━━━━━━━━━━━[color red]◤[color clear] COMANDOS [color red]◥[color clear]━━━━━━━━━━━━━━━━━━");
                    rust.SendChatMessage(netuser, chatPrefix, "[color red]➤  [color clear]/rank﹣  [color cyan]utilize para verificar o rank do servidor");
                    rust.SendChatMessage(netuser, chatPrefix, "[color red]➤  [color clear]/fov (60 a 120)﹣  [color cyan]utilize para alterar seu render.fov");
                    rust.SendChatMessage(netuser, chatPrefix, "[color red]➤  [color clear]/curar﹣  [color cyan]utilize para curar suas lesões");
                    rust.SendChatMessage(netuser, chatPrefix, "[color red]➤  [color clear]/stats﹣  [color cyan]utilize para verificar seus status");
                    rust.SendChatMessage(netuser, chatPrefix, "[color red]➤  [color clear]/contato﹣  [color cyan]utilize para verificar as formas de contato do servidor");
                    rust.SendChatMessage(netuser, chatPrefix, "[color red]➤  [color clear]/tags﹣  [color cyan]utilize para verificar as tags disponiveis");
                    rust.SendChatMessage(netuser, chatPrefix, "[color red]➤  [color clear]/vip﹣  [color cyan]utilize para verificar informações dos vip`s");
                    rust.SendChatMessage(netuser, chatPrefix, "ﾠ");
                    rust.SendChatMessage(netuser, chatPrefix, "[color red]➤  [color clear]/comandos 2﹣  [color red]utilize para ver a proxima pagina");
                    rust.SendChatMessage(netuser, chatPrefix, "━━━━━━━━━━━━━━━━━━━━━[color red]◤[color clear] 1/3 [color red]◥[color clear]━━━━━━━━━━━━━━━━━━━━━");
                    return;
                }


                switch (args[0].ToLower())
                {
                    case "1":
                        rust.SendChatMessage(netuser, chatPrefix, "━━━━━━━━━━━━━━━━━━━[color red]◤[color clear] COMANDOS [color red]◥[color clear]━━━━━━━━━━━━━━━━━━");
                        rust.SendChatMessage(netuser, chatPrefix, "[color red]➤  [color clear]/rank﹣  [color cyan]utilize para verificar o rank do servidor");
                        rust.SendChatMessage(netuser, chatPrefix, "[color red]➤  [color clear]/fov﹣  [color cyan]utilize para alterar seu render.fov");
                        rust.SendChatMessage(netuser, chatPrefix, "[color red]➤  [color clear]/c﹣  [color cyan]utilize para ativar/desativar seu chat");
                        rust.SendChatMessage(netuser, chatPrefix, "[color red]➤  [color clear]/stats﹣  [color cyan]utilize para verificar seus status");
                        rust.SendChatMessage(netuser, chatPrefix, "[color red]➤  [color clear]/contato﹣  [color cyan]utilize para verificar as formas de contato do servidor");
                        rust.SendChatMessage(netuser, chatPrefix, "[color red]➤  [color clear]/tags﹣  [color cyan]utilize para verificar as tags disponiveis");
                        rust.SendChatMessage(netuser, chatPrefix, "[color red]➤  [color clear]/vip﹣  [color cyan]utilize para verificar informações dos vip`s");
                        rust.SendChatMessage(netuser, chatPrefix, "ﾠ");
                        rust.SendChatMessage(netuser, chatPrefix, "[color red]➤  [color clear]/comandos 2﹣  [color red]utilize para ver a proxima pagina");
                        rust.SendChatMessage(netuser, chatPrefix, "━━━━━━━━━━━━━━━━━━━━━[color red]◤[color clear] 1/3 [color red]◥[color clear]━━━━━━━━━━━━━━━━━━━━━");
                        break;
                    case "2":
                        rust.SendChatMessage(netuser, chatPrefix, "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
                        rust.SendChatMessage(netuser, chatPrefix, "[color red]➤  [color clear]/fps﹣  [color cyan]utilize para ajustar seus graficos");
                        rust.SendChatMessage(netuser, chatPrefix, "[color red]➤  [color clear]/regras﹣  [color cyan]utilize para verificar as regras do servidor");
                        rust.SendChatMessage(netuser, chatPrefix, "[color red]➤  [color clear]/suicide﹣  [color cyan]utilize para se matar");
                        rust.SendChatMessage(netuser, chatPrefix, "[color red]➤  [color clear]/remove﹣  [color cyan]utilize para remover estruturas em que você possui permissão");
                        rust.SendChatMessage(netuser, chatPrefix, "[color red]➤  [color clear]/players﹣  [color cyan]utilize para verificar os jogadores online");
                        rust.SendChatMessage(netuser, chatPrefix, "[color red]➤  [color clear]/addfriend﹣  [color cyan]utilize para adicionar um jogador em sua friendlist");
                        rust.SendChatMessage(netuser, chatPrefix, "[color red]➤  [color clear]/friendlist﹣  [color cyan]utilize para ver quem está em sua friendlist");
                        rust.SendChatMessage(netuser, chatPrefix, "[color red]➤  [color clear]/unfriend﹣  [color cyan]utilize para remover um jogador de sua friendlist");
                        rust.SendChatMessage(netuser, chatPrefix, "[color red]➤  [color clear]/sethome﹣  [color cyan]utilize para setar sua home no servidor.");
                        rust.SendChatMessage(netuser, chatPrefix, "[color red]➤  [color clear]/home﹣  [color cyan]utilize para teleportar ao local da sua home no servidor.");
                        rust.SendChatMessage(netuser, chatPrefix, "[color red]➤  [color clear]/homelist﹣  [color cyan]utilize para ver quais são suas homes no servidor.");
                        rust.SendChatMessage(netuser, chatPrefix, "ﾠ");
                        rust.SendChatMessage(netuser, chatPrefix, "[color red]➤  [color clear]/comandos 3﹣  [color red]utilize para ver a proxima pagina");
                        rust.SendChatMessage(netuser, chatPrefix, "━━━━━━━━━━━━━━━━━━━━━[color red]◤[color clear] 2/3 [color red]◥[color clear]━━━━━━━━━━━━━━━━━━━━━");
                        break;
                    case "3":
                        rust.SendChatMessage(netuser, chatPrefix, "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
                        rust.SendChatMessage(netuser, chatPrefix, "[color red]➤  [color clear]/share﹣  [color cyan]utilize para adicionar um jogador em sua sharelist");
                        rust.SendChatMessage(netuser, chatPrefix, "[color red]➤  [color clear]/unshare﹣  [color cyan]utilize para remover um jogador de sua sharelist");
                        rust.SendChatMessage(netuser, chatPrefix, "[color red]➤  [color clear]/pm﹣  [color cyan]utilize para enviar uma mensagem privada a um jogador");
                        rust.SendChatMessage(netuser, chatPrefix, "[color red]➤  [color clear]/r﹣  [color cyan]utilize para responder uma mensagem privada de um jogador");
                        rust.SendChatMessage(netuser, chatPrefix, "[color red]➤  [color clear]/dono﹣  [color cyan]utilize verificar o dono de uma estrutura");
                        rust.SendChatMessage(netuser, chatPrefix, "[color red]➤  [color clear]/ping﹣  [color cyan]utilize verificar seu ping");
                        rust.SendChatMessage(netuser, chatPrefix, "[color red]➤  [color clear]/loc﹣  [color cyan]utilize para ver sua localização");
                        rust.SendChatMessage(netuser, chatPrefix, "━━━━━━━━━━━━━━━━━━━━━[color red]◤[color clear] 3/3 [color red]◥[color clear]━━━━━━━━━━━━━━━━━━━━━");
                        break;
                    default:
                        {
                            rust.SendChatMessage(netuser, chatPrefix, "━━━━━━━━━━━━━━━━━━━[color red]◤[color clear] COMANDOS [color red]◥[color clear]━━━━━━━━━━━━━━━━━━");
                            rust.SendChatMessage(netuser, chatPrefix, "[color red]➤  [color clear]/rank﹣  [color cyan]utilize para verificar o rank do servidor");
                            rust.SendChatMessage(netuser, chatPrefix, "[color red]➤  [color clear]/fov﹣  [color cyan]utilize para alterar seu render.fov");
                            rust.SendChatMessage(netuser, chatPrefix, "[color red]➤  [color clear]/c﹣  [color cyan]utilize para ativar/desativar seu chat");
                            rust.SendChatMessage(netuser, chatPrefix, "[color red]➤  [color clear]/stats﹣  [color cyan]utilize para verificar seus status");
                            rust.SendChatMessage(netuser, chatPrefix, "[color red]➤  [color clear]/contato﹣  [color cyan]utilize para verificar as formas de contato do servidor");
                            rust.SendChatMessage(netuser, chatPrefix, "[color red]➤  [color clear]/tags﹣  [color cyan]utilize para verificar as tags disponiveis");
                            rust.SendChatMessage(netuser, chatPrefix, "[color red]➤  [color clear]/vip﹣  [color cyan]utilize para verificar informações dos vip`s");
                            rust.SendChatMessage(netuser, chatPrefix, "ﾠ");
                            rust.SendChatMessage(netuser, chatPrefix, "[color red]➤  [color clear]/comandos 2﹣  [color red]utilize para ver a proxima pagina");
                            rust.SendChatMessage(netuser, chatPrefix, "━━━━━━━━━━━━━━━━━━━━━[color red]◤[color clear] 1/3 [color red]◥[color clear]━━━━━━━━━━━━━━━━━━━━━");
                            break;
                        }
                }
            
        }






        [ChatCommand("contato")]
        void cmdContato(NetUser netuser, string command, string[] args)
        {
           
                rust.SendChatMessage(netuser, chatPrefix, "[color white]━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
                rust.SendChatMessage(netuser, chatPrefix, "[color red]➤  [color clear]Dono: [color cyan]KichDM#6035");
                rust.SendChatMessage(netuser, chatPrefix, "[color red]➤  [color clear]Discord﹣  [color cyan]discord.gg/t8WeFSYMfE");
                rust.SendChatMessage(netuser, chatPrefix, "[color red]➤  [color clear]Site﹣  [color cyan]Em desenvolvimento");
                rust.SendChatMessage(netuser, chatPrefix, "[color white]━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");

            
        }

        void MensagensVip(NetUser netuser)
        {
           
                rust.SendChatMessage(netuser, chatPrefix, "[color white]━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
                rust.SendChatMessage(netuser, chatPrefix, "[color red]➤  [color white]/vip comprar - [color cyan]para checar como comprar seu vip.");
                rust.SendChatMessage(netuser, chatPrefix, "[color red]➤  [color white]/vip ativacao - [color cyan]para checar como ativar seu vip.");
                rust.SendChatMessage(netuser, chatPrefix, "[color red]➤  [color white]/vip preco - [color cyan]para checar os valores dos vip`s.");
                rust.SendChatMessage(netuser, chatPrefix, "ﾠ");
                rust.SendChatMessage(netuser, chatPrefix, "[color red]➤  [color white]/vip ferro - [color cyan]para checar os beneficios do vip ferro.");
                rust.SendChatMessage(netuser, chatPrefix, "[color red]➤  [color white]/vip pedra - [color cyan]para checar os beneficios do vip pedra.");
                rust.SendChatMessage(netuser, chatPrefix, "[color red]➤  [color white]/vip madeira - [color cyan]para checar os beneficios do vip madeira.");
                rust.SendChatMessage(netuser, chatPrefix, "[color white]━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
           
        }

        [ChatCommand("regras")]
        void cmdregras(NetUser netuser, string command, string[] args)
        {
           
                rust.SendChatMessage(netuser, chatPrefix, "[color red]━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
                rust.SendChatMessage(netuser, chatPrefix, "[color red]1. [color white]A utilização de qualquer tipo de [color red]macro/hack[color clear] é totalmente proibido.");
                rust.SendChatMessage(netuser, chatPrefix, "[color red]2. [color white]O uso do discord é obrigatorio em nosso servidor.");
                rust.SendChatMessage(netuser, chatPrefix, "[color red]3. [color white]Não negue TV para um membro da Staff.");
                rust.SendChatMessage(netuser, chatPrefix, "[color red]4. [color white]Qualquer tipo de ofensa a staff/players não será tolerado.");
                rust.SendChatMessage(netuser, chatPrefix, "[color red]5. [color white]Proibido utilização de [color red]Bug´s[color clear] que beneficie a si proprio [color red](bug do ctrl e alt + enter são exceções)[color white].");
                rust.SendChatMessage(netuser, chatPrefix, "[color red]6. [color white]Divulgação de links maliciosos e outros servidores resultara em banimento.");
                rust.SendChatMessage(netuser, chatPrefix, "[color red]7. [color white]Utilização de nicks impróprios resultará em [color red]banimento[color white].");
                rust.SendChatMessage(netuser, chatPrefix, "[color red]8. [color white]Limite de casas para players normais é [color red]8x8x5 [color white]e para players vips é [color red]10x10x8[color white].");
                rust.SendChatMessage(netuser, chatPrefix, "[color red]9. [color white]Proibido fazer bases anti raid ou em buracos.");
                rust.SendChatMessage(netuser, chatPrefix, "[color red]━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
            
        }

        [ChatCommand("vip")]
        void cmdViP(NetUser netuser, string command, string[] args)
        {
           
                if (args.Length == 0) { MensagensVip(netuser); return; }
                switch (args[0].ToLower())
                {
                    case "comprar":
                        rust.SendChatMessage(netuser, chatPrefix, "[color white]━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
                        rust.SendChatMessage(netuser, chatPrefix, "[color red]➤  [color white]Para efetuar a compra do seu vip");
                        rust.SendChatMessage(netuser, chatPrefix, "[color red]➤  [color white]Realize o pagamento em nosso site");
                        rust.SendChatMessage(netuser, chatPrefix, "[color red]➤  [color white]Site﹣  [color cyan]em desenvolvimento");
                        rust.SendChatMessage(netuser, chatPrefix, "[color white]━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
                        break;
                    case "preco":
                        rust.SendChatMessage(netuser, chatPrefix, "[color white]━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
                        rust.SendChatMessage(netuser, chatPrefix, "[color red]➤  [color white]Ferro﹣  [color cyan]R$ 75,00[color clear]﹣  30 dias");
                        rust.SendChatMessage(netuser, chatPrefix, "[color red]➤  [color white]Pedra﹣  [color cyan]R$ 45,00[color clear]﹣  30 dias");
                        rust.SendChatMessage(netuser, chatPrefix, "[color red]➤  [color white]Madeira﹣  [color cyan]R$ 30,00[color clear]﹣  30 dias");
                        rust.SendChatMessage(netuser, chatPrefix, "[color white]━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
                        break;
                    case "ativacao":
                        rust.SendChatMessage(netuser, chatPrefix, "[color white]━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
                        rust.SendChatMessage(netuser, chatPrefix, "[color red]➤  [color clear]Para ativação do seu vip");
                        rust.SendChatMessage(netuser, chatPrefix, "[color red]➤  [color clear]Contate um dos responsáveis﹣  [color cyan]/contato");
                        rust.SendChatMessage(netuser, chatPrefix, "[color red]➤  [color clear]Apresente o comprovante de pagamento");
                        rust.SendChatMessage(netuser, chatPrefix, "[color white]━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
                        break;
                    case "ferro":
                        rust.SendChatMessage(netuser, chatPrefix, "[color white]━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
                        rust.SendChatMessage(netuser, chatPrefix, "[color red]➤  [color white]Falar colorido no chat do servidor");
                        rust.SendChatMessage(netuser, chatPrefix, "[color red]➤  [color white]Tag[color cyan]〔 FERRO 〕   [color white]no chat e discord do servidor");
                        rust.SendChatMessage(netuser, chatPrefix, "[color red]➤  [color white]Acesso aos 5 kits exclusivo ao vip ferro.");
                        rust.SendChatMessage(netuser, chatPrefix, "[color red]➤  [color white]Cooldown dos comandos reduzidos.");
                        rust.SendChatMessage(netuser, chatPrefix, "[color red]➤  [color white]Limite de homes: 30");
                        rust.SendChatMessage(netuser, chatPrefix, "[color white]━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
                        break;
                    case "pedra":
                        rust.SendChatMessage(netuser, chatPrefix, "[color white]━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
                        rust.SendChatMessage(netuser, chatPrefix, "[color red]➤  [color white]Falar colorido no chat do servidor");
                        rust.SendChatMessage(netuser, chatPrefix, "[color red]➤  [color white]Tag[color cyan]〔 PEDRA 〕   [color white]no chat e discord do servidor");
                        rust.SendChatMessage(netuser, chatPrefix, "[color red]➤  [color white]Acesso aos 5 kits exclusivo ao vip pedra.");
                        rust.SendChatMessage(netuser, chatPrefix, "[color red]➤  [color white]Cooldown dos comandos reduzidos.");
                        rust.SendChatMessage(netuser, chatPrefix, "[color red]➤  [color white]Limite de homes: 20");
                        rust.SendChatMessage(netuser, chatPrefix, "[color white]━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
                        break;
                    case "madeira":
                        rust.SendChatMessage(netuser, chatPrefix, "[color white]━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
                        rust.SendChatMessage(netuser, chatPrefix, "[color red]➤  [color white]Falar colorido no chat do servidor");
                        rust.SendChatMessage(netuser, chatPrefix, "[color red]➤  [color white]Tag[color cyan]〔 MADEIRA 〕   [color white]no chat e discord do servidor");
                        rust.SendChatMessage(netuser, chatPrefix, "[color red]➤  [color white]Acesso aos 4 kits exclusivo ao vip madeira.");
                        rust.SendChatMessage(netuser, chatPrefix, "[color red]➤  [color white]Cooldown dos comandos reduzidos.");
                        rust.SendChatMessage(netuser, chatPrefix, "[color red]➤  [color white]Limite de homes: 10");
                        rust.SendChatMessage(netuser, chatPrefix, "[color white]━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
                        break;
                    default:
                        {
                            MensagensVip(netuser);
                            break;
                        }
                }
            
        }

        void Mensagenstags(NetUser netuser)
        {

            rust.SendChatMessage(netuser, chatPrefix, "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
            rust.SendChatMessage(netuser, chatPrefix, "[color red]➤  [color white]/tags dv﹣  [color cyan]utilize para ver os requisitos de um divulgador");
            rust.SendChatMessage(netuser, chatPrefix, "[color red]➤  [color white]/tags yt﹣  [color cyan]utilize para ver os requisitos de um youtuber");
            rust.SendChatMessage(netuser, chatPrefix, "[color red]➤  [color white]/tags mod﹣  [color cyan]utilize para ver os requisitos de um moderador");
            rust.SendChatMessage(netuser, chatPrefix, "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
        }

        [ChatCommand("tags")]
        void cmdtags(NetUser netuser, string command, string[] args)
        {
           
                if (args.Length == 0) { Mensagenstags(netuser); return; }
                switch (args[0].ToLower())
                {
                    case "dv":
                        rust.SendChatMessage(netuser, chatPrefix, "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
                        rust.SendChatMessage(netuser, chatPrefix, "[color red]➤  [color white]Divulgue nosso servidor no mínimo em 5 grupos﹣  [color cyan]Facebook[color white]/[color cyan]Discord");
                        rust.SendChatMessage(netuser, chatPrefix, "[color red]➤  [color white]Entre em contato com um dos responsáveis﹣  [color cyan]/contato");
                        rust.SendChatMessage(netuser, chatPrefix, "[color red]➤  [color white]Apresente prints de divulgação de todos os grupos divulgados");
                        rust.SendChatMessage(netuser, chatPrefix, "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
                        break;
                    case "yt":
                        rust.SendChatMessage(netuser, chatPrefix, "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
                        rust.SendChatMessage(netuser, chatPrefix, "[color red]➤  [color white]Grave e poste um vídeo apresentando nosso servidor");
                        rust.SendChatMessage(netuser, chatPrefix, "[color red]➤  [color white]É necessário o vídeo possuir no mínimo [color cyan]3 minutos[color white] de duração");
                        rust.SendChatMessage(netuser, chatPrefix, "[color red]➤  [color white]Entre em contato com um dos responsáveis﹣  [color cyan]/contato");
                        rust.SendChatMessage(netuser, chatPrefix, "[color red]➤  [color white]Apresente o vídeo e aguarde ele ser aprovado");
                        rust.SendChatMessage(netuser, chatPrefix, "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
                        break;
                    case "mod":
                        rust.SendChatMessage(netuser, chatPrefix, "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
                        rust.SendChatMessage(netuser, chatPrefix, "[color red]➤  [color white]Necessário possuir conhecimento de busca");
                        rust.SendChatMessage(netuser, chatPrefix, "[color red]➤  [color white]Idade minima requisitada﹣  [color cyan]15 anos");
                        rust.SendChatMessage(netuser, chatPrefix, "[color red]➤  [color white]Entre em contato com um dos responsáveis﹣  [color cyan]/contato");
                        rust.SendChatMessage(netuser, chatPrefix, "[color red]➤  [color white]Você sera submetido a um teste de busca");
                        rust.SendChatMessage(netuser, chatPrefix, "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
                        break;
                    default:
                        {
                            Mensagenstags(netuser);
                            break;
                        }
                }
            
        }
    }
}