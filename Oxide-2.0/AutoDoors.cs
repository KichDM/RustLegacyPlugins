using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace Oxide.Plugins
{
    [Info("AutoDoors", "Pilatus", "1.0.0")]
    [Description("AutoDoors para RustLegacy")]

    class AutoDoors : RustLegacyPlugin
    {
        private static MethodInfo togglestateserver;
        private static FieldInfo doorstate;
        Timer ctimer;
        float distanceClose = 3f;

        void Loaded()
        {
            foreach (MethodInfo methodinfo in typeof(BasicDoor).GetMethods((BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance | BindingFlags.NonPublic)))
            {
                if (methodinfo.Name == "ToggleStateServer")
                {
                    if (methodinfo.GetParameters().Length == 3)
                    {
                        togglestateserver = methodinfo;
                    }
                }
            }
            doorstate = typeof(BasicDoor).GetField("state", (BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance | BindingFlags.NonPublic));
        }

        void OnDoorToggle(BasicDoor door, ulong timestamp, Controllable controllable)
        {
            string wasDoorState = doorstate.GetValue(door).ToString();
            if (wasDoorState == "Opened") return;
            bool change = false;
            ctimer = timer.Repeat(1f, 0, () => {
                if(controllable.netUser == null) { ctimer.Destroy(); }
                if (Vector3.Distance(door.transform.position, controllable.netUser.playerClient.lastKnownPosition) > distanceClose) { ChangeState(controllable.netUser.playerClient, door, wasDoorState); ctimer.Destroy(); }
            });

        }

        void ChangeState(PlayerClient player, BasicDoor door, string action)
        {
            if (action == "Closed" && doorstate.GetValue(door).ToString() == "Opened")
            {
                togglestateserver.Invoke(door, new object[] { player.lastKnownPosition, NetCull.timeInMillis, null });
            }
        }
    }
}