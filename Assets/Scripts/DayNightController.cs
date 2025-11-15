using UnityEngine;
using UnityEngine.UI;

public class DayNightPanel : MonoBehaviour
{
    public Image panel; // assign your UI Panel here
    public float dayLengthInSeconds = 60f; // 1 min = full day cycle
    private float time; // goes from 0 -> 1 (day cycle progress)

    void Update()
    {
        // Move time forward smoothly
        time += Time.deltaTime / dayLengthInSeconds;
        if (time > 1f) time = 0f;

        UpdatePanel();
    }

    void UpdatePanel()
    {
        // Simple color transitions (Day -> Sunset -> Night -> Morning)
        Color dayColor = new Color(1f, 1f, 1f, 0f);      // transparent (day)
        Color sunsetColor = new Color(1f, 0.5f, 0f, 0.2f); // light orange tint
        Color nightColor = new Color(0f, 0f, 0.2f, 0.6f); // dark blue tint

        Color currentColor;

        if (time < 0.25f)          // Morning → Day
            currentColor = Color.Lerp(nightColor, dayColor, time / 0.25f);
        else if (time < 0.5f)      // Day → Sunset
            currentColor = Color.Lerp(dayColor, sunsetColor, (time - 0.25f) / 0.25f);
        else if (time < 0.75f)     // Sunset → Night
            currentColor = Color.Lerp(sunsetColor, nightColor, (time - 0.5f) / 0.25f);
        else                       // Night → Morning
            currentColor = Color.Lerp(nightColor, dayColor, (time - 0.75f) / 0.25f);

        panel.color = currentColor;
    }
}
