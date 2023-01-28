using System;
using UnityEngine;

// Token: 0x02000172 RID: 370
public class ControllerClass : global::UnityEngine.ScriptableObject
{
	// Token: 0x06000A37 RID: 2615 RVA: 0x00029E70 File Offset: 0x00028070
	public ControllerClass()
	{
	}

	// Token: 0x17000288 RID: 648
	// (get) Token: 0x06000A38 RID: 2616 RVA: 0x00029E84 File Offset: 0x00028084
	internal string npcName
	{
		get
		{
			return (!string.IsNullOrEmpty(this._npcName)) ? this._npcName : base.name;
		}
	}

	// Token: 0x17000289 RID: 649
	// (get) Token: 0x06000A39 RID: 2617 RVA: 0x00029EA8 File Offset: 0x000280A8
	internal bool root
	{
		get
		{
			return (this.runtime & global::ControllerClass.Configuration.DynamicFreeVessel) == global::ControllerClass.Configuration.DynamicRoot;
		}
	}

	// Token: 0x1700028A RID: 650
	// (get) Token: 0x06000A3A RID: 2618 RVA: 0x00029EB8 File Offset: 0x000280B8
	internal bool vessel
	{
		get
		{
			return (this.runtime & global::ControllerClass.Configuration.DynamicFreeVessel) != global::ControllerClass.Configuration.DynamicRoot;
		}
	}

	// Token: 0x1700028B RID: 651
	// (get) Token: 0x06000A3B RID: 2619 RVA: 0x00029EC8 File Offset: 0x000280C8
	internal bool staticGroup
	{
		get
		{
			return (this.runtime & global::ControllerClass.Configuration.StaticRoot) == global::ControllerClass.Configuration.StaticRoot;
		}
	}

	// Token: 0x1700028C RID: 652
	// (get) Token: 0x06000A3C RID: 2620 RVA: 0x00029ED8 File Offset: 0x000280D8
	internal bool vesselStandalone
	{
		get
		{
			return (this.runtime & global::ControllerClass.Configuration.DynamicFreeVessel) == global::ControllerClass.Configuration.DynamicStandaloneVessel;
		}
	}

	// Token: 0x1700028D RID: 653
	// (get) Token: 0x06000A3D RID: 2621 RVA: 0x00029EE8 File Offset: 0x000280E8
	internal bool vesselDependant
	{
		get
		{
			return (this.runtime & global::ControllerClass.Configuration.DynamicFreeVessel) == global::ControllerClass.Configuration.DynamicDependantVessel;
		}
	}

	// Token: 0x1700028E RID: 654
	// (get) Token: 0x06000A3E RID: 2622 RVA: 0x00029EF8 File Offset: 0x000280F8
	internal bool vesselFree
	{
		get
		{
			return (this.runtime & global::ControllerClass.Configuration.DynamicFreeVessel) == global::ControllerClass.Configuration.DynamicFreeVessel;
		}
	}

	// Token: 0x06000A3F RID: 2623 RVA: 0x00029F08 File Offset: 0x00028108
	internal string GetClassName(bool player, bool local)
	{
		return (this.classNames != null) ? this.classNames.GetClassName(player, local) : null;
	}

	// Token: 0x06000A40 RID: 2624 RVA: 0x00029F28 File Offset: 0x00028128
	internal bool GetClassName(bool player, bool local, out string className)
	{
		string className2;
		className = (className2 = this.GetClassName(player, local));
		return !object.ReferenceEquals(className2, null);
	}

	// Token: 0x06000A41 RID: 2625 RVA: 0x00029F4C File Offset: 0x0002814C
	internal bool DefinesClass(bool player, bool local)
	{
		return !object.ReferenceEquals(this.GetClassName(player, local), null);
	}

	// Token: 0x06000A42 RID: 2626 RVA: 0x00029F60 File Offset: 0x00028160
	internal bool DefinesClass(bool player)
	{
		return !object.ReferenceEquals(this.GetClassName(player, false) ?? this.GetClassName(player, true), null);
	}

	// Token: 0x1700028F RID: 655
	// (get) Token: 0x06000A43 RID: 2627 RVA: 0x00029F90 File Offset: 0x00028190
	internal string unassignedClassName
	{
		get
		{
			return this.classNames.unassignedClassName;
		}
	}

	// Token: 0x04000771 RID: 1905
	private const global::ControllerClass.Configuration kDriverMask = global::ControllerClass.Configuration.DynamicFreeVessel;

