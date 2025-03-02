using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace TheAllKnowingMod
{
    public static class UIManager
    {
        // References for UI elements
        public static Toggle respawnTimerToggle;
        public static TextMeshProUGUI timeToLevelText; // Reference for "Time to Level"

        public static void Initialize()
        {
            // Create a new Canvas for our mod options.
            GameObject canvasGO = new GameObject("ModCanvas");
            Canvas canvas = canvasGO.AddComponent<Canvas>();
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            canvasGO.AddComponent<GraphicRaycaster>();

            // Optional: Scale UI with screen size.
            CanvasScaler scaler = canvasGO.AddComponent<CanvasScaler>();
            scaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
            scaler.referenceResolution = new Vector2(1920, 1080);

            // Create a Panel to hold the options.
            GameObject panelGO = new GameObject("OptionsPanel");
            panelGO.transform.SetParent(canvasGO.transform, false);
            RectTransform panelRT = panelGO.AddComponent<RectTransform>();
            panelRT.sizeDelta = new Vector2(300, 150); // Increased height to fit new text
            panelRT.anchorMin = new Vector2(0, 1);
            panelRT.anchorMax = new Vector2(0, 1);
            panelRT.pivot = new Vector2(0, 1);
            panelRT.anchoredPosition = new Vector2(10, -10);

            Image panelImage = panelGO.AddComponent<Image>();
            panelImage.color = new Color(0, 0, 0, 0.5f); // Semi-transparent background

            // Create a Toggle for the "Respawn Timer" option.
            GameObject toggleGO = new GameObject("RespawnTimerToggle");
            toggleGO.transform.SetParent(panelGO.transform, false);
            RectTransform toggleRT = toggleGO.AddComponent<RectTransform>();
            toggleRT.sizeDelta = new Vector2(20, 20);
            toggleRT.anchorMin = new Vector2(0, 1);
            toggleRT.anchorMax = new Vector2(0, 1);
            toggleRT.pivot = new Vector2(0, 1);
            toggleRT.anchoredPosition = new Vector2(10, -10);

            respawnTimerToggle = toggleGO.AddComponent<Toggle>();

            // Create a background for the toggle.
            GameObject bgGO = new GameObject("Background");
            bgGO.transform.SetParent(toggleGO.transform, false);
            RectTransform bgRT = bgGO.AddComponent<RectTransform>();
            bgRT.anchorMin = Vector2.zero;
            bgRT.anchorMax = Vector2.one;
            bgRT.offsetMin = Vector2.zero;
            bgRT.offsetMax = Vector2.zero;
            Image bgImage = bgGO.AddComponent<Image>();
            bgImage.color = Color.white;
            respawnTimerToggle.targetGraphic = bgImage;

            // Create a checkmark for the toggle.
            GameObject checkmarkGO = new GameObject("Checkmark");
            checkmarkGO.transform.SetParent(bgGO.transform, false);
            RectTransform checkmarkRT = checkmarkGO.AddComponent<RectTransform>();
            checkmarkRT.anchorMin = Vector2.zero;
            checkmarkRT.anchorMax = Vector2.one;
            checkmarkRT.offsetMin = Vector2.zero;
            checkmarkRT.offsetMax = Vector2.zero;
            Image checkmarkImage = checkmarkGO.AddComponent<Image>();
            checkmarkImage.color = Color.green;
            respawnTimerToggle.graphic = checkmarkImage;

            // Assign background to toggle.
            respawnTimerToggle.targetGraphic = bgImage;
            respawnTimerToggle.graphic = checkmarkImage;

            // Set the initial state of the toggle.
            respawnTimerToggle.isOn = false;

            // Create a Label for the toggle.
            GameObject labelGO = new GameObject("Label");
            labelGO.transform.SetParent(panelGO.transform, false);
            RectTransform labelRT = labelGO.AddComponent<RectTransform>();
            labelRT.anchorMin = new Vector2(0, 1);
            labelRT.anchorMax = new Vector2(0, 1);
            labelRT.pivot = new Vector2(0, 1);
            labelRT.anchoredPosition = new Vector2(40, -10);
            labelRT.sizeDelta = new Vector2(200, 30);

            // Use TextMeshProUGUI instead of Text
            TextMeshProUGUI labelText = labelGO.AddComponent<TextMeshProUGUI>();
            labelText.text = "Respawn Timer";
            labelText.fontSize = 14;
            labelText.alignment = TextAlignmentOptions.Left;
            labelText.color = Color.white;

            // 🆕 Create a Label for "Time to Level:"
            GameObject timeToLevelGO = new GameObject("TimeToLevelLabel");
            timeToLevelGO.transform.SetParent(panelGO.transform, false);
            RectTransform timeToLevelRT = timeToLevelGO.AddComponent<RectTransform>();
            timeToLevelRT.anchorMin = new Vector2(0, 1);
            timeToLevelRT.anchorMax = new Vector2(0, 1);
            timeToLevelRT.pivot = new Vector2(0, 1);
            timeToLevelRT.anchoredPosition = new Vector2(10, -50); // Position below the toggle
            timeToLevelRT.sizeDelta = new Vector2(280, 30);

            // 🆕 Add TextMeshProUGUI component for time display
            timeToLevelText = timeToLevelGO.AddComponent<TextMeshProUGUI>();
            timeToLevelText.text = "Time to Level: Calculating...";
            timeToLevelText.fontSize = 14;
            timeToLevelText.alignment = TextAlignmentOptions.Left;
            timeToLevelText.color = Color.white;
        }

        // 🆕 Method to Update the "Time to Level" Text
        public static void UpdateTimeToLevel(string time)
        {
            if (timeToLevelText != null)
            {
                timeToLevelText.text = $"Time to Level: {time}";
            }
        }
    }
}
