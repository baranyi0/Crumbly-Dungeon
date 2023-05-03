using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetLocation : MonoBehaviour
{
    [SerializeField] GenerateMap gen;
    void Start()
    {
        this.transform.position = new Vector3(0, 0, gen.length);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