	// Token: 0x04000772 RID: 1906
	private const global::ControllerClass.Configuration kStaticMask = global::ControllerClass.Configuration.StaticRoot;

	// Token: 0x04000773 RID: 1907
	private const global::ControllerClass.Configuration kDriver_Root = global::ControllerClass.Configuration.DynamicRoot;

	// Token: 0x04000774 RID: 1908
	private const global::ControllerClass.Configuration kDriver_StandaloneVessel = global::ControllerClass.Configuration.DynamicStandaloneVessel;

	// Token: 0x04000775 RID: 1909
	private const global::ControllerClass.Configuration kDriver_DependantVessel = global::ControllerClass.Configuration.DynamicDependantVessel;

	// Token: 0x04000776 RID: 1910
	private const global::ControllerClass.Configuration kDriver_FreeVessel = global::ControllerClass.Configuration.DynamicFreeVessel;

	// Token: 0x04000777 RID: 1911
	private const global::ControllerClass.Configuration kStatic_Static = global::ControllerClass.Configuration.StaticRoot;

	// Token: 0x04000778 RID: 1912
	private const global::ControllerClass.Configuration kStatic_Dynamic = global::ControllerClass.Configuration.DynamicRoot;

	// Token: 0x04000779 RID: 1913
	[global::UnityEngine.SerializeField]
	private string _npcName = string.Empty;

	// Token: 0x0400077A RID: 1914
	[global::UnityEngine.SerializeField]
	private global::ControllerClassesConfigurations classNames;

	// Token: 0x0400077B RID: 1915
	[global::UnityEngine.SerializeField]
	private global::ControllerClass.Configuration runtime;

	// Token: 0x02000173 RID: 371
	public enum Configuration
	{
		// Token: 0x0400077D RID: 1917
		DynamicRoot,
		// Token: 0x0400077E RID: 1918
		DynamicStandaloneVessel,
		// Token: 0x0400077F RID: 1919
		DynamicDependantVessel,
		// Token: 0x04000780 RID: 1920
		DynamicFreeVessel,
		// Token: 0x04000781 RID: 1921
		StaticRoot,
		// Token: 0x04000782 RID: 1922
		StaticStandaloneVessel,
		// Token: 0x04000783 RID: 1923
		StaticDependantVessel,
		// Token: 0x04000784 RID: 1924
		StaticFreeVessel
	}

	// Token: 0x02000174 RID: 372
	public struct Merge
	{
		// Token: 0x06000A44 RID: 2628 RVA: 0x00029FA0 File Offset: 0x000281A0
		public bool Add(global::ControllerClass @class)
		{
			if (!@class)
			{
				return false;
			}
			global::ControllerClass.Merge.Instance instance;
			instance.hash = @class.GetHashCode();
			instance.value = @class;
			if (this.length == 1)
			{
				if (this.hash == instance.hash && object.ReferenceEquals(this.first.value, instance.value))
				{
					return false;
				}
			}
			else if (this.length > 1 && (this.hash & instance.hash) == instance.hash)
			{
				for (int i = 0; i < this.length; i++)
				{
					if (this.classes[i].hash == this.hash && object.ReferenceEquals(this.classes[i].value, instance.value))
					{
						return false;
					}
				}
			}
			this.hash |= instance.hash;
			int num = this.length++;
			if (num == 0)
			{
				this.first = instance;
			}
			else if (num == 1)
			{
				this.classes = new global::ControllerClass.Merge.Instance[]
				{
					this.first,
					instance
				};
				this.first.hash = 0;
				this.first.value = null;
			}
			else
			{
				global::System.Array.Resize<global::ControllerClass.Merge.Instance>(ref this.classes, this.length);
				this.classes[num] = instance;
			}
			return true;
		}

		// Token: 0x17000290 RID: 656
		// (get) Token: 0x06000A45 RID: 2629 RVA: 0x0002A138 File Offset: 0x00028338
		public bool any
		{
			get
			{
				return this.length > 0;
			}
		}

		// Token: 0x17000291 RID: 657
		// (get) Token: 0x06000A46 RID: 2630 RVA: 0x0002A144 File Offset: 0x00028344
		public bool root
		{
			get
			{
				if (this.length <= 0)
				{
					return false;
				}
				if (this.length == 1)
				{
					return this.first.value.root;
				}
				for (int i = 0; i < this.length; i++)
				{
					if (!this.classes[i].value.root)
					{
						return false;
					}
				}
				return true;
			}
		}

