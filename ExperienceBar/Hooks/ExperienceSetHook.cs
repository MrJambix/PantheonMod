using System;
using System.Runtime.CompilerServices;
using EnhancedExperienceBar.Models;
using HarmonyLib;
using Il2Cpp;

namespace EnhancedExperienceBar.Hooks
{
	// Token: 0x02000009 RID: 9
	[HarmonyPatch(typeof(Experience.Logic), "SetExperience")]
	public class ExperienceSetHook
	{
		// Token: 0x06000011 RID: 17 RVA: 0x000022A0 File Offset: 0x000004A0
		[NullableContext(1)]
		private static void Postfix(Experience.Logic __instance)
		{
			BarEnhancer.OnExperienceChanged(new PlayerExperience((double)__instance.Level, (double)__instance.CalculateCurrentExperienceIntoLevel(), (double)__instance.CalculateExperienceRequiredToNextLevel(), __instance.CalculatePercentThroughCurrentLevel()));
		}
	}
}
