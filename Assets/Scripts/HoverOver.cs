using UnityEngine;
using UnityEngine.UI;
public class HoverOver : MonoBehaviour
{
    Text txt;
    Color defaultColor;
    void Start()
    {
        txt = GetComponent<Text>();
        defaultColor = txt.color;
    }
    public void HoverOff()
    {
        txt.color = defaultColor;
    }

    public void HoverOn()
    {
        txt.color = Color.white;
    }
}