		// Token: 0x17000292 RID: 658
		// (get) Token: 0x06000A47 RID: 2631 RVA: 0x0002A1B4 File Offset: 0x000283B4
		public bool vessel
		{
			get
			{
				if (this.length <= 0)
				{
					return false;
				}
				if (this.length == 1)
				{
					return this.first.value.vessel;
				}
				for (int i = 0; i < this.length; i++)
				{
					if (!this.classes[i].value.vessel)
					{
						return false;
					}
				}
				return true;
			}
		}

		// Token: 0x17000293 RID: 659
		// (get) Token: 0x06000A48 RID: 2632 RVA: 0x0002A224 File Offset: 0x00028424
		public bool staticGroup
		{
			get
			{
				if (this.length <= 0)
				{
					return false;
				}
				if (this.length == 1)
				{
					return this.first.value.staticGroup;
				}
				for (int i = 0; i < this.length; i++)
				{
					if (!this.classes[i].value.staticGroup)
					{
						return false;
					}
				}
				return true;
			}
		}

		// Token: 0x17000294 RID: 660
		// (get) Token: 0x06000A49 RID: 2633 RVA: 0x0002A294 File Offset: 0x00028494
		public bool vesselStandalone
		{
			get
			{
				if (this.length <= 0)
				{
					return false;
				}
				if (this.length == 1)
				{
					return this.first.value.vesselStandalone;
				}
				for (int i = 0; i < this.length; i++)
				{
					if (!this.classes[i].value.vesselStandalone)
					{
						return false;
					}
				}
				return true;
			}
		}

		// Token: 0x17000295 RID: 661
		// (get) Token: 0x06000A4A RID: 2634 RVA: 0x0002A304 File Offset: 0x00028504
		public bool vesselDependant
		{
			get
			{
				if (this.length <= 0)
				{
					return false;
				}
				if (this.length == 1)
				{
					return this.first.value.vesselDependant;
				}
				for (int i = 0; i < this.length; i++)
				{
					if (!this.classes[i].value.vesselDependant)
					{
						return false;
					}
				}
				return true;
			}
		}

		// Token: 0x17000296 RID: 662
		// (get) Token: 0x06000A4B RID: 2635 RVA: 0x0002A374 File Offset: 0x00028574
		public bool vesselFree
		{
			get
			{
				if (this.length <= 0)
				{
					return false;
				}
				if (this.length == 1)
				{
					return this.first.value.vesselFree;
				}
				for (int i = 0; i < this.length; i++)
				{
					if (!this.classes[i].value.vesselFree)
					{
						return false;
					}
				}
				return true;
			}
		}

		// Token: 0x17000297 RID: 663
		public bool this[bool player, bool local]
		{
			get
			{
				if (this.length <= 0)
				{
					return false;
				}
				if (this.length == 1)
				{
					return this.first.value.DefinesClass(player, local);
				}
				for (int i = 0; i < this.length; i++)
				{
					if (!this.classes[i].value.DefinesClass(player, local))
					{
						return false;
					}
				}
				return true;
			}
		}

		// Token: 0x17000298 RID: 664
		public bool this[bool player]
		{
			get
			{
				if (this.length <= 0)
				{
					return false;
				}
				if (this.length == 1)
				{
					return this.first.value.DefinesClass(player);
				}
				for (int i = 0; i < this.length; i++)
				{
					if (!this.classes[i].value.DefinesClass(player))
					{
						return false;
					}
				}
				return true;
			}
		}

		// Token: 0x17000299 RID: 665
		// (get) Token: 0x06000A4E RID: 2638 RVA: 0x0002A4C8 File Offset: 0x000286C8
		public bool multiple
		{
			get
			{
				return this.length > 1;
			}
		}

		// Token: 0x04000785 RID: 1925
		private int length;

		// Token: 0x04000786 RID: 1926
		private int hash;

		// Token: 0x04000787 RID: 1927
		private global::ControllerClass.Merge.Instance first;

		// Token: 0x04000788 RID: 1928
		private global::ControllerClass.Merge.Instance[] classes;

		// Token: 0x02000175 RID: 373
		private struct Instance
		{
			// Token: 0x04000789 RID: 1929
			public int hash;

			// Token: 0x0400078A RID: 1930
			public global::ControllerClass value;
		}
	}
}
