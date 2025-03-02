using System;
using System.Runtime.CompilerServices;
using HarmonyLib;
using Il2Cpp;

namespace EnhancedExperienceBar.Hooks
{
	// Token: 0x0200000A RID: 10
	[HarmonyPatch(typeof(UIWindowPanel), "Start")]
	public class UIPanelHooks
	{
		// Token: 0x06000013 RID: 19 RVA: 0x000022CF File Offset: 0x000004CF
		[NullableContext(1)]
		private static void Postfix(UIWindowPanel __instance)
		{
			if (__instance.name == "Panel_XpBar")
			{
				BarEnhancer.OnExperienceBarReady(__instance);
			}
		}
	}
}
