using System;
using RustBuster2016.API;
using UnityEngine;

namespace EasyMenu
{
	public class EasyMenu : RustBusterPlugin
	{
		public GameObject Load;

		public bool On = true;

		public override string Name
		{
			get
			{
				return "IziMenu";
			}
		}

		public override string Author
		{
			get
			{
				return "KichDM/Trectar";
			}
		}

		public override Version Version
		{
			get
			{
				return new Version("1.0");
			}
		}

		public override void DeInitialize()
		{
			if (Load != null)
			{
				UnityEngine.Object.Destroy(Load);
			}
		}

		public override void Initialize()
		{
			Load = new GameObject();
			Load.AddComponent<EasyMenu_GUI>();
			UnityEngine.Object.DontDestroyOnLoad(Load);
		}
	}
}
