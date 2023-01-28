using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Oxide.Core;
using Oxide.Core.Plugins;
using RustExtended;
using UnityEngine;
using Random = Oxide.Core.Random;
// ReSharper disable StringLiteralTypo

namespace Oxide.Plugins
{
    [Info("Warps", "vk.com/host_fun", "1.0")]
    [Description("New warp system")]
    internal class Warps : RustLegacyPlugin
    {
        private WarpManager _warpManager;

        public class WarpManager
        {
            [JsonProperty("Система Варпов")] public string Prefix;
            [JsonProperty("Список варпов")] public List<NewWarp> AllWarps;
        }

        public class NewWarp
        {
            [JsonProperty("Название файла")] public string Name;
            [JsonProperty("Точки для рандом тп")] public List<string> PositionList;
            [JsonProperty("Цена за тп")] public ulong Price;
            [JsonProperty("Задержка перед тп")] public int Timeout;
        }

        private WarpManager TryDefault()
        {
            var manager = new WarpManager
            {
                Prefix = "Система Варпов",
                AllWarps = new List<NewWarp>
                {
                    new NewWarp
                    {
                        Name = "small",
                        PositionList = new List<string>
                        {
                            "(6156, 376, -3487)",
                            "(6099, 377, -3470)",
                            "(6051, 378, -3623)",
                            "(6038, 376, -3545)"
                        },
                        Price = 1,
                        Timeout = 30
                    },
                    new NewWarp
                    {
                        Name = "hangar",
                        PositionList = new List<string>
                        {
                            "(6599, 358, -4289)",
                            "(6640, 347, -4384)",
                            "(6673, 356, -4201)"
                        },
                        Price = 100,
                        Timeout = 30
                    },
                    new NewWarp
                    {
                        Name = "mayak",
                        PositionList = new List<string>
                        {
                            "(5963, 279, -5323)",
                            "(6010, 263, -5332)",
                            "(6007, 257, -5367)"
                        },
                        Price = 100,
                        Timeout = 30
                    },
                    new NewWarp
                    {
                        Name = "big",
                        PositionList = new List<string>
                        {
                            "(5108, 370, -4908)",
                            "(5248, 367, -4859)",
                            "(5230, 370, -4739)"
                        },
                        Price = 100,
                        Timeout = 30
                    },
                    new NewWarp
                    {
                        Name = "hackerka",
                        PositionList = new List<string>
                        {
                            "(5636, 403, -2406)",
                            "(5539, 413, -2474)",
                            "(5600, 422, -2608)"
                        },
                        Price = 100,
                        Timeout = 30
                    },
                    new NewWarp
                    {
                        Name = "medvega",
                        PositionList = new List<string>
                        {
                            "(5059, 422, -3676)",
                            "(4774, 432, -3881)",
                            "(4535, 464, -3821)",
                            "(4623, 448, -4050)"
                        },
                        Price = 100,
                        Timeout = 30
                    },
                    new NewWarp
                    {
                        Name = "bochki",
                        PositionList = new List<string>
                        {
                            "(6637, 353, -3865)",
                            "(6727, 353, -3856)",
                            "(6775, 353, -3786)",
                            "(6840, 353, -3876)"
                        },
                        Price = 100,
                        Timeout = 30
                    },
                    new NewWarp
                    {
                        Name = "factory",
                        PositionList = new List<string>
                        {
                            "(6429, 366, -4382)",
                            "(6351, 366, -4418)",
                            "(6224, 356, -4436)",
                            "(6278, 360, -4599)"
                        },
                        Price = 100,
                        Timeout = 30
                    }
                }
            };
            return manager;
        }

        [HookMethod("Loaded")]
        internal void Loaded()
        {
            if (Interface.Oxide.DataFileSystem.ExistsDatafile("WarpManager"))
                _warpManager = Interface.Oxide.DataFileSystem.ReadObject<WarpManager>("WarpManager");
            else
                Interface.Oxide.DataFileSystem.WriteObject("WarpManager", _warpManager = TryDefault(), true);
        }

        [ChatCommand("t")]
        private void cmd_t(NetUser netuser, string command, string[] args)
        {
            Puts($"({netuser.playerClient.controllable.transform.position.x}, {netuser.playerClient.controllable.transform.position.y}, {netuser.playerClient.controllable.transform.position.z}");
        }

        [ChatCommand("w")]
        private void CmdWarp(NetUser netuser, string command, string[] args)
        {
            if (args.Length == 0)
            {
                Broadcast.Message(netuser, "[color#F142C2]Доступные варпы:", _warpManager.Prefix);
                _warpManager.AllWarps.ForEach(warp =>
                {
                    Broadcast.Message(netuser,
                        $"[color#fff123]/w [color#ffffff]{warp.Name}[color#fff123] телепортация [color#00ff00]100$ [color#fff123]Время телепортации [color#00ff00]30 сек",
                        _warpManager.Prefix);
                });
                return;
            }

            var findWarp = _warpManager.AllWarps.Find(warp => warp.Name.ToLower() == args[0]);
            if (findWarp == null)
            {
                Broadcast.Message(netuser, $"[color##fff123]Варпа [color#ffffff] {args[0]}[color##fff123] не существует", _warpManager.Prefix);
                return;
            }

            if (findWarp.Price > 0 && !netuser.admin)
            {
                var economy = Economy.Get(netuser.userID);
                if (economy == null) return;
                if (economy.Balance < findWarp.Price)
                {
                    Broadcast.Message(netuser,
                        $"[color#ff0000]Вам не хватает [color#00ff00]{findWarp.Price - economy.Balance}{Economy.CurrencySign} [color#ff0000]для телепортации",
                        _warpManager.Prefix);
                    return;
                }

                economy.Balance -= findWarp.Price;
            }

            if (findWarp.Timeout > 0 && !netuser.admin)
            {
                Broadcast.Message(netuser, $"[color#ffff00]Телепортация на варп[color##fff123] {args[0].ToLower()}[color#ffff00] через [color##fff123] {findWarp.Timeout}[color#ffff00] секунд",
                    _warpManager.Prefix);
                timer.Once(float.Parse(findWarp.Timeout.ToString()), () => { TeleportToWarp(findWarp, netuser); });
                return;
            }

            TeleportToWarp(findWarp, netuser);
        }

        private void TeleportToWarp(NewWarp warp, NetUser user)
        {
            if (warp.PositionList == null || warp.PositionList.Count <= 0) return;
            var randomwarp = Random.Range(0, warp.PositionList.Count);
            if (user == null) return;
            var originalPos = user.playerClient.controllable.character.transform.position;
			RustExtended.Helper.TeleportTo(user, StringToVector3(warp.PositionList.ElementAt(randomwarp)));
            Broadcast.Message(user, "Телепортация прошла успешно [ -100$ ]", _warpManager.Prefix);
        }

        public static Vector3 StringToVector3(string sVector)
        {
            if (sVector.StartsWith("(") && sVector.EndsWith(")")) sVector = sVector.Substring(1, sVector.Length - 2);
            var sArray = sVector.Split(',');
            var result = new Vector3(
                float.Parse(sArray[0]),
                float.Parse(sArray[1]),
                float.Parse(sArray[2]));
            return result;
        }
    }
}