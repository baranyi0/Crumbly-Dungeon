using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableText : MonoBehaviour
{
    [SerializeField] GameObject g;
    public void Ena()
    {
        g.SetActive(true);
    }
}
