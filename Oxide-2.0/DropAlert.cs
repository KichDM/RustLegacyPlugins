using System.Collections.Generic;
using System;
using System.Reflection;
using System.Data;
using Oxide.Core;
using RustProto;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Oxide.Plugins
{
    [Info("DropAlert", "Ates", 0.2)]
    [Description("️Aviso de Caida de Airdrop️")]

    class DropAlert : RustLegacyPlugin
    {
        double posicion = 0;
        void OnAirdrop(Vector3 position)
        {
            foreach (NetUser _netUser in rust.GetAllNetUsers())
            {
                posicion = Math.Round(Vector3.Distance(_netUser.playerClient.lastKnownPosition, position));
                rust.Notice(_netUser, string.Format("✈️Airdrop en Camino✈ ({0} Metros)", posicion.ToString()));
            }
        }
    }
}