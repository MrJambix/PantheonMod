using System;
using System.Runtime.CompilerServices;
using HarmonyLib;
using Il2Cpp;

namespace EnhancedExperienceBar.Hooks
{
	// Token: 0x02000008 RID: 8
	[HarmonyPatch(typeof(EntityPlayerGameObject), "NetworkStart")]
	public class PlayerNetworkStart
	{
		// Token: 0x0600000F RID: 15 RVA: 0x0000226A File Offset: 0x0000046A
		[NullableContext(1)]
		private static void Postfix(EntityPlayerGameObject __instance)
		{
			if (__instance.NetworkId.Value == 1U)
			{
				return;
			}
			if (__instance.NetworkId.Value == EntityPlayerGameObject.LocalPlayerId.Value)
			{
				BarEnhancer.OnLocalPlayerReady(__instance);
			}
		}
	}
}
