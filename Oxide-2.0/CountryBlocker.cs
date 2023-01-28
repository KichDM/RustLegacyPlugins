using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Oxide.Plugins
{
    [Info("CountryBlocker", "Jacellen+Hostfun", "1.0")]
    internal class CountryBlocker : RustLegacyPlugin
    {
        private readonly List<string> WhiteList = new List<string>()
        {
            "127.0.0.1",
			"127.0.0.1",
			"127.0.0.1",
            "127.0.0.1"
        };

        private const string CountryList = "RU,UA,BY,UZ,MD,KG,AM,AZ,LV,PL,CZ,TR,SK,IR,HU,GE,EE,ME,RS,IL,IT"; // БЕЗ ПРОБЕЛОВ! Инструкция и список стран в группе хостинга хостфан - vk.com/topic-170503653_46498645

        void OnUserApprove(ClientConnection connection, uLink.NetworkPlayerApproval approval)
        {
            if (!WhiteList.Contains(approval.ipAddress))
            {
                webrequest.EnqueueGet($"http://ip-api.com/json/{approval.ipAddress}", (code, response) => GetCallback(code, response, connection), this, null, 200f);
            }
        }

        private void GetCallback(int code, string response, ClientConnection connection)
        {
            if (response == null || code != 200)
            {
                connection.netUser.Kick(NetError.ApprovalDenied, true);
                return;
            }
            var jsonresponse = JsonConvert.DeserializeObject<IpInfo>(response);
            if (jsonresponse.status != "success") return;
            if (!string.IsNullOrEmpty(CountryList.Split(',')
                .FirstOrDefault(select => @select == jsonresponse.countryCode))) return;
            rust.SendChatMessage(connection.netUser, "CountryBlocker", $" Country  {jsonresponse.countryCode} blocked. vk.com/host_fun");
            connection.netUser.Kick(NetError.ApprovalDenied, true);
        }

        public class IpInfo
        {
            public string status { get; set; }
            public string countryCode { get; set; }
        }
    }
}