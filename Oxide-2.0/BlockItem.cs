using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Oxide.Core;
using Oxide.Core.Plugins;
using RustExtended;
// Редактировать плагин нельзя! Настройки делать в конфиге, в папке Data.
namespace Oxide.Plugins
{
    [Info("BlockItem", "Jacellen", 1.0)]
    internal class BlockItem : RustLegacyPlugin
    {
        private const string Prefix = "Блок";
        private const string MsgTimeLeft = "[COLOR#FFFFFF]До разблокировки[COLOR#C8FE2E] %ITEMNAME% [COLOR#FFFFFF]осталось [COLOR#C8FE2E]%TIME%";
        private const string MsgAllUnlocked = "Все предметы уже разблокированы";
        private List<BlockedItem> _allBlocked = new List<BlockedItem>();

        private List<BlockedItem> TryDefault()
        {
            var newlist = new List<BlockedItem>
            {
                new BlockedItem
                {
                    Name = "M4",
                    DateTime = DateTime.Now.ToString("g")
                },
                new BlockedItem
                {
                    Name = "Explosive Charge",
                    DateTime = DateTime.Now.ToString("g")
                }
            };
            return newlist;
        }

        public class BlockedItem
        {
            [JsonProperty("Название предмета")] 
            public string Name;

            [JsonProperty("Время окончание блокировки (Месяц/День/Год Часы:Минуты)")]
            public string DateTime;
        }

        private void Loaded()
        {
            if (Interface.Oxide.DataFileSystem.ExistsDatafile("BlockConfig"))
            {
                _allBlocked = Interface.Oxide.DataFileSystem.ReadObject<List<BlockedItem>>("BlockConfig");
                return;
            }

            Interface.Oxide.DataFileSystem.WriteObject("BlockConfig", _allBlocked = TryDefault(), true);
        }
        
        [ChatCommand("wipeblock")]
        private void CMDWipeBlock(NetUser netuser, string command, string[] args)
        {
            if (_allBlocked.Count > 0)
            {
                foreach (BlockedItem item in _allBlocked)
                {
                    DateTime blockDate;
                    if (DateTime.TryParse(item.DateTime, out blockDate))
                    {
                        if (DateTime.Now < blockDate)
                        {
                            string text = MsgTimeLeft.Replace("%ITEMNAME%", item.Name);

                            var timeLeft = TimeSpan.FromSeconds((blockDate - DateTime.Now).TotalSeconds);

                            if (timeLeft.TotalDays >= 1)
                                text = text.Replace("%TIME%", $"{timeLeft.Days:F0}д {timeLeft.Hours:F0}ч {timeLeft.Minutes:D2}м {timeLeft.Seconds:D2} с");
                            else if (timeLeft.TotalHours >= 1)
                                text = text.Replace("%TIME%", $"{timeLeft.Hours:F0}ч {timeLeft.Minutes:D2}м {timeLeft.Seconds:D2} с");
                            else if (timeLeft.TotalMinutes >= 1)
                                text = text.Replace("%TIME%", $"{timeLeft.Minutes}м {timeLeft.Seconds:D2}с");
                            else text = text.Replace("%TIME%", $"{timeLeft.Seconds:D2}с");

                            rust.SendChatMessage(netuser, Prefix, text);
                        }
                    }
                }
            }
            else
            {
                rust.SendChatMessage(netuser, Prefix, MsgAllUnlocked);
            }
        }

        [HookMethod("OnBeltUse")]
        public object BeltDetector(PlayerInventory inv, IInventoryItem inventoryItem)
        {
            var netuser = inventoryItem.controllable.netUser;
            if (netuser == null || netuser.admin) return null;
            if (_allBlocked == null || _allBlocked.Count <= 0) return null;
            var selectblock = _allBlocked.FirstOrDefault(item => item.Name == inventoryItem.datablock.name);
            if (selectblock == null) return null;
            DateTime datetime;
            var isParse = DateTime.TryParse(selectblock.DateTime, out datetime);
            if (!isParse) return null;
            if (DateTime.Now > datetime) return null;

            var kitTime = TimeSpan.FromSeconds((datetime - DateTime.Now).TotalSeconds);
            var msgTimeLeftnew = MsgTimeLeft.Replace("%ITEMNAME%", inventoryItem.datablock.name);
            if (kitTime.TotalDays >= 1)
            {
                msgTimeLeftnew = msgTimeLeftnew.Replace("%TIME%",
                    $"{kitTime.TotalDays:F0}д {kitTime.TotalHours:F0}ч {kitTime.Minutes:D2}м {kitTime.Seconds:D2} с");
            }
            else if (kitTime.TotalHours >= 1)
                msgTimeLeftnew = msgTimeLeftnew.Replace("%TIME%",
                    $"{kitTime.TotalHours:F0}ч {kitTime.Minutes:D2}м {kitTime.Seconds:D2} с");
            else if (kitTime.TotalMinutes >= 1)
                msgTimeLeftnew = msgTimeLeftnew.Replace("%TIME%",
                    $"{kitTime.Minutes}м {kitTime.Seconds:D2}с");
            else msgTimeLeftnew = msgTimeLeftnew.Replace("%TIME%", $"{kitTime.Seconds:D2}с");
            Broadcast.Message(netuser, msgTimeLeftnew, Prefix);
            return true;
        }
    }
}