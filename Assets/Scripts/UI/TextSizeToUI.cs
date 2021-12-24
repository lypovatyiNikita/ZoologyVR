using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextSizeToUI : MonoBehaviour
{
    public TMPro.TextMeshProUGUI text;
    public RectTransform rect;
    public float margin = 0f;

    void Update()
    {
        rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, text.GetPreferredValues().x + margin);
    }
}
