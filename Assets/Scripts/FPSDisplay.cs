using UnityEngine;

public class FPSDisplay : MonoBehaviour
{
    private const float V = 0.1f;
    private const float V1 = 1.0f;
    GUIStyle style;
    Rect rect;
    float deltaTime = 0.0f;
    int w, h;
    float msec;
    float fps;
    string text;

    private void Start()
    {
        style = new GUIStyle();
        rect = new Rect(0, 0, w, h * 2 / 100);
        w = Screen.width;
        h = Screen.height;
        style.alignment = TextAnchor.UpperLeft;
        style.fontSize = h * 4 / 100;
        style.normal.textColor = new Color(255f, 0f, 0f, 1.0f);
    }
    void Update()
    {
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * V;
    }
    void OnGUI()
    {
        msec = deltaTime * 1000.0f;
        fps = V1 / deltaTime;
        text = $"{msec:0.0} ms ({fps:0.} fps)";
        GUI.Label(rect, text, style);
    }
}