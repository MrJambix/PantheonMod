using System;
using System.Runtime.CompilerServices;
using EnhancedExperienceBar.Models;
using Il2Cpp;
using Il2CppTMPro;
using UnityEngine;

namespace EnhancedExperienceBar
{
	// Token: 0x02000005 RID: 5
	[NullableContext(1)]
	[Nullable(0)]
	public static class BarEnhancer
	{
		// Token: 0x06000005 RID: 5 RVA: 0x00002090 File Offset: 0x00000290
		public static void OnLocalPlayerReady(EntityPlayerGameObject entityPlayerGameObject)
		{
			Experience.Logic experience = entityPlayerGameObject.Experience;
			BarEnhancer.OnExperienceChanged(new PlayerExperience((double)experience.Level, (double)experience.CalculateCurrentExperienceIntoLevel(), (double)experience.CalculateExperienceRequiredToNextLevel(), experience.CalculatePercentThroughCurrentLevel()));
		}

		// Token: 0x06000006 RID: 6 RVA: 0x000020CC File Offset: 0x000002CC
		public static void OnExperienceBarReady(UIWindowPanel xpWindow)
		{
			RectTransform component = xpWindow.GetComponent<RectTransform>();
			component.sizeDelta = new Vector2(component.sizeDelta.x, component.sizeDelta.y + 10f);
			GameObject gameObject = new GameObject("Test");
			gameObject.transform.SetParent(xpWindow.transform);
			TextMeshProUGUI textMeshProUGUI = gameObject.AddComponent<TextMeshProUGUI>();
			textMeshProUGUI.text = "0 / 0";
			textMeshProUGUI.fontSize = 16f;
			textMeshProUGUI.alignment = 514;
			RectTransform component2 = gameObject.GetComponent<RectTransform>();
			component2.sizeDelta = new Vector2(500f, 20f);
			component2.anchoredPosition = new Vector2(0f, 0f);
			BarEnhancer._text = textMeshProUGUI;
		}

		// Token: 0x06000007 RID: 7 RVA: 0x0000217E File Offset: 0x0000037E
		public static void OnExperienceChanged(PlayerExperience playerExperience)
		{
			if (BarEnhancer._text == null)
			{
				return;
			}
			BarEnhancer._text.text = BarEnhancer.CreateText(playerExperience);
		}

		// Token: 0x06000008 RID: 8 RVA: 0x000021A0 File Offset: 0x000003A0
		private static string CreateText(PlayerExperience playerExperience)
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(7, 3);
			defaultInterpolatedStringHandler.AppendFormatted<double>(playerExperience.Current, "N0");
			defaultInterpolatedStringHandler.AppendLiteral(" / ");
			defaultInterpolatedStringHandler.AppendFormatted<double>(playerExperience.ToNextLevel, "N0");
			defaultInterpolatedStringHandler.AppendLiteral(" (");
			defaultInterpolatedStringHandler.AppendFormatted<float>(playerExperience.ExperiencePercentage * 100f, "F");
			defaultInterpolatedStringHandler.AppendLiteral("%)");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x04000003 RID: 3
		[Nullable(2)]
		private static TextMeshProUGUI _text;
	}
}
