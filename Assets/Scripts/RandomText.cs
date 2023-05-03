using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomText : MonoBehaviour
{
    [SerializeField] string[] texts;
    [SerializeField] Text text;
    void Start()
    {
        text.text = texts[Random.Range(0, texts.Length)];
        Destroy(this.gameObject, 4f);
    }
}
