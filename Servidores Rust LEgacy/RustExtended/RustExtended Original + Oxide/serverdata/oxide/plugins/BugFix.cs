using System.Collections.Generic;
using System;
using System.Reflection;
using System.Data;
using UnityEngine;
using Oxide.Core;
using Oxide.Core.Plugins;
using RustProto;
using System.Linq;
using System.Collections.Generic;
using Oxide.Core.Libraries;
#pragma warning disable 0618 // отключение предупреждений об устаревших методах

namespace Oxide.Plugins
{
    [Info("BugFix", "XBOCT", "1.2.2")]
	[Description("Фикс на подпирание дверей и постановку текстур под себя")]
    class BugFix : RustLegacyPlugin
    {
		public double distFix {get; set;} = 0;
		void OnItemDeployed(DeployableObject component, IDeployableItem item)
		{
			distFix = Math.Floor(Vector3.Distance(component.transform.position, item.character.playerClient.lastKnownPosition));
			if(component.gameObject.name == "Barricade_Fence_Deployable(Clone)"||component.gameObject.name == "Furnace(Clone)")
			if(distFix<=1)
			{
				SendReply(item.character.playerClient.netUser, "Ставить под себя текстуры [color#FF0000]запрещено.");
				item.character.GetComponent<Inventory>().AddItemAmount(item.datablock, 1);
				timer.Once(0.01f, () => NetCull.Destroy(component.gameObject));
			}
			if(component.gameObject.name.Contains("Gateway"))
			{
				Vector3 lastPosition = component.transform.position;
				foreach(Collider collider in Physics.OverlapSphere(lastPosition, 3f))
				{
					if(collider.gameObject.name.Contains("Door"))					
					{
						SendReply(item.character.playerClient.netUser, "Закрывать воротами вход [color#FF0000]запрещено.");
						item.character.GetComponent<Inventory>().AddItemAmount(item.datablock, 0);
						timer.Once(0.01f, () => NetCull.Destroy(component.gameObject));
					}
				}
			}
		}
	}
}